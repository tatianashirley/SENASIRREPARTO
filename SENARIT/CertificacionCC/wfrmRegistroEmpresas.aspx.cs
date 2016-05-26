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
using wcfCertificacionCC.Logica;
using wcfGeo.Logica;
using wcfWorkFlowN.Logica;

public partial class CertificacionCC_wfrmRegistroEmpresas : System.Web.UI.Page
{
    clsProcedimientoValidoManual ObjProcedimientoValidoManual = new clsProcedimientoValidoManual();
    clsEmpresa ObjEmpresa = new clsEmpresa();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CambiarInterfaz();
            pnlRegistroEmpresa.Visible = true;
            pnlBusqueda.Visible = false;
            gvDatosBusqueda.DataSource = null;
            gvDatosBusqueda.DataBind();

        }
    }
    
    #region INTERFAZ

    private void CambiarInterfaz()
    {


        AgregarJSAtributos(txtRUC,txtNombreEmpresa);
        AgregarJSAtributos(txtNombreEmpresa,txtSector);
        AgregarJSAtributos(txtSector,txtPatronal );
        AgregarJSAtributos(txtPatronal, chbSalarioConvenio);
        AgregarJSAtributos(chbSalarioConvenio,btnGuardar);

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;
            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");
            //controlActual.Attributes.Add("onFocus", "  JavaScript:this.style.backgroundColor='#ffff00'; SelectAll(this)");
            //controlActual.Attributes.Add("onBlur", "  JavaScript:this.style.backgroundColor='#ffffff'; return focusNext('" + ctrlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "', null)  ");

        }
    }
    #endregion
    protected void txtRUC_TextChanged(object sender, EventArgs e)
    {
        DescripcionRUC(txtRUC.Text);
    }
    private void DescripcionRUC(string sRUC)
    {
        DataTable tblDescripcionRUC = null;
        tblDescripcionRUC = ObjProcedimientoValidoManual.DescripcionRuc(sRUC);
        if (tblDescripcionRUC != null && tblDescripcionRUC.Rows.Count > 0)
        {
            lblError2.Text = tblDescripcionRUC.Rows[0]["NombreEmpresa"].ToString();
            lblError2.Visible = true;
            lblError1.Visible = true;
            lblError3.Visible = true;
            btnGuardar.Visible = false;
            txtRUC.Focus();
        }
        else
        {            
            lblError1.Visible = false;
            lblError2.Visible = false;
            lblError3.Visible = false;
            btnGuardar.Visible = true;
            txtNombreEmpresa.Focus();
            hfOperacion.Value = "I";
            chbEstado.Visible = false;
        }




    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {            
            
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = hfOperacion.Value;
            int iEstado;
            if (cOperacion == "I")
            {
                iEstado = 1;
                
            }
            else
            {
               
                if (chbEstado.Checked==true)
                {
                    iEstado = 1;
                }
                else
                {
                    iEstado = 0;
                }
            }

            string sMensajeError = null;
            string sRUC = txtRUC.Text;
            string sNombreEmpresa = txtNombreEmpresa.Text;
            string sSector = txtSector.Text;
            string sPatronal = txtPatronal.Text;
            int iValido = 0;
            if (chbSalarioConvenio.Checked==true)
            {
                 iValido=1;
            }
            else
            {
                 iValido=0;
            }
            if (ObjEmpresa.RegistraEmpresa( iIdConexion,  cOperacion,  sRUC, sNombreEmpresa, sSector, sPatronal, iValido,iEstado, ref  sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                CleanControl(this.Controls);
                lblRucBusqueda.Visible = false;
                txtRucBusqueda.Visible = false;
                lblSectorBusqueda.Visible = false;
                txtSectorBusqueda.Visible = false;
                lblEmpresaBusqueda.Visible = false;
                txtNombreEmpresaBusqueda.Visible = false;                

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
  

 
    protected void rblBusquedas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblBusquedas.SelectedValue == "1")
        {
            lblSectorBusqueda.Visible = true;
            txtSectorBusqueda.Visible = true;
            lblRucBusqueda.Visible = false;
            txtRucBusqueda.Visible = false;
            lblEmpresaBusqueda.Visible = false;
            txtNombreEmpresaBusqueda.Visible = false;
        }
        if (rblBusquedas.SelectedValue == "2")
        {
            lblEmpresaBusqueda.Visible = true;
            txtNombreEmpresaBusqueda.Visible = true;
            lblSectorBusqueda.Visible = false;
            txtSectorBusqueda.Visible = false;
            lblRucBusqueda.Visible = false;
            txtRucBusqueda.Visible = false;
        }
        if (rblBusquedas.SelectedValue == "3")
        {
            lblRucBusqueda.Visible = true;
            txtRucBusqueda.Visible = true;
            lblSectorBusqueda.Visible = false;
            txtSectorBusqueda.Visible = false;
            lblEmpresaBusqueda.Visible = false;
            txtNombreEmpresaBusqueda.Visible = false;
        }
    }
   
    protected void btn_busqueda_Click(object sender, EventArgs e)
    {
          
        
        string sOpcionBusqueda=Convert.ToString(rblBusquedas.SelectedValue);
        
        string sDatoBusqueda=null;
        if (sOpcionBusqueda == "1") //SECTOR
        {
             sDatoBusqueda=txtSectorBusqueda.Text;    
        }
        if (sOpcionBusqueda == "2") //NOMBRE DE EMPRESA
        {
             sDatoBusqueda=txtNombreEmpresaBusqueda.Text;    
        }
        if (sOpcionBusqueda == "3") //NUMERO DE RUC
        {
             sDatoBusqueda=txtRucBusqueda.Text; 
        }
        ViewState["sDatosBusqueda"] = sDatoBusqueda; ;
        ViewState["sOpcionBusqueda"] = sOpcionBusqueda;

        ListaBusqueda(sOpcionBusqueda, sDatoBusqueda);
        
        
    }
    protected void ListaBusqueda(string sOpcionBusqueda, string sDatoBusqueda)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "B";
        string sMensajeError = null;  
        DataTable tblBusqueda;
        tblBusqueda = ObjEmpresa.BuscaEmpresa(iIdConexion, cOperacion, sOpcionBusqueda, sDatoBusqueda, ref  sMensajeError);        
        
            gvDatosBusqueda.DataSource = tblBusqueda;
            gvDatosBusqueda.DataBind();
        
    }
    protected void gvDatosBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatosBusqueda.PageIndex = e.NewPageIndex;

        ListaBusqueda((string)ViewState["sOpcionBusqueda"], (string)ViewState["sDatosBusqueda"]);

    }

    protected void gvDatosBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            

        }
    }
    protected void btnBusquedaEmpresa_Click(object sender, ImageClickEventArgs e)
    {
        
        pnlRegistroEmpresa.Visible = false;
        pnlBusqueda.Visible = true;
        CleanControl(this.Controls);
        gvDatosBusqueda.DataSource = null;
        gvDatosBusqueda.DataBind();


        
    }


    protected void btn_limpiar_celdas_Click(object sender, EventArgs e)
    {
        CleanControl(this.Controls);
    }

    protected void btn_borrar_resultados_Click(object sender, EventArgs e)
    {
        gvDatosBusqueda.DataSource = null;
        gvDatosBusqueda.DataBind();
    }
    protected void btnRegistraEmpresa_Click(object sender, ImageClickEventArgs e)
    {
        CleanControl(this.Controls);
        pnlRegistroEmpresa.Visible = true;
        pnlBusqueda.Visible = false;
        chbEstado.Visible = false;
        gvDatosBusqueda.DataSource = null;
        gvDatosBusqueda.DataBind();
        btnGuardar.Visible = false;
        txtRUC.AutoPostBack = true;
        txtRUC.Enabled = true;

    }
    protected void gvDatosBusqueda_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            try
            {

                pnlRegistroEmpresa.Visible = true;
                pnlBusqueda.Visible = false;
                txtRUC.AutoPostBack = false;
                txtRUC.Enabled = false;
                int Index = Convert.ToInt32(e.CommandArgument);
                //RUC,NombreEmpresa,NroPatronal,IdSector,Sector,SalarioConvenio,Estado
                txtRUC.Text=Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["RUC"]);
                txtNombreEmpresa.Text = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["NombreEmpresa"]);
                txtSector.Text = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["Sector"]);
                txtPatronal.Text = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["NroPatronal"]);
                string sSalarioConvenio = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["SalarioConvenio"]);
                string sEstado = Convert.ToString(gvDatosBusqueda.DataKeys[Index].Values["Estado"]);
                chbEstado.Visible = true;
                if (sSalarioConvenio == "Salario Convenio")
                {
                    chbSalarioConvenio.Checked = true;
                    
                }
                else
                {
                    chbSalarioConvenio.Checked = false;
                    
                }
                if (sEstado == "Activo")
                {
                    chbEstado.Checked = true;
                }
                else
                {
                    chbEstado.Checked = false;
                }
                if (txtSector.Text == "COOPERATIVAS")
                {
                    chbSalarioConvenio.Visible = true;
                }
                else
                {
                    chbSalarioConvenio.Visible = false;
                }
                hfOperacion.Value = "U";
                btnGuardar.Visible = true;
                
                
                
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        
    }
    protected void txtSector_TextChanged(object sender, EventArgs e)
    {
        if (txtSector.Text != "COOPERATIVAS")
        {
            chbSalarioConvenio.Visible = false;
            chbSalarioConvenio.Checked = false;
        }
        else
        {
            chbSalarioConvenio.Visible = true;
            chbSalarioConvenio.Checked = true;
        }
    }
}