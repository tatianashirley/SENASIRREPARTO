using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Reporting.WebForms;
using System.Data;
using wcfEmisionCertificadoCC.Logica;
using System.Security.Principal;
using System.Net;
using wcfSeguridad.Logica;


public partial class Reportes_wfrmReporteCertificadoCC : System.Web.UI.Page
{
    clsEmisionCertificado obt = new clsEmisionCertificado();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    int t;
    int b;
    int tf;
    int nc;
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
        t = Convert.ToInt32(Request.QueryString["iIdTramite"]);
        b = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
        tf = (int)Session["TipoFormulario"];
        nc = (int)Session["NroFormCalculo"];
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


            DataTable Reporte = new DataTable();
            try
            {
                string UsrRep;
                string PassUsrRep;
                string DomRep;
                string ServRep;
                string ServApl;
                ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

                //Reporte = obt.Impresion((int)Session["IdConexion"], "Q", t, b, tf, nc, ref mensaje);
                ReportParameter[] repParams = new ReportParameter[4];
                repParams[0] = new ReportParameter("Tramite", Convert.ToString(t));
                repParams[1] = new ReportParameter("GrupoB", Convert.ToString(b));
                repParams[2] = new ReportParameter("TipoForm", Convert.ToString(tf));
                repParams[3] = new ReportParameter("NoFormCalculo", Convert.ToString(nc));

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ServRep);
                ReportViewer1.ServerReport.ReportPath = "/EmisionCC/rptCertificadoCC";
                ReportViewer1.ServerReport.SetParameters(repParams);
                ReportViewer1.ServerReport.Refresh();

                extension = "pdf";
                deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                bytes = ReportViewer1.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("charset", "UTF-8");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "CertificadoCC.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch 
            {
                Master.MensajeError("Error al Cargar los datos", mensaje);
            }
        }
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