using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

using wcfSeguridad.Logica;
using wcfReprocesos.Logica;
using wcfInicioTramite.Logica;
using wcfWFArticulador.Logica;

public partial class Reprocesos_wfrmReprocesos : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsReprocesoCC objReprocesoCC = new clsReprocesoCC();
    clsRM266 objRM266 = new clsRM266();
    clsDS28888 objDS28888 = new clsDS28888();
    clsRECLAMACIONES objRECLAMACIONES = new clsRECLAMACIONES();

    clsBandejaUsuario objBandejaUsuario = new clsBandejaUsuario();

    int IdConexion;

    private Int32 vIdUsuario
    {
        get { return Int32.Parse(ViewState["IdUsuario"].ToString()); }
        set { ViewState["IdUsuario"] = value; }
    }
    private Int32 vNroFormularioRepro
    {
        get { return Int32.Parse(ViewState["NroFormularioRepro"].ToString()); }
        set { ViewState["NroFormularioRepro"] = value; }
    }
    private Int32 vIdTipoReproceso
    {
        get { return Int32.Parse(ViewState["IdTipoFormulario"].ToString()); }
        set { ViewState["IdTipoFormulario"] = value; }
    }
    private String vCodigoTipoReproceso
    {
        get { object obj = ViewState["CodigoTipoReproceso"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["CodigoTipoReproceso"] = value; }
    }
    private String vNumeroResolucion
    {
        get { object obj = ViewState["NumeroResolucion"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["NumeroResolucion"] = value; }
    }
    public DateTime? vFechaResolucion
    {
        get { object obj = ViewState["FechaResolucion"]; if (obj != null) return (DateTime)obj; return null; }
        set { ViewState["FechaResolucion"] = value; }
    }
    public DateTime? vFechaNacimientoNueva
    {
        get { object obj = ViewState["FechaNacimientoNueva"]; if (obj != null) return (DateTime)obj; return null; }
        set { ViewState["FechaNacimientoNueva"] = value; }
    }
    private String vsIdTramite
    {
        get { object obj = ViewState["sIdTramite"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["sIdTramite"] = value; }
    }
    private Int64 vIdTramite
    {
        get { return Int64.Parse(ViewState["IdTramite"].ToString()); }
        set { ViewState["IdTramite"] = value; }
    }
    private Int32 vIdGrupoBeneficio
    {
        get { return Int32.Parse(ViewState["IdGrupoBeneficio"].ToString()); }
        set { ViewState["IdGrupoBeneficio"] = value; }
    }
    private Int32 vIdTipoTramite
    {
        get { return Int32.Parse(ViewState["IdTipoTramite"].ToString()); }
        set { ViewState["IdTipoTramite"] = value; }
    }
    private Int64 vNUP
    {
        get { return Int64.Parse(ViewState["NUP"].ToString()); }
        set { ViewState["NUP"] = value; }
    }
    private Int32 vNoFormularioCalculo
    {
        get { return Int32.Parse(ViewState["NoFormularioCalculo"].ToString()); }
        set { ViewState["NoFormularioCalculo"] = value; }
    }
    private Int32 vIdTipoFormularioCalculo
    {
        get { return Int32.Parse(ViewState["IdTipoFormularioCalculo"].ToString()); }
        set { ViewState["IdTipoFormularioCalculo"] = value; }
    }
    private Int32 vNroCertificado
    {
        get { return Int32.Parse(ViewState["NroCertificado"].ToString()); }
        set { ViewState["NroCertificado"] = value; }
    }
    private Int32 vNroCertificadoNuevo
    {
        get { return Int32.Parse(ViewState["NroCertificadoNuevo"].ToString()); }
        set { ViewState["NroCertificadoNuevo"] = value; }
    }
    private Boolean vRegistroAPS
    {
        get { return Boolean.Parse(ViewState["RegistroAPS"].ToString()); }
        set { ViewState["RegistroAPS"] = value; }
    }
    private Boolean vRegistroAPS_Baja
    {
        get { return Boolean.Parse(ViewState["RegistroAPS_Baja"].ToString()); }
        set { ViewState["RegistroAPS_Baja"] = value; }
    }
    private Boolean vRegistroAPS_Alta
    {
        get { return Boolean.Parse(ViewState["RegistroAPS_Alta"].ToString()); }
        set { ViewState["RegistroAPS_Alta"] = value; }
    }
    private Boolean vCertificadoAnulado
    {
        get { return Boolean.Parse(ViewState["CertificadoAnulado"].ToString()); }
        set { ViewState["CertificadoAnulado"] = value; }
    }
    private Decimal vMontoCCAceptadoNuevo
    {
        get { return Decimal.Parse(ViewState["MontoCCNuevo"].ToString()); }
        set { ViewState["MontoCCNuevo"] = value; }
    }
    private Decimal vMontoCCAceptado
    {
        get { return Decimal.Parse(ViewState["MontoCC"].ToString()); }
        set { ViewState["MontoCC"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];

            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion(IdConexion);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                vIdUsuario = Int32.Parse(dtUsuarioDatos.Rows[0]["IdUsuario"].ToString());
            }
            else
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
        }

        if (!Page.IsPostBack)
        {
            //wfrmReprocesos.aspx?iIdTramite=286132&iIdGrupoBeneficio=3
            if (Request.QueryString["iIdTramite"] != null)
            {
                vIdTramite = Int64.Parse(Request.QueryString["iIdTramite"]);
                vIdGrupoBeneficio = Int32.Parse(Request.QueryString["iIdGrupoBeneficio"]);
                txtNumeroTramite.Text = vIdTramite.ToString();
                CargaFormularioReprocesos(vIdTramite);
            }
            else
            {
                vIdGrupoBeneficio = 3;
                //CargaFormularioReprocesos(-1);
            }
            CargaTiposReprocesos();
            CargaEstadosReprocesos();
        }
    }
    protected void imgBuscarReproceso_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        if (String.IsNullOrEmpty(txtNumeroTramite.Text) == true)
            vIdTramite=-1;
        else
            vIdTramite = Int64.Parse(txtNumeroTramite.Text);
        
        vIdGrupoBeneficio = 3;

        CargaFormularioReprocesos(vIdTramite);
    }
    private void CargaTiposReprocesos()
    {
        objReprocesoCC.iIdConexion = IdConexion;
        if (objReprocesoCC.ListaTiposReprocesos())
        {
            ddlTipoReproceso.DataTextField = "TipoReproceso";
            ddlTipoReproceso.DataValueField = "IdTipoReproceso";
            ddlTipoReproceso.DataSource = objReprocesoCC.DSet.Tables[0];
            ddlTipoReproceso.DataBind();
            ddlTipoReproceso.Items.Add(new ListItem("Todos (*)", "-1"));

            ddlTipoReproceso.ClearSelection(); //making sure the previous selection has been cleared
            ddlTipoReproceso.Items.FindByValue("-1").Selected = true;
        }
        else
        {
            //Error
            string DetalleError = objReprocesoCC.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }        
    }
    private void CargaEstadosReprocesos()
    {
        objReprocesoCC.iIdConexion = IdConexion;
        if (objReprocesoCC.ListaEstadosReprocesos())
        {
            ddlEstadoReproceso.DataTextField = "EstadoReproceso";
            ddlEstadoReproceso.DataValueField = "IdEstadoReproceso";
            ddlEstadoReproceso.DataSource = objReprocesoCC.DSet.Tables[0]; 
            ddlEstadoReproceso.DataBind();
            ddlEstadoReproceso.Items.Add(new ListItem("Todos (*)", "-1"));

            ddlEstadoReproceso.ClearSelection(); //making sure the previous selection has been cleared
            ddlEstadoReproceso.Items.FindByValue("-1").Selected = true;
        }
        else
        {
            //Error
            string DetalleError = objReprocesoCC.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void CargaFormularioReprocesos(long iIdTramite)
    {
        objReprocesoCC.iIdConexion = IdConexion;
        objReprocesoCC.sIdTramite = iIdTramite.ToString();
        //objReprocesoCC.iIdEstadoReproceso = int.Parse(ddlEstadoReproceso.SelectedValue);
        objReprocesoCC.iIdEstadoReproceso = (ddlEstadoReproceso.SelectedValue == "" ? -1 : Int32.Parse(ddlEstadoReproceso.SelectedValue));
        //objReprocesoCC.iIdTipoReproceso = int.Parse(ddlTipoReproceso.SelectedValue);
        objReprocesoCC.iIdTipoReproceso = (ddlTipoReproceso.SelectedValue == "" ? -1 : Int32.Parse(ddlTipoReproceso.SelectedValue));
        objReprocesoCC.bBandejaTrabajo = Boolean.Parse(dllBandejaTrabajo.SelectedValue);
        if (objReprocesoCC.BuscaFormulariosReprocesos())
        {
            gvFormulariosReprocesos.DataSource = objReprocesoCC.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objReprocesoCC.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvFormulariosReprocesos.DataBind();
        gvFormulariosReprocesos.SelectedIndex = -1;
        
        pnlFormReprocesoDatos.Visible = false;
        pnlReprocesoRM266.Visible = false;
        pnlReproceso28888.Visible = false;
        pnlReprocesoReclamaciones.Visible = false;
    }
    protected void gvFormulariosReprocesos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BuscaTramite")
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            string sIdTramite = gvFormulariosReprocesos.DataKeys[currentRowIndex]["IdTramite"].ToString();
            string sIdGrupoBeneficio = gvFormulariosReprocesos.DataKeys[currentRowIndex]["IdGrupoBeneficio"].ToString();
            Response.Redirect("wfrmBuscadorDeTramites.aspx?iIdTramite=" + sIdTramite + "&iIdGrupoBeneficio=" + sIdGrupoBeneficio);
        }
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvFormulariosReprocesos.SelectedIndex = currentRowIndex;

            Int64 HIdTramite = Int64.Parse(gvFormulariosReprocesos.DataKeys[currentRowIndex]["IdTramite"].ToString());
            Int32 HIdGrupoBeneficio = Int32.Parse(gvFormulariosReprocesos.DataKeys[currentRowIndex]["IdGrupoBeneficio"].ToString());
            lblHIdTramite.Text = HIdTramite.ToString();

            CargarGrillaHistorialTramite(HIdTramite.ToString());
            ModalPopupExtender2.Show();
        }
        if (e.CommandName == "CANCELAR") //Cancelar creación de Reproceso (solo en estado registrado)
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvFormulariosReprocesos.SelectedIndex = currentRowIndex;

            objReprocesoCC.iIdConexion = IdConexion;
            objReprocesoCC.iIdTramite = Int64.Parse(gvFormulariosReprocesos.DataKeys[currentRowIndex]["IdTramite"].ToString());
            objReprocesoCC.iIdGrupoBeneficio = Int32.Parse(gvFormulariosReprocesos.DataKeys[currentRowIndex]["IdGrupoBeneficio"].ToString());
            if (objReprocesoCC.CancelaFormularioReproceso())
            {
                imgBuscarReproceso_Click(imgBuscarReproceso, null);
            }
            else
            {
                //Error
                string DetalleError = objReprocesoCC.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void gvFormulariosReprocesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFormulariosReprocesos.PageIndex = e.NewPageIndex;
        CargaFormularioReprocesos(-1);
        gvFormulariosReprocesos.SelectedIndex = -1;
        pnlReprocesoRM266.Visible = false;
        pnlReproceso28888.Visible = false;
        pnlReprocesoReclamaciones.Visible = false;
    }
    protected void gvFormulariosReprocesos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkReproceso = (CheckBox)e.Row.FindControl("chkReproceso");
            Int32 IdEstadoReproceso = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[e.Row.RowIndex]["IdEstadoReproceso"].ToString()) ? 0 : Int32.Parse(gvFormulariosReprocesos.DataKeys[e.Row.RowIndex]["IdEstadoReproceso"].ToString()));
            Int32 NroFormularioRepro = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[e.Row.RowIndex]["NroFormularioRepro"].ToString()) ? 0 : Int32.Parse(gvFormulariosReprocesos.DataKeys[e.Row.RowIndex]["NroFormularioRepro"].ToString()));

            ImageButton imgCancelarReproceso = (ImageButton)e.Row.FindControl("imgCancelarReproceso");
            if (IdEstadoReproceso != 1)
            {
                imgCancelarReproceso.Enabled = false;
                imgCancelarReproceso.Visible = false;
            }
            if (IdEstadoReproceso == 47 || IdEstadoReproceso == 1)
            {
                //e.Row.BackColor = System.Drawing.Color.LightGray;
                //e.Row.ForeColor = System.Drawing.Color.BlueViolet;
                e.Row.Cells[12].ForeColor = System.Drawing.Color.Black;
                e.Row.Cells[12].Font.Bold = true;
                e.Row.Cells[12].Font.Italic = true;
                //e.Row.Cells[13].BackColor = System.Drawing.Color.Black;

                //chkReproceso.Enabled = false;
                chkReproceso.BackColor = System.Drawing.Color.Goldenrod;
            }
        }
    }
    protected void chkReproceso_CheckedChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        int IdEstadoReproceso=0;

        gvFormulariosReprocesos.SelectedIndex = -1;
        pnlReprocesoRM266.Visible = false;
        pnlReproceso28888.Visible = false;
        pnlReprocesoReclamaciones.Visible = false;
        vCodigoTipoReproceso = null;

        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;

        CheckBox cbCertificadoS = (CheckBox)sender;
        if (cbCertificadoS.Checked)
        {
            foreach (GridViewRow row01 in this.gvFormulariosReprocesos.Rows)
            {
                CheckBox row01cb = (CheckBox)row01.FindControl("chkReproceso");
                if (row01cb != cbCertificadoS)
                {
                    row01cb.Checked = false;
                }
            }

            gvFormulariosReprocesos.SelectedIndex = index;
            vNroFormularioRepro = Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["NroFormularioRepro"].ToString());
            vIdTipoReproceso = Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["IdTipoReproceso"].ToString());
            vCodigoTipoReproceso = gvFormulariosReprocesos.DataKeys[index]["CodigoTipoReproceso"].ToString();
            vNumeroResolucion = gvFormulariosReprocesos.DataKeys[index]["NumeroResolucion"].ToString();
            vFechaResolucion = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["FechaResolucion"].ToString()) ? (DateTime?)null : DateTime.Parse(gvFormulariosReprocesos.DataKeys[index]["FechaResolucion"].ToString()));
            IdEstadoReproceso = Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["IdEstadoReproceso"].ToString());

            vIdTramite = Int64.Parse(gvFormulariosReprocesos.DataKeys[index]["IdTramite"].ToString());
            vIdGrupoBeneficio = Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["IdGrupoBeneficio"].ToString());
            vIdTipoTramite = Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["IdTipoTramite"].ToString());
            vNUP = Int64.Parse(gvFormulariosReprocesos.DataKeys[index]["NUP"].ToString());
            vNoFormularioCalculo = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["NoFormularioCalculo"].ToString()) ? 0 : Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["NoFormularioCalculo"].ToString()));
            vIdTipoFormularioCalculo = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["IdTipoFormularioCalculo"].ToString()) ? 0 : Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["IdTipoFormularioCalculo"].ToString()));
            //vNroCertificado = Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["NroCertificado"].ToString());
            vNroCertificado = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["NroCertificado"].ToString()) ? 0 : Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["NroCertificado"].ToString()));
            vNroCertificadoNuevo = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["NroCertificadoNuevo"].ToString()) ? 0 : Int32.Parse(gvFormulariosReprocesos.DataKeys[index]["NroCertificadoNuevo"].ToString()));
            //vRegistroAPS = Boolean.Parse(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS"].ToString());
            vRegistroAPS = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS"].ToString()) ? false : Boolean.Parse(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS"].ToString()));
            vRegistroAPS_Baja = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS_Baja"].ToString()) ? false : Boolean.Parse(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS_Baja"].ToString()));
            vRegistroAPS_Alta = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS_Alta"].ToString()) ? false : Boolean.Parse(gvFormulariosReprocesos.DataKeys[index]["RegistroAPS_Alta"].ToString()));
            vCertificadoAnulado = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["CertificadoAnulado"].ToString()) ? false : Boolean.Parse(gvFormulariosReprocesos.DataKeys[index]["CertificadoAnulado"].ToString()));
            vMontoCCAceptado = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["MontoCCAceptado"].ToString()) ? 0 : Decimal.Parse(gvFormulariosReprocesos.DataKeys[index]["MontoCCAceptado"].ToString()));
            vMontoCCAceptadoNuevo = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["MontoCCAceptadoNuevo"].ToString()) ? 0 : Decimal.Parse(gvFormulariosReprocesos.DataKeys[index]["MontoCCAceptadoNuevo"].ToString()));
            //FechaNacimientoNueva
            vFechaNacimientoNueva = (String.IsNullOrEmpty(gvFormulariosReprocesos.DataKeys[index]["FechaNacimientoNueva"].ToString()) ? (DateTime?)null : DateTime.Parse(gvFormulariosReprocesos.DataKeys[index]["FechaNacimientoNueva"].ToString()));
            string FechaNacimiento = String.Format("{0:dd/MM/yyyy}", gvFormulariosReprocesos.DataKeys[index]["FechaNacimiento"]);

            //Impresión de Certificados
            DataTable dtImpresionCertificados = new DataTable();
            objReprocesoCC.iIdConexion = IdConexion;
            objReprocesoCC.iIdTramite = vIdTramite;
            objReprocesoCC.iIdGrupoBeneficio = vIdGrupoBeneficio;
            dtImpresionCertificados = objReprocesoCC.ImprimeCertificados();
            if (dtImpresionCertificados.Rows.Count > 0)
            {
                vNroCertificadoNuevo = -99; 
            }

            //Carga Detalle
            pnlFormReprocesoDatos.Visible = true;
            objReprocesoCC.iIdConexion = IdConexion;
            objReprocesoCC.iNroFormularioRepro = vNroFormularioRepro;
            if (objReprocesoCC.ObtieneFormReproDetalle())
            {
                fvFormReprocesoDatos.DataSource = objReprocesoCC.DSet.Tables[0];
            }
            else
            {
                //Error
                string DetalleError = objReprocesoCC.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);
            }
            fvFormReprocesoDatos.DataBind();

            lblMsgRegistroAPS_Baja.Visible = false;
            lblMsgRegistroAPS_Alta.Visible = false;
            lblMsgReclamacionesEnProceso.Visible = false;
            imgRM266BajaAPS.Visible = false;
            lblBajaAPS.Visible = false;
            pnlRM266NuevaFechaNacimiento.Visible = false;
            imgRM266AnulaCertificadoAPS.Visible = false;
            lblRM266AnulaCertificadoAPS.Visible = false;
            imgCambiarFechaNacimiento.Visible = false;
            lblCambiarFechaNacimiento.Visible = false;
            imgRM266Certificado.Visible = false;
            lblRM266Certificado.Visible = false;
            txtFechaNacimientoNueva.Text = FechaNacimiento;

            lblMsg28888RegistroAPS_Baja.Visible = false;
            lblMsg28888RegistroAPS_Alta.Visible = false;
            lblMsg28888EnProceso.Visible = false;
            img28888BajaAPS.Visible = false;
            lbl28888BajaAPS.Visible = false;
            img28888HabilitaReproceso.Visible = false;
            lbl28888HabilitaReproceso.Visible = false;
            img28888Certificado.Visible = false;
            lbl28888Certificado.Visible = false;
            pnlImprimeCertificado28888.Visible = false;

            lblMsgReclamacionesRegistroAPS_Baja.Visible = false;
            lblMsgReclamacionesRegistroAPS_Alta.Visible = false;
            imgReclamacionesBajaAPS.Visible = false;
            lblReclamacionesBajaAPS.Visible = false;
            imgReclamacionesHabilitaReproceso.Visible = false;
            lblReclamacionesHabilitaReproceso.Visible = false;
            imgReclamacionesCertificado.Visible = false;
            lblReclamacionesCertificado.Visible = false;

            //--Tipo de Reproceso:
            //--C	REC. RECLAMACION
            //--D	D.S. 28888(24 APORTES)
            //--E	D.S. 28888(ERRORES) - D.S.0822
            //--L	D.S. 29194 (RECALCULO)
            //--M	D.S. 29194(CAMB. BENEF)
            //--O	REPROCESO
            //--R	R.M. 266
            //--U	CAMBIO BENEFICIO PU A CC
            //--X	R.M. 752

            int caseSwitch = 25;
            switch (vCodigoTipoReproceso)
            {
                case "R":
                    //RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266
                    //20: RegistroAPS=1,RegistroAPS_Baja=0
                    if (vRegistroAPS && !vRegistroAPS_Baja) caseSwitch = 20;
                    //21: RegistroAPS=1,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=0
                    if (vRegistroAPS && vRegistroAPS_Baja && vNroCertificado > 0 && !vCertificadoAnulado) caseSwitch = 21;
                    //21: RegistroAPS=0,NroCertificado>0,CertificadoAnulado=0
                    if (!vRegistroAPS && vNroCertificado > 0 && !vCertificadoAnulado) caseSwitch = 21;
                    //22: NroCertificado>0,CertificadoAnulado=1,MontoCCNuevo=NULL
                    if (vNroCertificado > 0 && vCertificadoAnulado && vMontoCCAceptadoNuevo == 0 && vFechaNacimientoNueva == null) caseSwitch = 22;
                    //23: NroCertificado>0,CertificadoAnulado=1,MontoCCNuevo<MontoCC,NroCertificadoNuevo=NULL
                    if (vNroCertificado > 0 && vCertificadoAnulado && vFechaNacimientoNueva != null && vNroCertificadoNuevo == 0) caseSwitch = 23;
                    //24: NroCertificado>0,CertificadoAnulado=1,MontoCCNuevo>MontoCC,NroCertificadoNuevo=NULL
                    if (vNroCertificado > 0 && vCertificadoAnulado && vMontoCCAceptadoNuevo != 0 && vFechaNacimientoNueva != null && vMontoCCAceptadoNuevo > vMontoCCAceptado && vNroCertificadoNuevo == 0) caseSwitch = 24;
                    //25: RegistroAPS=0,NroCertificado>0,NroCertificadoNuevo>0
                    if (!vRegistroAPS && vNroCertificado > 0 && vNroCertificadoNuevo > 0) caseSwitch = 25;
                    //26: RegistroAPS=1,RegistroAPS_Alta=0,NroCertificadoNuevo>0
                    if (vRegistroAPS && !vRegistroAPS_Alta && vNroCertificado > 0 && vNroCertificadoNuevo > 0) caseSwitch = 26;
                    //25: RegistroAPS=1,RegistroAPS_Alta=0,NroCertificadoNuevo>0
                    if (vRegistroAPS && vRegistroAPS_Alta && vNroCertificado > 0 && vNroCertificadoNuevo > 0) caseSwitch = 25;
                    break;
                case "E":
                    //DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888
                    //40: RegistroAPS=1,RegistroAPS_Baja=0
                    if (vRegistroAPS && !vRegistroAPS_Baja) caseSwitch = 40;
                    //41: RegistroAPS=0,NroCertificado>0,CertificadoAnulado=0
                    if (!vRegistroAPS && vNroCertificado > 0 && !vCertificadoAnulado) caseSwitch = 41;
                    //41: RegistroAPS=1,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=0
                    if (vRegistroAPS && vRegistroAPS_Baja && vNroCertificado > 0 && !vCertificadoAnulado) caseSwitch = 41;
                    //42: RegistroAPS=1,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=1
                    if (vRegistroAPS && vRegistroAPS_Baja && vNroCertificado > 0 && vCertificadoAnulado) caseSwitch = 42;
                    //42: RegistroAPS=0,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=1
                    if (!vRegistroAPS && vNroCertificado > 0 && vCertificadoAnulado) caseSwitch = 42;
                    //45: RegistroAPS=0,NroCertificado>0,NroCertificadoNuevo>0
                    if (!vRegistroAPS && vNroCertificado > 0 && vNroCertificadoNuevo > 0) caseSwitch = 45;
                    //46: RegistroAPS=1,RegistroAPS_Alta=0,NroCertificadoNuevo>0
                    if (vRegistroAPS && !vRegistroAPS_Alta && vNroCertificadoNuevo > 0) caseSwitch = 46;
                    if (vNroCertificadoNuevo == -99) caseSwitch = 47;
                    break;
                case "C":
                    //RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES
                    //30: RegistroAPS=1,RegistroAPS_Baja=0
                    if (vRegistroAPS && !vRegistroAPS_Baja) caseSwitch = 30;
                    //31: RegistroAPS=0,NroCertificado>0,CertificadoAnulado=0
                    if (!vRegistroAPS && vNroCertificado > 0 && !vCertificadoAnulado) caseSwitch = 31;
                    //31: RegistroAPS=1,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=0
                    if (vRegistroAPS && vRegistroAPS_Baja && vNroCertificado > 0 && !vCertificadoAnulado) caseSwitch = 31;
                    //32: RegistroAPS=1,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=1
                    if (vRegistroAPS && vRegistroAPS_Baja && vNroCertificado > 0 && vCertificadoAnulado) caseSwitch = 32;
                    //32: RegistroAPS=0,RegistroAPS_Baja=1,NroCertificado>0,CertificadoAnulado=1
                    if (!vRegistroAPS && vNroCertificado > 0 && vCertificadoAnulado) caseSwitch = 32;
                    //35: RegistroAPS=0,NroCertificado>0,NroCertificadoNuevo>0
                    if (!vRegistroAPS && vNroCertificado > 0 && vNroCertificadoNuevo > 0) caseSwitch = 35;
                    //36: RegistroAPS=1,RegistroAPS_Alta=0,NroCertificadoNuevo>0
                    if (vRegistroAPS && !vRegistroAPS_Alta && vNroCertificadoNuevo > 0) caseSwitch = 36;
                    if (vNroCertificadoNuevo == -99) caseSwitch = 37;
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }

            //caseSwitch = 47;
            switch (caseSwitch)
            {
                //RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266-RM266
                case 20: //RegistroAPS Baja de Certificado
                    lblMsgRegistroAPS_Baja.Visible = true;
                    imgRM266BajaAPS.Visible = true;
                    lblBajaAPS.Visible = true;
                    break;
                case 21: //Anula Certificado
                    imgRM266AnulaCertificadoAPS.Visible = true;
                    lblRM266AnulaCertificadoAPS.Visible = true;
                    break;
                case 22: //Cambia Fecha de Nacimiento
                    imgCambiarFechaNacimiento.Visible = true;
                    lblCambiarFechaNacimiento.Visible = true;
                    txtMatriculaNueva.Text = "";
                    break;
                case 23: //Genera e Imprime Certificado
                    imgRM266Certificado.Visible = true;
                    lblRM266Certificado.Visible = true;
                    break;
                case 24: //Renuncia
                    imgRM266Certificado.Visible = true;
                    lblRM266Certificado.Visible = true;
                    break;
                case 25: //Ver Certificado
                    break;
                case 26: //Ver Certificado, precisa Alta de Certificado en APS
                    lblMsgRegistroAPS_Alta.Visible = true;
                    break;
                //RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES-RECLAMACIONES
                case 30: //Baja APS
                    lblMsgReclamacionesRegistroAPS_Baja.Visible = true;
                    imgReclamacionesBajaAPS.Visible = true;
                    lblReclamacionesBajaAPS.Visible = true;
                    break;
                case 31: //Habilita Reproceso
                    imgReclamacionesHabilitaReproceso.Visible = true;
                    lblReclamacionesHabilitaReproceso.Visible = true;
                    break;
                case 32: //Reproceso RECLAMACIONES en proceso...
                    lblMsgReclamacionesEnProceso.Visible = true;
                    break;
                case 35: //Ver Certificado
                    break;
                case 36: //Ver Certificado, Registrar Alta APS
                    lblMsgReclamacionesRegistroAPS_Alta.Visible = true;
                    break;
                case 37: //Imprime Certificado REPROCESADO
                    pnlImprimeCertificado28888.Visible = true;
                    imgReclamacionesCertificado.Visible = false;
                    lblReclamacionesCertificado.Visible = false;
                    break;

                //DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888-DS28888
                case 40: //Baja APS
                    img28888BajaAPS.Visible = true;
                    lbl28888BajaAPS.Visible = true;
                    break;
                case 41: //Habilita Reproceso
                    img28888HabilitaReproceso.Visible = true;
                    lbl28888HabilitaReproceso.Visible = true;
                    break;
                case 42: //Reproceso 28888 en proceso...
                    lblMsg28888EnProceso.Visible = true;
                    break;
                case 45: //Ver Certificado
                    break;
                case 46: //Ver Certificado, Registrar Alta APS
                    lblMsg28888RegistroAPS_Alta.Visible = true;
                    break;
                case 47: //Imprime Certificado REPROCESADO
                    img28888Certificado.Visible = true;
                    lbl28888Certificado.Visible = true;
                    pnlImprimeCertificado28888.Visible = true;
                    gvGImpCertificados.DataSource = dtImpresionCertificados;
                    gvGImpCertificados.DataBind();
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }
        }
        else
        {
            pnlFormReprocesoDatos.Visible = false;
        }

        switch (vCodigoTipoReproceso)
        {
            case "R": // R.M. 266
                pnlReprocesoRM266.Visible = true;
                break;
            case "E": // D.S. 28888(ERRORES) - D.S.0822
                pnlReproceso28888.Visible = true;
                break;
            case "C": // RECLAMACIONES
                pnlReprocesoReclamaciones.Visible = true;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }

        if (IdEstadoReproceso == 50)
        {
            pnlReprocesoRM266.Visible = false;
            pnlReproceso28888.Visible = false;
            pnlReprocesoReclamaciones.Visible = false;
        }
    }
    protected void imgImprimeFormularioReproceso_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgImprimeCertificado = sender as ImageButton;
        GridViewRow gRow = (GridViewRow)imgImprimeCertificado.NamingContainer;
        //string s0 = gvCertificados.DataKeys[gRow.RowIndex].Value.ToString();
        Session["NroFormularioRepro"] = gvFormulariosReprocesos.DataKeys[gRow.RowIndex]["NroFormularioRepro"];
        Session["NUP"] = gvFormulariosReprocesos.DataKeys[gRow.RowIndex]["NUP"];
        Session["IdTramite"] = gvFormulariosReprocesos.DataKeys[gRow.RowIndex]["IdTramite"];
        Session["IdTipoTramite"] = gvFormulariosReprocesos.DataKeys[gRow.RowIndex]["IdTipoTramite"];
        Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;

        vCodigoTipoReproceso = gvFormulariosReprocesos.DataKeys[gRow.RowIndex]["CodigoTipoReproceso"].ToString();

        //--Tipo de Reproceso:
        //--C	REC. RECLAMACION
        //--D	D.S. 28888(24 APORTES)
        //--E	D.S. 28888(ERRORES) - D.S.0822
        //--L	D.S. 29194 (RECALCULO)
        //--M	D.S. 29194(CAMB. BENEF)
        //--O	REPROCESO
        //--R	R.M. 266
        //--U	CAMBIO BENEFICIO PU A CC
        //--X	R.M. 752
        switch (vCodigoTipoReproceso)
        {
            case "R": // R.M. 266
                //Response.Redirect("wfrmRptRM266FormularioReproceso.aspx");
                Response.Redirect("wfrmRptFormularioReprocesoRM266svr.aspx");
                break;
            default:
                Response.Redirect("wfrmRptFormularioReprocesoSvr.aspx");
                //Response.Redirect("wfrmRptFormularioReproceso.aspx");
                break;
        }
    }
    protected void imgImprimeCertificado28888_Click(object sender, ImageClickEventArgs e)
    {
        pnlImprimeCertificado28888.Visible = false;

        Session["NroFormularioRepro"] = vNroFormularioRepro;
        Session["RegistroAPS"] = vRegistroAPS;
        Session["IdTramite"] = vIdTramite;
        Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
        Session["NroCertificado"] = vNroCertificado;
        Session["IdTipoTramite"] = vIdTipoTramite;
        Session["IdTipoReproceso"] = vIdTipoReproceso;
        
        //Formulario de Cálculo elegido
        ImageButton imgImprimeCertificado = sender as ImageButton;
        GridViewRow gRow = (GridViewRow)imgImprimeCertificado.NamingContainer;
        int NoFormularioCalculo = Int32.Parse(gvGImpCertificados.DataKeys[gRow.RowIndex]["NoFormularioCalculo"].ToString());
        
        Session["NoFormularioCalculo"] = NoFormularioCalculo;

        Response.Redirect("~/Reportes/wfrmReporteCertificadoCCReproceso.aspx");        
    }
    protected void imgRM266BajaAPS_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~/EnvioAPS/wfrmRegistroDeBajas.aspx");
    }
    protected void imgRM266CambiarFechaNacimiento_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        pnlRM266NuevaFechaNacimiento.Visible = true;
        lblMsgMatriculaNueva.Visible = false;
    }
    protected void imgRM266Certificado_Click(object sender, ImageClickEventArgs e)
    {
        pnlRM266NuevaFechaNacimiento.Visible = false;

        Session["NroFormularioRepro"] = vNroFormularioRepro;
        Session["RegistroAPS"] = vRegistroAPS;
        Session["IdTramite"] = vIdTramite;
        Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
        Session["NroCertificado"] = vNroCertificado;
        Session["IdTipoTramite"] = vIdTipoTramite;
        Session["IdTipoReproceso"] = vIdTipoReproceso;

        //Formulario de Cálculo elegido
        Session["NoFormularioCalculo"] = vNoFormularioCalculo;

        Response.Redirect("~/Reportes/wfrmReporteCertificadoCCReproceso.aspx");
    }
    protected void imgRM266AnulaCertificado_Click(object sender, ImageClickEventArgs e)
    {
        objRM266.iIdConexion = IdConexion;
        objRM266.iNroCertificado = vNroCertificado;
        objRM266.iIdTipoTramite = vIdTipoTramite;
        objRM266.iNroFormularioRepro = vNroFormularioRepro;
        if (objRM266.AnulaCertificado())
        {
            Master.MensajeOk("Se Anuló Certificado! Si está Registrado en la APS se producirá su Baja en el siguiente envío.");
        }
        else
        {
            //Error
            string DetalleError = objRM266.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        string Mensaje = "Se anuló exitosamente el Certificado!<br/>";
        Mensaje += "<ul>";
        Mensaje += "<li>Reproceso cambia de estado, pasa de Registrado a Iniciado.</li>";
        Mensaje += "<li>Certificado en estado Anulado por Reproceso.</li>";
        Mensaje += "</ul><br/>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('"+Mensaje+"');", true);
        //Response.Redirect("wfrmReprocesos.aspx");

        pnlReprocesoRM266.Visible = false;
        CargaFormularioReprocesos(vIdTramite);
    }
    protected void img28888BajaAPS_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~/EnvioAPS/wfrmRegistroDeBajas.aspx");
    }
    protected void imgReclamacionesBajaAPS_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~/EnvioAPS/wfrmRegistroDeBajas.aspx");
    }
    protected void btnRM266CambiaFechaNacimiento_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid && !String.IsNullOrEmpty(txtMatriculaNueva.Text))
        {
            DateTime FechaNacimientoNueva = DateTime.Parse(txtFechaNacimientoNueva.Text);

            objRM266.iIdConexion = IdConexion;

            objRM266.iNoFormularioCalculo = vNoFormularioCalculo;
            objRM266.iIdTipoFormularioCalculo = vIdTipoFormularioCalculo;
            objRM266.iNroCertificado = vNroCertificado;

            objRM266.iNumeroResolucion = vNumeroResolucion;
            objRM266.fFechaResolucion = vFechaResolucion;
            objRM266.fFechaNacimientoNueva = FechaNacimientoNueva;
            objRM266.sMatriculaNueva = txtMatriculaNueva.Text;
            objRM266.iNroFormularioRepro = vNroFormularioRepro;
            if (objRM266.ModificaFechaNacimiento())
            {
                Master.MensajeOk("EXITO! Nueva Fecha de Nacimiento actualizada.");
                CargaFormularioReprocesos(vIdTramite); 
            }
            else
            {
                //Error
                string DetalleError = objRM266.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }

            string Mensaje = "Se actualizó exitosamente la nueva Fecha de Nacimiento!<br/>";
            Mensaje += "<ul>";
            Mensaje += "<li>El módulo Novedades registró el cambio, que puede verificarse en el Formulario Novedades RM266.</li>";
            Mensaje += "<li>Mediante Novedades, se actualizó la Tabla Persona.Persona, tanto la Fecha de Nacimiento como la nueva Matrícula.</li>";
            Mensaje += "<li>Mediante Novedades, Se actualizó la Tabla Referencial.PERSONA_CC, solamente la Fecha de Nacimiento.</li>";
            Mensaje += "</ul><br/>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + Mensaje + "');", true);

            pnlReprocesoRM266.Visible = false;
            CargaFormularioReprocesos(vIdTramite);
        }
        else
        {
            lblMsgMatriculaNueva.Visible = true;
        }
    }
    protected void img28888HabilitaReproceso_Click(object sender, ImageClickEventArgs e)
    {
        //Habilita Reproceso, copiando SalarioCotizable y ActualizacionCC en una nueva versión y con estado 42=REPROCESO
        objDS28888.iIdConexion = IdConexion;
        objDS28888.iIdTramite = vIdTramite;
        objDS28888.iIdGrupoBeneficio = vIdGrupoBeneficio;
        objDS28888.iNroCertificado = vNroCertificado;
        objDS28888.iIdTipoTramite = vIdTipoTramite;
        objDS28888.iIdUsuario = vIdUsuario;
        objDS28888.iNroFormularioRepro = vNroFormularioRepro;
        if (objDS28888.HabilitaCertificacion())
        {
            Master.MensajeOk("EXITO! Se cambiaron los estados de SalarioCotizable!.");
        }
        else
        {
            //Error
            string DetalleError = objDS28888.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        string Mensaje = "Se habilitó exitosamente las tablas para el Reproceso DS28888!<br/>";
        Mensaje += "<ul>";
        Mensaje += "<li>Cambian los estados de SalarioCotizable y FormularioCalculoCC.</li>";
        Mensaje += "<li>Certificado en estado Anulado por Reproceso.</li>";
        Mensaje += "</ul><br/>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + Mensaje + "');", true);

        CargaFormularioReprocesos(vIdTramite);
    }
    protected void imgReclamacionesHabilitaReproceso_Click(object sender, ImageClickEventArgs e)
    {
        //Habilita Reproceso, copiando SalarioCotizable y ActualizacionCC en una nueva versión y con estado 42=REPROCESO
        //Session["NroFormularioRepro"] = vNroFormularioRepro;
        //Session["RegistroAPS"] = vRegistroAPS;
        //Session["IdTramite"] = vIdTramite;
        //Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
        //Session["NroCertificado"] = vNroCertificado;
        //Session["IdTipoTramite"] = vIdTipoTramite;
        //Response.Redirect("wfrmDS288HabilitaReproceso.aspx");

        objRECLAMACIONES.iIdConexion = IdConexion;
        objRECLAMACIONES.iIdTramite = vIdTramite;
        objRECLAMACIONES.iIdGrupoBeneficio = vIdGrupoBeneficio;
        objRECLAMACIONES.iNroCertificado = vNroCertificado;
        objRECLAMACIONES.iIdTipoTramite = vIdTipoTramite;
        objRECLAMACIONES.iIdUsuario = vIdUsuario;
        objRECLAMACIONES.iNroFormularioRepro = vNroFormularioRepro;
        if (objRECLAMACIONES.HabilitaCertificacion())
        {
            Master.MensajeOk("EXITO! Se cambiaron los estados de SalarioCotizable!.");
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        string Mensaje = "Se habilitó exitosamente las tablas para el Reproceso RECLAMACIONES!<br/>";
        Mensaje += "<ul>";
        Mensaje += "<li>Cambian los estados de SalarioCotizable y FormularioCalculoCC.</li>";
        Mensaje += "<li>Certificado en estado Anulado por Reproceso.</li>";
        Mensaje += "</ul><br/>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + Mensaje + "');", true);

        imgReclamacionesHabilitaReproceso.EnableViewState = false;
        lblReclamacionesHabilitaReproceso.EnableViewState = false;
        CargaFormularioReprocesos(vIdTramite);
    }
    #region Genera Matricula
    protected void btnGenerarMatricula_Click(object sender, EventArgs e)
    {
        //Datos Afiliado
        DataTable dtDatosPersona = new DataTable();
        objRM266.iIdConexion = IdConexion;
        objRM266.iIdTramite = vIdTramite;
        objRM266.iIdGrupoBeneficio = vIdGrupoBeneficio;
        if (objRM266.ObtieneDatosPersona())
        {
            dtDatosPersona = objRM266.DSet.Tables[0];
            string PrimerApellido = dtDatosPersona.Rows[0]["PrimerApellido"].ToString();
            string SegundoApellido = dtDatosPersona.Rows[0]["SegundoApellido"].ToString();
            string PrimerNombre = dtDatosPersona.Rows[0]["PrimerNombre"].ToString();
            string Sexo = dtDatosPersona.Rows[0]["Sexo"].ToString();
            txtMatriculaNueva.Text = GenerarMatricula(PrimerApellido, SegundoApellido, PrimerNombre, (new clsFormatoFecha()).GeneraFechaDMY(txtFechaNacimientoNueva.Text), Sexo);
        }
        else
        {
            //Error
            string DetalleError = objRM266.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }        
        btnCambiaFechaNacimiento.Focus();
    }
    public string GenerarMatricula(string pat, string mat, string nombre, DateTime fnac, string sex)
    {
        string result = "";
        string mat_new;
        try
        {
            string ip = "";
            string im = "";
            string ino = "";
            int tsexo;
            int a, d, m;
            string a1, d1, m1;

            if (pat == "NULL" || pat.Trim() == "")
            {
                pat = "";
            }
            else
            {
                pat = pat.Trim();
                ip = pat.Substring(0, 1);
            }

            if (mat == "NULL" || mat.Trim() == "")
            {
                mat = "";
            }
            else
            {
                mat = mat.Trim();
                im = mat.Substring(0, 1);
            }

            if (nombre == "NULL" || nombre.Trim() == "")
            {
                nombre = "";
            }
            else
            {
                nombre = nombre.Trim();
                ino = nombre.Substring(0, 1);
            }

            if (ip == "" && im != "")
            {
                if (mat.Length > 1)
                {
                    im = mat.Substring(0, 2);
                }
            }
            if (im == "" && ip != "")
            {
                if (pat.Length > 1)
                {
                    ip = pat.Substring(0, 2);
                }
            }

            tsexo = 0;

            if (sex == "1" || sex == "F")
            {
                tsexo = 50;
            }

            a = fnac.Year;
            m = fnac.Month;
            d = fnac.Day;
            m = m + tsexo;

            a1 = a.ToString().Substring(2, 2);
            if (m < 10)
            {
                m1 = "0" + m;
            }
            else
            {
                m1 = m.ToString();
            }

            if (d < 10)
            {
                d1 = "0" + d;
            }
            else
            {
                d1 = d.ToString();
            }

            mat_new = a1 + m1 + d1 + ip + im + ino;
            result = mat_new.ToUpper();
        }
        catch (Exception ex)
        {
            result = "";
            System.Console.Write(ex.Message);
        }
        return result;
    }
    #endregion
    #region HistorialTramite Popup
    private void CargarGrillaHistorialTramite(string sIdTramite)
    {
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.sIdTramite = sIdTramite;
        if (objBandejaUsuario.HistorialTramite())
        {
            var dt = objBandejaUsuario.DSet.Tables[0];
            gvBusqMaestro.DataSource = dt;
            gvBusqMaestro.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla la busqueda", objBandejaUsuario.sMensajeError);
            gvBusqMaestro.DataSource = null;
            gvBusqMaestro.DataBind();
        }
    }
    #endregion
}