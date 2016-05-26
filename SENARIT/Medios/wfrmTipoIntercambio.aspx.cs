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
using wcfServicioIntercambioPago.Logica;
using WcfServicioClasificador.Logica;

using System.Drawing;

public partial class Medios_wfrmTipoIntercambio : System.Web.UI.Page
{
    int IdArchivoIntercambio;
    DataTable TiposIntercambio;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!Page.IsPostBack)
        {
            //string piel = gvwTiposIntercambio.SkinID;
            gvTiposIntercambio.DataBind();
         }
       //CargarTipoIntercambio();
    }
    #region botonesprincipal

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de Tipo Intercambio";
        CargaTipoMedio();
        this.pnlDatos_ModalPopupExtender.Show();
      
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        if (btnAccionar.Text == "Modificar")
        {
            if (txtExpReg.Text != "" && txtAlta.Text != "" && txtTablaTemp.Text != "" && ddlTipoMedio.SelectedIndex>0)  // verifica que el campo llenado no sea nulo
            {
                try
                {
                    clsIntercambio mod = new clsIntercambio();
                    /*mod.ModificarTipoIntercambio("Modificar", Convert.ToInt32(lblIdArchivo.Text), 300 , txtDescripcion.Text,
                        txtPrefijo.Text, txtFormato.Text, ddlTipoMedio.SelectedValue.ToString(), txtExtension.Text, txtExpReg.Text, txtTablaTemp.Text,
                        txtTablaFin.Text, txtProcedimiento.Text, txtAlta.Text, txtBaja.Text);*/
                    string mensaje = null;
                    mod.ModificaTipoMedio((int)Session["IdConexion"], "U", "Modificar", Convert.ToInt32(hdIdArchivo.Value), 1500040, txtDescripcion.Text,
                        txtPrefijo.Text, txtFormato.Text, ddlTipoMedio.SelectedValue.ToString(), txtExtension.Text, txtExpReg.Text, txtTablaTemp.Text,
                        txtTablaFin.Text, txtProcedimiento.Text, txtAlta.Text, txtBaja.Text, ref mensaje);
                    //Response.Write("<script>window.alert('La modificación fue exitosa!!!');</script>");
                    if (mensaje == null)
                    {
                        Master.MensajeOk("La modificación fue exitosa!!!");
                        odsIntercambioMedio.Update();
                    }
                    else
                    {
                        Master.MensajeError("No se pudo realizar la modificación", "mensaje");
                    }
                    //Response.Redirect("~/Medios/wfrmTipoIntercambio.aspx",true);
                }
                catch (Exception ex)
                {
                    //Response.Write("<script>window.alert('No se pudo realizar la modificación " + ex.Message + "');</script>");
                    Master.MensajeError("No se pudo realizar la modificación.", ex.Message);
                }
            }
            else
            {
                lblObservaciones.Text = "Debe llenar los campos necesarios";
            }

        }
        if (btnAccionar.Text == "Adicionar")
        {
            if (txtExpReg.Text != "" && txtAlta.Text != "" && txtTablaTemp.Text != "" && ddlTipoMedio.SelectedIndex > 0)  // verifica que el campo llenado no sea nulo
            {
                try
                {
                    clsIntercambio ins = new clsIntercambio();
                    /*ins.AdicionarTipoIntercambio(1500040, txtDescripcion.Text, txtPrefijo.Text, txtFormato.Text, ddlTipoMedio.SelectedValue.ToString()
                                                , txtExtension.Text, txtExpReg.Text, txtTablaTemp.Text, txtTablaFin.Text, txtProcedimiento.Text
                                                , txtAlta.Text, txtBaja.Text);*/
                    string mensaje = null;
                    ins.RegistraTipoMedio((int)Session["IdConexion"], "I", 1500040, txtDescripcion.Text, txtPrefijo.Text, txtFormato.Text, ddlTipoMedio.SelectedValue.ToString()
                                                , txtExtension.Text, txtExpReg.Text, txtTablaTemp.Text, txtTablaFin.Text, txtProcedimiento.Text
                                                , txtAlta.Text, txtBaja.Text,ref mensaje);
                    //Response.Write("<script>window.alert('Se agregó el tipo de medio exitosamente!!!');</script>");
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se agregó el tipo de medio exitosamente!!!");
                        odsIntercambioMedio.Update();
                    }
                    else
                    {
                        Master.MensajeError("Hubo un error al intentar adicionar el medio", mensaje);
                    }
                    //Response.Redirect("~/Medios/wfrmTipoIntercambio.aspx",true);
                }
                catch (Exception ex)
                {
                    //Response.Write("<script>window.alert('No se pudo adicionar el tipo de medio " + ex.Message + "');</script>");
                    Master.MensajeError("Hubo un error al intentar adicionar el medio", ex.Message);
                }
            }
            else
            {
                lblObservaciones.Text = "Debe llenar los campos necesarios";
                pnlDatos_ModalPopupExtender.Show();
            }
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
        
    }
    #endregion

    #region limpiarcampos
    //limpiar campos de tipo
    protected void Limpiar()
    {
        //txtNombreIntercambio.Text = "";
        lblObservaciones.Text = "";
        
    }
   
    #endregion


    protected void imgCerrar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/wfrmPrincipal.aspx");
    }

    protected void CargaTipoMedio()
    {
        clsDetalleClasificador clas = new clsDetalleClasificador();
        ddlTipoMedio.DataSource = clas.ListarDetalleClasificador(12);
        ddlTipoMedio.DataValueField = "CodigoDetalleClasificador";
        ddlTipoMedio.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoMedio.DataBind();
        ddlTipoMedio.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlTipoMedio.SelectedValue = "0";
    }

    protected void CargarTipoIntercambio()
    {
        clsServicioIntercambio Inter = new clsServicioIntercambio();
        string mensaje = null;
        TiposIntercambio = Inter.ListarTipoMedio((int)Session["IdConexion"], "Q", 0, "TODOS", ref mensaje);
        gvTiposIntercambio.DataSource = TiposIntercambio;
        gvTiposIntercambio.DataBind();
    }

    //protected void gvwTiposIntercambio_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    clsIntercambio inter = new clsIntercambio();
    //    int id = Convert.ToInt32(gvwTiposIntercambio.DataKeys[e.RowIndex].Value);
    //    bool resp = inter.EliminarTipoIntercambio(id);
    //    Response.Redirect("~/Medios/wfrmTipoIntercambio.aspx", true);//para que no se vea ese mensaje de error
    //}

    //protected void gvwTiposIntercambio_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    IdArchivoIntercambio = Convert.ToInt32(gvwTiposIntercambio.DataKeys[e.NewEditIndex].Values["IdArchivo"]);
    //    Limpiar();
    //    btnAccionar.Text = "Modificar";
    //    lblTitulo.Text = "Modificar el Tipo de Intercambio";
    //    odsIntercambioMedio.Select();
    //    int id = Convert.ToInt32(gvwTiposIntercambio.DataKeys[e.NewEditIndex].Value);
    //    CargarTipoIntercambio(id,e.NewEditIndex);
    //    CargaTipoMedio();
    //    this.pnlDatos_ModalPopupExtender.Show();
    //}

    protected void CargarTipoIntercambio(int IdTipointercambio, int fila)
    {
        ddlTipoMedio.SelectedValue = gvTiposIntercambio.Rows[fila].Cells[5].Text;
        txtDescripcion.Text = HttpUtility.HtmlDecode(gvTiposIntercambio.Rows[fila].Cells[2].Text);
        txtPrefijo.Text = gvTiposIntercambio.Rows[fila].Cells[3].Text;
        txtFormato.Text = gvTiposIntercambio.Rows[fila].Cells[4].Text;
        txtExtension.Text = gvTiposIntercambio.Rows[fila].Cells[6].Text;
        txtExpReg.Text = HttpUtility.HtmlDecode(gvTiposIntercambio.Rows[fila].Cells[7].Text);
        txtTablaTemp.Text = HttpUtility.HtmlDecode(gvTiposIntercambio.Rows[fila].Cells[8].Text);
        txtTablaFin.Text = HttpUtility.HtmlDecode(gvTiposIntercambio.Rows[fila].Cells[9].Text.Replace("&nbsp;", ""));
        txtProcedimiento.Text = HttpUtility.HtmlDecode(gvTiposIntercambio.Rows[fila].Cells[10].Text.Replace("&nbsp;", ""));
        txtAlta.Text = gvTiposIntercambio.Rows[fila].Cells[11].Text;
        txtBaja.Text = gvTiposIntercambio.Rows[fila].Cells[12].Text.Replace("&nbsp;", "");
        hdIdArchivo.Value = gvTiposIntercambio.DataKeys[fila].Values["IdArchivo"].ToString();
    }

    protected void imgRegistros_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Medios/wfrmTipoRegistro.aspx",false);
    }

    protected void gvwTiposIntercambio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Int32 v = 0;
        bool canConvert = Int32.TryParse(e.CommandArgument.ToString(), out v);
        if (canConvert == true)
        {
            int Indice = Convert.ToInt32(e.CommandArgument);
            int IdArhcivoMedio = Convert.ToInt32(gvTiposIntercambio.DataKeys[Indice].Values["IdArchivo"]);
            if (e.CommandName == "cmdEditar")
            {
                if (gvTiposIntercambio.Rows[Indice].Cells[13].Text == "Activo")
                {
                    //IdArchivoIntercambio = Convert.ToInt32(gvTiposIntercambio.DataKeys[Indice].Values["IdArchivo"]);
                    btnAccionar.Text = "Modificar";
                    lblTitulo.Text = "Modificar el Tipo de Intercambio";
                    int id = Convert.ToInt32(gvTiposIntercambio.DataKeys[Indice].Value);
                    CargaTipoMedio();
                    CargarTipoIntercambio(id, Indice);
                    ddlTipoMedio.Enabled = false;
                    this.pnlDatos_ModalPopupExtender.Show();
                }
                else
                {
                    Master.MensajeError("No se puede editar un registro que está inactivo", "Proceda activando el registro");
                }
            }
            if (e.CommandName == "cmdDesactivar")
            {
                try
                {
                    clsIntercambio inter = new clsIntercambio();
                    int id = Convert.ToInt32(gvTiposIntercambio.DataKeys[Indice].Value);
                    //inter.ModificarTipoIntercambio("Desactivar", id, 300, "", "", "", "", "", "", "", "", "", "", "");
                    string mensaje = null;
                    inter.ModificaTipoMedio((int)Session["IdConexion"], "U", "Desactivar", id, 1500040, "", "", ""
                                                        , gvTiposIntercambio.Rows[Indice].Cells[5].Text, "", "", "", "", "", "", "", ref mensaje);
                    if (mensaje == null)
                    {
                        Master.MensajeOk("Se Habilitó/Deshabilitó el tipo de medio.");                   
                        odsIntercambioMedio.Update();
                    }
                    else
                    {
                        Master.MensajeError("No se pudo cambiar el estado de la excepción.", mensaje);
                    }
                    //Response.Redirect("~/Medios/wfrmTipoIntercambio.aspx", true);//para que no se vea ese mensaje de error
                }
                catch (Exception ex)
                {
                    Master.MensajeError("No se pudo cambiar el estado de la excepción.", ex.Message);
                }
            }
        }
        else
        {
            string columna = e.CommandArgument.ToString();
            gvTiposIntercambio.Sort(columna, SortDirection.Descending);
            gvTiposIntercambio.DataBind();
        }
    }
    protected void gvTiposIntercambio_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvTiposIntercambio.Rows)
        {
            if (row.Cells[13].Text == "True" || row.Cells[13].Text == "1")
            {
                row.Cells[13].Text = "Activo";
                row.Cells[15].ToolTip = "Desactivar";
            }
            else
            {
                row.Cells[13].Text = "Inactivo";
                row.Cells[15].ToolTip = "Activar";
                ImageButton img = (ImageButton)row.Cells[15].Controls[0];
                img.ImageUrl = "~/Imagenes/iconos16x16/Undo_16x16.png";
            }
        }
    }
}