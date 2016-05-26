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
//using System.Windows.Forms;



using System.Drawing;


public partial class CertificacionCC_wfrmAportesSIR: System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsParametrizacion ObjParametrizacion = new clsParametrizacion();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    DataTable objdtLista;
    protected void Page_Load(object sender, EventArgs e)
    
    {

        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            pnlFormularioModifica.Visible = false;
            int iIdTramite = 0;
            int iIdGrupoBeneficio = 0;
            int iVersion;
            string sRUC;
            int iComponente;
            lblMensajeNegativo.Visible = false;
            lblCooperativa.Visible = false;

            if (Request.QueryString["iIdTramite"] != null)
            {
                //ViewState["iIdTramite"] = iIdTramite = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdTramite"]));
                //ViewState["iIdGrupoBeneficio"] = iIdGrupoBeneficio = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iIdGrupoBeneficio"]));

                ViewState["iIdTramite"] = iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                ViewState["iIdGrupoBeneficio"] = iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                ViewState["vURL"] = Request.QueryString["vUrl"];

                if (Request.QueryString["iVersion"] != null)
                {
                    ViewState["iVersion"] = iVersion = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iVersion"]));
                    ViewState["sRUC"] = sRUC = Convert.ToString(ObjSeguridad.URLDecode(Request.QueryString["sRUC"]));
                    ViewState["iComponente"] = iComponente = Convert.ToInt32(ObjSeguridad.URLDecode(Request.QueryString["iComponente"]));
                }
                else
                {
                    ViewState["iVersion"] = iVersion = 0;
                    ViewState["sRUC"] = sRUC = "0";
                    ViewState["iComponente"] = iComponente = 0;

                }
                ListarActualizacionCC();
                DatosAsegurado(iIdTramite, iIdGrupoBeneficio);
                //hfIdTramite.Value = Convert.ToString(iIdTramite);
                //hfIdGrupoBeneficio.Value = Convert.ToString(iIdGrupoBeneficio);
                //hfVersion.Value = Convert.ToString(iVersion);
                //hfRUC.Value=Convert.ToString               

            }

            txtDescripcionRUC.Focus();
            txtDescripcionRUC.AutoPostBack = true;

            //objdtLista = new DataTable();
            //CrearTabla();
        }
    }
    private void CrearTabla()

{

objdtLista.Columns.Add("RUC");

objdtLista.Columns.Add("Descripcion");

objdtLista.Columns.Add("Sector");

objdtTabla = objdtLista;

}
    
    private void AgregarFila(string sRUC, string sDescripcion, string sSector)
    {

        DataTable dt = objdtTabla;

        DataRow drFila = dt.NewRow();

        drFila["RUC"] = sRUC;

        drFila["Descripcion"] = sDescripcion;

        drFila["Sector"] = sSector;

        dt.Rows.Add(drFila);

        objdtTabla = dt;

    }
    private void EliminarFila(int fila)
    {

        DataTable dt = objdtTabla;
        dt.Rows.RemoveAt(fila);
        objdtTabla = dt;

    }
    
    protected DataTable objdtTabla
    {

        get
        {

            if (ViewState["objdtTabla"] != null)
            {

                return (DataTable)ViewState["objdtTabla"];

            }

            else
            {

                return objdtLista;

            }

        }

        set
        {

            ViewState["objdtTabla"] = value;

        }

    }
   

    #region INTERFAZ
    
    private void CambiarInterfaz()
    {


        AgregarJSAtributos(txtFechaAfiliacion, txtFechaBaja);        
        AgregarJSAtributos(txtFechaBaja, ddlParametrizacion);
        
        
   
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
    private void DatosAsegurado(int iIdTramite,int iIdGrupoBeneficio)
    {
        
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        DataTable tblListaDatosAsegurado = null;
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAsegurado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblListaDatosAsegurado != null && tblListaDatosAsegurado.Rows.Count > 0)
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
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }
    // Lista los componentes que se estan certificando o no
    private void ListarActualizacionCC()
    {
        objdtLista = new DataTable();
        if (objdtTabla.Rows.Count < 1)
        {
            CrearTabla();
        }
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";                
        string sMensajeError = null;
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        int iVersion = (int)ViewState["iVersion"];
        string sRuc = (string)ViewState["sRUC"];
        int iComponente =(int) ViewState["iComponente"];
        DataTable tblDatosActualizacionCC= ObjProcedimientoManual.ListaActualizacionCC(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio,iVersion,sRuc,iComponente, ref sMensajeError);
        if (tblDatosActualizacionCC==null)
        {
            gvDatosComponentes.Visible = false;
            CleanControl(this.Controls);
            txtDescripcionRUC.Focus();
            txtDescripcionRUC.AutoPostBack = true;
            hdfOperacion.Value = "I";
            Habilita_paneles_insertar();
           

        }
        else
        {
            if (objdtTabla.Rows.Count < 1)
            {
                DataView MyView = new DataView(tblDatosActualizacionCC);
                DataTable tblEmpresas = null;
                tblEmpresas = MyView.ToTable(true, "RUC");
                //gvDatosRuc.DataBind();
                foreach (DataRow drDataRow in tblEmpresas.Rows)
                {

                    string sRucRegistrado = Convert.ToString(drDataRow["RUC"]);
                    DescripcionRUC(sRucRegistrado);

                    string sDescripcion, sSector;

                    sDescripcion = txtDetRUC.Text;

                    sSector = txtSector.Text;

                    AgregarFila(sRucRegistrado, sDescripcion, sSector);
                    gvDatosRuc.DataSource = objdtTabla;
                    gvDatosRuc.DataBind();


                }
                hdfOperacion.Value = "I";
            }

            
            gvDatosComponentes.Visible = true;

            if ((int)Session["RolUsuario"] == 9) //Verificador
            {

                if (tblDatosActualizacionCC.Rows.Count > 7)
                {
                    pnlBotonesAuxiliares.Visible = false;

                }
                else
                {
                    pnlBotonesAuxiliares.Visible = false;
                }
                hdfOperacion.Value = "I";
                Habilita_paneles_insertar();
            }

        }
       
        gvDatosComponentes.DataSource = tblDatosActualizacionCC;
        gvDatosComponentes.DataBind();


        ddlParametrizacion.Items.Clear();
        ddlParametrizacion.ClearSelection();                
        ddlParametrizacion.DataSource = tblDatosActualizacionCC;
        ddlParametrizacion.DataValueField = "DDLGlosaCertificacion";
        ddlParametrizacion.DataTextField = "DDLGlosaCertificacion";
        ddlParametrizacion.DataBind();
        ddlParametrizacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlParametrizacion.SelectedValue = Convert.ToString(0);
        
        
        



        if ((int)Session["RolUsuario"] == 9) //Verificador
        {
            if (tblDatosActualizacionCC == null)
            {
                btnGeneracion.Visible = true;
                btnGeneracion2.Visible = true;
                pnlBusqueda.Visible = true;
                
            }
            else
            {
                
                //btnGeneracion.Visible = true;

                pnlComponentesNew.Visible = true;
                pnlFormularioModifica.Visible = true;                
                pnlBusqueda.Visible = false;

                btnGeneracion.Visible = true;
                lblSalario.Visible = true;
            }
        }

       
    }
   //Añadir componente certificado o no
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        try
        {
            DeshabilitaPaneles();
            string sMensajeError = null;
            int iIdConexion = (int)Session["IdConexion"];            
            string cOperacion = hdfOperacion.Value;
            string sRUC=null;
            string sFechaAfiliacionAnt = null;
            string sFechaBajaAnt=null;
            if (cOperacion== "I")
            {
                 sRUC = ddlRazonSocial.SelectedValue;

            }
            if (cOperacion == "U")
            {
                

                 //sRUC = txtRUC.Text;
                sRUC = ddlRazonSocial.SelectedValue;
                 sFechaAfiliacionAnt = hfFechaInicioAnt.Value;
                 sFechaBajaAnt = hfFechaBajaAnt.Value;

            }

            int iIdTramite = (int)ViewState["iIdTramite"];
            int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
            int iVersion = (int)ViewState["iVersion"];            
            int iComponente = (int)ViewState["iComponente"];            
            
            int iAnio = Convert.ToInt32(lblAnios.Text);
            int iMes = Convert.ToInt32(lblMeses.Text);


            string sFechaAfiliacion = Convert.ToString(Convert.ToDateTime("01/" + txtFechaAfiliacion.Text)).Substring(3, 7);
            string sFechaBaja = Convert.ToString(Convert.ToDateTime("01/" + txtFechaBaja.Text)).Substring(3, 7);
            int iPeriodoVerificado;
            if (chbCertificado.Checked)
            {
                iPeriodoVerificado = 1;
            }
            else
            {
                iPeriodoVerificado = 0;
            }
            
            //int iIdParametrizacion = Convert.ToInt32(ddlParametrizacion.SelectedValue);           
            int iIdParametrizacion = 0;
            string sGlosa = txtGlosaSalario.Text;
            sGlosa = sGlosa.Replace("\n", "<BR/>");
            sGlosa=sGlosa.ToUpper();

            if (ObjProcedimientoManual.InsertaActualizacionCC(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, sRUC, sFechaAfiliacion, sFechaBaja, sFechaAfiliacionAnt, sFechaBajaAnt,iPeriodoVerificado, iIdParametrizacion, sGlosa, iAnio, iMes, ref sMensajeError))
            {
                this.pnlFormularioModifica_ModalPopupExtender.Show();                
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                //ListarActualizacionCC();
                pnlInsertaDetalle.Visible = false;
               
                        if (ObjProcedimientoManual.ActualizaDensidad(iIdConexion, "U", iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, ref sMensajeError))
                        {                
                            msg = "La operacion se realizo con exito ";
                            Master.MensajeOk(msg);
                            ListarActualizacionCC();
                            if (cOperacion == "I")
                            {
                                pnlVisibleRegistroAporte();
                            }
                        }
                        else
                        {
                            this.pnlFormularioModifica_ModalPopupExtender.Show();
                            string Error = "Error al realizar la operación";
                            string DetalleError = sMensajeError;
                            Master.MensajeError(Error, DetalleError);
                            Master.MensajeErrorVisible();
                            DetalleError = DetalleError.Replace("\n", "");
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: " + DetalleError + "', 'height=600, width=400, toolbar=0, menubar=0, status=0, location=0')", true);
                            //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "&iComponente=" + Server.UrlEncode(iComponente) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

                           
                        }
                        
            }
            else
            {
                this.pnlFormularioModifica_ModalPopupExtender.Show();               
                string Error = "Error al realizar la operación" + sMensajeError;
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
           
                DetalleError = DetalleError.Replace("\n", "");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR:" + DetalleError + "', 'height=600, width=400, toolbar=0, menubar=0, status=0, location=0')", true);
                //Master.MensajeErrorVisible();
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR: " + Error + "', 'height=600, width=400, toolbar=0, menubar=0, status=0, location=0')", true);
            //Master.MensajeErrorVisible();
            
        }
    }

  
    // Cierra popup
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlFormularioModifica.Visible = true;
        pnlBusqueda.Visible = false;
        pnlComponentesNew.Visible = true;
        pnlInsertaDetalle.Visible = false;
        txtDescripcionRUC.AutoPostBack = false;
        txtDescripcionRUC.Text = "";
        lblRUC.Visible = false;
        lblMenuRazon.Visible = false;
        lblDescripcionRuc.Visible = true;
        lblSector.Visible = false;
        txtDetRUC.Visible = false;
        txtRUC.Visible = false;
        txtSector.Visible = false;
        DatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);

    }

  
    //Ejectua el metodo de busqueda de la Razon Social o Ruc
    protected void txtDescripcionRUC_TextChanged(object sender, EventArgs e)
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        string sDescripcionRuc = txtDescripcionRUC.Text;
        int posicionfinal = sDescripcionRuc.IndexOf('/');
        string sRuc = sDescripcionRuc.Substring(4, posicionfinal - 4);
        txtRUC.Text = sRuc;
        DescripcionRUC(txtRUC.Text);
        

        string sDescripcion, sSector;

        sRuc = txtRUC.Text;

        sDescripcion = txtDetRUC.Text;

        sSector = txtSector.Text;

        AgregarFila(sRuc, sDescripcion, sSector);

        
        gvDatosRuc.DataSource = objdtTabla;
        gvDatosRuc.DataBind();

        RazonSocial();
        txtDescripcionRUC.Text = "";
        txtDescripcionRUC.Focus();

    }
    protected void gvDatosRuc_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEliminar")
        {
            try
            {

                int Index = Convert.ToInt32(e.CommandArgument);
                pnlFormularioModifica.Visible = false;

                string sRuc= Convert.ToString(gvDatosRuc.DataKeys[Index].Values["RUC"]);
                EliminarFila(Index);
                gvDatosRuc.DataSource = objdtTabla;
                gvDatosRuc.DataBind();

                CleanControl(this.Controls);
                txtDescripcionRUC.Focus();                
                hdfOperacion.Value = "I";
                Habilita_paneles_insertar();
                

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
       
        
    }
   
    //Codigo que oculta el boton editar en el caso de no certificado)
    protected void gvDatosComponentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex)+1;            
            int iIdTramite = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            int iVersion = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["Version"]);
            string sRUC = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["RUC"]);
            string iComponente = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["Componente"]);
            string sFechaAfiliacion = Convert.ToString(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["FechaAfiliacion"]);
            int iEstadoSalario = Convert.ToInt32(gvDatosComponentes.DataKeys[e.Row.RowIndex].Values["EstadoSalario"]);

            if (iComponente != "0")
            {
                lblNumeroComponente.Text = "Componente Nº " + iComponente;
                lblNumeroComponente.Visible = true;
            }
            else
            {
                lblNumeroComponente.Visible = false;
            }
         

            if (iEstadoSalario == 0)
            {
                if ((int)Session["RolUsuario"] == 9) //Verificador
                {
                    e.Row.FindControl("imgEditar").Visible = true;
                    e.Row.FindControl("imgEliminar").Visible = true;                   

                }
                else
                {
                    e.Row.FindControl("imgEditar").Visible = false;
                    e.Row.FindControl("imgEliminar").Visible = false;
                    gvDatosComponentes.Columns[10].Visible = false;
                    // gvDatosComponentes.Columns[11].Visible = false;
                    btnGuardaCert.Visible = false;
                    btnInsertarSalarioCotizable.Visible = false;
                    lblEmpresas.Visible = false;
                    lblAportes.Visible = false;
                    btnGeneracion.Visible = false;



                    btnInsertar.Visible = false;
                    btnGeneracion.Visible = false;
                    btnGeneracion2.Visible = false;
                    btn1.Visible = false;
                    btn2.Visible = false;
                    lblSalario.Visible = false;
                    lblAportes.Visible = false;
                    pnlFormularioModifica.Visible = true;
                    pnlBusqueda.Visible = false;
                    pnlComponentesNew.Visible = true;


                }
            }
            else
            {
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;
                gvDatosComponentes.Columns[10].Visible = false;
                // gvDatosComponentes.Columns[11].Visible = false;
                btnGuardaCert.Visible = false;
                btnInsertarSalarioCotizable.Visible = false;
                btnInsertar.Visible = false;
                btnGeneracion.Visible = true;
                btnGeneracion2.Visible = true;
                btn1.Visible = false;
                btn2.Visible = false;
                pnlFormularioModifica.Visible = true;
                pnlComponentesNew.Visible = true;
            }
            
            
        }
    }
    private void DescripcionRUC(string sRUC)
    {
        DataTable tblDescripcionRUC = null;
        tblDescripcionRUC = ObjProcedimientoValidoManual.DescripcionRuc(sRUC);
        if (tblDescripcionRUC != null && tblDescripcionRUC.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in tblDescripcionRUC.Rows)
            {
                txtDetRUC.Text = Convert.ToString(drDataRow["NombreEmpresa"]);
                txtSector.Text = Convert.ToString(drDataRow["DescripcionSector"]);

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

                this.pnlFormularioModifica_ModalPopupExtender.Show();
                txtDescripcionRUC.AutoPostBack = true;
                hdfOperacion.Value = "U";
                int Index = Convert.ToInt32(e.CommandArgument);
                Habilita_paneles_insertar();

                
                
                hfIdTramite.Value= Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                hfIdGrupoBeneficio.Value= Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                hfVersion.Value = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                hfRUC.Value = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                hfComponente.Value= Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Componente"]);
                hfFechaAfiliacion.Value = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["FechaAfiliacion"]);

                txtRUC.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                txtDetRUC.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["NombreEmpresa"]);
                txtSector.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["DescripcionSector"]);
                txtFechaAfiliacion.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["FechaAfiliacion"]);
                txtFechaBaja.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["FechaBajaAfilia"]);
                hfFechaInicioAnt.Value = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["FechaAfiliacion"]);
                hfFechaBajaAnt.Value= Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["FechaBajaAfilia"]);
                int IdParametrizacion;

                RazonSocial();
                ddlRazonSocial.Visible = true;
                ddlRazonSocial.SelectedValue = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                //if (Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdParametrizacion"]) == "")
                //{
                //    IdParametrizacion=0;
                //}
                //else
                //{
                //    IdParametrizacion = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdParametrizacion"]);
                //}
                IdParametrizacion = 0;
                string GlosaSalario = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["GlosaCertificacion"]);
                GlosaSalario = GlosaSalario.Replace("<BR/>", "\n");
                GlosaSalario = GlosaSalario.Replace("<BR>", "\n");

                lblAnios.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["AnioCotiza"]);
                lblMeses.Text = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["MesesCotiza"]);
                int PeriodoVerificado = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["PeriodoVerificado"]);
                int iCertificado;
                if (PeriodoVerificado == 1)
                {
                    chbCertificado.Checked=true;
                    iCertificado = 448;
                }
                else
                {
                    chbCertificado.Checked = false;
                    iCertificado = 449;
                }


                //Parametrizacion(446, iCertificado, IdParametrizacion);
                txtGlosaSalario.Text = GlosaSalario;
                
                txtFechaAfiliacion.Enabled = true;
                txtFechaBaja.Enabled = true;
                //chbEditar.Visible = true;


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
                string cOperacion ="D";
                string sMensajeError = null;
                   
                ViewState["iIdTramite"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                ViewState["iIdGrupoBeneficio"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);
                ViewState["iVersion"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Version"]);
                ViewState["sRUC"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]);
                ViewState["iComponente"] = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["Componente"]);
                ViewState["sFechaAfiliacion"] = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["FechaAfiliacion"]);
                int PeriodoVerificado = Convert.ToInt32(gvDatosComponentes.DataKeys[Index].Values["PeriodoVerificado"]);

                int iIdTramite = (int)ViewState["iIdTramite"];
                int iIdGrupoBeneficio=(int)ViewState["iIdGrupoBeneficio"];
                int iVersion=(int)ViewState["iVersion"];
                string sRUC=(string)ViewState["sRUC"];
                int iComponente = (int)ViewState["iComponente"];
                string fFechaAfiliacion = (string)ViewState["sFechaAfiliacion"];


                
                    if (ObjProcedimientoManual.InsertaActualizacionCC(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, sRUC, fFechaAfiliacion, "", "", "", PeriodoVerificado, 0, "", 0, 0, ref sMensajeError))
                {
                    string msg= "La operacion se realizo con exito";
                    //Master.MensajeOk(msg);
                    //ListarActualizacionCC();
                    if (ObjProcedimientoManual.ActualizaDensidad(iIdConexion, "U", iIdTramite, iIdGrupoBeneficio, iVersion, iComponente, ref sMensajeError))
                    {
                        msg = "La operacion se realizo con exito";
                        Master.MensajeOk(msg);
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
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                    Master.MensajeErrorVisible();
                }
                ListarActualizacionCC();         

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdCancha")
        {
            
                int Index = Convert.ToInt32(e.CommandArgument);
                //string iIdTramite = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]));
                //string iIdGrupoBeneficio = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]));

                string iIdTramite = Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdTramite"]);
                string iIdGrupoBeneficio =Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["IdGrupoBeneficio"]);

                string iVersion = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Version"]));
                string sRUC = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["RUC"]));
                string iComponente = ObjSeguridad.URLEncode(Convert.ToString(gvDatosComponentes.DataKeys[Index].Values["Componente"]));

                Response.Redirect("wfrmAportesSIR.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + "&iVersion=" + Server.UrlEncode(iVersion) + "&sRUC= " + Server.UrlEncode(sRUC) + "&iComponente= " + Server.UrlEncode(iComponente) + "&vUrl=" + Server.UrlEncode(ViewState["vURL"].ToString()) + " ");
            
        }
    }
    protected void ddlParametrizacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obtener la descripcion de la parametrizacion y mostrar en la gloza
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        //int iIdParametrizacion=Convert.ToInt32(ddlParametrizacion.SelectedValue);
        //string Glosa = ObjParametrizacion.ListaParametrizacion(0, 0, iIdParametrizacion, Convert.ToString(Convert.ToDateTime("01/" + txtFechaAfiliacion.Text)).Substring(3, 7), Convert.ToString(Convert.ToDateTime("01/" + txtFechaBaja.Text)).Substring(3, 7)).Rows[0]["Glosa"].ToString();
        string Glosa = ddlParametrizacion.SelectedValue;
        txtGlosaSalario.Text = Glosa;
    }
    private void DescripcionGlosa(string descripcion)
    {   
       
            txtGlosaSalario.Text=descripcion;
       
        
    }
    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = Convert.ToInt32(hfVersion.Value);




        if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, null, 0, ref sMensajeError))
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
    protected void btnApruebaCertificacion_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "R";
        string sMensajeError = null;
        int iIdTramite = Convert.ToInt32(hfIdTramite.Value);
        int iIdGrupoBeneficio = Convert.ToInt32(hfIdGrupoBeneficio.Value);
        int iVersion = Convert.ToInt32(hfVersion.Value);




        if (ObjProcedimientoValidoManual.EliminayAprueba_Certificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, iVersion, null, 0, ref sMensajeError))
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
    protected void btnInsertarSalarioCotizable_Click(object sender, EventArgs e)
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        CleanControl(this.Controls);
        txtDescripcionRUC.Focus();    
        txtDescripcionRUC.AutoPostBack = true;        
        hdfOperacion.Value = "I";
        Habilita_paneles_insertar();
    }
    public void CleanControl(ControlCollection controles)
    {
        
        foreach (Control control in controles)
        {
            if (control is TextBox)
                ((TextBox)control).Text = string.Empty;
            //else if (control is  Label)
            //    ((Label)control).Text = string.Empty;
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
    public void Habilita_paneles_insertar()
    {
        if (hdfOperacion.Value=="I")
        {
        pnlFormularioModifica.Visible = true;
        pnlBusqueda.Visible = true;
        pnlInsertaDetalle.Visible = false;
        pnlComponentesNew.Visible = false;
        DatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);        
        }
        if (hdfOperacion.Value == "U")
        {
            pnlFormularioModifica.Visible = true;
            pnlInsertaDetalle.Visible = true;
            pnlBusqueda.Visible = false;
            pnlComponentesNew.Visible = true;
            txtFechaAfiliacion.ReadOnly = false;

            lblMenuRazon.Visible = false;
            lblRUC.Visible = true;
            lblSector.Visible = true;
            lblDescripcionRuc.Visible = true;

            ddlRazonSocial.Visible = false;
            
            txtDetRUC.Visible = true;
            txtRUC.Visible = true;
            txtSector.Visible = true;
            DatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);
        }
        
        

    }
    public void DeshabilitaPaneles()
    {
        pnlFormularioModifica.Visible = true;
        pnlBusqueda.Visible = false;
        pnlInsertaDetalle.Visible = true;
        pnlComponentesNew.Visible = true;
        lblRUC.Visible = false;
        lblDescripcionRuc.Visible = true;
        lblMenuRazon.Visible = false;
        lblSector.Visible = false;
        txtDetRUC.Visible = false;
        txtRUC.Visible = false;
        txtSector.Visible = false;
    }


    private void Parametrizacion(int TipoCertificacion, int EstadoCertificacion, int IdParametrizacion = 0)
    {

        ddlParametrizacion.ClearSelection();
        ddlParametrizacion.DataSource = ObjParametrizacion.ListaParametrizacion(TipoCertificacion, EstadoCertificacion, IdParametrizacion,null,null);
        ddlParametrizacion.DataValueField = "IdParametrizacion";
        ddlParametrizacion.DataTextField = "DescripcionCertificacion"; 
        ddlParametrizacion.DataBind();
        ddlParametrizacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlParametrizacion.SelectedValue = Convert.ToString(IdParametrizacion);

    }
    private void RazonSocial()
    {

        ddlRazonSocial.ClearSelection();
        ddlRazonSocial.DataSource = objdtTabla;
        ddlRazonSocial.DataValueField = "RUC";
        ddlRazonSocial.DataTextField = "Descripcion";
        ddlRazonSocial.DataBind();
        ddlRazonSocial.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlRazonSocial.SelectedValue = Convert.ToString(0);

    }
    protected void txtFechaBaja_TextChanged(object sender, EventArgs e)
     {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        int iIdConexion = (int)Session["IdConexion"];
        
        string sMensajeError = null;
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        if (txtFechaAfiliacion.Text != "")
        {
            if (txtFechaBaja.Text != "")
            {
                string sAnios = Convert.ToString(Convert.ToDateTime("01/" + txtFechaAfiliacion.Text)).Substring(3, 7);
                string sMeses = Convert.ToString(Convert.ToDateTime("01/" + txtFechaBaja.Text)).Substring(3, 7);

                DataTable AnioMes;
                string cOperacion = "B";
                DataTable Sector;
                string sRUC = null;

                if (ddlRazonSocial.SelectedValue == "")
                {
                    sRUC = txtRUC.Text;
                }
                else
                {
                    sRUC = ddlRazonSocial.SelectedValue;
                }

                if (txtFechaBaja.Text != null && txtFechaBaja.Text != "")
                {
                    Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRUC, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
                    if (Sector != null && Sector.Rows.Count > 0)
                    {
                        foreach (DataRow drDataRow in Sector.Rows)
                        {

                            int iValido = Convert.ToInt32(drDataRow["Valido"]);
                            string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                            int Origen = Convert.ToInt32(drDataRow["Origen"]);
                            if (Origen == 342) // FA MANUAL CONTINUO
                            {
                                DateTime fFechaAfiliacion = Convert.ToDateTime("01/" + txtFechaAfiliacion.Text);
                                DateTime fFechaBaja = Convert.ToDateTime("01/" + txtFechaBaja.Text);
                                DateTime fCooperativa = Convert.ToDateTime("01/05/1997");
                                if (fFechaAfiliacion <= fCooperativa && fFechaBaja <= fCooperativa)
                                {
                                    if (fFechaAfiliacion <= fFechaBaja)
                                    {
                                        btnInsertar.Visible = true;
                                        lblCooperativa.Visible = false;
                                        lblMensajeNegativo.Visible = false;
                                        cOperacion = "E";
                                        AnioMes = ObjProcedimientoManual.CalculoAniosMeses(iIdConexion, cOperacion, sAnios, sMeses, ref sMensajeError);
                                        if (AnioMes != null && AnioMes.Rows.Count > 0)
                                        {
                                            foreach (DataRow drDataRoww in AnioMes.Rows)
                                            {


                                                lblAnios.Text = Convert.ToString(drDataRoww["anios"]);
                                                lblMeses.Text = Convert.ToString(drDataRoww["meses"]);

                                            }
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
                                        lblMensajeNegativo.Visible = true;
                                        lblMensajeNegativo.Text = "La Fecha inicio no puede ser mayor a la Fecha Baja";
                                        btnInsertar.Visible = false;
                                        lblAnios.Text = "";
                                        lblMeses.Text = "";

                                    }
                                }
                                else
                                {
                                    lblCooperativa.Visible = true;
                                    lblCooperativa.Text = "El sector es Fuerza Armada la fecha del aporte debe ser a 05/1997";
                                    btnInsertar.Visible = false;
                                }

                            }
                            else
                            {
                                DateTime fFechaAfiliacion = Convert.ToDateTime("01/" + txtFechaAfiliacion.Text);
                                DateTime fFechaBaja = Convert.ToDateTime("01/" + txtFechaBaja.Text);
                                DateTime fCooperativa = Convert.ToDateTime("01/04/1997");
                                if (fFechaAfiliacion <= fCooperativa && fFechaBaja <= fCooperativa)
                                {
                                    if (fFechaAfiliacion <= fFechaBaja)
                                    {
                                        btnInsertar.Visible = true;
                                        lblCooperativa.Visible = false;
                                        lblMensajeNegativo.Visible = false;

                                        cOperacion = "E";
                                        AnioMes = ObjProcedimientoManual.CalculoAniosMeses(iIdConexion, cOperacion, sAnios, sMeses, ref sMensajeError);
                                        if (AnioMes != null && AnioMes.Rows.Count > 0)
                                        {
                                            foreach (DataRow drDataRoww in AnioMes.Rows)
                                            {

                                                lblAnios.Text = Convert.ToString(drDataRoww["anios"]);
                                                lblMeses.Text = Convert.ToString(drDataRoww["meses"]);

                                            }
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
                                        lblMensajeNegativo.Visible = true;
                                        lblMensajeNegativo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Baja";
                                        btnInsertar.Visible = false;
                                        lblAnios.Text = "";
                                        lblMeses.Text = "";

                                    }
                                }
                                else
                                {
                                    lblCooperativa.Visible = true;
                                    lblCooperativa.Text = "Segun el sector  la fecha del aporte debe ser a 04/1997";
                                    btnInsertar.Visible = false;
                                }

                            }
                        }
                    }
                }
            }
        }

    }
    protected void btnGeneracion_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;

        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        int iVersion=(int)ViewState["iVersion"];        
        int iComponente = (int)ViewState["iComponente"];
        string sRUC=null;
        string sFechaAfiliacion=null;
        string sOpe=null;


        DataTable UltimoRUC;
        UltimoRUC = ObjProcedimientoManual.ObtenerUltimoRUC(iIdConexion, cOperacion,iIdTramite,iIdGrupoBeneficio,iVersion,iComponente, ref sMensajeError);
        if (sMensajeError != null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El componente no es simultaneo')", true);
        }
        else
        {
            if (UltimoRUC != null)
            {
                foreach (DataRow drDataRow in UltimoRUC.Rows)
                {
                    sRUC = Convert.ToString(drDataRow["RUC"]);
                    sFechaAfiliacion = Convert.ToString(drDataRow["FechaAfiliacion"]);
                    sOpe = Convert.ToString(drDataRow["Operacion"]);

                }
                //string sIdTramite = ObjSeguridad.URLEncode(Convert.ToString((int)ViewState["iIdTramite"]));
                //string sIdGrupoBeneficio = ObjSeguridad.URLEncode(Convert.ToString((int)ViewState["iIdGrupoBeneficio"]));

                string sIdTramite = Convert.ToString((int)ViewState["iIdTramite"]);
                string sIdGrupoBeneficio = Convert.ToString((int)ViewState["iIdGrupoBeneficio"]);

                sRUC = ObjSeguridad.URLEncode(sRUC);
                sFechaAfiliacion = ObjSeguridad.URLEncode(sFechaAfiliacion);
                if (sOpe == "U")
                {
                    Response.Redirect("wfrmProcedimientoManual.aspx?iIdTramite=" + sIdTramite + "&iIdGrupoBeneficio=" + sIdGrupoBeneficio + "&sRUC=" + Server.UrlEncode(sRUC) + "&sFechaAfiliacion=" + Server.UrlEncode(sFechaAfiliacion) + "&sOpe=" + sOpe + "&iComp=" + iComponente + "&vUrl=" + Server.UrlEncode(ViewState["vURL"].ToString()) + "");
                }
                else
                {
                    Response.Redirect("wfrmProcedimientoManual.aspx?iIdTramite=" + sIdTramite + "&iIdGrupoBeneficio=" + sIdGrupoBeneficio + "&sRUC=" + Server.UrlEncode(sRUC) + "&sFechaAfiliacion=" + Server.UrlEncode(sFechaAfiliacion) + "&vUrl=" + Server.UrlEncode(ViewState["vURL"].ToString()) + "");
                }

            }
            else
            {
                //string sIdTramite = ObjSeguridad.URLEncode(Convert.ToString((int)ViewState["iIdTramite"]));
                //string sIdGrupoBeneficio = ObjSeguridad.URLEncode(Convert.ToString((int)ViewState["iIdGrupoBeneficio"]));

                string sIdTramite = Convert.ToString((int)ViewState["iIdTramite"]);
                string sIdGrupoBeneficio = Convert.ToString((int)ViewState["iIdGrupoBeneficio"]);
                Response.Redirect("wfrmProcedimientoManual.aspx?iIdTramite=" + sIdTramite + "&iIdGrupoBeneficio=" + sIdGrupoBeneficio + "&vUrl=" + Server.UrlEncode(ViewState["vURL"].ToString()) + "");
            }
        }
    }
    protected void btnVerCabecera_Click(object sender, EventArgs e)
    {
        clsSeguridad ObjSeguridad = new clsSeguridad();         
        string iIdTramite =Convert.ToString((int)ViewState["iIdTramite"] );
        string iIdGrupoBeneficio = Convert.ToString((int)ViewState["iIdGrupoBeneficio"]);
        //iIdTramite = ObjSeguridad.URLEncode(iIdTramite);
        //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
        iIdTramite = iIdTramite;
        iIdGrupoBeneficio = iIdGrupoBeneficio;
        Response.Redirect("wfrmProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + "&vUrl=" + Server.UrlEncode(ViewState["vURL"].ToString()) + " ");
    }   
    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        pnlComponentesNew.Visible = true;
        pnlInsertaDetalle.Visible = true;
        pnlBusqueda.Visible = false;
        lblRUC.Visible = false;
        lblMenuRazon.Visible = true;
        lblDescripcionRuc.Visible = false;
        lblSector.Visible = false;

        RazonSocial();
        ddlRazonSocial.Visible = true;
        
        txtDetRUC.Visible = false;
        txtRUC.Visible = false;
        txtSector.Visible = false;
        //Parametrizacion(446, 449, 0);
        txtFechaAfiliacion.Enabled = true;
        txtFechaBaja.Enabled = true;
        //chbEditar.Visible = false;

    }
    protected void btnGuardaCert_Click(object sender, EventArgs e)
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        CleanControl(this.Controls);
        
        pnlFormularioModifica.Visible = true;
        pnlInsertaDetalle.Visible = true;
        pnlBusqueda.Visible = false;
        lblRUC.Visible = false;
        lblMenuRazon.Visible = true;
        lblDescripcionRuc.Visible = false;
        lblSector.Visible = false;
        RazonSocial();
        ddlRazonSocial.Visible = true;

        txtDetRUC.Visible = false;
        txtRUC.Visible = false;
        txtSector.Visible = false;
        DatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);
        pnlComponentesNew.Visible = true;
        lblAnios.Text = "";
        lblMeses.Text = "";
        //Parametrizacion(446, 449, 0);
        txtFechaAfiliacion.Enabled = true;
        txtFechaBaja.Enabled = true;       
        //chbEditar.Visible = false;
    }
    protected void pnlVisibleRegistroAporte()
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        CleanControl(this.Controls);

        pnlFormularioModifica.Visible = true;
        pnlInsertaDetalle.Visible = true;
        pnlBusqueda.Visible = false;
        lblRUC.Visible = false;
        lblMenuRazon.Visible = true;
        lblDescripcionRuc.Visible = false;
        lblSector.Visible = false;
        RazonSocial();
        ddlRazonSocial.Visible = true;

        txtDetRUC.Visible = false;
        txtRUC.Visible = false;
        txtSector.Visible = false;
        DatosAsegurado((int)ViewState["iIdTramite"], (int)ViewState["iIdGrupoBeneficio"]);
        pnlComponentesNew.Visible = true;
        lblAnios.Text = "";
        lblMeses.Text = "";
        //Parametrizacion(446, 449, 0);
        txtFechaAfiliacion.Enabled = true;
        txtFechaBaja.Enabled = true;
    }

    protected void chbCertificado_CheckedChanged(object sender, EventArgs e)
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        if (txtFechaAfiliacion.Text != "" || txtFechaBaja.Text != "")
        {
            ValidaFechas();
        }
        


        //int iCertificado;
        //if (chbCertificado.Checked == true)
        //{
        //     iCertificado = 448; // CERTIFICA
        //}
        //else
        //{
        //     iCertificado = 449; //NO CERTIFICA
        //}


        //Parametrizacion(446, iCertificado, 0);
    }
    protected void txtFechaAfiliacion_TextChanged(object sender, EventArgs e)
    {
        this.pnlFormularioModifica_ModalPopupExtender.Show();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        DataTable Sector;
        string sMensajeError = null;
        int iIdTramite=(int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio=(int)ViewState["iIdGrupoBeneficio"];
        string sMeses = null;
        string sRUC = null;
        string sAnios = null;

        if (ddlRazonSocial.SelectedValue == "")
        {
            sRUC = txtRUC.Text;
        }
        else
        {
            sRUC=ddlRazonSocial.SelectedValue;
        }
        if (txtFechaBaja.Text != "")
        {
            if (txtFechaAfiliacion.Text != "")
            {
                sAnios = Convert.ToString(Convert.ToDateTime("01/" + txtFechaAfiliacion.Text)).Substring(3, 7);
                /*if (txtFechaBaja.Text!="")
                {*/
                sMeses = Convert.ToString(Convert.ToDateTime("01/" + txtFechaBaja.Text)).Substring(3, 7);


                DataTable AnioMes;

                if (txtFechaBaja.Text != null && txtFechaBaja.Text != "")
                {
                    Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRUC, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
                    if (Sector != null && Sector.Rows.Count > 0)
                    {
                        foreach (DataRow drDataRow in Sector.Rows)
                        {

                            int iValido = Convert.ToInt32(drDataRow["Valido"]);
                            string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                            int Origen = Convert.ToInt32(drDataRow["Origen"]);
                            if (Origen == 342) // FA MANUAL CONTINUO
                            {
                                DateTime fFechaAfiliacion = Convert.ToDateTime("01/" + txtFechaAfiliacion.Text);
                                DateTime fFechaBaja = Convert.ToDateTime("01/" + txtFechaBaja.Text);
                                DateTime fCooperativa = Convert.ToDateTime("01/05/1997");
                                if (fFechaAfiliacion <= fCooperativa && fFechaBaja <= fCooperativa)
                                {
                                    if (fFechaAfiliacion <= fFechaBaja)
                                    {
                                        btnInsertar.Visible = true;
                                        lblCooperativa.Visible = false;
                                        lblMensajeNegativo.Visible = false;
                                        cOperacion = "E";
                                        AnioMes = ObjProcedimientoManual.CalculoAniosMeses(iIdConexion, cOperacion, sAnios, sMeses, ref sMensajeError);
                                        if (AnioMes != null && AnioMes.Rows.Count > 0)
                                        {
                                            foreach (DataRow drDataRoww in AnioMes.Rows)
                                            {


                                                lblAnios.Text = Convert.ToString(drDataRoww["anios"]);
                                                lblMeses.Text = Convert.ToString(drDataRoww["meses"]);

                                            }
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
                                        lblMensajeNegativo.Visible = true;
                                        lblMensajeNegativo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Baja";
                                        btnInsertar.Visible = false;
                                        lblAnios.Text = "";
                                        lblMeses.Text = "";

                                    }
                                }
                                else
                                {
                                    lblCooperativa.Visible = true;
                                    lblCooperativa.Text = "El sector es Fuerza Armada la fecha del aporte debe ser a 05/1997";
                                    btnInsertar.Visible = false;
                                }

                            }
                            else
                            {
                                DateTime fFechaAfiliacion = Convert.ToDateTime("01/" + txtFechaAfiliacion.Text);
                                DateTime fFechaBaja = Convert.ToDateTime("01/" + txtFechaBaja.Text);
                                DateTime fCooperativa = Convert.ToDateTime("01/04/1997");
                                if (fFechaAfiliacion <= fCooperativa && fFechaBaja <= fCooperativa)
                                {
                                    if (fFechaAfiliacion <= fFechaBaja)
                                    {
                                        btnInsertar.Visible = true;
                                        lblCooperativa.Visible = false;
                                        lblMensajeNegativo.Visible = false;

                                        cOperacion = "E";
                                        AnioMes = ObjProcedimientoManual.CalculoAniosMeses(iIdConexion, cOperacion, sAnios, sMeses, ref sMensajeError);
                                        if (AnioMes != null && AnioMes.Rows.Count > 0)
                                        {
                                            foreach (DataRow drDataRoww in AnioMes.Rows)
                                            {

                                                lblAnios.Text = Convert.ToString(drDataRoww["anios"]);
                                                lblMeses.Text = Convert.ToString(drDataRoww["meses"]);



                                            }
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
                                        lblMensajeNegativo.Visible = true;
                                        lblMensajeNegativo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Baja";
                                        btnInsertar.Visible = false;
                                        lblAnios.Text = "";
                                        lblMeses.Text = "";

                                    }
                                }
                                else
                                {
                                    lblCooperativa.Visible = true;
                                    lblCooperativa.Text = "Segun el sector la fecha del aporte debe ser a 04/1997";
                                    btnInsertar.Visible = false;
                                }

                            }
                        }
                    }
                }
            }
        }
        txtFechaBaja.Focus();
    }
    protected void ValidaFechas()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        DataTable Sector;
        string sMensajeError = null;
        int iIdTramite = (int)ViewState["iIdTramite"];
        int iIdGrupoBeneficio = (int)ViewState["iIdGrupoBeneficio"];
        string sMeses = null;
        string sRUC = null;

        if (ddlRazonSocial.SelectedValue == "")
        {
            sRUC = txtRUC.Text;
        }
        else
        {
            sRUC = ddlRazonSocial.SelectedValue;
        }
        string sAnios = Convert.ToString(Convert.ToDateTime("01/" + txtFechaAfiliacion.Text)).Substring(3, 7);
        if (txtFechaBaja.Text != "")
        {
            sMeses = Convert.ToString(Convert.ToDateTime("01/" + txtFechaBaja.Text)).Substring(3, 7);
        }

        DataTable AnioMes;

        if (txtFechaBaja.Text != null && txtFechaBaja.Text != "")
        {
            Sector = ObjProcedimientoManual.ComibolSalarioConvenio(iIdConexion, cOperacion, sRUC, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            if (Sector != null && Sector.Rows.Count > 0)
            {
                foreach (DataRow drDataRow in Sector.Rows)
                {

                    int iValido = Convert.ToInt32(drDataRow["Valido"]);
                    string sCodigo = Convert.ToString(drDataRow["Codigo"]);
                    int Origen = Convert.ToInt32(drDataRow["Origen"]);
                    if (Origen == 342) // FA MANUAL CONTINUO
                    {
                        DateTime fFechaAfiliacion = Convert.ToDateTime("01/" + txtFechaAfiliacion.Text);
                        DateTime fFechaBaja = Convert.ToDateTime("01/" + txtFechaBaja.Text);
                        DateTime fCooperativa = Convert.ToDateTime("01/05/1997");
                        if (fFechaAfiliacion <= fCooperativa && fFechaBaja <= fCooperativa)
                        {
                            if (fFechaAfiliacion <= fFechaBaja)
                            {
                                btnInsertar.Visible = true;
                                lblCooperativa.Visible = false;
                                lblMensajeNegativo.Visible = false;
                                cOperacion = "E";
                                AnioMes = ObjProcedimientoManual.CalculoAniosMeses(iIdConexion, cOperacion, sAnios, sMeses, ref sMensajeError);
                                if (AnioMes != null && AnioMes.Rows.Count > 0)
                                {
                                    foreach (DataRow drDataRoww in AnioMes.Rows)
                                    {


                                        lblAnios.Text = Convert.ToString(drDataRoww["anios"]);
                                        lblMeses.Text = Convert.ToString(drDataRoww["meses"]);

                                    }
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
                                lblMensajeNegativo.Visible = true;
                                lblMensajeNegativo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Baja";
                                btnInsertar.Visible = false;
                                lblAnios.Text = "";
                                lblMeses.Text = "";

                            }
                        }
                        else
                        {
                            lblCooperativa.Visible = true;
                            lblCooperativa.Text = "El sector es Fuerza Armada la fecha del aporte debe ser a 05/1997";
                            btnInsertar.Visible = false;
                        }

                    }
                    else
                    {
                        DateTime fFechaAfiliacion = Convert.ToDateTime("01/" + txtFechaAfiliacion.Text);
                        DateTime fFechaBaja = Convert.ToDateTime("01/" + txtFechaBaja.Text);
                        DateTime fCooperativa = Convert.ToDateTime("01/04/1997");
                        if (fFechaAfiliacion <= fCooperativa && fFechaBaja <= fCooperativa)
                        {
                            if (fFechaAfiliacion <= fFechaBaja)
                            {
                                btnInsertar.Visible = true;
                                lblCooperativa.Visible = false;
                                lblMensajeNegativo.Visible = false;

                                cOperacion = "E";
                                AnioMes = ObjProcedimientoManual.CalculoAniosMeses(iIdConexion, cOperacion, sAnios, sMeses, ref sMensajeError);
                                if (AnioMes != null && AnioMes.Rows.Count > 0)
                                {
                                    foreach (DataRow drDataRoww in AnioMes.Rows)
                                    {

                                        lblAnios.Text = Convert.ToString(drDataRoww["anios"]);
                                        lblMeses.Text = Convert.ToString(drDataRoww["meses"]);



                                    }
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
                                lblMensajeNegativo.Visible = true;
                                lblMensajeNegativo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Baja";
                                btnInsertar.Visible = false;
                                lblAnios.Text = "";
                                lblMeses.Text = "";

                            }
                        }
                        else
                        {
                            lblCooperativa.Visible = true;
                            lblCooperativa.Text = "Segun el sector la fecha del aporte debe ser a 04/1997";
                            btnInsertar.Visible = false;
                        }

                    }
                }
            }
        }
    }
    
    //protected void chbEditar_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chbEditar.Checked == true)
    //    {
    //        ddlRazonSocial.Visible = true;
    //        lblMenuRazon.Visible = true;
    //        lblRUC.Visible = false;
    //        lblSector.Visible = false;
    //        lblDescripcionRuc.Visible = false;
    //        txtDetRUC.Visible = false;
    //        txtRUC.Visible = false;
    //        txtSector.Visible = false;
    //    }
    //    else
    //    {
    //        ddlRazonSocial.Visible = false;
    //        lblMenuRazon.Visible = false;
    //        lblRUC.Visible = true;
    //        lblSector.Visible = true;
    //        lblDescripcionRuc.Visible = true;
    //        txtDetRUC.Visible = true;
    //        txtRUC.Visible = true;
    //        txtSector.Visible = true;
    //    }
    //}
}