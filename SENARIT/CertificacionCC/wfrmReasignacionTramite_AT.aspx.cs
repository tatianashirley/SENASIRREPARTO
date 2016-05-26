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


public partial class Seguridad_wfrmUsuario : System.Web.UI.Page
{
    clsTramiteAsignado ObjTramite = new clsTramiteAsignado();
    clsTramiteClasificado ObjTramiteClasi = new clsTramiteClasificado();
   

   //wcfNovedades.Datos.clsNovedadesDA obj = new wcfNovedades.Datos.clsNovedadesDA();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            Panel1.Visible = true;                        
            pnlRegistro.Visible = false;
            CambiarInterfaz();
                       
            
        }
        

     }
    private void CambiarInterfaz()
    {
        string sMensajeError = null;

        ddlUsuariosCC.Visible = true;
        int iIdConexion = (int)Session["IdConexion"];
        const string cOperacion = "C";
        string TipoUsuario ="1";
        ddlUsuariosCC.Items.Clear();
        ddlUsuariosCC.ClearSelection();
        ddlUsuariosCC.DataSource = ObjTramite.UsuariosAsignaPorTipo(iIdConexion, cOperacion, TipoUsuario, ref sMensajeError);
        ddlUsuariosCC.DataValueField = "IdRolUsuario";
        ddlUsuariosCC.DataTextField = "CuentaUsuario";
        ddlUsuariosCC.DataBind();
        //ddlUsuariosCC.SelectedValue = "0";

    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Cargar_Grid();
    }

    private void Cargar_Grid()
    {
        DateTime FechaInicio = DateTime.Today;
        DateTime FechaFin;
        if (DateTime.TryParse(txtFechaInicio.Text, out FechaInicio)) FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
        //else FechaInicio = DateTime.Today;
        else FechaInicio = DateTime.MinValue;
        if (DateTime.TryParse(txtFechaFin.Text, out FechaFin)) FechaFin = Convert.ToDateTime(txtFechaFin.Text);
        //else FechaFin = DateTime.Today;
        else FechaFin = DateTime.MaxValue;
        int numregistros = Convert.ToInt32(txtnumregistros.Text);
        int CUA = Convert.ToInt32(txtCUA.Text);
        string NumeroDocumento = txtDocumento.Text;
        string Tramite = txtTramite.Text;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "A";
        string sSessionTrabajo = null;
        string sSNN = null;
        string sMensajeError= null;
        string sNivelError = null;
        //clsTramiteClasificado busca = new clsTramiteClasificado();
        gvDatos.DataSource = ObjTramite.ListarTramitesEnAT(iIdConexion, cOperacion, sSessionTrabajo, sSNN, FechaInicio, FechaFin, numregistros,
                NumeroDocumento, CUA, Tramite, ref sMensajeError, ref sNivelError);
        gvDatos.DataBind();
        gvDatos.Visible = true;
        int registros = gvDatos.Rows.Count;
    }


    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        Cargar_Grid();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        //chbEstado.Visible = false;
        pnlRegistro.Visible = false;
        //btnActualizar.Visible = false;
        //txtIdUsuario.Visible = false;
    }


    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {
            int iIdUsuario =Convert.ToInt32(e.CommandArgument.ToString());
            this.pnlRegistra_ModalPopupExtender.Show(); 
            pnlRegistro.Visible = true;
            //btnActualizar.Visible = true;
            //lblClaveUsuario.Visible = true;


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






        }
        if (e.CommandName == "cmdEliminar")
        {
            int iIdUsuario = Convert.ToInt32(e.CommandArgument.ToString());

        }
    }


    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btnActualizar.Visible = true;
        this.pnlRegistra_ModalPopupExtender.Show(); 
        pnlRegistro.Visible = true;
        GridViewRow row = gvDatos.SelectedRow;
        //txtTramite1.Text = Convert.ToString(gvDatos.DataKeys[row.RowIndex].Values["Tramite"]).ToUpper();
        //txtNombre.Text = Convert.ToString(gvDatos.DataKeys[row.RowIndex].Values["Nombre"]).ToUpper();
        //txtCUA1.Text = Convert.ToString(gvDatos.DataKeys[row.RowIndex].Values["CUA"]).ToUpper();
        //ddlClasif.SelectedValue = Convert.ToString(gvDatos.DataKeys[row.RowIndex].Values["IdClasificacionTramite"]).ToUpper();
        //txtIdTramite.Text = Convert.ToString(gvDatos.DataKeys[row.RowIndex].Values["IdTramiteClasificado"]).ToUpper();

    }


    protected void btnActualizar_Click(object sender, EventArgs e)
    {

        String sMensajeError = null;
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        try
        {
            clsTramiteClasificado busca = new clsTramiteClasificado();
            string sSessionTrabajo = null;
            string sSNN = null;
            int IdTramiteClasificado = 0;
            int IdClasificacionTramite = 0;
            //int IdTramiteClasificado = Convert.ToInt32(txtIdTramite.Text);
            //int IdClasificacionTramite = Convert.ToInt32(this.ddlClasif.SelectedValue);


            if (ObjTramiteClasi.ReClasificarTramite(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError, IdTramiteClasificado, IdClasificacionTramite))
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
  


        }
        catch (Exception ex)
        {
            sMensajeError = ex.Message.ToString();
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        
    }

    protected void imgbtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {

        txtFechaInicio.Text = "";
        txtFechaFin.Text = "";
        txtnumregistros.Text = "0";
        txtDocumento.Text = "";
        txtTramite.Text = "";
        txtCUA.Text = "0";
        gvDatos.DataSource = null;
        gvDatos.DataBind();
        gvDatos.Visible = false;
    }



    protected void btnEnviar_Click(object sender, EventArgs e)
    {

        int iIdConexion = (int)Session["IdConexion"];
        //String STramiteClasificado="";
        int IdUsuarioAsignado = 0;
        IdUsuarioAsignado = Convert.ToInt32(ddlUsuariosCC.SelectedValue);
        
        string sObservaciones = txtObservaciones.Text;
        foreach (GridViewRow row in gvDatos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkTramite = (row.Cells[1].FindControl("chkTramite") as CheckBox);

                if (chkTramite.Checked)
                {
                    int IdTramiteAsignado = (int)gvDatos.DataKeys[row.RowIndex].Value;
                    string sMensajeError = null;

                    if (ObjTramite.ReAsignaTramite_DesdeAT(iIdConexion, IdTramiteAsignado, IdUsuarioAsignado, sObservaciones, ref sMensajeError))
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
                        

                }
            }
        }

        Cargar_Grid();

    }


}