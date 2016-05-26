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

public partial class Seguridad_wfrmTransaccion : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   clsTransaccion ObjTransaccion = new clsTransaccion();
   clsProcedimientos ObjProcedimientos = new clsProcedimientos();
   ListItem oItem = new ListItem("Seleccione...", "0");
   MasterPage ObjMaster = new MasterPage();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaTransaccion.Visible = true;
            ListaModulo();
            //ListaTransaccion();
            
            pnlRegistraTransaccion.Visible = false;
            CambiarInterfaz();
            //ListaTransaccionPadre();
        }
        //else
        //{
        //    ListaTransaccion();            
        //}
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtNroTransaccion, cbFlag);
        AgregarJSAtributos(txtDescripcionTransaccion, txtOperacion);
        AgregarJSAtributos(txtOperacion, txtSegsTimeout);
        AgregarJSAtributos(txtSegsTimeout, rblIdEstado);

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
        ListaProcedimientoBusqueda();
        
    }
    protected void ListaProcedimientoBusqueda()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        string sMensajeError = null;
        ddlIdProcedimientoBusqueda.Items.Clear();        
        ddlIdProcedimientoBusqueda.DataSource = ObjProcedimientos.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError);        
        ddlIdProcedimientoBusqueda.DataValueField = "IdProcedimiento";
        ddlIdProcedimientoBusqueda.DataTextField = "Nombre";
        ddlIdProcedimientoBusqueda.DataBind();
        ddlIdProcedimientoBusqueda.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdProcedimientoBusqueda.SelectedValue = "0";
        
        
    }
    protected void ddlIdProcedimientoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimientoBusqueda.SelectedValue);
        ListaTransaccion(iIdModulo,iIdProcedimiento);
    }
    private void Transaccion(int transaccion)
    {
       // DEVUELVE 0 Disabled - 1 Enabled
        int result=Master.HabilitaTransaccion(transaccion);
    }
    protected void ListaTransaccion(int iIdModulo,int iIdProcedimiento)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;        
        string sMensajeError = null;
        string sNivelError = null;
        //System.Threading.Thread.Sleep(2000);
        gvDatos.DataSource = ObjTransaccion.ListaTransaccionPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, iIdProcedimiento, ref sMensajeError,ref sNivelError);
        gvDatos.DataBind();        
        if (sNivelError == "2")
        {
            string Error = "No existen datos que correspondan al criterio especificado";
            Master.MensajeWarning(Error);
        }
        else
        {
            string Error = null;
            Master.MensajeWarning(Error);
        }
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
        this.pnlRegistra_ModalPopupExtender.Show();
        Label1.Text = "Nueva Transaccion";
        pnlListaTransaccion.Visible = false;
        pnlRegistraTransaccion.Visible = true;
        
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;
        ddlIdModuloRegistrar.Enabled = true;
        ddlIdProcedimiento.Enabled = true;

        ListaModuloRegistrar();
        txtDescripcionTransaccion.Text = "";
        txtIdTransaccion.Text = "";
        txtIdTransaccion.Visible = false;
        txtOperacion.Text = "";
        txtSegsTimeout.Text = "";
        txtNroTransaccion.Visible = true;
        txtNroTransaccion.Text = "";
        lblNroTransaccion.Visible = true;

        
        
        
        
       
    }
    protected void ListaModuloRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        int iIdModulo;
        if (ddlIdModuloRegistrar.SelectedValue != "")
        {
            iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        }
        else
        {
            iIdModulo = 0;
        }
        ddlIdModuloRegistrar.Items.Clear();
        ddlIdModuloRegistrar.DataSource = obj.ListaModulos(iIdConexion, cOperacion);
        ddlIdModuloRegistrar.DataValueField = "IdModulo";
        ddlIdModuloRegistrar.DataTextField = "DescripcionModulo";
        ddlIdModuloRegistrar.DataBind();
        ddlIdModuloRegistrar.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdModuloRegistrar.SelectedValue =Convert.ToString(iIdModulo);

    }
    protected void ddlIdModuloRegistrar_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ListaProcedimientoRegistrar();
        txtNroTransaccion.Text = "";
        this.pnlRegistra_ModalPopupExtender.Show();
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
        ddlIdProcedimiento.DataSource = ObjProcedimientos.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError);
        ddlIdProcedimiento.DataValueField = "IdProcedimiento";
        ddlIdProcedimiento.DataTextField = "Nombre";
        ddlIdProcedimiento.DataBind();
        ddlIdProcedimiento.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlIdProcedimiento.SelectedValue = "0";
        
       

        
    }
    protected void ObtieneNroTransaccion()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";
        //string sSessionTrabajo = null;
        //string sSNN = null;
        //int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimiento.SelectedValue);
        string sMensajeError = null;
//        ddlIdProcedimiento.Items.Clear();
        DataTable dtDataTable = null;
        int NroTransaccion=0;

        dtDataTable = ObjTransaccion.ObtieneNroTransaccion(iIdConexion, cOperacion, iIdProcedimiento, ref sMensajeError);
        if (dtDataTable != null && dtDataTable.Rows.Count > 0)
        {
            foreach (DataRow drDataRow in dtDataTable.Rows)
            {
                NroTransaccion=Convert.ToInt32(drDataRow["NroTransaccion"]);   
            }
            
        }
        txtNroTransaccion.Text = Convert.ToString(NroTransaccion);

        
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaTransaccion.Visible = true;
        pnlRegistraTransaccion.Visible = false;
        btnActualizar.Visible = false;
        txtIdTransaccion.Visible = false;
        txtDescripcionTransaccion.Text = "";
        txtOperacion.Text = "";
        txtSegsTimeout.Text = "";
        txtNroTransaccion.Visible = false;
        txtNroTransaccion.Text = "";
        lblNroTransaccion.Visible = false;
        ddlIdProcedimiento.Items.Clear();
        ddlIdModuloRegistrar.Items.Clear(); 
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar")
        {
            Label1.Text = "Editar Transaccion";
            ListaModuloRegistrar();
            this.pnlRegistra_ModalPopupExtender.Show();
           
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";

            int iIdTransaccion = Convert.ToInt32(e.CommandArgument.ToString());
            pnlRegistraTransaccion.Visible = true;
            pnlListaTransaccion.Visible = false;
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdTransaccion.Visible = false;
            ddlIdModuloRegistrar.Enabled = false;
            ddlIdProcedimiento.Enabled = false;


            DataTable dtDataTable = null;
            string sMensajeError = null;
            //int IdEstado;

            dtDataTable = ObjTransaccion.ListaTransaccionPorId(iIdConexion, cOperacion, iIdTransaccion, ref sMensajeError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    string sIdTransaccion=Convert.ToString(drDataRow["IdTransaccion"]);
                    string sIdModulo=Convert.ToString(sIdTransaccion.Substring(0, 2));
                    ddlIdModuloRegistrar.SelectedValue = sIdModulo;
                    txtIdTransaccion.Text = Convert.ToString(drDataRow["IdTransaccion"]);
                    txtDescripcionTransaccion.Text = Convert.ToString(drDataRow["Descripcion"]);
                    ListaProcedimientoActualizar(sIdModulo);
                    ddlIdProcedimiento.SelectedValue = Convert.ToString(drDataRow["IdProcedimiento"]);

                    if (Convert.ToInt32(drDataRow["FlagLog"]) == 1)
                    {
                        cbFlag.Checked = true;
                    }
                    else
                    {
                        cbFlag.Checked = false;
                    }
                    txtOperacion.Text = Convert.ToString(drDataRow["OperacionTrn"]);
                    txtSegsTimeout.Text= Convert.ToString(drDataRow["SegsTimeout"]);

                    
                    if (Convert.ToInt32(drDataRow["IdEstado"]) == 31)
                    {
                        rblIdEstado.Items[0].Enabled = true;
                    }
                    else
                    {
                        rblIdEstado.Items[1].Enabled = true;
                    }
                    //ListaProcedimientoActualizar(sIdModulo);
                }
                
                
            }
        }




    }
    protected void ListaProcedimientoActualizar(string sIdModulo)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(sIdModulo);
        string sMensajeError = null;
        ddlIdProcedimiento.DataSource = ObjProcedimientos.ListaProcedimientoPorModulo(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iIdModulo, ref sMensajeError);
        ddlIdProcedimiento.DataValueField = "IdProcedimiento";
        ddlIdProcedimiento.DataTextField = "Nombre";
        ddlIdProcedimiento.DataBind();
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimientoBusqueda.SelectedValue);
        ListaTransaccion(iIdModulo,iIdProcedimiento);
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        string sSessionTrabajo = null;
        string sSNN = null;
        int iIdModulo = Convert.ToInt32(ddlIdModuloRegistrar.SelectedValue);
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimiento.SelectedValue);
        int iNroTransaccion = Convert.ToInt32(txtNroTransaccion.Text);
        string sDescripcionTransaccion = txtDescripcionTransaccion.Text;
        string sOperacionTrn = txtOperacion.Text;
        int iSegsTimeout=0;
        if (txtSegsTimeout.Text == "" || txtSegsTimeout.Text == null)
        {
           iSegsTimeout = 0;
        }
        else
        {
            iSegsTimeout = Convert.ToInt32(txtSegsTimeout.Text);
        }
        int iIdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
        int iFlag;
        if (cbFlag.Checked == true)
        {
            iFlag = 1;
        }
        else
        {
            iFlag = 0;
        }
        string sMensajeError=null;
        if (ObjTransaccion.TransaccionAdiciona(iIdConexion, cOperacion, sSessionTrabajo, sSNN, iNroTransaccion,sDescripcionTransaccion, iIdProcedimiento, iFlag, sOperacionTrn, iSegsTimeout, iIdEstado, iIdModulo, ref sMensajeError))
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
        pnlListaTransaccion.Visible = true;
        pnlRegistraTransaccion.Visible = false;
        txtDescripcionTransaccion.Text = "";
        txtOperacion.Text = "";
        txtSegsTimeout.Text = "";
        txtIdTransaccion.Text = "";
        txtNroTransaccion.Visible = false;
        txtNroTransaccion.Text = "";
        lblNroTransaccion.Visible = false;        
        ListaTransaccion(iIdModulo,iIdProcedimiento);
        ddlIdProcedimiento.Items.Clear();
        ddlIdModuloRegistrar.Items.Clear(); 


       
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";
        int iIdTransaccion =Convert.ToInt32(txtIdTransaccion.Text);
        string sDescripcion = txtDescripcionTransaccion.Text;
        int iIdProcedimiento = Convert.ToInt32(ddlIdProcedimiento.SelectedValue);
        int iFlagLog;
        if (cbFlag.Checked == true)
        {
            iFlagLog = 1;
        }
        else
        {
            iFlagLog = 0;
        }
        string sOperacionTrn = txtOperacion.Text;
        int iSegsTimeout ;
        if (txtSegsTimeout.Text == "" || txtSegsTimeout.Text == null)
        {
            iSegsTimeout = 0;
        }
        else
        {
            iSegsTimeout = Convert.ToInt32(txtSegsTimeout.Text);
        }
        
        
        int iIdEstado = Convert.ToInt32(rblIdEstado.SelectedValue);
        string sMensajeError = null;
        if (ObjTransaccion.TransaccionModifica(iIdConexion, cOperacion, iIdTransaccion, sDescripcion, iIdProcedimiento, iFlagLog, sOperacionTrn, iSegsTimeout, iIdEstado, ref sMensajeError))
        {
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
           // ObjMaster.MensajeOk(msg);
            
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        pnlListaTransaccion.Visible = true;
        pnlRegistraTransaccion.Visible = false;
        txtDescripcionTransaccion.Text = "";
        pnlListaTransaccion.Visible = true;
        pnlRegistraTransaccion.Visible = false;
        txtDescripcionTransaccion.Text = "";
        txtOperacion.Text = "";
        txtSegsTimeout.Text = "";
        txtIdTransaccion.Text = "";     
        
        btnActualizar.Visible = false;
        txtIdTransaccion.Visible=false;
        int iIdModulo = Convert.ToInt32(ddlIdModulo.SelectedValue);        
        ListaTransaccion(iIdModulo,iIdProcedimiento);
        ddlIdProcedimiento.Items.Clear();
        ddlIdModuloRegistrar.Items.Clear(); 

        
        
    }



    protected void ddlIdProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObtieneNroTransaccion();
        txtDescripcionTransaccion.Focus();
        this.pnlRegistra_ModalPopupExtender.Show();
    }
}