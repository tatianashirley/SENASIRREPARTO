using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Net;
using System.Security.Principal;
using wfcDoblePercepcion.Logica;
using wcfServicioIntercambioPago.Logica;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using wcfSeguridad.Logica;
using System.Diagnostics;
using System.Reflection;

public partial class DoblePercepcion_wfrmCargarInformacionAsegurado : System.Web.UI.Page
{
    long NUP = 0;
    string CUA = null;
    string Matricula = null;
    string Paterno = null;
    string Materno = null;
    string PrimerNombre = null;
    string NumeroDocumento = null;
    DataTable Encontrados;
    int BanderaHabilitacion = 0;
    int BanderaHabilitacionRol = 0;
    //DataTable Encontrados = new DataTable("Customers");
    //Encontrados.Locale = CultureInfo.InvariantCulture;

    string mensaje = null;
    clsInformacion info = new clsInformacion();
    int bandera = 0;
    const int FechaCorteSistema = 15;
    clsPagoCC PagosCC = new clsPagoCC();
    //clsInformacion info = new clsInformacion();
    
    clsSeguridad ObjSeguridad = new clsSeguridad();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Cronograma", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        DataRow row1 = Encontrados.Rows[0];
        BanderaHabilitacion = Convert.ToInt32(row1[0].ToString());

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "ROL", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        DataRow row2 = Encontrados.Rows[0];
        BanderaHabilitacionRol = Convert.ToInt32(row2[0].ToString());

        NUP = Convert.ToInt64(Session["NUPT"]);
        CUA = (string)Session["CUAT"];
        Matricula = (string)Session["MATRICULAT"];
        Paterno = (string)Session["PATERNOT"];
        Materno = (string)Session["MATERNOT"];
        PrimerNombre = (string)Session["PRIMERNOMBRET"];
        NumeroDocumento = (string)Session["NUMERODOCUMENTO"];
        if (!Page.IsPostBack)
        {
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona1", "", "", "", "", NumeroDocumento, Matricula, CUA, NUP, 0, ref mensaje);
            //SE ASIGNA VALORES A LOS TEXTBOX'S
            DataRow row = Encontrados.Rows[0];
            txtNup.Text = row[0].ToString();
            txtCUA.Text = row[1].ToString();
            txtMatricula.Text = row[2].ToString();
            txtDocumento.Text = row[3].ToString();
            txtNroDocumento.Text = row[4].ToString();
            txtExpedido.Text = row[5].ToString();
            txtPrimerApellido.Text = row[6].ToString();
            txtPrimerNombre.Text = row[7].ToString();
            txtFechaNacimiento.Text = ((string)row[8].ToString()).Substring(0, 10);
            txtSegundoApellido.Text = row[9].ToString();
            txtSegundoNombre.Text = row[10].ToString();
            txtSexo.Text = row[11].ToString();
            txtEstadoCivil.Text = row[12].ToString();
            txtDireccionActual.Text = row[13].ToString();
            txtFechaFallecimiento.Text = row[14].ToString();// ((string)row[14].ToString()).Substring(0,10);
            lblBeneficios.Visible = true;
            DateTime fechaActual = DateTime.Now;
            cargar_gvBeneficios();

        }

        //--------------------------------------------------------------------------------------------------------------------
        if (gvBeneficios.Rows.Count == 0)
        {
            this.lnkSuspencionPreventiva.Visible = true;

            if (BanderaHabilitacion == 0)
            //if (fechaActual.Day > FechaCorteSistema)
            {
                this.lnkSuspencionPreventiva.Enabled = false;
            }

            cargar_gvSuspencionPreventiva();
            tctSuspencionPreventiva.Visible = true;
            tcDetalle.Visible = false;
            cargar_gvDocumentoPreventivo();
            panPagos.Visible = false;
        }
        else
        {
			cargar_gvSuspencionPreventiva();
            if (gvSuspencionPreventiva.Rows.Count != 0)
            {
                tctSuspencionPreventiva.Visible = true;
                tcDetalle.Visible = false;
                cargar_gvDocumentoPreventivo();
                panPagos.Visible = false;
            }
			
            if (BanderaHabilitacion == 0 || BanderaHabilitacionRol == 0)
            //if (fechaActual.Day > FechaCorteSistema)
            {
                gvBeneficios.Rows[0].Cells[9].Enabled = false;
                gvBeneficios.Rows[0].Cells[9].ForeColor = Color.Gray;
            }

            txtRangoSPC.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "FechaPago", gvBeneficios.Rows[0].Cells[12].Text, "", "", "", "", "", "", NUP, 0, ref mensaje);
            DataRow row_q = Encontrados.Rows[0];
            txtRangoEPC.Text = row_q[0].ToString();

            string vv = Convert.ToString(gvBeneficios.Rows[0].Cells[7].Text);
            if (Convert.ToString(gvBeneficios.Rows[0].Cells[7].Text) == "FALLECIDO")
            {
                lbTituloDH.Visible = true;
                cargar_gvDerechoHabientes();
            }
        }
        //--------------------------------------------------------------------------------------------------------------------

       if (!Page.IsPostBack)
        {
            CrearTablas();
            cargar_gvConvenios();
            if (gvConvenios.Rows.Count != 0 && gvConvenios != null)
            {
                lblConvenios.Visible = true;
                gvConvenios.Visible = true;
            }
        }
    }

    protected void cargar_gvConvenios()
    {
        gvConvenios.DataSourceID = null;
        gvConvenios.DataSource = PagosCC.ObtieneDatos((int)Session["IdConexion"], "Q", "Convenios", txtPrimerApellido.Text
                                            , txtSegundoApellido.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtNroDocumento.Text, txtMatricula.Text
                                            , txtCUA.Text, NUP, "", ref mensaje);
        gvConvenios.DataBind();
    }
    protected void cargar_gvDerechoHabientes()
    {
        gvDH.Visible = true;
        gvDH.DataSourceID = null;
        gvDH.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DerechoHabientes", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, "0", Matricula, CUA, NUP, 0, ref mensaje);
        gvDH.DataBind();
    }

    protected void cargar_gvSuspencionPreventiva()
    {
        gvSuspencionPreventiva.Visible = true;
        gvSuspencionPreventiva.DataSourceID = null;
        gvSuspencionPreventiva.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Preventiva", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, "0", Matricula, CUA, NUP, 0, ref mensaje);
        gvSuspencionPreventiva.DataBind();
    }
    protected void cargar_gvDocumentoPreventivo()
    {
        gvDocumentosPreventivos.Visible = true;
        gvDocumentosPreventivos.DataSourceID = null;
        gvDocumentosPreventivos.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Documentos2", "", "", ""
                            , "", "0", "", "", NUP, 0, ref mensaje);
        gvDocumentosPreventivos.DataBind();
    }
    protected void cargar_gvBeneficios()
    {
        gvBeneficios.Visible = true;
        gvBeneficios.DataSourceID = null;
        gvBeneficios.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Beneficios", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, "0", Matricula, CUA, NUP, 0, ref mensaje);
      
        gvBeneficios.DataBind();
    }

    protected void gvBeneficios_SelectedIndexChanged(object sender, EventArgs e)
    {

        int fila2 = gvBeneficios.SelectedRow.RowIndex;
        CargarSeleccionado(fila2);

    }

    private void CargarSeleccionado(int fila)
    {

        string estado = gvBeneficios.SelectedRow.Cells[6].Text;
        estado = gvBeneficios.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        txtActivo.Text = estado;
    }


    private void CargarCombos()
    {
        mensaje = null;
    }

    protected void gvPagos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        string RangoEPC = txtRangoEPC.Text;
        string RangoSPC = txtRangoSPC.Text;
        string fechaini = RangoEPC.Substring(6, 4) + RangoEPC.Substring(3, 2) + RangoEPC.Substring(0, 2);
        string fechafin = RangoSPC.Substring(6, 4) + RangoSPC.Substring(3, 2) + RangoSPC.Substring(0, 2);
        gvPagos.PageIndex = e.NewPageIndex;
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Pagos", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, fechaini, fechafin, CUA, NUP, 0, ref mensaje);
        gvPagos.DataSource = Encontrados;
        gvPagos.DataBind();

    }
    protected void gvConciliacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConciliacion.PageIndex = e.NewPageIndex;
        gvConciliacion.Visible = true;
        gvConciliacion.DataSourceID = null;
        gvConciliacion.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Conciliacion", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, "0", Matricula, CUA, NUP, 0, ref mensaje);
        gvConciliacion.DataBind();

    }
    protected void gvDocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocumentos.PageIndex = e.NewPageIndex;
        cargar_gvDocumentos(Convert.ToInt32(Session["IdBeneficio"]));
        gvDocumentos.DataBind();
    }


    protected void gvPeriodosIncurridos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPeriodosIncurridos.PageIndex = e.NewPageIndex;
        cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
        gvPeriodosIncurridos.DataBind();

    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string h = checkinsitucion.Checked.ToString();
        string nup = txtNup.Text;
        string BeneficioOtorgado = null;
        BeneficioOtorgado = Convert.ToString(Session["IdBeneficio"]);
        string estado = ddlNuevoEstado.SelectedValue;
        string estadoT = ddlNuevoEstado.Text;
        string norma = null;
        string normaT = null;
        if (estado == "364")
        {
            norma = "372";
            normaT = txtnorma.Text;
        }
        else
        {
            norma = ddlnorma.SelectedValue;
            normaT = ddlnorma.Text;
        }

        string tdocumento = ddlTDocumento.SelectedValue;
        string tdocumentoT = ddlTDocumento.Text;
        string nrodocumento = txtNroDocumento1.Text;
        string FechaDocumento = txtFechaActual.Text;
        //var referencia = txaObservacion.Text;
        string Institucion = ddlInstitucion.SelectedValue;

        if (Institucion == "SELECCIONE...")
            Institucion = "0";

        string PeriodoInicioInstitucion = txtPeriodoInicioInstitucion.Text;
        string PeriodoFinInInstitucion = txtPerioFinInstitucion.Text;
        string FechaSuspencion = txtFechaSuspencion.Text;
        string FechaRehabilitacion = txtFechaRehabilitacion.Text;
        string EstadoActual = lbIdEstadoBeneficio.Text;
        string refencia = txtReferenciai.Text;
        string observacion = txaObservacioni.Text;
        string observacion1 = txtObservacioni.Text;
        int NroReferenciaSuspencion = 0;
        if (txtNroReferenciaSuspencion.Text != "" && txtNroReferenciaSuspencion.Text != "&nbsp;")
            NroReferenciaSuspencion = Convert.ToInt32(txtNroReferenciaSuspencion.Text);
        else
            NroReferenciaSuspencion = 0;
        int NroReferenciaRehabilitacion = 0;
        if (txtNroReferenciaRehabilitacion.Text == "" || txtNroReferenciaRehabilitacion.Text == "&nbsp;")
        {
            NroReferenciaRehabilitacion = 0;
        }
        else
        {
            NroReferenciaRehabilitacion = Convert.ToInt32(txtNroReferenciaRehabilitacion.Text);
        }

        string documentoextra = ddldocumentoextra.SelectedValue;
        string documentoextraT = ddldocumentoextra.Text;
        string nrodocumentoextra = txtdocumentoextra.Text;
        string fechadocumentoextra = txtfechadocumentoextra.Text;
        string referenciadocumentoextra = txaReferenciadocumentoextra.Value;
        string observaciondocumentoextra = txaObservacionDocumentoExtra.Value;
        string documentoextra1 = ddldocumentoextra1.SelectedValue;
        string documentoextraT1 = ddldocumentoextra1.Text;
        string nrodocumentoextra1 = txtdocumentoextra1.Text;
        string fechadocumentoextra1 = txtfechadocumentoextra1.Text;
        string referenciadocumentoextra1 = txaReferenciadocumentoextra1.Value;
        string observaciondocumentoextra1 = txaObservacionDocumentoExtra1.Value;

        int sw = 0;
        if (validar(EstadoActual, estado, FechaSuspencion, FechaRehabilitacion, estadoT, normaT, h, Institucion, PeriodoInicioInstitucion, PeriodoFinInInstitucion, NroReferenciaSuspencion, NroReferenciaRehabilitacion))
        {
            if (this.MasDocumentos.Visible == true)
            {
                if (this.MasDocumentos1.Visible == true)
                {

                    if (validar_documento(nrodocumentoextra, fechadocumentoextra, documentoextraT) && validar_documento(nrodocumentoextra1, fechadocumentoextra1, documentoextraT1))
                    {
                        if (Institucion == "0")
                            h = "False";
                        else
                            h = "True";

                        if (referenciadocumentoextra == "&nbsp;")
                            referenciadocumentoextra = "";
                        if (observaciondocumentoextra == "&nbsp;")
                            observaciondocumentoextra = "";

                        info.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToInt64(nup), "3", BeneficioOtorgado, Convert.ToInt32(estado),
                        Convert.ToInt32(norma), Convert.ToInt32(tdocumento), nrodocumento, FechaDocumento, Institucion, PeriodoInicioInstitucion,
                        PeriodoFinInInstitucion, FechaSuspencion, FechaRehabilitacion, "5", h, refencia, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);
                        info.InsertaDocuementoExtra((int)Session["IdConexion"], "I", Convert.ToInt64(nup), Convert.ToInt32(estado),Convert.ToInt32(BeneficioOtorgado), documentoextra, nrodocumentoextra, fechadocumentoextra
                        , referenciadocumentoextra, observaciondocumentoextra, ref mensaje);
                        info.InsertaDocuementoExtra((int)Session["IdConexion"], "I", Convert.ToInt64(nup), Convert.ToInt32(estado),Convert.ToInt32(BeneficioOtorgado), documentoextra1, nrodocumentoextra1, fechadocumentoextra1
                        , referenciadocumentoextra1, observaciondocumentoextra1, ref mensaje);
                        cargar_gvBeneficios();
                        cargar_gvSuspencion(Convert.ToInt32(BeneficioOtorgado));
                        cargar_gvDocumentos(Convert.ToInt32(BeneficioOtorgado));
                        cargar_gvPeriodos(Convert.ToInt32(BeneficioOtorgado));
                    }
                    else
                    {
                        mensaje = "INGRESE NRO DE DOCUMENTO O SU FECHA";
                        //Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                        this.mpeNuevoRegistro.Show();
                        sw = 1;
                    }
                }
                else
                {
                    if (validar_documento(nrodocumentoextra, fechadocumentoextra, documentoextraT))
                    {
                        if (Institucion == "0")
                            h = "False";
                        else
                            h = "True";

                        info.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToInt64(nup), "3", BeneficioOtorgado, Convert.ToInt32(estado),
                        Convert.ToInt32(norma), Convert.ToInt32(tdocumento), nrodocumento, FechaDocumento, Institucion, PeriodoInicioInstitucion,
                        PeriodoFinInInstitucion, FechaSuspencion, FechaRehabilitacion, "5", h, refencia, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);

                        if (referenciadocumentoextra == "&nbsp;")
                            referenciadocumentoextra = "";
                        if (observaciondocumentoextra == "&nbsp;")
                            observaciondocumentoextra = "";

                        info.InsertaDocuementoExtra((int)Session["IdConexion"], "I", Convert.ToInt64(nup), Convert.ToInt32(estado), Convert.ToInt32(BeneficioOtorgado), documentoextra, nrodocumentoextra, fechadocumentoextra
                        , referenciadocumentoextra, observaciondocumentoextra, ref mensaje);
                        cargar_gvBeneficios();
                        cargar_gvSuspencion(Convert.ToInt32(BeneficioOtorgado));
                        cargar_gvDocumentos(Convert.ToInt32(BeneficioOtorgado));
                        cargar_gvPeriodos(Convert.ToInt32(BeneficioOtorgado));
                    }
                    else
                    {
                        mensaje = "INGRESE NRO DE DOCUMENTO O SU FECHA";
                        this.mpeNuevoRegistro.Show();
                        sw = 1;
                    }
                }
            }

            else
            {
                if (Institucion == "0")
                    h = "False";
                else
                    h = "True";

                if (gvDocTempNormales.Rows[0].Cells[4].Text == "&nbsp;")
                    gvDocTempNormales.Rows[0].Cells[4].Text = "";
                if (gvDocTempNormales.Rows[0].Cells[5].Text == "&nbsp;")
                    gvDocTempNormales.Rows[0].Cells[5].Text = "";

                int yu = Convert.ToInt32(gvDocTempNormales.DataKeys[0].Values["IdDocumento"].ToString());
                info.InsertaRegistro((int)Session["IdConexion"], "I" , Convert.ToInt64(nup), "3", BeneficioOtorgado, Convert.ToInt32(estado),
                Convert.ToInt32(norma), Convert.ToInt32(gvDocTempNormales.DataKeys[0].Values["IdDocumento"].ToString()), gvDocTempNormales.Rows[0].Cells[2].Text, gvDocTempNormales.Rows[0].Cells[3].Text, Institucion, PeriodoInicioInstitucion,
                PeriodoFinInInstitucion, FechaSuspencion, FechaRehabilitacion, lblNroCertificado.Text, h, gvDocTempNormales.Rows[0].Cells[4].Text, gvDocTempNormales.Rows[0].Cells[5].Text, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);

                int NumeroDocumento = gvDocTempNormales.Rows.Count;

                for (int i = 1; i < NumeroDocumento; i++)
                {
                    if (gvDocTempNormales.Rows[i].Cells[4].Text == "&nbsp;")
                        gvDocTempNormales.Rows[i].Cells[4].Text = "";
                    if (gvDocTempNormales.Rows[i].Cells[5].Text == "&nbsp;")
                        gvDocTempNormales.Rows[i].Cells[5].Text = "";


                    info.InsertaDocuementoExtra((int)Session["IdConexion"], "I", Convert.ToInt64(nup),
                    Convert.ToInt32(estado), Convert.ToInt32(BeneficioOtorgado),gvDocTempNormales.DataKeys[i].Values["IdDocumento"].ToString(), gvDocTempNormales.Rows[i].Cells[2].Text, gvDocTempNormales.Rows[i].Cells[3].Text
                    , gvDocTempNormales.Rows[i].Cells[4].Text, gvDocTempNormales.Rows[i].Cells[5].Text, ref mensaje);

                }

                cargar_gvBeneficios();
                cargar_gvSuspencion(Convert.ToInt32(Session["IdBeneficio"]));
                cargar_gvDocumentos(Convert.ToInt32(Session["IdBeneficio"]));
                cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));

            }
            if (mensaje == null)
            {
                Master.MensajeOk("Se registró la modificacion correctamente");
                this.mpeNuevoRegistro.Hide();
            }
            else
            {
                if (sw == 0)
                {
                    Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                    this.mpeNuevoRegistro.Hide();
                }
            }
        }
        else
        {
            this.mpeNuevoRegistro.Show();
        }
    }

    protected bool validar_documento(string nrodocumentoextra, string fechadocumentoextra, string documentoextra)
    {
        if (nrodocumentoextra == "" || fechadocumentoextra == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE NRO DE DOCUMENTO O SU FECHA');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (documentoextra == "SELECCIONE...")
        {
            string script = @"<script type='text/javascript'>alert('SELECCIONE UN TIPO DE DOCUMENTO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        return true;

    }

    protected bool validar(string EstadoActual, string estado, string FechaSuspencion, string FechaRehabilitacion, string estadoT, string normaT, string h, string Institucion, string PeriodoInicioInstitucion, string PeriodoFinInInstitucion, int NroReferenciaSuspencion, int NroReferenciaRehabilitacion)
    {
        DateTime fechaActual1 = DateTime.Now;
        int anyo3 = fechaActual1.Year;
        if (EstadoActual == "364" && estado == "707" || estado == "365" || estado == "366" ||
            estado == "709" || estado == "708")
        {
            if (FechaSuspencion == "")
            {
                string script = @"<script type='text/javascript'>alert('NO INGRESO PERIODO DE INICIO DE SUSPENSION');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }

            string panyo = FechaSuspencion.Substring(0, 4);
            string pmes = FechaSuspencion.Substring(4, 2);

            if (Convert.ToInt32(panyo) < 2000 || Convert.ToInt32(panyo) > anyo3)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }

            if (Convert.ToInt32(pmes) < 1 || Convert.ToInt32(pmes) > 12)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            
            if (NroReferenciaSuspencion != 0)
            {
                DataTable NroSuspensio = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroSuspension", "", "", "", "", "", "", estado, Convert.ToInt16(panyo), NroReferenciaSuspencion, ref mensaje);
                if (Convert.ToInt32(NroSuspensio.Rows[0][0].ToString()) >= 1)
                {
                    DataTable MaximoNroSuspensio = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MaximoNroSuspension", "", "", "", "", "", "", estado, Convert.ToInt16(panyo), NroReferenciaSuspencion, ref mensaje);
                    
                    string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE SUSPENSION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. NUMERO MAXIMO REGISTRADO(" + MaximoNroSuspensio.Rows[0][0].ToString() + ").');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    return false;
                    
                }
            }
            else 
            {
                string script = @"<script type='text/javascript'>alert('INGRESE EL NRO DE REFERENCIA DE SUSPENSION');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
        }
        else
        {
            if (EstadoActual == "365" || EstadoActual == "366" || EstadoActual == "707" || EstadoActual == "709" || EstadoActual == "708" && estado == "364")
            {
                if (FechaRehabilitacion == "")
                {
                    string script = @"<script type='text/javascript'>alert('NO INGRESO PERIOD DE FIN DE SUSPENSION');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    return false;
                }
                else
                {
                    if (FechaRehabilitacion != "")
                    {
                        if (Convert.ToInt32(FechaRehabilitacion) < Convert.ToInt32(FechaSuspencion))
                        {
                            string script = @"<script type='text/javascript'>alert('LA FECHA DE INICIO DE FIN DE SUSPENSION ES MENOR A LA DE INICIO DE SUSPENSION');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return false;
                        }

                        string panyo2 = FechaRehabilitacion.Substring(0, 4);
                        string pmes1 = FechaRehabilitacion.Substring(4, 2);

                        if (Convert.ToInt32(panyo2) < 2000 || Convert.ToInt32(panyo2) > anyo3)
                        {
                            string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE REHABILITACION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return false;

                        }
                        if (Convert.ToInt32(pmes1) < 1 || Convert.ToInt32(pmes1) > 12)
                        {
                            string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return false;
                        }
                        if (NroReferenciaRehabilitacion != 0)
                        {
                            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroRehabilitacion", "", "", "", "", "", "", EstadoActual, Convert.ToInt16(panyo2), NroReferenciaRehabilitacion, ref mensaje);
                            if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
                            {
                                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroMax", "", "", "", "", "", "", EstadoActual, Convert.ToInt16(panyo2), NroReferenciaSuspencion, ref mensaje);
                                string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE REHABILITACION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. NUMERO MAXIMO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ").');</script>";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                                return false;
                            }
                        }
                        else
                        {
                            string script = @"<script type='text/javascript'>alert('INGRESE EL NRO DE REFERENCIA DE REHABILITACION');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            return false;
                        }
                    }
                }
            }
        }
        if (gvDocTempNormales.Rows.Count == 0)
        {
            string script = @"<script type='text/javascript'>alert('INGRESO POR LO MENOS UN DOCUMENTO DE RESPALDO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (gvDocTempNormales == null)
        {
            string script = @"<script type='text/javascript'>alert('INGRESO POR LO MENOS UN DOCUMENTO DE RESPALDO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        DateTime fechaActual = DateTime.Now;
        int anyo = fechaActual.Year;
        int mes = fechaActual.Month;

        int anyo1 = Convert.ToInt32(FechaSuspencion.Substring(0, 4));
        int mes1 = Convert.ToInt32(FechaSuspencion.Substring(4, 2));

        if (anyo <= anyo1 && estado != "364")
        {
            if (mes < mes1)
            {
                string script = @"<script type='text/javascript'>alert('FECHA DE SUSPENSION MAYOR A LA FECHA ACTUAL');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
        }

        if (estadoT == "SELECCIONE...")
        {
            string script = @"<script type='text/javascript'>alert('SELECCIONE UN ESTADO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        if (normaT == "SELECCIONE...")
        {
            string script = @"<script type='text/javascript'>alert('SELECCIONE UNA NORMA');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        if (h == "True" && Institucion == "0")
        {
            string script = @"<script type='text/javascript'>alert('SELECCIONE UNA INSTITUCION');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }


        if (h == "True" && PeriodoInicioInstitucion != "")
        {
            string panyoI = PeriodoInicioInstitucion.Substring(0, 4);
            string pmesI = PeriodoInicioInstitucion.Substring(4, 2);

            if (Convert.ToInt32(panyoI) < 2000 || Convert.ToInt32(pmesI) > anyo3)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE INICIO INSTITUCION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

            if (Convert.ToInt32(panyoI) < 1 || Convert.ToInt32(pmesI) > 12)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE INICIO INSTITUCION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
        }
        if (h == "True" && PeriodoFinInInstitucion != "")
        {
            string panyoF = PeriodoFinInInstitucion.Substring(0, 4);
            string pmesF = PeriodoFinInInstitucion.Substring(4, 2);

            if (Convert.ToInt32(panyoF) < 2000 || Convert.ToInt32(pmesF) > anyo3)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE FIN INSTITUCION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

            if (Convert.ToInt32(panyoF) < 1 || Convert.ToInt32(pmesF) > 12)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE FIN INSTITUCION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }

        }
        if (h == "True" && PeriodoInicioInstitucion == "")
        {
            string script = @"<script type='text/javascript'>alert('PORFAVOR INGRESE UNA FECHA DE INICIO DE INSTITUCION');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        //NroReferenciaSuspencion, NroReferenciaRehabilitacion
        

        
        if (NroReferenciaRehabilitacion != 0)
        {
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroRehabilitacion", "", "", "", "", "", "", "", 0, NroReferenciaRehabilitacion, ref mensaje);
        }

        return true;

    }

    protected void gvBeneficios_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int indice = Convert.ToInt32(e.CommandArgument);
        string estado = gvBeneficios.DataKeys[indice].Values["IdEstadoBeneficio"].ToString();
        if (e.CommandName == "cmdModificar")
        {
            try
            {
                int t = Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString());
                Session["IdBeneficio"] = Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString());
                ddlInstitucion.Items.Clear();
                ddlInstitucion.Items.Add("SELECCIONE...");
                ddlInstitucion.AppendDataBoundItems = true;

                ddlInstitucion.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Institucion", "", "", "", "", "", "", ""
                                                   , 0, 0, ref mensaje);
                ddlInstitucion.DataValueField = "IdInstitucion";
                ddlInstitucion.DataTextField = "NombreInstitucion";
                ddlInstitucion.DataBind();

                ddlNuevoEstado.Items.Clear();
                ddlNuevoEstado.Items.Add("SELECCIONE...");
                ddlNuevoEstado.AppendDataBoundItems = true;

                ddlNuevoEstado.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Estado", "", "", "", "", "", "", ""
                                                   , 0, Convert.ToInt32(estado), ref mensaje);

                ddlNuevoEstado.DataValueField = "IdDetalleClasificador";
                ddlNuevoEstado.DataTextField = "DescripcionDetalleClasificador";
                ddlNuevoEstado.DataBind();

                ddlnorma.Items.Clear();
                ddlnorma.Items.Add("SELECCIONE...");
                ddlnorma.AppendDataBoundItems = true;

                ddlnorma.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Normativa", "", "", "", "", "", "", ""
                                              , 0, 0, ref mensaje);
                ddlnorma.DataValueField = "IdDetalleClasificador";
                ddlnorma.DataTextField = "DescripcionDetalleClasificador";
                ddlnorma.DataBind();

                ddlTDocumento.Items.Clear();
                ddlTDocumento.Items.Add("SELECCIONE...");
                ddlTDocumento.AppendDataBoundItems = true;

                ddlTDocumento.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", ""
                                                   , 0, 0, ref mensaje);
                ddlTDocumento.DataValueField = "IdDetalleClasificador";
                ddlTDocumento.DataTextField = "DescripcionDetalleClasificador";

                ddlTDocumento.DataBind();

                cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
                cargar_gvDocumentos(Convert.ToInt32(Session["IdBeneficio"]));
                cargar_gvSuspencion(Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString()));
                ddlnorma.Visible = true;
                txtnorma.Visible = false;
                lblobligatorio3.Visible = true;
                txtPeriodoInicioInstitucion.ReadOnly = true;
                txtPerioFinInstitucion.ReadOnly = true;
                checkinsitucion.Checked = false;

                txtActivo.Text = Convert.ToString(gvBeneficios.Rows[indice].Cells[7].Text);
                CargarCombos();
                txtNroDocumento1.Text = "";
                txtReferenciai.Text= "";
                txaObservacioni.Text= "";
                txtFechaActual.Text = "";
                txtPeriodoInicioInstitucion.Text = "";
                txtPeriodoFinInstitucion.Text = "";
                txtObservacioni.Text = "";
                DateTime fechaActual = DateTime.Now;
                string anyo = Convert.ToString(fechaActual.Year);
                string mes = null;
                if (fechaActual.Month < 10)
                    mes = "0" + Convert.ToString(fechaActual.Month);
                else
                    mes = Convert.ToString(fechaActual.Month);

                txtFechaSuspencion.Text = anyo + mes;
                txtFechaRehabilitacion.Text = "";
                lbIdEstadoBeneficio.Text = gvBeneficios.DataKeys[indice].Values["IdEstadoBeneficio"].ToString();
                lblNroCertificado.Text = gvBeneficios.DataKeys[indice].Values["NumeroCertificado"].ToString();

                int indiceUltimaFila = gvPeriodosIncurridos.Rows.Count - 1;
                int indiceUltimaFilaSus = gvSuspencion.Rows.Count - 1;

                if (lbIdEstadoBeneficio.Text.Equals("365") || lbIdEstadoBeneficio.Text.Equals("366") || lbIdEstadoBeneficio.Text.Equals("707") || lbIdEstadoBeneficio.Text.Equals("709") || lbIdEstadoBeneficio.Text.Equals("708"))
                {


                    if (indiceUltimaFilaSus != -1)
                    {
                        txtNroReferenciaSuspencion.Text = Convert.ToString(gvSuspencion.Rows[indiceUltimaFilaSus].Cells[10].Text);
                        txtNroReferenciaRehabilitacion.Text = Convert.ToString(gvSuspencion.Rows[indiceUltimaFilaSus].Cells[11].Text);
                    }

                    else
                    {
                        txtNroReferenciaSuspencion.Text = "";
                        txtNroReferenciaRehabilitacion.Text = "";
                    }


                    if (indiceUltimaFila != -1)
                    { 
                        /*txtFechaSuspencion.Text = Convert.ToString(gvPeriodosIncurridos.Rows[indiceUltimaFila].Cells[5].Text); */
                        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "PeriodoSuspension", "", "", "", "", "", "", "", NUP, 0, ref mensaje);
                        DataRow row = Encontrados.Rows[0];
                        txtFechaSuspencion.Text = row[0].ToString();
                    }

                    else
                    {
                        /* DateTime fechaActual = DateTime.Now;
                         string anyo = Convert.ToString(fechaActual.Year);
                         string mes = null;
                         if (fechaActual.Month < 10)
                             mes = "0" + Convert.ToString(fechaActual.Month);
                         else
                             mes = Convert.ToString(fechaActual.Month);
                         */
                        txtFechaSuspencion.Text = anyo + mes;
                    }

                    txtFechaSuspencion.ReadOnly = true;
                    txtFechaRehabilitacion.ReadOnly = false;
                    lblobligatorio2.Visible = true;
                    lblobligatorio1.Visible = false;
                    
                    lblObligatorio5.Visible = true;
                    lblObligatorio4.Visible = false;

                    CalendarExtender8.Enabled = false;
                    CalendarExtender9.Enabled = true;

                    txtNroReferenciaSuspencion.ReadOnly = true;
                    txtNroReferenciaRehabilitacion.ReadOnly = false;


                }
                if (lbIdEstadoBeneficio.Text.Equals("364"))
                {
                    txtNroReferenciaSuspencion.Text = Convert.ToString(gvBeneficios.Rows[indice].Cells[8].Text);
                    txtNroReferenciaRehabilitacion.Text = Convert.ToString(gvBeneficios.Rows[indice].Cells[9].Text);
                    txtFechaRehabilitacion.ReadOnly = true;
                    lblobligatorio2.Visible = false;
                    lblobligatorio1.Visible = true;
                    lblObligatorio5.Visible = false;
                    lblObligatorio4.Visible = true;
                    CalendarExtender9.Enabled = false;
                    CalendarExtender8.Enabled = true;
                    txtFechaSuspencion.ReadOnly = false;
                    txtNroReferenciaSuspencion.ReadOnly = false;
                    txtNroReferenciaRehabilitacion.ReadOnly = true;
                }

                this.MasDocumentos.Visible = false;
                this.MasDocumentos1.Visible = false;

                gvDocTempNormales.Visible = false;
                gvDocTempNormales.DataSource = null;
                gvDocTempNormales.DataBind();

                CrearTablas();

                if (indiceUltimaFilaSus == -1 && gvBeneficios.Rows[indice].Cells[2].Text == "G")
                {
                    string script = @"<script type='text/javascript'>alert('NO SE PUEDE SUSPENDER UN PAGO GOBLAL');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                  
                }
                else
                {
                    if (indiceUltimaFilaSus != -1 && gvBeneficios.Rows[indice].Cells[2].Text == "G")
                    {
                        string FechaRehabilitacion = gvSuspencion.Rows[indiceUltimaFilaSus].Cells[4].Text;
                        string FechaSuspension = gvSuspencion.Rows[indiceUltimaFilaSus].Cells[3].Text;
                        if (FechaSuspension == "&nbsp;")
                        {
                            string script = @"<script type='text/javascript'>alert('NO SE PUEDE SUSPENDER UN PAGO GOBLAL');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        }
                        else
                             this.mpeNuevoRegistro.Show();
                    
                    }
                    else
                        this.mpeNuevoRegistro.Show();
                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }


        if (e.CommandName == "cmdDetalle")
        {
            //cargar_gvSuspencion(Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdEstadoBeneficio"].ToString()));

            Session["IdBeneficio"] = Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString());
            cargar_gvSuspencion(Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString()));
            cargar_gvDocumentos(Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString()));
            cargar_gvPeriodos(Convert.ToInt32(gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString()));

            if (this.tabInformacion.Visible == false)
            {
                this.tabInformacion.Visible = true;
            }
            else
            {
                this.tabInformacion.Visible = false;
            }
        }
    }

    protected void cargar_gvDocumentos(int IdTipoCC)
    {
        gvDocumentos.Visible = true;
        gvDocumentos.DataSourceID = null;
        gvDocumentos.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Documentos", "", "", ""
                        , "", "0", "", "", NUP, IdTipoCC, ref mensaje);
        gvDocumentos.DataBind();
    }


    protected void cargar_gvSuspencion(int IdTipoCC)
    {
        gvSuspencion.Visible = true;
        gvSuspencion.DataSourceID = null;
        gvSuspencion.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Suspencion", Paterno, Materno, PrimerNombre
                            , txtSegundoNombre.Text, "0", Matricula, CUA, NUP, IdTipoCC, ref mensaje);
        gvSuspencion.DataBind();
    }
    protected void cargar_gvPeriodos(int IdTipoCC)
    {
        gvPeriodosIncurridos.Visible = true;
        gvPeriodosIncurridos.DataSourceID = null;
        gvPeriodosIncurridos.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Periodos", "", "", ""
                        , "", "0", "", "", NUP, IdTipoCC, ref mensaje);
        gvPeriodosIncurridos.DataBind();
    }

    protected void gvSuspencion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);

        string IdSuspencionBeneficio = gvSuspencion.DataKeys[indice].Values["IdSuspencionBeneficio"].ToString();
        lblIdSuspencion.Text = Convert.ToString(IdSuspencionBeneficio);
        DateTime fechaActual = DateTime.Now;
        string anyo = Convert.ToString(fechaActual.Year);
        string mes = null;
        if (fechaActual.Month < 10)
            mes = "0" + Convert.ToString(fechaActual.Month);
        else
            mes = Convert.ToString(fechaActual.Month);
        if (e.CommandName == "cmdModificarSuspension") //486 1115
        {
            try
            {
                CargarSuspencion(IdSuspencionBeneficio);
                this.mpmodificaSuspencion.Show();
                string anyo1 = Convert.ToString(gvSuspencion.Rows[indice].Cells[3].Text).Substring(6, 4);
                string mes1 = Convert.ToString(gvSuspencion.Rows[indice].Cells[3].Text).Substring(3, 2);
                if (anyo1 == anyo && mes1 == mes)
                {
                    txtPerioSuspencionM.ReadOnly = false;
                    txtNroReferenciaSuspencionM.ReadOnly = false;
                    CalendarExtender12.Enabled = true;
                }
                else
                {
                    string fech = Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text);
                    if (fech != "&nbsp;" || fech != "")
                    {
                        txtPerioRehabilitacionM.ReadOnly = true;
                    }
                    txtPerioSuspencionM.ReadOnly = true;
                    txtEstadoM.ReadOnly = true;
                    ddlnormaM.Enabled = false;
                    txtNroReferenciaSuspencionM.ReadOnly = true;
                    CalendarExtender12.Enabled = false;
                }
                string FechaRehabilitacion = Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text);
                if (FechaRehabilitacion != "&nbsp;")
                {
                    string anyo2 = Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text).Substring(6, 4);
                    string mes2 = Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text).Substring(3, 2);
                    if (anyo2 == anyo && mes2 == mes)
                    {
                        txtPerioRehabilitacionM.ReadOnly = false;
                    }
                    else
                    {
                        txtPerioRehabilitacionM.ReadOnly = true;
                        txtEstadoM.ReadOnly = true;
                        ddlnormaM.Enabled = true;
                    }
                }
                else
                {
                    txtPerioRehabilitacionM.ReadOnly = true;
                    CalendarExtender17.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }

    }
    private void CargarSuspencion(string IdSuspencionBeneficio)
    {
        mensaje = null;
        DataTable DetalleDeuda = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DetalleSuspencion", "", "", "", "", "", "", "", 0, Convert.ToInt32(IdSuspencionBeneficio), ref mensaje);
        ddlnormaM.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Normativa", "", "", "", "", "", "", ""
                                                    , 0, 0, ref mensaje);
        ddlnormaM.DataValueField = "IdDetalleClasificador";
        ddlnormaM.DataTextField = "DescripcionDetalleClasificador";
        ddlnormaM.DataBind();
        if (mensaje == null && DetalleDeuda != null && DetalleDeuda.Rows.Count !=0)
        {
            txtEstadoM.Text = DetalleDeuda.Rows[0][0].ToString();
            ddlnormaM.SelectedValue = DetalleDeuda.Rows[0][3].ToString();
            txaObsercacionSuspencion.Value = DetalleDeuda.Rows[0][4].ToString();
            txaObservacionRehabilitacion.Value = DetalleDeuda.Rows[0][5].ToString();

            txtPerioSuspencionM.Text = DetalleDeuda.Rows[0][6].ToString();

            if (DetalleDeuda.Rows[0][7].ToString().Equals(""))
            {

                txtPerioRehabilitacionM.ReadOnly = true;
                CalendarExtender17.Enabled = false;
            }
            else
            {
                txtPerioRehabilitacionM.ReadOnly = false;
                //Image5.Enabled = false;
            }

            txtPerioRehabilitacionM.Text = DetalleDeuda.Rows[0][7].ToString();


            txtNroReferenciaSuspencionM.Text = DetalleDeuda.Rows[0][8].ToString();
            Session["NroReferenciaSuspencionM"] = txtNroReferenciaSuspencionM.Text;
            txtNroReferenciaRehabilitacionM.Text = DetalleDeuda.Rows[0][9].ToString();
            Session["NroReferenciaRehabilitacionM"] = txtNroReferenciaRehabilitacionM.Text;
            Session["TipoSuspensionM"] = DetalleDeuda.Rows[0][10].ToString();
        }

    }

    protected void bntModificaSuspencion_Click(object sender, EventArgs e)
    {
        string IdSupencion = lblIdSuspencion.Text;
        string norma = ddlnormaM.SelectedValue;
        string FechaSuspencion = txtPerioSuspencionM.Text;
        string FechaRehabilitacion = txtPerioRehabilitacionM.Text;
        string observacion = txaObsercacionSuspencion.Value;
        string observacion1 = txaObservacionRehabilitacion.Value;

        DateTime fechaActual = DateTime.Now;
        int anyo = Convert.ToInt32(fechaActual.Year);

        int NroReferenciaSuspencion = 0;

        if (txtNroReferenciaSuspencionM.Text != "")
            NroReferenciaSuspencion = Convert.ToInt32(txtNroReferenciaSuspencionM.Text);
        else
            NroReferenciaSuspencion = 0;

        int NroReferenciaRehabilitacion = 0;
       
        if (txtNroReferenciaRehabilitacionM.Text == "")
        {
            NroReferenciaRehabilitacion = 0;
        }
        else
        {
            NroReferenciaRehabilitacion = Convert.ToInt32(txtNroReferenciaRehabilitacionM.Text);
        }

        int sw1 = 0;

        if (FechaRehabilitacion.Equals("") || FechaRehabilitacion.Equals("&nbsp;"))
        {
            FechaRehabilitacion = "";
            sw1 = 1;

        }

        //  if (FechaRehabilitacion != "" || FechaRehabilitacion != "&nbsp;")
        //  {

        string TipoSuspension = Session["TipoSuspensionM"].ToString();
        if (sw1 == 0)
        {
            if (Convert.ToInt32(FechaRehabilitacion) < Convert.ToInt32(FechaSuspencion))
            {
                string script = @"<script type='text/javascript'>alert('LA FECHA DE INICIO DE FIN DE SUSPENSION ES MENOR A LA DE INICIO DE SUSPENSION');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                this.mpmodificaSuspencion.Show();
            }

            else
            {
                //string tt = Convert.ToInt32( Session["NroReferenciaSuspencionM"].ToString());
                if (Convert.ToInt32(Session["NroReferenciaSuspencionM"].ToString()) != NroReferenciaSuspencion)
                {
                    if (NroReferenciaSuspencion != 0)
                    {
                        DataTable NroSuspensio = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroSuspension", "", "", "", "", "", "", TipoSuspension, anyo, NroReferenciaSuspencion, ref mensaje);
                        if (Convert.ToInt32(NroSuspensio.Rows[0][0].ToString()) >= 1)
                        {
                            DataTable MaximoNroSuspensio = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MaximoNroSuspension", "", "", "", "", "", "", TipoSuspension, anyo, NroReferenciaSuspencion, ref mensaje);
                            string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE SUSPENSION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. NUMERO MAXIMO REGISTRADO(" + MaximoNroSuspensio.Rows[0][0].ToString() + ").');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            this.mpmodificaSuspencion.Show();
                        }
                        else
                        {
                            info.ModificaSuspencion((int)Session["IdConexion"], "U", IdSupencion, norma, FechaSuspencion, FechaRehabilitacion, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);
                            if (mensaje == null)
                            {
                                Master.MensajeOk("Se registró la modificacion correctamente");
                                this.mpmodificaSuspencion.Hide();
                                cargar_gvSuspencion(Convert.ToInt32(Session["IdBeneficio"]));
                                cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
                            }
                            else
                            {
                                Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                                this.mpmodificaSuspencion.Hide();
                            }
                        }
                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>alert('INGRESE EL NRO DE REFERENCIA DE SUSPENSION');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        this.mpmodificaSuspencion.Show();
                    }
                }
                else 
                {
                    if (Convert.ToInt32(Session["NroReferenciaRehabilitacionM"].ToString()) != NroReferenciaRehabilitacion)
                    {
                        if (NroReferenciaRehabilitacion != 0)
                        {
                            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroMax", "", "", "", "", "", "", TipoSuspension, anyo, NroReferenciaSuspencion, ref mensaje);
                            if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
                            {
                                //Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MaximoNroRehabilitacion", "", "", "", "", "", "", "708", anyo, NroReferenciaRehabilitacion, ref mensaje);
                                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroMax", "", "", "", "", "", "", TipoSuspension, anyo, NroReferenciaRehabilitacion, ref mensaje);
                                string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE REHABILITACION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. NUMERO MAXIMO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ").');</script>";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                                this.mpmodificaSuspencion.Show();
                            }
                            else
                            {
                                info.ModificaSuspencion((int)Session["IdConexion"], "U", IdSupencion, norma, FechaSuspencion, FechaRehabilitacion, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);
                                if (mensaje == null)
                                {
                                    Master.MensajeOk("Se registró la modificacion correctamente");
                                    this.mpeNuevoRegistro.Hide();
                                    cargar_gvSuspencion(Convert.ToInt32(Session["IdBeneficio"]));
                                    cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
                                }
                                else
                                {
                                    Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                                    this.mpmodificaSuspencion.Hide();
                                }
                            }
                        }
                        else
                        {
                            string script = @"<script type='text/javascript'>alert('INGRESE EL NRO DE REFERENCIA DE REHABILITACION');</script>";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                        }
                    }
                    else
                    {
                        info.ModificaSuspencion((int)Session["IdConexion"], "U", IdSupencion, norma, FechaSuspencion, FechaRehabilitacion, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);
                        if (mensaje == null)
                        {
                            Master.MensajeOk("Se registró la modificacion correctamente");
                            this.mpmodificaSuspencion.Hide();
                            cargar_gvSuspencion(Convert.ToInt32(Session["IdBeneficio"]));
                            cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
                        }
                        else
                        {
                            Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                            this.mpmodificaSuspencion.Hide();
                        }
                    }
                }
            }
        }
        else
        {

            if (NroReferenciaSuspencion != 0)
            {

                DataTable NroSuspensio = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroSuspension", "", "", "", "", "", "", "708", Convert.ToInt16("2016"), NroReferenciaSuspencion, ref mensaje);
                if (Convert.ToInt32(NroSuspensio.Rows[0][0].ToString()) >= 1)
                {
                    DataTable MaximoNroSuspensio = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MaximoNroSuspension", "", "", "", "", "", "", "708", Convert.ToInt16("2016"), NroReferenciaSuspencion, ref mensaje);

                    string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE SUSPENSION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. NUMERO MAXIMO REGISTRADO(" + MaximoNroSuspensio.Rows[0][0].ToString() + ").');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    this.mpmodificaSuspencion.Show();
                }
                else {
                        info.ModificaSuspencion((int)Session["IdConexion"], "U", IdSupencion, norma, FechaSuspencion, FechaRehabilitacion, observacion, observacion1, NroReferenciaSuspencion, NroReferenciaRehabilitacion, ref mensaje);
                        if (mensaje == null)
                        {
                            Master.MensajeOk("Se registró la modificacion correctamente");
                            this.mpeNuevoRegistro.Hide();
                            cargar_gvSuspencion(Convert.ToInt32(Session["IdBeneficio"]));
                            cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
                        }
                        else
                        {
                            Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                            this.mpmodificaSuspencion.Hide();
                        }
                }
            }
            else
            {
                string script = @"<script type='text/javascript'>alert('INGRESE EL NRO DE REFERENCIA DE SUSPENSION');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                this.mpmodificaSuspencion.Show();
             }
        }
        //}
    }

    protected void gvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        string IdSuspencionBeneficio = gvDocumentos.DataKeys[indice].Values["IdSuspensionBeneficio"].ToString();
        string IdDocumento = gvDocumentos.DataKeys[indice].Values["IdDocumento"].ToString();
        lblIdSuspencionm.Text = IdSuspencionBeneficio;
        lblIdDocumetnom.Text = IdDocumento;
        DateTime fechaActual = DateTime.Now;
        string anyo = Convert.ToString(fechaActual.Year);
        string mes = null;
        if (fechaActual.Month < 10)
            mes = "0" + Convert.ToString(fechaActual.Month);
        else
            mes = Convert.ToString(fechaActual.Month);

        if (e.CommandName == "cmdModificarDocumento")
        {
            try
            {
                var s = string.Empty;
                int ind = -1;
                foreach (GridViewRow r in gvSuspencion.Rows)
                {
                    s = Convert.ToString(gvSuspencion.DataKeys[r.RowIndex]["IdSuspencionBeneficio"].ToString());

                    if (IdSuspencionBeneficio == s)
                    {
                        ind = Convert.ToInt32(r.RowIndex);
                        break;
                    }
                }
                CargaDocumento(IdSuspencionBeneficio, IdDocumento);
                this.mpeModificaDocumento.Show();

                if (ind != -1)
                {
                    string fecha = Convert.ToString(gvSuspencion.Rows[ind].Cells[4].Text);
                    string anyo1 = null;
                    string mes1 = null;
                    int sw = 0;
                    if (fecha != "&nbsp;")
                    {
                        anyo1 = Convert.ToString(gvSuspencion.Rows[ind].Cells[4].Text).Substring(6, 4);
                        mes1 = Convert.ToString(gvSuspencion.Rows[ind].Cells[4].Text).Substring(3, 2);
                        sw = 1;
                    }
                    else
                    {
                        anyo1 = Convert.ToString(gvSuspencion.Rows[ind].Cells[3].Text).Substring(6, 4);
                        mes1 = Convert.ToString(gvSuspencion.Rows[ind].Cells[3].Text).Substring(3, 2);
                        sw = 0;
                    }

                    if (anyo1 == anyo && mes1 == mes)
                    {
                        txtNroDocumentoM.ReadOnly = false;
                    }
                    else
                    {
                        txtFechaDocumentoM.ReadOnly = true;
                        txtNroDocumentoM.ReadOnly = true;
                        ddlTipoDocumentoM.Enabled = false;
                        CalendarExtender1.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
    }

    protected void CargaDocumento(string IdSuspencionBeneficio, string IdDocumento)
    {
        mensaje = null;
        DataTable DetalleDocumento = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DetalleDocumento", "", "", "", "", "", "", "", Convert.ToInt32(IdDocumento), Convert.ToInt32(IdSuspencionBeneficio), ref mensaje);
        ddlTipoDocumentoM.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        ddlTipoDocumentoM.DataValueField = "IdDetalleClasificador";
        ddlTipoDocumentoM.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoDocumentoM.DataBind();
        if (mensaje == null)
        {
            ddlTipoDocumentoM.SelectedValue = DetalleDocumento.Rows[0][2].ToString();
            txtNroDocumentoM.Text = DetalleDocumento.Rows[0][3].ToString();
            txtFechaDocumentoM.Text = DetalleDocumento.Rows[0][4].ToString();
            txtReferenciaM.Value = DetalleDocumento.Rows[0][5].ToString();
            txaObservacionDocumentoM.Value = DetalleDocumento.Rows[0][6].ToString();
            lblDocumento.Text = DetalleDocumento.Rows[0][7].ToString();
        }

    }

    protected void btnModificaDocumentoA_Click(object sender, EventArgs e)
    {
        string IdSuspencion = lblIdSuspencionm.Text;
        string IdDocumento = lblIdDocumetnom.Text;
        string idTipoDocumento = ddlTipoDocumentoM.SelectedValue;
        string NroDocumento = txtNroDocumentoM.Text;
        string FechaDocumento = txtFechaDocumentoM.Text;
        string ReferenciaDocumento = txtReferenciaM.Value;
        string ObservacionDocumento = txaObservacionDocumentoM.Value;
        info.ModificaDocumento((int)Session["IdConexion"], "U", IdSuspencion, IdDocumento, idTipoDocumento, NroDocumento, FechaDocumento, ReferenciaDocumento, ObservacionDocumento, ref mensaje);
        if (mensaje == null)
        {
            Master.MensajeOk("Se registró la modificacion correctamente");
            this.mpeNuevoRegistro.Hide();
            cargar_gvDocumentos(Convert.ToInt32(Session["IdBeneficio"]));
        }
        else
        {
            Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
            this.mpeNuevoRegistro.Hide();
        }
    }

    protected void lblMasDocumentos_Click(object sender, EventArgs e)
    {
        bandera = 1;
        if (this.MasDocumentos.Visible == true)
        {
            this.MasDocumentos.Visible = false;
            this.MasDocumentos1.Visible = false;
            lblMasDoc.Text = "Mas Documentos";
            lblMasDoc1.Text = "Mas Documentos";
        }
        else
        {
            ddldocumentoextra.Items.Clear();
            ddldocumentoextra.Items.Add("SELECCIONE...");
            ddldocumentoextra.AppendDataBoundItems = true;

            ddldocumentoextra.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", ""
                                                , 0, 0, ref mensaje);
            ddldocumentoextra.DataValueField = "IdDetalleClasificador";
            ddldocumentoextra.DataTextField = "DescripcionDetalleClasificador";
            ddldocumentoextra.DataBind();

            this.MasDocumentos.Visible = true;
            txtdocumentoextra.Text = "";
            txtfechadocumentoextra.Text = "";
            txaReferenciadocumentoextra.Value = "";
            txaObservacionDocumentoExtra.Value = "";
            lblMasDoc.Text = "Menos Documentos";
        }
        this.mpeNuevoRegistro.Show();
    }

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        bandera = 0;
        this.MasDocumentos.Visible = false;
    }

    protected void gvPeriodosIncurridos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        string IdSuspencion = gvPeriodosIncurridos.DataKeys[indice].Values["IdSuspension"].ToString();
        string IdInstitucion = gvPeriodosIncurridos.DataKeys[indice].Values["IdInstitucionM"].ToString();
        lblIdsuspencionP.Text = IdSuspencion;
        lblIdinstitucion.Text = IdInstitucion;
        DateTime fechaActual = DateTime.Now;
        string anyo = Convert.ToString(fechaActual.Year);
        string mes = null;
        if (fechaActual.Month < 9)
            mes = "0" + Convert.ToString(fechaActual.Month);
        else
            mes = Convert.ToString(fechaActual.Month);

        if (e.CommandName == "cmdModificarPeriodo")
        {

            try
            {
                var s = string.Empty;
                int ind = -1;
                foreach (GridViewRow r in gvSuspencion.Rows)
                {
                    s = Convert.ToString(gvSuspencion.DataKeys[r.RowIndex]["IdSuspencionBeneficio"].ToString());
                    if (IdSuspencion == s)
                    {
                        ind = Convert.ToInt32(r.RowIndex);
                        break;
                    }
                }

                if (CargarPeriodo(IdSuspencion, IdInstitucion))
                    this.mpeModificaPeriodo.Show();

                if (ind != -1)
                {
                    string anyo1 = Convert.ToString(gvSuspencion.Rows[ind].Cells[3].Text).Substring(6, 4);
                    string mes1 = Convert.ToString(gvSuspencion.Rows[ind].Cells[3].Text).Substring(3, 2);
                    if (anyo1 == anyo && mes1 == mes)
                    {
                        txtNroDocumentoM.ReadOnly = false;
                    }
                    else
                    {
                        txtPeriodoInicioInstitucionM.ReadOnly = true;
                        txtPeriodoFinInstitucion.ReadOnly = true;
                        //txaObsercacionSuspencion.disabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
    }

    protected bool CargarPeriodo(string IdSuspencion, string IdInstitucion)
    {
        mensaje = null;
        if (IdInstitucion == "")
        {
            IdInstitucion = "0";
        }
        DataTable DetalleDocumento = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DetallePeriodo", "", "", "", "", "", "", "", Convert.ToInt32(IdInstitucion), Convert.ToInt32(IdSuspencion), ref mensaje);
        ddlInstitucionM.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Institucion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        ddlInstitucionM.DataValueField = "IdInstitucion";
        ddlInstitucionM.DataTextField = "NombreInstitucion";
        ddlInstitucionM.DataBind();
        if (mensaje == null)
        {
            if (DetalleDocumento.Rows.Count == 0)
            {
                string script = @"<script type='text/javascript'>alert('NO HAY DATOS PARA MODIFICAR');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
            else
            {
                ddlInstitucionM.SelectedValue = DetalleDocumento.Rows[0][0].ToString();
                txtPeriodoInicioInstitucionM.Text = DetalleDocumento.Rows[0][1].ToString();
                txtPeriodoFinInstitucion.Text = DetalleDocumento.Rows[0][2].ToString();
                txaObservacionPeriodo.Value = DetalleDocumento.Rows[0][3].ToString();
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    protected void btnModificaPeriodo_Click(object sender, EventArgs e)
    {
        string IdSuspencion = lblIdsuspencionP.Text;
        string IdInstitucion = lblIdinstitucion.Text;
        string idinstitucionM = ddlInstitucionM.SelectedValue;
        string PeriodoInicioInstitucion = txtPeriodoInicioInstitucionM.Text;
        string PeriodoFinInstucion = txtPeriodoFinInstitucion.Text;
        string ObservacionPeriodo = txaObservacionPeriodo.Value;

        info.ModificaPeriodo((int)Session["IdConexion"], "U", IdSuspencion, IdInstitucion, idinstitucionM, PeriodoInicioInstitucion, PeriodoFinInstucion, ObservacionPeriodo, ref mensaje);
        if (mensaje == null)
        {
            Master.MensajeOk("Se registró la modificacion correctamente");
            this.mpeNuevoRegistro.Hide();
            cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
        }
        else
        {
            Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
            this.mpeNuevoRegistro.Hide();
            cargar_gvPeriodos(Convert.ToInt32(Session["IdBeneficio"]));
        }

    }

    protected void checkinsitucion_CheckedChanged(object sender, EventArgs e)
    {
        this.mpeNuevoRegistro.Show();
        if (this.checkinsitucion.Checked == true)
        {
            ddlInstitucion.Enabled = true;
            txtPeriodoInicioInstitucion.ReadOnly = false;
            txtPerioFinInstitucion.ReadOnly = false;
        }
        else
        {

            ddlInstitucion.Enabled = true;
            txtPeriodoInicioInstitucion.ReadOnly = true;
            txtPerioFinInstitucion.ReadOnly = true;
        }
    }

    protected void lnkSuspencionPreventiva_Click(object sender, EventArgs e)
    {
        txtEstadoSP.ReadOnly = false;
        txtNureroSuspencionsP.Text = "";
        txtNureroSuspencionsP.Enabled = true;
        txtNureroRehabilitacionSP.Text = "";
        txaObservacionSuspencionSPi.Text= "";
        txaObservacionRehabilitacionSPi.Text = "";
        txaObservacionRehabilitacionSPi.ReadOnly = true;
        txtEstadoSP.Text = "SUSPENSION PREVENTIVA";

        ddlInsitucionSP.Items.Clear();
        ddlInsitucionSP.Items.Add("SELECCIONE...");
        ddlInsitucionSP.AppendDataBoundItems = true;
        ddlInsitucionSP.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Institucion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        ddlInsitucionSP.DataValueField = "IdInstitucion";
        ddlInsitucionSP.DataTextField = "NombreInstitucion";
        ddlInsitucionSP.DataBind();
        ddlInsitucionSP.Enabled = true;

        ddlNormaPreventiva.Items.Clear();
        ddlNormaPreventiva.Items.Add("SELECCIONE...");
        ddlNormaPreventiva.AppendDataBoundItems = true;

        ddlNormaPreventiva.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Normativa", "", "", "", "", "", "", ""
                                      , 0, 0, ref mensaje);
        ddlNormaPreventiva.DataValueField = "IdDetalleClasificador";
        ddlNormaPreventiva.DataTextField = "DescripcionDetalleClasificador";
        ddlNormaPreventiva.DataBind();


       ddlTipoDocumentoSP.Items.Clear();
        ddlTipoDocumentoSP.Items.Add("SELECCIONE...");
        ddlTipoDocumentoSP.AppendDataBoundItems = true;
        ddlTipoDocumentoSP.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", ""
                                                   , 0, 0, ref mensaje);
        ddlTipoDocumentoSP.DataValueField = "IdDetalleClasificador";
        ddlTipoDocumentoSP.DataTextField = "DescripcionDetalleClasificador";

        ddlTipoDocumentoSP.DataBind();
        btnSuspencionPreventiva.Visible = true;
        btnRegistrarRehabilitacion.Visible = false;

        txtNroDocumentoSP.Text = "";
        txtFechaDocumentoSP.Text = "";
        txaReferenciaDocumentoSP.Value = "";
        txaObservacionDocumentoSP.Value = "";

        
        txtNureroSuspencionsP.ReadOnly = false;
        txtPeriodoSuspencionSP.Text = "";
        txtPeriodoRehabilitacionSP.Text = "";
        txtPeriodoSuspencionSP.ReadOnly = false;
        txtPeriodoRehabilitacionSP.ReadOnly = true;
        txtNureroRehabilitacionSP.ReadOnly = true;
        CalendarExtender16.Enabled = false;
        gvDocTemp.Visible = false;
        gvDocTemp.DataSource = null;
        gvDocTemp.DataBind();
        lblObligatorio6.Visible = true;
        lblObligatorio7.Visible = false;
        CrearTablas();
        this.mpeSP.Show();
    }

    protected void btnSuspencionPreventiva_Click(object sender, EventArgs e)
    {
        mensaje = null;

        int NroReferenciaSuspencionSP =0;
        if (txtNureroSuspencionsP.Text != "")
             NroReferenciaSuspencionSP = Convert.ToInt32(txtNureroSuspencionsP.Text);
        else
            NroReferenciaSuspencionSP = Convert.ToInt32("0");

       int NroReferenciaRehabilitacionSP = 0;
       
        if (txtNureroRehabilitacionSP.Text != "")
            NroReferenciaRehabilitacionSP = Convert.ToInt32(txtNureroRehabilitacionSP.Text);
        else
            NroReferenciaRehabilitacionSP = Convert.ToInt32("0");

        string observacionSuspencionSP = txaObservacionSuspencionSPi.Text;
        string observacionRehabilitacionSP = txaObservacionRehabilitacionSPi.Text;
        string PeriodoSuspencionSP = txtPeriodoSuspencionSP.Text;
        string PeriodoRehabilitacionSP = txtPeriodoRehabilitacionSP.Text;
        string InsitucionSP = ddlInsitucionSP.SelectedValue;

        //string normasp1 = ddlNormaPreventiva.SelectedValue;
        if (ValidarPreventivo(PeriodoSuspencionSP, PeriodoRehabilitacionSP, InsitucionSP, ddlNormaPreventiva.SelectedValue, NroReferenciaSuspencionSP, NroReferenciaRehabilitacionSP))
        {
            string TipoDocumentoSP = gvDocTemp.Rows[0].Cells[1].Text;
            string NroDocumentoSP = gvDocTemp.Rows[0].Cells[2].Text;
            string FechaDocumentoSP = gvDocTemp.Rows[0].Cells[3].Text;
            string ReferenciaDocumentoSP = gvDocTemp.Rows[0].Cells[4].Text;
            string ObservacionDocumentoSP = gvDocTemp.Rows[0].Cells[5].Text;

            long NUPsp = Convert.ToInt64(Session["NUPT"]);


            int normasp = Convert.ToInt32(ddlNormaPreventiva.SelectedValue);

            int GrupoDocumento;

            if(PeriodoRehabilitacionSP =="")
              GrupoDocumento = 917;
            else
              GrupoDocumento = 918;

            if (observacionSuspencionSP == "&nbsp;")
                observacionSuspencionSP = "";

            if (observacionRehabilitacionSP == "&nbsp;")
                observacionRehabilitacionSP = "";

            if (ReferenciaDocumentoSP == "&nbsp;")
                ReferenciaDocumentoSP = "";

            if (ObservacionDocumentoSP == "&nbsp;")
                ObservacionDocumentoSP = "";
        
            if (gvDocTemp.Rows[0].Cells[4].Text == "&nbsp;")
                gvDocTemp.Rows[0].Cells[4].Text = "";
            
            if (gvDocTemp.Rows[0].Cells[5].Text == "&nbsp;")
                gvDocTemp.Rows[0].Cells[5].Text = "";

                info.InsertarPreventivo((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUPT"]), normasp, NroReferenciaSuspencionSP
                , NroReferenciaRehabilitacionSP, PeriodoSuspencionSP, PeriodoRehabilitacionSP, InsitucionSP, observacionSuspencionSP, observacionRehabilitacionSP,
                gvDocTemp.DataKeys[0].Values["IdDocumento"].ToString(), gvDocTemp.Rows[0].Cells[2].Text, gvDocTemp.Rows[0].Cells[3].Text, gvDocTemp.Rows[0].Cells[4].Text, gvDocTemp.Rows[0].Cells[5].Text,
                ref mensaje);

            if (mensaje == null)
            {
                int NumeroDocumento = gvDocTemp.Rows.Count;

                for (int i = 1; i < NumeroDocumento; i++)
                {
                    if (gvDocTemp.Rows[i].Cells[4].Text == "&nbsp;")
                        gvDocTemp.Rows[i].Cells[4].Text = "";

                    if (gvDocTemp.Rows[i].Cells[5].Text == "&nbsp;")
                        gvDocTemp.Rows[i].Cells[5].Text = "";
                                        
                    if (mensaje == null)
                    {
                            info.InsertaDocuementoExtraPreventivo((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUPT"]), GrupoDocumento,
                            gvDocTemp.DataKeys[i].Values["IdDocumento"].ToString()
                            , gvDocTemp.Rows[i].Cells[2].Text, gvDocTemp.Rows[i].Cells[3].Text
                            , gvDocTemp.Rows[i].Cells[4].Text, gvDocTemp.Rows[i].Cells[5].Text, ref mensaje);
                        
                    }
                    else
                    {
                        Master.MensajeError("Error al insertar los los documentos de la suspension", mensaje);

                    }
                }
                if (mensaje == null)
                {
                    this.mpeSP.Hide();
                    cargar_gvSuspencionPreventiva();
                    cargar_gvDocumentoPreventivo();
                    Master.MensajeOk("Se inserto correctamente la suspension");
                }
            }
            else
            {
                Master.MensajeError("Error al intentar registrar la suspension", mensaje);
                this.mpeSP.Hide();
            }
        }
        else
            this.mpeSP.Show();

    }

    protected bool ValidarPreventivo(string PeriodoSuspencionSP, string PeriodoRehabilitacionSP, string InsitucionSP,string normaT, int NroReferenciaSuspencionSP, int NroReferenciaRehabilitacionSP)
    {
        DateTime fechaActual1 = DateTime.Now;
        int anyo3 = fechaActual1.Year;

        if (PeriodoSuspencionSP == "")
        {
            string script = @"<script type='text/javascript'>alert('NO INGRESO PERIODO DE INICIO DE SUSPENSION');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        string panyo = PeriodoSuspencionSP.Substring(0, 4);
        string pmes = PeriodoSuspencionSP.Substring(4, 2);

        if (Convert.ToInt32(panyo) < 2000 || Convert.ToInt32(panyo) > anyo3)
        {
            string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;

        }


        if (Convert.ToInt32(pmes) < 1 || Convert.ToInt32(pmes) > 12)
        {
            string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;

        }

        if (PeriodoRehabilitacionSP != "")
        {
            string panyop = PeriodoRehabilitacionSP.Substring(0, 4);
            string pmesp = PeriodoRehabilitacionSP.Substring(4, 2);

            if (Convert.ToInt32(panyop) < 2000 || Convert.ToInt32(panyop) > anyo3)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE REHABILITACION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

            if (Convert.ToInt32(pmesp) < 1 || Convert.ToInt32(pmesp) > 12)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE REHABILITACION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

    /*        if (Convert.ToInt32(PeriodoRehabilitacionSP) < Convert.ToInt32(PeriodoSuspencionSP))
            {
                string script = @"<script type='text/javascript'>alert('LA FECHA DE FIN DE SUSPENCION ES MENOR A LA DE INICIO DE SUSPENCION');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
    */
        }


        if (InsitucionSP == "SELECCIONE...")
        {
            string script = @"<script type='text/javascript'>alert('SELECCIONE INSTITUCION');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        DateTime fechaActual = DateTime.Now;
        int mes = fechaActual.Month;
        int anyo = fechaActual.Year;
        int anyo1 = Convert.ToInt32(PeriodoSuspencionSP.Substring(0, 4));
        int mes1 = Convert.ToInt32(PeriodoSuspencionSP.Substring(4, 2));

        if (mes < mes1 && anyo < anyo1)
        {
            string script = @"<script type='text/javascript'>alert('FECHA DE SUSPENSION MAYOR A LA FECHA ACTUAL');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        /*if (NroDocumentoSP == "" || FechaDocumentoSP == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE NRO DE DOCUMENTO O SU FECHA');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }*/
        if (gvDocTemp.Rows.Count == 0)
        {
            string script = @"<script type='text/javascript'>alert('INGRESE POR LO MENOS UN DOCUMENTO DE RESPALDO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (PeriodoRehabilitacionSP != "")
        {
            string panyop = PeriodoRehabilitacionSP.Substring(0, 4);
            string pmesp = PeriodoRehabilitacionSP.Substring(4, 2);

            if (Convert.ToInt32(panyop) < 2000 || Convert.ToInt32(panyop) > anyo3)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

            if (Convert.ToInt32(pmesp) < 1 || Convert.ToInt32(pmesp) > 12)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE SUSPENSION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }
        }

        if (gvDocTemp.Rows.Count == 0)
        {
            string script = @"<script type='text/javascript'>alert('INSERTE AL MENOS UN DOCUMENTO ');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        if (NroReferenciaSuspencionSP != 0)
        {
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroSuspensionP", "", "", "", "", "", "", "", Convert.ToInt16(anyo), NroReferenciaSuspencionSP, ref mensaje);
            if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
            {
                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MNroSuspensionP", "", "", "", "", "", "", "", Convert.ToInt16(anyo), NroReferenciaSuspencionSP, ref mensaje);
                string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE SUSPENSIÓN YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. MAIXMO NÚMERO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ")');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
        }

        if (NroReferenciaRehabilitacionSP != 0)
        {
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroRehabilitacionP", "", "", "", "", "", "", "", Convert.ToInt16(anyo), NroReferenciaRehabilitacionSP, ref mensaje);
            if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
            {
                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MNroRehabilitacionP", "", "", "", "", "", "", "", Convert.ToInt16(anyo), NroReferenciaRehabilitacionSP, ref mensaje);
                string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE REHABILITACION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. MAIXMO NÚMERO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ")');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
        }
        if (normaT == "SELECCIONE...")
        {
            string script = @"<script type='text/javascript'>alert('SELECCIONE UNA NORMA');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        return true;
    }
    
    protected bool ValidarPreventivoRehabilitado(string PeriodoRehabilitacionSP, int NureroRehabilitacionSP)
    {
        DateTime fechaActual = DateTime.Now;
        int mes = fechaActual.Month;
        int anyo = fechaActual.Year;
        int anyo1 = Convert.ToInt32(PeriodoRehabilitacionSP.Substring(0, 4));
        int mes1 = Convert.ToInt32(PeriodoRehabilitacionSP.Substring(4, 2));
        int anyo3 = fechaActual.Year;
        if (PeriodoRehabilitacionSP != "")
        {
            string panyop = PeriodoRehabilitacionSP.Substring(0, 4);
            string pmesp = PeriodoRehabilitacionSP.Substring(4, 2);

            if (Convert.ToInt32(panyop) < 2000 || Convert.ToInt32(panyop) > anyo3)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE REHABILITACION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

            if (Convert.ToInt32(pmesp) < 1 || Convert.ToInt32(pmesp) > 12)
            {
                string script = @"<script type='text/javascript'>alert('FORMATO DE PERIODO DE REHABILITACION INCORRECTO EL FORMATO ES AAAAMM (EJM 201503)');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;

            }

            /*        if (Convert.ToInt32(PeriodoRehabilitacionSP) < Convert.ToInt32(PeriodoSuspencionSP))
                    {
                        string script = @"<script type='text/javascript'>alert('LA FECHA DE FIN DE SUSPENCION ES MENOR A LA DE INICIO DE SUSPENCION');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return false;
                    }
            */
        }

        if (NureroRehabilitacionSP != 0)
        {
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroRehabilitacionP", "", "", "", "", "", "", "", Convert.ToInt16(anyo), NureroRehabilitacionSP, ref mensaje);
            if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
            {
                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MNroRehabilitacionP", "", "", "", "", "", "", "", Convert.ToInt16(anyo), NureroRehabilitacionSP, ref mensaje);
                string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE REHABILITACION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. MAIXMO NÚMERO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ")');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return false;
            }
        }
        return true;
    }


    protected void gvSuspencionPreventiva_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        string IdSuspensionPreventiva = gvSuspencionPreventiva.DataKeys[indice].Values["IdSuspensionPreventiva"].ToString();
        string IdInstitucion = gvSuspencionPreventiva.DataKeys[indice].Values["IdInstitucion"].ToString();
        string IdNormaId = gvSuspencionPreventiva.DataKeys[indice].Values["IdNormaId"].ToString();
        DateTime fechaActual = DateTime.Now;
        string anyo = Convert.ToString(fechaActual.Year);
        string mes = null;
        if (fechaActual.Month < 10)
            mes = "0" + (Convert.ToString(fechaActual.Month));
        else
            mes = Convert.ToString(fechaActual.Month);
        if (e.CommandName == "cmdModificar")
        {
            try
            {
                CargarSuspencionPreventiva(IdSuspensionPreventiva);
                this.mpeModificaPreventiva.Show();
                string anyo1 = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[8].Text).Substring(6, 4);
                string mes1 = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[8].Text).Substring(3, 2);
                gvDocTemp.Visible = false;
                gvDocTemp.DataSource = null;
                gvDocTemp.DataBind();
                if (anyo1 == anyo && mes1 == mes)
                {
                    txtPeriodoSuspencionSPM.ReadOnly = false;
                    txtNroReferenciaSupencionSPM.ReadOnly = false;
                }      

                else
                {
                    txtPeriodoSuspencionSPM.ReadOnly = true;
                    txtNroReferenciaSupencionSPM.ReadOnly = true;
                    ddlInsitucionSPM.Enabled = false;
                    txtObservacionSuspencionSPM.ReadOnly = true;
                }
                

                string fechaRehabilitacion = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[9].Text);
                if (fechaRehabilitacion != "&nbsp;")
                {
                    anyo1 = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[9].Text).Substring(6, 4);
                    mes1 = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[9].Text).Substring(3, 2);

                    if (anyo1 == anyo && mes1 == mes)
                    {
                        txtPeriodoDesactivacionSPM.ReadOnly = false;
                        txtNroReferenciaRehabilitacionSPM.ReadOnly = false;
                        txtObservacionDesactivacionSPM.ReadOnly = false;
                    }

                    else
                    {
                        txtPeriodoDesactivacionSPM.ReadOnly = true;
                        txtNroReferenciaRehabilitacionSPM.ReadOnly = true;
                        txtObservacionDesactivacionSPM.ReadOnly = true;
                        ddlInsitucionSPM.Enabled = false;
						Image8.Enabled = false;
                    }
                }
                else 
                {
                    txtPeriodoDesactivacionSPM.ReadOnly = true;
                    CalendarExtender11.Enabled = false;
                    txtNroReferenciaRehabilitacionSPM.ReadOnly = true;
                    txtObservacionDesactivacionSPM.ReadOnly = true;      

                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
        if (e.CommandName == "cmdRehabilitar")
        {
            lblIdSuspencionPreventivaS.Text = IdSuspensionPreventiva;
            txtEstadoSP.ReadOnly = false;
            txtNureroSuspencionsP.Text = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[4].Text);
            txtNureroSuspencionsP.ReadOnly = true;
            txtNureroRehabilitacionSP.Text = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[3].Text);
            txtPeriodoSuspencionSP.Text = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[10].Text);
            txtPeriodoSuspencionSP.ReadOnly = true;
            txtPeriodoRehabilitacionSP.Text = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[11].Text);
            CalendarExtender15.Enabled = false;
            txtPeriodoRehabilitacionSP.ReadOnly = false;
            txtNureroRehabilitacionSP.ReadOnly = false;
            CalendarExtender16.Enabled = true;

            if (Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[6].Text) != "&nbsp;")
                txaObservacionSuspencionSPi.Text = Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[6].Text);
            else
                txaObservacionSuspencionSPi.Text = "";

            txaObservacionSuspencionSPi.ReadOnly = true;

            if (Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[7].Text)!="&nbsp;")
                txaObservacionRehabilitacionSPi.Text= Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[7].Text);
            else
                txaObservacionRehabilitacionSPi.Text = "";
            
            txaObservacionRehabilitacionSPi.ReadOnly = false;
            
            txtEstadoSP.Text = "SUSPENCION PREVENTIVA";

            ddlInsitucionSP.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Institucion", "", "", "", "", "", "", ""
                                                 , 0, 0, ref mensaje);
            ddlInsitucionSP.DataValueField = "IdInstitucion";
            ddlInsitucionSP.DataTextField = "NombreInstitucion";
            ddlInsitucionSP.DataBind();
            if (IdInstitucion!="")
            ddlInsitucionSP.SelectedValue = IdInstitucion;

            ddlNormaPreventiva.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Normativa", "", "", "", "", "", "", ""
                                          , 0, 0, ref mensaje);
            ddlNormaPreventiva.DataValueField = "IdDetalleClasificador";
            ddlNormaPreventiva.DataTextField = "DescripcionDetalleClasificador";
            ddlNormaPreventiva.DataBind();

            if (IdNormaId != "")
            { ddlNormaPreventiva.SelectedValue = IdNormaId; }

            ddlNormaPreventiva.Enabled = false;

            ddlTipoDocumentoSP.Items.Clear();
            ddlTipoDocumentoSP.Items.Add("SELECCIONE...");
            ddlTipoDocumentoSP.AppendDataBoundItems = true;
            ddlTipoDocumentoSP.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", ""
                                                       , 0, 0, ref mensaje);
            ddlTipoDocumentoSP.DataValueField = "IdDetalleClasificador";
            ddlTipoDocumentoSP.DataTextField = "DescripcionDetalleClasificador";

            ddlTipoDocumentoSP.DataBind();
            txaReferenciaDocumentoSP.Value = "";
            txaObservacionDocumentoSP.Value = "";
            txtNroDocumentoSP.Text = "";
            txtFechaDocumentoSP.Text = "";
            btnSuspencionPreventiva.Visible = false;
            btnRegistrarRehabilitacion.Visible = true;
            ddlInsitucionSP.Enabled = false;

            gvDocTemp.Visible = false;
            gvDocTemp.DataSource = null;
            gvDocTemp.DataBind();

            lblObligatorio6.Visible = false;
            lblObligatorio7.Visible = true;

            CrearTablas();
            this.mpeSP.Show();
        }
    }

    protected void CargarSuspencionPreventiva(string IdSuspensionPreventiva)
    {
        mensaje = null;
        DataTable DetalleSuspencionPreventiva = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DetalleSuspencionP", "", "", "", "", "", "", "", 0, Convert.ToInt32(IdSuspensionPreventiva), ref mensaje);
        ddlInsitucionSPM.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Institucion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        ddlInsitucionSPM.DataValueField = "IdInstitucion";
        ddlInsitucionSPM.DataTextField = "NombreInstitucion";
        ddlInsitucionSPM.DataBind();

        if (mensaje == null)
        {
            lblIdSuspencionPreventiva.Text = DetalleSuspencionPreventiva.Rows[0][0].ToString();

            if (DetalleSuspencionPreventiva.Rows[0][6].ToString()!="")
            ddlInsitucionSPM.SelectedValue = DetalleSuspencionPreventiva.Rows[0][6].ToString();
            
            txtPeriodoSuspencionSPM.Text = DetalleSuspencionPreventiva.Rows[0][4].ToString();
            txtPeriodoDesactivacionSPM.Text = DetalleSuspencionPreventiva.Rows[0][5].ToString();
            txtNroReferenciaSupencionSPM.Text = DetalleSuspencionPreventiva.Rows[0][2].ToString();

            Session["txtNroReferenciaSupencionSPM"] = txtNroReferenciaSupencionSPM.Text;
            txtNroReferenciaRehabilitacionSPM.Text = DetalleSuspencionPreventiva.Rows[0][3].ToString();
            if (txtNroReferenciaRehabilitacionSPM.Text == "")
                txtNroReferenciaRehabilitacionSPM.Text = "0";
            Session["txtNroReferenciaRehabilitacionSPM"] = txtNroReferenciaRehabilitacionSPM.Text;

            txtObservacionSuspencionSPM.Text = DetalleSuspencionPreventiva.Rows[0][7].ToString();
            if (txtObservacionSuspencionSPM.Text == "&nbsp;")
                txtObservacionSuspencionSPM.Text = "";

            txtObservacionDesactivacionSPM.Text = DetalleSuspencionPreventiva.Rows[0][8].ToString();

            if (txtObservacionDesactivacionSPM.Text == "&nbsp;")
                txtObservacionDesactivacionSPM.Text= "";

        }
    }

    protected void btnModificaSuspencionPreventiva_Click(object sender, EventArgs e)
    {

        mensaje = null;
        string IdSuspencionPreventiva = lblIdSuspencionPreventiva.Text;
        string InsitucionSPM = ddlInsitucionSPM.SelectedValue;
        string PeriodoSuspencionSPM = txtPeriodoSuspencionSPM.Text;
        string PeriodoDesactivacionSPM = txtPeriodoDesactivacionSPM.Text;
        string NroReferenciaSupencionSPM = txtNroReferenciaSupencionSPM.Text;
        string NroReferenciaRehabilitacionSPM = txtNroReferenciaRehabilitacionSPM.Text;

        string ObservacionSuspencionSPM = txtObservacionSuspencionSPM.Text;
        string ObservacionDesactivacionSPM = txtObservacionDesactivacionSPM.Text;


        if (ValidarModificacionPreventiva(NroReferenciaSupencionSPM, NroReferenciaRehabilitacionSPM))
        {
            info.ModificaSuspencionPreventiva((int)Session["IdConexion"], "U", Convert.ToInt32(IdSuspencionPreventiva), Convert.ToInt32(InsitucionSPM), PeriodoSuspencionSPM, PeriodoDesactivacionSPM, Convert.ToInt32(NroReferenciaSupencionSPM), Convert.ToInt32(NroReferenciaRehabilitacionSPM), ObservacionSuspencionSPM, ObservacionDesactivacionSPM, ref mensaje);
            cargar_gvSuspencionPreventiva();
            cargar_gvDocumentoPreventivo();
            if (mensaje == null)
            {
                Master.MensajeOk("Se registró la modificacion correctamente");
                this.mpeModificaPreventiva.Hide();
            }
            else
            {
                Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
                this.mpeModificaPreventiva.Hide();
            }
        }
        else { this.mpeModificaPreventiva.Show(); }
       
    }

    protected bool ValidarModificacionPreventiva(string NroReferenciaSupencionSPM,string NroReferenciaRehabilitacionSPM)
    {
        DateTime fechaActual = DateTime.Now;
        if (Session["txtNroReferenciaRehabilitacionSPM"].ToString() != NroReferenciaRehabilitacionSPM)
         {
             if (NroReferenciaRehabilitacionSPM != "0")
                 {
                     Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroRehabilitacionP", "", "", "", "", "", "", "", fechaActual.Year,Convert.ToInt32( NroReferenciaRehabilitacionSPM), ref mensaje);
                    if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
                    {
                        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MNroRehabilitacionP", "", "", "", "", "", "", "", fechaActual.Year, 0, ref mensaje);
                        string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE REHABILITACION YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. MAIXMO NÚMERO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ")');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        return false;
                    }
                    else { return true; }
                 }
             return false;
         }
        if (Session["txtNroReferenciaSupencionSPM"].ToString() != NroReferenciaSupencionSPM)
         {
             if (NroReferenciaSupencionSPM != "0")
             {
                 Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "NroSuspensionP", "", "", "", "", "", "", "", fechaActual.Year, Convert.ToInt32(NroReferenciaSupencionSPM), ref mensaje);
                 if (Convert.ToInt32(Encontrados.Rows[0][0].ToString()) >= 1)
                 {
                     Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "MNroSuspensionP", "", "", "", "", "", "", "", fechaActual.Year, 0, ref mensaje);
                     string script = @"<script type='text/javascript'>alert('NRO DE REFERENCIA DE SUSPENSIÓN YA SE ENCUENTRA REGISTRADO PORFAVOR INGRESE OTRO NUMERO. MAIXMO NÚMERO REGISTRADO(" + Encontrados.Rows[0][0].ToString() + ")');</script>";
                     ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                     return false;
                 }
                 else { return true; }
             }
             return false;
         }
        return true;
    }

    protected void gvDocumentosPreventivos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        string IdSuspensionPreventiva = gvDocumentosPreventivos.DataKeys[indice].Values["IdSuspensionPeventiva"].ToString();
        string IdDocumento = gvDocumentosPreventivos.DataKeys[indice].Values["IdDocumento"].ToString();
        string IdGrupoDocumentp = gvDocumentosPreventivos.DataKeys[indice].Values["IdGrupoDocumento"].ToString();
        
        lblIdSuspensionPreventiva.Text = IdSuspensionPreventiva;
        lblIdDocumento.Text = IdDocumento;

        DateTime fechaActual = DateTime.Now;
        string anyo = Convert.ToString(fechaActual.Year);
        string mes = null;
        if (fechaActual.Month < 10)
            mes = "0" + Convert.ToString(fechaActual.Month);
        else
            mes = Convert.ToString(fechaActual.Month);

        if (e.CommandName == "cmdModificarDocumento")
        {

            try
            {
                var s = string.Empty;

                int ind = -1;
                foreach (GridViewRow r in gvSuspencionPreventiva.Rows)
                {
                    s = Convert.ToString(gvSuspencionPreventiva.DataKeys[r.RowIndex]["IdSuspensionPreventiva"].ToString());
                    if (IdSuspensionPreventiva == s)
                    {
                        ind = Convert.ToInt32(r.RowIndex);
                        break;
                    }
                }

                CargarDocumentoPeventivo(IdSuspensionPreventiva, IdDocumento);
                this.mpeModificaDocumentoSPM.Show();

                if (ind != -1)
                {
                   
                    string fecha = Convert.ToString(gvSuspencionPreventiva.Rows[ind].Cells[4].Text);
                    string anyo1 = Convert.ToString(gvSuspencionPreventiva.Rows[ind].Cells[8].Text).Substring(6, 4);
                    string mes1 = Convert.ToString(gvSuspencionPreventiva.Rows[ind].Cells[8].Text).Substring(3, 2);

                    if (anyo1 == anyo && mes1 == mes)
                    {
                        txtNroDocumentoM.ReadOnly = false;


                    }
                    else
                    {
                        txtNroDocumentoSPM.ReadOnly = true;
                        txtFechaDocumentoSPM.ReadOnly = true;
                        ddlTipoDocumentoSPM.Enabled = false;
                        CalendarExtender4.Enabled = false;
                       // txaObservacionDocumentoSPM.ReadOnly= true;
                       // txareferenciaSPM.ReadOnly = true;
                    }
                }



            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
    }

    protected void CargarDocumentoPeventivo(string IdSuspensionPreventiva, string IdDocumento)
    {
        mensaje = null;
        DataTable DetalleDocumento = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DetalleDocumentoSP", "", "", "", "", "", "", "", Convert.ToInt32(IdDocumento), Convert.ToInt32(IdSuspensionPreventiva), ref mensaje);

        ddlTipoDocumentoSPM.Items.Clear();
        ddlTipoDocumentoSPM.Items.Add("SELECCIONE...");
        ddlTipoDocumentoSPM.AppendDataBoundItems = true;
        ddlTipoDocumentoSPM.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        ddlTipoDocumentoSPM.DataValueField = "IdDetalleClasificador";
        ddlTipoDocumentoSPM.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoDocumentoSPM.DataBind();

        if (mensaje == null)
        {
            ddlTipoDocumentoSPM.SelectedValue = DetalleDocumento.Rows[0][2].ToString();
            txtNroDocumentoSPM.Text = DetalleDocumento.Rows[0][3].ToString();
            txtFechaDocumentoSPM.Text = DetalleDocumento.Rows[0][4].ToString();
            txareferenciaSPM.Value = DetalleDocumento.Rows[0][5].ToString();
            txaObservacionDocumentoSPM.Value = DetalleDocumento.Rows[0][6].ToString();
            lblDocumentoSPM.Text = DetalleDocumento.Rows[0][7].ToString();
        }

    }

    protected void btnModificarSPM_Click(object sender, EventArgs e)
    {
        string IdSuspencion = lblIdSuspensionPreventiva.Text;
        string IdDocumento = lblIdDocumento.Text;
        string idTipoDocumento = ddlTipoDocumentoSPM.SelectedValue;
        string NroDocumento = txtNroDocumentoSPM.Text;
        string FechaDocumento = txtFechaDocumentoSPM.Text;
        string ReferenciaDocumento = txareferenciaSPM.Value;
        string ObservacionDocumento = txaObservacionDocumentoSPM.Value;

        info.ModificaDocumentoSuspencionPreventiva((int)Session["IdConexion"], "U", IdSuspencion, IdDocumento, idTipoDocumento, NroDocumento, FechaDocumento, ReferenciaDocumento, ObservacionDocumento, ref mensaje);


        if (mensaje == null)
        {
            Master.MensajeOk("Se registró la modificacion correctamente");
            this.mpeNuevoRegistro.Hide();
            cargar_gvDocumentoPreventivo();
        }
        else
        {
            Master.MensajeError("Error al intentar registrar la modificacion", mensaje);
            this.mpeNuevoRegistro.Hide();
        }

    }

    protected void btnRegistrarRehabilitacion_Click(object sender, EventArgs e)
    {
        string PeriodoRehabilitacionSP = txtPeriodoRehabilitacionSP.Text;
        string NureroRehabilitacionSP = txtNureroRehabilitacionSP.Text;
        string ObservacionRehabilitacionSP = txaObservacionRehabilitacionSPi.Text;
        string TipoDocumentoSP = ddlTipoDocumentoSP.SelectedValue;
        string NroDocumentoSP = txtNroDocumentoSP.Text;
        string FechaDocumentoSP = txtFechaDocumentoSP.Text;
        string ReferenciaDocumentoSP = txaReferenciaDocumentoSP.Value;
        string ObservacionDocumentoSP = txaObsercacionSuspencion.Value;
        const int normasp = 0;
        string id = lblIdSuspencionPreventivaS.Text;
              
         if (gvDocTemp.Rows[0].Cells[4].Text == "&nbsp;")
             gvDocTemp.Rows[0].Cells[4].Text = "";
            
        if (gvDocTemp.Rows[0].Cells[5].Text == "&nbsp;")
            gvDocTemp.Rows[0].Cells[5].Text = "";

        if (ValidarPreventivoRehabilitado( PeriodoRehabilitacionSP,Convert.ToInt32(NureroRehabilitacionSP)))
        {
            info.RehabilitaPreventivo((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUPT"]), id, normasp,
            Convert.ToInt32(NureroRehabilitacionSP), PeriodoRehabilitacionSP, ObservacionRehabilitacionSP,
            gvDocTemp.DataKeys[0].Values["IdDocumento"].ToString(), gvDocTemp.Rows[0].Cells[2].Text, gvDocTemp.Rows[0].Cells[3].Text, gvDocTemp.Rows[0].Cells[4].Text, gvDocTemp.Rows[0].Cells[5].Text,
            ref mensaje);
    

        if (mensaje == null)
        {

            int NumeroDocumento = gvDocTemp.Rows.Count;

            for (int i = 1; i < NumeroDocumento; i++)
            {
                if (gvDocTemp.Rows[i].Cells[4].Text == "&nbsp;")
                gvDocTemp.Rows[i].Cells[4].Text = "";
            
                if (gvDocTemp.Rows[i].Cells[5].Text == "&nbsp;")
                gvDocTemp.Rows[i].Cells[5].Text = "";

                info.InsertaDocuementoExtraPreventivo((int)Session["IdConexion"], "I", 
                Convert.ToInt64(Session["NUPT"]), 918,
                gvDocTemp.DataKeys[i].Values["IdDocumento"].ToString(),gvDocTemp.Rows[i].Cells[2].Text, gvDocTemp.Rows[i].Cells[3].Text
                , gvDocTemp.Rows[i].Cells[4].Text, gvDocTemp.Rows[i].Cells[5].Text, ref mensaje);
            }
            cargar_gvSuspencionPreventiva();
            cargar_gvDocumentoPreventivo();
        }
            if (mensaje == null)
            {
                Master.MensajeOk("Se registró la modificacion correctamente");
                this.mpeNuevoRegistro.Hide();

            }
            else
            {
                Master.MensajeError("Error al intentar registrar la suspencion", mensaje);
                this.mpeNuevoRegistro.Hide();
            }
        }
        else
            this.mpeSP.Show();

    }


    protected void btnPC_Click(object sender, EventArgs e)
    {
        string RangoEPC = txtRangoEPC.Text;
        string RangoSPC = txtRangoSPC.Text;
        string fechaini = RangoEPC.Substring(6, 4) + RangoEPC.Substring(3, 2) + RangoEPC.Substring(0, 2);
        string fechafin = RangoSPC.Substring(6, 4) + RangoSPC.Substring(3, 2) + RangoSPC.Substring(0, 2);
        gvPagos.Visible = true;
        gvPagos.DataSourceID = null;
        gvPagos.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Pagos", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, fechaini, fechafin, CUA, NUP, 0, ref mensaje);
        gvPagos.DataBind();


        gvConciliacion.Visible = true;
        gvConciliacion.DataSourceID = null;
        gvConciliacion.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Conciliacion", Paterno, Materno, PrimerNombre
                        , txtSegundoNombre.Text, fechaini, fechafin, CUA, NUP, 0, ref mensaje);
        gvConciliacion.DataBind();
    }

    protected void lblMasDocumentos1_Click(object sender, EventArgs e)
    {
        bandera = 1;
        if (this.MasDocumentos1.Visible == true)
        {
            lblMasDoc1.Text = "Mas Documentos";
            this.MasDocumentos1.Visible = false;
        }
        else
        {

            ddldocumentoextra1.Items.Clear();
            ddldocumentoextra1.Items.Add("SELECCIONE...");
            ddldocumentoextra1.AppendDataBoundItems = true;

            ddldocumentoextra1.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocumento", "", "", "", "", "", "", ""
                                                , 0, 0, ref mensaje);
            ddldocumentoextra1.DataValueField = "IdDetalleClasificador";
            ddldocumentoextra1.DataTextField = "DescripcionDetalleClasificador";
            ddldocumentoextra1.DataBind();

            this.MasDocumentos1.Visible = true;
            txtdocumentoextra1.Text = "";
            txtfechadocumentoextra1.Text = "";
            txaReferenciadocumentoextra1.Value = "";
            txaObservacionDocumentoExtra1.Value = "";
            lblMasDoc1.Text = "Menos Documentos";
        }

        this.mpeNuevoRegistro.Show();
    }

    protected void gvSuspencionPreventiva_DataBound(object sender, EventArgs e)
    {
        string fecha = null;
        int indice = 0;
        foreach (GridViewRow row in gvSuspencionPreventiva.Rows)
        {
            if (row.Cells[14].Text == "ANTIGUO")
            {
                //12-revisar;13-ver errores;14-vermedio
                row.Cells[16].Enabled = false;
                row.Cells[16].ForeColor = Color.Gray;
                row.Cells[17].Enabled = false;
                row.Cells[17].ForeColor = Color.Gray;
            }
            else
            {
                DateTime fechaActual = DateTime.Now ;
                fecha =  Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[8].Text).Substring(6,4)+
                    Convert.ToString(gvSuspencionPreventiva.Rows[indice].Cells[8].Text).Substring(3, 2);
                string fecha2 = "";
                string fecha3 = "";
                if (fechaActual.Month<10) 
                {
                    fecha3 = "0" + Convert.ToString(fechaActual.Month);
                }
                else { fecha3 = Convert.ToString(fechaActual.Month); }
                fecha2 = Convert.ToString(fechaActual.Year) + fecha3;
                if (BanderaHabilitacion == 0)
                {

                    row.Cells[15].Enabled = false;
                    row.Cells[15].ForeColor = Color.Gray;
                    row.Cells[16].Enabled = false;
                    row.Cells[16].ForeColor = Color.Gray;
                }
                if (gvSuspencionPreventiva.Rows[indice].Cells[10].Text != "&nbsp;"& fecha!=fecha2)
                {
                    row.Cells[16].Enabled = false;
                    row.Cells[16].ForeColor = Color.Gray;
                }
                if (gvSuspencionPreventiva.Rows[indice].Cells[11].Text != "&nbsp;")
                {
					
					row.Cells[16].Enabled = true;
                    row.Cells[16].ForeColor = Color.Blue;
                    row.Cells[17].Enabled = false;
                    row.Cells[17].ForeColor = Color.Gray;
                }
            }
            indice++;
        }
    }

    protected void gvDocumentosPreventivos_DataBound(object sender, EventArgs e)
    {
        int indice = 0;
        string fecha = null;
        string IdSuspensionBeneficio = null;

        foreach (GridViewRow row in gvDocumentosPreventivos.Rows)
        {
            string registro = gvDocumentosPreventivos.DataKeys[indice].Values["RegistroActivo"].ToString();
            if (registro == "0")
            {
                row.Cells[8].Enabled = false;
                row.Cells[8].ForeColor = Color.Gray;
                /*row.Cells[16].Enabled = false;
                row.Cells[16].ForeColor = Color.Gray;*/

            }
            else
            {
                DateTime fechaActual = DateTime.Now;

                IdSuspensionBeneficio = gvDocumentosPreventivos.DataKeys[indice].Values["IdSuspensionPeventiva"].ToString();
                int ii = 0;

                foreach (GridViewRow row1 in gvSuspencionPreventiva.Rows)
                {
                    string IdSuspencionBeneficio1 = gvSuspencionPreventiva.DataKeys[ii].Values["IdSuspensionPreventiva"].ToString();
                    if (IdSuspencionBeneficio1 == IdSuspensionBeneficio)
                    {
                        if (Convert.ToInt32(gvDocumentosPreventivos.DataKeys[indice].Values["IdGrupoDocumento"].ToString()) == 917)
                            fecha = Convert.ToString(gvSuspencionPreventiva.Rows[ii].Cells[8].Text).Substring(3, 2);
                        else
                            fecha = Convert.ToString(gvSuspencionPreventiva.Rows[ii].Cells[9].Text).Substring(3, 2);
                    }
                    ii++;
                }
                int mes = (Convert.ToInt32(fecha));
                if ((BanderaHabilitacion == 0) || (fechaActual.Month > mes))
                {
                    row.Cells[10].Enabled = false;
                    row.Cells[10].ForeColor = Color.Gray;
                }

            }
            indice++;
        }
    }

    protected void gvSuspencion_DataBound(object sender, EventArgs e)
    {
        int indice = 0;
        string fecha = null;
        DateTime fechaActual2 = DateTime.Now; ;
        foreach (GridViewRow row in gvSuspencion.Rows)
        {
            string registro = gvSuspencion.DataKeys[indice].Values["RegistroActivo"].ToString();
            if (registro == "False")
            {
                row.Cells[12].Enabled = false;
                row.Cells[12].ForeColor = Color.Gray;
                /*row.Cells[16].Enabled = false;
                row.Cells[16].ForeColor = Color.Gray;*/

            }
            else
            {
                DateTime fechaActual = DateTime.Now;
                fecha = Convert.ToString(gvSuspencion.Rows[indice].Cells[3].Text).Substring(6, 4) + Convert.ToString(gvSuspencion.Rows[indice].Cells[3].Text).Substring(3, 2);
                if (Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text) != "&nbsp;")
                {
                    fecha = Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text).Substring(6, 4) + Convert.ToString(gvSuspencion.Rows[indice].Cells[4].Text).Substring(3, 2);
                }
               
                string mess  = Convert.ToString(fechaActual.Month);
                if (fechaActual.Month<10)
                {
                    mess = '0' + Convert.ToString(fechaActual.Month);
                }
                string FechaHoy = Convert.ToString(fechaActual.Year) + mess;

                if ((BanderaHabilitacion == 0) || ((Convert.ToInt32(fecha)) < (Convert.ToInt32(FechaHoy))) ||
                    (Convert.ToString(gvSuspencion.Rows[indice].Cells[1].Text) == "SUSPENSION MOMENTANEA") || (BanderaHabilitacionRol == 0))
                {
                    row.Cells[12].Enabled = false;
                    row.Cells[12].ForeColor = Color.Gray;
                }
            }
            indice++;
        }
    }

    protected void gvDocumentos_DataBound(object sender, EventArgs e)
    {
        int indice = 0;
        string fecha = null;
        string TipoSuspension = "";
        string IdSuspensionBeneficio = null;
        string IdSuspencionBeneficio1 = null;
        foreach (GridViewRow row in gvDocumentos.Rows)
        {
            string registro = gvDocumentos.DataKeys[indice].Values["RegistroActivo"].ToString();
            if (registro == "False")
            {
                row.Cells[9].Enabled = false;
                row.Cells[9].ForeColor = Color.Gray;
                /*row.Cells[16].Enabled = false;
                row.Cells[16].ForeColor = Color.Gray;*/

            }
            else
            {
                DateTime fechaActual = DateTime.Now;
                IdSuspensionBeneficio = gvDocumentos.DataKeys[indice].Values["IdSuspensionBeneficio"].ToString();
                int ii = 0;
                foreach (GridViewRow row1 in gvSuspencion.Rows)
                {
                     IdSuspencionBeneficio1 = gvSuspencion.DataKeys[ii].Values["IdSuspencionBeneficio"].ToString();
                    
                    if (IdSuspencionBeneficio1 == IdSuspensionBeneficio)
                    {
                        //fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[3].Text).Substring(3, 2);
                        fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[3].Text).Substring(6, 4) + Convert.ToString(gvSuspencion.Rows[ii].Cells[3].Text).Substring(3, 2);
                        if (Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text) != "&nbsp;")
                        {
                            //fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text).Substring(3, 2);
                            fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text).Substring(6, 4) + Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text).Substring(3, 2);
                            TipoSuspension = Convert.ToString(gvSuspencion.Rows[ii].Cells[1].Text);
                        }
                    }
                    ii++;
                }
                string mess = Convert.ToString(fechaActual.Month);
                if (fechaActual.Month < 10)
                {
                    mess = '0' + Convert.ToString(fechaActual.Month);
                }
                string FechaHoy = Convert.ToString(fechaActual.Year) + mess;
                if ((BanderaHabilitacion == 0) || ((Convert.ToInt32(fecha)) < (Convert.ToInt32(FechaHoy))) || (BanderaHabilitacionRol == 0) || (BanderaHabilitacionRol == 0))
                {
                    row.Cells[9].Enabled = false;
                    row.Cells[9].ForeColor = Color.Gray;
                }
                else
                {
                    if ((TipoSuspension == "SUSPENSION MOMENTANEA") && (IdSuspencionBeneficio1 != IdSuspensionBeneficio))
                    {
                        row.Cells[9].Enabled = false;
                        row.Cells[9].ForeColor = Color.Gray;
                    }
                }

            }
            indice++;
        }
    }
    protected void gvPeriodosIncurridos_DataBound(object sender, EventArgs e)
    {
        int indice = 0;
        string fecha = null;
        string IdSuspensionBeneficio = null;
        string IdSuspencionBeneficio1 = null;
        string TipoSuspension = "";
        int i = 0;
        foreach (GridViewRow row in gvPeriodosIncurridos.Rows)
        {
            string registro = gvPeriodosIncurridos.DataKeys[indice].Values["RegistroActivo"].ToString();
            string g = gvPeriodosIncurridos.Rows[indice].Cells[7].Text;
            if (gvPeriodosIncurridos.Rows[i].Cells[7].Text == "Periodo Devolucion TGN")
            {
                row.Cells[9].Enabled = false;
                row.Cells[9].ForeColor = Color.Gray;
            }
            if (registro == "False")
            {
                row.Cells[9].Enabled = false;
                row.Cells[9].ForeColor = Color.Gray;
                /*row.Cells[16].Enabled = false;
                row.Cells[16].ForeColor = Color.Gray;*/
            }
            else
            {
                DateTime fechaActual = DateTime.Now;
                IdSuspensionBeneficio = gvPeriodosIncurridos.DataKeys[indice].Values["IdSuspension"].ToString();
                int ii = 0;

                foreach (GridViewRow row1 in gvSuspencion.Rows)
                {
                    IdSuspencionBeneficio1 = gvSuspencion.DataKeys[ii].Values["IdSuspencionBeneficio"].ToString();
                    if (IdSuspencionBeneficio1 == IdSuspensionBeneficio)
                    {
                        //fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[3].Text).Substring(3, 2);
                        fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[3].Text).Substring(6, 4) + Convert.ToString(gvSuspencion.Rows[ii].Cells[3].Text).Substring(3, 2);
                        if (Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text) != "&nbsp;")
                        {
                            //fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text).Substring(3, 2);
                            fecha = Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text).Substring(6, 4) + Convert.ToString(gvSuspencion.Rows[ii].Cells[4].Text).Substring(3, 2);
                            TipoSuspension = Convert.ToString(gvSuspencion.Rows[ii].Cells[1].Text);
                        }

                    }
                    ii++;
                }
                string mess = Convert.ToString(fechaActual.Month);
                if (fechaActual.Month < 10)
                {
                    mess = '0' + Convert.ToString(fechaActual.Month);
                }
                string FechaHoy = Convert.ToString(fechaActual.Year) + mess;

                if ((BanderaHabilitacion == 0) || ((Convert.ToInt32(fecha)) < (Convert.ToInt32(FechaHoy))) || (BanderaHabilitacionRol == 0))
                {
                    row.Cells[9].Enabled = false;
                    row.Cells[9].ForeColor = Color.Gray;
                }
                else
                {
                    if ((TipoSuspension == "SUSPENSION MOMENTANEA") && (IdSuspencionBeneficio1 != IdSuspensionBeneficio))
                    {
                        row.Cells[9].Enabled = false;
                        row.Cells[9].ForeColor = Color.Gray;
                    }
                }
            }
            indice++;
            i++;
        }
    }
    protected void ddlNuevoEstado_SelectedIndexChanged(object sender, EventArgs e)
    {

        this.mpeNuevoRegistro.Show();
        int s = Convert.ToInt32(ddlNuevoEstado.SelectedValue);
        int indiceUltimaFila = gvSuspencion.Rows.Count - 1;
        int indiceUltimaFilaP = gvPeriodosIncurridos.Rows.Count - 1;

        if (s == 364)
        {
            if (indiceUltimaFila != -1)
            {
                txtnorma.Text = gvSuspencion.Rows[indiceUltimaFila].Cells[2].Text;
                ddlnorma.Visible = false;
                txtnorma.Visible = true;
                txtnorma.ReadOnly = true;
                ddlInstitucion.Enabled = true;
                lblobligatorio3.Visible = false;
                if (indiceUltimaFila != -1)
                {
                    Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "PeriodoSuspension", "", "", "", "", "", "", "", NUP, 0, ref mensaje);
                    DataRow row = Encontrados.Rows[0];
                    txtFechaSuspencion.Text = row[0].ToString();
                }
                else
                {
                    DateTime fechaActual = DateTime.Now;
                    string anyo = Convert.ToString(fechaActual.Year);
                    string mes = null;
                    if (fechaActual.Month < 10)
                        mes = "0" + Convert.ToString(fechaActual.Month);
                    else
                        mes = Convert.ToString(fechaActual.Month);

                    txtFechaSuspencion.Text = anyo + mes;
                }
                CalendarExtender8.Enabled = false;
                CalendarExtender9.Enabled = true;
            }

            
        }
        else
        {
            ddlnorma.Visible = true;
            txtnorma.Visible = false;
            lblobligatorio3.Visible = Visible;

            DateTime fechaActual = DateTime.Now;
            string anyo = Convert.ToString(fechaActual.Year);
            string mes = null;
            if (fechaActual.Month < 10)
                mes = "0" + Convert.ToString(fechaActual.Month);
            else
                mes = Convert.ToString(fechaActual.Month);

            txtFechaSuspencion.Text = anyo + mes;

            txtFechaSuspencion.ReadOnly = false;

            txtFechaRehabilitacion.Text = "";
            txtFechaRehabilitacion.ReadOnly = true;

            lblobligatorio1.Visible = true;
            lblobligatorio2.Visible = false;

            lblObligatorio4.Visible = true;
            lblObligatorio5.Visible = false;

            CalendarExtender8.Enabled = true;
            CalendarExtender9.Enabled = false;
        }
    }
    protected void gvDocumentosPreventivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocumentosPreventivos.PageIndex = e.NewPageIndex;
        cargar_gvDocumentoPreventivo();
        gvDocumentosPreventivos.DataBind();
    }


    protected void txtFechaRehabilitacion_TextChanged(object sender, EventArgs e)
    {
        this.mpeNuevoRegistro.Show();

        if (txtFechaRehabilitacion.Text != "")
        {
            string periodo = txtFechaRehabilitacion.Text.Substring(4, 4) + txtFechaRehabilitacion.Text.Substring(2, 2);
            txtFechaRehabilitacion.Text = periodo;
        }
    }

    protected void txtFechaSuspencion_TextChanged(object sender, EventArgs e)
    {
        this.mpeNuevoRegistro.Show();

        if (txtFechaSuspencion.Text != "")
        {
            string periodo = txtFechaSuspencion.Text.Substring(4, 4) + txtFechaSuspencion.Text.Substring(2, 2);
            txtFechaSuspencion.Text = periodo;
        }
    }

    protected void txtPeriodoSuspencionSPM_TextChanged(object sender, EventArgs e)
    {
        this.mpeModificaPreventiva.Show();

        if (txtPeriodoSuspencionSPM.Text != "")
        {
            string periodo = txtPeriodoSuspencionSPM.Text.Substring(4, 4) + txtPeriodoSuspencionSPM.Text.Substring(2, 2);
            txtPeriodoSuspencionSPM.Text = periodo;
        }
    }
    protected void txtPeriodoDesactivacionSPM_TextChanged(object sender, EventArgs e)
    {
        this.mpeModificaPreventiva.Show();

        if (txtPeriodoDesactivacionSPM.Text != "")
        {
            string periodo = txtPeriodoDesactivacionSPM.Text.Substring(4, 4) + txtPeriodoDesactivacionSPM.Text.Substring(2, 2);
            txtPeriodoDesactivacionSPM.Text = periodo;
        }
    }
    protected void txtPerioSuspencionM_TextChanged(object sender, EventArgs e)
    {
        this.mpmodificaSuspencion.Show();

        if (txtPerioSuspencionM.Text != "")
        {
            string periodo = txtPerioSuspencionM.Text.Substring(4, 4) + txtPerioSuspencionM.Text.Substring(2, 2);
            txtPerioSuspencionM.Text = periodo;
        }
    }
    protected void txtPeriodoInicioInstitucionM_TextChanged(object sender, EventArgs e)
    {
        this.mpmodificaSuspencion.Show();

        if (txtPerioSuspencionM.Text != "")
        {
            string periodo = txtPerioSuspencionM.Text.Substring(4, 4) + txtPerioSuspencionM.Text.Substring(2, 2);
            txtPerioSuspencionM.Text = periodo;
        }
    }
    /*   protected void btnIngresarDocumento_Click(object sender, EventArgs e)
       {
       
           DataTable Docs_temp = Session["DOC"] as DataTable;
           int NumDoc;
           if (gvDocumentos1 == null)
           {
               NumDoc = 1;
           }
           else
           {
               NumDoc = gvDocumentos1.Rows.Count + 1;
           }
           try
           {
               if (btnIngresarDocumento.Text.StartsWith("Agregar"))//agregamos
               {
                   Docs_temp.Rows.Add(NumDoc, Convert.ToInt32(ddlTDocumento.SelectedValue),
                       ddlTDocumento.SelectedItem.ToString(),
                       txtNroDocumento1.Text, txtFechaActual.Text
                     , txtReferencia.Value, txaObservacion.Value);
                   //cargar la gv
                
                   gvDocumentos1.DataSourceID = null;
                   gvDocumentos1.DataSource = Docs_temp;
                   gvDocumentos1.DataBind();
                   gvDocumentos1.visible = true;
                   Session["DOC"] = Docs_temp;
                   this.mpeNuevoRegistro.Show();
               }
          
           
           }
           catch (Exception ex)
           {
               Master.MensajeError("Error al agregar Docuemnto Deuda", ex.Message);
           }
       }
       */
    private void CrearTablas()
    {
        //crear tabla temp para documentos
        DataTable DocsTempDocs = new DataTable();
        DocsTempDocs.Columns.Add(new DataColumn("Fila", Type.GetType("System.Int32")));
        DocsTempDocs.Columns.Add(new DataColumn("IdDocumento", Type.GetType("System.Int32")));
        DocsTempDocs.Columns.Add(new DataColumn("TipoDocumento", Type.GetType("System.String")));
        DocsTempDocs.Columns.Add(new DataColumn("NumeroDocumento", Type.GetType("System.String")));
        DocsTempDocs.Columns.Add(new DataColumn("FechaDocumento", Type.GetType("System.String")));
        DocsTempDocs.Columns.Add(new DataColumn("Referencia", Type.GetType("System.String")));
        DocsTempDocs.Columns.Add(new DataColumn("Observaciones", Type.GetType("System.String")));
        Session["DOC"] = DocsTempDocs;

        //crear tabla temp para documentos
        DataTable DocsTemp = new DataTable();
        DocsTemp.Columns.Add(new DataColumn("Fila", Type.GetType("System.Int32")));
        DocsTemp.Columns.Add(new DataColumn("IdDocumento", Type.GetType("System.Int32")));
        DocsTemp.Columns.Add(new DataColumn("TipoDocumento", Type.GetType("System.String")));
        DocsTemp.Columns.Add(new DataColumn("NumeroDocumento", Type.GetType("System.String")));
        DocsTemp.Columns.Add(new DataColumn("FechaDocumento", Type.GetType("System.String")));
        DocsTemp.Columns.Add(new DataColumn("Referencia", Type.GetType("System.String")));
        DocsTemp.Columns.Add(new DataColumn("Observaciones", Type.GetType("System.String")));
        Session["DocsTemp"] = DocsTemp;

    }

    protected void btnAgregarDoc_Click(object sender, EventArgs e)
    {
        DataTable Doc_temp = Session["DOC"] as DataTable;
        int NumPer;
        if (gvDocTemp == null)
        {
            NumPer = 1;
        }
        else
        {
            NumPer = gvDocTempNormales.Rows.Count + 1;
        }
        try
        {
            if (btnAgregarDocTemp.Text.StartsWith("Agregar Documento"))//agregamos
            {
                if (validar_documento(txtNroDocumento1.Text, txtFechaActual.Text, ddlTDocumento.SelectedValue))
                {
                    Doc_temp.Rows.Add(NumPer, Convert.ToInt32(ddlTDocumento.SelectedValue), ddlTDocumento.SelectedItem.Text, txtNroDocumento1.Text, txtFechaActual.Text,
                        txtReferenciai.Text, txaObservacioni.Text);
                    //cargar la gv
                    gvDocTempNormales.Visible = true;
                    gvDocTempNormales.DataSourceID = null;
                    gvDocTempNormales.DataSource = Doc_temp;
                    gvDocTempNormales.DataBind();
                    Session["DOC"] = Doc_temp;

                    ddlTDocumento.SelectedIndex = 0;
                    txtNroDocumento1.Text = " ";
                    txtFechaActual.Text = "";
                    txtReferenciai.Text = " ";
                    txaObservacioni.Text= "";

                    this.mpeNuevoRegistro.Show();
                }
                else
                {
                    this.mpeNuevoRegistro.Show();
                }
            }

        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al agregar Periodos TGN", ex.Message);
        }
    }


    protected void gvDocTempNormales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "cmdEliminar")
        {
            if (btnAgregarDocTemp.Enabled == true)
            {
                DataTable Doc_temp = Session["DOC"] as DataTable;
                Doc_temp.Rows.Remove(Doc_temp.Rows[indice]);
                int n = 0;
                foreach (DataRow r in Doc_temp.Rows)
                {
                    Doc_temp.Rows[n][0] = (n + 1);
                    n += 1;
                }
                gvDocTempNormales.DataSourceID = null;
                gvDocTempNormales.DataSource = Doc_temp;
                gvDocTempNormales.DataBind();
                Session["DOC"] = Doc_temp;
                //gvDocumentos.DeleteRow(indice);
                this.mpeNuevoRegistro.Show();
            }
        }
    }


    protected void btnAgregarDocTemp_Click(object sender, EventArgs e)
    {
        DataTable Doc_temp = Session["DocsTemp"] as DataTable;
        int NumPer;
        if (gvDocTemp == null)
        {
            NumPer = 1;
        }
        else
        {
            NumPer = gvDocTemp.Rows.Count + 1;
        }
        try
        {
            if (btnAgregarDocTemp.Text.StartsWith("Agregar Documento"))//agregamos
            {
                if (validar_documento(txtNroDocumentoSP.Text, txtFechaDocumentoSP.Text, ddlTipoDocumentoSP.SelectedValue))
                {
                    Doc_temp.Rows.Add(NumPer, Convert.ToInt32(ddlTipoDocumentoSP.SelectedValue), ddlTipoDocumentoSP.SelectedItem.Text, txtNroDocumentoSP.Text, txtFechaDocumentoSP.Text,
                        txaReferenciaDocumentoSP.Value, txaObservacionDocumentoSP.Value);
                    //cargar la gv
                    gvDocTemp.Visible = true;
                    gvDocTemp.DataSourceID = null;
                    gvDocTemp.DataSource = Doc_temp;
                    gvDocTemp.DataBind();
                    Session["DocsTemp"] = Doc_temp;
                    ddlTipoDocumentoSP.SelectedIndex = 0;
                    txtNroDocumentoSP.Text = ""; txtFechaDocumentoSP.Text = "";
                    txaReferenciaDocumentoSP.Value = ""; txaObservacionDocumentoSP.Value = "";
                    this.mpeSP.Show();
                }
                else { this.mpeSP.Show(); }
            }

        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al agregar Periodos TGN", ex.Message);
        }


    }


    protected void gvDocTemp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "cmdEliminar")
        {
            if (btnAgregarDocTemp.Enabled == true)
            {
                DataTable Doc_temp = Session["DocsTemp"] as DataTable;
                Doc_temp.Rows.Remove(Doc_temp.Rows[indice]);
                int n = 0;
                foreach (DataRow r in Doc_temp.Rows)
                {
                    Doc_temp.Rows[n][0] = (n + 1);
                    n += 1;
                }
                gvDocTemp.DataSourceID = null;
                gvDocTemp.DataSource = Doc_temp;
                gvDocTemp.DataBind();
                Session["DocsTemp"] = Doc_temp;
                //gvDocumentos.DeleteRow(indice);
                this.mpeSP.Show();
            }
        }
    }
    protected void btnIrAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
    }
    protected void gvDH_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "cmdDetalle")
        {   try
            {
               /* NUP = Convert.ToInt64(Session["NUPT"]);
                CUA = (string)Session["CUAT"];
                Matricula = (string)Session["MATRICULAT"];
                Paterno = (string)Session["PATERNOT"];
                Materno = (string)Session["MATERNOT"];
                PrimerNombre = (string)Session["PRIMERNOMBRET"];*/
                Session["NUPT"] = gvDH.Rows[indice].Cells[2].Text;
                Session["CUAT"] = gvDH.Rows[indice].Cells[0].Text;
                Session["PATERNOT"] = gvDH.Rows[indice].Cells[4].Text;
                Session["PRIMERNOMBRET"] = gvDH.Rows[indice].Cells[5].Text;
                Session["NUMERODOCUMENTO"] = gvDH.Rows[indice].Cells[7].Text;
                Response.Redirect("~/DoblePercepcion/wfrmCargarInformacionAsegurado.aspx");
                //Response.Redirect("~/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }

    }
    protected void txtPeriodoRehabilitacionSP_TextChanged(object sender, EventArgs e)
    {
        //txtNureroRehabilitacionSP.Enabled = true;
        //txaObservacionRehabilitacionSP.ReadOnly= false;
        //txtPerioFinInstitucion.ReadOnly = true;
        this.mpeSP.Show();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SENARIT/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
        Session.Remove("CUAA");
        Response.Redirect("~/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
    }
    protected void btnReporte_Click(object sender, EventArgs e)
    {
       
        string RangoEPC = txtRangoEPC.Text;
        string RangoSPC = txtRangoSPC.Text;
        string fechaini = RangoEPC.Substring(6, 4) + RangoEPC.Substring(3, 2);
        string fechafin = RangoSPC.Substring(6, 4) + RangoSPC.Substring(3, 2);
        string UsrRep;
        string PassUsrRep;
        string DomRep;
        string ServRep;
        string ServApl;
        ReportParameter[] repParams = new ReportParameter[4];
        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
        repParams[0] = new ReportParameter("CUA", txtCUA.Text);
        repParams[1] = new ReportParameter("Fecha1", fechaini);
        repParams[2] = new ReportParameter("Fecha2", fechafin);
        repParams[3] = new ReportParameter("CuentaUsuario", ConexionUsuario());	
        /*panReporte.Visible = true;
        rtpInforme.Visible = true;*/
        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
        rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
        if (Resumido.Checked == true)
        { rtpInforme.ServerReport.ReportPath = "/InformesPagos/rptHistorialPagosResumen"; }
        else 
        {
            if (Completo.Checked == true)
            { rtpInforme.ServerReport.ReportPath = "/InformesPagos/rptHistorialPagos"; }
        }
        rtpInforme.ServerReport.SetParameters(repParams);
        rtpInforme.ServerReport.Refresh();
        //panReporte.Visible = true;

        /*rtpInforme.ShowPrintButton = true;
        rtpInforme.PromptAreaCollapsed = true;
        rtpInforme.Height = 500;
        rtpInforme.BackColor = Color.FromArgb(72, 128, 179);
        rtpInforme.ForeColor = Color.WhiteSmoke;
        rtpInforme.ServerReport.Refresh();*/
        GenerarPDF();
     }

    public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        // local variable for network credential.
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        private WindowsIdentity _ImpersonationUser;
        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
            // _ImpersonationUser = ImpersonationUser;
        }
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null; // not use ImpersonationUser
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {

                // use NetworkCredentials
                return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {

            // not use FormsCredentials unless you have implements a custom autentication.
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }

    protected void GenerarPDF()
    {
        try
        {
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;


            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>21.59cm</PageWidth>" +
            "  <PageHeight>27.94cm</PageHeight>" +
            "  <MarginTop>1cm</MarginTop>" +
            "  <MarginLeft>1cm</MarginLeft>" +
            "  <MarginRight>1cm</MarginRight>" +
            "  <MarginBottom>1cm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report

            renderedBytes = rtpInforme.ServerReport.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);

            Response.Clear();
            Response.ContentType = "application/txt";//mimeType;
            if (Resumido.Checked == true)
            {
                Response.AddHeader("content-disposition", "attachment; filename=rptHistorialPagosResumen." + fileNameExtension);
            }
            else
            {
                if (Completo.Checked == true)
                {
                    Response.AddHeader("content-disposition", "attachment; filename=rptHistorialPagos." + fileNameExtension);
                }
            }
            Response.BinaryWrite(renderedBytes);
            Response.End();
         }
        catch (Exception ex)
        {
            Master.MensajeError("Error al intentar crear el archivo PDF", ex.Message);
        }
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        GenerarPDF();
    }
    protected string ConexionUsuario()
    {
        string UsuarioConexio = "";
        string mensaje = "";
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Conexion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        UsuarioConexio = Encontrados.Rows[0][0].ToString();
        return UsuarioConexio;

    }

}
