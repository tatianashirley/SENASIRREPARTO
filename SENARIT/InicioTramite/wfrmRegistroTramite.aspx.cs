using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;

public partial class wfrmRegistroTramite : System.Web.UI.Page
{

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "MODULO INICIO TRÁMITE";
            lblSubTitulo.Text = "Buscar Persona";
            pnlRegistrosCabecera.Visible = false;
            Session["iPrecision"] = 11;
            //deshabilitar el Autocompletar
            txtPrimerApellido.Attributes.Add("autocomplete", "off");
            txtSegundoApellido.Attributes.Add("autocomplete", "off");
            txtPrimerNombre.Attributes.Add("autocomplete", "off");
            txtSegundoNombre.Attributes.Add("autocomplete", "off");
            txtNumeroDocumento.Attributes.Add("autocomplete", "off");
            txtFechaNacimiento.Attributes.Add("autocomplete", "off");
            txtPrimerApellido.Attributes.Add("autofocus", "on");
            if ((int)Session["RolUsuario"] == 269)
            {
                lblTituloSistema.Text = "MODULO SEGUIMIENTO DE REQUISITOS";
            }
        }
    }

    #endregion

    #region botones

    //Botón de Búsqueda de persona, permite bajar la Precision hasta un límite, cada click
    protected void imgbtnBuscar_Click(object sender, EventArgs e)
    {
        int iPrecision = Convert.ToInt16(Session["iPrecision"]);
        if (Validacion())
        {
            switch (iPrecision)
            {
                case 9:
                    this.lblPrecision.Text = "Precisión Baja";
                    BuscarPersona();
                    Session["iPrecision"] = 9;
                    break;
                case 10:
                    this.lblPrecision.Text = "Precisión Media";
                    BuscarPersona();
                    Session["iPrecision"] = iPrecision - 1;
                    break;
                case 11:
                    this.lblPrecision.Text = "Precisión Alta";
                    BuscarPersona();
                    Session["iPrecision"] = iPrecision - 1;
                    break;
            }
            this.lblPrecision.Visible = true;
        }
    }

    //Botón de limpieza de formulario de búsqueda.
    protected void imgbtnBorrar_Click(object sender, EventArgs e)
    {
        Session["iPrecision"] = 11;
        this.txtPrimerNombre.Text = "";
        this.txtPrimerNombre.Enabled = true;
        this.txtSegundoNombre.Text = "";
        this.txtSegundoNombre.Enabled = true;
        this.txtPrimerApellido.Text = "";
        this.txtPrimerApellido.Enabled = true;
        this.txtSegundoApellido.Text = "";
        this.txtSegundoApellido.Enabled = true;
        this.txtNumeroDocumento.Text = "";
        this.txtFechaNacimiento.Text = "";
        this.txtFechaNacimiento.Enabled = true;
        this.chkbPorDocumento.Checked = false;
        this.lblPrecision.Visible = false;
        this.pnlRegistrosCabecera.Visible = false;
        this.ImageButton1.Enabled = true;
        this.txtPrimerApellido.Focus();
        Master.MensajeCancel();
    }

    #endregion

    #region grilla

    //link tramite
    protected void gvPersona_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        string contentUrl;
        string sPaginaDestino;
        clsFuncionesGenerales encriptar;
        if (e.CommandName.Equals("cmdTramite") || e.CommandName.Equals("cmdActualizar"))
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

            queryStringNUP = Convert.ToString(gvPersona.DataKeys[Index].Values["nup"]);
            queryStringNombre = Convert.ToString(gvPersona.DataKeys[Index].Values["primerNombre"]);
            queryStringSegundoNombre = Convert.ToString(gvPersona.DataKeys[Index].Values["segundoNombre"]);
            queryStringPaterno = Convert.ToString(gvPersona.DataKeys[Index].Values["paterno"]);
            queryStringMaterno = Convert.ToString(gvPersona.DataKeys[Index].Values["materno"]);
            queryStringCasada = Convert.ToString(gvPersona.DataKeys[Index].Values["casada"]);
            queryStringNacimiento = Convert.ToString(gvPersona.DataKeys[Index].Values["fechanacimiento"]);
            queryStringCUA = Convert.ToString(gvPersona.DataKeys[Index].Values["nua"]);
            queryStringMatricula = Convert.ToString(gvPersona.DataKeys[Index].Values["matricula"]);
            queryStringCI = Convert.ToString(gvPersona.DataKeys[Index].Values["carnet"]);
            queryStringComplemento = Convert.ToString(gvPersona.DataKeys[Index].Values["complementoSEGIP"]);
            queryStringTabla = Convert.ToString(gvPersona.DataKeys[Index].Values["Tabla"]);
            queryStringPrestacionHabilitada = Convert.ToString(gvPersona.DataKeys[Index].Values["Habilitado"]);

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
            string encriptStringProc = encriptar.EncryptKey("IT");
            if (queryStringPrestacionHabilitada == "APODERADO")
            {
                sPaginaDestino = "wfrmModificarDatosAPO.aspx";
            }
            else
            {
                sPaginaDestino = "wfrmCompletarDatos.aspx";
            }
            contentUrl = string.Format(sPaginaDestino + "?NUP={0}&Tipo={1}&MAT={2}&PNO={3}&SNO={4}&PAP={5}&SAP={6}&ACA={7}&FNA={8}&CUA={9}&NDO={10}&CSE={11}&TAB={12}&PROC={13}",
            encriptNUP, encriptStringPrestacionHabilitada, encriptMatricula, encriptPrimerNombre, encriptSegundoNombres, encriptPrimerApellido, encriptSegundoApellido, encriptApellidoCasada,
            encriptFechaNacimiento, encriptCUA, encriptNumeroDocumento, encriptComplemento, encriptStringTabla, encriptStringProc);
            Response.Redirect(contentUrl);
        }
    }

    //colorear con automatico
    protected void gvPersona_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sPrestacionHabilitada = Convert.ToString(gvPersona.DataKeys[e.Row.RowIndex].Values["Habilitado"]);
            if (sPrestacionHabilitada == "AUTOMÁTICO")
            {
                e.Row.BackColor = Color.LightCoral;
            }
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");
            ImageButton btnActualizar = (ImageButton)e.Row.FindControl("ImgActualizar");

            if (btnTramite != null && btnBloqueo != null && btnActualizar != null)
            {
                if (sPrestacionHabilitada == "AP" || sPrestacionHabilitada == "AVC" || sPrestacionHabilitada == "AUTOMÁTICO" || sPrestacionHabilitada == "FFAA")
                {
                    btnTramite.Visible = true;
                    btnBloqueo.Visible = false;
                    btnActualizar.Visible = false;
                }
                else
                {
                    if (sPrestacionHabilitada == "APODERADO")
                    {
                        btnTramite.Visible = false;
                        btnBloqueo.Visible = false;
                        btnActualizar.Visible = true;
                    }
                    else
                    {
                        btnTramite.Visible = false;
                        btnBloqueo.Visible = true;
                        btnActualizar.Visible = false;
                    }
                }
            }
            if ((int)Session["RolUsuario"] == 269)
            {
                btnTramite.Visible = false;
                btnBloqueo.Visible = true;
                btnActualizar.Visible = false;
            }
        }
    }

    //index
    protected void gvPersona_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersona.PageIndex = e.NewPageIndex;
        BuscarPersona();
    }

    //elegir pagina
    protected void gvPersona_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvPersona = (GridView)sender;
        gvPersona.PageIndex = e.NewSelectedIndex;
        gvPersona.DataBind();
    }

    #endregion

    #region funciones

    //Buscar Persona
    private void BuscarPersona()
    {
        string sError;
        string sDetalleError;
        string sMensajeError;
        int iIdConexion;
        string cOperacion;
        DataTable dtListaPersonas;
        clsPersona clsPersona;

        string sPrecision;
        string sPrimerNombre;
        string sSegundoNombre;
        string sPrimerApellido;
        string sSegundoApellido;
        string sNumeroDocumento;
        string sFechaNacimiento;

        try
        {
            sMensajeError = "";
            iIdConexion = (int)Session["IdConexion"];
            cOperacion = "Q";
            sPrimerNombre = this.txtPrimerNombre.Text.Trim();
            sSegundoNombre = this.txtSegundoNombre.Text.Trim();
            sPrimerApellido = this.txtPrimerApellido.Text.Trim();
            sSegundoApellido = this.txtSegundoApellido.Text.Trim();
            sNumeroDocumento = this.txtNumeroDocumento.Text.Trim();
            sFechaNacimiento = this.txtFechaNacimiento.Text.Trim();

            //Precision
            if (Session["iPrecision"] != null)
            {
                sPrecision = Session["iPrecision"].ToString();
            }
            else
            {
                sPrecision = "11";
            }
            //Buscar
            clsPersona = new clsPersona();

            if (this.chkbPorDocumento.Checked)
            {
                dtListaPersonas = clsPersona.BuscarPorIdentificador(iIdConexion, cOperacion, "NORMAL", "CI", sNumeroDocumento, ref sMensajeError);
            }
            else
            {
                dtListaPersonas = clsPersona.BuscarPorAvanzada(iIdConexion, cOperacion, "NORMAL", sPrimerApellido, sSegundoApellido, sPrimerNombre, sSegundoNombre, sNumeroDocumento, sFechaNacimiento, sPrecision, ref sMensajeError);
            }
            gvPersona.DataSource = dtListaPersonas;
            gvPersona.DataBind();
            pnlRegistrosCabecera.Visible = true;

            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        catch (Exception ex)
        {
            sError = "Error al realizar la operación";
            sDetalleError = Convert.ToString(ex);
            Master.MensajeError(sError, sDetalleError);
        }
    }

    // Validar de datos de entrada
    protected bool Validacion()
    {
        string sError;
        string sDetalleError;
        string sFechaNacimiento;
        sError = "Error al realizar la operación.";
        //busqueda por ci
        if (this.chkbPorDocumento.Checked)
        {
            //Validar numero de documento
            if (String.IsNullOrEmpty(this.txtNumeroDocumento.Text.Trim()))
            {
                sDetalleError = "El Número Documento es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            else
            {
                if (this.txtNumeroDocumento.Text.Length < 3)
                {
                    sDetalleError = "El longitud del Número Documento debe ser mayor a 2 caracteres.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
            }
        }
        else //busqueda por nombres
        {
            //Validar apellidos
            if (String.IsNullOrEmpty(this.txtPrimerApellido.Text.Trim()) && String.IsNullOrEmpty(this.txtSegundoApellido.Text.Trim()))
            {
                sDetalleError = "El Primer o Segundo Apellido es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            else
            {
                if (!String.IsNullOrEmpty(this.txtPrimerApellido.Text.Trim()) && this.txtPrimerApellido.Text.Length < 3)
                {
                    sDetalleError = "La longitud del Primer Apellido debe ser mayor a 2 caracteres.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
                if (!String.IsNullOrEmpty(this.txtSegundoApellido.Text.Trim()) && this.txtSegundoApellido.Text.Length < 3)
                {
                    sDetalleError = "La longitud del Segundo Apellido debe ser mayor a 2 caracteres.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
            }
            //Validar nombres
            if (String.IsNullOrEmpty(this.txtPrimerNombre.Text.Trim()))
            {
                sDetalleError = "El Primer Nombre es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            else
            {
                if (this.txtPrimerNombre.Text.Length < 3)
                {
                    sDetalleError = "La longitud del Primer Nombre debe ser mayor a 2 caracteres.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
            }
            //Validar documento identificacion
            if (!String.IsNullOrEmpty(this.txtNumeroDocumento.Text.Trim()) && this.txtNumeroDocumento.Text.Length < 3)
            {
                sDetalleError = "El longitud del Número Documento debe ser mayor a 2 caracteres.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            //Validar fecha nacimiento
            sFechaNacimiento = this.txtFechaNacimiento.Text.Trim();
            if (!String.IsNullOrEmpty(sFechaNacimiento))
            {
                if (!IsDate(sFechaNacimiento))
                {
                    sDetalleError = "La Fecha Nacimiento no es válida.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
                if (Convert.ToDateTime(sFechaNacimiento) >= DateTime.Now.Date.AddYears(-18))
                {
                    sDetalleError = "La Fecha Nacimiento no es válida.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
                if (Convert.ToDateTime(sFechaNacimiento) < Convert.ToDateTime("01/01/1900"))
                {
                    sDetalleError = "La Fecha Nacimiento no es válida.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
            }
        }
        return true;
    }

    //validar la fecha 
    private bool IsDate(string sFecha)
    {
        string sResultado;
        try
        {
            sResultado = DateTime.Parse(sFecha).ToShortDateString();
        }
        catch
        {
            sResultado = "";
        }
        return (sResultado != "");
    }

    #endregion

    #region checkbox

    //Check box de tipo documento
    protected void chkbPorDocumento_CheckedChanged(object sender, EventArgs e)
    {
        if (this.chkbPorDocumento.Checked)
        {
            this.txtPrimerApellido.Text = "";
            this.txtPrimerApellido.Enabled = false;
            this.txtSegundoApellido.Text = "";
            this.txtSegundoApellido.Enabled = false;
            this.txtPrimerNombre.Text = "";
            this.txtPrimerNombre.Enabled = false;
            this.txtSegundoNombre.Text = "";
            this.txtSegundoNombre.Enabled = false;
            this.txtFechaNacimiento.Text = "";
            this.txtFechaNacimiento.Enabled = false;
            this.ImageButton1.Enabled = false;
            this.txtNumeroDocumento.Focus();
        }
        else
        {
            this.txtPrimerApellido.Text = "";
            this.txtPrimerApellido.Enabled = true;
            this.txtSegundoApellido.Text = "";
            this.txtSegundoApellido.Enabled = true;
            this.txtPrimerNombre.Text = "";
            this.txtPrimerNombre.Enabled = true;
            this.txtSegundoNombre.Text = "";
            this.txtSegundoNombre.Enabled = true;
            this.txtFechaNacimiento.Text = "";
            this.txtFechaNacimiento.Enabled = true;
            this.ImageButton1.Enabled = true;
            this.txtPrimerApellido.Focus();
        }

    }

    #endregion

}
