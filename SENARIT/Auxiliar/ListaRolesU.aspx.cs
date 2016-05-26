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
using System.Data.SqlClient;

using wcfSeguridad.Logica;
//using Seguridad.Entidades;
//using Seguridad.Datos;

using System.Drawing;

public partial class ListaRolesU : System.Web.UI.Page
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
            lblCodOficina.Text = Session["CodOficina"].ToString();
            lblCodUsuario.Text = Session["CodUsuario"].ToString();
        }

        if (!Page.IsPostBack)
        {
            
            ListarRolesUsuario();
            ContarRoles();
            lblFechaActual.Text = obj.ObtenerFecha();
            

            if(lblContador.Text == "0")
            {
                lblObservaciones.Text = "Solicite Asignacion de Roles al Administrador";
                string script = @"alert('Solicite Asignacion de Roles al Administrador');
                        window.location.href='../LoginLDAP.aspx';";
                //string script = "<script type=text/javascript>redireccionar();</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "redireccionar", script, true);
            }
            //else
            //{
            //    Obtener_Fecha_Sevidor();
            //    CalcularDiasCambioPassword();
            //}
        }
    }

    protected void Obtener_Fecha_Sevidor()
    {
        SqlConnection sqlConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnstr"].ConnectionString.ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT GETDATE()"; // 103
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConexion;

        sqlConexion.Open();
        lblFechaActual.Text = Convert.ToString(cmd.ExecuteScalar());
        //lblFechaActual.Text = Convert.ToDateTime(lblFechaActual.Text).ToLongDateString();
        //lblFechaActual.Text = Convert.ToString(lblFechaActual.Text);
        lblFechaActual.Text = lblFechaActual.Text;
        sqlConexion.Close();
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

    protected void ListarRolesUsuario()
    {
        DataTable dtDataTable = null;
        DateTime? fFechaVigencia = null;
        DateTime? fFechaExpiracion = null;
        dtDataTable = obj.ListaRolesUsuario(Convert.ToInt32(lblCodUsuario.Text), Convert.ToInt32(lblCodOficina.Text));
        if (dtDataTable.Rows.Count == 1)
        {
            
            foreach (DataRow drDataRow in dtDataTable.Rows)
            {

                Session["CodOficina"] = drDataRow["IdOficina"];
                Session["NombreOficina"] = drDataRow["Oficina"];
                //Session["Rol_A"] = drDataRow["AbreviacionRol"];
                Session["RolUsuario"] = drDataRow["IdRol"];
                Session["IdModulo"]= drDataRow["IdModulo"];
                fFechaVigencia = Convert.ToDateTime(drDataRow["FechaVigencia"]);
                fFechaExpiracion = Convert.ToDateTime(drDataRow["FechaExpiracion"]);

                if (fFechaExpiracion != null)
                {
                    if (DateTime.Today > fFechaExpiracion)
                    {
                        gvDatos.Visible = false;
                        lblObservaciones.Text = "Finalizo la fecha de vigencia de su rol" + Convert.ToString(fFechaExpiracion).Substring(0, 10) + " - Comuniquese con el Administrador del Sistema ";
                    }
                    else
                    {
                        Response.Redirect("~/Inicio.aspx");
                    }
                }
                
            }
        }
        else
        {
           // gvDatos.DataSource = obj.ListaRolesUsuario(Convert.ToInt32(lblCodUsuario.Text), Convert.ToInt32(lblCodOficina.Text));
            gvDatos.DataSource = dtDataTable;
            gvDatos.DataBind();
        }
    }

    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        string valor_A;
        string rolusr;
        string IdModulo;
        //string RUTA = "";
        //int val;

        GridViewRow row = gvDatos.SelectedRow;
        //valor_A = row.Cells[1].Text;
        rolusr = row.Cells[2].Text;
        IdModulo = row.Cells[3].Text;

        Session["CodUsuario"] = Convert.ToInt32(lblCodUsuario.Text);
        Session["CuentaUsuario"] = lblCuentaUsuario.Text;

        Session["CodOficina"] = Convert.ToInt32(lblCodOficina.Text);
        Session["NombreOficina"] = Session["NombreOficina"].ToString();

        //Session["Rol_A"] = valor_A;
        Session["RolUsuario"] =Convert.ToInt32(rolusr);
        Session["IdModulo"] = Convert.ToInt32(IdModulo);
        
        ////Obtener Pagina Principal del Modulo
        //clsMenu tpx = new clsMenu();
        //foreach (clsMenu tpy in tpx.ObtenerPadreModulo(Convert.ToInt32(lblModulo.Text)))
        //{
        //    RUTA = tpy.URL.Trim();
            
        //}
        //Response.Redirect(RUTA);
        Response.Redirect("~/Inicio.aspx");
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdSeleccionar")
        {
            try
            {

                int Index = Convert.ToInt32(e.CommandArgument);
                string valor_A;
                string rolusr;
                string IdModulo;
       

               // GridViewRow row = gvDatos.SelectedRow;
                //valor_A = row.Cells[1].Text;
                //rolusr = row.Cells[2].Text;
                //IdModulo = row.Cells[3].Text;

                rolusr = Convert.ToString(gvDatos.DataKeys[Index].Values["IdRol"]);
                IdModulo = Convert.ToString(gvDatos.DataKeys[Index].Values["IdModulo"]);

                Session["CodUsuario"] = Convert.ToInt32(lblCodUsuario.Text);
                Session["CuentaUsuario"] = lblCuentaUsuario.Text;

                Session["CodOficina"] = Convert.ToInt32(lblCodOficina.Text);
                Session["NombreOficina"] = Session["NombreOficina"].ToString();

                //Session["Rol_A"] = valor_A;
                Session["RolUsuario"] = Convert.ToInt32(rolusr);
                Session["IdModulo"] = Convert.ToInt32(IdModulo);
                Response.Redirect("~/Inicio.aspx");
            }
            catch (Exception ex)
            {
                
                string Error = "Error al realizar la operación";
                
            }
        }


    }

    protected void ContarRoles()
    {
        DataTable dtDataTable = null;
        dtDataTable = obj.ListaRolesUsuario(Convert.ToInt32(lblCodUsuario.Text), Convert.ToInt32(lblCodOficina.Text));
        if (dtDataTable == null || dtDataTable.Rows.Count == 0)
        {
            lblContador.Text = "0";
        }
        
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex)+1;            
            DateTime fFechaVigencia = Convert.ToDateTime(gvDatos.DataKeys[e.Row.RowIndex].Values["FechaVigencia"]);
            DateTime fFechaExpiracion = Convert.ToDateTime(gvDatos.DataKeys[e.Row.RowIndex].Values["FechaExpiracion"]);

            if (DateTime.Today > fFechaExpiracion)
            {
                e.Row.Cells[0].Enabled = false;
                e.Row.BackColor= Color.FromName("#FFCC00");
                
                lblObservaciones.Text = "Uno de los roles asignados vencio la fecha comuniquese con el administrador del sistema";

            }
            else
            {
                e.Row.Cells[1].Enabled = true;
            }

           // e.Row.Cells[2].Visible = true;
            //e.Row.Cells[3].Visible = true;
        }


    }
}