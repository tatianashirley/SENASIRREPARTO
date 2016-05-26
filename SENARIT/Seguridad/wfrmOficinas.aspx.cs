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




public partial class Seguridad_wfrmOficinas : System.Web.UI.Page
{
   clsSeguridad obj = new clsSeguridad();
   clsOficinas ObjOficinas = new clsOficinas();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlListaOficinas.Visible = true;
            ListaOficinasPrincipales();
            pnlRegistraOficinas.Visible = false;                        
            CambiarInterfaz();

        }
       
        
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtOficinas, ddlOficinas);
        AgregarJSAtributos(txtCodigo, txtNivel);
        AgregarJSAtributos(txtNivel, txtDireccion);
        AgregarJSAtributos(txtDireccion, txtTelefono);
        AgregarJSAtributos(txtTelefono, rblIdTipoOficina);

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
    protected void ddlIdOficinaPrincipal_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdOficinaPrincipal = Convert.ToInt32(ddlOficinaPrincipal.SelectedValue);
        ListaOficinas(iIdOficinaPrincipal);
    }
    protected void ListaOficinas(int iIdOficinaPrincipal)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "C";        
        string sMensajeError = "";
        string sNivelError="";
        gvDatos.DataSource = ObjOficinas.OficinaListaPorOficinaPrincipal(iIdConexion,cOperacion,iIdOficinaPrincipal,ref sMensajeError,ref sNivelError);
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
    protected void ListaOficinasPrincipales()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = "";
        ddlOficinaPrincipal.Items.Clear();
        ddlOficinaPrincipal.ClearSelection();        
        ddlOficinaPrincipal.DataSource = ObjOficinas.OficinaLista(iIdConexion, cOperacion, ref sMensajeError);
        ddlOficinaPrincipal.DataValueField = "IdOficina";
        ddlOficinaPrincipal.DataTextField = "Oficina";
        ddlOficinaPrincipal.DataBind();
        ddlOficinaPrincipal.Items.Insert(0, new ListItem("Seleccione...", "0"));

    }
    protected void ListaOficinasPrincipalesRegistrar()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = "";
        ddlOficinas.Items.Clear();
        ddlOficinas.ClearSelection();
        ddlOficinas.DataSource = ObjOficinas.OficinaLista(iIdConexion, cOperacion, ref sMensajeError);
        ddlOficinas.DataValueField = "IdOficina";
        ddlOficinas.DataTextField = "Oficina";
        ddlOficinas.DataBind();
        ddlOficinas.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
        Label1.Text = "Nueva Oficina";
        txtNivel.Text = "";
        txtOficinas.Text = "";
        txtTelefono.Text = "";
        txtIdOficinas.Text = "";
        ddlIdLocalidad.ClearSelection();
        ddlIdLocalidad.Items.Clear();
        ddlOficinaPrincipal.ClearSelection();
        ddlOficinas.ClearSelection();
        ListaOficinasPrincipalesRegistrar();        
        txtIdOficinas.Visible = false;        
        //pnlListaOficinas.Visible = false;
        this.pnlRegistraOficinas_ModalPopupExtender.Show();
        pnlRegistraOficinas.Visible = true;
        btnAdicionar.Visible = true;
        btnActualizar.Visible = false;

       
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlListaOficinas.Visible = true;
        pnlRegistraOficinas.Visible = false;
        btnActualizar.Visible = false;
        txtIdOficinas.Visible = false;
        txtCodigo.Text = "";
        txtDireccion.Text = "";
        txtIdDepartamento.Text = "";
        txtIdOficinas.Text = "";
        txtNivel.Text = "";
        txtOficinas.Text = "";
        txtTelefono.Text = "";
        ddlIdLocalidad.ClearSelection();
        //ddlOficinaPrincipal.ClearSelection();
        ddlOficinas.ClearSelection();
        
    }
    protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "cmdEditar")
        {

            Label1.Text = "Editar Oficina";
            int IdOficina = Convert.ToInt32(e.CommandArgument.ToString());
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";
            string sMensajeError = null;
            pnlRegistraOficinas.Visible = true;
            //pnlListaOficinas.Visible=false;
            this.pnlRegistraOficinas_ModalPopupExtender.Show();
            btnAdicionar.Visible = false;
            btnActualizar.Visible = true;
            txtIdOficinas.Visible = false;
            int iIdOficina = 0;
            string sOficina = null;
            int iIdOficinaSuperior=0;
            string sCodigo=null;
            string sNivel=null;
            string sDireccion = null;
            string sTelefono = null;
            int iLocalidad=0;
            int iIdTipoOficina=0;
            int iIdEstado=0;
            int iFlagCC=0;
            ListaOficinasPrincipalesRegistrar();
            
            DataTable dtDataTable = null;

            dtDataTable = ObjOficinas.ListaOficinasxIdOficinas(iIdConexion, cOperacion, IdOficina, ref sMensajeError);

            if (dtDataTable != null && dtDataTable.Rows.Count == 1)
            {
                foreach (DataRow drDataRow in dtDataTable.Rows)
                {
                    iIdOficina = Convert.ToInt32(drDataRow["IdOficina"]);
                    sCodigo = Convert.ToString(drDataRow["Codigo"]);
                    sOficina = Convert.ToString(drDataRow["Nombre"]);
                    iIdOficinaSuperior = Convert.ToInt32(drDataRow["IdOficinaSuperior"]);
                    sNivel = Convert.ToString(drDataRow["Nivel"]);
                    sDireccion = Convert.ToString(drDataRow["Direccion"]);
                    sTelefono = Convert.ToString(drDataRow["Telefono"]);
                    iLocalidad = Convert.ToInt32(drDataRow["IdLocalidad"]);
                    iIdTipoOficina = Convert.ToInt32(drDataRow["IdTipoOficina"]);
                    iFlagCC = Convert.ToInt32(drDataRow["FlagImprimeCC"]);
                    iIdEstado = Convert.ToInt32(drDataRow["IdEstado"]);
                }
                txtIdOficinas.Text = Convert.ToString(iIdOficina);
                txtOficinas.Text = sOficina;
                txtIdDepartamento.Text = Convert.ToString(iIdOficinaSuperior);
                ListaLocalidad();
                ddlOficinas.SelectedValue =Convert.ToString( iIdOficinaSuperior);
                txtNivel.Text = sNivel;
                txtDireccion.Text = sDireccion;
                txtTelefono.Text = sTelefono;
                txtCodigo.Text = sCodigo;
                ddlIdLocalidad.SelectedValue = Convert.ToString(iLocalidad);
                iIdTipoOficina = Convert.ToInt32(iIdTipoOficina);
                if (iIdTipoOficina ==34)
                {
                    rblIdTipoOficina.Items[0].Selected= true;
                    
                }
                else if (iIdTipoOficina ==35)
                {
                    rblIdTipoOficina.Items[1].Selected = true;
                }
                else
                {
                    rblIdTipoOficina.Items[2].Selected = true;
                }

                if (iIdEstado == 31)
                {
                    chbIdEstado.Checked = true;
                }
                else
                {
                    chbIdEstado.Checked = false;
                }
                if (iFlagCC == 1)
                {
                    chbFlagCC.Checked = true;
                }
                else
                {
                    chbFlagCC.Checked = false;
                }
            }

        }
       



    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        int iIdOficinaPrincipal = Convert.ToInt32(ddlOficinaPrincipal.SelectedValue);
        ListaOficinas(iIdOficinaPrincipal);
    }




    protected void btnAdicionar_Click(object sender, EventArgs e)
    {

        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        String sMensajeError = null;
        string sOficina = txtOficinas.Text;
        int iIdOficinaSuperior = Convert.ToInt32(ddlOficinas.SelectedValue);
        string sCodigo = txtCodigo.Text;
        string sNivel = txtNivel.Text;
        string sDireccion = txtDireccion.Text;
        int iTelefono = Convert.ToInt32(txtTelefono.Text);
        int iLocalidad = Convert.ToInt32(ddlIdLocalidad.SelectedValue);
        int iIdTipoOficina = Convert.ToInt32(rblIdTipoOficina.SelectedValue);
        int iIdEstado;
        int iFlagCC;
        if (chbIdEstado.Checked==true)
        {
           iIdEstado = 31;
        }
        else
        {
           iIdEstado = 32;
        }
        if (chbFlagCC.Checked == true)
        {
            iFlagCC = 1;
        }
        else
        {
            iFlagCC = 0;
        }


        if (ObjOficinas.OficinaAdiciona(iIdConexion, cOperacion, sOficina, iIdOficinaSuperior, sCodigo, sNivel, sDireccion, iTelefono, iLocalidad, iIdTipoOficina, iIdEstado, iFlagCC, ref sMensajeError))
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
        pnlListaOficinas.Visible = true;
        pnlRegistraOficinas.Visible = false;
        int iIdOficinaPrincipal = Convert.ToInt32(ddlOficinas.SelectedValue);
        ddlOficinaPrincipal.SelectedValue = Convert.ToString(iIdOficinaPrincipal);
        ListaOficinas(iIdOficinaPrincipal);
    }
    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "U";

        String sMensajeError = null;
        try
        {
            int iIdOficina = Convert.ToInt32(txtIdOficinas.Text);
            string sOficina = txtOficinas.Text;
            int iIdOficinaSuperior = Convert.ToInt32(ddlOficinas.SelectedValue);
            string sCodigo = txtCodigo.Text;
            string sNivel = txtNivel.Text;
            string sDireccion = txtDireccion.Text;
            int iTelefono = Convert.ToInt32(txtTelefono.Text);
            int iLocalidad = Convert.ToInt32(ddlIdLocalidad.SelectedValue);
            int iIdTipoOficina = Convert.ToInt32(rblIdTipoOficina.SelectedValue);
            int iIdEstado=0;
            int iFlagCC=0;
            if (chbIdEstado.Checked ==true)
            {
                iIdEstado = 31;
            }
            else
            {
                iIdEstado = 32;
            }
            if (chbFlagCC.Checked == true)
            {
                iFlagCC = 1;
            }
            else
            {
                iFlagCC = 0;
            }

            if (ObjOficinas.OficinaModifica(iIdConexion, cOperacion, iIdOficina, sOficina, iIdOficinaSuperior, sCodigo, sNivel, sDireccion, iTelefono, iLocalidad, iIdTipoOficina, iIdEstado, iFlagCC, ref sMensajeError))
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
            pnlListaOficinas.Visible = true;
            pnlRegistraOficinas.Visible = false;
            txtIdOficinas.Visible = false;
            ListaOficinas(iIdOficinaSuperior);
            btnActualizar.Visible = false;


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Visible = false;
        //    e.Row.Cells[1].Visible = false;
        //}
       


    }

    protected void ddlOficinas_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigo.Focus();
        txtIdDepartamento.Text = ddlOficinas.SelectedValue;
        ListaLocalidad();
        this.pnlRegistraOficinas_ModalPopupExtender.Show();
    }
    protected void ListaLocalidad()
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "L";
        string sMensajeError = "";
        int iIdDepartamento= Convert.ToInt32(txtIdDepartamento.Text);
        ddlIdLocalidad.Items.Clear();
        ddlIdLocalidad.ClearSelection();
        ddlIdLocalidad.DataSource = ObjOficinas.LocalidadLista(iIdConexion, cOperacion,iIdDepartamento, ref sMensajeError);
        ddlIdLocalidad.DataValueField = "CodigoLocalidad";
        ddlIdLocalidad.DataTextField = "NombreLocalidad";
        ddlIdLocalidad.DataBind();
        ddlIdLocalidad.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }
}