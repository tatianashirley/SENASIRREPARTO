using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_wfrmModificacionTramite : System.Web.UI.Page
{
    #region constantes

    private const string MOD_DATOS_PERSONALES = "MP";
    private const string MOD_FECHAS = "MF";
    private const string MOD_SALARIO = "MS";
    private const string MOD_EMPRESAS = "ME";
    private const string MOD_INICIO = "MI";
    private const string MOD_FFAA = "MR";
    private const string MOD_OFICINA = "MO";

    private const string TIPO_AUTOMATICO = "AUTOMATICO";
    private const string TIPO_MANUAL = "MANUAL";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string sTipo;
        if (!Page.IsPostBack)
        {
            sTipo = Request.QueryString["Tipo"];
            hddTipo.Value = sTipo;
            if (MOD_DATOS_PERSONALES.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION DATOS PERSONALES";
            }
            else if (MOD_FECHAS.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION FECHAS";
            }
            else if (MOD_SALARIO.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION SALARIO";
            }
            else if (MOD_EMPRESAS.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION EMPRESAS";
            }
            else if (MOD_FFAA.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION FFAA";
            }
            else if (MOD_INICIO.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION INICIO TRAMITE";
            }
            else if (MOD_OFICINA.Equals(sTipo))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION OFICINA NOTIFICACION";
            }
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
        this.pnlRegistrosCabecera.Visible = false;
        this.txtPaternoBuscar.Focus();
    }

    #endregion

    #region funciones

    private void BuscarTramite()
    {
        DataTable dtTramites = new DataTable();
        try
        {
            if (MOD_FFAA.Equals(hddTipo.Value))
            {
                dtTramites = buscarTramitesRenuncia("FFAA");
            }
            else
            {
                if (MOD_DATOS_PERSONALES.Equals(hddTipo.Value) ||
                    MOD_FECHAS.Equals(hddTipo.Value) ||
                    MOD_INICIO.Equals(hddTipo.Value) ||
                    MOD_OFICINA.Equals(hddTipo.Value))
                {
                    dtTramites = buscarTramitesRenuncia("Modificacion1");
                }
                else if (MOD_SALARIO.Equals(hddTipo.Value) ||
                         MOD_EMPRESAS.Equals(hddTipo.Value))
                {
                    dtTramites = buscarTramitesRenuncia("Modificacion2");
                }
            }
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

    #endregion

    #region grilla

    protected void gvBusquedaTramiteCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdTramite")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string queryStringNUP = "";
            string queryStringNombre = "";
            string queryStringSegundoNombre = "";
            string queryStringPaterno = "";
            string queryStringMaterno = "";
            string queryStringCasada = "";
            string queryStringNacimiento = DateTime.MinValue.ToString();
            string queryStringFallecimiento = DateTime.MinValue.ToString();
            string queryStringCUA = "";
            string queryStringMatricula = "";
            string queryStringCI = "";
            string queryStringComplemento = "";
            string queryStringTabla = "";
            string queryStringPrestacionHabilitada = "";

            queryStringNUP = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["NUP"]);
            queryStringNombre = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["PrimerNombre"]);
            queryStringSegundoNombre = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["SegundoNombre"]);
            queryStringPaterno = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["PrimerApellido"]);
            queryStringMaterno = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["SegundoApellido"]);
            queryStringCasada = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["ApellidoCasada"]);
            queryStringNacimiento = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["FechaNacimiento"]);
            queryStringFallecimiento = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["FechaFallecimiento"]);
            queryStringCUA = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["CUA"]);
            queryStringMatricula = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["Matricula"]);
            queryStringCI = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["NumeroDocumento"]);
            queryStringComplemento = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["ComplementoSEGIP"]);
            queryStringTabla = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            queryStringPrestacionHabilitada = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["TipoTramite"]);

            clsFuncionesGenerales encriptar = new clsFuncionesGenerales();
            string encriptNUP = encriptar.EncryptKey(queryStringNUP);
            string encriptPrimerNombre = encriptar.EncryptKey(queryStringNombre);
            string encriptSegundoNombres = encriptar.EncryptKey(queryStringSegundoNombre);
            string encriptPrimerApellido = encriptar.EncryptKey(queryStringPaterno);
            string encriptSegundoApellido = encriptar.EncryptKey(queryStringMaterno);
            string encriptApellidoCasada = encriptar.EncryptKey(queryStringCasada);
            string encriptFechaNacimiento = encriptar.EncryptKey(queryStringNacimiento);
            string encriptFechaFallecimiento = encriptar.EncryptKey(queryStringFallecimiento);
            string encriptCUA = encriptar.EncryptKey(queryStringCUA);
            string encriptMatricula = encriptar.EncryptKey(queryStringMatricula);
            string encriptNumeroDocumento = encriptar.EncryptKey(queryStringCI);
            string encriptComplemento = encriptar.EncryptKey(queryStringComplemento);
            string encriptStringTabla = encriptar.EncryptKey(queryStringTabla);
            string encriptStringPrestacionHabilitada = encriptar.EncryptKey(queryStringPrestacionHabilitada);
            string sPaginaDestino;
            if (MOD_DATOS_PERSONALES.Equals(hddTipo.Value) || MOD_FECHAS.Equals(hddTipo.Value) || MOD_FFAA.Equals(hddTipo.Value))
            {
                sPaginaDestino = "wfrmModificarDatos.aspx";
            }
            else if (MOD_INICIO.Equals(hddTipo.Value))
            {
                sPaginaDestino = "wfrmModificarDatosInicio.aspx";
            }
            else if (MOD_OFICINA.Equals(hddTipo.Value))
            {
                sPaginaDestino = "wfrmModificarDatosOficina.aspx";
            }
            else
            {
                sPaginaDestino = "wfrmModificarDatosEmpresa.aspx";
            }
            string contentUrl = string.Format(sPaginaDestino + "?NUP={0}&Tipo={1}&MAT={2}&PNO={3}&SNO={4}&PAP={5}&SAP={6}&ACA={7}&FNA={8}&CUA={9}&NDO={10}&CSE={11}&TAB={12}&BUS={13}&FDE={14}",
            encriptNUP, encriptStringPrestacionHabilitada, encriptMatricula, encriptPrimerNombre, encriptSegundoNombres, encriptPrimerApellido, encriptSegundoApellido, encriptApellidoCasada,
            encriptFechaNacimiento, encriptCUA, encriptNumeroDocumento, encriptComplemento, encriptStringTabla, hddTipo.Value, encriptFechaFallecimiento);
            Response.Redirect(contentUrl);
        }
    }

    protected void gvBusquedaTramiteCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sPrestacionHabilitada = Convert.ToString(gvBusquedaTramiteCC.DataKeys[e.Row.RowIndex].Values["TipoTramite"]);
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");
            if (MOD_SALARIO.Equals(hddTipo.Value))
            {
                if (TIPO_MANUAL.Equals(sPrestacionHabilitada))
                {
                    btnTramite.Visible = false;
                    btnBloqueo.Visible = true;
                }
                else
                {
                    btnTramite.Visible = true;
                    btnBloqueo.Visible = false;
                }
            }
            else
            {
                btnTramite.Visible = true;
                btnBloqueo.Visible = false;
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