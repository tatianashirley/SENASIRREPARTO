using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmProcesosTransicion : System.Web.UI.Page
{
    private clsFlujoNodoPredecesorProceso objFNPProc = new clsFlujoNodoPredecesorProceso();
    private clsFlujoNodoPredecesorProcesoPrm objFNPProcPrm = new clsFlujoNodoPredecesorProcesoPrm();

    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private int _idFlujo;
    private string _flujo, _nodoPred, _nodo;
    private short _idNodoPred, _idNodo;
    private Dictionary<string, string> _dic = new Dictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            _idConexion = (int)Session["IdConexion"];

            _dic = (Dictionary<string, string>)Session["dicNF"];
            _idTipoTramite = _dic["IdTipTram"];
            _tipoTramite = _dic["TipTram"];
            _idFlujo = Convert.ToInt32(_dic["IdFluj"]);
            _flujo = _dic["Fluj"];
            _idNodo = Convert.ToInt16(_dic["IdNod"]);
            _nodo = _dic["Nod"];
            _idNodoPred = Convert.ToInt16(_dic["IdNodPred"]);
            _nodoPred = _dic["NodPred"];
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;
            txtFlujo.Text = _flujo;
            CargarCboActividad(cboActPredecesora);
            CargarCboActividad(cboActividad);
            cboActPredecesora.SelectedValue = _idNodoPred.ToString();
            cboActividad.SelectedValue = _idNodo.ToString();
            CargarGrillaProcesos();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS_MAESTRO

    private void AsignarValoresPivote()
    {
        objFNPProc.iIdConexion = _idConexion;
        objFNPProc.iIdFlujo = _idFlujo;
        objFNPProc.iIdNodoPred = _idNodoPred;
        objFNPProc.iIdNodo = _idNodo;

        if (!String.IsNullOrEmpty(txtSecuencia.Text))
            objFNPProc.iSecuencia = Convert.ToInt16(txtSecuencia.Text);
        if (!String.IsNullOrEmpty(txtProcedimiento.Text))
            objFNPProc.iIdProcedimiento = Convert.ToInt32(txtProcedimiento.Text);
    }

    private void AsignarValores()
    {        
        objFNPProc.bFLagExitoProc = chkExito.Checked;
        objFNPProc.sPrmOperacion = txtOperacion.Text;
        objFNPProc.bFlagCbteAcepDoc = chkCmpteAcepDoc.Checked;
        objFNPProc.bFlagAceptacion = chkAceptacion.Checked;
    }


    private void CargarCboActividad(DropDownList pCbo)
    {
        var objIFlujoNodo = new clsFlujoNodo();

        objIFlujoNodo.iIdConexion = _idConexion;
        objIFlujoNodo.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        objIFlujoNodo.iIdFlujo = _idFlujo;

        if (objIFlujoNodo.ObtieneNodosXFlujo())
        {
            pCbo.DataSource = objIFlujoNodo.DSet.Tables[0];
            pCbo.DataTextField = "IdNodoDesc";
            pCbo.DataValueField = "IdNodo";
            pCbo.DataBind();

            pCbo.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            pCbo.SelectedIndex = 0;
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado del combo de Actividades", objIFlujoNodo.sMensajeError);
        }
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    private void LimpiarCampos()
    {
        LimpiarMensajesMasterPage();

        pnlMaestro.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        pnlMaestro.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        txtSecuencia.Enabled = true;
        txtProcedimiento.Enabled = true;
        btnEliminar.Enabled = false;

        pnlDetalle.Visible = false;
    }


    private void CargarGrillaProcesos()
    {
        AsignarValoresPivote();

        if (objFNPProc.ObtieneProcesosXTransicion())
        {
            gvProcesos.DataSource = objFNPProc.DSet.Tables[0];
            gvProcesos.DataBind();
        }
        else
        {
            gvProcesos.DataSource = null;
            gvProcesos.DataBind();

            if(objFNPProc.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Procesos a Ejecutarse", objFNPProc.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_PRINCIPALES_MAESTRO

    protected void gvProcesos_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvProcesos.SelectedRow.RowIndex;
        var dataKey = gvProcesos.DataKeys[rowSelect];
        if (dataKey != null)
            objFNPProc.iSecuencia = (short) dataKey.Values["Secuencia"];
        var key = gvProcesos.DataKeys[rowSelect];
        if (key != null)
            objFNPProc.iIdProcedimiento = (int) key.Values["IdProcedimiento"];

        if (objFNPProc.ObtieneFila())
        {
            var dr = objFNPProc.DSet.Tables[0].Rows[0];

            txtSecuencia.Text = dr["Secuencia"].ToString();
            txtProcedimiento.Text = dr["IdProcedimiento"].ToString();
            chkExito.Checked = (bool) dr["FLagExitoProc"];
            txtOperacion.Text = dr["PrmOperacion"].ToString();
            chkCmpteAcepDoc.Checked = (bool) dr["FlagCbteAcepDoc"];
            if (!String.IsNullOrEmpty(dr["FlagAceptacion"].ToString()))
                chkAceptacion.Checked = (bool) dr["FlagAceptacion"];

            CargarGrillaProcesos();
            txtSecuencia.Enabled = false;
            txtProcedimiento.Enabled = false;
            btnEliminar.Enabled = true;
            pnlDetalle.Visible = true;

            //Detalle
            CargarGrillaParametros();
            CargarCboConceptos();
        }
        else
        {
            Master.MensajeError("Se produjo un error al recuperar el registro de Proceso a Ejecutarse", objFNPProc.sMensajeError);
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();
        AsignarValores();

        if (Page.IsValid)
        {
            bool resEvento = false;
            string evento = "";

            if (txtSecuencia.Enabled)
            {
                resEvento = objFNPProc.Adicion();
                evento = "adicionó";
            }
            else
            {
                resEvento = objFNPProc.Modificacion();
                evento = "modificó";
            }

            if(resEvento)
            {
                CargarGrillaProcesos();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Proceso a Ejecutarse");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Procesos a Ejecutarse", objFNPProc.sMensajeError);
            }
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFNPProc.Eliminacion())
        {
            CargarGrillaProcesos();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el registro de Proceso a Ejecutarse");            
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación de Proceso a Ejecutarse", objFNPProc.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS_MAESTRO

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmPrecedenciaActividades.aspx");
    }

    protected void gvProcesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProcesos.PageIndex = e.NewPageIndex;
        CargarGrillaProcesos();
    }

    #endregion


    #region CARGAR_DATOS_DETALLE

    private void AsignarValoresPivoteDet()
    {
        objFNPProcPrm.iIdConexion = _idConexion;
        objFNPProcPrm.iIdFlujo = _idFlujo;
        objFNPProcPrm.iIdNodoPred = _idNodoPred;
        objFNPProcPrm.iIdNodo = _idNodo;
        if (!String.IsNullOrEmpty(txtSecuencia.Text))
            objFNPProcPrm.iSecuencia = Convert.ToInt16(txtSecuencia.Text);
        if (!String.IsNullOrEmpty(txtProcedimiento.Text))
            objFNPProcPrm.iIdProcedimiento = Convert.ToInt32(txtProcedimiento.Text);
        if (!String.IsNullOrEmpty(txtParam.Text))
            objFNPProcPrm.sIdParametro = txtParam.Text;
    }

    private void AsignarValoresDet()
    {
        objFNPProcPrm.sIdConcepto = cboConcepto.SelectedValue;
        objFNPProcPrm.bFlagSolicitud = chkSolicitud.Checked;
    }

    private void CargarGrillaParametros()
    {
        AsignarValoresPivoteDet();

        if (objFNPProcPrm.ObtieneParametrosXProceso())
        {
            gvParam.DataSource = objFNPProcPrm.DSet.Tables[0];
            gvParam.DataBind();
        }
        else
        {
            gvParam.DataSource = null;
            gvParam.DataBind();

            if(objFNPProcPrm.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Parámetros", objFNPProcPrm.sMensajeError);
        }
    }

    private void LimpiarCamposDet()
    {
        txtParam.Text = string.Empty;
        cboConcepto.SelectedIndex = 0;
        chkSolicitud.Checked = false;

        txtParam.Enabled = true;
        btnEliminarDet.Enabled = false;
    }

    private DataTable CargarTablaConceptos(string pIdTipoTram)
    {
        try
        {
            var objInstanciaConcepto = new clsConcepto();
            objInstanciaConcepto.iIdConexion = _idConexion;
            if (objInstanciaConcepto.ObtieneConceptos())
            {
                var dtConceptos = objInstanciaConcepto.DSet.Tables[0];
                var dtConceptosXtram = ObtConceptoXTramite(pIdTipoTram);

                if (dtConceptosXtram != null)
                {
                    var query =
                        from dtC in dtConceptos.AsEnumerable()
                        join dtCT in dtConceptosXtram.AsEnumerable() on dtC["IdConcepto"] equals dtCT["IdConcepto"]
                        where Equals(dtCT["IdTipoTramite"], pIdTipoTram)
                        select new { Id = dtC["IdConcepto"], Desc = dtC["Descripcion"], TipDat = dtC["TipoDato"] };

                    var dtNueva = new DataTable();
                    dtNueva.Columns.Add("IdConcepto", typeof(string));
                    dtNueva.Columns.Add("Descripcion", typeof(string));
                    dtNueva.Columns.Add("TipoDato", typeof(string));

                    foreach (var rowInfo in query)
                    {
                        dtNueva.Rows.Add(rowInfo.Id, rowInfo.Desc, rowInfo.TipDat);
                    }

                    return dtNueva;
                }
                else
                {
                    Master.MensajeError("No existen conceptos asociados al trámite", "No existen conceptos asociados al trámite -> ObtConceptoXTramite(" + pIdTipoTram + ")");
                    return null;
                }
            }
            else
            {
                Master.MensajeError("Se produjo un error en el cargado de Conceptos", objInstanciaConcepto.sMensajeError);
                return null;
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error en el cargado de Conceptos sociados al Tipo de Trámite", ex.Message);                        
            return null;
        }        
    }

    private DataTable ObtConceptoXTramite(string pIdTipoTram)
    {
        var objTipTramConcep = new clsTipoTramiteConcepto();

        objTipTramConcep.iIdConexion = _idConexion;
        objTipTramConcep.sIdTipoTramite = pIdTipoTram;
        objTipTramConcep.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);

        if (objTipTramConcep.ObtieneConceptosXTipoTramite())
        {
            return objTipTramConcep.DSet.Tables[0];
        }
        else
        {
            return null;
        }
    }

    private void CargarCboConceptos()
    {
        cboConcepto.DataSource = CargarTablaConceptos(_idTipoTramite);
        cboConcepto.DataTextField = "Descripcion";
        cboConcepto.DataValueField = "IdConcepto";
        cboConcepto.DataBind();

        cboConcepto.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboConcepto.SelectedIndex = 0;
    }

    #endregion


    #region EVENTOS_PRINCIPALES_DETALLE

    protected void gvParam_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsignarValoresPivoteDet();

        var rowSelect = gvParam.SelectedRow.RowIndex;
        var dataKey = gvParam.DataKeys[rowSelect];
        if (dataKey != null)
            objFNPProcPrm.sIdParametro = (string) dataKey.Values["IdParametro"];
        
        if (objFNPProcPrm.ObtieneFila())
        {
            var dr = objFNPProcPrm.DSet.Tables[0].Rows[0];

            txtParam.Text = dr["IdParametro"].ToString();
            cboConcepto.SelectedValue = dr["IdConcepto"].ToString();
            chkSolicitud.Checked = (bool) dr["FlagSolicitud"];

            txtParam.Enabled = false;
            btnEliminarDet.Enabled = true;
        }
        else
        {
            Master.MensajeError("Se produjo un error al recuperar el registro de Parámetro", objFNPProcPrm.sMensajeError);
        }
    }

    protected void btnNuevoDet_Click(object sender, EventArgs e)
    {
        LimpiarCamposDet();
    }

    protected void btnGrabarDet_Click(object sender, EventArgs e)
    {
        AsignarValoresPivoteDet();
        AsignarValoresDet();

        if (Page.IsValid)
        {
            bool resEvento = false;
            string evento = "";

            if (txtParam.Enabled)
            {
                resEvento = objFNPProcPrm.Adicion();
                evento = "adicionó";
            }
            else
            {
                resEvento = objFNPProcPrm.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaParametros();
                LimpiarCamposDet();
                Master.MensajeOk("Se " + evento + " correctamente el registro Parámetro");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Parámetro", objFNPProcPrm.sMensajeError);
            }
        }
    }   

    protected void btnEliminarDet_Click(object sender, EventArgs e)
    {
        AsignarValoresPivoteDet();

        if (objFNPProcPrm.Eliminacion())
        {
            CargarGrillaParametros();
            LimpiarCamposDet();
            Master.MensajeOk("Se eliminó correctamente el registro de Parámetro");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación de Parámetro", objFNPProcPrm.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS_DETALLE

    protected void gvParam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProcesos.PageIndex = e.NewPageIndex;
        CargarGrillaParametros();
    }

    #endregion


}