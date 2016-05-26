using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmConceptosDisponiblesActividad : System.Web.UI.Page
{
    private clsFlujoNodoConcepto objFnConcepto = new clsFlujoNodoConcepto();

    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private int _idFlujo;
    private string _flujo;
    private short _idNodo;
    private string _nodo;
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
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;
            txtFlujo.Text = _flujo;
            txtActividad.Text = _nodo;

            CargarCboConceptos();
            CargarGrillaConceptosActividad();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void CargarGrillaConceptosActividad()
    {
        AsignarValoresPivote();

        if (objFnConcepto.ObtieneConceptosXNodo())
        {
            gvConcep.DataSource = objFnConcepto.DSet.Tables[0];
            gvConcep.DataBind();
        }
        else
        {
            gvConcep.DataSource = null;
            gvConcep.DataBind();

            if(objFnConcepto.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de la realación de Conceptos Disponibles para la Actividad", objFnConcepto.sMensajeError);
        }
        
    }

    private string RecuperaTipoDatoPorConcepto(string pIdConcepto)
    {
        var eTipoDato = CargarTablaConceptos(_idTipoTramite).AsEnumerable();

        return eTipoDato.Where(x => x.Field<string>("IdConcepto") == pIdConcepto).Select(x => x.Field<string>("TipoDato")).Single();
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



    private void AsignarValoresPivote()
    {
        objFnConcepto.iIdConexion = _idConexion;
        objFnConcepto.iIdFlujo = _idFlujo;
        objFnConcepto.iIdNodo = _idNodo;
        objFnConcepto.sIdTipoTramite = _idTipoTramite;
        if (cboConcepto.SelectedIndex > 0)
            objFnConcepto.sIdConcepto = cboConcepto.SelectedValue;
    }

    private void AsignarValores()
    {
        objFnConcepto.bFlagObligatorio = chkObligatorio.Checked;
        objFnConcepto.bFlagModificable = chkModificable.Checked;
        if(chkActivo.Checked)
            objFnConcepto.sEstado = "A";
        else
            objFnConcepto.sEstado = "I";

        string tipoDato = RecuperaTipoDatoPorConcepto(objFnConcepto.sIdConcepto);

        switch (tipoDato)
        {
            case "I":
                objFnConcepto.iValorInt = Convert.ToInt32(txtValorInt.Text);
                objFnConcepto.mValorMoney = null;
                objFnConcepto.dValorFloat = null;
                objFnConcepto.sValorChar = null;
                objFnConcepto.fValorDate = null;
                objFnConcepto.iValorCatalog = null;
                objFnConcepto.bValorBoolean = null;

                break;
            case "M":
                objFnConcepto.iValorInt = null;
                objFnConcepto.mValorMoney = Convert.ToDecimal(txtValorMoney.Text);
                objFnConcepto.dValorFloat = null;
                objFnConcepto.sValorChar = null;
                objFnConcepto.fValorDate = null;
                objFnConcepto.iValorCatalog = null;
                objFnConcepto.bValorBoolean = null;
                break;
            case "F":
                objFnConcepto.iValorInt = null;
                objFnConcepto.mValorMoney = null;
                objFnConcepto.dValorFloat = Convert.ToDouble(txtValorFloat.Text);
                objFnConcepto.sValorChar = null;
                objFnConcepto.fValorDate = null;
                objFnConcepto.iValorCatalog = null;
                objFnConcepto.bValorBoolean = null;
                break;
            case "C":
                objFnConcepto.iValorInt = null;
                objFnConcepto.mValorMoney = null;
                objFnConcepto.dValorFloat = null;
                objFnConcepto.sValorChar = txtValorChar.Text;
                objFnConcepto.fValorDate = null;
                objFnConcepto.iValorCatalog = null;
                objFnConcepto.bValorBoolean = null;
                break;
            case "D":
                objFnConcepto.iValorInt = null;
                objFnConcepto.mValorMoney = null;
                objFnConcepto.dValorFloat = null;
                objFnConcepto.sValorChar = null;
                objFnConcepto.fValorDate = Convert.ToDateTime(txtValorFecha.Text);
                objFnConcepto.iValorCatalog = null;
                objFnConcepto.bValorBoolean = null;
                break;
            case "T":
                objFnConcepto.iValorInt = null;
                objFnConcepto.mValorMoney = null;
                objFnConcepto.dValorFloat = null;
                objFnConcepto.sValorChar = null;
                objFnConcepto.fValorDate = null;
                objFnConcepto.iValorCatalog = Convert.ToInt32(txtValorCTalog.Text);
                objFnConcepto.bValorBoolean = null;
                break;
            case "B":
                objFnConcepto.iValorInt = null;
                objFnConcepto.mValorMoney = null;
                objFnConcepto.dValorFloat = null;
                objFnConcepto.sValorChar = null;
                objFnConcepto.fValorDate = null;
                objFnConcepto.iValorCatalog = null;
                objFnConcepto.bValorBoolean = chkValorBool.Checked;
                break;
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

    private void VisualizarMultaVista(string pTipoDato)
    {
        cboTipoDato.SelectedValue = pTipoDato;
        switch (pTipoDato)
        {
            case "I":
                mvValores.SetActiveView(vInt);
                break;
            case "M":
                mvValores.SetActiveView(vMoney);
                break;
            case "F":
                mvValores.SetActiveView(vFloat);
                break;
            case "C":
                mvValores.SetActiveView(vChar);
                break;
            case "D":
                mvValores.SetActiveView(vDate);
                break;
            case "T":
                mvValores.SetActiveView(vCTalog);
                break;
            default:
                mvValores.SetActiveView(vBoolean);
                break;
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

        cboConcepto.SelectedIndex = 0;
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        cboConcepto.Enabled = true;
        btnEliminar.Enabled = false;

        LimpiarValores();
        
    }

    private void LimpiarValores()
    {

        vInt.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vMoney.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vFloat.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vChar.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vDate.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vCTalog.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vBoolean.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        cboTipoDato.SelectedIndex = 0;
    }

    #endregion


    #region EVENTOS_PRINCIPALES
    protected void gvConcep_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvConcep.SelectedRow.RowIndex;
        if (objFnConcepto != null)
        {
            objFnConcepto.sIdConcepto = gvConcep.DataKeys[rowSelect].Values["IdConcepto"].ToString();

            if (objFnConcepto.ObtieneFila())
            {
                var dr = objFnConcepto.DSet.Tables[0].Rows[0];
                cboConcepto.SelectedValue = dr["IdConcepto"].ToString();
                chkModificable.Checked = Convert.ToBoolean(dr["FlagModificable"]);
                chkObligatorio.Checked = Convert.ToBoolean(dr["FlagObligatorio"]);
                if (dr["Estado"].ToString() == "A")
                    chkActivo.Checked = true;
                else
                    chkActivo.Checked = false;
            
                string tipoDato = RecuperaTipoDatoPorConcepto(dr["IdConcepto"].ToString());
                switch (tipoDato)
                {
                    case "I":
                        txtValorInt.Text = dr["ValorInt"].ToString();
                        break;
                    case "M":
                        txtValorMoney.Text = dr["ValorMoney"].ToString();
                        break;
                    case "F":
                        txtValorFloat.Text = dr["ValorFloat"].ToString();
                        break;
                    case "C":
                        txtValorChar.Text = dr["ValorChar"].ToString();
                        break;
                    case "D":
                        txtValorFecha.Text = Convert.ToDateTime(dr["ValorDate"]).ToShortDateString();
                        break;
                    case "T":
                        txtValorCTalog.Text = dr["ValorCatalog"].ToString();
                        break;
                    default:
                        if (dr["ValorBoolean"].ToString() == "Verdad")
                            chkValorBool.Checked = true;
                        else
                            chkValorBool.Checked = false;
                        break;
                }

                VisualizarMultaVista(tipoDato);

                btnEliminar.Enabled = true;
                cboConcepto.Enabled = false;
            }
            else
            {
                Master.MensajeError("Se produjo un error al recuperar el registro de Concepto Disponible para la Actividad", objFnConcepto.sMensajeError);
            }
        }

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();
        AsignarValores();

        if (Page.IsValid)
        {
            bool resEvento = false;
            string evento;
            
            if (cboConcepto.Enabled)
            {
                resEvento = objFnConcepto.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objFnConcepto.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaConceptosActividad();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Concepto Disponible para la Actividad");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Concepto Disponible para la Actividad", objFnConcepto.sMensajeError);
            }
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFnConcepto.Eliminacion())
        {
            CargarGrillaConceptosActividad();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el registro de Concepto Disponible para la Actividad");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación del registro de Concepto Disponible para la Actividad", objFnConcepto.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS

    protected void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboConcepto.SelectedIndex != 0)
        {
            var tipoDato = RecuperaTipoDatoPorConcepto(cboConcepto.SelectedValue);
            VisualizarMultaVista(tipoDato);
        }
        else
            mvValores.ActiveViewIndex = -1;
    }

    protected void gvConcep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConcep.PageIndex = e.NewPageIndex;
        CargarGrillaConceptosActividad();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmActividadesFlujo.aspx");
    }

    #endregion
}