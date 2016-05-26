using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wcfWorkFlowN.Logica;
using wcfObservados.Logica;

using WcfServicioClasificador.Logica;

public partial class SeguimientoObservados_wfrmSeguimientoObservados : System.Web.UI.Page
{
    clsSeguimientoObservados Observado = new clsSeguimientoObservados();
    DataTable grillaDatos = new DataTable();
    string mensaje;
    Int64 iIdTramite;
    Int32 iIdGrupoBeneficio;
    int habilitacion;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {   
                if (Request.QueryString["iIdTramite"] != null)
                {
                    iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                    iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                    Tram.Value = Convert.ToString(iIdTramite);
                    gruBen.Value = Convert.ToString(iIdGrupoBeneficio);

                }
                HttpContext.Current.Server.ScriptTimeout = 2400;
                CargarDatosTramite_Persona();
        }
    }

    #region Llenar_Datos
        // LLENA TODOS LOS DATOS DEL TRAMITE Y DE LA PERSONA 
        private void CargarDatosTramite_Persona()
    {
        mensaje = null;
        grillaDatos = Observado.DatosBeneficiario((int)Session["IdConexion"], "Q", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje); //BENEFICIARIO
        if (grillaDatos != null && grillaDatos.Rows.Count > 0)
        {
            foreach (DataRow tp2 in grillaDatos.Rows)
            {
                imgRevision.Enabled = true;
                txtTramite.Text = tp2["IdTramite"].ToString();
                txtTipotramite.Text = tp2["TipoTramite"].ToString();
                txtFechaInicio.Text = tp2["FechaInicioTramite"].ToString();
                txtFono.Text = tp2["Telefono"].ToString();
                txtNroIngresos.Text = tp2["Ingresos"].ToString();
                txtMatricula.Text = tp2["Matricula"].ToString();
                txtApPaterno.Text = tp2["PrimerApellido"].ToString();
                txtApMaterno.Text = tp2["SegundoApellido"].ToString();
                txtPNombre.Text = tp2["PrimerNombre"].ToString();
                txtSNombre.Text = tp2["SegundoNombre"].ToString();
                txtSexo.Text = tp2["Sexo"].ToString();
                txtDireccion.Text = tp2["Direccion"].ToString();
                txtFechaNac.Text = tp2["FechaNacimiento"].ToString();
                txtFechaFall.Text = tp2["FechaFallecimiento"].ToString();
                txtNroDoc.Text = tp2["NumeroDocumento"].ToString();
                txtTipoDoc.Text = tp2["TipoDocumento"].ToString();
                txtEstadocivil.Text = tp2["EstadoCivil"].ToString();
                txtCua.Text = tp2["CUA"].ToString();
                txtAfp.Text = tp2["EntidadGestora"].ToString();
                txtRegional.Text = tp2["Regional"].ToString();
            }
            lblCodigo.Text = txtPNombre.Text + " " + txtSNombre.Text + " " + txtApPaterno.Text + " " + txtApMaterno.Text;
        }
        else
        {
            Master.MensajeError("Error al realizar la operación", mensaje);
            imgRevision.Enabled = false;
        }

    }
        // cargar grilla con datos
        protected void ListarRegistros()
        {
            mensaje = null;
            gvTipo.DataSource = Observado.DatosBeneficiario((int)Session["IdConexion"], "A", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
            gvTipo.DataBind();

        }

        protected void ListarVisitas()
        {
            mensaje = null;
            gvVisitas.DataSource = Observado.DatosBeneficiario((int)Session["IdConexion"], "J", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
            gvVisitas.DataBind();

        }
        // CARGAR TIPO REVISION
        protected void CargarTipoRevision()
        {

            mensaje = null;
            ddlTipoAccion.DataSource = Observado.ListarAcciones((int)Session["IdConexion"],"B",ref mensaje);
            ddlTipoAccion.DataValueField = "IdDetalleClasificador";
            ddlTipoAccion.DataTextField = "Descripcion";
            ddlTipoAccion.DataBind();
            
        }
        // CARGAR GESTIONES
        protected void CargarGestiones()
        {   mensaje=null;

            ddlGestion.DataSource = Observado.Gestiones((int)Session["IdConexion"], "C", ref mensaje);
            ddlGestion.DataValueField = "Gestion";
            ddlGestion.DataTextField = "Gestion";
            ddlGestion.DataBind();
        }
        protected void ddlObservadosVer() 
        {
            mensaje = null;
            ddlObs.DataSource = Observado.ddlObservados((int)Session["IdConexion"], "F", ref mensaje);
            ddlObs.DataValueField = "IdObs";
            ddlObs.DataTextField = "Descripcion";
            ddlObs.DataBind();
        }
        // CARGAR area
        protected void CargarAreas()
        {
            mensaje = null;
            ddlArea.DataSource = Observado.AreasOficina((int)Session["IdConexion"], "E", 2, ref mensaje);
            ddlArea.DataValueField = "IdArea";
            ddlArea.DataTextField = "Descripcion";
            ddlArea.DataBind();
        }
        //LLENAR DATOS DE LA VENTANA
        protected void VerDatos()
        {
            mensaje = null;
            habilitacion = 0;
            foreach (DataRow tp2 in Observado.DatosVer((int)Session["IdConexion"], "H", Convert.ToInt32(lblCodigo1.Text), ref mensaje).Rows)
            {
                ddlTipoAccion.SelectedValue = tp2["IdTipoAccion"].ToString();
                habilitacion = Convert.ToInt32(tp2["IdTipoAccion"]);
                txtHojaRuta.Text = tp2["HojaRuta"].ToString();
                txtFecha.Text = tp2["FechaHojaRuta"].ToString();
                ddlGestion.DataValueField = tp2["Gestion"].ToString();
                txtFojas.Text = tp2["NumeroFojas"].ToString();
                txtNombreInteresado.Text = tp2["NombreInteresado"].ToString();
                txtObservacion.Text = tp2["TextoObservacion"].ToString();
                ddlObs.SelectedValue = tp2["IdTipoObservacion"].ToString();
                if (tp2["IdAreaDestino"].ToString() != null && tp2["IdAreaDestino"].ToString() != "0")
                    ddlArea.SelectedValue = tp2["IdAreaDestino"].ToString();
                else
                    ddlArea.SelectedValue = "20300";
            }
            HabilitaCamposRegistro(habilitacion);
        }
    #endregion

    
    #region Acciones_ButtonImagen
        // accion click de boton de revision
        protected void imgRevision_Click(object sender, ImageClickEventArgs e)  
            {
                pnlDatos.Visible = false; // panel de mostrar datos
                pnlGV.Visible = true;     // panel de mostrar grilla
                pnlRevision.Visible = false; // panel de mostrar datos revision
                pnlFechas.Visible = false;  // panel de mostra fechas para emitir listado de revisiones por fechas
                imgRevision.Enabled = false;
                ListarRegistros();             // carga datos de pnldatos de la cargas datos en grilla de revisiones
                ListarVisitas();             // carga datos de pnldatos de la cargas datos en grilla de visitas
                
             //clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
             //ObjINodo.iIdConexion = Convert.ToInt64(Session["IdConexion"]);
             //ObjINodo.iIdTramite = Convert.ToInt64(Tram.Value);
             //ObjINodo.iIdGrupoBeneficio = Convert.ToInt32(gruBen.Value);
             //ObjINodo.sNemoNodoOrig = "OBSERVADOS";
             //ObjINodo.sEstado = "I";
             //if (ObjINodo.ObtieneActividadActiva())
             //{  

             //    clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
             //    ObjINodoCpto.iIdConexion = Convert.ToInt64(Session["IdConexion"]);
             //    ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
             //    ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
             //    ObjINodoCpto.sIdConcepto = "CLASIF_OBS_OK";
             //    ObjINodoCpto.bValorBoolean = true;
             //    if (ObjINodoCpto.Grabar())
             //    {
             //        string msg = "La operacion se realizó con éxito";
             //        Master.MensajeOk(msg);                 
             //    }
             //    else
             //    {
             //        string Error = "Error al realizar la operación";
             //        string DetalleError = ObjINodoCpto.sMensajeError;
             //        Master.MensajeError(Error, DetalleError);
             //    }

             //}
             //else
             //{
             //    string Error = "Error al realizar la operación";
             //    string DetalleError = ObjINodo.sMensajeError;
             //    Master.MensajeError(Error, DetalleError);
             //}

            }
        // Reporte de Seguimiento de Revisiones del Trámite
        protected void imgReporte_Click(object sender, ImageClickEventArgs e)
        {
            Session["Matricula"] = txtMatricula.Text;
            Session["Paterno"] = txtApPaterno.Text ;
            Session["Materno"]= txtApMaterno.Text;
            Session["PNombre"]= txtPNombre.Text;
            Session["SNombre"]=txtSNombre.Text;
            Session["FNacimiento"] = txtFechaNac.Text;
            Session["CI"] = txtNroDoc.Text;
            Session["afp"] = txtAfp.Text;
            Session["Nua"] = txtCua.Text;
            Session["TipoTramite"] = txtTipotramite.Text;
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteSeguimiento", " window.open('../Reportes/wfrmReporteSeguimientoTramite.aspx?iIdTramite=" + Tram.Value+"&iIdGrupoBeneficio=" + gruBen.Value +"', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }

        // accion click de boton de cerrar
        protected void imgCerrar_Click(object sender, ImageClickEventArgs e)
        {
            pnlDatos.Visible = true;
            pnlGV.Enabled = true;
            pnlGV.Visible = false;
            pnlFechas.Visible = false; 
            pnlRevision.Visible = false;
            imgRevision.Enabled = true;
        }
    #endregion

    #region AccionBotonesCombos
        //BUSCAR DATOS DE CORRESPONDENCIA
        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            mensaje = null;
            if (txtHojaRuta.Text != "")
            {
                lblObser.Text = "";
                txtDescripcionDoc.Text = "";
                foreach (DataRow tp2 in Observado.HojaRutas((int)Session["IdConexion"], "G", Convert.ToInt32(txtHojaRuta.Text), Convert.ToInt32(ddlGestion.SelectedValue), ref mensaje).Rows)
                {
                    txtDescripcionDoc.Text = tp2["Referencia"].ToString();
                    txtFecha.Text = tp2["Fecha_Recep"].ToString();
                }
                if (txtDescripcionDoc.Text != "")
                {
                    lblObser.Text = "Datos HR";
                    lblCodigo1.Text = "Si";
                }
                else
                {
                    lblObser.Text = "No existe HR";
                    lblCodigo1.Text = "No";
                }
            }
            else
            {
                lblObser.Text = "Falta N° hoja de ruta";
            }

        }
        // ACCIONES DEL BOTON ACCIONAR ADICIONAR, ELIMINAR O MODIFICAR
        protected void btnAccionar_Click(object sender, EventArgs e)
            {
            int etapa = Convert.ToInt32(Session["Etapaactual"]);
            String sMensajeError = null;
            string Error;
            string DetalleError;
            string Msg;
            string cOperacion;
            int iIdConexion = (int)Session["IdConexion"];

            // CUANDO BOTON ES ADICIONAR
            if (btnAccionar.Text == "Adicionar")
            {
                cOperacion = "I";

                if (txtNombreInteresado.Text == "" || txtObservacion.Text == "")
                {
                    lblObservaciones.Text = "El texto Introducido de algun dato... No es Valido!!!";
                }
                else
                {
                    int valor;
                    valor = Convert.ToInt32(ddlTipoAccion.SelectedValue);
                    switch (valor)
                    {
                        case 663:
                            //IdConexion,cOperacion,IdTramite,IdGrupoBeneficio,Accion,etapa,Interesado,hojaRuta,FechaHR,AreaDestino,NroFicha,Observacion,RegistroActivo,IdTipoObservacion,CodigoFicha
                            if (Observado.AdicionarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), etapa, txtNombreInteresado.Text, 0, "01/01/1900", 0, 0, txtObservacion.Text.ToUpper(), 1, Convert.ToInt32(ddlObs.SelectedValue),txtFicha.Text, ref sMensajeError))
                            {
                                Msg = "Se adicionó la observación revisión  de forma Satisfactoria";
                                Master.MensajeOk(Msg);
                            }
                            else
                            {
                                Error = "Error de Operación";
                                DetalleError = sMensajeError;
                                Master.MensajeError(Error, DetalleError);
                            }
                           //  lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
                            break;
                        case 665:
                        case 664:
                            if (lblCodigo1.Text == "Si")
                            {
                                bool registro;
                                if (valor == 664)
                                {   //IdConexion,cOperacion,IdTramite,IdGrupoBeneficio,Accion,etapa,Interesado,hojaRuta,FechaHR,AreaDestino,NroFojas,Observacion,RegistroActivo,IdTipoObservacion,txtFicha = OtrasNotas
                                    registro = Observado.AdicionarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), etapa, txtNombreInteresado.Text, Convert.ToInt32(txtHojaRuta.Text), txtFecha.Text, 0, Convert.ToInt32(txtFojas.Text), txtObservacion.Text.ToUpper(), 1, Convert.ToInt32(ddlObs.SelectedValue),txtFicha.Text ,ref sMensajeError);
                                }
                                else 
                                {
                                    //IdConexion,cOperacion,IdTramite,IdGrupoBeneficio,Accion,etapa,Interesado,hojaRuta,FechaHR,AreaDestino,NroFojas,Observacion,RegistroActivo,IdTipoObservacion,txtFicha = OtrasNotas
                                    registro = Observado.AdicionarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), etapa, txtNombreInteresado.Text, Convert.ToInt32(txtHojaRuta.Text), txtFecha.Text, Convert.ToInt32(ddlArea.SelectedValue), Convert.ToInt32(txtFojas.Text), txtObservacion.Text.ToUpper(), 1, Convert.ToInt32(ddlObs.SelectedValue),txtFicha.Text, ref sMensajeError);
                                }
                                     if (registro)
                                     {
                                         Msg = "Se adicionó la observación revisión  de forma Satisfactoria";
                                         Master.MensajeOk(Msg);
                                     }
                                     else
                                     {
                                         Error = "Error de Operación";
                                         DetalleError = sMensajeError;
                                         Master.MensajeError(Error, DetalleError);
                                     }
                                //   lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
                                 }
                            else
                                {
                                    Error = "Error de Operación";
                                    DetalleError = "La Hoja que Ruta no es la correcta.. vuelva a introducir";
                                    Master.MensajeError(Error, DetalleError);
                                  //lblObservaciones.Text = "La Hoja que Ruta no es la correcta.. vuelva a introducir ";
                                }
                            break;
                        case 671:
                            //IdConexion,cOperacion,IdTramite,IdGrupoBeneficio,Accion,etapa,Interesado,hojaRuta,FechaHR,AreaDestino,NroFojas,Observacion,RegistroActivo,IdTipoObservacion, txtFicha = null
                            if (Observado.AdicionarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), etapa, txtNombreInteresado.Text, 0, "01/01/1900", 20300, 0, txtObservacion.Text.ToUpper(), 1, Convert.ToInt32(ddlObs.SelectedValue),txtFicha.Text, ref sMensajeError))
                            //if (adicionar.AdicionarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), etapa, txtNombreInteresado.Text, Convert.ToInt32(txtHojaRuta.Text), txtFecha.Text, Convert.ToInt32(ddlArea.SelectedItem.Value), 0, txtObservacion.Text.ToUpper(), 1, ref sMensajeError))
                            {
                                Msg = "Se adicionó la observación de revisión  de forma Satisfactoria";
                                Master.MensajeOk(Msg);
                            }
                            else
                            {
                                Error = "Error de Operación";
                                DetalleError = sMensajeError;
                                Master.MensajeError(Error, DetalleError);
                            }
                        //    lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
                            break;
                    }
                //    lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
                }
                Limpiarventana();
                ListarRegistros();
                ListarVisitas();
                pnlGV.Visible = true;
                pnlGV.Enabled = true;
                pnlRevision.Visible = false;
            }
            // CUANDO BOTON ES MODIFICAR
            if (btnAccionar.Text == "Modificar")
            {
                cOperacion = "U";
                if (txtNombreInteresado.Text == "" || txtObservacion.Text == "")
                {
                    lblObservaciones.Text = "El texto Introducido de algún dato... No es Válido!!!";
                }
                else
                {
                    //if (Observado.ModificarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt32(lblCodigo1.Text), Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), txtNombreInteresado.Text, Convert.ToInt32(txtFojas.Text), txtObservacion.Text.ToUpper(), 1, ref sMensajeError))                   
                    //{
                    //    Msg = "Se modificó la observación revisión  de forma Satisfactoria";
                    //    Master.MensajeOk(Msg);
                    //}
                    //else
                    //{
                    //    Error = "Error de Operación";
                    //    DetalleError = sMensajeError;
                    //    Master.MensajeError(Error, DetalleError);
                    //}
                    int valor;
                    valor = Convert.ToInt32(ddlTipoAccion.SelectedValue);
                    switch (valor)
                    {
                        case 663:
                        case 666:
                            if (Observado.ModificarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt32(hdfFormulario.Value), Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), txtNombreInteresado.Text, Convert.ToInt32(txtFojas.Text), txtObservacion.Text.ToUpper(), 1,valor, ref sMensajeError))
                            {
                                Msg = "Se modificó la observacion revisión  de forma Satisfactoria";
                                Master.MensajeOk(Msg);
                            }
                            else
                            {
                                Error = "Error de Operación";
                                DetalleError = sMensajeError;
                                Master.MensajeError(Error, DetalleError);
                            }
                            //  lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
                            break;
                        case 665:
                        case 664:
                            bool registro = false;
                            //registro = Observado.ModificarFormularioDocumentos(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ddlTipoAccion.SelectedItem.Value, etapa, txtNombreInteresado.Text, 0, "01/01/1900", 0, 0, txtObservacion.Text.ToUpper(), 1, Convert.ToInt32(ddlObs.SelectedValue), ref sMensajeError);
                            registro = Observado.ModificarFormularioDocumentos(iIdConexion, cOperacion, Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), valor, etapa, txtNombreInteresado.Text, Convert.ToInt32(txtHojaRuta.Text), txtFecha.Text, ddlArea.SelectedValue, Convert.ToInt32(txtFojas.Text), txtObservacion.Text, 1, Convert.ToInt32(ddlObs.SelectedValue),Convert.ToInt32(hdfFormulario.Value), ref sMensajeError);
                            if (registro)
                            {
                                Msg = "Se modificó la observación revisión  de forma Satisfactoria";
                                Master.MensajeOk(Msg);
                            }
                            else
                            {
                                Error = "Error de Operación";
                                DetalleError = sMensajeError;
                                Master.MensajeError(Error, DetalleError);
                            }
                            break;
                        //   lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
                    }

                }
                Limpiarventana();
                ListarRegistros();
                ListarVisitas();
                pnlGV.Visible = true;
                pnlGV.Enabled = true;
                pnlRevision.Visible = false;
            }
            // CUANDO ELIMINA
            if (btnAccionar.Text == "Eliminar")
            {
                cOperacion = "D";
                clsSeguimientoObservados eliminar = new clsSeguimientoObservados();
                if (eliminar.EliminarSeguimientoObservados(iIdConexion, cOperacion, Convert.ToInt32(lblCodigo1.Text), ref sMensajeError))
                {
                    Msg = "Se elimino la observacion revision  de forma Satisfactoria";
                    Master.MensajeOk(Msg);
                }
                else
                {
                    Error = "Error de Operación";
                    DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            //    lblObservaciones.Text = "Se elimino la observacion revision  de forma Satisfactoria";
                Limpiarventana();
                ListarRegistros();
                pnlGV.Visible = true;
                pnlGV.Enabled = true;
                pnlRevision.Visible = false;
            }
        }
        // ACCION PARA EL BOTON CANCELAR
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiarventana();
            pnlGV.Visible = true;
            pnlGV.Enabled = true;
            pnlRevision.Visible = false;
        }
        // ACCION BOTON PARA GENERAR EL REPORTE
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (txtDateIni.Text!="")
            {
                if (txtDateFin.Text != "")
                {
                    Session["FechaIni"] = txtDateIni.Text;
                    Session["FechaFin"] = txtDateFin.Text;
                    Session["rbnExport"] = rbnExportFormato.SelectedValue;
                    DateTime Ini, Fin;
                    Ini = Convert.ToDateTime(txtDateIni.Text);
                    Fin = Convert.ToDateTime(txtDateFin.Text);
                    string IniA, FinA;
                    IniA = Ini.ToString("yyyy-MM-dd");
                    FinA = Fin.ToString("yyyy-MM-dd");

                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../Reportes/wfrmReporteListadoFormulariosRevision.aspx?FecIni="+IniA+"&FecFin="+FinA+"', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                    txtDateFin.Text = txtDateIni.Text = "";

                    //Response.Write("<script>");
                    //Response.Write("window.open('../Reportes/wfrmReporteListadoFormulariosRevision.aspx','_blank')");
                    //Response.Write("</script>");
                }
                else
                {
                    txtDateIni.Text = "";
                    txtDateFin.Text = "";
                    pnlDatos.Visible = true;
                    pnlGV.Visible = false;
                    pnlRevision.Visible = false;
                }
            }
            else
            {
                txtDateIni.Text = "";
                txtDateFin.Text = "";
                pnlDatos.Visible = true;
                pnlGV.Visible = false;
                pnlRevision.Visible = false;

            }
        }
        // ACCION BOTON PARA ACCEDER A VE
        protected void imgReporteListado_Click(object sender, ImageClickEventArgs e)
        {
            pnlFechas.Visible = true; 
            this.pnlFechas_ModalPopupExtender.Show();
        }
        protected void btnCancelarGenerar_Click(object sender, EventArgs e)
        {
         // Limpiarventana();
            txtDateIni.Text="";
            txtDateFin.Text = "";
            pnlGV.Visible = true;
            pnlGV.Enabled = true;
            pnlRevision.Visible = false;
        }
        // ACCION PARA EL COMBO TIPO ACCION
        protected void ddlTipoAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor;
            valor = Convert.ToInt32(ddlTipoAccion.SelectedValue);
            HabilitaCamposRegistro(valor);
            
        }
        // ACCION PARA EL BOTON RECARGAR NOMBRE
        protected void imgCopia_Click(object sender, ImageClickEventArgs e)
        {
            txtNombreInteresado.Text = lblCodigo.Text;

        }
        // ACCION DEL BOTON NUEVO REVISION 
        protected void imgNuevoRevision_Click(object sender, ImageClickEventArgs e)
        {
            HabilitaCampos();
            Master.MensajeCancel();
            // Habilita paneles
            pnlDatos.Visible = false;
            pnlGV.Enabled = false;
            pnlRevision.Visible = true;
            // coloca textos
            lblTitulopopup.Text = "ADICION DE REVISIONES";
            btnAccionar.Text = "Adicionar";
            // habilita el combo accion
            ddlTipoAccion.Enabled = true;
            lblFicha.Visible = true;
            txtFicha.Visible = true;
            lblObs.Visible = true;
            ddlObs.Visible = true;
            // carga datos
            CargarTipoRevision();
            CargarGestiones();
            CargarAreas();
            ddlObservadosVer();
            
        }
    #endregion

    # region EventosGrilla
        // ACCION PARA SELLECIONAR OPCION
        protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarRegistros();
        }
        // GVTIPO_ROWCOMMAND
        protected void gvTipo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            string accion = e.CommandName.ToUpper();

            if (accion == "VER")
            {
                string form;
                int index = Convert.ToInt32(e.CommandArgument);
                form = gvTipo.Rows[index].Cells[1].Text; //IdFormulario
                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../Reportes/wfrmReporteFormularioRevision.aspx?iIdTramite="+Tram.Value+"&iIdGrupoBeneficio="+gruBen.Value+"&Codigo="+form+"', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
            }

            if (e.CommandName == "cmdEditar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                hdfFormulario.Value = index.ToString();
                // obtiene indice
                lblCodigo1.Text = Convert.ToString(e.CommandArgument.ToString()); 
                // limpia ventana de datos
                Limpiarventana();
                // coloca textos
                lblTitulopopup.Text = "MODIFICACION DE REVISIONES";
                btnAccionar.Text = "Modificar";
                // carga datos
                CargarTipoRevision();
                ddlObservadosVer();
                CargarGestiones();
                CargarAreas();
                VerDatos();
                //habilita paneles
                pnlGV.Enabled = true;
                pnlRevision.Visible = true;
                // (des)habilita objetos
                ddlTipoAccion.Enabled = true;
                txtHojaRuta.Enabled = true;
                ddlGestion.Enabled = true;
                ddlGestion.Enabled = true;
                txtNombreInteresado.Enabled = true;
                ddlObs.Enabled = true;
                txtFojas.Enabled = true;
                txtObservacion.Enabled = true;
            }
            if (e.CommandName == "cmdEliminar")
            {
                lblCodigo1.Text = Convert.ToString(e.CommandArgument.ToString());
                Limpiarventana();
                lblTitulopopup.Text = "ELIMINACION DE REVISIONES";
                btnAccionar.Text = "Eliminar";
                CargarTipoRevision();
                CargarGestiones();
                VerDatos();
                // /habilita paneles
                pnlGV.Enabled = false;
                pnlRevision.Visible = true;
                // (des)habilita objetos
                ddlTipoAccion.Enabled = false;
                txtHojaRuta.Enabled = false;
                ddlGestion.Enabled = false;
                txtFojas.Enabled = false;
                txtNombreInteresado.Enabled = false;
                txtObservacion.Enabled = false;
                ddlArea.Enabled = false;
                txtFecha.Enabled = false;
                ddlObs.Enabled = false;
            }
            if (e.CommandName == "cmdVer") 
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                string strObservado = Convert.ToString(gvTipo.DataKeys[Index].Values["TextoObservacion"]);
                txtObsEtapa.Text = strObservado;
                pnlObservado.Visible = true;
                ModalPopupExtender_Observado.Show();
            }
        }
        //GVTIPO_ROWDATABOUND
        protected void gvTipo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int DEstado;
                gvTipo.Enabled = true;
                pnlGV.Enabled = true;
                DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));
                if (DEstado == 1)
                {
                    //ToolTip Prueba = new ToolTip();
                    //HyperLink hlnk = new HyperLink();
                    //hlnk.ImageUrl = "~/Imagenes/16Activo.png";
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgEstado");
                    //e.Row.Cells[6].ToolTip = e.Row.Cells[7].Text;
                    imagen.ImageUrl = "~/Imagenes/16Activo.png";
                    e.Row.Cells[9].Enabled = true;
                    e.Row.Cells[10].Enabled = true;

                }
                if (DEstado == 0)
                {
                    e.Row.BackColor = Color.Silver;
                    e.Row.ForeColor = Color.Lavender;
                    //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                    //HyperLink hlnk = new HyperLink();
                    //hlnk.ImageUrl = "~/Imagenes/16Inactivo.png";
                    //e.Row.Cells[8].Controls.Add(hlnk);
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgEstado");
                    imagen.ImageUrl = "~/Imagenes/16Inactivo.png";
                    e.Row.Cells[0].Enabled = false;
                    e.Row.Cells[9].Enabled = false;
                    e.Row.Cells[10].Enabled = false;
                    if (rbTipoMuestra.SelectedIndex == 1)
                        e.Row.Visible = false;
                }
                if (e.Row.RowIndex != 0)
                {
                    e.Row.FindControl("imgEditar").Visible = false;
                    e.Row.FindControl("imgEliminar").Visible = false;
                }
            }
        }

        protected void gvTipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTipo.PageIndex = e.NewPageIndex;
            ListarRegistros();
        }
        // LIMPIA LOS REGISTROS DE LA VENTANA 
        protected void Limpiarventana()
        {
            txtHojaRuta.Text = "";
            txtFojas.Text = "";
            txtNombreInteresado.Text = "";
            txtDescripcionDoc.Text = "";
            txtObservacion.Text = "";
            txtFecha.Text = "";

            lblHojaRuta.Visible = false;
            txtHojaRuta.Visible = false;
            ddlGestion.Visible = false;
            imgBuscar.Visible = false;
            lblBuscar.Visible = false;
            lblObser.Visible = false;
            lblDescripcionDoc.Visible = false;
            txtDescripcionDoc.Visible = false;
            lblFecha.Visible = false;
            txtFecha.Visible = false;
            lblFojas.Visible = false;
            txtFojas.Visible = false;
            lblArea.Visible = false;
            ddlArea.Visible = false;

            HabilitaCampos();

            lblObser.Text = "";


        }

        public void HabilitaCampos() 
        {
            lblHojaRuta.Enabled = true;
            txtHojaRuta.Enabled = true;
            ddlGestion.Enabled = true;
            imgBuscar.Enabled = true;
            lblBuscar.Enabled = false;
            lblObser.Enabled = false;
            lblDescripcionDoc.Enabled = true;
            txtDescripcionDoc.Enabled = true;
            lblFecha.Enabled = true;
            txtFecha.Enabled = true;
            lblFojas.Enabled = true;
            txtFojas.Enabled = true;
            lblArea.Enabled = true;
            ddlArea.Enabled = true;
            ddlObs.Enabled = true;
            txtObservacion.Enabled = true;
            txtNombreInteresado.Enabled = true;
        }

        public void HabilitaCamposRegistro(int X) 
        {
            int valor = X;
            switch (valor)
            {
                case 663:
                    lblHojaRuta.Visible = false;        // Hoja de Ruta:
                    txtHojaRuta.Visible = false;        // Caja Texto Hoja Ruta
                    ddlGestion.Visible = false;         // Lista de Gestion
                    imgBuscar.Visible = false;          // Boton Buscar
                    lblBuscar.Visible = false;          // Texto que acompaña al boton
                    lblObser.Visible = false;           // Boton Buscar       
                    lblDescripcionDoc.Visible = false;  // Descripción:
                    txtDescripcionDoc.Visible = false;  // Caja de Texto Descripción
                    lblFecha.Visible = false;           // Fecha:
                    txtFecha.Visible = false;           // Caja de Texto Fecha
                    lblFojas.Visible = false;           // Fojas:
                    txtFojas.Visible = false;           // Caja de Texto Fojas
                    lblArea.Visible = false;            // Área:
                    ddlArea.Visible = false;            // Lista de Áreas
                    lblObser.Text = "";                 // Observación
                    lblFicha.Visible = true;            //CodFicha
                    txtFicha.Visible = true;            //Campo para la Ficha
                    lblObs.Visible = true;
                    ddlObs.Visible = true;
                    lblFicha.Text = "Ficha";
                    break;
                case 664:
                    lblHojaRuta.Enabled = true;         // Hoja de Ruta:
                    txtHojaRuta.Enabled = true;         // Caja Texto Hoja Ruta
                    ddlGestion.Enabled = true;          // Lista de Gestion
                    imgBuscar.Enabled = true;           // Boton Buscar
                    lblHojaRuta.Visible = true;         // Hoja de Ruta
                    txtHojaRuta.Visible = true;         // Caja de Texto Hoja Ruta
                    ddlGestion.Visible = true;          // Lista de Gestion
                    imgBuscar.Visible = true;           // Boton Buscar
                    lblFecha.Visible = true;            // Fecha:
                    txtFecha.Visible = true;            // Caja de Texto Fecha
                    lblBuscar.Visible = true;           // Texto q acompaña al boton Buscar
                    lblObser.Visible = true;            // Observacion:
                    lblDescripcionDoc.Visible = true;   // Descripcion:
                    txtDescripcionDoc.Visible = true;   // Caja de Texto de Descripcion
                    lblFojas.Visible = true;            // Fojas:
                    txtFojas.Visible = true;            // Caja de Texto de Fojas
                    lblArea.Visible = false;            // Area:
                    ddlArea.Visible = false;            // Lista de Áreas
                    lblObser.Text = "";                 // Observacion:
                    lblFicha.Visible = true;            //Ficha
                    txtFicha.Visible = true;           //Ficha campo
                    lblObs.Visible = true;
                    ddlObs.Visible = true;
                    lblFicha.Text = "OtrasNotas";
                    break;
                case 665:
                    lblHojaRuta.Visible = true;          // Hoja Ruta:
                    txtHojaRuta.Visible = true;         // Caja de Texto Hoja Ruta
                    ddlGestion.Visible = true;          // Lista de Gestiones
                    imgBuscar.Visible = true;           // Boton de Buscar
                    lblBuscar.Visible = true;           // Texto que acompaña al boton
                    lblObser.Visible = true;            // Observacion:
                    lblDescripcionDoc.Visible = true;   // Descripcion:
                    txtDescripcionDoc.Visible = true;   // Caja de Texto de Descripcion
                    lblFecha.Visible = true;            // Fecha:     
                    txtFecha.Visible = true;            // Caja de Texto de Fecha
                    lblFojas.Visible = false;           // Fojas:
                    txtFojas.Visible = false;           // Caja de Texto de Fojas
                    lblArea.Visible = true;             // Area:
                    ddlArea.Visible = true;             // Lista de Areas para Derivacion
                    lblFojas.Visible = true;            // Fojas:
                    txtFojas.Visible = true;            // Caja de texto de Fojas
                    lblObser.Text = "";                 // Observacion
                    lblFicha.Visible = true;            //Ficha
                    txtFicha.Visible = true;           //Ficha campo
                    lblObs.Visible = true;
                    ddlObs.Visible = true;
                    lblFicha.Text = "OtrasNotas";
                    break;
                case 671:
                    lblHojaRuta.Visible = false;        // Hoja de Ruta:
                    txtHojaRuta.Visible = false;        // Caja Texto Hoja Ruta
                    ddlGestion.Visible = false;         // Lista de Gestion
                    imgBuscar.Visible = false;          // Boton Buscar
                    lblBuscar.Visible = false;          // Texto que acompaña al boton
                    lblObser.Visible = false;           // Boton Buscar       
                    lblDescripcionDoc.Visible = false;  // Descripción:
                    txtDescripcionDoc.Visible = false;  // Caja de Texto Descripción
                    lblFecha.Visible = false;           // Fecha:
                    txtFecha.Visible = false;           // Caja de Texto Fecha
                    lblFojas.Visible = false;           // Fojas:
                    txtFojas.Visible = false;           // Caja de Texto Fojas
                    lblArea.Visible = false;            // Área:
                    ddlArea.Visible = false;            // Lista de Áreas
                    lblObser.Text = "";                 // Observación
                    lblFicha.Visible = false;            //CodFicha
                    txtFicha.Visible = false;            //Campo para la Ficha
                    lblFojas.Visible = false;            //Fojas
                    txtFojas.Visible = false;            //Campo para las fojas
                    lblObs.Visible = true;
                    ddlObs.Visible = true;
                    break;
                default:
                    break;
            }
        }
    #endregion
        protected void gvVisitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string accion = e.CommandName.ToUpper();
            if (accion == "VERVISITA")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                //form = gvTipo.Rows[index].Cells[1].Text; //IdFormulario
                string FecRevision = Convert.ToDateTime(gvVisitas.DataKeys[index]["FechaRev"]).ToString("yyyy-MM-dd");
                string CodFicha = gvVisitas.DataKeys[index]["CodFicha"].ToString();
                Session["FechaRev"] = FecRevision;
                Session["CodFicha"] = CodFicha;
                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../Reportes/wfrmReporteFormularioRevision.aspx?iIdTramite=" + Tram.Value + "&iIdGrupoBeneficio=" + gruBen.Value +"', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
            }
            if (e.CommandName == "cmdVerVisita")
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                string strObservado = Convert.ToString(gvVisitas.DataKeys[Index].Values["Observacion"]);
                txtObsEtapa.Text = strObservado;
                pnlObservado.Visible = true;
                ModalPopupExtender_Observado.Show();
            }
        }
}