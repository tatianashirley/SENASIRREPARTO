
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class Administracion_CompletarDatos : System.Web.UI.Page
{
    #region contantes

    private const string CARNET_IDENTIDAD = "25";
    private const string CARNET_EXTRANJERO = "26";
    private const string EXPEDIDO_EXTRANJERO = "45";
    private const string BOLIVIA = "83";
    private const string FEMENINO = "1";
    private const string TITULAR = "526";
    private const string APODERADO = "527";
    private const string DER_HAB = "528";
    private const string APODERADO_DER_HAB = "529";
    private const string MAN_TITULAR = "780";
    private const string MAN_DER_HAB = "781";
    private const string CON_WF = "NO";//MODIFICAR EN CASO DE NO IR POR WF
    private const string ACCESO_DIRECTO = "AD";
    private const string DERECHO_HAB_REPARTO = "DERECHO HABIENTE REPARTO";

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
        string queryStringCUA;
        string queryStringCI;
        string queryStringComplemento;
        string queryStringTabla;
        string queryStringProceso;

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
            lblSubTitulo.Text = "Registro Trámite";

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
            queryStringProceso = Request.QueryString["PROC"].Replace(' ', '+');

            encriptar = new clsFuncionesGenerales();
            if (queryStringTipo != "")
            {
                Tipo = encriptar.DecryptKey(queryStringTipo);
                Session["Tipo"] = Tipo;

                lblTipo.Text = Tipo;
                if (this.lblTipo.Text == "AUTOMÁTICO")
                {
                    lblProceso.Text = "PROCEDIMIENTO AUTOMÁTICO";
                }
                else if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP")
                {
                    lblProceso.Text = "PROCEDIMIENTO MANUAL";
                }
                else if (this.lblTipo.Text == "CRENTA")
                {
                    lblProceso.Text = "PROCEDIMIENTO MANUAL - ACCESO DIRECTO";
                }
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

                if (queryStringProceso != "")
                    hddProceso.Value = encriptar.DecryptKey(queryStringProceso);

                if (ACCESO_DIRECTO.Equals(hddProceso.Value))//Acceso Directo
                {
                    lblTituloSistema.Text = "MODULO ACCESO DIRECTO";
                }
                this.btnImprimir.OnClientClick = "return PrintPanel('" + pnlRegistro.ClientID + "');";
                //cargar datos en pantalla
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla);
                CargarSector();
                CargarOficina();
                CargarSexo();
                CargarEstadoCivil();
                CargarTipoDocumento();
                CargarEntidadAseguradora();
                CargarPersonaTipo();
                CargarValoresDefecto(1);
                deshabilitarAutocomplete();
            }
            DeshabilitarPaneles();
        }
    }

    #endregion

    #region paneles

    // DESHABILITAR PANELES
    private void DeshabilitarPaneles()
    {
        this.Panel8.Visible = false;//Datos Personales Similares
        this.pnlDatosSimilares.Visible = false;
        this.TabResidencia.Visible = false;//residencia
        this.pnlDatosResidencia.Visible = false;
        this.TabTramite.Visible = false;//Persona Inicia Trámite
        this.pnlPersonaInicia.Visible = false;
        this.TabDocumentos.Visible = false;//documentos
        this.pnlDocumentosDetalle.Visible = false;
        this.TabAutomatico.Visible = false;//automático
        this.pnlSalarioCotizableE.Visible = false;
        this.TabManual.Visible = false;
        this.PanelDatosDeclaraciondeEmpresaManualref.Visible = false;
    }

    //Habilitar paneles
    private void HabilitarPaneles(int iTipo)
    {
        switch (iTipo)
        {
            case 1:
                this.pnlDatosSimilares.Visible = false;
                this.Panel8.Visible = false;
                this.pnlJustificar.Visible = false;
                this.TabResidencia.Visible = true;//residencia
                this.TabResidencia.HeaderText = "Datos Residencia";
                this.pnlDatosResidencia.Visible = true;
                this.TabContainer1.ActiveTabIndex = 1;
                this.txtBuscarPais.Focus();
                break;
            case 2:
                this.TabTramite.Visible = true;//Persona Inicia Trámite
                this.TabTramite.HeaderText = "Datos Trámite";
                this.pnlPersonaInicia.Visible = true;
                this.TabContainer1.ActiveTabIndex = 2;
                this.rblTipoPersonaInicia.Focus();
                break;
            case 3:
                this.TabDocumentos.Visible = true;//Documentos
                this.TabDocumentos.HeaderText = "Documentos Trámite";
                this.TabContainer1.ActiveTabIndex = 3;
                this.pnlDocumentosDetalle.Visible = true;
                if (CON_WF.Equals("SI"))
                {
                    CargarDocumentosWF();
                }
                else
                {
                    CargarDocumentos();
                }
                this.rdbtDocs.Focus();
                break;
            case 4:
                if (this.lblTipo.Text == "AUTOMÁTICO")//automático
                {
                    CargarCombosEmpresas("A");
                    this.TabAutomatico.Visible = true;
                    this.TabAutomatico.HeaderText = "PA - Salario Cotizable";
                    this.TabContainer1.ActiveTabIndex = 4;
                    this.pnlSalarioCotizableE.Visible = true;
                    this.txtBuscarEmpresaAutomatico.Focus();
                }
                if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP" || this.lblTipo.Text == "CRENTA")//manual
                {
                    CargarCombosEmpresas("M");
                    this.TabManual.Visible = true;
                    this.TabManual.HeaderText = "PM - Empresas Asegurado";
                    this.TabContainer1.ActiveTabIndex = 4;
                    this.PanelDatosDeclaraciondeEmpresaManualref.Visible = true;
                    this.txtEmpresaManual.Focus();
                }
                break;
        }

    }

    //Habilita el panel de datos repetidos
    private void HabilitaPanelRepetidos()
    {
        DeshabilitarPaneles();
        this.Panel8.Visible = true;
        this.pnlDatosSimilares.Visible = true;
        this.pnlDatosResidencia.Visible = false;
        this.pnlSalarioCotizableE.Visible = false;
    }

    #endregion

    #region funciones

    private void CargarValoresDefecto(int tipo)
    {
        switch (tipo) {
            case 1: 
                this.hdnIdPais.Value = BOLIVIA;
                this.txtBuscarPais.Text = "BOLIVIA"; 
                break;
            case 2: 
                this.hddPaisInicia.Value = BOLIVIA;
                this.txtPaisInicia.Text = "BOLIVIA";
                break;
        }
    }

    //CARGA LOS DATOS OBTENIDOS EN EL LISTADO ANTERIOR
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla)
    {
        clsFormatoFecha f = new clsFormatoFecha();
        this.hddCodigo.Value = NUPString;
        this.txtPrimerApellido.Text = Paterno;
        this.txtSegundoApellido.Text = Materno;
        this.txtApellidoCasada.Text = Casada;
        this.txtPrimerNombre.Text = Nombre;
        this.txtSegundoNombre.Text = SegundoNombre;
        if (!String.IsNullOrEmpty(CI))
        {
            try
            {
                if (IsNumeric(CI))
                {
                    this.txtNumeroDocumento.Text = Convert.ToString(Convert.ToInt64(CI));
                }
                else
                {
                    this.txtNumeroDocumento.Text = CI;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
                this.txtNumeroDocumento.Text = CI;
            }
        }
        if (!String.IsNullOrEmpty(Complemento))
        {
            this.txtComplemento.Text = Complemento;
        }

        if (!String.IsNullOrEmpty(Nacimiento))
        {
            this.txtFechaNacimiento.Text = f.Fecha(f.GeneraFechaDMY(Nacimiento));
        }
        this.hfTabla.Value = Tabla;

        if (!(CUA == null || CUA == "" || CUA == "0"))
        {
            this.txtCUA.Text = CUA;
            //this.txtCUA.Enabled = false;
        }
        if (Matricula == null || Matricula == "" || Matricula == "0")
        {
            this.btnGenerarMatricula.Enabled = true;
        }
        else
        {
            this.txtMatricula.Text = Matricula;
            //this.btnGenerarMatricula.Enabled = false;
            this.hddMatriculaORG.Value = Matricula;
        }
        this.txtMatricula.Enabled = false;
        this.txtPrimerApellido.Focus();
    }

    //Deshabilita los autocompletar
    private void deshabilitarAutocomplete()
    {
        //Datos persona
        txtPrimerApellido.Attributes.Add("autocomplete", "off");
        txtSegundoApellido.Attributes.Add("autocomplete", "off");
        txtApellidoCasada.Attributes.Add("autocomplete", "off");
        txtPrimerNombre.Attributes.Add("autocomplete", "off");
        txtSegundoNombre.Attributes.Add("autocomplete", "off");
        txtNumeroDocumento.Attributes.Add("autocomplete", "off");
        txtFechaNacimiento.Attributes.Add("autocomplete", "off");
        txtFechaFallecimient.Attributes.Add("autocomplete", "off");
        //datos residencia
        txtTelefono.Attributes.Add("autocomplete", "off");
        txtCelular.Attributes.Add("autocomplete", "off");
        txtEmail.Attributes.Add("autocomplete", "off");
        //datos inicio
        txtPrimerApellidoInicia.Attributes.Add("autocomplete", "off");
        txtSegundoApellidoInicia.Attributes.Add("autocomplete", "off");
        txtApellidoCasadaInicia.Attributes.Add("autocomplete", "off");
        txtPrimerNombreInicia.Attributes.Add("autocomplete", "off");
        txtSegundoNombreInicia.Attributes.Add("autocomplete", "off");
        txtFechaNacimientoInicia.Attributes.Add("autocomplete", "off");
        txtNumeroDocumentoInicia.Attributes.Add("autocomplete", "off");
        //busquedas
        //buscar pais
        txtBusPais.Attributes.Add("autocomplete", "off");
        txtBusLocalidad.Attributes.Add("autocomplete", "off");
        //grilla automaticA
        txtMontoAuto.Attributes.Add("autocomplete", "off");
        txtMontoAuto2.Attributes.Add("autocomplete", "off");
        txtBusEmpAuto.Attributes.Add("autocomplete", "off");
        txtBusRucAuto.Attributes.Add("autocomplete", "off");
    }

    //Combo Sector
    private void CargarSector()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtSector = new DataTable();
        dtSector = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "Sector", ref sMensajeError);
        if (dtSector != null && dtSector.Rows.Count > 0)
        {
            ddlSector.DataSource = dtSector;
            ddlSector.DataTextField = "Descripcion";
            ddlSector.DataValueField = "IdSector";
            ddlSector.DataBind();
            ddlSector.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlSector.SelectedValue = "0";
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
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
    private void CargarExpedicionDocumento(string sTipoDocumento)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
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
            rblAFP.DataSource = dtExpDocumento;
            rblAFP.DataTextField = "Descripcion";
            rblAFP.DataValueField = "IdDetalleClasificador";
            rblAFP.DataBind();
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
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

    //Cargar combos empresa
    private void CargarCombosEmpresas(string sTipo)
    {
        clsPersona objPersona;
        DataTable dtSalario;
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];

        if (sTipo.Equals("A"))
        {
            //Primera Fecha Afiliacion
            DataTable dtPFA = GetPFA(hddMatriculaORG.Value);
            if (dtPFA != null && dtPFA.Rows.Count > 0)
            {
                foreach (DataRow row in dtPFA.Rows)
                {
                    txtPFA.Text = row["fecha_ingreso"].ToString();
                }
            }
            //Años
            DataTable dtAnio = GetAnio();
            if (dtAnio != null && dtAnio.Rows.Count > 0)
            {
                ddlAnioAuto.DataSource = dtAnio;
                ddlAnioAuto.DataTextField = "Anio";
                ddlAnioAuto.DataValueField = "Anio";
                ddlAnioAuto.DataBind();
                ddlAnioAuto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlAnioAuto.SelectedValue = "0";
            }
            //Moneda
            ddlMonedaAuto.DataSource = null;
            ddlMonedaAuto.DataTextField = "DescripMoneda";
            ddlMonedaAuto.DataValueField = "IdDetalleClasificadorMon";
            ddlMonedaAuto.DataBind();
            ddlMonedaAuto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlMonedaAuto.SelectedValue = "0";
            //Documentos
            DataTable dtDocumentos = GetDocumentosSalarioAutomaticos();
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                ddlDocumentoAuto.DataSource = dtDocumentos;
                ddlDocumentoAuto.DataTextField = "DescripDocSalarios";
                ddlDocumentoAuto.DataValueField = "IdDetalleClasificadorDoc";
                ddlDocumentoAuto.DataBind();
                ddlDocumentoAuto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlDocumentoAuto.SelectedValue = "0";
            }
            //Salario Referencial
            string cOperacion = "C";
            try
            {
                objPersona = new clsPersona();
                objPersona.Matricula = this.hddMatriculaORG.Value;
                dtSalario = objPersona.ObtenerDatosReferencial(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
                if (dtSalario != null && dtSalario.Rows.Count > 0)
                {
                    gvSalarioRef.DataSource = dtSalario;
                    gvSalarioRef.DataBind();
                }
                gvSalarioRef.Visible = true;
            }
            catch (Exception ex)
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = ex.Message;
                Master.MensajeError(sError, sDetalleError);
            }
        }
        else if (sTipo.Equals("M"))
        {
            //Sector
            DataTable dtSector = GetSector();
            if (dtSector != null && dtSector.Rows.Count > 0)
            {
                ddlSectorEmpresaManual.DataSource = dtSector;
                ddlSectorEmpresaManual.DataTextField = "Descripcion";
                ddlSectorEmpresaManual.DataValueField = "IdSector";
                ddlSectorEmpresaManual.DataBind();
                ddlSectorEmpresaManual.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlSectorEmpresaManual.SelectedValue = "0";
            }
            ddlSectorEmpresaManual.Enabled = false;
            //Documentos
            DataTable dtDocumentos = GetDocumentosSalarioAutomaticos();
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                ddlDocumentoManual.DataSource = dtDocumentos;
                ddlDocumentoManual.DataTextField = "DescripDocSalarios";
                ddlDocumentoManual.DataValueField = "IdDetalleClasificadorDoc";
                ddlDocumentoManual.DataBind();
                ddlDocumentoManual.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlDocumentoManual.SelectedValue = "0";
            }
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
        this.imgcalendarioIni.Enabled = false;
        this.btncalendarff.Enabled = false;
        this.txtFechaFallecimient.Enabled = false;
        this.rblAFP.Enabled = false;
        this.txtCUA.Enabled = false;
        this.txtMatricula.Enabled = false;
        this.txtMatriculaGenerada.Enabled = false;
        this.ddlSector.Enabled = false;
        this.ddlOficinaNotificacion.Enabled = false;
        this.btnGenerarMatricula.Enabled = false;
        this.ibtnVerificar.Enabled = false;
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

    //Habilita comparación CUA
    private void HabilitaComparaDatos()
    {
        DataTable dtValidarCua;
        clsTramite ObjTramite;
        try
        {
            ObjTramite = new clsTramite();
            ObjTramite.iIdConexion = (int)Session["IdConexion"];
            ObjTramite.cOperacion = "V";
            ObjTramite.PrimerApellido = this.txtPrimerApellido.Text;
            ObjTramite.SegundoApellido = this.txtSegundoApellido.Text;
            ObjTramite.Nombre = this.txtPrimerNombre.Text;
            ObjTramite.SegundoNombre = this.txtSegundoNombre.Text;
            ObjTramite.NumeroDocumento = this.txtNumeroDocumento.Text;
            ObjTramite.Nua = this.txtCUA.Text;
            ObjTramite.Matricula = this.txtMatricula.Text;
            ObjTramite.Sexo = this.rblSexo.SelectedValue;
            //validar si permite seguir el tramite
            dtValidarCua = ObjTramite.ValidarCUA();
            if (dtValidarCua != null && dtValidarCua.Rows.Count > 0)
            {
                foreach (DataRow row in dtValidarCua.Rows)
                {
                    this.txtNUA_AP.Text = row["NUA"].ToString();
                    this.txtPrimerApellido_AP.Text = row["PRIMER_APELLIDO"].ToString();
                    this.txtSegundoApellido_AP.Text = row["SEGUNDO_APELLIDO"].ToString();
                    this.txtPrimerNombre_AP.Text = row["PRIMER_NOMBRE"].ToString();
                    this.txtSegundoNombre_AP.Text = row["SEGUNDO_NOMBRE"].ToString();
                    if (row["FEC_NACIMIENTO"] != null && !String.IsNullOrEmpty(row["FEC_NACIMIENTO"].ToString()))
                    {
                        this.txtFechaNac_AP.Text = clsFormatoFecha.FechaText(row["FEC_NACIMIENTO"].ToString());
                    }
                }
                this.txtNUA_IT.Text = this.txtCUA.Text;
                this.txtPrimerApellido_IT.Text = this.txtPrimerApellido.Text;
                this.txtSegundoApellido_IT.Text = this.txtSegundoApellido.Text;
                this.txtPrimerNombre_IT.Text = this.txtPrimerNombre.Text;
                this.txtSegundoNombre_IT.Text = this.txtSegundoNombre.Text;
                if (this.txtFechaNacimiento.Text != null && !String.IsNullOrEmpty(this.txtFechaNacimiento.Text))
                {
                    this.txtFechaNac_IT.Text = this.txtFechaNacimiento.Text;
                }
                this.pnlAfiliados.Visible = true;
                this.ModalPopupExtender_COTEJAR.Show();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
    }

    //Valida existencia de datos para generar la matrícula
    private bool VerificaMatricula()
    {
        string sError = "Error al realizar la operación.";
        string sDetalleError;
        if (this.txtMatricula.Text.Trim() == null || this.txtMatricula.Text.Trim() == "" || this.txtMatricula.Text == "0")
        {
            sDetalleError = "La Matrícula es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    //Valida datos de entrada
    private bool ValidaDatos()
    {
        clsFormatoFecha ObjFormatoFecha;
        string sFechanacimiento;
        string sFechafallecimiento;
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
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
        if ((ddlTipoDocumento.SelectedValue.ToString().Equals(CARNET_IDENTIDAD) || ddlTipoDocumento.SelectedValue.ToString().Equals(CARNET_EXTRANJERO)) && ddlExpedicion.SelectedValue.ToString() == "0")
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
        else
        {
            sDetalleError = "La Fecha Nacimiento no es válida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        if (ddlEstadoCivil.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Estado Civil es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (rblAFP.Text == null || rblAFP.Text == "")
        {
            sDetalleError = "El Fondo de Pensiones es requerido.";
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
        if (ddlSector.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Sector Laboral es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlOficinaNotificacion.SelectedValue.ToString() == "0")
        {
            sDetalleError = "La Oficina Notificación es requerida.";
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

    //Validar CUA
    private bool ValidaCUA()
    {
        bool bExisteCUA;
        DataTable dtValidarCua;
        clsTramite ObjTramite;
        bExisteCUA = false;
        try
        {
            ObjTramite = new clsTramite();
            ObjTramite.iIdConexion = (int)Session["IdConexion"];
            ObjTramite.cOperacion = "V";
            ObjTramite.PrimerApellido = this.txtPrimerApellido.Text;
            ObjTramite.SegundoApellido = this.txtSegundoApellido.Text;
            ObjTramite.Nombre = this.txtPrimerNombre.Text;
            ObjTramite.SegundoNombre = this.txtSegundoNombre.Text;
            ObjTramite.NumeroDocumento = this.txtNumeroDocumento.Text;
            ObjTramite.Nua = this.txtCUA.Text;
            ObjTramite.Matricula = this.txtMatricula.Text;
            ObjTramite.Sexo = this.rblSexo.SelectedValue;
            if (!String.IsNullOrEmpty(this.txtFechaNacimiento.Text))
            {
                ObjTramite.FechaNacimiento = this.txtFechaNacimiento.Text;
            }
            //validar si permite seguir el tramite
            dtValidarCua = ObjTramite.ValidarCUA();
            if (dtValidarCua != null && dtValidarCua.Rows.Count > 0)
            {
                foreach (DataRow row in dtValidarCua.Rows)
                {
                    if (this.rblSexo.SelectedValue.Equals(FEMENINO))
                    {
                        if (ObjTramite.PrimerApellido.Equals(row["PRIMER_APELLIDO"].ToString()) &&
                        ObjTramite.Nombre.Equals(row["PRIMER_NOMBRE"].ToString()) &&
                        ObjTramite.FechaNacimiento.Equals(clsFormatoFecha.FechaText(row["FEC_NACIMIENTO"].ToString())) &&
                        (String.IsNullOrEmpty(ObjTramite.SegundoNombre) || (!String.IsNullOrEmpty(ObjTramite.SegundoNombre) && ObjTramite.SegundoNombre.Equals(row["SEGUNDO_NOMBRE"].ToString()))))
                        {
                            bExisteCUA = true;
                        }
                    }
                    else
                    {
                        if (ObjTramite.PrimerApellido.Equals(row["PRIMER_APELLIDO"].ToString()) &&
                            ObjTramite.SegundoApellido.Equals(row["SEGUNDO_APELLIDO"].ToString()) &&
                        ObjTramite.Nombre.Equals(row["PRIMER_NOMBRE"].ToString()) &&
                        ObjTramite.FechaNacimiento.Equals(clsFormatoFecha.FechaText(row["FEC_NACIMIENTO"].ToString())) &&
                        (String.IsNullOrEmpty(ObjTramite.SegundoNombre) || (!String.IsNullOrEmpty(ObjTramite.SegundoNombre) && ObjTramite.SegundoNombre.Equals(row["SEGUNDO_NOMBRE"].ToString()))))
                        {
                            bExisteCUA = true;
                        }
                    }
                    if (!bExisteCUA)
                    {
                        if (((String.IsNullOrEmpty(ObjTramite.PrimerApellido) && ObjTramite.SegundoApellido.Equals(row["PRIMER_APELLIDO"].ToString()) && String.IsNullOrEmpty(row["SEGUNDO_APELLIDO"].ToString())) || (String.IsNullOrEmpty(ObjTramite.SegundoApellido) && ObjTramite.PrimerApellido.Equals(row["SEGUNDO_APELLIDO"].ToString()) && String.IsNullOrEmpty(row["PRIMER_APELLIDO"].ToString()))) && (ObjTramite.Nombre.Equals(row["PRIMER_NOMBRE"].ToString()) &&
                        ObjTramite.FechaNacimiento.Equals(clsFormatoFecha.FechaText(row["FEC_NACIMIENTO"].ToString())) &&
                        (String.IsNullOrEmpty(ObjTramite.SegundoNombre) || (!String.IsNullOrEmpty(ObjTramite.SegundoNombre) && ObjTramite.SegundoNombre.Equals(row["SEGUNDO_NOMBRE"].ToString())))))
                        {
                            bExisteCUA = true;
                        }

                    }
                }
            }
            else
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = "El CUA no está registrado en la aseguradora.";
                Master.MensajeError(sError, sDetalleError);
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
        return bExisteCUA;
    }

    //Validar similitudes
    private bool ValidaDatosRepetidos()
    {
        string sCUA, sCARNET;
        bool bExisteCUA, bExisteCARNET;
        int iContador;
        DataTable dtValidarInicio;
        clsTramite ObjTramite;
        try
        {
            bExisteCUA = false;
            bExisteCARNET = false;
            dtValidarInicio = new DataTable();
            ObjTramite = new clsTramite();
            ObjTramite.iIdConexion = (int)Session["IdConexion"];
            if (ACCESO_DIRECTO.Equals(hddProceso.Value))//Acceso Directo
            {
                ObjTramite.cOperacion = "R";
            }
            else
            {
                ObjTramite.cOperacion = "V";
            }
            ObjTramite.PrimerApellido = this.txtPrimerApellido.Text;
            ObjTramite.SegundoApellido = this.txtSegundoApellido.Text;
            ObjTramite.Nombre = this.txtPrimerNombre.Text;
            ObjTramite.NumeroDocumento = this.txtNumeroDocumento.Text;
            ObjTramite.Nua = this.txtCUA.Text;
            ObjTramite.Matricula = this.txtMatricula.Text;
            //validar si permite seguir el tramite
            iContador = 0;
            sCUA = this.txtCUA.Text;
            sCARNET = this.txtNumeroDocumento.Text;
            dtValidarInicio = ObjTramite.ValidarInicio();
            if (dtValidarInicio != null && dtValidarInicio.Rows.Count > 0)
            {
                foreach (DataRow row in dtValidarInicio.Rows)
                {
                    if (sCUA.Equals(row["NUA"].ToString()))
                    {
                        bExisteCUA = true;
                    }
                    if (sCARNET.Equals(row["CARNET"].ToString()) && !("FALLECIMIENTO".Equals(row["ESTADO_TDES"].ToString())))
                    {
                        bExisteCARNET = true;
                    }
                    if (DERECHO_HAB_REPARTO.Equals(row["TIPO"].ToString()))
                    {
                        iContador++;
                    }
                }
                if (iContador == dtValidarInicio.Rows.Count)
                {
                    this.lblSimilitud.Text = "";
                    this.lblSimilitud.Visible = false;
                    this.ibtnPermitir.Enabled = true;
                }
                else
                {
                    if (bExisteCUA || bExisteCARNET)
                    {
                        this.lblSimilitud.Text = "La persona tiene trámites, revisar la solicitud.";
                        this.lblSimilitud.Visible = true;
                        this.ibtnPermitir.Enabled = false;
                    }
                    else
                    {
                        this.lblSimilitud.Text = "";
                        this.lblSimilitud.Visible = false;
                        this.ibtnPermitir.Enabled = true;
                    }
                }
                gv_ValidaDatosRepetidos.DataSource = dtValidarInicio;
                gv_ValidaDatosRepetidos.DataBind();
                return true;
            }
            else
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = ObjTramite.sMensajeError;
                Master.MensajeError(sError, sDetalleError);
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
        return false;
    }

    //colorear con automatico
    protected void gv_ValidaDatosRepetidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sCUA = Convert.ToString(gv_ValidaDatosRepetidos.DataKeys[e.Row.RowIndex].Values["NUA"]);
            string sCARNET = Convert.ToString(gv_ValidaDatosRepetidos.DataKeys[e.Row.RowIndex].Values["CARNET"]);
            string sEstado = Convert.ToString(gv_ValidaDatosRepetidos.DataKeys[e.Row.RowIndex].Values["ESTADO_TDES"]);
            string sTipo = Convert.ToString(gv_ValidaDatosRepetidos.DataKeys[e.Row.RowIndex].Values["TIPO"]);
            if (!DERECHO_HAB_REPARTO.Equals(sTipo))
            {
                if (this.txtCUA.Text == sCUA || (this.txtNumeroDocumento.Text == sCARNET && "FALLECIMIENTO" != sEstado))
                {
                    e.Row.BackColor = Color.LightCoral;
                }
            }
        }
    }

    //Validar acceso directo resoluciones
    private bool ObtenerResoluciones()
    {
        clsAccesoDirecto ObjAccesoDirecto;
        DataTable dtResoluciones;
        try
        {
            dtResoluciones = new DataTable();
            ObjAccesoDirecto = new clsAccesoDirecto();
            ObjAccesoDirecto.iIdConexion = (int)Session["IdConexion"];
            ObjAccesoDirecto.cOperacion = "Q";
            ObjAccesoDirecto.IdTramite = this.hddCodigo.Value;
            ObjAccesoDirecto.Matricula = this.txtMatricula.Text;
            if (ObjAccesoDirecto.ObtenerResoluciones())
            {
                dtResoluciones = ObjAccesoDirecto.DSetTmp.Tables[0];
                if (dtResoluciones != null && dtResoluciones.Rows.Count > 0)
                {
                    pnlTituloAccesoDirecto.Visible = true;
                    pnlAcceso.Visible = true;
                    gvADResoluciones.DataSource = dtResoluciones;
                    gvADResoluciones.DataBind();
                    return true;
                }

            }
            else
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = ObjAccesoDirecto.sMensajeError;
                Master.MensajeError(sError, sDetalleError);
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
        return false;
    }

    //Validar acceso directo convenios
    private bool ObtenerConvenios()
    {
        clsAccesoDirecto ObjAccesoDirecto;
        DataTable dtConvenios;
        try
        {
            dtConvenios = new DataTable();
            ObjAccesoDirecto = new clsAccesoDirecto();
            ObjAccesoDirecto.iIdConexion = (int)Session["IdConexion"];
            ObjAccesoDirecto.cOperacion = "Q";
            ObjAccesoDirecto.IdTramite = this.hddCodigo.Value;
            ObjAccesoDirecto.Matricula = this.txtMatricula.Text;
            if (ObjAccesoDirecto.ObtenerConvenios())
            {
                dtConvenios = ObjAccesoDirecto.DSetTmp.Tables[0];
                if (dtConvenios != null && dtConvenios.Rows.Count > 0)
                {
                    pnlTituloAccesoDirecto.Visible = true;
                    pnlAcceso.Visible = true;

                    gvADConvenios.DataSource = dtConvenios;
                    gvADConvenios.DataBind();
                    return true;
                }

            }
            else
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = ObjAccesoDirecto.sMensajeError;
                Master.MensajeError(sError, sDetalleError);
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
        return false;
    }

    //Listar Localidad
    private void BuscarLocalidad(string sLocalidad, GridView gvLocalidadTmp)
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
                    gvLocalidadTmp.DataSource = dtLocalidad;
                    gvLocalidadTmp.DataBind();
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

    //Listar Pais
    private void BuscarPais(string sPais, GridView gvPaisTmp)
    {
        string sError;
        string sDetalleError;
        DataTable dtPais;
        clsTramite ObjTramite;
        try
        {
            if (!String.IsNullOrEmpty(sPais))
            {
                ObjTramite = new clsTramite();
                ObjTramite.iIdConexion = (int)Session["IdConexion"];
                ObjTramite.cOperacion = "Q";
                ObjTramite.Pais = sPais;
                dtPais = ObjTramite.BuscarPaises();
                if (dtPais != null && dtPais.Rows.Count > 0)
                {
                    gvPaisTmp.DataSource = dtPais;
                    gvPaisTmp.DataBind();
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

    //Validar datos residencia
    public bool ValidaDatosResidencia()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        if (this.txtBuscarPais.Text.Trim() == null || txtBuscarPais.Text.Trim() == "")
        {
            sDetalleError = "El País es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (this.hdnIdPais.Value.Equals(BOLIVIA) && (this.txtBuscarLocalidad.Text.Trim() == null || txtBuscarLocalidad.Text.Trim() == ""))
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

    //Validar documentos
    public bool ValidaDocumentos()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        int iCantidad = 0;
        if (rdbtDocs != null && rdbtDocs.Items.Count > 0)
        {
            wcfWorkFlowN.Datos.clsSolicitudTramiteDocumentoTmpDA doc = new wcfWorkFlowN.Datos.clsSolicitudTramiteDocumentoTmpDA();
            foreach (ListItem fila in rdbtDocs.Items)
            {
                if (fila.Selected)
                {
                    iCantidad++;
                }
            }
        }
        if (iCantidad <= 0)
        {
            sDetalleError = "Debe elegir al menos un documento.";
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
        if (this.rblTipoPersonaInicia.SelectedValue.ToString() != TITULAR)
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
                    if (this.txtPaisInicia.Text.Trim() == null || txtPaisInicia.Text.Trim() == "")
                    {
                        sDetalleError = "El País es requerido.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (this.hddPaisInicia.Value.Equals(BOLIVIA) && (this.txtLocalidadInicia.Text.Trim() == null || txtLocalidadInicia.Text.Trim() == ""))
                    {
                        sDetalleError = "La Localidad es requerida.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (this.txtDireccionInicia.Text.Trim() == null || txtDireccionInicia.Text.Trim() == "")
                    {
                        sDetalleError = "La Dirección es requerida.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    if (this.txtTelefonoFijoInicia.Text.Trim() != null && this.txtTelefonoFijoInicia.Text.Trim() != "")
                    {
                        if (this.txtTelefonoFijoInicia.Text.Length < 7)
                        {
                            sDetalleError = "El Teléfono Fijo no es válido.";
                            Master.MensajeError(sError, sDetalleError);
                            return false;
                        }
                    }
                    if (this.txtTelefonoCelularInicia.Text.Trim() != null && this.txtTelefonoCelularInicia.Text.Trim() != "")
                    {
                        if (this.txtTelefonoCelularInicia.Text.Length < 8 || !(this.txtTelefonoCelularInicia.Text.Substring(0).Contains("6")
                            || this.txtTelefonoCelularInicia.Text.Substring(0).Contains("7"))
                            )
                        {
                            sDetalleError = "El Teléfono Celular no es válido.";
                            Master.MensajeError(sError, sDetalleError);
                            return false;
                        }
                    }
                    if (this.txtEmailInicia.Text.Trim() != null && this.txtEmailInicia.Text.Trim() != "")
                    {
                        try
                        {
                            MailAddress email = new MailAddress(this.txtEmailInicia.Text);
                        }
                        catch (Exception ex)
                        {
                            System.Console.Write(ex.Message);
                            sDetalleError = "El E-MAIL no es válido.";
                            Master.MensajeError(sError, sDetalleError);
                            return false;
                        }
                    }
                    if (this.txtTelefonoReferenciaInicia.Text.Trim() != null && this.txtTelefonoReferenciaInicia.Text.Trim() != "")
                    {
                        if (this.txtTelefonoReferenciaInicia.Text.Length < 8 || !(this.txtTelefonoReferenciaInicia.Text.Substring(0).Contains("6")
                            || this.txtTelefonoReferenciaInicia.Text.Substring(0).Contains("7"))
                            )
                        {
                            sDetalleError = "El Teléfono Referencia no es válido.";
                            Master.MensajeError(sError, sDetalleError);
                            return false;
                        }
                    }
                    if (this.txtTelefonoFijoInicia.Text.Trim() == null || this.txtTelefonoFijoInicia.Text.Trim() == "")
                    {
                        if (this.txtTelefonoCelularInicia.Text.Trim() == null || this.txtTelefonoCelularInicia.Text.Trim() == "")
                        {
                            if (this.txtTelefonoReferenciaInicia.Text.Trim() == null || this.txtTelefonoReferenciaInicia.Text.Trim() == "")
                            {
                                sDetalleError = "El Teléfono Fijo o el Teléfono Celular o el Teléfono Referencia es requerido.";
                                Master.MensajeError(sError, sDetalleError);
                                return false;
                            }
                        }
                    }
                }
                if (this.txtNumeroDocumento.Text.Equals(this.txtNumeroDocumentoInicia.Text))
                {
                    sDetalleError = "La persona registrada como titular no puede ser apoderado.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
                if (this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO || this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO_DER_HAB)
                {
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
                }
                if (this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO)
                {
                    if (!String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
                    {
                        sDetalleError = "La persona registrada no puede tener apoderado.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
                else if (this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO_DER_HAB)
                {
                    if (String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
                    {
                        sDetalleError = "La persona registrada para tener apoderado derechohabiente debe ingresar la fecha defunción.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
                else if (this.rblTipoPersonaInicia.SelectedItem.Value == DER_HAB)
                {
                    if (String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
                    {
                        sDetalleError = "La persona registrada para tener derechohabiente debe ingresar la fecha defunción.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
                else if (this.rblTipoPersonaInicia.SelectedItem.Value == MAN_TITULAR)
                {
                    if (!String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
                    {
                        sDetalleError = "La persona registrada no puede ser mandatario titular.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
                else if (this.rblTipoPersonaInicia.SelectedItem.Value == MAN_DER_HAB)
                {
                    if (String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
                    {
                        sDetalleError = "La persona registrada para tener mandatario derechohabiente debe ingresar la fecha defunción.";
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                }
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
            {
                sDetalleError = "La persona registrada no puede ser titular.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        return true;
    }

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
        if (this.rblTipoPersonaInicia.SelectedValue.ToString() == TITULAR)
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
            if (this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO || this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO_DER_HAB)
            {
                txtPoderNotarial.Enabled = true;
                txtAdministracionPoder.Enabled = true;
                txtVigenciaPoderDel.Enabled = true;
                txtVigenciaPoderAl.Enabled = true;
            }
            else
            {
                txtPoderNotarial.Enabled = false;
                txtAdministracionPoder.Enabled = false;
                txtVigenciaPoderDel.Enabled = false;
                txtVigenciaPoderAl.Enabled = false;
            }
        }
        Master.MensajeCancel();
    }

    //adicionar empresa automatico
    private void AgregarEmpAuto()
    {
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        dt2 = new DataTable();
        dt2.Columns.Add("Empresa");
        dt2.Columns.Add("Ruc");
        dt2.Columns.Add("IdSector");
        dt2.Columns.Add("Sector");
        dt2.Columns.Add("IdMes");
        dt2.Columns.Add("Mes");
        dt2.Columns.Add("Anio");
        dt2.Columns.Add("Total");
        dt2.Columns.Add("CopiaTotal");
        dt2.Columns.Add("IdDetalleClasificadorMon");
        dt2.Columns.Add("Moneda");
        dt2.Columns.Add("IdDetalleClasificadorDoc");
        dt2.Columns.Add("Documento");
        dt2.Columns.Add("pfa");
        dt2.Columns.Add("IdDocumentoSSLP");
        dt2.Columns.Add("DocumentoSSLP");
        filadt2 = dt2.NewRow();
        filadt2["Empresa"] = txtBuscarEmpresaAutomatico.Text;
        filadt2["Ruc"] = txtBuscarRUCAutomatico.Text;
        filadt2["IdSector"] = hddSectorAuto.Value;
        filadt2["Sector"] = txtSectorAuto.Text;
        filadt2["IdMes"] = ddlMesAuto.SelectedValue;
        filadt2["Mes"] = ddlMesAuto.SelectedItem.Text;
        filadt2["Anio"] = ddlAnioAuto.SelectedValue;
        filadt2["Total"] = txtMontoAuto.Text;
        filadt2["CopiaTotal"] = txtMontoAuto2.Text;
        filadt2["IdDetalleClasificadorMon"] = ddlMonedaAuto.SelectedValue;
        filadt2["Moneda"] = ddlMonedaAuto.SelectedItem.Text;
        filadt2["IdDetalleClasificadorDoc"] = ddlDocumentoAuto.SelectedValue;
        filadt2["Documento"] = ddlDocumentoAuto.SelectedItem.Text;
        filadt2["pfa"] = (ckboxPFA.Checked) ? "SI" : "NO";
        filadt2["IdDocumentoSSLP"] = ddlSectorSSLP.SelectedValue;
        filadt2["DocumentoSSLP"] = txtDocumentoSSLP.Text;
        dt2.Rows.Add(filadt2);
        // salvar datos de la grid
        if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
        {
            foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
            {
                filadt2 = dt2.NewRow();
                filadt2["Empresa"] = Convert.ToString(fila.Values["Empresa"]);
                filadt2["Ruc"] = Convert.ToString(fila.Values["Ruc"]);
                filadt2["IdSector"] = Convert.ToString(fila.Values["IdSector"]);
                filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                filadt2["IdMes"] = Convert.ToString(fila.Values["IdMes"]);
                filadt2["Mes"] = Convert.ToString(fila.Values["Mes"]);
                filadt2["Anio"] = Convert.ToString(fila.Values["Anio"]);
                filadt2["Total"] = Convert.ToString(fila.Values["Total"]);
                filadt2["CopiaTotal"] = Convert.ToString(fila.Values["CopiaTotal"]);
                filadt2["IdDetalleClasificadorMon"] = Convert.ToString(fila.Values["IdDetalleClasificadorMon"]);
                filadt2["Moneda"] = Convert.ToString(fila.Values["Moneda"]);
                filadt2["IdDetalleClasificadorDoc"] = Convert.ToString(fila.Values["IdDetalleClasificadorDoc"]);
                filadt2["Documento"] = Convert.ToString(fila.Values["Documento"]);
                filadt2["pfa"] = Convert.ToString(fila.Values["pfa"]);
                filadt2["IdDocumentoSSLP"] = Convert.ToString(fila.Values["IdDocumentoSSLP"]);
                filadt2["DocumentoSSLP"] = Convert.ToString(fila.Values["DocumentoSSLP"]);
                dt2.Rows.Add(filadt2);
            }
        }
        grdSalariosAutomaticos.DataSource = dt2;
        grdSalariosAutomaticos.DataBind();
    }

    //adicionar empresa manual
    private void AgregarEmpManual()
    {
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        dt2 = new DataTable();
        dt2.Columns.Add("Empresa");
        dt2.Columns.Add("Ruc");
        dt2.Columns.Add("IdSector");
        dt2.Columns.Add("Sector");
        dt2.Columns.Add("Fecha_Ingreso");
        dt2.Columns.Add("Fecha_Retiro");
        dt2.Columns.Add("EmpNoExis");
        dt2.Columns.Add("RazonSocialEmpresaManual");
        dt2.Columns.Add("NroPatronal_Ruc_Alternativo");
        dt2.Columns.Add("IdDetalleClasificadorDoc");
        dt2.Columns.Add("Documento");
        filadt2 = dt2.NewRow();
        filadt2["Empresa"] = txtEmpresaManual.Text;
        filadt2["Ruc"] = txtRucManual.Text;
        filadt2["IdSector"] = ddlSectorEmpresaManual.SelectedValue;
        filadt2["Sector"] = ddlSectorEmpresaManual.SelectedItem.Text;
        filadt2["Fecha_Ingreso"] = txtFecha_Ingreso.Text;
        filadt2["Fecha_Retiro"] = txtFecha_Retiro.Text;
        filadt2["RazonSocialEmpresaManual"] = txtRazonSocialEmpresaManual_Alternativo.Text;
        filadt2["NroPatronal_Ruc_Alternativo"] = txtNroPatronal_Ruc_Alternativo.Text;
        filadt2["IdDetalleClasificadorDoc"] = ddlDocumentoManual.SelectedValue;
        filadt2["Documento"] = ddlDocumentoManual.SelectedItem.Text;
        dt2.Rows.Add(filadt2);
        // salvar datos de la grid
        if (gvEmpresasmanuales != null && gvEmpresasmanuales.Rows.Count > 0)
        {
            foreach (DataKey fila in gvEmpresasmanuales.DataKeys)
            {
                filadt2 = dt2.NewRow();
                filadt2["Empresa"] = Convert.ToString(fila.Values["Empresa"]);
                filadt2["Ruc"] = Convert.ToString(fila.Values["Ruc"]);
                filadt2["IdSector"] = Convert.ToString(fila.Values["IdSector"]);
                filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                filadt2["Fecha_Ingreso"] = Convert.ToString(fila.Values["Fecha_Ingreso"]);
                filadt2["Fecha_Retiro"] = Convert.ToString(fila.Values["Fecha_Retiro"]);
                filadt2["EmpNoExis"] = Convert.ToString(fila.Values["EmpNoExis"]);
                filadt2["RazonSocialEmpresaManual"] = Convert.ToString(fila.Values["RazonSocialEmpresaManual"]);
                filadt2["NroPatronal_Ruc_Alternativo"] = Convert.ToString(fila.Values["NroPatronal_Ruc_Alternativo"]);
                filadt2["IdDetalleClasificadorDoc"] = Convert.ToString(fila.Values["IdDetalleClasificadorDoc"]);
                filadt2["Documento"] = Convert.ToString(fila.Values["Documento"]);
                dt2.Rows.Add(filadt2);
            }
        }
        gvEmpresasmanuales.DataSource = dt2;
        gvEmpresasmanuales.DataBind();
    }

    //DATOS GRILLAS

    //Obtener datos sector
    public DataTable GetSector()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtSector = new DataTable();
        dtSector = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "Sector", ref sMensajeError);
        return dtSector;
    }

    //Obtener datos meses
    public DataTable GetMes()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        return ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 30, ref sMensajeError);
    }

    //Obtener datos años
    public DataTable GetAnio()
    {
        DataTable dtAnios = new DataTable();
        dtAnios.Columns.Add("Anio", typeof(int));
        for (int i = 1997; i > 1929; i--)
        {
            DataRow row = dtAnios.NewRow();
            row["Anio"] = i;
            dtAnios.Rows.Add(row);
        }
        return dtAnios;
    }

    //Obtener datos moneda
    public DataTable GetMoneda()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        return ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "Moneda", ref sMensajeError);
    }

    //Obtener doc salario
    public DataTable GetDocumentosSalarioAutomaticos()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        return ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "DocSalario", ref sMensajeError);
    }

    //Obtener fecha afiliacion
    public DataTable GetSectorSSLP(int iIdSector)
    {
        clsTramite ObjTramite = new clsTramite();
        ObjTramite.iIdConexion = (int)Session["IdConexion"];
        ObjTramite.cOperacion = "Q";
        ObjTramite.IdSector = iIdSector;
        return ObjTramite.ObtenerClasificadorSSLP();
    }

    //Obtener fecha afiliacion
    public DataTable GetPFA(string sMatricula)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";

        clsPersona ObjPersona = new clsPersona();
        ObjPersona.Matricula = sMatricula;
        return ObjPersona.ObtenerDatosReferencial(iIdConexion, cOperacion, ref ObjPersona, ref sMensajeError);
    }

    //Obtener salario referencial
    public DataTable GetSalarioRef(string sMatricula, string sPeriodo)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";

        clsPersona ObjPersona = new clsPersona();
        ObjPersona.Matricula = sMatricula;
        ObjPersona.Periodo = sPeriodo;
        return ObjPersona.ObtenerDatosReferencial(iIdConexion, cOperacion, ref ObjPersona, ref sMensajeError);
    }

    //Validar grilla Automatico
    private bool validagrillaAutomatico()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (txtBuscarEmpresaAutomatico.Text.Trim() == null || txtBuscarEmpresaAutomatico.Text.Trim() == "")
        {
            sDetalleError = "La Empresa es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtBuscarRUCAutomatico.Text.Trim() == null || txtBuscarRUCAutomatico.Text.Trim() == "")
        {
            sDetalleError = "El RUC es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (hddSectorAuto.Value.Trim() == null || hddSectorAuto.Value.Trim() == "")
        {
            sDetalleError = "El Sector es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (grdSalariosAutomaticos == null || grdSalariosAutomaticos.Rows.Count <= 0)
        {
            if (!hddSectorAuto.Value.Trim().Equals(ddlSector.SelectedValue.Trim()))
            {
                sDetalleError = "El Sector Laboral elegido en Datos Personales debe ser similar al Sector de la Empresa.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (ddlAnioAuto.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Año es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlMesAuto.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Mes es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlDocumentoAuto.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Documento es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtMontoAuto.Text.Trim() == null || txtMontoAuto.Text.Trim() == "")
        {
            sDetalleError = "El Monto Total es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtMontoAuto2.Text.Trim() == null || txtMontoAuto2.Text.Trim() == "")
        {
            sDetalleError = "La Copia Monto Total es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (!txtMontoAuto.Text.Equals(txtMontoAuto2.Text))
        {
            sDetalleError = "El Monto Total y la Copia Monto Total deben ser iguales.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlMonedaAuto.SelectedValue.ToString() == "0")
        {
            sDetalleError = "La Moneda es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
        {
            string mes = ddlMesAuto.SelectedValue.ToString();
            string anio = ddlAnioAuto.SelectedValue.ToString();
            int cantidad = 0;
            foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
            {
                if (mes.Equals(Convert.ToString(fila.Values["IdMes"])) && anio.Equals(Convert.ToString(fila.Values["Anio"])))
                {
                    cantidad++;
                }
            }
            if (cantidad != grdSalariosAutomaticos.Rows.Count)
            {
                sDetalleError = "El periodo de las empresas registradas debe ser igual.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }

        return true;
    }

    //Validar grilla manual
    private bool validagrillaEmpresas()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (!txtRazonSocialEmpresaManual_Alternativo.Enabled)
        {
            if (txtEmpresaManual.Text.Trim() == null || txtEmpresaManual.Text.Trim() == "")
            {
                sDetalleError = "La Empresa es requerida.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            if (txtRucManual.Text.Trim() == null || txtRucManual.Text.Trim() == "")
            {
                sDetalleError = "El RUC es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        if (ddlSectorEmpresaManual.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Sector es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtFecha_Ingreso.Text.Trim() == null || txtFecha_Ingreso.Text.Trim() == "")
        {
            sDetalleError = "La Fecha Ingreso es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtFecha_Retiro.Text.Trim() == null || txtFecha_Retiro.Text.Trim() == "")
        {
            sDetalleError = "La Fecha Retiro es requerida.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        try
        {
            if (Convert.ToDateTime(txtFecha_Ingreso.Text.Trim()) > Convert.ToDateTime(txtFecha_Retiro.Text.Trim()))
            {
                sDetalleError = "La Fecha Ingreso no debe ser mayor a la Fecha Retiro.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            else
            {
                if (Convert.ToDateTime(txtFecha_Ingreso.Text.Trim()) >= Convert.ToDateTime("01/06/1997"))
                {
                    sDetalleError = "La Fecha Ingreso no debe ser mayor al 01/06/1997.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
                if (Convert.ToDateTime(txtFecha_Retiro.Text.Trim()) >= Convert.ToDateTime("01/06/1997"))
                {
                    sDetalleError = "La Fecha Retiro no debe ser mayor al 01/06/1997.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }
            }
        }
        catch
        {
            sDetalleError = "Error en el formato de las fechas.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlDocumentoManual.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Documento es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtRazonSocialEmpresaManual_Alternativo.Enabled)
        {

            if (txtRazonSocialEmpresaManual_Alternativo.Text.Trim() == null || txtRazonSocialEmpresaManual_Alternativo.Text.Trim() == "")
            {
                sDetalleError = "La Razón Social es requerida.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            /*if (txtNroPatronal_Ruc_Alternativo.Text.Trim() == null || txtNroPatronal_Ruc_Alternativo.Text.Trim() == "")
            {
                sDetalleError = "El Nro.Patronal/Ruc/Alter es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }*/
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

    private void BuscarEmpresaAuto(string sEmpresa, string sRuc)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        try
        {
            clsTramite ObjTramite = new clsTramite();
            DataTable dtEmpresas = new DataTable();
            dtEmpresas = ObjTramite.BuscarEmpresas(iIdConexion, cOperacion, sEmpresa, sRuc, ref sMensajeError);
            if (dtEmpresas != null && dtEmpresas.Rows.Count > 0)
            {
                gvSeleccionarEmpresaAutomatico.DataSource = dtEmpresas;
                gvSeleccionarEmpresaAutomatico.DataBind();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
    }

    private void BuscarEmpresaManual(string sEmpresa, string sRUC)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        try
        {
            clsTramite ObjTramite = new clsTramite();
            DataTable dtEmpresas = new DataTable();
            dtEmpresas = ObjTramite.BuscarEmpresas(iIdConexion, cOperacion, sEmpresa, sRUC, ref sMensajeError);
            if (dtEmpresas != null && dtEmpresas.Rows.Count > 0)
            {
                gvSeleccionarEmpresaManual.DataSource = dtEmpresas;
                gvSeleccionarEmpresaManual.DataBind();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
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

    //Obtener documentos Articulador
    protected void CargarDocumentos()
    {
        clsDocumentos ObjDocs = new clsDocumentos();
        DataTable dtDocumentos = new DataTable();
        string tipoTramite = "";
        try
        {
            if (this.lblTipo.Text == "AUTOMÁTICO")//automático
            {
                tipoTramite = "AUTOMATICO";//Curso de Adq. - Trámite CC Automático
            }
            if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP" || this.lblTipo.Text == "CRENTA")//manual
            {
                tipoTramite = "MANUAL";//Curso de Adq. - Trámite CC Manual
            }
            ObjDocs.iIdConexion = (int)Session["IdConexion"];
            ObjDocs.cOperacion = "Q";
            ObjDocs.TipoTramite = tipoTramite;
            ObjDocs.IdTipoPersona = Convert.ToInt64(this.rblTipoPersonaInicia.SelectedValue);
            ObjDocs.IdSector = Convert.ToInt64(this.ddlSector.SelectedValue);
            dtDocumentos = ObjDocs.ObtenerDocumentos();
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                rdbtDocs.DataSource = dtDocumentos;
                rdbtDocs.DataTextField = "Descripcion";
                rdbtDocs.DataValueField = "IdTipoDocumento";
                rdbtDocs.DataBind();
                if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDocumentos.Rows)
                    {
                        foreach (ListItem fila in rdbtDocs.Items)
                        {
                            if (row["IdTipoDocumento"].ToString().Equals(fila.Value))
                            {
                                if (row["obligatorio"].ToString().Equals("SI"))
                                {
                                    fila.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ObjDocs.sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }

    }

    //Obtener documentos workflow
    protected void CargarDocumentosWF()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        long lSesion = 0;
        long IdTipoTramite = 0;
        clsDocumentos ObjDocs = new clsDocumentos();
        DataTable dtDocumentos = new DataTable();
        try
        {
            if (this.lblTipo.Text == "AUTOMÁTICO")//automático
            {
                IdTipoTramite = 1401002;//Curso de Adq. - Trámite CC Automático
            }
            if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP" || this.lblTipo.Text == "CRENTA")//manual
            {
                IdTipoTramite = 1401001;//Curso de Adq. - Trámite CC Manual
            }
            dtDocumentos = ObjDocs.ObtenerDocumentosWF(iIdConexion, cOperacion, IdTipoTramite, Convert.ToInt64(this.rblTipoPersonaInicia.SelectedValue), Convert.ToInt64(this.ddlSector.SelectedValue), ref sMensajeError, ref lSesion);
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                rdbtDocs.DataSource = dtDocumentos;
                rdbtDocs.DataTextField = "Comentarios";
                rdbtDocs.DataValueField = "CptoTDOc";
                rdbtDocs.DataBind();
                Session["IdSesionDocumentos"] = lSesion;

                if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDocumentos.Rows)
                    {
                        foreach (ListItem fila in rdbtDocs.Items)
                        {
                            if (row["CptoTDOc"].ToString().Equals(fila.Value))
                            {
                                if (row["FlagObligatorio"].ToString().Equals("1"))
                                {
                                    fila.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }

    }

    //GUARDAR TRÁMITE
    private string GuardarTramite()
    {
        clsPersona objPersona;
        clsPersona objPersonaInicia;
        clsTramite objTramite;
        List<clsEmpresaPersona> lstEmpresaPersona;
        List<clsSalario> lstSalario;
        List<clsDocumentos> lstDocumentos;
        clsSalario objSalario;
        clsEmpresaPersona objEmpresaPersona;
        clsDocumentos objdoc;
        clsPoderNotariado objPoderNotariado;
        long IdTramite = 0;
        long NUP = 0;
        long NUPInicia = 0;
        string res = "not";
        bool conError = false;
        string Error = "Error al realizar la operación";
        string sMensajeError = "";
        string DetalleError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        //Datos Persona
        objPersona = ObtenerDatosPersona();
        NUP = objPersona.RegistrarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
        if (NUP != 0)
        {
            if (!String.IsNullOrEmpty(hdnNupIniciaTramite.Value))
            {
                objPersonaInicia = ObtenerDatosPersonaInicia();
                NUPInicia = objPersonaInicia.RegistrarPersona(iIdConexion, cOperacion, ref objPersonaInicia, ref sMensajeError);
            }
            else
            {
                NUPInicia = NUP;
            }
            //Datos Tramite
            objTramite = ObtenerDatosTramite(NUP, NUPInicia);
            IdTramite = objTramite.RegistrarTramite(iIdConexion, cOperacion, ref objTramite, ref sMensajeError);
            if (IdTramite != 0)
            {
                //Poder Notariado
                if (this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO || this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO_DER_HAB)
                {
                    if (!String.IsNullOrEmpty(hdnNupIniciaTramite.Value))
                    {
                        objPoderNotariado = ObtenerDatosPoder(IdTramite);
                        objPoderNotariado.iIdConexion = iIdConexion;
                        objPoderNotariado.cOperacion = "I";

                        if (!objPoderNotariado.Registrar())
                        {
                            DetalleError = DetalleError + " " + Convert.ToString(objPoderNotariado.sMensajeError);
                            conError = true;
                        }
                    }
                }
                //DOCUMENTOS
                lstDocumentos = ObtenerDocumentos(IdTramite);
                foreach (clsDocumentos item in lstDocumentos)
                {
                    objdoc = item;
                    if (!objdoc.RegistrarDocumentos(iIdConexion, cOperacion, objdoc, ref sMensajeError))
                    {
                        DetalleError = DetalleError + " " + Convert.ToString(sMensajeError);
                        conError = true;
                    }
                }
                //PROCESO AUTOMATICO
                if (this.lblTipo.Text == "AUTOMÁTICO")
                {
                    //Datos Salario
                    lstSalario = ObtenerDatosSalario(IdTramite);
                    foreach (clsSalario item in lstSalario)
                    {
                        objSalario = item;
                        objSalario.iIdConexion = iIdConexion;
                        objSalario.cOperacion = cOperacion;
                        if (!objSalario.Registrar())
                        {
                            DetalleError = DetalleError + " " + Convert.ToString(objSalario.sMensajeError);
                            conError = true;
                        }
                    }
                    //Datos Empresas
                    lstEmpresaPersona = ObtenerDatosEmpresasAuto(IdTramite);
                    foreach (clsEmpresaPersona item in lstEmpresaPersona)
                    {
                        objEmpresaPersona = item;
                        objEmpresaPersona.iIdConexion = iIdConexion;
                        objEmpresaPersona.cOperacion = cOperacion;
                        if (!objEmpresaPersona.Registrar())
                        {
                            DetalleError = DetalleError + " " + Convert.ToString(objEmpresaPersona.sMensajeError);
                            conError = true;
                        }
                    }
                }
                //PROCESO MANUAL
                if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP" || this.lblTipo.Text == "CRENTA")
                {
                    lstEmpresaPersona = ObtenerDatosEmpresas(IdTramite);
                    foreach (clsEmpresaPersona item in lstEmpresaPersona)
                    {
                        objEmpresaPersona = item;
                        objEmpresaPersona.iIdConexion = iIdConexion;
                        objEmpresaPersona.cOperacion = cOperacion;
                        if (!objEmpresaPersona.Registrar())
                        {
                            DetalleError = DetalleError + " " + Convert.ToString(objEmpresaPersona.sMensajeError);
                            conError = true;
                        }
                    }
                }
            }
            else
            {
                DetalleError = Convert.ToString(sMensajeError);
                conError = true;
            }
        }
        else
        {
            DetalleError = Convert.ToString(sMensajeError);
            conError = true;
        }
        if (conError)
        {
            Master.MensajeError(Error, DetalleError);
        }
        else
        {
            res = IdTramite.ToString();
        }
        return res;
    }

    //Iniciar tramite workflow
    private bool IniciarTramite(long IdTramite, int valido, ref string sMensajeError)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "P";
        clsTramite objTramiteInicio;
        int IdTipoTramite = 0;
        //Iniciar Tramite
        objTramiteInicio = new clsTramite();
        objTramiteInicio.IdTramite = IdTramite;
        objTramiteInicio.IdGrupoBeneficio = 3;
        if (this.lblTipo.Text == "AUTOMÁTICO")//automático
        {
            IdTipoTramite = 1401002;//Curso de Adq. - Trámite CC Automático
        }
        if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP" || this.lblTipo.Text == "CRENTA")//manual
        {
            IdTipoTramite = 1401001;//Curso de Adq. - Trámite CC Manual
        }
        objTramiteInicio.IdFlujoTramite = IdTipoTramite;
        objTramiteInicio.validoManual = valido;
        //objTramiteInicio.sesion = (long)Session["IdSesionDocumentos"];
        return objTramiteInicio.IniciarTramite(iIdConexion, cOperacion, ref objTramiteInicio, ref sMensajeError);
    }

    //Validar proceso automatico
    private bool validacionAutomatica(long IdTramite, ref int bValidoManual, ref string sMensaje, ref string sMensajeError)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        clsTramite ObjTramite = new clsTramite();
        return ObjTramite.ValidarProcesoAutomatico(iIdConexion, cOperacion, IdTramite, ref bValidoManual, ref sMensaje, ref sMensajeError);
    }

    //Obtener datos persona
    private clsPersona ObtenerDatosPersona()
    {
        clsPersona Persona = new clsPersona();

        clsFormatoFecha f = new clsFormatoFecha();
        Persona.IdTipoDocumento = Convert.ToInt16(this.ddlTipoDocumento.SelectedValue);
        Persona.IdEstadoCivil = Convert.ToInt16(this.ddlEstadoCivil.SelectedValue);
        Persona.IdEntidadGestora = Convert.ToInt32(rblAFP.SelectedValue);
        Persona.IdSexo = Convert.ToInt16(this.rblSexo.SelectedValue);
        Persona.CUA = Convert.ToInt64(this.txtCUA.Text);
        Persona.Matricula = this.txtMatricula.Text;
        Persona.MatriculaOriginal = this.hddMatriculaORG.Value;
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
        if (!String.IsNullOrEmpty(this.hdnIdPais.Value.Trim()))
        {
            Persona.IdPaisResidencia = Convert.ToInt16(this.hdnIdPais.Value);
        }
        else
        {
            Persona.IdPaisResidencia = Convert.ToInt16(BOLIVIA);
        }
        Persona.CorreoElectronico = this.txtEmail.Text;
        Persona.Celular = this.txtCelular.Text;
        Persona.CelularReferencia = this.txtCelular2.Text;
        Persona.Direccion = this.txtDireccion.Text;
        if (!String.IsNullOrEmpty(this.hdnIdLocalidad.Value.Trim()))
        {
            Persona.IdLocalidad = Convert.ToInt16(this.hdnIdLocalidad.Value);
        }
        else
        {
            Persona.IdLocalidad = 0;
        }
        Persona.Telefono = this.txtTelefono.Text;
        Persona.RegistroActivo = 1;

        return Persona;
    }

    //Obtener datos tramite
    private clsTramite ObtenerDatosTramite(long NUP, long NUPIniciaTramite)
    {
        clsTramite Tramite = new clsTramite();

        if (this.lblTipo.Text == "AUTOMÁTICO")
        {
            Tramite.IdGrupoBeneficio = 3;//Procedimiento Automático aal
            Tramite.IdBeneficio = 1;
            Tramite.IdSubBeneficio = 1;
            Tramite.IdTipoTramite = 357;//normal aal
        }
        if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP" || this.lblTipo.Text == "CRENTA")//Manual
        {
            Tramite.IdGrupoBeneficio = 3;//Procedimiento Manual
            Tramite.IdBeneficio = 1;
            Tramite.IdSubBeneficio = 2;
            Tramite.IdTipoTramite = 356;//Manual modif aal
        }
        if (ACCESO_DIRECTO.Equals(hddProceso.Value))//Acceso Directo
        {
            Tramite.IdOrigen = 765;
            Tramite.NumeroTramiteCRENTA = hddCodigo.Value;
        }
        else
        {
            Tramite.IdOrigen = 340;
            Tramite.NumeroTramiteCRENTA = "-1";
        }

        if (this.ddlSector.SelectedValue != "")
            Tramite.IdSector = Convert.ToInt32(this.ddlSector.SelectedValue);
        else
            Tramite.IdSector = 0;
        Tramite.NUP = NUP;
        Tramite.NUPIniciaTramite = NUPIniciaTramite;
        Tramite.IdTipoIniciaTramite = Convert.ToInt32(this.rblTipoPersonaInicia.SelectedValue);
        Tramite.Observaciones = "INICIO TRAMITE";
        Tramite.IdOficinaNotificacion = Convert.ToInt32(ddlOficinaNotificacion.SelectedValue.ToString());
        Tramite.IdClaseRenta = 31566;
        if (!String.IsNullOrEmpty(hddObservado.Value))
        {
            Tramite.IdObservado = Convert.ToInt64(hddObservado.Value);
        }
        Tramite.IdEstadoTramite = 1;
        Tramite.RegistroActivo = 1;

        return Tramite;
    }

    //Obtener datos Empresa Proceso MANUAL
    private List<clsEmpresaPersona> ObtenerDatosEmpresas(long IdTramite)
    {
        List<clsEmpresaPersona> lstEmpresaPersona = new List<clsEmpresaPersona>();
        if (gvEmpresasmanuales != null && gvEmpresasmanuales.Rows.Count > 0)
        {
            foreach (DataKey fila in gvEmpresasmanuales.DataKeys)
            {
                clsEmpresaPersona objPersonaEmpresa = new clsEmpresaPersona();
                objPersonaEmpresa.IdTramite = IdTramite;
                objPersonaEmpresa.idGrupoBeneficio = 3;
                objPersonaEmpresa.IdEmpresa = Convert.ToString(fila.Values["Ruc"]);
                objPersonaEmpresa.NombreEmpresaDeclarada = Convert.ToString(fila.Values["RazonSocialEmpresaManual"]);
                objPersonaEmpresa.PeriodoInicio = Convert.ToString(fila.Values["Fecha_Ingreso"]);
                objPersonaEmpresa.PeriodoFin = Convert.ToString(fila.Values["Fecha_Retiro"]);
                objPersonaEmpresa.IdSector = Convert.ToInt32(fila.Values["IdSector"]);
                objPersonaEmpresa.NroPatronalRucAlt = Convert.ToString(fila.Values["NroPatronal_Ruc_Alternativo"]);
                objPersonaEmpresa.IdTipoDocSalario = Convert.ToInt32(fila.Values["IdDetalleClasificadorDoc"]);
                objPersonaEmpresa.EstadoRegistro = 1;
                lstEmpresaPersona.Add(objPersonaEmpresa);
            }
        }
        return lstEmpresaPersona;
    }

    //Obtener datos Empresa Proceso AUTOMATICO
    private List<clsEmpresaPersona> ObtenerDatosEmpresasAuto(long IdTramite)
    {
        List<clsEmpresaPersona> lstEmpresaPersona = new List<clsEmpresaPersona>();
        if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
        {
            foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
            {
                clsEmpresaPersona objPersonaEmpresa = new clsEmpresaPersona();
                objPersonaEmpresa.IdTramite = IdTramite;
                objPersonaEmpresa.idGrupoBeneficio = 3;
                objPersonaEmpresa.IdEmpresa = Convert.ToString(fila.Values["Ruc"]);
                objPersonaEmpresa.PeriodoInicio = "01/" + Convert.ToString(fila.Values["IdMes"]) + "/" + Convert.ToString(fila.Values["Anio"]);
                objPersonaEmpresa.PeriodoFin = null;
                objPersonaEmpresa.Monto = Convert.ToString(fila.Values["Total"]);
                objPersonaEmpresa.IdMoneda = Convert.ToInt32(fila.Values["IdDetalleClasificadorMon"]);
                objPersonaEmpresa.IdSector = Convert.ToInt32(fila.Values["IdSector"]);
                objPersonaEmpresa.IdTipoDocSalario = Convert.ToInt32(fila.Values["IdDetalleClasificadorDoc"]);
                if (!String.IsNullOrEmpty(Convert.ToString(fila.Values["IdDocumentoSSLP"])))
                {
                    objPersonaEmpresa.IdSectorSSLP = Convert.ToInt32(fila.Values["IdDocumentoSSLP"]);
                }
                objPersonaEmpresa.ValidaPFA = Convert.ToString(fila.Values["pfa"]);
                if (!String.IsNullOrEmpty(hddMatriculaORG.Value))
                {
                    objPersonaEmpresa.MatriculaORG = hddMatriculaORG.Value;
                }
                else
                {
                    objPersonaEmpresa.MatriculaORG = txtMatricula.Text;
                }
                objPersonaEmpresa.EstadoRegistro = 1;
                lstEmpresaPersona.Add(objPersonaEmpresa);
            }
        }
        return lstEmpresaPersona;
    }

    //Obtener datos Salario AUTOMATICO
    private List<clsSalario> ObtenerDatosSalario(long IdTramite)
    {
        List<clsSalario> lstSalario = new List<clsSalario>();
        if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
        {
            foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
            {
                clsSalario objSalario = new clsSalario();
                objSalario.IdTramite = IdTramite;
                objSalario.IdGrupoBeneficio = 3;
                objSalario.Version = 1;
                objSalario.Componente = 1;
                objSalario.Ruc = Convert.ToString(fila.Values["Ruc"]);
                objSalario.PeriodoSalario = Convert.ToString(fila.Values["IdMes"]) + "/" + Convert.ToString(fila.Values["Anio"]);
                objSalario.SalarioCotizable = Convert.ToString(fila.Values["Total"]);
                objSalario.IdMonedaSalario = Convert.ToInt32(fila.Values["IdDetalleClasificadorMon"]);
                objSalario.IdTipoDocSalario = Convert.ToInt32(fila.Values["IdDetalleClasificadorDoc"]);
                objSalario.IdSector = Convert.ToInt32(fila.Values["IdSector"]);
                objSalario.IdEstadoSalario = 1;
                objSalario.RegistroActivo = 1;
                lstSalario.Add(objSalario);
            }
        }

        return lstSalario;
    }

    //Obtener datos persona inicia tramite
    private clsPersona ObtenerDatosPersonaInicia()
    {
        clsPersona Persona = new clsPersona();
        if (rblTipoPersonaInicia.SelectedValue.ToString() != TITULAR)
        {
            clsFormatoFecha f = new clsFormatoFecha();
            Persona.IdTipoDocumento = Convert.ToInt16(this.ddlTipoDocumentoInicia.SelectedValue);
            Persona.IdEstadoCivil = Convert.ToInt16(this.ddlEstadoCivilInicia.SelectedValue);
            Persona.IdSexo = Convert.ToInt16(this.rdblSexoInicia.SelectedValue);
            Persona.NUB = 0;
            Persona.NumeroDocumento = this.txtNumeroDocumentoInicia.Text;
            Persona.ComplementoSEGIP = this.txtComplementoInicia.Text;
            Persona.DocumentoExpedido = Convert.ToInt32(this.ddlExpedicionInicia.SelectedValue);
            Persona.PrimerNombre = this.txtPrimerNombreInicia.Text;
            Persona.SegundoNombres = this.txtSegundoNombreInicia.Text;
            Persona.PrimerApellido = this.txtPrimerApellidoInicia.Text;
            Persona.SegundoApellido = this.txtSegundoApellidoInicia.Text;
            Persona.ApellidoCasada = this.txtApellidoCasadaInicia.Text;
            Persona.FechaNacimiento = f.GeneraFechaDMY(this.txtFechaNacimientoInicia.Text);
            Persona.IdEntidadGestora = 31511;
            Persona.CUA = 0;
            Persona.Matricula = GenerarMatricula(this.txtPrimerApellidoInicia.Text, this.txtSegundoApellidoInicia.Text, this.txtPrimerNombreInicia.Text, (new clsFormatoFecha()).GeneraFechaDMY(this.txtFechaNacimientoInicia.Text), rdblSexoInicia.Text);
            if (!String.IsNullOrEmpty(this.hddPaisInicia.Value.Trim()))
            {
                Persona.IdPaisResidencia = Convert.ToInt16(this.hddPaisInicia.Value);
            }
            else
            {
                Persona.IdPaisResidencia = Convert.ToInt16(BOLIVIA);
            }
            Persona.CorreoElectronico = this.txtEmailInicia.Text;
            Persona.Celular = this.txtTelefonoCelularInicia.Text;
            Persona.CelularReferencia = this.txtTelefonoReferenciaInicia.Text;
            Persona.Direccion = this.txtDireccionInicia.Text;
            if (!String.IsNullOrEmpty(this.hddLocalidadInicia.Value.Trim()))
            {
                Persona.IdLocalidad = Convert.ToInt16(this.hddLocalidadInicia.Value);
            }
            else
            {
                Persona.IdLocalidad = 0;
            }
            Persona.Telefono = this.txtTelefonoFijoInicia.Text;

            Persona.RegistroActivo = 1;
        }
        return Persona;
    }

    //Obtener datos poder notariado
    private clsPoderNotariado ObtenerDatosPoder(long IdTramite)
    {
        clsPoderNotariado PoderNotariado = new clsPoderNotariado();
        if (rblTipoPersonaInicia.SelectedValue.ToString() != TITULAR)
        {
            clsFormatoFecha f = new clsFormatoFecha();
            PoderNotariado.IdTipoDocumento = Convert.ToInt16(this.ddlTipoDocumentoInicia.SelectedValue);
            PoderNotariado.NumeroDocumento = this.txtNumeroDocumentoInicia.Text;
            PoderNotariado.ComplementoSEGIP = this.txtComplementoInicia.Text;
            PoderNotariado.DocumentoExpedido = Convert.ToInt32(this.ddlExpedicionInicia.SelectedValue);
            PoderNotariado.PrimerNombre = this.txtPrimerNombreInicia.Text;
            PoderNotariado.SegundoNombres = this.txtSegundoNombreInicia.Text;
            PoderNotariado.PrimerApellido = this.txtPrimerApellidoInicia.Text;
            PoderNotariado.SegundoApellido = this.txtSegundoApellidoInicia.Text;
            PoderNotariado.ApellidoCasada = this.txtApellidoCasadaInicia.Text;
            if (!String.IsNullOrEmpty(this.hddPaisInicia.Value.Trim()))
            {
                PoderNotariado.IdPaisResidencia = Convert.ToInt16(this.hddPaisInicia.Value);
            }
            else
            {
                PoderNotariado.IdPaisResidencia = Convert.ToInt16(BOLIVIA);
            }
            PoderNotariado.CorreoElectronico = this.txtEmailInicia.Text;
            PoderNotariado.Celular = this.txtTelefonoCelularInicia.Text;
            PoderNotariado.CelularReferencia = this.txtTelefonoReferenciaInicia.Text;
            PoderNotariado.Direccion = this.txtDireccionInicia.Text;
            if (!String.IsNullOrEmpty(this.hddLocalidadInicia.Value.Trim()))
            {
                PoderNotariado.IdLocalidad = Convert.ToInt16(this.hddLocalidadInicia.Value);
            }
            else
            {
                PoderNotariado.IdLocalidad = 0;
            }
            PoderNotariado.Telefono = this.txtTelefonoFijoInicia.Text;
            PoderNotariado.NroPoder = Convert.ToInt16(this.txtPoderNotarial.Text);
            PoderNotariado.Administracion = this.txtAdministracionPoder.Text;
            PoderNotariado.VigenciaDesde = this.txtVigenciaPoderDel.Text;
            PoderNotariado.VigenciaHasta = this.txtVigenciaPoderAl.Text;
            PoderNotariado.IdTramite = IdTramite;
            PoderNotariado.IdGrupoBeneficio = 3;
            PoderNotariado.IdRegional = Convert.ToInt32(ddlOficinaNotificacion.SelectedValue.ToString());
        }
        return PoderNotariado;
    }

    //Obtener documentos elegidos
    private List<clsDocumentos> ObtenerDocumentos(long IdTramite)
    {
        List<clsDocumentos> lstDocumentos = new List<clsDocumentos>();
        foreach (ListItem fila in rdbtDocs.Items)
        {
            if (fila.Selected)
            {
                clsDocumentos objDocumento = new clsDocumentos();
                objDocumento.IdTramite = IdTramite;
                objDocumento.IdGrupoBeneficio = 3;
                objDocumento.IdTipoDocumento = Convert.ToInt32(fila.Value);
                objDocumento.IdDocumento = 1;
                lstDocumentos.Add(objDocumento);
            }
        }
        return lstDocumentos;
    }

    //Valida que se tengan registrados los datos necesarios para iniciar trámite
    private bool ValidaDatosCompletos()
    {
        if (this.rblTipoPersonaInicia.SelectedItem != null)
        {
            if (this.rblTipoPersonaInicia.SelectedValue.ToString() != TITULAR)
            {
                if (this.hdnNupIniciaTramite.Value != "")
                    return true;
                else
                {
                    this.lblCompletarInformacion.Text = "Debe seleccionar, o insertar la persona que inicia el trámite";
                    this.lblCompletarInformacion.Visible = true;
                    return false;
                }
            }
            else
                return true;
        }
        else
        {
            this.lblCompletarInformacion.Text = "Debe seleccionar el tipo de persona que inicia el trámite";
            this.lblCompletarInformacion.Visible = true;
            return false;
        }
    }

    private bool ValidarObservado()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        if (txtAutorizadori.Text.Trim() == null || txtAutorizadori.Text.Trim() == "")
        {
            sDetalleError = "El Autorizador es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtMotivoi.Text.Trim() == null || txtMotivoi.Text.Trim() == "")
        {
            sDetalleError = "El Motivo es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        if (txtObservacioni.Text.Trim() == null || txtObservacioni.Text.Trim() == "")
        {
            sDetalleError = "Las Observaciones son requeridas.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        return true;
    }

    #endregion

    #region botones

    //GENERAR MATRÍCULA
    protected void btnGenerarMatricula_Click(object sender, EventArgs e)
    {
        if (ValidaDatos())
        {
            txtMatriculaGenerada.Text = GenerarMatricula(this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtPrimerNombre.Text, (new clsFormatoFecha()).GeneraFechaDMY(this.txtFechaNacimiento.Text), rblSexo.Text);
            txtMatricula.Text = txtMatriculaGenerada.Text;
            this.btnImprimir.Focus();
            //this.btnGenerarMatricula.Enabled = false;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
    }

    //BOTON IMPRIMIR
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        if (ValidaDatos())
        {
            btnImprimir.Attributes.Add("onclick", "return printing()");
            this.ibtnVerificar.Visible = true;
        }
    }

    //BOTÓN VALIDAR PERSONA Y HABILITAR PANELES:
    protected void ibtnVerificar_Click(object sender, EventArgs e)
    {
        bool bExisteResolucion = false;
        bool bExisteConvenio = false;
        try
        {
            if (ValidaDatos()) //Valida informacion del formulario
            {
                if (VerificaMatricula()) //valida generacion de matricula
                {
                    if (ValidaCUA()) //valida CUA afiliados
                    {
                        if (ValidaDatosRepetidos())// valida repetidos
                        {
                            HabilitaPanelRepetidos();
                            if (ACCESO_DIRECTO.Equals(hddProceso.Value))//Acceso Directo
                            {
                                bExisteResolucion = ObtenerResoluciones();
                                bExisteConvenio = ObtenerConvenios();
                                if (!bExisteResolucion && !bExisteConvenio)
                                {
                                    HabilitarPaneles(1);
                                }
                            }
                        }
                        else
                        {
                            if (ACCESO_DIRECTO.Equals(hddProceso.Value))//Acceso Directo
                            {
                                bExisteResolucion = ObtenerResoluciones();
                                bExisteConvenio = ObtenerConvenios();
                                if (!bExisteResolucion && !bExisteConvenio)
                                {
                                    HabilitarPaneles(1);
                                }
                            }
                            else
                            {
                                HabilitarPaneles(1);
                            }
                            InhabilitarDatosPersonales();
                        }
                        string msg = "La operacion se realizo con exito";
                        Master.MensajeOk(msg);
                    }
                    else
                    {
                        HabilitaComparaDatos();
                    }
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

    //Permitir seguir con inicio de trámite
    protected void ibtnPermitir_Click(object sender, EventArgs e)
    {
        this.pnlJustificar.Visible = true;
        ModalPopupExtender3.Show();
        txtMotivoi.Focus();
    }

    //Redireccionar al inicio de trámite
    protected void ibtnDenegar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmRegistroTramite.aspx");
    }

    //Actualizar datos
    protected void btnActualizarAP_Click(object sender, EventArgs e)
    {
        this.txtPrimerApellido.Text = this.txtPrimerApellido_IT.Text;
        this.txtSegundoApellido.Text = this.txtSegundoApellido_IT.Text;
        this.txtPrimerNombre.Text = this.txtPrimerNombre_IT.Text;
        this.txtSegundoNombre.Text = this.txtSegundoNombre_IT.Text;
        this.txtFechaNacimiento.Text = this.txtFechaNac_IT.Text;
        this.pnlAfiliados.Visible = false;
        this.txtMatricula.Text = null;
        this.txtMatriculaGenerada.Text = null;
        this.btnGenerarMatricula.Enabled = true;
        this.ModalPopupExtender_COTEJAR.Hide();
    }

    //Registrar Observados
    protected void btnSiJustificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarObservado())
            {
                //Registrar Tramite Observado
                clsObservado ObjObservado = new clsObservado();
                ObjObservado.iIdConexion = (int)Session["IdConexion"];
                ObjObservado.cOperacion = "I";
                ObjObservado.NumeroDocumento = this.txtNumeroDocumento.Text;
                ObjObservado.CUA = this.txtCUA.Text;
                ObjObservado.Matricula = this.txtMatricula.Text;
                ObjObservado.Tabla = this.lblTipo.Text;
                ObjObservado.PrimerApellido = this.txtPrimerApellido.Text;
                ObjObservado.SegundoApellido = this.txtSegundoApellido.Text;
                ObjObservado.PrimerNombre = this.txtPrimerNombre.Text;
                ObjObservado.Autorizador = this.txtAutorizadori.Text;
                ObjObservado.Motivo = this.txtMotivoi.Text;
                ObjObservado.Observaciones = this.txtObservacioni.Text;
                if (ObjObservado.Registrar())
                {
                    hddObservado.Value = Convert.ToString(ObjObservado.IdObservado);
                    //Registrar Tramite Observado Detalle
                    clsObservadoDetalle ObjObservadoDetalle = new clsObservadoDetalle();
                    ObjObservadoDetalle.iIdConexion = ObjObservado.iIdConexion;
                    ObjObservadoDetalle.cOperacion = ObjObservado.cOperacion;
                    ObjObservadoDetalle.IdObservado = ObjObservado.IdObservado;
                    foreach (GridViewRow dr in gv_ValidaDatosRepetidos.Rows)
                    {
                        ObjObservadoDetalle.Tramite = dr.Cells[0].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.Tipo = dr.Cells[1].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.NumeroDocumento = dr.Cells[2].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.Matricula = dr.Cells[3].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.CUA = dr.Cells[4].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.PrimeroApellido = dr.Cells[5].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.SegundoApellido = dr.Cells[6].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.Nombres = dr.Cells[7].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.FechaNacimiento = dr.Cells[8].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.Sector = dr.Cells[9].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.DHMatricula = dr.Cells[10].Text.Replace("&nbsp;", "");
                        ObjObservadoDetalle.EstadoObservado = dr.Cells[11].Text.Replace("&nbsp;", "");
                        if (!ObjObservadoDetalle.Registrar())
                        {
                            string Error = "Error al realizar la operación";
                            string DetalleError = Convert.ToString(ObjObservadoDetalle.sMensajeError);
                            Master.MensajeError(Error, DetalleError);
                        }
                    }
                    HabilitarPaneles(1);
                    InhabilitarDatosPersonales();
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = Convert.ToString(ObjObservado.sMensajeError);
                    Master.MensajeError(Error, DetalleError);
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

    //Boton Residencia Siguiente
    protected void btnSiguienteResidencia_Click(object sender, EventArgs e)
    {
        if (ValidaDatosResidencia())
        {
            this.txtBuscarPais.Enabled = false;
            this.ibtnBuscarPais.Enabled = false;
            this.txtBuscarLocalidad.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtCelular.Enabled = false;
            this.txtCelular2.Enabled = false;
            this.txtEmail.Enabled = false;
            this.ibtnBuscarLocalidad.Enabled = false;
            HabilitarPaneles(2);
            this.btnSiguienteResidencia.Enabled = false;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
    }

    //Boton Tramite Siguiente
    protected void btnSiguienteTramite_Click(object sender, EventArgs e)
    {
        if (ValidaDatosTramite())
        {
            this.rblTipoPersonaInicia.Enabled = false;
            this.txtNombreCompeto.Enabled = false;
            this.btnBuscarTramitador.Enabled = false;

            this.txtPrimerApellidoInicia.Enabled = false;
            this.txtSegundoApellidoInicia.Enabled = false;
            this.txtApellidoCasadaInicia.Enabled = false;
            this.txtPrimerNombreInicia.Enabled = false;
            this.txtSegundoNombreInicia.Enabled = false;
            this.txtFechaNacimientoInicia.Enabled = false;
            this.ddlTipoDocumentoInicia.Enabled = false;
            this.txtNumeroDocumentoInicia.Enabled = false;
            this.txtComplementoInicia.Enabled = false;
            this.ddlExpedicionInicia.Enabled = false;
            this.rdblSexoInicia.Enabled = false;
            this.ddlEstadoCivilInicia.Enabled = false;

            this.txtPaisInicia.Enabled = false;
            this.imgBtnPaisInicia.Enabled = false;
            this.txtLocalidadInicia.Enabled = false;
            this.imgBtnLocalidadInicia.Enabled = false;
            this.txtDireccionInicia.Enabled = false;
            this.txtTelefonoFijoInicia.Enabled = false;
            this.txtTelefonoCelularInicia.Enabled = false;
            this.txtEmailInicia.Enabled = false;
            this.txtTelefonoReferenciaInicia.Enabled = false;
            this.txtPoderNotarial.Enabled = false;
            this.txtAdministracionPoder.Enabled = false;
            this.txtVigenciaPoderDel.Enabled = false;
            this.txtVigenciaPoderAl.Enabled = false;

            HabilitarPaneles(3);
            this.btnSiguienteTramite.Enabled = false;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
    }

    //Boton documentos siguiente 
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (ValidaDocumentos())
        {
            this.rdbtDocs.Enabled = false;
            HabilitarPaneles(4);
            this.Button2.Enabled = false;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
    }

    //Boton PA Siguiente
    protected void btnSiguientePA_Click(object sender, EventArgs e)
    {
        imgBuscarEmpresaAuto.Enabled = false;
        ddlMesAuto.Enabled = false;
        ddlAnioAuto.Enabled = false;
        ddlMonedaAuto.Enabled = false;
        ddlDocumentoAuto.Enabled = false;
        txtMontoAuto.Enabled = false;
        txtMontoAuto2.Enabled = false;
        this.grdSalariosAutomaticos.Enabled = false;
        this.btnSiguientePA.Enabled = false;
        this.btnIniciarTramite.Visible = true;
        this.btnAgregarAuto.Enabled = false;
        ckboxSeguroSocial.Enabled = false;
        ddlSectorSSLP.Enabled = false;
        ckboxPFA.Enabled = false;

        string msg = "La operacion se realizo con exito";
        Master.MensajeOk(msg);
    }

    //Boton PM Siguiente
    protected void btnSiguientePM_Click(object sender, EventArgs e)
    {
        this.ibtnBuscarEmpresaManual.Enabled = false;
        this.txtEmpresaManual.Enabled = false;
        this.txtRucManual.Enabled = false;
        ddlSectorEmpresaManual.Enabled = false;
        txtFecha_Ingreso.Enabled = false;
        txtFecha_Retiro.Enabled = false;
        ddlDocumentoManual.Enabled = false;
        txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
        txtNroPatronal_Ruc_Alternativo.Enabled = false;
        this.gvEmpresasmanuales.Enabled = false;
        this.btnSiguientePM.Enabled = false;
        this.btnIniciarTramite.Visible = true;
        this.btnAgregarManual.Enabled = false;
        string msg = "La operacion se realizo con exito";
        Master.MensajeOk(msg);
    }

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        if (ACCESO_DIRECTO.Equals(hddProceso.Value))//Acceso Directo
        {
            Response.Redirect("wfrmAccesoDirecto.aspx?Tipo=RG");
        }
        else
        {
            Response.Redirect("wfrmRegistroTramite.aspx");
        }
    }

    //Buscar pais
    protected void ibtnBuscarPais_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusPais.Text = this.txtBuscarPais.Text;
        BuscarPais(this.txtBuscarPais.Text, gvPais);
        this.gvPais.Visible = true;
        ModalPopupExtender_Pais.Show();
        this.txtBusPais.Focus();
    }

    //Buscar localidad
    protected void ibtnBuscarLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        if (this.hdnIdPais.Value.Equals(BOLIVIA))
        {
            this.txtBusLocalidad.Text = this.txtBuscarLocalidad.Text;
            BuscarLocalidad(this.txtBuscarLocalidad.Text, gvGeo);
            this.gvGeo.Visible = true;
            ModalPopupExtender_LOCALIDAD.Show();
            this.txtBusLocalidad.Focus();
        }
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

        this.txtTelefonoFijoInicia.Text = null;
        this.txtTelefonoFijoInicia.Enabled = true;
        this.txtEmailInicia.Text = null;
        this.txtEmailInicia.Enabled = true;
        this.txtTelefonoCelularInicia.Text = null;
        this.txtTelefonoCelularInicia.Enabled = true;
        this.txtTelefonoReferenciaInicia.Text = null;
        this.txtTelefonoReferenciaInicia.Enabled = true;
        this.txtDireccionInicia.Text = null;
        this.txtDireccionInicia.Enabled = true;
        this.hddPaisInicia.Value = null;
        imgBtnPaisInicia.Enabled = true;
        this.hddLocalidadInicia.Value = null;
        imgBtnLocalidadInicia.Enabled = true;
        this.txtLocalidadInicia.Text = null;
        this.txtLocalidadInicia.Enabled = false;
        this.txtPaisInicia.Text = null;
        this.txtPaisInicia.Enabled = false;
        this.txtPoderNotarial.Text = null;
        this.txtAdministracionPoder.Text = null;
        this.txtVigenciaPoderDel.Text = null;
        this.txtVigenciaPoderAl.Text = null;
        this.hdnNupIniciaTramite.Value = "-1";
        CargarValoresDefecto(2);
        this.txtPrimerApellidoInicia.Focus();
    }

    //BUSCAR EMPRESA Proceso automatico 
    protected void btnBuscarAutomatico_Click1(object sender, EventArgs e)
    {
        this.txtBusEmpAuto.Text = this.txtBuscarEmpresaAutomatico.Text;
        this.txtBusRucAuto.Text = this.txtBuscarRUCAutomatico.Text;
        BuscarEmpresaAuto(this.txtBuscarEmpresaAutomatico.Text, this.txtBuscarRUCAutomatico.Text);
        gvSeleccionarEmpresaAutomatico.Visible = true;
        ModalPopupExtender.Show();
    }

    //BUSCAR EMPRESA Proceso manual
    protected void ibtnBuscarEmpresaManual_Click(object sender, EventArgs e)
    {
        this.txtBusEmpMan.Text = this.txtEmpresaManual.Text;
        this.txtBusRucMan.Text = this.txtRucManual.Text;
        BuscarEmpresaManual(this.txtEmpresaManual.Text, this.txtRucManual.Text);
        gvSeleccionarEmpresaManual.Visible = true;
        ModalPopupExtenderEmpresasManual2.Show();
    }

    //VALIDA Y LLAMA A FUNCION QUE GUARDA EL TRAMITE
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        this.btnIniciarTramite.Enabled = false;
        try
        {
            string IdTramite = "";
            string sTexto = "";
            string sMensajerror = "";
            int bValidoManual = 1;
            clsTramite flujo = new clsTramite();
            IdTramite = GuardarTramite();
            this.lblCompletarInformacion.Visible = true;
            if (IsNumeric(IdTramite))
            {
                HiddenIdtramite.Value = IdTramite.ToString();
                if (this.lblTipo.Text == "AUTOMÁTICO")//automático
                {
                    if (validacionAutomatica(Convert.ToInt64(IdTramite), ref bValidoManual, ref sTexto, ref sMensajerror))
                    {
                        lblResultadoValidacionAutomatica.Text = sTexto;
                    }
                    else
                    {
                        throw new System.InvalidOperationException(sMensajerror);
                    }
                }
                /*Inicio Work Flow */
                if (CON_WF.Equals("SI"))
                {
                    if (!IniciarTramite(Convert.ToInt64(IdTramite), bValidoManual, ref sMensajerror))
                    {
                        throw new System.InvalidOperationException(sMensajerror);
                    }
                }
                else
                {
                    /*Inicio Articulador */
                    flujo.iIdConexion = (int)Session["IdConexion"];
                    flujo.cOperacion = "I";
                    flujo.Tipo = "Inicia";
                    flujo.IdTramite = Convert.ToInt64(IdTramite);
                    if (!flujo.FlujoTramite())
                    {
                        throw new System.InvalidOperationException(flujo.sMensajeError);
                    }
                }
                this.lblCompletarInformacion.Text = "Se ha registrado correctamente el trámite: " + IdTramite.ToString();
                this.btnReporte.Visible = true;
                btnReporte.OnClientClick = "window.open('wfrmReport.aspx?tramite=" + IdTramite.ToString() + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
                this.btnForm02.Visible = true;
                btnForm02.OnClientClick = "window.open('wfrmReportForm02.aspx?tramite=" + IdTramite.ToString() + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
                this.btnCancelar.Text = "Volver";
                //Poder Notariado
                if (!String.IsNullOrEmpty(hdnNupIniciaTramite.Value) && (this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO || this.rblTipoPersonaInicia.SelectedItem.Value == APODERADO_DER_HAB))
                {
                    this.btnReportePoder.Visible = true;
                }
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
            else
            {
                this.lblCompletarInformacion.Text = IdTramite.ToString();
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Boton de reporte
    protected void btnForm02_Click(object sender, System.EventArgs e)
    {
        string Variable = HiddenIdtramite.Value;
        //Response.Redirect("wfrmReportForm02.aspx?tramite=" + Variable);
        //btnForm02.OnClientClick = "window.open('wfrmReportForm02.aspx?tramite=" + Variable + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";        
    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string Variable = HiddenIdtramite.Value;
        //Response.Redirect("wfrmReport.aspx?tramite=" + Variable);
        //btnReporte.OnClientClick = "window.open('wfrmReport.aspx?tramite=" + Variable + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
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

    protected void btnAgregarAuto_Click(object sender, EventArgs e)
    {
        if (validagrillaAutomatico())
        {
            AgregarEmpAuto();
            txtBuscarEmpresaAutomatico.Text = "";
            txtBuscarRUCAutomatico.Text = "";
            hddSectorAuto.Value = "";
            txtSectorAuto.Text = "";
            ddlMesAuto.SelectedValue = "0";
            ddlAnioAuto.SelectedValue = "0";
            txtMontoAuto.Text = "";
            txtMontoAuto2.Text = "";
            ddlMonedaAuto.SelectedValue = "0";
            ddlDocumentoAuto.SelectedValue = "0";
            ckboxSeguroSocial.Checked = false;
            ckboxPFA.Checked = false;
            txtDocumentoSSLP.Text = "";
            ddlSectorSSLP.SelectedValue = null;
            ddlSectorSSLP.Enabled = false;
            btnSiguientePA.Visible = true;
            Master.MensajeCancel();
        }
    }

    protected void btnAgregarManual_Click(object sender, EventArgs e)
    {
        if (validagrillaEmpresas())
        {
            AgregarEmpManual();
            txtEmpresaManual.Text = "";
            txtEmpresaManual.Enabled = false;
            txtRucManual.Text = "";
            txtRucManual.Enabled = false;
            hddSectorManual.Value = "";
            ddlSectorEmpresaManual.SelectedValue = "0";
            ddlSectorEmpresaManual.Enabled = false;
            txtFecha_Ingreso.Text = "";
            txtFecha_Retiro.Text = "";
            ddlDocumentoManual.SelectedValue = "0";
            txtRazonSocialEmpresaManual_Alternativo.Text = "";
            txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
            txtNroPatronal_Ruc_Alternativo.Text = "";
            txtNroPatronal_Ruc_Alternativo.Enabled = false;
            btnSiguientePM.Visible = true;
            Master.MensajeCancel();
        }
    }

    protected void btnSiguienteAcceso_Click(object sender, EventArgs e)
    {
        HabilitarPaneles(1);
        btnSiguienteAcceso.Enabled = false;
    }

    //Buscar pais
    protected void ibtnBuscarPaisInicia_Click(object sender, ImageClickEventArgs e)
    {
        this.txtPaisIniciaBus.Text = this.txtPaisInicia.Text;
        BuscarPais(this.txtPaisInicia.Text, gvPaisInicia);
        this.gvPaisInicia.Visible = true;
        mpePaisInicia.Show();
        this.txtPaisIniciaBus.Focus();
    }

    //Buscar localidad
    protected void ibtnBuscarLocalidadInicia_Click(object sender, ImageClickEventArgs e)
    {
        if (this.hddPaisInicia.Value.Equals(BOLIVIA))
        {
            this.txtLocalidadIniciaBus.Text = this.txtLocalidadInicia.Text;
            BuscarLocalidad(this.txtLocalidadInicia.Text, gvLocalidadInicia);
            this.gvLocalidadInicia.Visible = true;
            mpeLocalidadInicia.Show();
            this.txtLocalidadIniciaBus.Focus();
        }
    }

    //Reporte
    protected void btnReportePoder_Click(object sender, EventArgs e)
    {
        Session["IdTramite"] = HiddenIdtramite.Value;
        Session["TipoReporte"] = "PODER";
        //Response.Redirect("wfrmReportTramite.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReportTramite.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
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
        BuscarLocalidad(this.txtBusLocalidad.Text, gvGeo);
        ModalPopupExtender_LOCALIDAD.Show();
    }

    protected void gvGeo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGeo.PageIndex = e.NewPageIndex;
        BuscarLocalidad(this.txtBusLocalidad.Text, gvGeo);
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

    #region grilla paises

    protected void btnCancelPais_Click(object sender, EventArgs e)
    {
        this.gvPais.Visible = false;
        this.txtBuscarPais.Focus();
    }

    protected void btnBusPais_Click(object sender, EventArgs e)
    {
        BuscarPais(this.txtBusPais.Text, gvPais);
        ModalPopupExtender_Pais.Show();
    }

    protected void gvPais_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPais.PageIndex = e.NewPageIndex;
        BuscarPais(this.txtBusPais.Text, gvPais);
        ModalPopupExtender_Pais.Show();
    }

    protected void gvPais_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvPais = (GridView)sender;
        gvPais.PageIndex = e.NewSelectedIndex;
        gvPais.DataBind();
        ModalPopupExtender_Pais.Show();
    }

    protected void gvPais_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdPais")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            this.hdnIdPais.Value = Convert.ToString(gvPais.DataKeys[Index].Values["CodigoPais"]);
            this.txtBuscarPais.Text = Convert.ToString(gvPais.DataKeys[Index].Values["NombrePais"]);
            this.gvPais.Visible = false;
            this.txtBuscarPais.Focus();
            if (!this.hdnIdPais.Value.Equals(BOLIVIA))
            {
                this.txtBuscarLocalidad.Text = "";
                this.hdnIdLocalidad.Value = "0";
            }
            ModalPopupExtender_Pais.Hide();
        }
    }

    #endregion

    #region grilla paises inicia

    protected void btnCancelPaisInicia_Click(object sender, EventArgs e)
    {
        this.gvPaisInicia.Visible = false;
        this.txtPaisInicia.Focus();
    }

    protected void btnBusPaisInicia_Click(object sender, EventArgs e)
    {
        BuscarPais(this.txtPaisIniciaBus.Text, gvPaisInicia);
        mpePaisInicia.Show();
    }

    protected void gvPaisInicia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPaisInicia.PageIndex = e.NewPageIndex;
        BuscarPais(this.txtPaisIniciaBus.Text, gvPaisInicia);
        mpePaisInicia.Show();
    }

    protected void gvPaisInicia_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvPaisInicia = (GridView)sender;
        gvPaisInicia.PageIndex = e.NewSelectedIndex;
        gvPaisInicia.DataBind();
        mpePaisInicia.Show();
    }

    protected void gvPaisInicia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdPais")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            this.hddPaisInicia.Value = Convert.ToString(gvPaisInicia.DataKeys[Index].Values["CodigoPais"]);
            this.txtPaisInicia.Text = Convert.ToString(gvPaisInicia.DataKeys[Index].Values["NombrePais"]);
            this.gvPaisInicia.Visible = false;
            this.txtPaisInicia.Focus();
            if (!this.hddPaisInicia.Value.Equals(BOLIVIA))
            {
                this.txtLocalidadInicia.Text = "";
                this.hddLocalidadInicia.Value = "0";
            }
            mpePaisInicia.Hide();
        }
    }

    #endregion

    #region grilla localidades inicia

    protected void btnCancelLocalidadInicia_Click(object sender, EventArgs e)
    {
        this.gvLocalidadInicia.Visible = false;
        this.txtLocalidadInicia.Focus();
    }

    protected void btnBusLocalidadInicia_Click(object sender, EventArgs e)
    {
        BuscarLocalidad(this.txtLocalidadIniciaBus.Text, gvLocalidadInicia);
        mpeLocalidadInicia.Show();
    }

    protected void gvLocalidadInicia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLocalidadInicia.PageIndex = e.NewPageIndex;
        BuscarLocalidad(this.txtLocalidadIniciaBus.Text, gvLocalidadInicia);
        mpeLocalidadInicia.Show();
    }

    protected void gvLocalidadInicia_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvLocalidadInicia = (GridView)sender;
        gvLocalidadInicia.PageIndex = e.NewSelectedIndex;
        gvLocalidadInicia.DataBind();
        mpeLocalidadInicia.Show();
    }

    protected void gvLocalidadInicia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdLocalidad")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            this.hddLocalidadInicia.Value = Convert.ToString(gvLocalidadInicia.DataKeys[Index].Values["CodigoLocalidad"]);
            this.txtLocalidadInicia.Text = Convert.ToString(gvLocalidadInicia.DataKeys[Index].Values["NombreLocalidad"]);
            this.gvLocalidadInicia.Visible = false;
            this.txtLocalidadInicia.Focus();
            mpeLocalidadInicia.Hide();
        }
    }

    #endregion

    #region grilla empresas manual

    protected void ibtnNuevaEmpresaManual_Click(object sender, EventArgs e)
    {
        txtEmpresaManual.Text = "";
        txtEmpresaManual.Enabled = false;
        txtRucManual.Text = "";
        txtRucManual.Enabled = false;
        ddlSectorEmpresaManual.SelectedValue = "0";
        ddlSectorEmpresaManual.Enabled = true;

        txtRazonSocialEmpresaManual_Alternativo.Text = "";
        txtRazonSocialEmpresaManual_Alternativo.Enabled = true;
        txtNroPatronal_Ruc_Alternativo.Text = "";
        txtNroPatronal_Ruc_Alternativo.Enabled = true;
        ddlSectorEmpresaManual.Focus();
    }

    protected void gvSeleccionarEmpresaManual_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvSeleccionarEmpresaManual = (GridView)sender;
        gvSeleccionarEmpresaManual.PageIndex = e.NewSelectedIndex;
        gvSeleccionarEmpresaManual.DataBind();
        ModalPopupExtenderEmpresasManual2.Show();
    }

    protected void gvSeleccionarEmpresaManual_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSeleccionarEmpresaManual.PageIndex = e.NewPageIndex;
        BuscarEmpresaManual(this.txtBusEmpMan.Text, this.txtBusRucMan.Text);
        ModalPopupExtenderEmpresasManual2.Show();
    }

    protected void gvSeleccionarEmpresaManual_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int Index;
            if (e.CommandName == "cmdEmpresaMan")
            {
                Index = Convert.ToInt32(e.CommandArgument);
                string ruc = Convert.ToString(gvSeleccionarEmpresaManual.DataKeys[Index].Values["RUC"]);
                string empresa = Convert.ToString(gvSeleccionarEmpresaManual.DataKeys[Index].Values["NombreEmpresa"]);
                string IdSector = Convert.ToString(gvSeleccionarEmpresaManual.DataKeys[Index].Values["IdSector"]);
                string sector = Convert.ToString(gvSeleccionarEmpresaManual.DataKeys[Index].Values["DescripcionSector"]);
                this.txtRucManual.Text = ruc;
                this.txtEmpresaManual.Text = empresa;
                this.hddSectorManual.Value = IdSector;
                this.ddlSectorEmpresaManual.SelectedValue = IdSector;
                this.txtRazonSocialEmpresaManual_Alternativo.Text = "";
                this.txtNroPatronal_Ruc_Alternativo.Text = "";
                this.txtRucManual.Enabled = false;
                this.txtEmpresaManual.Enabled = false;
                this.ddlSectorEmpresaManual.Enabled = false;
                this.gvSeleccionarEmpresaManual.Visible = false;
                this.txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
                this.txtNroPatronal_Ruc_Alternativo.Enabled = false;
                ModalPopupExtenderEmpresasManual2.Hide();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
        }
    }

    protected void gvEmpresasmanuales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        if (e.CommandName == "cmdEliminarEmpManual")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            dt2 = new DataTable();
            dt2.Columns.Add("Empresa");
            dt2.Columns.Add("Ruc");
            dt2.Columns.Add("IdSector");
            dt2.Columns.Add("Sector");
            dt2.Columns.Add("Fecha_Ingreso");
            dt2.Columns.Add("Fecha_Retiro");
            dt2.Columns.Add("EmpNoExis");
            dt2.Columns.Add("RazonSocialEmpresaManual");
            dt2.Columns.Add("NroPatronal_Ruc_Alternativo");
            dt2.Columns.Add("IdDetalleClasificadorDoc");
            dt2.Columns.Add("Documento");
            // salvar datos de la grid
            if (gvEmpresasmanuales != null && gvEmpresasmanuales.Rows.Count > 0)
            {
                foreach (DataKey fila in gvEmpresasmanuales.DataKeys)
                {
                    filadt2 = dt2.NewRow();
                    filadt2["Empresa"] = Convert.ToString(fila.Values["Empresa"]);
                    filadt2["Ruc"] = Convert.ToString(fila.Values["Ruc"]);
                    filadt2["IdSector"] = Convert.ToString(fila.Values["IdSector"]);
                    filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                    filadt2["Fecha_Ingreso"] = Convert.ToString(fila.Values["Fecha_Ingreso"]);
                    filadt2["Fecha_Retiro"] = Convert.ToString(fila.Values["Fecha_Retiro"]);
                    filadt2["EmpNoExis"] = Convert.ToString(fila.Values["EmpNoExis"]);
                    filadt2["RazonSocialEmpresaManual"] = Convert.ToString(fila.Values["RazonSocialEmpresaManual"]);
                    filadt2["NroPatronal_Ruc_Alternativo"] = Convert.ToString(fila.Values["NroPatronal_Ruc_Alternativo"]);
                    filadt2["IdDetalleClasificadorDoc"] = Convert.ToString(fila.Values["IdDetalleClasificadorDoc"]);
                    filadt2["Documento"] = Convert.ToString(fila.Values["Documento"]);
                    dt2.Rows.Add(filadt2);
                }
            }
            dt2.Rows.RemoveAt(Index);
            gvEmpresasmanuales.DataSource = dt2;
            gvEmpresasmanuales.DataBind();
            if (dt2.Rows.Count <= 0)
            {
                btnSiguientePM.Visible = false;
            }
        }
    }

    protected void btnBusEmpresaManual_Click(object sender, EventArgs e)
    {
        BuscarEmpresaManual(this.txtBusEmpMan.Text, this.txtBusRucMan.Text);
        ModalPopupExtenderEmpresasManual2.Show();
    }

    #endregion

    #region grilla empresas automatico

    protected void btnBusEmpresaAuto_Click(object sender, EventArgs e)
    {
        BuscarEmpresaAuto(this.txtBusEmpAuto.Text, this.txtBusRucAuto.Text);
        ModalPopupExtender.Show();
    }

    protected void gvSeleccionarEmpresaAutomatico_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdEmpresaAuto")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string ruc = Convert.ToString(gvSeleccionarEmpresaAutomatico.DataKeys[Index].Values["RUC"]);
            string empresa = Convert.ToString(gvSeleccionarEmpresaAutomatico.DataKeys[Index].Values["NombreEmpresa"]);
            string IdSector = Convert.ToString(gvSeleccionarEmpresaAutomatico.DataKeys[Index].Values["IdSector"]);
            string sector = Convert.ToString(gvSeleccionarEmpresaAutomatico.DataKeys[Index].Values["DescripcionSector"]);
            this.txtBuscarRUCAutomatico.Text = ruc;
            this.txtBuscarEmpresaAutomatico.Text = empresa;
            this.hddSectorAuto.Value = IdSector;
            this.txtSectorAuto.Text = sector;
            this.gvSeleccionarEmpresaAutomatico.Visible = false;
            ModalPopupExtender.Hide();
        }
    }

    protected void gvSeleccionarEmpresaAutomatico_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSeleccionarEmpresaAutomatico.PageIndex = e.NewPageIndex;
        BuscarEmpresaAuto(this.txtBusEmpAuto.Text, this.txtBusRucAuto.Text);
        ModalPopupExtender.Show();
    }

    protected void gvSeleccionarEmpresaAutomatico_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvSeleccionarEmpresaAutomatico = (GridView)sender;
        gvSeleccionarEmpresaAutomatico.PageIndex = e.NewSelectedIndex;
        gvSeleccionarEmpresaAutomatico.DataBind();
        ModalPopupExtender.Show();
    }

    protected void grdSalariosAutomaticos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        if (e.CommandName == "cmdEliminarEmp")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            dt2 = new DataTable();
            dt2.Columns.Add("Empresa");
            dt2.Columns.Add("Ruc");
            dt2.Columns.Add("IdSector");
            dt2.Columns.Add("Sector");
            dt2.Columns.Add("IdMes");
            dt2.Columns.Add("Mes");
            dt2.Columns.Add("Anio");
            dt2.Columns.Add("Total");
            dt2.Columns.Add("CopiaTotal");
            dt2.Columns.Add("IdDetalleClasificadorMon");
            dt2.Columns.Add("Moneda");
            dt2.Columns.Add("IdDetalleClasificadorDoc");
            dt2.Columns.Add("Documento");
            dt2.Columns.Add("pfa");
            dt2.Columns.Add("IdDocumentoSSLP");
            dt2.Columns.Add("DocumentoSSLP");
            // salvar datos de la grid
            if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
            {
                foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
                {
                    filadt2 = dt2.NewRow();
                    filadt2["Empresa"] = Convert.ToString(fila.Values["Empresa"]);
                    filadt2["Ruc"] = Convert.ToString(fila.Values["Ruc"]);
                    filadt2["IdSector"] = Convert.ToString(fila.Values["IdSector"]);
                    filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                    filadt2["IdMes"] = Convert.ToString(fila.Values["IdMes"]);
                    filadt2["Mes"] = Convert.ToString(fila.Values["Mes"]);
                    filadt2["Anio"] = Convert.ToString(fila.Values["Anio"]);
                    filadt2["Total"] = Convert.ToString(fila.Values["Total"]);
                    filadt2["CopiaTotal"] = Convert.ToString(fila.Values["CopiaTotal"]);
                    filadt2["IdDetalleClasificadorMon"] = Convert.ToString(fila.Values["IdDetalleClasificadorMon"]);
                    filadt2["Moneda"] = Convert.ToString(fila.Values["Moneda"]);
                    filadt2["IdDetalleClasificadorDoc"] = Convert.ToString(fila.Values["IdDetalleClasificadorDoc"]);
                    filadt2["Documento"] = Convert.ToString(fila.Values["Documento"]);
                    filadt2["pfa"] = Convert.ToString(fila.Values["pfa"]);
                    filadt2["IdDocumentoSSLP"] = Convert.ToString(fila.Values["IdDocumentoSSLP"]);
                    filadt2["DocumentoSSLP"] = Convert.ToString(fila.Values["DocumentoSSLP"]);
                    dt2.Rows.Add(filadt2);
                }
            }
            dt2.Rows.RemoveAt(Index);
            grdSalariosAutomaticos.DataSource = dt2;
            grdSalariosAutomaticos.DataBind();
            if (dt2.Rows.Count <= 0)
            {
                btnSiguientePA.Visible = false;
            }

        }
    }

    protected void ckboxSeguroSocial_CheckedChanged(object sender, EventArgs e)
    {
        if (ckboxSeguroSocial.Checked)
        {
            DataTable dtDocumentos = GetSectorSSLP(Convert.ToInt16(hddSectorAuto.Value));
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                ddlSectorSSLP.DataSource = dtDocumentos;
                ddlSectorSSLP.DataTextField = "Descripcion";
                ddlSectorSSLP.DataValueField = "IdSectorSeguridadSocial";
                ddlSectorSSLP.DataBind();
                ddlSectorSSLP.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlSectorSSLP.SelectedValue = "0";
                ddlSectorSSLP.Enabled = true;
                txtDocumentoSSLP.Text = null;
            }
        }
        else
        {
            ddlSectorSSLP.DataSource = null;
            ddlSectorSSLP.DataBind();
            ddlSectorSSLP.SelectedValue = null;
            ddlSectorSSLP.Enabled = false;
            txtDocumentoSSLP.Text = null;
        }
    }

    protected void ddlSectorSSLP_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtDocumentos = GetSectorSSLP(Convert.ToInt16(hddSectorAuto.Value));
        if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
        {
            foreach (DataRow row in dtDocumentos.Rows)
            {
                if (ddlSectorSSLP.SelectedValue.Equals(row["IdSectorSeguridadSocial"].ToString()))
                {
                    txtDocumentoSSLP.Text = row["Documento"].ToString();
                }
            }
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
                try
                {
                    this.ddlEstadoCivilInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdEstadoCivil"]);
                    this.ddlEstadoCivilInicia.Enabled = false;
                }
                catch (Exception ex)
                {
                    this.ddlEstadoCivilInicia.SelectedValue = null;
                    this.ddlEstadoCivilInicia.Enabled = true;
                    System.Console.Out.WriteLine(ex.Message);
                }


                this.txtComplementoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["ComplementoSEGIP"]);
                this.txtComplementoInicia.Enabled = false;
                try
                {

                    this.ddlTipoDocumentoInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdTipoDocumento"]);
                    this.ddlTipoDocumentoInicia.Enabled = false;
                }
                catch (Exception ex)
                {
                    this.ddlTipoDocumentoInicia.SelectedValue = null;
                    this.ddlTipoDocumentoInicia.Enabled = true;
                    System.Console.Out.WriteLine(ex.Message);
                }
                try
                {
                    this.ddlExpedicionInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdDocumentoExpedido"]);
                    this.ddlExpedicionInicia.Enabled = false;
                }
                catch (Exception ex)
                {
                    this.ddlExpedicionInicia.SelectedValue = null;
                    this.ddlExpedicionInicia.Enabled = true;
                    System.Console.Out.WriteLine(ex.Message);
                }
                this.txtFechaNacimientoInicia.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["FechaNacimiento"])));
                this.txtFechaNacimientoInicia.Enabled = false;
                try
                {
                    this.rdblSexoInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdSexo"]);
                    this.rdblSexoInicia.Enabled = false;
                }
                catch (Exception ex)
                {
                    this.rdblSexoInicia.SelectedValue = null;
                    this.rdblSexoInicia.Enabled = true;
                    System.Console.Out.WriteLine(ex.Message);
                }

                this.txtTelefonoFijoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["Telefono"]);
                this.txtTelefonoFijoInicia.Enabled = false;

                this.txtEmailInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["CorreoElectronico"]);
                this.txtEmailInicia.Enabled = false;

                this.txtTelefonoCelularInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["Celular"]);
                this.txtTelefonoCelularInicia.Enabled = false;

                this.txtTelefonoReferenciaInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["CelularReferencia"]);
                this.txtTelefonoReferenciaInicia.Enabled = false;

                this.txtDireccionInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["Direccion"]);
                this.txtDireccionInicia.Enabled = false;

                this.hddPaisInicia.Value = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdPaisResidencia"]);
                imgBtnPaisInicia.Enabled = false;

                this.hddLocalidadInicia.Value = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdLocalidad"]);
                imgBtnLocalidadInicia.Enabled = false;

                this.txtLocalidadInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["localidad"]);
                this.txtLocalidadInicia.Enabled = false;

                this.txtPaisInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["pais"]);
                this.txtPaisInicia.Enabled = false;

                this.txtPoderNotarial.Text = null;
                this.txtAdministracionPoder.Text = null;
                this.txtVigenciaPoderDel.Text = null;
                this.txtVigenciaPoderAl.Text = null;

                this.gvPersonaInicio.Visible = false;
                ModalPopupExtender1.Hide();
                this.btnSiguienteTramite.Focus();
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

    #region tipo documento

    protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlExpedicion.ClearSelection();
        ddlExpedicion.DataSource = null;
        ddlExpedicion.DataBind();
        if (ddlTipoDocumento.SelectedValue.Equals(CARNET_IDENTIDAD) || ddlTipoDocumento.SelectedValue.Equals(CARNET_EXTRANJERO))
        {
            ddlExpedicion.Enabled = true;
            CargarExpedicionDocumento(ddlTipoDocumento.SelectedValue);
        }
        else
        {
            ddlExpedicion.Enabled = false;
        }
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

    #region anios

    protected void ddlAnioAuto_SelectedIndexChanged(object sender, EventArgs e)
    {
        int anio = Convert.ToInt16(ddlAnioAuto.SelectedValue);
        //Moneda
        DataTable dtMoneda = GetMoneda();
        if (dtMoneda != null && dtMoneda.Rows.Count > 0)
        {
            foreach (DataRow row in dtMoneda.Rows)
            {
                if (anio <= 1986)
                {
                    if (row["IdDetalleClasificadorMon"].ToString().Equals("324"))
                    {
                        row.Delete();
                    }
                }
                else
                {
                    if (row["IdDetalleClasificadorMon"].ToString().Equals("323"))
                    {
                        row.Delete();
                    }
                }
            }
            ddlMonedaAuto.DataSource = dtMoneda;
            ddlMonedaAuto.DataTextField = "DescripMoneda";
            ddlMonedaAuto.DataValueField = "IdDetalleClasificadorMon";
            ddlMonedaAuto.DataBind();
            ddlMonedaAuto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlMonedaAuto.SelectedValue = "0";
        }
        //Mes
        DataTable dtMes = GetMes();
        if (dtMes != null && dtMes.Rows.Count > 0)
        {
            foreach (DataRow row in dtMes.Rows)
            {
                if (anio == 1997 && !row["Codigo"].ToString().Equals("05"))
                {
                    row.Delete();
                }
            }
            ddlMesAuto.DataSource = dtMes;
            ddlMesAuto.DataTextField = "Descripcion";
            ddlMesAuto.DataValueField = "Codigo";
            ddlMesAuto.DataBind();
            ddlMesAuto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlMesAuto.SelectedValue = "0";
        }
    }

    #endregion

}