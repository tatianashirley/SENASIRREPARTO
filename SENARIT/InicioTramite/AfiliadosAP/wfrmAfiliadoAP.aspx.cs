
using System;
using System.Data;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_AfiliadoAP : System.Web.UI.Page
{
    #region constantes

    private const string MOD_REGISTRO = "REG";
    private const string MOD_MODIFICACION = "MOD";

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringTipo;
        string queryStringNUA = null;

        if (!Page.IsPostBack)
        {
            lblSubTitulo.Text = "Datos Asegurado";
            queryStringTipo = Request.QueryString["Tipo"].Replace(' ', '+');
            hddTipo.Value = queryStringTipo;
            if (MOD_REGISTRO.Equals(queryStringTipo))
            {
                lblTituloSistema.Text = "MODULO REGISTRO AFILIADO";
            }
            else if (MOD_MODIFICACION.Equals(queryStringTipo))
            {
                queryStringNUA = Request.QueryString["NUA"].Replace(' ', '+');
                lblTituloSistema.Text = "MODULO MODIFICACION AFILIADO";
            }

            if (queryStringTipo != "")
            {
                //cargar datos en pantalla
                CargarTipoDocumento();
                CargarEntidadAseguradora();
                CargarDatos(queryStringNUA, queryStringTipo);
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
    private void CargarDatos(string NUA, string Tipo)
    {
        if (MOD_MODIFICACION.Equals(Tipo))
        {
            DataTable dtListaPersonas = buscarAfiliados(NUA);
            DataRow row = dtListaPersonas.Rows[0];
            clsFormatoFecha f = new clsFormatoFecha();
            this.txtPrimerApellido.Text = Convert.ToString(row["PRIMER_APELLIDO"]);
            this.txtSegundoApellido.Text = Convert.ToString(row["SEGUNDO_APELLIDO"]);
            this.txtApellidoCasada.Text = Convert.ToString(row["APELLIDO_CONYUGUE"]);
            this.txtPrimerNombre.Text = Convert.ToString(row["PRIMER_NOMBRE"]);
            this.txtSegundoNombre.Text = Convert.ToString(row["SEGUNDO_NOMBRE"]);
            this.txtNumeroDocumento.Text = Convert.ToString(row["NUM_IDENTIFICACION"]);
            this.txtFechaNacimiento.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FEC_NACIMIENTO"])));
            this.txtCUA.Text = NUA;
            this.txtCUA.Enabled = false;
            this.ddlTipoDocumento.SelectedValue = Convert.ToString(row["TIP_IDENTIFICACION"]);
            this.ddlAFP.SelectedValue = Convert.ToString(row["COD_AFP"]);
        }
    }

    //Buscar Tramites
    protected DataTable buscarAfiliados(string NUA)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsAfiliadoAp objAfiliado = new clsAfiliadoAp();
        objAfiliado.iIdConexion = iIdConexion;
        objAfiliado.cOperacion = cOperacion;
        objAfiliado.NUA = NUA;
        if (objAfiliado.Buscar())
        {
            if (objAfiliado.DSetTmp != null && objAfiliado.DSetTmp.Tables.Count > 0)
            {
                dtListaPersonas = objAfiliado.DSetTmp.Tables[0];
            }
        }

        return dtListaPersonas;
    }

    //Combo tipo documento
    private void CargarTipoDocumento()
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";

        clsTramite ObjTramite = new clsTramite();
        DataTable dtTipoDocumento = new DataTable();
        dtTipoDocumento = ObjTramite.ObtenerClasificador(iIdConexion, cOperacion, 92, ref sMensajeError);
        if (dtTipoDocumento != null && dtTipoDocumento.Rows.Count > 0)
        {
            ddlTipoDocumento.DataSource = dtTipoDocumento;
            ddlTipoDocumento.DataTextField = "Descripcion";
            ddlTipoDocumento.DataValueField = "Codigo";
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
            ddlAFP.DataValueField = "Codigo";
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
        this.txtFechaNacimiento.Enabled = false;
        this.ddlAFP.Enabled = false;
        this.txtCUA.Enabled = false;
    }

    //HABILITAR DATOS PERSONALES.
    private void HabilitarDatosPersonales()
    {
        this.txtPrimerNombre.Enabled = true;
        this.txtSegundoNombre.Enabled = true;
        this.txtPrimerApellido.Enabled = true;
        this.txtSegundoApellido.Enabled = true;
        this.txtApellidoCasada.Enabled = true;
        this.ddlTipoDocumento.Enabled = true;
        this.txtNumeroDocumento.Enabled = true;
        this.txtFechaNacimiento.Enabled = true;
        this.txtCUA.Enabled = true;
    }

    //Valida datos de entrada
    private bool ValidaDatos()
    {
        clsFormatoFecha ObjFormatoFecha;
        string sFechanacimiento;
        string sError = "Error al realizar la operación."; ;
        string sDetalleError;
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
        if (this.txtDescripcion.Text == null || this.txtDescripcion.Text == "")
        {
            sDetalleError = "El Motivo es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        return true;
    }

    //GUARDAR TRÁMITE
    private string GuardarTramite()
    {
        clsAfiliadoAp objPersona;
        string res = "not";
        string Error = "Error al realizar la operación";
        string sMensajeError = "";
        string DetalleError = "";
        //Datos afiliado
        objPersona = ObtenerDatosPersona();
        objPersona.iIdConexion = (int)Session["IdConexion"];

        if (MOD_REGISTRO.Equals(hddTipo.Value))
        {
            objPersona.cOperacion = "I";
            if (objPersona.Registrar())
            {
                res = "0";
            }
            else
            {
                DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            objPersona.cOperacion = "U";
            if (objPersona.Actualizar())
            {
                res = "0";
            }
            else
            {
                DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
        }
        return res;
    }

    //Obtener datos persona
    private clsAfiliadoAp ObtenerDatosPersona()
    {
        clsAfiliadoAp objAfiliado = new clsAfiliadoAp();
        clsFormatoFecha formatos = new clsFormatoFecha();
        objAfiliado.TipoIdentificacion = this.ddlTipoDocumento.SelectedValue;
        objAfiliado.CodAFP = ddlAFP.SelectedValue.ToString();
        objAfiliado.NUA = this.txtCUA.Text;
        objAfiliado.NumeroIdentificacion = this.txtNumeroDocumento.Text;
        objAfiliado.PrimerNombre = this.txtPrimerNombre.Text;
        objAfiliado.SegundoNombre = this.txtSegundoNombre.Text;
        objAfiliado.PrimerApellido = this.txtPrimerApellido.Text;
        objAfiliado.SegundoApellido = this.txtSegundoApellido.Text;
        objAfiliado.ApellidoConyuge = this.txtApellidoCasada.Text;
        objAfiliado.Motivo = this.txtDescripcion.Text;
        objAfiliado.FechaNacimiento = this.txtFechaNacimiento.Text;
        return objAfiliado;
    }

    #endregion

    #region botones


    //Cancelar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBuscarAfiliadoAP.aspx");
    }

    //Guardar Tramite
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        try
        {
            string IdTramite = "";
            if (ValidaDatos())
            {
                IdTramite = GuardarTramite();
                this.lblCompletarInformacion.Visible = true;
                if (IdTramite == "0")
                {
                    HiddenIdtramite.Value = IdTramite.ToString();
                    this.lblCompletarInformacion.Text = "Se ha guardado correctamente el afiliado.";
                    this.btnIniciarTramite.Visible = false;
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
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }
    }

    #endregion
}