
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;
using wcfWorkFlowN.Logica;
public partial class InicioTramite_CompletarDatosReporte : System.Web.UI.Page
{
    #region constantes

    private const string PRE_RENUNCIA = "0";
    private const string RENUNCIA = "1";
    private const string MENU = "Menu";
    private const string WORKFLOW = "Workflow";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringIdTramite;
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
            lblTituloSistema.Text = "MODULO REPORTES VERIFICACIÓN DE DATOS";
            lblSubTitulo.Text = "OBSERVACIONES";
            queryStringIdTramite = Request.QueryString["iIdTramite"];

            if (queryStringIdTramite != "")
            {
                lblTipo.Text = "Nro. Trámite:" + queryStringIdTramite;
                hddIdTramite.Value = queryStringIdTramite;
                hddIdGrupoBeneficio.Value = "3";
                dtTramite = buscarTramite(queryStringIdTramite, hddIdGrupoBeneficio.Value, "Modificacion");
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
                CargarDatos(NUPString, Matricula, Nombre, SegundoNombre, Paterno, Materno, Casada, Nacimiento, CUA, CI, Complemento, Tabla, IdTramite);
                CargarCombo();
                imgVolver.Visible = true;
            }
        }
    }

    #endregion

    #region funciones

    //Buscar Tramites
    protected DataTable buscarTramite(string nroTramite, string grupoBeneficio, string estadoTramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string iIdTramite = "0";
        int iGrupoBeneficio = 0;
        string cOperacion = "Q";
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

        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, iGrupoBeneficio, "", "", "", "", "", "", "", estadoTramite, ref sMensajeError);

        return dtListaPersonas;
    }

    //Cargar Datos
    private void CargarDatos(string NUPString, string Matricula, string Nombre, string SegundoNombre, string Paterno, string Materno, string Casada, string Nacimiento, string CUA, string CI, string Complemento, string Tabla, string IdTramite)
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
       
    //Cargar combos tipos
    private void CargarCombo()
    {
        //Tipos
        DataTable dtTipoReporte = GetTipoReporte();
        if (dtTipoReporte != null && dtTipoReporte.Rows.Count > 0)
        {
            ddlTipoReporte.DataSource = dtTipoReporte;
            ddlTipoReporte.DataTextField = "Descripcion";
            ddlTipoReporte.DataValueField = "IdDetalleClasificador";
            ddlTipoReporte.DataBind();
            ddlTipoReporte.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione...", "0"));
            ddlTipoReporte.SelectedValue = "0";
        }
    }

    //Obtener datos tipos
    public DataTable GetTipoReporte()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtTipoReporte = new DataTable();
        dtTipoReporte = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 21, ref sMensajeError);
        return dtTipoReporte;
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

    #endregion

    #region botones
        
    //Guardar renuncia inicial
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        long iIdTramite = Convert.ToInt32(hddIdTramite.Value);
        clsVerificacionDatos objTramite;
        if (ValidarObservaciones())
        {
           
            //Iniciar Tramite
            objTramite = new clsVerificacionDatos();
            objTramite.iIdConexion=(int)Session["IdConexion"];
            objTramite.cOperacion="I";
            objTramite.IdTramite = iIdTramite;
            objTramite.IdGrupoBeneficio = 3;
            objTramite.IdTipoInconsistencia = Convert.ToInt16(this.ddlTipoReporte.SelectedValue);
            objTramite.Observacion= this.txtDescripcion.Text;
        
            if (objTramite.Registrar())
            {
                lblConfirmacion.Text = "Se registró correctamente los datos del reporte.";
                this.btnGuardar.Enabled = false;
                this.btnReporte.Visible = true;
                this.imgVolver.Text = "Salir";                
            }
            else
            {
                lblConfirmacion.Text = objTramite.sMensajeError;
            }
        }
    }

   
    //Boton de reporte
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        string sTipoReporte = null;
        int iTipoReporte = Convert.ToInt16(this.ddlTipoReporte.SelectedValue);
        switch (iTipoReporte)
        {
            case 31571: sTipoReporte = "RENUNCIA INICIO MANUAL"; break;
            case 31570: sTipoReporte = "OBSERVADOS"; break;
            case 31569: sTipoReporte = "460"; break;
            case 31568: sTipoReporte = "266"; break;
            case 31567: sTipoReporte = "JURIDICO"; break;
        }        
        Session["TipoReporte"] = sTipoReporte;
        Session["IdTramite"] = hddIdTramite.Value;
        Session["TipoIdReporte"] = Convert.ToString(iTipoReporte);
        //Response.Redirect("wfrmReportTramite.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../InicioTramite/wfrmReportTramite.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmReportAdicional.aspx");       
    }

    #endregion    
    
    protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsTramite tramite=new clsTramite();
        string mensaje="";
        txtDescripcion.Text = "";
        DataTable textos= tramite.ObtenerClasificador((int)Session["IdConexion"],"Q",29,ref mensaje);
        if (textos!=null){
            foreach (DataRow row in textos.Rows)
            {
                if (row["Codigo"].ToString().Equals(ddlTipoReporte.SelectedValue))
                {
                    txtDescripcion.Text = row["Observacion"].ToString();
                    break;
                }
            }
        }        
        
    }
}