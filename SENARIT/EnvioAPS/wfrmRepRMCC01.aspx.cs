﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using wcfEnvioAPS.Logica;

using wcfSeguridad.Logica;
using System.Security.Principal;
using System.Net;

public partial class EnvioAPS_wfrmRepRMCC01 : System.Web.UI.Page
{
    clsGeneraEnvios objGeneraEnvios = new clsGeneraEnvios();
    clsSeguridad ObjSeguridad = new clsSeguridad();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;
    long iIdComprobante;

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
            }
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState

            CuentaUsuario = ObjSeguridad.ListaDatosConexion(IdConexion).Rows[0]["CuentaUsuario"].ToString();

            try
            {
                string ServRep;
                string ServApl;
                string UsrRep;
                string PassUsrRep;
                string DomRep;
                ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

                string sIdEntidad=null;
                if (Session["IdEntidad"] != null)
                {
                    sIdEntidad = Session["IdEntidad"].ToString();
                }

                string sNumeroEnvioReporte = Session["NumeroEnvioReporte"].ToString();

                ReportParameter[] param = new ReportParameter[3]; //Para 2 el 0 y el 1
                param[0] = new ReportParameter("CuentaUsuario", CuentaUsuario);
                param[1] = new ReportParameter("i_sNumeroEnvio", sNumeroEnvioReporte);
                param[2] = new ReportParameter("i_iIdEntidad", sIdEntidad);
                //param[3] = new ReportParameter("s_sSSN", s_iIdConexion);
                //param[4] = new ReportParameter("o_sMensajeError", s_iIdConexion);
                //param[5] = new ReportParameter("i_iIdComprobante", s_iIdConexion);

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                //ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ServRep);
                ReportViewer1.ServerReport.ReportPath = "/ReportesEnviosAPS/rptRM-CC-01c";
                ReportViewer1.ServerReport.SetParameters(param); //Asignación de parámetros luego de definido el reporte
                ReportViewer1.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al Cargar los datos", ex.Message);
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