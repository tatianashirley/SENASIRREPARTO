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




public partial class Seguridad_wfrmProcedimiento : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   clsProcedimientos ObjProcedimiento = new clsProcedimientos();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaProcedimiento.Visible = true;
            ListaModulo();
            //ListaProcedimiento();
            
            pnlRegistraProcedimiento.Visible = false;
            //ListaProcedimientoPadre();
            CambiarInterfaz();
        }
        //else
        //{
        //    ListaProcedimiento();            
        //}
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtNroProcedimiento, txtNombreProcedimiento);
        AgregarJSAtributos(txtNombreProcedimiento, txtScript);
        AgregarJSAtributos(txtScript, txtDescripcion);
        AgregarJSAtributos(txtDescripcion, rblIdEstado);
        

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
        ListaProcedimiento();
    }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
    }
    protected void ListaProcedimiento()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        string sMensajeError = null;
        gvDatos.DataSource = ObjProcedimiento.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError);
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
        Label1.Text = "Nuevo Procedimiento";
        rblIdEstado.Items[0].Selected=true;
        ddlIdModuloRegistrar.Enabled = true;
        //pnlListaProcedimiento.Visible = false;
        this.pnlRegistra_ModalPopupExtender.Show();  
        pnlRegistraProcedimiento.Visible = true;
        
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;

        ListaModuloRegistrar();
        txtDescripcion.Text = "";
        txtIdProcedimiento.Text = "";
        txtNombreProcedimiento.Text = "";
        txtScript.Text = "";
        txtIdProcedimiento.Visible = false;

        txtNroProcedimiento.Visible = true;
        lblNroProcedimiento.Visible = true;
        txtNroProcedimiento.Text = "";

        
        
        
       
    }
    protected void ListaModuloRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        ddlIdModuloRegistrar.Items.Clear();
        ddlIdModuloRegistrar.DataSource = obj.ListaModulos(iIdConexion, cOperacion);
        ddlIdModuloRegistrar.DataValueField = "IdModulo";
        ddlIdModuloRegistrar.DataTextField = "DescripcionModulo";
        ddlIdModuloRegistrar.DataBind();
        ddlIdModuloRegistrar.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdModuloRegistrar.SelectedValue = "0";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(2000); 
        pnlListaProcedimiento.Visible = true;
        pnlRegistraProcedimiento.Visible = false;
        btnActualizar.Visible = false;
        txtIdProcedimiento.Visible = false;
        txtNombreProcedimiento.Text = "";
        txtDescripcion.Text = "";
        txtScript.Text = "";
        rblIdEstado.ClearSelection();
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            Label1.Text = "Edita Procedimiento";
            ddlIdModuloRegistrar.Enabled = false;
            ListaModuloRegistrar();
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";
            
            int iIdProcedimiento = Convert.ToInt32(e.CommandArgument.ToString());
            pnlRegistraProcedimiento.Visible = true;
            //pnlListaProcedimiento.Visible = false;
            this.pnlRegistra_ModalPopupExtender.Show();  
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdProcedimiento.Visible = false;


            DataTable dtDataTable = null;
            string sMensajeError = null;
            int IdEstado;

            dtDataTable = ObjProcedimiento.ListaProcedimientoPorId(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    txtIdProcedimiento.Text = Convert.ToString(drDataRow["IdProcedimiento"]);
                    txtNroProcedimiento.Text = Convert.ToString(drDataRow["IdProcedimiento"]);
                    txtNombreProcedimiento.Text = Convert.ToString(drDataRow["Nombre"]);
                    txtScript.Text = Convert.ToString(drDataRow["Script"]);
                    txtDescripcion.Text = Convert.ToString(drDataRow["Descripcion"]);
                    ddlIdModuloRegistrar.SelectedValue = Convert.ToString(drDataRow["IdModulo"]);

                    if (Convert.ToInt32(drDataRow["IdEstado"]) == 31)
                    {
                        //rblIdEstado.Items[0].Enabled = true;
                        rblIdEstado.Items[0].Selected = true;
                        
                    }
                    else
                    {
                        //rblIdEstado.Items[1].Enabled = true;
                        rblIdEstado.Items[1].Selected = true;
                    }
                }
            }
        }




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

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        ListaProcedimiento();
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(txtNroProcedimiento.Text);
        string sNombreProcedimiento = txtNombreProcedimiento.Text;
        string sScript = txtScript.Text;
        string sDescripcion = txtDescripcion.Text;
        int iIdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
        string sMensajeError=null;
        if (ObjProcedimiento.ProcedimientoAdiciona(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdProcedimiento,sNombreProcedimiento, sScript, sDescripcion, iIdModulo, iIdEstado, ref sMensajeError))
        {
            string msg="La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        pnlListaProcedimiento.Visible = true;
        pnlRegistraProcedimiento.Visible = false;
        txtNombreProcedimiento.Text = "";
        txtDescripcion.Text = "";
        txtScript.Text = "";
        txtNroProcedimiento.Visible = false;
        lblNroProcedimiento.Visible = false;
        txtNroProcedimiento.Text = "";
        ListaProcedimiento();
        rblIdEstado.ClearSelection();
       
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        int iIdProcedimiento =Convert.ToInt32(txtIdProcedimiento.Text);
        string sNombreProcedimiento = txtNombreProcedimiento.Text;
        string sScript = txtScript.Text;
        string sDescripcion = txtDescripcion.Text;
        int iIdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
        string sMensajeError = null;
        if (ObjProcedimiento.ProcedimientoModifica(iIdConexion, cOperacion,iIdProcedimiento, sNombreProcedimiento, sScript, sDescripcion, iIdEstado, ref sMensajeError))
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
        pnlListaProcedimiento.Visible = true;
        pnlRegistraProcedimiento.Visible = false;
        txtNombreProcedimiento.Text = "";
        txtDescripcion.Text = "";
        txtScript.Text = "";
        btnActualizar.Visible = false;
        txtIdProcedimiento.Visible=false;
        ListaProcedimiento();
        rblIdEstado.ClearSelection();

        
        
    }

    protected void ddlIdModuloRegistrar_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pnlRegistra_ModalPopupExtender.Show();  
        ObtieneNroProcedimiento();
        txtNombreProcedimiento.Focus();
    }
    protected void ObtieneNroProcedimiento()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        string sMensajeError = null;
        
        DataTable dtDataTable = null;
        int NroProcedimiento = 0;

        dtDataTable = ObjProcedimiento.ObtieneNroProcedimiento(iIdConexion, cOperacion, iIdModulo, ref sMensajeError);
        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in dtDataTable.Rows)
            {
                NroProcedimiento = Convert.ToInt32(drDataRow["NroProcedimiento"]);
            }

        }
        txtNroProcedimiento.Text = Convert.ToString(NroProcedimiento);


    }
}