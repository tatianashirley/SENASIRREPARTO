
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;
public partial class Administracion_CompletarDatosRenuncia : System.Web.UI.Page
{
    #region constantes

    private const string RENUNCIA_INICIO_MANUAL = "0";
    private const string RENUNCIA = "1";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringGrupo;
        string queryStringIdTramite;
        string queryStringTabla;
        string queryStringOrigen;

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
        string IdTramite = "";
        DataTable dtTramite;

        if (!Page.IsPostBack)
        {
            queryStringOrigen = Request.QueryString["Origen"];
            queryStringTabla = Request.QueryString["Tipo"];
            queryStringIdTramite = Request.QueryString["iIdTramite"];
            queryStringGrupo = Request.QueryString["iIdGrupoBeneficio"];

            if (queryStringTabla != "")
            {
                lblTipo.Text = "Nro. Trámite:" + queryStringIdTramite;
                hddIdTramite.Value = queryStringIdTramite;
                hddIdGrupoBeneficio.Value = queryStringGrupo;
                hddTipo.Value = queryStringTabla;
                hddOrigen.Value = queryStringOrigen;

                if (RENUNCIA_INICIO_MANUAL.Equals(queryStringTabla))
                {
                    lblTituloSistema.Text = "MODULO RENUNCIA INICIO MANUAL";
                    lblSubTitulo.Text = "Confirmar Renuncia Inicio Manual";
                }
                else if (RENUNCIA.Equals(queryStringTabla))
                {
                    lblTituloSistema.Text = "MODULO RENUNCIA AUTOMÁTICA";
                    lblSubTitulo.Text = "Confirmar Renuncia Automática";
                }
                dtTramite = buscarTramitesRenuncia(queryStringIdTramite, queryStringGrupo, queryStringTabla);
                if (dtTramite != null && dtTramite.Rows.Count > 0)
                {
                    foreach (DataRow row in dtTramite.Rows)
                    {
                        NUPString = row["NUP"].ToString();
                        Matricula = row["Matricula"].ToString();
                        Nombre = row["PrimerNombre"].ToString();
                        SegundoNombre = row["SegundoNombre"].ToString();
                        Paterno = row["PrimerApellido"].ToString();
                        Materno = row["SegundoApellido"].ToString();
                        //Casada = row["FechaNacimiento"].ToString();
                        clsFormatoFecha f = new clsFormatoFecha();
                        DateTime d = f.GeneraFechaDMY(row["FechaNacimiento"].ToString());
                        Nacimiento = f.Fecha(d);
                        CUA = row["CUA"].ToString();
                        CI = row["NumeroDocumento"].ToString();
                        Complemento = row["ComplementoSEGIP"].ToString();
                        IdTramite = row["IdTramite"].ToString();
                    }
                }
                //cargar datos en pantalla
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla, IdTramite, queryStringTabla);
                CargarDocumentos(1);
                CargarDocumentos(2);
            }
            HabilitarPaneles(queryStringTabla);
        }
    }

    #endregion

    #region paneles

    //Habilitar paneles
    private void HabilitarPaneles(string iTipo)
    {
        switch (iTipo)
        {
            case RENUNCIA_INICIO_MANUAL:
                this.TabRenuncia.Visible = true;
                this.TabRenuncia.HeaderText = "Renuncia Inicio Manual";
                this.TabContainer1.ActiveTabIndex = 0;
                break;
            case RENUNCIA:
                this.TabRenuncia.Visible = true;
                this.TabRenuncia.HeaderText = "Confirmar Renuncia";
                this.TabContainer1.ActiveTabIndex = 0;
                break;
        }
    }

    #endregion

    #region funciones

    //Buscar Tramites
    protected DataTable buscarTramitesRenuncia(string nroTramite, string grupoBeneficio, string estadoTramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string iIdTramite = "0";
        int iGrupoBeneficio = 0;
        string cOperacion = "Q";
        string sTipo = "";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();
        if (!String.IsNullOrEmpty(nroTramite))
        {
            iIdTramite = nroTramite;
        }
        if (!String.IsNullOrEmpty(grupoBeneficio))
        {
            iGrupoBeneficio = Convert.ToInt32(grupoBeneficio);
        }
        /*
        if (RENUNCIA_INICIO_MANUAL.Equals(estadoTramite))
        {
            sTipo = "Inicial";
        }
        else if (RENUNCIA.Equals(estadoTramite))
        {
            sTipo = "PreRenuncia";
        }*/
        sTipo = "PreRenuncia";
        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, iGrupoBeneficio, "", "", "", "", "", "", "", sTipo, ref sMensajeError);

        return dtListaPersonas;
    }

    //Cargar Datos
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla, string IdTramite, string Tipo)
    {
        clsFormatoFecha f = new clsFormatoFecha();
        txtPrimerNombre.Text = Nombre;
        txtSegundoNombre.Text = SegundoNombre;
        txtPrimerApellido.Text = Paterno;
        txtSegundoApellido.Text = Materno;
        txtApellidoCasada.Text = Casada;
        txtNumeroDocumento.Text = CI;
        txtCUA.Text = CUA;
        if (!String.IsNullOrEmpty(Nacimiento))
        {
            txtFechaNac.Text = f.Fecha(f.GeneraFechaDMY(Nacimiento));
        }
        txtMatricula.Text = Matricula;
    }

    //Cargar documentos
    protected void CargarDocumentos(long IdTipoTramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        clsDocumentos ObjDocs = new clsDocumentos();
        DataTable dtDocumentos = new DataTable();
        try
        {
            dtDocumentos = ObjDocs.ObtenerDocumentosRenuncia(iIdConexion, cOperacion, IdTipoTramite, ref sMensajeError);
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                if (IdTipoTramite == 1)
                {
                    rdbtDocs1.DataSource = dtDocumentos;
                    rdbtDocs1.DataTextField = "Descripcion";
                    rdbtDocs1.DataValueField = "IdTipoDocumento";
                    rdbtDocs1.DataBind();
                }
                if (IdTipoTramite == 2)
                {
                    rdbtDocs2.DataSource = dtDocumentos;
                    rdbtDocs2.DataTextField = "Descripcion";
                    rdbtDocs2.DataValueField = "IdTipoDocumento";
                    rdbtDocs2.DataBind();
                }
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
            if (IdTipoTramite == 1 && rdbtDocs1 != null)
            {
                foreach (ListItem fila in rdbtDocs1.Items)
                {
                    fila.Selected = true;
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

    //Obtener documentos elegidos
    private List<clsDocumentos> ObtenerDocumentos1(long IdTramite)
    {
        List<clsDocumentos> lstDocumentos = new List<clsDocumentos>();
        foreach (ListItem fila in rdbtDocs1.Items)
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

    //Obtener documentos elegidos
    private List<clsDocumentos> ObtenerDocumentos2(long IdTramite)
    {
        List<clsDocumentos> lstDocumentos = new List<clsDocumentos>();
        foreach (ListItem fila in rdbtDocs2.Items)
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

    //Buscar empresas
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

    //Cargar combos empresa    
    private void CargarCombosEmpresas(string sTipo)
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

    //Obtener doc salario
    public DataTable GetDocumentosSalarioAutomaticos()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        return ObjTramite.ObtenerParametros(iIdConexion, cOperacion, "DocSalario", ref sMensajeError);
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
        btnSiguienteEmpresa.Enabled = true;
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
        }
        return true;
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

    //Valida datos de entrada
    private bool ValidarObservaciones()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (txtDescripcion.Text.Trim() == null || txtDescripcion.Text.Trim() == "")
        {
            sDetalleError = "Las Observaciones son requeridas.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    //Validar documentos
    public bool ValidarDocumentos()
    {
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
        int iCantidad = 0;
        if (rdbtDocs1 != null && rdbtDocs1.Items.Count > 0)
        {
            foreach (ListItem fila in rdbtDocs1.Items)
            {
                if (fila.Selected)
                {
                    iCantidad++;
                }
            }
        }
        if (iCantidad != rdbtDocs1.Items.Count)
        {
            sDetalleError = "Debe elegir todos los documentos requeridos.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        iCantidad = 0;
        if (rdbtDocs2 != null && rdbtDocs2.Items.Count > 0)
        {
            foreach (ListItem fila in rdbtDocs2.Items)
            {
                if (fila.Selected)
                {
                    iCantidad++;
                }
            }
        }
        if (iCantidad <= 0)
        {
            sDetalleError = "Debe elegir al menos un documento por sector.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    #endregion

    #region botones

    protected void btnSiguienteRenuncia_Click(object sender, EventArgs e)
    {
        if (ValidarObservaciones())
        {
            this.txtDescripcion.Enabled = false;
            this.btnSiguienteRenuncia.Enabled = false;
            this.TabDocumentos.Visible = true;
            this.TabDocumentos.HeaderText = "Documentos";
            this.TabContainer1.ActiveTabIndex = 1;
            this.Master.MensajeCancel();
        }
    }

    protected void btnSiguienteDoc_Click(object sender, EventArgs e)
    {
        if (ValidarDocumentos())
        {
            this.rdbtDocs1.Enabled = false;
            this.rdbtDocs2.Enabled = false;
            this.btnSiguienteDoc.Enabled = false;
            if (RENUNCIA_INICIO_MANUAL.Equals(hddTipo.Value))
            {
                this.btnRenunciaInicial.Visible = true;
            }
            else
            {
                CargarCombosEmpresas("M");
                this.TabManual.Visible = true;
                this.TabManual.HeaderText = "PM - Empresas";
                this.TabContainer1.ActiveTabIndex = 2;
            }
            this.Master.MensajeCancel();
        }
    }

    protected void btnSiguienteEmpresa_Click(object sender, EventArgs e)
    {
        txtEmpresaManual.Enabled = false;
        txtRucManual.Enabled = false;
        ddlSectorEmpresaManual.Enabled = false;
        txtFecha_Ingreso.Enabled = false;
        txtFecha_Retiro.Enabled = false;
        ddlDocumentoManual.Enabled = false;
        txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
        txtNroPatronal_Ruc_Alternativo.Enabled = false;
        this.gvEmpresasmanuales.Enabled = false;

        this.btnSiguienteEmpresa.Enabled = false;
        this.btnAgregarManual.Enabled = false;
        this.ibtnBuscarEmpresaManual.Enabled = false;
        this.btnConfirmarRenuncia.Visible = true;
        this.btnCancelarRenuncia.Visible = true;
        this.Master.MensajeCancel();
    }

    //BUSCAR EMPRESA Proceso manual
    protected void ibtnBuscarEmpresaManual_Click(object sender, EventArgs e)
    {
        this.txtBusEmpMan.Text = "";// this.txtEmpresaManual.Text;
        this.txtBusRucMan.Text = "";// this.txtRucManual.Text;
        BuscarEmpresaManual(this.txtBusEmpMan.Text, this.txtBusRucMan.Text);
        gvSeleccionarEmpresaManual.Visible = true;
        gvSeleccionarEmpresaManual.DataSource = null;
        gvSeleccionarEmpresaManual.DataBind();
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
            txtRazonSocialEmpresaManual_Alternativo.Text = "";
            txtRazonSocialEmpresaManual_Alternativo.Enabled = false;
            txtNroPatronal_Ruc_Alternativo.Text = "";
            txtNroPatronal_Ruc_Alternativo.Enabled = false;
            btnSiguienteEmpresa.Visible = true;
            Master.MensajeCancel();
        }
    }

    protected void btnBusEmpresaManual_Click(object sender, EventArgs e)
    {
        BuscarEmpresaManual(this.txtBusEmpMan.Text, this.txtBusRucMan.Text);
        ModalPopupExtenderEmpresasManual2.Show();
    }

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        string sTipo = "A";
        if (RENUNCIA_INICIO_MANUAL.Equals(hddTipo.Value))
        {
            sTipo = "I";
        }
        Response.Redirect("wfrmPreRenunciaAutomatica.aspx?Tipo=" + sTipo);
    }

    //Guardar renuncia inicial
    protected void btnRenunciaInicial_Click(object sender, EventArgs e)
    {
        string Error;
        string DetalleError;
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        long iIdTramite = Convert.ToInt32(hddIdTramite.Value);
        long lIdTramite = 0;
        int iGrupoBeneficio = Convert.ToInt32(hddIdGrupoBeneficio.Value);
        clsTramite objTramite = new clsTramite();
        List<clsDocumentos> lstDocumentos;
        clsDocumentos objdoc;
        if (ValidarObservaciones())
        {
            Master.MensajeCancel();
            if (objTramite.RenunciaAutomatica(iIdConexion, cOperacion, iIdTramite, iGrupoBeneficio, txtDescripcion.Text.Trim(), ref lIdTramite, ref sMensajeError))
            {
                //DOCUMENTOS
                cOperacion = "R";
                lstDocumentos = ObtenerDocumentos1(iIdTramite);
                foreach (clsDocumentos item in lstDocumentos)
                {
                    objdoc = item;
                    if (!objdoc.RegistrarDocumentos(iIdConexion, cOperacion, objdoc, ref sMensajeError))
                    {
                        Error = "Error al realizar la operación";
                        DetalleError = Convert.ToString(sMensajeError);
                        Master.MensajeError(Error, DetalleError);
                    }
                }
                lstDocumentos = ObtenerDocumentos2(iIdTramite);
                foreach (clsDocumentos item in lstDocumentos)
                {
                    objdoc = item;
                    if (!objdoc.RegistrarDocumentos(iIdConexion, cOperacion, objdoc, ref sMensajeError))
                    {
                        Error = "Error al realizar la operación";
                        DetalleError = Convert.ToString(sMensajeError);
                        Master.MensajeError(Error, DetalleError);
                    }
                }
                lblConfirmacion.Text = "Se registró correctamente la Renuncia Inicial.";
                this.btnRenunciaInicial.Enabled = false;
                this.btnCancelar.Text = "Salir";
                this.btnReporteRenuncia.Visible = true;
                btnReporteRenuncia.OnClientClick = "window.open('wfrmReportForm03.aspx?tramite=" + hddIdTramite.Value + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
            }
            else
            {
                lblConfirmacion.Text = sMensajeError;
            }
        }
    }

    //Guardar confirmación renuncia
    protected void btnConfirmarRenuncia_Click(object sender, EventArgs e)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";
        long iIdTramite = Convert.ToInt32(hddIdTramite.Value);
        long lIdTramite = 0;
        int iGrupoBeneficio = Convert.ToInt32(hddIdGrupoBeneficio.Value);
        string Error;
        string DetalleError;
        List<clsDocumentos> lstDocumentos;
        clsDocumentos objdoc;
        clsTramite objTramite = new clsTramite();
        List<clsEmpresaPersona> lstEmpresaPersona;
        clsEmpresaPersona objEmpresaPersona;
        clsTramite flujo = new clsTramite();
        try
        {
            if (objTramite.RenunciaAutomatica(iIdConexion, cOperacion, iIdTramite, iGrupoBeneficio, txtDescripcion.Text.Trim(), ref lIdTramite, ref sMensajeError))
            {

                lblConfirmacion.Text = "Se registró correctamente la Renuncia Inicial.";
                this.btnRenunciaInicial.Enabled = false;
                this.btnCancelar.Text = "Salir";

                hddIdTramiteManual.Value = Convert.ToString(lIdTramite);
                //DOCUMENTOS
                cOperacion = "R";
                lstDocumentos = ObtenerDocumentos1(lIdTramite);
                foreach (clsDocumentos item in lstDocumentos)
                {
                    objdoc = item;
                    if (!objdoc.RegistrarDocumentos(iIdConexion, cOperacion, objdoc, ref sMensajeError))
                    {
                        Error = "Error al realizar la operación";
                        DetalleError = Convert.ToString(sMensajeError);
                        Master.MensajeError(Error, DetalleError);
                    }
                }
                lstDocumentos = ObtenerDocumentos2(lIdTramite);
                foreach (clsDocumentos item in lstDocumentos)
                {
                    objdoc = item;
                    if (!objdoc.RegistrarDocumentos(iIdConexion, cOperacion, objdoc, ref sMensajeError))
                    {
                        Error = "Error al realizar la operación";
                        DetalleError = Convert.ToString(sMensajeError);
                        Master.MensajeError(Error, DetalleError);
                    }
                }

                //PROCESO MANUAL
                lstEmpresaPersona = ObtenerDatosEmpresas(lIdTramite);
                foreach (clsEmpresaPersona item in lstEmpresaPersona)
                {
                    objEmpresaPersona = item;
                    objEmpresaPersona.iIdConexion = iIdConexion;
                    objEmpresaPersona.cOperacion = "I";
                    if (!objEmpresaPersona.Registrar())
                    {
                        Error = "Error al realizar la operación";
                        sMensajeError = sMensajeError + " " + Convert.ToString(objEmpresaPersona.sMensajeError);
                        Master.MensajeError(Error, sMensajeError);
                    }
                }
                /*Inicio Articulador */
                flujo.iIdConexion = (int)Session["IdConexion"];
                flujo.cOperacion = "I";
                flujo.Tipo = "Inicia";
                flujo.IdTramite = Convert.ToInt64(lIdTramite);
                if (!flujo.FlujoTramite())
                {
                    throw new System.InvalidOperationException(flujo.sMensajeError);
                }
                lblConfirmacion.Text = "Se fusionó el Trámite Automático con el Trámite Manual:" + lIdTramite;
                this.btnCancelarRenuncia.Enabled = false;
                this.btnConfirmarRenuncia.Enabled = false;
                this.btnCancelar.Text = "Salir";
                this.btnReporte.Visible = true;
                btnReporte.OnClientClick = "window.open('wfrmReport.aspx?tramite=" + hddIdTramiteManual.Value + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
                this.btnForm02.Visible = true;
                btnForm02.OnClientClick = "window.open('wfrmReportForm02.aspx?tramite=" + hddIdTramiteManual.Value + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
            }
            else
            {
                lblConfirmacion.Text = sMensajeError;
            }
        }
        catch (Exception ex)
        {
            Error = "Error al realizar la operación";
            DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Guardar cancelar renuncia inicial
    protected void btnCancelarRenuncia_Click(object sender, EventArgs e)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        long iIdTramite = Convert.ToInt32(hddIdTramite.Value);
        long lIdTramite = 0;
        int iGrupoBeneficio = Convert.ToInt32(hddIdGrupoBeneficio.Value);
        clsTramite objTramite = new clsTramite();
        if (objTramite.RenunciaAutomatica(iIdConexion, cOperacion, iIdTramite, iGrupoBeneficio, txtDescripcion.Text.Trim(), ref lIdTramite, ref sMensajeError))
        {
            lblConfirmacion.Text = "Se registró correctamente la Cancelación de la Renuncia Inicial.";
            this.btnCancelarRenuncia.Enabled = false;
            this.btnConfirmarRenuncia.Enabled = false;
            this.btnCancelar.Text = "Salir";
        }
        else
        {
            lblConfirmacion.Text = sMensajeError;
        }
    }

    //Boton de reporte
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string Variable = hddIdTramiteManual.Value;
        //Response.Redirect("wfrmReport.aspx?tramite=" + Variable);
    }

    protected void btnForm02_Click(object sender, System.EventArgs e)
    {
        string Variable = hddIdTramiteManual.Value;
    }

    protected void btnReporteRenuncia_Click(object sender, EventArgs e)
    {
        string Variable = hddIdTramiteManual.Value;
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmPreRenunciaAutomatica.aspx");
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
                btnSiguienteEmpresa.Visible = false;
            }
        }
    }

    #endregion
}