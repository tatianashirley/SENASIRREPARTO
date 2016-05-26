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

public partial class CertificacionCC_wfrmRecursoReclamacion : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            CambiarInterfaz();
            if (Request.QueryString["iIdTramite"] != null)
            {
                txtTramite.Text = Request.QueryString["iIdTramite"];
                ListaAsegurado();
            }
            pnlOpcionBusqueda.Visible = true;

            lblTramite.Visible = true;
            txtTramite.Visible = true;
            lblTituloBusqueda.Text = "Ingresar numero de tramite";
        }
    }
    #region INTERFAZ

    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtTramite, btn_busqueda);
        
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
  
    private void OcultarOpcionesBusqueda ()
    {
        pnlOpcionBusqueda.Visible = false;
        lblTramite.Visible = false;
        txtTramite.Visible = false;
        
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
    protected void btn_busqueda_Click(object sender, EventArgs e)
    {
        ListaAsegurado();
    }
    protected void ListaAsegurado()
    {
        DataTable tblListaDatosAsegurado = null;
        pnlResultados.Visible = true;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        string iIdTramite = Convert.ToString(txtTramite.Text);
        int iIdGrupoBeneficio = 3;
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAseguradoCrenta(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        gvDatosBusqueda.DataSource = tblListaDatosAsegurado;
        gvDatosBusqueda.DataBind();
    }
    protected void gvDatosBusqueda_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "cmdLevantar")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "D";
                string sMensajeError = null;
                int iIdTramite=Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTramite"]);          
                int iIdGrupoBeneficio =3;
                int IdTipoTramite = Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTipoTramite"]);

                if (IdTipoTramite == 356) //manual
                {
                    if (ObjEmisionFormularioCC.CambioEstado(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError))
                    {
                        string msg = "La operacion se realizo con exito";
                        Master.MensajeOk(msg);
                        CleanControl(this.Controls);
                        pnlResultados.Visible = false;
                        gvDatosBusqueda.DataSource = null;
                        gvDatosBusqueda.DataBind();

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
   
    protected void btn_borrar_resultados_Click(object sender, EventArgs e)
    {
        CleanControl(this.Controls);
        pnlResultados.Visible = false;
    }
    
    }