using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Security.Principal;
using System.Drawing;
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

public partial class CertificacionCC_wfrmListaFormulariosCC : System.Web.UI.Page
{
    clsSeguridad ObjSeguridad = new clsSeguridad();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFechaInicio.Enabled = false;
        txtFechaFin.Enabled = false;
     
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        CleanControl(this.Controls);
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


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string i_fFechaInicio = txtFechaInicio.Text;
        string i_fFechaFin = txtFechaFin.Text;
        string CuentaUsuario=(string)Session["CuentaUsuario"];
        i_fFechaInicio = ObjSeguridad.URLEncode(i_fFechaInicio);
        i_fFechaFin = ObjSeguridad.URLEncode(i_fFechaFin);
        CuentaUsuario = ObjSeguridad.URLEncode(CuentaUsuario);


        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteFormularioCCManual", " window.open('../Reportes/wfrmReporteListaFormularioCCManual.aspx?FechaInicio=" + Server.UrlEncode(i_fFechaInicio) + "&FechaFin=" + Server.UrlEncode(i_fFechaFin)  + "&sUsr=" + Server.UrlEncode(CuentaUsuario) + "', 'newWindow', 'height=800, width=800,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

    }
   
   
}