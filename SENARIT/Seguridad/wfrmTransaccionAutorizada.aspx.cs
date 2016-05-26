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

public partial class Seguridad_wfrmTransaccionAutorizada : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   ListItem oItem = new ListItem("Seleccione...", "0",true);
   clsTransaccionAutorizada ObjTransaccionAutorizada = new clsTransaccionAutorizada();
   clsTransaccion ObjTransaccion = new clsTransaccion();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaTransaccionAutorizada.Visible = true;
            ListaModulo();
            
            
            pnlRegistraTransaccionAutorizada.Visible = false;
          
        }
       
    }
    protected void ddlIdModulo_SelectedIndexChanged(object sender, EventArgs e)
    {

        int IdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        ListaRolBuscar(IdModulo);        
    }
    protected void ListaRolBuscar(int iIdModulo)
    {
        
        ddlIdRolBusqueda.Items.Clear();
        ddlIdRolBusqueda.DataSource = obj.ListaRolconParametro(iIdModulo);
        ddlIdRolBusqueda.DataValueField = "IdRol";
        ddlIdRolBusqueda.DataTextField = "DescripcionRol";
        ddlIdRolBusqueda.DataBind();
        ddlIdRolBusqueda.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdRolBusqueda.SelectedValue = "0";
    }
    private void TransaccionAutorizada(int TransaccionAutorizada)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(TransaccionAutorizada);
    }
    protected void ListaTransaccionAutorizada()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";       
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        string sMensajeError = null;        
        gvDatos.DataSource = ObjTransaccionAutorizada.ListaTransaccionAutorizadaPorModulo(iIdConexion, cOperacion,iIdModulo, ref sMensajeError);
        gvDatos.DataBind();
    }
    protected void ListaModulo()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string sOperacion = "Q";     
        
        ddlIdModulo.DataSource = obj.ListaModulos(iIdConexion, sOperacion);
        ddlIdModulo.DataValueField = "IdModulo";
        ddlIdModulo.DataTextField = "DescripcionModulo";
        ddlIdModulo.DataBind();
    }
 
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        
        
        //pnlListaTransaccionAutorizada.Visible = false;
        this.pnlRegistra_ModalPopupExtender.Show(); 
        pnlRegistraTransaccionAutorizada.Visible = true;
        
        btnAdicionar.Visible = true;
        

        ListaModuloRegistrar();
       
    }
    protected void ListaModuloRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        
        int iIdModulo;
        if (ddlIdModuloRegistrar.SelectedValue != "")
        {
             iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        }
        else
        {
             iIdModulo = 0;
        }
        ddlIdModuloRegistrar.Items.Clear();
        ddlIdModuloRegistrar.DataSource = obj.ListaModulos(iIdConexion, cOperacion);
        ddlIdModuloRegistrar.DataValueField = "IdModulo";
        ddlIdModuloRegistrar.DataTextField = "DescripcionModulo";
        ddlIdModuloRegistrar.DataBind();
        ddlIdModuloRegistrar.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdModuloRegistrar.SelectedValue = Convert.ToString(iIdModulo);
    }
    protected void ddlIdModuloRegistrar_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnlRegistra_ModalPopupExtender.Show();
        ListaProcedimiento();
        ListaRolRegistrar();
    }
    protected void ListaProcedimiento()
    {
       
        
        ddlIdTransaccion.Items.Clear();
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        ddlProcedimiento.DataSource = obj.ListaProcedimientoconParametro(iIdModulo);
        ddlProcedimiento.DataValueField = "IdProcedimiento";
        ddlProcedimiento.DataTextField = "Nombre";
        ddlProcedimiento.DataBind();      
        ddlProcedimiento.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlProcedimiento.SelectedValue = "0";
    }
    protected void ListaRolRegistrar()
    {
        //int iIdConexion = (int)Session["IdConexion"];
        //string cOperacion = "Q";
        ddlIdRol.Items.Clear();
        ddlIdTransaccion.Items.Clear();
        //int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);        
        int iIdModulo = 0;
        ddlIdRol.DataSource = obj.ListaRolconParametro(iIdModulo);
        ddlIdRol.DataValueField = "IdRol";
        ddlIdRol.DataTextField = "DescripcionRol";
        ddlIdRol.DataBind();
        //ddlIdRol.Items.Add(oItem);
        ddlIdRol.Items.Insert(0, new ListItem("Seleccione...", "0"));  
        ddlIdRol.SelectedValue = "0";
    }

    protected void ListaTransacionRegistrar()
    {
        
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        int iIdRol = Convert.ToInt32(ddlIdRol.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(ddlProcedimiento.SelectedValue);
        
        string sMensajeError = null;
        string sNivelError = null;
        ddlIdTransaccion.Items.Clear();
        ddlIdTransaccion.DataSource = ObjTransaccion.ListaTransacionporprocedimiento(iIdProcedimiento);
        ddlIdTransaccion.DataValueField = "IdTransaccion";
        ddlIdTransaccion.DataTextField = "Descripcion";
        ddlIdTransaccion.DataBind();
        //ddlIdTransaccion.Items.Add(oItem);
        ddlIdTransaccion.Items.Insert(0, new ListItem("Seleccione...", "0"));  
        ddlIdTransaccion.SelectedValue = "0";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

        pnlListaTransaccionAutorizada.Visible = true;
        pnlRegistraTransaccionAutorizada.Visible = false;
        
        //System.Threading.Thread.Sleep(3000);
       
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        ListaTransaccionAutorizadaBusqueda();
    }

    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        int iIdRol = Convert.ToInt32(ddlIdRol.SelectedValue);
        int iIdTransaccion = Convert.ToInt32(ddlIdTransaccion.SelectedValue);

        string sMensajeError = null;
        if (ObjTransaccionAutorizada.TransaccionAutorizadaAdiciona(iIdConexion, cOperacion, iIdRol, iIdTransaccion, ref sMensajeError))
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
        pnlListaTransaccionAutorizada.Visible = true;
        pnlRegistraTransaccionAutorizada.Visible = false;

        //ListaTransaccionAutorizada();
        ListaTransaccionAutorizadaBusqueda();
       
    }
    


    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
         int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "D";       
        string sMensajeError = null;       
        GridViewRow row = gvDatos.SelectedRow;

        int iIdRol = Convert.ToInt32(row.Cells[1].Text);
        int iIdTransaccion = Convert.ToInt32(row.Cells[2].Text);
        //int iIdModulo = Convert.ToInt32(row.Cells[3].Text);
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);


        if (ObjTransaccionAutorizada.TransaccionAutorizadaElimina(iIdConexion, cOperacion,iIdRol,iIdTransaccion, ref sMensajeError))
        {
            string Msg = "Actualizacion realizada con exito";
            Master.MensajeOk(Msg);
            ddlIdModulo.SelectedValue =Convert.ToString(iIdModulo);
            ListaTransaccionAutorizada();

        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
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
                GridViewRow row = gvDatos.SelectedRow;

                int iIdRol = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdRol"]);
                int iIdTransaccion = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdTransaccion"]);                
                int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);


                if (ObjTransaccionAutorizada.TransaccionAutorizadaElimina(iIdConexion, cOperacion, iIdRol, iIdTransaccion, ref sMensajeError))
                {
                    string Msg = "Actualizacion realizada con exito";
                    Master.MensajeOk(Msg);
                    ddlIdModulo.SelectedValue = Convert.ToString(iIdModulo);
                    //ListaTransaccionAutorizada();
                    ListaTransaccionAutorizadaBusqueda();

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



    protected void ddlProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnlRegistra_ModalPopupExtender.Show(); 
        ListaTransacionRegistrar();
    }

    protected void ddlIdRolBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaTransaccionAutorizadaBusqueda();
    }
    protected void ListaTransaccionAutorizadaBusqueda()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "R";
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        int iIdRol = Convert.ToInt32(ddlIdRolBusqueda.SelectedValue);
        string sMensajeError = null;
        gvDatos.DataSource = ObjTransaccionAutorizada.ListaTransaccionAutorizadaPorModuloyRol(iIdConexion, cOperacion, iIdModulo, iIdRol, ref sMensajeError);
        gvDatos.DataBind();
    }
}