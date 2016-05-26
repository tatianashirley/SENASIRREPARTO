using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_wfrmPreRenunciaAutomatica : System.Web.UI.Page
{
    #region contantes

    private const int CC = 3;
    private const string RENUNCIA_AUTOMATICA = "A";
    private const string RENUNCIA_INICIO_MANUAL = "I";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string sTipo = Request.QueryString["Tipo"];
            hddTipo.Value = sTipo;
            if (RENUNCIA_AUTOMATICA.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO RENUNCIA AUTOMÁTICA";
            }
            else if (RENUNCIA_INICIO_MANUAL.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO RENUNCIA INICIO MANUAL";
            }
            lblSubTitulo.Text = "Buscar Trámite";
            pnlRegistrosCabecera.Visible = false;
            this.CargarTipoRenuncia();
            //deshabilitar el Autocompletar
            txtCuaBuscar.Attributes.Add("autocomplete", "off");
            txtMaternoBuscar.Attributes.Add("autocomplete", "off");
            txtMatriculaBuscar.Attributes.Add("autocomplete", "off");
            txtNumDocBuscar.Attributes.Add("autocomplete", "off");
            txtNumTramiteBuscar.Attributes.Add("autocomplete", "off");
            txtPaternoBuscar.Attributes.Add("autocomplete", "off");
            txtPrimerNormbreBuscar.Attributes.Add("autocomplete", "off");
            txtSegundoNombreBuscar.Attributes.Add("autocomplete", "off");
        }
    }

    #endregion

    #region botones

    //Boton buscar tramite
    protected void imgbtnBuscar_Click(object sender, EventArgs e)
    {
        if (Validacion())
        {
            BuscarTramite();
        }
    }

    //Boton limpiar busqueda
    protected void imgbtnBorrar_Click(object sender, EventArgs e)
    {
        this.txtPrimerNormbreBuscar.Text = "";
        this.txtSegundoNombreBuscar.Text = "";
        this.txtPaternoBuscar.Text = "";
        this.txtMaternoBuscar.Text = "";
        this.txtNumDocBuscar.Text = "";
        this.txtMatriculaBuscar.Text = "";
        this.txtCuaBuscar.Text = "";
        this.txtNumTramiteBuscar.Text = "";
        //this.rbtTramitesAutomatico.Checked = false;
        this.ddlTipoRenuncia.SelectedIndex = 0;
        this.rbtPreIniciados.Checked = false;
        this.rbtRenunciados.Checked = false;
        this.pnlRegistrosCabecera.Visible = false;
        this.txtPaternoBuscar.Focus();
    }

    #endregion

    #region funciones

    // Validar de datos de entrada
    protected bool Validacion()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        //Validar algun dato
        if (String.IsNullOrEmpty(this.txtPaternoBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtMaternoBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtPrimerNormbreBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtSegundoNombreBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtNumDocBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtCuaBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtNumTramiteBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtMatriculaBuscar.Text.Trim()))
        {
            sDetalleError = "Debe ingresar un criterio de búsqueda.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    //Combo tipo renuncia
    private void CargarTipoRenuncia()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtTipoRenuncia = new DataTable();
        dtTipoRenuncia = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "TipoRenuncia", ref sMensajeError);
        if (dtTipoRenuncia != null && dtTipoRenuncia.Rows.Count > 0)
        {
            ddlTipoRenuncia.DataSource = dtTipoRenuncia;
            ddlTipoRenuncia.DataTextField = "Tipo";
            ddlTipoRenuncia.DataValueField = "idTipo";
            ddlTipoRenuncia.DataBind();
            ddlTipoRenuncia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlTipoRenuncia.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Buscar Tramite
    private void BuscarTramite()
    {
        string sTipo = "";
        string Error;
        string DetalleError;
        DataTable dtTramites = new DataTable();
        Error = "Error al realizar la operación";
        try
        {
            if (ddlTipoRenuncia.SelectedValue.ToString() == "0")
            {
                DetalleError = "El Tipo Renuncia es requerido.";
                Master.MensajeError(Error, DetalleError);
                return;
            }
            /*if (rbtTramitesAutomatico.Checked)
            {
                sTipo = "Inicial";
            }
            else*/
            if (rbtPreIniciados.Checked)
            {
                if (RENUNCIA_AUTOMATICA.Equals(hddTipo.Value))
                {
                    sTipo = "PreRenunciaA";
                } else {
                    sTipo = "PreRenunciaI";
                }                
            }
            else if (rbtRenunciados.Checked)
            {
                sTipo = "Renuncia";
            }
            else
            {
                DetalleError = "Debe elegir el tipo de busqueda";
                Master.MensajeError(Error, DetalleError);
                return;
            }
            dtTramites = buscarTramitesRenuncia(sTipo);
            gvBusquedaTramiteCC.DataSource = dtTramites;
            gvBusquedaTramiteCC.DataBind();
            pnlRegistrosCabecera.Visible = true;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        catch (Exception ex)
        {
            DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Buscar Tramites
    protected DataTable buscarTramitesRenuncia(string estadotramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string iIdTramite = "0";
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();
        if (!String.IsNullOrEmpty(txtNumTramiteBuscar.Text.Trim()))
        {
            iIdTramite = txtNumTramiteBuscar.Text.Trim();
        }
        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, Int16.Parse(this.ddlTipoRenuncia.SelectedValue), this.txtPrimerNormbreBuscar.Text.Trim(), this.txtSegundoNombreBuscar.Text.Trim(), this.txtPaternoBuscar.Text.Trim(), this.txtMaternoBuscar.Text.Trim(), txtNumDocBuscar.Text.Trim(), txtCuaBuscar.Text.Trim(), this.txtMatriculaBuscar.Text.Trim(), estadotramite, ref sMensajeError);

        return dtListaPersonas;
    }

    #endregion

    #region grilla

    protected void gvBusquedaTramiteCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        string contentUrl;
        string sPaginaDestino;
        string sIdTramite;
        string sIdGrupoBeneficio;
        string sTabla;
        string sOrigen;
        if (e.CommandName.Equals("cmdTramite"))
        {
            sTabla = "";
            sOrigen = "Menu";
            Index = Convert.ToInt32(e.CommandArgument);
            sIdTramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            sIdGrupoBeneficio = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdGrupoBeneficio"]);
            if (RENUNCIA_INICIO_MANUAL.Equals(hddTipo.Value))
            {
                sTabla = "0";//renuncia inicio manual
            }
            else
            {
                sTabla = "1";//renuncia automatica
            }
            sPaginaDestino = "wfrmCompletarDatosRenuncia.aspx";
            contentUrl = string.Format(sPaginaDestino + "?Origen={0}&Tipo={1}&iIdTramite={2}&iIdGrupoBeneficio={3}", sOrigen, sTabla, sIdTramite, sIdGrupoBeneficio);
            Response.Redirect(contentUrl);
        }
    }

    protected void gvBusquedaTramiteCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");

            /*if (rbtTramitesAutomatico.Checked)
            {
                btnTramite.Visible = true;
                btnBloqueo.Visible = false;
            }*/
            if (rbtPreIniciados.Checked)
            {
                btnTramite.Visible = true;
                btnBloqueo.Visible = false;
            }
            if (rbtRenunciados.Checked)
            {
                btnTramite.Visible = false;
                btnBloqueo.Visible = true;
            }
        }
    }

    protected void gvBusquedaTramiteCC_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvBusquedaTramiteCC = (GridView)sender;
        gvBusquedaTramiteCC.PageIndex = e.NewSelectedIndex;
        gvBusquedaTramiteCC.DataBind();
    }

    protected void gvBusquedaTramiteCC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusquedaTramiteCC.PageIndex = e.NewPageIndex;
        BuscarTramite();
    }

    #endregion

}