using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using wcfEmisionCertificadoCC.Logica;  // cambiar clase
//using WcfServicioClasificador.Logica;

using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;
using System.Data;

public partial class WorkFlow_wfrmEjecucionActividades : System.Web.UI.Page
{
    clsSeguridad objSeguridad = new clsSeguridad();
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    clsInstanciaNodoConcepto ObjINodoCpto = new clsInstanciaNodoConcepto();
    clsInstanciaNodoDocumento ObjINodoDocmto = new clsInstanciaNodoDocumento();
    clsInstanciaNodoLink ObjINodoLnk = new clsInstanciaNodoLink();

    clsSolicitudTramite objSolTram = new clsSolicitudTramite();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;
    string instancia, secuencia;

    private String vIdTramite
    {
        get { object obj = ViewState["IdTramite"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["IdTramite"] = value; }
    }
    private String vIdGrupoBeneficio
    {
        get { object obj = ViewState["IdGrupoBeneficio"]; return (obj == null) ? String.Empty : (string)obj; }
        set { ViewState["IdGrupoBeneficio"] = value; }
    }

    private String sTipoDato
    {
        get
        {
            object obj = ViewState["sTipoDato"];
            return (obj == null) ? String.Empty : (string)obj;
        }
        set { ViewState["sTipoDato"] = value; }
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
            //IdConexion = 5638;
        }

        instancia = Request.QueryString["inst"];
        secuencia = Request.QueryString["sec"];

        if (!Page.IsPostBack)
        {
            CargaDatosTramite();
            CargaConceptosXActividad();
            CargaDocumentosXActividad();
            CargaEnlacesDisponibles();
            CargaTransicionesPosibles();
            btnTransicion.Enabled = false;
            pnlHistorialTramites.Visible = false;
        }
    }
    # region cargar_datos
    protected void CargaDatosTramite()
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdInstancia = Convert.ToInt64(instancia); //Request.QueryString("rf")
        ObjInstanciaNodo.iSecuencia = Convert.ToInt32(secuencia);
        DataTable dtDatosTramite = new DataTable();

        if (ObjInstanciaNodo.ObtieneFila())
        {
            dtDatosTramite = ObjInstanciaNodo.DSet.Tables[0];
            txtNroTramite.Text = dtDatosTramite.Rows[0]["IdTramite"].ToString();
            txtTipoTramite.Text = dtDatosTramite.Rows[0]["IdTipoTramite"].ToString();
            txtBeneficiario.Text = dtDatosTramite.Rows[0]["NombreBeneficiario"].ToString();
            txtCI.Text = dtDatosTramite.Rows[0]["DocIdBeneficiario"].ToString();
            txtGrupoBeneficio.Text = dtDatosTramite.Rows[0]["DescripcionGrupoBeneficio"].ToString();
            txtFlujo.Text = dtDatosTramite.Rows[0]["DescFlujo"].ToString();
            txtActividad.Text = dtDatosTramite.Rows[0]["DescNodo"].ToString();
            txtComentarios.Text = dtDatosTramite.Rows[0]["Comentarios"].ToString();

            vIdTramite = dtDatosTramite.Rows[0]["IdTramite"].ToString();
            vIdGrupoBeneficio = dtDatosTramite.Rows[0]["IdGrupoBeneficio"].ToString();
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void CargaConceptosXActividad()
    {
        ObjINodoCpto.iIdConexion = IdConexion;
        ObjINodoCpto.iIdInstancia = Convert.ToInt64(instancia);
        ObjINodoCpto.iSecuencia = Convert.ToInt32(secuencia);
        if (ObjINodoCpto.ObtieneConceptosXActividad())
        {
            pnlGrilla1.Visible = true;
            gvDatosAdicionales.DataSource = ObjINodoCpto.DSet.Tables[0];
            gvDatosAdicionales.DataBind();
        }
        else
        {
            //Error
            pnlGrilla1.Visible = false;
            string DetalleError = ObjINodoCpto.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    protected void CargaDocumentosXActividad()
    {
        ObjINodoDocmto.iIdConexion = IdConexion;
        ObjINodoDocmto.iIdInstancia = Convert.ToInt64(instancia);
        ObjINodoDocmto.iSecuencia = Convert.ToInt32(secuencia);
        if (ObjINodoDocmto.ObtieneDocumentosXActividad())
        {
            pnlGrilla2.Visible = true;
            gvDocumento.DataSource = ObjINodoDocmto.DSet.Tables[0];
            gvDocumento.DataBind();
        }
        else
        {
            //Error
            pnlGrilla2.Visible = false;
            string DetalleError = ObjINodoDocmto.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    protected void CargaEnlacesDisponibles()
    {
        ObjINodoLnk.iIdConexion = IdConexion;
        ObjINodoLnk.iIdInstancia = Convert.ToInt32(instancia);
        ObjINodoLnk.iSecuencia = Convert.ToInt16(secuencia);
        if (ObjINodoLnk.ObtieneLinksDisponibles())
        {
            pnlLinks.Visible = true;
            gvEnlaces.DataSource = ObjINodoLnk.DSet.Tables[0];
            gvEnlaces.DataBind();
        }
        else
        {
            //Error
            pnlLinks.Visible = false;
            string DetalleError = ObjINodoLnk.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    protected void CargaTransicionesPosibles()
    {
        pnlTransiciones.Visible = false;

        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdHisInstancia = Convert.ToInt32(instancia);
        ObjInstanciaNodo.iSecuencia = Convert.ToInt32(secuencia);
        ObjInstanciaNodo.bFlagManual = true;
        if (ObjInstanciaNodo.ObtieneTransicionesPosibles())
        {
            gvTransiciones.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            gvTransiciones.DataBind();
            
            if (ObjInstanciaNodo.DSet.Tables[0].Rows.Count > 0)
            {
                pnlTransiciones.Visible = true;
            }
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }

    #endregion
    #region Acciones_botones
   // ACCIONES BOTONES PANEL POPUPDATOS
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        ObjINodoCpto.iIdConexion = IdConexion;
        ObjINodoCpto.iIdInstancia = Convert.ToInt64(instancia);
        ObjINodoCpto.iSecuencia = Convert.ToInt32(secuencia);
        ObjINodoCpto.sIdConcepto = lblIdConcepto.Text;
        ObjINodoCpto.sValorGenerico = txtValor.Text;
        ObjINodoCpto.sTipoDato = sTipoDato;
        if (!ObjINodoCpto.Grabar())
        {
            //Error
            pnlGrilla1.Visible = false;
            string DetalleError = ObjINodoCpto.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        Response.Redirect("wfrmEjecucionActividades.aspx?inst=" + instancia + "&sec=" + secuencia);
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        ObjINodoCpto.iIdConexion = IdConexion;
        ObjINodoCpto.iIdInstancia = Convert.ToInt64(instancia);
        ObjINodoCpto.iSecuencia = Convert.ToInt32(secuencia);
        ObjINodoCpto.sIdConcepto = lblIdConcepto.Text;
        //ObjINodoCpto.sValorGenerico = txtValor.Text;
        //ObjINodoCpto.sTipoDato = sTipoDato;
        if (!ObjINodoCpto.Eliminacion())
        {
            //Error
            pnlGrilla1.Visible = false;
            string DetalleError = ObjINodoCpto.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        Response.Redirect("wfrmEjecucionActividades.aspx?inst=" + instancia + "&sec=" + secuencia);
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
    //ACCIONES BOTONES PANEL POPUP DOCUEMENTOS
    protected void btnAccionarDoc_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancelarDoc_Click(object sender, EventArgs e)
    {

    }
    //ACCIONES BOTONES DE PANEL PNLTRANSICIONES
    protected void btnTransicion_Click2(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Realiza la Transición con normalidad!!');", true);
    }
    protected void btnTransicion_Click(object sender, EventArgs e)
    {
        //int iIdConexion = (int)Session["IdConexion"];
        //string cOperacion = "I";
        //string sMensajeError = null;
        string cadenaIdNodos = "";
        foreach (GridViewRow row in this.gvTransiciones.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRol = (row.Cells[0].FindControl("chktrans") as CheckBox);
                if (chkRol.Checked)
                {
                    Label lblIdNodo = (row.Cells[1].FindControl("lblIdNodo") as Label);
                    cadenaIdNodos = cadenaIdNodos + lblIdNodo.Text + ",";
                }
            }
        }
        cadenaIdNodos = cadenaIdNodos.Remove(cadenaIdNodos.Length - 1);
        //Procesa....(cadenaIdNodos)
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdInstancia = Convert.ToInt64(instancia);
        ObjInstanciaNodo.iSecuencia = Convert.ToInt32(secuencia);
        ObjInstanciaNodo.sComentarios = txtComentario.Text;
        ObjInstanciaNodo.sIdListaNodoTrg = cadenaIdNodos;
        ObjInstanciaNodo.bFlagManual = true;
        if (ObjInstanciaNodo.RealizaTransicion())
        {
            Response.Redirect("wfrmBandejaTramites.aspx");
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    #endregion

    protected void gvDatosAdicionales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DatosAdicionales")
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            lblIdConcepto.Text = gvDatosAdicionales.DataKeys[currentRowIndex].Value.ToString();
            lblConcepto.Text = gvDatosAdicionales.DataKeys[currentRowIndex]["Descripcion"].ToString();
            txtValor.Text = gvDatosAdicionales.DataKeys[currentRowIndex]["Valor"].ToString();
            sTipoDato = gvDatosAdicionales.DataKeys[currentRowIndex]["TipoDato"].ToString();

            pnlPopupDatos_ModalPopupExtender.Show();
        }
    }
    protected void btnHistorialTramite_Click(object sender, EventArgs e)
    {
        //Response.Redirect("wfrmHistorialEjecucion.aspx?inst=" + instancia + "&sec=" + secuencia);
        pnlHistorialTramites.Visible = true;
        lblHIdTramite.Text = vIdTramite;
        lblHIdGrupoBeneficio.Text = vIdGrupoBeneficio;
        CargarGrillaBusquedaMaestra(Int64.Parse(vIdTramite), Int32.Parse(vIdGrupoBeneficio));
    }
    #region HistorialTramite
    //---------------------------------------
    private void CargarGrillaBusquedaMaestra(long IdTramite, int IdGrupoBeneficio)
    {
        objSolTram.iIdConexion = IdConexion;
        objSolTram.sNombres = null;
        objSolTram.sApellidoPaterno = null;
        objSolTram.sApellidoMaterno = null;
        objSolTram.sNumeroDocumento = null;
        objSolTram.iIdTramite = IdTramite;
        if (objSolTram.Busqueda())
        {
            var dt = objSolTram.DSet.Tables[0];
            gvBusqMaestro.DataSource = dt;
            gvBusqMaestro.DataBind();

            CargarGrillaDetalle(Convert.ToInt64(instancia));
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla la busqueda", objSolTram.sMensajeError);
            gvBusqMaestro.DataSource = null;
            gvBusqMaestro.DataBind();
        }
    }
    private void CargarGrillaDetalle(long pInstancia)
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdInstancia = pInstancia;

        if (ObjInstanciaNodo.ObtieneHistorialEjecucion())
        {
            gvDetalle.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            gvDetalle.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla de historial", objSolTram.sMensajeError);
            gvDetalle.DataSource = null;
            gvDetalle.DataBind();
        }
    }
    protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDetalle.PageIndex = e.NewPageIndex;
            CargarGrillaDetalle(Convert.ToInt64(instancia));
        }
        catch (Exception Ex)
        {
            Master.MensajeError("Se produjo un error al recorrer la grilla de Historial", Ex.Message);
        }
    }
    #endregion

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/Workflow/wfrmBandejaTramites.aspx");
    }
    protected void gvEnlaces_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        return;
        // Check if the row that is being bound, is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[15].Text solo para campos del tipo BoundField

            //Finding the TemplateField
            string Enlace = DataBinder.Eval(e.Row.DataItem, "Enlace").ToString();
            string EnlaceEncriptado = URLencriptaParams(Enlace);
            if (!String.IsNullOrEmpty(EnlaceEncriptado))
            {
                HyperLink hlkEnlace = (HyperLink)e.Row.FindControl("hlkEnlace");
                hlkEnlace.Text = EnlaceEncriptado;
                hlkEnlace.NavigateUrl = EnlaceEncriptado;
            }
        }
    }
    protected String URLencriptaParams(string queryString)
    {
        //String queryString = @"http://domain.test/Default.aspx?var1=true&var2=test&var3=3";
        String queryStringResult = "";
        string[] querySegments = queryString.Split('&');
        foreach (string segment in querySegments)
        {
            string[] parts2 = segment.Split('=');
            if (parts2.Length > 0)
            {
                string key = parts2[0].Trim(new char[] { '?', ' ' });
                string val = parts2[1].Trim();

                queryStringResult = queryStringResult + key + "=" + objSeguridad.Encriptar(val) + "&";
            }
        }
        queryStringResult = queryStringResult.Substring(0, queryStringResult.Length - 1);

        return queryStringResult;
    }
}