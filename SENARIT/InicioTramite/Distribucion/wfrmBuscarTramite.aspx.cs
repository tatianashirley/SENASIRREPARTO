using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class Distribucion_wfrmBuscarTramite : System.Web.UI.Page
{
    #region constantes

    private const string TIPO_AUTOMATICO = "AUTOMATICO";
    private const string TIPO_MANUAL = "MANUAL";
    private const string CONTROL_CALIDAD = "ControlCalidad";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string sTipo;
        if (!Page.IsPostBack)
        {
            sTipo = Request.QueryString["Tipo"];
            hddTipo.Value = sTipo;
            lblTituloSistema.Text = "DISTRIBUCIÓN DE TRÁMITES";
            lblSubTitulo.Text = "Buscar Trámite";
            pnlRegistrosCabecera.Visible = false;
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
        if(Validacion()){
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
        this.pnlRegistrosCabecera.Visible = false;
        this.txtPaternoBuscar.Focus();
    }

    //Boton check control calidad
    protected void btnSiJustificar_Click(object sender, EventArgs e)
    {
        if (!rdbtCheck.Checked)
        {
            Master.MensajeError("Error al realizar la operacion", "El Check es requerido.");
        }
        else if (String.IsNullOrEmpty(txtObservacioni.Text))
        {
            Master.MensajeError("Error al realizar la operacion", "Las Observaciones son requeridas.");
        }
        else
        {
            clsControlCalidad objControl = new clsControlCalidad();
            objControl.iIdConexion = (int)Session["IdConexion"];
            objControl.cOperacion = "I";
            objControl.IdTramite = Convert.ToInt32(txtTramitei.Text);
            objControl.IdGrupoBeneficio = 3;
            objControl.IdEstado = (rdbtCheck.Checked ? 1 : 0);
            objControl.Observacion = txtObservacioni.Text;
            if (!objControl.Registrar() && !String.IsNullOrEmpty(objControl.sMensajeError))
            {
                Master.MensajeError("Error al realizar la operacion", objControl.sMensajeError);
            }
            mpControlCalidad.Hide();
            pnlJustificar.Visible = false;
        }
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

    private void BuscarTramite()
    {
        DataTable dtTramites = new DataTable();
        try
        {
            dtTramites = buscarTramitesRenuncia("ControlCalidad");
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
        else
        {
            iIdTramite = "0";
        }
        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, 3, this.txtPrimerNormbreBuscar.Text.Trim(), this.txtSegundoNombreBuscar.Text.Trim(), this.txtPaternoBuscar.Text.Trim(), this.txtMaternoBuscar.Text.Trim(), txtNumDocBuscar.Text.Trim(), txtCuaBuscar.Text.Trim(), this.txtMatriculaBuscar.Text.Trim(), estadotramite, ref sMensajeError);

        return dtListaPersonas;
    }

    #endregion

    #region grilla

    protected void gvBusquedaTramiteCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        string queryStringTramite = "";
        string sPaginaDestino = "";
        if (e.CommandName.Equals("cmdTramite"))
        {
            Index = Convert.ToInt32(e.CommandArgument);
            queryStringTramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            clsTramite ObjTramite = new clsTramite();
            ObjTramite.iIdConexion = (int)Session["IdConexion"];
            ObjTramite.cOperacion = "Q";
            ObjTramite.IdTramite = Convert.ToInt64(queryStringTramite);
            if (ObjTramite.ValidarControlEstados(ref sPaginaDestino))
            {
                if (!String.IsNullOrEmpty(sPaginaDestino))
                {
                    clsFuncionesGenerales encriptar = new clsFuncionesGenerales();
                    string encriptStringTramite = encriptar.EncryptKey(queryStringTramite);
                    string encriptStringCC = encriptar.EncryptKey(CONTROL_CALIDAD);
                    string contentUrl = string.Format(sPaginaDestino + "?TT={0}&Tipo={1}", encriptStringTramite, encriptStringCC);
                    Response.Redirect(contentUrl);
                }
            }
        }
        else if (e.CommandName.Equals("cmdCheck"))
        {
            mpControlCalidad.Show();
            pnlJustificar.Visible = true;
            rdbtCheck.Checked = false;
            txtObservacioni.Text = "";
            Index = Convert.ToInt32(e.CommandArgument);
            txtTramitei.Text = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
        }
    }

    protected void gvBusquedaTramiteCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int Index;
        string sPaginaDestino = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Index = e.Row.RowIndex;
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");
            ImageButton btnCheck = (ImageButton)e.Row.FindControl("imgCheck");
            ImageButton btnNoCheck = (ImageButton)e.Row.FindControl("imgNoCheck");

            //Consulta
            clsTramite ObjTramite = new clsTramite();
            ObjTramite.iIdConexion = (int)Session["IdConexion"];
            ObjTramite.cOperacion = "Q";
            ObjTramite.IdTramite = Convert.ToInt32(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            if (ObjTramite.ValidarControlEstados(ref sPaginaDestino))
            {
                if (!String.IsNullOrEmpty(sPaginaDestino))
                {
                    btnTramite.Visible = true;
                    btnBloqueo.Visible = false;
                }
                else
                {
                    btnTramite.Visible = false;
                    btnBloqueo.Visible = true;
                }
            }
            else
            {
                btnTramite.Visible = false;
                btnBloqueo.Visible = true;
            }

            //Control calidad
            clsControlCalidad objControl = new clsControlCalidad();
            objControl.iIdConexion = (int)Session["IdConexion"];
            objControl.cOperacion = "V";
            objControl.IdTramite = Convert.ToInt32(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            objControl.IdGrupoBeneficio = 3;

            if (objControl.Obtener())
            {
                if (objControl.IdEstado == 1)
                {
                    btnCheck.Visible = false;
                    btnNoCheck.Visible = true;
                }
                else
                {
                    btnCheck.Visible = true;
                    btnNoCheck.Visible = false;
                }
            }
            else
            {
                btnCheck.Visible = false;
                btnNoCheck.Visible = true;
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