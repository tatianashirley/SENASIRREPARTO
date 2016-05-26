using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using wcfSeguridad.Logica;

public partial class PagoUnico_wfrmRptResolucionRentas : System.Web.UI.Page
{
    private int _idConexion;
    private string _mensajeError;

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
            Imprimir();
        }
    }

    private string ObtenerNomUsuario(string pCuenta)
    {
        try
        {
            var vNomUsua = "";
            var objUsua = new clsUsuario();
            var tbUsua = objUsua.ListaUsuarios(_idConexion, "Q", pCuenta, ref _mensajeError);
            if (tbUsua.Rows.Count > 0 && tbUsua != null)
            {
                vNomUsua = tbUsua.Rows[0]["NombreCompleto"].ToString();
            }
            return vNomUsua;
        }
        catch (Exception)
        {
            return "    ";
        }

    }

    private void Imprimir()
    {
        try
        {
            clsSeguridad ObjSeguridad = new clsSeguridad();

            string ServRep;
            string ServApl;
            string UsrRep;
            string PassUsrRep;
            string DomRep;
            ObjSeguridad.UsrReporte(out ServRep, out ServApl, out UsrRep, out PassUsrRep, out DomRep);

            var vCtaUsuario = Session["CuentaUsuario"].ToString();
            var vNomUsuario = ObtenerNomUsuario(Session["CuentaUsuario"].ToString());
            var repParams = new ReportParameter[3];
            repParams[0] = new ReportParameter("USUARIO", vCtaUsuario);
            repParams[1] = new ReportParameter("NOM_USUARIO", vNomUsuario);
            repParams[2] = new ReportParameter("QR", ServApl);

            rViewerRR.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rViewerRR.ServerReport.ReportServerUrl = new Uri(ServRep);
            rViewerRR.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rViewerRR.ServerReport.ReportPath = "/ReportesPU/RptResolRentas";
            rViewerRR.ServerReport.SetParameters(repParams);
            rViewerRR.ShowParameterPrompts = false;
            rViewerRR.ServerReport.Refresh();
            Master.MensajeOk("Se generó correctamente el reporte");
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al generar el reporte", ex.Message);
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