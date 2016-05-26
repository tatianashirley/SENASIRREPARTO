using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using wcfServicioIntercambioPago.Logica;
using wcfSeguridad.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;

public partial class PagoCC_wfrmConvenios : System.Web.UI.Page
{
    clsControlEnvios EnvioCC = new clsControlEnvios();
    clsPagoCC PagoCC = new clsPagoCC();
    clsConciliacion Concil = new clsConciliacion();
    clsManejoArchivo Medio = new clsManejoArchivo();
    clsSeguridad Seguridad = new clsSeguridad();
    string mensaje;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 360000;
            HttpContext.Current.Server.ScriptTimeout = 360000;
            //Server.ScriptTimeout = 1800;
            CargarCombos();
        }
        
    }

    private bool RevisarEnvios(string Tipo)
    {
        mensaje=null;
        try
        {
            DataTable Envios = EnvioCC.ObtieneVista((int)Session["idConexion"], "Q", "ObtieneProceso", ddlEntidad.SelectedValue, ddlProceso.SelectedValue
                                     , ddlPeriodo.SelectedItem.ToString(), "", 0, ref mensaje);
            if (Envios.Rows.Count > 0)
            {
                foreach (DataRow r in Envios.Rows)
                {
                    if (Tipo == "Convenios" && r.ItemArray[3].ToString() != "APROBADO")
                    {
                        return false;
                    }
                    if (Tipo == "Consolidar" && r.ItemArray[3].ToString() != "CULMINADO" /*&& r.ItemArray[2].ToString() != "SOLICITUD DE REPOSICIONES - REGULARES"*/)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProceso.SelectedValue == "P")
        {
            pnlPagos.Visible = true;
            pnlConciliaciones.Visible = false;
            pnlReposiciones.Visible = false;
        }
        if (ddlProceso.SelectedValue == "C")
        {
            pnlPagos.Visible = false;
            pnlConciliaciones.Visible = true;
            pnlReposiciones.Visible = false;
        }
        if (ddlProceso.SelectedValue == "R")
        {
            pnlPagos.Visible = false;
            pnlConciliaciones.Visible = false;
            pnlReposiciones.Visible = true;
        }
    }

    #region Convenios

    protected void btnConvenios_Click(object sender, EventArgs e)
    {
        if (ddlProceso.SelectedValue == "P")
        {
            if (RevisarEnvios("Convenios"))
            {
                //hacer todo
                GenerarTransConvenio(ddlEntidad.SelectedValue);
                lblTituloResumen.Visible = true;
                gvResumen.Visible = true;
                btnTransacciones.Visible = true;
            }
            else
            {
                Master.MensajeError("Imposible Generar las transacciones de convenios para " + ddlEntidad.SelectedItem.ToString()
                                + "para el periodo " + ddlPeriodo.SelectedItem.ToString()
                                , "No se puede generar las Transacciones de Convenio en este momento. Estados de los envios no validos");
                btnConvenios.Enabled = false;
            }
        }
        else
        {
            Response.Write("<script>window.alert('Solo se puede generar las transacciones de convenios para el proceso de Pagos');</script>");
        }
    }

    private void GenerarTransConvenio(string Entidad)
    {
        try
        {
            PagoCC.GeneraConvenios(Entidad);
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al intentar generar las transacciones de convenio", ex.Message);
        }
        mensaje = null;
        gvResumen.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ResumenConvenios", Entidad, "", "", "", 0, ref mensaje);
        gvResumen.DataBind();
        Session["Convenios"] = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ConveniosPreliminar", Entidad, "", "", "", 0, ref mensaje);
        gvDetalle.DataSource = Session["Convenios"] as DataTable;
        gvDetalle.DataBind();
        if (mensaje == null)
        {
            Master.MensajeOk("Se generaron las transacciones de Convenio Preliminares");
        }
        else
        {
            Master.MensajeError("Error al intentar generar las transacciones de convenio", mensaje);
            btnTransacciones.Enabled = false;
        }
    }

    protected void btnTransacciones_Click(object sender, EventArgs e)
    {
        lblTituloDetalle.Visible = true;
        lblTituloDetalle.Text += " " + (Session["Convenios"] as DataTable).Rows.Count.ToString() + " casos";
        gvDetalle.Visible = true;
        btnInsertar.Visible = true;
        btnTransacciones.Enabled = false;
    }

    protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetalle.PageIndex = e.NewPageIndex;
        gvDetalle.DataSource = Session["Convenios"] as DataTable;
        gvDetalle.DataBind();
        int x = gvDetalle.PageIndex;
    }

    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable TransConv = Session["Convenios"] as DataTable;
            foreach (DataRow r in TransConv.Rows)
            {
                PagoCC.CambiarEstadoRevision(r.ItemArray[14].ToString(), Convert.ToInt64(r.ItemArray[4].ToString())
                         , Convert.ToInt32(r.ItemArray[5].ToString()), r.ItemArray[6].ToString(), Convert.ToInt64(r.ItemArray[7].ToString())
                         ,r.ItemArray[3].ToString(), r.ItemArray[10].ToString(), Convert.ToInt32(r.ItemArray[8].ToString()), "A",0);
                //ahora generamos el medio con las transacciones de convenio
            }
            DataTable PagosConvenios = EnvioCC.ObtieneVista((int)Session["idConexion"], "Q", "GenerarMedio", ddlEntidad.SelectedValue, "PR"
                                     , ddlPeriodo.SelectedValue, "", 0, ref mensaje);
            DataTable DatosEnvio = EnvioCC.ObtieneVista((int)Session["idConexion"], "Q", "ObtieneEnvio", ddlEntidad.SelectedValue, "PR"
                                 , ddlPeriodo.SelectedValue, "", 0, ref mensaje);
            string RutaArchivo = DatosEnvio.Rows[0][8].ToString();
            int NumeroEnvio = Convert.ToInt16(DatosEnvio.Rows[0][5].ToString());
            Medio.CrearArchivo(PagosConvenios, RutaArchivo);
            Medio.GenerarCRC(RutaArchivo);
            EnvioCC.ModificaEnvio((int)Session["IdConexion"], "U", ddlEntidad.SelectedValue, "PR", ddlPeriodo.SelectedItem.ToString()
                                    , NumeroEnvio, "G", "", 0, ref mensaje);
            Master.MensajeOk("Se confirmaron las transacciones de convenio y se generó el medio correctamente.");
            btnInsertar.Enabled = false;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al confirmar las transacciones de convenio", ex.Message);
        }
    }

    protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            //--int IdTipoCC = Convert.ToInt32(gvDetalle.DataKeys[indice].Values["IdTipoCC"].ToString());
            //string CodMedio = gvBandeja.DataKeys[indice].Values["CodigoMedio"].ToString();
            //int IdControl =Convert.ToInt32(gvBandeja.DataKeys[indice].Values["IdControlEnvio"]);
            //int Gestion = Convert.ToInt32(gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[1].Text);
            //int Intervalo = Convert.ToInt32(gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[2].Text);
            string mensaje = null;
            if (e.CommandName == "cmdEditar")
            {
                try
                {
                    btnAccionarIncremento.Text = "Modificar Monto";
                    lblTituloIncremento.Text = "Modificar Monto de Cambio";
                    hfConvenio.Value = indice.ToString();
                    this.pnlConvenios_ModalPopupExtender.Show();
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al intentar modificar el monto de la transaccion de Convenio", ex.Message);
                }
            }
            if (e.CommandName == "cmdEliminar")
            {
                try
                {
                    PagoCC.CambiarEstadoRevision("CONVD", Convert.ToInt64(gvDetalle.Rows[indice].Cells[4].Text)
                                    , Convert.ToInt32(gvDetalle.Rows[indice].Cells[5].Text), gvDetalle.Rows[indice].Cells[6].Text
                                    , Convert.ToInt64(gvDetalle.Rows[indice].Cells[7].Text), gvDetalle.Rows[indice].Cells[3].Text
                                    , gvDetalle.Rows[indice].Cells[10].Text, Convert.ToInt32(gvDetalle.Rows[indice].Cells[8].Text)
                                    , "", 0);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se eliminó la transacción de convenio con éxito");
                        Session["Convenios"] = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ConveniosPreliminar"
                                                                    , ddlEntidad.SelectedValue, "", "", "", 0, ref mensaje);
                        gvDetalle.DataSource = Session["Convenios"] as DataTable;
                        gvDetalle.DataBind();
                    }
                    else
                    {
                        Master.MensajeError("Error al eliminar la transacción de convenio", mensaje);
                    }
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al intentar eliminar la transacción de convenio", ex.Message);
                }
            }
        }
    }

    protected void btnAccionarConv_Click(object sender, EventArgs e)
    {
        mensaje = null;
        int indice = Convert.ToInt32(hfConvenio.Value);
        PagoCC.CambiarEstadoRevision("CONVD", Convert.ToInt64(gvDetalle.Rows[indice].Cells[4].Text)
                                    , Convert.ToInt32(gvDetalle.Rows[indice].Cells[5].Text), gvDetalle.Rows[indice].Cells[6].Text
                                    , Convert.ToInt64(gvDetalle.Rows[indice].Cells[7].Text), gvDetalle.Rows[indice].Cells[3].Text
                                    , gvDetalle.Rows[indice].Cells[10].Text, Convert.ToInt32(gvDetalle.Rows[indice].Cells[8].Text)
                                    , "", Convert.ToDecimal(txtMonto.Text));
        if (mensaje == null)
        {
            Master.MensajeOk("Se modificó el Incremento de Gestión con éxito!!!");
            Session["Convenios"] = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ConveniosPreliminar", ddlEntidad.SelectedValue
                                            , "", "", "", 0, ref mensaje);
            gvDetalle.DataSource = Session["Convenios"] as DataTable;
            gvDetalle.DataBind();
        }
        else
        {
            Master.MensajeError("Error al modificar el Incremento de Getión", mensaje);
        }

    }

    protected void btnCancelarConv_Click(object sender, EventArgs e)
    {

    }

    #endregion

    #region Consolidar

    protected void btnConsolidar_Click(object sender, EventArgs e)
    {
        if (RevisarEnvios("Consolidar"))
        {
            //hacer todo
            mensaje = null;
            PagoCC.Consolida((int)Session["IdConexion"], "I", ddlProceso.SelectedValue, ddlEntidad.SelectedValue, ddlPeriodo.SelectedItem.ToString(), ref mensaje);
            if (mensaje == null)
            {
                Master.MensajeOk("Se consolidó todo el proceso de " + ddlProceso.SelectedItem.ToString() + " " + ddlPeriodo.SelectedItem.ToString() + " para " + ddlEntidad.SelectedItem.ToString() + " correctamente.");
                MostrarConsolidados();
            }
            else
            {
                Master.MensajeError("Error al consolidar", mensaje);
            }
        }
        else
        {
            Master.MensajeError("Imposible consolidar la información de " + ddlEntidad.SelectedItem.ToString()
                            + " para el periodo " + ddlPeriodo.SelectedItem.ToString()
                            , "No se puede consolidar la información en este momento. Estados de los envios no validos");
        }
    }

    private void MostrarConsolidados()
    {
        DataTable Resultados;
        if (ddlProceso.SelectedValue == "P")
        {
            Resultados = EnvioCC.ObtieneVista((int)Session["idConexion"], "Q", "ResultadosConsolidados", ddlEntidad.SelectedValue, ddlProceso.SelectedValue
                                         , ddlPeriodo.SelectedItem.ToString(), "", 0, ref mensaje);
            gvConsolidados.DataSource = Resultados;
            gvConsolidados.DataBind();
            gvConsolidados.Visible = true;
            lblTituloConsolidado.Visible = true;
        }
        if (ddlProceso.SelectedValue == "C")
        {
            ddlFiltroDatos.SelectedIndex = 1;//cantidades
            string d = ddlInicio.Items.FindByValue(ddlPeriodo.SelectedValue).ToString();
            ddlInicio.SelectedIndex = ddlPeriodo.SelectedIndex;
            ddlFinal.SelectedIndex = ddlPeriodo.SelectedIndex;
            Resultados = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", ddlFiltroDatos.SelectedValue, ddlEntidad.SelectedValue
                                    , ddlTipoPlanillaFiltros.SelectedValue, ddlPeriodo.SelectedValue, ddlPeriodo.SelectedValue, ref mensaje);
            if (mensaje == null)
            {
                gvFiltrado.DataSource = Resultados;
                gvFiltrado.DataBind();
                gvFiltrado.Visible = true;
            }
            else
            {
                Response.Write("<script>window.alert('No existen datos consolidados');</script>");
                Master.MensajeError("Error al obtener la información", mensaje);
            }

        }
        if (ddlProceso.SelectedValue == "R")
        {
            Session["DetalleRepos"] = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", "ConsolidadoRepos", ddlEntidad.SelectedValue
                                   , "RR", ddlPeriodo.SelectedValue, ddlPeriodo.SelectedValue, ref mensaje);
            Resultados = Session["DetalleRepos"] as DataTable;
            if (mensaje == null)
            {
                gvDetalleRepos.DataSource = Resultados;
                gvDetalleRepos.DataBind();
                gvDetalleRepos.Visible = true;
            }
            else
            {
                Response.Write("<script>window.alert('No existen datos consolidados');</script>");
                Master.MensajeError("Error al obtener la información", mensaje);
            }
        }
    }

    #endregion

    #region FormC31

    protected void btnFormC31_Click(object sender, EventArgs e)
    {
        if (btnFormC31.Text.StartsWith("Registrar"))
        {
            btnAccionar.Text = "Registrar";
        }
        else
        {
            btnAccionar.Text = "Modificar";
        }
        this.pnlFormC31_ModalPopupExtender.Show();
        txtMonto.Text = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "TotalesC31", ddlEntidad.SelectedValue, ""
                                        , ddlPeriodo.SelectedValue, "", 0, ref mensaje).Rows[0][0].ToString();
    }

    private void CargarCombos()
    {
        
        clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlEntidad.DataSource = clas.ListarDetalleClasificador(16);
        ddlEntidad.DataValueField = "CodigoDetalleClasificador";
        ddlEntidad.DataTextField = "DescripcionDetalleClasificador";
        ddlEntidad.DataBind();

        ddlEntidad.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlEntidad.SelectedValue = "0";

        ddlEntidad.Items.Remove(ddlEntidad.Items.FindByValue("11"));
        ddlEntidad.Items.Remove(ddlEntidad.Items.FindByValue("03"));

        //clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlProceso.DataSource = clas.ListarDetalleClasificador(73);
        ddlProceso.DataValueField = "CodigoDetalleClasificador";
        ddlProceso.DataTextField = "DescripcionDetalleClasificador";
        ddlProceso.DataBind();

        ddlProceso.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlProceso.SelectedValue = "0";
        ddlProceso.SelectedIndex = 0;
        int IdRol = Convert.ToInt32(Seguridad.ListaDatosConexion((int)Session["IdConexion"]).Rows[0][2].ToString());
        if (IdRol == 86)
        {
            ddlProceso.Items.Remove(ddlProceso.Items.FindByValue("C"));
            ddlProceso.Items.Remove(ddlProceso.Items.FindByValue("R"));
        }
        else if (IdRol==115)
        {
            ddlProceso.Items.Remove(ddlProceso.Items.FindByValue("P"));
        }

        DateTime fecha = DateTime.Now.Date;
        ddlPeriodo.Items.Capacity = 12;
        for (int x = 0; x < 12; x++)
        {
            ddlPeriodo.Items.Add(fecha.Year.ToString() + fecha.Month.ToString("00"));
            ddlInicio.Items.Add(fecha.Year.ToString() + fecha.Month.ToString("00"));
            ddlFinal.Items.Add(fecha.Year.ToString() + fecha.Month.ToString("00"));
            fecha = fecha.AddMonths(-1);
        }

        //ddlCodigoPlanilla.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ObtienePlanillas", ddlEntidad.SelectedValue, ddlTipoPlanilla.SelectedValue
        //                                                , ddlPeriodo.SelectedValue, "", 0, ref mensaje);
        //ddlCodigoPlanilla.DataValueField = "IdDetalleClasificador";
        //ddlCodigoPlanilla.DataTextField = "DescripcionDetalleClasificador";
        //ddlCodigoPlanilla.DataBind();
        fecha = DateTime.Now.Date;
        ddlAnio.Items.Capacity = 8;
        ddlGestion.Items.Capacity = 8;
        for (int x = 0; x < 8; x++)
        {
            ddlAnio.Items.Add(fecha.Year.ToString());
            ddlGestion.Items.Add(fecha.Year.ToString());
            fecha = fecha.AddYears(-1);
        }

        ddlMes.Items.Capacity = 12;
        for (int x = 0; x < 12; x++)
        {
            ddlMes.Items.Add(fecha.Month.ToString("00"));
            fecha = fecha.AddMonths(-1);
        }
        ddlMes.SelectedIndex = 0;

        ddlFinanciera.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ObtieneFinancieras", ddlEntidad.SelectedValue, ""
                                                            , ddlPeriodo.SelectedValue, "", 0, ref mensaje);
        ddlFinanciera.DataValueField = "IdCuenta";
        ddlFinanciera.DataTextField = "Descripcion";
        ddlFinanciera.DataBind();

        ddlGrupoBeneficio.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ObtieneGrupoBeneficio", ddlEntidad.SelectedValue,""
                                                        , ddlPeriodo.SelectedValue, "", 0, ref mensaje);
        ddlGrupoBeneficio.DataValueField = "IdGrupoBeneficio";
        ddlGrupoBeneficio.DataTextField = "DescripcionGrupoBeneficio";
        ddlGrupoBeneficio.DataBind();

        ddlBeneficio.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ObtienePrestacion", ddlEntidad.SelectedValue, ""
                                                        , ddlPeriodo.SelectedValue, "", 3, ref mensaje);
        ddlBeneficio.DataValueField = "IdBeneficio";
        ddlBeneficio.DataTextField = "NombreBeneficio";
        ddlBeneficio.DataBind();

        txtPorcentaje.Text = "0";
        txtMontoInferior.Text = "0";
        txtMontoSuperior.Text = "0";
        txtIncremento.Text = "0";
        ddlBeneficio.SelectedIndex = 0;
        ddlGrupoBeneficio.SelectedIndex = 2;
    }

    protected void ddlGrupoBeneficio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBeneficio.DataSource = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "ObtienePrestacion", ddlEntidad.SelectedValue, ""
                                                        , ddlPeriodo.SelectedValue, "", Convert.ToInt32(ddlGrupoBeneficio.SelectedValue), ref mensaje);
        ddlBeneficio.DataValueField = "IdBeneficio";
        ddlBeneficio.DataTextField = "NombreBeneficio";
        ddlBeneficio.DataBind();
        this.pnlFormC31_ModalPopupExtender.Show();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        mensaje = null;
        if (btnAccionar.Text == "Registrar")
        {
            PagoCC.RegistraFormC31((int)Session["IdConexion"], "I", ddlEntidad.SelectedValue, ddlPeriodo.SelectedValue
                         , Convert.ToInt32(txtNumeroC31.Text), ddlAnio.SelectedItem.ToString(), ddlMes.SelectedItem.ToString()
                         , Convert.ToInt32(ddlFinanciera.SelectedValue), Convert.ToInt32(ddlGrupoBeneficio.SelectedValue)
                         , Convert.ToInt32(ddlBeneficio.SelectedValue), Convert.ToDecimal(txtMonto.Text), txtObservaciones.Text
                         , ref mensaje);
        }
        else
        {
            PagoCC.ModificaFormC31((int)Session["IdConexion"], "U", ddlEntidad.SelectedValue, ddlPeriodo.SelectedValue
                         , Convert.ToInt32(txtNumeroC31.Text), ddlAnio.SelectedItem.ToString(), ddlMes.SelectedItem.ToString()
                         , Convert.ToInt32(ddlFinanciera.SelectedValue), Convert.ToDecimal(txtMonto.Text), txtObservaciones.Text
                         , ref mensaje);
        }
        if (mensaje == null)
        {
            Master.MensajeOk("Se registro/modifico el Formulario C31 con éxito!!!");
            btnFormC31.Text = "Registrar Form C31";
        }
        else
        {
            Master.MensajeError("Error al registrar/modificar Formulario C31", mensaje);
            if (mensaje.StartsWith("Nro. Error: 3600282 Descripción: Ya existe"))
            {
                btnFormC31.Text = "Modificar Form C31";
                ddlGrupoBeneficio.Enabled = false;
                ddlBeneficio.Enabled = false;
                btnAccionar.Text = "Modificar";
            }
        }

    }

    #endregion

    #region Incrementos

    protected void btnAccionarIncremento_Click(object sender, EventArgs e)
    {
        mensaje = null;
        if (btnAccionarIncremento.Text.StartsWith("Registrar"))
        {
            PagoCC.RegistraIncremento((int)Session["IdConexion"], "I", Convert.ToInt32(ddlGestion.SelectedValue)
               , Convert.ToInt32(ddlTipoCC.SelectedValue), Convert.ToDecimal(txtMontoInferior.Text), Convert.ToDecimal(txtMontoSuperior.Text)
               , Convert.ToDecimal(txtIncremento.Text), Convert.ToDecimal(txtPorcentaje.Text), ref mensaje);
            if (mensaje == null)
            {
                Master.MensajeOk("Se registro el Incremento de Gestión con éxito!!!");
            }
            else
            {
                Master.MensajeError("Error al registrar el Incremento de Getión", mensaje);
            }
        }
        else
        {
            PagoCC.ModificaIncremento((int)Session["IdConexion"], "U", "Modifica", Convert.ToInt32(ddlGestion.SelectedValue)
                , Convert.ToInt32(hfIdArchivoIncremento.Value), Convert.ToInt32(ddlTipoCC.SelectedValue), Convert.ToDecimal(txtMontoInferior.Text)
                , Convert.ToDecimal(txtMontoSuperior.Text), Convert.ToDecimal(txtIncremento.Text), Convert.ToDecimal(txtPorcentaje.Text), ref mensaje);
            if (mensaje == null)
            {
                Master.MensajeOk("Se modificó el Incremento de Gestión con éxito!!!");
            }
            else
            {
                Master.MensajeError("Error al modificar el Incremento de Getión", mensaje);
            }
        }
        VerIncrementos();
    }

    protected void btnCancelarIncremento_Click(object sender, EventArgs e)
    {

    }

    protected void btnRegistraIncremento_Click(object sender, EventArgs e)
    {
        btnAccionarIncremento.Text = "Registrar";
        this.pnlIncremento_ModalPopupExtender.Show();
    }

    protected void btnIncrementoGestion_Click(object sender, EventArgs e)
    {
        VerIncrementos();
    }

    private void VerIncrementos()
    {
        lblTituloIncrementos.Visible = true;
        Session["Incrementos"] = EnvioCC.ObtieneVista((int)Session["IdConexion"], "Q", "DetalleIncrementos", "", "", "", "", 0, ref mensaje);
        gvIncrementos.DataSource = Session["Incrementos"] as DataTable;
        gvIncrementos.DataBind();
        gvIncrementos.Visible = true;
        btnRegistraIncremento.Visible = true;
    }

    protected void gvIncrementos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvIncrementos.PageIndex = e.NewPageIndex;
        gvIncrementos.DataSource = Session["Incrementos"] as DataTable;
        gvIncrementos.DataBind();
    }

    protected void gvIncrementos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            int IdTipoCC = Convert.ToInt32(gvIncrementos.DataKeys[indice].Values["IdTipoCC"].ToString());
            //string CodMedio = gvBandeja.DataKeys[indice].Values["CodigoMedio"].ToString();
            //int IdControl =Convert.ToInt32(gvBandeja.DataKeys[indice].Values["IdControlEnvio"]);
            int Gestion = Convert.ToInt32(gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[1].Text);
            int Intervalo = Convert.ToInt32(gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[2].Text);
            string mensaje = null;
            if (e.CommandName == "cmdEditar")
            {
                try
                {
                    btnAccionarIncremento.Text = "Actualizar Intervalo";
                    lblTituloIncremento.Text = "Actualizar Incrementos de Gestión";
                    ddlGestion.SelectedValue = Gestion.ToString();
                    ddlTipoCC.SelectedValue = IdTipoCC.ToString();
                    txtMontoInferior.Text = gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[5].Text;
                    txtMontoSuperior.Text = gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[6].Text;
                    txtIncremento.Text = gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[7].Text;
                    txtPorcentaje.Text = gvIncrementos.Rows[Convert.ToInt32(indice)].Cells[8].Text;
                    hfIdArchivoIncremento.Value = Intervalo.ToString();
                    this.pnlIncremento_ModalPopupExtender.Show();
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al intentar modificar el Incremento de Gestión", ex.Message);
                }
            }
            if (e.CommandName == "cmdEliminar")
            {
                try
                {
                    PagoCC.ModificaIncremento((int)Session["IdConexion"], "U", "Desactiva", Gestion, Intervalo, IdTipoCC, 0, 0, 0, 0, ref mensaje);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se habilitó/deshabilitó el intervalo con éxito!!!");
                        VerIncrementos();
                    }
                    else
                    {
                        Master.MensajeError("Error al habilitar/deshabilitar el intervalo", mensaje);
                    }
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al intentar deshabilitar el Incremento de Gestión", ex.Message);
                }
            }
        }
    }

    #endregion

    #region Conciliaciones

    protected void btnComprobante_Click(object sender, EventArgs e)
    {
        mensaje = null;
        Concil.ActualizaComprobante((int)Session["IdConexion"], "U", ddlEntidad.SelectedValue, ddlPeriodo.SelectedItem.ToString()
                                        , txtComprobante.Text, ref mensaje);
        if (mensaje == null)
        {
            Master.MensajeOk("Se registró el Comprobante de Devolución con éxito!!!");
        }
        else
        {
            Master.MensajeError("Error al registrar el Comprobante", mensaje);
        }
    }

    protected void ddlFiltroDatos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        mensaje = null;
         DataTable Filtro = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", ddlFiltroDatos.SelectedValue, ddlEntidad.SelectedValue
                    , ddlTipoPlanillaFiltros.SelectedValue, ddlInicio.SelectedItem.ToString(), ddlFinal.SelectedItem.ToString(), ref mensaje);
        if (mensaje == null)
        {
            gvFiltrado.DataSource = Filtro;
            gvFiltrado.DataBind();
            gvFiltrado.Visible = true;
        }
        else
        {
            Response.Write("<script>window.alert('No existen resultados para los creiterios del filtro');</script>");
            Master.MensajeError("Error al obtener la información", mensaje);
        }

    }

    protected void btnGeneraMedios_Click(object sender, EventArgs e)
    {
        mensaje = null;
        DataTable DatosEnvioConcil = EnvioCC.ObtieneVista((int)Session["idConexion"], "Q", "ObtieneEnvio", ddlEntidad.SelectedValue
                                ,ddlTipoPlanillaFiltros.SelectedValue, ddlPeriodo.SelectedValue, "", 0, ref mensaje);
        string RutaConilOk = DatosEnvioConcil.Rows[0][8].ToString();
        RutaConilOk = RutaConilOk.Remove(RutaConilOk.Length - 6, 2);
        Session["RutaMOK"] = RutaConilOk;
        string RutaConcilError = RutaConilOk.Replace("CP", "R");
        Session["RutaMError"] = RutaConcilError;
        DataTable MediosGenOK = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", "MediosOK", ddlEntidad.SelectedValue
                   , ddlTipoPlanillaFiltros.SelectedValue, ddlPeriodo.SelectedItem.ToString(), ddlFinal.SelectedItem.ToString(), ref mensaje);
        if (MediosGenOK.Rows.Count > 0)
        {
            DataTable MediosGenError = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", "MediosError", ddlEntidad.SelectedValue
                   , ddlTipoPlanillaFiltros.SelectedValue, ddlPeriodo.SelectedItem.ToString(), ddlFinal.SelectedItem.ToString(), ref mensaje);
            // si existen medios OK, generamos su medio
            Medio.CrearArchivo(MediosGenOK, RutaConilOk);
            Medio.GenerarCRC(RutaConilOk);
            if (MediosGenError != null && MediosGenError.Rows.Count > 0)
            {
                Medio.CrearArchivo(MediosGenError, RutaConcilError);
                Medio.GenerarCRC(RutaConcilError);
            }
            mensaje = null;
        }
        else//si no existe en la Temp si no es actual, buscamos en los historicos
        {
            mensaje = null;
            MediosGenOK = Concil.FiltrosConciliacion((int)Session["IdConexion"], "Q", "MediosHistoricos", ddlEntidad.SelectedValue
                       , ddlTipoPlanillaFiltros.SelectedValue, ddlInicio.SelectedItem.ToString(), ddlFinal.SelectedItem.ToString(), ref mensaje);
            //generar tb para los emdios his
        }
        if (mensaje == null)
        {
            Master.MensajeOk("Los medios fueron generados con éxito!");
            lblDescargaMedioOk.Visible = true;
            lblDescargaMediosError.Visible = true;
        }
        else
        {
            Response.Write("<script>window.alert('No existen resultados para los criterios del filtro');</script>");
            Master.MensajeError("Error al obtener la información", mensaje);
        }
    }

    protected void lblDescargaMedioOk_Click(object sender, EventArgs e)
    {
        ///adecaur al caso esta copy paste
        string rutaDescarga = Session["RutaMOK"].ToString();
        int p = rutaDescarga.LastIndexOf("\\");
        string NomArchivo = rutaDescarga.Remove(0,p+1);
        if (File.Exists(rutaDescarga))
        {
            Response.Clear();
            Response.ContentType = "application/txt";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
            Response.WriteFile(rutaDescarga);
            Response.End();
        }
        else
        {
            Master.MensajeError("Imposible Descargar el archivo", "El archivo no se encuentra disponible o no existe");
        }
    }

    protected void lblDescargaMediosError_Click(object sender, EventArgs e)
    {
        ///adecaur al caso esta copy paste
        string rutaDescarga = Session["RutaMError"].ToString();
        int p = rutaDescarga.LastIndexOf("\\");
        string NomArchivo = rutaDescarga.Remove(0,p + 1);
        if (File.Exists(rutaDescarga))
        {
            Response.Clear();
            Response.ContentType = "application/txt";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + NomArchivo);
            Response.WriteFile(rutaDescarga);
            Response.End();
        }
        else
        {
            Master.MensajeError("Imposible Descargar el archivo", "El archivo no se encuentra disponible o no existe");
        }
    }

    #endregion

    protected void gvDetalleRepos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetalleRepos.PageIndex = e.NewPageIndex;
        gvDetalleRepos.DataSource = Session["DetalleRepos"] as DataTable;
        gvDetalleRepos.DataBind();
    }

}