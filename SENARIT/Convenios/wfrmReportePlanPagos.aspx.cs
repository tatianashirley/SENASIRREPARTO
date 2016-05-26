using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using wcfEmisionCertificadoCC.Logica;
using System.Security.Principal;
using System.Drawing;

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
using wcfConvenios.Logica;
using wfcDoblePercepcion.Logica;

public partial class Convenios_wfrmReportePlanPagos : System.Web.UI.Page
{
    clsInformacion DP = new clsInformacion();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    DataTable Encontrados;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["id"] != null)
            {
                /*repParams[1] = new ReportParameter("FechaInicio", h);
                repParams[2] = new ReportParameter("FechaFin", h);
                repParams[3] = new ReportParameter("Periodo", h);*/

                 /*string UsrRep;
                 string PassUsrRep;
                 string DomRep;
                 ObjSeguridad.UsrReporte(out UsrRep, out PassUsrRep, out DomRep);*/
                  string UsrRep;
                  string PassUsrRep;
                  string DomRep;
                  string ServRep;
                  string ServApl;
                  ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
                  ReportParameter[] repParams;
                  repParams = new ReportParameter[0];
                  if ((string)Session["informe"] == "rptConvenioPlanPagos")
                  {
                      repParams = new ReportParameter[2];
                      ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                      string h = (string)Session["id"];

                      repParams[0] = new ReportParameter("ID", h);
                      repParams[1] = new ReportParameter("Usuario", ConexionUsuario());
                  }

                  if ((string)Session["informe"] == "rptConvenioDeposito")
                  {
                      repParams = new ReportParameter[2];
                      ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                      string h = (string)Session["id"];

                      repParams[0] = new ReportParameter("ID", h);
                      repParams[1] = new ReportParameter("Usuario", ConexionUsuario());
                  }

                  if ((string)Session["informe"] == "rptPagosDeuda")
                    {
                          repParams = new ReportParameter[6];
                          ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                          string h = (string)Session["id"];

                          repParams[0] = new ReportParameter("IdDeuda", h);
                          repParams[1] = new ReportParameter("FechaInicio", (string)Session["txtFechaInicio"]);
                          repParams[2] = new ReportParameter("FechaFin", (string)Session["txtFechaFin"]);
                        
                          if((string)Session["Anio"]=="0")
                          {
                              Session["Anio"] ="";
                          }
                          repParams[3] = new ReportParameter("Periodo", (string)Session["Anio"]);
                          repParams[4] = new ReportParameter("Usuario", ConexionUsuario());
                          repParams[5] = new ReportParameter("TipoDeuda", (string)Session["TipoDeuda"]); 
                     }
                else
                {
                    if ((string)Session["informe"] == "rptLiquidacion")
                    {
                        repParams = new ReportParameter[2];
                        ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                        string h = (string)Session["id"];
                        repParams[0] = new ReportParameter("ID", h);
                        repParams[1] = new ReportParameter("Usuario", ConexionUsuario());
                    }
                    else
                    {

                        if ((string)Session["informe"] == "FORM01")
                        {

                            if ((string)Session["TipoForm"] == "001")
                            {
                                repParams = new ReportParameter[5];
                                ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                                string h = (string)Session["id"];
                                repParams[0] = new ReportParameter("ID", h);
                                repParams[1] = new ReportParameter("Usuario", ConexionUsuario());
                                repParams[2] = new ReportParameter("TipoForm", (string)Session["TipoForm"]);
                                repParams[3] = new ReportParameter("PeriodoRetiro", (string)Session["MesRetiro"]);
                                repParams[4] = new ReportParameter("FechaDePago", (string)Session["FechaPago"]);
                            }
                        }
                        if ((string)Session["informe"] == "FORM02")
                        {
                            if ((string)Session["TipoForm"] == "002")
                            {
                                repParams = new ReportParameter[5];
                                ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                                string h = (string)Session["id"];
                                repParams[0] = new ReportParameter("ID", h);
                                repParams[1] = new ReportParameter("Usuario", ConexionUsuario());
                                repParams[2] = new ReportParameter("TipoForm", (string)Session["TipoForm"]);
                                repParams[3] = new ReportParameter("PeriodoRetiro", (string)Session["MesRetiro"]);
                                repParams[4] = new ReportParameter("FechaDePago", (string)Session["FechaPago"]);
                            }
                        }
                        
                    }
                  
                }
                  if ((string)Session["informe"] == "rptDetalleDeuda")
                  {
                      repParams = new ReportParameter[2];
                      ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                      string h = (string)Session["id"];
                      repParams[0] = new ReportParameter("ID", h);
                      repParams[1] = new ReportParameter("Usuario", ConexionUsuario());
                  }
                  string yy = "/ReporteConvenio/" + (string)Session["informe"];

                  rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                  rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                  //rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials("SFERNANDEZ", "Darkrai780", "SENASIR");
                  rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                  rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
                  rtpInforme.ServerReport.ReportPath = "/ReporteConvenio/" + (string)Session["informe"];
                  rtpInforme.ServerReport.SetParameters(repParams);
                  rtpInforme.ServerReport.Refresh();
                  pnlRegistro.Visible = false;
                  pnlTipoReporte.Visible = false;
                  Session.Remove("id");
         
            }
            else 
            {
                pnlRegistro.Visible = true;
                pnlTipoReporte.Visible = true;
            }
        }
    }
  /*  protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["PreviousPage"].ToString());
    }
  */  
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

    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {
        string FechaInicio = txtFechaInicio.Text;
        string FechaFin = txtFechaFin.Text;
        string rep ="";
        if(rbReporte.SelectedValue == "1")
            rep = "rptDetalleDescuento";
        else
            rep = "rptDetalleDescuento2";

        if (validar(FechaInicio, FechaFin))
        {
            try
            {
                /*string UsrRep;
                string PassUsrRep;
                string DomRep;
                ObjSeguridad.UsrReporte(out UsrRep, out PassUsrRep, out DomRep);*/
                string UsrRep;
                string PassUsrRep;
                string DomRep;
                string ServRep;
                string ServApl;
                ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);
                panReporte.Visible = true;
                pnlTipoReporte.Visible = true;
                rtpInforme.Visible = true;

                ReportParameter[] repParams = new ReportParameter[3];
                ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                string h = (string)Session["id"];
                repParams[0] = new ReportParameter("PerioI", txtFechaInicio.Text);
                repParams[1] = new ReportParameter("PerioF", txtFechaFin.Text);
                repParams[2] = new ReportParameter("Usuario", ConexionUsuario());
                string yy = "/ReporteConvenio/" + (string)Session["informe"];
                rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                //rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials("SFERNANDEZ", "Darkrai780", "SENASIR");
                rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
                rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
                rtpInforme.ServerReport.ReportPath = "/ReporteConvenio/" + rep;
                rtpInforme.ServerReport.SetParameters(repParams);
                rtpInforme.ServerReport.Refresh();
              

            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al generar Reporte", ex.Message);
            }
        }

    }

    protected bool validar(string FechaInicio, string FechaFin)
    {
        if (FechaInicio == "" && FechaFin == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA INICIO Y FECHA FIN');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (FechaInicio == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA INICIO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (FechaFin == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA FIN');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        return true;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Convenios/wfrmReportePlanPagos.aspx");
    }
    protected string ConexionUsuario()
    {
        string UsuarioConexio = "";
        string mensaje = "";
        Encontrados = DP.ObtieneDatos((int)Session["IdConexion"], "Q", "Conexion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        UsuarioConexio = Encontrados.Rows[0][0].ToString();
        return UsuarioConexio;

    }
}