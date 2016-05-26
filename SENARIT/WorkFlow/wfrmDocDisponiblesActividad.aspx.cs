using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfDocumento.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmDocDisponiblesActividad : System.Web.UI.Page
{
    private clsFlujoNodoTipoDocumento objFNTipDoc = new clsFlujoNodoTipoDocumento();

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

            CargarGrillaFlujoTipoDoc();
            CargarCboTipoDoc();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void AsignarValoresPivote()
    {
        objFNTipDoc.iIdConexion = _idConexion;
        objFNTipDoc.iIdFlujo = _idFlujo;
        objFNTipDoc.iIdNodo = _idNodo;
        objFNTipDoc.sIdTipoTramite = _idTipoTramite;
        if (cboTipoDoc.SelectedIndex > 0)
            objFNTipDoc.iIdTipoDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
    }

    private void AsignarValores()
    {
        objFNTipDoc.bFlagObligatorio = chkObligatorio.Checked;
        objFNTipDoc.bFlagModificable = chkModificable.Checked;
        if (chkActivo.Checked)
            objFNTipDoc.sEstado = "A";
        else
            objFNTipDoc.sEstado = "I";
    }

    private DataTable CargarTipoDoc()
    {
        var objInstTipoDoc = new clsTipoDocumento();

        objInstTipoDoc.iIdConexion = _idConexion;
        if (objInstTipoDoc.ObtieneTiposDeDocumento())
            return objInstTipoDoc.DSet.Tables[0];
        else
            return null;
    }

    private DataTable CargarTipoTramTipoDoc(string pIdTipoTram)
    {
        var objTramTipoDoc = new clsTipoTramiteTipoDocumento();

        objTramTipoDoc.iIdConexion = _idConexion;
        objTramTipoDoc.sIdTipoTramite = pIdTipoTram;
        if (objTramTipoDoc.ObtieneConceptosXTipoTramite())
            return objTramTipoDoc.DSet.Tables[0];
        else
            return null;
    }

    private DataTable CargarCboTipoDocXTram(string pIdTipoTram)
    {
        try
        {
            var dtTipDoc = CargarTipoDoc();
            var dtTipTramTipDoc = CargarTipoTramTipoDoc(pIdTipoTram);

            if (dtTipTramTipDoc != null)
            {
                var query =
                    from dtTD in dtTipDoc.AsEnumerable()
                    join dtTT in dtTipTramTipDoc.AsEnumerable() on dtTD["IdTipoDocumento"] equals dtTT["IdTipoDocumento"]
                    where Equals(dtTT["IdTipoTramite"], pIdTipoTram)
                    select new {Id = dtTD["IdTipoDocumento"], Desc = dtTD["Descripcion"]};

                var dtNueva = new DataTable();
                dtNueva.Columns.Add("IdTipoDocumento", typeof (Int32));
                dtNueva.Columns.Add("Descripcion", typeof (string));

                foreach (var rowInfo in query)
                {
                    dtNueva.Rows.Add(rowInfo.Id, rowInfo.Desc);
                }

                return dtNueva;
            }
            else
            {
                Master.MensajeError("Se produjo un error al obtener Tipos de Documentos por Trámite", "Se produjo un error al obtener Tipos de Documentos por Trámite -> CargarTipoTramTipoDoc("+pIdTipoTram+")");
                return null;
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error en el cargado de Tipo Documento asociados al Tipo de Trámite", ex.Message);
            return null;
        }

    }

    private void CargarCboTipoDoc()
    {
        cboTipoDoc.DataSource = CargarCboTipoDocXTram(_idTipoTramite);
        cboTipoDoc.DataTextField = "Descripcion";
        cboTipoDoc.DataValueField = "IdTipoDocumento";
        cboTipoDoc.DataBind();

        cboTipoDoc.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboTipoDoc.SelectedIndex = 0;
    }

    private void CargarGrillaFlujoTipoDoc()
    {
        AsignarValoresPivote();

        if (objFNTipDoc.ObtieneTDocsXNodo())
        {
            gvTipDoc.DataSource = objFNTipDoc.DSet.Tables[0];
            gvTipDoc.DataBind();
        }
        else
        {            
            gvTipDoc.DataSource = null;
            gvTipDoc.DataBind();

            if(objFNTipDoc.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de historial", objFNTipDoc.sMensajeError);
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

        cboTipoDoc.SelectedIndex = 0;
        pnlDatos.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);

        cboTipoDoc.Enabled = true;
        btnEliminar.Enabled = false;
    }

    #endregion


    #region EVENTOS_PRINCIPALES

    protected void gvTipDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvTipDoc.SelectedRow.RowIndex;
        var dataKey = gvTipDoc.DataKeys[rowSelect];
        if (dataKey != null)
            objFNTipDoc.iIdTipoDocumento = (int) dataKey.Values["IdTipoDocumento"];

        if (objFNTipDoc.ObtieneFila())
        {
            var dr = objFNTipDoc.DSet.Tables[0].Rows[0];
            cboTipoDoc.SelectedValue = dr["IdTipoDocumento"].ToString();
            chkModificable.Checked = Convert.ToBoolean(dr["FlagModificable"]);
            chkObligatorio.Checked = Convert.ToBoolean(dr["FlagObligatorio"]);

            if (dr["Estado"].ToString() == "A")
                chkActivo.Checked = true;
            else
                chkActivo.Checked = false;
            
            btnEliminar.Enabled = true;
            cboTipoDoc.Enabled = false;
        }
        else
        {
            Master.MensajeError("Se produjo un error al recuperar el registro de Documento Disponible para la Actividad", objFNTipDoc.sMensajeError);
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

            if (cboTipoDoc.Enabled)
            {
                resEvento = objFNTipDoc.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objFNTipDoc.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaFlujoTipoDoc();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el registro de Documento Disponible para la Actividad");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el registro de Documento Disponible para la Actividad", objFNTipDoc.sMensajeError);
            }
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFNTipDoc.Eliminacion())
        {
            CargarGrillaFlujoTipoDoc();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el registro de Documento Disponible para la Actividad");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación de Documento Disponible para la Actividad", objFNTipDoc.sMensajeError);
        }
    }
    
    #endregion


    #region EVENTOS_SECUNDARIOS
    protected void gvTipDoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipDoc.PageIndex = e.NewPageIndex;
        CargarGrillaFlujoTipoDoc();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmActividadesFlujo.aspx");
    }

    #endregion

    
}