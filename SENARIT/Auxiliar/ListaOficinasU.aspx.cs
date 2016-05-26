using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.SqlClient;

using wcfSeguridad.Logica;
//using Seguridad.Entidades;
//using Seguridad.Datos;

using System.Drawing;

public partial class ListaOficinasU : System.Web.UI.Page
{
    clsSeguridad obj = new clsSeguridad();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("IdConexion");
        if (Session["CodUsuario"] == null)
        {
            Response.Redirect("~/LoginLDAP.aspx");
        }
        else
        {
            lblCuentaUsuario.Text = Session["CuentaUsuario"].ToString();
            lblCodUsuario.Text = Session["CodUsuario"].ToString();
        }

        if (!Page.IsPostBack)
        {
            
            ListaOficinasUsuario();
            ContarRoles();
            lblFechaActual.Text =obj.ObtenerFecha();
            

            if(lblContador.Text == "0")
            {
                lblObservaciones.Text = "Solicite Asignacion de Sistemas al Administrador";
                string script = @"alert('Solicite Asignacion de Oficina al Administrador');
                        window.location.href='../LoginLDAP.aspx';";                
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }
            //else
            //{
            //    Obtener_Fecha_Sevidor();
            //    CalcularDiasCambioPassword();
            //}
        }
    }


    protected void CalcularDiasCambioPassword()
    {
        //TimeSpan diferencia;
        //int dif;

        //clsDiasModificacion tp1 = new clsDiasModificacion();
        //foreach (clsDiasModificacion tp2 in tp1.ObtenerDiasModificacion(Convert.ToInt32(lblCodUsuario.Text)))
        //{
        //    lblObservaciones.Text = tp2.Dias.ToString();
        //    lblFechaModificacion.Text = tp2.FechaModificacion.AddDays(Convert.ToInt32(lblObservaciones.Text)).ToString();
        //}
        //if (lblFechaModificacion.Text == "")
        //{
        //    lblFechaModificacion.Text = lblFechaActual.Text;
        //}
        //diferencia = Convert.ToDateTime(lblFechaModificacion.Text) - (Convert.ToDateTime(lblFechaActual.Text));
        //dif = diferencia.Days;

        //if (dif < 0)
        //{
        //    lblObservaciones.Text = "Cambie su Password ...";
        //}
        //else
        //{
        //    lblObservaciones.Text = "Continue ...";
        //}
    }
   
    protected void ListaOficinasUsuario()
    {
        DataTable dtDataTable = null;
        
        int iIdUsuario = Convert.ToInt32(lblCodUsuario.Text);

            dtDataTable = obj.ListaOficinasUsuario(iIdUsuario);
            if (dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {

                    Session["CodOficina"] = drDataRow["IdOficina"];
                    Session["NombreOficina"] = drDataRow["Oficina"];
                    Response.Redirect("~/Auxiliar/ListaRolesU.aspx");


                }
            }

            else
            {

                //gvDatos.DataSource = obj.ListaOficinasUsuario(Convert.ToInt32(lblCodUsuario.Text));
                gvDatos.DataSource = dtDataTable;
                gvDatos.DataBind();
            }

        
        
        
    }
    

    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        string valor;
        string DescripcionOficina;
        //int val;

        GridViewRow row = gvDatos.SelectedRow;
        valor = row.Cells[2].Text;
        lblOficina.Text = valor;
        DescripcionOficina = row.Cells[1].Text;
        //lblContador.Text = nombreModulo;
        

        Session["CodUsuario"] = Convert.ToInt32(lblCodUsuario.Text);      
        Session["CodOficina"] = Convert.ToInt32(lblOficina.Text);
        Session["NombreOficina"] = DescripcionOficina;

        Response.Redirect("~/Auxiliar/ListaRolesU.aspx");
    }

    protected void ContarRoles()
    {
        DataTable dtDataTable = null;
        dtDataTable = obj.ListaOficinasUsuario(Convert.ToInt32(lblCodUsuario.Text));
        if (dtDataTable == null || dtDataTable.Rows.Count == 0)
        {
            lblContador.Text ="0";
        }
        
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[2].Visible = false;
    }
}