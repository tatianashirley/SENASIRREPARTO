
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wcfEmisionCertificadoCC.Logica;
using WcfServicioClasificador.Logica;
public partial class EmisionCertificadoCC_wfrmTipoCambioConvenios : System.Web.UI.Page
{
    clsTipoCambio Resolucion = new clsTipoCambio();
    string mensaje;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;
            CargarComboMoneda();
            ListarRegistros();
        }
    }

    // LISTA LOS REGISTROS Y COLOCA EN GRILLA
    protected void ListarRegistros()
    {
        gvTipo.DataSource = Resolucion.ListarTiposdeCambios((int)Session["IdConexion"], "M",2, ref mensaje);
        gvTipo.DataBind();
    }
    // LIMPIA LOS REGISTROS 
    protected void Limpiarventana()
    {
        txtTasaCambio.Text = "";
        txtFechaCom.Text = "";
        txtDetalle.Text = "";
    }
    // CARGAR COMBO MONEDA
    protected void CargarComboMoneda()
    {

        ddlMoneda.DataSource = Resolucion.ListarTiposMoneda((int)Session["IdConexion"], "B", ref mensaje);
        ddlMoneda.DataValueField = "IdDetalleClasificador";
        ddlMoneda.DataTextField = "Descripcion";
        ddlMoneda.DataBind();
    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipo.PageIndex = e.NewPageIndex;
        ListarRegistros();
    }

    //RECUPERA LOS DATOS PARA VERLOS
    private void VerDatos(Int32 IdMoneda,string Fecha)
    {
        //Obtiene Datos para su Modificacion
        DataTable TipoResolucion = Resolucion.DatosTipoCambio((int)Session["IdConexion"], "N",IdMoneda,Fecha, ref mensaje);
        ddlMoneda.SelectedValue = TipoResolucion.Rows[0]["IdMoneda"].ToString();
        txtFechaCom.Text = TipoResolucion.Rows[0]["Fecha"].ToString();  
        txtTasaCambio.Text = TipoResolucion.Rows[0]["TasaCambio"].ToString();
        txtDetalle.Text = TipoResolucion.Rows[0]["ObservacionTasaCambio"].ToString();
    }

    # region botonespopup

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiarventana();
        ListarRegistros();
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {   
        int valorverificar = Convert.ToInt32(Resolucion.DatosTipoCambio((int)Session["IdConexion"],"O",Convert.ToInt32(ddlMoneda.SelectedValue),txtFechaCom.Text,ref mensaje).Rows[0]["existedatos"]);
        if (btnAccionar.Text == "Adicionar")
        {      
           if (valorverificar == 0) // si no existen datos para ese periodo
                {
                    if(Resolucion.InsertaTipoCambio((int)Session["IdConexion"], "P",Convert.ToInt32(ddlMoneda.SelectedValue), txtFechaCom.Text,  txtTasaCambio.Text, txtDetalle.Text, ref mensaje))
                    {   
                        Limpiarventana();
                        ListarRegistros();
                    }
                    else
                    {
                      Limpiarventana();
                      ListarRegistros();
                      Master.MensajeError("Error al realizar la operacion", mensaje);
                    }
                }
                else
                {
                    Master.MensajeError("Error al realizar la operacion", "Ya existe el Tipo de Cambio");
                }
            }
        if (btnAccionar.Text == "Modificar") // CUANDO EL BOTON ES Modificar
        {
            if (valorverificar == 0) // si no existen 
            {
                if(Resolucion.ActualizaTipoCambio((int)Session["IdConexion"], "R",txtFechaCom.Text, Convert.ToInt32(ddlMoneda.SelectedValue), txtTasaCambio.Text, txtDetalle.Text, ref mensaje))
                {
                    Master.MensajeOk("Se realizo operacion satisfacoriamente");
                    Limpiarventana();
                    ListarRegistros();
                }
                else
                {
                    Master.MensajeError("Error al realizar la Operacion", mensaje);
                    Limpiarventana();
                    ListarRegistros();
                }

            }
            else //si existen
            {
                ListarRegistros();
            }
        }
}
    #endregion

    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiarventana();
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de Tipo de cambio";
        txtFechaCom.Text = "";
        txtTasaCambio.Text = "";
        CargarComboMoneda();
        ddlMoneda.Enabled = true;
        txtTasaCambio.Enabled = true;
        txtDetalle.Text = "";
        this.pnlDatos_ModalPopupExtender.Show();
    }
    #endregion

    # region eventos

    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }

    protected void gvTipo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));
        }
    }
  
    #endregion

    protected void gvTipo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index = Convert.ToInt32(e.CommandArgument);
        string valor;
        int val;
        GridViewRow row = gvTipo.Rows[Index];
        val = row.RowIndex;
        Limpiarventana();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion de Tipo de Cambio ";
        ddlMoneda.Enabled = true;
        txtTasaCambio.Enabled = true;
        txtFechaCom.Enabled = false;
        VerDatos(Convert.ToInt32(gvTipo.DataKeys[Index]["IdMoneda"]), gvTipo.DataKeys[Index]["Fecha"].ToString());
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {

        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}