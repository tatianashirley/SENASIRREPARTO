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

public partial class Seguridad_wfrmMensajeError : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   clsMensajeError ObjMensajeError = new clsMensajeError();
   clsProcedimientos ObjProcedimientos = new clsProcedimientos();
   ListItem oItem = new ListItem("Seleccione...", "0");
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaMensajeError.Visible = true;
            ListaModulo();
            //ListaMensajeError();
            
            pnlRegistraMensajeError.Visible = false;
            
            //ListaMensajeErrorPadre();
        }
        //else
        //{
        //    ListaMensajeError();            
        //}
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtNroMensaje, txtDescripcionMensajeError);
        AgregarJSAtributos(txtDescripcionMensajeError, btnAdicionar);
        AgregarJSAtributos(txtDescripcionMensajeError, btnActualizar);

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void ddlIdModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ListaMensajeError();
        ListaProcedimiento();
    }
    private void MensajeError(int MensajeError)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(MensajeError);
    }
    protected void ListaMensajeError()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;
        //int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimientoLista.SelectedValue);
        string sMensajeError = null;
        gvDatos.DataSource = ObjMensajeError.ListaMensajeErrorPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdProcedimiento, ref sMensajeError);
        gvDatos.DataBind();
    }
    protected void ListaModulo()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string sOperacion = "Q";
        ddlIdModulo.Items.Clear();
        ddlIdModulo.DataSource = obj.ListaModulos(iIdConexion, sOperacion);
        ddlIdModulo.DataValueField = "IdModulo";
        ddlIdModulo.DataTextField = "DescripcionModulo";
        ddlIdModulo.DataBind();
        ddlIdModulo.Items.Insert(0, new ListItem("Seleccione...", "0"));

    }
 
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        Label1.Text = "Nuevo Mensaje de Error";
        ddlIdModuloRegistrar.Enabled = true;
        //pnlListaMensajeError.Visible = false;
        this.pnlRegistra_ModalPopupExtender.Show();  
        pnlRegistraMensajeError.Visible = true;
        
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;

        ListaModuloRegistrar();
        txtDescripcionMensajeError.Text = "";
        txtIdMensaje.Text = "";
        txtIdMensaje.Visible = false;
        lblNroMensaje.Visible = true;
        txtNroMensaje.Visible = true;
        ddlIdProcedimiento.Visible = true;
        lblProcedimiento.Visible = true;
       
        
        
        
        
       
    }
    protected void ListaModuloRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        ddlIdProcedimiento.ClearSelection();
        ddlIdModuloRegistrar.ClearSelection();
        ddlIdModuloRegistrar.DataSource = obj.ListaModulos(iIdConexion, cOperacion);
        ddlIdModuloRegistrar.DataValueField = "IdModulo";
        ddlIdModuloRegistrar.DataTextField = "DescripcionModulo";
        ddlIdModuloRegistrar.DataBind();
    }
    

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaMensajeError.Visible = true;
        pnlRegistraMensajeError.Visible = false;
        btnActualizar.Visible = false;
        txtIdMensaje.Visible = false;
        txtDescripcionMensajeError.Text = "";
        lblNroMensaje.Visible = false;
        txtNroMensaje.Visible = false;
        txtNroMensaje.Text = "";
        txtDescripcionMensajeError.Text = "";
       
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            Label1.Text = "Editar Mensaje de Error";
            ListaModuloRegistrar();
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";

            int iIdMensaje = Convert.ToInt32(e.CommandArgument.ToString());
            pnlRegistraMensajeError.Visible = true;
            //pnlListaMensajeError.Visible = false;
            this.pnlRegistra_ModalPopupExtender.Show();  
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdMensaje.Visible = false;
            ddlIdModuloRegistrar.Enabled = false;


            DataTable dtDataTable = null;
            string sMensajeError = null;
            

            dtDataTable = ObjMensajeError.ListaMensajeErrorPorId(iIdConexion, cOperacion, iIdMensaje, ref sMensajeError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    txtIdMensaje.Text = Convert.ToString(drDataRow["IdMensaje"]);
                    txtDescripcionMensajeError.Text = Convert.ToString(drDataRow["TextoMensaje"]);
                    ddlIdModuloRegistrar.SelectedValue = Convert.ToString(drDataRow["IdMensaje"]).Substring(0, 2);
                    ddlIdProcedimiento.Visible = false;
                    lblProcedimiento.Visible = false;
                    
                }


            }
        }




    }
 

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        ListaMensajeError();
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";        
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        int iIdMensajeError = Convert.ToInt32(txtNroMensaje.Text);
        string sDescripcionMensajeError = txtDescripcionMensajeError.Text;
        string sMensajeError=null;
        if (ObjMensajeError.MensajeErrorAdiciona(iIdConexion, cOperacion, iIdMensajeError,sDescripcionMensajeError, iIdModulo, ref sMensajeError))
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
        pnlListaMensajeError.Visible = true;
        pnlRegistraMensajeError.Visible = false;
        txtDescripcionMensajeError.Text = "";
        lblNroMensaje.Visible = false;
        txtNroMensaje.Visible = false;
        txtNroMensaje.Text = "";
        txtDescripcionMensajeError.Text = "";
        //ListaMensajeError();
        
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        int iIdMensaje =Convert.ToInt32(txtIdMensaje.Text);
        string sDescripcion = txtDescripcionMensajeError.Text;
        
        string sMensajeError = null;
        if (ObjMensajeError.MensajeErrorModifica(iIdConexion, cOperacion, iIdMensaje, sDescripcion,  ref sMensajeError))
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
        
        pnlRegistraMensajeError.Visible = false;
        txtDescripcionMensajeError.Text = "";
        pnlListaMensajeError.Visible = true;
        pnlRegistraMensajeError.Visible = false;
        txtDescripcionMensajeError.Text = "";

        txtIdMensaje.Text = "";

        btnActualizar.Visible = false;
        txtIdMensaje.Visible = false;
        //ListaMensajeError();

        
        
    }


    protected void ddlIdModuloRegistrar_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnlRegistra_ModalPopupExtender.Show();  
        ListaProcedimientoRegistrar();
        txtNroMensaje.Text = "";
    }
    protected void ListaProcedimiento()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        string sMensajeError = null;
        //ddlIdProcedimiento.Items.Clear();
        ddlIdProcedimientoLista.Items.Clear();
        ddlIdProcedimientoLista.ClearSelection();
        ddlIdProcedimientoLista.DataSource = ObjProcedimientos.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError);
        ddlIdProcedimientoLista.DataValueField = "IdProcedimiento";
        ddlIdProcedimientoLista.DataTextField = "Nombre";
        ddlIdProcedimientoLista.DataBind();
        //ddlIdProcedimientoLista.Items.Add(oItem);
        ddlIdProcedimientoLista.Items.Insert(0, new ListItem("Seleccione...", "0")); 
        ddlIdProcedimientoLista.SelectedValue = "0";




    }
    protected void ListaProcedimientoRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        string sMensajeError = null;
        ddlIdProcedimiento.Items.Clear();
        ddlIdProcedimiento.ClearSelection();       
        ddlIdProcedimiento.DataSource = ObjProcedimientos.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError);
        ddlIdProcedimiento.DataValueField = "IdProcedimiento";
        ddlIdProcedimiento.DataTextField = "Nombre";
        ddlIdProcedimiento.DataBind();
        ddlIdProcedimiento.Items.Insert(0, new ListItem("Seleccione...", "0")); 
        ddlIdProcedimiento.SelectedValue = "0";




    }
    protected void ddlIdProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnlRegistra_ModalPopupExtender.Show();  
        ObtieneNroMensaje();
     txtDescripcionMensajeError.Focus();

    }
        
        protected void ObtieneNroMensaje()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";
        string sSessionTrabajo = null;
        string sSNN = null;
        
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimiento.SelectedValue);
        string sMensajeError = null;
        DataTable dtDataTable = null;
        int NroMensaje=0;

        dtDataTable = ObjMensajeError.ObtieneNroMensaje(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError);
        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in dtDataTable.Rows)
            {
                NroMensaje=Convert.ToInt32(drDataRow["NroMensaje"]);   
            }
            
        }
        txtNroMensaje.Text = Convert.ToString(NroMensaje);

        
    }

        protected void ddlIdProcedimientoLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaMensajeError();
            btnInsertar.Visible = true;
        }
}