using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmConceptos : System.Web.UI.Page
{
    clsConcepto ObjInstanciaConcepto = new clsConcepto();
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
        ObjInstanciaConcepto.iIdConexion = _idConexion;
        if (ObjInstanciaConcepto.ObtieneConceptos())
        {
            gvConcepto.DataSource = ObjInstanciaConcepto.DSet.Tables[0];
            gvConcepto.DataBind();
        }
        else
        {
            gvConcepto.DataSource = null;
            gvConcepto.DataBind();

            if(ObjInstanciaConcepto.iNivelError == 1)
                Master.MensajeError("Se produjo un error en el cargado de conceptos", ObjInstanciaConcepto.sMensajeError);
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
        btnEliminar.Enabled = false;
    }

    private void AsignarValores()
    {
        ObjInstanciaConcepto.iIdConexion = _idConexion;
        ObjInstanciaConcepto.sIdConcepto = txtIdConcepto.Text;
        ObjInstanciaConcepto.sDescripcion = txtDescripcion.Text;
        ObjInstanciaConcepto.sComentarios = txtComentarios.Text;
        ObjInstanciaConcepto.sTipoDato = cboTipoDato.SelectedValue;
        if (!String.IsNullOrEmpty(txtLongitud.Text))
            ObjInstanciaConcepto.iLongitud = Convert.ToInt16(txtLongitud.Text);
        ObjInstanciaConcepto.bFlagMayusculas = chkMayuscula.Checked;
        if (!String.IsNullOrEmpty(txtMascara.Text))
            ObjInstanciaConcepto.sMascara = txtMascara.Text;
        if (!String.IsNullOrEmpty(txtTipoClasificador.Text))
            ObjInstanciaConcepto.iIdTipoClasificador = Convert.ToInt16(txtTipoClasificador.Text);
        if (!String.IsNullOrEmpty(txtAlias.Text))
            ObjInstanciaConcepto.sAlias = txtAlias.Text;

    }

    #endregion

    #region EVENTOS_PRINCIPALES
    
    protected void gvConcepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        ObjInstanciaConcepto.iIdConexion = _idConexion;        
        int rowSelect = gvConcepto.SelectedIndex;
        var dataKey = gvConcepto.DataKeys[rowSelect];
        if (dataKey != null)
            ObjInstanciaConcepto.sIdConcepto = dataKey.Value.ToString();

        if (ObjInstanciaConcepto.ObtieneFila())
        {
            DataRow dr = ObjInstanciaConcepto.DSet.Tables[0].Rows[0];            
            txtIdConcepto.Text = dr["IdConcepto"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();            
            txtComentarios.Text = dr["Comentarios"].ToString();
            cboTipoDato.SelectedValue = dr["TipoDato"].ToString();
            cboTipoDato_SelectedIndexChanged(sender,e);
            txtTipoClasificador.Text = dr["IdTipoClasificador"].ToString();
            txtMascara.Text = dr["Mascara"].ToString();
            txtAlias.Text = dr["Alias"].ToString();
            if (!String.IsNullOrEmpty(dr["FlagMayusculas"].ToString()))
                chkMayuscula.Checked = Convert.ToBoolean(dr["FlagMayusculas"]);
            else
                chkMayuscula.Checked = false;

            btnEliminar.Enabled = true;
            txtIdConcepto.Enabled = false;
        }
        else 
        {
            Master.MensajeError("Se produjo un error al seleccionar el concepto", ObjInstanciaConcepto.sMensajeError);        
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

            if (txtIdConcepto.Enabled)
            {
                resEvento = ObjInstanciaConcepto.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = ObjInstanciaConcepto.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaConceptos();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " el Registro de Concepto");
            }
            else            
                Master.MensajeError("Se produjo un error al grabar el Concepto", ObjInstanciaConcepto.sMensajeError);
        }
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ObjInstanciaConcepto.iIdConexion = _idConexion;
        ObjInstanciaConcepto.sIdConcepto = txtIdConcepto.Text;
        if (ObjInstanciaConcepto.Eliminacion())
        {
            CargarGrillaConceptos();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó el Registro de Concepto correctamente");
        }
        else
        {
            Master.MensajeError("Se produjo un error al eliminar el Concepto", ObjInstanciaConcepto.sMensajeError);
        }
    }

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