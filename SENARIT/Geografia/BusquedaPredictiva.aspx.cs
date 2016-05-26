using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wcfGeo.Logica;

public partial class BusquedaPredictiva : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }

    protected void ListarPorLocalidad()
    {
        clsGeo admi = new clsGeo();
        gvGeo.DataSource = admi.ListarPorNombreLocalidadV(txtBuscarLocalidad.Text);
        gvGeo.DataBind();//.ListarFormulario solo codigo
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ListarPorLocalidad();
    }
    protected void gvGeo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblIDs.Text = "";
        string valor;
        
        GridViewRow row = gvGeo.SelectedRow;
        valor = row.Cells[1].Text;
        lblIDs.Text = lblIDs.Text + valor + " prov:";
        valor = row.Cells[3].Text;
        lblIDs.Text = lblIDs.Text + valor + " sec:";
        valor = row.Cells[5].Text;
        lblIDs.Text = lblIDs.Text + valor + " loc:";
        valor = row.Cells[7].Text;
        lblIDs.Text = lblIDs.Text + valor;
    }
}