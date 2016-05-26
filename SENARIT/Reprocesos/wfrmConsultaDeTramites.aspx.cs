using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

using wcfSeguridad.Logica;
using wcfReprocesos.Logica;
using wcfInicioTramite.Logica;
using wcfWorkFlowN.Logica;
using wcfWFArticulador.Logica;

public partial class Reprocesos_wfrmConsultaDeTramites : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsReprocesoCC objReprocesoCC = new clsReprocesoCC();
    clsRM266 objRM266 = new clsRM266();

    //clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    //clsSolicitudTramite objSolTram = new clsSolicitudTramite();
    private static long _idInstancia = 0;

    clsBandejaUsuario objBandejaUsuario = new clsBandejaUsuario();

    int IdConexion;
    string Sort_Direction = "IdTramite ASC";

    private Int32 vIdUsuario
    {
        get { return Int32.Parse(ViewState["IdUsuario"].ToString()); }
        set { ViewState["IdUsuario"] = value; }
    }
    private Int32 vIdOficina
    {
        get { return Int32.Parse(ViewState["IdOficina"].ToString()); }
        set { ViewState["IdOficina"] = value; }
    }
    private Int64 vIdTramite
    {
        get { return Int64.Parse(ViewState["IdTramite"].ToString()); }
        set { ViewState["IdTramite"] = value; }
    }
    private Int64 vNUP
    {
        get { return Int64.Parse(ViewState["NUP"].ToString()); }
        set { ViewState["NUP"] = value; }
    }
    private Int32 vIdGrupoBeneficio
    {
        get { return Int32.Parse(ViewState["IdGrupoBeneficio"].ToString()); }
        set { ViewState["IdGrupoBeneficio"] = value; }
    }
    private Int32 vIdTipoTramite
    {
        get { return Int32.Parse(ViewState["IdTipoTramite"].ToString()); }
        set { ViewState["IdTipoTramite"] = value; }
    }
    private Int32 vIdEstadoObjetoProceso
    {
        get { return Int32.Parse(ViewState["IdEstadoObjetoProceso"].ToString()); }
        set { ViewState["IdEstadoObjetoProceso"] = value; }
    }
    private Int32 vNroCertificado
    {
        get { return Int32.Parse(ViewState["NroCertificado"].ToString()); }
        set { ViewState["NroCertificado"] = value; }
    }
    private Int32 vIdTipoCC
    {
        get { return Int32.Parse(ViewState["IdTipoCC"].ToString()); }
        set { ViewState["IdTipoCC"] = value; }
    }
    private Boolean vCertifNecesario
    {
        get { return Boolean.Parse(ViewState["RegistroAPS"].ToString()); }
        set { ViewState["RegistroAPS"] = value; }
    }
    private Boolean vRegistroAPS
    {
        get { return Boolean.Parse(ViewState["RegistroAPS"].ToString()); }
        set { ViewState["RegistroAPS"] = value; }
    }
    private Boolean vRegistroActivo
    {
        get { return Boolean.Parse(ViewState["RegistroActivo"].ToString()); }
        set { ViewState["RegistroActivo"] = value; }
    }
    private Boolean vTramiteNOenBandejaTrabajo
    {
        get { return Boolean.Parse(ViewState["TramiteNOenBandejaTrabajo"].ToString()); }
        set { ViewState["TramiteNOenBandejaTrabajo"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];
            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion(IdConexion);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
                vIdUsuario = Int32.Parse(s10);
                string s14 = dtUsuarioDatos.Rows[0]["IdOficina"].ToString();    //2
                vIdOficina = Int32.Parse(s14);
            }
            else
            {
                //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
                Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
                return;
            }
        }

        if (!Page.IsPostBack)
        {
            ViewState["SortExpr"] = Sort_Direction;

            pnlDetalle02.Visible = false;
            pnlRM266.Visible = false;
            pnlRenumeracion.Visible = false;
            vNroCertificado = 0;
            vRegistroAPS = false;
            vIdTipoCC = 0;

            //wfrmBuscadorDeTramites.aspx?iIdTramite=1073&iIdGrupoBeneficio=3
            if (Request.QueryString["iIdTramite"] != null)
            {
                txtNumeroTramite.Text = Request.QueryString["iIdTramite"];
                //iIdGrupoB.Value = Request.QueryString["iIdGrupoBeneficio"];
                imgBuscar_Click(imgBuscar, null);

                //gvDatosAfiliado_RowCommand(gvDatosAfiliado, null);
                pnlBusqueda.Visible = false;
            }
        }
    }
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        pnlDatosAfiliado.Visible = true;
        pnlDetalle02.Visible = false;
        pnlRM266.Visible = false;
        pnlRenumeracion.Visible = false;

        //pnlNuevaFechaNacimientoRM266.Visible = false;
        vCertifNecesario = false;
        CargaDatosAfiliado(1, txtNumeroTramite.Text, txtPaterno.Text.ToUpper(), txtMaterno.Text.ToUpper(), txtNombres.Text.ToUpper(), Int32.Parse(dllEstadoTramite.SelectedValue), Int32.Parse(dllEstadoCertificado.SelectedValue), Boolean.Parse(dllBandejaTrabajo.SelectedValue));
        gvDatosAfiliado.SelectedIndex = -1;
        pnlDetalle01.Visible = false;
    }
    #region DatosAfiliado
    protected void CargaDatosAfiliado(int pageIndex, string sIdTramite, string sPrimerApellido, string sSegundoApellido, string sNombres, int IdEstadoTramite, int IdEstadoCertificado, bool bBandejaTrabajo)
    {
        Master.MensajeCancel();

        int RecordCount = 0;
        int pageSize = int.Parse(ddlPageSize.SelectedValue);
        sPrimerApellido = sPrimerApellido.ToUpper();
        sSegundoApellido = sSegundoApellido.ToUpper();

        DataTable listado1 = new DataTable();
        objDatosAfiliado.iIdConexion = IdConexion;
        objDatosAfiliado.iPageIndex = pageIndex;
        objDatosAfiliado.iPageSize = pageSize;
        objDatosAfiliado.sIdTramite = sIdTramite;
        objDatosAfiliado.iIdEstadoTramite = IdEstadoTramite;
        objDatosAfiliado.sPrimerApellido = sPrimerApellido;
        objDatosAfiliado.sSegundoApellido = sSegundoApellido;
        objDatosAfiliado.sNombres = sNombres;
        objDatosAfiliado.iIdEstadoCertificado = IdEstadoCertificado;
        objDatosAfiliado.bBandejaTrabajo = bBandejaTrabajo;
        objDatosAfiliado.sOrderBy = ViewState["SortExpr"].ToString(); ;
        if (objDatosAfiliado.ObtieneDatosAfiliadoPag())
        {
            listado1 = objDatosAfiliado.DSet.Tables[0];
            RecordCount = objDatosAfiliado.iRecordCount;
            //gvDatosAfiliado.DataSource = listado1;

            DataView dvlistado1 = listado1.DefaultView;
            dvlistado1.Sort = ViewState["SortExpr"].ToString();
            gvDatosAfiliado.DataSource = dvlistado1;
            gvDatosAfiliado.DataBind();
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        //gvDatosAfiliado.DataBind();

        this.PopulatePager(RecordCount, pageIndex);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        CargaDatosAfiliado(pageIndex, txtNumeroTramite.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, Int32.Parse(dllEstadoTramite.SelectedValue), Int32.Parse(dllEstadoCertificado.SelectedValue), Boolean.Parse(dllBandejaTrabajo.SelectedValue));
        gvDatosAfiliado.SelectedIndex = -1;
        pnlDetalle01.Visible = false;
        //pnlNuevaFechaNacimientoRM266.Visible = false;
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        CargaDatosAfiliado(1, txtNumeroTramite.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, Int32.Parse(dllEstadoTramite.SelectedValue), Int32.Parse(dllEstadoCertificado.SelectedValue), Boolean.Parse(dllBandejaTrabajo.SelectedValue));
        gvDatosAfiliado.SelectedIndex = -1;
        pnlDetalle01.Visible = false;
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        Master.MensajeCancel();
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("|<", "1", currentPage > 1));
            //for (int i = 1; i <= pageCount; i++)
            //{
            //    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //}
            int startPage = currentPage - 5;
            int endPage = currentPage + 5;
            if (startPage < 5) startPage = 1;
            if (endPage > pageCount) endPage = pageCount;
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == startPage & i != 1) pages.Add(new ListItem("...", startPage.ToString(), startPage != currentPage));
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                if (i == endPage & i != pageCount) pages.Add(new ListItem("...", endPage.ToString(), currentPage < pageCount));
            }
            pages.Add(new ListItem(">|", pageCount.ToString(), currentPage < pageCount));
        }
        if (pageCount > 1)
        {
            rptPager.Visible = true;
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
        else
        {
            rptPager.Visible = false;
        }
    }
    protected void gvDatosAfiliado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;

        if (e.CommandName == "DETALLE01")
        {
            Master.MensajeCancel();
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ImageButton imgDetTramite = (ImageButton)gvDatosAfiliado.Rows[index].FindControl("imgDetTramite");
            GridViewRow gRow = (GridViewRow)imgDetTramite.NamingContainer;
            //string s3 = gRow.Cells[2].Text; //IdTramite
            //string s5 = gRow.Cells[4].Text; //Matricula
            //string s6 = gRow.Cells[5].Text; //NUP
            //string s7 = gRow.Cells[6].Text; //TipoTramite
            //string s8 = gRow.Cells[7].Text; //NumDoc

            gvDatosAfiliado.SelectedIndex = index;

            vIdTramite = Int64.Parse(gvDatosAfiliado.DataKeys[gRow.RowIndex]["IdTramite"].ToString());
            vIdGrupoBeneficio = Int32.Parse(gvDatosAfiliado.DataKeys[gRow.RowIndex]["IdGrupoBeneficio"].ToString());
            vIdTipoTramite = Int32.Parse(gvDatosAfiliado.DataKeys[gRow.RowIndex]["IdTipoTramite"].ToString());
            vIdEstadoObjetoProceso = Int32.Parse(gvDatosAfiliado.DataKeys[gRow.RowIndex]["IdEstadoObjetoProceso"].ToString());
            vNUP = Int64.Parse(gvDatosAfiliado.DataKeys[gRow.RowIndex]["NUP"].ToString());
            lblNUP.Text = gvDatosAfiliado.DataKeys[gRow.RowIndex]["NUP"].ToString();
            vRegistroActivo = Boolean.Parse(gvDatosAfiliado.DataKeys[gRow.RowIndex]["RegistroActivo"].ToString());

            //Obtiene Datos del Afiliado
            DataTable dtDatosAfiliadoA = new DataTable();
            DataTable dtDatosAfiliadoB = new DataTable();
            objDatosAfiliado.iIdConexion = IdConexion;
            objDatosAfiliado.iNUP = Int64.Parse(lblNUP.Text);
            objDatosAfiliado.iIdTramite = vIdTramite;
            objDatosAfiliado.iIdGrupoBeneficio = vIdGrupoBeneficio;
            if (objDatosAfiliado.ObtieneDatosEspecificosAfiliado())
            {
                dtDatosAfiliadoA = objDatosAfiliado.DSet.Tables[0];
                dtDatosAfiliadoB = objDatosAfiliado.DSet.Tables[1];
                if (dtDatosAfiliadoA.Rows.Count > 0)
                {
                    lblPrimerApellido.Text = dtDatosAfiliadoA.Rows[0]["PrimerApellido"].ToString();
                    lblSegundoApellido.Text = dtDatosAfiliadoA.Rows[0]["SegundoApellido"].ToString();
                    lblPrimerNombre.Text = dtDatosAfiliadoA.Rows[0]["PrimerNombre"].ToString();
                    lblSegundoNombre.Text = dtDatosAfiliadoA.Rows[0]["SegundoNombre"].ToString();
                    lblSexo.Text = dtDatosAfiliadoA.Rows[0]["Sexo"].ToString();
                    lblCUA.Text = dtDatosAfiliadoA.Rows[0]["CUA"].ToString();
                    lblFechaNacimiento.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoA.Rows[0]["FechaNacimiento"]);
                    //txtFechaNacimientoNueva.Text = lblFechaNacimiento.Text;
                    lblFechaFallecimiento.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoA.Rows[0]["FechaFallecimiento"]);
                    lblEstadoCivil.Text = dtDatosAfiliadoA.Rows[0]["EstadoCivil"].ToString();
                    lblEntidadGestora.Text = dtDatosAfiliadoA.Rows[0]["EntidadGestora"].ToString();
                    lblNombreSubBeneficio.Text = dtDatosAfiliadoA.Rows[0]["NombreSubBeneficio"].ToString();
                    lblSector.Text = dtDatosAfiliadoA.Rows[0]["Sector"].ToString();
                    lblOficinaRegistro.Text = dtDatosAfiliadoA.Rows[0]["OficinaRegistro"].ToString();
                    lblOficinaNotificacion.Text = dtDatosAfiliadoA.Rows[0]["OficinaNotificacion"].ToString();
                    lblFechaInicioTramite.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoA.Rows[0]["FechaInicioTramite"]);
                    lblDescripcionEstadoObjeto.Text = dtDatosAfiliadoA.Rows[0]["DescripcionEstadoObjeto"].ToString();
                }
                if (dtDatosAfiliadoB.Rows.Count > 0)
                {
                    //lblMontoCC.Text = String.Format("{0:f2}", dtDatosAfiliadoB.Rows[0]["MontoCC"]); //206.00
                    //lblMontoCCA.Text = String.Format("{0:f2}", dtDatosAfiliadoB.Rows[0]["MontoCCAceptado"]); //206.00
                    ////lblFechaGeneracion.Text = dtDatosAfiliadoB.Rows[0]["FechaGeneracion"].ToString();
                    //lblFechaCalculo.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaCalculo"]);
                    //lblFechaGeneracion.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaGeneracion"]);
                    //lblFechaAceptacion.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaAceptacion"]);
                    //lblFechaImpresion.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["FechaImpresion"]);
                    //lblPeriodoSalario.Text = String.Format("{0:dd/MM/yyyy}", dtDatosAfiliadoB.Rows[0]["PeriodoSalario"]);
                    //lblSIPimp.Text = dtDatosAfiliadoB.Rows[0]["SIP_impresion"].ToString();
                    //lblDensidadTotal.Text = String.Format("{0:f2}", dtDatosAfiliadoB.Rows[0]["DensidadTotal"]); //206.00 
                }
            }
            else
            {
                //Error
                string DetalleError = objDatosAfiliado.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
            
            pnlRM266.Visible = false;
            CargaDatosCertificado(vIdTramite, vIdGrupoBeneficio);
            CargaSalarioCotizable(vIdTramite, vIdGrupoBeneficio);

            pnlDetalle01.Visible = true;
            pnlDetalle02.Visible = false;
            //pnlNuevaFechaNacimientoRM266.Visible = false;
            hlkTramiteEnReproceso.Visible = false;
            lblMsgRenunciaCCAutomáticaFFAA.Visible = false;
            lblMsgRegistroActivo.Visible = false;
            //lblMsgMatriculaNueva.Visible = false;

            lblTipoReproceso.Visible = false;
            ddlTipoReproceso.Visible = false;
            //ddlTipoReproceso.Items.Add(new ListItem("Elija un Certificado...", "X"));

            //42 Tramite en Reproceso
            //43 Tramite con recalculo terminado
            //52 Renuncia CC Automática FFAA
            //46 Tramite Reprocesado
            if ((vIdEstadoObjetoProceso == 42 || vIdEstadoObjetoProceso == 43) && vRegistroActivo) //Tramite en Reproceso, Tramite con Recalculo Terminado 
            {
                ddlTipoReproceso.Items.Clear();
                ddlTipoReproceso.Visible = false;
                lblTipoReproceso.Visible = false;
                hlkTramiteEnReproceso.Visible = true;
                hlkTramiteEnReproceso.NavigateUrl = "wfrmReprocesos.aspx?iIdTramite=" + vIdTramite + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio;
            }
            if ((vIdEstadoObjetoProceso == 32) && vRegistroActivo) //Certificado Emitido, Tramite con Recalculo Terminado 
            {
                ddlTipoReproceso.Items.Clear();
                ddlTipoReproceso.Visible = false;
                lblTipoReproceso.Visible = false;
                hlkTramiteEnReproceso.Visible = false;
                hlkTramiteEnReproceso.NavigateUrl = "wfrmReprocesos.aspx?iIdTramite=" + vIdTramite + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio;
            }
            if (!vRegistroActivo)
            {
                lblMsgRegistroActivo.Visible = true;
                ddlTipoReproceso.Items.Clear();
                ddlTipoReproceso.Visible = false;
                lblTipoReproceso.Visible = false;
            }
            else
            {
                lblMsgRegistroActivo.Visible = false;
            }
        }
        if (e.CommandName == "Historial") //Historial de Tramite
        {
            Master.MensajeCancel();
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            gvDatosAfiliado.SelectedIndex = currentRowIndex;

            Int64 HIdTramite = Int64.Parse(gvDatosAfiliado.DataKeys[currentRowIndex]["IdTramite"].ToString());
            Int32 HIdGrupoBeneficio = Int32.Parse(gvDatosAfiliado.DataKeys[currentRowIndex]["IdGrupoBeneficio"].ToString());
            lblHIdTramite.Text = HIdTramite.ToString();

            CargarGrillaHistorialTramite(HIdTramite.ToString());
            ModalPopupExtender2.Show();
        }
    }
    protected void gvDatosAfiliado_Sorting(object sender, GridViewSortEventArgs e)
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
        CargaDatosAfiliado(1, txtNumeroTramite.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, Int32.Parse(dllEstadoTramite.SelectedValue), Int32.Parse(dllEstadoCertificado.SelectedValue), Boolean.Parse(dllBandejaTrabajo.SelectedValue));
        gvDatosAfiliado.SelectedIndex = -1;
    }
    #endregion
    protected void chkCertificado_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow gv = (GridViewRow)chk.NamingContainer;
        int rownumber = gv.RowIndex;

        if (chk.Checked)
        {
            int i;
            for (i = 0; i <= gvCertificados.Rows.Count - 1; i++)
            {
                if (i != rownumber)
                {
                    CheckBox chkcheckbox = ((CheckBox)(gvCertificados.Rows[i].FindControl("chkCertificado")));
                    chkcheckbox.Checked = false;
                }
            }
        }

        CheckBox chkCertificado = (CheckBox)sender;

        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox chkRegistroAPS = (CheckBox)gvCertificados.Rows[index].FindControl("chkRegistroAPS");

        //here you can find your control and get value(Id).
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chkCursoPago = (CheckBox)gvCertificados.Rows[selRowIndex].FindControl("chkCursoPago");
        string EstadoCertificado = gvCertificados.DataKeys[selRowIndex]["EstadoCertificado"].ToString();

        if (chkCertificado.Checked == true)
        {
            //Llena opciones correspondientes al tramite
            lblTipoReproceso.Visible = true;
            ddlTipoReproceso.Visible = true;
            ddlTipoReproceso.Items.Clear();
            ddlTipoReproceso.Items.Add(new ListItem("Elija Opcion", "X"));

            if (!chkRegistroAPS.Checked && !chkCursoPago.Checked && vIdEstadoObjetoProceso == 32 && EstadoCertificado == "33")
            {
                ddlTipoReproceso.Items.Add(new ListItem("RENUMERACIONES", "N"));
            }
            if (!chkRegistroAPS.Checked && !chkCursoPago.Checked && vIdEstadoObjetoProceso != 32 && EstadoCertificado != "33")
            {
                ddlTipoReproceso.Items.Add(new ListItem("R.M.266", "R"));
                ddlTipoReproceso.Items.Add(new ListItem("D.S. 28888(ERRORES) - D.S.0822", "E"));
                //ddlTipoReproceso.Items.Add(new ListItem("REC. RECLAMACION", "C"));
                ddlTipoReproceso.Items.Add(new ListItem("RENUMERACIONES", "N"));
            }
            else if (chkRegistroAPS.Checked && !chkCursoPago.Checked)
            {
                ddlTipoReproceso.Items.Add(new ListItem("R.M.266", "R"));
                ddlTipoReproceso.Items.Add(new ListItem("D.S. 28888(ERRORES) - D.S.0822", "E"));
                ddlTipoReproceso.Items.Add(new ListItem("REC. RECLAMACION", "C"));
                ddlTipoReproceso.Items.Add(new ListItem("RENUMERACIONES", "N"));
            }
            else if (chkRegistroAPS.Checked && chkCursoPago.Checked)
            {
                //ddlTipoReproceso.Items.Add(new ListItem("R.M.266", "R"));
                //ddlTipoReproceso.Items.Add(new ListItem("D.S. 28888(ERRORES) - D.S.0822", "E"));
                ddlTipoReproceso.Items.Add(new ListItem("REC. RECLAMACION", "C"));
                //ddlTipoReproceso.Items.Add(new ListItem("RENUMERACIONES", "N"));
            }
        }
        else
        {
            //Borra opciones correspondientes al tramite
            lblTipoReproceso.Visible = false;
            ddlTipoReproceso.Visible = false;
            ddlTipoReproceso.Items.Clear();
        }

        if (vIdEstadoObjetoProceso == 52) //Renuncia CC Automática FFAA
        {
            ddlTipoReproceso.Items.Clear();
            ddlTipoReproceso.Visible = false;
            lblTipoReproceso.Visible = false;
            lblMsgRenunciaCCAutomáticaFFAA.Visible = true;
            hlkTramiteEnReproceso.Visible = false;
        }
        if (vIdEstadoObjetoProceso == 39 || vIdEstadoObjetoProceso == 23) //Renuncia CC Automatica, Tramite con Recurso
        {
            ddlTipoReproceso.Items.Clear();
            ddlTipoReproceso.Visible = false;
            lblTipoReproceso.Visible = false;
        }

        //Si el tramite está en bandeja recién se hacen visibles las opciones caso contrario se borra todo
        if (!vTramiteNOenBandejaTrabajo && chkCertificado.Checked == true)
        {
            //ddlTipoReproceso.Items.Clear();
            //ddlTipoReproceso.Visible = false;
            //lblTipoReproceso.Visible = false;

            //Solo se puede RENUMERAR
            lblTipoReproceso.Visible = true;
            ddlTipoReproceso.Visible = true;
            ddlTipoReproceso.Items.Clear();
            ddlTipoReproceso.Items.Add(new ListItem("Elija Opcion", "X"));
            ddlTipoReproceso.Items.Add(new ListItem("RENUMERACIONES", "N"));
        }
    }
    protected void CargaDatosCertificado(Int64 iIdTramite, Int32 iIdGrupoBeneficio)
    {
        //Datos Certificado
        vCertifNecesario = false;
        DataTable dtDatosCertificado = new DataTable();
        objDatosAfiliado.iIdConexion = IdConexion;
        objDatosAfiliado.iIdTramite = iIdTramite;
        objDatosAfiliado.iIdGrupoBeneficio = iIdGrupoBeneficio;
        if (objDatosAfiliado.ObtieneEstadoDelBeneficio())
        {
            dtDatosCertificado = objDatosAfiliado.DSet.Tables[0];
            gvCertificados.DataSource = dtDatosCertificado;
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);

            pnlRM266.Visible = true;

            ////Si el tramite no está en bandeja no se habilita el chkCertificado
            //vTramiteNOenBandejaTrabajo = objDatosAfiliado.ValidaTramiteEnBandejaTrabajo(IdConexion, iIdTramite, iIdGrupoBeneficio);
            //if (vTramiteNOenBandejaTrabajo)
            //{
            //    pnlRM266.Visible = true;
            //}            
        }
        gvCertificados.DataBind();
    }
    protected void gvCertificados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string IdTramite = gvCertificados.DataKeys[e.Row.RowIndex].Value.ToString();
            string NroCertificado = gvCertificados.DataKeys[e.Row.RowIndex]["NroCertificado"].ToString();
            GridView gvEnviosAPS = e.Row.FindControl("gvEnviosAPS") as GridView;
            string EstadoCertificado = DataBinder.Eval(e.Row.DataItem, "EstadoCertificado").ToString();
            CheckBox chkCertificado = (CheckBox)e.Row.FindControl("chkCertificado");
            chkCertificado.Visible = false;
            ImageButton imgFormularioCalculoCC = (ImageButton)e.Row.FindControl("imgFormularioCalculoCC");
            imgFormularioCalculoCC.Visible = false;
            ImageButton imgViewCertificadoCC = (ImageButton)e.Row.FindControl("imgViewCertificadoCC");
            imgViewCertificadoCC.Visible = false;

            if (EstadoCertificado == "34" || EstadoCertificado == "12")
            {
                e.Row.BackColor = System.Drawing.Color.RoyalBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
                //e.Row.BackColor = System.Drawing.Color.FromName("#6495ED");
                //e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                //e.Row.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32("c6efce", 16));
                chkCertificado.Visible = true;
                vCertifNecesario = true;
            }
            if (EstadoCertificado == "34")
            {
                imgViewCertificadoCC.Visible = true;
            }
            if ((vIdEstadoObjetoProceso == 42 || vIdEstadoObjetoProceso == 43) && vRegistroActivo) //Tramite en Reproceso, Tramite con Recalculo Terminado 
            {
                chkCertificado.Visible = false;
            }
            if ((vIdEstadoObjetoProceso == 32 || EstadoCertificado == "32") && vRegistroActivo) //Certificado Generado - Notificado
            {
                chkCertificado.Visible = true;
            }
            //Si el tramite no está en bandeja no se habilita el chkCertificado
            vTramiteNOenBandejaTrabajo = objDatosAfiliado.ValidaTramiteEnBandejaTrabajo(IdConexion, Int64.Parse(IdTramite), vIdGrupoBeneficio);

            //Datos Envios APS
            DataTable dtDatosEnvios = new DataTable();
            objDatosAfiliado.iIdConexion = IdConexion;
            objDatosAfiliado.iIdTramite = Int64.Parse(IdTramite);
            objDatosAfiliado.iIdTipoTramite = vIdTipoTramite;
            objDatosAfiliado.iNroCertificado = Int32.Parse(NroCertificado);
            if (objDatosAfiliado.ObtieneDatosEnviosAPSxTramite())
            {
                dtDatosEnvios = objDatosAfiliado.DSet.Tables[0];
                gvEnviosAPS.DataSource = dtDatosEnvios;
            }
            else
            {
                //Error
                string DetalleError = objDatosAfiliado.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);
            }
            gvEnviosAPS.DataBind();

            imgFormularioCalculoCC.Visible = false;
            imgViewCertificadoCC.Visible = false;
            chkCertificado.Visible = false;
        }
    }
    protected void imgViewCertificadoCC_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgViewCertificadoCC = sender as ImageButton;
        GridViewRow gRow = (GridViewRow)imgViewCertificadoCC.NamingContainer;
        //string s0 = gvCertificados.DataKeys[gRow.RowIndex].Value.ToString();

        Session["NroCertificado"] = gvCertificados.DataKeys[gRow.RowIndex]["NroCertificado"];
        Session["IdTipoTramite"] = vIdTipoTramite;
        //Response.Redirect("../Reportes/wfrmRptCertificadoCC.aspx");
        //Response.Redirect("../EmisionCertificadoCC/wfrmRenumeracion.aspx?iIdTramite=" + vIdTramite + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio + " ");
    }
    protected void imgFormularioCalculoCC_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgFormularioCalculoCC = sender as ImageButton;
        GridViewRow gRow = (GridViewRow)imgFormularioCalculoCC.NamingContainer;
        //string s0 = gvCertificados.DataKeys[gRow.RowIndex].Value.ToString();

        //--------------vIdTipoTramite=356 / IdTipoCC=359 - Manual-Global
        string iIdTipoCC = gvCertificados.DataKeys[gRow.RowIndex]["IdTipoCC"].ToString();
        string sIdTramite = objSeguridad.URLEncode(vIdTramite.ToString());
        string sIdGrupoBeneficio = objSeguridad.URLEncode(vIdGrupoBeneficio.ToString());
        string sIdTipoCC = objSeguridad.URLEncode(iIdTipoCC);
        //IdTipoCC=359 - Global / IdTipoCC=358 - Mensual
        switch (vIdTipoTramite)
        {
            case 357: //Automatico
                Response.Redirect("../Reportes/wfrmReporteProcedimientoAutomatico.aspx?iIdTramite=" + sIdTramite + "&iIdGrupoBeneficio=" + sIdGrupoBeneficio + "&iIdTipoCC=" + sIdTipoCC + " ");
                break;
            case 356: //Manual
                Response.Redirect("../Reportes/wfrmReporteProcedimientoManual.aspx?iIdTramite=" + sIdTramite + "&iIdGrupoBeneficio=" + sIdGrupoBeneficio + "&iIdTipoCC=" + sIdTipoCC + " ");
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }
    protected void CargaSalarioCotizable(Int64 IdTramite, Int32 IdGrupoBeneficio)
    {
        //Datos Certificado
        DataTable dtSalarioCotizable = new DataTable();
        DataTable dtActualizacionCC = new DataTable();
        DataTable dtFormularioCalculoCC = new DataTable();
        objDatosAfiliado.iIdConexion = IdConexion;
        objDatosAfiliado.iIdTramite = IdTramite;
        objDatosAfiliado.iIdGrupoBeneficio = IdGrupoBeneficio;
        if (objDatosAfiliado.ObtieneSalarioCotizable())
        {
            dtSalarioCotizable = objDatosAfiliado.DSet.Tables[0];
            dtActualizacionCC = objDatosAfiliado.DSet.Tables[1];
            dtFormularioCalculoCC = objDatosAfiliado.DSet.Tables[2];
            gvSalarioCotizable.DataSource = dtSalarioCotizable;
            gvActualizacionCC.DataSource = dtActualizacionCC;
            gvFormularioCalculoCC.DataSource = dtFormularioCalculoCC;
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvSalarioCotizable.DataBind();
        gvActualizacionCC.DataBind();
        gvFormularioCalculoCC.DataBind();
    }
    protected void CargaFormulariosCalculo(Int64 iIdTramite)
    {
        //Datos Certificado
        DataTable dtSalarioCotizable = new DataTable();
        DataTable dtActualizacionCC = new DataTable();
        objDatosAfiliado.iIdConexion = IdConexion;
        objDatosAfiliado.iIdTramite = iIdTramite;
        if (objDatosAfiliado.ObtieneSalarioCotizable())
        {
            dtSalarioCotizable = objDatosAfiliado.DSet.Tables[0];
            dtActualizacionCC = objDatosAfiliado.DSet.Tables[1];
            gvSalarioCotizable.DataSource = dtSalarioCotizable;
            gvActualizacionCC.DataSource = dtActualizacionCC;
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvSalarioCotizable.DataBind();
        gvActualizacionCC.DataBind();
    }
    protected void ddlTipoReproceso_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string var2 = ddlTipoReproceso.SelectedItem.Text;  //RENUMERACION
        pnlDetalle02.Visible = false;
        pnlRM266.Visible = false;
        pnlRenumeracion.Visible = false;
        //pnlNuevaFechaNacimientoRM266.Visible = false;
        switch (ddlTipoReproceso.SelectedValue)
        {
            case "F":   //Cambio Fecha Nacimiento
                //pnlNuevaFechaNacimientoRM266.Visible = true;
                //txtNumeroResolucion2.Text = "";
                //txtFechaResolucion2.Text = "";
                //txtMatriculaNueva.Text = "";
                //pnlDetalle02.Visible = true;
                break;
            case "N":   //RENUMERACION
                pnlRenumeracion.Visible = true;
                break;
            case "R":   //RM266
                pnlDetalle02.Visible = true;
                break;
            case "E":   //D.S. 28888(ERRORES) - D.S.0822
                pnlDetalle02.Visible = true;
                break;
            case "C":   //REC. RECLAMACION
                pnlDetalle02.Visible = true;
                break;
            case "U":   //CAMBIO BENEFICIO PU A CC
                break;
            case "O":   //REPROCESO
                break;
            default:
                break;
        }
    }
    protected void btnGeneraFormularioReproceso_Click(object sender, EventArgs e)
    {
        //Int32 NoFormularioCalculo = 0;
        //DateTime? fFechaCalculo = null;
        //Decimal dMontoCCAceptado = 0;
        //Decimal dSalarioCotizableActualizadoTotal = 0;
        //Decimal dDensidadTotal = 0;
        //Int32 iSIP_impresion = 0;
        Boolean bCursoPago = false;
        vNroCertificado = 0;
        foreach (GridViewRow gRow in this.gvCertificados.Rows)
        {
            if (gRow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkCertificado = (gRow.Cells[0].FindControl("chkCertificado") as CheckBox);
                if (chkCertificado.Checked)
                {
                    Session["IdTipoCC"] = gvCertificados.DataKeys[gRow.RowIndex]["IdTipoCC"];

                    string NroCertificado = gvCertificados.DataKeys[gRow.RowIndex]["NroCertificado"].ToString();
                    vNroCertificado = Int32.Parse(NroCertificado);
                    //NoFormularioCalculo = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["NoFormularioCalculo"].ToString()) ? 0 : Int32.Parse(gvCertificados.DataKeys[gRow.RowIndex]["NoFormularioCalculo"].ToString()));
                    //fFechaCalculo = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["FechaCalculo"].ToString()) ? (DateTime?)null : DateTime.Parse(gvCertificados.DataKeys[gRow.RowIndex]["FechaCalculo"].ToString()));
                    //fFechaCalculo = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["FechaEmision"].ToString()) ? (DateTime?)null : DateTime.Parse(gvCertificados.DataKeys[gRow.RowIndex]["FechaEmision"].ToString()));
                    //dMontoCCAceptado = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["MontoCCAceptado"].ToString()) ? 0 : Decimal.Parse(gvCertificados.DataKeys[gRow.RowIndex]["MontoCCAceptado"].ToString()));
                    //dSalarioCotizableActualizadoTotal = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["SalarioCotizableActualizadoTotal"].ToString()) ? 0 : Decimal.Parse(gvCertificados.DataKeys[gRow.RowIndex]["SalarioCotizableActualizadoTotal"].ToString()));
                    //dDensidadTotal = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["DensidadTotal"].ToString()) ? 0 : Decimal.Parse(gvCertificados.DataKeys[gRow.RowIndex]["DensidadTotal"].ToString()));
                    //iSIP_impresion = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["SIP_impresion"].ToString()) ? 0 : Int32.Parse(gvCertificados.DataKeys[gRow.RowIndex]["SIP_impresion"].ToString()));
                    //string IdTipoCC = gvCertificados.DataKeys[gRow.RowIndex]["IdTipoCC"].ToString();
                    //vIdTipoCC = Int32.Parse(IdTipoCC);
                    //vRegistroAPS = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["RegistroAPS"].ToString()) ? false : Boolean.Parse(gvCertificados.DataKeys[gRow.RowIndex]["RegistroAPS"].ToString()));
                    //bCursoPago = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["CursoPago"].ToString()) ? false : Boolean.Parse(gvCertificados.DataKeys[gRow.RowIndex]["CursoPago"].ToString()));

                    Session["NroCertificado"] = vNroCertificado;
                    Session["IdTipoCC"] = vIdTipoCC;
                }
            }
        }
        if (vCertifNecesario && vNroCertificado == 0)
        {
            CustomValidator1.IsValid = false;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Debe Elegir un Certificado!');", true);
        }
        if (ddlTipoReproceso.SelectedItem.Value == "X")
        {
            CustomValidator2.IsValid = false;
        }
        if (ddlTipoReproceso.SelectedItem.Value == "R" && bCursoPago)
        {
            CustomValidator3.IsValid = false;
        }

        if (Page.IsValid)
        {
            objReprocesoCC.iIdConexion = IdConexion;
            objReprocesoCC.iIdTramite = vIdTramite;
            objReprocesoCC.iIdGrupoBeneficio = vIdGrupoBeneficio;
            objReprocesoCC.iIdTipoTramite = vIdTipoTramite;
            objReprocesoCC.iNUP = vNUP;
            objReprocesoCC.iNumeroResolucion = txtNumeroResolucion.Text;
            objReprocesoCC.iFechaResolucion = string.IsNullOrEmpty(txtFechaResolucion.Text) ? (DateTime?)null : DateTime.Parse(txtFechaResolucion.Text);
            //objReprocesoCC.iNoFormularioCalculo = NoFormularioCalculo;
            //objReprocesoCC.fFechaCalculo = fFechaCalculo;
            //objReprocesoCC.dMontoCCAceptado = dMontoCCAceptado;
            //objReprocesoCC.dSalarioCotizableActualizadoTotal = dSalarioCotizableActualizadoTotal;
            //objReprocesoCC.dDensidadTotal = dDensidadTotal;
            //objReprocesoCC.iSIP_impresion = iSIP_impresion;
            //objReprocesoCC.bRegistroAPS = vRegistroAPS;
            //objReprocesoCC.bCursoPago = bCursoPago;
            objReprocesoCC.iIdUsuario = vIdUsuario;
            objReprocesoCC.iNroCertificado = vNroCertificado;
            //objReprocesoCC.iIdTipoCC = vIdTipoCC;
            objReprocesoCC.cCodigoReproceso = ddlTipoReproceso.SelectedItem.Value;
            if (objReprocesoCC.InsertaFormularioReproceso())
            {
                int NroFormularioRepro = objReprocesoCC.iNroFormularioRepro;
                Response.Redirect("wfrmReprocesos.aspx?iIdTramite=" + vIdTramite.ToString() + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio.ToString());
            }
            else
            {
                //Error
                string DetalleError = objDatosAfiliado.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void imgRenumeraCertificado_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();

        //Recupera datos del grid
        Int32 NoFormularioCalculo = 0;
        DateTime? fFechaCalculo = null;
        Decimal dMontoCCAceptado = 0;
        Decimal dSalarioCotizableActualizadoTotal = 0;
        Decimal dDensidadTotal = 0;
        Int32 iSIP_impresion = 0;
        Boolean bCursoPago = false;
        vNroCertificado = 0; string EstadoCertificado = "";
        foreach (GridViewRow gRow in this.gvCertificados.Rows)
        {
            if (gRow.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkCertificado = (gRow.Cells[0].FindControl("chkCertificado") as CheckBox);
                if (chkCertificado.Checked)
                {
                    Session["IdTipoCC"] = gvCertificados.DataKeys[gRow.RowIndex]["IdTipoCC"];

                    string NroCertificado = gvCertificados.DataKeys[gRow.RowIndex]["NroCertificado"].ToString();
                    EstadoCertificado = gvCertificados.DataKeys[gRow.RowIndex]["EstadoCertificado"].ToString();
                    vNroCertificado = Int32.Parse(NroCertificado);
                    NoFormularioCalculo = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["NoFormularioCalculo"].ToString()) ? 0 : Int32.Parse(gvCertificados.DataKeys[gRow.RowIndex]["NoFormularioCalculo"].ToString()));
                    //fFechaCalculo = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["FechaCalculo"].ToString()) ? (DateTime?)null : DateTime.Parse(gvCertificados.DataKeys[gRow.RowIndex]["FechaCalculo"].ToString()));
                    fFechaCalculo = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["FechaEmision"].ToString()) ? (DateTime?)null : DateTime.Parse(gvCertificados.DataKeys[gRow.RowIndex]["FechaEmision"].ToString()));
                    dMontoCCAceptado = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["MontoCCAceptado"].ToString()) ? 0 : Decimal.Parse(gvCertificados.DataKeys[gRow.RowIndex]["MontoCCAceptado"].ToString()));
                    dSalarioCotizableActualizadoTotal = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["SalarioCotizableActualizadoTotal"].ToString()) ? 0 : Decimal.Parse(gvCertificados.DataKeys[gRow.RowIndex]["SalarioCotizableActualizadoTotal"].ToString()));
                    dDensidadTotal = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["DensidadTotal"].ToString()) ? 0 : Decimal.Parse(gvCertificados.DataKeys[gRow.RowIndex]["DensidadTotal"].ToString()));
                    iSIP_impresion = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["SIP_impresion"].ToString()) ? 0 : Int32.Parse(gvCertificados.DataKeys[gRow.RowIndex]["SIP_impresion"].ToString()));
                    string IdTipoCC = gvCertificados.DataKeys[gRow.RowIndex]["IdTipoCC"].ToString();
                    vIdTipoCC = Int32.Parse(IdTipoCC);
                    vRegistroAPS = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["RegistroAPS"].ToString()) ? false : Boolean.Parse(gvCertificados.DataKeys[gRow.RowIndex]["RegistroAPS"].ToString()));
                    bCursoPago = (String.IsNullOrEmpty(gvCertificados.DataKeys[gRow.RowIndex]["CursoPago"].ToString()) ? false : Boolean.Parse(gvCertificados.DataKeys[gRow.RowIndex]["CursoPago"].ToString()));

                    Session["NroCertificado"] = vNroCertificado;
                    Session["IdTipoCC"] = vIdTipoCC;
                }
            }
        }
        if (vCertifNecesario && vNroCertificado == 0)
        {
            CustomValidator1.IsValid = false;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Debe Elegir un Certificado!');", true);
        }

        if (Page.IsValid)
        {
            //if (!vRegistroAPS && !bCursoPago && (EstadoCertificado == "33" || EstadoCertificado == "34"))
            if (true)
            {
                Session["NroFormularioRepro"] = -99;
                Session["RegistroAPS"] = vRegistroAPS;
                Session["IdTramite"] = vIdTramite;
                Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
                Session["NroCertificado"] = vNroCertificado;
                Session["IdTipoTramite"] = vIdTipoTramite;
                Session["IdTipoReproceso"] = -99;

                //Response.Redirect("~/Reportes/wfrmReporteCertificadoCCReproceso.aspx");
                Response.Redirect("~/EmisionCertificadoCC/wfrmRenumeracion.aspx?IdUsuario=" + vIdUsuario + "&IdOficina=" + vIdOficina + "&iIdTramite=" + vIdTramite + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio);
            }
            else
            {
                //Error
                string DetalleError = "No es posible Renumerar el Certificado, <br> posiblemente el Certificado está en curso de pago <br> o el Certificado fué registrado en la APS <br> o el Certificado está en estado diferente de generado o impreso";
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        pnlRenumeracion.Visible = false;
        ddlTipoReproceso.SelectedValue = "X";
    }
    #region HistorialTramite Popup
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
    #region RM266
    protected void imgRM266CambiarFechaNacimiento_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        //Session["NroFormularioRepro"] = vNroFormularioRepro;
        //Session["RegistroAPS"] = vRegistroAPS;
        //Session["IdTramite"] = vIdTramite;
        //Session["IdGrupoBeneficio"] = vIdGrupoBeneficio;
        //Session["NroCertificado"] = vNroCertificado;
        //Session["IdTipoTramite"] = vIdTipoTramite;
        //Session["IdTipoReproceso"] = vIdTipoReproceso;

        ////Formulario de Cálculo elegido
        //ImageButton imgImprimeCertificado = sender as ImageButton;
        //GridViewRow gRow = (GridViewRow)imgImprimeCertificado.NamingContainer;
        //int NoFormularioCalculo = Int32.Parse(gvGImpCertificados.DataKeys[gRow.RowIndex]["NoFormularioCalculo"].ToString());

        //Session["NoFormularioCalculo"] = NoFormularioCalculo;

        //Reprocesos/wfrmRM266CambiaFechaNacimiento.aspx?iIdTramite=218318&iIdGrupoBeneficio=3
        Response.Redirect("~/Reprocesos/wfrmRM266CambiaFechaNacimiento.aspx?iIdTramite=" + vIdTramite + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio);        
    }
    #endregion
}