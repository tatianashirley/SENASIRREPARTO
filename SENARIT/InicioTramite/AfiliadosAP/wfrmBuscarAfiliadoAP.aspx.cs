using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;

public partial class InicioTramite_wfrmBuscarAfiliadoAP : System.Web.UI.Page
{
    #region constantes

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string sTipo;
        if (!Page.IsPostBack)
        {
            sTipo = Request.QueryString["Tipo"];
            hddTipo.Value = sTipo;
            lblTituloSistema.Text = "MODULO AFILIADOS AP";
            lblSubTitulo.Text = "Buscar Asegurado";
            pnlRegistrosCabecera.Visible = false;
            //deshabilitar el Autocompletar
            txtCuaBuscar.Attributes.Add("autocomplete", "off");
            txtMaternoBuscar.Attributes.Add("autocomplete", "off");
            txtNumDocBuscar.Attributes.Add("autocomplete", "off");
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
            BuscarAsegurados();
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
        this.txtCuaBuscar.Text = "";
        this.pnlRegistrosCabecera.Visible = false;
        this.txtCuaBuscar.Focus();
    }

    //Boton nuevo asegurado
    protected void imgbtnNuevo_Click(object sender, EventArgs e)
    {
        string sPaginaDestino = "wfrmAfiliadoAP.aspx";
        string contentUrl = string.Format(sPaginaDestino + "?Tipo={0}", "REG");
        Response.Redirect(contentUrl);
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
            && String.IsNullOrEmpty(this.txtCuaBuscar.Text.Trim()))
        {
            sDetalleError = "Debe ingresar un criterio de búsqueda.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    private void BuscarAsegurados()
    {
        DataTable dtTramites = new DataTable();
        try
        {
            dtTramites = buscarAfiliados("FFAA");
            gvBusquedaTramiteCC.DataSource = dtTramites;
            gvBusquedaTramiteCC.DataBind();
            pnlRegistrosCabecera.Visible = true;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Buscar Tramites
    protected DataTable buscarAfiliados(string estadotramite)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsAfiliadoAp objAfiliado = new clsAfiliadoAp();
        objAfiliado.iIdConexion = iIdConexion;
        objAfiliado.cOperacion = cOperacion;
        objAfiliado.NUA = txtCuaBuscar.Text.Trim();
        objAfiliado.NumeroIdentificacion = txtNumDocBuscar.Text.Trim();
        objAfiliado.PrimerNombre = this.txtPrimerNormbreBuscar.Text.Trim();
        objAfiliado.SegundoNombre = this.txtSegundoNombreBuscar.Text.Trim();
        objAfiliado.PrimerApellido = this.txtPaternoBuscar.Text.Trim();
        objAfiliado.SegundoApellido = this.txtMaternoBuscar.Text.Trim();
        if (objAfiliado.Buscar())
        {
            if (objAfiliado.DSetTmp != null && objAfiliado.DSetTmp.Tables.Count > 0)
            {
                dtListaPersonas = objAfiliado.DSetTmp.Tables[0];
            }
        }

        return dtListaPersonas;
    }

    #endregion

    #region grilla

    protected void gvBusquedaTramiteCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdTramite")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string queryStringCUA = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["NUA"]);
            string sPaginaDestino = "wfrmAfiliadoAP.aspx";
            string contentUrl = string.Format(sPaginaDestino + "?Tipo={0}&NUA={1}", "MOD", queryStringCUA);
            Response.Redirect(contentUrl);
        }
    }

    protected void gvBusquedaTramiteCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string sPrestacionHabilitada = Convert.ToString(gvBusquedaTramiteCC.DataKeys[e.Row.RowIndex].Values["TipoTramite"]);
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");
            btnTramite.Visible = true;
            btnBloqueo.Visible = false;
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
        BuscarAsegurados();
    }

    #endregion

}