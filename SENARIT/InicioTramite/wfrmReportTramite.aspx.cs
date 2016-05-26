using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Net;
using System.Security.Principal;
using wcfSeguridad.Logica;


public partial class Reportes_wfrmReportTramite : System.Web.UI.Page
{
    private const string REPORTE_PODER = "PODER";
    private const string REPORTE_RENUNCIA = "RENUNCIA INICIO MANUAL";
    private const string REPORTE_OBSERVADOS = "OBSERVADOS";
    private const string REPORTE_460 = "460";
    private const string REPORTE_266 = "266";
    private const string REPORTE_JURIDICO = "JURIDICO";
    private const string REPORTE_ASIGNACION = "ASIGNACION";

    clsSeguridad ObjSeguridad = new clsSeguridad();
    string b;
    string IdTramite;
    string TipoReporte;
    string TipoIdReporte;
    int IdConexion;
    string mensaje = null;

    Warning[] warnings;
    string[] streamids;
    string mimeType;
    string encoding;
    string extension;
    string deviceInfo;
    byte[] bytes;
    protected void Page_Load(object sender, EventArgs e)
    {
        string ServRep;
        string ServApl;
        string UsrRep;
        string PassUsrRep;
        string DomRep;
        ReportParameter[] repParams = null;
        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
            //Id Conexion
            if (Session["IdConexion"] == null)
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
            else
            {
                IdConexion = (int)Session["IdConexion"];
            }
            //Id Tramite
            if (Session["IdTramite"] != null)
            {
                IdTramite = Convert.ToString(Session["IdTramite"]);
            }
            else
            {
                IdTramite = Convert.ToString(Request.QueryString["IdTramite"]);
            }
            //Tipo Reporte
            if (Session["TipoReporte"] != null)
            {
                TipoReporte = Convert.ToString(Session["TipoReporte"]);
            }
            else
            {
                TipoReporte = Convert.ToString(Request.QueryString["TipoReporte"]);
            }
            //Tipo Id Reporte
            if (Session["TipoIdReporte"] != null)
            {
                TipoIdReporte = Convert.ToString(Session["TipoIdReporte"]);
            }
            else
            {
                TipoIdReporte = Convert.ToString(Request.QueryString["TipoIdReporte"]);
            }
        }
     
            b = ObjSeguridad.ListaDatosConexion(IdConexion).Rows[0]["CuentaUsuario"].ToString();
            DataTable Reporte = new DataTable();
            try
            {
                ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ServRep);

                //Reporte Poder
                if (REPORTE_PODER.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[2];
                    repParams[0] = new ReportParameter("IdTramite", IdTramite);
                    repParams[1] = new ReportParameter("CuentaUsuario", b);                    
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/PoderNotarial";//nombre del reporte
                }
                //Reporte renuncia
                if (REPORTE_RENUNCIA.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[3];
                    repParams[0] = new ReportParameter("IdTramite", IdTramite);
                    repParams[1] = new ReportParameter("IdTipoInconsistencia", TipoIdReporte);
                    repParams[2] = new ReportParameter("CuentaUsuario", b);
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/RenunciaInicioManual";//nombre del reporte
                }
                //Reporte observados
                if (REPORTE_OBSERVADOS.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[3];
                    repParams[0] = new ReportParameter("IdTramite", IdTramite);
                    repParams[1] = new ReportParameter("IdTipoInconsistencia", TipoIdReporte);
                    repParams[2] = new ReportParameter("CuentaUsuario", b);
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/Observados";//nombre del reporte
                }
                //Reporte 460
                if (REPORTE_460.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[3];
                    repParams[0] = new ReportParameter("IdTramite", IdTramite);
                    repParams[1] = new ReportParameter("IdTipoInconsistencia", TipoIdReporte);
                    repParams[2] = new ReportParameter("CuentaUsuario", b);
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/Formulario460";//nombre del reporte
                }
                //Reporte 266
                if (REPORTE_266.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[3];
                    repParams[0] = new ReportParameter("IdTramite", IdTramite);
                    repParams[1] = new ReportParameter("IdTipoInconsistencia", TipoIdReporte);
                    repParams[2] = new ReportParameter("CuentaUsuario", b);
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/ModificacionFechaNacimiento";//nombre del reporte
                }
                //Reporte juridico
                if (REPORTE_JURIDICO.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[3];
                    repParams[0] = new ReportParameter("IdTramite", IdTramite);
                    repParams[1] = new ReportParameter("IdTipoInconsistencia", TipoIdReporte);
                    repParams[2] = new ReportParameter("CuentaUsuario", b);
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/Juridico";//nombre del reporte
                }
                //Reporte asignacion
                if (REPORTE_ASIGNACION.Equals(TipoReporte))
                {
                    repParams = new ReportParameter[2];
                    repParams[0] = new ReportParameter("IdAsignacion", IdTramite);
                    repParams[1] = new ReportParameter("CuentaUsuario", b);
                    ReportViewer1.ServerReport.ReportPath = "/InicioTramite/Asignacion";//nombre del reporte
                }
            }
            catch
            {
                Master.MensajeError("Error al Cargar los datos", mensaje);
            }
            ReportViewer1.ServerReport.SetParameters(repParams);
            ReportViewer1.ServerReport.Refresh();
            extension = "pdf";
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            bytes = ReportViewer1.ServerReport.Render(extension, null, out mimeType, out encoding, out extension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("charset", "UTF-8");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "FormEmitidos.pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
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