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
using wcfGeo.Logica;
using wcfWorkFlowN.Logica;


using System.Drawing;


public partial class CertificacionCC_wfrmEmisionProcedimientoManual : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    int FlagWF = 0;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (FlagWF == 1)
            {
                pnlTransicionWF.Visible = false;
            }
            if (FlagWF == 0)
            {
                pnlTransicionWF.Visible = false;
            }

            ViewState["CuentaRechazos"] = 0;
            
            int iIdTramite=0;
            int iIdGrupoBeneficio=0;
            txtFechaCalculo.Text = "";
            

            if (Request.QueryString["vUrl"] != null)
            {
                ViewState["PreviousPage"] = ObjSeguridad.URLDecode(Request.QueryString["vUrl"]);
            }
            else
            {
                ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
            }
            
            if (Request.QueryString["iIdTramite"] != null )
            {
                //iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
                //iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));

                iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                hfIdTramite.Value= Convert.ToString(iIdTramite);
                hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);

            }
            Permisos(iIdTramite, iIdGrupoBeneficio);
           ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
            ListaAprobaciones(iIdTramite, iIdGrupoBeneficio);
            
            //VISUALIZA TRANSICION EN CASO DE NO APROBAR EL TRAMITE
            
            if ((int)ViewState["CuentaRechazos"] >= 2)
            {
                if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                {
                                      
                     iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                     iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                     
                     if (FlagWF == 1)
                     {
                         btnRechazoCCR.Visible = true;
                         txtObservacion.Visible = true;
                         lblObservacionTransicion.Visible = true;
                         btnTransicion.Visible = true;
                         ddlListaWF.Visible = true;
                         ListaWF(iIdTramite, iIdGrupoBeneficio);
                         rfvObservacion.Visible = true;

                     }

                   
                }


                lblGeneracion.Visible = true;
                txtCodGeneracion.Visible = true;
                btnGenerar.Visible = false;
            }
        }

    }
    private void Permisos(int iIdTramite,int iIdGrupoBeneficio)
    {
        if (Master.HabilitaTransaccion(3500289) == 1) //HABILITA BOTON PARA EL VOCAL O EL SECRETARIO CCR
        {
            if ((int)Session["RolUsuario"] == 103) //Secretario
            {
                btnApruebaCCR.Visible = true;
                lblGeneracion.Visible = true;          
                txtCodGeneracion.Visible = true;
                btnGenerar.Visible = false;
                btnFormularioMensual.Visible = false;
                btnFormularioGlobal.Visible = false;
                
                
                btnFormularioGlobal.Visible = false;
                btnFormularioMensual.Visible = false;
                ddlListaWF.Visible = false;

                btnConfirmacion.Visible = false;
                btnRechazoCCR.Visible = false;
                lblObservacionTransicion.Visible = false;
                txtObservacion.Visible = false;
                rfvObservacion.Visible = false;
                rfvListaWF.Visible = false;
                btnTransicion.Visible = false;
                txtFechaCalculo.Visible = false;

            }
            if ((int)Session["RolUsuario"] == 102) //Vocal
            {
                btnApruebaCCR.Visible = true;

                lblGeneracion.Visible = true;
                
                txtCodGeneracion.Visible = true;
                btnGenerar.Visible = false;
                btnFormularioMensual.Visible = false;
                btnFormularioGlobal.Visible = false;                
                btnFormularioGlobal.Visible = false;
                btnFormularioMensual.Visible = false;
                ddlListaWF.Visible = false;



                btnConfirmacion.Visible = false;
                btnRechazoCCR.Visible = false;
                lblObservacionTransicion.Visible = false;
                txtObservacion.Visible = false;
                rfvObservacion.Visible = false;
                rfvListaWF.Visible = false;
                btnTransicion.Visible = false;
                txtFechaCalculo.Visible = false;
            }
        }
        if (Master.HabilitaTransaccion(3500290) == 1) //HABILITA BOTON PARA EL PRESIDENTE CCR
        {

            if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
            {
                btnApruebaCCR.Visible = true;
                // No es necesario q este aqui este codigo
                lblGeneracion.Visible = true;
                txtCodGeneracion.Visible = true;
                btnFormularioGlobal.Visible = false;
                btnFormularioMensual.Visible = false;
                lblObservacionTransicion.Visible = false;
                txtObservacion.Visible = false;
                rfvObservacion.Visible = false;
                rfvListaWF.Visible = false;
                btnRechazoCCR.Visible = false;
                txtFechaCalculo.Visible = false;
                ddlListaWF.Visible = false;
                btnGenerar.Visible = false;
                btnConfirmacion.Visible = false;
                btnTransicion.Visible = false;
                
            }

        }
    }
    private void ListaWF(int iIdTramite,int iIdGrupoBeneficio)
    {
        
        int iIdConexion = (int)Session["IdConexion"];
        DataTable tblListaWF = null;
        clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
        ObjINodo.iIdConexion = iIdConexion;
        ObjINodo.iIdTramite = iIdTramite;
        ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
        ObjINodo.sNemoNodoOrig = "CCR";
        ObjINodo.sEstado = "I";
        ObjINodo.bFlagManual = false;

        if (ObjINodo.ObtieneActividadActiva())
        {
            if (ObjINodo.ObtieneTransicionesPosibles())
            {
                tblListaWF = ObjINodo.DSet.Tables[0];
                if (tblListaWF != null && tblListaWF.Rows.Count == 1)
                {
                    string iIdNodo = tblListaWF.Rows[0]["IdNodo"].ToString();
                    //CODIGO DE INTEGRACION CON WF

                    if (ObjINodo.ObtieneActividadActiva())
                    {
                        ObjINodo.iIdConexion = iIdConexion;
                        ObjINodo.iIdInstancia = ObjINodo.iIdInstancia;
                        ObjINodo.iSecuencia = ObjINodo.iSecuencia;
                        ObjINodo.sComentarios = txtObservacion.Text;
                        ObjINodo.sIdListaNodoTrg = iIdNodo;
                        ObjINodo.bFlagManual = false;

                        if (ObjINodo.RealizaTransicion())
                        {
                            string msg = "La operacion se realizo con exito";
                            Master.MensajeOk(msg);
                            Response.Redirect("../CertificacionCC/wfrmListaTramitesParaEmision.aspx");

                        }
                        else
                        {
                            string Error = "Error al realizar la operación";
                            string DetalleError = ObjINodo.sMensajeError;
                            Master.MensajeError(Error, DetalleError);
                        }
                    }

                }
                else
                {
                    ddlListaWF.DataSource = tblListaWF;
                    ddlListaWF.DataValueField = "IdNodo";
                    ddlListaWF.DataTextField = "Descripcion";
                    ddlListaWF.DataBind();
                    ddlListaWF.Items.Insert(0, new ListItem("Seleccione...", "0"));
                }

            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = ObjINodo.sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = ObjINodo.sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void gvDatosAprobacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            string sEstadoAprobacion = Convert.ToString(gvDatosAprobacion.DataKeys[e.Row.RowIndex].Values["EstadoAprobacion"]);            
            
            
            if (sEstadoAprobacion=="RECHAZADO")
            {
                //e.Row.BackColor = System.Drawing.Color.FromName(;
                e.Row.BackColor =Color.FromName("#FFD5D2");
                lblGeneracion.Visible = true;
                txtCodGeneracion.Visible = true;
                btnFormularioGlobal.Visible = false;
                btnFormularioMensual.Visible = false;


                //if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                //{
                    
                //    btnRechazoCCR.Visible = true;
                //    txtObservacion.Visible = true;
                //    lblObservacionTransicion.Visible = true;
                //    btnTransicion.Visible = true;
                //    int iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                //    int iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                //    ddlListaWF.Visible = true;
                //    ListaWF(iIdTramite, iIdGrupoBeneficio);
                //    rfvObservacion.Visible = true;
                //}
                
                btnGenerar.Visible = false;
                
                ViewState["CuentaRechazos"] = (int)ViewState["CuentaRechazos"]+1;
     
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
    private void ListarDatosAsegurado(int iIdTramite,int iIdGrupoBeneficio)
    

{
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";                
        string sMensajeError = null;
        DataTable tblListaDatosAsegurado = null;
        int Flag;
        
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaDatosAsegurado != null && tblListaDatosAsegurado.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in tblListaDatosAsegurado.Rows)
            {
                lblPaterno.Text = Convert.ToString(drDataRow["PrimerApellido"]);
                lblMaterno.Text = Convert.ToString(drDataRow["SegundoApellido"]);
                lblNombres.Text = Convert.ToString(drDataRow["PrimerNombre"]) + ' ' + Convert.ToString(drDataRow["SegundoNombre"]);
                lblDocIdentidad.Text = Convert.ToString(drDataRow["NumeroDocumento"]) + ' ' + Convert.ToString(drDataRow["ComplementoSEGIP"]) + ' ' + Convert.ToString(drDataRow["Expedido"]);
                lblFechaNacimiento.Text = Convert.ToString(drDataRow["FechaNacimiento"]);
                lblFechaFallecimiento.Text = Convert.ToString(drDataRow["FechaFallecimiento"]);
                lblEstadoCivil.Text = Convert.ToString(drDataRow["EstadoCivil"]);
                lblRegional.Text = Convert.ToString(drDataRow["OficinaNotificacion"]); ;
                lblMatricula.Text = Convert.ToString(drDataRow["Matricula"]);
                lblCUA.Text = Convert.ToString(drDataRow["CUA"]);
                lblTramite.Text = Convert.ToString(drDataRow["NumeroTramiteCrenta"]);
                lblFechaInicio.Text = Convert.ToString(drDataRow["FechaInicioTramite"]);
                hfFlagM.Value = Convert.ToString(drDataRow["FlagM"]);
                hfFlagG.Value = Convert.ToString(drDataRow["FlagG"]);
                hfEstadoTramite.Value = Convert.ToString(drDataRow["EstadoTramite"]);
                hfNoImpresion.Value = Convert.ToString(drDataRow["NoImpresion"]);
                hfAprobaciones.Value = Convert.ToString(drDataRow["Aprobaciones"]);
                string FecCalculo = drDataRow["FechaCalculo"].ToString();
                if (/*drDataRow["FechaCalculo"] != null && drDataRow["FechaCalculo"] != ""*/ FecCalculo != null && FecCalculo != "")
                    txtFechaCalculo.Text = Convert.ToDateTime(drDataRow["FechaCalculo"]).ToShortDateString();
                else
                    txtFechaCalculo.Text = drDataRow["FechaCalculo"].ToString();
                lblTipoReproceso.Text = Convert.ToString(drDataRow["TipoReproceso"]);
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }



        if (hfEstadoTramite.Value== "42")
        {
            lblTipoReproceso.Visible = true;
            lblEstadoTramite.Text = "Tramite en reproceso verificar componentes";
            lblEstadoTramite.Visible = true;
            txtFechaCalculo.Visible = true;
        }
        else
        {
            txtFechaCalculo.Visible = false;
            txtFechaCalculo.Text = "";
        }
        //if (hfEstadoTramite.Value == "23")
        //{
        //    lblTipoReproceso.Visible = true;
        //    lblEstadoTramite.Text = "Tramite con Recurso de Reclamación";
        //    lblEstadoTramite.Visible = true;
        //    txtFechaCalculo.Visible = false;
        //    txtFechaCalculo.Text = "";
      
        //}
        //else
        //{
        //    txtFechaCalculo.Visible = false;
        //    txtFechaCalculo.Text = "";
        //}
        if (hfFlagM.Value == "0" && hfFlagG.Value == "0")
        {

            if (Master.HabilitaTransaccion(3500290) == 1) //HABILITA BOTON PARA EL PRESIDENTE CCR Y APRUEBA CCR
            {
                if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                {
                    
                    btnRechazoCCR.Visible = false;                    
                    ddlListaWF.Visible = false;
                    lblObservacionTransicion.Visible = false;
                    txtObservacion.Visible = false;
                    btnTransicion.Visible = false;
                    btnFormularioMensual.Visible = false;
                    btnFormularioGlobal.Visible = false;
                }
                if (hfAprobaciones.Value == "3" && (int)Session["RolUsuario"] == 101)
                {
                    lblGeneracion.Visible = true;
                    txtCodGeneracion.Visible = true;
                    btnGenerar.Visible = true;
                    btnApruebaCCR.Visible = true;
                }
                if (hfAprobaciones.Value == "2" && (int)Session["RolUsuario"] == 137)
                {
                    lblGeneracion.Visible = true;
                    txtCodGeneracion.Visible = true;
                    btnGenerar.Visible = true;
                    btnApruebaCCR.Visible = true;
                }
                
                
            }

            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "W");
        }
        if (Convert.ToInt32(hfFlagM.Value)>=1 && hfFlagG.Value == "0")
        {
            if (FlagWF == 1)
            {
                if (hfNoImpresion.Value == "0")
                {

                    ddlListaWF.Visible = true;
                    ListaWF(iIdTramite, iIdGrupoBeneficio);
                    lblObservacionTransicion.Visible = true;
                    txtObservacion.Visible = true;
                    btnTransicion.Visible = true;
                    rfvObservacion.Visible = true;
                    rfvListaWF.Visible = true;
                }
            }
            
            if (Master.HabilitaTransaccion(3500290) == 1) //HABILITA BOTON PARA EL PRESIDENTE CCR
            {
                if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                {
                    lblGeneracion.Visible = true;
                    txtCodGeneracion.Visible = true;
                    btnGenerar.Visible = false;
                    btnFormularioMensual.Visible = true;
                    btnFormularioGlobal.Visible = false;
                    //true
                    btnConfirmacion.Visible = false;
                }
               
            }            
            
            btnApruebaCCR.Visible = false;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");

        }
        if (Convert.ToInt32(hfFlagM.Value) >=1 && hfFlagG.Value == "0")
        {
            if (FlagWF == 1)
            {
                if (hfNoImpresion.Value == "0")
                {

                    ListaWF(iIdTramite, iIdGrupoBeneficio);
                    ddlListaWF.Visible = true;
                    lblObservacionTransicion.Visible = true;
                    txtObservacion.Visible = true;
                    btnTransicion.Visible = true;
                    rfvObservacion.Visible = true;
                    rfvListaWF.Visible = true;
                }
            }
            if (Master.HabilitaTransaccion(3500290) == 1) //HABILITA BOTON PARA EL PRESIDENTE CCR
            {
                if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                {
                    txtCodGeneracion.Visible = true;
                    lblGeneracion.Visible = true;
                    
                    btnGenerar.Visible = false;
                    btnFormularioMensual.Visible = true;
                    btnFormularioGlobal.Visible = false;
                    btnConfirmacion.Visible = false;
                }
               
            }
            
            
            btnApruebaCCR.Visible = false;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");

        }
        if (hfFlagM.Value == "0" && Convert.ToInt32(hfFlagG.Value) >=1)
        {
            if (FlagWF == 1)
            {
                if (hfNoImpresion.Value == "0")
                {

                    ListaWF(iIdTramite, iIdGrupoBeneficio);
                    ddlListaWF.Visible = true;
                    lblObservacionTransicion.Visible = true;
                    txtObservacion.Visible = true;
                    btnTransicion.Visible = true;
                    rfvObservacion.Visible = true;
                    rfvListaWF.Visible = true;
                }
            }
            if (Master.HabilitaTransaccion(3500290) == 1) //HABILITA BOTON PARA EL PRESIDENTE CCR
            {
                if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                {
                    txtCodGeneracion.Visible = true;
                    lblGeneracion.Visible = true;
                    btnGenerar.Visible = false;
                    btnFormularioMensual.Visible = false;
                    btnFormularioGlobal.Visible = true;
                    btnConfirmacion.Visible = false;
                }
                
            }
            
            
            btnApruebaCCR.Visible = false;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");

        }
        if (Convert.ToInt32(hfFlagM.Value) >=1 && Convert.ToInt32(hfFlagG.Value) >=1)
        {
            if (FlagWF == 1)
            {
                if (hfNoImpresion.Value == "0")
                {

                    ListaWF(iIdTramite, iIdGrupoBeneficio);
                    ddlListaWF.Visible = true;
                    lblObservacionTransicion.Visible = true;
                    txtObservacion.Visible = true;
                    btnTransicion.Visible = true;
                    rfvObservacion.Visible = true;
                    rfvListaWF.Visible = true;
                }
            }
            if (Master.HabilitaTransaccion(3500290) == 1) //HABILITA BOTON PARA EL PRESIDENTE CCR
            {
                if ((int)Session["RolUsuario"] == 101 || (int)Session["RolUsuario"] == 137) //PRESIDENTE
                {
                    txtCodGeneracion.Visible = true;
                    lblGeneracion.Visible = true;
                    btnGenerar.Visible = false;
                    btnFormularioMensual.Visible = true;
                    btnFormularioGlobal.Visible = true;
                    btnConfirmacion.Visible = false;
                }
               
            }
            
            
            btnApruebaCCR.Visible = false;
            ListarComponentes(iIdTramite, iIdGrupoBeneficio, "X");
        }
    }
    private void ListaAprobaciones(int iIdTramite,int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "E";
        string sMensajeError = null;
        if (hfVersion.Value!="")
        {
            int iVersion = Convert.ToInt32(hfVersion.Value);

            gvDatosAprobacion.DataSource = ObjProcedimientoManual.ListaAprobaciones(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, ref sMensajeError);
            gvDatosAprobacion.DataBind();
        }
        
    }
    private void ListarComponentes(int iIdTramite, int iIdGrupoBeneficio, string cOperacion)
    {
        int iIdConexion = (int)Session["IdConexion"];
        // string cOperacion = "W";
        string sMensajeError = null;

        if (sMensajeError == null)
        {
            DataTable Componentes = null;
            Componentes = ObjProcedimientoValidoManual.DatosProcedimientoValidoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            if (Componentes != null && Componentes.Rows.Count > 0)
            {
                foreach (DataRow drDataRow in Componentes.Rows)
                {
                    hfVersion.Value = Convert.ToString(drDataRow["Version"]);
                }
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
            
            gvDatos.DataSource = Componentes;
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
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        
        DataTable dtDataTable = null;
        string user=null;
        string pass=null;
        try
        {
            
            dtDataTable = ObjSeguridad.privilegiosUsuario((string)Session["CuentaUsuario"]);
            if (dtDataTable != null && dtDataTable.Rows.Count > 0)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    user = Convert.ToString(drDataRow["CuentaUsuario"]);
                    pass = Convert.ToString(drDataRow["ClaveUsuario"]);

                    pass = ObjSeguridad.Desencriptar(pass);
                }
                string CodigoPsw;
                if (ViewState["CodGeneracion"] == "")
                {
                    CodigoPsw=txtCodGeneracion.Text;
                }
                else
                {
                    CodigoPsw=(string)ViewState["CodGeneracion"];
                }
                if (pass == CodigoPsw)
                {
                    ViewState["CodGeneracion"] = txtCodGeneracion.Text;
                    int iIdConexion = (int)Session["IdConexion"];
                    string cOperacion = "I";
                    string sMensajeError = null;
                    int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
                    int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
                    string sFechaCalculo;
                    if (txtFechaCalculo.Text=="")
                    {
                        sFechaCalculo = null;
                    }
                    else
                    {
                        sFechaCalculo = Convert.ToString(txtFechaCalculo.Text);
                    }

                    if (ObjEmisionFormularioCC.GenerarFormularioManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,sFechaCalculo, ref sMensajeError))
                    {
                        string msg = "La operacion se realizo con exito";
                        Master.MensajeOk(msg);
                        lblObservaciones.Visible = false;
                        ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                        ListaAprobaciones(iIdTramite, iIdGrupoBeneficio);
                        ConfirmacionImpresion();

                    }
                    else
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                    }
                    

                }
                else
                {
                    lblObservaciones.Text = "El codigo de generacion es incorrecto";
                    lblObservaciones.Visible = true;

                }

            }
            else
            {
                lblObservaciones.Text = "El codigo de generacion es incorrecto";
                lblObservaciones.Visible = true;

            }
        }

        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
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
        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteSeguimiento", " window.open('../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) +"&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        
    }
    protected void btnFormularioGlobal_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        string iIdTipoCC = "359";
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);
        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
        //string vUrl = ViewState["PreviousPage"].ToString();
        //vUrl = ObjSeguridad.URLEncode(vUrl);
        //Response.Redirect("../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + "&iIdTipoCC=" + iIdTipoCC + "&vUrl=" + Server.UrlEncode(vUrl) + " ");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteSeguimiento", " window.open('../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        ViewState["CuentaRechazos"] = 0;
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = Convert.ToInt32(hfVersion.Value);
        string sRUC = null;
        int iComponente = 0;
        string MensajeTotal = null;

        //CODIGO PARA VALIDAR LA CONTRASEÑA DE LA CCCR
        DataTable dtDataTable = null;
        string user = null;
        string pass = null;

         dtDataTable = ObjSeguridad.privilegiosUsuario((string)Session["CuentaUsuario"]);
         if (dtDataTable != null && dtDataTable.Rows.Count > 0)
         {
             foreach (DataRow drDataRow in dtDataTable.Rows)
             {
                 user = Convert.ToString(drDataRow["CuentaUsuario"]);
                 pass = Convert.ToString(drDataRow["ClaveUsuario"]);

                 pass = ObjSeguridad.Desencriptar(pass);
             }
             if (pass == txtCodGeneracion.Text)
             {

                 ViewState["CodGeneracion"] = txtCodGeneracion.Text;

                 foreach (GridViewRow row in gvDatos.Rows)
                 {
                     if (row.RowType == DataControlRowType.DataRow)
                     {
                         CheckBox chkAprobacion = (row.Cells[15].FindControl("chkAprobacion") as CheckBox);

                         if (chkAprobacion.Checked)
                         {
                             // en lugar de val guardar registro
                             sRUC = Convert.ToString(row.Cells[4].Text);
                             iComponente = Convert.ToInt32(row.Cells[2].Text);
                             int EstadoAprobacion = 1;

                             if (ObjProcedimientoValidoManual.ApruebaRechaza_CCR(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sRUC, iComponente, EstadoAprobacion, ref sMensajeError))
                             {
                                 string msg = "La operacion se realizo con exito";
                                 Master.MensajeOk(msg);
                                 lblObservaciones.Visible = false;


                             }
                             else
                             {
                                 string Error = "Error al realizar la operación";
                                 string DetalleError = sMensajeError;
                                 Master.MensajeError(Error, DetalleError);

                             }


                             MensajeTotal = MensajeTotal + sMensajeError;

                         }
                         else
                         {
                             sRUC = Convert.ToString(row.Cells[4].Text);
                             iComponente = Convert.ToInt32(row.Cells[2].Text);
                             int EstadoAprobacion = 0;

                             if (ObjProcedimientoValidoManual.ApruebaRechaza_CCR(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sRUC, iComponente, EstadoAprobacion, ref sMensajeError))
                             {
                                 string msg = "La operacion se realizo con exito";
                                 Master.MensajeOk(msg);
                                 lblObservaciones.Visible = false;


                             }
                             else
                             {
                                 string Error = "Error al realizar la operación";
                                 string DetalleError = sMensajeError;
                                 Master.MensajeError(Error, DetalleError);
                             }


                             MensajeTotal = MensajeTotal + sMensajeError;

                         }
                     }
                 }

                 Permisos(iIdTramite, iIdGrupoBeneficio);
                 ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                 ListaAprobaciones(iIdTramite, iIdGrupoBeneficio);
                 if ((int)ViewState["CuentaRechazos"] != 0)
                 {

                     lblGeneracion.Visible = true;
                     txtCodGeneracion.Visible = true;
                     btnGenerar.Visible = false;
                 }
             }
             else
             {
                 lblObservaciones.Text = "El codigo de generacion es incorrecto";
                 lblObservaciones.Visible = true;
                 Permisos(iIdTramite, iIdGrupoBeneficio);
                 ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                 ListaAprobaciones(iIdTramite, iIdGrupoBeneficio);

             }

         }
         else
         {
             lblObservaciones.Text = "El codigo de generacion es incorrecto";
             lblObservaciones.Visible = true;

         }


      
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
    //            #region WF

    //            //CODIGO DE INTEGRACION CON WF
    //            clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
    //            ObjINodo.iIdConexion = iIdConexion;
    //            ObjINodo.iIdTramite = iIdTramite;
    //            ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
    //            ObjINodo.sNemoNodoOrig = "CCR";
    //            ObjINodo.sEstado = "I";
    //            if (ObjINodo.ObtieneActividadActiva())
    //            {
    //                clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
    //                ObjINodoCpto.iIdConexion = iIdConexion;
    //                ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
    //                ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
    //                ObjINodoCpto.sIdConcepto = "FCALC_MANUAL";
    //                ObjINodoCpto.bValorBoolean = true;
    //                if (ObjINodoCpto.Grabar())
    //                {
    //                    ListaWF(iIdTramite, iIdGrupoBeneficio);
    //                    btnTransicion.Visible = true;
    //                    rfvObservacion.Visible = true;
    //                    rfvListaWF.Visible = true;
    //                    txtObservacion.Visible = true;
    //                    ddlListaWF.Visible = true;
    //                    string msg = "La operacion se realizo con exito";
    //                    Master.MensajeOk(msg);

    //                }
    //                else
    //                {
    //                    string Error = "Error al realizar la operación";
    //                    string DetalleError = ObjINodo.sMensajeError;
    //                    Master.MensajeError(Error, DetalleError);
    //                }
    //            }
    //            #endregion
    //        }
    //        if (FlagWF == 0)
    //        {                
    //            if (ObjEmisionFormularioCC.CuatroTrentaInterno(iIdConexion, "J", iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
    //            {
    //                string msg = "La operacion se realizo con exito";
    //                Master.MensajeOk(msg);
    //                Response.Redirect("../CertificacionCC/wfrmListaTramitesParaEmision.aspx");
    //            }
    //            else
    //            {
    //                string Error = "Error al realizar la operación";
    //                string DetalleError = sMensajeError;
    //                Master.MensajeError(Error, DetalleError);
    //            }

    //        }
    //    }
    //    else
    //    {
    //        string Error = "Error al realizar la operación";
    //        string DetalleError = sMensajeError;
    //        Master.MensajeError(Error, DetalleError);
    //    }
    //}

    private void ConfirmacionImpresion()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        if (ObjEmisionFormularioCC.RegistraImpresion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
        {           
            if (FlagWF == 0)
            {
                if (ObjEmisionFormularioCC.CuatroTrentaInterno(iIdConexion, "J", iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    Response.Redirect("../CertificacionCC/wfrmListaTramitesParaEmision.aspx");
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }

            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void btnConfirmacionRechazo_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        
            //CODIGO DE INTEGRACION CON WF
            clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
            ObjINodo.iIdConexion = iIdConexion;
            ObjINodo.iIdTramite = iIdTramite;
            ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
            ObjINodo.sNemoNodoOrig = "CCR";
            ObjINodo.sEstado = "I";
            if (ObjINodo.ObtieneActividadActiva())
            {
                clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
                ObjINodoCpto.iIdConexion = iIdConexion;
                ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                ObjINodoCpto.sIdConcepto = "FCALC_MANUAL";
                ObjINodoCpto.bValorBoolean = false;
                if (ObjINodoCpto.Grabar())
                {
                    ListaWF(iIdTramite, iIdGrupoBeneficio);
                    btnTransicion.Visible = true;
                    rfvObservacion.Visible = true;
                    rfvListaWF.Visible = true;
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = ObjINodo.sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
        
       

    }
    protected void btnTransicion_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);

        //CODIGO DE INTEGRACION CON WF
        clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
        ObjINodo.iIdConexion = iIdConexion;
        ObjINodo.iIdTramite = iIdTramite;
        ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
        ObjINodo.sNemoNodoOrig = "CCR";
        ObjINodo.sEstado = "I";
        if (ObjINodo.ObtieneActividadActiva())
        {
            ObjINodo.iIdConexion = iIdConexion;
            ObjINodo.iIdInstancia = ObjINodo.iIdInstancia;
            ObjINodo.iSecuencia = ObjINodo.iSecuencia;                    
            ObjINodo.sComentarios =txtObservacion.Text;
            ObjINodo.sIdListaNodoTrg = ddlListaWF.SelectedValue;
            ObjINodo.bFlagManual = false;

            if (ObjINodo.RealizaTransicion())
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);

            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = ObjINodo.sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
           
        }



    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {        
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }


    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e) //Adicionado
    {
        if (e.CommandName == "cmdCertificacionSalario")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvDatos.DataKeys[Index].Values["IdTramite"]);
                int iIdTipoTramite = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);


                if (iIdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (iIdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
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
}