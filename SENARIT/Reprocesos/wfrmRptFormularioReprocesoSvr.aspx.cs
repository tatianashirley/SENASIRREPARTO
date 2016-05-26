using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using wcfReprocesos.Logica;

using System.Globalization;
using System.Threading;

using wcfSeguridad.Logica;
using System.Net;
using System.Security.Principal;

public partial class Reprocesos_wfrmRptFormularioReprocesoSvr : System.Web.UI.Page
{
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsReprocesoCC objReprocesoCC = new clsReprocesoCC();

    clsSeguridad ObjSeguridad = new clsSeguridad();

    int IdConexion; int IdUsuario; string CuentaUsuario, CodUsuario; int IdRol;
    long NUP; int NroFormularioRepro, IdTramite, IdTipoTramite, IdGrupoBeneficio;

    string mensaje = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
        //Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
        Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";

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
                CuentaUsuario = Session["CuentaUsuario"].ToString(); //VGALARZA
                CodUsuario = Session["CodUsuario"].ToString(); //45
                IdTipoTramite = (int)Session["IdTipoTramite"]; //357 Automatico, 356 Manual
            }
            NUP = Convert.ToInt64(Session["NUP"]);
            NroFormularioRepro = Convert.ToInt32(Session["NroFormularioRepro"]);
            IdTramite = Convert.ToInt32(Session["IdTramite"]);
            IdGrupoBeneficio = Convert.ToInt32(Session["IdGrupoBeneficio"]);

            //?iIdTramite=1073&iIdGrupoBeneficio=3
            string referencePage = HttpContext.Current.Request.UrlReferrer.AbsolutePath; ///SENARIT/Reprocesos/wfrmBuscadorDeTramites.aspx
            ViewState["PreviousPage"] = referencePage + "?iIdTramite=" + IdTramite.ToString() + "&iIdGrupoBeneficio=" + IdGrupoBeneficio;

            //ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
            //--------------------------------------------------
            CuentaUsuario = ObjSeguridad.ListaDatosConexion(IdConexion).Rows[0]["CuentaUsuario"].ToString();
            DataTable Reporte = new DataTable();
            try
            {
                string ServRep;
                string ServApl;
                string UsrRep;
                string PassUsrRep;
                string DomRep;
                ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

                //Reporte = obt.Impresion((int)Session["IdConexion"], "Q", t, b, tf, nc, ref mensaje);
                ReportParameter[] repParams = new ReportParameter[4];
                repParams[0] = new ReportParameter("CuentaUsuario", CuentaUsuario);
                repParams[1] = new ReportParameter("i_iNroFormularioRepro", NroFormularioRepro.ToString());
                repParams[2] = new ReportParameter("i_iIdTramite", IdTramite.ToString());
                repParams[3] = new ReportParameter("i_iIdGrupoBeneficio", IdGrupoBeneficio.ToString());

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                //ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://srapplp01.senasir.local/ReportServer");
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ServRep);

                if (IdTipoTramite == 357) //Automatico
                {
                    ReportViewer1.ServerReport.ReportPath = "/ReportesEnviosAPS/rptFormularioReprocesoAutomatico";
                }
                else //Manual
                {
                    ReportViewer1.ServerReport.ReportPath = "/ReportesEnviosAPS/rptFormularioReprocesoManual";
                }
                ReportViewer1.ServerReport.SetParameters(repParams);
                ReportViewer1.ServerReport.Refresh();
            }
            catch
            {
                Master.MensajeError("Error al Cargar los datos", mensaje);
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