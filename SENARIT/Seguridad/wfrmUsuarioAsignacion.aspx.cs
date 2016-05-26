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




public partial class Seguridad_wfrmUsuarioAsignacion : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   clsOficinas ObjOficina = new clsOficinas();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //pnlBusquedaUsuario.Visible = true;
            btnVolverBusqueda.Visible = false;
            CambiarInterfaz();
            lblTitulo.Text = "Asignacion de rol a un usuario";
            int iTipo = 0;
            HabilitarPaneles(iTipo);
            //pnlListaUsuarios.Visible = false;
            //pnlUsuarioModuloRol.Visible = false;
            //pnlAsignaRol.Visible = false;
            //pnlListaRol.Visible = true;
                //ListaRol();
                //pnlRegistraRol.Visible = false;
                //ListaModulo();
                //ListaMenuSuperior();
        }
        else
        {  
                       
        }
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtBusquedaUsuario, btnBuscarUsuario);
        AgregarJSAtributos(txtBusquedaLogin, btnBuscarLogin);
        AgregarJSAtributos(txtBusquedaLoginExterno, btnBuscarLoginExterno);

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void btnBuscarUsuario_Click(object sender, EventArgs e)
    {
        string Operacion = "U";
        string Usuario = txtBusquedaUsuario.Text;        
        ListaUsuarios(Operacion,Usuario,null);
        int iTipo = 1;
        HabilitarPaneles(iTipo);
        //pnlListaUsuarios.Visible = true;
    }
    private void HabilitarPaneles(int iTipo)
    {
        switch (iTipo)
        {
            case 0:                
                this.pnlBusquedaUsuario.Visible = true;
                this.pnlAsignaRol.Visible = false;
                this.pnlListaUsuarios.Visible = false;
                this.pnlUsuarioModuloRol.Visible = false;
                this.TabContainer1.ActiveTabIndex = 0;
                this.txtBusquedaUsuario.Focus();
                break;
            case 1:
                this.pnlBusquedaUsuario.Visible = true;                              
                this.pnlAsignaRol.Visible = false;
                this.pnlListaUsuarios.Visible = true;  
                this.pnlUsuarioModuloRol.Visible = false;

                this.TabContainer1.ActiveTabIndex = 1;
              
                break;
            case 2:
                
                this.pnlBusquedaUsuario.Visible = true;                              
                this.pnlAsignaRol.Visible = false;
                this.pnlListaUsuarios.Visible = true;  
                this.pnlUsuarioModuloRol.Visible = true;
                this.TabContainer1.ActiveTabIndex = 2;
                
                break;
            case 3:
                this.pnlBusquedaUsuario.Visible = true;                              
                this.pnlAsignaRol.Visible = true;
                this.pnlListaUsuarios.Visible = true;  
                this.pnlUsuarioModuloRol.Visible = true;               
                this.TabContainer1.ActiveTabIndex = 3;             
                break;
        }

    }
    protected void btnBuscarLogin_Click(object sender, EventArgs e)
    {
        string Operacion = "L";
        string LoginUsuario = txtBusquedaLogin.Text;
        ListaUsuarios(Operacion, null,LoginUsuario);
        int iTipo = 1;
        HabilitarPaneles(iTipo);
        //pnlListaUsuarios.Visible = true;
    }
    protected void btnBuscarLoginExterno_Click(object sender, EventArgs e)
    {
        string Operacion = "E";
        string LoginUsuario = txtBusquedaLoginExterno.Text;
        ListaUsuarios(Operacion, null, LoginUsuario);
        int iTipo = 1;
        HabilitarPaneles(iTipo);
        //pnlListaUsuarios.Visible = true;
    }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
    }
    protected void ListaUsuarios(string Operacion,string Usuario,string LoginUsuario)
    {
      //System.Threading.Thread.Sleep(2000);        
        gvListaUsuarios.DataSource = obj.UsuarioLista(Operacion,Usuario,LoginUsuario);
        gvListaUsuarios.DataBind();
    }
    protected void gvListaUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvListaUsuarios.PageIndex = e.NewPageIndex;
        if (Convert.ToString(txtBusquedaLogin.Text) == "")
        {
            string Operacion = "U";
            string Usuario = txtBusquedaUsuario.Text;
            ListaUsuarios(Operacion, Usuario, null);
        }
        else
        {
            string Operacion = "L";
            string LoginUsuario = txtBusquedaLogin.Text;
            ListaUsuarios(Operacion, null, LoginUsuario);
        }              
        
        //pnlListaUsuarios.Visible = true;
    }
  
  


    protected void gvListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {

        int iTipo = 2;
        HabilitarPaneles(iTipo);
        btnVolverBusqueda.Visible = true;
        //pnlBusquedaUsuario.Visible = false;
        //pnlListaUsuarios.Visible = false;
        //pnlUsuarioModuloRol.Visible = true;
        GridViewRow row = gvListaUsuarios.SelectedRow;         
        
        int IdUsuario = Convert.ToInt32(row.Cells[1].Text);
        ViewState["IdUsuario"] = IdUsuario;
        IdUsuario = (int)ViewState["IdUsuario"];
        int Carnet = Convert.ToInt32(Convert.ToString(row.Cells[2].Text));
        ViewState["Carnet"] = Carnet;
        lblNombreCompleto.Text =Convert.ToString(row.Cells[3].Text);
        lblNombreCompleto0.Text= Convert.ToString(row.Cells[3].Text);
        lblLogin.Text = Convert.ToString(row.Cells[4].Text);
        lblLogin0.Text = Convert.ToString(row.Cells[4].Text);
        ViewState["NombreCompleto"] = Convert.ToString(row.Cells[3].Text);
        ViewState["Login"] = Convert.ToString(row.Cells[4].Text);
        UsuarioListaModuloRol(IdUsuario);
        btnAsignar.Visible = true;
    }
  
    protected void UsuarioListaModuloRol(int iIdUsuario)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "O";
        string sMensajeError = null;
        DataTable TblUsuarioListaModuloRol = obj.UsuarioListaModuloRol(iIdUsuario);

        gvUsuarioModuloRol.DataSource = TblUsuarioListaModuloRol;
        gvUsuarioModuloRol.DataBind();

        DataTable TblUsuarioOficinaLista = ObjOficina.UsuarioOficinaLista(iIdConexion, cOperacion, iIdUsuario, ref sMensajeError);
        gvUsuarioOficina.DataSource = TblUsuarioOficinaLista;
        gvUsuarioOficina.DataBind();

        if (TblUsuarioOficinaLista!=null)
        {

            int Index = 0;

            hfIdOficina.Value = Convert.ToString(gvUsuarioOficina.DataKeys[Index].Values["IdOficina"]);
            hfIdArea.Value = Convert.ToString(gvUsuarioOficina.DataKeys[Index].Values["IdArea"]);
        }
        else
        {
            hfIdOficina.Value = "";
            hfIdArea.Value = "";
        }




    }
    protected void gvUsuarioModuloRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        string sSessionTrabajo = null;
        string sSNN = null;
        string sMensajeError = null;       
        GridViewRow row = gvUsuarioModuloRol.SelectedRow;

        int iIdRol = Convert.ToInt32(gvUsuarioModuloRol.DataKeys[row.RowIndex].Values["IdRol"]);
        int iIdUsuario = Convert.ToInt32(gvUsuarioModuloRol.DataKeys[row.RowIndex].Values["IdUsuario"]);
        int iIdRolUsuario = Convert.ToInt32(gvUsuarioModuloRol.DataKeys[row.RowIndex].Values["IdRolUsuario"]);
        
        

        if (obj.UsuarioRolBaja(iIdConexion, cOperacion, sSessionTrabajo, sSNN,iIdRolUsuario,iIdRol, iIdUsuario, ref sMensajeError))
        {
            string Msg = "Actualizacion realizada con exito";
            Master.MensajeOk(Msg);
            UsuarioListaModuloRol(iIdUsuario);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void gvUsuarioModuloRol_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEliminar")
        {
            try
            {

                int Index = Convert.ToInt32(e.CommandArgument);
                
                //int iIdTransaccion = Convert.ToInt32(gvListaRolesAct.DataKeys[Index].Values["IdTransaccion"]);
                ////int iIdRol = Convert.ToInt32(gvListaRolesAct.DataKeys[Index].Values["IdRol"]);
                //int iIdRol = Convert.ToInt32(txtIdRolAct.Text);
                //int iIdModulo = Convert.ToInt32(gvListaRolesAct.DataKeys[Index].Values["IdModulo"]);
                //int iIdConexcion = (int)Session["IdConexion"];

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "U";
                string sSessionTrabajo = null;
                string sSNN = null;
                string sMensajeError = null;
               // GridViewRow row = gvUsuarioModuloRol.SelectedRow;

                int iIdRol = Convert.ToInt32(gvUsuarioModuloRol.DataKeys[Index].Values["IdRol"]);
                int iIdUsuario = Convert.ToInt32(gvUsuarioModuloRol.DataKeys[Index].Values["IdUsuario"]);
                int iIdRolUsuario = Convert.ToInt32(gvUsuarioModuloRol.DataKeys[Index].Values["IdRolUsuario"]);



                if (obj.UsuarioRolBaja(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdRolUsuario, iIdRol, iIdUsuario, ref sMensajeError))
                {
                    string Msg = "Actualizacion realizada con exito";
                    Master.MensajeOk(Msg);
                    UsuarioListaModuloRol(iIdUsuario);
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

    protected void btnVolverBusqueda_Click(object sender, EventArgs e)
    {
        //pnlBusquedaUsuario.Visible = true;
        //pnlListaUsuarios.Visible = false;
        //pnlUsuarioModuloRol.Visible = false;
        //pnlAsignaRol.Visible = false;
        int iTipo = 0;
        HabilitarPaneles(iTipo);
        btnAsignar.Visible = false;
        txtBusquedaLogin.Text = "";
        txtBusquedaUsuario.Text = "";
        txtBusquedaLoginExterno.Text = "";
        btnVolverBusqueda.Visible = false;
    }
    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        ListaOficinas();
        int iTipo = 3;
        HabilitarPaneles(iTipo);
        //pnlBusquedaUsuario.Visible = false;
        //pnlListaUsuarios.Visible = false;
        //pnlUsuarioModuloRol.Visible =true;
        //pnlAsignaRol.Visible = true;        
        lblCarnet.Text = Convert.ToString((int)ViewState["Carnet"]);
        txtFechaExpiracion.Text = "";

        
    }
    protected void ListaModulo()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string sOperacion = "Q";
        ddlModulo.Items.Clear();
        ddlModulo.ClearSelection();
        ddlModulo.DataSource = obj.ListaModulos(iIdConexion, sOperacion);
        ddlModulo.DataValueField = "IdModulo";
        ddlModulo.DataTextField = "DescripcionModulo";
        ddlModulo.DataBind();
        ddlModulo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlModulo.SelectedValue = "0";
    }
    protected void ListaRoles(int IdModulo)
    {
        gvAsignaRol.DataSource = obj.ListaRolconParametro(IdModulo);        
        gvAsignaRol.DataBind();
        int iContador = gvAsignaRol.Rows.Count;
        if (iContador == 0)
        {
            btnAsignarRol.Visible = false;
        }
        else
        {
            btnAsignarRol.Visible = true;
        }
    }


   

    protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int IdModulo=Convert.ToInt32(ddlModulo.SelectedValue);
        ListaRoles(IdModulo);
        
        //pnlAsignaRol.Visible = true;
    }
    protected void btnAsignarRol_Click(object sender, EventArgs e)
    {
        
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "C";
            String Mensaje1="";
            String Mensaje2 = "";
            String MensajeTotal = "";
            String sMensajeError = "";
            int IdUsuario=0;
            btnAsignar.Visible = true;


            int IdOficina = Convert.ToInt32(ddlIdOficina.SelectedValue);
            int IdArea = Convert.ToInt32(ddlIdArea.SelectedValue);
            int IdModulo = Convert.ToInt32(ddlModulo.SelectedValue);
            int iIdUsuario = (int)ViewState["IdUsuario"];
            IdUsuario = 0;
            int Carnet=(int)ViewState["Carnet"];
            String ClaveUsuario = obj.Encriptar(Convert.ToString(Carnet));
            String sFechaExpiracion = txtFechaExpiracion.Text;
            if (sFechaExpiracion == "")
            {
                sFechaExpiracion = null;
            }

            //obj.UsuarioObtenerId(Carnet,ClaveUsuario,IdOficina,IdArea, out IdUsuario, out Mensaje1);

            obj.UsuarioObtenerId(iIdConexion,cOperacion,iIdUsuario,Carnet, ClaveUsuario, IdOficina, IdArea, ref IdUsuario, ref sMensajeError);


            if (IdUsuario != 0)
            {
                cOperacion = "I";
                foreach (GridViewRow row in gvAsignaRol.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRol = (row.Cells[0].FindControl("chkRol") as CheckBox);

                        if (chkRol.Checked)
                        {
                            // en lugar de val guardar registro
                            int IdRol = Convert.ToInt32(row.Cells[1].Text);
                            obj.UsuarioRol(iIdConexion, cOperacion, IdRol, IdUsuario, sFechaExpiracion,ref sMensajeError);
                            MensajeTotal = MensajeTotal + sMensajeError;

                        }
                    }
                }
            }
            MensajeTotal = MensajeTotal + sMensajeError + Mensaje1;

            if (MensajeTotal == null || MensajeTotal == "")
            {
                string msg = "Se realizo la operacion con exito";
                Master.MensajeOk(msg);

                //pnlBusquedaUsuario.Visible = false;
                //pnlListaUsuarios.Visible = false;
                //pnlAsignaRol.Visible = false;
                //pnlUsuarioModuloRol.Visible = true;
                int Ci=(int)ViewState["Carnet"];
                UsuarioListaModuloRol(IdUsuario);
                btnAsignar.Visible = true;

            }
            else
            {

                string Error = "Error al realizar la operación";
                string DetalleError = MensajeTotal;
                Master.MensajeError(Error, DetalleError);
                //pnlBusquedaUsuario.Visible = false;
                //pnlListaUsuarios.Visible = false;
                //pnlAsignaRol.Visible = false;
                //pnlUsuarioModuloRol.Visible = true;
                int Ci = (int)ViewState["Carnet"];
                UsuarioListaModuloRol(IdUsuario);
                btnAsignar.Visible = false;
            }
        }
        catch (Exception ex)
        {
            
            string Error = "Error al realizar la operación";
            string DetalleError =  Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void ListaOficinas()
    {
        ddlIdOficina.Items.Clear();
        ddlIdOficina.ClearSelection();
        ddlIdOficina.DataSource = obj.ListaOficinas();
        ddlIdOficina.DataValueField = "IdOficina";
        ddlIdOficina.DataTextField = "Nombre";
        ddlIdOficina.DataBind();
        ddlIdOficina.Items.Insert(0, new ListItem("Seleccione...", "0"));
        if (hfIdOficina.Value == "")
        {
            ddlIdOficina.SelectedValue = "0";
        }
        else
        {
        ddlIdOficina.SelectedValue=hfIdOficina.Value;
        ListaArea(Convert.ToInt32(hfIdOficina.Value));
        }

    }
    protected void ddlIdOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int IdOficina = Convert.ToInt32(ddlIdOficina.SelectedValue);
        hfIdArea.Value = "";
        ListaArea(IdOficina);
    }
    protected void ListaArea(int IdOficina)
    {
        ddlIdArea.Items.Clear();
        ddlIdArea.ClearSelection();
        ddlIdArea.DataSource = obj.ListaArea(IdOficina);
        ddlIdArea.DataValueField = "IdArea";
        ddlIdArea.DataTextField = "Descripcion";
        ddlIdArea.DataBind();
        ddlIdArea.Items.Insert(0, new ListItem("Seleccione...", "0"));

        if (hfIdArea.Value == "")
        {
            ddlIdArea.SelectedValue = "0";
        }
        else
        {
            ddlIdArea.SelectedValue = hfIdArea.Value;
            ListaModulo();
        }
        
    }
    protected void ddlIdArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaModulo();
    }
    
   
}