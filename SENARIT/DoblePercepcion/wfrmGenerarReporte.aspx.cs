
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
using System.Data;
using System.Net;
using System.Security.Principal;
using System.Globalization;
using System.Drawing;
using wfcDoblePercepcion.Logica;
using Microsoft.Reporting.WebForms;
using wcfSeguridad.Logica;

public partial class DoblePercepcion_wfrmGenerarReporte : System.Web.UI.Page
{
    clsManejoArchivo ManejoArchivo = new clsManejoArchivo();
    DataTable Encontrados;
    string mensaje = null;
    clsInformacion info = new clsInformacion();
    ReportParameter[] repParams = new ReportParameter[5];
    ReportParameter[] repParamsD = new ReportParameter[4];
    clsSeguridad ObjSeguridad = new clsSeguridad();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            ddlTipoReporte.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Estado1", "", "", "", "", "", "", ""
                                                         , 0, 0, ref mensaje);
            ddlTipoReporte.DataValueField = "IdDetalleClasificador";
            ddlTipoReporte.DataTextField = "DescripcionDetalleClasificador";
            ddlTipoReporte.DataBind();
        }


    }
    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        string FechaInicio = txtFechaInicio.Text;
        string FechaFin = txtFechaFin.Text;
        string TipoRehabilitacion = null;
        string rep = "ReporteDoblePercepcion";
        if (ddlTipoReporte.SelectedValue == "708")
        {   rep = "ReporteSuspendidos";
            lblSuspension.Style.Add("display", "none");
            pnlTipoReporte.Style.Add("display", "none");
        }
        else
        {  // if (rbReporte.Visible==true)
            if (ddlTipoReporte.SelectedValue == "364")
            {
                lblSuspension.Style.Add("display", "block");
                pnlTipoReporte.Style.Add("display", "block");
                //rbReporte.Style["display"] = "none";
                if (rbReporte.SelectedValue == "1")
                    TipoRehabilitacion = "708";

                else
                    TipoRehabilitacion = "707";
            }
            else
            {
                lblSuspension.Style.Add("display", "none");
                pnlTipoReporte.Style.Add("display", "none");
            }
            //lblSuspension.Style.Add("display", "none");
            //pnlTipoReporte.Style.Add("display", "none");
        }
        if (validar(FechaInicio, FechaFin))
        {
            try
            {
                    if (ddlTipoReporte.SelectedValue != "708")
                    {
                        string UsrRep;
                        string PassUsrRep;
                        string DomRep;
                        string ServRep;
                        string ServApl;
                        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
                        panReporte.Visible = true;
                        rtpInforme.Visible = true;
                        repParams[0] = new ReportParameter("idestado", ddlTipoReporte.SelectedValue);
                        repParams[1] = new ReportParameter("fechaini", txtFechaInicio.Text);
                        repParams[2] = new ReportParameter("fechafin", txtFechaFin.Text);
                        repParams[3] = new ReportParameter("TipoRecuperacion", TipoRehabilitacion);
                        repParams[4] = new ReportParameter("Usuario", ConexionUsuario());

                        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                        //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
                        //rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials("SFERNANDEZ", "Darkrai780", "SENASIR");
                        rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                        rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
                        rtpInforme.ServerReport.ReportPath = "/ReporteDoblePercepcion/" + rep;
                        rtpInforme.ServerReport.SetParameters(repParams);
                        rtpInforme.ServerReport.Refresh();
                        panReporte.Visible = true;
                    }
                    else
                    {
                        string UsrRep;
                        string PassUsrRep;
                        string DomRep;
                        string ServRep;
                        string ServApl;
                        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
                        panReporte.Visible = true;
                        rtpInforme.Visible = true;
                        repParamsD[0] = new ReportParameter("idestado", ddlTipoReporte.SelectedValue);
                        repParamsD[1] = new ReportParameter("fechaini", txtFechaInicio.Text);
                        repParamsD[2] = new ReportParameter("fechafin", txtFechaFin.Text);
                        repParamsD[3] = new ReportParameter("Usuario", ConexionUsuario());
                        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                        rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                        //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
                        //rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials("SFERNANDEZ", "Darkrai780", "SENASIR");
                        rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                        rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
                        rtpInforme.ServerReport.ReportPath = "/ReporteDoblePercepcion/" + rep;
                        rtpInforme.ServerReport.SetParameters(repParamsD);
                        rtpInforme.ServerReport.Refresh();
                        panReporte.Visible = true;

                    }
            }
            catch (Exception ex)
            {
                Master.MensajeError("No se pudo generar el Reporte", ex.Message);
            }
        }

    }

    protected bool validar(string FechaInicio, string FechaFin) 
    {
        if (FechaInicio == "" && FechaFin == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA INICIO Y FECHA FIN');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (FechaInicio == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA INICIO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (FechaFin == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA FIN');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        return true;
    }

    protected void generar()
    {      
              ReportParameter[] repParams = new ReportParameter[3];
              repParams[0] = new ReportParameter("idestado", ddlTipoReporte.SelectedValue);
              repParams[1] = new ReportParameter("fechaini", txtFechaInicio.Text);
              repParams[2] = new ReportParameter("fechafin", txtFechaFin.Text);

               //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
              /*  rvReportes.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer");
                rvReportes.ServerReport.ReportPath = "/ReportesDp/";//rptPagDetallexPlanilla";
                rvReportes.ServerReport.SetParameters(repParams);
                rvReportes.ServerReport.Refresh();
            */
    }

    /*  protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["PreviousPage"].ToString());
    }
  */
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


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DoblePercepcion/wfrmGenerarReporte.aspx");
    }
    
    protected string ConexionUsuario()
    {
        string UsuarioConexio= "";
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Conexion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        UsuarioConexio = Encontrados.Rows[0][0].ToString();
        return UsuarioConexio;

    }

    protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
    {
      /*  if (ddlTipoReporte.SelectedValue == "364")
        {
            lblSuspension.Visible = true;
            pnlTipoReporte.Visible = true;
        }
        else
        {
            lblSuspension.Visible = false;
            pnlTipoReporte.Visible = false;
        }*/
    }
}