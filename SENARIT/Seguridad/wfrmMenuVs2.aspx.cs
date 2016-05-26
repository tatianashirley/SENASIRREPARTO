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




public partial class Seguridad_wfrmMenuVs2 : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaMenu.Visible = true;
            
            pnlRegistraMenu.Visible = false;
            
            gvDatos.Columns[5].Visible = false;
            gvDatos.Columns[1].Visible = false;
            CambiarInterfaz();
            txtBMenuSuperior.Focus();

        }
       
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtBMenuSuperior, txtBMenu);
        AgregarJSAtributos(txtBMenu, btnMenuSuperior);

        AgregarJSAtributos(txtMenu, ddlMenu);
        AgregarJSAtributos(txtPosicion, txtURL);
        AgregarJSAtributos(txtURL,rblIdEstado);

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
    }
    protected void ListaMenu(string sBMenuSuperior,string sBMenu)
    {
        gvDatos.DataSource = obj.ListaMenu(sBMenuSuperior,sBMenu);
        gvDatos.DataBind();
        
    }
    protected void ListaMenuPadre()
    {
        ddlMenu.Items.Clear(); 
        ddlMenu.DataSource = obj.ListaMenuPadre();
         ddlMenu.ClearSelection();
        ddlMenu.DataValueField = "IdMenu";        
        ddlMenu.DataTextField ="DetalleMenu"; 
        ddlMenu.DataBind();
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        rblIdEstado.Items[0].Selected = true;
        ListaMenuPadre();
        txtIdMenu.Text = "";
        txtIdMenu.Visible = false;
        txtMenu.Text = "";
        txtPosicion.Text = "";
        txtURL.Text = "";
        txtURL.Text = "~/";
        //pnlListaMenu.Visible = false;
        pnlRegistraMenu.Visible = true;
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;
        ddlMenu.Enabled = true;
        this.pnlRegistraMenu_ModalPopupExtender.Show();
        
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaMenu.Visible = true;
        pnlRegistraMenu.Visible = false;
        btnActualizar.Visible = false;
        txtIdMenu.Visible = false;
        txtIdMenu.Text = "";
        txtMenu.Text = "";
        txtPosicion.Text = "";
        txtURL.Text = "";
        rblIdEstado.ClearSelection();
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {
            ListaMenuPadre();
            ddlMenu.Enabled = false;
            int IdMenu = Convert.ToInt32(e.CommandArgument.ToString());
            pnlRegistraMenu.Visible = true;
            //pnlListaMenu.Visible=false;
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdMenu.Visible = false;
            this.pnlRegistraMenu_ModalPopupExtender.Show();

            DataTable dtDataTable = null;
            string DescripcionMenu = null;
            int PadredelItem=0;
            int Posicion=0;
            string Url = null;
            int IdEstado = 0;

            dtDataTable = obj.ListaMenuxIdMenu(IdMenu);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {

                    DescripcionMenu = Convert.ToString(drDataRow["Descripcion"]);
                    PadredelItem = Convert.ToInt32(drDataRow["IdMenuSuperior"]);
                    Posicion=Convert.ToInt32(drDataRow["Orden"]);
                    Url = Convert.ToString(drDataRow["URL"]);
                    IdEstado = Convert.ToInt32(drDataRow["IdEstado"]);
                }
                txtIdMenu.Text =Convert.ToString(IdMenu);
                txtMenu.Text = DescripcionMenu;
                txtPosicion.Text = Convert.ToString(Posicion);
                txtURL.Text = Url;
                ddlMenu.SelectedValue = Convert.ToString(PadredelItem);
                
                if (IdEstado == 658)
                {
                    rblIdEstado.Items[0].Selected = true;                    
                }
                else if (IdEstado == 660)
                {
                    rblIdEstado.Items[1].Selected = true;
                }
                else
                {
                    rblIdEstado.Items[2].Selected = true;
                }
            }

        }
       



    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        string sBMenuSuperior = txtBMenuSuperior.Text;
        string sBMenu = txtBMenu.Text;
        ListaMenu(sBMenuSuperior, sBMenu);
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {

        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";

        String sMensajeError = null;       
            string DetalleMenu = txtMenu.Text;
            int IdMenuSuperior = Convert.ToInt32(ddlMenu.SelectedValue);            
            int Orden = Convert.ToInt32(txtPosicion.Text);
            string URL = txtURL.Text;
            int IdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
            if( obj.InsertarMenu(iIdConexion, cOperacion, DetalleMenu, IdMenuSuperior, Orden, URL, IdEstado, ref sMensajeError))
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
            
            pnlListaMenu.Visible = true;
            pnlRegistraMenu.Visible = false;
            string sBMenuSuperior ="";
            string sBMenu = txtMenu.Text;
            ListaMenu(sBMenuSuperior, sBMenu);
            rblIdEstado.ClearSelection();
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";

        String sMensajeError = null;
        try
        {
            int IdMenu = Convert.ToInt32(txtIdMenu.Text);
            string DetalleMenu = txtMenu.Text;
            int IdMenuSuperior = Convert.ToInt32(ddlMenu.SelectedValue);
            int Orden = Convert.ToInt32(txtPosicion.Text);
            string URL = txtURL.Text;
            int IdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);

            if (obj.ActualizarMenu(iIdConexion, cOperacion, IdMenu, DetalleMenu, IdMenuSuperior, Orden, URL, IdEstado, ref sMensajeError))
            {
                string Msg = "Actualizacion realizada con exito";
                Master.MensajeOk(Msg);
            }
            else
            {
                 string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }
            pnlListaMenu.Visible = true;
            pnlRegistraMenu.Visible = false;
            txtIdMenu.Visible = false;
            string sBMenuSuperior = txtBMenuSuperior.Text;
            string sBMenu = txtBMenu.Text;
            ListaMenu(sBMenuSuperior, sBMenu);
            btnActualizar.Visible = false;
            rblIdEstado.ClearSelection();


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[1].Visible = false;
        }
       


    }
    protected void btnMenuSuperior_Click(object sender, EventArgs e)
    {
        string sBMenuSuperior = txtBMenuSuperior.Text;
        string sBMenu = txtBMenu.Text;
        ListaMenu(sBMenuSuperior,sBMenu);
    }
}