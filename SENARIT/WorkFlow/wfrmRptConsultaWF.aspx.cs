using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class WorkFlow_wfrmRptConsultaWF : System.Web.UI.Page
{
    private int _idConexion;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            _idConexion = (int)Session["IdConexion"];
        }

        if (!Page.IsPostBack)
        {
            Master.btnCerrarSesion.CausesValidation = false;

            Imprimir();
        }
    }


    private void Imprimir()
    {
        try
        {
            var id = Session["IdInstancia"].ToString();

            var dtMaestra = ((DataTable) Session["dtMaestro"]).Copy();
            var drM = dtMaestra.Rows[0];

            var repParams = new ReportParameter[15];
            repParams[0] = new ReportParameter("Nombres", drM["Nombres"].ToString());
            repParams[1] = new ReportParameter("ApPaterno", drM["Ap. Paterno"].ToString());
            repParams[2] = new ReportParameter("ApMaterno", drM["Ap. Materno"].ToString());
            repParams[3] = new ReportParameter("NumDocIdentidad", drM["Nro. Doc. Id."].ToString());
            repParams[4] = new ReportParameter("Matricula", drM["Matrícula"].ToString());
            repParams[5] = new ReportParameter("FecNac", drM["Fec. Nac"].ToString());
            repParams[6] = new ReportParameter("CUA", drM["CUA"].ToString());
            repParams[7] = new ReportParameter("AFP", drM["AFP"].ToString());
            repParams[8] = new ReportParameter("NumTramite", drM["NroTramite"].ToString());
            repParams[9] = new ReportParameter("GrupoBeneficio", drM["GrupoBeneficio"].ToString());
            repParams[10] = new ReportParameter("USUARIO", Session["CuentaUsuario"].ToString());
            repParams[11] = new ReportParameter("IdInstancia", Session["IdInstancia"].ToString());
            repParams[12] = new ReportParameter("Regional", drM["OficinaRegistro"].ToString());
            repParams[13] = new ReportParameter("Sector", drM["Sector"].ToString());
            repParams[14] = new ReportParameter("EstadoTramite", drM["EstadoTrámite"].ToString());
            rptViewConsultaWF.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rptViewConsultaWF.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptViewConsultaWF.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
            rptViewConsultaWF.ServerReport.ReportServerCredentials = new CustomReportCredentials("ECAMARGO", "aOdalcdms.%5", "SENASIR");
            //rptViewConsultaWF.ServerReport.ReportServerUrl = new Uri("--http://localhost/ReportServer");
            rptViewConsultaWF.ServerReport.ReportPath = "/ReportesWF/RptConsultaWF";
            rptViewConsultaWF.ServerReport.SetParameters(repParams);
            rptViewConsultaWF.ShowParameterPrompts = false;
            rptViewConsultaWF.ServerReport.Refresh();
            Master.MensajeOk("Se generó correctamente el reporte");
        }
        catch (Exception ex)
        {
            rptViewConsultaWF.Reset();
            Master.MensajeError("Se produjo un error al generar el reporte", ex.Message);
        }
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmConsultaWF.aspx");
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