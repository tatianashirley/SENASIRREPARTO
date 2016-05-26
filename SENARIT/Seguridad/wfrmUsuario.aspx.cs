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




public partial class Seguridad_wfrmUsuario : System.Web.UI.Page
{
   clsUsuario ObjUsuario = new clsUsuario();
   clsSeguridad ObjSeguridad = new clsSeguridad();

   //wcfNovedades.Datos.clsNovedadesDA obj = new wcfNovedades.Datos.clsNovedadesDA();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            Panel1.Visible = true;                        
            pnlRegistro.Visible = false;
            CambiarInterfaz();
        }
        //else
        //{
        //    ListaUsuarios(); 
        //}

     }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtLogin, btnBuscar);
        AgregarJSAtributos(txtCarnet, txtCuentaUsuario);
        AgregarJSAtributos(txtCuentaUsuario, txtClaveUsuario);
        AgregarJSAtributos(txtClaveUsuario, txtFechaVigencia);
        AgregarJSAtributos(txtCuentaUsuario, txtFechaVigencia);
        AgregarJSAtributos(txtFechaVigencia, txtFechaExpiracion);
        AgregarJSAtributos(txtFechaExpiracion, rblTipoUsuario);

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
    protected void ListaUsuarios()
    {
        int iIdConexion =(int)Session["IdConexion"];
        string sOperacion = "Q";
        string sLogin = txtLogin.Text;
        string sMensajeError = null;
        gvDatos.DataSource = ObjUsuario.ListaUsuarios(iIdConexion, sOperacion, sLogin,ref sMensajeError);
        gvDatos.DataBind();

    }
    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        ListaUsuarios();
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        //Panel1.Visible = false;        
        Label2.Text = "Nuevo Usuario";
        this.pnlRegistra_ModalPopupExtender.Show(); 
        pnlRegistro.Visible = true;
        chbEstado.Visible = false;
        btnAceptar.Visible = true;
        rblTipoUsuario.Visible = true;
        lblTipoUsuario.Visible = true;
        btnActualizar.Visible = false;

        
        txtIdUsuario.Visible = false;
        txtCarnet.Text = "";
        txtCuentaUsuario.Text = "";
        txtFechaExpiracion.Text = "";
        txtFechaVigencia.Text = "";
        txtClaveUsuario.Text = "";
        lblClaveUsuario.Visible = false;
        txtClaveUsuario.Visible = false;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        chbEstado.Visible = false;
        pnlRegistro.Visible = false;
        btnActualizar.Visible = false;
        txtIdUsuario.Visible = false;
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        
        String sMensajeError = null;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        try
        {
            int iCarnet = Convert.ToInt32(txtCarnet.Text);            
            string sCuentaUsuario = txtCuentaUsuario.Text;            
            DateTime fFechaVigencia = Convert.ToDateTime(txtFechaVigencia.Text);
            DateTime? fFechaExpiracion;

            if (txtFechaExpiracion.Text == "")
            {
                fFechaExpiracion = null;
            }
            else
            {
                fFechaExpiracion = Convert.ToDateTime(txtFechaExpiracion.Text);
                
            }
            
            
            

            string sClaveUsuario = ObjSeguridad.Encriptar(Convert.ToString(iCarnet));
            int iTipoUsuario = Convert.ToInt32(rblTipoUsuario.SelectedValue);
            int iIdEstado;
            if (chbEstado.Checked == true)
            {
                iIdEstado = 31;
            }
            else
            {
                iIdEstado = 32;
            }
            DateTime hoy=DateTime.Today;
            

            if (ObjUsuario.UsuarioAdicion(iIdConexion, cOperacion,iCarnet,sCuentaUsuario,fFechaVigencia,fFechaExpiracion, iTipoUsuario,iIdEstado,sClaveUsuario, ref sMensajeError))
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
                pnlRegistro.Visible = false;
                chbEstado.Visible = false;
                ListaUsuarios();

                rblTipoUsuario.Visible = false;
                lblTipoUsuario.Visible = false;
            

        }
        catch (Exception ex)
        {
            sMensajeError=ex.Message.ToString();
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }

        

    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {
            //// Response.Redirect("FBolCensalAddV2.aspx?idv=" + Security.encryptQueryString(e.CommandArgument.ToString()) + "");
            Label2.Text = "Editar Usuario";
            int iIdUsuario =Convert.ToInt32(e.CommandArgument.ToString());
            //Panel1.Visible = false;
            this.pnlRegistra_ModalPopupExtender.Show(); 
            pnlRegistro.Visible = true;
            chbEstado.Visible = true;
            btnActualizar.Visible = true;
            btnAceptar.Visible = false;
            txtIdUsuario.Visible = false;
            lblClaveUsuario.Visible = true;
            txtClaveUsuario.Visible = true;
            lblTipoUsuario.Visible = true;
            rblTipoUsuario.Visible = true;

            DataTable dtDataTable = null;
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";

            int iCarnet=0;
            string sCuentaUsuario = null;
            string fFechaVigencia = null;
            string fFechaExpiracion = null;
            string sClaveUsuario = null;
            int iIdEstado=0;
            int iIdTipoUsuario=0;



            dtDataTable = ObjUsuario.UsuarioPorId(iIdConexion, cOperacion, iIdUsuario);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    iIdUsuario = Convert.ToInt32(drDataRow["IdUsuario"]);
                    iCarnet=Convert.ToInt32(drDataRow["Carnet"]);
                    sCuentaUsuario=Convert.ToString(drDataRow["CuentaUsuario"]);
                    fFechaVigencia=Convert.ToString(drDataRow["FechaVigencia"]).Substring(0,10);
                    if (drDataRow["FechaExpiracion"] != null && drDataRow["FechaExpiracion"].ToString()!="")
                    {
                        fFechaExpiracion = Convert.ToString(drDataRow["FechaExpiracion"]).Substring(0, 10);
                    }
                    
                    iIdEstado=Convert.ToInt32(drDataRow["IdEstado"]);
                    iIdTipoUsuario=Convert.ToInt32(drDataRow["IdTipoUsuario"]);
                    if (Convert.ToString(drDataRow["ClaveUsuario"]) == "")
                    {
                        sClaveUsuario = "";
                    }
                    else
                    {
                        sClaveUsuario = ObjSeguridad.Desencriptar(Convert.ToString(drDataRow["ClaveUsuario"]));
                    }
              }
                txtCarnet.Text = Convert.ToString(iCarnet);
                txtCuentaUsuario.Text = sCuentaUsuario;
                txtFechaVigencia.Text = fFechaVigencia;
                txtFechaExpiracion.Text = fFechaExpiracion;
                txtIdUsuario.Text =Convert.ToString( iIdUsuario);
                txtClaveUsuario.Text = sClaveUsuario;
                
                if (iIdEstado == 31)
                {
                    chbEstado.Checked = true;
                }
                else
                {
                    chbEstado.Checked = false;
                }

                rblTipoUsuario.SelectedValue = Convert.ToString(iIdTipoUsuario);
                
            }
        }
        if (e.CommandName == "cmdEliminar")
        {
            int iIdUsuario = Convert.ToInt32(e.CommandArgument.ToString());
            string sClaveUsuario = ObjSeguridad.Encriptar("123456");

            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "R";
            string sSessionTrabajo = null;
            string sSNN = null;
            string sMensajeError = null;
            if (ObjSeguridad.UsuarioRestauraPassword(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdUsuario, sClaveUsuario, ref sMensajeError))
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
        }
    }





    protected void btnActualizar_Click(object sender, EventArgs e)
    {

        String sMensajeError = null;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        try
        {
            int iIdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            int iCarnet = Convert.ToInt32(txtCarnet.Text);
            string sCuentaUsuario = txtCuentaUsuario.Text;
            DateTime fFechaVigencia = Convert.ToDateTime(txtFechaVigencia.Text);
            string fFechaExpiracion;
            fFechaExpiracion = txtFechaExpiracion.Text;
            if (txtFechaExpiracion.Text == "")
            {
                fFechaExpiracion = null;
            }
            string sClaveUsuario = ObjSeguridad.Encriptar(Convert.ToString(txtClaveUsuario.Text));
            int iTipoUsuario = Convert.ToInt32(rblTipoUsuario.SelectedValue);
            int iIdEstado;
            if (chbEstado.Checked == true)
            {
                iIdEstado = 31;
            }
            else
            {
                iIdEstado = 32;
            }


            if (ObjUsuario.UsuarioModifica(iIdConexion, cOperacion,iIdUsuario, iCarnet, sCuentaUsuario, fFechaVigencia, fFechaExpiracion, iTipoUsuario, iIdEstado, sClaveUsuario, ref sMensajeError))
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
            pnlRegistro.Visible = false;
            chbEstado.Visible = false;
            ListaUsuarios();

            rblTipoUsuario.Visible = false;
            lblTipoUsuario.Visible = false;


        }
        catch (Exception ex)
        {
            sMensajeError = ex.Message.ToString();
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ListaUsuarios();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.pnlRegistra_ModalPopupExtender.Show(); 
        txtFechaExpiracion.Text = "";
    }
}