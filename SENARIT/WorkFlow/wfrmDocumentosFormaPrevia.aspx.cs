using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfDocumento.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmDocumentosFormaPrevia : System.Web.UI.Page
{
    private clsFlujoNodoPredecesorTDocCond objFNPredTDoc = new clsFlujoNodoPredecesorTDocCond();

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
            cboActividad.SelectedValue = _idNodo.ToString();
            cboActPredecesora.SelectedValue = _idNodoPred.ToString();
            CargarCboTipoDocumento();
            CargarGrillaDocPrevios();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS

    private void AsignarValoresPivote()
    {

        objFNPredTDoc.iIdConexion = _idConexion;
        objFNPredTDoc.sIdTipoTramite = _idTipoTramite;
        objFNPredTDoc.iIdFlujo = _idFlujo;
        objFNPredTDoc.iIdNodoPred = _idNodoPred;
        objFNPredTDoc.iIdNodo = _idNodo;

        if (cboTipoDoc.SelectedIndex > 0)
            objFNPredTDoc.iIdTipoDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
    }


    private void AsignarValores()
    {
        if (chkEstado.Checked)
            objFNPredTDoc.sEstado = "A";
        else
            objFNPredTDoc.sEstado = "I";
    }

    private void CargarGrillaDocPrevios()
    {
        AsignarValoresPivote();

        if (objFNPredTDoc.ObtieneTDocsXTransicion())
        {
            gvDocPrevio.DataSource = objFNPredTDoc.DSet.Tables[0];
            gvDocPrevio.DataBind();
        }
        else
        {
            gvDocPrevio.DataSource = null;
            gvDocPrevio.DataBind();

            if(objFNPredTDoc.iNivelError == 1)
                Master.MensajeError("Se produjo un error al cargar la grilla de Documentos Registrados de Forma Previa", objFNPredTDoc.sMensajeError);
        }
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

    private DataTable CargarTipoDoc()
    {
        var objInstTipoDoc = new clsTipoDocumento();

        objInstTipoDoc.iIdConexion = _idConexion;
        if (objInstTipoDoc.ObtieneTiposDeDocumento())
            return objInstTipoDoc.DSet.Tables[0];
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

    private void CargarCboTipoDocumento()
    {
        cboTipoDoc.DataSource = CargarCboTipoDocXTram(_idTipoTramite);
        cboTipoDoc.DataTextField = "Descripcion";
        cboTipoDoc.DataValueField = "IdTipoDocumento";
        cboTipoDoc.DataBind();

        cboTipoDoc.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
        cboTipoDoc.SelectedIndex = 0;
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
        chkEstado.Checked = false;

        btnEliminar.Enabled = false;
        cboTipoDoc.Enabled = true;
    }

    #endregion


    #region EVENTOS_PRINCIPALES

    protected void gvDocPrevio_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        AsignarValoresPivote();

        var rowSelect = gvDocPrevio.SelectedRow.RowIndex;
        var dataKey = gvDocPrevio.DataKeys[rowSelect];
        if (dataKey != null)
            objFNPredTDoc.iIdTipoDocumento = (int) dataKey.Value;

        if (objFNPredTDoc.ObtieneFila())
        {
            var dr = objFNPredTDoc.DSet.Tables[0].Rows[0];

            cboTipoDoc.SelectedValue = dr["IdTipoDocumento"].ToString();
            if (dr["Estado"].ToString() == "A")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;         

            btnEliminar.Enabled = true;
            cboTipoDoc.Enabled = false;
        }
        else
        {
            Master.MensajeError("Se produjo un error al recuperar el Documento Registrado de Forma Previa", objFNPredTDoc.sMensajeError);
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

            if(cboTipoDoc.Enabled)
            {
                resEvento = objFNPredTDoc.Adicion();
                evento = "añadió";
            }
            else
            {
                resEvento = objFNPredTDoc.Modificacion();
                evento = "modificó";
            }

            if (resEvento)
            {
                CargarGrillaDocPrevios();
                LimpiarCampos();
                Master.MensajeOk("Se " + evento + " correctamente el Documento Registrado de Forma Previa");
            }
            else
            {
                Master.MensajeError("Se produjo un error al guardar el Documento Registrado de Forma Previa", objFNPredTDoc.sMensajeError);
            }
        }

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        AsignarValoresPivote();

        if (objFNPredTDoc.Eliminacion())
        {
            CargarGrillaDocPrevios();
            LimpiarCampos();
            Master.MensajeOk("Se eliminó correctamente el Documento Registrado de Forma Previa");
        }
        else
        {
            Master.MensajeError("Se produjo un error en la eliminación del Documento Registrado de Forma Previa", objFNPredTDoc.sMensajeError);
        }
    }    

    #endregion


    #region EVENTO_SECUNDARIOS

    protected void gvDocPrevio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocPrevio.PageIndex = e.NewPageIndex;
        CargarGrillaDocPrevios();
    }

    protected void imgAtras_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmPrecedenciaActividades.aspx");
    }

    #endregion


}