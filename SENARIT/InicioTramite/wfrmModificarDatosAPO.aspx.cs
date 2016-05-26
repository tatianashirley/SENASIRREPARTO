
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_ModificarDatosAPO : System.Web.UI.Page
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
        string queryStringCUA;
        string queryStringCI;
        string queryStringComplemento;
        string queryStringTabla;

        string Tipo = "";
        string NUPString = "";
        string Matricula = "";
        string Nombre = "";
        string SegundoNombre = "";
        string Paterno = "";
        string Materno = "";
        string Casada = "";
        string Nacimiento = "";
        string CUA = "";
        string CI = "";
        string Complemento = "";
        string Tabla = "";

        clsFuncionesGenerales encriptar;

        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "MODULO INICIO TRÁMITE";
            lblSubTitulo.Text = "Datos Persona";

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

            encriptar = new clsFuncionesGenerales();
            if (queryStringTipo != "")
            {
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
                    clsFormatoFecha f = new clsFormatoFecha();
                    DateTime d = f.GeneraFechaDMY(Nacimiento);
                    Nacimiento = f.Fecha(d);
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
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla);
                CargarSexo();
                CargarEstadoCivil();
                CargarTipoDocumento();
                CargarExpedicionDocumento();
                CargarEntidadAseguradora();
                CargarDatosPersona();
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

    #endregion

    #region funciones

    //CARGA LOS DATOS OBTENIDOS EN EL LISTADO ANTERIOR
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla)
    {
        clsFormatoFecha f = new clsFormatoFecha();
        this.hfNUP.Value = NUPString;
        this.txtPrimerApellido.Text = Paterno;
        this.txtPrimerApellido.Enabled = false;
        this.txtSegundoApellido.Text = Materno;
        this.txtSegundoApellido.Enabled = false;
        this.txtApellidoCasada.Text = Casada;
        this.txtApellidoCasada.Enabled = false;
        this.txtPrimerNombre.Text = Nombre;
        this.txtPrimerNombre.Enabled = false;
        this.txtSegundoNombre.Text = SegundoNombre;
        this.txtSegundoNombre.Enabled = false;
        this.txtNumeroDocumento.Text = CI;
        this.txtNumeroDocumento.Enabled = false;
        this.txtComplemento.Text = Complemento;
        this.txtComplemento.Enabled = false;
        this.txtFechaNacimiento.Text = f.Fecha(f.GeneraFechaDMY(Nacimiento));
        this.txtFechaNacimiento.Enabled = false;
        this.txtFechaFallecimient.Enabled = false;
        this.hfTabla.Value = Tabla;
        this.txtCUA.Text = CUA;
        this.txtCUA.Enabled = false;
        this.txtMatricula.Text = Matricula;
        this.txtMatricula.Enabled = false;
    }

    //Buscar Tramites
    protected void CargarDatosPersona()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        DataTable dtListaPersonas = null;
        clsPersona objPersona = new clsPersona();
        objPersona.NUP = Convert.ToInt32(this.hfNUP.Value);
        dtListaPersonas = objPersona.ObtenerPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
        if (dtListaPersonas != null && dtListaPersonas.Rows.Count > 0)
        {
            DataRow row = dtListaPersonas.Rows[0];
            ddlTipoDocumento.SelectedValue = Convert.ToString(row["IdTipoDocumento"]);            
            ddlExpedicion.SelectedValue = Convert.ToString(row["IdDocumentoExpedido"]);
           
            ddlEstadoCivil.SelectedValue = Convert.ToString(row["IdEstadoCivil"]);
         
            ddlAFP.SelectedValue = Convert.ToString(row["IdEntidadGestora"]);
            rblSexo.SelectedValue = Convert.ToString(row["IdSexo"]);
       
            txtCelular.Text = Convert.ToString(row["Celular"]);
          
            txtTelefono.Text = Convert.ToString(row["Telefono"]);
           
            txtEmail.Text = Convert.ToString(row["CorreoElectronico"]);
            
            txtDireccion.Text = Convert.ToString(row["Direccion"]);
            
            hdnIdLocalidad.Value = Convert.ToString(row["IdLocalidad"]);
            //txtBuscarLocalidad.Text = Convert.ToString(row["NombreLocalidad"]);
        }
        ddlTipoDocumento.Enabled = false;
        ddlExpedicion.Enabled = false;
        ddlEstadoCivil.Enabled = false;
        txtDireccion.Enabled = false;
        rblSexo.Enabled = false;
        txtPais.Enabled = false;
        txtCelular.Enabled = false;
        txtBusLocalidad.Enabled = false;
        txtTelefono.Enabled = false;
        txtEmail.Enabled = false;
        //IdPaisResidencia
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

    //Validar similitudes
    private void BuscarPersonas()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        DataTable dtListaPersonas;
        clsPersona clsPersona;

        string sPrecision;
        string sFechaNacimiento=null;
        string sPrimerNombre = this.txtPrimerNombre.Text;
        string sSegundoNombre = this.txtSegundoNombre.Text;
        string sPrimerApellido = this.txtPrimerApellido.Text;
        string sSegundoApellido = this.txtSegundoApellido.Text;
        string sNumeroDocumento = this.txtNumeroDocumento.Text;
        try
        {
            //Precision
            sPrecision = "11";
            //Buscar
            clsPersona = new clsPersona();

            dtListaPersonas = clsPersona.BuscarPorAvanzada(iIdConexion, cOperacion, "NORMAL", sPrimerApellido, sSegundoApellido, sPrimerNombre, sSegundoNombre, sNumeroDocumento, sFechaNacimiento, sPrecision, ref sMensajeError);
            if (dtListaPersonas != null && dtListaPersonas.Rows.Count > 0)
            {
                gvPersona.DataSource = dtListaPersonas;
                gvPersona.DataBind();
                pnlSimilitud.Visible = true;
                pnlSimilitudes.Visible = true;
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
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
        if (rblSexo.Text == null || rblSexo.Text == "")
        {
            sDetalleError = "El Sexo es requerido.";
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
            sFechafallecimiento = this.txtFechaFallecimient.Text;
            if (sFechafallecimiento != "" && ObjFormatoFecha.VerificaFormatoMDY(sFechafallecimiento))
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
                if (sFechafallecimiento != "" && !ObjFormatoFecha.VerificaFormatoMDY(sFechafallecimiento))
                {
                    sDetalleError = "La Fecha Defunción no es válida.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
            }
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

        return true;
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
        string cOperacion = "U";
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
        clsPersona Persona = new clsPersona();

        clsFormatoFecha f = new clsFormatoFecha();
        Persona.NUP = Convert.ToInt64(hfNUP.Value);
        Persona.IdTipoDocumento = Convert.ToInt16(this.ddlTipoDocumento.SelectedValue);
        Persona.IdEstadoCivil = Convert.ToInt16(this.ddlEstadoCivil.SelectedValue);
        Persona.IdEntidadGestora = Convert.ToInt32(ddlAFP.SelectedValue.ToString());
        Persona.IdSexo = Convert.ToInt16(this.rblSexo.SelectedValue);
        Persona.IdEstado = 1;
        Persona.CUA = Convert.ToInt64(this.txtCUA.Text);
        Persona.Matricula = this.txtMatricula.Text;
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
        Persona.Direccion = this.txtDireccion.Text;
        if (this.hdnIdLocalidad.Value != "")
            Persona.IdLocalidad = Convert.ToInt16(this.hdnIdLocalidad.Value);
        else
            Persona.IdLocalidad = 0;
        Persona.Telefono = this.txtTelefono.Text; ;
        Persona.RegistroActivo = 1;

        return Persona;
    }

    #endregion

    #region botones

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmRegistroTramite.aspx");
    }

    //Buscar localidad
    protected void ibtnBuscarLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusLocalidad.Text = this.txtBuscarLocalidad.Text;
        BuscarLocalidad(this.txtBuscarLocalidad.Text);
        this.gvGeo.Visible = true;
        ModalPopupExtender_LOCALIDAD.Show();
    }

    //VALIDA Y LLAMA A FUNCION QUE GUARDA EL TRAMITE
    protected void btnVerificar_Click(object sender, EventArgs e)
    {
        BuscarPersonas();
        string msg = "La operacion se realizo con exito";
        Master.MensajeOk(msg);
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
            this.hdnIdLocalidad.Value = Convert.ToString(gvGeo.DataKeys[Index].Values["IdLocalidad"]);
            this.txtBuscarLocalidad.Text = Convert.ToString(gvGeo.DataKeys[Index].Values["NombreLocalidad"]);
            this.gvGeo.Visible = false;
            this.txtBuscarLocalidad.Focus();
            ModalPopupExtender_LOCALIDAD.Hide();
        }
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
        if (e.CommandName != "imgBloquear")
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
                if (sPrestacionHabilitada == "AP" || sPrestacionHabilitada == "AVC" || sPrestacionHabilitada == "AUTOMÁTICO" )
                {
                    btnTramite.Visible = true;
                    btnBloqueo.Visible = false;
                    btnActualizar.Visible = false;
                }
                else
                {
                    e.Row.Visible = false;                    
                }
            }
        }
    }

    //index
    protected void gvPersona_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPersona.PageIndex = e.NewPageIndex;
        BuscarPersonas();
    }

    //elegir pagina
    protected void gvPersona_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvPersona = (GridView)sender;
        gvPersona.PageIndex = e.NewSelectedIndex;
        gvPersona.DataBind();
    }

    #endregion

}