using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfDocumento.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmTipoTramiteTipoDoc : System.Web.UI.Page
{
    private clsTipoTramiteTipoDocumento objInstTipTramTipDoc = new clsTipoTramiteTipoDocumento();
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

            CargarCboTipoDocumento();
            CargarGrillaTipTramTipDoc();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void CargarCboTipoDocumento()
    {
        var objInstTipoDoc = new clsTipoDocumento();

        cboTipoDocumento.Items.Clear();

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
            Master.MensajeError("Se produjo un error en el cargado del combo de Tipo de Documentos", objInstTipoDoc.sMensajeError);
    }

    private void CargarGrillaTipTramTipDoc()
    {
        AsignarValoresPivote();

        if (objInstTipTramTipDoc.ObtieneConceptosXTipoTramite())
        {
            gvTipTramTipDoc.DataSource = objInstTipTramTipDoc.DSet.Tables[0];
            gvTipTramTipDoc.DataBind();
        }
        else
        {
            gvTipTramTipDoc.DataSource = null;
            gvTipTramTipDoc.DataBind();

            if(objInstTipTramTipDoc.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Tipos de Documentos asociados al Tipo de Trámite", objInstTipTramTipDoc.sMensajeError);
        }
    }

    private void LimpiarCampos()
    {
        txtComentarios.Text = string.Empty;
        cboTipoDocumento.SelectedIndex = 0;
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        cboTipoDocumento.Enabled = true;
        btnEliminar.Enabled = false;        
        _filaSeleccionada = false;

        LimpiarMensajesMasterPage();
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }


    private void AsignarValoresPivote()
    {
        objInstTipTramTipDoc.iIdConexion = _idConexion;
        objInstTipTramTipDoc.sIdTipoTramite = _idTipoTramite;
        objInstTipTramTipDoc.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        if (!string.IsNullOrEmpty(cboTipoDocumento.SelectedValue))
            objInstTipTramTipDoc.iIdTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
    }

    private void AsignarValores()
    {        
        objInstTipTramTipDoc.sComentarios = txtComentarios.Text;
        objInstTipTramTipDoc.bFlagSolicitud = chkRegSolicitud.Checked;
        objInstTipTramTipDoc.bFlagObligatorio = chkCaracterObli.Checked;
        objInstTipTramTipDoc.bFlagRepeticion = chkRegVarDocMismoTiempo.Checked;
    }

    #endregion


    #region EVENTOS_PRIMARIOS

    protected void gvTipTramTipDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        AsignarValoresPivote();
        var rowSelect = gvTipTramTipDoc.SelectedRow.RowIndex;
        var dataKey = gvTipTramTipDoc.DataKeys[rowSelect];
        if (dataKey != null)
            objInstTipTramTipDoc.iIdTipoDocumento = Convert.ToInt32(dataKey.Value);

        if (objInstTipTramTipDoc.ObtieneFila())
        {
            var dr = objInstTipTramTipDoc.DSet.Tables[0].Rows[0];

            cboTipoDocumento.SelectedValue = dr["IdTipoDocumento"].ToString();
            txtComentarios.Text = dr["Comentarios"].ToString();
            chkRegSolicitud.Checked = Convert.ToBoolean(dr["FlagSolicitud"]);
            chkCaracterObli.Checked = Convert.ToBoolean(dr["FlagObligatorio"]);
            chkRegVarDocMismoTiempo.Checked = Convert.ToBoolean(dr["FlagRepeticion"]);

            _filaSeleccionada = true;
            cboTipoDocumento.Enabled = false;
            btnEliminar.Enabled = true;
        }
        else
        {
            _filaSeleccionada = false;
            btnEliminar.Enabled = false;
            Master.MensajeError("Se produjo un error al recuperar el registro de Documento asociado al Tipo de Trámite", objInstTipTramTipDoc.sMensajeError);
        }

    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmTipoTramite.aspx");
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValoresPivote();
            AsignarValores();

            string evento;
            bool resEvento = false;

            if (!_filaSeleccionada)
            {
                resEvento = objInstTipTramTipDoc.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objInstTipTramTipDoc.Modificacion();
                evento = "modificó";  
            }

            if (resEvento)
            {
                CargarGrillaTipTramTipDoc();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Documento asociado al Tipo de Trámite");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Documento asociado al Tipo de Trámite", objInstTipTramTipDoc.sMensajeError);
            }
        }
    }

    
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objInstTipTramTipDoc.Eliminacion())
        {
            LimpiarCampos();
            CargarGrillaTipTramTipDoc();
            Master.MensajeOk("Se eliminó correctamente el registro de Documento asociado al Tipo de Trámite");
        }
        else
        {
            Master.MensajeError("Se produjo un error al eliminar el registro de Documento asociado al Tipo de Trámite", objInstTipTramTipDoc.sMensajeError);
        }
    }
   

    #endregion


    #region EVENTOS_SECUNDARIOS

    protected void gvTipTramTipDoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipTramTipDoc.PageIndex = e.NewPageIndex;
        CargarGrillaTipTramTipDoc();
    }
    

    #endregion
    
}