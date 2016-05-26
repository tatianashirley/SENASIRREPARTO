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


public partial class CertificacionCC_wfrmAprobacionTopeSalarial : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsParametrizacion ObjParametrizacion = new clsParametrizacion();
    clsTramiteAsignado ObjTramite = new clsTramiteAsignado();
    clsTopeSalarial ObjTopeSalarial= new clsTopeSalarial();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtTramite.Focus();

            CambiarInterfaz();

        }
    }
    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtTramite, txtPeriodoSalario);
        AgregarJSAtributos(txtPeriodoSalario,txtMonto);
        AgregarJSAtributos(txtMonto, btnRegistrar);
        
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
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        CleanControl(this.Controls);
        gvDatos.DataSource = null;
        gvDatos.DataBind();
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
    private void Moneda(int IdMonedaSalario)
    {
        ddlMonedaSalario.DataSource = ObjProcedimientoValidoManual.ListaDetalleClasificador(13);
        ddlMonedaSalario.DataValueField = "IdDetalleClasificador";
        ddlMonedaSalario.DataTextField = "DescripcionDetalleClasificador";
        ddlMonedaSalario.DataBind();
        ddlMonedaSalario.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlMonedaSalario.SelectedValue = Convert.ToString(IdMonedaSalario);
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        
        
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            string sCrenta =txtTramite.Text;
            int iIdGrupoBeneficio = 3;
            string sMensajeError = null;
            string sPeriodoSalario = txtPeriodoSalario.Text;
            sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);
            string sSalarioCotizable = (txtMonto.Text).Replace(",", "");
            int iMonedaSalario = Convert.ToInt32(ddlMonedaSalario.SelectedValue);


            if (ObjTopeSalarial.Inserta(iIdConexion, cOperacion, sCrenta, iIdGrupoBeneficio, sPeriodoSalario, sSalarioCotizable, iMonedaSalario, ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                ListaTopeSalarial();
                
            
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
    protected void txtPeriodoSalario_TextChanged(object sender, EventArgs e)
    {
        string sPeriodoSalario = txtPeriodoSalario.Text;
        sPeriodoSalario = Convert.ToString(Convert.ToDateTime("01/" + sPeriodoSalario)).Substring(3, 7);

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
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListaTopeSalarial();

    }
    private void ListaTopeSalarial()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "V";
        string sMensajeError = null;
        DataTable tblListaTopeSalarial = null;
        string sCrenta = txtTramite.Text;
        int iIdGrupoBeneficio = 3;
        tblListaTopeSalarial = ObjTopeSalarial.ListaTopes(iIdConexion, cOperacion, sCrenta, iIdGrupoBeneficio, ref sMensajeError);
        gvDatos.DataSource = tblListaTopeSalarial;
        gvDatos.DataBind();

    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int iRegistroActivo = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["RegistroActivo"]);
            if (iRegistroActivo == 1)
            {
                e.Row.FindControl("imgEliminar").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgEliminar").Visible = false;
            }
                    
            
        }
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        if (e.CommandName == "cmdEliminar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "D";
                string sMensajeError = null;
                int iIdTramite = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdTramite"]);
                int iIdGrupoBeneficio = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"]);
                DateTime FechaRegistro = Convert.ToDateTime(gvDatos.DataKeys[Index].Values["FechaRegistro"]);


                if (ObjTopeSalarial.EstadoBajaTope(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, FechaRegistro,ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListaTopeSalarial();
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
}