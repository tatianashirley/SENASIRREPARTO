
using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_ModificarDatosOficina : System.Web.UI.Page
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
            lblTituloSistema.Text = "MODULO MODIFICACION OFICINA NOTIFICACION";
            lblSubTitulo.Text = "Modificar Datos Notificación";

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
                CargarOficina();
                CargarDatosTramite();
                CargarDatosOficina();
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

    //Combo Oficina Notificacion
    private void CargarOficina()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtOficina = new DataTable();
        dtOficina = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "OficinaNotif", ref sMensajeError);
        if (dtOficina != null && dtOficina.Rows.Count > 0)
        {
            ddlOficinaNotificacion.DataSource = dtOficina;
            ddlOficinaNotificacion.DataTextField = "DescripcionNotificacion";
            ddlOficinaNotificacion.DataValueField = "IdOficina";
            ddlOficinaNotificacion.DataBind();
            ddlOficinaNotificacion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlOficinaNotificacion.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Buscar Tramites
    protected void CargarDatosOficina()
    {
        DataTable dtInicioTramite;
        clsTramite objTramite = new clsTramite();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt32(this.hfTabla.Value);
        objTramite.IdGrupoBeneficio = 3;
        dtInicioTramite = objTramite.ObtenerInicioTramite();
        if (dtInicioTramite != null && dtInicioTramite.Rows.Count > 0)
        {
            DataRow row = dtInicioTramite.Rows[0];
            ddlOficinaNotificacion.SelectedValue = Convert.ToString(row["IdOficinaNotificacion"]);
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

    //Validar si es numero
    public static bool IsNumeric(string numeric)
    {
        bool isNumber;
        double isItNumeric;
        isNumber = Double.TryParse(Convert.ToString(numeric), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric);
        return isNumber;
    }

    //GUARDAR TRÁMITE
    private string GuardarTramite()
    {
        string Error = "Error en la modificación";
        clsTramite objTramite = new clsTramite();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "U";
        objTramite.IdTramite = Convert.ToInt32(this.hfTabla.Value);
        objTramite.IdGrupoBeneficio = 3;
        objTramite.IdOficinaNotificacion = Convert.ToInt16(ddlOficinaNotificacion.SelectedValue);
        objTramite.Observaciones = txtDescripcion.Text;
        if (!objTramite.ModificarOficinaNotificacion())
        {
            Master.MensajeError(Error, objTramite.sMensajeError);
        }
        return this.hfTabla.Value;
    }


    #endregion

    #region botones

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmModificacionTramite.aspx?Tipo=" + hddTipo.Value);
    }

    //Grabar el tramite
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


}