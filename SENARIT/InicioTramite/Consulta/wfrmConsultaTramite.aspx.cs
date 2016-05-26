
using System;
using System.Data;
using System.Web.UI;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;

public partial class Consulta_ConsultaTramite : System.Web.UI.Page
{
    #region constantes
    
    private const string CONTROL_CALIDAD = "ControlCalidad";
    
    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringTramite;
        string queryStringOrigen;
        string queryStringGrupo;
        string queryStringTipo;
        string IdTramite = "";
        clsFuncionesGenerales encriptar;
        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "CONSULTA DE TRÁMITES";
            lblSubTitulo.Text = "Consulta Trámite";

            queryStringOrigen = Request.QueryString["Origen"];
            if (!String.IsNullOrEmpty(queryStringOrigen))
            {
                queryStringTramite = Request.QueryString["iIdTramite"];
                queryStringGrupo = Request.QueryString["iIdGrupoBeneficio"];
                IdTramite = queryStringTramite;
            }
            else if (!String.IsNullOrEmpty(Request.QueryString["TT"]))
            {
                queryStringTramite = Request.QueryString["TT"].Replace(' ', '+');
                queryStringTipo = Request.QueryString["Tipo"].Replace(' ', '+');
                encriptar = new clsFuncionesGenerales();
                if (queryStringTramite != "")
                {
                    IdTramite = encriptar.DecryptKey(queryStringTramite);
                }
                if (queryStringTipo!="")
                {
                    tipoConsulta.Value=encriptar.DecryptKey(queryStringTipo);
                }
            }
            lblTipo.Text = "Nro. Trámite:" + IdTramite;
            hfTramite.Value = IdTramite;
            //cargar datos en pantalla
            CargarDatos(IdTramite);
            if (!this.txtTipoInicioTramite.Text.Equals("TITULAR"))
            {
                TabPanel2.Visible = true;
                TabPanel2.HeaderText = "Datos Inicio Trámite";
                CargarInicioTramite(IdTramite);
            }
            else
            {
                TabPanel2.Visible = false;
                TabPanel2.HeaderText = "";
            }
            CargarDocumentosTramite(IdTramite);
            CargarDatosEmpresa(IdTramite);
            if (CONTROL_CALIDAD.Equals(tipoConsulta.Value))
            {
                CargarControlCalidad();
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

    //Cargar datos tramite
    private void CargarDatos(string IdTramite)
    {
        DataTable dtDatosTramite = null;
        clsTramite objTramite = new clsTramite();
        clsFormatoFecha f = new clsFormatoFecha();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt64(IdTramite);
        objTramite.Tipo = "DatosTramite";
        dtDatosTramite = objTramite.ConsultaTramite();
        if (dtDatosTramite != null && dtDatosTramite.Rows.Count > 0)
        {
            DataRow row = dtDatosTramite.Rows[0];
            this.txtIdTramite.Text = IdTramite;
            this.txtEstadoTramite.Text = Convert.ToString(row["EstadoTramite"]);
            this.txtTramiteCrenta.Text = Convert.ToString(row["NumeroTramiteCrenta"]);
            this.txtPrimerApellido.Text = Convert.ToString(row["PrimerApellido"]);
            this.txtSegundoApellido.Text = Convert.ToString(row["SegundoApellido"]);
            this.txtApellidoCasada.Text = Convert.ToString(row["ApellidoCasada"]);
            this.txtPrimerNombre.Text = Convert.ToString(row["PrimerNombre"]);
            this.txtSegundoNombre.Text = Convert.ToString(row["SegundoNombre"]);

            this.txtTipoDocumento.Text = Convert.ToString(row["TipoDocumento"]);
            this.txtNumeroDocumento.Text = Convert.ToString(row["NumeroDocumento"]);
            this.txtComplemento.Text = Convert.ToString(row["ComplementoSEGIP"]);
            this.txtExpedicion.Text = Convert.ToString(row["Expedido"]);
            this.txtAFP.Text = Convert.ToString(row["AFP"]); ;
            this.txtCUA.Text = Convert.ToString(row["CUA"]); ;
            this.txtMatricula.Text = Convert.ToString(row["Matricula"]); ;


            // Datos Personales
            this.txtFechaNacimiento.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaNacimiento"])));
            this.txtFechaFallecimient.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaFallecimiento"])));
            this.txtSexo.Text = Convert.ToString(row["Sexo"]);
            this.txtEstadoCivil.Text = Convert.ToString(row["EstadoCivil"]);

            // Datos Localidad 
            this.txtLocalidad.Text = Convert.ToString(row["NombreLocalidad"]);
            this.txtCelular.Text = Convert.ToString(row["Celular"]);
            this.txtCelularReferencia.Text = Convert.ToString(row["CelularReferencia"]);
            this.txtTelefono.Text = Convert.ToString(row["Telefono"]);
            this.txtEmail.Text = Convert.ToString(row["CorreoElectronico"]);
            this.txtDireccion.Text = Convert.ToString(row["Direccion"]);

            // Datos Tramite
            this.txtClaseRenta.Text = Convert.ToString(row["ClaseRenta"]);
            this.txtTipoTramite.Text = Convert.ToString(row["TipoTramite"]);
            this.txtSector.Text = Convert.ToString(row["Descripcion"]);
            this.txtInicioTramite.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaInicioTramite"])));
            this.txtFuncionario.Text = Convert.ToString(row["Funcionario"]);
            this.txtOrigenTramite.Text = Convert.ToString(row["OrigenTramite"]);
            this.txtOficinaRegistro.Text = Convert.ToString(row["OficinaRegistro"]);
            this.txtOficinaNotificacion.Text = Convert.ToString(row["OficinaNotificacion"]);
            this.txtTipoInicioTramite.Text = Convert.ToString(row["TipoInicioTramite"]);

        }
    }

    //Cargar datos inicio  tramite
    private void CargarInicioTramite(string IdTramite)
    {
        DataTable dtDatosTramite = null;
        clsTramite objTramite = new clsTramite();
        clsFormatoFecha f = new clsFormatoFecha();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt64(IdTramite);
        objTramite.Tipo = "DatosIniciaTramite";
        dtDatosTramite = objTramite.ConsultaTramite();
        if (dtDatosTramite != null && dtDatosTramite.Rows.Count > 0)
        {
            DataRow row = dtDatosTramite.Rows[0];
            this.txtIdTramite.Text = IdTramite;
            this.txtPrimerApellidoInicia.Text = Convert.ToString(row["PrimerApellido"]);
            this.txtSegundoApellidoInicia.Text = Convert.ToString(row["SegundoApellido"]);
            this.txtApellidoCasadaInicia.Text = Convert.ToString(row["ApellidoCasada"]);
            this.txtPrimerNombreInicia.Text = Convert.ToString(row["PrimerNombre"]);
            this.txtSegundoNombreInicia.Text = Convert.ToString(row["SegundoNombre"]);
            this.txtTipoDocumentoInicia.Text = Convert.ToString(row["TipoDocumento"]);
            this.txtNumeroDocumentoInicia.Text = Convert.ToString(row["NumeroDocumento"]);
            this.txtComplementoInicia.Text = Convert.ToString(row["ComplementoSEGIP"]);
            this.txtExpedicionInicia.Text = Convert.ToString(row["Expedido"]);
            this.txtSexoInicia.Text = Convert.ToString(row["Sexo"]);
            this.txtEstadoCivilInicia.Text = Convert.ToString(row["EstadoCivil"]);
            this.txtFechaNacimientoInicia.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaNacimiento"])));


            this.txtDireccionInicia.Text = Convert.ToString(row["Direccion"]);
            this.txtLocalidadInicia.Text = Convert.ToString(row["NombreLocalidad"]);
            this.txtTelefonoInicia.Text = Convert.ToString(row["Telefono"]);
            this.txtCelularInicia.Text = Convert.ToString(row["Celular"]);
            this.txtTelRefInicia.Text = Convert.ToString(row["CelularReferencia"]);
            this.txtEmailInicia.Text = Convert.ToString(row["CorreoElectronico"]);

            this.txtPoderInicia.Text = Convert.ToString(row["NumeroPoderNotarial"]);
            this.txtAdmInicia.Text = Convert.ToString(row["Administracion"]);
            this.txtPoderDesdeInicia.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["PeriodoInicio"])));
            this.txtPoderHastaInicia.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["PeriodoFinal"])));

        }
    }

    //Cargar datos documentos 
    private void CargarDocumentosTramite(string IdTramite)
    {
        DataTable dtDatosTramite = null;
        clsTramite objTramite = new clsTramite();
        clsFormatoFecha f = new clsFormatoFecha();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt64(IdTramite);
        objTramite.Tipo = "DatosDocsTramite";
        dtDatosTramite = objTramite.ConsultaTramite();
        if (dtDatosTramite != null)
        {
            gvDocumentos.DataSource = dtDatosTramite;//asignar valor a grilla
            gvDocumentos.DataBind();//asignar valor a grilla
        }
    }

    //Cargar datos empresa
    private void CargarDatosEmpresa(string IdTramite)
    {
        DataTable dtDatosTramite = null;
        clsTramite objTramite = new clsTramite();
        clsFormatoFecha f = new clsFormatoFecha();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "Q";
        objTramite.IdTramite = Convert.ToInt64(IdTramite);
        objTramite.Tipo = "DatosEmpresa";
        dtDatosTramite = objTramite.ConsultaTramite();
        if (dtDatosTramite != null && dtDatosTramite.Rows.Count > 0)
        {
            if (txtTipoTramite.Text.Equals("MANUAL"))
            {
                gvEmpresaManual.Visible = true;
                gvEmpresaManual.DataSource = dtDatosTramite;//asignar valor a grilla
                gvEmpresaManual.DataBind();//asignar valor a grilla
            }
            else
            {
                gvEmpresaAutomatica.Visible = true;
                gvEmpresaAutomatica.DataSource = dtDatosTramite;//asignar valor a grilla
                gvEmpresaAutomatica.DataBind();//asignar valor a grilla
            }
        }
    }

    private void CargarControlCalidad() {
        //Control calidad
        clsControlCalidad objControl = new clsControlCalidad();
        objControl.iIdConexion = (int)Session["IdConexion"];
        objControl.cOperacion = "V";
        objControl.IdTramite = Convert.ToInt64(hfTramite.Value);
        objControl.IdGrupoBeneficio = 3;
        btnControlCalidad.Visible = true;
        if (objControl.Obtener())
        {
            if (objControl.IdEstado == 1)
            {
                btnControlCalidad.Enabled = false;
            }
            else
            {
                btnControlCalidad.Enabled = true;
            }
        }
        else
        {
            btnControlCalidad.Enabled = false;
        }
    }

    #endregion

    #region botones

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/InicioTramite/Distribucion/wfrmBuscarTramite.aspx");
    }

    protected void btnControlCalidad_Click(object sender, EventArgs e)
    {
        mpControlCalidad.Show();
        pnlJustificar.Visible = true;
        rdbtCheck.Checked = false;
        txtObservacioni.Text = "";
        txtTramitei.Text = hfTramite.Value;
    }

    //Boton check control calidad
    protected void btnSiJustificar_Click(object sender, EventArgs e)
    {
        if (!rdbtCheck.Checked)
        {
            Master.MensajeError("Error al realizar la operacion", "El Check es requerido.");
        }
        else if (String.IsNullOrEmpty(txtObservacioni.Text))
        {
            Master.MensajeError("Error al realizar la operacion", "Las Observaciones son requeridas.");
        }
        else
        {
            clsControlCalidad objControl = new clsControlCalidad();
            objControl.iIdConexion = (int)Session["IdConexion"];
            objControl.cOperacion = "I";
            objControl.IdTramite = Convert.ToInt32(txtTramitei.Text);
            objControl.IdGrupoBeneficio = 3;
            objControl.IdEstado = (rdbtCheck.Checked ? 1 : 0);
            objControl.Observacion = txtObservacioni.Text;
            if (!objControl.Registrar() && !String.IsNullOrEmpty(objControl.sMensajeError))
            {
                Master.MensajeError("Error al realizar la operacion", objControl.sMensajeError);
            }
            mpControlCalidad.Hide();
            pnlJustificar.Visible = false;
        }
        btnControlCalidad.Enabled = false;
    }
    
    #endregion       
}