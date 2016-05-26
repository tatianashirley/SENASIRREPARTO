
using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_ModificarDatos : System.Web.UI.Page
{
    #region constantes

    private const string MOD_DATOS_PERSONALES = "MP";
    private const string MOD_FECHAS = "MF";
    private const string MOD_SALARIO = "MS";
    private const string MOD_EMPRESAS = "ME";
    private const string MOD_FFAA = "MR";
    private const string MOD_OFICINA = "MO";

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
            lblSubTitulo.Text = "Modificar Datos Persona";

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
            if (MOD_DATOS_PERSONALES.Equals(queryStringTipoBus))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION DATOS PERSONALES";
                txtFechaNacimiento.Enabled = false;
                txtFechaFallecimient.Enabled = false;
                txtCUA.Enabled = false;
                txtMatricula.Enabled = false;
                imgcalendarioIni.Enabled = false;
                btncalendarff.Enabled = false;
            }
            else if (MOD_FECHAS.Equals(queryStringTipoBus))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION FECHAS";
                txtFechaNacimiento.Enabled = true;
                txtFechaFallecimient.Enabled = true;
                txtCUA.Enabled = false;
                txtMatricula.Enabled = false;
                txtPrimerApellido.Enabled = false;
                txtSegundoApellido.Enabled = false;
                txtApellidoCasada.Enabled = false;
                txtPrimerNombre.Enabled = false;
                txtSegundoNombre.Enabled = false;
                ddlTipoDocumento.Enabled = false;
                txtNumeroDocumento.Enabled = false;
                txtComplemento.Enabled = false;
                ddlExpedicion.Enabled = false;
                rblSexo.Enabled = false;
                ddlEstadoCivil.Enabled = false;
                ddlAFP.Enabled = false;
                txtPais.Enabled = false;
                txtBuscarLocalidad.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
                txtCelular.Enabled = false;
                txtCelular2.Enabled = false;
                txtEmail.Enabled = false;
                ibtnBuscarLocalidad.Enabled = false;
            }
            else if (MOD_FFAA.Equals(queryStringTipoBus))
            {
                lblTituloSistema.Text = "MODULO MODIFICACION FFAA";
                txtFechaNacimiento.Enabled = false;
                txtFechaFallecimient.Enabled = false;
                txtCUA.Enabled = false;
                txtMatricula.Enabled = false;
                imgcalendarioIni.Enabled = false;
                btncalendarff.Enabled = false;
            }

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
                txtNroTramite.Text = Tabla;
                //cargar datos en pantalla
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, Defuncion, CUA, CI, Complemento, Tabla);
                CargarSexo();
                CargarEstadoCivil();
                CargarTipoDocumento();
                CargarExpedicionDocumento();
                CargarEntidadAseguradora();
                CargarDatosTramite();
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
        if (!pnlDatosResidencia.Visible)
        {
            ibtnOpenCloseDatosResidencia.ImageUrl = "~/Imagenes/16quitar.png";
            pnlDatosResidencia.Visible = true;
        }
        else
        {
            ibtnOpenCloseDatosResidencia.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlDatosResidencia.Visible = false;
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
        this.txtFechaNacimiento.Text = f.Fecha(f.GeneraFechaDMY(Nacimiento));
        this.txtFechaFallecimient.Text = f.Fecha(f.GeneraFechaDMY(Defuncion));
        this.hfTabla.Value = Tabla;
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
        if (MOD_FFAA.Equals(hddTipo.Value))
        {
            dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, 3, null, null, null, null, null, null, null, "FFAA", ref sMensajeError);
        }
        else
        {
            dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, 3, null, null, null, null, null, null, null, "Modificacion", ref sMensajeError);
        }
        DataRow row = dtListaPersonas.Rows[0];
        ddlTipoDocumento.SelectedValue = Convert.ToString(row["idDocumento"]);
        ddlExpedicion.SelectedValue = Convert.ToString(row["IdDocExpedicion"]);
        ddlEstadoCivil.SelectedValue = Convert.ToString(row["IdEstadoCivil"]);
        ddlAFP.SelectedValue = Convert.ToString(row["IdEntidadGestora"]);
        rblSexo.SelectedValue = Convert.ToString(row["IdSexo"]);
        txtCelular.Text = Convert.ToString(row["Celular"]);
        txtCelular2.Text = Convert.ToString(row["CelularReferencia"]);
        txtTelefono.Text = Convert.ToString(row["Telefono"]);
        txtEmail.Text = Convert.ToString(row["CorreoElectronico"]);
        txtDireccion.Text = Convert.ToString(row["Direccion"]);
        hdnIdLocalidad.Value = Convert.ToString(row["CodigoLocalidad"]);
        txtBuscarLocalidad.Text = Convert.ToString(row["NombreLocalidad"]);
    }

    //Combo sexo
    private void CargarSexo()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
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
            rblSexo.DataSource = dtSexo;
            rblSexo.DataTextField = "Descripcion";
            rblSexo.DataValueField = "IdDetalleClasificador";
            rblSexo.DataBind();
            //rblSexo.Items.RemoveAt(2);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Combo estado civil
    private void CargarEstadoCivil()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtEstadoCivil = new DataTable();
        dtEstadoCivil = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 3, ref sMensajeError);
        if (dtEstadoCivil != null && dtEstadoCivil.Rows.Count > 0)
        {
            ddlEstadoCivil.DataSource = dtEstadoCivil;
            ddlEstadoCivil.DataTextField = "Descripcion";
            ddlEstadoCivil.DataValueField = "IdDetalleClasificador";
            ddlEstadoCivil.DataBind();
            ddlEstadoCivil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlEstadoCivil.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
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
        this.rblSexo.Enabled = false;
        this.ddlEstadoCivil.Enabled = false;
        this.ddlTipoDocumento.Enabled = false;
        this.txtNumeroDocumento.Enabled = false;
        this.txtComplemento.Enabled = false;
        this.ddlExpedicion.Enabled = false;
        this.txtFechaNacimiento.Enabled = false;
        this.txtFechaFallecimient.Enabled = false;
        this.ddlAFP.Enabled = false;
        this.txtCUA.Enabled = false;
        this.txtMatricula.Enabled = false;
        this.txtMatriculaGenerada.Enabled = false;
    }

    //HABILITAR DATOS PERSONALES.
    private void HabilitarDatosPersonales()
    {
        this.txtPrimerNombre.Enabled = true;
        this.txtSegundoNombre.Enabled = true;
        this.txtPrimerApellido.Enabled = true;
        this.txtSegundoApellido.Enabled = true;
        this.txtApellidoCasada.Enabled = true;
        this.rblSexo.Enabled = true;
        this.ddlEstadoCivil.Enabled = true;
        this.ddlTipoDocumento.Enabled = true;
        this.txtNumeroDocumento.Enabled = true;
        this.txtComplemento.Enabled = true;
        this.ddlExpedicion.Enabled = true;
        this.txtFechaNacimiento.Enabled = true;
        this.txtFechaFallecimient.Enabled = true;
        this.txtCUA.Enabled = true;
        this.txtMatricula.Enabled = true;
        this.txtMatriculaGenerada.Enabled = true;
    }

    //Valida datos de entrada
    private bool ValidaDatos()
    {
        clsFormatoFecha ObjFormatoFecha;
        string sFechanacimiento;
        string sFechafallecimiento;
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        if (MOD_DATOS_PERSONALES.Equals(hddTipo.Value) || MOD_FFAA.Equals(hddTipo.Value))
        {
            //Validar apellidos
            if (String.IsNullOrEmpty(this.txtPrimerApellido.Text.Trim()) && String.IsNullOrEmpty(this.txtSegundoApellido.Text.Trim()))
            {
                sDetalleError = "El Primer o Segundo Apellido es requerido.";
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
            if (rblSexo.Text == null || rblSexo.Text == "")
            {
                sDetalleError = "El Sexo es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            
            if (ddlEstadoCivil.SelectedValue.ToString() == "0")
            {
                sDetalleError = "El Estado Civil es requerido.";
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
        }
        else if (MOD_FECHAS.Equals(hddTipo.Value))
        {
            if (this.txtFechaNacimiento.Text == null || this.txtFechaNacimiento.Text == "")
            {
                sDetalleError = "El Fecha Nacimiento es requerida.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            ObjFormatoFecha = new clsFormatoFecha();
            sFechanacimiento = this.txtFechaNacimiento.Text;
            if (sFechanacimiento != "" && ObjFormatoFecha.VerificaFormatoDMY(sFechanacimiento))
            {
                if (Convert.ToDateTime(sFechanacimiento) > DateTime.Now)
                {
                    sDetalleError = "La Fecha Nacimiento no puede ser mayor a la fecha actual.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
                sFechafallecimiento = this.txtFechaFallecimient.Text;
                if (sFechafallecimiento != "" && ObjFormatoFecha.VerificaFormatoDMY(sFechafallecimiento))
                {
                    if (Convert.ToDateTime(sFechafallecimiento) > DateTime.Now)
                    {
                        sDetalleError = "La Fecha Defunción no puede ser mayor a la fecha actual.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (Convert.ToDateTime(sFechanacimiento) > Convert.ToDateTime(sFechafallecimiento))
                    {
                        sDetalleError = "La Fecha Nacimiento no puede ser mayor a la Fecha Defunción.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
                else
                {
                    if (sFechafallecimiento != "" && !ObjFormatoFecha.VerificaFormatoDMY(sFechafallecimiento))
                    {
                        sDetalleError = "La Fecha Defunción no es válida.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
            }
        }
        if (this.txtDescripcion.Text == null || this.txtDescripcion.Text == "")
        {
            sDetalleError = "El Motivo es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        return true;
    }

    //Generar Matricula
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

    //Listar Localidad
    private void BuscarLocalidad(string sLocalidad)
    {
        string sError;
        string sDetalleError;
        DataTable dtLocalidad;
        clsTramite ObjTramite;
        try
        {
            if (!String.IsNullOrEmpty(sLocalidad))
            {
                ObjTramite = new clsTramite();
                ObjTramite.iIdConexion = (int)Session["IdConexion"];
                ObjTramite.cOperacion = "Q";
                ObjTramite.Localidad = sLocalidad;
                dtLocalidad = ObjTramite.BuscarLocalidades();
                if (dtLocalidad != null && dtLocalidad.Rows.Count > 0)
                {
                    gvGeo.DataSource = dtLocalidad;
                    gvGeo.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            sError = "Error al realizar la operación.";
            sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
    }

    //Verificar Paises
    private bool VerificarPaises()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        //Sexo
        DataTable dtClasificador = new DataTable();
        dtClasificador = ObjTramite.ObtenerClasificadorPorDescripcion(iIdConexion, cOperacion, 10, this.txtPais.Text, ref sMensajeError);

        if (dtClasificador != null && dtClasificador.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Validar datos residencia
    public bool ValidaDatosResidencia()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        if (this.txtPais.Text.Trim() == null || txtPais.Text.Trim() == "")
        {
            sDetalleError = "El País es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        else
        {
            if (!VerificarPaises())
            {
                sDetalleError = "El País no es válido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (this.txtBuscarLocalidad.Text.Trim() == null || txtBuscarLocalidad.Text.Trim() == "")
        {
            sDetalleError = "La Localidad es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.txtDireccion.Text.Trim() == null || txtDireccion.Text.Trim() == "")
        {
            sDetalleError = "La Dirección es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.txtTelefono.Text.Trim() != null && this.txtTelefono.Text.Trim() != "")
        {
            if (this.txtTelefono.Text.Length < 7)
            {
                sDetalleError = "El Teléfono Fijo no es válido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (this.txtCelular.Text.Trim() != null && this.txtCelular.Text.Trim() != "")
        {
            if (this.txtCelular.Text.Length < 8 || !(this.txtCelular.Text.Substring(0).Contains("6")
                || this.txtCelular.Text.Substring(0).Contains("7"))
                )
            {
                sDetalleError = "El Teléfono Celular no es válido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (this.txtEmail.Text.Trim() != null && this.txtEmail.Text.Trim() != "")
        {
            try
            {
                MailAddress email = new MailAddress(this.txtEmail.Text);
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
                sDetalleError = "El E-MAIL no es válido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (this.txtCelular2.Text.Trim() != null && this.txtCelular2.Text.Trim() != "")
        {
            if (this.txtCelular2.Text.Length < 8 || !(this.txtCelular2.Text.Substring(0).Contains("6")
                || this.txtCelular2.Text.Substring(0).Contains("7"))
                )
            {
                sDetalleError = "El Teléfono Referencia no es válido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (this.txtTelefono.Text.Trim() == null || this.txtTelefono.Text.Trim() == "")
        {
            if (this.txtCelular.Text.Trim() == null || this.txtCelular.Text.Trim() == "")
            {
                if (this.txtCelular2.Text.Trim() == null || this.txtCelular2.Text.Trim() == "")
                {
                    sDetalleError = "El Teléfono Fijo o el Teléfono Celular o el Teléfono Referencia es requerido.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
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

    //GUARDAR TRÁMITE
    private string GuardarTramite()
    {
        clsPersona objPersona;
        long NUP = 0;
        string res = "not";
        string Error = "Error al realizar la operación";
        string sMensajeError = "";
        string DetalleError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion;
        if (MOD_DATOS_PERSONALES.Equals(hddTipo.Value) || MOD_FFAA.Equals(hddTipo.Value))
        {
            cOperacion = "U";
        }
        else
        {
            cOperacion = "F";
        }
        //Datos Persona
        objPersona = ObtenerDatosPersona();
        NUP = objPersona.RegistrarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
        if (NUP != 0)
        {
            res = hfTabla.Value;
        }
        else
        {
            DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        return res;
    }

    //Obtener datos persona
    private clsPersona ObtenerDatosPersona()
    {
        string sMatriculaGenerada;
        clsPersona Persona = new clsPersona();
        clsFormatoFecha f = new clsFormatoFecha();
        Persona.NUP = Convert.ToInt64(hfNUP.Value);
        Persona.IdTipoDocumento = Convert.ToInt16(this.ddlTipoDocumento.SelectedValue);
        Persona.IdEstadoCivil = Convert.ToInt16(this.ddlEstadoCivil.SelectedValue);
        Persona.IdEntidadGestora = Convert.ToInt32(ddlAFP.SelectedValue.ToString());
        Persona.IdSexo = Convert.ToInt16(this.rblSexo.SelectedValue);
        Persona.IdEstado = 1;
        Persona.CUA = Convert.ToInt64(this.txtCUA.Text);

        sMatriculaGenerada = GenerarMatricula(this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtPrimerNombre.Text, (new clsFormatoFecha()).GeneraFechaDMY(this.txtFechaNacimiento.Text), rblSexo.Text);
        txtMatricula.Text = sMatriculaGenerada;
        Persona.Matricula = sMatriculaGenerada;
        Persona.NUB = 0;
        Persona.NumeroDocumento = this.txtNumeroDocumento.Text;
        Persona.ComplementoSEGIP = this.txtComplemento.Text;
        Persona.DocumentoExpedido = Convert.ToInt32(this.ddlExpedicion.SelectedValue);
        Persona.PrimerNombre = this.txtPrimerNombre.Text;
        Persona.SegundoNombres = this.txtSegundoNombre.Text;
        Persona.PrimerApellido = this.txtPrimerApellido.Text;
        Persona.SegundoApellido = this.txtSegundoApellido.Text;
        Persona.ApellidoCasada = this.txtApellidoCasada.Text;
        Persona.FechaNacimiento = f.GeneraFechaDMY(this.txtFechaNacimiento.Text);
        Persona.FechaFallecimiento = f.GeneraFechaDMY(this.txtFechaFallecimient.Text);
        //Encuentra id de pais
        Persona.IdPaisResidencia = 83;
        //int IdPaisResidencia = c.EncontrarIdPorDescripcion(this.txtPais.Text, 10);
        Persona.CorreoElectronico = this.txtEmail.Text;
        Persona.Celular = this.txtCelular.Text;
        Persona.CelularReferencia = this.txtCelular2.Text;
        Persona.Direccion = this.txtDireccion.Text;
        if (this.hdnIdLocalidad.Value != "")
            Persona.IdLocalidad = Convert.ToInt16(this.hdnIdLocalidad.Value);
        else
            Persona.IdLocalidad = 0;
        Persona.Telefono = this.txtTelefono.Text; ;
        Persona.RegistroActivo = 1;
        Persona.motivo = txtDescripcion.Text;
        return Persona;
    }

    #endregion

    #region botones

    //Buscar localidad
    protected void ibtnBuscarLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusLocalidad.Text = this.txtBuscarLocalidad.Text;
        BuscarLocalidad(this.txtBuscarLocalidad.Text);
        this.gvGeo.Visible = true;
        ModalPopupExtender_LOCALIDAD.Show();
    }

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmModificacionTramite.aspx?Tipo=" + hddTipo.Value);
    }

    //Guardar Tramite
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            string IdTramite = "";
            if (ValidaDatos() && ValidaDatosResidencia())
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

    #region grilla localidades

    protected void btnCancelLocalidad_Click(object sender, EventArgs e)
    {
        this.gvGeo.Visible = false;
        this.txtBuscarLocalidad.Focus();
    }

    protected void btnBusLocalidad_Click(object sender, EventArgs e)
    {
        BuscarLocalidad(this.txtBusLocalidad.Text);
        ModalPopupExtender_LOCALIDAD.Show();
    }

    protected void gvGeo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGeo.PageIndex = e.NewPageIndex;
        BuscarLocalidad(this.txtBusLocalidad.Text);
        ModalPopupExtender_LOCALIDAD.Show();
    }

    protected void gvGeo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvGeo = (GridView)sender;
        gvGeo.PageIndex = e.NewSelectedIndex;
        gvGeo.DataBind();
        ModalPopupExtender_LOCALIDAD.Show();
    }

    protected void gvGeo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdLocalidad")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            this.hdnIdLocalidad.Value = Convert.ToString(gvGeo.DataKeys[Index].Values["CodigoLocalidad"]);
            this.txtBuscarLocalidad.Text = Convert.ToString(gvGeo.DataKeys[Index].Values["NombreLocalidad"]);
            this.gvGeo.Visible = false;
            this.txtBuscarLocalidad.Focus();
            ModalPopupExtender_LOCALIDAD.Hide();
        }
    }

    #endregion

}