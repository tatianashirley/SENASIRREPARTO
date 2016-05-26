using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Reporting.WebForms;
using System.Data;
using wcfEmisionCertificadoCC.Logica;
using System.Security.Principal;
using System.Net;
using wcfSeguridad.Logica;
using wcfWFArticulador;


public partial class Reportes_wfrmReporteFormulario430 : System.Web.UI.Page
{
   
    clsSeguridad ObjSeguridad = new clsSeguridad();
    //int t;
    string b;
    int Id430;
    string Formato;
 
    int IdConexion;
    string mensaje = null;

    Warning[] warnings;
    string[] streamids;
    string mimeType;
    string encoding;
    string extension;
    string deviceInfo;
    byte[] bytes;
    protected void Page_Load(object sender, EventArgs e)
    {
        //t = Convert.ToInt32(Request.QueryString["iId430"]);
     
        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
            if (Session["IdConexion"] == null)
            {
                //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
            else
            {
                IdConexion = (int)Session["IdConexion"];
            }

            if (Session["Id430"] != null)
            {
                Id430 = Convert.ToInt32(Session["Id430"]);
                Formato = Session["xls_pdf"].ToString();
            }
            else
            {
                Id430 = Convert.ToInt32(Request.QueryString["Id430"]);
            }
        }

            b = ObjSeguridad.ListaDatosConexion(IdConexion).Rows[0]["CuentaUsuario"].ToString();
            DataTable Reporte = new DataTable();
                string ServRep;
                string ServApl;
                string UsrRep;
                string PassUsrRep;
                string DomRep;
                ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep );

                //Reporte = obt.Impresion((int)Session["IdConexion"], "Q", t, b, tf, nc, ref mensaje);
                ReportParameter[] repParams = new ReportParameter[2];
                repParams[0] = new ReportParameter("Id430", Convert.ToString(Id430));
                repParams[1] = new ReportParameter("Cuenta", b);

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                //ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ServRep);

                if (Formato == "pdf")
                {
                    ReportViewer1.ServerReport.ReportPath = "/SeguimientoTramite/Form430";
                    ReportViewer1.ServerReport.SetParameters(repParams);
                    ReportViewer1.ServerReport.Refresh();
                    extension = "pdf";
                    deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                    bytes = ReportViewer1.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("charset", "UTF-8");
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "Form430.pdf");
                }
                if (Formato == "xls") 
                {
                    ReportViewer1.ServerReport.ReportPath = "/SeguimientoTramite/Form430xls";
                    ReportViewer1.ServerReport.SetParameters(repParams);
                    ReportViewer1.ServerReport.Refresh();
                    extension = "EXCEL";
                    deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                    bytes = ReportViewer1.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = "application/xls";
                    Response.AddHeader("charset", "UTF-8");
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "Form430.xls");
                }
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["PreviousPage"].ToString());
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