using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.Reporting.WebForms;
using System.Security.Principal;
using System.Net;
using wcfSeguridad.Logica;


public partial class Reportes_wfrmReporteSeguimientoTramite : System.Web.UI.Page
{
    int t;
    int b;
    int IdConexion;
    clsSeguridad ObjSeguridad = new clsSeguridad();
    string CuentaUsuario;
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
        }
        string UsrRep;
        string PassUsrRep;
        string DomRep;
        string ServRep;
        string ServApl;
        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
        CuentaUsuario = ObjSeguridad.ListaDatosConexion((int)Session["IdConexion"]).Rows[0]["CuentaUsuario"].ToString();
        ReportParameter[] repParams = new ReportParameter[3];
        repParams[0] = new ReportParameter("Tramite", Convert.ToString(t));
        repParams[1] = new ReportParameter("GrupoBen", Convert.ToString(b));
        repParams[2] = new ReportParameter("CuentaUsuario", CuentaUsuario);

        rptSeguimientoTramite.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        rptSeguimientoTramite.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
        rptSeguimientoTramite.ServerReport.ReportServerUrl = new Uri(ServRep);
        rptSeguimientoTramite.ServerReport.ReportPath = "/Reportes Observados/rptSeguimientoTramite";
        rptSeguimientoTramite.ServerReport.SetParameters(repParams);
        rptSeguimientoTramite.ServerReport.Refresh();


        extension = "pdf";
        deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
        bytes = rptSeguimientoTramite.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("charset", "UTF-8");
        Response.AddHeader("Content-Disposition", "attachment; filename=" + "SeguimientoTramite.pdf");
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