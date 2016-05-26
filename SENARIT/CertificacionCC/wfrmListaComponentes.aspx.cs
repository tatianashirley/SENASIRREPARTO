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
using wcfGeo.Logica;
using wcfWorkFlowN.Logica;
public partial class CertificacionCC_wfrmListaComponentes : System.Web.UI.Page
{
   clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsParametrizacion ObjParametrizacion = new clsParametrizacion();
    clsTramiteAsignado ObjTramite = new clsTramiteAsignado();
    int FlagWF = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            
            ViewState["PreviousPage"] = Request.UrlReferrer;
            hfIdTramite.Value=Request.QueryString["iIdTramite"];
            hfIdGrupoBeneficio.Value = "3";
            hfIdTipoTramite.Value = Request.QueryString["iIdTipoTramite"];
            int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
            int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
            int iIdTipoTramite =Convert.ToInt32(Request.QueryString["iIdTipoTramite"]);
            
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";
            string sMensajeError = null;

            DataTable tblDatosComponentes = ObjProcedimientoManual.DatosProcedimientoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            if (tblDatosComponentes != null)
            {
                ViewState["Cantidad"] = tblDatosComponentes.Rows.Count;
                int iVersion = Convert.ToInt32(tblDatosComponentes.Rows[0]["Version"]);

                DataTable tblDatosActualizacionCC = ObjProcedimientoManual.ListaActualizacionCC(iIdConexion, "Q", iIdTramite, iIdGrupoBeneficio, 0, null, 0, ref sMensajeError);
                DataView dv = new DataView(tblDatosActualizacionCC);

                dv.RowFilter = "Version in (0)";


                if (dv.Count > 0)
                {
                    lblCertificacionParcial.Visible = true;
                    lblCertificacionParcial.Text = ".::EL TRAMITE TIENE UNA CERTIFICACION PARCIAL::. ==>";
                    btnCertificacionParcial.Visible = true;
                }
                else
                {
                    lblCertificacionParcial.Visible = false;
                    btnCertificacionParcial.Visible = false;
                    
                }


            }
            else
            {
                DataTable tblDatosActualizacionCC = ObjProcedimientoManual.ListaActualizacionCC(iIdConexion, "Q", iIdTramite, iIdGrupoBeneficio, 0, null, 0, ref sMensajeError);
                DataView dv = new DataView(tblDatosActualizacionCC);

                dv.RowFilter = "Version in (0)";


                if (dv.Count > 0)
                {
                    lblCertificacionParcial.Visible = true;
                    lblCertificacionParcial.Text = ".::EL TRAMITE TIENE UNA CERTIFICACION PARCIAL::. ==>";
                    btnCertificacionParcial.Visible = true;
                    

                }
                else
                {
                    lblCertificacionParcial.Visible = false;
                    btnCertificacionParcial.Visible = false;
                    
                    
                }
            }
            gvDatosComponentes.DataSource = tblDatosComponentes;
            gvDatosComponentes.DataBind();
        }
    }
    protected void gvDatosComponentes_RowCommand(object sender, GridViewCommandEventArgs e)
    {



        if (e.CommandName == "cmdCerti")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "G";
                string sMensajeError = null;

                int Index = Convert.ToInt32(e.CommandArgument);
                int iIdTipoTramite = Convert.ToInt32(hfIdTipoTramite.Value);
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);
                string iIdTramite = Convert.ToString(ViewState["iIdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(ViewState["iIdGrupoBeneficio"]);
                string iComponente = Convert.ToString(ViewState["iComponente"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                iComponente = ObjSeguridad.URLEncode(iComponente);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

                if (iIdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (iIdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) +  "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdCertificacionSalarioCorrelativo")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "G";
                string sMensajeError = null;

                int Index = Convert.ToInt32(e.CommandArgument);
                int iIdTipoTramite = Convert.ToInt32(hfIdTipoTramite.Value);
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);
                string iIdTramite = Convert.ToString(ViewState["iIdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(ViewState["iIdGrupoBeneficio"]);
                string iComponente = Convert.ToString(ViewState["iComponente"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                iComponente = ObjSeguridad.URLEncode(iComponente);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

                if (iIdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (iIdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomaticoCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
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
    protected void btnCertificacionParcial_Click(object sender, ImageClickEventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = "3";
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        string iComponente = "0";
        iComponente = ObjSeguridad.URLEncode(iComponente);
        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
        int iIdTipoTramite = Convert.ToInt32(hfIdTipoTramite.Value);
        if (iIdTipoTramite == 356) //manual
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
        if (iIdTipoTramite == 357) //automatico
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx";
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
    protected void gvDatosComponentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            if ((int)Session["RolUsuario"] == 14) //Responsable de Certificacion
            {
                e.Row.FindControl("imgCertificacionSalarioCorrelativo").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgCertificacionSalarioCorrelativo").Visible = false;
            }
        }
    }
     
   
}