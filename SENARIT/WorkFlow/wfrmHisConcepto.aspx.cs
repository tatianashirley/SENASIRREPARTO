using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmHisConcepto : System.Web.UI.Page
{
    clsHisConcepto ObjInstanciaHisConcepto = new clsHisConcepto();
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
            CargarGrillaConceptos();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void CargarGrillaConceptos()
    {
        ObjInstanciaHisConcepto.iIdConexion = _idConexion;
        if (ObjInstanciaHisConcepto.ObtieneHisConceptos())
        {
            gvConcepto.DataSource = ObjInstanciaHisConcepto.DSet.Tables[0];
            gvConcepto.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de conceptos", ObjInstanciaHisConcepto.sMensajeError);
            gvConcepto.DataSource = null;
            gvConcepto.DataBind();
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
        pnlConcepto.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        cboTipoDato.SelectedIndex = 0;
        chkMayuscula.Checked = false;
        txtIdConcepto.Enabled = true;
        //btnEliminar.Enabled = false;
    }

    private void AsignarValores()
    {   
        ObjInstanciaHisConcepto.iIdConexion = _idConexion;
        ObjInstanciaHisConcepto.iIdHisInstancia = Convert.ToInt32(hdfHisInstancia.Value);
        ObjInstanciaHisConcepto.sIdConcepto = txtIdConcepto.Text;
        ObjInstanciaHisConcepto.sDescripcion = txtDescripcion.Text;
        ObjInstanciaHisConcepto.sComentarios = txtComentarios.Text;
        ObjInstanciaHisConcepto.sTipoDato = cboTipoDato.SelectedValue;
        if (!String.IsNullOrEmpty(txtLongitud.Text))
            ObjInstanciaHisConcepto.iLongitud = Convert.ToInt16(txtLongitud.Text);
        ObjInstanciaHisConcepto.bFlagMayusculas = chkMayuscula.Checked;
        if (!String.IsNullOrEmpty(txtMascara.Text))
            ObjInstanciaHisConcepto.sMascara = txtMascara.Text;
        if (!String.IsNullOrEmpty(txtTipoClasificador.Text))
            ObjInstanciaHisConcepto.iIdTipoClasificador = Convert.ToInt16(txtTipoClasificador.Text);
        if (!String.IsNullOrEmpty(txtAlias.Text))
            ObjInstanciaHisConcepto.sAlias = txtAlias.Text;

    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void gvConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        ObjInstanciaHisConcepto.iIdConexion = _idConexion;
        int rowSelect = gvConcepto.SelectedIndex;
        var dataKey = gvConcepto.DataKeys[rowSelect];
        if (dataKey != null)
        {
            ObjInstanciaHisConcepto.iIdHisInstancia = Convert.ToInt32(gvConcepto.DataKeys[rowSelect]["IdHisInstancia"]);
            hdfHisInstancia.Value = ObjInstanciaHisConcepto.iIdHisInstancia.ToString();
            ObjInstanciaHisConcepto.sIdConcepto = gvConcepto.DataKeys[rowSelect]["IdConcepto"].ToString();
        }


        if (ObjInstanciaHisConcepto.ObtieneFila())
        {
            DataRow dr = ObjInstanciaHisConcepto.DSet.Tables[0].Rows[0];
            txtIdConcepto.Text = dr["IdConcepto"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            txtComentarios.Text = dr["Comentarios"].ToString();
            cboTipoDato.SelectedValue = dr["TipoDato"].ToString();
            cboTipoDato_SelectedIndexChanged(sender, e);
            txtTipoClasificador.Text = dr["IdTipoClasificador"].ToString();
            txtMascara.Text = dr["Mascara"].ToString();
            txtAlias.Text = dr["Alias"].ToString();
            if (!String.IsNullOrEmpty(dr["FlagMayusculas"].ToString()))
                chkMayuscula.Checked = Convert.ToBoolean(dr["FlagMayusculas"]);
            else
                chkMayuscula.Checked = false;

            //btnEliminar.Enabled = true;
            txtIdConcepto.Enabled = false;
        }
        else
        {
            Master.MensajeError("Se produjo un error al seleccionar el concepto", ObjInstanciaHisConcepto.sMensajeError);
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }


    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValores();

            bool resEvento = false;
            string evento = "";

            //if (txtIdConcepto.Enabled)
            //{
            //    resEvento = ObjInstanciaConcepto.Adicion();
            //    evento = "añadió";
            //}
            //else
            //{
            resEvento = ObjInstanciaHisConcepto.Modificacion();
                evento = "modificó";
            //}

            if (resEvento)
            {
                CargarGrillaConceptos();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " el Registro de HisConcepto");
            }
            else
                Master.MensajeError("Se produjo un error al grabar el Concepto", ObjInstanciaHisConcepto.sMensajeError);
        }
    }
    //protected void btnEliminar_Click(object sender, EventArgs e)
    //{
    //    ObjInstanciaConcepto.iIdConexion = _idConexion;
    //    ObjInstanciaConcepto.sIdConcepto = txtIdConcepto.Text;
    //    if (ObjInstanciaConcepto.Eliminacion())
    //    {
    //        CargarGrillaConceptos();
    //        LimpiarCampos();
    //        Master.MensajeOk("Se eliminó el Registro de Concepto correctamente");
    //    }
    //    else
    //    {
    //        Master.MensajeError("Se produjo un error al eliminar el Concepto", ObjInstanciaConcepto.sMensajeError);
    //    }
    //}

    #endregion

    #region EVENTOS_SECUNADARIOS

    protected void gvConcepto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConcepto.PageIndex = e.NewPageIndex;
        CargarGrillaConceptos();
    }

    protected void cboTipoDato_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTipoClasificador.Text = string.Empty;
        txtTipoClasificador.Enabled = false;

        switch (cboTipoDato.SelectedValue)
        {
            case "C":
                txtLongitud.Enabled = true;
                chkMayuscula.Enabled = true;
                txtMascara.Enabled = true;
                break;
            case "T":
                txtTipoClasificador.Enabled = true;
                break;
            default:
                txtLongitud.Enabled = false;
                chkMayuscula.Enabled = false;
                txtMascara.Enabled = false;
                txtLongitud.Text = string.Empty;
                chkMayuscula.Checked = false;
                txtMascara.Text = string.Empty;
                break;
        }
    }

    #endregion

}