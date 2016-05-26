using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Drawing;

using WcfServicioClasificador.Logica;
using wcfServicioIntercambioPago.Logica;
using System.Globalization;

public partial class Medios_wfrmTipoRegistro : System.Web.UI.Page
{
    int IdArchivoRegistro;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
        {
           CargaListaMedio();
           if (Session["CTM"] == null)
           {
               ddlMedios.SelectedValue = "PR";
           }
           else
           {
               ddlMedios.SelectedValue = Session["CTM"].ToString();
           }
         }
    }
    #region botonesprincipal

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de Registro Intercambio";
        CargaTipoDato();
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        TextInfo TI = new CultureInfo("es-ES", false).TextInfo;
        Session["CTM"] = ddlMedios.SelectedValue.ToString();
        if (btnAccionar.Text == "Modificar")
        {
            if (txtTabla.Text != "" && txtCampo.Text != "" && txtExpReg.Text != "" && ddlTipoDato.SelectedIndex>0)  // verifica que el campo llenado no sea nulo
            {
                try
                {
                    clsIntercambio mod = new clsIntercambio();
                    //int IdArchivoTM = Convert.ToInt32(mod.ListarTipoIntercambio(0, ddlMedios.SelectedValue.ToString())[0].IdArchivo);
                    /*mod.ModificarRegistroIntercambio("Modificar",Convert.ToInt32(lblIdArchivo.Text),IdArchivoTM,txtNombreCampo.Text,
                         TI.ToTitleCase(ddlTipoDato.SelectedValue.ToString().ToLower()), Convert.ToInt32(txtTamaño.Text), txtTabla.Text,
                         txtCampo.Text, txtObservacion.Text, txtExpReg.Text);*/
                    string mensaje = null;
                    mod.ModificaCampoMedio((int)Session["IdConexion"],"U","Modificar", Convert.ToInt32(hfIdArchivo.Value), ddlMedios.SelectedValue
                                                        , txtNombreCampo.Text,TI.ToTitleCase(ddlTipoDato.SelectedValue.ToString().ToLower())
                                                        , Convert.ToInt32(txtTamaño.Text), txtTabla.Text,txtCampo.Text, txtObservacion.Text
                                                        , txtExpReg.Text,ref mensaje);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("La modificación fue exitosa!!!");
                        odsRegistro.Update();
                    }
                    else
                    {
                        Master.MensajeError("No se pudo realizar la modificación", mensaje);
                    }
                    //Response.Write("<script>window.alert('La modificación fue exitosa!!!');</script>");
                    /*gvwRegistros.DataBind();
                    gvwRegistros.SkinID = "GridView";*/
                    //System.Configuration.ConfigurationSettings.AppSettings["CTM"] = ddlMedios.SelectedValue.ToString();
                }
                catch (Exception ex)
                {
                    //Response.Write("<script>window.alert('No se pudo realizar la modificación " + ex.Message + "');</script>");
                    Master.MensajeError("No se pudo realizar la modificación", ex.Message);
                }
            }
            else
            {
                lblObservaciones.Text = "Debe llenar los campos necesarios";
            }

        }
        if (btnAccionar.Text == "Adicionar")
        {
            if (txtTabla.Text != "" && txtCampo.Text != "" && txtExpReg.Text != "" && ddlTipoDato.SelectedIndex>0)  // verifica que el campo llenado no sea nulo
            {
                try
                {
                    clsIntercambio ins = new clsIntercambio();
                    //int IdArchivoTM = Convert.ToInt32(ins.ListarTipoIntercambio(0, ddlMedios.SelectedValue.ToString())[0].IdArchivo);
                    /*ins.AdicionarRegistroIntercambio(IdArchivoTM, txtNombreCampo.Text,TI.ToTitleCase(ddlTipoDato.SelectedValue.ToString().ToLower()),
                        Convert.ToInt32(txtTamaño.Text),txtTabla.Text, txtCampo.Text, txtObservacion.Text, txtExpReg.Text);*/
                    string mensaje = null;
                    ins.RegistraCampoMedio((int)Session["IdConexion"],"I",ddlMedios.SelectedValue, txtNombreCampo.Text, TI.ToTitleCase(ddlTipoDato.SelectedValue.ToString().ToLower()),
                            Convert.ToInt32(txtTamaño.Text), txtTabla.Text, txtCampo.Text, txtObservacion.Text, txtExpReg.Text,ref mensaje);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se agregó el campo de medio exitosamente!!!");
                        //Response.Redirect("~/Medios/wfrmTipoRegistro.aspx",false);
                        odsRegistro.Update();
                    }
                    else
                    {
                        Master.MensajeError("No se pudo adicionar el tipo de medio", mensaje);
                    }
                    //Response.Write("<script>window.alert('Se agregó el campo de medio exitosamente!!!');</script>");
                    
                }
                catch (Exception ex)
                {
                    //Response.Write("<script>window.alert('No se pudo adicionar el tipo de medio " + ex.Message + "');</script>");
                    Master.MensajeError("No se pudo adicionar el tipo de medio", ex.Message);
                }
            }
            else
            {
                lblObservaciones.Text = "Debe llenar los campos necesarios";
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //Limpiar();
        Response.Redirect("~/Medios/wfrmTipoRegistro.aspx",true);
    }
    #endregion

    #region limpiarcampos
    //limpiar campos de tipo
    protected void Limpiar()
    {
        lblObservaciones.Text = "";
        txtNombreCampo.Text = "";
        txtTamaño.Text = "";
        txtTabla.Text = "";
        txtObservacion.Text = "";
        txtCampo.Text = "";
        txtExpReg.Text = "";
    }
   
    #endregion


    protected void imgCerrar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/wfrmTipoPrincipal.aspx");
    }

    protected void CargaTipoDato()
    {
        clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlTipoDato.DataSource = clas.ListarDetalleClasificador(39);
        ddlTipoDato.DataValueField = "DescripcionDetalleClasificador";
        ddlTipoDato.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoDato.DataBind();
        ddlTipoDato.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlTipoDato.SelectedValue = "0";
    }

    protected void CargaListaMedio()
    {
        clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlMedios.DataSource = clas.ListarDetalleClasificador(12);
        ddlMedios.DataValueField = "CodigoDetalleClasificador";
        ddlMedios.DataTextField = "DescripcionDetalleClasificador";
        ddlMedios.DataBind();
    }

    protected void CargarRegistroIntercambio(int IdRegistro, int fila)
    {
        txtNombreCampo.Text = HttpUtility.HtmlDecode(gvRegistros.Rows[fila].Cells[2].Text);
        ddlTipoDato.SelectedValue = gvRegistros.Rows[fila].Cells[3].Text.ToUpper();
        txtTamaño.Text = gvRegistros.Rows[fila].Cells[4].Text;
        txtTabla.Text = HttpUtility.HtmlDecode(gvRegistros.Rows[fila].Cells[5].Text.Replace("&nbsp;", ""));
        txtCampo.Text = HttpUtility.HtmlDecode(gvRegistros.Rows[fila].Cells[6].Text.Replace("&nbsp;", ""));
        txtObservacion.Text = HttpUtility.HtmlDecode(gvRegistros.Rows[fila].Cells[7].Text.Replace("&nbsp;", ""));
        txtExpReg.Text = HttpUtility.HtmlDecode(gvRegistros.Rows[fila].Cells[8].Text);
        hfIdArchivo.Value = IdRegistro.ToString();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Medios/wfrmTipoIntercambio.aspx",false);
    }

    protected void gvRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int32 v = 0;
        bool canConvert = Int32.TryParse(e.CommandArgument.ToString(), out v);
        if (canConvert == true)
        {
            int Indice = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "cmdEditar")
            {
                if (gvRegistros.Rows[Indice].Cells[9].Text == "Activo")
                {
                    IdArchivoRegistro = Convert.ToInt32(gvRegistros.DataKeys[Indice].Values["IdRegistro"]);
                    Limpiar();
                    btnAccionar.Text = "Modificar";
                    lblTitulo.Text = "Modificar el Tipo de Intercambio";
                    odsRegistro.Select();
                    int id = Convert.ToInt32(gvRegistros.DataKeys[Indice].Value);
                    CargaTipoDato();
                    CargarRegistroIntercambio(id, Indice);
                    this.pnlDatos_ModalPopupExtender.Show();
                }
                else
                {
                    Master.MensajeError("No se puede editar un registro que está inactivo", "Proceda activando el registro");
                }
            }
            if (e.CommandName == "cmdDesactivar")
            {
                clsIntercambio inter = new clsIntercambio();
                try
                {
                    int id = Convert.ToInt32(gvRegistros.DataKeys[Indice].Value);
                    string mensaje = null;
                    //inter.ModificarRegistroIntercambio("Desactivar", id, 0, "", "", 0, "", "", "", "");
                    inter.ModificaCampoMedio((int)Session["IdConexion"], "U", "Desactivar", id, "", "", "", 0
                            , gvRegistros.Rows[Indice].Cells[5].Text, gvRegistros.Rows[Indice].Cells[6].Text, "", "", ref mensaje);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se Habilitó/Deshabilitó el campo del tipo de medio.");
                        odsRegistro.Update();
                    }
                    else
                    {
                        Master.MensajeError("Error al Activar/Desactivar", mensaje);
                    }
                    //Response.Redirect("wfrmTipoRegistro.aspx");//para que no se vea ese mensaje de error
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al Activar/Desactivar", ex.Message);
                }
            }
        }
        else
        {
            string columna = e.CommandArgument.ToString();
            gvRegistros.Sort(columna, SortDirection.Descending);
            gvRegistros.DataBind();
        }
    }

    protected void gvRegistros_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvRegistros.Rows)
        {
            if (row.Cells[9].Text == "True" || row.Cells[9].Text == "1")
            {
                row.Cells[9].Text = "Activo";
                row.Cells[11].ToolTip = "Desactivar";
            }
            else
            {
                row.Cells[9].Text = "Inactivo";
                row.Cells[11].ToolTip = "Activar";
                ImageButton img = (ImageButton)row.Cells[11].Controls[0];
                img.ImageUrl = "~/Imagenes/iconos16x16/Undo_16x16.png";
            }
        }
    }
}