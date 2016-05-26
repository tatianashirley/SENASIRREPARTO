﻿using System;
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

public partial class Reprocesos_wfrmRegistroReprocesos : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsDatosAfiliado objDatosAfiliado = new clsDatosAfiliado();
    clsReprocesoCC objReprocesoCC = new clsReprocesoCC();
    clsRM266 objRM266 = new clsRM266();

    int IdConexion;
    private Int32 vIdUsuario
    {
        get { return Int32.Parse(ViewState["IdUsuario"].ToString()); }
        set { ViewState["IdUsuario"] = value; }
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
            pnlDetalle02.Visible = false;
            vNroCertificado = 0;
            vRegistroAPS = false;
            vIdTipoCC = 0;

            //Reprocesos/wfrmRegistroReprocesos.aspx?iIdTramite=1073&iIdGrupoBeneficio=3
            if (Request.QueryString["iIdTramite"] != null)
            {
                vIdTramite = Int64.Parse(Request.QueryString["iIdTramite"]);
                vIdGrupoBeneficio = Int32.Parse(Request.QueryString["iIdGrupoBeneficio"]);
                imgBuscar_Click();
            }
            else
            {
                Response.Redirect("../Inicio.aspx");
            }
        }
    }
    protected void imgBuscar_Click()
    {
        pnlDatosAfiliado.Visible = true;
        pnlDetalle02.Visible = false;
        //pnlNuevaFechaNacimientoRM266.Visible = false;
        vCertifNecesario = false;
        CargaDatosAfiliado(1, vIdTramite, vIdGrupoBeneficio);
        gvDatosAfiliado.SelectedIndex = -1;
        pnlDetalle01.Visible = false;
    }
    #region DatosAfiliado
    protected void CargaDatosAfiliado(int pageIndex, long iIdTramite, int iIdGrupoBeneficio)
    {
        int RecordCount = 0;
        int pageSize = int.Parse(ddlPageSize.SelectedValue);

        DataTable listado1 = new DataTable();
        objDatosAfiliado.iIdConexion = IdConexion;
        objDatosAfiliado.iPageIndex = pageIndex;
        objDatosAfiliado.iPageSize = pageSize;
        objDatosAfiliado.iIdTramite = iIdTramite;
        objDatosAfiliado.iIdGrupoBeneficio = iIdGrupoBeneficio;
        if (objDatosAfiliado.ObtieneDatosAfiliadoUnico())
        {
            listado1 = objDatosAfiliado.DSet.Tables[0];
            RecordCount = objDatosAfiliado.iRecordCount;
            gvDatosAfiliado.DataSource = listado1;
        }
        else
        {
            //Error
            string DetalleError = objDatosAfiliado.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvDatosAfiliado.DataBind();

        this.PopulatePager(RecordCount, pageIndex);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        CargaDatosAfiliado(pageIndex, vIdTramite, vIdGrupoBeneficio);
        gvDatosAfiliado.SelectedIndex = -1;
        pnlDetalle01.Visible = false;
        //pnlNuevaFechaNacimientoRM266.Visible = false;
    }
    protected void PageSize_Changed(object sender, EventArgs e)
    {
        CargaDatosAfiliado(1, vIdTramite, vIdGrupoBeneficio);
        gvDatosAfiliado.SelectedIndex = -1;
        pnlDetalle01.Visible = false;
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
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

            CargaDatosCertificado(vIdTramite,vIdGrupoBeneficio);
            CargaSalarioCotizable(vIdTramite,vIdGrupoBeneficio);

            pnlDetalle01.Visible = true;
            pnlDetalle02.Visible = false;
            //pnlNuevaFechaNacimientoRM266.Visible = false;
            hlkTramiteEnReproceso.Visible = false;
            lblMsgRenunciaCCAutomáticaFFAA.Visible = false;
            //lblMsgMatriculaNueva.Visible = false;

            //Llena opciones correspondientes al tramite
            lblTipoReproceso.Visible = true;
            ddlTipoReproceso.Visible = true;
            ddlTipoReproceso.Items.Clear();
            ddlTipoReproceso.Items.Add(new ListItem("Elija Opcion", "X"));
            //if (vCertifNecesario && vNroCertificado == 0)
            if (vCertifNecesario)
            {
                ddlTipoReproceso.Items.Add(new ListItem("R.M.266", "R"));
                ddlTipoReproceso.Items.Add(new ListItem("D.S. 28888(ERRORES) - D.S.0822", "E"));
                ddlTipoReproceso.Items.Add(new ListItem("REC. RECLAMACION", "C"));
            }
            else
            {
                //ddlTipoReproceso.Items.Add(new ListItem("Cambio de Fecha de Nacimiento", "F"));
                //ddlTipoReproceso.Items.Add(new ListItem("R.M.266", "F"));
                ddlTipoReproceso.Items.Clear();
                ddlTipoReproceso.Visible = false;
                lblTipoReproceso.Visible = false;
            }
            //42 Tramite en Reproceso
            //43 Tramite con recalculo terminado
            //52 Renuncia CC Automática FFAA
            //46 Tramite Reprocesado
            if ((vIdEstadoObjetoProceso == 42 || vIdEstadoObjetoProceso == 43) && vRegistroActivo) //Tramite en Reproceso, Tramite con Recalculo Terminado 
            {
                ddlTipoReproceso.Items.Clear();
                ddlTipoReproceso.Visible = false;
                lblTipoReproceso.Visible = false;
                //vIdTramite,vIdGrupoBeneficio
                hlkTramiteEnReproceso.NavigateUrl = "~/Reprocesos/wfrmReprocesos.aspx?iIdTramite=" + vIdTramite.ToString() + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio.ToString();
                hlkTramiteEnReproceso.Visible = true;
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
    }
    #endregion
    protected void CargaDatosCertificado(Int64 iIdTramite,Int32 iIdGrupoBeneficio)
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
            Image imgPlus = (Image)e.Row.FindControl("imgPlus");
            chkCertificado.Visible = false;
            ImageButton imgRenumeraCertificadoCC = (ImageButton)e.Row.FindControl("imgRenumeraCertificadoCC");
            imgRenumeraCertificadoCC.Visible = false;

            if (EstadoCertificado == "34" || EstadoCertificado == "12" || EstadoCertificado == "37")
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
                imgRenumeraCertificadoCC.Visible = true;
            }
            //Datos Envios APS
            DataTable dtDatosEnvios = new DataTable();
            objDatosAfiliado.iIdConexion = IdConexion;
            objDatosAfiliado.iIdTramite = Int32.Parse(IdTramite);
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
                imgPlus.Visible = false;
            }
            gvEnviosAPS.DataBind();
        }
    }
    protected void imgRenumeraCertificadoCC_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgRenumeraCertificadoCC = sender as ImageButton;
        GridViewRow gRow = (GridViewRow)imgRenumeraCertificadoCC.NamingContainer;
        //string s0 = gvCertificados.DataKeys[gRow.RowIndex].Value.ToString();

        Session["NroCertificado"] = gvCertificados.DataKeys[gRow.RowIndex]["NroCertificado"];
        Session["IdTipoTramite"] = vIdTipoTramite;
        //Response.Redirect("../Reportes/wfrmRptCertificadoCC.aspx");
        Response.Redirect("../EmisionCertificadoCC/wfrmRenumeracion.aspx?iIdTramite=" + vIdTramite + "&iIdGrupoBeneficio=" + vIdGrupoBeneficio + " ");
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
    protected void CargaSalarioCotizable(Int64 IdTramite,Int32 IdGrupoBeneficio)
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
        Int32 NoFormularioCalculo = 0;
        DateTime? fFechaCalculo = null;
        Decimal dMontoCCAceptado = 0;
        Decimal dSalarioCotizableActualizadoTotal = 0;
        Decimal dDensidadTotal = 0;
        Int32 iSIP_impresion = 0;
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
            objReprocesoCC.iNoFormularioCalculo = NoFormularioCalculo;
            objReprocesoCC.fFechaCalculo = fFechaCalculo;
            objReprocesoCC.dMontoCCAceptado = dMontoCCAceptado;
            objReprocesoCC.dSalarioCotizableActualizadoTotal = dSalarioCotizableActualizadoTotal;
            objReprocesoCC.dDensidadTotal = dDensidadTotal;
            objReprocesoCC.iSIP_impresion = iSIP_impresion;
            objReprocesoCC.bRegistroAPS = vRegistroAPS;
            objReprocesoCC.bCursoPago = bCursoPago;
            objReprocesoCC.iIdUsuario = vIdUsuario;
            objReprocesoCC.iNroCertificado = vNroCertificado;
            objReprocesoCC.iIdTipoCC = vIdTipoCC;
            objReprocesoCC.cCodigoReproceso = ddlTipoReproceso.SelectedItem.Value;
            if (objReprocesoCC.InsertaFormularioReproceso())
            {
                int NroFormularioRepro = objReprocesoCC.iNroFormularioRepro;
            }
            else
            {
                //Error
                string DetalleError = objDatosAfiliado.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
            Response.Redirect("wfrmReprocesos.aspx");
        }
    }
}