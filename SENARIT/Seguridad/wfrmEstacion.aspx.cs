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




public partial class Seguridad_wfrmEstacion : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   clsEstacion ObjEstacion = new clsEstacion();
   clsOficinas ObjOficina = new clsOficinas();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaEstacion.Visible = true;
            ListaOficina();
            //ListaEstacion();
            
            pnlRegistraEstacion.Visible = false;
            //ListaEstacionPadre();
            CambiarInterfaz();
        }
        //else
        //{
        //    ListaEstacion();            
        //}
        
    }
    private void CambiarInterfaz()
    {
        
        AgregarJSAtributos(txtNombreEstacion, txtIp);
        AgregarJSAtributos(txtIp, txtMac);
        AgregarJSAtributos(txtMac, rblIdEstado);
        
        
        

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void ddlIdOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaEstacion();
    }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
    }
    protected void ListaEstacion()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";      
        int iIdOficina = Convert.ToInt32(ddlIdOficina.SelectedValue);
        string sMensajeError = null;
        gvDatos.DataSource = ObjEstacion.ListaEstacion(iIdConexion, cOperacion,iIdOficina, ref sMensajeError);
        gvDatos.DataBind();
    }
    protected void ListaOficina()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        ddlIdOficina.DataSource = ObjOficina.OficinaLista(iIdConexion, cOperacion,ref sMensajeError);
        ddlIdOficina.DataValueField = "IdOficina";
        ddlIdOficina.DataTextField = "DescripcionOficina";
        ddlIdOficina.DataBind();
    }
 
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        Label1.Text = "Nueva Estacion";
        ddlIdOficinaRegistrar.Enabled = true;
        
        //pnlListaEstacion.Visible = false;
        this.pnlRegistra_ModalPopupExtender.Show();  
        pnlRegistraEstacion.Visible = true;
        
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;

        ListaOficinaRegistrar();
        txtNombreEstacion.Text = "";
        txtIdEstacion.Visible = false;

    }
    protected void ListaOficinaRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        ddlIdOficinaRegistrar.Items.Clear();
        ddlIdOficinaRegistrar.DataSource = ObjOficina.OficinaLista(iIdConexion, cOperacion, ref sMensajeError);
        ddlIdOficinaRegistrar.DataValueField = "IdOficina";
        ddlIdOficinaRegistrar.DataTextField = "DescripcionOficina";
        ddlIdOficinaRegistrar.DataBind();
        ddlIdOficinaRegistrar.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdOficinaRegistrar.SelectedValue = "0";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaEstacion.Visible = true;
        pnlRegistraEstacion.Visible = false;
        btnActualizar.Visible = false;
        txtIdEstacion.Visible = false;
        txtNombreEstacion.Text = "";
        txtIp.Text = "";
        txtMac.Text = "";   
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            Label1.Text = "Edita Estacion";
            ListaOficinaRegistrar();                       
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";
            
            int iIdEstacion = Convert.ToInt32(e.CommandArgument.ToString());
            pnlRegistraEstacion.Visible = true;
            //pnlListaEstacion.Visible = false;
            this.pnlRegistra_ModalPopupExtender.Show();  
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdEstacion.Visible = true;
            DataTable dtDataTable = null;
            string sMensajeError = null;
            int IdEstado;

            dtDataTable = ObjEstacion.ListaEstacionPorId(iIdConexion, cOperacion, iIdEstacion, ref sMensajeError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    txtIdEstacion.Text= Convert.ToString(drDataRow["IdEstacion"]);
                    txtNombreEstacion.Text= Convert.ToString(drDataRow["Nombre"]);
                    txtIp.Text = Convert.ToString(drDataRow["IPAddress"]);
                    txtMac.Text = Convert.ToString(drDataRow["MACAddress"]);                    
                    ddlIdOficinaRegistrar.SelectedValue = Convert.ToString(drDataRow["IdOficina"]);
                    if (Convert.ToInt32(drDataRow["IdEstado"]) == 31)
                    {
                        rblIdEstado.Items[0].Enabled = true;
                    }
                    else
                    {
                        rblIdEstado.Items[1].Enabled = true;
                    }
                }

            }
        }
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        ListaEstacion();
    }
    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        
        int iIdOficina = Convert.ToInt32(ddlIdOficinaRegistrar.SelectedValue);
        string sEstacion = txtNombreEstacion.Text;
        string sIp = txtIp.Text;
        string sMac = txtMac.Text;
        int iIdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
        string sMensajeError=null;
        if (ObjEstacion.EstacionAdiciona(iIdConexion, cOperacion, sEstacion,sIp,sMac,iIdOficina, iIdEstado, ref sMensajeError))
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
        pnlListaEstacion.Visible = true;
        pnlRegistraEstacion.Visible = false;
        txtNombreEstacion.Text = "";
        txtIp.Text = "";
        txtMac.Text = "";                
        
        ListaEstacion();
       
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        int iIdEstacion =Convert.ToInt32(txtIdEstacion.Text);
        string sEstacion = txtNombreEstacion.Text;
        string sIp = txtIp.Text;
        string sMac = txtMac.Text;
        int iIdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
        string sMensajeError = null;
        int iIdOficina = Convert.ToInt32(ddlIdOficinaRegistrar.SelectedValue);
        if (ObjEstacion.EstacionModifica(iIdConexion, cOperacion, iIdEstacion, sEstacion, sIp, sMac, iIdOficina,iIdEstado, ref sMensajeError))
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
        pnlListaEstacion.Visible = true;
        pnlRegistraEstacion.Visible = false;
        txtNombreEstacion.Text = "";
        txtMac.Text = "";
        txtIp.Text = "";
        txtIdEstacion.Text = "";
        txtIdEstacion.Visible = false;
        btnActualizar.Visible = false;        
        ListaEstacion();

        
        
    }


    protected void ddlIdOficinaRegistrar_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtNombreEstacion.Focus();
        this.pnlRegistra_ModalPopupExtender.Show();  
    }
}