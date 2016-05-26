using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfNotificacion.Logica;
public partial class Notificaciones_wfrmEnvios : System.Web.UI.Page
{
    clsEnvio Envio = new clsEnvio();
    DataTable gEnvio;
    string mensaje = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        HttpContext.Current.Server.ScriptTimeout = 2400;
        if (!Page.IsPostBack)
        {

            ListaOficinas();
            ComboFuncionario();
            grillaEnvio();
        }
    }

    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
      int fila2 = gvEnvio.SelectedRow.RowIndex;
      CargarSeleccionado(fila2);
    }
   private void CargarSeleccionado(int fila)
    {
        txtCIC.Text = gvEnvio.SelectedDataKey["NumeroDocumento"].ToString();
        txtFechaNacC.Text = gvEnvio.SelectedDataKey["FechaNacimiento"].ToString();
        txtPaternoC.Text = gvEnvio.SelectedDataKey["PrimerApellido"].ToString();
        txtMaternoC.Text = gvEnvio.SelectedDataKey["SegundoApellido"].ToString();
        txtNombreC.Text = gvEnvio.SelectedDataKey["PrimerNombre"].ToString();
        txtTramiteC.Text = gvEnvio.SelectedDataKey["IdTramite"].ToString();
        txtMatriculaC.Text = gvEnvio.SelectedDataKey["Matricula"].ToString();
        txtRegional.Text = gvEnvio.SelectedDataKey["OfiNot"].ToString();
        //txtOficinaNot.Text = gvEnvio.SelectedDataKey["OfiNot"].ToString();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Int64 tram;
        Int32 idGBene;
        string fechDoc;
        Int32 nroDoc;
        Int32 idDoc;
        foreach (GridViewRow row in gvEnvio.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                //CheckBox chkRol = (row.Cells[9].FindControl("chkRol") as CheckBox);
                //CheckBox check = (CheckBox)row.Cells["prueba"].FindControl("chkRol");
                CheckBox chk_Publicar = (CheckBox)row.Cells[15].FindControl("chkEnvio");
                if (chk_Publicar.Checked)
                {
                    // en lugar de val guardar registro
                    //int IdRol = Convert.ToInt32(row.Cells[1].Text);
                    tram = Convert.ToInt64(gvEnvio.DataKeys[row.RowIndex].Values["IdTramite"].ToString());
                    idGBene = Convert.ToInt32(gvEnvio.DataKeys[row.RowIndex].Values["IdGrupoBeneficio"].ToString());
                    fechDoc = gvEnvio.DataKeys[row.RowIndex].Values["FechaDocumento"].ToString();
                    nroDoc = Convert.ToInt32(gvEnvio.DataKeys[row.RowIndex].Values["NroDocumento"].ToString());
                    idDoc = Convert.ToInt32(gvEnvio.DataKeys[row.RowIndex].Values["IdDocumento"].ToString());
                    //Envio K
                    if (Envio.RegistroEnvio((int)Session["IdConexion"], "K", tram, idGBene, fechDoc, nroDoc, idDoc, txtCite.Text, txtFechaCITE.Text, txtFechaEnvio.Text, 100, Convert.ToInt32(ddlOficina.SelectedValue.ToString()), txtObsEnvio.Text,ref mensaje))
                    { 
                        Master.MensajeOk("Se realizo la Operacion con exito");
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script language=javascript>alert('Se registro el envío correctamente');</script>");
                    }
                    else
                        Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
                }   
            }
        }

        //FORMA BUENA
        /*foreach (GridViewRow gvr in gvEnvio.Rows)
        {   
             if (gvr.RowType == DataControlRowType.DataRow)
             {
                 CheckBox chk = (gvr.Cells[9].FindControl("chkVarios") as CheckBox);
                if (chk != null)
                {

                    if (chk.Checked)
                    {
                        txtFechaNacC.Text = "Ingresa4";
                    }
                }
            }*/
        ddlOficina.SelectedValue = "0";
        txtCite.Text = "";
        txtFechaCITE.Text = "";
        txtFechaEnvio.Text = "";
        grillaEnvio();
        }

    public void grillaEnvio() //Envio D
    {
        try
        {
            gvEnvio.Visible = true;
            gvEnvio.DataSource = Envio.ObtieneDatos((int)Session["IdConexion"], "D", ref mensaje);
            gvEnvio.DataBind();
            if (gvEnvio.DataSource != null && gvEnvio.Rows.Count > 0)                
            {
                btnEnviar.Visible = true;
            }
            else
            {
                btnEnviar.Visible = false;
            }
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operación", mensaje);
        }
    }

    protected void btnEnviar_Click1(object sender, EventArgs e)
    {
        pnlTipoCambio_ModalPopupExtender.Show();
    }
    public void ListaOficinas() //Oficina B
    {   
        ddlOficina.DataSource = null;
        ddlOficina.DataSource = Envio.ListaOficinas((int)Session["IdConexion"], "B",2, ref mensaje);
        ddlOficina.DataValueField = "IdOficina";
        ddlOficina.DataTextField = "Nombre";
        ddlOficina.DataBind();
        ddlOficina.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlOficina.SelectedValue = "0";
    }
    protected void gvEnvio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEnvio.PageIndex = e.NewPageIndex;
        grillaEnvio();
    }
    protected void ComboFuncionario()
    {
        try
        {
            ddlFuncionario.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlFuncionario.SelectedValue = "0";
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
        }
    }
    protected void btnCancelarEnvio_Click(object sender, EventArgs e)
    {
        txtCite.Text = "";
        txtFechaCITE.Text = "";
        txtFechaEnvio.Text = "";
        ddlFuncionario.SelectedValue = Convert.ToString(0);
    }
    protected void UltimoEnvio(object sender, EventArgs e)
    {
        if (lnkMas.Text == "VER ULTIMO ENVIO")
        {
            try
            {
                gvEnvio.Visible = false;
                lblRegional.Visible = false;
                btnEnviar.Visible = false;
                gvUltEnvio.Visible = true;
                gvUltEnvio.DataSource = Envio.DocsUltimoEnvio((int)Session["IdConexion"], "J", ref mensaje);
                gvUltEnvio.DataBind();
                lnkMas.Text = "VOLVER ATRAS";
            }
            catch 
            {
                Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
            }
        }
        else 
        {
            gvUltEnvio.Visible = false;
            lblRegional.Visible = true;
            grillaEnvio();
            lnkMas.Text = "VER ULTIMO ENVIO";
        }
    }
    protected void ddlFuncionario_TextChanged(object sender, EventArgs e)
    {
        ddlFuncionario.DataSource = Envio.ListaFuncionarios((int)Session["IdConexion"], "A",Convert.ToInt32(ddlOficina.SelectedValue), ref mensaje);
        ddlFuncionario.DataValueField = "IdUsuario";
        ddlFuncionario.DataTextField = "Nombre";
        ddlFuncionario.DataBind();
        if (ddlFuncionario.DataSource == null)
        {
            ddlFuncionario.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlFuncionario.SelectedValue = "0";
            ddlFuncionario.Enabled = false;
        }
        else 
        {
            ddlFuncionario.Enabled = true;
        }
        pnlTipoCambio_ModalPopupExtender.Show();
    }
}   
