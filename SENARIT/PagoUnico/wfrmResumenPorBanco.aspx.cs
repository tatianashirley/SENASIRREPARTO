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
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using wcfInicioTramite.Tramite.Logica;
using wcfSeguridad.Logica;

public partial class PagoUnico_Default : System.Web.UI.Page
{
    private clsTramite objTramite = new clsTramite();
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
            _idConexion = (int) Session["IdConexion"];
        }

        if (!Page.IsPostBack)
        {
            Master.btnCerrarSesion.CausesValidation = false;

            CargarCboEntidadFinan();

            txtAnio.Text = DateTime.Today.Year.ToString();
            ddlMes.SelectedValue = DateTime.Today.Month.ToString();
        }
    }

    #region CARGAR_DATOS

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }
   
    private void CargarCboEntidadFinan()
    {
        var dt = objTramite.ObtenerClasificador(_idConexion, "Q", 93, ref _mensajeError);

        if (dt != null && dt.Rows.Count > 0)
        {
            ddlEntFinan.DataSource = dt;
            ddlEntFinan.DataTextField = "Descripcion";
            ddlEntFinan.DataValueField = "IdDetalleClasificador";
            ddlEntFinan.DataBind();

            ddlEntFinan.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            ddlEntFinan.SelectedValue = 811.ToString(); //BANCO UNION
        }
        else
        {
            Master.MensajeError(_mensajeError, "Se produjo un error al cargar el combo de Entidades Financieras");
        }
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void ibtnImprimir_Click(object sender, ImageClickEventArgs e)
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

            rptViewResumen.Visible = true;

            var repParams = new ReportParameter[5];
            repParams[0] = new ReportParameter("IdBanco", ddlEntFinan.SelectedValue);
            repParams[1] = new ReportParameter("Mes", ddlMes.SelectedValue);
            repParams[2] = new ReportParameter("Anio", txtAnio.Text);
            repParams[3] = new ReportParameter("Usuario", Session["CuentaUsuario"].ToString());
            repParams[4] = new ReportParameter("QR", ServApl);
            rptViewResumen.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptViewResumen.ServerReport.ReportServerUrl = new Uri(ServRep);
            rptViewResumen.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rptViewResumen.ServerReport.ReportPath = "/ReportesPU/RptResumenPorBanco";
            rptViewResumen.ServerReport.SetParameters(repParams);
            rptViewResumen.ShowParameterPrompts = false;
            rptViewResumen.ServerReport.Refresh();
            Master.MensajeOk("Se generó correctamente el reporte");
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al generar el reporte", ex.Message);
        }
    }

    protected void ibtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        txtAnio.Text = "0";
        ddlMes.SelectedIndex = 0;
        rptViewResumen.Visible = false;
        LimpiarMensajesMasterPage();
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

    #endregion
}