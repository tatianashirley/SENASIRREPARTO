using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Workflow.Activities;
using wcfDocumento.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmHisRestricciones : System.Web.UI.Page
{
    //private clsRestriccion objInstanciaRestric = new clsRestriccion();
    private clsHisRestriccion objInstanciaRestric = new clsHisRestriccion();
    private clsHisConcepto objInstanciaConcepto = new clsHisConcepto();

    int _idConexion;

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
        }
        if (!Page.IsPostBack)
        {
            CargarGrillaRestricciones();
            CargarCboTipoDocumento();
            CargarCboHisConceptos();
            CargarCboTipoRestricciones();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    //******************************************************************
    //Existe un problema con el símbolo '<' se procedió a modificarlo
    //******************************************************************
    private void CargarCboTipoRestricciones()
    {
        cboTipoRestriccion.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboTipoRestriccion.Items.Insert(1, new ListItem("El dato debe estar presente (diferente de nulo)", "E"));
        cboTipoRestriccion.Items.Insert(2, new ListItem("Específico igual", "E="));
        cboTipoRestriccion.Items.Insert(3, new ListItem("Especìfico like", "E%"));
        cboTipoRestriccion.Items.Insert(4, new ListItem("Específico mayor", "E>"));
        cboTipoRestriccion.Items.Insert(5, new ListItem("Específico mayor o igual", "E>="));
        cboTipoRestriccion.Items.Insert(6, new ListItem("Específico menor", "E{"));
        cboTipoRestriccion.Items.Insert(7, new ListItem("Específico menor o igual", "E{="));
        cboTipoRestriccion.Items.Insert(8, new ListItem("Rango límite Inferior Abierto, Superior Abierto", "R1{X{R2"));
        cboTipoRestriccion.Items.Insert(9, new ListItem("Rango límite Inferior Abierto, Superior Cerrado", "R1{X{=R2"));
        cboTipoRestriccion.Items.Insert(10, new ListItem("Rango límite Inferior Cerrado, Superior Abierto", "R1{=X{R2"));
        cboTipoRestriccion.Items.Insert(11, new ListItem("Rango límite Inferior Cerrado, Superior Cerrado", "R1{=X{=R2"));
        cboTipoRestriccion.SelectedIndex = 0;
    }

    private void CargarGrillaRestricciones()
    {
        objInstanciaRestric.iIdConexion = _idConexion;
        if (objInstanciaRestric.ObtieneHisRestricciones())
        {
            var dtRestriccion = objInstanciaRestric.DSet.Tables[0];
            dtRestriccion.Columns.Add("Valor1", typeof(string));
            dtRestriccion.Columns.Add("Valor2", typeof(string));

            foreach (DataRow dr in dtRestriccion.Rows)
            {
                switch (dr["TipoDato"].ToString())
                {
                    case "I":
                        dr["Valor1"] = dr["Valor1Int"].ToString();
                        dr["Valor2"] = dr["Valor2Int"].ToString();
                        break;
                    case "M":
                        dr["Valor1"] = dr["Valor1Money"].ToString();
                        dr["Valor2"] = dr["Valor2Money"].ToString();
                        break;
                    case "F":
                        dr["Valor1"] = dr["Valor1Float"].ToString();
                        dr["Valor2"] = dr["Valor2Float"].ToString();
                        break;
                    case "C":
                        dr["Valor1"] = dr["Valor1Char"].ToString();
                        break;
                    case "D":
                        dr["Valor1"] = dr["Valor1Date"].ToString();
                        dr["Valor2"] = dr["Valor2Date"].ToString();
                        break;
                    case "T":
                        dr["Valor1"] = dr["Valor1Catalog"].ToString();
                        break;
                    case "B":
                        dr["Valor1"] = dr["Valor1Bit"].ToString();
                        break;
                }
            }
            dtRestriccion.AcceptChanges();

            gvRestricciones.DataSource = dtRestriccion;
            gvRestricciones.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de restricciones", objInstanciaRestric.sMensajeError);
            gvRestricciones.DataSource = null;
            gvRestricciones.DataBind();
        }
    }

    private DataTable CargarTablaHisConceptos()
    {
        objInstanciaConcepto.iIdConexion = _idConexion;
        if (objInstanciaConcepto.ObtieneHisConceptos())
        {
            return objInstanciaConcepto.DSet.Tables[0];
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de Conceptos", objInstanciaConcepto.sMensajeError);
            return null;
        }
    }

    private void CargarCboHisConceptos()
    {
        cboConcepto.DataSource = CargarTablaHisConceptos();
        cboConcepto.DataTextField = "Descripcion";
        cboConcepto.DataValueField = "IdConcepto";
        cboConcepto.DataBind();

        cboConcepto.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboConcepto.SelectedIndex = 0;
    }

    private void CargarCboTipoDocumento()
    {
        var objInstTipoDoc = new clsTipoDocumento();

        objInstTipoDoc.iIdConexion = _idConexion;
        if (objInstTipoDoc.ObtieneTiposDeDocumento())
        {
            cboTipoDocumento.DataSource = objInstTipoDoc.DSet.Tables[0];
            cboTipoDocumento.DataTextField = "Descripcion";
            cboTipoDocumento.DataValueField = "IdTipoDocumento";
            cboTipoDocumento.DataBind();

            cboTipoDocumento.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboTipoDocumento.SelectedIndex = 0;
        }
        else
            Master.MensajeError("Se produjo un error en el cargado al combo de Tipo de Documentos", objInstTipoDoc.sMensajeError);
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

        pnlDatos.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        pnlDatos.Controls.OfType<RadioButton>().ToList().ForEach(x => x.Checked = false);
        pnlDatos.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);
        txtIdRestriccion.Enabled = true;
        //btnEliminar.Enabled = false;
        pnlValores.Visible = false;

        pnlDatos.Controls.OfType<DropDownList>().ToList().ForEach(x => x.Enabled = true);
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Enabled = true);

        LimpiarCamposValores();
    }

    private string RecuperaTipoDatoPorConcepto(string pIdConcepto)
    {
        var eTipoDato = CargarTablaHisConceptos().AsEnumerable();

        return eTipoDato.Where(x => x.Field<string>("IdConcepto") == pIdConcepto).Select(x => x.Field<string>("TipoDato")).Single();
    }

    private void AsignarValores()
    {
        objInstanciaRestric.iIdConexion = _idConexion;        
        objInstanciaRestric.iIdHisInstancia = Convert.ToInt32(hdfInstancia.Value);
        objInstanciaRestric.iIdRestriccion = Convert.ToInt32(txtIdRestriccion.Text);
        objInstanciaRestric.sDescripcion = txtDescripcion.Text;
        objInstanciaRestric.iIdHisInstancia = Convert.ToInt32(hdfInstancia.Value);
        if (rbtConcepto.Checked && cboConcepto.SelectedIndex != 0)
        {
            objInstanciaRestric.sIdConcepto = cboConcepto.SelectedValue;
            objInstanciaRestric.sTipoDato = RecuperaTipoDatoPorConcepto(objInstanciaRestric.sIdConcepto);
        }

        if (rbtTipoDoc.Checked && cboTipoDocumento.SelectedIndex != 0)
            objInstanciaRestric.iIdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);

        objInstanciaRestric.sComentarios = txtComentarios.Text;
        objInstanciaRestric.sTipoRestriccion = cboTipoRestriccion.SelectedValue.Replace('{', '<');//problemas con el signo "<"
        objInstanciaRestric.bFlagNegacion = chkNegacion.Checked;

        switch (objInstanciaRestric.sTipoDato)
        {
            case "I":
                if (!string.IsNullOrEmpty(txtValorDesdeInt.Text))
                    objInstanciaRestric.iValor1Int = Convert.ToInt32(txtValorDesdeInt.Text);
                if (!string.IsNullOrEmpty(txtValorHastaInt.Text))
                    objInstanciaRestric.iValor2Int = Convert.ToInt32(txtValorHastaInt.Text);

                objInstanciaRestric.mValor1Money = null;
                objInstanciaRestric.mValor2Money = null;
                objInstanciaRestric.dValor1Float = null;
                objInstanciaRestric.dValor2Float = null;
                objInstanciaRestric.sValor1Char = null;
                objInstanciaRestric.fValor1Date = null;
                objInstanciaRestric.fValor2Date = null;
                objInstanciaRestric.iValor1Catalog = null;
                objInstanciaRestric.bValor1Bit = null;
                break;

            case "M":
                if (!string.IsNullOrEmpty(txtValorDesdeMon.Text))
                    objInstanciaRestric.mValor1Money = Convert.ToDecimal(txtValorDesdeMon.Text);
                if (!string.IsNullOrEmpty(txtValorHastaMon.Text))
                    objInstanciaRestric.mValor2Money = Convert.ToDecimal(txtValorHastaMon.Text);

                objInstanciaRestric.iValor1Int = null;
                objInstanciaRestric.iValor2Int = null;
                objInstanciaRestric.dValor1Float = null;
                objInstanciaRestric.dValor2Float = null;
                objInstanciaRestric.sValor1Char = null;
                objInstanciaRestric.fValor1Date = null;
                objInstanciaRestric.fValor2Date = null;
                objInstanciaRestric.iValor1Catalog = null;
                objInstanciaRestric.bValor1Bit = null;
                break;

            case "F":
                if (!string.IsNullOrEmpty(txtValorDesdeFloat.Text))
                    objInstanciaRestric.dValor1Float = Convert.ToDouble(txtValorDesdeFloat.Text);
                if (!string.IsNullOrEmpty(txtValorHastaFloat.Text))
                    objInstanciaRestric.dValor2Float = Convert.ToDouble(txtValorHastaFloat.Text);

                objInstanciaRestric.iValor1Int = null;
                objInstanciaRestric.iValor2Int = null;
                objInstanciaRestric.mValor1Money = null;
                objInstanciaRestric.mValor2Money = null;
                objInstanciaRestric.sValor1Char = null;
                objInstanciaRestric.fValor1Date = null;
                objInstanciaRestric.fValor2Date = null;
                objInstanciaRestric.iValor1Catalog = null;
                objInstanciaRestric.bValor1Bit = null;
                break;

            case "C":
                if (!string.IsNullOrEmpty(txtValorChar.Text))
                    objInstanciaRestric.sValor1Char = txtValorChar.Text;

                objInstanciaRestric.iValor1Int = null;
                objInstanciaRestric.iValor2Int = null;
                objInstanciaRestric.mValor1Money = null;
                objInstanciaRestric.mValor2Money = null;
                objInstanciaRestric.dValor1Float = null;
                objInstanciaRestric.dValor2Float = null;
                objInstanciaRestric.fValor1Date = null;
                objInstanciaRestric.fValor2Date = null;
                objInstanciaRestric.iValor1Catalog = null;
                objInstanciaRestric.bValor1Bit = null;
                break;

            case "D":
                if (!string.IsNullOrEmpty(txtValorDesdeFec.Text))
                    objInstanciaRestric.fValor1Date = Convert.ToDateTime(txtValorDesdeFec.Text);
                if (!string.IsNullOrEmpty(txtValorHastaFec.Text))
                    objInstanciaRestric.fValor2Date = Convert.ToDateTime(txtValorHastaFec.Text);

                objInstanciaRestric.iValor1Int = null;
                objInstanciaRestric.iValor2Int = null;
                objInstanciaRestric.mValor1Money = null;
                objInstanciaRestric.mValor2Money = null;
                objInstanciaRestric.dValor1Float = null;
                objInstanciaRestric.dValor2Float = null;
                objInstanciaRestric.sValor1Char = null;
                objInstanciaRestric.iValor1Catalog = null;
                objInstanciaRestric.bValor1Bit = null;
                break;
            case "T":
                if (!string.IsNullOrEmpty(txtValorCTalog.Text))
                    objInstanciaRestric.iValor1Catalog = Convert.ToInt32(txtValorCTalog.Text);

                objInstanciaRestric.iValor1Int = null;
                objInstanciaRestric.iValor2Int = null;
                objInstanciaRestric.mValor1Money = null;
                objInstanciaRestric.mValor2Money = null;
                objInstanciaRestric.dValor1Float = null;
                objInstanciaRestric.dValor2Float = null;
                objInstanciaRestric.fValor1Date = null;
                objInstanciaRestric.fValor2Date = null;
                objInstanciaRestric.sValor1Char = null;
                objInstanciaRestric.bValor1Bit = null;
                break;

            case "B":
                objInstanciaRestric.bValor1Bit = chkValorBool.Checked;

                objInstanciaRestric.iValor1Int = null;
                objInstanciaRestric.iValor2Int = null;
                objInstanciaRestric.mValor1Money = null;
                objInstanciaRestric.mValor2Money = null;
                objInstanciaRestric.dValor1Float = null;
                objInstanciaRestric.dValor2Float = null;
                objInstanciaRestric.fValor1Date = null;
                objInstanciaRestric.fValor2Date = null;
                objInstanciaRestric.sValor1Char = null;
                objInstanciaRestric.iValor1Catalog = null;
                break;
        }

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

    private void LimpiarCamposValores()
    {
        vInt.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vMoney.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vFloat.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vChar.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vDate.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vCTalog.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        vBoolean.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);
    }

    private void HabilitarConcepto(bool pBool)
    {
        rbtConcepto.Checked = pBool;
        cboConcepto.Enabled = pBool;
        if (pBool)
        {
            cboTipoDocumento.SelectedIndex = 0;
            rbtTipoDoc.Checked = false;
        }
        else
            cboConcepto.SelectedIndex = 0;
    }

    private void HabilitarTipoDoc(bool pBool)
    {
        rbtTipoDoc.Checked = pBool;
        cboTipoDocumento.Enabled = pBool;
        if (pBool)
        {
            cboConcepto.SelectedIndex = 0;
            rbtConcepto.Checked = false;
        }
        else
            cboTipoDocumento.SelectedIndex = 0;
    }

    #endregion


    #region EVENTOS_PRINCIPALES

    protected void gvRestricciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();
        LimpiarCamposValores();

        int rowSelect = gvRestricciones.SelectedRow.RowIndex;
        objInstanciaRestric.iIdConexion = _idConexion;

        var dataKey = gvRestricciones.DataKeys[rowSelect];
        if (dataKey != null)
        {
            //objInstanciaRestric.iIdHisInstancia = Convert.ToInt32(gvRestricciones.DataKeys[rowSelect]["IdHisInstancia"]);
            objInstanciaRestric.iIdHisInstancia = Convert.ToInt32(gvRestricciones.DataKeys[rowSelect]["IdHisInstancia"]);
            hdfInstancia.Value = objInstanciaRestric.iIdHisInstancia.ToString();
            objInstanciaRestric.iIdRestriccion = Convert.ToInt32(gvRestricciones.DataKeys[rowSelect]["IdRestriccion"]);
        }

        if (objInstanciaRestric.ObtieneFila())
        {
            DataRow dr = objInstanciaRestric.DSet.Tables[0].Rows[0];
            txtIdRestriccion.Text = dr["IdRestriccion"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            if (!string.IsNullOrEmpty(dr["IdConcepto"].ToString()))
            {
                cboConcepto.SelectedValue = dr["IdConcepto"].ToString();
                HabilitarConcepto(true);
                HabilitarTipoDoc(false);
                cboConcepto_SelectedIndexChanged(sender, e);
                rbtConcepto_CheckedChanged(sender, e);
                rbtConcepto.Enabled = true;
                rbtTipoDoc.Enabled = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(dr["IdTipoDocumento"].ToString()))
                {
                    cboTipoDocumento.SelectedValue = dr["IdTipoDocumento"].ToString();
                    HabilitarTipoDoc(true);
                    HabilitarConcepto(false);
                    cboTipoDocumento_SelectedIndexChanged(sender, e);
                    rbtTipoDoc_CheckedChanged(sender, e);
                    rbtConcepto.Enabled = false;
                    rbtTipoDoc.Enabled = true;
                }
                else
                {
                    HabilitarTipoDoc(false);
                    HabilitarConcepto(false);
                }
            }

            txtComentarios.Text = dr["Comentarios"].ToString();
            if (!string.IsNullOrEmpty(dr["TipoRestriccion"].ToString()))
            {
                cboTipoRestriccion.SelectedValue = dr["TipoRestriccion"].ToString().Replace('<', '{');
                cboTipoRestriccion_SelectedIndexChanged(sender, e);
            }
            chkNegacion.Checked = Convert.ToBoolean(dr["FlagNegacion"]);

            //Cargar Valores
            if (!string.IsNullOrEmpty(dr["Valor1Int"].ToString()))
                txtValorDesdeInt.Text = dr["Valor1Int"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor2Int"].ToString()))
                txtValorHastaInt.Text = dr["Valor2Int"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor1Money"].ToString()))
                txtValorDesdeMon.Text = dr["Valor1Money"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor2Money"].ToString()))
                txtValorHastaMon.Text = dr["Valor2Money"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor1Float"].ToString()))
                txtValorDesdeFloat.Text = dr["Valor1Float"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor2Float"].ToString()))
                txtValorHastaFloat.Text = dr["Valor2Float"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor1Char"].ToString()))
                txtValorChar.Text = dr["Valor1Char"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor1Date"].ToString()))
                txtValorDesdeFec.Text = Convert.ToDateTime(dr["Valor1Date"]).ToShortDateString();
            if (!string.IsNullOrEmpty(dr["Valor2Date"].ToString()))
                txtValorHastaFec.Text = Convert.ToDateTime(dr["Valor2Date"]).ToShortDateString();
            if (!string.IsNullOrEmpty(dr["Valor1Catalog"].ToString()))
                txtValorCTalog.Text = dr["Valor1Catalog"].ToString();
            if (!string.IsNullOrEmpty(dr["Valor1Bit"].ToString()))
                chkValorBool.Checked = Convert.ToBoolean(dr["Valor1Bit"]);

            txtIdRestriccion.Enabled = false;
            //btnEliminar.Enabled = true;
        }
        else
            Master.MensajeError("Se produjo un error en el cargado de Restricciones", objInstanciaRestric.sMensajeError);

    }

    //protected void btnNuevo_Click(object sender, EventArgs e)
    //{
    //    LimpiarCampos();
    //}

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            bool resEvento = false;
            string evento = "";

            AsignarValores();
            //if (txtIdRestriccion.Enabled == true)
            //{
            //    resEvento = objInstanciaRestric.Adicion();
            //    evento = "añadió";
            //}
            //else
            //{
                resEvento = objInstanciaRestric.Modificacion();
                evento = "modificó";
            //}

            if (resEvento == true)
            {
                CargarGrillaRestricciones();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " el Registro de Restricción");
            }
            else
                Master.MensajeError("Se produjo un error al grabar el Registro de Restricción", objInstanciaRestric.sMensajeError);
        }
    }

    //protected void btnEliminar_Click(object sender, EventArgs e)
    //{
    //    objInstanciaRestric.iIdConexion = _idConexion;
    //    int rowSelect = gvRestricciones.SelectedRow.RowIndex;
    //    var dataKey = gvRestricciones.DataKeys[rowSelect];
    //    if (dataKey != null)
    //        objInstanciaRestric.iIdRestriccion = Convert.ToInt32(dataKey.Value);

    //    if (objInstanciaRestric.Eliminacion())
    //    {
    //        LimpiarCampos();
    //        CargarGrillaRestricciones();
    //        Master.MensajeOk("Se eliminó el Registro de la Restricción correctamente");
    //    }
    //    else
    //        Master.MensajeError("Se produjo un error al eliminar el registro de Restricción", objInstanciaRestric.sMensajeError);
    //}

    #endregion

    #region EVENTOS_SECUNDARIOS


    protected void gvRestricciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRestricciones.PageIndex = e.NewPageIndex;
        CargarGrillaRestricciones();
    }

    protected void rbtTipoDoc_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtTipoDoc.Checked)
        {
            pnlValores.Visible = false;
            cboTipoDocumento.Enabled = true;
            cboTipoRestriccion.SelectedValue = "E";
            cboTipoRestriccion.Enabled = false;
            cboConcepto.Enabled = false;
            cboConcepto.SelectedIndex = 0;

            rfvTipoDoc.Enabled = true;
            rfvConcepto.Enabled = false;
            rbtConcepto.Checked = false;

            mvValores.ActiveViewIndex = -1;
        }

    }

    protected void rbtConcepto_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtConcepto.Checked)
        {
            cboConcepto.Enabled = true;
            cboTipoDocumento.Enabled = false;
            cboTipoDocumento.SelectedIndex = 0;
            cboTipoRestriccion.Enabled = true;
            cboTipoRestriccion.SelectedIndex = 0;

            rfvConcepto.Enabled = true;
            rfvTipoDoc.Enabled = false;
            rbtTipoDoc.Checked = false;

            if (cboConcepto.SelectedIndex != 0)
                pnlValores.Visible = true;
        }
    }

    protected void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboConcepto.SelectedIndex != 0)
        {
            pnlValores.Visible = true;
            VisualizarMultaVista(RecuperaTipoDatoPorConcepto(cboConcepto.SelectedValue));
        }
    }

    protected void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboTipoDocumento.SelectedIndex != 0)
        {
            mvValores.ActiveViewIndex = -1;
            pnlValores.Visible = false;
        }
    }

    protected void cboTipoRestriccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool habilitado;

        if (cboTipoRestriccion.SelectedIndex > 7)
            habilitado = true;
        else
        {
            habilitado = false;
            txtValorHastaInt.Text = string.Empty;
            txtValorHastaFloat.Text = string.Empty;
            txtValorHastaMon.Text = string.Empty;
            txtValorHastaFec.Text = string.Empty;
        }

        lblHastaInt.Enabled = habilitado;
        rfvValHasInt.Enabled = habilitado;
        ravIntHasta.Enabled = habilitado;
        txtValorHastaInt.Enabled = habilitado;

        lblHastaFloat.Enabled = habilitado;
        rfvValHastaFloat.Enabled = habilitado;
        ravFloatHasta.Enabled = habilitado;
        txtValorHastaFloat.Enabled = habilitado;

        lblMonHasta.Enabled = habilitado;
        rfvValHasMon.Enabled = habilitado;
        ravMonDesde.Enabled = habilitado;
        txtValorHastaMon.Enabled = habilitado;

        lblHastaFec.Enabled = habilitado;
        txtValorHastaFec.Enabled = habilitado;
    }

    #endregion

}