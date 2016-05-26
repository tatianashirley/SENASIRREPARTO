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

public partial class CertificacionCC_wfrmBusquedaFCCyCS : System.Web.UI.Page
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
        
        if (e.CommandName == "cmdMensual")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite=Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);               

                string iIdGrupoBeneficio ="3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                string iIdTipoCC = "358";                
                iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);
                
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                if (IdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) +"&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
               if (IdTipoTramite==357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) +"&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

                    
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
                string iIdTramite = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTipoTramite"]);
                iIdTramite = ObjSeguridad.URLEncode(iIdTramite);

                string iIdGrupoBeneficio = "3";
                iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
                string iIdTipoCC = "359";
                iIdTipoCC = ObjSeguridad.URLEncode(iIdTipoCC);
                
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                if (IdTipoTramite == 356) //manual
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) +"&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                }
                if (IdTipoTramite == 357) //automatico
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&iIdTipoCC=" + Server.UrlEncode(iIdTipoCC) +"&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                    
                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
        
        if (e.CommandName == "cmdCertificacionSalario")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                int iIdTramite = Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTramite"]);
                int iIdTipoTramite = Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTipoTramite"]);                
                String CuentaUsuario = (string)Session["CuentaUsuario"];
                CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);

                Response.Redirect("wfrmListaComponentes.aspx?iIdTramite=" + iIdTramite + "&iIdTipoTramite="+iIdTipoTramite);

                //if (iIdTipoTramite == 356) //manual
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalarios.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" +Server.UrlEncode(iIdGrupoBeneficio) +"&sUsr="+Server.UrlEncode(CuentaUsuario)+"', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                //}
                //if (iIdTipoTramite == 357) //automatico
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "openReporteCertificacion", " window.open('../Reportes/wfrmReporteCertificacionSalariosAutomatico.aspx?iIdTramite=" + Server.UrlEncode(iIdTramite) + "&iIdGrupoBeneficio=" + Server.UrlEncode(iIdGrupoBeneficio) + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
                //}                
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdInforme")
        {
            try
            {
                clsSeguridad ObjSeguridad = new clsSeguridad();
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["IdTramite"]);
                int IdTipoTramite = Convert.ToInt32(gvDatosBusqueda.DataKeys[Index].Values["IdTipoTramite"]);
               // iIdTramite = ObjSeguridad.URLEncode(iIdTramite);

                string iIdGrupoBeneficio = "3";
                //iIdGrupoBeneficio = ObjSeguridad.URLEncode(iIdGrupoBeneficio);
               

                ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioDeCalculo", " window.open('../CertificacionCC/wfrmIngresarInforme.aspx?iIdTramite=" +iIdTramite + "&iIdGrupoBeneficio=" +iIdGrupoBeneficio+ "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

               
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                //Master.MensajeError(Error, DetalleError);
            }
        }
       

    }
    protected void gvDatosBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int FlagM = Convert.ToInt32(gvDatosBusqueda.DataKeys[e.Row.RowIndex].Values["FlagM"]);
            int FlagG = Convert.ToInt32(gvDatosBusqueda.DataKeys[e.Row.RowIndex].Values["FlagG"]);
            int CertificacionSalario=Convert.ToInt32(gvDatosBusqueda.DataKeys[e.Row.RowIndex].Values["CertificacionSalario"]);
            int CantTramiteInformado = Convert.ToInt32(gvDatosBusqueda.DataKeys[e.Row.RowIndex].Values["TramiteInformado"]);


            if ((int)Session["RolUsuario"] == 9  ||  (int)Session["RolUsuario"] == 8  || (int)Session["RolUsuario"] == 7 || (int)Session["RolUsuario"] ==14) //Verificador
            {
                if (CertificacionSalario >= 1)
                {                   
                    
                    e.Row.FindControl("imgCertificacionSalario").Visible = true;
                    e.Row.FindControl("imgFMensual").Visible = false;
                    e.Row.FindControl("imgFGlobal").Visible = false;
                }
                else
                {
                    e.Row.FindControl("imgCertificacionSalario").Visible = false;
                    e.Row.FindControl("imgFMensual").Visible = false;
                    e.Row.FindControl("imgFGlobal").Visible = false;
                }
               
            }
            else
            {
                if (CertificacionSalario >= 1)
                {
                    e.Row.FindControl("imgCertificacionSalario").Visible = true;
                }
                else
                {
                    e.Row.FindControl("imgCertificacionSalario").Visible = false;
                }

                if (FlagM >= 1)
                {
                    e.Row.FindControl("imgFMensual").Visible = true;
                }
                else
                {
                    e.Row.FindControl("imgFMensual").Visible = false;
                }
                if (FlagG >= 1)
                {
                    e.Row.FindControl("imgFGlobal").Visible = true;
                }
                else
                {
                    e.Row.FindControl("imgFGlobal").Visible = false;
                }
            }
            if (CantTramiteInformado >= 1)
            {
                e.Row.FindControl("imgInforme").Visible = true;
            }
            else
            {
                e.Row.FindControl("imgInforme").Visible = false;
            }
           

        }
    }
    protected void btn_borrar_resultados_Click(object sender, EventArgs e)
    {
        CleanControl(this.Controls);
        pnlResultados.Visible = false;
    }
    
    }