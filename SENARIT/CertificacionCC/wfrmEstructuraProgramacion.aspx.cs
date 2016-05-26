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
using wcfCertificacionCC.Logica;
using wcfGeo.Logica;



using System.Drawing;
public partial class CertificacionCC_wfrmEstructuraProgramacion : System.Web.UI.Page
{
  
  clsEstructuraProgramacion ObjEstructuraProgramacion = new clsEstructuraProgramacion();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String TituloSistema="Certificacion CC";
            Master.TituloSistema(TituloSistema);
            lblTituloSistema.Text = TituloSistema;
            lblSubTitulo.Text = "Estructura Programacion";            
            ListaEstructuraProgramacion();
            CambiarInterfaz();
            pnlConsultaEstructuraProgramacion.Visible = true;
            pnlRegistroDetalleEstructura.Visible = false;
            pnlRegistroEstructura.Visible = false;
        }
        
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtDescripcion, btnRegistraPanel1);
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void ListaEstructuraProgramacion()
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "Q";

            DataTable EstructuraProgramacion;
            EstructuraProgramacion = ObjEstructuraProgramacion.ConsultaEstructuraProgramacion(iIdConexion, cOperacion, ref sMensajeError);

            if (EstructuraProgramacion != null)
            {
                if (EstructuraProgramacion.Rows.Count > 0)
                {
                    gvEstructura.DataSource = EstructuraProgramacion;
                    gvEstructura.DataBind();

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = Convert.ToString(sMensajeError);
                    Master.MensajeError(Error, DetalleError);
                }
            }

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
        
    }
    protected void gvEstructura_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            txtIdEstructuraAct.Visible = true;
            pnlConsultaEstructuraProgramacion.Visible = false;
            pnlRegistroEstructura.Visible = true;            
            btnActualizarPanel1.Visible = true;
            btnCancelar.Visible = true;
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";

            int iIdEstructura = Convert.ToInt32(e.CommandArgument.ToString());
            
            //this.pnlRegistra_ModalPopupExtender.Show();  
            
            DataTable dtDataTable = null;
            string sMensajeError = null;
            chbEstado.Visible = true;


            dtDataTable = ObjEstructuraProgramacion.ProgramacionEstructuraListaPorId(iIdConexion, cOperacion, iIdEstructura, ref sMensajeError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    txtDescripcion.Text =Convert.ToString(drDataRow["Descripcion"]);
                    txtIdEstructuraAct.Text = Convert.ToString(drDataRow["IdEstructura"]);
                    
                    if (Convert.ToInt32(drDataRow["EstadoEstructura"]) ==1)
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

        if (e.CommandName == "cmdEditarEstructuraDetalle")
        {
          
            pnlConsultaEstructuraProgramacion.Visible = false;
            pnlRegistroDetalleEstructura.Visible = true;
            int iIdEstructura = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["iIdEstructura"] = iIdEstructura;
            txtIdEstructura.Text = Convert.ToString(iIdEstructura);
            ListaRolSuperior();
            ListaRol();
            ListaGvEstructuraDetalle((int)ViewState["iIdEstructura"]);
            
            
            
        }



    }

    protected void gvEstructura_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEstructura.PageIndex = e.NewPageIndex;
        ListaEstructuraProgramacion();
        
    }

    protected void ddlIdModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
       // ListaProcedimiento();
    }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
    }
  
 
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        txtIdEstructuraAct.Visible = false;
        
        txtDescripcion.Focus();
        pnlConsultaEstructuraProgramacion.Visible = false;
        pnlRegistroEstructura.Visible = true;
        btnRegistraPanel1.Visible = true;
        btnLimpiar.Visible = true;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtDescripcion.Text = "";
    }
    protected void btnRegistraPanel1_Click(object sender, EventArgs e)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            string sDescripcion = txtDescripcion.Text;
            string sMensajeError = null;
            int iIdEstructura = 0;
            if (ObjEstructuraProgramacion.EstructuraProgramacionAdiciona(iIdConexion, cOperacion, sDescripcion, ref sMensajeError,ref iIdEstructura))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                pnlRegistroEstructura.Visible = false;
                pnlRegistroDetalleEstructura.Visible = true;
                txtIdEstructura.Text =Convert.ToString(iIdEstructura);
                ViewState["iIdEstructura"] = iIdEstructura;
                ListaRolSuperior();
                ListaRol();
                btnRegistraPanel1.Visible = false;

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
    protected void ListaRolSuperior()
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "Q";
            string cLista = "S";
            int iIdModulo = 35; //Codigo del modulo de certificacion
            int iIdRolSuperior = 0;
            DataTable RolSuperior;
            RolSuperior = ObjEstructuraProgramacion.ListaRolSuperior(iIdConexion, cOperacion, iIdModulo,iIdRolSuperior,cLista, ref sMensajeError);

            if (RolSuperior.Rows.Count > 0)
            {
                ddlIdRolSuperior.DataSource = RolSuperior;
                ddlIdRolSuperior.DataValueField = "IdRol";
                ddlIdRolSuperior.DataTextField = "Descripcion";
                ddlIdRolSuperior.DataBind();
                ddlIdRolSuperior.Items.Insert(0, new ListItem("Seleccione....", "0"));
                ddlIdRolSuperior.Items.Insert(1, new ListItem("Ninguno", "0"));
                ddlIdRolSuperior.SelectedIndex=1;
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
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
    protected void ddlIdRolSuperior_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaRol();
    }
    protected void ListaRol()
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "Q";
            string cLista = null;
            int iIdModulo = 35; //Codigo del modulo de certificacion
            int iIdRolSuperior = Convert.ToInt32(ddlIdRolSuperior.SelectedValue);
           
            DataTable ListaRoles;
            ListaRoles = ObjEstructuraProgramacion.ListaRolSuperior(iIdConexion, cOperacion, iIdModulo, iIdRolSuperior, cLista, ref sMensajeError);

            if (ListaRoles.Rows.Count > 0)
            {
                ddlIdRol.DataSource = ListaRoles;
                ddlIdRol.DataValueField = "IdRol";
                ddlIdRol.DataTextField = "Descripcion";
                ddlIdRol.DataBind();
                ddlIdRol.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlIdRol.SelectedValue = "0";
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
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

    protected void btnRegistraPnl1_Click(object sender, EventArgs e)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            int iIdEstructura =(int)ViewState["iIdEstructura"];
            int iIdRolSuperior = Convert.ToInt32(ddlIdRolSuperior.SelectedValue);
            int iIdRol = Convert.ToInt32(ddlIdRol.SelectedValue);
            int iCantidad = Convert.ToInt32(txtCantidadUsuarios.Text);
            string sMensajeError = null;            
            if (ObjEstructuraProgramacion.EstructuraDetalleAdiciona(iIdConexion, cOperacion,iIdEstructura,iIdRolSuperior,iIdRol,iCantidad,ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                pnlRegistroEstructura.Visible = false;
                pnlRegistroDetalleEstructura.Visible = true;
                txtIdEstructura.Text = Convert.ToString(iIdEstructura);
                ListaRolSuperior();
                ListaRol();
                ListaGvEstructuraDetalle((int)ViewState["iIdEstructura"]);
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
    protected void btnActualizarPanel1_Click(object sender, EventArgs e)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "U";
            string sDescripcion = txtDescripcion.Text;
            string sMensajeError = null;
            int iEstado;
            int iIdEstructura = Convert.ToInt32(txtIdEstructuraAct.Text);
            if (chbEstado.Checked == true)
            {
                iEstado = 1;
            }
            else
            {
                iEstado = 0;
            }
            if (ObjEstructuraProgramacion.EstructuraProgramacionModifica(iIdConexion, cOperacion, iIdEstructura,sDescripcion,iEstado, ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                pnlConsultaEstructuraProgramacion.Visible = true;
                pnlRegistroEstructura.Visible = false;
                pnlRegistroDetalleEstructura.Visible = false;
                ListaEstructuraProgramacion();
                

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
    protected void btnLimpiarPnl2_Click(object sender, EventArgs e)
    {
        ddlIdRolSuperior.ClearSelection();       
        ddlIdRol.ClearSelection();
        txtCantidadUsuarios.Text = "";
       
    }
    protected void chbSuperior_CheckedChanged(object sender, EventArgs e)
    {
        if (chbSuperior.Checked == false)
        {
            ddlIdRolSuperior.Visible = true;
            lblRolSuperior.Visible = true;
        }
        else
        {
            ddlIdRolSuperior.Visible = false;
            lblRolSuperior.Visible = false;
        }
    }
    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CertificacionCC/wfrmEstructuraProgramacion.aspx");
    }
    protected void ListaGvEstructuraDetalle(int iIdEstructura)
    {
        string sMensajeError = "";
        try
        {
        
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "Q";

            DataTable EstructuraDetalle;
            EstructuraDetalle = ObjEstructuraProgramacion.ConsultaEstructuraDetalle(iIdConexion, cOperacion, iIdEstructura,ref sMensajeError);

            //if (EstructuraDetalle!=null )
            //{
                gvEstructuraDetalle.DataSource = EstructuraDetalle;
                gvEstructuraDetalle.DataBind();

            //}
            //else
            //{
            //    string Error = "Error al realizar la operación";
            //    string DetalleError = Convert.ToString(sMensajeError);
            //    Master.MensajeError(Error, DetalleError);
            //}
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, sMensajeError+' '+DetalleError);
        }

    }
       protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CertificacionCC/wfrmEstructuraProgramacion.aspx");
    }
    protected void gvEstructuraDetalle_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {
            GridViewRow row = gvEstructuraDetalle.SelectedRow;
            int iIdEstructura = Convert.ToInt32(gvEstructuraDetalle.DataKeys[row.RowIndex].Values["IdEstructura"]);
            int iIdRol = Convert.ToInt32(gvEstructuraDetalle.DataKeys[row.RowIndex].Values["IdRol"]);
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "D";            
            string sMensajeError = "";
            if (ObjEstructuraProgramacion.EstructuraProgramacionElimina(iIdConexion, cOperacion, iIdEstructura, iIdRol, ref sMensajeError))
            {
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
                ListaGvEstructuraDetalle((int)ViewState["iIdEstructura"]);
                

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