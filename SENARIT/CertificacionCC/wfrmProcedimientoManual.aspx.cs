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


public partial class CertificacionCC_wfrmProcedimientoManual : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsParametrizacion ObjParametrizacion = new clsParametrizacion();
    clsTramiteAsignado ObjTramite = new clsTramiteAsignado();
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
            // btnTraObservado.Visible = false;

            CambiarInterfaz();
            pnlFormularioModifica.Visible = false;
            int iIdTramite = 0;
            int iIdGrupoBeneficio = 0;
            string sRUC;
            string sFechaAfiliacion;
            if (Request.QueryString["iIdTramite"] != null)
            {
                //iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
                //iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));

                iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                ListaInformes(iIdTramite, iIdGrupoBeneficio);
                ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
               
                DatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                hfIdTramite.Value = Convert.ToString(iIdTramite);
                hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);
                
                ReporteSalario(iIdTramite, iIdGrupoBeneficio);
                if ((int)Session["RolUsuario"] == 9) //Verificador
                {
                    //lblInfVerificador.Visible = true;                  
                    //ckeVerificador.Visible = true;
                    btnRechaza.Visible = false;
                    lblRechaza.Visible = false;
                    if (Request.QueryString["sRUC"] != null)
                    {
                        InsertarSalarioCotizable();
                    }
                    txtDescripcionRUC.Enabled = false;
                    btnRegistrarCancha.Visible = true;
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible = false;
                    btnIngresarInforme.Visible = true;
                }
                if ((int)Session["RolUsuario"] == 8) //Revisor
                {
                    //lblInfVerificador.Visible = true;                 
                    //ckeVerificador.Visible = true;
                    //btnTraObservado.Visible = true;
                    btnRegistrarCancha.Visible = false;
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnRechaza.Visible = true;
                    lblRechaza.Visible = true;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible = false;
                    btnIngresarInforme.Visible = false;
                    lblRegistroAportes.Visible = false;
                    lblIngresarInforme.Visible = false;

                }
                if ((int)Session["RolUsuario"] == 7) //Control
                {
                    //lblInfVerificador.Visible = true;                 
                    //ckeVerificador.Visible = false;
                    btnRegistrarCancha.Visible = false;
                    btnAprobar.Visible = true;
                    lblAprobar.Visible = true;
                    btnApruebaCertificacion.Visible = false;
                    lblApruebaCertificacion.Visible = false;
                    btnRechaza.Visible = true;
                    lblRechaza.Visible = true;
                    btnIngresarInforme.Visible = false;

                    lblRegistroAportes.Visible = false;
                    lblIngresarInforme.Visible = false;
                }
                if ((int)Session["RolUsuario"] == 14) //Responsable de Certificacion
                {
                    //lblInfVerificador.Visible = false;
                    //ckeVerificador.Visible = false;
                    btnRegistrarCancha.Visible = false;
                    btnAprobar.Visible = false;
                    lblAprobar.Visible = false;
                    btnApruebaCertificacion.Visible = true;
                    lblApruebaCertificacion.Visible = true;
                    btnImprimeCorrelativo.Visible = false;
                    lblImprimeCorrelativo.Visible = false;
                    btnRechaza.Visible = true;
                    lblRechaza.Visible = true;
                    btnIngresarInforme.Visible = false;
                    lblRegistroAportes.Visible = false;
                    lblIngresarInforme.Visible = false;
                }
            }

            if (Request.QueryString["sOpe"] == "U")
            {
                hdfOperacion.Value = Request.QueryString["sOpe"];
                ViewState["iComponente"] = Convert.ToInt32(Request.QueryString["iComp"]);
            }
            //Parametrizacion(447, 448, 0);
            //btnImpresionCertificacion.Visible = false;
        }


    }


    #region INTERFAZ

    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtDescripcionRUC, ddlTipoDocumento);
        AgregarJSAtributos(txtRUC, txtDetRUC);
        AgregarJSAtributos(txtDetRUC, ddlTipoDocumento);
        AgregarJSAtributos(txtPeriodoSalario, txtSalarioCotizable);
        AgregarJSAtributos(txtSalarioCotizable, ddlMonedaSalario);
        // AgregarJSAtributos(txtGlosaSalario, btnInsertar);
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
    private void ReporteSalario(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "X";
        string sMensajeError = null;
        /*
        DataTable tblListaAprobacionesCC = null;
        tblListaAprobacionesCC = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        int CantidadAprobaciones;
        CantidadAprobaciones = Convert.ToInt32(tblListaAprobacionesCC.Rows[0]["Aprobaciones"]);
        if (CantidadAprobaciones == 4)
        {
            btnImpresionCertificacion.Visible = false;
        }*/
        btnImpresionCertificacion.Visible = false;
    }
    private void ListaInformes(int iIdTramite, int iIdGrupoBeneficio)
    {
        hfCantidadInformes.Value = "0";
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
    private void DatosAsegurado(int iIdTramite, int iIdGrupoBeneficio)
    {

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
            if (hfEstadoTramite.Value == "42")
            {
                lblTipoReproceso.Visible = true;
                lblEstadoTramite.Text = "- Tramite en reproceso verificar componentes";
                lblEstadoTramite.Visible = true;

            }
            if (hfEstadoTramite.Value == "23")
            {

                lblEstadoTramite.Text = "Tramite en recurso de reclamacion";
                lblEstadoTramite.Visible = true;


            }

        }
    }
    // Lista los componentes que se estan certificando o no
    private void ListarComponentesNew(int iIdTramite, int iIdGrupoBeneficio)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        string sMensajeError = null;
        DataTable tblDatosComponentes = ObjProcedimientoManual.DatosProcedimientoManual(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblDatosComponentes != null)
        {
            ViewState["Cantidad"] = tblDatosComponentes.Rows.Count;
            int iVersion = Convert.ToInt32(tblDatosComponentes.Rows[0]["Version"]);

            DataTable tblDatosActualizacionCC = ObjProcedimientoManual.ListaActualizacionCC(iIdConexion, "Q", iIdTramite, iIdGrupoBeneficio, 0, null, 0, ref sMensajeError);
            DataView dv = new DataView(tblDatosActualizacionCC);

            dv.RowFilter = "Version in (0)";


            if (dv.Count > 0)
            {
                lblCertificacionParcial.Visible = true;
                lblCertificacionParcial.Text = ".::EL TRAMITE TIENE UNA CERTIFICACION PARCIAL::. ==>";
                btnCertificacionParcial.Visible = true;


                if (Convert.ToInt32(hfCantidadInformes.Value) == 0)
                {
                    ///false
                    btnAprobar.Enabled = true;
                    lblCertSNInforme.Visible = true;
                    lblCertSNInforme.Text = ".::DEBE INGRESAR UN INFORME::.";
                }
                else
                {
                    lblCertSNInforme.Visible = false;
                    btnAprobar.Enabled = true;
                }
                
            }
            else
            {
                lblCertificacionParcial.Visible = false;
                btnCertificacionParcial.Visible = false;
                lblCertSNInforme.Visible = false;
                btnAprobar.Enabled = true;
            }


        }
        else
        {
            DataTable tblDatosActualizacionCC = ObjProcedimientoManual.ListaActualizacionCC(iIdConexion, "Q", iIdTramite, iIdGrupoBeneficio, 0, null, 0, ref sMensajeError);
            DataView dv = new DataView(tblDatosActualizacionCC);

            dv.RowFilter = "Version in (0)";


            if (dv.Count > 0)
            {
                lblCertificacionParcial.Visible = true;
                lblCertificacionParcial.Text = ".::EL TRAMITE TIENE UNA CERTIFICACION PARCIAL::. ==>";
                btnCertificacionParcial.Visible = true;
                if (Convert.ToInt32(hfCantidadInformes.Value) == 0)
                {
                    //false
                    btnAprobar.Enabled = true;
                    lblCertSNInforme.Visible = true;
                    lblCertSNInforme.Text = "DEBE INGRESAR UN INFORME";
                }
                else
                {
                    lblCertSNInforme.Visible = false;
                    btnAprobar.Enabled = true;
                }

            }
            else
            {
                lblCertificacionParcial.Visible = false;
                btnCertificacionParcial.Visible = false;
                lblCertSNInforme.Visible = false;
                btnAprobar.Enabled = true;
            }
        }
        gvDatosComponentes.DataSource = tblDatosComponentes;
        gvDatosComponentes.DataBind();
    }
    //Añadir componente certificado o no
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            pnlFormularioModifica.Visible = false;
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = hdfOperacion.Value;
            int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
            int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
            int iVersion = 0;
            int iComponente;

            if (cOperacion == "U")
            {
                iComponente = (int)ViewState["iComponente"];
            }
            else
            {
                iComponente = 0;
            }
            string sRUC = txtRUC.Text;
            int iIdTipoDocumento = Convert.ToInt32(ddlTipoDocumento.SelectedValue);
            string sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + txtPeriodoSalario.Text)).Substring(3, 7);
            int iMitas;
            if (txtMitas.Text == null || txtMitas.Text == "")
            {
                iMitas = 0;
            }
            else
            {
                iMitas = Convert.ToInt32(txtMitas.Text);
            }
            string sSalarioCotizable = (txtSalarioCotizable.Text).Replace(",", "");
            //string sSalarioCotizableActualizado = (txtSalarioCotizableActualizado.Text).Replace(",", "");
            string sSalarioCotizableActualizado = null;
            int iMonedaSalario = Convert.ToInt32(ddlMonedaSalario.SelectedValue);
            int? iIdParametrizacion = Convert.ToInt32(ddlParametrizacion.SelectedValue);
            if (iIdParametrizacion == 0)
            {
                iIdParametrizacion = null;
            }
            //int iIdParametrizacion = 1;
            string sGlosa = txtGlosaSalario.Text;
            sGlosa = sGlosa.Replace("\n", "<BR/>");
            sGlosa = sGlosa.ToUpper();
            string sDetalleGeneral = txtDetalleGeneral.Text;
            sDetalleGeneral = sDetalleGeneral.Replace("\n", "<BR/>");
            sDetalleGeneral = sDetalleGeneral.ToUpper();
            string sMensajeError = null;
            int iCertificado;
            iCertificado = 1;
            string sSector = txtSector.Text;


            if (ObjProcedimientoManual.InsertaComponentes(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iComponente, sRUC, iIdTipoDocumento, sPeriodoSalario, sSalarioCotizable, sSalarioCotizableActualizado, iMonedaSalario, iIdParametrizacion, sGlosa, iCertificado, iMitas, sSector,sDetalleGeneral, ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                //ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);

            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
                pnlFormularioModifica.Visible = Visible;
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
        // this.pnlFormularioModifica_ModalPopupExtender.Show();
        if (chkRuc.Checked == true)
        {
            pnlBusqueda.Visible = true;
            txtDescripcionRUC.Enabled = true;
            txtDescripcionRUC.Focus();
            txtDescripcionRUC.AutoPostBack = true;
        }
        else
        {
            pnlBusqueda.Visible = false;
            txtDescripcionRUC.AutoPostBack = false;
            txtDescripcionRUC.Enabled = false;
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



    //Ejectua el metodo de busqueda de la Razon Social o Ruc
    protected void txtDescripcionRUC_TextChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        string sMensajeError = null;
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];

        string sDescripcionRuc = txtDescripcionRUC.Text;
        int posicionfinal = sDescripcionRuc.IndexOf('/');
        string sRuc = sDescripcionRuc.Substring(4, posicionfinal - 4);
        txtRUC.Text = sRuc;
        DescripcionRUC(txtRUC.Text);

        string sDescripcionSector = txtSector.Text;

        DataTable Sector;
        Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRuc, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (Sector != null && Sector.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in Sector.Rows)
            {

                int iValido = Convert.ToInt32(drDataRow["Valido"]);
                //string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                if (sCodigo == "C")
                {
                    chkRuc.Visible = false;
                    txtPeriodoSalario.Enabled = true;
                    txtMitas.Visible = true;
                    lblMitas.Visible = true;
                    rdbCertNormal.Checked = true;
                }
                else
                {
                    if (sCodigo == "F" && iValido == 1)
                    {
                        chkRuc.Visible = false;
                        txtPeriodoSalario.Enabled = false;
                        rdbCertDS29537.Visible = true;
                        rdbCertDS29537.Checked = true;
                        rdbCertDS29537.Enabled = true;
                        txtSalarioCotizable.Enabled = false;
                        Moneda(324);
                        ddlMonedaSalario.Enabled = false;
                        txtSalarioCotizable.Text = "349.92";

                    }
                    else
                    {
                        chkRuc.Visible = false;
                        txtPeriodoSalario.Enabled = false;
                        txtMitas.Visible = false;
                        lblMitas.Visible = false;
                        rdbCertNormal.Checked = true;
                        rdbCertDS29537.Visible = false;
                    }

                }
            }
        }



    }
    //Codigo que oculta el boton editar en el caso de no certificado)
    protected void gvDatosComponentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int cantidad = (int)ViewState["Cantidad"];
            int iIdTramite = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            int iVersion = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["Version"]);
            string sRUC = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["RUC"]);
            int iComponente = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["Componente"]);
            int iIdEstadoComponente = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdEstadoComponente"]);
            string sFechaAfiliacion = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["PeriodoSalario"]);
            if ((int)Session["RolUsuario"] == 14) //Responsable de Certificacion
            {
                e.Row.FindControl("imgCertificacionSalarioCorrelativo").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgCertificacionSalarioCorrelativo").Visible = false;
            }
            //Valida si los componentes estan actualizados
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "A";
            string sMensajeError = null;
            DataTable UltimoRUC;

            UltimoRUC = ObjProcedimientoManual.ObtenerUltimoRUC(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, ref sMensajeError);
            if (txtSector.Text != "COMIBOL")
            {
                if (UltimoRUC != null)
                {
                    if (Convert.ToString(UltimoRUC.Rows[0]["Operacion"]) == "U")
                    {
                        if (Convert.ToString(UltimoRUC.Rows[0]["FechaAfiliacion"]) == "10/1996")
                        {
                            e.Row.BackColor = Color.FromName("#FFCC00");
                        }
                        else
                        {
                            e.Row.BackColor = Color.FromName("#FFCC00");
                            //false
                            btnAprobar.Enabled = true;
                            btnImpresionCertificacion.Enabled = false;
                            lblGenerarSalario.Visible = true;
                            lblGenerarSalario.Text = "Se agrego un aporte, que modifica sustancialmente el salario, eliminar el salario y volver a generarlo";

                        }


                    }
                }

            }
            else
            {
                btnAprobar.Enabled = true;
                btnImpresionCertificacion.Enabled = true;
                lblGenerarSalario.Visible = false;
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
                            if (cantidad == rowIndex)
                            {
                                e.Row.FindControl("imgEliminar").Visible = true;
                            }
                            else
                            {
                                e.Row.FindControl("imgEliminar").Visible = false;
                            }
                        }
                        else
                        {
                            if (iIdEstadoComponente == 902)
                            {
                                e.Row.FindControl("imgEditar").Visible = true;
                                if (cantidad == rowIndex)
                                {
                                    e.Row.FindControl("imgEliminar").Visible = true;
                                }
                                else
                                {
                                    e.Row.FindControl("imgEliminar").Visible = true;
                                }
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
                    gvDatosComponentes.Columns[11].Visible = false;

                }
            }
            else
            {
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;
                //e.Row.FindControl("imgSubir").Visible = false;
                //e.Row.FindControl("imgBajar").Visible = false;
                gvDatosComponentes.Columns[10].Visible = false;
                //gvDatosComponentes.Columns[11].Visible = false;
                btnRegistrarCancha.Visible = false;


            }



        }
    }
    private void DescripcionRUC(string sRUC)
    {
        DataTable tblDescripcionRUC = null;
        tblDescripcionRUC = ObjProcedimientoValidoManual.DescripcionRuc(sRUC);
        foreach (DataRow drDataRow in tblDescripcionRUC.Rows)
        {
            txtDetRUC.Text = Convert.ToString(drDataRow["NombreEmpresa"]);
            txtSector.Text = Convert.ToString(drDataRow["DescripcionSector"]);


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
                chkRuc.Checked = false;
                chkSalarioCotizable.Checked = false;
                pnlBusqueda.Visible = false;

                hdfOperacion.Value = "U";

                txtSalarioCotizable.ReadOnly = false;
                txtSalarioCotizable.AutoPostBack = false;



                int Index = Convert.ToInt32(e.CommandArgument);
                gvDatosComponentes.Rows[Index].BackColor = Color.FromName("#FFCC00");
                pnlFormularioModifica.Visible = true;
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);
                ViewState["iMitas"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Mitas"]);
                ViewState["sSector"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Sector"]);
                ViewState["sCodigo"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Codigo"]);
                txtRUC.Text = (string)ViewState["sRUC"];


                // Obtiene el sector
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "B";
                string sMensajeError = null;
                int iIdTramite = (int)ViewState["iIdTramite"];
                int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];

                string sRuc = txtRUC.Text;
                txtRUC.Text = sRuc;
                DataTable Sector;
                Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRuc, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
                if (Sector != null && Sector.Rows.Count > 0)
                {
                    foreach (DataRow drDataRow in Sector.Rows)
                    {

                        int iValido = Convert.ToInt32(drDataRow["Valido"]);
                        //string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                        string sCodigo = Convert.ToString(ViewState["sCodigo"]);
                        if (sCodigo == "C")
                        {
                            chkRuc.Visible = false;
                            txtPeriodoSalario.Enabled = true;
                            txtMitas.Visible = true;
                            lblMitas.Visible = true;
                            rdbCertNormal.Checked = true;
                        }
                        else
                        {
                            if (sCodigo == "F" && iValido == 1)
                            {
                                chkRuc.Visible = false;
                                txtPeriodoSalario.Enabled = false;
                                rdbCertDS29537.Visible = true;
                                rdbCertDS29537.Checked = true;
                                rdbCertDS29537.Enabled = true;
                                txtSalarioCotizable.Enabled = false;
                                Moneda(324);
                                ddlMonedaSalario.Enabled = false;
                                txtSalarioCotizable.Text = "349.92";

                            }
                            else
                            {
                                chkRuc.Visible = false;
                                txtPeriodoSalario.Enabled = false;
                                txtMitas.Visible = false;
                                lblMitas.Visible = false;
                                rdbCertNormal.Checked = true;
                                rdbCertDS29537.Visible = false;
                            }

                        }
                    }
                }
                DescripcionRUC(txtRUC.Text);
                txtSector.Text = Convert.ToString(ViewState["sSector"]);


                string sPeriodoSalario = (Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["PeriodoSalario"])).Substring(0, 7);
                string sSalarioCotizable = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["SalarioCotizable"]);
                //PeriodoSalario=PeriodoSalario.Replace("/", "").ToString();
                txtPeriodoSalario.Text = sPeriodoSalario;
                txtSalarioCotizable.Text = Convert.ToString(sSalarioCotizable);
                //Calcula el salario cotizalble actualizado                
                int IdTipoDocSalario = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTipoDocSalario"]);
                int IdMonedaSalario = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdMonedaSalario"]);
                int IdParametrizacion = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdParametrizacion"]);

                string GlosaSalario = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["GlosaSalario"]);
                string sDetalleGeneral = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["DetalleGeneral"]);
                GlosaSalario = GlosaSalario.Replace("<BR/>", "\n");
                GlosaSalario = GlosaSalario.Replace("<BR>", "\n");
                sDetalleGeneral = sDetalleGeneral.Replace("<BR/>", "\n");
                sDetalleGeneral = sDetalleGeneral.Replace("<BR>", "\n");
                int Certificado = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Certificado"]);


                TipoDocumento(IdTipoDocSalario);
                Moneda(IdMonedaSalario);

                Parametrizacion(447, 448, IdParametrizacion);


                txtGlosaSalario.Text = GlosaSalario;
                txtDetalleGeneral.Text = sDetalleGeneral;
                txtMitas.Text = Convert.ToString((int)ViewState["iMitas"]);


                //CalculoSalarioCotizableActualizado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"], (string)ViewState["sRUC"], sPeriodoSalario, sSalarioCotizable);

                txtRUC.Focus();


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
                pnlFormularioModifica.Visible = false;

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "G";
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
                    //ListarDatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);

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
                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);




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

                //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

              
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
              
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }


        if (e.CommandName == "cmdCancha")
        {

            int Index = Convert.ToInt32(e.CommandArgument);
            //string iIdTramite = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]));
            //string iIdGrupoBeneficio = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]));
            string iIdTramite = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
            string iIdGrupoBeneficio = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);



            string iVersion = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Version"]));
            string sRUC = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]));
            string iComponente = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Componente"]));
            string vUrl = ViewState["PreviousPage"].ToString();
            vUrl = ObjSeguridad.URLEncode(vUrl);
            Response.Redirect("wfrmAportesSIR.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + "&iVersion=" + Server.UrlEncode(iVersion) + "&sRUC=" + Server.UrlEncode(sRUC) + "&iComponente=" + Server.UrlEncode(iComponente) + "&vUrl=" + Server.UrlEncode(vUrl) + " ");

        }
    }

    protected void ddlParametrizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obtener la descripcion de la parametrizacion y mostrar en la gloza
        // this.pnlFormularioModifica_ModalPopupExtender.Show();
        int iIdParametrizacion = Convert.ToInt32(ddlParametrizacion.SelectedValue);
        string Glosa = ObjParametrizacion.ListaParametrizacion(0, 0, iIdParametrizacion, Convert.ToString(Convert.ToDateTime("01/" + txtPeriodoSalario.Text)).Substring(3, 7), null).Rows[0]["Glosa"].ToString();
        txtGlosaSalario.Text = Glosa; ;
    }

    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        string sInforme = null;

        //WF
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        if (hfVersion.Value == "")
        {
            hfVersion.Value = "0";
        }
        int iVersion = Convert.ToInt32(hfVersion.Value);
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
            foreach (DataRow drDataRow in tblVerificador.Rows)
            {
                Par3 = Convert.ToString(drDataRow["IdUsuarioSuperior"]);

            }
            clsSeguridad ObjSeguridad = new clsSeguridad();
            string sIdTramite = hfIdTramite.Value;
            string sIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
            sIdTramite = ObjSeguridad.URLEncode(sIdTramite);
            sIdGrupoBeneficio = "3";
            sIdGrupoBeneficio = ObjSeguridad.URLEncode(sIdGrupoBeneficio);

            String CuentaUsuario = (string)Session["CuentaUsuario"];
            CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(sIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(sIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
        if ((int)Session["RolUsuario"] == 8) // Revisor
        {
            Par1 = "REVISION";
            Par2 = "REVISION_OK";
        }
        if ((int)Session["RolUsuario"] == 7) // Control
        {
            Par1 = "QCTRL";
            Par2 = "QCTRL_OK";
        }

        cOperacion = "A";
        if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, null, 0, ref sMensajeError))
        //if (ObjProcedimientoManual.Apruebaconinforme_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, sInforme, ref sMensajeError))
        {

            //CODIGO DE INTEGRACION CON WF
            if (FlagWF == 1)
            {
                #region PARTE I WF

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

                    Response.Redirect(ViewState["PreviousPage"].ToString());
                }

                #endregion
            }
            if (FlagWF == 0)
            {
                #region WFArticulador
                string msg = "La aprobacion se realizo con exito";
                Master.MensajeOk(msg);


                /*Codigo WFArticulador*/

                if (ObjProcedimientoValidoManual.AsignacionWFArticulador(iIdConexion, "I", iIdTramite, iIdGrupoBeneficio, Convert.ToInt32(Par3), sObservacion, ref sMensajeError))
                {
                    msg = "La Aprobacion se realizo con exito";
                    Master.MensajeOk(msg);

                    if ((int)Session["RolUsuario"] == 9) // Verificador
                    {
                        pnlComponentesNew.Visible = false;
                        btnRegistrarCancha.Visible = false;
                        lblRegistroAportes.Visible = false;
                        btnIngresarInforme.Visible = false;
                        lblIngresarInforme.Visible = false;
                        btnRechaza.Visible = false;
                        lblRechaza.Visible = false;
                        btnAprobar.Visible = false;
                        lblAprobar.Visible = false;

                    }
                    if ((int)Session["RolUsuario"] == 8) // Revisor
                    {
                        pnlComponentesNew.Visible = false;
                        btnRegistrarCancha.Visible = false;
                        lblRegistroAportes.Visible = false;
                        btnIngresarInforme.Visible = false;
                        lblIngresarInforme.Visible = false;
                        btnRechaza.Visible = false;
                        lblRechaza.Visible = false;
                        btnAprobar.Visible = false;
                        lblAprobar.Visible = false;

                    }
                    if ((int)Session["RolUsuario"] == 7) // CtrlCalidad
                    {
                        pnlComponentesNew.Visible = false;
                        btnRegistrarCancha.Visible = false;
                        lblRegistroAportes.Visible = false;
                        btnIngresarInforme.Visible = false;
                        lblIngresarInforme.Visible = false;
                        btnRechaza.Visible = false;
                        lblRechaza.Visible = false;
                        btnAprobar.Visible = false;
                        lblAprobar.Visible = false;

                    }
                    if ((int)Session["RolUsuario"] == 14) // VoBo
                    {
                        pnlComponentesNew.Visible = false;
                        btnRegistrarCancha.Visible = false;
                        lblRegistroAportes.Visible = false;
                        btnIngresarInforme.Visible = false;
                        lblIngresarInforme.Visible = false;
                        btnRechaza.Visible = false;
                        lblRechaza.Visible = false;
                        btnAprobar.Visible = false;
                        btnApruebaCertificacion.Visible = false;
                        lblAprobar.Visible = false;

                       

                    }


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
            #region Parte WF Rechazo

            int iIdConexion = (int)Session["IdConexion"];
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
        int iVersion = Convert.ToInt32(hfVersion.Value);
        string Par1 = null;
        string Par2 = null;
        string Par3 = null;
        string sObservacion = null;



        if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, null, 0, ref sMensajeError))
        {
            if ((int)Session["RolUsuario"] == 14) // responsable
            {
                Par1 = "VOBO";
                Par2 = "VOBO_OK";
            }
            if (FlagWF == 1)
            {
                #region PARTE II WF

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
                        clsSeguridad ObjSeguridad = new clsSeguridad();
                        string sIdTramite = hfIdTramite.Value;
                        string sIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
                        sIdTramite = ObjSeguridad.URLEncode(sIdTramite);
                        sIdGrupoBeneficio = "3";
                        sIdGrupoBeneficio = ObjSeguridad.URLEncode(sIdGrupoBeneficio);

                        String CuentaUsuario = (string)Session["CuentaUsuario"];
                        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
                        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(sIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(sIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(sIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(sIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                        //Response.Redirect("~/CertificacionCC/wfrmBuscadorTramiteCertificacion.aspx");
                        pnlComponentesNew.Visible = false;
                        btnRegistrarCancha.Visible = false;
                        lblRegistroAportes.Visible = false;
                        btnIngresarInforme.Visible = false;
                        lblIngresarInforme.Visible = false;
                        btnRechaza.Visible = false;
                        lblRechaza.Visible = false;
                        btnAprobar.Visible = false;
                        lblAprobar.Visible = false;
                        btnApruebaCertificacion.Visible = false;
                        lblApruebaCertificacion.Visible = false;

                        
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




                #endregion
            }
            if (FlagWF == 0)
            {
                #region WFArticulador
                string msg = "La aprobacion se realizo con exito";
                Master.MensajeOk(msg);


                /*Codigo WFArticulador*/

                if (ObjProcedimientoValidoManual.AsignacionWFArticulador(iIdConexion, "I", iIdTramite, iIdGrupoBeneficio, Convert.ToInt32(Par3), sObservacion, ref sMensajeError))
                {
                    msg = "La Aprobacion se realizo con exito";
                    Master.MensajeOk(msg);
                    pnlComponentesNew.Visible = false;
                    btnRegistrarCancha.Visible = false;
                    lblRegistroAportes.Visible = false;
                    btnIngresarInforme.Visible = false;
                    lblIngresarInforme.Visible = false;
                    btnRechaza.Visible = false;
                    lblRechaza.Visible = false;
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
    private void InsertarSalarioCotizable()
    {
        CleanControl(this.Controls);
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        pnlBusqueda.Visible = true;
        txtDescripcionRUC.AutoPostBack = true;
        txtSalarioCotizable.ReadOnly = false;
        txtDescripcionRUC.Text = ObjSeguridad.URLDecode(Request.QueryString["sRUC"]);
        txtPeriodoSalario.Text = ObjSeguridad.URLDecode(Request.QueryString["sFechaAfiliacion"]);

        String sPeriodoSalario = txtPeriodoSalario.Text;
        ObtenerTipoMoneda(sPeriodoSalario);
        pnlFormularioModifica.Visible = true;
        TipoDocumento(0);

        Parametrizacion(447, 448, 0);

        chkSalarioCotizable.Visible = false;
        hdfOperacion.Value = "I";


        // Obtiene el sector
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        string sMensajeError = null;

        string sRuc = txtDescripcionRUC.Text;
        txtRUC.Text = sRuc;

        int iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
        int iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
        DataTable Sector;
        Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRuc, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (Sector != null && Sector.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in Sector.Rows)
            {

                int iValido = Convert.ToInt32(drDataRow["Valido"]);
                string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                if (sCodigo == "C")
                {
                    chkRuc.Visible = false;
                    txtPeriodoSalario.Enabled = true;
                    txtMitas.Visible = true;
                    lblMitas.Visible = true;
                    rdbCertNormal.Checked = true;
                }
                else
                {
                    if (sCodigo == "F" && iValido == 1)
                    {
                        chkRuc.Visible = false;
                        txtPeriodoSalario.Enabled = false;
                        rdbCertDS29537.Visible = true;
                        rdbCertDS29537.Checked = true;
                        rdbCertDS29537.Enabled = true;
                        txtSalarioCotizable.Enabled = false;
                        ddlMonedaSalario.Enabled = false;
                        txtSalarioCotizable.Text = "349.92";
                        Moneda(324);
                        

                    }
                    else
                    {
                        chkRuc.Visible = false;
                        txtPeriodoSalario.Enabled = false;
                        txtMitas.Visible = false;
                        lblMitas.Visible = false;
                        rdbCertNormal.Checked = true;
                        rdbCertDS29537.Visible = false;
                    }

                }
            }
        }






        DescripcionRUC(txtRUC.Text);


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

    private void TipoDocumento(int IdTipoDocSalario)
    {
        ddlTipoDocumento.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(40);
        ddlTipoDocumento.DataValueField = "IdDetalleClasificador";
        ddlTipoDocumento.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoDocumento.DataBind();
        ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlTipoDocumento.SelectedValue = Convert.ToString(IdTipoDocSalario);
    }
    private void Moneda(int IdMonedaSalario)
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
    protected void btnRegistrarCancha_Click(object sender, EventArgs e)
    {
        string iIdTramite = Request.QueryString["iIdTramite"];
        string iIdGrupoBeneficio = Request.QueryString["iIdGrupoBeneficio"];
        string iVersion = ObjSeguridad.URLEncode("0");
        string sRUC = ObjSeguridad.URLEncode("0");
        string iComponente = ObjSeguridad.URLEncode("0");
        string vUrl = ViewState["PreviousPage"].ToString();
        vUrl = ObjSeguridad.URLEncode(vUrl);
        Response.Redirect("wfrmAportesSIR.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + "&iVersion=" + iVersion + "&sRUC=" + sRUC + "&iComponente=" + iComponente + "&vUrl=" + Server.UrlEncode(vUrl) + "");
    }
    protected void btnAdicionarInforme_Click(object sender, EventArgs e)
    {
        /*
         string iIdTramite = Request.QueryString["iIdTramite"];
        string iIdGrupoBeneficio = Request.QueryString["iIdGrupoBeneficio"];
        ScriptManager.RegisterStartupScript(this, GetType(), "RegistrarInforme", " window.open('wfrmIngresarInforme.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) +  "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        */
        string FechaInicio = lblFechaInicio.Text;
        string FechaAsg = lblFechaAsignacion.Text.Substring(0, 10);
        string Asegurado = lblPaterno.Text + ' ' + lblMaterno.Text + ' ' + lblNombres.Text;
        string Matricula = lblMatricula.Text;
        string Tramite = lblTramite.Text;
        pnlEditarInforme.Visible = true;
        ckeInforme.Text = "";
        btnActualizar.Visible = false;
        btnInsertarInforme.Visible = true;


    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        //Response.Redirect(@"~/EnvioAPS/wfrmGeneracionDeMedios.aspx";
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            //Redirect to Previous page by retrieving the PreviousPage Url from ViewState.
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
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
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    //protected void btnAlugar_Click(object sender, EventArgs e)
    //{
    //    int iIdConexion = (int)Session["IdConexion"];
    //    string cOperacion = "J";

    //    int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
    //    int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
    //    int iVersion = Convert.ToInt32(hfVersion.Value);
    //    int iIdTipoCC = 358;
    //    string sMensajeError = null;
    //    if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iIdTipoCC, ref sMensajeError))
    //    {
    //                string msg = "La aprobacion se realizo con exito";
    //                Master.MensajeOk(msg);
    //                btnAlugar.Visible = false;
    //                btnAlugarGlobal.Visible = false;
    //                ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
    //    }
    //    else
    //    {
    //        string Error = "Error al realizar la operación";
    //        string DetalleError = sMensajeError;
    //        Master.MensajeError(Error, DetalleError);
    //    }
    //}
    //protected void btnAlugarGlobal_Click(object sender, EventArgs e)
    //{
    //    int iIdConexion = (int)Session["IdConexion"];
    //    string cOperacion = "J";

    //    int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
    //    int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
    //    int iVersion = Convert.ToInt32(hfVersion.Value);
    //    int iIdTipoCC = 359;
    //    string sMensajeError = null;
    //    if (ObjProcedimientoValidoManual.RecursoReclamacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iIdTipoCC, ref sMensajeError))
    //    {
    //        string msg = "La aprobacion se realizo con exito";
    //        Master.MensajeOk(msg);
    //        btnAlugarGlobal.Visible = false;

    //        ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);



    //    }
    //    else
    //    {
    //        string Error = "Error al realizar la operación";
    //        string DetalleError = sMensajeError;
    //        Master.MensajeError(Error, DetalleError);
    //    }
    //}
    protected void rdbCertSalMin_CheckedChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        txtSalarioCotizable.Enabled = false;
        // Moneda(324);
        ddlMonedaSalario.Enabled = true;
        txtSalarioCotizable.Text = "1";




    }
    protected void rdbCertDS29537_CheckedChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        txtSalarioCotizable.Enabled = false;
        Moneda(324);
        ddlMonedaSalario.Enabled = false;
        txtSalarioCotizable.Text = "349.92";

    }
    protected void rdbCertNormal_CheckedChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        txtSalarioCotizable.Enabled = true;
        ddlMonedaSalario.Enabled = true;
        string sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + txtPeriodoSalario.Text)).Substring(3, 7);
        ObtenerTipoMoneda(sPeriodoSalario);
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
        int iIdTipoInforme=0;


        if (rbTipoInforme.SelectedValue =="1")
        {
            iIdTipoInforme = 1;
        }
        else 
        {
            iIdTipoInforme = 2;
        }
        if (ObjProcedimientoManual.IngresaInforme(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, 0, sInforme, iIdTipoInforme, ref sMensajeError))
        //Apruebaconinforme_Certificacion
        {
            string msg = "La aprobacion se realizo con exito";
            Master.MensajeOk(msg);
            pnlEditarInforme.Visible = false;
            hfCantidadInformes.Value = "0";
           
            ListaInformes(iIdTramite, iIdGrupoBeneficio);
            ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
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
            ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
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
                e.Row.FindControl("imgLevantar").Visible = true;
                e.Row.FindControl("imgVer").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;
                e.Row.FindControl("imgLevantar").Visible = false;
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
        hfCantidadInformes.Value =Convert.ToString(Convert.ToInt32(hfCantidadInformes.Value)+ iContador);
        
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

                string sInforme = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["Informe"]);                 
                sInforme = sInforme.Replace("<BR/>", "\n");
                sInforme = sInforme.Replace("<BR>", "\n");
                ckeInforme.Text = sInforme;

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
                    ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);

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
                    ListarComponentesNew(iIdTramite, iIdGrupoBeneficio);
                    

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
                //pnlEditarInforme.Visible = true;
                //btnActualizar.Visible = false;
                //btnInsertarInforme.Visible = false;
                int Index = Convert.ToInt32(e.CommandArgument);                
                string NroControl= Convert.ToString(gvDatosInformes.DataKeys[Index].Values["NroControl"]);
                string iIdTramite = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                string iIdTipoInforme = Convert.ToString(gvDatosInformes.DataKeys[Index].Values["IdTipoInforme"]);

                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteInformeCertificacion.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&NroControl=" + Server.UrlEncode(NroControl) + "&IdTipoInforme=" + Server.UrlEncode(iIdTipoInforme) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                

                

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }

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

        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosCorrelativo.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

    }
    protected void txtSector_TextChanged(object sender, EventArgs e)
    {
        //this.pnlFormularioModifica_ModalPopupExtender.Show();
        string sDescripcionSector = txtSector.Text;
        if (sDescripcionSector == "COMIBOL")
        {
            txtPeriodoSalario.ReadOnly = false;
            txtPeriodoSalario.Enabled = true;
            lblMitas.Visible = true;
            txtMitas.Visible = true;
            rdbCertNormal.Checked = true;
        }
        else
        {
            txtPeriodoSalario.ReadOnly = false;
            txtPeriodoSalario.Enabled = false;
            lblMitas.Visible = false;
            txtMitas.Visible = false;
            txtMitas.Text = "";

        }

    }
    protected void txtPeriodoSalario_TextChanged(object sender, EventArgs e)
    {
        string sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + txtPeriodoSalario.Text)).Substring(3, 7);

        ObtenerTipoMoneda(sPeriodoSalario);

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
        Moneda(iIdMoneda);

    }
    protected void btnCertificacionParcial_Click(object sender, ImageClickEventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();
        string iIdTramite = hfIdTramite.Value;
        string iIdGrupoBeneficio = hfIdGrupoBeneficio.Value;
        iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        iIdGrupoBeneficio = "3";
        iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        string iComponente = "0";
        iComponente = ObjSeguridad.URLEncode(iComponente);
        String CuentaUsuario = (string)Session["CuentaUsuario"];
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
}