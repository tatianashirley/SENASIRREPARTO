using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfInicioTramite.Tramite.Logica;

public partial class InicioTramite_wfrmReimpReporte : System.Web.UI.Page
{
    #region inicio

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblTituloSistema.Text = "MODULO REPORTES TRÁMITE";
            lblSubTitulo.Text = "Buscar Trámite";
            pnlRegistrosCabecera.Visible = false;
            //deshabilitar el Autocompletar
            txtCuaBuscar.Attributes.Add("autocomplete", "off");
            txtMaternoBuscar.Attributes.Add("autocomplete", "off");
            txtMatriculaBuscar.Attributes.Add("autocomplete", "off");
            txtNumDocBuscar.Attributes.Add("autocomplete", "off");
            txtNumTramiteBuscar.Attributes.Add("autocomplete", "off");
            txtPaternoBuscar.Attributes.Add("autocomplete", "off");
            txtPrimerNormbreBuscar.Attributes.Add("autocomplete", "off");
            txtSegundoNombreBuscar.Attributes.Add("autocomplete", "off");
        }
    }

    #endregion

    #region botones

    //Boton buscar tramite
    protected void imgbtnBuscar_Click(object sender, EventArgs e)
    {
        if (Validacion())
        {
            BuscarTramite();
        }
    }

    //Boton limpiar busqueda
    protected void imgbtnBorrar_Click(object sender, EventArgs e)
    {
        this.txtPrimerNormbreBuscar.Text = "";
        this.txtSegundoNombreBuscar.Text = "";
        this.txtPaternoBuscar.Text = "";
        this.txtMaternoBuscar.Text = "";
        this.txtNumDocBuscar.Text = "";
        this.txtMatriculaBuscar.Text = "";
        this.txtCuaBuscar.Text = "";
        this.txtNumTramiteBuscar.Text = "";
        this.pnlRegistrosCabecera.Visible = false;
        this.txtPaternoBuscar.Focus();
    }

    #endregion

    #region funciones

    // Validar de datos de entrada
    protected bool Validacion()
    {
        string sError;
        string sDetalleError;
        sError = "Error al realizar la operación.";
        //Validar algun dato
        if (String.IsNullOrEmpty(this.txtPaternoBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtMaternoBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtPrimerNormbreBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtSegundoNombreBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtNumDocBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtCuaBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtNumTramiteBuscar.Text.Trim())
            && String.IsNullOrEmpty(this.txtMatriculaBuscar.Text.Trim()))
        {
            sDetalleError = "Debe ingresar un criterio de búsqueda.";
            Master.MensajeError(sError, sDetalleError);
            return false;
        }
        return true;
    }

    private void BuscarTramite()
    {
        DataTable dtTramites = new DataTable();
        try
        {
            dtTramites = buscarTramitesRenuncia("Modificacion");
            gvBusquedaTramiteCC.DataSource = dtTramites;
            gvBusquedaTramiteCC.DataBind();
            pnlRegistrosCabecera.Visible = true;
            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }

    //Buscar Tramites
    protected DataTable buscarTramitesRenuncia(string estadotramite)
    {
        string sMensajeError = "";
        int iIdConexion = (int)Session["IdConexion"];
        string iIdTramite = "0";
        string cOperacion = "Q";
        DataTable dtListaPersonas = null;
        clsTramite objTramite = new clsTramite();
        if (!String.IsNullOrEmpty(txtNumTramiteBuscar.Text.Trim()))
        {
            iIdTramite = txtNumTramiteBuscar.Text.Trim();
        }
        else
        {
            iIdTramite = "0";
        }
        dtListaPersonas = objTramite.BuscarTramite(iIdConexion, cOperacion, iIdTramite, 3, this.txtPrimerNormbreBuscar.Text.Trim(), this.txtSegundoNombreBuscar.Text.Trim(), this.txtPaternoBuscar.Text.Trim(), this.txtMaternoBuscar.Text.Trim(), txtNumDocBuscar.Text.Trim(), txtCuaBuscar.Text.Trim(), this.txtMatriculaBuscar.Text.Trim(), estadotramite, ref sMensajeError);

        return dtListaPersonas;
    }

    #endregion

    #region grilla

    protected void gvBusquedaTramiteCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        System.Console.WriteLine("");
        /*if (e.CommandName == "cmdReporte1")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string sTramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            string contentUrl = "wfrmReport.aspx";
            //Response.Redirect(contentUrl + "?tramite=" + sTramite);  
        }
        if (e.CommandName == "cmdReporte2")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            //string sTramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            //string contentUrl = "wfrmReportForm02.aspx";
            //Response.Redirect(contentUrl + "?tramite=" + sTramite);
        }
        if (e.CommandName == "cmdReporte3")
        {
            Index = Convert.ToInt32(e.CommandArgument);
            string sTramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[Index].Values["IdTramite"]);
            string contentUrl = "wfrmReportForm03.aspx";
            //Response.Redirect(contentUrl + "?tramite=" + sTramite);
        }*/
    }

    protected void gvBusquedaTramiteCC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Idtramite = Convert.ToString(gvBusquedaTramiteCC.DataKeys[e.Row.RowIndex].Values["IdTramite"]);
            ImageButton imgReporte1 = (ImageButton)e.Row.FindControl("imgReporte1");
            ImageButton imgReporte2 = (ImageButton)e.Row.FindControl("imgReporte2");
            ImageButton imgReporte3 = (ImageButton)e.Row.FindControl("imgReporte3");
            imgReporte1.Visible = true;
            imgReporte1.OnClientClick = "window.open('wfrmReport.aspx?tramite=" + Idtramite + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
            imgReporte2.Visible = true;
            imgReporte2.OnClientClick = "window.open('wfrmReportForm02.aspx?tramite=" + Idtramite + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
            imgReporte3.Visible = true;
            imgReporte3.OnClientClick = "window.open('wfrmReportForm03.aspx?tramite=" + Idtramite + "', 'reporte','menubar=no,toolbar=no,statusbar=no,scrollbars=yes,height=10,width=10,left=0,top=0'); return false;";
        }
    }

    protected void gvBusquedaTramiteCC_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView gvBusquedaTramiteCC = (GridView)sender;
        gvBusquedaTramiteCC.PageIndex = e.NewSelectedIndex;
        gvBusquedaTramiteCC.DataBind();
    }

    protected void gvBusquedaTramiteCC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBusquedaTramiteCC.PageIndex = e.NewPageIndex;
        BuscarTramite();
    }

    #endregion

}