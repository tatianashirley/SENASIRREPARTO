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
using wcfGeo.Logica;
using System.Drawing;
public partial class Seguridad_wfrmCambiarPassword : System.Web.UI.Page
{
   clsUsuario ObjUsuario = new clsUsuario();
   clsSeguridad ObjSeguridad = new clsSeguridad();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            
            pnlRegistro.Visible = true;
            txtClaveN.Text ="";
            txtConfirmaClaveNueva.Text = "";
            CleanControl(this.Controls);

        }
        //else
        //{
        //    ListaUsuarios(); 
        //}

     }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
        
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Inicio.aspx");
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {

        String sMensajeError = null;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "R";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdUsuario=0;
        DataTable dtDataTableConexion = null;
        dtDataTableConexion = ObjSeguridad.ListaDatosConexion(iIdConexion);
        if (dtDataTableConexion != null && dtDataTableConexion.Rows.Count > 0)
        {
            foreach (DataRow drDataRowConexion in dtDataTableConexion.Rows)
            {
                if (Convert.ToInt32(drDataRowConexion["IdTipoUsuario"]) == 677)
                {
                    iIdUsuario = Convert.ToInt32(drDataRowConexion["IdUsuario"]);
                }
            }
        }

        if (Convert.ToString(txtClaveN.Text) == Convert.ToString(txtConfirmaClaveNueva.Text))
        {
            string sClaveUsuario = ObjSeguridad.Encriptar(Convert.ToString(txtClaveN.Text));
            if (ObjSeguridad.UsuarioRestauraPassword(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdUsuario, sClaveUsuario, ref sMensajeError))
            {
                string Msg = "Se realizo la Operacion con exito";
                Master.MensajeOk(Msg);
               

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
            string DetalleError = "Error la contraseña nueva y la confirmacion no son iguales";
            Master.MensajeError(Error, DetalleError);
        }
        txtClaveN.Text = "";
        txtConfirmaClaveNueva.Text = "";        
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

  
}