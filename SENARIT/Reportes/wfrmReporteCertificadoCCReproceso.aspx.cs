using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Reporting.WebForms;
using System.Data;
using wcfEmisionCertificadoCC.Logica;
using System.Security.Principal;
using System.Net;
using wcfSeguridad.Logica;

using System.Web;
using System.Collections.Specialized;

public partial class Reportes_wfrmReporteCertificadoCCReproceso : System.Web.UI.Page
{
    clsEmisionCertificado ObjCertificado = new clsEmisionCertificado();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    Int64 Idtramite;
    Int32 IdConexion, IdGrupoBeneficio, NroCertificadoOld, IdTipoTramite, IdTipoReproceso, NroFormularioRepro, NoFormularioCalculo;
    string mensaje = null;
    string t, b, tf, nc;
    DataTable Parametros;
    Warning[] warnings;
    string[] streamids;
    string mimeType;
    string encoding;
    string extension;
    string deviceInfo;
    byte[] bytes;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["NroFormularioRepro"] = vNroFormularioRepro;
        //Session["RegistroAPS"] = vRegistroAPS;
        //Session["IdTramite"] = vIdTramite;
        //Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
        //Session["NroCertificado"] = vNroCertificado;
        //Session["IdTipoTramite"] = vIdTipoTramite;
        //Session["IdTipoReproceso"] = vIdTipoReproceso;

        Idtramite = (long)Session["IdTramite"];
        IdGrupoBeneficio = (int)Session["IdGrupoBeneficio"];
        NroCertificadoOld = (int)Session["NroCertificado"];
        IdTipoTramite = (int)Session["IdTipoTramite"];
        IdTipoReproceso = (int)Session["IdTipoReproceso"];
        NroFormularioRepro = (int)Session["NroFormularioRepro"];

        if (Session["NoFormularioCalculo"] != null)
        {
            NoFormularioCalculo = (int)Session["NoFormularioCalculo"]; //DS28888 y Reclamaciones
        }
        else
        {
            NoFormularioCalculo = -99;
        }

        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
            
            //?iIdTramite=1073&iIdGrupoBeneficio=3
            ViewState["PreviousPage"] = Request.UrlReferrer + "?iIdTramite=" + Idtramite + "&iIdGrupoBeneficio=" + IdGrupoBeneficio; 

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

            if (ObjCertificado.CertificadoReprocesado(IdConexion, "I", Idtramite, IdGrupoBeneficio, NroCertificadoOld, IdTipoTramite, IdTipoReproceso, NroFormularioRepro, NoFormularioCalculo, ref mensaje))
            {
                Parametros = ObjCertificado.ObtieneParametros(IdConexion, "Q", Idtramite, IdGrupoBeneficio, IdTipoTramite, ObjCertificado.iNroCertificadoReemplazo, ref mensaje);
                if (Parametros != null && Parametros.Rows.Count > 0)
                {
                    t = Parametros.Rows[0]["IdTramite"].ToString();
                    b = Parametros.Rows[0]["IdGrupoBeneficio"].ToString();
                    tf = Parametros.Rows[0]["IdTipoFormularioCalculo"].ToString();
                    nc = Parametros.Rows[0]["NoFormularioCalculo"].ToString();
                }
                else
                    Master.MensajeError("Error al realizar la operacion", mensaje);
            }
            else
                Master.MensajeError("Error al realizar la operacion", mensaje);
            
            if (mensaje == null)
            {
                try
                {
                    string UsrRep;
                    string PassUsrRep;
                    string DomRep;
                    string ServRep;
                    string ServApl;
                    ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

                    //Reporte = obt.Impresion((int)Session["IdConexion"], "Q", t, b, tf, nc, ref mensaje);
                    ReportParameter[] repParams = new ReportParameter[4];
                    repParams[0] = new ReportParameter("Tramite", t);
                    repParams[1] = new ReportParameter("GrupoB", b);
                    repParams[2] = new ReportParameter("TipoForm", tf);
                    repParams[3] = new ReportParameter("NoFormCalculo", nc);

                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                    ReportViewer1.ServerReport.ReportServerUrl = new Uri(ServRep);
                    ReportViewer1.ServerReport.ReportPath = "/EmisionCC/rptCertificadoCC";
                    ReportViewer1.ServerReport.SetParameters(repParams);
                    ReportViewer1.ServerReport.Refresh();

                    extension = "pdf";
                    deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
                    bytes = ReportViewer1.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("charset", "UTF-8");
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "CertificadoCCReproceso.pdf");
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch
                {
                    Master.MensajeError("Error al Cargar los datos", mensaje);
                }
            }
            else 
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
        }
    }
    //PageName comes from HttpContext.Current.Request.RawUrl and is supplied by the Page_Load event.
    public static string GetReferrerPageName()
    {
        string functionReturnValue = null;

        if ((((System.Web.HttpContext.Current.Request.UrlReferrer) != null)))
        {
            functionReturnValue = HttpContext.Current.Request.UrlReferrer.ToString();
        }
        else
        {
            functionReturnValue = "N/A";
        }
        return functionReturnValue;
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["PreviousPage"].ToString());
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