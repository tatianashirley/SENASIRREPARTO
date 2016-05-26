using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using wcfServicioIntercambioPago.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfConvenios.Logica;
using wfcDoblePercepcion.Logica;

public partial class Convenios_wfrmControlDeudas : System.Web.UI.Page
{
    string mensaje = null;
    clsInformacionLO Convenio = new clsInformacionLO();
    string Periodo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargaPeriodos();
            
        }
    }


    private void CargaPeriodos()
    {
        ddTipo.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDepositos", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        ddTipo.DataValueField = "ID";
        ddTipo.DataTextField = "TIPO";
        ddTipo.DataBind();
        ddTipo.Items.Insert(0, new ListItem("--", "0"));
        ddTipo.SelectedValue = "0";

        ddlTipoConvenio.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaTipoDeuda", "", "", "", "", "", "", ""
                                              , 0, 0, ref mensaje);
        ddlTipoConvenio.DataValueField = "IdDetalleClasificador";
        ddlTipoConvenio.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoConvenio.DataBind();
        ddlTipoConvenio.Items.Insert(0, new ListItem("TODOS", "0"));
        ddlTipoConvenio.SelectedValue = "0";

        DateTime fecha = DateTime.Now.Date;
        ddlAnio.Items.Capacity = 36;

        for (int x = 2008; x <= fecha.Year; x++)
        {
            ddlAnio.Items.Add(x.ToString());
            
        }

        ddlAnio.Items.Insert(0, new ListItem("--", "0"));
        ddlAnio.SelectedValue = "0";

    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        mensaje = null;
        /*string mes =ddlMes.SelectedItem.ToString();
        if (Convert.ToInt32(ddlMes.SelectedItem.ToString()) < 10)
            mes = "0" + ddlMes.SelectedItem.ToString();

        
        Periodo = ddlAnio.SelectedItem.ToString() + mes;
        */
        //string prueba = ddlTipoConvenio.SelectedItem.ToString();
        int tt = ddTipo.SelectedIndex;
        DataTable Pagos = Convenio.Pagos((int)Session["IdConexion"], "Q", ddlAnio.SelectedItem.ToString(), ddlTipoConvenio.SelectedItem.ToString(), 0, txtFechaInicio.Text, txtFechaFin.Text, tt, ref mensaje);
        if (mensaje == null)
        {
            Session["Pagos"] = Pagos;
            gvControl.Visible = true;
            gvControl.DataSource = Pagos;
            gvControl.DataBind();
            gvControl.RowDataBound += new GridViewRowEventHandler(gvControl_RowDataBound);
            gvDetalle.Visible = false;
            lblSubTitulo.Visible = false;
            pnlConvenio.Visible = true;
            PnlDetalle.Visible = false;
            btnVolver.Visible = false;
            btnAceptar.Visible = true;
            if (gvControl!=null && gvControl.Rows.Count != 0)
            {
                btnExportar.Visible = true;
            }
        }
        else
        { Master.MensajeError("Error a la Hora de Mostrar el Resultado", mensaje); }

    }
    protected void gvControl_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvControl.PageIndex = e.NewPageIndex;
        gvControl.DataSource = Session["Pagos"] as DataTable; ;
        gvControl.DataBind();
        gvControl.Visible = true;
    }
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        /*string mes = ddlMes.SelectedItem.ToString();
        if (Convert.ToInt32(ddlMes.SelectedItem.ToString()) < 10)
            mes = "0" + ddlMes.SelectedItem.ToString();
        Periodo = ddlAnio.SelectedItem.ToString() + mes;*/

        Session["id"] = ddTipo.SelectedIndex.ToString();
        Session["txtFechaInicio"] = txtFechaInicio.Text;
        Session["txtFechaFin"] = txtFechaFin.Text;
        Session["Anio"] = ddlAnio.SelectedValue.ToString();
        Session["informe"] = "rptPagosDeuda";
        Session["TipoDeuda"] = ddlTipoConvenio.SelectedItem.ToString();
        // Response.Redirect("wfrmReportePlanPagos.aspx");
        string script = "window.open('wfrmReportePlanPagos.aspx', '');";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
    }
    protected void gvControl_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int indice = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "cmdDetalle")
        {
            try
            {
                int tt = ddTipo.SelectedIndex;
                int RR = Convert.ToInt32(gvControl.Rows[indice].Cells[5].Text);
                DataTable Pagos = Convenio.Pagos((int)Session["IdConexion"], "C","","", RR,"","", tt, ref mensaje);
               
                if (mensaje == null)
                {
                    lblSubTitulo.Visible = true;
                    Session["PagosDetalle"] = Pagos;
                    gvDetalle.Visible = true;
                  //  gvControl.Visible = false;
                    pnlConvenio.Visible = false;
                    PnlDetalle.Visible = true;
                    btnVolver.Visible=true;
                    btnAceptar.Visible = false;
                    btnExportar.Visible = false;
                    gvDetalle.DataSource = Pagos;
                    gvDetalle.DataBind();

                    if (gvControl != null && gvControl.Rows.Count != 0)
                    {
                        btnExportar.Visible = true;
                        gvControl.RowDataBound += new GridViewRowEventHandler(gvControl_RowDataBound);
                    }
                }

                else
                { Master.MensajeError("Error a la Hora de Mostrar el Resultado", mensaje); }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Erro al Mostrar el Detalle del Deposito", ex.Message);
            }
        }
    }

    protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetalle.PageIndex = e.NewPageIndex;
        gvDetalle.DataSource = Session["PagosDetalle"] as DataTable; ;
        gvDetalle.DataBind();
        gvDetalle.Visible = true;
    }
    protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            switch (e.Row.Cells[17].Text)
            {
                case "A":
                    e.Row.BackColor = Color.FromName("#43F25D");
                    break;
                case "PR":
                    e.Row.BackColor = Color.FromName("#EBFF00");
                    break;
                case "M":
                    e.Row.BackColor = Color.FromName("#F79D9B");
                    break;
                case "P":
                    e.Row.BackColor = Color.FromName("#0DE3F6");
                    break;
            }
        }
    }

    protected void gvControl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[17].Text)
            {
                case "A":
                    e.Row.BackColor = Color.FromName("#43F25D");
                    break;
                case "PR":
                    e.Row.BackColor = Color.FromName("#EBFF00");
                    break;
                case "M":
                    e.Row.BackColor = Color.FromName("#F79D9B");
                    break;
                case "P":
                    e.Row.BackColor = Color.FromName("#0DE3F6");
                    break;
            }
        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        int tt = ddTipo.SelectedIndex;
        DataTable Pagos = Convenio.Pagos((int)Session["IdConexion"], "Q", ddlAnio.SelectedItem.ToString(), ddlTipoConvenio.SelectedItem.ToString(), 0, txtFechaInicio.Text, txtFechaFin.Text, tt, ref mensaje);
        if (mensaje == null)
        {
            Session["Pagos"] = Pagos;
            gvControl.Visible = true;
            gvControl.DataSource = Pagos;
            gvControl.DataBind();
            gvControl.RowDataBound += new GridViewRowEventHandler(gvControl_RowDataBound);
            gvDetalle.Visible = false;
            lblSubTitulo.Visible = false;
            pnlConvenio.Visible = true;
            PnlDetalle.Visible = false;
            btnVolver.Visible = false;
            btnAceptar.Visible = true;
            if (gvControl != null && gvControl.Rows.Count != 0)
            {
                btnExportar.Visible = true;
            }
        }
        else
        { Master.MensajeError("Error a la Hora de Mostrar el Resultado", mensaje); }
    }
}