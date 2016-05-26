
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;
public partial class Administracion_CompletarDatosRenunciaAcceso : System.Web.UI.Page
{
    #region constantes

    private const string PRE_RENUNCIA = "0";
    private const string RENUNCIA = "1";
    private const string MENU = "Menu";
    private const string WORKFLOW = "Workflow";

    private const int REQ_INDISPENSABLES = 31440;
    private const int REQ_SECTOR = 31441;
    private const int REQ_MODALIDAD = 31442;
    private const int CAUSA_NINGUNA = 31504;

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringIdTramite;
        string queryStringMatricula;

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
            lblTituloSistema.Text = "MODULO RENUNCIA AL SISTEMA DE REPARTO";
            lblSubTitulo.Text = "Datos Asegurado";
            queryStringMatricula = Request.QueryString["iMatricula"];
            queryStringIdTramite = Request.QueryString["iIdTramite"];

            if (queryStringIdTramite != "")
            {
                lblTipo.Text = "Nro. Trámite:" + queryStringIdTramite;
                hddIdTramite.Value = queryStringIdTramite;
                hddIdMatricula.Value = queryStringMatricula;

                dtTramite = buscarTramitesRenuncia(queryStringIdTramite, queryStringMatricula);
                if (dtTramite != null && dtTramite.Rows.Count > 0)
                {
                    foreach (DataRow row in dtTramite.Rows)
                    {
                        Matricula = row["Matricula"].ToString();
                        Nombre = row["PrimerNombre"].ToString();
                        SegundoNombre = row["SegundoNombre"].ToString();
                        Paterno = row["PrimerApellido"].ToString();
                        Materno = row["SegundoApellido"].ToString();
                        CI = row["NumeroDocumento"].ToString();
                        Complemento = row["ComplementoSEGIP"].ToString();
                        IdTramite = row["IdTramite"].ToString();
                    }
                }
                //cargar datos en pantalla
                CargarDatos(Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla, IdTramite);
                CargarDocumentos(1, "A");
                CargarDocumentos(2, "A");
                CargarDocumentos(1, "B");
            }
        }
    }

    #endregion

    #region funciones

    //Buscar Tramites
    protected DataTable buscarTramitesRenuncia(string nroTramite, string matricula)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();

        dtListaPersonas = objTramite.BuscarTramiteReparto(iIdConexion, cOperacion, nroTramite, "", "", "", "", "", "", matricula, "Inicial", ref sMensajeError);

        return dtListaPersonas;
    }

    //Cargar Datos
    private void CargarDatos(string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla, string IdTramite)
    {
        txtPrimerNombre.Text = Nombre;
        txtSegundoNombre.Text = SegundoNombre;
        txtPrimerApellido.Text = Paterno;
        txtSegundoApellido.Text = Materno;
        txtApellidoCasada.Text = Casada;
        txtNumeroDocumento.Text = CI;
        txtMatricula.Text = Matricula;
    }

    protected void CargarDocumentos(long IdTipoTramite, string tipo)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = tipo;
        clsDocumentos ObjDocs = new clsDocumentos();
        DataTable dtDocumentos = new DataTable();
        try
        {
            dtDocumentos = ObjDocs.ObtenerDocumentosRenuncia(iIdConexion, cOperacion, IdTipoTramite, ref sMensajeError);
            if (dtDocumentos != null && dtDocumentos.Rows.Count > 0)
            {
                if (tipo.Equals("A"))
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
                else if (tipo.Equals("B"))
                {
                    if (IdTipoTramite == 1)
                    {
                        rdbtCausa.DataSource = dtDocumentos;
                        rdbtCausa.DataTextField = "Descripcion";
                        rdbtCausa.DataValueField = "IdTipoDocumento";
                        rdbtCausa.DataBind();
                    }

                }
                else if (tipo.Equals("C"))
                {
                    rdbtDocs3.DataSource = dtDocumentos;
                    rdbtDocs3.DataTextField = "Descripcion";
                    rdbtDocs3.DataValueField = "IdTipoDocumento";
                    rdbtDocs3.DataBind();
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

    //Obtener documentos requisito 1
    private List<clsDocumentosAcceso> ObtenerDocumentos1(string IdTramite)
    {
        List<clsDocumentosAcceso> lstDocumentos = new List<clsDocumentosAcceso>();
        foreach (ListItem fila in rdbtDocs1.Items)
        {
            if (fila.Selected)
            {
                clsDocumentosAcceso objDocumento = new clsDocumentosAcceso();
                objDocumento.IdTramite = IdTramite;
                objDocumento.Matricula = this.txtMatricula.Text;
                objDocumento.IdRequisito = REQ_INDISPENSABLES;
                objDocumento.IdCausa = CAUSA_NINGUNA;
                objDocumento.IdTipoDocumento = Convert.ToInt32(fila.Value);
                lstDocumentos.Add(objDocumento);
            }
        }
        return lstDocumentos;
    }

    //Obtener documentos requisito 2
    private List<clsDocumentosAcceso> ObtenerDocumentos2(string IdTramite)
    {
        List<clsDocumentosAcceso> lstDocumentos = new List<clsDocumentosAcceso>();
        foreach (ListItem fila in rdbtDocs2.Items)
        {
            if (fila.Selected)
            {
                clsDocumentosAcceso objDocumento = new clsDocumentosAcceso();
                objDocumento.IdTramite = IdTramite;
                objDocumento.Matricula = this.txtMatricula.Text;
                objDocumento.IdRequisito = REQ_SECTOR;
                objDocumento.IdCausa = CAUSA_NINGUNA;
                objDocumento.IdTipoDocumento = Convert.ToInt32(fila.Value);
                lstDocumentos.Add(objDocumento);
            }
        }
        return lstDocumentos;
    }

    //Obtener documentos requisito 3
    private List<clsDocumentosAcceso> ObtenerDocumentos3(string IdTramite)
    {
        List<clsDocumentosAcceso> lstDocumentos = new List<clsDocumentosAcceso>();
        foreach (ListItem fila in rdbtDocs3.Items)
        {
            if (fila.Selected)
            {
                clsDocumentosAcceso objDocumento = new clsDocumentosAcceso();
                objDocumento.IdTramite = IdTramite;
                objDocumento.Matricula = this.txtMatricula.Text;
                objDocumento.IdRequisito = REQ_MODALIDAD;
                objDocumento.IdCausa = Convert.ToInt32(rdbtCausa.SelectedValue);
                objDocumento.IdTipoDocumento = Convert.ToInt32(fila.Value);
                lstDocumentos.Add(objDocumento);
            }
        }
        return lstDocumentos;
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

    //validar documentos
    private bool ValidarDocs()
    {
        int iCantidad = 0;
        if (rdbtDocs1 != null)
        {
            foreach (ListItem fila in rdbtDocs1.Items)
            {
                if (fila.Selected)
                {
                    iCantidad++;
                }
            }
            if (iCantidad == rdbtDocs1.Items.Count)
            {
                Master.MensajeOk("La operacion se realizo con exito");
                return true;
            }
            else
            {
                Master.MensajeError("Error en la operación", "Debe elegir todos los requisitos indispensables.");
            }
        }
        return false;
    }

    //validar documentos
    private bool ValidarDocsCausa()
    {
        int iCantidad = 0;
        if (rdbtCausa != null)
        {
            if (rdbtCausa.SelectedValue == null || String.IsNullOrEmpty(rdbtCausa.SelectedValue))
            {
                Master.MensajeError("Error en la operación", "La causa es requerida.");
            }
            if (rdbtDocs3 != null)
            {
                foreach (ListItem fila in rdbtDocs3.Items)
                {
                    if (fila.Selected)
                    {
                        iCantidad++;
                    }
                }
                if (iCantidad == rdbtDocs3.Items.Count)
                {
                    Master.MensajeOk("La operacion se realizo con exito");
                    return true;
                }
                else
                {
                    Master.MensajeError("Error en la operación", "Debe elegir todos los requisitos por modalidad.");
                }
            }
        }
        return false;
    }

    #endregion

    #region botones

    //Siguiente
    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        if (ValidarDocs())
        {
            rdbtDocs1.Enabled = false;
            rdbtDocs2.Enabled = false;
            btnSiguiente.Enabled = false;
            TabDocReq.HeaderText = "Causas";
            TabDocReq.Visible = true;
            TabContainer1.ActiveTabIndex = 1;
        }
    }

    protected void btnSiguienteCausa_Click(object sender, EventArgs e)
    {
        if (ValidarDocsCausa())
        {
            rdbtCausa.Enabled = false;
            rdbtDocs3.Enabled = false;
            btnSiguienteCausa.Enabled = false;
            btnRenunciaInicial.Visible = true;
        }
    }

    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmAccesoDirecto.aspx?Tipo=RN");
    }

    //Guardar renuncia inicial
    protected void btnRenunciaInicial_Click(object sender, EventArgs e)
    {
        List<clsDocumentosAcceso> lstDocumentos;
        clsDocumentosAcceso objdoc;
        string Error = "Error al realizar la operación";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        string lIdTramite = hddIdTramite.Value;
        //DOCUMENTOS
        lstDocumentos = ObtenerDocumentos1(lIdTramite);
        foreach (clsDocumentosAcceso item in lstDocumentos)
        {
            objdoc = item;
            objdoc.iIdConexion = iIdConexion;
            objdoc.cOperacion = cOperacion;
            if (!objdoc.Registrar())
            {
                Master.MensajeError(Error, objdoc.sMensajeError);
            }
        }
        lstDocumentos = ObtenerDocumentos2(lIdTramite);
        foreach (clsDocumentosAcceso item in lstDocumentos)
        {
            objdoc = item;
            objdoc.iIdConexion = iIdConexion;
            objdoc.cOperacion = cOperacion;
            if (!objdoc.Registrar())
            {
                Master.MensajeError(Error, objdoc.sMensajeError);
            }
        }
        lstDocumentos = ObtenerDocumentos3(lIdTramite);
        foreach (clsDocumentosAcceso item in lstDocumentos)
        {
            objdoc = item;
            objdoc.iIdConexion = iIdConexion;
            objdoc.cOperacion = cOperacion;
            if (!objdoc.Registrar())
            {
                Master.MensajeError(Error, objdoc.sMensajeError);
            }
        }
        lblConfirmacion.Text = "Se registró correctamente la Renuncia al Sistema de Reparto.";
        this.btnRenunciaInicial.Enabled = false;
        this.btnReporteRenuncia.Enabled = true;
        this.btnReporteRenuncia.Visible = true;

        this.btnReporteRenuncia.OnClientClick = "window.open('wfrmReportForm03ACC.aspx?tramite=" + this.hddIdTramite.Value + "&matricula=" + this.txtMatricula.Text + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
        this.btnCancelar.Text = "Salir";
    }

    protected void btnReporteRenuncia_Click(object sender, EventArgs e)
    {
        string tramite = this.hddIdTramite.Value;
        string matricula = this.txtMatricula.Text;
        //Response.Redirect("wfrmReportForm03ACC.aspx?tramite=" + tramite + "&matricula=" + matricula);
    }

    #endregion

    #region causa
    protected void rdbtCausa_SelectedIndexChanged(object sender, EventArgs e)
    {
        int valor = Convert.ToInt32(this.rdbtCausa.SelectedValue);
        rdbtDocs3.DataSource = null;
        rdbtDocs3.DataBind();
        CargarDocumentos(valor, "C");
    }
    #endregion
}