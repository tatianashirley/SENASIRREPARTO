using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_wfrmAccesoDirecto : System.Web.UI.Page
{
    #region contantes

    private const string REGISTRO = "RG";
    private const string RENUNCIA = "RN";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            lblSubTitulo.Text = "Buscar Trámite";
            pnlRegistrosCabecera.Visible = false;
            hddTipo.Value = Request.QueryString["Tipo"];
            if (REGISTRO.Equals(hddTipo.Value))
            {
                lblTituloSistema.Text = "MODULO REGISTRO ACCESO DIRECTO";
            }
            else
            {
                lblTituloSistema.Text = "MODULO RENUNCIA AL SISTEMA DE REPARTO";
            }

            //deshabilitar el Autocompletar
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
        this.txtNumTramiteBuscar.Text = "";
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
        string sTipo = "";
        DataTable dtTramites = new DataTable();
        try
        {
            sTipo = "Inicial";
            dtTramites = buscarTramitesRenuncia(sTipo);
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
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();

        dtListaPersonas = objTramite.BuscarTramiteReparto(iIdConexion, cOperacion, txtNumTramiteBuscar.Text.Trim(), this.txtPrimerNormbreBuscar.Text.Trim(), this.txtSegundoNombreBuscar.Text.Trim(), this.txtPaternoBuscar.Text.Trim(), this.txtMaternoBuscar.Text.Trim(), txtNumDocBuscar.Text.Trim(), "", this.txtMatriculaBuscar.Text.Trim(), estadotramite, ref sMensajeError);

        return dtListaPersonas;
    }

    #endregion

    #region grilla

    protected void gvBusquedaTramiteCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        string contentUrl;
        string sPaginaDestino;
        clsFuncionesGenerales encriptar;
        if (e.CommandName.Equals("cmdTramite"))
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string queryStringNUP = "";
            string queryStringNombre = "";
            string queryStringSegundoNombre = "";
            string queryStringPaterno = "";
            string queryStringMaterno = "";
            string queryStringCasada = "";
            string queryStringNacimiento = DateTime.MinValue.ToString();
            string queryStringCUA = "";
            string queryStringMatricula = "";
            string queryStringCI = "";
            string queryStringComplemento = "";
            string queryStringTabla = "";
            string queryStringPrestacionHabilitada = "";

            queryStringNUP = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            queryStringNombre = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["PrimerNombre"]);
            queryStringSegundoNombre = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["SegundoNombre"]);
            queryStringPaterno = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["PrimerApellido"]);
            queryStringMaterno = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["SegundoApellido"]);
            queryStringCasada = "";
            queryStringNacimiento = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["FechaNacimiento"]);
            queryStringCUA = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["CUA"]);
            queryStringMatricula = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["Matricula"]);
            queryStringCI = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["NumeroDocumento"]);
            queryStringComplemento = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["ComplementoSEGIP"]);
            queryStringTabla = "CRENTA";
            queryStringPrestacionHabilitada = "CRENTA";

            if (REGISTRO.Equals(hddTipo.Value))
            {
                encriptar = new clsFuncionesGenerales();
                string encriptNUP = encriptar.EncryptKey(queryStringNUP);
                string encriptPrimerNombre = encriptar.EncryptKey(queryStringNombre);
                string encriptSegundoNombres = encriptar.EncryptKey(queryStringSegundoNombre);
                string encriptPrimerApellido = encriptar.EncryptKey(queryStringPaterno);
                string encriptSegundoApellido = encriptar.EncryptKey(queryStringMaterno);
                string encriptApellidoCasada = encriptar.EncryptKey(queryStringCasada);
                string encriptFechaNacimiento = encriptar.EncryptKey(queryStringNacimiento);
                string encriptCUA = encriptar.EncryptKey(queryStringCUA);
                string encriptMatricula = encriptar.EncryptKey(queryStringMatricula);
                string encriptNumeroDocumento = encriptar.EncryptKey(queryStringCI);
                string encriptComplemento = encriptar.EncryptKey(queryStringComplemento);
                string encriptStringTabla = encriptar.EncryptKey(queryStringTabla);
                string encriptStringPrestacionHabilitada = encriptar.EncryptKey(queryStringPrestacionHabilitada);
                string encriptStringProc = encriptar.EncryptKey("AD");

                sPaginaDestino = "wfrmCompletarDatos.aspx";
                contentUrl = string.Format(sPaginaDestino + "?NUP={0}&Tipo={1}&MAT={2}&PNO={3}&SNO={4}&PAP={5}&SAP={6}&ACA={7}&FNA={8}&CUA={9}&NDO={10}&CSE={11}&TAB={12}&PROC={13}",
            encriptNUP, encriptStringPrestacionHabilitada, encriptMatricula, encriptPrimerNombre, encriptSegundoNombres, encriptPrimerApellido, encriptSegundoApellido, encriptApellidoCasada,
            encriptFechaNacimiento, encriptCUA, encriptNumeroDocumento, encriptComplemento, encriptStringTabla, encriptStringProc);
            }
            else
            {
                sPaginaDestino = "wfrmCompletarDatosRenunciaAcceso.aspx";
                contentUrl = string.Format(sPaginaDestino + "?iMatricula={0}&iIdTramite={1}",
            queryStringMatricula, queryStringNUP);
            }

            Response.Redirect(contentUrl);
        }

    }

    protected void gvBusquedaTramiteCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string idTramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");

            btnTramite.Visible = true;
            btnBloqueo.Visible = false;
            if (String.IsNullOrEmpty(idTramite))
            {
                e.Row.BackColor = Color.Yellow;
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