
using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_ModificarDatosInicio : System.Web.UI.Page
{
    #region constantes

    private const string CARNET_IDENTIDAD = "25";
    private const string CARNET_EXTRANJERO = "26";
    private const string EXPEDIDO_EXTRANJERO = "45";
    private const string BOLIVIA = "83";
    private const string FEMENINO = "1";
    private const string TITULAR = "526";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringNUP;
        string queryStringTipo;
        string queryStringMatricula;
        string queryStringNombre;
        string queryStringSegundoNombre;
        string queryStringPaterno;
        string queryStringMaterno;
        string queryStringCasada;
        string queryStringNacimiento;
        string queryStringDefuncion;
        string queryStringCUA;
        string queryStringCI;
        string queryStringComplemento;
        string queryStringTabla;
        string queryStringTipoBus;

        string Tipo = "";
        string NUPString = "";
        string Matricula = "";
        string Nombre = "";
        string SegundoNombre = "";
        string Paterno = "";
        string Materno = "";
        string Casada = "";
        string Nacimiento = "";
        string Defuncion = "";
        string CUA = "";
        string CI = "";
        string Complemento = "";
        string Tabla = "";

        clsFuncionesGenerales encriptar;

        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "MODULO MODIFICACION INICIO TRAMITE";
            lblSubTitulo.Text = "Modificar Datos Inicio";

            Session["Documento"] = "";
            Session["EmpresaManual"] = "";
            Session["EmpresaAutomatico"] = "";
            Session["Monto"] = "";

            queryStringNUP = Request.QueryString["NUP"].Replace(' ', '+');
            queryStringTipo = Request.QueryString["Tipo"].Replace(' ', '+');
            queryStringMatricula = Request.QueryString["MAT"].Replace(' ', '+');
            queryStringNombre = Request.QueryString["PNO"].Replace(' ', '+');
            queryStringSegundoNombre = Request.QueryString["SNO"].Replace(' ', '+');
            queryStringPaterno = Request.QueryString["PAP"].Replace(' ', '+');
            queryStringMaterno = Request.QueryString["SAP"].Replace(' ', '+');
            queryStringCasada = Request.QueryString["ACA"].Replace(' ', '+');
            queryStringNacimiento = Request.QueryString["FNA"].Replace(' ', '+');
            queryStringCUA = Request.QueryString["CUA"].Replace(' ', '+');
            queryStringCI = Request.QueryString["NDO"].Replace(' ', '+');
            queryStringComplemento = Request.QueryString["CSE"].Replace(' ', '+');
            queryStringTabla = Request.QueryString["TAB"].Replace(' ', '+');
            queryStringTipoBus = Request.QueryString["BUS"].Replace(' ', '+');
            queryStringDefuncion = Request.QueryString["FDE"].Replace(' ', '+');

            hddTipo.Value = queryStringTipoBus;
            encriptar = new clsFuncionesGenerales();
            if (queryStringTipo != "")
            {
                clsFormatoFecha f;
                DateTime d;
                Tipo = encriptar.DecryptKey(queryStringTipo);
                Session["Tipo"] = Tipo;

                lblTipo.Text = Tipo;
                if (queryStringNUP != "")
                    NUPString = encriptar.DecryptKey(queryStringNUP);

                if (queryStringMatricula != "")
                    Matricula = encriptar.DecryptKey(queryStringMatricula);

                if (queryStringNombre != "")
                    Nombre = encriptar.DecryptKey(queryStringNombre);

                if (queryStringSegundoNombre != "")
                    SegundoNombre = encriptar.DecryptKey(queryStringSegundoNombre);

                if (queryStringPaterno != "")
                    Paterno = encriptar.DecryptKey(queryStringPaterno);

                if (queryStringMaterno != "")
                    Materno = encriptar.DecryptKey(queryStringMaterno);

                if (queryStringCasada != "")
                    Casada = encriptar.DecryptKey(queryStringCasada);

                if (queryStringNacimiento != "")
                {
                    Nacimiento = encriptar.DecryptKey(queryStringNacimiento);
                    f = new clsFormatoFecha();
                    d = f.GeneraFechaDMY(Nacimiento);
                    Nacimiento = f.Fecha(d);
                }

                if (queryStringDefuncion != "")
                {
                    Defuncion = encriptar.DecryptKey(queryStringDefuncion);
                    f = new clsFormatoFecha();
                    d = f.GeneraFechaDMY(Defuncion);
                    Defuncion = f.Fecha(d);
                }

                if (queryStringCUA != "")
                    CUA = encriptar.DecryptKey(queryStringCUA);

                if (queryStringCI != "")
                    CI = encriptar.DecryptKey(queryStringCI);

                if (queryStringComplemento != "")
                    Complemento = encriptar.DecryptKey(queryStringComplemento);

                if (queryStringTabla != "")
                    Tabla = encriptar.DecryptKey(queryStringTabla);
                //cargar datos en pantalla
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, Defuncion, CUA, CI, Complemento, Tabla);
                CargarTipoDocumento();
                CargarExpedicionDocumento();
                CargarEntidadAseguradora();
                CargarDatosTramite();
                CargarPersonaTipo();
                CargarCombosInicia();
                CargarDatosInicioTramite();
                InhabilitarDatosPersonales();
            }
        }
    }

    #endregion

    #region acordeones

    //Abrir/Cerrar registro.
    protected void ibtnOpenCloseRegistro_Click(object sender, ImageClickEventArgs e)
    {
        if (!pnlRegistro.Visible)
        {
            ibtnOpenCloseRegistro.ImageUrl = "~/Imagenes/16quitar.png";
            pnlRegistro.Visible = true;
        }
        else
        {
            ibtnOpenCloseRegistro.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlRegistro.Visible = false;
        }
    }

    //Abrir/Cerrar datos residencia.
    protected void ibtnOpenCloseDatosResidencia_Click(object sender, ImageClickEventArgs e)
    {
        if (!pnlPersonaInicia.Visible)
        {
            ibtnOpenCloseDatosResidencia.ImageUrl = "~/Imagenes/16quitar.png";
            pnlPersonaInicia.Visible = true;
        }
        else
        {
            ibtnOpenCloseDatosResidencia.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlPersonaInicia.Visible = false;
        }
    }


    //Abrir/Cerrar datos residencia.
    protected void ibtnOpenCloseDatosMotivo_Click(object sender, ImageClickEventArgs e)
    {
        if (!Panel4.Visible)
        {
            ibtnOpenCloseDatosMotivo.ImageUrl = "~/Imagenes/16quitar.png";
            Panel4.Visible = true;
        }
        else
        {
            ibtnOpenCloseDatosMotivo.ImageUrl = "~/Imagenes/16adicionar.png";
            Panel4.Visible = false;
        }
    }

    #endregion

    #region funciones

    //CARGA LOS DATOS OBTENIDOS EN EL LISTADO ANTERIOR
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string Defuncion, string CUA, string CI, string Complemento, string Tabla)
    {
        clsFormatoFecha f = new clsFormatoFecha();
        this.hfNUP.Value = NUPString;
        this.txtPrimerApellido.Text = Paterno;
        this.txtSegundoApellido.Text = Materno;
        this.txtApellidoCasada.Text = Casada;
        this.txtPrimerNombre.Text = Nombre;
        this.txtSegundoNombre.Text = SegundoNombre;
        this.txtNumeroDocumento.Text = CI;
        this.txtComplemento.Text = Complemento;
        this.hfTabla.Value = Tabla;
        this.txtNroTramite.Text = Tabla;
        this.txtCUA.Text = CUA;
        this.txtMatricula.Text = Matricula;
    }

    //Buscar Tramites
    protected void CargarDatosTramite()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string iIdTramite = "0";
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();
        iIdTramite = this.hfTabla.Value;
        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, 3, null, null, null, null, null, null, null, "Modificacion", ref sMensajeError);
        DataRow row = dtListaPersonas.Rows[0];
        ddlTipoDocumento.SelectedValue = Convert.ToString(row["idDocumento"]);
        ddlExpedicion.SelectedValue = Convert.ToString(row["IdDocExpedicion"]);
        ddlAFP.SelectedValue = Convert.ToString(row["IdEntidadGestora"]);
    }

    //Cargar Tipo Persona
    private void CargarPersonaTipo()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtTipoPersona = new DataTable();
        dtTipoPersona = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 46, ref sMensajeError);
        if (dtTipoPersona != null && dtTipoPersona.Rows.Count > 0)
        {
            rblTipoPersonaInicia.DataSource = dtTipoPersona;
            rblTipoPersonaInicia.DataTextField = "Descripcion";
            rblTipoPersonaInicia.DataValueField = "IdDetalleClasificador";
            rblTipoPersonaInicia.DataBind();
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Buscar Tramites
    protected void CargarDatosInicioTramite()
    {
        DataTable dtInicioTramite;
        clsTramite objTramite = new clsTramite();
        string sMensajeError = "";
        string cOperacion = "V";
        DataTable dtListaPersonas = null;
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt32(this.hfTabla.Value);
        objTramite.IdGrupoBeneficio = 3;
        dtInicioTramite = objTramite.ObtenerInicioTramite();
        if (dtInicioTramite != null && dtInicioTramite.Rows.Count > 0)
        {
            DataRow row = dtInicioTramite.Rows[0];
            rblTipoPersonaInicia.SelectedValue = Convert.ToString(row["IdTipoIniciaTramite"]);
            if (!TITULAR.Equals(rblTipoPersonaInicia.SelectedValue))
            {
                clsPersona objPersona = new clsPersona();
                objPersona.NUP = Convert.ToInt32(row["NUPIniciaTramite"]);
                dtListaPersonas = objPersona.ObtenerPersona(objTramite.iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
                if (dtListaPersonas != null && dtListaPersonas.Rows.Count > 0)
                {
                    DataRow row1 = dtListaPersonas.Rows[0];
                    this.pnlNuevaPersona.Visible = true;
                    this.hdnNupIniciaTramite.Value = Convert.ToString(row1["NUP"]);
                    this.txtNumeroDocumentoInicia.Text = Convert.ToString(row1["NumeroDocumento"]);
                    this.txtNumeroDocumentoInicia.Enabled = false;
                    this.txtPrimerApellidoInicia.Text = Convert.ToString(row1["PrimerApellido"]);
                    this.txtPrimerApellidoInicia.Enabled = false;
                    this.txtSegundoApellidoInicia.Text = Convert.ToString(row1["SegundoApellido"]);
                    this.txtSegundoApellidoInicia.Enabled = false;
                    this.txtPrimerNombreInicia.Text = Convert.ToString(row1["PrimerNombre"]);
                    this.txtPrimerNombreInicia.Enabled = false;
                    this.txtSegundoNombreInicia.Text = Convert.ToString(row1["SegundoNombre"]);
                    this.txtSegundoNombreInicia.Enabled = false;
                    this.txtApellidoCasadaInicia.Text = Convert.ToString(row1["ApellidoCasada"]);
                    this.txtApellidoCasadaInicia.Enabled = false;
                    this.ddlEstadoCivilInicia.SelectedValue = Convert.ToString(row1["IdEstadoCivil"]);
                    this.ddlEstadoCivilInicia.Enabled = false;
                    this.txtComplementoInicia.Text = Convert.ToString(row1["ComplementoSEGIP"]);
                    this.txtComplementoInicia.Enabled = false;
                    this.ddlTipoDocumentoInicia.SelectedValue = Convert.ToString(row1["IdTipoDocumento"]);
                    this.ddlTipoDocumentoInicia.Enabled = false;
                    this.ddlExpedicionInicia.SelectedValue = Convert.ToString(row1["IdDocumentoExpedido"]);
                    this.ddlExpedicionInicia.Enabled = false;
                    this.txtFechaNacimientoInicia.Text = clsFormatoFecha.FechaText(Convert.ToString(row1["FechaNacimiento"]));
                    this.txtFechaNacimientoInicia.Enabled = false;
                    this.rdblSexoInicia.SelectedValue = Convert.ToString(row1["IdSexo"]);
                    this.rdblSexoInicia.Enabled = false;
                }
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(objTramite.sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Combo tipo documento
    private void CargarTipoDocumento()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtTipoDocumento = new DataTable();
        dtTipoDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 4, ref sMensajeError);
        if (dtTipoDocumento != null && dtTipoDocumento.Rows.Count > 0)
        {
            ddlTipoDocumento.DataSource = dtTipoDocumento;
            ddlTipoDocumento.DataTextField = "Descripcion";
            ddlTipoDocumento.DataValueField = "IdDetalleClasificador";
            ddlTipoDocumento.DataBind();
            ddlTipoDocumento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlTipoDocumento.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Combo Expedición Documento
    private void CargarExpedicionDocumento()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtExpDocumento = new DataTable();
        dtExpDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 9, ref sMensajeError);
        if (dtExpDocumento != null && dtExpDocumento.Rows.Count > 0)
        {
            ddlExpedicion.DataSource = dtExpDocumento;
            ddlExpedicion.DataTextField = "Descripcion";
            ddlExpedicion.DataValueField = "IdDetalleClasificador";
            ddlExpedicion.DataBind();
            ddlExpedicion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlExpedicion.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Combo Expedición Documento
    private void CargarEntidadAseguradora()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtExpDocumento = new DataTable();
        dtExpDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 16, ref sMensajeError);
        if (dtExpDocumento != null && dtExpDocumento.Rows.Count > 0)
        {
            ddlAFP.DataSource = dtExpDocumento;
            ddlAFP.DataTextField = "Descripcion";
            ddlAFP.DataValueField = "IdDetalleClasificador";
            ddlAFP.DataBind();
            ddlAFP.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlAFP.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //INHABILITAR DATOS PERSONALES.
    private void InhabilitarDatosPersonales()
    {
        this.txtPrimerNombre.Enabled = false;
        this.txtSegundoNombre.Enabled = false;
        this.txtPrimerApellido.Enabled = false;
        this.txtSegundoApellido.Enabled = false;
        this.txtApellidoCasada.Enabled = false;
        this.ddlTipoDocumento.Enabled = false;
        this.txtNumeroDocumento.Enabled = false;
        this.txtComplemento.Enabled = false;
        this.ddlExpedicion.Enabled = false;
        this.ddlAFP.Enabled = false;
        this.txtCUA.Enabled = false;
        this.txtMatricula.Enabled = false;
        this.txtMatriculaGenerada.Enabled = false;
    }

    //Valida datos de entrada
    private bool ValidaDatos()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        if (txtPrimerApellido.Text.Trim() == null || txtPrimerApellido.Text.Trim() == "")
        {
            sDetalleError = "El Primer Apellido es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtPrimerNombre.Text.Trim() == null || txtPrimerNombre.Text.Trim() == "")
        {
            sDetalleError = "El Primer Nombre es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlTipoDocumento.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Tipo Documento es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtNumeroDocumento.Text.Trim() == null || txtNumeroDocumento.Text.Trim() == "" || txtNumeroDocumento.Text.Length < 4)
        {
            sError = "Error al realizar la operación.";
            sDetalleError = "El Número Documento es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlExpedicion.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Expedido es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        if (ddlAFP.SelectedValue.ToString() == "0")
        {
            sDetalleError = "La empresa AFP es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtCUA.Text.Trim() == null || txtCUA.Text.Trim() == "" || txtCUA.Text.Trim() == "0")
        {
            sError = "Error al realizar la operación.";
            sDetalleError = "El NUA es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.txtDescripcion.Text == null || this.txtDescripcion.Text == "")
        {
            sDetalleError = "El Motivo es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        return true;
    }

    //Validar Datos Tramite
    public bool ValidaDatosTramite()
    {
        clsFormatoFecha ObjFormatoFecha;
        string sFechanacimiento;
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        if (this.rblTipoPersonaInicia.SelectedValue == "" || this.rblTipoPersonaInicia.SelectedValue == "0")
        {
            sDetalleError = "El Tipo de Persona quién realiza el trámite es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.rblTipoPersonaInicia.SelectedItem.Text != "TITULAR")
        {
            if (String.IsNullOrEmpty(hdnNupIniciaTramite.Value))
            {
                sDetalleError = "La persona que inicia el trámite es requerida.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            else
            {
                if (hdnNupIniciaTramite.Value == "-1")
                {
                    if (txtPrimerApellidoInicia.Text.Trim() == null || txtPrimerApellidoInicia.Text.Trim() == "")
                    {
                        sDetalleError = "El Primer Apellido es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (txtPrimerNombreInicia.Text.Trim() == null || txtPrimerNombreInicia.Text.Trim() == "")
                    {
                        sDetalleError = "El Primer Nombre es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (ddlTipoDocumentoInicia.SelectedValue.ToString() == "0")
                    {
                        sDetalleError = "El Tipo Documento es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (txtNumeroDocumentoInicia.Text.Trim() == null || txtNumeroDocumentoInicia.Text.Trim() == "" || txtNumeroDocumentoInicia.Text.Length < 4)
                    {
                        sDetalleError = "El Número Documento es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if ((ddlTipoDocumentoInicia.SelectedValue.ToString().Equals(CARNET_IDENTIDAD) || ddlTipoDocumentoInicia.SelectedValue.ToString().Equals(CARNET_EXTRANJERO)) && ddlExpedicionInicia.SelectedValue.ToString() == "0")
                    {
                        sDetalleError = "El Expedido es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (rdblSexoInicia.Text == null || rdblSexoInicia.Text == "")
                    {
                        sDetalleError = "El Sexo es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (this.txtFechaNacimientoInicia.Text == null || this.txtFechaNacimientoInicia.Text == "")
                    {
                        sDetalleError = "El Fecha Nacimiento es requerida.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    ObjFormatoFecha = new clsFormatoFecha();
                    sFechanacimiento = this.txtFechaNacimientoInicia.Text;
                    if (sFechanacimiento != "" && ObjFormatoFecha.VerificaFormatoDMY(sFechanacimiento))
                    {
                        if (Convert.ToDateTime(sFechanacimiento) > DateTime.Now)
                        {
                            sDetalleError = "La Fecha Nacimiento no puede ser mayor a la fecha actual.";
                            Master.MensajeError(sError, sDetalleError);
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    //Validar si es numero
    public static bool IsNumeric(string numeric)
    {
        bool isNumber;
        double isItNumeric;
        isNumber = Double.TryParse(Convert.ToString(numeric), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric);
        return isNumber;
    }

    private void BuscarPersonaInicio(string sNumDoc, string sPrimerNombre, string sPrimerApellido)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        try
        {
            DataTable dtPersona = new DataTable();
            clsPersona objPersona = new clsPersona();
            objPersona.NumeroDocumento = sNumDoc;
            objPersona.PrimerNombre = sPrimerNombre;
            objPersona.PrimerApellido = sPrimerApellido;

            dtPersona = objPersona.BuscarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
            if (dtPersona != null && dtPersona.Rows.Count > 0)
            {
                gvPersonaInicio.DataSource = dtPersona;
                gvPersonaInicio.DataBind();
            }
            else
            {
                gvPersonaInicio.DataSource = null;
                gvPersonaInicio.DataBind();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
    }

    //CARGAR COMBOS INICIA
    private void CargarCombosInicia()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        //Sexo
        DataTable dtSexo = new DataTable();
        dtSexo = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 1, ref sMensajeError);
        if (dtSexo != null && dtSexo.Rows.Count > 0)
        {
            foreach (DataRow row in dtSexo.Rows)
            {
                if (row["IdDetalleClasificador"].ToString().Equals("0"))
                {
                    row.Delete();
                }
            }
            rdblSexoInicia.DataSource = dtSexo;
            rdblSexoInicia.DataTextField = "Descripcion";
            rdblSexoInicia.DataValueField = "IdDetalleClasificador";
            rdblSexoInicia.DataBind();
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        //Estado Civil
        DataTable dtEstadoCivil = new DataTable();
        dtEstadoCivil = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 3, ref sMensajeError);
        if (dtEstadoCivil != null && dtEstadoCivil.Rows.Count > 0)
        {
            ddlEstadoCivilInicia.DataSource = dtEstadoCivil;
            ddlEstadoCivilInicia.DataTextField = "Descripcion";
            ddlEstadoCivilInicia.DataValueField = "IdDetalleClasificador";
            ddlEstadoCivilInicia.DataBind();
            ddlEstadoCivilInicia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlEstadoCivilInicia.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        //TipoDocumento 
        DataTable dtTipoDocumento = new DataTable();
        dtTipoDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 4, ref sMensajeError);
        if (dtTipoDocumento != null && dtTipoDocumento.Rows.Count > 0)
        {
            ddlTipoDocumentoInicia.DataSource = dtTipoDocumento;
            ddlTipoDocumentoInicia.DataTextField = "Descripcion";
            ddlTipoDocumentoInicia.DataValueField = "IdDetalleClasificador";
            ddlTipoDocumentoInicia.DataBind();
            ddlTipoDocumentoInicia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlTipoDocumentoInicia.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        //Expedición Documento
        DataTable dtExpDocumento = new DataTable();
        dtExpDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 9, ref sMensajeError);
        if (dtExpDocumento != null && dtExpDocumento.Rows.Count > 0)
        {
            ddlExpedicionInicia.DataSource = dtExpDocumento;
            ddlExpedicionInicia.DataTextField = "Descripcion";
            ddlExpedicionInicia.DataValueField = "IdDetalleClasificador";
            ddlExpedicionInicia.DataBind();
            ddlExpedicionInicia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlExpedicionInicia.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }

    }

    //GUARDAR TRÁMITE
    private string GuardarTramite()
    {
        string Error = "Error al registrar la empresa";
        /*
        //Datos Empresas
        clsEmpresaPersona objPersonaEmpresa = new clsEmpresaPersona();
        objPersonaEmpresa.iIdConexion = (int)Session["IdConexion"];
        objPersonaEmpresa.cOperacion = "U";
        objPersonaEmpresa.IdTramite = Convert.ToInt64(hfTabla.Value);
        objPersonaEmpresa.idGrupoBeneficio = 3;

        if (MANUAL.Equals(lblTipo.Text))
        {
            objPersonaEmpresa.IdEmpresa = txtRucManual.Text;
            objPersonaEmpresa.NombreEmpresaDeclarada = txtRazonSocialEmpresaManual_Alternativo.Text;
            objPersonaEmpresa.PeriodoInicio = txtFecha_Ingreso.Text;
            objPersonaEmpresa.PeriodoFin = txtFecha_Retiro.Text;
            objPersonaEmpresa.IdSector = Convert.ToInt32(ddlSectorEmpresaManual.SelectedValue);
            objPersonaEmpresa.NroPatronalRucAlt = txtNroPatronal_Ruc_Alternativo.Text;
            objPersonaEmpresa.IdTipoDocSalario = Convert.ToInt32(ddlDocumentoManual.SelectedValue);
            objPersonaEmpresa.IdTipoTramite = 356;
        }
        else
        {
            objPersonaEmpresa.IdEmpresa = txtBuscarRUCAutomatico.Text;
            objPersonaEmpresa.PeriodoInicio = "01/" + Convert.ToString(ddlMesAuto.SelectedValue) + "/" + Convert.ToString(ddlAnioAuto.SelectedValue);
            objPersonaEmpresa.PeriodoFin = null;
            objPersonaEmpresa.IdSector = Convert.ToInt32(hddSectorAuto.Value);
            objPersonaEmpresa.Monto = txtMontoAuto.Text;
            objPersonaEmpresa.IdMoneda = Convert.ToInt32(ddlMonedaAuto.SelectedValue);
            objPersonaEmpresa.IdTipoDocSalario = Convert.ToInt32(ddlDocumentoAuto.SelectedValue);
            objPersonaEmpresa.IdTipoTramite = 357;
            objPersonaEmpresa.Version = 1;
            //objPersonaEmpresa.Componente = this.Componente;
            objPersonaEmpresa.PeriodoSalario = Convert.ToString(ddlMesAuto.SelectedValue) + "/" + Convert.ToString(ddlAnioAuto.SelectedValue);
            objPersonaEmpresa.IdMonedaSalario = Convert.ToInt32(ddlMonedaAuto.SelectedValue);
        }
        objPersonaEmpresa.Motivo = txtDescripcion.Text;
        if (!objPersonaEmpresa.Modificar())
        {
            Master.MensajeError(Error, objPersonaEmpresa.sMensajeError);
        }
         * */
        return hfTabla.Value;
    }


    #endregion

    #region botones

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmModificacionTramite.aspx?Tipo=" + hddTipo.Value);
    }

    //Grabar Tramite
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            string IdTramite = "";
            if (ValidaDatos())
            {
                IdTramite = GuardarTramite();
                this.lblCompletarInformacion.Visible = true;
                if (IsNumeric(IdTramite))
                {
                    HiddenIdtramite.Value = IdTramite.ToString();
                    this.lblCompletarInformacion.Text = "Se ha modificado correctamente el trámite: " + IdTramite.ToString();
                    this.btnIniciarTramite.Visible = false;
                    this.btnCancelar.Text = "Volver";
                    this.btnReporte.Visible = true;
                    this.btnReporte.OnClientClick = "window.open('wfrmReport.aspx?tramite=" + IdTramite.ToString() + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
                    this.btnForm02.Visible = true;
                    this.btnForm02.OnClientClick = "window.open('wfrmReportForm02.aspx?tramite=" + IdTramite.ToString() + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";

                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                }
                else
                {
                    this.lblCompletarInformacion.Text = IdTramite.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }
    }

    #endregion

    #region iniciotramite

    protected void rblTipoPersonaInicia_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.hdnNupIniciaTramite.Value = null;
        this.txtPrimerApellidoInicia.Text = null;
        this.txtSegundoApellidoInicia.Text = null;
        this.txtPrimerNombreInicia.Text = null;
        this.txtSegundoNombreInicia.Text = null;
        this.txtApellidoCasadaInicia.Text = null;
        this.txtNumeroDocumentoInicia.Text = null;
        this.txtFechaNacimientoInicia.Text = null;
        this.ddlTipoDocumentoInicia.SelectedValue = null;
        this.ddlExpedicionInicia.SelectedValue = null;
        this.rdblSexoInicia.SelectedValue = null;
        this.ddlEstadoCivilInicia.SelectedValue = null;
        this.pnlNuevaPersona.Visible = false;
        if (this.rblTipoPersonaInicia.SelectedItem.Text == "TITULAR")
        {
            this.lblNombreCompleto.Visible = false;
            this.txtNombreCompeto.Visible = false;
            this.btnBuscarTramitador.Visible = false;
        }
        else
        {
            this.lblNombreCompleto.Visible = true;
            this.txtNombreCompeto.Visible = true;
            this.btnBuscarTramitador.Visible = true;
        }

    }

    //Buscar tramitador en persona
    protected void btnBuscarTramitador_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusNumDoc.Text = txtNombreCompeto.Text;
        this.txtBusNombre.Text = "";
        this.txtBusApellido.Text = "";
        //BuscarPersonaInicio(this.txtBusNumDoc.Text, "", "");
        gvPersonaInicio.Visible = true;
        gvPersonaInicio.DataSource = null;
        gvPersonaInicio.DataBind();
        ModalPopupExtender1.Show();
    }

    //MOSTRAR PANEL DE NUEVA PERSONA
    protected void btnNuevaPersona_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        this.pnlNuevaPersona.Visible = true;
        this.txtNumeroDocumentoInicia.Text = null;
        this.txtNumeroDocumentoInicia.Enabled = true;
        this.txtPrimerApellidoInicia.Text = null;
        this.txtPrimerApellidoInicia.Enabled = true;
        this.txtSegundoApellidoInicia.Text = null;
        this.txtSegundoApellidoInicia.Enabled = true;
        this.txtPrimerNombreInicia.Text = null;
        this.txtPrimerNombreInicia.Enabled = true;
        this.txtSegundoNombreInicia.Text = null;
        this.txtSegundoNombreInicia.Enabled = true;
        this.txtApellidoCasadaInicia.Text = null;
        this.txtApellidoCasadaInicia.Enabled = true;
        this.ddlEstadoCivilInicia.SelectedValue = null;
        this.ddlEstadoCivilInicia.Enabled = true;
        this.txtComplementoInicia.Text = null;
        this.txtComplementoInicia.Enabled = true;
        this.ddlTipoDocumentoInicia.SelectedValue = null;
        this.ddlTipoDocumentoInicia.Enabled = true;
        this.ddlExpedicionInicia.SelectedValue = null;
        this.ddlExpedicionInicia.Enabled = true;
        this.txtFechaNacimientoInicia.Text = null;
        this.txtFechaNacimientoInicia.Enabled = true;
        this.rdblSexoInicia.SelectedValue = null;
        this.rdblSexoInicia.Enabled = true;
        CargarCombosInicia();
        this.hdnNupIniciaTramite.Value = "-1";
        this.txtPrimerApellidoInicia.Focus();
    }

    protected void ddlTipoDocumentoInicia_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sTipoDocumento = ddlTipoDocumentoInicia.SelectedValue;
        clsTramite ObjTramite = new clsTramite();
        ddlExpedicionInicia.ClearSelection();
        ddlExpedicionInicia.DataSource = null;
        ddlExpedicionInicia.DataBind();
        if (ddlTipoDocumentoInicia.SelectedValue.Equals(CARNET_IDENTIDAD) || ddlTipoDocumentoInicia.SelectedValue.Equals(CARNET_EXTRANJERO))
        {
            ddlExpedicionInicia.Enabled = true;
            //Expedición Documento
            DataTable dtExpDocumento = new DataTable();
            dtExpDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 9, ref sMensajeError);
            if (dtExpDocumento != null && dtExpDocumento.Rows.Count > 0)
            {
                foreach (DataRow row in dtExpDocumento.Rows)
                {
                    if (sTipoDocumento.Equals(CARNET_IDENTIDAD))
                    {
                        if (row["IdDetalleClasificador"].ToString().Equals(EXPEDIDO_EXTRANJERO))
                        {
                            row.Delete();
                        }
                    }
                    else if (sTipoDocumento.Equals(CARNET_EXTRANJERO))
                    {
                        if (!row["IdDetalleClasificador"].ToString().Equals(EXPEDIDO_EXTRANJERO))
                        {
                            row.Delete();
                        }
                    }
                }
                ddlExpedicionInicia.DataSource = dtExpDocumento;
                ddlExpedicionInicia.DataTextField = "Descripcion";
                ddlExpedicionInicia.DataValueField = "IdDetalleClasificador";
                ddlExpedicionInicia.DataBind();
                ddlExpedicionInicia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlExpedicionInicia.SelectedValue = "0";
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            ddlExpedicionInicia.Enabled = false;
        }
    }

    #endregion

    #region grilla persona

    protected void btnBusPersona_Click(object sender, EventArgs e)
    {
        BuscarPersonaInicio(this.txtBusNumDoc.Text, this.txtBusNombre.Text, this.txtBusApellido.Text);
        ModalPopupExtender1.Show();
    }

    protected void gvPersonaInicio_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvPersonaInicio = (GridView)sender;
        gvPersonaInicio.PageIndex = e.NewSelectedIndex;
        gvPersonaInicio.DataBind();
        ModalPopupExtender1.Show();
    }

    protected void gvPersonaInicio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersonaInicio.PageIndex = e.NewPageIndex;
        BuscarPersonaInicio(this.txtBusNumDoc.Text, this.txtBusNombre.Text, this.txtBusApellido.Text);
        ModalPopupExtender1.Show();
    }

    protected void gvPersonaInicio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        clsFormatoFecha f = new clsFormatoFecha();
        try
        {
            int Index;
            if (e.CommandName == "cmdPersona")
            {
                Index = Convert.ToInt32(e.CommandArgument);
                CargarCombosInicia();
                this.pnlNuevaPersona.Visible = true;
                this.hdnNupIniciaTramite.Value = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["NUP"]);

                this.txtNumeroDocumentoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["NumeroDocumento"]);
                this.txtNumeroDocumentoInicia.Enabled = false;
                this.txtPrimerApellidoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["PrimerApellido"]);
                this.txtPrimerApellidoInicia.Enabled = false;

                this.txtSegundoApellidoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["SegundoApellido"]);
                this.txtSegundoApellidoInicia.Enabled = false;

                this.txtPrimerNombreInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["PrimerNombre"]);
                this.txtPrimerNombreInicia.Enabled = false;

                this.txtSegundoNombreInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["SegundoNombre"]);
                this.txtSegundoNombreInicia.Enabled = false;

                this.txtApellidoCasadaInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["ApellidoCasada"]);
                this.txtApellidoCasadaInicia.Enabled = false;

                this.ddlEstadoCivilInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdEstadoCivil"]);
                this.ddlEstadoCivilInicia.Enabled = false;

                this.txtComplementoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["ComplementoSEGIP"]);
                this.txtComplementoInicia.Enabled = false;

                this.ddlTipoDocumentoInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdTipoDocumento"]);
                this.ddlTipoDocumentoInicia.Enabled = false;

                this.ddlExpedicionInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdDocumentoExpedido"]);
                this.ddlExpedicionInicia.Enabled = false;

                this.txtFechaNacimientoInicia.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["FechaNacimiento"])));
                this.txtFechaNacimientoInicia.Enabled = false;



                this.rdblSexoInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdSexo"]);
                this.rdblSexoInicia.Enabled = false;

                this.gvPersonaInicio.Visible = false;
                ModalPopupExtender1.Hide();
                //this.btnSiguienteTramite.Focus();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
    }

    #endregion
}