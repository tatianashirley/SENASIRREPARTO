using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AjaxControlToolkit;
using wcfSeguridad.Logica;
using wcfCertificacionCC.Logica;
using wcfEmisionCertificadoCC.Logica;
using System.Drawing;

public partial class EmisionCertificadoCC_wfrmBuscadorTramiteEmision : System.Web.UI.Page
{
    clsEmisionCertificado ObjEmisionCertificado = new clsEmisionCertificado();
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();

    string ResolucionAdm = null, TasaCambio = null, SalMinNal = null;
    DataTable tblRenuncia;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            BandejaTramites();
            RevisaValores();
        }

    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtIdtramite, btnEnviar);        

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "H";
        string sMensajeError = null;

        string iIdTramite = txtIdtramite.Text;
        int iIdGrupoBeneficio =3 ;
        int iChkRecurso;
        if (chkRespuesta.Checked)
        {
            iChkRecurso=1;
        }
        else
        {
            iChkRecurso=0;
        }
         
        DataTable tblTramiteUrl = null;
        tblTramiteUrl=ObjEmisionFormularioCC.TramiteUrl(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iChkRecurso, ref sMensajeError);

        if (tblTramiteUrl != null)
        {
            if (tblTramiteUrl.Rows.Count > 0 && tblTramiteUrl.Rows[0]["Url"].ToString() != "")
            {
                string sUrl = tblTramiteUrl.Rows[0]["Url"].ToString();
                iIdTramite = tblTramiteUrl.Rows[0]["IdTramite"].ToString();
                Response.Redirect(sUrl + "?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = "El tramite no esta disponible para ejecutar la actividad";
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = "El tramite no esta disponible para ejecutar la actividad";
            Master.MensajeError(Error, DetalleError);
        }
        
    }

    public void BandejaTramites() 
    { 
        clsEmisionCertificado ObjEmisionCC = new clsEmisionCertificado();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string mensajeError= null;
        DataTable tblBandeja = null;
        string NroCrenta = txtIdtramite.Text;
        int iIdGrupoBeneficio;
        if (NroCrenta != null && NroCrenta != "")
        {
            iIdGrupoBeneficio = 3;
        }
        else
        {
            NroCrenta = "";
            iIdGrupoBeneficio = 0;
        }
        tblBandeja = ObjEmisionCC.BandejaEmisionCC(iIdConexion, cOperacion,NroCrenta,iIdGrupoBeneficio, ref mensajeError);

        if (tblBandeja != null && tblBandeja.Rows.Count > 0)
        {
            lblCantidad.Text = Convert.ToString(tblBandeja.Rows.Count);
            gvBandeja.DataSource = tblBandeja;
            gvBandeja.DataBind();
            gvFormCC.Visible = false;
            chkRespuesta.Visible = false;
        }
        else 
        {
            gvBandeja.DataSource = null;
            gvBandeja.DataBind();
        }
        if (gvBandeja.Rows.Count == 1) 
        {
            if (Convert.ToInt32(gvBandeja.DataKeys[0].Values["IdTipoTramite"]) == 357 && Convert.ToInt32(gvBandeja.DataKeys[0].Values["IdEstadoTramite"]) == 30)
            {
                chkRespuesta.Visible = true;
                chkRespuesta.Text = "Presentar Revision/Renuncia";
                gvFormCC.Visible = true;
                ListaReportes();
            }
            else 
            {
                if (Convert.ToInt32(gvBandeja.DataKeys[0].Values["IdTipoTramite"]) == 356 && Convert.ToInt32(gvBandeja.DataKeys[0].Values["IdEstadoTramite"]) == 30)
                {
                    chkRespuesta.Visible = true;
                    chkRespuesta.Text = "Presentar Recurso de Reclamación";
                    gvFormCC.Visible = false;
                }
                else
                {
                    chkRespuesta.Visible = false;
                    gvFormCC.Visible = false;
                }
            }
        }
    }
    protected void gvBandeja_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandeja.PageIndex = e.NewPageIndex;
        BandejaTramites();
    }

    protected void RevisaValores()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string MensajeError = null;
        DataTable Valores = ObjEmisionCertificado.ValoresCC(iIdConexion, "S", ref MensajeError);
        DataTable MinNal = ObjEmisionCertificado.ValoresCC(iIdConexion, "T", ref MensajeError);

        if (Valores != null && Valores.Rows.Count > 0)
        {
            TasaCambio = Valores.Rows[0][0].ToString();
            ResolucionAdm = Valores.Rows[0][1].ToString();
        }
        if(MinNal != null && MinNal.Rows.Count> 0)
            SalMinNal = MinNal.Rows[0][0].ToString();

        if (ResolucionAdm != null && ResolucionAdm != "")
            lblResolucion.Text = ResolucionAdm;
        else
        {
            lblResolucion.Text = "No existe Registro";
            lblResolucion.ForeColor = Color.Red;
        }

        if (TasaCambio != null && TasaCambio != "")
            lblTipoCambio.Text = TasaCambio;
        else
        {
            lblTipoCambio.Text = "No existe Registro";
            lblTipoCambio.ForeColor = Color.Red;
        }
        if (SalMinNal != null && SalMinNal != "")
            lblNal.Text = SalMinNal;
        else
        {
            lblNal.Text = "No existe Registro";
            lblNal.ForeColor = Color.Red;
        }
        if (ResolucionAdm == null || TasaCambio == null || SalMinNal == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe Registro de Tasa de Cambio, R.A. o Salario Minimo Nacional')", true);
        }
    }

    //--------------------------------------------------------------------------------------------NUEVA CONFIGURACION---------------------------------------------------------------------
    protected void btn_buscar(object sender, EventArgs e)
    {

        BandejaTramites();
    }
    protected void gvBandeja_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string commandName = e.CommandName;
        if (commandName == "cmdSelect") 
        {
            string a = lblTipoCambio.Text, b = lblResolucion.Text, c = lblNal.Text;
            if (lblTipoCambio.Text != "No existe Registro" && lblResolucion.Text != "No existe Registro" && lblNal.Text != "No existe Registro")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                clsSeguridad ObjSeguridad = new clsSeguridad();
                clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "H";
                string sMensajeError = null;

                string iIdTramite = gvBandeja.DataKeys[rowIndex].Values["IdTramite"].ToString();
                int iIdEstadoTramite = Convert.ToInt32(gvBandeja.DataKeys[rowIndex].Values["IdEstadoTramite"]);

                int iIdGrupoBeneficio = 3;
                int iChkRecurso;
                if (chkRespuesta.Checked)
                {
                    iChkRecurso = 1;
                }
                else
                {
                    iChkRecurso = 0;
                }


                DataTable tblTramiteUrl = null;
                tblTramiteUrl = ObjEmisionFormularioCC.TramiteUrl(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iChkRecurso, ref sMensajeError);

                if (tblTramiteUrl != null)
                {
                    if (tblTramiteUrl.Rows.Count > 0 && tblTramiteUrl.Rows[0]["Url"].ToString() != "")
                    {
                        string sUrl = tblTramiteUrl.Rows[0]["Url"].ToString();
                        iIdTramite = tblTramiteUrl.Rows[0]["IdTramite"].ToString();
                        Response.Redirect(sUrl + "?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
                    }
                    else
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = "El tramite no esta disponible para ejecutar la actividad";
                        Master.MensajeError(Error, DetalleError);
                    }
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = "El tramite no esta disponible para ejecutar la actividad";
                    Master.MensajeError(Error, DetalleError);
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe Registro de Tasa de Cambio, R.A. o Salario Minimo Nacional')", true);
        }
    }
    protected void gvBandeja_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Master.MensajeCancel();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex);
            if (gvBandeja.DataKeys[rowIndex]["IdEstadoTramite"].ToString() == "31") // Tramite en Revision
            {
                e.Row.BackColor = Color.Yellow;
                e.Row.Font.Bold = true;
            }
            if (gvBandeja.DataKeys[rowIndex]["IdEstadoTramite"].ToString() == "23") // Tramite con Rec. Reclamacion
            {
                e.Row.BackColor = Color.Yellow;
                e.Row.Font.Bold = true;
            }
            if (gvBandeja.DataKeys[rowIndex]["IdEstadoTramite"].ToString() == "51") // Tramite con Renuncia
            {
                e.Row.BackColor = Color.Orange;
                e.Row.Font.Bold = true;
            }
            if (gvBandeja.DataKeys[rowIndex]["IdEstadoTramite"].ToString() == "42") // Tramite con Reproceso
            {
                e.Row.BackColor = Color.FromName("#f98b9a"); ;
                e.Row.Font.Bold = true;
            }
        }
    }

    protected void LimpiarTabla() 
    {
        tblRenuncia = new DataTable();
        tblRenuncia.Columns.Add("IdTipoTramite", typeof(Int32)); tblRenuncia.Columns.Add("TipoTramite", typeof(string));
        tblRenuncia.Columns.Add("IdTramite", typeof(Int64)); tblRenuncia.Columns.Add("NUP", typeof(Int32));
        tblRenuncia.Columns.Add("CUA", typeof(Int32)); tblRenuncia.Columns.Add("Matricula", typeof(string));
        tblRenuncia.Columns.Add("NombreCompleto", typeof(string)); tblRenuncia.Columns.Add("FechaInicioTramite", typeof(string));
        tblRenuncia.Columns.Add("Regional", typeof(string)); tblRenuncia.Columns.Add("FechaIngreso", typeof(string));
        tblRenuncia.Columns.Add("Dias", typeof(Int32)); tblRenuncia.Columns.Add("EstadoTramite", typeof(string));
        tblRenuncia.Columns.Add("IdEstadoTramite", typeof(Int32)); 
    }

    protected DataTable GrillaValores() 
    {
        clsEmisionCertificado ObjEmisionCC = new clsEmisionCertificado();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string mensajeError = null;
        DataTable tblBandeja = null;
        LimpiarTabla();

        string NroCrenta = "";
        int iIdGrupoBeneficio = 0;

        tblBandeja = ObjEmisionCC.BandejaEmisionCC(iIdConexion, cOperacion, NroCrenta, iIdGrupoBeneficio, ref mensajeError);
        return tblBandeja;
    }

    protected void lblAutomaticoRenuncia_Click(object sender, EventArgs e)
    {
        DataTable tblBandeja = GrillaValores();

        LimpiarTabla();

        foreach (DataRow row in tblBandeja.Rows)
        {
            string a = row[12].ToString();
            DataRow nRow = row;
            if (row[12].ToString() == "51")
            {
                tblRenuncia.Rows.Add(Convert.ToInt32(row[0]), row[1].ToString(),Convert.ToInt64(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), Convert.ToInt32(row[10]), row[11].ToString(),Convert.ToInt32(row[12]));
            }
        }

        lblCantidad.Text = Convert.ToString(tblRenuncia.Rows.Count);
        gvBandeja.DataSource = tblRenuncia;
        gvBandeja.DataBind();
    }
    protected void lblManualReclamacion_Click(object sender, EventArgs e)
    {
        DataTable tblBandeja = GrillaValores();

        LimpiarTabla();

        foreach (DataRow row in tblBandeja.Rows)
        {
            string a = row[12].ToString();
            DataRow nRow = row;
            if (row[12].ToString() == "23" || row[12].ToString() == "31")
            {
                tblRenuncia.Rows.Add(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt64(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), Convert.ToInt32(row[10]), row[11].ToString(), Convert.ToInt32(row[12]));
            }
        }

        lblCantidad.Text = Convert.ToString(tblRenuncia.Rows.Count);
        gvBandeja.DataSource = tblRenuncia;
        gvBandeja.DataBind();
    }

    protected void lblReproceso_Click(object sender, EventArgs e)
    {
        DataTable tblBandeja = GrillaValores();

        LimpiarTabla();

        foreach (DataRow row in tblBandeja.Rows)
        {
            string a = row[12].ToString();
            DataRow nRow = row;
            if (row[12].ToString() == "42")
            {
                tblRenuncia.Rows.Add(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToInt64(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), Convert.ToInt32(row[10]), row[11].ToString(), Convert.ToInt32(row[12]));
            }
        }

        lblCantidad.Text = Convert.ToString(tblRenuncia.Rows.Count);
        gvBandeja.DataSource = tblRenuncia;
        gvBandeja.DataBind();
    }

    protected void ListaReportes()
    {
        DataTable tblListaDatosAsegurado = null;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        string iIdTramite = Convert.ToString(txtIdtramite.Text);
        int iIdGrupoBeneficio = 3;
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAseguradoCrenta(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        gvFormCC.DataSource = tblListaDatosAsegurado;
        gvFormCC.DataBind();
    }
    protected void gvFormCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int FlagM = Convert.ToInt32(gvFormCC.DataKeys[e.Row.RowIndex].Values["FlagM"]);
            int FlagG = Convert.ToInt32(gvFormCC.DataKeys[e.Row.RowIndex].Values["FlagG"]);

            if (FlagM >= 1)
            {
                e.Row.FindControl("imgFMensual").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgFMensual").Visible = false;
            }
            if (FlagG >= 1)
            {
                e.Row.FindControl("imgFGlobal").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgFGlobal").Visible = false;
            }
        }
    }
    protected void gvFormCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdMensual")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvFormCC.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvFormCC.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);

                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                string iIdTipoCC = "358";
                iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);

                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                if (IdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (IdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);


                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdGlobal")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvFormCC.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvFormCC.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);

                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                string iIdTipoCC = "359";
                iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);

                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                if (IdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (IdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
    }
}