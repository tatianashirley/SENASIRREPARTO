using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using wcfEnvioAPS.Logica;

public partial class EnvioAPS_wfrmRemisionDeTramites : System.Web.UI.Page
{
    clsContrlEnvios objContrlEnvios = new clsContrlEnvios();
    
    int IdConexion;
    string sMensajeError = null;
    string NumeroEnvioDetalleEnvioAPS;
    string Sort_Direction = "NumeroEnvio DESC";

    private String FechaCorte
    {
        get
        {
            object obj = ViewState["FechaCorte"];
            return (obj == null) ? String.Empty : (string)obj;
        }
        set { ViewState["FechaCorte"] = value; }
    }

    private String vNumeroEnvio
    {
        get { object obj = ViewState["vNumeroEnvio"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["vNumeroEnvio"] = value; }
    }
    private Int32 vIdEntidad
    {
        get { return Int32.Parse(ViewState["vIdEntidad"].ToString()); }
        set { ViewState["vIdEntidad"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];
            //IdConexion = 4039;
            //IdConexion = 5679;
        }
        if (!Page.IsPostBack)
        {
            ViewState["SortExpr"] = Sort_Direction;

            txtFechaCorte.Text = FechaCorte;

            objContrlEnvios.iIdConexion = IdConexion;
            ddlEntidades.DataTextField = "DescripcionDetalleClasificador";
            ddlEntidades.DataValueField = "IdDetalleClasificador";
            ddlEntidades.DataSource = objContrlEnvios.ListaEntidades(16);
            ddlEntidades.DataBind();
            ddlEntidades.Items.Add(new ListItem("Todos (*)", "00"));
            ddlEntidades.ClearSelection(); //making sure the previous selection has been cleared
            ddlEntidades.Items.FindByValue("00").Selected = true;

            objContrlEnvios.iIdConexion = IdConexion;
            if (objContrlEnvios.ListaNumeroEnviosRegistradosAPS())
            {
                ddlNumeroEnvios.DataTextField = "NumeroEnvio";
                ddlNumeroEnvios.DataValueField = "NumeroEnvio";
                ddlNumeroEnvios.DataSource = objContrlEnvios.DSet.Tables[0];
                ddlNumeroEnvios.DataBind();
                ddlNumeroEnvios.Items.Add(new ListItem("Todos (*)", "00"));
                ddlNumeroEnvios.ClearSelection(); //making sure the previous selection has been cleared
                ddlNumeroEnvios.Items.FindByValue("00").Selected = true;
            }
            else
            {
                //Error
                string DetalleError = objContrlEnvios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }

            //Carga_gvEnvios();
        }
    }
    private void Llena_gvEnvioDeMedios(string SFechaCorte, int IdEntidad, string NumeroEnvio)
    {
        if (SFechaCorte.Length == 0)
        {
            FechaCorte = String.Format("{0:dd/MM/yyyy}", "01/01/1919");
        }
        else
        {
            FechaCorte = SFechaCorte;
        }

        DataTable listado1 = new DataTable();
        objContrlEnvios.iIdConexion = IdConexion;
        objContrlEnvios.fFechaCorte = Convert.ToDateTime(FechaCorte);
        objContrlEnvios.iIdEntidad = IdEntidad;
        objContrlEnvios.sNumeroEnvio = NumeroEnvio;
        if (objContrlEnvios.ListaMediosEnviados())
        {
            listado1 = objContrlEnvios.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objContrlEnvios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        if (listado1.Rows.Count > 0)
        {
            DataView dvlistado1 = listado1.DefaultView;
            dvlistado1.Sort = ViewState["SortExpr"].ToString();
            gvEnvioDeMedios.DataSource = dvlistado1;
        }
        gvEnvioDeMedios.DataBind();
    }
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Llena_gvEnvioDeMedios(txtFechaCorte.Text, Int32.Parse(ddlEntidades.SelectedItem.Value), ddlNumeroEnvios.SelectedItem.Text);
        gvEnvioDeMedios.SelectedIndex = -1;
        gvEnvioDeMediosDetalle.Visible = false;
    }
    protected void imgImprimir_Click(object sender, ImageClickEventArgs e)
    {
        Session["fFechaCorte"] = FechaCorte;
        Session["iIdEntidad"] = Int32.Parse(ddlEntidades.SelectedItem.Value);
        Session["sNumeroEnvio"] = ddlNumeroEnvios.SelectedItem.Text;
        //Response.Redirect(@"~/EnvioAPS/wfrmRepCtrlCites2.aspx");
        Response.Redirect(@"~/EnvioAPS/wfrmRepCtrlCites.aspx");
    }
    protected void gvEnvioDeMedios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEnvioDeMedios.PageIndex = e.NewPageIndex;
        Llena_gvEnvioDeMedios(txtFechaCorte.Text, Int32.Parse(ddlEntidades.SelectedItem.Value), ddlNumeroEnvios.SelectedItem.Text);
        gvEnvioDeMedios.SelectedIndex = -1;
        gvEnvioDeMediosDetalle.Visible = false;
    }
    protected void gvEnvioDeMedios_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
        }
        Llena_gvEnvioDeMedios(txtFechaCorte.Text, Int32.Parse(ddlEntidades.SelectedItem.Value), ddlNumeroEnvios.SelectedItem.Text);
    }
    protected void btnGrabaCite_Click(object sender, EventArgs e)
    {
        string NumeroEnvio = lblNumeroEnvio.Text;
        int IdEntidad = Convert.ToInt32(lblIdEntidad.Text);
        int NumeroCite = Convert.ToInt32(txtNumeroCite.Text);
        string FechaCite = txtFechaCite.Text;
        string FechaRecepcion = txtFechaRecepcion.Text;

        objContrlEnvios.iIdConexion = IdConexion;
        objContrlEnvios.sNumeroEnvio = NumeroEnvio;
        objContrlEnvios.iIdEntidad = IdEntidad;
        objContrlEnvios.iNumeroCite = NumeroCite;
        objContrlEnvios.fFechaCite = Convert.ToDateTime(FechaCite);
        objContrlEnvios.fFechaRecepcion = Convert.ToDateTime(FechaRecepcion);
        if (!objContrlEnvios.ActualizaCitesEnvioAPS())
        {
            //Error
            string DetalleError = objContrlEnvios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        Llena_gvEnvioDeMedios(txtFechaCorte.Text, Int32.Parse(ddlEntidades.SelectedItem.Value), ddlNumeroEnvios.SelectedItem.Text);
    }
    protected void gvEnvioDeMedios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string NumeroEnvio = gvEnvioDeMedios.DataKeys[e.Row.RowIndex].Value.ToString();
            int IdEntidad = Convert.ToInt32(gvEnvioDeMedios.DataKeys[e.Row.RowIndex]["IdEntidad"]);
            string Entidad = e.Row.Cells[4].Text;

            DataTable listado1 = new DataTable();
            listado1 = objContrlEnvios.RemisionEnviosAPS_ArchivoCentral(IdConexion, NumeroEnvio, IdEntidad);
            
            int NumeroCite = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NumeroCite"));
            if (NumeroCite == -1 || NumeroCite > 0)
            {
                ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1");
                ImageButton1.ImageUrl = "~/Imagenes/16AttachDocumentSecure.gif";
                ImageButton1.CommandName = "REGISTRADO";
                ImageButton1.Enabled = false;
                ImageButton imgRemiteTramites = (ImageButton)e.Row.FindControl("imgRemiteTramites");
                imgRemiteTramites.Visible = false;
            }
            else
            {
                ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1");
                ImageButton1.ImageUrl = "~/Imagenes/16AttachDocumentSecurityDoubtful.gif";
                ImageButton1.CommandName = "REGISTRAR";
                ImageButton1.Enabled = true;
                if (listado1.Rows.Count > 0)
                {
                    ImageButton imgRemiteTramites = (ImageButton)e.Row.FindControl("imgRemiteTramites");
                    imgRemiteTramites.Visible = true;
                }
                else
                {
                    ImageButton imgRemiteTramites = (ImageButton)e.Row.FindControl("imgRemiteTramites");
                    imgRemiteTramites.Visible = false;
                }
            }
        }
    }
    protected void gvEnvioDeMedios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "REGISTRAR")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton ImageButton1 = (ImageButton)gvEnvioDeMedios.Rows[index].FindControl("ImageButton1");

            GridViewRow gRow = (GridViewRow)ImageButton1.NamingContainer;
            lblNumeroEnvio.Text = gvEnvioDeMedios.DataKeys[gRow.RowIndex].Value.ToString();
            lblIdEntidad.Text = gvEnvioDeMedios.DataKeys[gRow.RowIndex]["IdEntidad"].ToString();
            lblEntidad.Text = gRow.Cells[2].Text;
            txtNumeroCite.Text = gRow.Cells[3].Text;
            txtFechaCite.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            txtFechaRecepcion.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);

            gvEnvioDeMedios.SelectedIndex = index;

            ModalPopupExtender1.Show();
        }
        if (e.CommandName == "DETALLE01")
        {
            Master.MensajeCancel();
            gvEnvioDeMediosDetalle.Visible = true;

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgDetTramite = (ImageButton)gvEnvioDeMedios.Rows[index].FindControl("imgDetTramite");
            GridViewRow gRow = (GridViewRow)imgDetTramite.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvEnvioDeMedios.SelectedIndex = index;

            vNumeroEnvio = gvEnvioDeMedios.DataKeys[gRow.RowIndex]["NumeroEnvio"].ToString();
            vIdEntidad = Int32.Parse(gvEnvioDeMedios.DataKeys[gRow.RowIndex]["IdEntidad"].ToString());

            //vFechaIngreso = DateTime.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioDestinoNew = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["IdUsuarioDestinoNew"].ToString());
            //vIdUsuarioDestino = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["IdUsuarioDestino"].ToString());
            //vIdAreaDestino = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["IdAreaDestino"].ToString());

            CargaEnvioDeMediosDetalle(vNumeroEnvio, vIdEntidad);
        }
        if (e.CommandName == "REMITE")
        {
            Master.MensajeCancel();
            gvEnvioDeMediosDetalle.Visible = false;

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgRemiteTramites = (ImageButton)gvEnvioDeMedios.Rows[index].FindControl("imgRemiteTramites");
            GridViewRow gRow = (GridViewRow)imgRemiteTramites.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            vNumeroEnvio = gvEnvioDeMedios.DataKeys[gRow.RowIndex]["NumeroEnvio"].ToString();
            vIdEntidad = Int32.Parse(gvEnvioDeMedios.DataKeys[gRow.RowIndex]["IdEntidad"].ToString());

            objContrlEnvios.iIdConexion = IdConexion;
            objContrlEnvios.sNumeroEnvio = vNumeroEnvio;
            objContrlEnvios.iIdEntidad = vIdEntidad;
            if (objContrlEnvios.RemisionDeTramites())
            {
                Master.MensajeOk("Se Remitieron los tramites del Envío Numero: " + vNumeroEnvio + " a Archivo Central");
                Llena_gvEnvioDeMedios(txtFechaCorte.Text, Int32.Parse(ddlEntidades.SelectedItem.Value), ddlNumeroEnvios.SelectedItem.Text);
            }
            else
            {
                //Error
                string DetalleError = objContrlEnvios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "Reporte01")
        {
            //ButtonField
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            string NumeroEnvio = gvEnvioDeMedios.DataKeys[currentRowIndex].Value.ToString();
            string IdEntidad = gvEnvioDeMedios.DataKeys[currentRowIndex]["IdEntidad"].ToString(); ;

            Session["NumeroEnvioReporte"] = NumeroEnvio;
            Session["IdEntidad"] = IdEntidad;
            Response.Redirect("wfrmRepRMCC01.aspx");

            //Response.Write("<script>");
            //Response.Write("window.open('wfrmControlDeEnvios.aspx','_blank')");
            //Response.Write("</script>");
        }
    }
    private DataTable TramitesEnvioDeMediosDetalle(string NumeroEnvio, int IdEntidad)
    {
        DataTable listado1 = new DataTable();

        objContrlEnvios.iIdConexion = IdConexion;
        objContrlEnvios.sNumeroEnvio = NumeroEnvio;
        objContrlEnvios.iIdEntidad = IdEntidad;
        if (objContrlEnvios.TramitesEnvioDeMediosDetalle())
        {
            listado1 = objContrlEnvios.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objContrlEnvios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        return listado1;
    }
    protected void CargaEnvioDeMediosDetalle(string NumeroEnvio, int IdEntidad)
    {
        gvEnvioDeMediosDetalle.DataSource = TramitesEnvioDeMediosDetalle(NumeroEnvio, IdEntidad);
        gvEnvioDeMediosDetalle.DataBind();
    }
    protected void gvEnvioDeMediosDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEnvioDeMediosDetalle.PageIndex = e.NewPageIndex;
        CargaEnvioDeMediosDetalle(vNumeroEnvio, vIdEntidad);
    }
}