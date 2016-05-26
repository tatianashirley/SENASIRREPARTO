using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfConvenios.Logica;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class Convenios_wfrmCompletaDatos : System.Web.UI.Page
{
    #region inicio
    private const string CARNET_IDENTIDAD = "25";
    private const string CARNET_EXTRANJERO = "26";
    private const string EXPEDIDO_EXTRANJERO = "45";
    private const string BOLIVIA = "83";
    private const string FEMENINO = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
        /*string queryStringNUP;
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
         */
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

        //clsFuncionesGenerales encriptar;

        if (!Page.IsPostBack)
        {
            /*lblTituloSistema.Text = "MODULO INICIO TRÁMITE";
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
                this.btnImprimir.OnClientClick = "return PrintPanel('" + pnlRegistro.ClientID + "');";*/

            Matricula = (string)Session["Matricula"];
            CI = (string)Session["NroDocumento"];
            Paterno = (string)Session["Paterno"];
            Materno = (string)Session["Materno"];
            Nombre = (string)Session["PrimerNombre"];

            //cargar datos en pantalla
            CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla);
            CargarSector();
            CargarSexo();
            CargarEstadoCivil();
            CargarTipoDocumento();
            CargarExpedicionDocumento();
            CargarEntidadAseguradora();
            CargarPersonaTipo();

            //}
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
                CargarDocumentos();
                this.rdbtDocs.Focus();
                break;
            case 4:
                if (this.lblTipo.Text == "AUTOMÁTICO")//automático
                {
                    this.TabAutomatico.Visible = true;
                    this.TabAutomatico.HeaderText = "PA - Salario Cotizable";
                    this.TabContainer1.ActiveTabIndex = 4;
                    this.pnlSalarioCotizableE.Visible = true;
                    this.txtBuscarEmpresaAutomatico.Focus();
                }
                if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP")//manual
                {
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

    //CARGA LOS DATOS OBTENIDOS EN EL LISTADO ANTERIOR
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla)
    {
        wcfConvenios.Logica.clsFormatoFecha f = new wcfConvenios.Logica.clsFormatoFecha();

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
            this.btnGenerarMatricula.Enabled = false;
        }
        this.txtMatricula.Enabled = false;
        this.txtPrimerApellido.Focus();
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
        wcfConvenios.Logica.clsFormatoFecha ObjFormatoFecha;
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
        ObjFormatoFecha = new wcfConvenios.Logica.clsFormatoFecha();
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
        if (ddlSector.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Sector Laboral es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        /*        if (ddlOficinaNotificacion.SelectedValue.ToString() == "0")
                {
                    sDetalleError = "La Oficina Notificación es requerida.";
                    Master.MensajeError(sError, sDetalleError);
                    return false;
                }*/
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

    //Validar similitudes
    private bool ValidaDatosRepetidos()
    {
        try
        {
            DataTable dtValidarInicio = new DataTable();
            clsTramite ObjTramite = new clsTramite();
            string sCUA;
            string sCARNET;
            bool bExisteCUA = false;
            bool bExisteCARNET = false;
            bool Suspension = false;
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
                    if (("SUSPENSION DEFINITIVA".Equals(row["ESTADO_TDES"].ToString())))
                    {
                        Suspension = true;
                    }
                }
                if ((bExisteCUA || bExisteCARNET)&&!(Suspension) )
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
            rdblSexoInicia.DataSource = dtSexo;
            rdblSexoInicia.DataTextField = "Descripcion";
            rdblSexoInicia.DataValueField = "IdDetalleClasificador";
            rdblSexoInicia.DataBind();
            rdblSexoInicia.Items.RemoveAt(2);
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

    //Verificar Paises
    private bool VerificarPaises()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        //Sexo
        DataTable dtClasificador = new DataTable();
        dtClasificador = ObjTramite.ObtenerClasificadorPorDescripcion(iIdConexion, cOperacion, 10, this.txtBuscarPais.Text, ref sMensajeError);

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
        if (this.txtBuscarPais.Text.Trim() == null || txtBuscarPais.Text.Trim() == "")
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

    //Validar documentos
    public bool ValidaDocumentos()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        int iCantidad = 0;
        string sIdTipoTramite = "CC_CADQ";
        Int64 iSesionTmp = 0;
        if (rdbtDocs != null && rdbtDocs.Items.Count > 0)
        {

            wcfWorkFlowN.Datos.clsSolicitudTramiteDocumentoTmpDA doc = new wcfWorkFlowN.Datos.clsSolicitudTramiteDocumentoTmpDA();
            foreach (ListItem fila in rdbtDocs.Items)
            {
                if (fila.Selected)
                {
                    //COMENTAR P Q FUNCIONE
                    /*
                    doc.iIdConexion = (int)Session["IdConexion"];
                    doc.iSesionTrabajo = iSesionTmp;
                    doc.sIdTipoTramite = sIdTipoTramite;
                    doc.iIdTipoDocumento = Convert.ToInt32(fila.Value);
                    doc.iIdDocumento = Convert.ToInt32(fila.Value);
                    if (!doc.Adicion())
                    {
                        sDetalleError = doc.sMensajeError;
                        Master.MensajeError(sError, sDetalleError);
                        return false;
                    }
                    else
                    {
                        iSesionTmp = doc.iSesionTrabajo;
                    }
                    */
                    //HASTA AQUI
                    iCantidad++;
                }
            }
        }
        if (iCantidad <= 0)
        {
            sDetalleError = "Debe elegir al menos un documento.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }//COMENTAR P Q FUNCIONE
        /*
        else
        {
            wcfWorkFlowN.Datos.clsSolicitudTramiteDA solicitud = new wcfWorkFlowN.Datos.clsSolicitudTramiteDA();
            solicitud.iIdConexion = (int)Session["IdConexion"];
            solicitud.iSesionTrabajo = iSesionTmp;
            solicitud.sIdTipoTramite = sIdTipoTramite;
            if (!solicitud.RestriccionesDocumentosOK())
            {
                sDetalleError = solicitud.sMensajeError;
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        */
        //HASTA AQUI
        return true;
    }

    //Validar Datos Tramite
    public bool ValidaDatosTramite()
    {
        wcfConvenios.Logica.clsFormatoFecha ObjFormatoFecha;
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
                    if (ddlExpedicionInicia.SelectedValue.ToString() == "0")
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
                    ObjFormatoFecha = new wcfConvenios.Logica.clsFormatoFecha();
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

    //adicionar empresa automatico
    private void adiccionaempresa(string ruc, string empresaautomatico)
    {
        if (Convert.ToInt32(grdSalariosAutomaticos.Rows.Count) < 1)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            dt.Columns.Add("IdSector");
            dt.Columns.Add("Ruc");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Anio");
            dt.Columns.Add("Total");
            dt.Columns.Add("CopiaTotal");
            dt.Columns.Add("IdDetalleClasificadorMon");
            dt.Columns.Add("IdDetalleClasificadorDoc");
            DataRow fila = dt.NewRow();
            fila["IdSector"] = "0";
            fila["Ruc"] = ruc;
            fila["Empresa"] = empresaautomatico;
            fila["Codigo"] = "01";
            fila["Anio"] = "1996";
            fila["Total"] = "";
            fila["CopiaTotal"] = "";
            fila["IdDetalleClasificadorMon"] = "0";
            fila["IdDetalleClasificadorDoc"] = "0";
            dt.Rows.Add(fila);
            grdSalariosAutomaticos.DataSource = dt;
            grdSalariosAutomaticos.DataBind();
        }
        else
        {
            DataTable dt2 = new DataTable();
            DataRow filadt2;
            dt2 = new DataTable();
            dt2.Columns.Add("IdSector");
            dt2.Columns.Add("Ruc");
            dt2.Columns.Add("Empresa");
            dt2.Columns.Add("Codigo");
            dt2.Columns.Add("Anio");
            dt2.Columns.Add("Total");
            dt2.Columns.Add("CopiaTotal");
            dt2.Columns.Add("IdDetalleClasificadorMon");
            dt2.Columns.Add("IdDetalleClasificadorDoc");
            DataRow fila2 = dt2.NewRow();

            // salvar datos de la grid
            foreach (GridViewRow filagrd in grdSalariosAutomaticos.Rows)
            {
                filadt2 = dt2.NewRow();
                DropDownList ddlSectorSalario = (DropDownList)filagrd.FindControl("ddlSectorSalario");
                filadt2["IdSector"] = ddlSectorSalario.SelectedValue;
                System.Web.UI.WebControls.TextBox txtRuc = (System.Web.UI.WebControls.TextBox)filagrd.FindControl("txtRuc");
                filadt2["Ruc"] = txtRuc.Text;
                System.Web.UI.WebControls.TextBox txtEmpresa = (System.Web.UI.WebControls.TextBox)filagrd.FindControl("txtEmpresa");
                filadt2["Empresa"] = txtEmpresa.Text;
                DropDownList cboMes = (DropDownList)filagrd.FindControl("cboMes");
                filadt2["Codigo"] = cboMes.SelectedValue;
                DropDownList cboAno = (DropDownList)filagrd.FindControl("cboAno");
                filadt2["Anio"] = cboAno.SelectedValue;
                System.Web.UI.WebControls.TextBox txtTotal = (System.Web.UI.WebControls.TextBox)filagrd.FindControl("txtTotal");
                filadt2["Total"] = txtTotal.Text;

                System.Web.UI.WebControls.TextBox txtCopiaTotal = (System.Web.UI.WebControls.TextBox)filagrd.FindControl("txtCopiaTotal");
                filadt2["CopiaTotal"] = txtCopiaTotal.Text;
                DropDownList cboMoneda = (DropDownList)filagrd.FindControl("cboMoneda");
                filadt2["IdDetalleClasificadorMon"] = cboMoneda.SelectedValue;
                DropDownList cboDocumentosAutomatico = (DropDownList)filagrd.FindControl("cboDocumentosAutomatico");
                filadt2["IdDetalleClasificadorDoc"] = cboDocumentosAutomatico.SelectedValue;
                dt2.Rows.Add(filadt2);
            }
            filadt2 = dt2.NewRow();
            filadt2["IdSector"] = "0";
            filadt2["Ruc"] = ruc;
            filadt2["Empresa"] = empresaautomatico;
            filadt2["Codigo"] = "01";
            filadt2["Anio"] = "1996";
            filadt2["Total"] = "";
            filadt2["CopiaTotal"] = "";
            filadt2["IdDetalleClasificadorMon"] = "0";
            filadt2["IdDetalleClasificadorDoc"] = "0";
            dt2.Rows.Add(filadt2);
            grdSalariosAutomaticos.DataSource = dt2;
            grdSalariosAutomaticos.DataBind();
        }
    }

    //adicionar empresa manual
    private void adicionaempresaManual2(string ruc, string empresaautomatico)
    {
        DataTable dt = new DataTable();
        dt = new DataTable();
        dt.Columns.Add("IdSector");
        dt.Columns.Add("Fecha_Ingreso");
        dt.Columns.Add("Fecha_Retiro");
        dt.Columns.Add("Ruc");
        dt.Columns.Add("Empresa");
        dt.Columns.Add("IdDetalleClasificadorDoc");
        dt.Columns.Add("RazonSocialEmpresaManual");
        dt.Columns.Add("NroPatronal_Ruc_Alternativo");
        if (gvEmpresasmanuales.Rows.Count > 0)
        {
            foreach (GridViewRow filagrd in gvEmpresasmanuales.Rows)
            {
                DataRow filadt2 = dt.NewRow();
                DropDownList ddlSectorEmpresaManual = (DropDownList)filagrd.FindControl("ddlSectorEmpresaManual");
                filadt2["IdSector"] = ddlSectorEmpresaManual.SelectedValue;

                TextBox txtFecha_Ingreso = (TextBox)filagrd.FindControl("txtFecha_Ingreso");
                filadt2["Fecha_Ingreso"] = txtFecha_Ingreso.Text;

                TextBox txtFecha_Retiro = (TextBox)filagrd.FindControl("txtFecha_Retiro");
                filadt2["Fecha_Retiro"] = txtFecha_Ingreso.Text;

                TextBox txtRucEmpresaManual = (TextBox)filagrd.FindControl("txtRucEmpresaManual");
                filadt2["Ruc"] = txtRucEmpresaManual.Text;

                TextBox txtEmpresaManual = (TextBox)filagrd.FindControl("txtEmpresaManual");
                filadt2["Empresa"] = txtEmpresaManual.Text;

                DropDownList cboDocumentosManual = (DropDownList)filagrd.FindControl("cboDocumentosManual");
                filadt2["IdDetalleClasificadorDoc"] = cboDocumentosManual.SelectedValue;

                TextBox txtRazonSocialEmpresaManual_Alternativo = (TextBox)filagrd.FindControl("txtRazonSocialEmpresaManual_Alternativo");
                filadt2["RazonSocialEmpresaManual"] = txtRazonSocialEmpresaManual_Alternativo.Text;

                TextBox txtNroPatronal_Ruc_Alternativo = (TextBox)filagrd.FindControl("txtNroPatronal_Ruc_Alternativo");
                filadt2["NroPatronal_Ruc_Alternativo"] = txtNroPatronal_Ruc_Alternativo.Text;
                dt.Rows.Add(filadt2);
            }
        }
        DataRow fila = dt.NewRow();
        fila["IdSector"] = "0";
        fila["Fecha_Ingreso"] = "";
        fila["Fecha_Retiro"] = "";
        fila["Ruc"] = ruc;
        fila["Empresa"] = empresaautomatico;
        fila["IdDetalleClasificadorDoc"] = "0";
        fila["RazonSocialEmpresaManual"] = "";
        fila["NroPatronal_Ruc_Alternativo"] = "";
        dt.Rows.Add(fila);
        gvEmpresasmanuales.DataSource = dt;
        gvEmpresasmanuales.DataBind();
    }

    //DATOS GRILLAS

    //Obtener datos sector
    public DataTable GetSector()
    {
        DataRow drFila;
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtSector = new DataTable();
        dtSector = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "Sector", ref sMensajeError);
        if (dtSector != null && dtSector.Rows.Count > 0)
        {
            drFila = dtSector.NewRow();
            drFila[0] = "0";
            drFila[1] = "Seleccione";
            dtSector.Rows.Add(drFila);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        return dtSector;
    }

    //Obtener datos meses
    public DataTable GetMes()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtMeses = new DataTable();
        dtMeses = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 30, ref sMensajeError);
        if (dtMeses != null && dtMeses.Rows.Count > 0)
        {

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        return dtMeses;
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
        DataRow drFila;
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtMoneda = new DataTable();
        dtMoneda = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "Moneda", ref sMensajeError);
        if (dtMoneda != null && dtMoneda.Rows.Count > 0)
        {
            int cantcol = dtMoneda.Columns.Count;
            drFila = dtMoneda.NewRow();
            for (int i = 0; i < cantcol; i++)
            {
                if (i == 4)
                {
                    drFila[i] = "Seleccione";
                }
                else
                {
                    drFila[i] = "0";
                }

            }
            dtMoneda.Rows.Add(drFila);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        return dtMoneda;
    }

    //Obtener doc salario
    public DataTable GetDocumentosSalarioAutomaticos()
    {
        DataRow drFila;
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtDocSalario = new DataTable();
        dtDocSalario = ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "DocSalario", ref sMensajeError);
        if (dtDocSalario.Rows.Count > 0)
        {
            int cantcol = dtDocSalario.Columns.Count;
            drFila = dtDocSalario.NewRow();
            for (int i = 0; i < cantcol; i++)
            {
                if (i == 4)
                {
                    drFila[i] = "Seleccione";
                }
                else
                {
                    drFila[i] = "0";
                }

            }
            dtDocSalario.Rows.Add(drFila);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(sMensajeError);
            Master.MensajeError(Error, DetalleError);
        }
        return dtDocSalario;
    }

    //Validar inicio tramite
    private bool ValidarProceso()
    {
        string Error = "Error al realizar la operación";
        string DetalleError;
        if (this.lblTipo.Text == "AUTOMÁTICO")
        {
            if (validagrillaAutomatico() == "0")
            {
                return true;
            }
            else
            {
                DetalleError = "Revisar la lista de Salarios a registrar";
                Master.MensajeError(Error, DetalleError);
                return false;
            }
        }
        else
        {
            if (validagrillaEmpresas() == "0")
            {
                return true;
            }
            else
            {
                DetalleError = "Revisar la lista de empresas a registrar";
                Master.MensajeError(Error, DetalleError);
                return false;
            }
        }
    }

    //Validar grilla Automatico
    private string validagrillaAutomatico()
    {
        int contador = 0;
        string sw = "0";
        foreach (GridViewRow fila in grdSalariosAutomaticos.Rows)
        {
            contador++;
            DropDownList ddlSectorSalario = (DropDownList)fila.FindControl("ddlSectorSalario");
            DropDownList cboMoneda = (DropDownList)fila.FindControl("cboMoneda");
            DropDownList cboDocumentosAutomatico = (DropDownList)fila.FindControl("cboDocumentosAutomatico");
            System.Web.UI.WebControls.TextBox txtTotal = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtTotal");
            System.Web.UI.WebControls.TextBox txtCopiaTotal = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtCopiaTotal");
            if (txtTotal.Text.Trim() != txtCopiaTotal.Text.Trim())
            {
                sw = "1";
            }
            if (ddlSectorSalario.SelectedValue.ToString() == "0")
            {
                sw = "2";
            }
            if (cboMoneda.SelectedValue.ToString() == "0")
            {
                sw = "3";
            }
            if (cboDocumentosAutomatico.SelectedValue.ToString() == "0")
            {
                sw = "4";
            }
        }
        if (contador == 0)
        {
            sw = "5";
        }
        return sw;
    }

    //Validar grilla empresas
    private string validagrillaEmpresas()
    {
        int contador = 0;
        string sw = "0";
        foreach (GridViewRow fila in gvEmpresasmanuales.Rows)
        {
            contador++;
            DropDownList ddlSectorEmpresaManual = (DropDownList)fila.FindControl("ddlSectorEmpresaManual");
            DropDownList cboDocumentosManual = (DropDownList)fila.FindControl("cboDocumentosManual");
            System.Web.UI.WebControls.TextBox txtFecha_Ingreso = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtFecha_Ingreso");
            System.Web.UI.WebControls.TextBox txtFecha_Retiro = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtFecha_Retiro");
            System.Web.UI.WebControls.TextBox txtRucEmpresaManual = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtRucEmpresaManual");
            System.Web.UI.WebControls.TextBox txtEmpresaManual = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtEmpresaManual");
            System.Web.UI.WebControls.CheckBox ckboxHabilitaEmpresaManual = (System.Web.UI.WebControls.CheckBox)fila.FindControl("ckboxHabilitaEmpresaManual");
            System.Web.UI.WebControls.TextBox txtRazonSocialEmpresaManual_Alternativo = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtRazonSocialEmpresaManual_Alternativo");
            System.Web.UI.WebControls.TextBox txtNroPatronal_Ruc_Alternativo = (System.Web.UI.WebControls.TextBox)fila.FindControl("txtNroPatronal_Ruc_Alternativo");
            if (ddlSectorEmpresaManual.SelectedValue.ToString() == "0")
            {
                sw = "1";
            }
            if (cboDocumentosManual.SelectedValue.ToString() == "0")
            {
                sw = "2";
            }
            if (ckboxHabilitaEmpresaManual.Checked == true)
            {
                if (txtRazonSocialEmpresaManual_Alternativo.Text.Trim() == "")
                {
                    sw = "3";
                }
                if (txtNroPatronal_Ruc_Alternativo.Text.Trim() == "")
                {
                    sw = "4";
                }
            }
            else
            {
                if (txtRucEmpresaManual.Text.Trim() == "")
                {
                    sw = "5";
                }
                if (txtEmpresaManual.Text.Trim() == "")
                {
                    sw = "6";
                }
            }
            if (txtFecha_Ingreso.Text.Trim() == "")
            {
                sw = "7";
            }
            else
            {
                if (txtFecha_Retiro.Text.Trim() == "")
                {
                    sw = "8";
                }
                else
                {
                    try
                    {
                        if (Convert.ToDateTime(txtFecha_Ingreso.Text.Trim()) > Convert.ToDateTime(txtFecha_Retiro.Text.Trim()))
                        {
                            sw = "9";
                        }
                        else
                        {
                            if (Convert.ToDateTime(txtFecha_Ingreso.Text.Trim()) >= Convert.ToDateTime("01/06/1997"))
                            {
                                sw = "10";
                            }
                            if (Convert.ToDateTime(txtFecha_Retiro.Text.Trim()) >= Convert.ToDateTime("01/06/1997"))
                            {
                                sw = "10";
                            }
                        }
                    }
                    catch
                    {
                        sw = "9";
                    }
                }
            }


        }
        if (contador == 0)
        {
            sw = "10";
        }
        return sw;
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
            wcfConvenios.Logica.clsPersona objPersona = new wcfConvenios.Logica.clsPersona();
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

    protected void CargarDocumentos()
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
            if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP")//manual
            {
                IdTipoTramite = 1401001;//Curso de Adq. - Trámite CC Manual
            }
           // dtDocumentos = ObjDocs.ObtenerDocumentos(iIdConexion, cOperacion, IdTipoTramite, Convert.ToInt64(this.rblTipoPersonaInicia.SelectedValue), Convert.ToInt64(this.ddlSector.SelectedValue), ref sMensajeError, ref lSesion);
            dtDocumentos = ObjDocs.ObtenerDocumentos();
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                rdbtDocs.DataSource = dtDocumentos;
                rdbtDocs.DataTextField = "Comentarios";
                rdbtDocs.DataValueField = "CptoTDOc";
                rdbtDocs.DataBind();
                Session["IdSesionDocumentos"] = lSesion;
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

    //Obtener datos persona
    private wcfConvenios.Logica.clsPersona ObtenerDatosPersona()
    {
        wcfConvenios.Logica.clsPersona Persona = new wcfConvenios.Logica.clsPersona();

        wcfConvenios.Logica.clsFormatoFecha f = new wcfConvenios.Logica.clsFormatoFecha();
        Persona.IdTipoDocumento = Convert.ToInt16(this.ddlTipoDocumento.SelectedValue);
        Persona.IdEstadoCivil = Convert.ToInt16(this.ddlEstadoCivil.SelectedValue);
        Persona.IdEntidadGestora = Convert.ToInt32(ddlAFP.SelectedValue.ToString());
        Persona.IdSexo = Convert.ToInt16(this.rblSexo.SelectedValue);
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
        //int IdPaisResidencia = c.EncontrarIdPorDescripcion(this.txtBuscarPais.Text, 10);
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
        if (this.lblTipo.Text == "AVC" || this.lblTipo.Text == "AP")//Manual
        {
            Tramite.IdGrupoBeneficio = 3;//Procedimiento Manual
            Tramite.IdBeneficio = 1;
            Tramite.IdSubBeneficio = 2;
            Tramite.IdTipoTramite = 356;//Manual modif aal
        }
        Tramite.IdOrigen = 340;
        if (this.ddlSector.SelectedValue != "")
            Tramite.IdSector = Convert.ToInt32(this.ddlSector.SelectedValue);
        else
            Tramite.IdSector = 0;
        Tramite.NUP = NUP;
        Tramite.NUPIniciaTramite = NUPIniciaTramite;
        Tramite.IdTipoIniciaTramite = Convert.ToInt32(this.rblTipoPersonaInicia.SelectedValue);
        Tramite.Observaciones = "INICIO TRAMITE";
        Tramite.IdEstadoTramite = 1;
        Tramite.RegistroActivo = 1;

        return Tramite;
    }

    //Valida que se tengan registrados los datos necesarios para iniciar trámite
    private bool ValidaDatosCompletos()
    {
        if (this.rblTipoPersonaInicia.SelectedItem != null)
        {
            if (this.rblTipoPersonaInicia.SelectedItem.Text != "TITULAR")
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
            txtMatriculaGenerada.Text = GenerarMatricula(this.txtPrimerApellido.Text, this.txtSegundoApellido.Text, this.txtPrimerNombre.Text, (new wcfConvenios.Logica.clsFormatoFecha()).GeneraFechaDMY(this.txtFechaNacimiento.Text), rblSexo.Text);
            txtMatricula.Text = txtMatriculaGenerada.Text;
            this.btnGenerarMatricula.Enabled = false;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
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
        /* this.pnlJustificar.Visible = true;
         ModalPopupExtender3.Show();
         txtMotivoi.Focus();*/
        HabilitarPaneles(1);
        InhabilitarDatosPersonales();
    }

    //Redireccionar al inicio de trámite
    protected void ibtnDenegar_Click(object sender, EventArgs e)
    {
        // Response.Redirect("wfrmRegistroTramite.aspx");
    }

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

    //Boton Residencia Siguiente
    protected void btnSiguienteResidencia_Click(object sender, EventArgs e)
    {
        if (ValidaDatosResidencia())
        {
            this.txtBuscarPais.Enabled = false;
            this.txtBuscarLocalidad.Enabled = false;
            this.ibtnBuscarPais.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtCelular.Enabled = false;
            this.txtEmail.Enabled = false;
            this.ibtnBuscarLocalidad.Enabled = false;
            //HabilitarPaneles(2);
            this.btnSiguienteResidencia.Enabled = false;
            this.btnRegistrar.Visible = true;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
    }

    /*  //Boton Tramite Siguiente
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

      //Boton PM Siguiente
      protected void btnSiguientePA_Click(object sender, EventArgs e)
      {
          if (ValidarProceso())
          {
              this.txtBuscarEmpresaAutomatico.Enabled = false;
              this.txtBuscarRUCAutomatico.Enabled = false;
              this.btnBuscarAutomatico.Enabled = false;
              this.grdSalariosAutomaticos.Enabled = false;
              this.btnSiguientePA.Enabled = false;
              string msg = "La operacion se realizo con exito";
              Master.MensajeOk(msg);
          }
      }

      //Boton PM Siguiente
      protected void btnSiguientePM_Click(object sender, EventArgs e)
      {
          if (ValidarProceso())
          {
              this.txtEmpresaManual.Enabled = false;
              this.txtRucManual.Enabled = false;
              this.ibtnBuscarEmpresaManual.Enabled = false;
              this.ibtnNuevaEmpresaManual.Enabled = false;
              this.gvEmpresasmanuales.Enabled = false;
              this.btnSiguientePM.Enabled = false;
           
              string msg = "La operacion se realizo con exito";
              Master.MensajeOk(msg);
          }
      }*/

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmInformacion.aspx");
    }

    //Buscar localidad
    protected void ibtnBuscarLocalidad_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusLocalidad.Text = this.txtBuscarLocalidad.Text;
        BuscarLocalidad(this.txtBuscarLocalidad.Text);
        this.gvGeo.Visible = true;
        ModalPopupExtender_LOCALIDAD.Show();
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
    //Boton de reporte
    protected void btnForm02_Click(object sender, System.EventArgs e)
    {
        string Variable = HiddenIdtramite.Value;
        Response.Redirect("wfrmReportForm02.aspx?tramite=" + Variable);
    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string Variable = HiddenIdtramite.Value;
        Response.Redirect("wfrmReport.aspx?tramite=" + Variable);
    }

    //Buscar tramitador en persona
    protected void btnBuscarTramitador_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusNumDoc.Text = txtNombreCompeto.Text;
        this.txtBusNombre.Text = "";
        this.txtBusApellido.Text = "";
        BuscarPersonaInicio(this.txtBusNumDoc.Text, "", "");
        gvPersonaInicio.Visible = true;
        ModalPopupExtender1.Show();
    }
    protected void ibtnBuscarPais_Click(object sender, ImageClickEventArgs e)
    {
        this.txtBusPais.Text = this.txtBuscarPais.Text;
        BuscarPais(this.txtBuscarPais.Text);
        this.gvPais.Visible = true;
        ModalPopupExtender_Pais.Show();
        this.txtBusPais.Focus();
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
    protected void btnBusPais_Click(object sender, EventArgs e)
    {
        
BuscarPais(this.txtBusPais.Text);
        ModalPopupExtender_Pais.Show();
    }
    protected void btnCancelPais_Click(object sender, EventArgs e)
    {
        this.gvPais.Visible = false;
        this.txtBuscarPais.Focus();
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

    #region grilla empresas manual

    protected void ckboxHabilitaEmpresaManual_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow dr in gvEmpresasmanuales.Rows)
        {
            CheckBox ckboxHabilitaEmpresaManual = (CheckBox)dr.Cells[0].FindControl("ckboxHabilitaEmpresaManual");
            TextBox txtRazonSocialEmpresaManual_Alternativo = (TextBox)dr.Cells[0].FindControl("txtRazonSocialEmpresaManual_Alternativo");
            TextBox txtNroPatronal_Ruc_Alternativo = (TextBox)dr.Cells[0].FindControl("txtNroPatronal_Ruc_Alternativo");

            if (ckboxHabilitaEmpresaManual.Checked == true)
            {
                txtRazonSocialEmpresaManual_Alternativo.Visible = true;
                txtNroPatronal_Ruc_Alternativo.Visible = true;
            }
            else
            {
                txtRazonSocialEmpresaManual_Alternativo.Visible = false;
                txtNroPatronal_Ruc_Alternativo.Visible = false;
            }
        }
    }

    protected void ibtnNuevaEmpresaManual_Click(object sender, EventArgs e)
    {
        adicionaempresaManual2("0", "");
        enabledgrillaEmpresas();
    }

    private void enabledgrillaEmpresas()
    {
        if (gvEmpresasmanuales.Rows.Count > 0)
        {
            foreach (GridViewRow fila in gvEmpresasmanuales.Rows)
            {
                TextBox txtRucEmpresaManual = (TextBox)fila.FindControl("txtRucEmpresaManual");
                TextBox txtEmpresaManual = (TextBox)fila.FindControl("txtEmpresaManual");
                CheckBox ckboxHabilitaEmpresaManual = (CheckBox)fila.FindControl("ckboxHabilitaEmpresaManual");
                if (txtRucEmpresaManual.Text == "0")
                {
                    txtRucEmpresaManual.Enabled = false;
                    txtEmpresaManual.Enabled = false;
                    ckboxHabilitaEmpresaManual.Enabled = true;
                }
                else
                {
                    txtRucEmpresaManual.Enabled = true;
                    txtEmpresaManual.Enabled = true;
                    ckboxHabilitaEmpresaManual.Enabled = false;
                }
            }
        }
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
                this.gvSeleccionarEmpresaManual.Visible = false;
                adicionaempresaManual2(ruc, empresa);
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
        if (e.CommandName == "cmdEliminarEmpManual")
        {
            Index = Convert.ToInt32(e.CommandArgument);

            DataTable dt = new DataTable();
            DataRow filadt;
            dt = new DataTable();
            dt.Columns.Add("IdSector");
            dt.Columns.Add("Fecha_Ingreso");
            dt.Columns.Add("Fecha_Retiro");
            dt.Columns.Add("Ruc");
            dt.Columns.Add("Empresa");
            dt.Columns.Add("IdDetalleClasificadorDoc");
            dt.Columns.Add("RazonSocialEmpresaManual");
            dt.Columns.Add("NroPatronal_Ruc_Alternativo");


            // salvar datos de la grid
            foreach (GridViewRow fila in gvEmpresasmanuales.Rows)
            {
                filadt = dt.NewRow();
                DropDownList ddlSectorEmpresaManual = (DropDownList)fila.FindControl("ddlSectorEmpresaManual");
                filadt["IdSector"] = ddlSectorEmpresaManual.SelectedValue;

                TextBox txtFecha_Ingreso = (TextBox)fila.FindControl("txtFecha_Ingreso");
                filadt["Fecha_Ingreso"] = txtFecha_Ingreso.Text;

                TextBox txtFecha_Retiro = (TextBox)fila.FindControl("txtFecha_Retiro");
                filadt["Fecha_Retiro"] = txtFecha_Ingreso.Text;

                TextBox txtRucEmpresaManual = (TextBox)fila.FindControl("txtRucEmpresaManual");
                filadt["Ruc"] = txtRucEmpresaManual.Text;

                TextBox txtEmpresaManual = (TextBox)fila.FindControl("txtEmpresaManual");
                filadt["Empresa"] = txtEmpresaManual.Text;

                DropDownList cboDocumentosManual = (DropDownList)fila.FindControl("cboDocumentosManual");
                filadt["IdDetalleClasificadorDoc"] = cboDocumentosManual.SelectedValue;

                TextBox txtRazonSocialEmpresaManual_Alternativo = (TextBox)fila.FindControl("txtRazonSocialEmpresaManual_Alternativo");
                filadt["RazonSocialEmpresaManual"] = txtRazonSocialEmpresaManual_Alternativo.Text;

                TextBox txtNroPatronal_Ruc_Alternativo = (TextBox)fila.FindControl("txtNroPatronal_Ruc_Alternativo");
                filadt["NroPatronal_Ruc_Alternativo"] = txtNroPatronal_Ruc_Alternativo.Text;
                dt.Rows.Add(filadt);
            }
            dt.Rows.RemoveAt(Index);
            gvEmpresasmanuales.DataSource = dt;
            gvEmpresasmanuales.DataBind();
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
        try
        {
            int Index;
            if (e.CommandName == "cmdEmpresaAuto")
            {
                Index = Convert.ToInt32(e.CommandArgument);
                string ruc = Convert.ToString(gvSeleccionarEmpresaAutomatico.DataKeys[Index].Values["RUC"]);
                string empresa = Convert.ToString(gvSeleccionarEmpresaAutomatico.DataKeys[Index].Values["NombreEmpresa"]);
                this.gvSeleccionarEmpresaAutomatico.Visible = false;
                adiccionaempresa(ruc, empresa);
                ModalPopupExtender.Hide();
            }
        }
        catch (Exception ex)
        {
            string sError = "Error al realizar la operación.";
            string sDetalleError = ex.Message;
            Master.MensajeError(sError, sDetalleError);
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
        if (e.CommandName == "cmdEliminarEmp")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            try
            {
                DataTable dt = new DataTable();
                DataRow filadt;
                dt.Columns.Add("IdSector");
                dt.Columns.Add("Ruc");
                dt.Columns.Add("Empresa");
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Anio");
                dt.Columns.Add("Total");
                dt.Columns.Add("CopiaTotal");
                dt.Columns.Add("IdDetalleClasificadorMon");
                dt.Columns.Add("IdDetalleClasificadorDoc");

                // salvar datos de la grid
                foreach (GridViewRow fila in grdSalariosAutomaticos.Rows)
                {
                    filadt = dt.NewRow();
                    DropDownList ddlSectorSalario = (DropDownList)fila.FindControl("ddlSectorSalario");
                    filadt["IdSector"] = ddlSectorSalario.SelectedValue;
                    TextBox txtRuc = (TextBox)fila.FindControl("txtRuc");
                    filadt["Ruc"] = txtRuc.Text;
                    TextBox txtEmpresa = (TextBox)fila.FindControl("txtEmpresa");
                    filadt["Empresa"] = txtEmpresa.Text;
                    DropDownList cboMes = (DropDownList)fila.FindControl("cboMes");
                    filadt["Codigo"] = cboMes.SelectedValue;
                    DropDownList cboAno = (DropDownList)fila.FindControl("cboAno");
                    filadt["Anio"] = cboAno.SelectedValue;
                    TextBox txtTotal = (TextBox)fila.FindControl("txtTotal");
                    filadt["Total"] = txtTotal.Text;

                    TextBox txtCopiaTotal = (TextBox)fila.FindControl("txtCopiaTotal");
                    filadt["CopiaTotal"] = txtCopiaTotal.Text;
                    DropDownList cboMoneda = (DropDownList)fila.FindControl("cboMoneda");
                    filadt["IdDetalleClasificadorMon"] = cboMoneda.SelectedValue;
                    DropDownList cboDocumentosAutomatico = (DropDownList)fila.FindControl("cboDocumentosAutomatico");
                    filadt["IdDetalleClasificadorDoc"] = cboDocumentosAutomatico.SelectedValue;
                    dt.Rows.Add(filadt);
                }
                dt.Rows.RemoveAt(Index);
                grdSalariosAutomaticos.DataSource = dt;
                grdSalariosAutomaticos.DataBind();
            }
            catch (Exception ex)
            {
                string sError = "Error al realizar la operación.";
                string sDetalleError = ex.Message;
                Master.MensajeError(sError, sDetalleError);
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

                this.txtFechaNacimientoInicia.Text = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["FechaNacimiento"]);
                this.txtFechaNacimientoInicia.Enabled = false;



                this.rdblSexoInicia.SelectedValue = Convert.ToString(gvPersonaInicio.DataKeys[Index].Values["IdSexo"]);
                this.rdblSexoInicia.Enabled = false;

                this.gvPersonaInicio.Visible = false;
                ModalPopupExtender1.Hide();
                // this.btnSiguienteTramite.Focus();
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
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        wcfConvenios.Logica.clsPersona objPersona;
        long NUP = 0;
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        //Datos Persona
        objPersona = ObtenerDatosPersona();
        NUP = objPersona.RegistrarPersona(iIdConexion, cOperacion, ref objPersona, ref sMensajeError);
        if (NUP != 0)
        {
            Master.MensajeOk("Se registro a la persona");
            Session["NUP"] = NUP;
            Session["CUA"] = objPersona.CUA;
            Response.Redirect("~/Convenios/wfrmVerDeuda.aspx");
        }
        else
        {
            Master.MensajeError("No se registro a la persona", sMensajeError);
            HabilitarPaneles(0);
            HabilitarPaneles(1);
            HabilitarDatosPersonales();
        }
    }
}