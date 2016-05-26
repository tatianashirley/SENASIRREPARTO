using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmHisGrupoRestricciones : System.Web.UI.Page
{
    private clsHisGrupoRestriccion objInstanciaGrupoRest = new clsHisGrupoRestriccion();
    private clsHisGrupoRestriccionDet objInstanciaGrupoRestDet = new clsHisGrupoRestriccionDet();
    private int _idConexion;

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
            //Maestro
            CargarGrillaGrupoRestriccion();

            //Detalle
            CargarCboRestricciones();

            Master.btnCerrarSesion.CausesValidation = false;
        }
    }

    #region CARGAR_DATOS_MAESTRO

    private void CargarGrillaGrupoRestriccion()
    {
        objInstanciaGrupoRest.iIdConexion = _idConexion;
        if (objInstanciaGrupoRest.ObtieneGruposDeRestricciones())
        {
            gvGrupRestric.DataSource = objInstanciaGrupoRest.DSet;
            gvGrupRestric.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla de Grupo de Restricción", objInstanciaGrupoRest.sMensajeError);
            gvGrupRestric.DataSource = null;
            gvGrupRestric.DataBind();
        }
    }


    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    private void LimpiarCamposPnlMestro()
    {

        LimpiarMensajesMasterPage();

        pnlMaestro.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        pnlDetalle.Visible = false;
        txtIdGrupRestric.Enabled = true;
        //btnEliminar.Enabled = false;
    }

    private void AsignarValoresMaestro()
    {
        objInstanciaGrupoRest.iIdConexion = _idConexion;
        objInstanciaGrupoRest.iIdGrupoRestriccion = Convert.ToInt32(txtIdGrupRestric.Text);
        objInstanciaGrupoRest.iIdHisInstancia = Convert.ToInt32(hdfHisInstancia.Value);
        objInstanciaGrupoRest.sDescripcion = txtDescripcion.Text;
        objInstanciaGrupoRest.sComentarios = txtComentarios.Text;
        objInstanciaGrupoRest.sReglaEvaluacion = txtReglaEvaluacion.Text;
    }

    private void LlenarCamposMaestro(DataRow dr)
    {
        txtIdGrupRestric.Text = dr["IdGrupoRestriccion"].ToString();
        txtDescripcion.Text = dr["Descripcion"].ToString();
        txtComentarios.Text = dr["Comentarios"].ToString();
        txtReglaEvaluacion.Text = dr["ReglaEvaluacion"].ToString();

        txtIdGrupRestric.Enabled = false;
        //btnEliminar.Enabled = true;
        pnlDetalle.Visible = true;
    }


    #endregion


    #region EVENTOS_MAESTRO_PRIMARIOS

    protected void gvGrupRestric_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarMensajesMasterPage();

        int rowSelect = gvGrupRestric.SelectedRow.RowIndex;
        //objInstanciaGrupoRest.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect].Value);
        objInstanciaGrupoRest.iIdConexion = _idConexion;

        var dataKey = gvGrupRestric.DataKeys[rowSelect];
        if (dataKey != null)
        {
            objInstanciaGrupoRest.iIdHisInstancia = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect]["IdHisInstancia"]);
            hdfHisInstancia.Value = objInstanciaGrupoRest.iIdHisInstancia.ToString();
            objInstanciaGrupoRest.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect]["IdGrupoRestriccion"]);
        }

        if (objInstanciaGrupoRest.ObtieneFila())
        {
            DataRow dr = objInstanciaGrupoRest.DSet.Tables[0].Rows[0];
            LlenarCamposMaestro(dr);

            CargarGrillaGrupoRestricDet();
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de Grupo de Restricciones", objInstanciaGrupoRest.sMensajeError);
            pnlDetalle.Visible = false;
        }
    }

    //protected void btnNuevo_Click(object sender, EventArgs e)
    //{
    //    LimpiarCamposPnlMestro();
    //}

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Page.Validate("maestro");

        if (Page.IsValid)
        {
            AsignarValoresMaestro();

            string evento = null;
            bool resEvento = false;
            //if (txtIdGrupRestric.Enabled)
            //{
            //    resEvento = objInstanciaGrupoRest.Adicion();
            //    evento = "adicionó";
            //}
            //else
            //{
                resEvento = objInstanciaGrupoRest.Modificacion();
                evento = "modificó";
            //}

            if (resEvento)
            {
                LimpiarCamposPnlMestro();
                CargarGrillaGrupoRestriccion();
                Master.MensajeOk("Se " + evento + " el registro de Grupo de Restricción");
            }
            else
                Master.MensajeError("Se produjo al grabar el Grupo de Restricción", objInstanciaGrupoRest.sMensajeError);
        }
    }

    //protected void btnEliminar_Click(object sender, EventArgs e)
    //{
    //    int rowSelect = gvGrupRestric.SelectedRow.RowIndex;
    //    objInstanciaGrupoRest.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect].Value);
    //    objInstanciaGrupoRest.iIdConexion = _idConexion;

    //    if (objInstanciaGrupoRest.Eliminacion())
    //    {
    //        LimpiarCamposPnlMestro();
    //        CargarGrillaGrupoRestriccion();
    //        Master.MensajeOk("Se eliminó el registro de Grupo de Restricción");
    //    }
    //    else
    //        Master.MensajeError("Se produjo un error en el cargado de Restricciones", objInstanciaGrupoRest.sMensajeError);
    //}

    #endregion


    #region EVENTOS_MAESTRO_SECUNDARIOS

    protected void gvGrupRestric_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGrupRestric.PageIndex = e.NewPageIndex;
        CargarGrillaGrupoRestriccion();
    }

    #endregion


    #region CARGAR_DATOS_DETALLE

    private void LimpiarCamposPnlDetalle()
    {
        pnlDetalle.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        cboRestriccion.SelectedIndex = 0;
        chkSubGrupoInclusivo.Checked = false;
        //btnEliminar.Enabled = false;
        cboRestriccion.Enabled = true;
    }

    private void CargarCboRestricciones()
    {
        var objInstRestricciones = new clsHisRestriccion();

        
        objInstRestricciones.iIdConexion = _idConexion;
        if (objInstRestricciones.ObtieneHisRestricciones())
        {
            cboRestriccion.DataSource = objInstRestricciones.DSet.Tables[0];
            cboRestriccion.DataTextField = "Descripcion";
            cboRestriccion.DataValueField = "IdRestriccion";
            cboRestriccion.DataBind();

            cboRestriccion.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
            cboRestriccion.SelectedIndex = 0;
        }
        else
            Master.MensajeError("Se produjo un error en el cargado de Restricciones", objInstRestricciones.sMensajeError);
    }

    private void CargarGrillaGrupoRestricDet()
    {
        int rowSelect = gvGrupRestric.SelectedRow.RowIndex;

        var dataKey = gvGrupRestric.DataKeys[rowSelect];
        if (dataKey != null)
        {
            objInstanciaGrupoRestDet.iIdHisInstancia = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect]["IdHisInstancia"]);
            hdfHisInstancia2.Value = objInstanciaGrupoRest.iIdHisInstancia.ToString();
            objInstanciaGrupoRestDet.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect]["IdGrupoRestriccion"]);
            objInstanciaGrupoRestDet.iIdConexion = _idConexion;
        }


        if (objInstanciaGrupoRestDet.ObtieneDetalleGrupoDeRestricciones())
        {
            gvGrupoRestricDet.DataSource = objInstanciaGrupoRestDet.DSet.Tables[0];
            gvGrupoRestricDet.DataBind();
            pnlDetalle.Visible = true;
        }
        else
        {
            Master.MensajeError("Se produjo un error en el cargado de Detalle de Grupo de Restricciones", objInstanciaGrupoRestDet.sMensajeError);
            gvGrupoRestricDet.DataSource = null;
            gvGrupoRestricDet.DataBind();
        }
    }


    private void CargarCamposDetalle(int pIdGrupoRestricion,int pIdHisIntancia)
    {
        objInstanciaGrupoRestDet.iIdConexion = _idConexion;
        objInstanciaGrupoRestDet.iIdHisInstancia = pIdHisIntancia;
        objInstanciaGrupoRestDet.iIdGrupoRestriccion = pIdGrupoRestricion;

        if (objInstanciaGrupoRestDet.ObtieneFila())
        {
            DataRow dr = objInstanciaGrupoRestDet.DSet.Tables[0].Rows[0];
            cboRestriccion.SelectedValue = dr["IdRestriccion"].ToString();
            txtOrden.Text = dr["Orden"].ToString();
            txtSubGrupo.Text = dr["SubGrupo"].ToString();
            if (!string.IsNullOrEmpty(txtSubGrupo.Text) && !string.IsNullOrEmpty(dr["FlagInclusivo"].ToString()))
                chkSubGrupoInclusivo.Checked = Convert.ToBoolean(dr["FlagInclusivo"]);
            txtProcedimiento.Text = dr["IdProcedimiento"].ToString();
            txtParametro.Text = dr["IdParametro"].ToString();
            txtReglaEvaluacionDet.Text = dr["ReglaEvaluacion"].ToString();
        }
        else
            Master.MensajeError("Se produjo un error en el cargado de los campos de Detalle de Grupo de Restricciones", objInstanciaGrupoRestDet.sMensajeError);
    }

    private void AsignarValoresDetalle()
    {
        int rowSelect = gvGrupRestric.SelectedRow.RowIndex;
        objInstanciaGrupoRestDet.iIdConexion = _idConexion;
        objInstanciaGrupoRestDet.iIdHisInstancia = Convert.ToInt32(hdfHisInstancia.Value);
        objInstanciaGrupoRestDet.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect].Value);
        objInstanciaGrupoRestDet.iIdRestriccion = Convert.ToInt32(cboRestriccion.SelectedValue);
        objInstanciaGrupoRestDet.iOrden = Convert.ToInt16(txtOrden.Text);
        if (!string.IsNullOrEmpty(txtSubGrupo.Text))
            objInstanciaGrupoRestDet.iSubGrupo = Convert.ToInt16(txtSubGrupo.Text);
        objInstanciaGrupoRestDet.bFlagInclusivo = chkSubGrupoInclusivo.Checked;
        objInstanciaGrupoRestDet.iIdProcedimiento = Convert.ToInt32(txtProcedimiento.Text);
        objInstanciaGrupoRestDet.sIdParametro = txtParametro.Text;

        if (!string.IsNullOrEmpty(txtReglaEvaluacionDet.Text))
            objInstanciaGrupoRestDet.sReglaEvaluacion = txtReglaEvaluacionDet.Text;
    }

    #endregion


    #region EVENTOS_DETALLE_PRIMARIOS

    protected void gvGrupoRestricDet_SelectedIndexChanged(object sender, EventArgs e)
    {
        int rowSelect = gvGrupRestric.SelectedRow.RowIndex;
        int rowSelectDet = gvGrupoRestricDet.SelectedRow.RowIndex;
        objInstanciaGrupoRestDet.iIdConexion = _idConexion;
        objInstanciaGrupoRestDet.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect].Value);
        objInstanciaGrupoRestDet.iIdRestriccion = Convert.ToInt32(gvGrupoRestricDet.DataKeys[rowSelectDet].Value);
        objInstanciaGrupoRestDet.iIdHisInstancia = Convert.ToInt32(hdfHisInstancia.Value);
        if (objInstanciaGrupoRestDet.ObtieneFila())
        {
            CargarCamposDetalle(objInstanciaGrupoRestDet.iIdGrupoRestriccion,Convert.ToInt32(hdfHisInstancia.Value));

            //btnEliminar.Enabled = true;
            cboRestriccion.Enabled = false;
            //btnEliminarDet.Enabled = true;
        }
        else
            Master.MensajeError("Se produjo al cargar la grilla de Detalle de Grupo de Restricciones", objInstanciaGrupoRestDet.sMensajeError);
    }

    //protected void btnNuevoDet_Click(object sender, EventArgs e)
    //{
    //    LimpiarCamposPnlDetalle();

    //}

    protected void btnGuardarDet_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            AsignarValoresDetalle();

            bool resEvento = false;
            string evento;
            //if (cboRestriccion.Enabled)
            //{
            //    resEvento = objInstanciaGrupoRestDet.Adicion();
            //    evento = "adicionó";
            //}
            //else
            //{
                resEvento = objInstanciaGrupoRestDet.Modificacion();
                evento = "modificó";
            //}

            if (resEvento)
            {
                CargarGrillaGrupoRestricDet();
                LimpiarCamposPnlDetalle();
                Master.MensajeOk("Se " + evento + " el registro de Detalle de Grupo de Restricciones.");
            }
            else
                Master.MensajeError("Se produjo al grabar el Detalle de Grupo de Restricciones", objInstanciaGrupoRestDet.sMensajeError);
        }
    }

    //protected void btnEliminarDet_Click(object sender, EventArgs e)
    //{
    //    int rowSelect = gvGrupRestric.SelectedRow.RowIndex;
    //    int rowSelectDet = gvGrupoRestricDet.SelectedRow.RowIndex;

    //    objInstanciaGrupoRestDet.iIdConexion = _idConexion;
    //    objInstanciaGrupoRestDet.iIdGrupoRestriccion = Convert.ToInt32(gvGrupRestric.DataKeys[rowSelect].Value);
    //    objInstanciaGrupoRestDet.iIdRestriccion = Convert.ToInt32(gvGrupoRestricDet.DataKeys[rowSelectDet].Value);

    //    if (objInstanciaGrupoRestDet.Eliminacion())
    //    {
    //        CargarGrillaGrupoRestricDet();
    //        LimpiarCamposPnlDetalle();
    //        Master.MensajeOk("Se eliminó correctamente el Detalle de Grupo de Restricción");
    //    }
    //    else
    //        Master.MensajeError("Se produjo al eliminar el Detalle de Grupo de Restricciones", objInstanciaGrupoRestDet.sMensajeError);
    //}

    #endregion


    #region EVENTOS_DETALLE_SECUNDARIOS

    protected void gvGrupoRestricDet_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGrupoRestricDet.PageIndex = e.NewPageIndex;
        CargarGrillaGrupoRestricDet();
    }

    #endregion


}