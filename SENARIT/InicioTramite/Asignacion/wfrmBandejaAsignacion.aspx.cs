
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Logica;
using wcfInicioTramite.Tramite.Logica;
using wcfSeguridad.Logica;

public partial class Asignacion_Principal : System.Web.UI.Page
{
    #region contantes

    private const int ACCESO_DIRECTO = 31580;
    private const int TRAMITE_NUEVO = 31596;

    #endregion

    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "MODULO ASIGNACIÓN TRÁMITE";
            lblSubTitulo.Text = "Registro CC";
            if ((int)Session["RolUsuario"] == 92)
            {
                CargarUsuarios();
                CargarUsuariosAsignacion();
                deshabilitarAutocomplete();
                TabAsignacion.Visible = true;
                TabAsignacion.HeaderText = "Asignación Trámites Registro CC";
                TabPanelCancelacion.Visible = true;
                TabPanelCancelacion.HeaderText = "Cancelar Asignación Trámites Registro CC";
                TabPanelRecepcion.Visible = false;
                TabPanelRecepcion.HeaderText = "";
            } else if ((int)Session["RolUsuario"] == 93)
            {
                CargarBandeja();
                TabAsignacion.Visible = false;
                TabAsignacion.HeaderText = "";
                TabPanelCancelacion.Visible = false;
                TabPanelCancelacion.HeaderText = "";
                TabPanelRecepcion.Visible = true;
                TabPanelRecepcion.HeaderText = "Recepción Trámites Registro CC";
            }
        }
    }

    #endregion

    #region funciones

    //Deshabilita los autocompletar
    private void deshabilitarAutocomplete()
    {
        txtTramite.Attributes.Add("autocomplete", "off");
        txtObservacion.Attributes.Add("autocomplete", "off");
    }

    private void CargarBandeja()
    {
        int IdUsuario = obtenerUsuario();
        clsAsignacion objAsignacion = new clsAsignacion();
        objAsignacion.iIdConexion = (int)Session["IdConexion"];
        objAsignacion.cOperacion = "Q";
        objAsignacion.IdUsuarioDestino = IdUsuario;
        objAsignacion.TipoConsulta = "Recepcion";
        if (objAsignacion.Obtener())
        {
            gvRecepcion.DataSource = objAsignacion.DSetTmp.Tables[0];
            gvRecepcion.DataBind();
            if (gvRecepcion.Rows.Count > 0)
            {
                gvRecepcion.Visible = true;
            }
        }
    }

    private int obtenerUsuario()
    {
        int IdUsuario = 0;
        clsSeguridad objSeguridad = new clsSeguridad();
        DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion((int)Session["IdConexion"]);
        if (dtUsuarioDatos.Rows.Count > 0)
        {
            string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
            IdUsuario = Int32.Parse(s10);
        }
        return IdUsuario;
    }

    //Combo usuarios
    private void CargarUsuarios()
    {
        clsAsignacion objAsignacion = new clsAsignacion();
        objAsignacion.iIdConexion = (int)Session["IdConexion"];
        objAsignacion.cOperacion = "Q";
        objAsignacion.TipoConsulta = "Usuario";
        if (objAsignacion.Obtener())
        {
            ddlUsuarioDestino.DataSource = objAsignacion.DSetTmp.Tables[0];
            ddlUsuarioDestino.DataTextField = "CuentaUsuario";
            ddlUsuarioDestino.DataValueField = "IdUsuario";
            ddlUsuarioDestino.DataBind();
            ddlUsuarioDestino.Items.Insert(0, new ListItem("--Elegir--", "0"));
        }
        else
        {
            //Error
            string DetalleError = objAsignacion.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Combo usuarios
    private void CargarUsuariosAsignacion()
    {
        clsAsignacion objAsignacion = new clsAsignacion();
        objAsignacion.iIdConexion = (int)Session["IdConexion"];
        objAsignacion.cOperacion = "Q";
        objAsignacion.TipoConsulta = "Usuario";
        if (objAsignacion.Obtener())
        {
            ddlUsuarioAsignacion.DataSource = objAsignacion.DSetTmp.Tables[0];
            ddlUsuarioAsignacion.DataTextField = "CuentaUsuario";
            ddlUsuarioAsignacion.DataValueField = "IdUsuario";
            ddlUsuarioAsignacion.DataBind();
            ddlUsuarioAsignacion.Items.Insert(0, new ListItem("--Elegir--", "0"));
        }
        else
        {
            //Error
            string DetalleError = objAsignacion.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Valida datos de entrada
    private bool ValidaDatos()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (ddlAreaDestino.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Tipo Clasificador es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlUsuarioDestino.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Usuario Destino es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (gvTramites == null || gvTramites.Rows.Count <= 0)
        {
            sDetalleError = "Los trámites para asignar son requeridos.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }

        return true;
    }

    //adicionar tramite manual
    private void AgregarTramites(string sTramite)
    {
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        dt2 = new DataTable();
        dt2.Columns.Add("IdTipoClasificador");
        dt2.Columns.Add("TipoClasificador");
        dt2.Columns.Add("IdUsuario");
        dt2.Columns.Add("Usuario");
        dt2.Columns.Add("IdTramite");
        dt2.Columns.Add("TipoTramite");
        dt2.Columns.Add("FechaInicioTramite");
        dt2.Columns.Add("NumeroTramiteCrenta");
        dt2.Columns.Add("Sector");
        dt2.Columns.Add("Nombre");
        dt2.Columns.Add("Matricula");
        dt2.Columns.Add("Observaciones");
        filadt2 = dt2.NewRow();
        if (ACCESO_DIRECTO != Convert.ToInt32(ddlAreaDestino.SelectedValue) && TRAMITE_NUEVO != Convert.ToInt32(ddlAreaDestino.SelectedValue))
        {
            //Consultar 
            clsAsignacion objAsignacion = new clsAsignacion();
            string Codigo = ddlAreaDestino.SelectedValue;
            objAsignacion.iIdConexion = (int)Session["IdConexion"];
            objAsignacion.cOperacion = "Q";
            objAsignacion.TipoConsulta = "Tramite";
            objAsignacion.IdTramite = Convert.ToInt64(sTramite.Trim());
            if (objAsignacion.Obtener())
            {
                if (objAsignacion.DSetTmp != null)
                {
                    foreach (DataRow row in objAsignacion.DSetTmp.Tables[0].Rows)
                    {
                        if (!String.IsNullOrEmpty(row["IdTramite"].ToString().Trim()))
                        {
                            filadt2["IdTipoClasificador"] = ddlAreaDestino.SelectedValue;
                            filadt2["TipoClasificador"] = ddlAreaDestino.SelectedItem;
                            filadt2["IdUsuario"] = ddlUsuarioDestino.SelectedValue;
                            filadt2["Usuario"] = ddlUsuarioDestino.SelectedItem;
                            filadt2["IdTramite"] = row["IdTramite"].ToString();
                            filadt2["TipoTramite"] = row["TipoTramite"].ToString();
                            filadt2["FechaInicioTramite"] = row["FechaInicioTramite"].ToString();
                            filadt2["NumeroTramiteCrenta"] = row["NumeroTramiteCrenta"].ToString();
                            filadt2["Sector"] = row["Sector"].ToString();
                            filadt2["Nombre"] = row["Nombre"].ToString();
                            filadt2["Matricula"] = row["Matricula"].ToString();
                            filadt2["Observaciones"] = txtObservacion.Text;
                        }
                    }
                }
            }
        }
        else
        {
            filadt2["IdTipoClasificador"] = ddlAreaDestino.SelectedValue;
            filadt2["TipoClasificador"] = ddlAreaDestino.SelectedItem;
            filadt2["IdUsuario"] = ddlUsuarioDestino.SelectedValue;
            filadt2["Usuario"] = ddlUsuarioDestino.SelectedItem;
            filadt2["Observaciones"] = txtObservacion.Text;
        }
        dt2.Rows.Add(filadt2);
        // salvar datos de la grid
        if (gvTramites != null && gvTramites.Rows.Count > 0)
        {
            foreach (DataKey fila in gvTramites.DataKeys)
            {
                filadt2 = dt2.NewRow();
                filadt2["IdTipoClasificador"] = Convert.ToString(fila.Values["IdTipoClasificador"]);
                filadt2["TipoClasificador"] = Convert.ToString(fila.Values["TipoClasificador"]);
                filadt2["IdUsuario"] = Convert.ToString(fila.Values["IdUsuario"]);
                filadt2["Usuario"] = Convert.ToString(fila.Values["Usuario"]);
                filadt2["IdTramite"] = Convert.ToString(fila.Values["IdTramite"]);
                filadt2["TipoTramite"] = Convert.ToString(fila.Values["TipoTramite"]);
                filadt2["FechaInicioTramite"] = Convert.ToString(fila.Values["FechaInicioTramite"]);
                filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                filadt2["NumeroTramiteCrenta"] = Convert.ToString(fila.Values["NumeroTramiteCrenta"]);
                filadt2["Nombre"] = Convert.ToString(fila.Values["Nombre"]);
                filadt2["Matricula"] = Convert.ToString(fila.Values["Matricula"]);
                filadt2["Observaciones"] = Convert.ToString(fila.Values["Observaciones"]);
                dt2.Rows.Add(filadt2);
            }
        }
        gvTramites.DataSource = dt2;
        gvTramites.DataBind();
    }

    //Validar grilla manual
    private bool ValidaGrillaTramite()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (ddlAreaDestino.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Tipo Clasificador es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ddlUsuarioDestino.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Usuario Destino es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (ACCESO_DIRECTO == Convert.ToInt32(ddlAreaDestino.SelectedValue) || TRAMITE_NUEVO == Convert.ToInt32(ddlAreaDestino.SelectedValue))
        {
            if (txtObservacion.Text.Trim() == null || txtObservacion.Text.Trim() == "")
            {
                sDetalleError = "La Observación es requerida.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        else
        {
            if (txtTramite.Text.Trim() == null || txtTramite.Text.Trim() == "")
            {
                sDetalleError = "El Trámite es requerido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
            else
            {
                //Consultar 
                clsAsignacion objAsignacion = new clsAsignacion();
                string Codigo = ddlAreaDestino.SelectedValue;
                objAsignacion.iIdConexion = (int)Session["IdConexion"];
                objAsignacion.cOperacion = "Q";
                objAsignacion.TipoConsulta = "Tramite";
                objAsignacion.IdTramite = Convert.ToInt64(txtTramite.Text.Trim());
                if (objAsignacion.Obtener())
                {
                    if (objAsignacion.DSetTmp != null)
                    {
                        foreach (DataRow row in objAsignacion.DSetTmp.Tables[0].Rows)
                        {
                            if (!String.IsNullOrEmpty(row["IdTramite"].ToString().Trim()))
                            {
                                return true;
                            }
                        }
                    }
                }
                sDetalleError = "El Trámite no es válido.";
                Master.MensajeError(sError, sDetalleError);
                return false;
            }
        }
        return true;
    }

    //Validar grilla manual
    private bool ValidaGrillaTramite2()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (ddlUsuarioAsignacion.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Usuario Destino es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        if (txtGrupoAsignacion.Text.Trim() == null || txtGrupoAsignacion.Text.Trim() == "")
        {
            sDetalleError = "El Código Asignación es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    private void BuscarTramites()
    {
        clsAsignacion objAsignacion = new clsAsignacion();
        string Codigo = ddlAreaDestino.SelectedValue;
        objAsignacion.iIdConexion = (int)Session["IdConexion"];
        objAsignacion.cOperacion = "Q";
        objAsignacion.TipoConsulta = "Tramites";
        if (objAsignacion.Obtener())
        {
            gvSeleccionarTramite.DataSource = objAsignacion.DSetTmp.Tables[0];
            gvSeleccionarTramite.DataBind();
        }
        else
        {
            //Error
            string DetalleError = objAsignacion.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Obtener datos Tramite
    private List<clsAsignacion> ObtenerDatosTramite()
    {
        List<clsAsignacion> lstAsignaciones = new List<clsAsignacion>();
        if (gvTramites != null && gvTramites.Rows.Count > 0)
        {
            int IdUsuario = 0;
            int IdArea = 0;
            clsSeguridad objSeguridad = new clsSeguridad();
            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion((int)Session["IdConexion"]);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
                string s11 = dtUsuarioDatos.Rows[0]["CuentaUsuario"].ToString();  //TECENVIOS2
                string s12 = dtUsuarioDatos.Rows[0]["IdRol"].ToString();    //107
                string s13 = dtUsuarioDatos.Rows[0]["Rol"].ToString();    //Técnico de Procesamiento CC y Envío APS
                string s14 = dtUsuarioDatos.Rows[0]["IdOficina"].ToString();    //2
                string s15 = dtUsuarioDatos.Rows[0]["Oficina"].ToString();  //LA PAZ
                string s16 = dtUsuarioDatos.Rows[0]["IdArea"].ToString();  //240
                string s17 = dtUsuarioDatos.Rows[0]["Area"].ToString(); //Envíos APS
                string s18 = dtUsuarioDatos.Rows[0]["FecHoraString"].ToString();    //29/05/2015  9:15AM
                string s19 = dtUsuarioDatos.Rows[0]["IdTipoUsuario"].ToString();    //677

                IdUsuario = Int32.Parse(s10);
                IdArea = Int32.Parse(s16);
            }
            foreach (DataKey fila in gvTramites.DataKeys)
            {
                clsAsignacion objAsigna = new clsAsignacion();
                if (ACCESO_DIRECTO != Convert.ToInt32(Convert.ToInt32(fila.Values["IdTipoClasificador"])) && TRAMITE_NUEVO != Convert.ToInt32(Convert.ToInt32(fila.Values["IdTipoClasificador"])))
                {
                    objAsigna.IdTramite = Convert.ToInt64(fila.Values["IdTramite"]);
                }
                objAsigna.IdGrupoBeneficio = 3;
                objAsigna.IdUsuarioOrigen = IdUsuario;
                objAsigna.IdUsuarioDestino = Convert.ToInt32(fila.Values["IdUsuario"]);
                objAsigna.IdAreaOrigen = IdArea;
                objAsigna.IdAreaDestino = Convert.ToInt32(fila.Values["IdTipoClasificador"]);
                objAsigna.Observacion = Convert.ToString(fila.Values["Observaciones"]);
                lstAsignaciones.Add(objAsigna);
            }
        }
        return lstAsignaciones;
    }

    //Obtener datos Tramite
    private List<clsAsignacion> ObtenerDatosTramite2()
    {
        List<clsAsignacion> lstAsignaciones = new List<clsAsignacion>();
        clsAsignacion objAsignacion = new clsAsignacion();
        objAsignacion.iIdConexion = (int)Session["IdConexion"];
        objAsignacion.cOperacion = "Q";
        objAsignacion.IdUsuarioDestino = Convert.ToInt32(ddlUsuarioAsignacion.SelectedValue);
        objAsignacion.IdGrupoTramite = Convert.ToInt64(txtGrupoAsignacion.Text);
        objAsignacion.TipoConsulta = "Cancela";
        if (objAsignacion.Obtener())
        {
            if (objAsignacion.DSetTmp.Tables[0].Rows.Count > 0)
            {
                if (gvAsignaciones != null && gvAsignaciones.Rows.Count > 0)
                {
                    foreach (DataRow row in objAsignacion.DSetTmp.Tables[0].Rows)
                    {
                        int contador = 0;
                        if (!String.IsNullOrEmpty(row["IdAsignacion"].ToString().Trim()))
                        {
                            foreach (DataKey fila in gvAsignaciones.DataKeys)
                            {
                                if (row["IdAsignacion"].ToString().Trim().Equals(Convert.ToString(fila.Values["IdAsignacion"])))
                                {
                                    contador++;
                                }
                            }
                        }
                        if (contador == 0)
                        {
                            clsAsignacion objAsigna = new clsAsignacion();
                            objAsigna.IdTramite = Convert.ToInt64(row["IdAsignacion"].ToString().Trim());
                            objAsigna.IdGrupoBeneficio = 3;
                            lstAsignaciones.Add(objAsigna);
                        }
                    }
                }
                else
                {
                    foreach (DataRow row in objAsignacion.DSetTmp.Tables[0].Rows)
                    {
                        if (!String.IsNullOrEmpty(row["IdAsignacion"].ToString().Trim()))
                        {
                            clsAsignacion objAsigna = new clsAsignacion();
                            objAsigna.IdTramite = Convert.ToInt64(row["IdAsignacion"].ToString().Trim()); ;
                            objAsigna.IdGrupoBeneficio = 3;
                            lstAsignaciones.Add(objAsigna);
                        }
                    }
                }
            }
        }
        else
        {
            //Error
            string DetalleError = objAsignacion.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        return lstAsignaciones;
    }

    #endregion

    #region botones

    //Boton PM Siguiente
    protected void btnSiguientePM_Click(object sender, EventArgs e)
    {
        this.btnBuscarTramite.Enabled = false;
        this.ddlAreaDestino.Enabled = false;
        this.ddlUsuarioDestino.Enabled = false;
        this.txtTramite.Enabled = false;
        this.txtObservacion.Enabled = false;
        this.gvTramites.Enabled = false;
        this.btnAgregarManual.Enabled = false;
        this.btnSiguientePM.Enabled = false;
        this.btnIniciarTramite.Visible = true;
        string msg = "La operacion se realizo con exito";
        Master.MensajeOk(msg);
    }

    //Limpiar Tramite
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBandejaAsignacion.aspx");
    }

    //VALIDA Y LLAMA A FUNCION QUE GUARDA EL TRAMITE
    protected void btnIniciarTramite_Click(object sender, EventArgs e)
    {
        List<clsAsignacion> lstTramites;
        clsAsignacion objAsignacion;
        long IdGrupoTramite = 0;
        try
        {
            if (ValidaDatos())
            {
                //Obtener asignaciones
                lstTramites = ObtenerDatosTramite();
                foreach (clsAsignacion item in lstTramites)
                {
                    objAsignacion = item;
                    objAsignacion.iIdConexion = (int)Session["IdConexion"];
                    objAsignacion.cOperacion = "I";
                    if (IdGrupoTramite != 0)
                    {
                        objAsignacion.IdGrupoTramite = IdGrupoTramite;
                    }
                    if (!objAsignacion.Registrar())
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = objAsignacion.sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                        return;
                    }
                    else
                    {
                        if (IdGrupoTramite == 0)
                        {
                            IdGrupoTramite = objAsignacion.IdGrupoTramite;
                        }
                    }
                }
                Session["IdTramite"] = IdGrupoTramite;
                this.lblCompletarInformacion.Visible = true;
                this.lblCompletarInformacion.Text = "Se ha registrado correctamente.";
                this.btnIniciarTramite.Enabled = false;
                this.btnReporteAsignacion.Visible = true;
                TabAsignacion.Enabled = false;
                TabPanelCancelacion.Enabled = false;
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }
    }

    protected void btnAgregarManual_Click(object sender, EventArgs e)
    {
        if (ValidaGrillaTramite())
        {
            AgregarTramites(txtTramite.Text);
            txtTramite.Text = "";
            txtObservacion.Text = "";
            //ddlAreaDestino.SelectedValue = "0";
            //ddlUsuarioDestino.SelectedValue = "0";
            btnSiguientePM.Visible = true;
            Master.MensajeCancel();
        }
    }

    protected void btnBuscarTramite_Click(object sender, ImageClickEventArgs e)
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        if (ddlAreaDestino.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Tipo Clasificador es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return;
        }
        if (ddlUsuarioDestino.SelectedValue.ToString() == "0")
        {
            sDetalleError = "El Usuario Destino es requerido.";
            Master.MensajeError(sError, sDetalleError);
            return;
        }
        this.txtTramite.Text = "";
        this.txtObservacion.Text = "";
        BuscarTramites();
        gvSeleccionarTramite.Visible = true;
        mpeDatosTramite.Show();
    }

    protected void btnReporteAsignacion_Click(object sender, EventArgs e)
    {
        //Session["IdTramite"] = HiddenIdtramite.Value;
        Session["TipoReporte"] = "ASIGNACION";
        //Response.Redirect("../wfrmReportTramite.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../wfrmReportTramite.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }

    protected void btnBuscarGrupo_Click(object sender, EventArgs e)
    {
        if (ValidaGrillaTramite2())
        {
            clsAsignacion objAsignacion = new clsAsignacion();
            objAsignacion.iIdConexion = (int)Session["IdConexion"];
            objAsignacion.cOperacion = "Q";
            objAsignacion.IdUsuarioDestino = Convert.ToInt32(ddlUsuarioAsignacion.SelectedValue);
            objAsignacion.IdGrupoTramite = Convert.ToInt64(txtGrupoAsignacion.Text);
            objAsignacion.TipoConsulta = "Cancela";
            if (objAsignacion.Obtener())
            {
                gvAsignaciones.DataSource = objAsignacion.DSetTmp.Tables[0];
                gvAsignaciones.DataBind();
                if (gvAsignaciones.Rows.Count > 0)
                {
                    gvAsignaciones.Visible = true;
                }
            }
            else
            {
                //Error
                string DetalleError = objAsignacion.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }

    protected void btnSiguiente2_Click(object sender, EventArgs e)
    {
        this.btnBuscarGrupo.Enabled = false;
        this.ddlUsuarioAsignacion.Enabled = false;
        this.txtGrupoAsignacion.Enabled = false;
        this.gvAsignaciones.Enabled = false;
        this.btnSiguiente2.Enabled = false;
        this.btnIniciarTramite2.Visible = true;
        string msg = "La operacion se realizo con exito";
        Master.MensajeOk(msg);
    }

    protected void btnIniciarTramite2_Click(object sender, EventArgs e)
    {
        List<clsAsignacion> lstTramites;
        clsAsignacion objAsignacion;
        try
        {
            if (ValidaGrillaTramite2() && hddElimina.Value == "OK")
            {
                //Obtener asignaciones
                lstTramites = ObtenerDatosTramite2();
                foreach (clsAsignacion item in lstTramites)
                {
                    objAsignacion = item;
                    objAsignacion.iIdConexion = (int)Session["IdConexion"];
                    objAsignacion.cOperacion = "U";
                    objAsignacion.IdUsuarioDestino = Convert.ToInt32(ddlUsuarioAsignacion.SelectedValue);
                    objAsignacion.IdGrupoTramite = Convert.ToInt64(txtGrupoAsignacion.Text);
                    if (!objAsignacion.Actualizar())
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = objAsignacion.sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                        return;
                    }
                }
                Session["IdTramite"] = Convert.ToInt64(txtGrupoAsignacion.Text);
                this.lblCompletarInformacion.Visible = true;
                this.lblCompletarInformacion.Text = "Se ha registrado correctamente.";
                TabAsignacion.Enabled = false;
                TabPanelCancelacion.Enabled = false;
                this.btnIniciarTramite2.Enabled = false;
                this.btnReporteAsignacion.Visible = true;
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex.Message);
            Master.MensajeError(Error, DetalleError);
        }
    }

    protected void btnRecepcionar_Click(object sender, EventArgs e)
    {
        clsAsignacion objAsigna;
        List<clsAsignacion> lstAsignacion = new List<clsAsignacion>();
        int IdUsuario = obtenerUsuario();
        int contador = 0;
        foreach (GridViewRow item in gvRecepcion.Rows)
        {
            if ((item.Cells[0].FindControl("chkAsignacion") as CheckBox).Checked)
            {
                objAsigna = new clsAsignacion();
                objAsigna.IdTramite = Convert.ToInt64(item.Cells[1].Text);//IDAsignacion 
                lstAsignacion.Add(objAsigna);
                contador++;
            }
        }
        if (contador > 0)
        {
            foreach (clsAsignacion objAsignacion in lstAsignacion)
            {
                objAsignacion.iIdConexion = (int)Session["IdConexion"];
                objAsignacion.cOperacion = "R";
                objAsignacion.IdUsuarioDestino = IdUsuario;
                if (!objAsignacion.Actualizar())
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = objAsignacion.sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                    return;
                }
            }
            gvRecepcion.Enabled = false;
            this.btnRecepcionar.Enabled = false;
            this.lblCompletarInformacion.Visible = true;
            this.lblCompletarInformacion.Text = "Se ha registrado correctamente.";
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = "Debe elegir un trámite para recepcionar.";
            Master.MensajeError(Error, DetalleError);
        }
    }

    #endregion

    #region destino

    protected void ddlAreaDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Codigo = ddlAreaDestino.SelectedValue;
        txtTramite.Text = "";
        if (ACCESO_DIRECTO == Convert.ToInt32(Codigo) || TRAMITE_NUEVO == Convert.ToInt32(Codigo))
        {
            txtTramite.Enabled = false;
            btnBuscarTramite.Enabled = false;
        }
        else
        {
            txtTramite.Enabled = true;
            btnBuscarTramite.Enabled = true;
        }
    }

    protected void ddlUsuarioDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsTramite objTramite = new clsTramite();
        DataTable dt = new DataTable();
        int session = (int)Session["IdConexion"];
        string Error = "Error al realizar la operación";
        string DetalleError = null;
        dt = objTramite.ObtenerClasificador(session, "Q", 59, ref DetalleError);
        if (dt != null && dt.Rows.Count > 0)
        {
            ddlAreaDestino.DataSource = dt;
            ddlAreaDestino.DataTextField = "Descripcion";
            ddlAreaDestino.DataValueField = "IdDetalleClasificador";
            ddlAreaDestino.DataBind();
            ddlAreaDestino.Items.Insert(0, new ListItem("--Elegir--", "0"));
            ddlUsuarioDestino.Enabled = false;

        }
        else
        {
            //Error            
            Master.MensajeError(Error, DetalleError);
        }
    }

    #endregion

    #region grilla tramites

    protected void gvSeleccionarTramite_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvSeleccionarTramite = (GridView)sender;
        gvSeleccionarTramite.PageIndex = e.NewSelectedIndex;
        gvSeleccionarTramite.DataBind();
        mpeDatosTramite.Show();
    }

    protected void gvSeleccionarTramite_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSeleccionarTramite.PageIndex = e.NewPageIndex;
        BuscarTramites();
        mpeDatosTramite.Show();
    }

    protected void gvTramites_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        if (e.CommandName == "cmdEliminarTramite")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            dt2 = new DataTable();
            dt2.Columns.Add("IdTipoClasificador");
            dt2.Columns.Add("TipoClasificador");
            dt2.Columns.Add("IdUsuario");
            dt2.Columns.Add("Usuario");
            dt2.Columns.Add("IdTramite");
            dt2.Columns.Add("TipoTramite");
            dt2.Columns.Add("FechaInicioTramite");
            dt2.Columns.Add("NumeroTramiteCrenta");
            dt2.Columns.Add("Sector");
            dt2.Columns.Add("Nombre");
            dt2.Columns.Add("Matricula");
            dt2.Columns.Add("Observaciones");

            // salvar datos de la grid
            if (gvTramites != null && gvTramites.Rows.Count > 0)
            {
                foreach (DataKey fila in gvTramites.DataKeys)
                {
                    filadt2 = dt2.NewRow();
                    filadt2["IdTipoClasificador"] = Convert.ToString(fila.Values["IdTipoClasificador"]);
                    filadt2["TipoClasificador"] = Convert.ToString(fila.Values["TipoClasificador"]);
                    filadt2["IdUsuario"] = Convert.ToString(fila.Values["IdUsuario"]);
                    filadt2["Usuario"] = Convert.ToString(fila.Values["Usuario"]);
                    filadt2["IdTramite"] = Convert.ToString(fila.Values["IdTramite"]);
                    filadt2["TipoTramite"] = Convert.ToString(fila.Values["TipoTramite"]);
                    filadt2["FechaInicioTramite"] = Convert.ToString(fila.Values["FechaInicioTramite"]);
                    filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                    filadt2["NumeroTramiteCrenta"] = Convert.ToString(fila.Values["NumeroTramiteCrenta"]);
                    filadt2["Nombre"] = Convert.ToString(fila.Values["Nombre"]);
                    filadt2["Matricula"] = Convert.ToString(fila.Values["Matricula"]);
                    filadt2["Observaciones"] = Convert.ToString(fila.Values["Observaciones"]);
                    dt2.Rows.Add(filadt2);
                }
            }
            dt2.Rows.RemoveAt(Index);
            gvTramites.DataSource = dt2;
            gvTramites.DataBind();
            if (dt2.Rows.Count <= 0)
            {
                btnSiguientePM.Visible = false;
            }
        }
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in gvSeleccionarTramite.Rows)
        {
            if ((item.Cells[0].FindControl("chkTramite") as CheckBox).Checked)
            {
                DataTable dt2 = new DataTable();
                DataRow filadt2;
                dt2 = new DataTable();
                dt2.Columns.Add("IdTipoClasificador");
                dt2.Columns.Add("TipoClasificador");
                dt2.Columns.Add("IdUsuario");
                dt2.Columns.Add("Usuario");
                dt2.Columns.Add("IdTramite");
                dt2.Columns.Add("TipoTramite");
                dt2.Columns.Add("FechaInicioTramite");
                dt2.Columns.Add("NumeroTramiteCrenta");
                dt2.Columns.Add("Sector");
                dt2.Columns.Add("Nombre");
                dt2.Columns.Add("Matricula");
                dt2.Columns.Add("Observaciones");
                filadt2 = dt2.NewRow();
                filadt2["IdTipoClasificador"] = ddlAreaDestino.SelectedValue;
                filadt2["TipoClasificador"] = ddlAreaDestino.SelectedItem;
                filadt2["IdUsuario"] = ddlUsuarioDestino.SelectedValue;
                filadt2["Usuario"] = ddlUsuarioDestino.SelectedItem;

                filadt2["IdTramite"] = item.Cells[1].Text;
                filadt2["TipoTramite"] = item.Cells[2].Text;
                filadt2["FechaInicioTramite"] = item.Cells[3].Text;
                filadt2["NumeroTramiteCrenta"] = item.Cells[4].Text;
                filadt2["Sector"] = item.Cells[7].Text;
                filadt2["Nombre"] = item.Cells[5].Text;
                filadt2["Matricula"] = item.Cells[6].Text;
                filadt2["Observaciones"] = txtObservaciones.Text;
                dt2.Rows.Add(filadt2);
                // salvar datos de la grid
                if (gvTramites != null && gvTramites.Rows.Count > 0)
                {
                    foreach (DataKey fila in gvTramites.DataKeys)
                    {
                        filadt2 = dt2.NewRow();
                        filadt2["IdTipoClasificador"] = Convert.ToString(fila.Values["IdTipoClasificador"]);
                        filadt2["TipoClasificador"] = Convert.ToString(fila.Values["TipoClasificador"]);
                        filadt2["IdUsuario"] = Convert.ToString(fila.Values["IdUsuario"]);
                        filadt2["Usuario"] = Convert.ToString(fila.Values["Usuario"]);
                        filadt2["IdTramite"] = Convert.ToString(fila.Values["IdTramite"]);
                        filadt2["TipoTramite"] = Convert.ToString(fila.Values["TipoTramite"]);
                        filadt2["FechaInicioTramite"] = Convert.ToString(fila.Values["FechaInicioTramite"]);
                        filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                        filadt2["NumeroTramiteCrenta"] = Convert.ToString(fila.Values["NumeroTramiteCrenta"]);
                        filadt2["Nombre"] = Convert.ToString(fila.Values["Nombre"]);
                        filadt2["Matricula"] = Convert.ToString(fila.Values["Matricula"]);
                        filadt2["Observaciones"] = Convert.ToString(fila.Values["Observaciones"]);
                        dt2.Rows.Add(filadt2);
                    }
                }
                gvTramites.DataSource = dt2;
                gvTramites.DataBind();
                btnSiguientePM.Visible = true;
            }
        }
        mpeDatosTramite.Hide();

    }

    #endregion

    #region grilla asignacion

    protected void gvAsignaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index;
        DataTable dt2 = new DataTable();
        DataRow filadt2;
        if (e.CommandName == "cmdEliminarTramite")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            dt2 = new DataTable();
            dt2.Columns.Add("IdAsignacion");
            dt2.Columns.Add("IdGrupoAsignacion");
            dt2.Columns.Add("FechaAsignacion");
            dt2.Columns.Add("IdTramite");
            dt2.Columns.Add("TipoTramite");
            dt2.Columns.Add("FechaInicioTramite");
            dt2.Columns.Add("NumeroTramiteCrenta");
            dt2.Columns.Add("Sector");
            dt2.Columns.Add("Nombre");
            dt2.Columns.Add("Matricula");
            // salvar datos de la grid
            if (gvAsignaciones != null && gvAsignaciones.Rows.Count > 0)
            {
                foreach (DataKey fila in gvAsignaciones.DataKeys)
                {
                    filadt2 = dt2.NewRow();
                    filadt2["IdAsignacion"] = Convert.ToString(fila.Values["IdAsignacion"]);
                    filadt2["IdGrupoAsignacion"] = Convert.ToString(fila.Values["IdGrupoAsignacion"]);
                    filadt2["FechaAsignacion"] = Convert.ToString(fila.Values["FechaAsignacion"]);
                    filadt2["IdTramite"] = Convert.ToString(fila.Values["IdTramite"]);
                    filadt2["TipoTramite"] = Convert.ToString(fila.Values["TipoTramite"]);
                    filadt2["FechaInicioTramite"] = Convert.ToString(fila.Values["FechaInicioTramite"]);
                    filadt2["Sector"] = Convert.ToString(fila.Values["Sector"]);
                    filadt2["NumeroTramiteCrenta"] = Convert.ToString(fila.Values["NumeroTramiteCrenta"]);
                    filadt2["Nombre"] = Convert.ToString(fila.Values["Nombre"]);
                    filadt2["Matricula"] = Convert.ToString(fila.Values["Matricula"]);
                    dt2.Rows.Add(filadt2);
                }
            }
            dt2.Rows.RemoveAt(Index);
            gvAsignaciones.DataSource = dt2;
            gvAsignaciones.DataBind();
            hddElimina.Value = "OK";
            btnSiguiente2.Visible = true;
        }
    }

    #endregion

}