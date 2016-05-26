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




public partial class Seguridad_wfrmInsertarListarModulo : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   MasterPage objj = new MasterPage();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            Panel1.Visible = true;
            //Panel2.Visible = false;
            ListaModulos();
            pnlRegistroModulo.Visible = false;
            gvDatos.Columns[1].Visible = false;
            gvDatos.Columns[4].Visible = false;
            CambiarInterfaz();

        }
       
     }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtAbreviatura, txtDetalleModulo);
        AgregarJSAtributos(txtDetalleModulo, rblTipo);
        
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
    protected void ListaModulos()
    {
        int iIdConexion =(int)Session["IdConexion"];
        string sOperacion = "Q";        
        gvDatos.DataSource = obj.ListaModulos(iIdConexion,sOperacion);
        gvDatos.DataBind();

    }
    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        ListaModulos();
    }
    protected void btnInsertarModulo_Click(object sender, EventArgs e)
    {
        //Panel1.Visible = false; 
        Label3.Text = "Nuevo modulo o servicio";
        this.pnlRegistroModulo_ModalPopupExtender.Show();
        pnlRegistroModulo.Visible = true;
        chbEstado.Visible = false;
        btnAceptar.Visible = true;
        rblTipo.Visible = true;
        lblTipo.Visible = true;
        btnActualizar.Visible = false;

        //LIMPIA textbox
        txtAbreviatura.Text = "";
        txtDetalleModulo.Text = "";
        txtIdModulo.Visible = false;
        
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        txtAbreviatura.Text = ".";
        txtDetalleModulo.Text = ".";
        //Panel1.Visible = true;
        chbEstado.Visible = false;
        pnlRegistroModulo.Visible = false;
        btnActualizar.Visible = false;
        txtIdModulo.Visible = false;
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        
        String sMensajeError = null;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        try
        {
            String DetalleModulo = txtDetalleModulo.Text;
            String Abreviatura = txtAbreviatura.Text;
            int Tipo = Convert.ToInt32(rblTipo.SelectedValue);
            if (obj.InsertarModulo(iIdConexion, cOperacion, DetalleModulo, Abreviatura, Tipo, ref sMensajeError))
            {
                string Msg = "Se realizo la Operacion con exito";
                Master.MensajeOk(Msg);

            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = sMensajeError;
                Master.MensajeError(Error, DetalleError);
            }           

              
                Panel1.Visible = true;
                pnlRegistroModulo.Visible = false;
                chbEstado.Visible = false;
                ListaModulos();

                rblTipo.Visible = false;
                lblTipo.Visible = false;
            

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

        

    }
   
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {
            // Response.Redirect("FBolCensalAddV2.aspx?idv=" + Security.encryptQueryString(e.CommandArgument.ToString()) + "");
            int iIdModulo =Convert.ToInt32(e.CommandArgument.ToString());
            //Panel1.Visible = false;
            Label3.Text = "Editar modulo o servicio";
            pnlRegistroModulo.Visible = true;
            chbEstado.Visible = true;
            btnActualizar.Visible = true;
            btnAceptar.Visible = false;
            txtIdModulo.Visible = false;

            DataTable dtDataTable = null;
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";
            
            string DescripcionModulo=null;
            string SiglaModulo=null;
            int IdEstado=0;

            dtDataTable = obj.ListaModulosconParametro(iIdConexion,cOperacion,iIdModulo);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    
                    DescripcionModulo = Convert.ToString(drDataRow["DescripcionModulo"]);
                    SiglaModulo = Convert.ToString(drDataRow["SiglaModulo"]);
                    IdEstado = Convert.ToInt32(drDataRow["IdEstado"]);
                }
                txtDetalleModulo.Text = DescripcionModulo;
                txtAbreviatura.Text = SiglaModulo;
                txtIdModulo.Text =Convert.ToString(iIdModulo);
                if (IdEstado == 31)
                {
                    chbEstado.Checked = true;
                }
                else
                {
                    chbEstado.Checked = false;
                }
            }
            this.pnlRegistroModulo_ModalPopupExtender.Show();
        }
    }


    


    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        
        int Semaforo = 0;
        String sMensajeError = null;
        try
        {
            int IdModulo =Convert.ToInt32(txtIdModulo.Text);
            int iIdConexion =(int)Session["IdConexion"];
            string cOperacion = "U";
            String DetalleModulo = txtDetalleModulo.Text;
            String Abreviatura = txtAbreviatura.Text;
            
            int Estado;
            if (chbEstado.Checked == true)
            {
                Estado = 31;
            }
            else
            {
                Estado = 32;
            }

            if(obj.ActualizarModulo(iIdConexion, cOperacion, IdModulo, DetalleModulo, Abreviatura, Estado, ref sMensajeError))
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
            Panel1.Visible = true;
            pnlRegistroModulo.Visible = false;
            chbEstado.Visible = false;
            txtIdModulo.Visible = false;
            ListaModulos();
            btnActualizar.Visible = false;


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
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
        }
         if (this.gvDatos.Rows.Count > 0)
             {
                 gvDatos.UseAccessibleHeader = true;
                 gvDatos.HeaderRow.TableSection = TableRowSection.TableHeader;
                 //gvDatosBoleta.FooterRow.TableSection = TableRowSection.TableFooter;
             }
        
    }
}