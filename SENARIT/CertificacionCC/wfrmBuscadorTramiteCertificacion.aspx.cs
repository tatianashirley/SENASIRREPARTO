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
using System.Drawing;


public partial class CertificacionCC_wfrmBuscadorTramiteCertificacion : System.Web.UI.Page
{
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            txtIdtramite.Focus();
            ListaBandeja();
           
        }

    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtIdtramite, btnEnviar);        

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "L";
        string sMensajeError = null;

        string iIdTramite = txtIdtramite.Text;
        int iIdGrupoBeneficio =3 ;
        DataTable tblTramiteUrl = null;
        tblTramiteUrl=ObjEmisionFormularioCC.TramiteUrlCertificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (tblTramiteUrl != null)
        {

            if (tblTramiteUrl.Rows.Count > 0 && tblTramiteUrl.Rows[0]["Url"].ToString() != "")
            {
                string sUrl = tblTramiteUrl.Rows[0]["Url"].ToString();
                iIdTramite = tblTramiteUrl.Rows[0]["IdTramite"].ToString();
                Response.Redirect(sUrl + "?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = "El tramite no esta disponible para ejecutar la actividad con el rol asignado";
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = "El tramite no esta disponible para ejecutar la actividad con el rol asignado";
            Master.MensajeError(Error, DetalleError);
        }
        
    }
    private void ListaBandeja()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sMensajeError = null;
        DataTable tblBandeja = null;
        tblBandeja = ObjEmisionFormularioCC.BandejaCertificacion(iIdConexion, cOperacion, ref sMensajeError);
        if (tblBandeja != null)
        {
            lblCantidad.Text = Convert.ToString(tblBandeja.Rows.Count);
            gvBandeja.DataSource = tblBandeja;
            gvBandeja.DataBind();
        }
    }
    protected void gvBandeja_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int Rechazos = Convert.ToInt32(gvBandeja.DataKeys[e.Row.RowIndex].Values["Rebotes"]);
            if (Rechazos>0)
            {
                e.Row.BackColor = Color.FromName("#FFCC00");
            }
            if (Rechazos > 3)
            {
                e.Row.BackColor = Color.FromName("#f98b9a");
            }
           /*
            int iIdTramite = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            int NroControl = Convert.ToInt32(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["NroControl"]);
            string sRevisor = Convert.ToString(gvDatosInformes.DataKeys[e.Row.RowIndex].Values["Revisor"]);


            if ((int)Session["RolUsuario"] == 9) //Verificador
            {
                e.Row.FindControl("imgEditar").Visible = true;
                if (sRevisor != null || sRevisor != "")
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
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;
            }
            */
        }
    }
    protected void gvBandeja_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "cmdSeleccionar")
        {

            int Index = Convert.ToInt32(e.CommandArgument);            
            string iIdTramite = Convert.ToString(gvBandeja.DataKeys[Index].Values["IdTramite"]);            
            int iIdGrupoBeneficio = 3;
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "L";
            string sMensajeError = null;
            DataTable tblTramiteUrl = null;
            tblTramiteUrl = ObjEmisionFormularioCC.TramiteUrlCertificacion(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
            if (tblTramiteUrl != null)
            {

                if (tblTramiteUrl.Rows.Count > 0 && tblTramiteUrl.Rows[0]["Url"].ToString() != "")
                {
                    string sUrl = tblTramiteUrl.Rows[0]["Url"].ToString();
                    iIdTramite = tblTramiteUrl.Rows[0]["IdTramite"].ToString();
                    Response.Redirect(sUrl + "?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + " ");
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = "El tramite no esta disponible para ejecutar la actividad con el rol asignado";
                    Master.MensajeError(Error, DetalleError);
                }
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = "El tramite no esta disponible para ejecutar la actividad con el rol asignado";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    
    protected void gvBandeja_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandeja.PageIndex = e.NewPageIndex;
        ListaBandeja();
        
    }
   
}