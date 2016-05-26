using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using wcfEnvioAPS.Logica;

public partial class EnvioAPS_wfrmRepCtrlCites2 : System.Web.UI.Page
{
    clsContrlEnvios objContrlEnvios = new clsContrlEnvios();
    int IdConexion;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["IdConexion"] == null)
            {
                //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
            else
            {
                IdConexion = (int)Session["IdConexion"];
                //IdConexion = 4039;
                //IdConexion = 5638;
            }
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState

            string SFechaCorte = Session["fFechaCorte"].ToString();
            string FechaCorte;
            if (SFechaCorte.Length == 0)
            {
                FechaCorte = String.Format("{0:dd/MM/yyyy}", "01/01/1919");
            }
            else
            {
                FechaCorte = SFechaCorte;
            }
            try
            {
                ReportParameter[] repParams = new ReportParameter[5];
                repParams[0] = new ReportParameter("s_iIdConexion", IdConexion.ToString());
                repParams[1] = new ReportParameter("s_cOperacion", "Q");
                repParams[2] = new ReportParameter("i_fFechaCorte", FechaCorte);
                repParams[3] = new ReportParameter("i_iIdEntidad", Session["iIdEntidad"].ToString());
                repParams[4] = new ReportParameter("i_sNumeroEnvio", Session["sNumeroEnvio"].ToString());
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
                ReportViewer1.ServerReport.ReportPath = "/SENARIT_EnviosAPS Report Project/rptCtrlCites3";
                ReportViewer1.ServerReport.SetParameters(repParams);
                ReportViewer1.ServerReport.Refresh();

                //ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                //ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
                //ReportViewer1.ServerReport.ReportPath = "/SENARIT_EnviosAPS Report Project/rptCtrlCites2";
                //ReportViewer1.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx");
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}