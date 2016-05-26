
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_wfrmCompletarDatosFFAA : System.Web.UI.Page
{
    #region contantes

    private const string CARNET_IDENTIDAD = "25";
    private const string CARNET_EXTRANJERO = "26";
    private const string EXPEDIDO_EXTRANJERO = "45";
    private const string BOLIVIA = "83";
    private const string FEMENINO = "1";

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
            lblTituloSistema.Text = "MODULO INICIO TRÁMITE FF.AA.";
            lblSubTitulo.Text = "Registro Trámite FF.AA.";

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
                this.btnImprimir.OnClientClick = "return PrintPanel('" + pnlRegistro.ClientID + "');";
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla);
                CargarSector();
                CargarOficina();
                CargarSexo();
                CargarEstadoCivil();
                CargarTipoDocumento();
                CargarExpedicionDocumento();
                CargarEntidadAseguradora();
                CargaDatosffaa();
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
        this.TabDatosResidencia.Visible = false;//residencia
        this.pnlDatosResidencia.Visible = false;
        this.TabSalario.Visible = false;//automático
        this.pnlSalarioCotizableE.Visible = false;
    }

    //Habilitar paneles
    private void HabilitarPaneles(int tipo)
    {
        switch (tipo)
        {
            case 1:
                this.TabDatosResidencia.Visible = true;//residencia                
                this.pnlDatosSimilares.Visible = false;
                this.Panel8.Visible = false;
                this.pnlJustificar.Visible = false;
                this.pnlDatosResidencia.Visible = true;
                this.TabDatosResidencia.HeaderText = "Datos Complementarios";
                this.TabContainer1.ActiveTabIndex = 1;
                break;
            case 2:
                this.TabSalario.Visible = true;
                this.pnlSalarioCotizableE.Visible = true;
                this.TabSalario.HeaderText = "Datos Salario";
                this.TabContainer1.ActiveTabIndex = 2;
                this.btnObservarTramite.Focus();
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

    //CARGA LOS DATOS OBTENIDOS EN EL LISTADO ANTERIOR
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla)
    {
        clsFormatoFecha f = new clsFormatoFecha();

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

        if (!String.IsNullOrEmpty(CI))
        {
            try
            {
                if (IsNumeric(CI))
                {
                    this.txtNumeroDocumento.Text = Convert.ToString(Convert.ToInt64(CI));
                    this.txtNumeroDocumento.Enabled = false;
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
            this.txtComplemento.Enabled = false;
        }

        if (!String.IsNullOrEmpty(Nacimiento))
        {
            this.txtFechaNacimiento.Text = f.Fecha(f.GeneraFechaDMY(Nacimiento));
            this.txtFechaNacimiento.Enabled = false;
        }
        this.hfTabla.Value = Tabla;

        if (CUA == null || CUA == "" || CUA == "0")
        {
            this.txtCUA.Enabled = true;
        }
        else
        {
            this.txtCUA.Text = CUA;
            this.txtCUA.Enabled = false;
        }
        if (Matricula == null || Matricula == "" || Matricula == "0")
        {
            this.btnGenerarMatricula.Enabled = true;
        }
        else
        {
            this.txtMatricula.Text = Matricula;
            this.btnGenerarMatricula.Enabled = false;
        }
        this.txtMatricula.Enabled = false;
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
            // rblSexo.Items.RemoveAt(2);
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

    //Cargar datos fuerzas armadas
    private void CargaDatosffaa()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        DataRow row;
        clsPersona objPersona = new clsPersona();
        DataTable dtDatosPersonaFFAA = new DataTable();
        dtDatosPersonaFFAA = objPersona.ObtenerDatosPersonaFFAA(iIdConexion, cOperacion, this.txtNumeroDocumento.Text, this.txtCUA.Text, ref sMensajeError);
        if (dtDatosPersonaFFAA != null && dtDatosPersonaFFAA.Rows.Count > 0)
        {
            row = dtDatosPersonaFFAA.Rows[0];
            if (row["cod_afp"] != null)
            {
                this.ddlAFP.SelectedValue = Convert.ToString(row["cod_afp"]);
                this.ddlAFP.Enabled = false;
            }
            if (row["tipo_doc"] != null)
            {
                this.ddlTipoDocumento.SelectedValue = Convert.ToString(row["tipo_doc"]);
                this.ddlTipoDocumento.Enabled = false;
            }
            if (row["ext_doc"] != null)
            {
                this.ddlExpedicion.SelectedValue = Convert.ToString(row["ext_doc"]);
                this.ddlExpedicion.Enabled = false;
            }
            if (row["num_comp"] != null)
            {
                this.txtComplemento.Text = Convert.ToString(row["num_comp"]);
                this.txtComplemento.Enabled = false;
            }
            if (row["sexo"] != null)
            {
                this.rblSexo.Text = Convert.ToString(row["sexo"]);
                this.rblSexo.Enabled = false;
            }
            if (row["matricula"] != null)
            {
                this.txtMatricula.Text = Convert.ToString(row["matricula"]);
                this.txtMatricula.Enabled = false;
            }
            if (row["Regional"] != null)
            {
                this.ddlOficinaNotificacion.SelectedValue = Convert.ToString(row["Regional"]);
                this.ddlOficinaNotificacion.Enabled = true;
            }
            this.ddlSector.SelectedValue = "20"; //COSSMIL
            this.ddlSector.Enabled = false;
            this.txtContinuo.Text = Convert.ToString(row["continuo"]);
            this.txtSalarioffaa.Text = Convert.ToString(row["sal_oct96"]);
            this.txtPeriodo.Text = "30/10/1996";
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
        this.ddlSector.Enabled = false;
        this.ddlOficinaNotificacion.Enabled = true;
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

    //INHABILITAR DATOS PERSONALES.
    private void InhabilitarDatosResidencia()
    {
        this.txtBuscarPais.Enabled = false;
        this.txtBuscarLocalidad.Enabled = false;
        this.txtDireccion.Enabled = false;
        this.txtTelefono.Enabled = false;
        this.txtCelular.Enabled = false;
        this.txtCelular2.Enabled = false;
        this.txtEmail.Enabled = false;
        this.ibtnBuscarPais.Enabled = false;
        this.ibtnBuscarLocalidad.Enabled = false;
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
            sDetalleError = "El CUA es requerido.";
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
    public string GenerarMatricula(string pat, string mat, string nombre, DateTime fnac, string sex, string matri)
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

    private bool ValidaDatosRepetidos()
    {
        string sCUA;
        string sCARNET;
        bool bExisteCUA;
        bool bExisteCARNET;
        DataTable dtValidarInicio;
        clsTramite ObjTramite;
        try
        {
            bExisteCUA = false;
            bExisteCARNET = false;
            dtValidarInicio = new DataTable();
            ObjTramite = new clsTramite();
            ObjTramite.iIdConexion = (int)Session["IdConexion"];
            ObjTramite.cOperacion = "V";
            ObjTramite.PrimerApellido = this.txtPrimerApellido.Text;
            ObjTramite.SegundoApellido = this.txtSegundoApellido.Text;
            ObjTramite.Nombre = this.txtPrimerNombre.Text;
            ObjTramite.NumeroDocumento = this.txtNumeroDocumento.Text;
            ObjTramite.Nua = this.txtCUA.Text;
            ObjTramite.Matricula = this.txtMatricula.Text;
            //validar si permite seguir el tramite
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
                }
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
            if (this.txtCUA.Text == sCUA || (this.txtNumeroDocumento.Text == sCARNET && "FALLECIMIENTO" != sEstado))
            {
                e.Row.BackColor = Color.LightCoral;
            }
        }
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

    //Listar Pais
    private void BuscarPais(string sPais)
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
                    gvPais.DataSource = dtPais;
                    gvPais.DataBind();
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

    //Validar inicio tramite
    private bool ValidarInicioTramite()
    {
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
        clsTramite objTramiteManual;
        clsTramite objTramiteAuto;
        clsSalario objSalario;
        long IdTramiteAuto = 0;
        long IdTramiteManual = 0;
        long NUP = 0;
        string res = "not";
        bool conError = false;
        string Error = "Error al realizar la operación";
        string sMensajeError = "";
        string DetalleError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        int iIdContinuo;
        //Datos Persona
        objPersona = ObtenerDatosPersona();
        NUP = objPersona.RegistrarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
        if (NUP != 0)
        {
            //Datos Tramite
            objTramiteAuto = ObtenerDatosTramite(NUP, 1);
            IdTramiteAuto = objTramiteAuto.RegistrarTramite(iIdConexion, cOperacion, ref objTramiteAuto, ref sMensajeError);
            if (IdTramiteAuto != 0)
            {
                objTramiteManual = ObtenerDatosTramite(NUP, 2);
                IdTramiteManual = objTramiteManual.RegistrarTramite(iIdConexion, cOperacion, ref objTramiteManual, ref sMensajeError);
                if (IdTramiteManual != 0)
                {
                    //Datos Salario
                    objSalario = ObtenerDatosSalario(IdTramiteAuto);
                    objSalario.iIdConexion = iIdConexion;
                    objSalario.cOperacion = cOperacion;
                    if (objSalario.Registrar())
                    {
                        cOperacion = "U";
                        if (this.txtContinuo.Text == "SI")
                        {
                            iIdContinuo = 1;
                        }
                        else
                        {
                            iIdContinuo = 0;
                        }
                        string sDetalle = objTramiteManual.RegistrarTramiteFFAA(iIdConexion, cOperacion, this.txtCUA.Text, iIdContinuo, IdTramiteManual, "", ref sMensajeError);
                    }
                    else
                    {
                        DetalleError = DetalleError + " " + Convert.ToString(objSalario.sMensajeError);
                        conError = true;
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
            res = IdTramiteManual.ToString();
        }
        return res;
    }

    //Obtener datos persona
    private clsPersona ObtenerDatosPersona()
    {
        clsPersona Persona = new clsPersona();

        clsFormatoFecha f = new clsFormatoFecha();
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
        if (!String.IsNullOrEmpty(this.txtFechaNacimiento.Text))
        {
            Persona.FechaNacimiento = f.GeneraFechaDMY(this.txtFechaNacimiento.Text);
        }
        if (!String.IsNullOrEmpty(this.txtFechaFallecimient.Text))
        {
            Persona.FechaFallecimiento = f.GeneraFechaDMY(this.txtFechaFallecimient.Text);
        }
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

        return Persona;
    }

    //Obtener datos tramite
    private clsTramite ObtenerDatosTramite(long NUP, int tipo)
    {
        clsTramite Tramite = new clsTramite();

        if (tipo == 1)//Automatico
        {
            Tramite.IdGrupoBeneficio = 3;//Procedimiento Automático aal
            Tramite.IdBeneficio = 1;
            Tramite.IdSubBeneficio = 1;
            Tramite.IdTipoTramite = 357;//normal aal
            Tramite.IdOrigen = 341;
            Tramite.Observaciones = "Migración Automática de Fuerzas Armadas";
            Tramite.IdEstadoTramite = 52;
        }
        else
        {
            if (tipo == 2)//Manual
            {
                Tramite.IdGrupoBeneficio = 3;//Procedimiento Manual
                Tramite.IdBeneficio = 1;
                Tramite.IdSubBeneficio = 2;
                Tramite.IdTipoTramite = 356;//Manual modif aal
                if (this.txtContinuo.Text == "SI")
                {
                    Tramite.IdOrigen = 342;
                }
                else
                {
                    Tramite.IdOrigen = 343;
                }
                Tramite.Observaciones = "Generación Tramite Manual FFAA";
                Tramite.IdEstadoTramite = 1;
            }
        }

        if (this.ddlSector.SelectedValue != "")
            Tramite.IdSector = Convert.ToInt32(this.ddlSector.SelectedValue);
        else
            Tramite.IdSector = 0;
        Tramite.NUP = NUP;
        Tramite.NUPIniciaTramite = NUP;
        Tramite.IdTipoIniciaTramite = 526;
        Tramite.NumeroTramiteCRENTA = "-1";
        Tramite.IdClaseRenta = 31566;
        Tramite.IdOficinaNotificacion = Convert.ToInt32(ddlOficinaNotificacion.SelectedValue.ToString());
        Tramite.RegistroActivo = 1;
        return Tramite;
    }

    //Obtener datos Salario AUTOMATICO
    private clsSalario ObtenerDatosSalario(long IdTramite)
    {
        clsSalario objSalario = new clsSalario();
        objSalario.IdTramite = IdTramite;
        objSalario.IdGrupoBeneficio = 3;
        objSalario.Version = 1;
        objSalario.Componente = 1;
        objSalario.Ruc = "249000500";
        objSalario.PeriodoSalario = this.txtPeriodo.Text;
        objSalario.SalarioCotizable = this.txtSalarioffaa.Text;
        objSalario.IdMonedaSalario = 324;
        objSalario.IdTipoDocSalario = 488;
        objSalario.IdEstadoSalario = 39;
        objSalario.IdSector = Convert.ToInt32(this.ddlSector.SelectedValue); 
        objSalario.RegistroActivo = 1;
        return objSalario;
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

    //Iniciar tramite workflow
    private bool IniciarTramite(long IdTramite, int valido, ref string sMensajeError)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "P";
        clsTramite objTramiteInicio;
        //Iniciar Tramite
        objTramiteInicio = new clsTramite();
        objTramiteInicio.IdTramite = IdTramite;
        objTramiteInicio.IdGrupoBeneficio = 3;
        objTramiteInicio.IdFlujoTramite = 1401001;//Curso de Adq. - Trámite CC Manual
        objTramiteInicio.validoManual = valido;
        return objTramiteInicio.IniciarTramite(iIdConexion, cOperacion, ref objTramiteInicio, ref sMensajeError);
    }

    #endregion

    #region botones

    //GENERAR MATRÍCULA
    protected void btnGenerarMatricula_Click(object sender, EventArgs e)
    {
        if (ValidaDatos())
        {
            txtMatriculaGenerada.Text = GenerarMatricula(this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtPrimerNombre.Text, Convert.ToDateTime(this.txtFechaNacimiento.Text), rblSexo.Text, this.txtMatricula.Text);
            txtMatricula.Text = txtMatriculaGenerada.Text;
            this.btnGenerarMatricula.Enabled = false;
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
        try
        {
            if (ValidaDatos())
            {
                if (VerificaMatricula())
                {
                    if (ValidaDatosRepetidos())
                    {
                        HabilitaPanelRepetidos();
                    }
                    else
                    {
                        HabilitarPaneles(1);
                        InhabilitarDatosPersonales();
                    }
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
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
    }

    //Redireccionar al inicio de trámite
    protected void ibtnDenegar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmRegistroTramiteFFAA.aspx");
    }

    //Boton Aceptar justificar tramite
    protected void btnSiJustificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidarObservado())
            {
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
                    clsObservadoDetalle ObjObservadoDetalle = new clsObservadoDetalle();
                    ObjObservadoDetalle.iIdConexion = ObjObservado.iIdConexion;
                    ObjObservadoDetalle.cOperacion = ObjObservado.cOperacion;
                    ObjObservadoDetalle.IdObservado = ObjObservado.IdObservado;
                    foreach (GridViewRow dr in gv_ValidaDatosRepetidos.Rows)
                    {
                        ObjObservadoDetalle.Tramite = dr.Cells[0].Text;
                        ObjObservadoDetalle.Tipo = dr.Cells[1].Text;
                        ObjObservadoDetalle.NumeroDocumento = dr.Cells[2].Text;
                        ObjObservadoDetalle.CUA = dr.Cells[3].Text;
                        ObjObservadoDetalle.Matricula = dr.Cells[4].Text;
                        ObjObservadoDetalle.PrimeroApellido = dr.Cells[5].Text;
                        ObjObservadoDetalle.SegundoApellido = dr.Cells[6].Text;
                        ObjObservadoDetalle.Nombres = dr.Cells[7].Text;
                        ObjObservadoDetalle.FechaNacimiento = dr.Cells[8].Text;
                        ObjObservadoDetalle.Sector = dr.Cells[9].Text;
                        ObjObservadoDetalle.DHMatricula = dr.Cells[10].Text;
                        ObjObservadoDetalle.EstadoObservado = dr.Cells[11].Text;
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

    // no continuar el tramite
    protected void btnNoJustificar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmRegistroTramiteFFAA.aspx");
    }

    //Boton Residencia Siguiente
    protected void btnSiguienteResidencia_Click(object sender, EventArgs e)
    {
        if (ValidaDatosResidencia())
        {
            InhabilitarDatosResidencia();
            HabilitarPaneles(2);
            this.btnObservarTramite.Visible = true;
            this.btnIniciarTramite.Visible = true;
            this.btnSiguienteResidencia.Enabled = false;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
    }

    //Boton Observar Tramite
    protected void btnObservarTramite_Click(object sender, EventArgs e)
    {
        pnlCasoObservado.Visible = true;
        ModalPopupExtender_CasosObs.Show();
        this.txtCasoObservacion.Focus();
    }

    //Boton aceptar justificacion
    protected void btn2AceptaCasoObs_Click(object sender, EventArgs e)
    {
        this.pnlCasoObservado.Visible = false;
        this.ModalPopupExtender_CasosObs.Hide();

        clsTramite objTramiteObs = new clsTramite();
        string Error = "Error al realizar la operación";
        string sMensajeError = "";
        string DetalleError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "O";
        try
        {
            string sDetalle = objTramiteObs.RegistrarTramiteFFAA(iIdConexion, cOperacion, this.txtCUA.Text, 0, 0, this.txtCasoObservacion.Text.Trim(), ref sMensajeError);
            //this.lblCompletarInformacion.Text = sDetalle;
            this.lblCompletarInformacion.Visible = true;
            this.lblCompletarInformacion.Text = "Trámite Observado con NUA:" + this.txtCUA.Text;
            this.btnIniciarTramite.Enabled = false;
            this.btnObservarTramite.Enabled = false;
        }
        catch (Exception ex)
        {
            DetalleError = ex.Message;
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmRegistroTramiteFFAA.aspx");
    }

    //Buscar pais
    protected void ibtnBuscarPais_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusPais.Text = this.txtBuscarPais.Text;
        BuscarPais(this.txtBuscarPais.Text);
        this.gvPais.Visible = true;
        ModalPopupExtender_Pais.Show();
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
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        string IdTramite;
        int bValidoManual;
        string sMensajerror;
        clsTramite flujo = new clsTramite();
        try
        {
            IdTramite = "";
            bValidoManual = 1;
            sMensajerror = "";
            if (ValidarInicioTramite())
            {
                IdTramite = GuardarTramite();
                this.lblCompletarInformacion.Visible = true;
                if (IsNumeric(IdTramite))
                {
                    HiddenIdtramite.Value = IdTramite.ToString();
                    /*Inicio Work Flow
					if (!IniciarTramite(Convert.ToInt64(IdTramite), bValidoManual, ref sMensajerror))
                    {
                        throw new System.InvalidOperationException(sMensajerror);
                    }*/
                    /*Inicio Articulador */
                    flujo.iIdConexion = (int)Session["IdConexion"];
                    flujo.cOperacion = "I";
                    flujo.Tipo = "Inicia";
                    flujo.IdTramite = Convert.ToInt64(IdTramite);
                    if (!flujo.FlujoTramite())
                    {
                        throw new System.InvalidOperationException(flujo.sMensajeError);
                    }
                    this.lblCompletarInformacion.Text = "Se ha registrado correctamente el trámite: " + IdTramite.ToString();
                    this.btnObservarTramite.Enabled = false;
                    this.btnIniciarTramite.Enabled = false;
                    this.btnReporte.Visible = true;
                    this.btnReporte.OnClientClick = "window.open('wfrmReport.aspx?tramite=" + IdTramite.ToString() + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
                    this.btnForm02.Visible = true;
                    this.btnForm02.OnClientClick = "window.open('wfrmReportForm02.aspx?tramite=" + IdTramite.ToString() + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
                    this.btnCancelar.Text = "Volver";
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
            string DetalleError = Convert.ToString(ex.Message + ex.StackTrace);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Boton de reporte
    protected void btnForm02_Click(object sender, System.EventArgs e)
    {
        string Variable = HiddenIdtramite.Value;
        //Response.Redirect("wfrmReportForm02.aspx?tramite=" + Variable);
    }

    //Boton de reporte
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string Variable = HiddenIdtramite.Value;
        //Response.Redirect("wfrmReport.aspx?tramite=" + Variable);
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

    #region grilla paises

    protected void btnCancelPais_Click(object sender, EventArgs e)
    {
        this.gvPais.Visible = false;
        this.txtBuscarPais.Focus();
    }

    protected void btnBusPais_Click(object sender, EventArgs e)
    {
        BuscarPais(this.txtBusPais.Text);
        ModalPopupExtender_Pais.Show();
    }

    protected void gvPais_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPais.PageIndex = e.NewPageIndex;
        BuscarPais(this.txtBusPais.Text);
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
}