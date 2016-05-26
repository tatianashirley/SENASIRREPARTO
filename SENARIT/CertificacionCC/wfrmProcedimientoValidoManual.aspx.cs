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


public partial class CertificacionCC_wfrmProcedimientoValidoManual : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    clsParametrizacion ObjParametrizacion = new clsParametrizacion();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsTramiteAsignado ObjTramite = new clsTramiteAsignado();
    private Control UpdatePanel1;
    int FlagWF = 0;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            rdbCertSalMin.Visible = false;
            btnImpresionCertificacion.Visible = false;
            ViewState["PreviousPage"] = Request.UrlReferrer; //Saves the Previous page url in ViewState
            //btnTraObservado.Visible = false;

            CambiarInterfaz();
            pnlFormularioModifica.Visible = false;
            int iIdTramite = 0;
            int iIdGrupoBeneficio = 0;
            if (Request.QueryString["iIdTramite"] != null)
            {
                //iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
                //iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));
                iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                ViewState["iIdTramite"] = iIdTramite;
                ViewState["iIdGrupoBeneficio"] = iIdGrupoBeneficio;

                hfIdTramite.Value = Convert.ToString(iIdTramite);
                hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);
                ListaInformes(iIdTramite, iIdGrupoBeneficio);
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "Q";
                string sMensajeError = null;
                DataTable tblListaDatosAsegurado = null;
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
                        lblTramite.Text = Convert.ToString(drDataRow["NumeroTramiteCrenta"]);
                        lblFechaInicio.Text = Convert.ToString(drDataRow["FechaInicioTramite"]);
                        hfEstadoTramite.Value = Convert.ToString(drDataRow["EstadoTramite"]);
                        lblTipoReproceso.Text = Convert.ToString(drDataRow["TipoReproceso"]);
                        lblFechaAsignacion.Text = Convert.ToString(drDataRow["FechaAsignacion"]);
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
                    lblEstadoTramite.Text = "-Tramite en reproceso";
                    lblEstadoTramite.Visible = true;
                }

                if (Master.HabilitaTransaccion(3500280) == 1)
                {
                    pnlComponentesOld.Visible = true;
                    btnAprobar.Visible = false;
                    lblAprobar.Visible = false;
                    btnReprobar.Visible = false;
                    lblReprobar.Visible = false;
                    //Visualizar Primer Grid
                    ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible=false;
                }
                if (Master.HabilitaTransaccion(3500282) == 1)
                {
                    pnlComponentesNew.Visible = true;
                    //Visualizar Grid de Certificacion
                    ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                    btnAprobar.Visible = false;
                    lblAprobar.Visible = false;
                    btnReprobar.Visible = false;
                    lblReprobar.Visible = false;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible=false;
                }
                if (Master.HabilitaTransaccion(3500285) == 1)
                {
                    pnlComponentesNew.Visible = true;
                    //Visualizar Grid de Certificacion
                    ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnReprobar.Visible = true;
                    lblReprobar.Visible = true;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible=false;

                }
                if (Master.HabilitaTransaccion(3500286) == 1)
                {

                    btnApruebaCertificacion.Visible = true;
                    lblApruebaCertificacion.Visible=true;

                }
                if ((int)Session["RolUsuario"] == 9) //Verificador
                {
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnReprobar.Visible = false;
                    lblReprobar.Visible = false;
                    btnInsertarCertificacion.Visible = true;                    
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible=false;
                }
                if ((int)Session["RolUsuario"] == 8) //Revisor
                {
                    if (FlagWF == 1)
                    {
                        //btnTraObservado.Visible = true;
                    }
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnReprobar.Visible = true;
                    lblReprobar.Visible = true;
                    btnInsertarCertificacion.Visible = false;
                    lblInsertarCertificacion.Visible = false;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible=false;
                    btnIngresarInforme.Visible = false;
                    lblIngresarInforme.Visible = false;
                                        
                }
                if ((int)Session["RolUsuario"] == 7) //Control
                {
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnReprobar.Visible = true;
                    lblReprobar.Visible = true;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible = false;
                    btnInsertarCertificacion.Visible = false;
                    btnIngresarInforme.Visible = false;
                    lblIngresarInforme.Visible = false;
                    lblInsertarCertificacion.Visible = false;
                }
                if ((int)Session["RolUsuario"] == 14) //Responsable de Certificacion
                {
                    btnAprobar.Visible = false;
                    lblAprobar.Visible = false;
                    btnReprobar.Visible = true;
                    lblReprobar.Visible = true;
                    btnApruebaCertificacion.Visible = true;
                    lblApruebaCertificacion.Visible=true;
                    btnImprimeCorrelativo.Visible = false;
                    lblImprimeCorrelativo.Visible = false;
                    btnInsertarCertificacion.Visible = false;
                    lblInsertarCertificacion.Visible = false;
                }
            }

        }

    }
    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);

        ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);

        ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);

    }

    #region INTERFAZ
    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtDescripcionRUC, ddlTipoDocumento);
        AgregarJSAtributos(txtRUC, txtDetRUC);
        AgregarJSAtributos(txtDetRUC, ddlTipoDocumento);
        AgregarJSAtributos(txtPeriodoSalario, txtSalarioCotizable);
        AgregarJSAtributos(txtSalarioCotizable, ddlMonedaSalario);
        //AgregarJSAtributos(txtGlosaSalario, btnInsertar);
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");
            //controlActual.Attributes.Add("onFocus", "  JavaScript:this.style.backgroundColor='#ffff00'; SelectAll(this)");
            //controlActual.Attributes.Add("onBlur", "  JavaScript:this.style.backgroundColor='#ffffff'; return focusNext('" + ctrlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "', null)  ");

        }
    }
    #endregion
    // Lista los componentes que se estan certificando o no
    private void ListarComponentesNew(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        string sMensajeError = null;

        gvDatosComponentes.DataSource = ObjProcedimientoValidoManual.DatosProcedimientoValidoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        gvDatosComponentes.DataBind();

    }
    private void MonedaNacional(int IdMonedaSalario)
    {

        DataTable tblMoneda = null;
        tblMoneda = ObjProcedimientoValidoManual.ListaDetalleClasificador(13);
        DataView dv = new DataView(tblMoneda);

        dv.RowFilter = "IdDetalleClasificador in (323,324)";
        ddlMonedaSalario.DataSource = dv;
        ddlMonedaSalario.DataValueField = "IdDetalleClasificador";
        ddlMonedaSalario.DataTextField = "DescripcionDetalleClasificador";
        ddlMonedaSalario.DataBind();
        ddlMonedaSalario.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlMonedaSalario.SelectedValue = Convert.ToString(IdMonedaSalario);

    }
    //Lista los componentes del tramite registrado en registro
    private void ListarDatosAsegurado(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;

        if (sMensajeError == null)
        {

            gvDatos.DataSource = ObjProcedimientoValidoManual.DatosProcedimientoValidoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            gvDatos.DataBind();
            //if (sMensajeError != null)
            //{
            //    string Error = "Error al realizar la operación";
            //    string DetalleError = sMensajeError;
            //    Master.MensajeError(Error, DetalleError);
            //}
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }


    }
    // Codigo que oculta el boton de certificacion
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iIdTramite = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            int iVersion = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["Version"]);
            string sRUC = Convert.ToString(gvDatos.DataKeys[e.Row.RowIndex].Values["RUC"]);
            string iComponente = Convert.ToString(gvDatos.DataKeys[e.Row.RowIndex].Values["Componente"]);
            int iIdEstadoComponente = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["IdEstadoComponente"]);

            
            // La transaccion 3500281 esta habilitada solo para el Verificador para insertar una certificacion            
            //if (Master.HabilitaTransaccion(3500281) == 1)
            //{
            //    // Si los componentes se encuentran en estado 902=PENDIENTE            
            //    if ((iIdEstadoComponente == 902))
            //    {
            //        e.Row.FindControl("imgCertificar").Visible = false;
            //    }
            //    else
            //    {
            //        e.Row.FindControl("imgCertificar").Visible = true;
            //    }
            //}
            //else
            //{
            //    e.Row.FindControl("imgCertificar").Visible = false;
            //}
        }
    }
    //Operaciones que presenta el grid view (Certificar)
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdCertificar")
        {
            try
            {

                //this.pnlFormularioModifica_ModalPopupExtender.Show();
                txtDescripcionRUC.Text = "";
                chkRuc.Checked = false;
                chkSalarioCotizable.Checked = false;
                pnlBusqueda.Visible = false;
                txtSalarioCotizable.ReadOnly = true;
                hdfOperacion.Value = "I";
                txtGlosaSalario.Text = "";


                int Index = Convert.ToInt32(e.CommandArgument);
                gvDatos.Rows[Index].BackColor = Color.FromName("#FFCC00");
                pnlFormularioModifica.Visible = true;
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatos.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatos.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = 0;//Convert.ToInt32(gvDatos.DataKeys[Index].Values["Componente"]);



                txtRUC.Text = (string)ViewState["sRUC"];
                DataTable tblDescripcionRUC = null;
                tblDescripcionRUC = ObjProcedimientoValidoManual.DescripcionRuc((string)ViewState["sRUC"]);

                foreach (DataRow drDataRow in tblDescripcionRUC.Rows)
                {
                    txtDetRUC.Text = Convert.ToString(drDataRow["NombreEmpresa"]);
                    txtDescripcionSector.Text = Convert.ToString(drDataRow["DescripcionSector"]);

                }
                //txtDetRUC.Text = ObjProcedimientoValidoManual.Descripcion_RUC((string)ViewState["sRUC"]);

                string sPeriodoSalario = (Convert.ToString(gvDatos.DataKeys[Index].Values["PeriodoSalario"])).Substring(0, 7);
                string sSalarioCotizable = Convert.ToString(gvDatos.DataKeys[Index].Values["SalarioCotizable"]);
                ViewState["SalarioCotizable"] = sSalarioCotizable.Replace(",", "").ToString();
                txtPeriodoSalario.Text = sPeriodoSalario;
                txtSalarioCotizable.Text = Convert.ToString(sSalarioCotizable);

                //Calcula el salario cotizalble actualizado
                sSalarioCotizable = sSalarioCotizable.Replace(",", "").ToString();


                int IdTipoDocSalario = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdTipoDocSalario"]);
                int IdMonedaSalario = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdMonedaSalario"]);
                int IdParametrizacion = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdParametrizacion"]);


                ddlTipoDocumento.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(40);
                ddlTipoDocumento.DataValueField = "IdDetalleClasificador";
                ddlTipoDocumento.DataTextField = "DescripcionDetalleClasificador";
                ddlTipoDocumento.DataBind();
                ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlTipoDocumento.SelectedValue = Convert.ToString(IdTipoDocSalario);
                ObtenerTipoMoneda(sPeriodoSalario);

                //ddlMonedaSalario.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(13);
                //ddlMonedaSalario.DataValueField = "IdDetalleClasificador";
                //ddlMonedaSalario.DataTextField = "DescripcionDetalleClasificador";
                //ddlMonedaSalario.DataBind();
                //ddlMonedaSalario.Items.Insert(0, new ListItem("Seleccione...", "0"));
                //ddlMonedaSalario.SelectedValue = Convert.ToString(IdMonedaSalario);

                Parametrizacion(447, 448, 0);
                CalculoSalarioCotizableActualizado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"], (string)ViewState["sRUC"], sPeriodoSalario, sSalarioCotizable);
                txtRUC.Focus();
                ComibolSalarioConvenio((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"], (string)ViewState["sRUC"]);


            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    //Añadir componente certificado o no
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {

            
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = hdfOperacion.Value;
            int iIdTramite = (int)ViewState["iIdTramite"];
            int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
            int iVersion = (int)ViewState["iVersion"];
            int iComponente = (int)ViewState["iComponente"];
            string sRUC = txtRUC.Text;
            int iIdTipoDocumento = Convert.ToInt32(ddlTipoDocumento.SelectedValue);
            string sPeriodoSalario = txtPeriodoSalario.Text;
            sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);
            string sSalarioCotizable = (txtSalarioCotizable.Text).Replace(",", "");
            string sSalarioCotizableActualizado = (txtSalarioCotizableActualizado.Text).Replace(",", "");
            int iMonedaSalario = Convert.ToInt32(ddlMonedaSalario.SelectedValue);
            int ?iIdParametrizacion = Convert.ToInt32(ddlParametrizacion.SelectedValue);
            if (iIdParametrizacion == 0)
            {
                iIdParametrizacion = null;
            }
            //int iIdParametrizacion = 1;
            string sGlosa = txtGlosaSalario.Text;
            sGlosa = sGlosa.Replace("\n", "<BR/>");
            sGlosa = sGlosa.ToUpper();
            string sMensajeError = null;
            string sSector = txtDescripcionSector.Text;
            int iCertificado;
            if (chbCertificado.Checked == true)
            {
                iCertificado = 1;
            }
            else
            {
                iCertificado = 0;
            }
            if (ObjProcedimientoValidoManual.InsertaModificaComponentes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iComponente, sRUC, iIdTipoDocumento, sPeriodoSalario, sSalarioCotizable, sSalarioCotizableActualizado, iMonedaSalario, iIdParametrizacion, sGlosa, iCertificado, sSector, ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                pnlFormularioModifica.Visible = false;

            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }





    }
    // Cierra popup
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlFormularioModifica.Visible = false;
        txtSalarioCotizable.AutoPostBack = false;
        txtDescripcionRUC.AutoPostBack = false;
        txtDescripcionRUC.Text = "";
    }

    //Se visualiza el panel de busqueda de Razon Social o RUC
    protected void chkRuc_CheckedChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        if (chkRuc.Checked == true)
        {
            pnlBusqueda.Visible = true;
            txtDescripcionRUC.Focus();
            txtDescripcionRUC.AutoPostBack = true;
        }
        else
        {
            pnlBusqueda.Visible = false;
            txtDescripcionRUC.AutoPostBack = false;
        }
    }
    //Se habilita la opcion de poder modificar el salario cotizable
    protected void chkSalarioCotizable_CheckedChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show(); 
        if (chkSalarioCotizable.Checked == true)
        {

            txtSalarioCotizable.ReadOnly = false;
            txtSalarioCotizable.Focus();
            txtSalarioCotizable.AutoPostBack = true;


        }
        else
        {
            txtSalarioCotizable.ReadOnly = true;
            txtSalarioCotizable.AutoPostBack = false;

        }
    }

    //Ejecuta el metodo de calculo del salario cotizable actualizado
    protected void txtSalarioCotizable_TextChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show(); 
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        string sRUC = txtRUC.Text;
        string sPeriodoSalario = txtPeriodoSalario.Text;
        sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);
        string sSalarioCotizable = Convert.ToString(txtSalarioCotizable.Text);
        sSalarioCotizable = sSalarioCotizable.Replace(",", "").ToString();
        //llamar a funcion para q me devuelva el SalarioCotizableActualizado
        CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sRUC, sPeriodoSalario, sSalarioCotizable);



    }
    //Realiza el calculo del Salario Cotizable Actualizado
    private void CalculoSalarioCotizableActualizado(int iIdTramite, int iIdGrupoBeneficio, string sRUC, string sPeriodoSalario, string sSalarioCotizable)
    {

        string sFechaCalculo = null; // con finalidad de hacer pruebas la fecha de calculo
        string sTipoAct = "N";


        DataTable tblSalarioCotizableAztualizado = null;
        tblSalarioCotizableAztualizado = ObjProcedimientoValidoManual.CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sFechaCalculo, sTipoAct, sPeriodoSalario, sSalarioCotizable, sRUC);
        if (tblSalarioCotizableAztualizado != null)
        {
            foreach (DataRow drDataRow in tblSalarioCotizableAztualizado.Rows)
            {
                txtSalarioCotizableActualizado.Text = Convert.ToString(drDataRow["SalarioCotizableAct"]);

            }
        }


        //txtSalarioCotizableActualizado.Text = "100.90";


    }
    private void CalculoSalarioMinimo(int iIdTramite, int iIdGrupoBeneficio, string sRUC, string sPeriodoSalario, string sSalarioCotizable)
    {

        string sFechaCalculo = null; // con finalidad de hacer pruebas la fecha de calculo
        string sTipoAct = "N";


        DataTable tblSalarioCotizableAztualizado = null;
        tblSalarioCotizableAztualizado = ObjProcedimientoValidoManual.CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sFechaCalculo, sTipoAct, sPeriodoSalario, sSalarioCotizable, sRUC);
        if (tblSalarioCotizableAztualizado != null)
        {
            foreach (DataRow drDataRow in tblSalarioCotizableAztualizado.Rows)
            {
                txtSalarioCotizable.Text = Convert.ToString(drDataRow["SalarioMinimo"]);
                txtSalarioCotizableActualizado.Text = Convert.ToString(drDataRow["SalarioCotizableAct"]);

            }
        }
    }
    //Ejectua el metodo de busqueda de la Razon Social o Ruc
    protected void txtDescripcionRUC_TextChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        string sDescripcionRuc = txtDescripcionRUC.Text;
        int posicionfinal = sDescripcionRuc.IndexOf('/');
        string sRuc = sDescripcionRuc.Substring(4, posicionfinal - 4);
        txtRUC.Text = sRuc;
        DataTable tblDescripcionRUC = null;
        tblDescripcionRUC = ObjProcedimientoValidoManual.DescripcionRuc(sRuc);
        foreach (DataRow drDataRow in tblDescripcionRUC.Rows)
        {
            txtDetRUC.Text = Convert.ToString(drDataRow["NombreEmpresa"]);
            txtSector.Text = Convert.ToString(drDataRow["IdSector"]);
            txtDescripcionSector.Text = Convert.ToString(drDataRow["DescripcionSector"]);

        }
    }
    //Codigo que oculta el boton editar en el caso de no certificado)
    protected void gvDatosComponentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iIdTramite = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            int iVersion = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["Version"]);
            string sRUC = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["RUC"]);
            string iComponente = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["Componente"]);
            int iIdEstadoComponente = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdEstadoComponente"]);
            string sPeriodoSalario = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["PeriodoSalario"]);
            if ((int)Session["RolUsuario"] == 14) //Responsable de Certificacion
            {
                e.Row.FindControl("imgCertificacionSalarioCorrelativo").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgCertificacionSalarioCorrelativo").Visible = false;
            }
            if (sPeriodoSalario != null)
            {
                ViewState["sPeriodoSalario"] = sPeriodoSalario;
                txtPeriodoSalario.Enabled = false;
            }

            hfVersion.Value = Convert.ToString(iVersion);

            if ((int)Session["RolUsuario"] == 9) //Verificador
            {
                // La transaccion 3500283 esta habilitada solo para el Verificador para insertar una certificacion
                if (Master.HabilitaTransaccion(3500283) == 1)
                {
                    // Si los componentes se encuentran en estado 906=NO CERTIFICADO O 903= APROBADO
                    if (iIdEstadoComponente == 903)
                    {
                        e.Row.FindControl("imgEditar").Visible = false;
                        e.Row.FindControl("imgEliminar").Visible = false;
                    }
                    else
                    {
                        if (iIdEstadoComponente == 906)
                        {
                            e.Row.FindControl("imgEditar").Visible = false;
                            e.Row.FindControl("imgEliminar").Visible = true;
                        }
                        else
                        {
                            if (iIdEstadoComponente == 902)
                            {
                                e.Row.FindControl("imgEditar").Visible = true;
                                e.Row.FindControl("imgEliminar").Visible = true;
                            }
                            else
                            {
                                e.Row.FindControl("imgEditar").Visible = false;
                                e.Row.FindControl("imgEliminar").Visible = false;
                            }
                        }


                    }
                }
                else
                {
                    e.Row.FindControl("imgEditar").Visible = false;
                    e.Row.FindControl("imgEliminar").Visible = false;
                    gvDatosComponentes.Columns[10].Visible = false;

                }
            }
            else
            {
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;

                gvDatosComponentes.Columns[10].Visible = false;



            }


        }
    }
    //Operaciones que presenta el grid view de los componentes certificados o no 
    protected void gvDatosComponentes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            try
            {

                //this.pnlFormularioModifica_ModalPopupExtender.Show();
                txtDescripcionRUC.Text = "";
                chkRuc.Checked = false;
                chkSalarioCotizable.Checked = false;
                pnlBusqueda.Visible = false;
                txtSalarioCotizable.ReadOnly = true;
                hdfOperacion.Value = "U";


                int Index = Convert.ToInt32(e.CommandArgument);
                gvDatosComponentes.Rows[Index].BackColor = Color.FromName("#FFCC00");
                pnlFormularioModifica.Visible = true;
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);




                txtRUC.Text = (string)ViewState["sRUC"];
                DataTable tblDescripcionRUC = null;
                tblDescripcionRUC = ObjProcedimientoValidoManual.DescripcionRuc((string)ViewState["sRUC"]);
                foreach (DataRow drDataRow in tblDescripcionRUC.Rows)
                {
                    txtDetRUC.Text = Convert.ToString(drDataRow["NombreEmpresa"]);
                    txtDescripcionSector.Text = Convert.ToString(drDataRow["DescripcionSector"]);

                }
                //txtDetRUC.Text = ObjProcedimientoValidoManual.Descripcion_RUC((string)ViewState["sRUC"]);

                string sPeriodoSalario = (Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["PeriodoSalario"])).Substring(0, 7);
                string sSalarioCotizable = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["SalarioCotizable"]);
                ViewState["SalarioCotizable"] = sSalarioCotizable.Replace(",", "").ToString();
                sSalarioCotizable = sSalarioCotizable.Replace(",", "").ToString();
                //PeriodoSalario=PeriodoSalario.Replace("/", "").ToString();
                txtPeriodoSalario.Text = sPeriodoSalario;
                txtSalarioCotizable.Text = Convert.ToString(sSalarioCotizable);
                //Calcula el salario cotizalble actualizado                
                int IdTipoDocSalario = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTipoDocSalario"]);
                int IdMonedaSalario = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdMonedaSalario"]);
                int IdParametrizacion = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdParametrizacion"]);
                string GlosaSalario = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["GlosaSalario"]);
                GlosaSalario = GlosaSalario.Replace("<BR/>", "\n");
                GlosaSalario = GlosaSalario.Replace("<BR>", "\n");
                int Certificado = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Certificado"]);
                int iCertificado = 0;

                if (Certificado == 1)
                {
                    chbCertificado.Checked = true;
                    iCertificado = 448;
                }
                else
                {
                    chbCertificado.Checked = false;
                    iCertificado = 449;
                }

                ddlTipoDocumento.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(40);
                ddlTipoDocumento.DataValueField = "IdDetalleClasificador";
                ddlTipoDocumento.DataTextField = "DescripcionDetalleClasificador";
                ddlTipoDocumento.DataBind();
                ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlTipoDocumento.SelectedValue = Convert.ToString(IdTipoDocSalario);

                ddlMonedaSalario.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(13);
                ddlMonedaSalario.DataValueField = "IdDetalleClasificador";
                ddlMonedaSalario.DataTextField = "DescripcionDetalleClasificador";
                ddlMonedaSalario.DataBind();
                ddlMonedaSalario.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlMonedaSalario.SelectedValue = Convert.ToString(IdMonedaSalario);

                Parametrizacion(447, iCertificado, IdParametrizacion);


                txtGlosaSalario.Text = GlosaSalario;


                CalculoSalarioCotizableActualizado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"], (string)ViewState["sRUC"], sPeriodoSalario, sSalarioCotizable);

                txtRUC.Focus();


            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }

        }
        if (e.CommandName == "cmdCerti")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                pnlFormularioModifica.Visible = false;

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "G";
                string sMensajeError = null;

                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);

                clsSeguridad ObjSeguridad = new clsSeguridad();
                string iIdTramite = Convert.ToString(ViewState["iIdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(ViewState["iIdGrupoBeneficio"]);
                string iComponente = Convert.ToString(ViewState["iComponente"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                iComponente = ObjSeguridad.URLEncode(iComponente);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);




            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdCertificacionSalarioCorrelativo")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "G";
                string sMensajeError = null;

                int Index = Convert.ToInt32(e.CommandArgument);
               
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);
                string iIdTramite = Convert.ToString(ViewState["iIdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(ViewState["iIdGrupoBeneficio"]);
                string iComponente = Convert.ToString(ViewState["iComponente"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
                iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                iComponente = ObjSeguridad.URLEncode(iComponente);
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

              
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomaticoCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdEliminar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                pnlFormularioModifica.Visible = false;

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "D";
                string sMensajeError = null;

                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);

                if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, (int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"], (int)ViewState["iVersion"], (string)ViewState["sRUC"], (int)ViewState["iComponente"], ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListarComponentesNew((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);
                    ListarDatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }


            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void ddlParametrizacion_SelectedIndexChanged(object sender, EventArgs e)
    {

        int iIdParametrizacion = Convert.ToInt32(ddlParametrizacion.SelectedValue);
        string Glosa = ObjParametrizacion.ListaParametrizacion(0, 0, iIdParametrizacion, txtPeriodoSalario.Text, null).Rows[0]["Glosa"].ToString();

        txtGlosaSalario.Text = Glosa;
    }

    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = -99;
        if (hfVersion.Value == "")
        {
            hfVersion.Value = "0";
        }

        if (Convert.ToInt32(hfVersion.Value) != -99)
        {
            iVersion = Convert.ToInt32(hfVersion.Value);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = "No existe ninguna certificacion a aprobar";
            Master.MensajeError(Error, DetalleError);
        }


        //CODIGO PARA WF

        string Par1 = null;
        string Par2 = null;
        string Par3 = null;
        string Par4 = null;
        string Par5 = null;
        string sObservacion = null;


        if ((int)Session["RolUsuario"] == 9) // Verificador
        {
            Par1 = "VERIFICACION";
            Par2 = "VERIFICACION_OK";

            DataTable tblVerificador = null;
            tblVerificador = ObjTramite.ListaParametrosWF(iIdConexion, "S", iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            if (tblVerificador != null)
            {
                foreach (DataRow drDataRow in tblVerificador.Rows)
                {
                    Par3 = Convert.ToString(drDataRow["IdUsuarioSuperior"]);

                }
            }
            sObservacion = "Asignacion Revisor";
        }

        if ((int)Session["RolUsuario"] == 8) // Revisor
        {
            Par1 = "REVISION";
            Par2 = "REVISION_OK";

            sObservacion = "Asignacion ArchivoTransitorio";
        }
        if ((int)Session["RolUsuario"] == 7) // Control
        {
            Par1 = "QCTRL";
            Par2 = "QCTRL_OK";
            sObservacion = "Asignacion ArchivoTransitorio para aprobacion VoBo";
        }



        if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, null, 0, ref sMensajeError))
        {
            if (FlagWF == 1)
            {
                #region PARTE I WF


                //string msg = "La operacion se realizo con exito";
                //Master.MensajeOk(msg);
                //System.Threading.Thread.Sleep(10);

                //CODIGO DE INTEGRACION CON WF


                clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
                ObjINodo.iIdConexion = iIdConexion;
                ObjINodo.iIdTramite = iIdTramite;
                ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
                ObjINodo.sNemoNodoOrig = Par1;
                ObjINodo.sEstado = "I";
                if (ObjINodo.ObtieneActividadActiva())
                {
                    clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
                    ObjINodoCpto.iIdConexion = iIdConexion;
                    ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                    ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                    ObjINodoCpto.sIdConcepto = Par2;
                    ObjINodoCpto.bValorBoolean = true;
                    if (ObjINodoCpto.Grabar())
                    {
                        ObjINodoCpto.iIdConexion = iIdConexion;
                        ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                        ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                        ObjINodoCpto.sIdConcepto = "ID_USUARIO";
                        ObjINodoCpto.iValorInt = Convert.ToInt32(Par3);
                        if (ObjINodoCpto.Grabar())
                        {
                            ObjINodoCpto.iIdConexion = iIdConexion;
                            ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                            ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                            ObjINodoCpto.sIdConcepto = "SIN_DATOS_CERTIF";
                            ObjINodoCpto.bValorBoolean = false;
                            if (ObjINodoCpto.Grabar())
                            {
                                string msg = "La aprobacion se realizo con exito";
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
                    else
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = ObjINodo.sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                    }

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = ObjINodo.sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }



                if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
                {
                    //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
                    Response.Redirect(ViewState["PreviousPage"].ToString());
                }


                #endregion
            }
            if (FlagWF == 0)
            {
                #region WFArticulador

                /*Codigo WFArticulador*/
                string msg = "La Aprobacion se realizo con exito";
                Master.MensajeOk(msg);

                if (ObjProcedimientoValidoManual.AsignacionWFArticulador(iIdConexion, "I", iIdTramite, iIdGrupoBeneficio, Convert.ToInt32(Par3), sObservacion, ref sMensajeError))
                {
                    msg = "La Aprobacion se realizo con exito";
                    Master.MensajeOk(msg);
                    pnlComponentesNew.Visible = false;
                    
                    btnIngresarInforme.Visible = false;
                    lblIngresarInforme.Visible = false;
                    btnReprobar.Visible = false;
                    lblReprobar.Visible = false;
                    btnInsertarCertificacion.Visible = false;
                    lblInsertarCertificacion.Visible = false;
                    btnAprobar.Visible = false;
                    lblAprobar.Visible = false;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible = false;
                    pnlComponentesOld.Visible = false;

                    // Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }


                #endregion
            }

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }

    protected void btnRechaza_Click(object sender, EventArgs e)
    {
        if (FlagWF == 1)
        {
            #region PARTE WF RECHAZO
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "A";
            string sMensajeError = null;
            int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
            int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
            int iVersion = Convert.ToInt32(hfVersion.Value);

            //CODIGO PARA WF

            string Par1 = null;
            string Par2 = null;
            string Par3 = null;
            string Par4 = null;
            string Par5 = null;


            if ((int)Session["RolUsuario"] == 9) // Verificador
            {
                Par1 = "VERIFICACION";
                Par2 = "VERIFICACION_OK";
            }
            if ((int)Session["RolUsuario"] == 8) // Revisor
            {
                Par1 = "REVISION";
                Par2 = "REVISION_OK";
            }
            if ((int)Session["RolUsuario"] == 7) // Control
            {
                Par1 = "QCTRL";
                Par2 = "REVISION_OK";
            }


            #region PARTE III WF
            /*
        ////CODIGO DE INTEGRACION CON WF

            clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
            ObjINodo.iIdConexion = iIdConexion;
            ObjINodo.iIdTramite = iIdTramite;
            ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
            ObjINodo.sNemoNodoOrig = Par1;
            ObjINodo.sEstado = "I";
            if (ObjINodo.ObtieneActividadActiva())
            {
                clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
                ObjINodoCpto.iIdConexion = iIdConexion;
                ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                ObjINodoCpto.sIdConcepto = Par2;
                ObjINodoCpto.bValorBoolean = false;
                if (ObjINodoCpto.Grabar())
                { 
                    string msg = "Se rechazo la certificacion con exito";
                    Master.MensajeOk(msg);
                    

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = ObjINodo.sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }

            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = ObjINodo.sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }*/
            #endregion

            if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
            {
                //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
            #endregion
        }
        if (FlagWF == 0)
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
            int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
            if (hfVersion.Value != "")
            {
                int iVersion = Convert.ToInt32(hfVersion.Value);
            }
            string cOperacion = "I";

            if (ObjProcedimientoValidoManual.Rechaza_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
        }
    }

    protected void btnApruebaCertificacion_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "R";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        if (hfVersion.Value == "")
        {
            hfVersion.Value = "0";
        }
        int iVersion = Convert.ToInt32(hfVersion.Value);

        string Par1 = null;
        string Par2 = null;
        string Par3 = null;
        string sObservacion = null;
        if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, null, 0, ref sMensajeError))
        {
            //string msg = "La operacion se realizo con exito";
            //Master.MensajeOk(msg);
            //System.Threading.Thread.Sleep(10);

            if ((int)Session["RolUsuario"] == 14) // responsable
            {
                Par1 = "VOBO";
                Par2 = "VOBO_OK";
            }
            if (FlagWF == 1)
            {
                #region PARTE IV WF


                //CODIGO DE INTEGRACION CON WF
                clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
                ObjINodo.iIdConexion = iIdConexion;
                ObjINodo.iIdTramite = iIdTramite;
                ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
                ObjINodo.sNemoNodoOrig = Par1;
                ObjINodo.sEstado = "I";
                if (ObjINodo.ObtieneActividadActiva())
                {
                    clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
                    ObjINodoCpto.iIdConexion = iIdConexion;
                    ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                    ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                    ObjINodoCpto.sIdConcepto = Par2;
                    ObjINodoCpto.bValorBoolean = true;
                    if (ObjINodoCpto.Grabar())
                    {

                        string msg = "La aprobacion se realizo con exito";
                        Master.MensajeOk(msg);
                        cOperacion = "X";
                        DataTable tblListaAprobacionesCC = null;
                        tblListaAprobacionesCC = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
                        int CantidadAprobaciones;
                        CantidadAprobaciones = Convert.ToInt32(tblListaAprobacionesCC.Rows[0]["Aprobaciones"]);



                        if (CantidadAprobaciones == 4)
                        {
                            btnImpresionCertificacion.Visible = false;
                        }

                    }
                    else
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = ObjINodo.sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                    }

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = ObjINodo.sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }


                if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
                {
                    //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
                    Response.Redirect(ViewState["PreviousPage"].ToString());
                }

                #endregion
            }
            if (FlagWF == 0)
            {
                #region WFArticulador

                /*Codigo WFArticulador*/

                string msg = "La aprobacion se realizo con exito";
                Master.MensajeOk(msg);
                cOperacion = "X";
                DataTable tblListaAprobacionesCC = null;
                tblListaAprobacionesCC = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
                int CantidadAprobaciones;
                CantidadAprobaciones = Convert.ToInt32(tblListaAprobacionesCC.Rows[0]["Aprobaciones"]);

                if (ObjProcedimientoValidoManual.AsignacionWFArticulador(iIdConexion, "I", iIdTramite, iIdGrupoBeneficio, Convert.ToInt32(Par3), sObservacion, ref sMensajeError))
                {
                    msg = "La Aprobacion se realizo con exito";
                    Master.MensajeOk(msg);
                    // Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");
                    pnlComponentesNew.Visible = false;

                    btnIngresarInforme.Visible = false;
                    lblIngresarInforme.Visible = false;
                    btnReprobar.Visible = false;
                    lblReprobar.Visible = false;
                    btnInsertarCertificacion.Visible = false;
                    lblInsertarCertificacion.Visible = false;
                    btnAprobar.Visible = false;
                    lblAprobar.Visible = false;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible = false;


                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
                if (CantidadAprobaciones == 4)
                {
                    btnImpresionCertificacion.Visible = false;
                }
                #endregion
            }

        }
        else
        {
            string error = "error al realizar la operación";
            string detalleerror = sMensajeError;
            Master.MensajeError(error, detalleerror);
        }

    }


    protected void rdbCertSalMin_CheckedChanged(object sender, EventArgs e)
    {
        txtSalarioCotizable.Enabled = false;
        //MonedaNacional(324);
        ddlMonedaSalario.Enabled = false;
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        string sRUC = txtRUC.Text;
        string sPeriodoSalario = txtPeriodoSalario.Text;
        string sSalarioCotizable = "1";
        //llamar a funcion para q me devuelva el SalarioCotizableActualizado

        CalculoSalarioMinimo(iIdTramite, iIdGrupoBeneficio, sRUC, sPeriodoSalario, sSalarioCotizable);
        ObtenerTipoMoneda(sPeriodoSalario);


    }
    protected void rdbCertDS29537_CheckedChanged(object sender, EventArgs e)
    {
        txtSalarioCotizable.Enabled = false;
        //MonedaNacional(324);
        ddlMonedaSalario.Enabled = false;
        txtSalarioCotizable.Text = "349.92";
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        string sRUC = txtRUC.Text;
        string sPeriodoSalario = txtPeriodoSalario.Text;
        sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);
        string sSalarioCotizable = Convert.ToString(txtSalarioCotizable.Text);
        CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sRUC, sPeriodoSalario, sSalarioCotizable);
        ObtenerTipoMoneda(sPeriodoSalario);
    }
    protected void rdbCertNormal_CheckedChanged(object sender, EventArgs e)
    {
        txtSalarioCotizable.Enabled = true;
        ddlMonedaSalario.Enabled = true;
        txtSalarioCotizable.Text = ((string)ViewState["SalarioCotizable"]).Replace(",", "").ToString();
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        string sRUC = txtRUC.Text;
        string sPeriodoSalario = txtPeriodoSalario.Text;
        sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);
        string sSalarioCotizable = Convert.ToString(txtSalarioCotizable.Text);
        CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sRUC, sPeriodoSalario, sSalarioCotizable);


    }
    protected void txtPeriodoSalario_TextChanged(object sender, EventArgs e)
    {
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        string sRUC = txtRUC.Text;
        string sPeriodoSalario = txtPeriodoSalario.Text;
        sPeriodoSalario  = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);

        string sSalarioCotizable = Convert.ToString(txtSalarioCotizable.Text);
        if (sSalarioCotizable!=null)
        {
        sSalarioCotizable = sSalarioCotizable.Replace(",", "").ToString();
        if (sSalarioCotizable != "0" )
        {
            //llamar a funcion para q me devuelva el SalarioCotizableActualizado
            CalculoSalarioCotizableActualizado(iIdTramite, iIdGrupoBeneficio, sRUC, sPeriodoSalario, sSalarioCotizable);
        }
        }

        ObtenerTipoMoneda(sPeriodoSalario);
        
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../WorlkFlow/wfrmEjecucionActividades.aspx");
    }

    protected void btnInsertarCertificacion_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            //this.pnlFormularioModifica_ModalPopupExtender.Show();
            CleanControl(this.Controls);
            ViewState["SalarioCotizable"] = "0";
            int iIdTramite = (int)ViewState["iIdTramite"];
            int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
            ViewState["iVersion"] = 0;
            ViewState["iComponente"] = 0;

            pnlFormularioModifica.Visible = true;
            txtDescripcionRUC.AutoPostBack = true;
            txtDescripcionRUC.Text = "";
            hdfOperacion.Value = "I";

            pnlBusqueda.Visible = true;
            chkRuc.Checked = true;

            txtGlosaSalario.Text = "";

            txtSalarioCotizable.ReadOnly = false;
            txtSalarioCotizable.AutoPostBack = true;
            txtSalarioCotizable.Text = "0";
            chkSalarioCotizable.Checked = false;
            txtPeriodoSalario.AutoPostBack = true;
             string sSalarioCotizable = txtSalarioCotizable.Text;
            
            string sRUC = txtRUC.Text;
            if ((string)ViewState["sPeriodoSalario"] != null)
            {
                txtPeriodoSalario.Text = (string)ViewState["sPeriodoSalario"];
                string sPeriodoSalario = txtPeriodoSalario.Text;
                ObtenerTipoMoneda(sPeriodoSalario);
            }
            else
            {
                txtPeriodoSalario.Text ="";
                MonedaNacional(324);
            }
            
            chbCertificado.Checked = true;


           

            //Calcula el salario cotizalble actualizado
            //sSalarioCotizable = sSalarioCotizable.Replace(",", "").ToString();
            ddlTipoDocumento.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(40);
            ddlTipoDocumento.DataValueField = "IdDetalleClasificador";
            ddlTipoDocumento.DataTextField = "DescripcionDetalleClasificador";
            ddlTipoDocumento.DataBind();
            ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlTipoDocumento.SelectedValue = Convert.ToString(0);


            //ddlMonedaSalario.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(13);
            //ddlMonedaSalario.DataValueField = "IdDetalleClasificador";
            //ddlMonedaSalario.DataTextField = "DescripcionDetalleClasificador";
            //ddlMonedaSalario.DataBind();
            //ddlMonedaSalario.Items.Insert(0, new ListItem("Seleccione...", "0"));
            //ddlMonedaSalario.SelectedValue = Convert.ToString(324);

            Parametrizacion(447, 448, 0);


            txtDescripcionRUC.Focus();


        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnVolver2_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx";
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
    protected void chbCertificado_CheckedChanged(object sender, EventArgs e)
    {
        int iCertificado;
        if (chbCertificado.Checked == true)
        {
            iCertificado = 448; // CERTIFICA
        }
        else
        {
            iCertificado = 449; //NO CERTIFICA
        }


        Parametrizacion(447, iCertificado, 0);

    }

    private void ObtenerTipoMoneda(string sPeriodoSalario)
    {

        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        string sMensajeError = null;
        DataTable tblTipoMoneda = null;

        tblTipoMoneda = ObjProcedimientoValidoManual.ObtenerTipoMoneda(iIdConexion, cOperacion, sPeriodoSalario, ref sMensajeError);
        int iIdMoneda;
        iIdMoneda = Convert.ToInt32(tblTipoMoneda.Rows[0]["IdMoneda"]);
        MonedaNacional(iIdMoneda);

    }
    private void Parametrizacion(int TipoCertificacion, int EstadoCertificacion, int IdParametrizacion = 0)
    {

        ddlParametrizacion.ClearSelection();
        ddlParametrizacion.DataSource = ObjParametrizacion.ListaParametrizacion(TipoCertificacion, EstadoCertificacion, IdParametrizacion, null, null);
        ddlParametrizacion.DataValueField = "IdParametrizacion";
        ddlParametrizacion.DataTextField = "DescripcionCertificacion";
        ddlParametrizacion.DataBind();
        ddlParametrizacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlParametrizacion.SelectedValue = Convert.ToString(IdParametrizacion);
    }
    protected void btnImpresionCertificacion_Click(object sender, ImageClickEventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = "3";
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);

        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

    }
    protected void btnImprimeCorrelativo_Click(object sender, ImageClickEventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = "3";
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);

        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomaticoCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

    }
    public void CleanControl(ControlCollection controles)
    {
        foreach (Control control in controles)
        {
            if (control is TextBox)
                ((TextBox)control).Text = string.Empty;
            else if (control is DropDownList)
                ((DropDownList)control).ClearSelection();
            else if (control is RadioButtonList)
                ((RadioButtonList)control).ClearSelection();
            else if (control is CheckBoxList)
                ((CheckBoxList)control).ClearSelection();
            else if (control is RadioButton)
                ((RadioButton)control).Checked = false;
            else if (control is CheckBox)
                ((CheckBox)control).Checked = false;
            else if (control.HasControls())
                //Esta linea detécta un Control que contenga otros Controles
                //Así ningún control se quedará sin ser limpiado.
                CleanControl(control.Controls);
        }
    }
    protected void btnAdicionarInforme_Click(object sender, EventArgs e)
    {
        /*
         string iIdTramite = Request.QueryString["iIdTramite"];
        string iIdGrupoBeneficio = Request.QueryString["iIdGrupoBeneficio"];
        ScriptManager.RegisterStartupScript(this, GetType(), "RegistrarInforme", " window.open('wfrmIngresarInforme.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) +  "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        */
        pnlEditarInforme.Visible = true;
        ckeInforme.Text = "";
        btnActualizar.Visible = false;
        btnInsertarInforme.Visible = true;


    }
    protected void btnTraObservado_Click(object sender, ImageClickEventArgs e)
    {
        string Par1 = "REVISION";
        string Par2 = "REVISION_OK";
        string Par3 = "SIN_DATOS_CERTIF";



        int iIdConexion = (int)Session["IdConexion"];
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        string sMensajeError = null;
        //CODIGO DE INTEGRACION CON WF
        clsInstanciaNodo ObjINodo = new clsInstanciaNodo();
        ObjINodo.iIdConexion = iIdConexion;
        ObjINodo.iIdTramite = iIdTramite;
        ObjINodo.iIdGrupoBeneficio = iIdGrupoBeneficio;
        ObjINodo.sNemoNodoOrig = Par1;
        ObjINodo.sEstado = "I";
        if (ObjINodo.ObtieneActividadActiva())
        {
            clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
            ObjINodoCpto.iIdConexion = iIdConexion;
            ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
            ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
            ObjINodoCpto.sIdConcepto = Par2;
            ObjINodoCpto.bValorBoolean = true;
            if (ObjINodoCpto.Grabar())
            {
                ObjINodoCpto.iIdConexion = iIdConexion;
                ObjINodoCpto.iIdInstancia = ObjINodo.iIdInstancia;
                ObjINodoCpto.iSecuencia = ObjINodo.iSecuencia;
                ObjINodoCpto.sIdConcepto = Par3;
                ObjINodoCpto.bValorBoolean = true;
                if (ObjINodoCpto.Grabar())
                {
                    string msg = "La aprobacion se realizo con exito";
                    Master.MensajeOk(msg);
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = ObjINodo.sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = ObjINodo.sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = ObjINodo.sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnIngresarInforme_Click(object sender, EventArgs e)
    {
        string sInforme = ckeInforme.Text;
        sInforme = sInforme.Replace("\n", "<BR/>");
        sInforme = sInforme.ToUpper();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iIdTipoInforme = 0;
        if (rbTipoInforme.SelectedValue == "1")
        {
            iIdTipoInforme = 1;
        }
        else
        {
            iIdTipoInforme = 2;
        }
        if (ObjProcedimientoManual.IngresaInforme(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, 0, sInforme, iIdTipoInforme, ref sMensajeError))        
        {
            string msg = "La aprobacion se realizo con exito";
            Master.MensajeOk(msg);
            pnlEditarInforme.Visible = false;
            ListaInformes(iIdTramite, iIdGrupoBeneficio);
            btnActualizar.Visible = false;
            btnInsertarInforme.Visible = false;

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "M";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        string sInforme = ckeInforme.Text;
        sInforme = sInforme.Replace("\n", "<BR/>");
        sInforme = sInforme.ToUpper();
        string sNroControl = (string)ViewState["NroControl"];
        int iIdTipoInforme = 0;
        if (rbTipoInforme.SelectedValue == "1")
        {
            iIdTipoInforme = 1;
        }
        else
        {
            iIdTipoInforme = 2;
        }
        if (ObjProcedimientoManual.ActualizaInforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, sNroControl, sInforme,iIdTipoInforme, ref  sMensajeError))
        {
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
            ListaInformes(iIdTramite, iIdGrupoBeneficio);
            pnlEditarInforme.Visible = false;
            btnActualizar.Visible = false;
            btnInsertarInforme.Visible = false;

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void btnCancelarInforme_Click(object sender, EventArgs e)
    {
        pnlEditarInforme.Visible = false;

        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        ListaInformes(iIdTramite, iIdGrupoBeneficio);
        btnActualizar.Visible = false;
        btnInsertarInforme.Visible = false;
        ckeInforme.Text = "";
    }
    protected void gvDatosInformes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int iContador = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int iIdTramite = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            string NroControl = Convert.ToString(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["NroControl"]);
            string sRevisor = Convert.ToString(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["Revisor"]);
            int iRegistroActivo = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["RegistroActivo"]);
            int IdTipoInforme = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdTipoInforme"]);
            if (IdTipoInforme == 1 && iRegistroActivo == 1) //Observado
            {
                iContador = iContador + 1;
            }


            if ((int)Session["RolUsuario"] == 9) //Verificador
            {
                e.Row.FindControl("imgEliminar").Visible = true;
                e.Row.FindControl("imgEditar").Visible = true;
                e.Row.FindControl("imgVer").Visible = true;


            }
            else
            {
                e.Row.FindControl("imgEliminar").Visible = false;
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgVer").Visible = true;
            }
            if (iRegistroActivo == 0)
            {
                e.Row.BackColor = Color.FromName("#FFCC00");
                e.Row.FindControl("imgLevantar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;
                e.Row.FindControl("imgEditar").Visible = false;

            }
        }
    }
    protected void gvDatosInformes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sMensajeError = null;
        if (e.CommandName == "cmdEditar")
        {
            try
            {
                pnlEditarInforme.Visible = true;
                ckeInforme.Enabled = true;
                btnActualizar.Visible = true;
                btnInsertarInforme.Visible = false;
                int Index = Convert.ToInt32(e.CommandArgument);
                string sInforme = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["Informe"]);
                sInforme = sInforme.Replace("<BR/>", "\n");
                sInforme = sInforme.Replace("<BR>", "\n");
                ckeInforme.Text = sInforme;
                
                ViewState["NroControl"] = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);
                hfIdTramite.Value = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                hfIdGrupoBeneficio.Value = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                int iIdTipoInforme = Convert.ToInt32(gvDatosInformes.DataKeys[Index].Values["IdTipoInforme"]);
                if (iIdTipoInforme == 1)
                {
                    rbTipoInforme.SelectedValue = "1";
                }
                if (iIdTipoInforme == 2)
                {
                    rbTipoInforme.SelectedValue = "2";
                }

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdEliminar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "N";
                int iIdTramite = Convert.ToInt32(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                int iIdGrupoBeneficio = Convert.ToInt32(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                string sNroControl = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);


                if (ObjProcedimientoManual.EliminarInforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, sNroControl, ref  sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListaInformes(iIdTramite, iIdGrupoBeneficio);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }


            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdLevantar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "L";
                int iIdTramite = Convert.ToInt32(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                int iIdGrupoBeneficio = Convert.ToInt32(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                string sNroControl = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);


                if (ObjProcedimientoManual.LevantaInforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, sNroControl, ref  sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListaInformes(iIdTramite, iIdGrupoBeneficio);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }


            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdVer")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                string NroControl = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);
                string iIdTramite = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteInformeCertificacion.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&NroControl=" + Server.UrlEncode(NroControl) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                
                
                
                //pnlEditarInforme.Visible = true;
                //btnActualizar.Visible = false;
                //btnInsertarInforme.Visible = false;
                //int Index = Convert.ToInt32(e.CommandArgument);
                //string FechaInicio = lblFechaInicio.Text.Substring(0, 10);
                //string FechaAsg = lblFechaAsignacion.Text.Substring(0, 10);
                //string Asegurado = lblPaterno.Text + ' ' + lblMaterno.Text + ' ' + lblNombres.Text;
                //string Matricula = lblMatricula.Text;
                //string Tramite = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroCrenta"]);
                //string FechaInforme = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["FechaInforme"]).Substring(0, 10);
                ////ckeInforme.Text = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["Informe"]);
                //ViewState["NroControl"] = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);
                //hfIdTramite.Value = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                //hfIdGrupoBeneficio.Value = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                //ckeInforme.Enabled = false;
                //ckeInforme.Text ="<table width='100%' border='0' cellpadding='0' cellspacing='0'>   <tr>     <td width='27%'><img src='http://serv01/senasir/Imagenes/reportes/senasir2.png' width='200' height='50' /></td>     <td width='43%'>&nbsp;</td>     <td width='30%' valign='bottom'><strong>FORM - 460</strong></td>   </tr>   <tr>     <td>&nbsp;</td>     <td>&nbsp;</td>     <td>Nro. Control:" + ViewState["NroControl"] + "</td>   </tr>   <tr>     <td colspan='3' align='center'><strong><H2>INFORME AREA CERTIFICACION CC</H2></strong></td>   </tr>   <tr>     <td>&nbsp;</td>     <td>&nbsp;</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Unidad Origen:</strong></td>     <td> CERTIFICACION CC</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Unidad Destino</strong></td>     <td>OBSERVADOS CC</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Fecha Transcrita:</strong></td>     <td>" + FechaInforme + "</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Fecha Ini. Tram:</strong></td>     <td>" + FechaInicio + "</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Fecha Asg.:</strong></td>     <td>" + FechaAsg + "</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Asegurado:</strong></td>     <td>" + Asegurado + "</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Matricula:</strong></td>     <td>" + Matricula + "</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><strong>Tramite:</strong></td>     <td>" + Tramite + "</td>     <td>&nbsp;</td>   </tr><tr>     <td colspan='3' align='right'><HR  width='80%'/></td>   </tr>   <tr>     <td align='left'><strong>OBSERVACION:</strong></td>     <td>&nbsp;</td>     <td>&nbsp;</td>   </tr>></table>" + Convert.ToString(gvDatosInformes.DataKeys[Index].Values["Informe"]) + "<table width='100%' border='0' cellpadding='0' cellspacing='0'>    <tr>     <td width='30%' align='left'>&nbsp;</td>     <td width='40%'>&nbsp;</td>     <td width='30%'>&nbsp;</td>   </tr>   <tr>     <td align='left'>&nbsp;</td>     <td>&nbsp;</td>     <td>&nbsp;</td>   </tr>   <tr>     <td align='right'><br>VERIFICADOR</td>     <td>&nbsp;</td>     <td align='left'><br>REVISOR</td>   </tr> </table>";

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }

    }
    private void ListaInformes(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "K";
        string sMensajeError = null;
        DataTable tblListaInformes = null;
        tblListaInformes = ObjEmisionFormularioCC.ListaInformes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaInformes != null && tblListaInformes.Rows.Count > 0)
        {
            gvDatosInformes.Visible = true;
            lblTituloInformes.Visible = true;
            gvDatosInformes.DataSource = tblListaInformes;
            gvDatosInformes.DataBind();
        }
        else
        {
            gvDatosInformes.Visible = false;
            lblTituloInformes.Visible = false;
        }

    }
    private void ComibolSalarioConvenio(int iIdTramite, int iIdGrupoBeneficio, string sRuc)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        string sMensajeError = null;
        DataTable Sector;
        Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRuc, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (Sector != null && Sector.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in Sector.Rows)
            {

                int iValido = Convert.ToInt32(drDataRow["Valido"]);
                //string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                string sCodigo = Convert.ToString(drDataRow["Codigo"]);

                if (sCodigo == "F" && iValido == 1)
                {
                    rdbCertDS29537.Visible = true;
                    rdbCertDS29537.Checked = true;
                    rdbCertDS29537.Enabled = true;
                    txtSalarioCotizable.Enabled = false;
                    //Moneda(324);
                    //ddlMonedaSalario.Enabled = false;
                    txtSalarioCotizable.Text = "349.92";

                }
                else
                {

                    txtPeriodoSalario.Enabled = true;
                    rdbCertNormal.Checked = true;
                    rdbCertDS29537.Visible = false;
                }

            }
        }
    }
}

