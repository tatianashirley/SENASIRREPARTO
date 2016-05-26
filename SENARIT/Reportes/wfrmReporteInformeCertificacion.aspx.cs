﻿using System.Collections.Generic;
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
using wcfSeguridad.Logica;
using wcfCertificacionCC.Logica;
using System.Security.Principal;


public partial class Reportes_wfrmReporteInformeCertificacion : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    Warning[] warnings;
    string[] streamids;
    string mimeType;
    string encoding;
    string extension;
    string deviceInfo;
    byte[] bytes;

    int i_iIdTramite;
    int i_iIdGrupoBeneficio;
    string s_NroControl;
    int iIdTipoInforme;
    string RutaReporte;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            i_iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
            i_iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
            s_NroControl = Convert.ToString(Request.QueryString["NroControl"]);
            iIdTipoInforme = Convert.ToInt32(Request.QueryString["IdTipoInforme"]);
            
            switch (iIdTipoInforme)
                {
                    case 1:
                        RutaReporte="/CertificacionCC/rptInformCertificacion";
                        break;
                    case 2:
                        RutaReporte="/CertificacionCC/rptInformCertificacion";
                        break;
                    case 3:
                        RutaReporte="/CertificacionCC/rptInformCertificacion";
                        break;
                    default: 
                        RutaReporte="/CertificacionCC/rptInformCertificacion";
                        break; 
            }
                

           
            
            string UsrRep;
            string PassUsrRep;
            string DomRep;
            string ServRep;
            string ServApl;
            ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
            
           try
            {
                ReportParameter[] repParams = new ReportParameter[3];
                repParams[0] = new ReportParameter("i_iIdTramite", Convert.ToString(i_iIdTramite));
                repParams[1] = new ReportParameter("i_iIdGrupoBeneficio", Convert.ToString(i_iIdGrupoBeneficio));
                repParams[2] = new ReportParameter("s_NroControl", Convert.ToString(s_NroControl));                
             

                rptCertificacionSalarios.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;                
                rptCertificacionSalarios.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);                
                rptCertificacionSalarios.ServerReport.ReportServerUrl = new Uri(ServRep);
                rptCertificacionSalarios.ServerReport.ReportPath =RutaReporte ;
                rptCertificacionSalarios.ServerReport.SetParameters(repParams);
                rptCertificacionSalarios.ServerReport.Refresh();
                extension = "pdf";
                deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                bytes = rptCertificacionSalarios.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                Response.Buffer = true;
                Response.Clear();
               // Response.ContentType = "application/pdf";
                Response.ContentType = "application/vnd.ms-word";
                Response.AddHeader("charset", "UTF-8");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "Reporte.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
           catch (Exception ex)
           {
               throw ex;
           }
           

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