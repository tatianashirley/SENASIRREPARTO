using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
using System.Globalization;

using wcfSeguridad.Logica;
using wcfWFArticulador.Logica;

using System.ComponentModel;

public partial class WFArticulador_wfrmBandejaUsuario : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsBandejaUsuario objBandejaUsuario = new clsBandejaUsuario();

    int IdConexion; int IdUsuario, IdOficina, IdArea; string CuentaUsuario; int IdRol;
    long IdTramite; string ErroresTramites;

    private Int32 vId430Entrada
    {
        get { return Int32.Parse(ViewState["vId430Entrada"].ToString()); }
        set { ViewState["vId430Entrada"] = value; }
    }
    private Int32 vId430Salida
    {
        get { return Int32.Parse(ViewState["vId430Salida"].ToString()); }
        set { ViewState["vId430Salida"] = value; }
    }

    string Sort_Direction = "FechaIngreso DESC";
    string Sort_Direction2 = "FechaIngreso DESC";
    string Sort_Direction3 = "IdTramite ASC";
    string Sort_Direction4 = "IdTramite ASC";

    private String vF430generado
    {
        get { object obj = ViewState["CodigoTipoReproceso"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["CodigoTipoReproceso"] = value; }
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
            lblAux01.Text = "IdConexion="+IdConexion.ToString();
            Session.Timeout = 360;  //Sets new session time for this session

            string s01 = Session["CuentaUsuario"].ToString();
            string s02 = Session["CodUsuario"].ToString();
            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion(IdConexion);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
                string s11 = dtUsuarioDatos.Rows[0]["CuentaUsuario"].ToString();  //TECENVIOS2
                string s12 = dtUsuarioDatos.Rows[0]["IdRol"].ToString();    //107
                string s13 = dtUsuarioDatos.Rows[0]["Rol"].ToString();    //Técnico de Procesamiento CC y Envío APS
                string s14 = dtUsuarioDatos.Rows[0]["IdOficina"].ToString();    //2
                string s15 = dtUsuarioDatos.Rows[0]["Oficina"].ToString();  //LA PAZ
                string s16 = dtUsuarioDatos.Rows[0]["IdArea"].ToString();  //240
                string s17 = dtUsuarioDatos.Rows[0]["Area"].ToString(); //Envíos APS
                string s18 = dtUsuarioDatos.Rows[0]["FecHoraString"].ToString();    //29/05/2015  9:15AM
                string s19 = dtUsuarioDatos.Rows[0]["IdTipoUsuario"].ToString();    //677

                IdUsuario = Int32.Parse(s10);
                IdOficina = Int32.Parse(s14);
                IdArea = Int32.Parse(s16);

                lblAux01.Text += " IdUsuario=" + IdUsuario + " IdRol=" + s12 + " IdOficina=" + s14 + " IdArea=" + s16;
            }
            else
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
        }
        
        if (!Page.IsPostBack)
        {
            ViewState["SortExpr"] = Sort_Direction;
            ViewState["SortExpr2"] = Sort_Direction2;
            ViewState["SortExpr3"] = Sort_Direction3;
            ViewState["SortExpr4"] = Sort_Direction4;

            Tabs.ActiveTabIndex = 0;
            imgTramiteAcepta.Visible = false;
            lblAceptar.Visible = false;
            imgTramiteRechaza.Visible = false;
            lblRechazar.Visible = false;

            CargaBandejaEntrada();
            txtFechaAsignacion.Text = DateTime.Today.ToShortDateString();
            CargaPosiblesDestinos();

            txtDesde.Text = (String.IsNullOrEmpty(txtDesde.Text) ? DateTime.Today.ToShortDateString() : txtDesde.Text);
            txtHasta.Text = (String.IsNullOrEmpty(txtHasta.Text) ? DateTime.Today.ToShortDateString() : txtHasta.Text);
        }
    }

    # region BandejaEntrada
    protected void imgImprimeBandejaEntrada_Click(object sender, EventArgs e)
    {
        //Imprime Bandeja de Entrada
        int super10 = 0;
        super10 = 3123 * 12 / 2;
        
        //Session["iTotalTramites"] = "0";

        //objBandejaUsuario.iIdConexion = IdConexion;
        //if (objBandejaUsuario.CantidadTramitesBandejaTrabajo())
        //{
        //    Session["iTotalTramites"] = objBandejaUsuario.DSet.Tables[0].Rows[0][0].ToString();
        //}
        //else
        //{
        //    //Error
        //    string DetalleError = objBandejaUsuario.sMensajeError;
        //    string Error = "Error al realizar la operación";
        //    Master.MensajeError(Error, DetalleError);
        //}

        //Session["IdAreaDestino"] = IdArea;

        ////Response.Redirect("wfrmReporteBandejaTrabajo.aspx");
        //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReporteBandejaTrabajo.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        if (String.IsNullOrEmpty(txtNumeroTramite.Text) == true)
            return;

        //Busca Tramite en Bandeja Entrada 
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.sIdTramite = txtNumeroTramite.Text;
        if (objBandejaUsuario.BuscaTramiteBandejaEntrada())
        {
            dt = objBandejaUsuario.DSet.Tables[0];

            imgTramiteAcepta.Visible = true;
            lblAceptar.Visible = true;
            imgTramiteRechaza.Visible = true;
            lblRechazar.Visible = true;

            gvBandejaEntradaDetalle.DataSource = dt;
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvBandejaEntradaDetalle.Visible = true;
        gvBandejaEntradaDetalle.DataBind();
        gvBandejaEntrada.SelectedIndex = -1;
    }
    private DataTable BandejaEntrada()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.ListaBandejaEntrada())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    protected void gvBandejaEntrada_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;

        if (e.CommandName == "DETALLE01")
        {
            Master.MensajeCancel();
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgDetTramite = (ImageButton)gvBandejaEntrada.Rows[index].FindControl("imgDetTramite");
            GridViewRow gRow = (GridViewRow)imgDetTramite.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvBandejaEntrada.SelectedIndex = index;

            vId430Entrada = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["Id430"].ToString());
            //vFechaIngreso = DateTime.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdUsuarioOrigen"].ToString());
            //vIdAreaOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdAreaOrigen"].ToString());

            imgTramiteAcepta.Visible = true;
            lblAceptar.Visible = true;
            imgTramiteRechaza.Visible = true;
            lblRechazar.Visible = true;

            gvBandejaEntradaDetalle.Visible = true;
            CargaBandejaEntradaDetalle();
        }
        if (e.CommandName == "IMPRIME430xls")
        {
            Master.MensajeCancel();
            Session["xls_pdf"] = "xls";

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgImprime430 = (ImageButton)gvBandejaEntrada.Rows[index].FindControl("imgImprime430xls");
            GridViewRow gRow = (GridViewRow)imgImprime430.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvBandejaEntrada.SelectedIndex = index;

            string Id430 = gvBandejaEntrada.DataKeys[gRow.RowIndex]["Id430"].ToString();

            //esto mas por si aca
            vId430Entrada = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["Id430"].ToString());
            //vFechaIngreso = DateTime.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdUsuarioOrigen"].ToString());
            //vIdAreaOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdAreaOrigen"].ToString());

            //Rutina de impresión de 430
            Session["Id430"] = Id430;
            //Response.Redirect("wfrmRptFormulario430.aspx");
            //Response.Redirect("wfrmReporteFormulario430.aspx");
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../WFArticulador/wfrmReporteFormulario430.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
        if (e.CommandName == "IMPRIME430pdf")
        {
            Master.MensajeCancel();
            Session["xls_pdf"] = "pdf";

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgImprime430 = (ImageButton)gvBandejaEntrada.Rows[index].FindControl("imgImprime430pdf");
            GridViewRow gRow = (GridViewRow)imgImprime430.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvBandejaEntrada.SelectedIndex = index;

            string Id430 = gvBandejaEntrada.DataKeys[gRow.RowIndex]["Id430"].ToString();

            //esto mas por si aca
            vId430Entrada = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["Id430"].ToString());
            //vFechaIngreso = DateTime.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdUsuarioOrigen"].ToString());
            //vIdAreaOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdAreaOrigen"].ToString());

            //Rutina de impresión de 430
            Session["Id430"] = Id430;
            //Response.Redirect("wfrmRptFormulario430.aspx");
            //Response.Redirect("wfrmReporteFormulario430.aspx");
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../WFArticulador/wfrmReporteFormulario430.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
    }
    protected void gvBandejaEntrada_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandejaEntrada.PageIndex = e.NewPageIndex;
        CargaBandejaEntrada();
    }
    protected void gvBandejaEntrada_Sorting(object sender, GridViewSortEventArgs e)
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
        CargaBandejaEntrada();
    }
    protected void CargaBandejaEntrada()
    {
        DataTable listado1 = BandejaEntrada();
        DataView dvlistado1 = listado1.DefaultView;
        if (dvlistado1.Count>0)
            dvlistado1.Sort = ViewState["SortExpr"].ToString();

        gvBandejaEntrada.DataSource = dvlistado1;
        gvBandejaEntrada.DataBind();

        gvBandejaEntradaDetalle.Visible = false;
        imgTramiteAcepta.Visible = false;
        lblAceptar.Visible = false;
        imgTramiteRechaza.Visible = false;
        lblRechazar.Visible = false;
    }

    private DataTable TramitesEntrada()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.iId430 = vId430Entrada;
        if (objBandejaUsuario.ListaBandejaEntradaDetalle())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    protected void CargaBandejaEntradaDetalle()
    {
        gvBandejaEntradaDetalle.Visible = true;
        gvBandejaEntradaDetalle.DataSource = TramitesEntrada(); 
        gvBandejaEntradaDetalle.DataBind();

        imgTramiteAcepta.Visible = true;
        lblAceptar.Visible = true;
        imgTramiteRechaza.Visible = true;
        lblRechazar.Visible = true;
    }
    protected void gvBandejaEntradaDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvBandejaEntradaDetalle.SelectedIndex = currentRowIndex;

            String HIdTramite = gvBandejaEntradaDetalle.DataKeys[currentRowIndex]["IdTramite"].ToString();
            lblHIdTramite.Text = HIdTramite;

            CargarGrillaHistorialTramite(HIdTramite);
            ModalPopupExtender2.Show();
        }
    }
    protected void imgTramiteAcepta_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        //Obteniendo los Tramites seleccionados
        string LoteTramites="";
        foreach (GridViewRow row in gvBandejaEntradaDetalle.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkTramite") as CheckBox);
                if (chkRow.Checked)
                {
                    string sIdTramite = row.Cells[5].Text;
                    LoteTramites = LoteTramites + IdTramite + "|";

                    objBandejaUsuario.iIdConexion = IdConexion;
                    objBandejaUsuario.sIdTramite = sIdTramite;
                    if (objBandejaUsuario.AceptaTramite())
                    {
                        Master.MensajeOk("Exito!! Se aceptó el tramite correctamente.");
                    }
                    else
                    {
                        //Error
                        string DetalleError = objBandejaUsuario.sMensajeError;
                        string Error = "Error al realizar la operación";
                        Master.MensajeError(Error, DetalleError);
                    }
                }
            }
        }
        if (LoteTramites.Length == 0) Master.MensajeWarning("No hubo selección de Tramites!!");

        CargaBandejaEntrada();
    }
    protected void imgTramiteRechaza_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        //Obteniendo los Tramites seleccionados
        string LoteTramites = "";
        foreach (GridViewRow row in gvBandejaEntradaDetalle.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkTramite") as CheckBox);
                if (chkRow.Checked)
                {
                    string sIdTramite = row.Cells[5].Text;
                    LoteTramites = LoteTramites + IdTramite + "|";

                    objBandejaUsuario.iIdConexion = IdConexion;
                    objBandejaUsuario.sIdTramite = sIdTramite;
                    if (objBandejaUsuario.RechazaTramite())
                    {
                        Master.MensajeOk("Exito!! Se rechazó el tramite correctamente.");
                    }
                    else
                    {
                        //Error
                        string DetalleError = objBandejaUsuario.sMensajeError;
                        string Error = "Error al realizar la operación";
                        Master.MensajeError(Error, DetalleError);
                    }
                }
            }
        }
        if (LoteTramites.Length == 0) Master.MensajeWarning("No hubo selección de Tramites!!");

        CargaBandejaEntrada();
    }
    protected void HFPanel1_ValueChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        imgImprime430GeneradoPDF.Visible = false;
        lblImprime430Generadopdf.Visible = false;
        Tabs.ActiveTabIndex = 0;
        CargaBandejaEntrada();
    }
    #endregion

    # region BandejaTrabajo y Derivación de Trámites
    protected void imgBuscarTrabajo_Click(object sender, ImageClickEventArgs e)
    {
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.CantidadTramitesBandejaTrabajo())
        {
            lblTitBandejaTrabajo.Text = "Detalle de Trámites Aceptados [" + objBandejaUsuario.DSet.Tables[0].Rows[0][0].ToString() + "]";
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        
        if (String.IsNullOrEmpty(txtNumeroTramiteTrabajo.Text) == true)
        {
            Master.MensajeCancel();
            CargaBandejaAceptados();
            return;
        }
        else
        {
            Master.MensajeCancel();
            //Busca Tramite en Bandeja Entrada 
            DataTable dt = new DataTable();
            objBandejaUsuario.iIdConexion = IdConexion;
            objBandejaUsuario.sIdTramite = txtNumeroTramiteTrabajo.Text;
            if (objBandejaUsuario.BuscaTramiteBandejaTrabajo())
            {
                dt = objBandejaUsuario.DSet.Tables[0];

                imgTramiteCancela.Enabled = true;
                gvBandejaAceptados.DataSource = dt;
            }
            else
            {
                //Error
                string DetalleError = objBandejaUsuario.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);
                imgBuscarSalida.Enabled = false;
            }
            gvBandejaAceptados.DataBind();
        }
    }
    protected void CargaBandejaAceptados()
    {
        DataTable listado1 = TramitesAceptados();
        DataView dvlistado1 = listado1.DefaultView;
        if (dvlistado1.Count > 0)
            dvlistado1.Sort = ViewState["SortExpr3"].ToString();

        gvBandejaAceptados.DataSource = dvlistado1;
        gvBandejaAceptados.DataBind();
        gvBandejaAceptados.SelectedIndex = -1;
    }
    protected void gvBandejaAceptados_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandejaAceptados.PageIndex = e.NewPageIndex;
        CargaBandejaAceptados();
    }
    protected void gvBandejaAceptados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Int32 IdUsuarioActividad = (String.IsNullOrEmpty(gvBandejaAceptados.DataKeys[e.Row.RowIndex]["IdUsuarioActividad"].ToString()) ? 0 : Int32.Parse(gvBandejaAceptados.DataKeys[e.Row.RowIndex]["IdUsuarioActividad"].ToString()));
            if (IdUsuarioActividad > 0)
            {
                e.Row.BackColor = System.Drawing.Color.DarkSlateGray;
                e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;
            }
            Int32 t430 = (String.IsNullOrEmpty(gvBandejaAceptados.DataKeys[e.Row.RowIndex]["t430"].ToString()) ? 0 : Int32.Parse(gvBandejaAceptados.DataKeys[e.Row.RowIndex]["t430"].ToString()));
            if (t430 == 0)
            {
                e.Row.BackColor = System.Drawing.Color.DimGray;
                e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;
                //e.Row.ForeColor = System.Drawing.Color.BlueViolet;
            }
        }
    }
    protected void gvBandejaAceptados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvBandejaAceptados.SelectedIndex = currentRowIndex;

            String HIdTramite = gvBandejaAceptados.DataKeys[currentRowIndex]["IdTramite"].ToString();
            lblHIdTramite.Text = HIdTramite;

            CargarGrillaHistorialTramite(HIdTramite);
            ModalPopupExtender2.Show();
        }
    }
    protected void gvBandejaAceptados_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["SortExpr3"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["SortExpr3"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpr3"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["SortExpr3"] = e.SortExpression + " " + "ASC";
        }
        CargaBandejaAceptados();
    }
    private DataTable TramitesAceptados()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.ListaBandejaTrabajo())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    private DataTable TramitesTrabajo()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.ListaBandejaTrabajo())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        ViewState["dtTramitesTrabajo"] = dt;

        return dt;
    }
    protected void CargaBandejaTrabajo()
    {
        if (ViewState["dtTramitesTrabajo"] != null)
        {
            DataTable listado1 = ViewState["dtTramitesTrabajo"] as DataTable;
            DataView dvlistado1 = listado1.DefaultView;
            dvlistado1.Sort = ViewState["SortExpr4"].ToString();
            gvBandejaTrabajo.DataSource = dvlistado1;
        }
        
        //gvBandejaTrabajo.DataSource = ViewState["dtTramitesTrabajo"] as DataTable;
        if (ViewState["dtEnvios"] != null & ViewState["dtTramitesTrabajo"] != null)
        {
            DataTable dt1 = ViewState["dtTramitesTrabajo"] as DataTable;
            DataTable dt2 = ViewState["dtEnvios"] as DataTable;

            int indexRow = 0;
            foreach (DataRow fila1 in dt1.Rows)
            {
                foreach (DataRow fila2 in dt2.Rows)
                {
                    if (fila1["IdTramite"].ToString() == fila2["IdTramite"].ToString())
                    {
                        dt1.Rows[indexRow].Delete();
                        break;
                    }
                }
                indexRow +=1;
                //if (cont1 > 6)
                //{
                //    break;
                //}
            }
            dt1.AcceptChanges();

            gvBandejaTrabajo.DataSource = dt1;
        }
        gvBandejaTrabajo.DataBind();
        gvBandejaTrabajo.SelectedIndex = -1;
    }
    protected void gvBandejaTrabajo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandejaTrabajo.PageIndex = e.NewPageIndex;
        TramitesTrabajo();
        CargaBandejaTrabajo();
    }
    protected void gvBandejaTrabajo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool showChkTramite = true;
            Int32 IdUsuarioActividad = (String.IsNullOrEmpty(gvBandejaTrabajo.DataKeys[e.Row.RowIndex]["IdUsuarioActividad"].ToString()) ? 0 : Int32.Parse(gvBandejaTrabajo.DataKeys[e.Row.RowIndex]["IdUsuarioActividad"].ToString()));
            if (IdUsuarioActividad > 0)
            {
                e.Row.BackColor = System.Drawing.Color.DarkSlateGray;
                e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;
                showChkTramite = false;
            }
            Int32 t430 = (String.IsNullOrEmpty(gvBandejaTrabajo.DataKeys[e.Row.RowIndex]["t430"].ToString()) ? 0 : Int32.Parse(gvBandejaTrabajo.DataKeys[e.Row.RowIndex]["t430"].ToString()));
            if (t430 == 0)
            {
                e.Row.BackColor = System.Drawing.Color.LightGray;
                //e.Row.ForeColor = System.Drawing.Color.BlueViolet;
                showChkTramite = false;
            }
            if (!showChkTramite)
            {
                CheckBox chkTramite = (CheckBox)e.Row.FindControl("chkTramite");
                chkTramite.Checked = false;
                chkTramite.Visible = false;
            }
        }
    }
    protected void gvBandejaTrabajo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvBandejaTrabajo.SelectedIndex = currentRowIndex;

            String HIdTramite = gvBandejaTrabajo.DataKeys[currentRowIndex]["IdTramite"].ToString();
            lblHIdTramite.Text = HIdTramite;

            CargarGrillaHistorialTramite(HIdTramite);
            ModalPopupExtender2.Show();
        }
    }
    protected void gvBandejaTrabajo_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["SortExpr4"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["SortExpr4"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpr4"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["SortExpr4"] = e.SortExpression + " " + "ASC";
        }
        CargaBandejaTrabajo(); ;
    }
    protected void imgImprimeBandejaTrabajoXLS_Click(object sender, ImageClickEventArgs e)
    {
        Session["xls_pdf"] = "xls";

        Session["IdAreaDestino"] = IdArea;
        //Response.Redirect("wfrmReporteBandejaTrabajo.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReporteBandejaTrabajo.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    protected void imgImprimeBandejaTrabajoPDF_Click(object sender, ImageClickEventArgs e)
    {
        Session["xls_pdf"] = "pdf";

        Session["IdAreaDestino"] = IdArea;
        //Response.Redirect("wfrmReporteBandejaTrabajo.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReporteBandejaTrabajo.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    protected void BuscaInsertaTramitePreEnvio(string sIdTramite)
    {
        if (sIdTramite == "") sIdTramite = "0";
        //------ Inserta en ViewState["dtEnvios"] 
        DataTable dt = new DataTable();
        dt.Columns.Add("Numerador");
        dt.Columns.Add("IdRuta");
        dt.Columns.Add("NumeroTramiteCrenta");                
        dt.Columns.Add("IdTramite");
        dt.Columns.Add("Matricula");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("FechaIngreso");
        dt.Columns.Add("ObsSalidaArea");

        if (ViewState["dtEnvios"] != null)
            dt = ViewState["dtEnvios"] as DataTable;

        //Buscamos si se repite
        foreach (DataRow fila1 in dt.Rows)
        {
            if (fila1["IdTramite"].ToString() == sIdTramite)
                return;
        }

        //string sCodigo = ddlRolUsuario.SelectedValue;
        //sCodigo = sCodigo.Substring(0, sCodigo.Length - 1);  
        //string[] aCodigo = sCodigo.Split('|');
        //string sIdRol = aCodigo[0];
        //string sIdUsuario = aCodigo[1];

        string sIdRol = ddlRolUsuario.SelectedValue;

        //Busca Tramite en Bandeja de Trabajo
        DataTable dtConsulta = new DataTable();
        int numFilas=0;
        int numColumnas=0;

        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.sIdTramite = sIdTramite;
        objBandejaUsuario.iIdAreaDestino = IdArea;
        objBandejaUsuario.iIdAreaDestinoNew = Int32.Parse(ddlPosiblesDestinos.SelectedValue);
        objBandejaUsuario.iIdRolNew = Int32.Parse(sIdRol);
        if (objBandejaUsuario.BuscaTramitePreAsignaBandejaTrabajo())
        {
            dtConsulta = objBandejaUsuario.DSet.Tables[0];
            numFilas = dtConsulta.Rows.Count;
            numColumnas = dtConsulta.Columns.Count;
            lblUltimoTramiteInsertado.Visible = true;
            lblUltimoTramiteInsertado.Text = "Ultimo Tramite insertado: " + sIdTramite;
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        if (numFilas != 1 || numColumnas != 1)
        {
            ViewState["dtTramitesTrabajo"] = dtConsulta;
            //IdRuta, IdTramite, Matricula, Nombre, FechaIngreso, NumeroTramiteCrenta,IdtipoTRamite, TipoTramite
            foreach (DataRow item in dtConsulta.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["Numerador"] = 0;
                dr["IdRuta"] = item[0].ToString();
                dr["NumeroTramiteCrenta"] = item[5].ToString();
                dr["IdTramite"] = item[1].ToString();
                dr["Matricula"] = item[2].ToString();
                dr["Nombre"] = item[3].ToString();
                dr["FechaIngreso"] = item[4].ToString();
                dr["ObsSalidaArea"] = txtProeidoEspecifico.Text;
                dt.Rows.Add(dr);
                txtProeidoEspecifico.Text = "";
            }

            int numerador = 1;
            foreach (DataRow fila1 in dt.Rows)
            {
                fila1["Numerador"] = numerador;
                numerador += 1;
            }
            ViewState["dtEnvios"] = dt;
            txtTramiteEnvia.Text = "";
        }
        else
        {
            lblUltimoTramiteInsertado.Visible = false;
            ErroresTramites = ErroresTramites + sIdTramite + "-->" + dtConsulta.Rows[0][0].ToString() + "<br>";
            //Error
            string DetalleError = dtConsulta.Rows[0][0].ToString();
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void imgBuscarTramite_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();

        if (String.IsNullOrEmpty(txtTramiteEnvia.Text) == true)
            return;

        BuscaInsertaTramitePreEnvio(txtTramiteEnvia.Text);

        ViewState["dtTramitesTrabajo"] = null;
        CargaBandejaEnvio();
        CargaBandejaTrabajo();

        ddlPosiblesDestinos.Enabled = false;
        ddlRolUsuario.Enabled = false;
        imgImprime430GeneradoPDF.Visible = false;
        lblImprime430Generadopdf.Visible = false;

        imgBuscarTramite.Enabled = true;
        btnVerBandejaTrabajo.Enabled = true;
        lblDetalleTramitesDerivarse.Visible = true;
        imgPreEnvio.Enabled = true;
        imgEnvioTramite.Enabled = true;
    }
    protected void btnVerBandejaTrabajoFiltrada_Click(object sender, EventArgs e)
    {
        Master.MensajeCancel();

        imgImprime430GeneradoPDF.Visible = false;
        lblImprime430Generadopdf.Visible = false;

        CargaBandejaEnvio();
        TramitesTrabajo();
        CargaBandejaTrabajo();
    }
    protected void imgPreEnvio_Click(object sender, ImageClickEventArgs e)
    {
        ErroresTramites = "";
        foreach (GridViewRow item in gvBandejaTrabajo.Rows)
        {
            if ((item.Cells[0].FindControl("chkTramite") as CheckBox).Checked)
            {
                BuscaInsertaTramitePreEnvio(Server.HtmlDecode(item.Cells[2].Text));
            }
        }
        if (String.IsNullOrEmpty(ErroresTramites) == false)
        {
            //Despliega la pila de tramites con error en sus estados
            string DetalleError = ErroresTramites;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        txtProeidoEspecifico.Text = "";

        CargaBandejaEnvio();
        ViewState["dtTramitesTrabajo"]=TramitesTrabajo();
        CargaBandejaTrabajo();

        ddlPosiblesDestinos.Enabled = false;
        ddlRolUsuario.Enabled = false;
        imgBuscarTramite.Enabled = true;
        btnVerBandejaTrabajo.Enabled = true;
        lblDetalleTramitesDerivarse.Visible = true;
        imgPreEnvio.Enabled = true;
        imgEnvioTramite.Enabled = true;
    }
    protected void CargaBandejaEnvio()
    {
        gvBandejaEnvio.DataSource = null;

        //Reordena Grid
        DataTable dt = ViewState["dtEnvios"] as DataTable;
        if (dt != null)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns[0].DataType = typeof(Int32);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            dtCloned.DefaultView.Sort = "Numerador DESC";
            dt = dtCloned.DefaultView.ToTable();
            gvBandejaEnvio.DataSource = dt;
        }
        gvBandejaEnvio.DataBind();
    }
    protected void gvBandejaEnvio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EXCLUIR")
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            Label lblNumeroEnvio = (Label)gvBandejaEnvio.Rows[currentRowIndex].FindControl("lblNumeroEnvio");
            Label lblFila = (Label)gvBandejaEnvio.Rows[currentRowIndex].FindControl("lblFila");

            DataTable dt = ViewState["dtEnvios"] as DataTable;
            //Reordena Grid
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns[0].DataType = typeof(Int32);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            dtCloned.DefaultView.Sort = "Numerador DESC";
            dt = dtCloned.DefaultView.ToTable();
            //
            dt.Rows[currentRowIndex].Delete();
            //Reordena Grid
            DataTable dtCloned2 = dt.Clone();
            dtCloned2.Columns[0].DataType = typeof(Int32);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned2.ImportRow(row);
            }
            dtCloned2.DefaultView.Sort = "Numerador ASC";
            dt = dtCloned2.DefaultView.ToTable();
            //
            ViewState["dtEnvios"] = dt;
            int numerador = 1;
            foreach (DataRow fila1 in dt.Rows)
            {
                fila1["Numerador"] = numerador;
                numerador += 1;
            }

            if (dt.Rows.Count == 0)
            {
                ddlPosiblesDestinos.Enabled = true;
                ddlRolUsuario.Enabled = true;
                btnVerBandejaTrabajo.Enabled = false;
                lblDetalleTramitesDerivarse.Visible = false;
                imgPreEnvio.Enabled = false;
                imgEnvioTramite.Enabled = false;
            }
            CargaBandejaTrabajo();
            CargaBandejaEnvio();
        }
        if (e.CommandName == "IMGProveido")
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            Label lblProveidoE_grid = (Label)gvBandejaEnvio.Rows[currentRowIndex].FindControl("lblProveidoE");
            txtProveidoTrans.Text = lblProveidoE_grid.Text;
            ViewState["gvBandejaEnvioIndex"] = currentRowIndex.ToString();

            ModalPopupExtender1.Show();
        }
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvBandejaEnvio.SelectedIndex = currentRowIndex;

            String HIdTramite = gvBandejaEnvio.DataKeys[currentRowIndex]["IdTramite"].ToString();
            lblHIdTramite.Text = HIdTramite;

            CargarGrillaHistorialTramite(HIdTramite);
            ModalPopupExtender2.Show();
        }
    }
    private DataTable ListaPosiblesDestinos()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.ListaPosiblesDestinos())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    protected void CargaPosiblesDestinos()
    {
        ddlPosiblesDestinos.DataSource = ListaPosiblesDestinos();
        ddlPosiblesDestinos.DataTextField = "AreaDestino";
        ddlPosiblesDestinos.DataValueField = "IdAreaDestino";
        ddlPosiblesDestinos.DataBind();

        ddlPosiblesDestinos.Items.Insert(0, new ListItem("--Elegir--", "0"));
        ddlRolUsuario.Items.Insert(0, new ListItem("--Elegir--", "0"));
    }
    protected void ddlPosiblesDestinos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        string Codigo = ddlPosiblesDestinos.SelectedValue;

        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.iIdAreaDestino = IdArea;
        objBandejaUsuario.iIdAreaDestinoNew = Int32.Parse(Codigo);
        if (objBandejaUsuario.ListaUsuarioDestinoPosible())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        ddlRolUsuario.DataSource = dt;
        ddlRolUsuario.DataTextField = "Descripcion";
        ddlRolUsuario.DataValueField = "IdRolDestino";
        ddlRolUsuario.DataBind();

        ddlRolUsuario.Items.Insert(0, new ListItem("--Elegir--", "0"));

        imgImprime430GeneradoPDF.Visible = false;
        lblImprime430Generadopdf.Visible = false;
    }
    protected void ddlRolUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        imgBuscarTramite.Enabled = true;
        btnVerBandejaTrabajo.Enabled = true;
        lblDetalleTramitesDerivarse.Visible = true;
        imgPreEnvio.Enabled = true;
        imgEnvioTramite.Enabled = false;

        imgImprime430GeneradoPDF.Visible = false;
        lblImprime430Generadopdf.Visible = false;
    }
    protected void imgEnvioTramite_Click(object sender, ImageClickEventArgs e)
    {
        //Reordena Grid
        //DataTable dt = ViewState["dtEnvios"] as DataTable;
        //if (dt != null)
        //{
        //    DataTable dtCloned = dt.Clone();
        //    dtCloned.Columns[0].DataType = typeof(Int32);
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        dtCloned.ImportRow(row);
        //    }
        //    DataView dvlistado1 = dtCloned.DefaultView;
        //    if (dvlistado1.Count > 0)
        //        dvlistado1.Sort = "Numerador ASC";
        //    gvBandejaEnvio.DataSource = dvlistado1;
        //}
        //gvBandejaEnvio.DataBind();

        //Reordena Grid
        //DataTable dt = ViewState["dtEnvios"] as DataTable;
        //if (dt != null)
        //{
        //    dt.DefaultView.Sort = "Numerador ASC";
        //    dt = dt.DefaultView.ToTable();
        //    gvBandejaEnvio.DataSource = dt;
        //}
        //gvBandejaEnvio.DataBind();

        //Reordena Grid
        DataTable dt = ViewState["dtEnvios"] as DataTable;
        if (dt != null)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns[0].DataType = typeof(Int32);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            dtCloned.DefaultView.Sort = "Numerador ASC";
            dt = dtCloned.DefaultView.ToTable();
            gvBandejaEnvio.DataSource = dt;
        }
        gvBandejaEnvio.DataBind();

        //Envio de Tramites a Bandeja de Salida
        Master.MensajeCancel();
        vF430generado = "";
        txtTramiteEnvia.Text = "";
        string LoteTramites = ""; 
        DateTime fFechaAsignacion = DateTime.Now;
        foreach (GridViewRow row in gvBandejaEnvio.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                string IdRuta = row.Cells[3].Text;

                string sIdTramite = row.Cells[5].Text;
                LoteTramites = LoteTramites + IdTramite + "|";
                int iIdAreaDestinoNew = Int32.Parse(ddlPosiblesDestinos.SelectedValue);

                //string s = ddlRolUsuario.SelectedValue;
                //s = s.Substring(0, s.Length - 1);  //Without the last character of a string
                //string[] words = s.Split('|');
                //string sIdRol = words[0];
                //string sIdUsuario = words[1];

                //int iIdUsuarioDestinoNew = Int32.Parse(sIdUsuario);

                //string sObsSalidaArea = row.Cells[8].Text;
                Label lblProveidoE_grid = (Label)gvBandejaEnvio.Rows[row.RowIndex].FindControl("lblProveidoE");
                string sObsSalidaArea = lblProveidoE_grid.Text;
                DataSet dsBandejaUsuario = new DataSet();

                objBandejaUsuario.iIdConexion = IdConexion;
                objBandejaUsuario.sIdTramite = sIdTramite;
                objBandejaUsuario.iIdRuta = Int32.Parse(IdRuta);
                objBandejaUsuario.iIdAreaDestinoNew = iIdAreaDestinoNew;
                objBandejaUsuario.fFechaAsignacion = fFechaAsignacion;
                objBandejaUsuario.sObsSalidaArea = sObsSalidaArea;
                objBandejaUsuario.sProvehido = txtProveidoGeneral.Text;
                if (objBandejaUsuario.AsignaTramite())
                {
                    Master.MensajeOk("Exito!! Se aceptó el tramite correctamente.");
                    dsBandejaUsuario = objBandejaUsuario.DSet;
                    if (dsBandejaUsuario.Tables.Count > 0)
                    {
                        vF430generado = objBandejaUsuario.DSet.Tables[0].Rows[0][0].ToString();
                    }
                    txtProveidoGeneral.Text = "";
                }
                else
                {
                    //Error
                    string DetalleError = objBandejaUsuario.sMensajeError;
                    string Error = "Error al realizar la operación";
                    Master.MensajeError(Error, DetalleError);
                }
            }
        }
        if (LoteTramites.Length == 0) Master.MensajeWarning("No se aceptó ningún tramite porque no hubo selección de Tramites!!");
        

        ViewState["dtEnvios"] = null;
        
        ddlPosiblesDestinos.Enabled = true;
        ddlPosiblesDestinos.SelectedIndex = ddlPosiblesDestinos.Items.IndexOf(ddlPosiblesDestinos.Items.FindByText("--Elegir--"));
        ddlRolUsuario.Enabled = true;
        ddlRolUsuario.SelectedIndex = ddlRolUsuario.Items.IndexOf(ddlRolUsuario.Items.FindByText("--Elegir--"));
        if (!String.IsNullOrEmpty(vF430generado))
        {
            imgImprime430GeneradoPDF.Visible = true;
            lblImprime430Generadopdf.Visible = true;
            lblImprime430Generadopdf.Text = "Imprimir el F430 generado [" + vF430generado + "]";
        }

        imgBuscarTramite.Enabled = false;
        btnVerBandejaTrabajo.Enabled = true;
        lblDetalleTramitesDerivarse.Visible = true;
        imgPreEnvio.Enabled = true;
        imgEnvioTramite.Enabled = true;

        CargaBandejaTrabajo();
        CargaBandejaEnvio();
    }
    protected void btnProveido_Click(object sender, EventArgs e)
    {
        int currentRowIndex = Int32.Parse(ViewState["gvBandejaEnvioIndex"].ToString());
        Label lblProveidoE_grid = (Label)gvBandejaEnvio.Rows[currentRowIndex].FindControl("lblProveidoE");
        lblProveidoE_grid.Text = txtProveidoTrans.Text;

        //------ Actualiza en ViewState["dtEnvios"] 
        string sIdTramite = gvBandejaEnvio.DataKeys[currentRowIndex]["IdTramite"].ToString();

        DataTable dt = new DataTable();
        dt.Columns.Add("Numerador");
        dt.Columns.Add("IdRuta");
        dt.Columns.Add("NumeroTramiteCrenta");
        dt.Columns.Add("IdTramite");
        dt.Columns.Add("Matricula");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("FechaIngreso");
        dt.Columns.Add("ObsSalidaArea");

        if (ViewState["dtEnvios"] != null)
            dt = ViewState["dtEnvios"] as DataTable;

        foreach (DataRow fila1 in dt.Rows)
        {
            if (fila1["IdTramite"].ToString() == sIdTramite)
            {
                fila1["ObsSalidaArea"] = lblProveidoE_grid.Text;
            }
        }
        dt.AcceptChanges();
        ViewState["dtEnvios"] = dt;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        HFProveidoTrans.Value = "0";
    }
    protected void imgImprime430GeneradoPDF_Click(object sender, EventArgs e)
    {
        Session["xls_pdf"] = "pdf";
        Session["Id430"] = vF430generado;
        //Response.Redirect("wfrmRptFormulario430.aspx");
        //Response.Redirect("wfrmReporteFormulario430.aspx");
        ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../WFArticulador/wfrmReporteFormulario430.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    #endregion

    # region BandejaSalida
    protected void imgImprimeBandejaSalida_Click(object sender, EventArgs e)
    {
        //Imprime Bandeja de Entrada
        int super10 = 0;
        super10 = 3123 * 12 / 2;

        //Session["iTotalTramites"] = "0";

        //objBandejaUsuario.iIdConexion = IdConexion;
        //if (objBandejaUsuario.CantidadTramitesBandejaTrabajo())
        //{
        //    Session["iTotalTramites"] = objBandejaUsuario.DSet.Tables[0].Rows[0][0].ToString();
        //}
        //else
        //{
        //    //Error
        //    string DetalleError = objBandejaUsuario.sMensajeError;
        //    string Error = "Error al realizar la operación";
        //    Master.MensajeError(Error, DetalleError);
        //}

        //Session["IdAreaDestino"] = IdArea;

        ////Response.Redirect("wfrmReporteBandejaTrabajo.aspx");
        //ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('wfrmReporteBandejaTrabajo.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
    }
    protected void imgBuscarSalida_Click(object sender, ImageClickEventArgs e)
    {
        if (String.IsNullOrEmpty(txtNumeroTramiteSalida.Text) == true)
            return;

        //Busca Tramite en Bandeja Entrada 
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.sIdTramite = txtNumeroTramiteSalida.Text;
        if (objBandejaUsuario.BuscaTramiteBandejaSalida())
        {
            dt = objBandejaUsuario.DSet.Tables[0];

            imgTramiteCancela.Enabled = true;
            gvBandejaSalidaDetalle.DataSource = dt;
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
            imgBuscarSalida.Enabled = false;
        }
        gvBandejaSalidaDetalle.Visible = true;
        gvBandejaSalidaDetalle.DataBind();
        gvBandejaSalida.SelectedIndex = -1;
    }
    private DataTable BandejaSalida()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        if (objBandejaUsuario.ListaBandejaSalida())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    protected void CargaBandejaSalida()
    {
        DataTable listado1 = BandejaSalida();

        if (listado1.Rows.Count != 0)
        {
            DataView dvlistado1 = listado1.DefaultView;
            dvlistado1.Sort = ViewState["SortExpr2"].ToString();

            gvBandejaSalida.DataSource = dvlistado1;
            imgBuscarSalida.Enabled = true;
        }
        gvBandejaSalida.DataBind();
        gvBandejaSalida.SelectedIndex = -1;
        gvBandejaSalidaDetalle.Visible = false;
        imgTramiteCancela.Visible = false;
        lblCancelar.Visible = false;
    }
    protected void gvBandejaSalida_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;

        if (e.CommandName == "DETALLE01")
        {
            Master.MensajeCancel();
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgDetTramite = (ImageButton)gvBandejaSalida.Rows[index].FindControl("imgDetTramite");
            GridViewRow gRow = (GridViewRow)imgDetTramite.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvBandejaSalida.SelectedIndex = index;

            vId430Salida = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["Id430"].ToString());

            //vFechaIngreso = DateTime.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioDestinoNew = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["IdUsuarioDestinoNew"].ToString());
            //vIdUsuarioDestino = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["IdUsuarioDestino"].ToString());
            //vIdAreaDestino = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["IdAreaDestino"].ToString());

            imgTramiteCancela.Enabled = true;

            CargaBandejaSalidaDetalle();
        }
        if (e.CommandName == "IMPRIME430xls")
        {
            Master.MensajeCancel();
            Session["xls_pdf"] = "xls";

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgImprime430 = (ImageButton)gvBandejaSalida.Rows[index].FindControl("imgImprime430xls");
            GridViewRow gRow = (GridViewRow)imgImprime430.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvBandejaSalida.SelectedIndex = index;

            string Id430 = gvBandejaSalida.DataKeys[gRow.RowIndex]["Id430"].ToString();

            //esto mas por si aca
            vId430Entrada = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["Id430"].ToString());
            //vFechaIngreso = DateTime.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdUsuarioOrigen"].ToString());
            //vIdAreaOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdAreaOrigen"].ToString());

            //Rutina de impresión de 430
            Session["Id430"] = Id430;
            //Response.Redirect("wfrmRptFormulario430.aspx");
            //Response.Redirect("wfrmReporteFormulario430.aspx");
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../WFArticulador/wfrmReporteFormulario430.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
        if (e.CommandName == "IMPRIME430pdf")
        {
            Master.MensajeCancel();
            Session["xls_pdf"] = "pdf";

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgImprime430 = (ImageButton)gvBandejaSalida.Rows[index].FindControl("imgImprime430pdf");
            GridViewRow gRow = (GridViewRow)imgImprime430.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvBandejaSalida.SelectedIndex = index;

            string Id430 = gvBandejaSalida.DataKeys[gRow.RowIndex]["Id430"].ToString();

            //esto mas por si aca
            vId430Entrada = Int32.Parse(gvBandejaSalida.DataKeys[gRow.RowIndex]["Id430"].ToString());
            //vFechaIngreso = DateTime.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["FechaIngreso"].ToString());
            //vIdUsuarioOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdUsuarioOrigen"].ToString());
            //vIdAreaOrigen = Int32.Parse(gvBandejaEntrada.DataKeys[gRow.RowIndex]["IdAreaOrigen"].ToString());

            //Rutina de impresión de 430
            Session["Id430"] = Id430;
            //Response.Redirect("wfrmRptFormulario430.aspx");
            //Response.Redirect("wfrmReporteFormulario430.aspx");
            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../WFArticulador/wfrmReporteFormulario430.aspx','newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }    
    }
    protected void gvBandejaSalida_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBandejaSalida.PageIndex = e.NewPageIndex;
        CargaBandejaSalida();
    }
    protected void gvBandejaSalida_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["SortExpr2"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["SortExpr2"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpr2"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["SortExpr2"] = e.SortExpression + " " + "ASC";
        }
        CargaBandejaSalida();
    }
    private DataTable TramitesSalida()
    {
        DataTable dt = new DataTable();
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.iId430 = vId430Salida;
        if (objBandejaUsuario.ListaBandejaSalidaDetalle())
        {
            dt = objBandejaUsuario.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objBandejaUsuario.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        return dt;
    }
    protected void CargaBandejaSalidaDetalle()
    {
        gvBandejaSalidaDetalle.Visible = true;
        gvBandejaSalidaDetalle.DataSource = TramitesSalida();
        gvBandejaSalidaDetalle.DataBind();
        imgTramiteCancela.Visible = true;
        lblCancelar.Visible = true;
    }
    protected void gvBandejaSalidaDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvBandejaSalidaDetalle.SelectedIndex = currentRowIndex;

            String HIdTramite = gvBandejaSalidaDetalle.DataKeys[currentRowIndex]["IdTramite"].ToString();
            lblHIdTramite.Text = HIdTramite;

            CargarGrillaHistorialTramite(HIdTramite);
            ModalPopupExtender2.Show();
        }
    }
    protected void imgTramiteCancela_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        //Obteniendo los Tramites seleccionados
        string LoteTramites = "";
        foreach (GridViewRow row in gvBandejaSalidaDetalle.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkTramite") as CheckBox);
                if (chkRow.Checked)
                {
                    string sIdTramite = row.Cells[5].Text;
                    LoteTramites = LoteTramites + IdTramite + "|";

                    objBandejaUsuario.iIdConexion = IdConexion;
                    objBandejaUsuario.sIdTramite = sIdTramite;
                    if (objBandejaUsuario.CancelaTramite())
                    {
                        Master.MensajeOk("Exito!! Se canceló el tramite correctamente.");
                    }
                    else
                    {
                        //Error
                        string DetalleError = objBandejaUsuario.sMensajeError;
                        string Error = "Error al realizar la operación";
                        Master.MensajeError(Error, DetalleError);
                    }
                }
            }
        }
        if (LoteTramites.Length == 0) Master.MensajeWarning("No hubo selección de Tramites!!");

        CargaBandejaSalida();
    }
    protected void HFPanel3_ValueChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        imgImprime430GeneradoPDF.Visible = false;
        lblImprime430Generadopdf.Visible = false;

        Tabs.ActiveTabIndex = 3;
        CargaBandejaSalida();
    }
    #endregion

    #region HistorialTramite
    protected void imgBuscarSeguimiento_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        if (String.IsNullOrEmpty(txtNumeroTramiteSeguimiento.Text) == true)
            return;
        else
        {
            CargarGrillaHistorialTramite(txtNumeroTramiteSeguimiento.Text);
            ModalPopupExtender2.Show();
        }
    }
    //---------------------------------------
    private void CargarGrillaHistorialTramite(string sIdTramite)
    {
        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.sIdTramite = sIdTramite;
        if (objBandejaUsuario.HistorialTramite())
        {
            var dt = objBandejaUsuario.DSet.Tables[0];
            gvBusqMaestro.DataSource = dt;
            gvBusqMaestro.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla la busqueda", objBandejaUsuario.sMensajeError);
            gvBusqMaestro.DataSource = null;
            gvBusqMaestro.DataBind();
        }
    }
    #endregion
    #region Seguimiento de Tramites
    protected void imgSeguimientoTramites_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        CargaGrillaSeguimientoTramite();
    }
    //---------------------------------------
    private void CargaGrillaSeguimientoTramite()
    {
        txtDesde.Text = (String.IsNullOrEmpty(txtDesde.Text) ? "01/01/1980" : txtDesde.Text);
        txtHasta.Text = (String.IsNullOrEmpty(txtHasta.Text) ? DateTime.Today.ToShortDateString() : txtHasta.Text);

        objBandejaUsuario.iIdConexion = IdConexion;
        objBandejaUsuario.fFecha1 = DateTime.Parse(txtDesde.Text);
        objBandejaUsuario.fFecha2 = DateTime.Parse(txtHasta.Text); 
        if (objBandejaUsuario.SeguimientoTramites())
        {
            var dt = objBandejaUsuario.DSet.Tables[0];
            gvSeguimientoTramite.DataSource = dt;
            gvSeguimientoTramite.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla la busqueda", objBandejaUsuario.sMensajeError);
            gvSeguimientoTramite.DataSource = null;
            gvSeguimientoTramite.DataBind();
        }
    }
    #endregion
}