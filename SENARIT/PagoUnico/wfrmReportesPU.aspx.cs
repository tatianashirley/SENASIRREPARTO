using System;
using System.Data;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using wcfInicioTramite.Tramite.Logica;
using wcfPagoUnico.Logica;
using System.Web.UI;
using wcfSeguridad.Logica;

public partial class PagoUnico_wfrmReportesPU : System.Web.UI.Page
{
    private clsPUProcesos objProcesos =  new clsPUProcesos();
    private int _idConexion;
    private string _mensajeError;
    
    private static long _NUPTit = 0, _NUPDH = 0;
    private static long _tramite = 0;
    private static int _certificado = 0, _idBeneficio = 0, _grupFlia;
    private static long _numResol = 0;
    private static int _estado = 0;
    private static DateTime _fecResol;
    private static int _filaSel;

    private const int EstAutorizado = 31510;
    private const int EstAprobado = 31509;


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
            Master.btnCerrarSesion.CausesValidation = false;

            VisualizarEstructura();

            rvFechaResol.MaximumValue = DateTime.Today.ToShortDateString();
        } 
    }

    #region LIMPIAR

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    private void LimpiarBusqueda()
    {
        txtMatriculaTit.Text = string.Empty;
        txtNumDocumento.Text = string.Empty;
        rptViewPU.Visible = false;
        gvBenefPU.DataSource = null;
        gvBenefPU.DataBind();
        ibtnLimpiar.Enabled = true;
    }

    private void LimpiarDatosResolucion()
    {
        txtNumResol.Text = string.Empty;
        txtFechaResol.Text = string.Empty;
    }

    #endregion

    #region CARGAR_DATOS_ESTRUCTURA

    private void VisualizarEstructura()
    {
        try
        {
            if (Request.QueryString["rpt"] != null)
            {
                switch (Request.QueryString["rpt"])
                {
                    //Reporte de Presolicitud PU
                    case "1":
                        lblTitulo.Text = "Imprimir Pre-Solicitud PU";
                        pnlBusqueda.Visible = false;
                        gvBenefPU.Columns[9].Visible = false; //columna10 Autorizar
                        gvBenefPU.Columns[10].Visible = false; //columna11 Aprobar
                        gvBenefPU.Columns[11].Visible = true; //columna11 Imprimir

                        CargarGrillaBeneficiarios(Session["MatriculaTit"].ToString(), Session["NumDocPU"].ToString());
                        _NUPTit = Convert.ToInt64(Session["NUPTit"]);

                        break;
                    //Interfaz para Revisar
                    case "2":
                        lblTitulo.Text = "Revisar Pre-Solicitud Pago Único";
                        pnlBusqueda.Visible = true;
                        gvBenefPU.Columns[9].Visible = true; //columna09 Autorizar
                        gvBenefPU.Columns[10].Visible = false; //columna10 Aprobar
                        gvBenefPU.Columns[11].Visible = true; //columna11 Imprimir
                        break;
                    //Interfaz para Resolución
                    case "3":
                        lblTitulo.Text = "Registro Resolución Pago Único";
                        pnlBusqueda.Visible = true;
                        gvBenefPU.Columns[9].Visible = false; //columna09 Autorizar
                        gvBenefPU.Columns[10].Visible = true; //columna10 Aprobar
                        gvBenefPU.Columns[11].Visible = false; //columna11 Imprimir

                        break;

                    //Interfaz para Reimpresión Pre-Solicitud
                    case "4":
                        lblTitulo.Text = "Re-Impresión de Pre-Solicitud Pago Único";
                        pnlBusqueda.Visible = true;
                        gvBenefPU.Columns[9].Visible = false; //columna09 Autorizar
                        gvBenefPU.Columns[10].Visible = false; //columna10 Aprobar
                        gvBenefPU.Columns[11].Visible = true; //columna11 Imprimir

                        break;

                    //Interfaz para Monto Actualizado para Auto
                    case "5":
                        lblTitulo.Text = "Auto de Generación para Pago Único";
                        pnlBusqueda.Visible = false;
                        gvBenefPU.Columns[9].Visible = false; //columna10 Autorizar
                        gvBenefPU.Columns[10].Visible = false; //columna11 Aprobar
                        gvBenefPU.Columns[11].Visible = true; //columna11 Imprimir

                        CargarGrillaBeneficiarios(Session["MatriculaTit"].ToString(), Session["NumDocPU"].ToString());
                        _NUPTit = Convert.ToInt64(Session["NUPTit"]);

                        break;
                }
            }
            else
            {
                Master.MensajeError("Una de las variables enviadas es nula.", "[rpt]=null");
            }

        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al cargar la página", ex.Message);
        }
    }

    private void CargarGrillaBeneficiarios(string pMatriculaTit, string pNumDoc)
    {
        try
        {
            var dt = objProcesos.ObtieneDatosSolicitantes(_idConexion, "Q", ref _mensajeError, pMatriculaTit, pNumDoc);

            if (_mensajeError == null)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    gvBenefPU.DataSource = dt;
                    gvBenefPU.DataBind();

                    if (Request.QueryString["rpt"] == "3")
                    {
                        DeshabilitarImpresion(11);    
                    }
                }
                else
                {
                    gvBenefPU.DataSource = null;
                    gvBenefPU.DataBind();
                    Master.MensajeWarning("No se encontró ningún registro para el criterio de búsqueda.");
                }
            }
            else
            {
                Master.MensajeError(
                       "Se produjo un error en el cargado de datos para la búsqueda con la matrícula requerida.",
                       _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se pordujo una excepción al cargar la Grilla", ex.Message);
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

            return " ";
        }
        
    }

    #endregion

    #region CARGAR_IMPRESION

    private ReportParameter[] ObtenerParamAuto(string pServApl)
    {
        DataTable dt = (DataTable) Session["dtMtoActual"];
        DataRow dr = dt.Rows[0];

        var vFecCerti = String.Format("{0:dd/MM/yyyy}", dr["FechaTCAnterior"]);
        var vFecCalc = String.Format("{0:dd/MM/yyyy}", dr["FechaTCActual"]);
            
            
        var repParams = new ReportParameter[11];
        repParams[0] = new ReportParameter("NUP", _NUPTit.ToString());
        repParams[1] = new ReportParameter("GrupFlia", _grupFlia.ToString());
        repParams[2] = new ReportParameter("MtoCertificado", dr["MontoAnterior"].ToString());
        repParams[3] = new ReportParameter("TCCertificado", dr["TCAnterior"].ToString());
        repParams[4] = new ReportParameter("FecEmisionCertificado", vFecCerti);
        repParams[5] = new ReportParameter("MtoActual", dr["MontoActual"].ToString());
        repParams[6] = new ReportParameter("TCCalculo", dr["TCActual"].ToString());
        repParams[7] = new ReportParameter("FecCalculo", vFecCalc);
        repParams[8] = new ReportParameter("USUARIO", Session["CuentaUsuario"].ToString());
        repParams[9] = new ReportParameter("nomUsuario", ObtenerNomUsuario(Session["CuentaUsuario"].ToString()));
        repParams[10] = new ReportParameter("QR", pServApl);

        return repParams;
    }

    private ReportParameter[] ObtenerParamPreSol(string pServApl)
    {
        var repParams = new ReportParameter[5];

        repParams[0] = new ReportParameter("NUP", _NUPTit.ToString());
        repParams[1] = new ReportParameter("NUPDH", _NUPDH.ToString());
        repParams[2] = new ReportParameter("USUARIO", Session["CuentaUsuario"].ToString());
        repParams[3] = new ReportParameter("GrupFlia", _grupFlia.ToString());
        repParams[4] = new ReportParameter("QR", pServApl);

        return repParams;
    }

    private void Imprimir(string pRpt)
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

            
            rptViewPU.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            rptViewPU.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptViewPU.ServerReport.ReportServerUrl = new Uri(ServRep);
            rptViewPU.ServerReport.ReportServerCredentials = new CustomReportCredentials(UsrRep, PassUsrRep, DomRep);
            rptViewPU.ServerReport.ReportPath = "/ReportesPU/" + pRpt;
            if (Request.QueryString["rpt"] == "5")
                rptViewPU.ServerReport.SetParameters(ObtenerParamAuto(ServApl));
            else
                rptViewPU.ServerReport.SetParameters(ObtenerParamPreSol(ServApl));
            rptViewPU.ShowParameterPrompts = false;
            rptViewPU.ServerReport.Refresh();
            Master.MensajeOk("Se generó correctamente el reporte");
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al generar el reporte", ex.Message);
        }
    }

    #endregion

    #region CARGAR_OPCIONES


    private void DeshabilitarImpresion(int pColImpresion)
    {
        for (int i = 0; i < gvBenefPU.Rows.Count; i++)
        {
            gvBenefPU.Rows[i].Cells[pColImpresion].Enabled = false;
        }
    }

    private void DeshabilitarBotonGrilla(int pEstado)
    {
        switch (pEstado)
        {
            case EstAutorizado:
                gvBenefPU.Rows[_filaSel].Cells[9].Enabled = false;
                break;
            case EstAprobado:
                gvBenefPU.Rows[_filaSel].Cells[10].Enabled = false;
                break;
        }
    }


    private void ActualizarEstadoPU(long pNUPTit, long pNUPDH, long pTramite, int pCertificado, int pEstado, string pDescripEstado)
    {
        var vNUP = objProcesos.ActualizaEstadosPU(_idConexion, "U", ref _mensajeError, pNUPTit, pNUPDH, pEstado, pTramite, pCertificado);
        if (vNUP != 0 && _mensajeError == null)
        {
            Master.MensajeOk("Se registró la "+ pDescripEstado +" correctamente de la Pre-Solicitud de PU");
            DeshabilitarBotonGrilla(pEstado);
        }
        else
        {
            Master.MensajeError("Se produjo un error en la "+ pDescripEstado +" de la Pre-Solicitud de PU", _mensajeError);
        }
    }

    private void AutorizarPU(long pNUPTit, long pNUPDH, long pTramite, int pCertificado)
    {
        ActualizarEstadoPU(pNUPTit, pNUPDH, pTramite, pCertificado, 31510, "Revisión");
    }

    private void AprobarPU(long pNUPTit, long pNUPDH, long pTramite, int pCertificado)
    {
        ActualizarEstadoPU(pNUPTit, pNUPDH, pTramite, pCertificado, 31509, "Resolución");
    }

    private void RegistrarResolEnPopup()
    {        
        _numResol = Convert.ToInt64(txtNumResol.Text);
        _fecResol = Convert.ToDateTime(txtFechaResol.Text);
        var vNUP = objProcesos.RegistraResolucion(_idConexion, "U", ref _mensajeError, _NUPTit, _NUPDH, _numResol,
            _fecResol);

        if (vNUP != 0 && _mensajeError == null)
        {            
            AprobarPU(_NUPTit, _NUPDH, _tramite, _certificado);
            
            gvBenefPU.Rows[_filaSel].Cells[11].Enabled = true;
            LimpiarDatosResolucion();

            Master.MensajeOk("Se registró los Datos de Resolución ");
        }
        else
        {
            Master.MensajeError("Se produjo un error al Registrar la Resolución", _mensajeError);
            LimpiarDatosResolucion();
        }
    }

    private void VerificarAutorizado(int pEstado, object sender, GridViewCommandEventArgs e) 
    {        
        if (pEstado == 31509)//31509=Estado Resolución
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('El trámite se encuentra con registro de Resolución.');", true);
        }
        else
        {
            btnResolAprob_Click(sender, e);
        }
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarMensajesMasterPage();
        CargarGrillaBeneficiarios(txtMatriculaTit.Text, txtNumDocumento.Text);
    }

    protected void ibtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarBusqueda();
        LimpiarMensajesMasterPage();
    }

    #endregion

    #region EVENTOS_GRILLA

    protected void btnResolAprob_Click(object sender, EventArgs e)
    {
        popupResol.Show();
    }

    protected void gvBenefPU_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        _filaSel = Int32.Parse(e.CommandArgument.ToString());
        var dataKey = gvBenefPU.DataKeys[_filaSel];
        if (dataKey != null)
        {
            _NUPTit = (long) dataKey["NUPTitular"];
            _tramite = (long) dataKey["Tramite"];
            _certificado = Convert.ToInt32(dataKey["NumeroCertificado"].ToString());
            _estado = Convert.ToInt32(dataKey["Estado"]);
            _idBeneficio = (int) dataKey["IdBeneficio"];
            _grupFlia = (int) dataKey["GrupoFamiliar"];
            
            if (_idBeneficio == 21) //IdBeneficio21=PAGO UNICO
                _NUPDH = 0;
            else
                _NUPDH = (long) dataKey["NUP"];
        }

        switch(e.CommandName)
        {
            case "cmdImprimir":
                rptViewPU.Visible = true;
                
                switch (Request.QueryString["rpt"])
                {
                    case "1":
                        Imprimir("RptPresolicitudPU");
                        break;
                    case "2":
                        Imprimir("RptSegurosPU");
                        break;
                    case "3":
                        Imprimir("RptSegurosPU");
                        break;
                    case "4":
                        Imprimir("RptPresolicitudPU");
                        break;
                    case "5":
                        Imprimir("RptMontosAuto");
                        break;
                }
                break;
            case "cmdAutorizar":
                AutorizarPU(_NUPTit, _NUPDH, _tramite, _certificado);//, _filaSel);
                break;
            case "cmdAprobar":
                VerificarAutorizado(_estado, sender,e);
                break;
        }
    }    
    
    #endregion

    #region REGISTRO_POPUPS

    protected void btnCancelaResol_Click(object sender, EventArgs e)
    {
       LimpiarDatosResolucion();
    }
    protected void btnRegistrarResol_Click(object sender, EventArgs e)
    {
        RegistrarResolEnPopup();
    }

    #endregion
    
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