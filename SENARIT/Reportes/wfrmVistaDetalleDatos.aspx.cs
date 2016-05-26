using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AjaxControlToolkit;
using System.Security.Principal;
using System.Net;

public partial class Reportes_wfrmVistaDetalleDatos : System.Web.UI.Page
{

    Int64 t;
    int b;
    int IdConexion;
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
        ReportParameter[] repParams = new ReportParameter[2];
        repParams[0] = new ReportParameter("Tramite", Convert.ToString(t));
        repParams[1] = new ReportParameter("GrupoB", Convert.ToString(b));

        rptDetalleTramite.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        rptDetalleTramite.ServerReport.ReportServerCredentials = new CustomReportCredentials("JBAYON", "Dante2100", "SENASIR");
        rptDetalleTramite.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
        rptDetalleTramite.ServerReport.ReportPath = "/Reportes Observados/rptFormRevisionDetalle";
        rptDetalleTramite.ServerReport.SetParameters(repParams);
        rptDetalleTramite.ServerReport.Refresh();



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

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../SeguimientoObservados/wfrmSeguimientoObservados.aspx?iIdTramite=" + t + "&iIdGrupoBeneficio=" + b + " ");
    }
}