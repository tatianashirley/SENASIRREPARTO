using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AjaxControlToolkit;
using wcfSeguridad.Logica;
using wcfCertificacionCC.Logica;
using wcfWorkFlowN.Logica;
using wcfNotificacion.Logica;



using System.Drawing;


public partial class CertificacionCC_wfrmProcedimientoAutomatico : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsNotificaciones ObjNotificacion = new clsNotificaciones();
    clsRegistroDocumento ObjDocumento = new clsRegistroDocumento();
    int FlagWF = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["vUrl"] != null)
            {
                ViewState["PreviousPage"] = ObjSeguridad.URLDecode(Request.QueryString["vUrl"]);
            }
            else
            {
                ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
            }


            int iIdTramite=0;
            int iIdGrupoBeneficio=0;            
            //txtObservacion.Visible = false;
            //lblNotificacion.Visible = false;
            txtFechaCalculo.Enabled = false;

            
            if (Request.QueryString["iIdTramite"] != null )
            
            
            {
                

                iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);


                hfIdTramite.Value= Convert.ToString(iIdTramite);
                hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);
                ListarDatosAsegurado(iIdTramite,iIdGrupoBeneficio);

                //INGRESAR CODIGO PARA CONTROLAR LOS REPROCESOS
                //int flgReproceso = 0;
                //if (flgReproceso == 0)
                //{
                //    txtFechaCalculo.Text = null;
                //}
            }
        }
        
    }

    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    private void ListarComponentes(int iIdTramite, int iIdGrupoBeneficio,string cOperacion)
    {
        int iIdConexion = (int)Session["IdConexion"];
       // string cOperacion = "W";
        string sMensajeError = null;

        if (sMensajeError == null)
        {

            gvDatos.DataSource = ObjProcedimientoValidoManual.DatosProcedimientoValidoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            gvDatos.DataBind();
            if (sMensajeError != null)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }


    }
   
   
    //Operaciones que presenta el grid view (Certificar)
    
    private void ListarDatosAsegurado(int iIdTramite,int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";                
        string sMensajeError = null;
        DataTable tblListaDatosAsegurado = null;
        int Flag;
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaDatosAsegurado != null)
        {
            foreach (DataRow drDataRow in tblListaDatosAsegurado.Rows)
            {
                lblPaterno.Text = Convert.ToString(drDataRow["PrimerApellido"]);
                lblMaterno.Text = Convert.ToString(drDataRow["SegundoApellido"]);
                lblNombres.Text = Convert.ToString(drDataRow["PrimerNombre"]) + ' ' + Convert.ToString(drDataRow["SegundoNombre"]);
                lblDocIdentidad.Text = Convert.ToString(drDataRow["NumeroDocumento"]) + ' ' + Convert.ToString(drDataRow["ComplementoSEGIP"]);
                lblFechaNacimiento.Text = Convert.ToString(drDataRow["FechaNacimiento"]);
                lblFechaFallecimiento.Text = Convert.ToString(drDataRow["FechaFallecimiento"]);
                lblEstadoCivil.Text = Convert.ToString(drDataRow["EstadoCivil"]);
                lblRegional.Text = Convert.ToString(drDataRow["OficinaNotificacion"]); ;
                lblMatricula.Text = Convert.ToString(drDataRow["Matricula"]);
                lblCUA.Text = Convert.ToString(drDataRow["CUA"]);
                lblTramite.Text = Convert.ToString(drDataRow["IdTramite"]);
                lblFechaInicio.Text = Convert.ToString(drDataRow["FechaInicioTramite"]);
                hfFlagM.Value = Convert.ToString(drDataRow["FlagM"]);
                hfFlagG.Value = Convert.ToString(drDataRow["FlagG"]);
                hfEstadoTramite.Value = Convert.ToString(drDataRow["EstadoTramite"]);
                txtFechaCalculo.Text = Convert.ToString(drDataRow["FechaCalculo"]);
                lblTipoReproceso.Text = Convert.ToString(drDataRow["TipoReproceso"]);
                hfOficinaNotificacion.Value = Convert.ToString(drDataRow["IdOficinaNotificacion"]);
                hfOficinaRegistro.Value = Convert.ToString(drDataRow["IdOficinaRegistro"]);
                
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        if (hfEstadoTramite.Value == "42")
        {
            lblTipoReproceso.Visible = true;
            lblEstadoTramite.Text = "- Tramite en reproceso ingresar la fecha de calculo";
            lblEstadoTramite.Visible = true;
            txtFechaCalculo.Visible = true;
        }
        else
        {
            txtFechaCalculo.Visible = false;
            txtFechaCalculo.Text = "";
        }
            if (hfFlagM.Value =="0" && hfFlagG.Value =="0")
        {
            btnGenerar.Visible = true;
            btnFormularioMensual.Visible = false;
            //btnConfirmacion.Visible = false;
            btnFormularioGlobal.Visible = false;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio,"W");
        }
        if (hfFlagM.Value == "1" && hfFlagG.Value == "0")
        {
            btnGenerar.Visible = false;
            btnFormularioMensual.Visible = true;
            btnFormularioGlobal.Visible = false;
            //btnConfirmacion.Visible = true;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");
            //string sOpe = "B";
            //int Notificacion = Convert.ToInt32(ObjNotificacion.HabilitaBoton(iIdConexion, sOpe, iIdTramite, iIdGrupoBeneficio, ref sMensajeError).Rows[0]["existe"].ToString());
  
            //if (Notificacion == 1)
            //{
            //    lblNotificacion.Visible = true;
            //    txtObservacion.Visible = true;
            //    btnNotificar.Visible = true;
            //}
            //else
            //{
            //    lblNotificacion.Visible = false;
            //    txtObservacion.Visible = false;
            //    btnNotificar.Visible = false;
            //}
        }
        if (hfFlagM.Value == "0" && hfFlagG.Value == "1")
        {
            btnGenerar.Visible = false;
            btnFormularioMensual.Visible = false;
            btnFormularioGlobal.Visible = true;
            //string sOpe = "B";
            //int Notificacion = Convert.ToInt32(ObjNotificacion.HabilitaBoton(iIdConexion, sOpe, iIdTramite, iIdGrupoBeneficio, ref sMensajeError).Rows[0]["existe"].ToString());
            //if (Notificacion == 1)
            //{
            //    lblNotificacion.Visible = true;
            //    txtObservacion.Visible = true;
            //    btnNotificar.Visible = true;
            //}
            //else
            //{
            //    lblNotificacion.Visible = false;
            //    txtObservacion.Visible = false;
            //    btnNotificar.Visible = false;
            //}
            //btnConfirmacion.Visible = true;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");
        }
        if (hfFlagM.Value == "1" && hfFlagG.Value == "1")
        {
            btnGenerar.Visible = false;
            btnFormularioMensual.Visible = true;
            btnFormularioGlobal.Visible = true;
            //string sOpe = "B";
            //int Notificacion = Convert.ToInt32(ObjNotificacion.HabilitaBoton(iIdConexion, sOpe, iIdTramite, iIdGrupoBeneficio, ref sMensajeError).Rows[0]["existe"].ToString());
            //if (Notificacion == 1)
            //{
            //    lblNotificacion.Visible = true;
            //    txtObservacion.Visible = true;
            //    btnNotificar.Visible = true;
            //}
            //else
            //{
            //    lblNotificacion.Visible = false;
            //    txtObservacion.Visible = false;
            //    btnNotificar.Visible = false;
            //}
            //btnConfirmacion.Visible = true;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");
        }
    }


    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        clsNotificaciones ObjNotificacion = new clsNotificaciones();
        string mensaje = null;
        //Inserta en el Formulario de Calculo 
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";                
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        DateTime? sFechaActual;

        if (txtFechaCalculo.Text == "")
        {
            sFechaActual = null;
        }
        else
        {
            sFechaActual = Convert.ToDateTime(txtFechaCalculo.Text);
        }

        if (ObjEmisionFormularioCC.GenerarDescripcionFormularioCC(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,sFechaActual, ref sMensajeError))
        {
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");
            ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
            Impresion();
            Notificar();
            DataTable FormCC = ObjNotificacion.ObtieneDatos((int)Session["IdConexion"], "F", iIdTramite.ToString(), iIdGrupoBeneficio.ToString(), ref mensaje);
            if (FormCC != null && FormCC.Rows.Count > 0)
            {
                lblNotificacion.Text = "Plazo de Vencimiento de Notificación: " + FormCC.Rows[0]["FechaVencePlazo"].ToString();
                lblNotificacion.Visible = true;
            }
            else
                Master.MensajeError("Error al registar la notificación", "No existe Fecha de Notificacion");
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }


    }
    protected void btnFormularioMensual_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        string iIdTipoCC = "358";
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);
        string vUrl = ViewState["PreviousPage"].ToString();
        vUrl = ObjSeguridad.URLEncode(vUrl);
        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
    
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        
    }
    protected void btnNotificacion_Click(object sender, EventArgs e)
    {
        
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;        
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);

        Response.Redirect("../Notificaciones/wfrmNotificaciones.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " "); 
       
        
    }
   
    protected void btnFormularioGlobal_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        string iIdTipoCC = "359";
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);
        string vUrl = ViewState["PreviousPage"].ToString();
        vUrl = ObjSeguridad.URLEncode(vUrl);
        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
        //Response.Redirect("../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&vUrl=" + Server.UrlEncode(vUrl) + " ");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=100%,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }




    //protected void btnConfirmacionImpresion_Click(object sender, EventArgs e)
    //{
    //    int iIdConexion = (int)Session["IdConexion"];
    //    string cOperacion = "U";
    //    string sMensajeError = null;
    //    int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
    //    int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
    //    if (ObjEmisionFormularioCC.RegistraImpresion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
    //    {
    //        if (FlagWF == 1)
    //        {
    //            #region Codigo Workflow parte 1
    //            //CODIGO DE INTEGRACION CON WF
    //            clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
    //            ObjINodo.iIdConexion = iIdConexion;
    //            ObjINodo.iIdTramite = iIdTramite;
    //            ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
    //            //EMISION
    //            //if (Convert.ToInt32(hfOficinaNotificacion.Value) == 2)
    //            if (Convert.ToInt32(hfOficinaNotificacion.Value) == (Convert.ToInt32(hfOficinaRegistro.Value)))
    //            {
    //                ObjINodo.sNemoNodoOrig = "NOTIFICACION";
    //            }
    //            else
    //            {
    //                ObjINodo.sNemoNodoOrig = "NOTIFICACION";
    //            }
    //            ObjINodo.sEstado = "I";
    //            if (ObjINodo.ObtieneActividadActiva())
    //            {
    //                clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
    //                ObjINodoCpto.iIdConexion = iIdConexion;
    //                ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
    //                ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
    //                ObjINodoCpto.sIdConcepto = "FCALC_AUTO";
    //                ObjINodoCpto.bValorBoolean = true;
    //                if (ObjINodoCpto.Grabar())
    //                {
    //                    string msg = "La operacion se realizo con exito";
    //                    Master.MensajeOk(msg);
    //                }
    //                else
    //                {
    //                    string Error = "Error al realizar la operación";
    //                    string DetalleError = ObjINodoCpto.sMensajeError;
    //                    Master.MensajeError(Error, DetalleError);
    //                }

    //            }
    //            else
    //            {
    //                string Error = "Error al realizar la operación";
    //                string DetalleError = ObjINodo.sMensajeError;
    //                Master.MensajeError(Error, DetalleError);
    //            }
    //            #endregion
    //        }
    //        if (FlagWF == 0)
    //        {
    //            #region WFArticulador
    //            string msg = "La operacion se realizo con exito";
    //            Master.MensajeOk(msg);
    //            #endregion
    //        }

    //    }
    //    else
    //    {
    //        string Error = "Error al realizar la operación";
    //        string DetalleError = sMensajeError;
    //        Master.MensajeError(Error, DetalleError);
    //    }
    //}
  
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx";
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
    //protected void btnNotificar_Click(object sender, EventArgs e)
    //{
    //    int iIdConexion = (int)Session["IdConexion"];
    //    string cOperacion = "L";
    //    string sObservacion = txtObservacion.Text;
    //    string sMensajeError = null;
    //    int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
    //    int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);


    //    if (ObjDocumento.RegistraDocumento(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, sObservacion, ref sMensajeError))
    //    {
    //        if (FlagWF == 1)
    //        {
    //            #region CodigoWorkFlow ParteIII
    //            clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
    //            ObjINodo.iIdConexion = iIdConexion;
    //            ObjINodo.iIdTramite = iIdTramite;
    //            ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
    //            ObjINodo.sNemoNodoOrig = "NOTIFICACION";
    //            ObjINodo.sEstado = "I";
    //            if (ObjINodo.ObtieneActividadActiva())
    //            {
    //                clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
    //                ObjINodoCpto.iIdConexion = iIdConexion;
    //                ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
    //                ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
    //                ObjINodoCpto.sIdConcepto = "NOTIFICACION_OK";
    //                ObjINodoCpto.bValorBoolean = true;
    //                if (ObjINodoCpto.Grabar())
    //                {


    //                    string msg = "La operacion se realizo con exito";
    //                    Master.MensajeOk(msg);
    //                }
    //            }
    //            #endregion
    //        }
    //        if (FlagWF == 0)
    //        {
    //            #region WFArticulador
    //            string msg = "La operacion se realizo con exito";
    //            Master.MensajeOk(msg);
    //            #endregion
    //        }

    //    }
    //    else
    //    {
    //        string Error = "Error al realizar la operación";
    //        string DetalleError = sMensajeError;
    //        Master.MensajeError(Error, DetalleError);
    //    }
    //}

    protected void Impresion() 
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        if (ObjEmisionFormularioCC.RegistraImpresion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
        {
            string msg = "La operación se realizo con éxito";
            Master.MensajeOk(msg);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }

    protected void Notificar() 
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "L";
        //string sObservacion = txtObservacion.Text;
        string sObservacion = "Notificación Automática";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);


        if (ObjDocumento.RegistraDocumento(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, sObservacion, ref sMensajeError))
        {
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }
}