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




public partial class Seguridad_wfrmArea : System.Web.UI.Page
{
   clsArea ObjArea = new clsArea();
   clsSeguridad obj = new clsSeguridad();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaArea.Visible = true;            
            pnlRegistraArea.Visible = false;
            
            gvDatos.Columns[5].Visible = false;
            gvDatos.Columns[1].Visible = false;
            CambiarInterfaz();
            Oficina();

        }
       
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtArea, ddlIdOficinaReg);
        AgregarJSAtributos(txtResponsable, chbEstado);

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void Oficina()
    {
        
        ddlIdOficina.DataSource = obj.ListaOficinas();
        ddlIdOficina.Items.Clear();
        ddlIdOficina.ClearSelection();        
        ddlIdOficina.DataValueField = "IdOficina";
        ddlIdOficina.DataTextField = "Nombre";
        ddlIdOficina.DataBind();
        ddlIdOficina.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdOficina.SelectedValue = "0";

    }
    protected void OficinaReg()
    {

        ddlIdOficinaReg.DataSource = obj.ListaOficinas();
        ddlIdOficinaReg.Items.Clear();
        ddlIdOficinaReg.ClearSelection();
        ddlIdOficinaReg.DataValueField = "IdOficina";
        ddlIdOficinaReg.DataTextField = "Nombre";
        ddlIdOficinaReg.DataBind();
        ddlIdOficinaReg.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdOficinaReg.SelectedValue = "0";

    }
   
    protected void ListaArea(int iIdOficina)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        int iNivelError=0;
        gvDatos.DataSource = ObjArea.ListaArea(iIdConexion,cOperacion,iIdOficina,ref iNivelError);
        gvDatos.DataBind();

        //if (iNivelError == 2)
        //{
        //    string Error = "No existen datos que correspondan al criterio especificado";
        //    Master.MensajeWarning(Error);
        //}
        //else
        //{
        //    string Error = null;
        //    Master.MensajeWarning(Error);
        //}
    }
    protected void ListaAreaReg(int iIdOficina)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        int iNivelError = 0;        
        ddlArea.DataSource= ObjArea.ListaArea(iIdConexion, cOperacion, iIdOficina, ref iNivelError);
        ddlArea.Items.Clear();
        ddlArea.ClearSelection();
        ddlArea.DataValueField = "IdArea";
        ddlArea.DataTextField = "Descripcion";
        ddlArea.DataBind();
        ddlArea.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlArea.SelectedValue = "0";
        this.pnlRegistraArea_ModalPopupExtender.Show();
    }


    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        Label1.Text = "Insertar Area";
        OficinaReg();
        int iIdOficina = Convert.ToInt32(ddlIdOficinaReg.SelectedValue);        
        txtArea.Text = "";
        txtIdArea.Text = "";
        txtResponsable.Text = "";
        pnlListaArea.Visible = false;
        pnlRegistraArea.Visible = true;
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;
        ddlIdOficinaReg.Visible = true;
        ddlArea.Visible = true;
        lblOficina.Visible = true;
        lblAreaSuperior.Visible = true;
        txtIdOficina.Visible = false;
        txtIdArea.Visible = false;
        this.pnlRegistraArea_ModalPopupExtender.Show();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaArea.Visible = true;
        pnlRegistraArea.Visible = false;
        btnActualizar.Visible = false;
        btnAdicionar.Visible = false;
        txtArea.Text = "";
        txtResponsable.Text = "";
        txtIdArea.Text = "";

        
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {
            Label1.Text = "Editar Area";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";
            int iIdOficina = Convert.ToInt32(ddlIdOficina.SelectedValue);
            int iIdArea=Convert.ToInt32(e.CommandArgument.ToString());
            pnlRegistraArea.Visible = true;
            pnlListaArea.Visible=false;
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdArea.Visible = false;
            this.pnlRegistraArea_ModalPopupExtender.Show();

            DataTable dtDataTable = null;
            
            string sDetalleArea =null;            
            int iIdAreaSuperior =0;
            string sResponsable = null;
            int iIdEstado=0;
            int iNivelError =0;

             dtDataTable = ObjArea.ListaAreaxIdOficina(iIdConexion, cOperacion, iIdArea, iIdOficina, ref iNivelError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    iIdOficina=Convert.ToInt32(drDataRow["IdOficina"]);
                    iIdArea=Convert.ToInt32(drDataRow["IdArea"]);
                    sDetalleArea = Convert.ToString(drDataRow["Descripcion"]);
                    iIdAreaSuperior = Convert.ToInt32(drDataRow["IdAreaSuperior"]);
                    sResponsable=Convert.ToString(drDataRow["Responsable"]);
                    iIdEstado = Convert.ToInt32(drDataRow["IdEstado"]);                                        
                }
                txtArea.Text = sDetalleArea;
                txtIdArea.Text = Convert.ToString(iIdArea);
                txtIdOficina.Text = Convert.ToString(iIdOficina);                
                ddlIdOficinaReg.Visible = false;
                ddlArea.Visible = false;
                lblOficina.Visible = false;
                lblAreaSuperior.Visible = false;
                txtResponsable.Text = sResponsable;
                

                if (iIdEstado == 31)
                {
                    chbEstado.Checked = true;
                }
                else 
                {
                    chbEstado.Checked = false;
                }
            
            }

        }
       



    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        int iIdOficina = Convert.ToInt32(ddlIdOficina.SelectedValue);
        ListaArea(iIdOficina);
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {

        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";

        String sMensajeError = null;       
        
            string sDetalleArea = txtArea.Text;
            int iIdOficina = Convert.ToInt32(ddlIdOficinaReg.SelectedValue);
            int iIdAreaSuperior = Convert.ToInt32(ddlArea.SelectedValue);
            string sResponsable = txtResponsable.Text;
            int iIdEstado=0;

            if (chbEstado.Checked == true)
            {
                iIdEstado = 31;
            }
            if (chbEstado.Checked == false)
            {
                iIdEstado = 32;
            }

            if (ObjArea.AreaAdicionar(iIdConexion, cOperacion, sDetalleArea,iIdOficina,iIdAreaSuperior,sResponsable,iIdEstado, ref sMensajeError))
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
            
            pnlListaArea.Visible = true;
            pnlRegistraArea.Visible = false;
            
            ListaArea(iIdOficina);
            ddlIdOficina.SelectedValue = Convert.ToString(iIdOficina);
            

        
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";

        String sMensajeError = null;
        try
        {
            int iIdOficina = Convert.ToInt32(txtIdOficina.Text);
            int iIdArea = Convert.ToInt32(txtIdArea.Text);
            string sDescripcionArea = txtArea.Text;
            string sResponsable = txtResponsable.Text;
            int iIdEstado=0; 
            if (chbEstado.Checked == true)
            {
                iIdEstado = 31;
            }
            if (chbEstado.Checked == false)
            {
                iIdEstado = 32;
            }
            


            if (ObjArea.AreaModificar(iIdConexion, cOperacion, iIdOficina,iIdArea,sDescripcionArea,iIdEstado, ref sMensajeError))
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
            pnlListaArea.Visible = true;
            pnlRegistraArea.Visible = false;
            txtIdArea.Visible = false;
            txtIdOficina.Visible = false;
        
        //    ListaArea(sBAreaSuperior, sBArea);
            btnActualizar.Visible = false;
            ListaArea(iIdOficina);
            ddlIdOficina.SelectedValue = Convert.ToString(iIdOficina);


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

    protected void ddlIdOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdOficina = Convert.ToInt32(ddlIdOficina.SelectedValue);
        ListaArea(iIdOficina);
    }
    protected void ddlIdOficinaReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdOficina = Convert.ToInt32(ddlIdOficinaReg.SelectedValue);
        ListaAreaReg(iIdOficina);
        ddlArea.Focus();
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtArea.Focus();
        this.pnlRegistraArea_ModalPopupExtender.Show();
    }
}