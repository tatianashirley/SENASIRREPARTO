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




public partial class Seguridad_wfrmRol : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaRol.Visible = true;
            
            
            pnlRegistraRol.Visible = false;
            pnlActualizaRol.Visible = false;            
            CambiarInterfaz();
            btnAdicionar.Visible = true;
            btnActualizar.Visible = true;
            ListaIdModulo();

        }
       
        
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtRol, ddlModulo);
        AgregarJSAtributos(txtRolAct, ddlIdModuloAct);

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
    protected void ListaRol(int iIdModulo)
    {
        gvDatos.DataSource = null;
        gvDatos.DataSource = obj.ListaRolconParametro(iIdModulo);
        gvDatos.DataBind();
    }
    protected void ListaMenuconParametro(int IdMenuSuperior)
    {
        
        gvDatos2.DataSource = obj.ListaMenuconParametro(IdMenuSuperior);
        gvDatos2.DataBind();
        int iContador = gvDatos2.Rows.Count;
        if (iContador == 0)
        {
            btnAdicionar.Visible = false;
        }
        else
        {
            btnAdicionar.Visible = true;
        }
    }
    protected void ListaModulo()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string sOperacion = "Q";
        ddlModulo.ClearSelection();
        ddlModulo.Items.Clear();
        ddlModulo.DataSource = obj.ListaModulos(iIdConexion,sOperacion);
        ddlModulo.DataValueField = "IdModulo";        
        ddlModulo.DataTextField ="DescripcionModulo"; 
        ddlModulo.DataBind();
        ddlModulo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlModulo.SelectedValue = "0";
    }
    protected void ListaIdModulo()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string sOperacion = "Q";
        ddlIdModulo.ClearSelection();
        ddlIdModulo.Items.Clear();
        ddlIdModulo.DataSource = obj.ListaModulos(iIdConexion, sOperacion);
        ddlIdModulo.DataValueField = "IdModulo";
        ddlIdModulo.DataTextField = "DescripcionModulo";
        ddlIdModulo.DataBind();
        ddlIdModulo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdModulo.SelectedValue = "0";
    }
    protected void ListaMenuSuperior()
    {
        ddlMenuSuperior.Items.Clear();
        ddlMenuSuperior.ClearSelection();        
        ddlMenuSuperior.DataSource = obj.ListaMenuSuperior();
        ddlMenuSuperior.DataValueField = "IdTransaccion";
        ddlMenuSuperior.DataTextField = "Menu";
        ddlMenuSuperior.DataBind();
        ddlMenuSuperior.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlMenuSuperior.SelectedValue = "0";
    }
    protected void ListaModuloAct()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string sOperacion = "Q";
        ddlIdModuloAct.Items.Clear();
        ddlIdModuloAct.DataSource = obj.ListaModulos(iIdConexion, sOperacion);
        ddlIdModuloAct.DataValueField = "IdModulo";
        ddlIdModuloAct.DataTextField = "DescripcionModulo";
        ddlIdModuloAct.DataBind();
        ddlIdModuloAct.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdModuloAct.SelectedValue ="0";
    }
    protected void ListaMenuSuperiorAct()
    {
        ddlIdMenuSuperiorAct.ClearSelection();
        ddlIdMenuSuperiorAct.Items.Clear();
        ddlIdMenuSuperiorAct.DataSource = obj.ListaMenuSuperior();
        ddlIdMenuSuperiorAct.DataValueField = "IdTransaccion";
        ddlIdMenuSuperiorAct.DataTextField = "Menu";
        ddlIdMenuSuperiorAct.DataBind();
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        //gvDatos2.DataSource = null;
        //pnlListaRol.Visible = false;
        txtRol.Text = "";
        pnlRegistraRol.Visible = true;
        this.pnlRegistra_ModalPopupExtender.Show();   
        pnlActualizaRol.Visible = false;
        ListaModulo();
        ListaMenuSuperior();
        btnAdicionar.Visible = true;
        //this.pnlDatos_ModalPopupExtender.Show();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaRol.Visible = true;
        pnlRegistraRol.Visible = false;
        pnlActualizaRol.Visible = false;
        txtRol.Text = "";
        txtIdRolAct.Text = "";
        txtRolAct.Text = "";
        btnActualizar.Visible = false;
        btnAdicionar.Visible = false;
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {

            int iIdConexcion = (int)Session["IdConexion"];
            string cOperacion = "V";
            string sSessionTrabajo = null;
            string sSNN = null;
            int Index = Convert.ToInt32(e.CommandArgument);
            int IdRol = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdRol"]);
            ListaModuloAct();
            int IdModulo = Convert.ToInt32(gvDatos.DataKeys[Index].Values["IdModulo"]);
            ddlIdModuloAct.SelectedValue = Convert.ToString(IdModulo);
            txtIdRolAct.Text = Convert.ToString(IdRol);
            string sIdTransaccion = null;
            string sIdMenuSuperior = null;
            
            // Visualizacion paneles
            pnlListaRol.Visible = false;
            this.pnlActualiza_ModalPopupExtender.Show();   
          
            ListaMenuSuperiorAct();
            pnlActualizaRol.Visible = true;
            pnlRegistraRol.Visible = false;
            btnActualizar.Visible = true;

            ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);
            DataTable dtDataTable = null;
            dtDataTable = obj.ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);

            if (dtDataTable.Rows.Count > 0)
            {
                txtRolAct.Text = Convert.ToString(dtDataTable.Rows[1]["DescripcionRol"]);
                txtDetalleRolAct.Text= Convert.ToString(dtDataTable.Rows[1]["DetalleRol"]);
               // ddlIdModuloAct.SelectedValue = Convert.ToString(dtDataTable.Rows[1]["IdModulo"]);
                rblIdEstadoAct.SelectedValue=Convert.ToString(dtDataTable.Rows[1]["IdEstadoRol"]);
            }
        }
    }
    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;

        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        ListaRol(iIdModulo);
    }
    //protected void gvDatos2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    this.pnlRegistra_ModalPopupExtender.Show();
    //    gvDatos2.PageIndex = e.NewPageIndex;
    //    ViewState["IdTransaccion"] = Convert.ToInt32(ddlMenuSuperior.SelectedValue);
    //    int IdTransaccion = (int)ViewState["IdTransaccion"];
    //    ListaMenuconParametro(IdTransaccion);
        
    //    ddlMenuSuperior.SelectedValue = Convert.ToString(IdTransaccion); 
    //}
    protected void gvListaRolesAct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvListaRolesAct.PageIndex = e.NewPageIndex;     
        this.pnlActualiza_ModalPopupExtender.Show();          
        int iIdConexcion = (int)Session["IdConexion"];
        string cOperacion = "V";
        string sSessionTrabajo = null;
        string sSNN = null;
        int IdRol = Convert.ToInt32(txtIdRolAct.Text);
        txtIdRolAct.Text = Convert.ToString(IdRol);
        string sIdTransaccion = null;
        string sIdMenuSuperior = Convert.ToString(ddlIdMenuSuperiorAct.SelectedValue);
        if (sIdMenuSuperior=="100")
        {
            sIdMenuSuperior = null;
        }
        
        pnlListaRol.Visible = false;
        pnlActualizaRol.Visible = true;

        ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);
        DataTable dtDataTable = null;
        dtDataTable = obj.ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);

        if (dtDataTable.Rows.Count > 0)
        {
            txtRolAct.Text = Convert.ToString(dtDataTable.Rows[1]["DescripcionRol"]);
        }
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            String Mensaje1=null;
            String Mensaje2 = null;
            String MensajeTotal=null;
            string DetalleRol = txtRol.Text;
            string DetRol = txtDetalleRol.Text;
            int IdModulo = Convert.ToInt32(ddlModulo.SelectedValue);
            int IdMenuSuperior = Convert.ToInt32(ddlMenuSuperior.SelectedValue);
            int IdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
            int CodTransaccion;
            int IdRol=0;
            string sMensajeError = "Error:";
            obj.InsertarRol(iIdConexion, cOperacion, DetalleRol, IdModulo, IdEstado, IdMenuSuperior, DetRol, ref IdRol, ref sMensajeError);

            if (IdRol != 0)
            {
                foreach (GridViewRow row in gvDatos2.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkTransaccion = (row.Cells[0].FindControl("chkTransaccion") as CheckBox);

                        if (chkTransaccion.Checked)
                        {
                            // en lugar de val guardar registro
                            CodTransaccion = Convert.ToInt32(row.Cells[2].Text);
                            MensajeTotal="";
                            if (obj.InsertarTransaccionAutorizada(iIdConexion, cOperacion, IdRol, CodTransaccion, ref sMensajeError))
                            {
                                MensajeTotal = null;
                            }
                            else
                            {

                                MensajeTotal = sMensajeError + MensajeTotal;
                            }
                            
                            
                            MensajeTotal = MensajeTotal + Mensaje2;

                        }
                    }
                }
            }
           

            if (MensajeTotal == null || MensajeTotal == "")
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);

                pnlListaRol.Visible = true;
                pnlRegistraRol.Visible = false;                
                ListaRol(IdModulo);
            }
            else
            {

                string Error = "Error al realizar la operación";
                string DetalleError = MensajeTotal;
                Master.MensajeError(Error, DetalleError);
                pnlListaRol.Visible = true;
                pnlRegistraRol.Visible = false;                
                ListaRol(IdModulo);
            }
        }
        catch (Exception ex)
            {
                throw ex;
            }
    }
    protected void ddlMenuSuperior_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ViewState["IdTransaccion"] = Convert.ToInt32(ddlMenuSuperior.SelectedValue);
        int IdTransaccion = (int)ViewState["IdTransaccion"];
        ListaMenuconParametro(IdTransaccion);
        this.pnlRegistra_ModalPopupExtender.Show();
        ddlMenuSuperior.SelectedValue = Convert.ToString(IdTransaccion);        
        
    }

    
    protected void ListaRolActualizar(int iIdConexcion, string cOperacion,string sSessionTrabajo,string sSNN,int IdRol,string sIdTransaccion,string sIdMenuSuperior)
    {
        gvListaRolesAct.DataSource = obj.ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);
        gvListaRolesAct.DataBind();
    }

    protected void gvListaRolesAct_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        this.pnlActualiza_ModalPopupExtender.Show();
        pnlActualizaRol.Visible = true;
        GridViewRow row = gvListaRolesAct.SelectedRow;
        int iIdTransaccion = Convert.ToInt32(row.Cells[3].Text);
        int iIdRol = Convert.ToInt32(txtIdRolAct.Text);
        int iIdModulo = Convert.ToInt32(ddlIdModuloAct.SelectedValue);        
        int iIdConexcion = (int)Session["IdConexion"];
        string cOperacion = "D";
        string sSessionTrabajo = null;
        string sSNN = null;        
        string sIdMenuSuperior = null;
        
        String sMensajeError = null;

        if (obj.TransaccionAutorizadaElimina(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, iIdRol, iIdTransaccion, sIdMenuSuperior,ref sMensajeError))
        {
            string Msg = "Actualizacion realizada con exito";
            Master.MensajeOk(Msg);

                cOperacion = "V";
                
                int IdRol = Convert.ToInt32(txtIdRolAct.Text);
               
                string sIdTransaccion = null;
                sIdMenuSuperior = Convert.ToString(ddlIdMenuSuperiorAct.SelectedValue);
                
                // Visualizacion paneles
                pnlListaRol.Visible = false;
                ListaModuloAct();
                ListaMenuSuperiorAct();
                pnlActualizaRol.Visible = true;

                ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);
                ddlIdModuloAct.SelectedValue = Convert.ToString(iIdModulo);
                ddlMenuSuperior.SelectedValue = Convert.ToString(sIdMenuSuperior);
                           
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void gvListaRolesAct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEliminar")
        {
            try
            {

                int Index = Convert.ToInt32(e.CommandArgument);
                this.pnlActualiza_ModalPopupExtender.Show();
                pnlActualizaRol.Visible = true;
                GridViewRow row = gvListaRolesAct.SelectedRow;
                int iIdTransaccion = Convert.ToInt32(gvListaRolesAct.DataKeys[Index].Values["IdTransaccion"]);
                //int iIdRol = Convert.ToInt32(gvListaRolesAct.DataKeys[Index].Values["IdRol"]);
                int iIdRol = Convert.ToInt32(txtIdRolAct.Text);
                int iIdModulo = Convert.ToInt32(gvListaRolesAct.DataKeys[Index].Values["IdModulo"]);
                int iIdConexcion = (int)Session["IdConexion"];
                string cOperacion = "D";
                string sSessionTrabajo = null;
                string sSNN = null;
                string sIdMenuSuperior = null;

                String sMensajeError = null;

                if (obj.TransaccionAutorizadaElimina(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, iIdRol, iIdTransaccion, sIdMenuSuperior, ref sMensajeError))
                {
                    string Msg = "Actualizacion realizada con exito";
                    Master.MensajeOk(Msg);

                    cOperacion = "V";

                    int IdRol = Convert.ToInt32(txtIdRolAct.Text);

                    string sIdTransaccion = null;
                    sIdMenuSuperior = Convert.ToString(ddlIdMenuSuperiorAct.SelectedValue);

                    // Visualizacion paneles
                    pnlListaRol.Visible = false;
                    ListaModuloAct();
                    ListaMenuSuperiorAct();
                    pnlActualizaRol.Visible = true;

                    ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);
                    ddlIdModuloAct.SelectedValue = Convert.ToString(iIdModulo);
                    ddlIdMenuSuperiorAct.SelectedValue = Convert.ToString(sIdMenuSuperior);

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

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
         
            String MensajeTotal = null;
            string msg = null;
            string cOperacion;
            
            int iIdRol = Convert.ToInt32(txtIdRolAct.Text);
            int iIdConexion = (int)Session["IdConexion"];            
            string sSessionTrabajo = null;
            string sSNN = null;
            int iIdModulo = Convert.ToInt32(ddlIdModuloAct.SelectedValue);
            int iIdMenuSuperior = Convert.ToInt32(ddlIdMenuSuperiorAct.SelectedValue);            
            string sDetalleRol = txtRolAct.Text;
            string sDetRol = txtDetalleRolAct.Text; //Campo añadido posterior al desarrollo del módulo
            String sMensajeError = null;
            
            int iIdEstadoRol = Convert.ToInt32(rblIdEstadoAct.SelectedValue);
            int iIdTransaccion;

            if ((Convert.ToInt32(ddlIdModuloAct.SelectedValue) != 0)&&(Convert.ToInt32(ddlIdMenuSuperiorAct.SelectedValue) != 0))
            {
                cOperacion = "U";
                if (obj.RolActualiza(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdRol, sDetalleRol, iIdModulo, iIdEstadoRol, sDetRol, ref sMensajeError))
                {
                    string Msg = "Se actualizo el Rol Correctamente";

                }
                else
                {

                    MensajeTotal = sMensajeError;

                }
            }

            if (iIdRol != 0)
            {
                cOperacion = "I";
                foreach (GridViewRow row in gvListaRolesAct.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkTransaccion = (row.Cells[0].FindControl("chkTransaccion") as CheckBox);

                        if (chkTransaccion.Checked)
                        {
                            
                            iIdTransaccion = Convert.ToInt32(row.Cells[3].Text);
                            if (obj.TransaccionAutorizadaInserta(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdRol, iIdTransaccion, ref sMensajeError))
                            {
                                string Msg = null;
                                
                            }
                            else
                            {
                                
                                MensajeTotal = sMensajeError+MensajeTotal;
                                
                            }

                        }
                    }
                }
            }
           

            if (MensajeTotal == null || MensajeTotal == "")
            {
                string Msg = "Se realizo de forma correcta la operación";
                Master.MensajeOk(Msg);

                pnlListaRol.Visible = true;
                pnlRegistraRol.Visible = false;
                pnlActualizaRol.Visible = false;
                ListaRol(iIdModulo);
            }
            else
            {

                string Error = "Error al realizar la operación";
                string DetalleError = MensajeTotal;
                Master.MensajeError(Error, DetalleError);
                pnlListaRol.Visible = true;
                pnlRegistraRol.Visible = false;
                pnlActualizaRol.Visible = false;
                ListaRol(iIdModulo);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ddlMenuSuperiorAct_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnlActualiza_ModalPopupExtender.Show();        
        int iIdMenuSuperior=Convert.ToInt32(ddlIdMenuSuperiorAct.SelectedValue);
        int iIdConexcion = (int)Session["IdConexion"];
        string cOperacion = "V";
        string sSessionTrabajo = null;
        string sSNN = null;
        int IdRol = Convert.ToInt32(txtIdRolAct.Text);
        txtIdRolAct.Text = Convert.ToString(IdRol);
        string sIdTransaccion = null;
        
        string sIdMenuSuperior = Convert.ToString(ddlIdMenuSuperiorAct.SelectedValue);

        if (sIdMenuSuperior == "100")
        {
            sIdMenuSuperior = null;
        }

        string sIdModulo = Convert.ToString(ddlIdModuloAct.SelectedValue);
        if (sIdMenuSuperior == "0")
        {
            btnActualizar.Visible = false;
        }
        else
        {
            btnActualizar.Visible=true;
        }
        // Visualizacion paneles
        pnlListaRol.Visible = false;
        ListaModuloAct();
        ddlIdModuloAct.SelectedValue = sIdModulo;
        ListaMenuSuperiorAct();
        pnlActualizaRol.Visible = true;

        ListaRolActualizar(iIdConexcion, cOperacion, sSessionTrabajo, sSNN, IdRol, sIdTransaccion, sIdMenuSuperior);
        ddlIdMenuSuperiorAct.SelectedValue = Convert.ToString(iIdMenuSuperior);
        

       
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
            
        }
        //if (this.gvDatos.Rows.Count > 0)
        //{
        //    gvDatos.UseAccessibleHeader = true;
        //    gvDatos.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    //gvDatos.FooterRow.TableSection = TableRowSection.TableFooter;
        //}
      //  e.Row.Cells[1].Visible = false;


    }



    protected void ddlIdModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        ListaRol(iIdModulo);
        gvDatos.Columns[1].Visible = false;
        gvDatos.Columns[5].Visible = false;
    }
}