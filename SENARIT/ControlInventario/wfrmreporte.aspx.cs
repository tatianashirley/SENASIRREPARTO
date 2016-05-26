
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using Microsoft.Reporting.WebForms;
using System.Data;
using wcfSeguridad.Logica;
using wfcInventario.Logica;

public partial class ControlInventario_reporte : System.Web.UI.Page
{
    ReportParameter[] repParams = new ReportParameter[4];
    clsSeguridad ObjSeguridad = new clsSeguridad();
    DataTable Encontrados = null;
    string mensaje = null;
    clsLogicaI info = new clsLogicaI();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string UsrRep;
            string PassUsrRep;
            string DomRep;
            string ServRep;
            string ServApl;
            ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
            string h = (string)Session["id"];
            repParams[0] = new ReportParameter("ID", (string)Session["id"]);
            repParams[1] = new ReportParameter("Estante", (string) Session["estante"]);
            repParams[2] = new ReportParameter("nave", (string)Session["nave"]);
            repParams[3] = new ReportParameter("Usuario", ConexionUsuario());
            rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
            //rtpInforme.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer");
            rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
            rtpInforme.ServerReport.ReportPath = "/ControlInventario/rtpInforme";
            rtpInforme.ServerReport.SetParameters(repParams);
            rtpInforme.ServerReport.Refresh();
        }
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
    protected string ConexionUsuario()
    {
        string UsuarioConexio = "";
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Conexion", "", "", "", "", "", "", "", 0, 0, 0, 0,
        ref mensaje); 
        UsuarioConexio = Encontrados.Rows[0][0].ToString();
        return UsuarioConexio;

    }

}