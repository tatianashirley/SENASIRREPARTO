
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_ModificarDatosEmpresa : System.Web.UI.Page
{
    #region constantes

    private const string MOD_SALARIO = "MS";
    private const string MOD_EMPRESAS = "ME";

    private const string MANUAL = "MANUAL";
    private const string AUTOMATICO = "AUTOMATICO";

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
        string queryStringTT;

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
        clsFormatoFecha f;
        DateTime d;
        clsFuncionesGenerales encriptar;

        if (!Page.IsPostBack)
        {
            lblSubTitulo.Text = "Modificación Datos de la Empresa";

            Session["Documento"] = "";
            Session["EmpresaManual"] = "";
            Session["EmpresaAutomatico"] = "";
            Session["Monto"] = "";
            encriptar = new clsFuncionesGenerales();
            f = new clsFormatoFecha();
            if (!String.IsNullOrEmpty(Request.QueryString["NUP"]))
            {
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
                if (MOD_SALARIO.Equals(queryStringTipoBus))
                {
                    lblTituloSistema.Text = "MODULO MODIFICACION SALARIO";
                }
                else if (MOD_EMPRESAS.Equals(queryStringTipoBus))
                {
                    lblTituloSistema.Text = "MODULO MODIFICACION EMPRESAS";
                }


                if (queryStringTipo != "")
                {

                    Tipo = encriptar.DecryptKey(queryStringTipo);
                    Session["Tipo"] = Tipo;

                    lblTipo.Text = Tipo;
                    if (MANUAL.Equals(lblTipo.Text))
                    {
                        pnlManual.Visible = true;
                        PanelDatosDeclaraciondeEmpresaManualref.Visible = true;
                    }
                    else
                    {
                        pnlAuto.Visible = true;
                        pnlSalarioCotizableE.Visible = true;
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

                }
            }
            else if (!String.IsNullOrEmpty(Request.QueryString["Origen"]))
            {
                queryStringTT = Request.QueryString["iIdTramite"];
                DataTable dtTramites = new DataTable();
                try
                {
                    dtTramites = buscarTramitesRenuncia(queryStringTT, "Modificacion");
                    if (dtTramites != null)
                    {
                        DataRow row = dtTramites.Rows[0];
                        Tipo = Convert.ToString(row["TipoTramite"]);
                        lblTipo.Text = Tipo;
                        NUPString = Convert.ToString(row["NUP"]);
                        Matricula = Convert.ToString(row["Matricula"]);
                        Nombre = Convert.ToString(row["PrimerNombre"]);
                        SegundoNombre = Convert.ToString(row["SegundoNombre"]);
                        Paterno = Convert.ToString(row["PrimerApellido"]);
                        Materno = Convert.ToString(row["SegundoApellido"]);
                        Casada = Convert.ToString(row["ApellidoCasada"]);
                        Nacimiento = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaNacimiento"])));
                        Defuncion = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaFallecimiento"])));
                        CUA = Convert.ToString(row["CUA"]);
                        CI = Convert.ToString(row["NumeroDocumento"]);
                        Complemento = Convert.ToString(row["ComplementoSEGIP"]);
                        Tabla = Convert.ToString(row["IdTramite"]);
                        //Tabla = Convert.ToString(row["TipoTramite"]);
                        if (MANUAL.Equals(lblTipo.Text))
                        {
                            pnlManual.Visible = true;
                            PanelDatosDeclaraciondeEmpresaManualref.Visible = true;
                        }
                        else
                        {
                            pnlAuto.Visible = true;
                            pnlSalarioCotizableE.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = Convert.ToString(ex);
                    Master.MensajeError(Error, DetalleError);
                }

            }
            else if (!String.IsNullOrEmpty(Request.QueryString["TT"]))
            {
                lblSubTitulo.Text = "Verificación Datos de la Empresa en Proceso Automático";
                queryStringTT = Request.QueryString["TT"].Replace(' ', '+');
                DataTable dtTramites = new DataTable();
                try
                {
                    dtTramites = buscarTramitesRenuncia(encriptar.DecryptKey(queryStringTT), "Modificacion");
                    if (dtTramites != null)
                    {
                        DataRow row = dtTramites.Rows[0];
                        Tipo = Convert.ToString(row["TipoTramite"]);
                        lblTipo.Text = Tipo;
                        NUPString = Convert.ToString(row["NUP"]);
                        Matricula = Convert.ToString(row["Matricula"]);
                        Nombre = Convert.ToString(row["PrimerNombre"]);
                        SegundoNombre = Convert.ToString(row["SegundoNombre"]);
                        Paterno = Convert.ToString(row["PrimerApellido"]);
                        Materno = Convert.ToString(row["SegundoApellido"]);
                        Casada = Convert.ToString(row["ApellidoCasada"]);
                        Nacimiento = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaNacimiento"])));
                        Defuncion = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaFallecimiento"])));
                        CUA = Convert.ToString(row["CUA"]);
                        CI = Convert.ToString(row["NumeroDocumento"]);
                        Complemento = Convert.ToString(row["ComplementoSEGIP"]);
                        Tabla = Convert.ToString(row["IdTramite"]);
                        //Tabla = Convert.ToString(row["TipoTramite"]);
                        if (MANUAL.Equals(lblTipo.Text))
                        {
                            pnlManual.Visible = true;
                            PanelDatosDeclaraciondeEmpresaManualref.Visible = true;
                        }
                        else
                        {
                            pnlAuto.Visible = true;
                            pnlSalarioCotizableE.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = Convert.ToString(ex);
                    Master.MensajeError(Error, DetalleError);
                }
            }
            //cargar datos en pantalla
            CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, Defuncion, CUA, CI, Complemento, Tabla);
            CargarTipoDocumento();
            CargarExpedicionDocumento();
            CargarEntidadAseguradora();
            CargarDatosTramite();
            CargarDatosEmpresas(lblTipo.Text);
            CargarCombosEmpresas(lblTipo.Text);
            InhabilitarDatosPersonales();

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
        if (!PanelDatosDeclaraciondeEmpresaManualref.Visible)
        {
            ibtnOpenCloseDatosResidencia.ImageUrl = "~/Imagenes/16quitar.png";
            PanelDatosDeclaraciondeEmpresaManualref.Visible = true;
        }
        else
        {
            ibtnOpenCloseDatosResidencia.ImageUrl = "~/Imagenes/16adicionar.png";
            PanelDatosDeclaraciondeEmpresaManualref.Visible = false;
        }
    }

    //Abrir/Cerrar datos residencia.
    protected void ibtnOpenCloseDatosAuto_Click(object sender, ImageClickEventArgs e)
    {
        if (!pnlSalarioCotizableE.Visible)
        {
            ibtnOpenCloseDatosAuto.ImageUrl = "~/Imagenes/16quitar.png";
            pnlSalarioCotizableE.Visible = true;
        }
        else
        {
            ibtnOpenCloseDatosAuto.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlSalarioCotizableE.Visible = false;
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

    //Buscar datos empresas
    protected void CargarDatosEmpresas(string sTipo)
    {
        clsEmpresaPersona objEmpresa = new clsEmpresaPersona();
        objEmpresa.iIdConexion = (int)Session["IdConexion"];
        objEmpresa.cOperacion = "L";
        objEmpresa.IdTramite = Convert.ToInt32(this.hfTabla.Value);
        objEmpresa.idGrupoBeneficio = 3;
        if (objEmpresa.ObtenerLista())
        {
            if (objEmpresa.DSetTmp != null)
            {
                if (MANUAL.Equals(sTipo))
                {
                    gvEmpresasmanuales.DataSource = objEmpresa.DSetTmp;
                    gvEmpresasmanuales.DataBind();
                }
                else
                {
                    grdSalariosAutomaticos.DataSource = objEmpresa.DSetTmp;
                    grdSalariosAutomaticos.DataBind();
                }
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(objEmpresa.sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Cargar combos empresa
    private void CargarCombosEmpresas(string sTipo)
    {
        if (AUTOMATICO.Equals(sTipo))
        {
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
            //Mes
            DataTable dtMes = GetMes();
            if (dtMes != null && dtMes.Rows.Count > 0)
            {
                ddlMesAuto.DataSource = dtMes;
                ddlMesAuto.DataTextField = "Descripcion";
                ddlMesAuto.DataValueField = "Codigo";
                ddlMesAuto.DataBind();
                ddlMesAuto.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
                ddlMesAuto.SelectedValue = "0";
            }
            //Moneda
            DataTable dtMoneda = GetMoneda();
            ddlMonedaAuto.DataSource = dtMoneda;
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

        }
        else if (MANUAL.Equals(sTipo))
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

    //Buscar Tramites
    protected DataTable buscarTramitesRenuncia(string idTramite, string estadotramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string iIdTramite = "0";
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();
        if (!String.IsNullOrEmpty(idTramite))
        {
            iIdTramite = idTramite;
        }
        else
        {
            iIdTramite = "0";
        }
        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, 3, null, null, null, null, null, null, null, estadotramite, ref sMensajeError);

        return dtListaPersonas;
    }

    //GUARDAR TRÁMITE
    private string GuardarTramite()
    {
        string Error = "Error al registrar la empresa";
        string DetalleError = null;
        bool conError = false;
        long idTramite = Convert.ToInt64(hfTabla.Value);
        //Datos Empresas
        /*
        clsEmpresaPersona objPersonaEmpresa = new clsEmpresaPersona();
        objPersonaEmpresa.iIdConexion = (int)Session["IdConexion"];
        objPersonaEmpresa.cOperacion = "U";
        objPersonaEmpresa.IdTramite = Convert.ToInt64(hfTabla.Value);
        objPersonaEmpresa.idGrupoBeneficio = 3;*/

        if (MANUAL.Equals(lblTipo.Text))
        {
            /*
            objPersonaEmpresa.IdEmpresa = txtRucManual.Text;
            objPersonaEmpresa.NombreEmpresaDeclarada = txtRazonSocialEmpresaManual_Alternativo.Text;
            objPersonaEmpresa.PeriodoInicio = txtFecha_Ingreso.Text;
            objPersonaEmpresa.PeriodoFin = txtFecha_Retiro.Text;
            objPersonaEmpresa.IdSector = Convert.ToInt32(ddlSectorEmpresaManual.SelectedValue);
            objPersonaEmpresa.NroPatronalRucAlt = txtNroPatronal_Ruc_Alternativo.Text;
            objPersonaEmpresa.IdTipoDocSalario = Convert.ToInt32(ddlDocumentoManual.SelectedValue);
            objPersonaEmpresa.IdTipoTramite = 356;
             * */


            List<clsEmpresaPersona> lstEmpresaPersona = ObtenerDatosEmpresas(idTramite, 0);
            if (lstEmpresaPersona != null && lstEmpresaPersona.Count > 0)
            {
                foreach (clsEmpresaPersona item in lstEmpresaPersona)
                {
                    clsEmpresaPersona objEmpresaPersona = item;
                    objEmpresaPersona.iIdConexion = (int)Session["IdConexion"];
                    objEmpresaPersona.cOperacion = "I";
                    if (!objEmpresaPersona.Registrar())
                    {
                        DetalleError = DetalleError + " " + Convert.ToString(objEmpresaPersona.sMensajeError);
                        conError = true;
                    }
                    if (conError)
                    {
                        Master.MensajeError(Error, DetalleError);
                    }
                }
            }
            else
            {
                lstEmpresaPersona = ObtenerDatosEmpresas(idTramite, 1);
                if (lstEmpresaPersona != null && lstEmpresaPersona.Count == 1)
                {
                    foreach (clsEmpresaPersona item in lstEmpresaPersona)
                    {
                        clsEmpresaPersona objPersonaEmpresa = item;
                        objPersonaEmpresa.iIdConexion = (int)Session["IdConexion"];
                        objPersonaEmpresa.cOperacion = "U";
                        objPersonaEmpresa.IdTramite = idTramite;
                        objPersonaEmpresa.idGrupoBeneficio = 3;
                        objPersonaEmpresa.IdTipoTramite = 356;
                        objPersonaEmpresa.Motivo = txtDescripcion.Text;
                        if (!objPersonaEmpresa.Modificar())
                        {
                            Master.MensajeError(Error, objPersonaEmpresa.sMensajeError);
                        }
                    }

                }
            }
        }
        else
        {
            /*
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
            */

            //Datos Salario
            List<clsSalario> lstSalario = ObtenerDatosSalario(idTramite, 0);
            if (lstSalario != null && lstSalario.Count > 0)
            {
                foreach (clsSalario item in lstSalario)
                {
                    clsSalario objSalario = item;
                    objSalario.iIdConexion = (int)Session["IdConexion"];
                    objSalario.cOperacion = "I";
                    if (!objSalario.Registrar())
                    {
                        DetalleError = DetalleError + " " + Convert.ToString(objSalario.sMensajeError);
                        conError = true;
                    }
                }
            }

            if (conError)
            {
                Master.MensajeError(Error, DetalleError);
            }
            //Datos Empresas
            List<clsEmpresaPersona> lstEmpresaPersona = ObtenerDatosEmpresasAuto(idTramite, 0);
            if (lstEmpresaPersona != null && lstEmpresaPersona.Count > 0)
            {
                foreach (clsEmpresaPersona item in lstEmpresaPersona)
                {
                    clsEmpresaPersona objEmpresaPersona = item;
                    objEmpresaPersona.iIdConexion = (int)Session["IdConexion"];
                    objEmpresaPersona.cOperacion = "I";
                    if (!objEmpresaPersona.Registrar())
                    {
                        DetalleError = DetalleError + " " + Convert.ToString(objEmpresaPersona.sMensajeError);
                        conError = true;
                    }
                }
            }
            else
            {
                lstEmpresaPersona = ObtenerDatosEmpresasAuto(idTramite, 1);
                if (lstEmpresaPersona != null && lstEmpresaPersona.Count == 1)
                {
                    foreach (clsEmpresaPersona item in lstEmpresaPersona)
                    {
                        clsEmpresaPersona objPersonaEmpresa = item;
                        objPersonaEmpresa.iIdConexion = (int)Session["IdConexion"];
                        objPersonaEmpresa.cOperacion = "U";
                        objPersonaEmpresa.IdTramite = idTramite;
                        objPersonaEmpresa.idGrupoBeneficio = 3;
                        objPersonaEmpresa.IdTipoTramite = 357;
                        objPersonaEmpresa.Motivo = txtDescripcion.Text;
                        if (!objPersonaEmpresa.Modificar())
                        {
                            Master.MensajeError(Error, objPersonaEmpresa.sMensajeError);
                        }
                    }

                }
            }
            if (conError)
            {
                Master.MensajeError(Error, DetalleError);
            }

        }

        return hfTabla.Value;
    }

    //Obtener datos Empresa Proceso MANUAL
    private List<clsEmpresaPersona> ObtenerDatosEmpresas(long IdTramite, int tipo)
    {
        List<clsEmpresaPersona> lstEmpresaPersona = new List<clsEmpresaPersona>();
        if (gvEmpresasmanuales != null && gvEmpresasmanuales.Rows.Count > 0)
        {
            foreach (DataKey fila in gvEmpresasmanuales.DataKeys)
            {
                string id = Convert.ToString(fila.Values["IdEmpresaPersona"]);
                if (tipo == 0)
                {
                    if (!(!String.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0))
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
                else
                {
                    if (!String.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
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
            }
        }
        return lstEmpresaPersona;
    }

    //Obtener datos Salario AUTOMATICO
    private List<clsSalario> ObtenerDatosSalario(long IdTramite, int tipo)
    {
        List<clsSalario> lstSalario = new List<clsSalario>();
        if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
        {
            foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
            {
                string Id = Convert.ToString(fila.Values["IdEmpresaPersona"]);
                if (tipo == 0)
                {
                    if (!(!String.IsNullOrEmpty(Id) && Convert.ToInt64(Id) > 0))
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
                else
                {
                    if (!String.IsNullOrEmpty(Id) && Convert.ToInt64(Id) > 0)
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
            }
        }

        return lstSalario;
    }


    //Obtener datos Empresa Proceso AUTOMATICO
    private List<clsEmpresaPersona> ObtenerDatosEmpresasAuto(long IdTramite, int tipo)
    {
        List<clsEmpresaPersona> lstEmpresaPersona = new List<clsEmpresaPersona>();
        if (grdSalariosAutomaticos != null && grdSalariosAutomaticos.Rows.Count > 0)
        {
            foreach (DataKey fila in grdSalariosAutomaticos.DataKeys)
            {
                string Id = Convert.ToString(fila.Values["IdEmpresaPersona"]);
                if (tipo == 0)
                {
                    if (!(!String.IsNullOrEmpty(Id) && Convert.ToInt64(Id) > 0))
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
                else
                {
                    if (!String.IsNullOrEmpty(Id) && Convert.ToInt64(Id) > 0)
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
            }
        }
        return lstEmpresaPersona;
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

    //adicionar empresa manual
    private void AgregarEmpManual()
    {
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        dt2 = new DataTable();
        dt2.Columns.Add("IdEmpresaPersona");
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
        filadt2["IdEmpresaPersona"] = null;
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
                filadt2["IdEmpresaPersona"] = Convert.ToString(fila.Values["IdEmpresaPersona"]);
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

    //Validar grilla manual
    private bool validagrillaEmpresas()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";

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
        if (ckboxHabilitaEmpresaManual.Checked)
        {

            if (txtRazonSocialEmpresaManual_Alternativo.Text.Trim() == null || txtRazonSocialEmpresaManual_Alternativo.Text.Trim() == "")
            {
                sDetalleError = "La Razón Social es requerida.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        return true;
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

    //adicionar empresa automatico
    private void AgregarEmpAuto()
    {
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        dt2 = new DataTable();
        dt2.Columns.Add("IdEmpresaPersona");
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
        dt2.Columns.Add("MatriculaORG");
        filadt2 = dt2.NewRow();
        filadt2["IdEmpresaPersona"] = null;
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
                filadt2["IdEmpresaPersona"] = Convert.ToString(fila.Values["IdEmpresaPersona"]);
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
        return true;
    }

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
        for (int i = 1996; i > 1929; i--)
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

    //Validar proceso automatico
    private bool validacionAutomatica(long IdTramite, ref int bValidoManual, ref string sMensaje, ref string sMensajeError)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        clsTramite ObjTramite = new clsTramite();
        return ObjTramite.ValidarProcesoAutomatico(iIdConexion, cOperacion, IdTramite, ref bValidoManual, ref sMensaje, ref sMensajeError);
    }

    #endregion

    #region botones

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        if (lblSubTitulo.Text == "Verificación Datos de la Empresa en Proceso Automático")
        {
            Response.Redirect("Distribucion/wfrmBuscarTramite.aspx");
        }
        else
        {
            Response.Redirect("wfrmModificacionTramite.aspx?Tipo=" + hddTipo.Value);
        }
    }

    //VALIDA Y LLAMA A FUNCION QUE GUARDA EL TRAMITE
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            string IdTramite = "";
            string sTexto = "";
            int bValidoManual = 1;
            string sMensajerror = "";
            if (ValidaDatos())
            {
                IdTramite = GuardarTramite();
                this.lblCompletarInformacion.Visible = true;
                if (IsNumeric(IdTramite))
                {
                    HiddenIdtramite.Value = IdTramite.ToString();
                    if (!MANUAL.Equals(lblTipo.Text))//automático
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

    //BUSCAR EMPRESA Proceso manual
    protected void ibtnBuscarEmpresaManual_Click(object sender, EventArgs e)
    {
        this.txtBusEmpMan.Text = this.txtEmpresaManual.Text;
        this.txtBusRucMan.Text = this.txtRucManual.Text;
        BuscarEmpresaManual(this.txtEmpresaManual.Text, this.txtRucManual.Text);
        gvSeleccionarEmpresaManual.Visible = true;
        pnlEmpresasManual.Visible = true;
        ModalPopupExtenderEmpresasManual2.Show();
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
            ckboxHabilitaEmpresaManual.Checked = false;
            txtRazonSocialEmpresaManual_Alternativo.Text = "";
            txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
            txtNroPatronal_Ruc_Alternativo.Text = "";
            txtNroPatronal_Ruc_Alternativo.Enabled = false;
        }
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
        }
    }

    //BUSCAR EMPRESA Proceso automatico 
    protected void btnBuscarAutomatico_Click1(object sender, EventArgs e)
    {
        this.txtBusEmpAuto.Text = this.txtBuscarEmpresaAutomatico.Text;
        this.txtBusRucAuto.Text = this.txtBuscarRUCAutomatico.Text;
        BuscarEmpresaAuto(this.txtBuscarEmpresaAutomatico.Text, this.txtBuscarRUCAutomatico.Text);
        gvSeleccionarEmpresaAutomatico.Visible = true;
        pnlPopup.Visible = true;
        ModalPopupExtender.Show();
    }

    #endregion

    #region grilla empresas manual

    protected void ckboxHabilitaEmpresaManual_CheckedChanged(object sender, EventArgs e)
    {
        txtRazonSocialEmpresaManual_Alternativo.Text = "";
        txtNroPatronal_Ruc_Alternativo.Text = "";
        if (ckboxHabilitaEmpresaManual.Checked)
        {
            txtRazonSocialEmpresaManual_Alternativo.Enabled = true;
            txtNroPatronal_Ruc_Alternativo.Enabled = true;
        }
        else
        {
            txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
            txtNroPatronal_Ruc_Alternativo.Enabled = false;
        }
    }

    protected void ibtnNuevaEmpresaManual_Click(object sender, EventArgs e)
    {
        enabledgrillaEmpresas();
    }

    private void enabledgrillaEmpresas()
    {
        txtEmpresaManual.Text = "";
        txtEmpresaManual.Enabled = true;
        txtRucManual.Text = "";
        txtRucManual.Enabled = true;
        ddlSectorEmpresaManual.SelectedValue = "0";
        ddlSectorEmpresaManual.Enabled = true;
    }

    protected void gvSeleccionarEmpresaManual_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvSeleccionarEmpresaManual = (GridView)sender;
        gvSeleccionarEmpresaManual.PageIndex = e.NewSelectedIndex;
        gvSeleccionarEmpresaManual.DataBind();
        pnlEmpresasManual.Visible = true;
        ModalPopupExtenderEmpresasManual2.Show();
    }

    protected void gvSeleccionarEmpresaManual_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSeleccionarEmpresaManual.PageIndex = e.NewPageIndex;
        BuscarEmpresaManual(this.txtBusEmpMan.Text, this.txtBusRucMan.Text);
        pnlEmpresasManual.Visible = true;
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
                this.txtRucManual.Enabled = false;
                this.txtEmpresaManual.Enabled = false;
                this.ddlSectorEmpresaManual.Enabled = false;
                this.gvSeleccionarEmpresaManual.Visible = false;
                pnlEmpresasManual.Visible = false;
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

        if (e.CommandName == "cmdModificarEmpManual")
        {
            Index = Convert.ToInt32(e.CommandArgument);

            txtEmpresaManual.Text = Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["Empresa"]);
            txtRucManual.Text = Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["Ruc"]);
            ddlSectorEmpresaManual.SelectedValue = Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["IdSector"]);
            txtFecha_Ingreso.Text = clsFormatoFecha.FechaText(Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["Fecha_Ingreso"]));
            txtFecha_Retiro.Text = clsFormatoFecha.FechaText(Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["Fecha_Retiro"]));
            txtRazonSocialEmpresaManual_Alternativo.Text = Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["RazonSocialEmpresaManual"]);
            txtNroPatronal_Ruc_Alternativo.Text = Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["NroPatronal_Ruc_Alternativo"]);
            ddlDocumentoManual.SelectedValue = Convert.ToString(gvEmpresasmanuales.DataKeys[Index].Values["IdDetalleClasificadorDoc"]);
            if (txtRazonSocialEmpresaManual_Alternativo.Text != null && !txtRazonSocialEmpresaManual_Alternativo.Text.Equals(""))
            {
                ckboxHabilitaEmpresaManual.Checked = true;
            }
            else
            {
                ckboxHabilitaEmpresaManual.Checked = false;
            }
        }
        else if (e.CommandName == "cmdEliminarEmpManual")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            dt2 = new DataTable();
            dt2.Columns.Add("IdEmpresaPersona");
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
                    filadt2["IdEmpresaPersona"] = Convert.ToString(fila.Values["IdEmpresaPersona"]);
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
        }
    }

    protected void gvEmpresasmanuales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sPrestacionHabilitada = Convert.ToString(gvEmpresasmanuales.DataKeys[e.Row.RowIndex].Values["IdEmpresaPersona"]);
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgEliminarEmpManual");
            ImageButton btnActualizar = (ImageButton)e.Row.FindControl("imgModificarEmpManual");

            if (!String.IsNullOrEmpty(sPrestacionHabilitada) && Convert.ToInt64(sPrestacionHabilitada) > 0)
            {
                btnBloqueo.Visible = false;
                btnActualizar.Visible = true;
            }
            else
            {
                btnBloqueo.Visible = true;
                btnActualizar.Visible = false;
            }

        }
    }

    protected void btnBusEmpresaManual_Click(object sender, EventArgs e)
    {
        BuscarEmpresaManual(this.txtBusEmpMan.Text, this.txtBusRucMan.Text);
        pnlEmpresasManual.Visible = true;
        ModalPopupExtenderEmpresasManual2.Show();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
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
        ckboxHabilitaEmpresaManual.Checked = false;
        txtRazonSocialEmpresaManual_Alternativo.Text = "";
        txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
        txtNroPatronal_Ruc_Alternativo.Text = "";
        txtNroPatronal_Ruc_Alternativo.Enabled = false;
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
        string sMes;
        string sValida;
        string sIdDoc;
        string sDoc;
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        if (e.CommandName == "cmdModificarEmp")
        {
            Index = Convert.ToInt32(e.CommandArgument);

            txtBuscarEmpresaAutomatico.Text = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["Empresa"]);
            txtBuscarRUCAutomatico.Text = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["Ruc"]);
            txtSectorAuto.Text = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["Sector"]);
            hddSectorAuto.Value = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["IdSector"]);
            sMes = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["IdMes"]);
            if (sMes.Length == 1)
            {
                sMes = '0' + sMes;
            }
            ddlMesAuto.SelectedValue = sMes;
            ddlAnioAuto.SelectedValue = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["Anio"]);
            txtMontoAuto.Text = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["Total"]);
            ddlMonedaAuto.SelectedValue = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["IdDetalleClasificadorMon"]);
            ddlDocumentoAuto.SelectedValue = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["IdDetalleClasificadorDoc"]);
            try
            {
                sValida = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["pfa"]);
                sIdDoc = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["IdDocumentoSSLP"]);
                sDoc = Convert.ToString(grdSalariosAutomaticos.DataKeys[Index].Values["DocumentoSSLP"]);
                //valida
                if ("SI".Equals(sValida))
                {
                    ckboxSeguroSocial.Checked = true;
                }
                else
                {
                    ckboxSeguroSocial.Checked = false;
                }
                //Sector
                if (!String.IsNullOrEmpty(sIdDoc))
                {
                    ObtenerSectorSSLP();
                    ddlSectorSSLP.SelectedValue = sIdDoc;
                    txtDocumentoSSLP.Text = sDoc;
                }

                //Primera Fecha Afiliacion
                ObtenerFechaAfiliacion();
                //Salario Referencial
                ObtenerSalarioRef();
                if (MOD_SALARIO.Equals(hddTipo.Value))
                {
                    txtBuscarEmpresaAutomatico.Enabled = false;
                    txtBuscarRUCAutomatico.Enabled = false;
                    txtSectorAuto.Enabled = false;
                    ddlMesAuto.Enabled = false;
                    ddlAnioAuto.Enabled = false;
                    ddlDocumentoAuto.Enabled = false;
                    imgBuscarEmpresaAuto.Enabled = false;
                    txtMontoAuto.Enabled = true;
                    txtMontoAuto2.Enabled = true;
                    ddlMonedaAuto.Enabled = true;
                    ckboxSeguroSocial.Enabled = false;
                    ddlSectorSSLP.Enabled = false;
                }
                else
                {
                    imgBuscarEmpresaAuto.Enabled = true;

                    txtMontoAuto.Enabled = false;
                    txtMontoAuto2.Enabled = false;
                    ddlMonedaAuto.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = ex.Message;
                Master.MensajeError(sError, sDetalleError);
            }
        }
        else if (e.CommandName == "cmdEliminarEmp")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            dt2 = new DataTable();
            dt2.Columns.Add("IdEmpresaPersona");
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
                    filadt2["IdEmpresaPersona"] = Convert.ToString(fila.Values["IdEmpresaPersona"]);
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
        }
    }

    private void ObtenerSalarioRef()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";
        clsPersona objPersona;
        DataTable dtSalario;
        string sMensajeError = "";
        try
        {
            objPersona = new clsPersona();
            objPersona.Matricula = hddMatriculaORG.Value;
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

    private void ObtenerFechaAfiliacion()
    {
        DataTable dtPFA = GetPFA(hddMatriculaORG.Value);
        if (dtPFA != null && dtPFA.Rows.Count > 0)
        {
            foreach (DataRow row in dtPFA.Rows)
            {
                txtPFA.Text = row["fecha_ingreso"].ToString();
            }
        }
    }

    private void ObtenerSectorSSLP()
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
        }
    }

    protected void grdSalariosAutomaticos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sPrestacionHabilitada = Convert.ToString(grdSalariosAutomaticos.DataKeys[e.Row.RowIndex].Values["IdEmpresaPersona"]);
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgEliminarEmpAuto");
            ImageButton btnActualizar = (ImageButton)e.Row.FindControl("imgModificarEmpAuto");

            if (!String.IsNullOrEmpty(sPrestacionHabilitada) && Convert.ToInt64(sPrestacionHabilitada) > 0)
            {
                btnBloqueo.Visible = false;
                btnActualizar.Visible = true;
            }
            else
            {
                btnBloqueo.Visible = true;
                btnActualizar.Visible = false;
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

    protected void btnNuevoAuto_Click(object sender, EventArgs e)
    {
        ObtenerSectorSSLP();
        ObtenerFechaAfiliacion();
        ObtenerSalarioRef();
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
        txtMontoAuto.Enabled = true;
        txtMontoAuto2.Enabled = true;
        ddlMonedaAuto.Enabled = true;
        txtMontoAuto.Text = "";
        txtMontoAuto2.Text = "";
        ddlMonedaAuto.SelectedValue = "0";

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
                if (anio >= 1982 && anio <= 1986)
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
    }

    #endregion
}