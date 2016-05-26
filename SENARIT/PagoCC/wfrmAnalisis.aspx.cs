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
using WcfServicioClasificador.Logica;
using wcfServicioIntercambioPago.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfSeguridad.Logica;

public partial class PagoCC_wfrmAnalisis : System.Web.UI.Page
{
    Int64 NUP;
    string IDHT;
    clsPagoCC PagosCC = new clsPagoCC();
    clsControlEnvios EnviosCC = new clsControlEnvios();
    clsSeguridad Seguridad = new clsSeguridad();
    DataTable Encontrados;

    string mensaje = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 360000;
            HttpContext.Current.Server.ScriptTimeout = 360000;
        }       
    }

    #region Inicio

    protected void cmdBuscar_Click(object sender, EventArgs e)
    {
        gvBusqueda.Visible = true;
        gvBusqueda.DataSourceID = null;
        Encontrados = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona", txtPrimerApellido.Text, txtSegundoApellido.Text, txtPrimerNombre.Text
                                                , txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, 0, "", ref mensaje);
        gvBusqueda.DataSource = Encontrados;
        gvBusqueda.DataBind();
    }

    protected void gvBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fila2 = gvBusqueda.SelectedRow.RowIndex;
        CargarSeleccionado(fila2);
        lnkPagos.Visible = true;
        lnkConciliaciones.Visible = true;
        lnkReposiciones.Visible = true;
        lnkSuspensiones.Visible = true;
        lnkConvenios.Visible = true;
        lnkFamilia.Visible = true;
        lnkMontoGestion.Visible = true;
        linkMontoAguinaldo.Visible = true;
        lblExcepciones.Visible = true;
        gvExcepciones.Visible = true;
        lblTitular.Visible = true;
        gvTitular.Visible = true;
        if (gvBusqueda.SelectedRow.Cells[13].Text != "TITULAR")
        {
            lblBeneficiario.Visible = true;
        }
        gvBeneficiario.Visible = true;
        MultiView1.ActiveViewIndex = 0;
    }

    private void CargarSeleccionado(int fila)
    {
        //cargamos los datos en los textbox
        txtCI.Text = gvBusqueda.SelectedRow.Cells[6].Text;
        txtPrimerApellido.Text = gvBusqueda.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        txtSegundoApellido.Text = gvBusqueda.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        txtPrimerNombre.Text = gvBusqueda.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
        txtSegundoNombre.Text = gvBusqueda.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        txtCUA.Text = gvBusqueda.SelectedRow.Cells[3].Text;
        txtMatricula.Text = gvBusqueda.SelectedRow.Cells[11].Text;
        txtEstadoCivil.Text = gvBusqueda.SelectedDataKey["EstadoCivil"].ToString();
        txtTipoPlanilla.Text = gvBusqueda.SelectedDataKey["TipoPlanilla"].ToString();
        txtFechaNacimiento.Text = Convert.ToDateTime(gvBusqueda.SelectedDataKey["FechaNacimiento"].ToString()).ToShortDateString();
        if (gvBusqueda.SelectedDataKey["FechaFallecimiento"].ToString().IndexOf("1900")!=-1)
        {
            txtFechaFallecimiento.Text = "";
        }
        else
        {
            txtFechaFallecimiento.Text = gvBusqueda.SelectedDataKey["FechaFallecimiento"].ToString();
        }
        txtSexo.Text = gvBusqueda.SelectedDataKey["Sexo"].ToString();
        txtNUP.Text = gvBusqueda.SelectedRow.Cells[2].Text;
        txtEntidad.Text = gvBusqueda.SelectedDataKey["Entidad"].ToString();
        NUP = Convert.ToInt64(gvBusqueda.SelectedRow.Cells[2].Text);
        IDHT = gvBusqueda.SelectedRow.Cells[12].Text;
        //luego cargamos los datos de pago,conciliacion y reposicion
        gvPagos.DataSourceID = null;
        Session["Pagos"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Pago", txtPrimerApellido.Text, txtSegundoApellido.Text
                                    , txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, txtCUA.Text, NUP, "", ref mensaje);
        gvPagos.DataSource = Session["Pagos"] as DataTable;
        gvPagos.DataBind();

        gvConciliaciones.DataSourceID = null;
        Session["Concil"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Conciliacion", txtPrimerApellido.Text
                                                , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text
                                                , txtMatricula.Text, txtCUA.Text, NUP, "", ref mensaje);
        gvConciliaciones.DataSource = Session["Concil"] as DataTable;
        gvConciliaciones.DataBind();

        gvReposiciones.DataSourceID = null;
        Session["Repo"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Reposicion", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvReposiciones.DataSource = Session["Repo"] as DataTable;
        gvReposiciones.DataBind();

        gvSuspensiones.DataSourceID = null;
        gvSuspensiones.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Suspensiones", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvSuspensiones.DataBind();

        gvConvenios.DataSourceID = null;
        gvConvenios.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Convenios", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvConvenios.DataBind();

        gvFamilia.DataSourceID = null;
        gvFamilia.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Familia", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvFamilia.DataBind();

        gvMontosGestion.DataSourceID = null;
        Session["Gest"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "MontosGestion", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvMontosGestion.DataSource = Session["Gest"] as DataTable;
        gvMontosGestion.DataBind();

        gvMontosAguinaldo.DataSourceID = null;
        Session["Aguinal"] = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "MontosAguinaldo", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvMontosAguinaldo.DataSource = Session["Aguinal"] as DataTable;
        gvMontosAguinaldo.DataBind();

        gvTitular.DataSourceID = null;
        gvTitular.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Titular", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvTitular.DataBind();

        gvBeneficiario.DataSourceID = null;
        gvBeneficiario.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Beneficiario", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvBeneficiario.DataBind();

        gvEnviosAPS.DataSourceID = null;
        gvEnviosAPS.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "EnvioAPS", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvEnviosAPS.DataBind();

        CargaExcepciones();

    }

    private void CargaExcepciones()
    {
        DataTable DatosConex = Seguridad.ListaDatosConexion((int)Session["IdConexion"]);
        int IdRol = Convert.ToInt32(DatosConex.Rows[0][2].ToString());
        if (IdRol != 86 && IdRol != 115)
        {
            imgNuevo.Enabled = false;
        }

        NUP = Convert.ToInt64(gvBusqueda.SelectedRow.Cells[2].Text);
        IDHT = gvBusqueda.SelectedRow.Cells[12].Text;
        gvExcepciones.DataSourceID = null;
        gvExcepciones.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Excepcion", txtPrimerApellido.Text, txtSegundoApellido.Text
                                           , txtPrimerNombre.Text, txtSegundoNombre.Text, txtCI.Text, txtMatricula.Text, IDHT, NUP, "", ref mensaje);
        gvExcepciones.DataBind();
        imgNuevo.Visible = true;
    }

    protected void cmdLimpiar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PagoCC/wfrmAnalisis.aspx");
        //Limpiar();
    }

    private void Limpiar()
    {
        /*foreach (Control c in this.Controls)
        {
            if (c is TextBox)
            {
                TextBox text = c as TextBox;
                text.Text = "";
            }
        }
        foreach (Control g in this.Controls)
        {
            if (g is GridView)
            {
                GridView grid = g as GridView;
                g.Visible = false;
            }
        }*/
        txtPrimerNombre.Text = "";
        txtSegundoNombre.Text = "";
        txtPrimerApellido.Text = "";
        txtSegundoApellido.Text = "";
        txtCUA.Text = "";
        txtMatricula.Text = "";
        txtCI.Text = "";
        gvBusqueda.Visible = false;
        lnkPagos.Visible = false;
        lnkConciliaciones.Visible = false;
        lnkReposiciones.Visible = false;
        gvExcepciones.Visible = false;
        imgNuevo.Visible = false;
    }

    #endregion

    #region Info

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void lnkReposiciones_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void lnkSuspensiones_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }

    protected void lnkConvenios_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }

    protected void lnkFamilia_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 5;
    }

    protected void lnkMontoGestion_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 6;
    }

    protected void linkMontoAguinaldos(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 7;
    }

    protected void gvPagos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPagos.PageIndex = e.NewPageIndex;
        gvPagos.DataSource = Session["Pagos"] as DataTable;
        gvPagos.DataBind();
        int x = gvPagos.PageIndex;
    }

    protected void gvConciliaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConciliaciones.PageIndex = e.NewPageIndex;
        gvConciliaciones.DataSource = Session["Concil"] as DataTable;
        gvConciliaciones.DataBind();
        int x = gvConciliaciones.PageIndex;
    }

    protected void gvReposiciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReposiciones.PageIndex = e.NewPageIndex;
        gvReposiciones.DataSource = Session["Repo"] as DataTable;
        gvReposiciones.DataBind();
        int x = gvReposiciones.PageIndex;
    }

    protected void gvMontosGestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMontosGestion.PageIndex = e.NewPageIndex;
        gvMontosGestion.DataSource = Session["Gest"] as DataTable;
        gvMontosGestion.DataBind();
        int x = gvMontosGestion.PageIndex;
    }

    protected void gvMontosAguinaldo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMontosAguinaldo.PageIndex = e.NewPageIndex;
        gvMontosAguinaldo.DataSource = Session["Aguinal"] as DataTable;
        gvMontosAguinaldo.DataBind();
        int x = gvMontosAguinaldo.PageIndex;
    }

    #endregion

    #region Excepciones

    private void CargarDatosExcepcion(int IdExcepcion, int IdCodigoError, int fila)
    {
        /*txtJustificacion.Text = gvExcepciones.SelectedRow.Cells[6].Text;
        txtPeriodoInicio.Text = gvExcepciones.SelectedRow.Cells[7].Text;
        txtPeriodoFinal.Text = gvExcepciones.SelectedRow.Cells[8].Text;*/
        //mp da cn selected row por que no entró con selected row, entonces sr=-1
        txtJustificacion.Text = gvExcepciones.Rows[fila].Cells[9].Text;
        txtPeriodoInicio.Text = gvExcepciones.Rows[fila].Cells[10].Text;
        txtPeriodoFinal.Text = gvExcepciones.Rows[fila].Cells[11].Text;
        ddlError.SelectedValue = gvExcepciones.Rows[fila].Cells[5].Text;
        txtCodigoError.Text = gvExcepciones.Rows[fila].Cells[5].Text;
        hfIdArchivo.Value = IdExcepcion.ToString();
    }

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de Excepción";
        CargarErrores();
        txtPeriodoInicio.Text = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
        txtPeriodoFinal.Text = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        //Int64 IDCE = Convert.ToInt64(gvExcepciones.SelectedDataKey["IdCodigoError"].ToString());//esto cuando vayamos a modificar un excecpion

        if (btnAccionar.Text == "Adicionar")
        {
            if (txtJustificacion.Text != "" && txtCodigoError.Text != "" && txtPeriodoInicio.Text != ""
                && (txtPeriodoFinal.Text == "" || (Convert.ToInt32(txtPeriodoFinal.Text) >= Convert.ToInt32(txtPeriodoInicio.Text))))
            {
                try
                {
                    PagosCC.RegistraExcepcion((int)Session["IdConexion"], "I", ddlError.SelectedValue, Convert.ToInt64(gvBusqueda.SelectedRow.Cells[2].Text)
                                                , Convert.ToInt64(gvBusqueda.SelectedRow.Cells[12].Text), txtJustificacion.Text
                                                , txtPeriodoInicio.Text, txtPeriodoFinal.Text, ref mensaje);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se agregó la excepción correctamente.");
                        CargaExcepciones();
                    }
                    else
                    {
                        Master.MensajeError("No se pudo registrar la excepción.", mensaje);
                    }
                }
                catch (Exception ex)
                {
                    Master.MensajeError("No se pudo registrar la excepción.", mensaje);
                }
            }
            else
            {
                lblObservaciones.Text = "Debe llenar los campos necesarios";
            }
        }
        if (btnAccionar.Text == "Modificar")
        {
            if (txtJustificacion.Text != "" && txtCodigoError.Text != "" && txtPeriodoInicio.Text != "")  // verifica que el campo llenado no sea nulo
            {
                try
                {
                    int IExcepcion = Convert.ToInt32(hfIdArchivo.Value);
                    PagosCC.ModificaExcepcion((int)Session["IdConexion"], "U", "Modifica", IExcepcion, ddlError.SelectedValue, txtJustificacion.Text
                                                , txtPeriodoInicio.Text, txtPeriodoFinal.Text, ref mensaje);
                    if (mensaje == null)
                    {
                        CargaExcepciones();
                        // Response.Redirect("~/Medios/wfrmTipoRegistro.aspx", false);
                        Master.MensajeOk("Se modificó la excepción correctamente.");
                    }
                    else
                    {
                        Master.MensajeError("No se pudo modificar la excepción.", mensaje);
                    }
                }
                catch (Exception ex)
                {
                    //Response.Write("<script>window.alert('No se pudo realizar la modificación " + ex.Message + "');</script>");
                    Master.MensajeError("No se pudo modificar la excepción.", mensaje);
                }
            }
            else
            {
                lblObservaciones.Text = "Debe llenar los campos necesarios";
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void ddlError_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoError.Text = ddlError.SelectedValue;
        this.pnlDatos_ModalPopupExtender.Show();
    }

    private void CargarErrores()
    {
        string mensaje = null;
        ddlError.DataSource = EnviosCC.ObtieneVista((int)Session["IdConexion"], "Q", "CargaErrores", "", "", "", "", 0, ref mensaje);
        ddlError.DataValueField = "CodigoError";
        ddlError.DataTextField = "Descripcion";
        ddlError.DataBind();
        ddlError.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlError.SelectedValue = "0";
    }

    protected void gvExcepciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "cmdEditar")
        {
            if (gvExcepciones.Rows[indice].Cells[12].Text == "Activo")
            {
                int IExcepcion = Convert.ToInt32(gvExcepciones.DataKeys[indice].Values["IdExcepcion"]);
                int IError = Convert.ToInt32(gvExcepciones.DataKeys[indice].Values["IdCodigoError"]);
                btnAccionar.Text = "Modificar";
                lblTitulo.Text = "Modificar el Tipo de Intercambio";
                CargarErrores();
                CargarDatosExcepcion(IExcepcion, IError, indice);
                this.pnlDatos_ModalPopupExtender.Show();
            }
            else
            {
                Master.MensajeError("No se puede editar un registro que está inactivo", "Proceda activando el registro");
            }
        }
        if (e.CommandName == "cmdDesactivar")
        {
            int Idex = Convert.ToInt32(gvExcepciones.DataKeys[indice].Value);
            try
            {
                PagosCC.ModificaExcepcion((int)Session["IdConexion"], "U", "Desactiva", Idex, ddlError.SelectedValue, txtJustificacion.Text
                                            , txtPeriodoInicio.Text, txtPeriodoFinal.Text, ref mensaje);
                if (mensaje == null)
                {
                    Master.MensajeOk("Se Activó/Desactivó la excepción correctamente.");
                    CargaExcepciones();
                }
                else
                {
                    Master.MensajeError("No se pudo cambiar el estado de la excepción.", mensaje);
                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("No se pudo cambiar el estado de la excepción.", mensaje);
            }
        }
    }

    #endregion

}