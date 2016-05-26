using System.Collections.Generic;
using System.Linq;
using Microsoft.Reporting.WebForms;
using System;
using System.Security.Principal;
using System.Net;
using System.Reflection;
using wcfSeguridad.Logica;

public partial class SeguimientoObservados_wfrmRptListadoObservacion : System.Web.UI.Page
{
    string IdObservacion, Regional, FecIni, FecFin,CuentaUsuario;
    int rbValor;
    clsSeguridad ObjSeguridad = new clsSeguridad();
    Warning[] warnings;
    string[] streamids;
    string mimeType;
    string encoding;
    string extension;
    string deviceInfo;
    byte[] bytes;
    protected void Page_Load(object sender, EventArgs e)
    {
        IdObservacion = Request.QueryString["IdObservacion"];
        Regional = Request.QueryString["Regional"];
        FecIni = Request.QueryString["FechaIni"];
        FecFin = Request.QueryString["FechaFin"];
        rbValor = (int)Session["rbID"];
        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
            if (Session["IdConexion"] == null)
            {
                //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
        }
        string UsrRep;
        string PassUsrRep;
        string DomRep;
        string ServRep;
        string ServApl;
        CuentaUsuario = ObjSeguridad.ListaDatosConexion((int)Session["IdConexion"]).Rows[0]["CuentaUsuario"].ToString();
        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
        if (rbValor == 1) //Reporte en formato PDF
        {
            ReportParameter[] repParams = new ReportParameter[5];
            repParams[0] = new ReportParameter("TipoObservacion", IdObservacion);
            repParams[1] = new ReportParameter("Regional", Regional);
            repParams[2] = new ReportParameter("FechaInicio", FecIni);
            repParams[3] = new ReportParameter("FechaFin", FecFin);
            repParams[4] = new ReportParameter("CuentaUsuario", CuentaUsuario);

            rptListadoObservacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptListadoObservacion.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rptListadoObservacion.ServerReport.ReportServerUrl = new Uri(ServRep);
            rptListadoObservacion.ServerReport.ReportPath = "/Reportes Observados/rptListadoObservados";
            rptListadoObservacion.ServerReport.SetParameters(repParams);
            rptListadoObservacion.ServerReport.Refresh();
            extension = "pdf";
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            bytes = rptListadoObservacion.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("charset", "UTF-8");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "FormEmitidos.pdf");
        }
        if (rbValor == 2) //Reporte en formato Excel
        {
            ReportParameter[] repParams = new ReportParameter[3];
            repParams[0] = new ReportParameter("Regional", Regional);
            repParams[1] = new ReportParameter("FechaInicio", FecIni);
            repParams[2] = new ReportParameter("FechaFin", FecFin);
            rptListadoObservacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptListadoObservacion.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rptListadoObservacion.ServerReport.ReportServerUrl = new Uri(ServRep);
            rptListadoObservacion.ServerReport.ReportPath = "/Reportes Observados/ObservadosXls";
            rptListadoObservacion.ServerReport.SetParameters(repParams);
            rptListadoObservacion.ServerReport.Refresh();

            extension = "EXCEL";
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            bytes = rptListadoObservacion.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("charset", "UTF-8");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "EnvioRegionales.xls");
        }
        if (rbValor == 3) //Reporte en formato PDF
        {
            ReportParameter[] repParams = new ReportParameter[3];
            repParams[0] = new ReportParameter("FechaInicio", FecIni);
            repParams[1] = new ReportParameter("FechaFin", FecFin);
            repParams[2] = new ReportParameter("CuentaUsuario", CuentaUsuario);

            rptListadoObservacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptListadoObservacion.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rptListadoObservacion.ServerReport.ReportServerUrl = new Uri(ServRep);
            rptListadoObservacion.ServerReport.ReportPath = "/Reportes Observados/rptListadoIngreso";
            rptListadoObservacion.ServerReport.SetParameters(repParams);
            rptListadoObservacion.ServerReport.Refresh();
            extension = "pdf";
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            bytes = rptListadoObservacion.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("charset", "UTF-8");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "Ingresos_Observados.pdf");
        }
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
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
}