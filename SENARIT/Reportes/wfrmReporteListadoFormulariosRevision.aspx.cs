﻿using System.Security.Principal;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Microsoft.Reporting.WebForms;
using System;
using wcfSeguridad.Logica;

public partial class Reportes_wfrmReporteListadoFormulariosRevision : System.Web.UI.Page
{
    string FecIni, FecFin;
    int IdConexion,iIdValor;
    string CuentaUsuario;
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
        FecIni = Request.QueryString["FecIni"];
        FecFin = Request.QueryString["FecFin"];
        iIdValor = Convert.ToInt32(Session["rbnExport"]);
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
        CuentaUsuario = ObjSeguridad.ListaDatosConexion((int)Session["IdConexion"]).Rows[0]["CuentaUsuario"].ToString();
        ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
        ReportParameter[] repParams = new ReportParameter[3];
        repParams[0] = new ReportParameter("fecInicio", FecIni);
        repParams[1] = new ReportParameter("fecFinal", FecFin);
        repParams[2] = new ReportParameter("CuentaUsuario", CuentaUsuario);
        rptListado.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        rptListado.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
        rptListado.ServerReport.ReportServerUrl = new Uri(ServRep);
        if (iIdValor== 1)
        {
            rptListado.ServerReport.ReportPath = "/Reportes Observados/rptListadoFormularioRevision";
            rptListado.ServerReport.SetParameters(repParams);
            rptListado.ServerReport.Refresh();

            extension = "pdf";
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            bytes = rptListado.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("charset", "UTF-8");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "ListadoFormRevision.pdf");
        }
        else 
        {
            rptListado.ServerReport.ReportPath = "/Reportes Observados/ListadoFormularioxls";
            rptListado.ServerReport.SetParameters(repParams);
            rptListado.ServerReport.Refresh();

            extension = "EXCEL";
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            bytes = rptListado.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("charset", "UTF-8");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "ListadoFormRevision.xls");
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