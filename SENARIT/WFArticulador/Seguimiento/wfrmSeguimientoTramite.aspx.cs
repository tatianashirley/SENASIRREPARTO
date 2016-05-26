
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfSeguridad.Logica;
using wcfWFArticulador.Logica;


public partial class SeguimientoTramite_SeguimientoTramite : System.Web.UI.Page
{

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        string queryStringTramite;
        string IdTramite = "";
        clsFuncionesGenerales encriptar;
        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "SEGUIMIENTO DE TRÁMITES";
            lblSubTitulo.Text = "Seguimiento Trámite";

            queryStringTramite = Request.QueryString["TT"].Replace(' ', '+');
            encriptar = new clsFuncionesGenerales();
            if (queryStringTramite != "")
            {
                //desencriptar
                IdTramite = encriptar.DecryptKey(queryStringTramite);
                lblTipo.Text = "Nro. Trámite:" + IdTramite;
                hfTramite.Value = IdTramite;
                //cargar datos en pantalla
                CargarDatos(IdTramite);
                CargarSeguimiento(IdTramite);
                CargarSeguimientoCertificacion(IdTramite);
                CargarSeguimientoEnvios(IdTramite);
                CargarSeguimientoSalario(IdTramite);
                CargarSeguimientoReprocesos(IdTramite);
                CargarSeguimientoReprocesos_Certi(IdTramite);
                CargarSeguimientoPagosAlternativos(IdTramite);
                CargarSeguimientoPagosAlternativosPU(IdTramite);
                CargarSeguimientoCertificado(IdTramite);
                CargarSeguimientoSalariosR(IdTramite);
                if ((int)Session["RolUsuario"] == 268)
                {
                    txtDescripcion.Enabled = true;
                    txtDescripcion.ReadOnly = false;
                    Button1.Visible = true;
                }
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
        clsSeguimientoTramite objTramite = new clsSeguimientoTramite();
        clsFormatoFecha f = new clsFormatoFecha();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "R";
        objTramite.IdTramite = IdTramite;
        objTramite.TipoConsulta = "DatosTramite";
        if (objTramite.ObtenerDatosTramite())
        {
            dtDatosTramite = ((objTramite.DSetTmp != null && objTramite.DSetTmp.Tables != null && objTramite.DSetTmp.Tables.Count > 0) ? objTramite.DSetTmp.Tables[0] : null);
            if (dtDatosTramite != null)
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
                this.txtRegional.Text = Convert.ToString(row["Oficina"]);
                this.txtTipoTramite.Text = Convert.ToString(row["TipoTramite"]);
                this.txtAreaActual.Text = Convert.ToString(row["AreaActual"]);
                this.txtFechaIngreso.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaIngreso"])));
                this.txtEstadoExpediente.Text = Convert.ToString(row["EstadoTramiteSeguimiento"]);
                this.txtSector.Text = Convert.ToString(row["Descripcion"]);
                this.txtInicioTramite.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaInicioTramite"])));
                this.txtFuncionario.Text = Convert.ToString(row["Funcionario"]);
                this.txtFechaTentativa.Text = f.Fecha(f.GeneraFechaDMY(Convert.ToString(row["FechaSalidaTentativa"])));
                this.txtDescripcion.Text = Convert.ToString(row["ObsSalidaArea"]);
            }
        }
    }

    //Cargar datos seguimiento tramite
    private void CargarSeguimiento(string IdTramite)
    {
        DataTable dtDatosSeguimiento = null;
        clsSeguimientoTramite objTramite = new clsSeguimientoTramite();
        objTramite.iIdConexion = (int)Session["IdConexion"];
        objTramite.cOperacion = "R";
        objTramite.IdTramite = IdTramite;
        objTramite.TipoConsulta = "SeguimientoTramite";
        if (objTramite.ObtenerDatosTramite())
        {
            dtDatosSeguimiento = ((objTramite.DSetTmp != null && objTramite.DSetTmp.Tables != null && objTramite.DSetTmp.Tables.Count > 0) ? objTramite.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimiento != null)
            {
                gvSeguimiento.DataSource = dtDatosSeguimiento;
                gvSeguimiento.DataBind();
            }
        }
    }

    //Cargar datos seguimiento CERTIFICACION
    private void CargarSeguimientoCertificacion(string IdTramite)
    {
        DataTable dtDatosSeguimientoCERT = null;
        clsSeguimientoTramite objTramiteCert = new clsSeguimientoTramite();
        objTramiteCert.iIdConexion = (int)Session["IdConexion"];
        objTramiteCert.cOperacion = "R";
        objTramiteCert.IdTramite = IdTramite;
        objTramiteCert.TipoConsulta = "Certificacion";// tipo de consulta pr
        if (objTramiteCert.ObtenerDatosTramite())
        {
            dtDatosSeguimientoCERT = ((objTramiteCert.DSetTmp != null && objTramiteCert.DSetTmp.Tables != null && objTramiteCert.DSetTmp.Tables.Count > 0) ? objTramiteCert.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoCERT != null)
            {
                gvCertificacion.DataSource = dtDatosSeguimientoCERT;//asignar valor a grilla
                gvCertificacion.DataBind();//asignar valor a grilla
            }
            if (gvCertificacion.Rows.Count > 0)
            {
                Label17.Visible = true;
            }
        }
    }

    //Cargar datos seguimiento SALARIO COTIZABLE
    private void CargarSeguimientoSalario(string IdTramite)
    {
        DataTable dtDatosSeguimientoSalario = null;
        clsSeguimientoTramite objTramiteSalario = new clsSeguimientoTramite();
        objTramiteSalario.iIdConexion = (int)Session["IdConexion"];
        objTramiteSalario.cOperacion = "R";
        objTramiteSalario.IdTramite = IdTramite;
        objTramiteSalario.TipoConsulta = "Formulario";// tipo de consulta pr
        if (objTramiteSalario.ObtenerDatosTramite())
        {
            dtDatosSeguimientoSalario = ((objTramiteSalario.DSetTmp != null && objTramiteSalario.DSetTmp.Tables != null && objTramiteSalario.DSetTmp.Tables.Count > 0) ? objTramiteSalario.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoSalario != null)
            {
                gvSalario.DataSource = dtDatosSeguimientoSalario;//asignar valor a grilla
                gvSalario.DataBind();//asignar valor a grilla
            }
            if (gvSalario.Rows.Count > 0)
            {
                lblFcAl.Visible = true;
            }
        }
    }

    //Cargar datos seguimiento CERTIFICADO
    private void CargarSeguimientoCertificado(string IdTramite)
    {
        DataTable dtDatosSeguimientoCertificado = null;
        clsSeguimientoTramite objTramiteCertificado = new clsSeguimientoTramite();
        objTramiteCertificado.iIdConexion = (int)Session["IdConexion"];
        objTramiteCertificado.cOperacion = "R";
        objTramiteCertificado.IdTramite = IdTramite;
        objTramiteCertificado.TipoConsulta = "CertificadoCC";// tipo de consulta pr
        if (objTramiteCertificado.ObtenerDatosTramite())
        {
            dtDatosSeguimientoCertificado = ((objTramiteCertificado.DSetTmp != null && objTramiteCertificado.DSetTmp.Tables != null && objTramiteCertificado.DSetTmp.Tables.Count > 0) ? objTramiteCertificado.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoCertificado != null)
            {
                gvCertificado.DataSource = dtDatosSeguimientoCertificado;//asignar valor a grilla
                gvCertificado.DataBind();//asignar valor a grilla
            }
            if (gvCertificado.Rows.Count > 0)
            {
                lblCCC1.Visible = true;
            }

        }
    }

    //Cargar datos seguimiento SALARIOS
    private void CargarSeguimientoSalariosR(string IdTramite)
    {
        DataTable dtDatosSeguimientoSalariosR = null;
        clsSeguimientoTramite objTramiteSalariosR = new clsSeguimientoTramite();
        objTramiteSalariosR.iIdConexion = (int)Session["IdConexion"];
        objTramiteSalariosR.cOperacion = "R";
        objTramiteSalariosR.IdTramite = IdTramite;
        objTramiteSalariosR.TipoConsulta = "Salarios";// tipo de consulta pr
        if (objTramiteSalariosR.ObtenerDatosTramite())
        {
            dtDatosSeguimientoSalariosR = ((objTramiteSalariosR.DSetTmp != null && objTramiteSalariosR.DSetTmp.Tables != null && objTramiteSalariosR.DSetTmp.Tables.Count > 0) ? objTramiteSalariosR.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoSalariosR != null)
            {
                gvSalarioR.DataSource = dtDatosSeguimientoSalariosR;//asignar valor a grilla
                gvSalarioR.DataBind();//asignar valor a grilla
            }
            if (gvSalarioR.Rows.Count > 0)
            {
                lblSalR.Visible = true;
            }
        }
    }

    //Cargar datos seguimiento ENVIOS
    private void CargarSeguimientoEnvios(string IdTramite)
    {
        DataTable dtDatosSeguimientoENVIOS = null;
        clsSeguimientoTramite objTramiteEnvi = new clsSeguimientoTramite();
        objTramiteEnvi.iIdConexion = (int)Session["IdConexion"];
        objTramiteEnvi.cOperacion = "R";
        objTramiteEnvi.IdTramite = IdTramite;
        objTramiteEnvi.TipoConsulta = "EnviosAPS";// tipo de consulta pr
        if (objTramiteEnvi.ObtenerDatosTramite())
        {
            dtDatosSeguimientoENVIOS = ((objTramiteEnvi.DSetTmp != null && objTramiteEnvi.DSetTmp.Tables != null && objTramiteEnvi.DSetTmp.Tables.Count > 0) ? objTramiteEnvi.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoENVIOS != null)
            {
                gvEnvios.DataSource = dtDatosSeguimientoENVIOS;//asignar valor a grilla
                gvEnvios.DataBind();//asignar valor a grilla
            }
        }
    }

    //Cargar datos seguimiento REPROCESOS
    private void CargarSeguimientoReprocesos(string IdTramite)
    {
        DataTable dtDatosSeguimientoREPRO = null;
        clsSeguimientoTramite objTramiteRepro = new clsSeguimientoTramite();
        objTramiteRepro.iIdConexion = (int)Session["IdConexion"];
        objTramiteRepro.cOperacion = "R";
        objTramiteRepro.IdTramite = IdTramite;
        objTramiteRepro.TipoConsulta = "Reprocesos";// tipo de consulta pr
        if (objTramiteRepro.ObtenerDatosTramite())
        {
            dtDatosSeguimientoREPRO = ((objTramiteRepro.DSetTmp != null && objTramiteRepro.DSetTmp.Tables != null && objTramiteRepro.DSetTmp.Tables.Count > 0) ? objTramiteRepro.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoREPRO != null)
            {
                gvReprocesos.DataSource = dtDatosSeguimientoREPRO;//asignar valor a grilla
                gvReprocesos.DataBind();//asignar valor a grilla
            }
            if (gvReprocesos.Rows.Count > 0)
            {
                Label19.Visible = true;
            }
        }
    }
    //Cargar datos seguimiento REPROCESOS
    private void CargarSeguimientoReprocesos_Certi(string IdTramite)
    {
        DataTable dtDatosSeguimientoREPROCERTI = null;
        clsSeguimientoTramite objTramiteReprocerti = new clsSeguimientoTramite();
        objTramiteReprocerti.iIdConexion = (int)Session["IdConexion"];
        objTramiteReprocerti.cOperacion = "R";
        objTramiteReprocerti.IdTramite = IdTramite;
        objTramiteReprocerti.TipoConsulta = "Reprocesos";// tipo de consulta pr
        if (objTramiteReprocerti.ObtenerDatosTramite())
        {
            dtDatosSeguimientoREPROCERTI = ((objTramiteReprocerti.DSetTmp != null && objTramiteReprocerti.DSetTmp.Tables != null && objTramiteReprocerti.DSetTmp.Tables.Count > 0) ? objTramiteReprocerti.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoREPROCERTI != null)
            {
                gvReprocesosCerti.DataSource = dtDatosSeguimientoREPROCERTI;//asignar valor a grilla
                gvReprocesosCerti.DataBind();//asignar valor a grilla
            }
           
        }
    }


    //Cargar datos seguimiento PAGOS
    private void CargarSeguimientoPagosAlternativos(string IdTramite)
    {
        DataTable dtDatosSeguimientoPAGOS = null;
        clsSeguimientoTramite objTramitePagos = new clsSeguimientoTramite();
        objTramitePagos.iIdConexion = (int)Session["IdConexion"];
        objTramitePagos.cOperacion = "R";
        objTramitePagos.IdTramite = IdTramite;
        objTramitePagos.TipoConsulta = "PagosAlternativos";// tipo de consulta pr
        if (objTramitePagos.ObtenerDatosTramite())
        {
            dtDatosSeguimientoPAGOS = ((objTramitePagos.DSetTmp != null && objTramitePagos.DSetTmp.Tables != null && objTramitePagos.DSetTmp.Tables.Count > 0) ? objTramitePagos.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoPAGOS != null)
            {
                gvPagosA.DataSource = dtDatosSeguimientoPAGOS;//asignar valor a grilla
                gvPagosA.DataBind();//asignar valor a grilla
            }
            if (gvPagosA.Rows.Count > 0)
            {
                Label20.Visible = true;
            }
        }
    }
    private void CargarSeguimientoPagosAlternativosPU(string IdTramite)
    {
        DataTable dtDatosSeguimientoPAGOSPU = null;
        clsSeguimientoTramite objTramitePagosPU = new clsSeguimientoTramite();
        objTramitePagosPU.iIdConexion = (int)Session["IdConexion"];
        objTramitePagosPU.cOperacion = "R";
        objTramitePagosPU.IdTramite = IdTramite;
        objTramitePagosPU.TipoConsulta = "PagosAlternativosPU";// tipo de consulta pr
        if (objTramitePagosPU.ObtenerDatosTramite())
        {
            dtDatosSeguimientoPAGOSPU = ((objTramitePagosPU.DSetTmp != null && objTramitePagosPU.DSetTmp.Tables != null && objTramitePagosPU.DSetTmp.Tables.Count > 0) ? objTramitePagosPU.DSetTmp.Tables[0] : null);
            if (dtDatosSeguimientoPAGOSPU != null)
            {
                gvPagosAPU.DataSource = dtDatosSeguimientoPAGOSPU;//asignar valor a grilla
                gvPagosAPU.DataBind();//asignar valor a grilla
            }
            if (gvPagosAPU.Rows.Count > 0)
            {
                Label21.Visible = true;
            }
        }
    }
    #endregion

    #region botones

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBuscarTramite.aspx");
    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        Session["IdTramite"] = hfTramite.Value;
        //Response.Redirect("wfrmReporteTramite.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReporteTramite.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }

    #endregion

    #region grilla seguimiento

    protected void gvSeguimiento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        if (e.CommandName == "cmdTramite")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string strObservado = Convert.ToString(gvSeguimiento.DataKeys[Index].Values["ObsSalidaArea"]);
            txtObsEtapa.Text = strObservado;
            pnlObservado.Visible = true;
            ModalPopupExtender_Observado.Show();

        }
    }
    protected void gvSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnTramite = (ImageButton)e.Row.FindControl("imgTramite");
            ImageButton btnBloqueo = (ImageButton)e.Row.FindControl("imgBloquear");
            string sFechaSalida = Convert.ToString(gvSeguimiento.DataKeys[e.Row.RowIndex].Values["FechaSalida"]);
            string sObservaciones = Convert.ToString(gvSeguimiento.DataKeys[e.Row.RowIndex].Values["ObsSalidaArea"]);
            if (String.IsNullOrEmpty(sFechaSalida))
            {
                e.Row.BackColor = Color.LightCoral;
            }
            if (sObservaciones != null && !String.IsNullOrEmpty(sObservaciones.Trim()))
            {
                btnTramite.Visible = true;
                btnBloqueo.Visible = false;
            }
            else
            {
                btnTramite.Visible = false;
                btnBloqueo.Visible = true;
            }

        }
    }

    #endregion

    protected void gvSalario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdMensual")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvSalario.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvSalario.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);

                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                string iIdTipoCC = "358";
                iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);

                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                if (IdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (IdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);


                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdGlobal")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvSalario.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvSalario.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);

                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                string iIdTipoCC = "359";
                iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);

                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                if (IdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (IdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }


    }

    protected void gvCertificado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdCertificacionSalario")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvCertificado.DataKeys[Index].Values["IdTramite"]);
                int iIdTipoTramite = Convert.ToInt32(gvCertificado.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);


                if (iIdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (iIdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void gvCertificacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdDetalleCertificacion")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvCertificacion.DataKeys[Index].Values["IdTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
                ScriptManager.RegisterStartupScript(this, GetType(), "openDetalleCertificacion", " window.open('../../CertificacionCC/wfrmBusquedaFCCyCS.aspx?IdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void gvSalario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string FlagM = Convert.ToString(gvSalario.DataKeys[e.Row.RowIndex].Values["TipoCC"]);
            if (FlagM == "MENSUAL")
            {
                e.Row.FindControl("imgFMensual").Visible = true;
                e.Row.FindControl("imgFGlobal").Visible = false;
            }
            else
            {
                e.Row.FindControl("imgFMensual").Visible = false;
                e.Row.FindControl("imgFGlobal").Visible = true;
            }
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        clsSeguimiento objTramite = new clsSeguimiento();       
        
        if (txtDescripcion.Text != null && !String.IsNullOrEmpty(txtDescripcion.Text))
        {
            try
            {
                objTramite.iIdConexion = (int)Session["IdConexion"];
                objTramite.cOperacion = "U";
                objTramite.IdTramite = txtIdTramite.Text;
                objTramite.TipoConsulta = "actualizar";
                objTramite.Observaciones = txtDescripcion.Text;
                if (objTramite.ActualizarObservaciones())
                {
                    Master.MensajeOk("Se registró correctamente la observación.");
                }
                else {
                    Master.MensajeError("Error al realizar la operacion",objTramite.sMensajeError);
                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al realizar la operacion", Convert.ToString(ex));
            }
        }
    }
}