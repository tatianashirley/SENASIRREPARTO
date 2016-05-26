using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Security.Principal;
using System.Net;
using wcfSeguridad.Logica;
using wcfConvenios.Logica;
using wfcDoblePercepcion.Logica;

public partial class Convenios_wfrmReporte : System.Web.UI.Page
{
    DataTable Encontrados;
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsInformacionLO Convenio = new clsInformacionLO();
    string mensaje = null;
    clsInformacion DP = new clsInformacion();
    clsInformacion info = new clsInformacion();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlRegional.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaRegional", "", "", "", "", "", "", ""
                                                 , 0, 0, ref mensaje);
            ddlRegional.DataValueField = "IdOficina";
            ddlRegional.DataTextField = "Nombre";
            ddlRegional.DataBind();
            ddlRegional.Items.Insert(0, new ListItem("TODOS", "0"));
            ddlRegional.SelectedValue = "0";

            ddlTipoDeuda.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaTipoDeuda", "", "", "", "", "", "", ""
                                                  , 0, 0, ref mensaje);
            ddlTipoDeuda.DataValueField = "IdDetalleClasificador";
            ddlTipoDeuda.DataTextField = "DescripcionDetalleClasificador";
            ddlTipoDeuda.DataBind();
            ddlTipoDeuda.Items.Insert(0, new ListItem("TODOS", ""));
            ddlTipoDeuda.SelectedValue = "0";
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
                rtpInforme.Visible = true;

                ReportParameter[] repParams = new ReportParameter[5];
                ViewState["PreviousPage"] = Request.UrlReferrer; //Guarda la url previa
                string h = (string)Session["id"];
                repParams[0] = new ReportParameter("FechaIncio", txtFechaInicio.Text);
                repParams[1] = new ReportParameter("FechaFin", txtFechaFin.Text);
                repParams[2] = new ReportParameter("TipoDeuda", ddlTipoDeuda.SelectedValue);
                repParams[3] = new ReportParameter("IdOficina", ddlRegional.SelectedValue);
                repParams[4] = new ReportParameter("Usuario", ConexionUsuario());
                string yy = "/ReporteConvenio/" + (string)Session["informe"];
                rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                rtpInforme.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                //rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials("SFERNANDEZ", "Darkrai780", "SENASIR");
                rtpInforme.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
                //rvReportes.ServerReport.ReportServerUrl = new Uri("--http://srapplp01.senasir.local/ReportServer";
                rtpInforme.ServerReport.ReportServerUrl = new Uri("http://srbdlp05.senasir.local/ReportServer");
                rtpInforme.ServerReport.ReportPath = "/ReporteConvenio/rptReportePorRegion";
                rtpInforme.ServerReport.SetParameters(repParams);
                rtpInforme.ServerReport.Refresh();


            }
            catch (Exception ex)
            {
                Master.MensajeError("No se pudo generar el informe", ex.Message);
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
        Response.Redirect("~/Convenios/wfrmReporte.aspx");
    }
    protected string ConexionUsuario()
    {
        string UsuarioConexio = "";
        Encontrados = DP.ObtieneDatos((int)Session["IdConexion"], "Q", "Conexion", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        UsuarioConexio = Encontrados.Rows[0][0].ToString();
        return UsuarioConexio;
    }
}