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


public partial class CertificacionCC_wfrmListaTramitesParaEmision : System.Web.UI.Page
{
    clsEmisionFormularioCalculo ObjEmisionFormularioCC = new clsEmisionFormularioCalculo();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsProcedimientoManual ObjProcedimientoManual = new clsProcedimientoManual();
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            int iIdTramite=0;
            int iIdGrupoBeneficio=0;
        }

    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtIdTramite, btnBuscar);

    }

    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }

    private void ListarDatosAsegurado(string iIdTramite, int iIdGrupoBeneficio=0)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "W";
        string sMensajeError = null;
        DataTable tblListaDatosAsegurado = null;
        
        
        tblListaDatosAsegurado = ObjEmisionFormularioCC.DatosAseguradoCCR(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, ref sMensajeError);
        if (sMensajeError == null)
        {
            gvDatos.DataSource = tblListaDatosAsegurado;
            gvDatos.DataBind();
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        
        
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iIdTramite = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            int iIdGrupoBeneficio = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["IdGrupoBeneficio"]);
            int iPresidente = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["Presidente"]);
            int iVocal = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["Vocal"]);
            int iSecretario = Convert.ToInt32(gvDatos.DataKeys[e.Row.RowIndex].Values["Secretario"]);

            if (iPresidente == 101)
            {
                e.Row.FindControl("imgPresidente").Visible = true;
            }
            if (iVocal == 102)
            {
                e.Row.FindControl("imgVocal").Visible = true;
            }
            if (iSecretario == 103)
            {
                e.Row.FindControl("imgSecretario").Visible = true;
            }
          
        }
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdAprobar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                string iIdTramite = Convert.ToString(gvDatos.DataKeys[Index].Values["IdTramite"]);
                string iIdGrupoBeneficio = Convert.ToString(gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"]);
                Response.Redirect("wfrmEmisionProcedimientoManual.aspx?iIdTramite=" + iIdTramite + "&iIdGrupoBeneficio=" + iIdGrupoBeneficio + "");
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string iIdTramite = txtIdTramite.Text;
        int iIdGrupoBeneficio = 3;
        ListarDatosAsegurado(iIdTramite, iIdGrupoBeneficio);
    }
}