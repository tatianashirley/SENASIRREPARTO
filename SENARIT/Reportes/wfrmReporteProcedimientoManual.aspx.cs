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

public partial class CertificacionCC_wfrmReporteProcedimientoManual : System.Web.UI.Page
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
    int i_iTipoCC;
    string s_Usr = null;

    
    protected void Page_Load(object sender, EventArgs e)

    {
        
        if (!Page.IsPostBack)
        {                     
            i_iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
            i_iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));
            i_iTipoCC = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTipoCC"]));
            s_Usr = Convert.ToString(ObjSeguridad.URLDecode(Request.QueryString["sUsr"]));
            string ServRep;
            string ServApl;
            string UsrRep;
            string PassUsrRep;
            string DomRep;
            ObjSeguridad.UsrReporte(out ServRep,out ServApl,out UsrRep, out PassUsrRep, out DomRep);
            string i_iRUC=null;
            int iIdConexion = (int)Session["IdConexion"];
            try
            {
            DataTable dt3 = GetData3(i_iIdTramite, i_iIdGrupoBeneficio, i_iTipoCC);
            string FCal=Convert.ToString(dt3.Rows[0]["FechaCal"]);
            int Version=Convert.ToInt32(dt3.Rows[0]["Version"]);
            
                ReportParameter[] repParams = new ReportParameter[9];
                repParams[0] = new ReportParameter("i_iIdTramite", Convert.ToString(i_iIdTramite));
                repParams[1] = new ReportParameter("i_iIdGrupoBeneficio", Convert.ToString(i_iIdGrupoBeneficio));
                repParams[2] = new ReportParameter("i_iComponente", "0");
                repParams[3] = new ReportParameter("i_sRUC", i_iRUC);
                repParams[4] = new ReportParameter("i_iIdTipoCC", Convert.ToString(i_iTipoCC));
                repParams[5] = new ReportParameter("TipoCC", Convert.ToString(i_iTipoCC));
                repParams[6] = new ReportParameter("FechaCal", Convert.ToString(FCal));
                repParams[7] = new ReportParameter("Version_nueva", Convert.ToString(Version));
                repParams[8] = new ReportParameter("s_Usr", Convert.ToString(s_Usr));


                //rptFormularioManual.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;

                rptFormularioManual.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                rptFormularioManual.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);               
                //rptFormularioManual.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
                rptFormularioManual.ServerReport.ReportServerUrl = new Uri(ServRep);
                //rptFormularioManual.ServerReport.ReportPath = "/EmisionCC/rptReporteProcedimientoManual";


                //rptFormularioManual.ServerReport.ReportServerCredentials = new CustomReportCredentials("Administrador", "Root4756", "WIN2008_SQL1");
                //rptFormularioManual.ServerReport.ReportServerUrl = new Uri("http://win2008_sql1/ReportServer_VLOPEZ");
                rptFormularioManual.ServerReport.ReportPath = "/EmisionCC/rptReporteProcedimientoManual";
                rptFormularioManual.ServerReport.SetParameters(repParams);
                rptFormularioManual.ServerReport.Refresh();

                extension = "pdf";
                deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                bytes = rptFormularioManual.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("charset", "UTF-8");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "FormEmitidos.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

                ////reset
                //rptFormularioManual.Reset();
                ////DataSource

                //DataTable dt = GetData(i_iIdTramite, i_iIdGrupoBeneficio);
                //DataTable dt2 = GetData2(i_iIdTramite, i_iIdGrupoBeneficio, 0, null, i_iTipoCC);
                //DataTable dt3 = GetData3(i_iIdTramite, i_iIdGrupoBeneficio, i_iTipoCC);
                //DataTable dt4 = GetData4(i_iIdTramite, i_iIdGrupoBeneficio, i_iTipoCC);
                //ReportDataSource rds = new ReportDataSource("dsDatosPersonales", dt);
                //ReportDataSource rds2 = new ReportDataSource("dsComponentes", dt2);
                //ReportDataSource rds3 = new ReportDataSource("dsCompensacionCotizaciones", dt3);
                //ReportDataSource rds4 = new ReportDataSource("dsDatosFormularioCalculo", dt4);


                //rptFormularioManual.LocalReport.DataSources.Add(rds);
                //rptFormularioManual.LocalReport.DataSources.Add(rds2);

                //rptFormularioManual.LocalReport.DataSources.Add(rds3);
                //rptFormularioManual.LocalReport.DataSources.Add(rds4);


                //rptFormularioManual.LocalReport.ReportPath = "Reportes/rptReporteProcedimientoManual.rdlc";
                //rptFormularioManual.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
    
    
    private void verDatosPersona()
    {
        //i_iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
        //i_iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));

        i_iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
        i_iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
        i_iTipoCC = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTipoCC"]));
        int iIdConexion = (int)Session["IdConexion"];
        //reset
        rptFormularioManual.Reset();

        //DataSource

        DataTable dt=GetData(i_iIdTramite,i_iIdGrupoBeneficio);
        DataTable dt2 = GetData2(i_iIdTramite, i_iIdGrupoBeneficio,0,null,i_iTipoCC);
        //DataTable dt3 = GetData3(i_iIdTramite, i_iIdGrupoBeneficio);
        ReportDataSource rds = new ReportDataSource("dsDatosPersonales",dt);
        ReportDataSource rds2 = new ReportDataSource("dsComponentes", dt2);
       // ReportDataSource rds3 = new ReportDataSource("DataSet3", dt3);

        rptFormularioManual.LocalReport.DataSources.Add(rds);
        rptFormularioManual.LocalReport.DataSources.Add(rds2);
        
        //rptFormularioManual.LocalReport.DataSources.Add(rds3);

        //Path
        rptFormularioManual.LocalReport.ReportPath = "Reportes/rptReporteProcedimientoManual.rdlc"; 


        //Parameters

        //ReportParameter[] rptParams = new ReportParameter[] {
        //    new ReportParameter("i_iIdTramite",Convert.ToString(i_iIdTramite)),
        //    new ReportParameter("i_iIdGrupoBeneficio",Convert.ToString(i_iIdGrupoBeneficio))
            

        //};
        //rptFormularioManual.LocalReport.SetParameters(rptParams);
        //rptFormularioManual.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
       // rptFormularioManual.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportSegundoNivelProcessingEventHandler);
        
        
        //Refresh
        rptFormularioManual.LocalReport.Refresh();

        //subreporte
       
    }

   
  
    private DataTable GetData(int iIdTramite,int iIdGrupoBeneficio)
    {
        
        DataTable dt = new DataTable();
        //int iIdConexion = (int)Session["IdConexion"];
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        dt = ObjEmisionFormularioCC.rptFormularioAutomatico(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,0,null,0, ref sMensajeError);
        return dt;

    }
    private DataTable GetData2(int iIdTramite, int iIdGrupoBeneficio,int iComponente,string sRUC,int iIdTipoCC)
    {

        DataTable dt = new DataTable();
        //int iIdConexion = (int)Session["IdConexion"];
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "R";
        string sMensajeError = null;
        dt = ObjEmisionFormularioCC.rptFormularioAutomatico(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,iComponente,sRUC,iIdTipoCC, ref sMensajeError);
        return dt;

    }
    //void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    //{

    //    i_iIdTramite = Convert.ToInt32(ObjSeguridad.Desencriptar(Request.QueryString["iIdTramite"]));
    //    i_iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.Desencriptar(Request.QueryString["iIdGrupoBeneficio"]));
    //    int iIdConexion = (int)Session["IdConexion"];
    //    int i_iComponente = (int.Parse(e.Parameters[0].Values[0]));
        
    //    //int i_iComponente = Convert.ToInt32((e.Parameters["Componente"].Values.First()));
    //    string i_sRUC = null;
        
        
    //    DataTable dt = GetData2(i_iIdTramite, i_iIdGrupoBeneficio, i_iComponente,i_sRUC);        
    //    //ReportDataSource rds = new ReportDataSource("dsDatosPersonales", dt);
        
    //   // e.DataSources.Add(new ReportDataSource("dsPruebaSubReporte",dt));
    //    ReportDataSource rdss = new ReportDataSource("dsRazonSocial", dt );
    //    e.DataSources.Add(rdss);
    //    //int i_iComponentes = Convert.ToInt32((e.Parameters["Componentedos"].Values.First()));
    //    //int i_iComponente1 = (int.Parse(e.Parameters[0].Values[0]));
    //    //int i_iComponente2 = (int.Parse(e.Parameters[1].Values[0]));
    //    //int i_iComponente3 = (int.Parse(e.Parameters[2].Values[0]));
    //    //int i_iComponente4 = (int.Parse(e.Parameters[3].Values[0]));

    //    ReportDataSource rdsss = new ReportDataSource("dsCancha", dt);
    //    e.DataSources.Add(rdsss);
    //    }

   
    

    private DataTable GetData3(int iIdTramite, int iIdGrupoBeneficio,int iIdTipoCC)
    {
        //i_iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
        //i_iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));

        //i_iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
        //i_iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);

        //i_iTipoCC = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTipoCC"]));
        int iIdConexion = (int)Session["IdConexion"];

        DataTable dt = new DataTable();
 
        string cOperacion = "F";
        string sMensajeError = null;
        dt = ObjEmisionFormularioCC.rptFormularioAutomatico(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,0,null,iIdTipoCC, ref sMensajeError);
        return dt;

    }
    private DataTable GetData4(int iIdTramite, int iIdGrupoBeneficio, int iIdTipoCC)
    {
        //i_iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
        //i_iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));

        i_iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
        i_iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
        i_iTipoCC = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTipoCC"]));
        int iIdConexion = (int)Session["IdConexion"];

        DataTable dt = new DataTable();

        string cOperacion = "G";
        string sMensajeError = null;
        dt = ObjEmisionFormularioCC.rptFormularioAutomatico(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, 0, null, iIdTipoCC, ref sMensajeError);
        return dt;

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