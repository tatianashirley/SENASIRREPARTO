
using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_ModificarDatosApoderado : System.Web.UI.Page
{
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
            lblSubTitulo.Text = "Modificar Datos";

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
            lblTituloSistema.Text = "MODULO MODIFICACION DATOS APODERADO";
            txtFechaNacimiento.Enabled = true;
            imgcalendarioIni.Enabled = true;

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
                CargarExpedicionDocumento();
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
        this.hfTabla.Value = Tabla;
    }

    //Buscar Tramites
    protected void CargarDatosTramite()
    {
        DataTable dtListaPersonas = null;
        clsPoderNotariado objTramite = new clsPoderNotariado();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt64(this.hfTabla.Value);
        objTramite.IdGrupoBeneficio = 3;
        if (objTramite.Obtener())
        {
            dtListaPersonas = objTramite.DSetTmp.Tables[0];
            DataRow row = dtListaPersonas.Rows[0];
            ddlExpedicion.SelectedValue = Convert.ToString(row["IdDocumentoExpedido"]);
            txtCelular.Text = Convert.ToString(row["Celular"]);
            txtCelular2.Text = Convert.ToString(row["CelularReferencia"]);
            txtTelefono.Text = Convert.ToString(row["Telefono"]);
            //txtEmail.Text = Convert.ToString(row["CorreoElectronico"]);
            txtDireccion.Text = Convert.ToString(row["Direccion"]);
            txtPoderNotarial.Text = Convert.ToString(row["NumeroPoderNotarial"]);
            txtAdministracionPoder.Text = Convert.ToString(row["Administracion"]);
            txtVigenciaPoderDel.Text = clsFormatoFecha.FechaText(Convert.ToString(row["PeriodoInicio"]));
            txtVigenciaPoderAl.Text = clsFormatoFecha.FechaText(Convert.ToString(row["PeriodoFinal"]));
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

    //INHABILITAR DATOS PERSONALES.
    private void InhabilitarDatosPersonales()
    {
        this.txtPrimerNombre.Enabled = false;
        this.txtSegundoNombre.Enabled = false;
        this.txtPrimerApellido.Enabled = false;
        this.txtSegundoApellido.Enabled = false;
        this.txtApellidoCasada.Enabled = false;
        this.txtNumeroDocumento.Enabled = false;
        this.txtComplemento.Enabled = false;
        this.ddlExpedicion.Enabled = false;
        this.txtFechaNacimiento.Enabled = false;
    }

    //HABILITAR DATOS PERSONALES.
    private void HabilitarDatosPersonales()
    {
        this.txtPrimerNombre.Enabled = true;
        this.txtSegundoNombre.Enabled = true;
        this.txtPrimerApellido.Enabled = true;
        this.txtSegundoApellido.Enabled = true;
        this.txtApellidoCasada.Enabled = true;
        this.txtNumeroDocumento.Enabled = true;
        this.txtComplemento.Enabled = true;
        this.ddlExpedicion.Enabled = true;
        this.txtFechaNacimiento.Enabled = true;
    }

    //Valida datos de entrada
    private bool ValidaDatos()
    {
        clsFormatoFecha ObjFormatoFecha;
        string sFechanacimiento;
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
        }

        if (this.txtDescripcion.Text == null || this.txtDescripcion.Text == "")
        {
            sDetalleError = "El Motivo es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.txtPoderNotarial.Text.Trim() == null || txtPoderNotarial.Text.Trim() == "")
        {
            sDetalleError = "El Nro. Poder Notarial es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.txtVigenciaPoderDel.Text.Trim() == null || txtVigenciaPoderDel.Text.Trim() == "")
        {
            sDetalleError = "La Vigencia del Poder es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        return true;
    }



    //Validar datos residencia
    public bool ValidaDatosResidencia()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
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
    private bool GuardarTramite()
    {
        clsPoderNotariado objPoderNotariado;
        bool conError = false;
        string Error = "Error al realizar la operación";
        string DetalleError = "";
        //Datos Persona
        objPoderNotariado = ObtenerDatosPoder(Convert.ToInt64(this.hfTabla.Value));
        objPoderNotariado.iIdConexion = (int)Session["IdConexion"];
        objPoderNotariado.cOperacion = "U";

        if (!objPoderNotariado.Actualizar())
        {
            conError = true;
            DetalleError = Convert.ToString(objPoderNotariado.sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        return !conError;
    }

    //Obtener datos poder notariado
    private clsPoderNotariado ObtenerDatosPoder(long IdTramite)
    {
        clsPoderNotariado PoderNotariado = new clsPoderNotariado();

        clsFormatoFecha f = new clsFormatoFecha();
        PoderNotariado.NumeroDocumento = this.txtNumeroDocumento.Text;
        PoderNotariado.ComplementoSEGIP = this.txtComplemento.Text;
        PoderNotariado.DocumentoExpedido = Convert.ToInt32(this.ddlExpedicion.SelectedValue);
        PoderNotariado.PrimerNombre = this.txtPrimerNombre.Text;
        PoderNotariado.SegundoNombres = this.txtSegundoNombre.Text;
        PoderNotariado.PrimerApellido = this.txtPrimerApellido.Text;
        PoderNotariado.SegundoApellido = this.txtSegundoApellido.Text;
        PoderNotariado.ApellidoCasada = this.txtApellidoCasada.Text;
        PoderNotariado.IdPaisResidencia = 83;
        PoderNotariado.Celular = this.txtCelular.Text;
        PoderNotariado.CelularReferencia = this.txtCelular2.Text;
        PoderNotariado.Direccion = this.txtDireccion.Text;
        PoderNotariado.Telefono = this.txtTelefono.Text;
        PoderNotariado.NroPoder = Convert.ToInt16(this.txtPoderNotarial.Text);
        PoderNotariado.Administracion = this.txtAdministracionPoder.Text;
        PoderNotariado.VigenciaDesde = this.txtVigenciaPoderDel.Text;
        PoderNotariado.VigenciaHasta = this.txtVigenciaPoderAl.Text;
        PoderNotariado.IdTramite = IdTramite;
        PoderNotariado.IdGrupoBeneficio = 3;
        PoderNotariado.Observacion = this.txtDescripcion.Text;
        return PoderNotariado;
    }

    #endregion

    #region botones


    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmModificacionApoderado.aspx");
    }

    //Guardar Tramite
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            string IdTramite = "";
            if (ValidaDatos() && ValidaDatosResidencia())
            {
                if (GuardarTramite())
                {
                    this.lblCompletarInformacion.Visible = true;
                    HiddenIdtramite.Value = IdTramite.ToString();
                    this.lblCompletarInformacion.Text = "Se ha modificado correctamente el trámite: " + IdTramite.ToString();
                    this.btnIniciarTramite.Visible = false;
                    this.btnCancelar.Text = "Volver";
                    this.btnReportePoder.Visible = true;

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


    //Reporte
    protected void btnReportePoder_Click(object sender, EventArgs e)
    {
        Session["IdTramite"] = this.hfTabla.Value;
        Session["TipoReporte"] = "PODER";
        //Response.Redirect("wfrmReportTramite.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReportTramite.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }

    #endregion
    
}