using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmTipoTramiteConcepto : System.Web.UI.Page
{
    private clsTipoTramiteConcepto objInstTipTramConcep = new clsTipoTramiteConcepto();
    private int _idConexion;
    private string _idTipoTramite;
    private string _tipoTramite;
    private static bool _filaSeleccionada = false;
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
        }

        if (!Page.IsPostBack)
        {
            txtTipoTramite.Text = _tipoTramite;

            CargarCboConceptos();
            CargarGrillaTipoTramConcepto();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }


    #region CARGAR_DATOS

    private void AsignarValoresPivote()
    {
        objInstTipTramConcep.iIdConexion = _idConexion;
        objInstTipTramConcep.sIdTipoTramite = _idTipoTramite;
        objInstTipTramConcep.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        objInstTipTramConcep.sIdConcepto = cboConcepto.SelectedValue;
    }

    private void AsignarValores()
    {        
        objInstTipTramConcep.iOrden = Convert.ToInt16(txtOrden.Text);
        objInstTipTramConcep.bFlagSolicitud = chkSolicitud.Checked;
        objInstTipTramConcep.bFlagModificable = chkModificable.Checked;
        objInstTipTramConcep.bFlagObligatorio = chkObligatorio.Checked;
        objInstTipTramConcep.bFlagDeterminaFlujo = chkDeterminaFlujo.Checked;

        string tipoDato = RecuperaTipoDatoPorConcepto(objInstTipTramConcep.sIdConcepto);

        switch (tipoDato)
        {
            case "I":
                objInstTipTramConcep.iValorInt = Convert.ToInt32(txtValorInt.Text);
                objInstTipTramConcep.mValorMoney = null;
                objInstTipTramConcep.dValorFloat = null;
                objInstTipTramConcep.sValorChar = null;
                objInstTipTramConcep.fValorDate = null;
                objInstTipTramConcep.iValorCatalog = null;
                objInstTipTramConcep.bValorBoolean = null;                

                break;
            case "M":
                objInstTipTramConcep.iValorInt = null;
                objInstTipTramConcep.mValorMoney = Convert.ToDecimal(txtValorMoney.Text);
                objInstTipTramConcep.dValorFloat = null;
                objInstTipTramConcep.sValorChar = null;
                objInstTipTramConcep.fValorDate = null;
                objInstTipTramConcep.iValorCatalog = null;
                objInstTipTramConcep.bValorBoolean = null;
                break;
            case "F":
                objInstTipTramConcep.iValorInt = null;
                objInstTipTramConcep.mValorMoney = null;
                objInstTipTramConcep.dValorFloat = Convert.ToDouble(txtValorFloat.Text);
                objInstTipTramConcep.sValorChar = null;
                objInstTipTramConcep.fValorDate = null;
                objInstTipTramConcep.iValorCatalog = null;
                objInstTipTramConcep.bValorBoolean = null;
                break;
            case "C":
                objInstTipTramConcep.iValorInt = null;
                objInstTipTramConcep.mValorMoney = null;
                objInstTipTramConcep.dValorFloat = null;
                objInstTipTramConcep.sValorChar = txtValorChar.Text;
                objInstTipTramConcep.fValorDate = null;
                objInstTipTramConcep.iValorCatalog = null;
                objInstTipTramConcep.bValorBoolean = null;
                break;
            case "D":
                objInstTipTramConcep.iValorInt = null;
                objInstTipTramConcep.mValorMoney = null;
                objInstTipTramConcep.dValorFloat = null;
                objInstTipTramConcep.sValorChar = null;
                objInstTipTramConcep.fValorDate = Convert.ToDateTime(txtValorFecha.Text);
                objInstTipTramConcep.iValorCatalog = null;
                objInstTipTramConcep.bValorBoolean = null;
                break;
            case "T":
                objInstTipTramConcep.iValorInt = null;
                objInstTipTramConcep.mValorMoney = null;
                objInstTipTramConcep.dValorFloat = null;
                objInstTipTramConcep.sValorChar = null;
                objInstTipTramConcep.fValorDate = null;
                objInstTipTramConcep.iValorCatalog = Convert.ToInt32(txtValorCTalog.Text);
                objInstTipTramConcep.bValorBoolean = null;
                break;
            case "B":
                objInstTipTramConcep.iValorInt = null;
                objInstTipTramConcep.mValorMoney = null;
                objInstTipTramConcep.dValorFloat = null;
                objInstTipTramConcep.sValorChar = null;
                objInstTipTramConcep.fValorDate = null;
                objInstTipTramConcep.iValorCatalog = null;
                objInstTipTramConcep.bValorBoolean = chkValorBool.Checked;
                break;
        }
    }


    private void CargarGrillaTipoTramConcepto()
    {
        AsignarValoresPivote();
        
        if (objInstTipTramConcep.ObtieneConceptosXTipoTramite())
        {
            gvTipoTramConcepto.DataSource = objInstTipTramConcep.DSet.Tables[0];
            gvTipoTramConcepto.DataBind();
        }
        else
        {
            gvTipoTramConcepto.DataSource = null;
            gvTipoTramConcepto.DataBind();

            if(objInstTipTramConcep.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Tipo Trámite Concepto", objInstTipTramConcep.sMensajeError);
        }
    }

    private DataTable CargarTablaConceptos()
    {
        var objInstanciaConcepto = new clsConcepto();
        objInstanciaConcepto.iIdConexion = _idConexion;
        if (objInstanciaConcepto.ObtieneConceptos())
            return objInstanciaConcepto.DSet.Tables[0];
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de Conceptos", objInstanciaConcepto.sMensajeError);
            return null;
        }
    }   

    private void CargarCboConceptos()
    {
        cboConcepto.DataSource = CargarTablaConceptos();
        cboConcepto.DataTextField = "Descripcion";
        cboConcepto.DataValueField = "IdConcepto";
        cboConcepto.DataBind();

        cboConcepto.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboConcepto.SelectedIndex = 0;
    }

    private string RecuperaTipoDatoPorConcepto(string pIdConcepto)
    {
        var eTipoDato = CargarTablaConceptos().AsEnumerable();

        return eTipoDato.Where(x => x.Field<string>("IdConcepto") == pIdConcepto).Select(x => x.Field<string>("TipoDato")).Single();
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
        txtOrden.Text = string.Empty;
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);
        
        btnEliminar.Enabled = false;

        LimpiarValores();

        cboConcepto.Enabled = true;
        _filaSeleccionada = false;
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

    protected void gvTipoTramConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvTipoTramConcepto.SelectedRow.RowIndex;
        if (objInstTipTramConcep != null)
        {
            objInstTipTramConcep.sIdConcepto = gvTipoTramConcepto.DataKeys[rowSelect].Values["IdConcepto"].ToString();

            if (objInstTipTramConcep.ObtieneFila())
            {
                var dr = objInstTipTramConcep.DSet.Tables[0].Rows[0];
                cboConcepto.SelectedValue = dr["IdConcepto"].ToString();
                txtOrden.Text = dr["Orden"].ToString();
                chkSolicitud.Checked = Convert.ToBoolean(dr["FlagSolicitud"]);
                chkModificable.Checked = Convert.ToBoolean(dr["FlagModificable"]);
                chkObligatorio.Checked = Convert.ToBoolean(dr["FlagObligatorio"]);
                chkDeterminaFlujo.Checked = Convert.ToBoolean(dr["FlagDeterminaFlujo"]);

                string tipoDato = RecuperaTipoDatoPorConcepto(dr["IdConcepto"].ToString());

                switch (tipoDato)
                {
                    case "I":
                        txtValorInt.Text = dr["Valor"].ToString();
                        break;
                    case "M":
                        txtValorMoney.Text = dr["Valor"].ToString();
                        break;
                    case "F":
                        txtValorFloat.Text = dr["Valor"].ToString();
                        break;
                    case "C":
                        txtValorChar.Text = dr["Valor"].ToString();
                        break;
                    case "D":
                        txtValorFecha.Text = dr["Valor"].ToString();
                        break;
                    case "T":
                        txtValorCTalog.Text = dr["Valor"].ToString();
                        break;
                    default:
                        if (dr["Valor"].ToString() == "Verdad")
                            chkValorBool.Checked = true;
                        else
                            chkValorBool.Checked = false;    
                        break;
                }


                VisualizarMultaVista(tipoDato);
                btnEliminar.Enabled = true;
                cboConcepto.Enabled = false;
                _filaSeleccionada = true;
            }
            else
            {
                Master.MensajeError("Se produjo un error al recuperar el registro de Concepto asociado al Tipo de Trámite",objInstTipTramConcep.sMensajeError);
                _filaSeleccionada = false;
            }
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
            string evento;
            
            if(!_filaSeleccionada)
            {
                resEvento = objInstTipTramConcep.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objInstTipTramConcep.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaTipoTramConcepto();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Concepto asociado al Tipo de Trámite");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Concepto asociado al Tipo de Trámite", objInstTipTramConcep.sMensajeError);
            }
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objInstTipTramConcep.Eliminacion())
        {
            CargarGrillaTipoTramConcepto();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el registro de Concepto asociado al Tipo de Trámite");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación del registro de Concepto asociado al Tipo de Trámite", objInstTipTramConcep.sMensajeError);
        }
    }

    #endregion


    #region EVENTOS_SECUNDARIOS

    protected void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarValores();
        if (cboConcepto.SelectedIndex != 0)
        {            
                var tipoDato = RecuperaTipoDatoPorConcepto(cboConcepto.SelectedValue);
                VisualizarMultaVista(tipoDato);
        }
        else
            mvValores.ActiveViewIndex = -1;
    }

    protected void gvTipoTramConcepto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipoTramConcepto.PageIndex = e.NewPageIndex;
        CargarGrillaTipoTramConcepto();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmTipoTramite.aspx");
    }


    #endregion




  
}