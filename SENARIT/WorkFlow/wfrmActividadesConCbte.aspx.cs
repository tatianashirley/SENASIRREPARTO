using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfrmActividadesConCbte : System.Web.UI.Page
{
    clsComprobanteTrasladoDocumento ObjCbteTrsldoDoc = new clsComprobanteTrasladoDocumento();
    clsComprobanteTrasladoDocumentoDet ObjCbteTrsldoDocDet = new clsComprobanteTrasladoDocumentoDet();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            IdConexion = (int)Session["IdConexion"];
            //IdConexion = 4039;
            //IdConexion = 5638;
        }

        if (!Page.IsPostBack)
        {
            CargarCbtesPendientesXUsuario();
            CargaInfComprobante();
            CargaActividadesConCbte();
        }
    }
    private void CargarCbtesPendientesXUsuario()
    {
        ObjCbteTrsldoDoc.iIdConexion = IdConexion;

        if (ObjCbteTrsldoDoc.ObtieneCbtesPendientesXUsuario())
        {
            dllCbtesPendientesXUsuario.DataTextField = "IdCbteArea";
            dllCbtesPendientesXUsuario.DataValueField = "IdComprobante";
            dllCbtesPendientesXUsuario.DataSource = ObjCbteTrsldoDoc.DSet.Tables[0];
            dllCbtesPendientesXUsuario.DataBind();
            dllCbtesPendientesXUsuario.SelectedIndex = 0;
        }
        else
        {
            dllCbtesPendientesXUsuario.Items.Add(new ListItem("El usuario NO tiene Actividades Asignadas", "0"));
            dllCbtesPendientesXUsuario.SelectedValue = "0";
            //Error
            string DetalleError = ObjCbteTrsldoDoc.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void CargaInfComprobante()
    {
        ObjCbteTrsldoDoc.iIdConexion = IdConexion;
        ObjCbteTrsldoDoc.iIdComprobante = Convert.ToInt64(dllCbtesPendientesXUsuario.SelectedValue);
        if (ObjCbteTrsldoDoc.ObtieneFila())
        {
            lblIdComprobante.Text = ObjCbteTrsldoDoc.DSet.Tables[0].Rows[0][0].ToString();
            lblFechaRegistro.Text = ObjCbteTrsldoDoc.DSet.Tables[0].Rows[0][1].ToString();
            lblComentarioGeneral.Text = ObjCbteTrsldoDoc.DSet.Tables[0].Rows[0]["ComentarioGeneral"].ToString();
            lblDescAreaOrigen.Text = ObjCbteTrsldoDoc.DSet.Tables[0].Rows[0]["DescAreaOrigen"].ToString();
            lblDescAreaDestino.Text = ObjCbteTrsldoDoc.DSet.Tables[0].Rows[0]["DescAreaDestino"].ToString();
        }
        else
        {
            //Error
            string DetalleError = ObjCbteTrsldoDoc.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void CargaActividadesConCbte()
    {
        ObjCbteTrsldoDocDet.iIdConexion = IdConexion;
        ObjCbteTrsldoDocDet.iIdComprobante = Convert.ToInt64(dllCbtesPendientesXUsuario.SelectedValue);
        if (ObjCbteTrsldoDocDet.ObtieneDetalleComprobante())
        {
            gvActividadesConCbte.DataSource = ObjCbteTrsldoDocDet.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = ObjCbteTrsldoDocDet.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        gvActividadesConCbte.DataBind();
    }
    protected void chkActividad_CheckedChanged(object sender, EventArgs e)
    {
        //::Llevar a Serverside unicamente, pero despues de haber elejido Client-Side
        // OnCheckedChanged="chkActividad_CheckedChanged"

        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cbx1 = (CheckBox)gvActividadesConCbte.Rows[index].FindControl("chkActividad");

        //here you can find your control and get value(Id).
        int currentRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chkActividadAux = (CheckBox)gvActividadesConCbte.Rows[currentRowIndex].FindControl("chkActividad");
        string IdInstancia = gvActividadesConCbte.DataKeys[currentRowIndex].Value.ToString();
        string Secuencia = gvActividadesConCbte.DataKeys[currentRowIndex]["Secuencia"].ToString();

        ObjCbteTrsldoDocDet.iIdConexion = IdConexion;
        ObjCbteTrsldoDocDet.iIdComprobante = Convert.ToInt64(dllCbtesPendientesXUsuario.SelectedValue);
        ObjCbteTrsldoDocDet.iIdInstancia = Convert.ToInt64(IdInstancia);
        ObjCbteTrsldoDocDet.iSecuencia = Convert.ToInt32(Secuencia);
        if (chkActividadAux.Checked)
        {
            ObjCbteTrsldoDocDet.bFlagAceptacion = true;
        }
        else
        {
            ObjCbteTrsldoDocDet.bFlagAceptacion = false;
        }
        if (!ObjCbteTrsldoDocDet.Modificacion())
        {
            //Error
            string DetalleError = ObjCbteTrsldoDocDet.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    protected void dllActividad_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaInfComprobante();
        CargaActividadesConCbte();
    }
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        /*:: Aqui ejecutar todo */
        for (int iRowIndex = 0; iRowIndex < gvActividadesConCbte.Rows.Count; iRowIndex++)
        {
            CheckBox chkActividadAux = (CheckBox)gvActividadesConCbte.Rows[iRowIndex].Cells[0].FindControl("chkActividad");
            if (chkActividadAux != null)
            {
                if (chkActividadAux.Checked)
                {
                    string IdInstancia = gvActividadesConCbte.DataKeys[iRowIndex].Value.ToString();
                    string Secuencia = gvActividadesConCbte.DataKeys[iRowIndex]["Secuencia"].ToString();

                    //ejecutamos la tarea objetivo del for
                    ObjCbteTrsldoDocDet.iIdConexion = IdConexion;
                    ObjCbteTrsldoDocDet.iIdComprobante = Convert.ToInt64(dllCbtesPendientesXUsuario.SelectedValue);
                    ObjCbteTrsldoDocDet.iIdInstancia = Convert.ToInt64(IdInstancia);
                    ObjCbteTrsldoDocDet.iSecuencia = Convert.ToInt32(Secuencia);
                    if (chkActividadAux.Checked)
                    {
                        ObjCbteTrsldoDocDet.bFlagAceptacion = true;
                    }
                    //else
                    //{
                    //    ObjCbteTrsldoDocDet.bFlagAceptacion = false;
                    //}
                    if (!ObjCbteTrsldoDocDet.Modificacion())
                    {
                        //Error
                        string DetalleError = ObjCbteTrsldoDocDet.sMensajeError;
                        string Error = "Error al realizar la operación";
                        Master.MensajeError(Error, DetalleError);
                        return;
                    }
                }
            }
        }

        //*/
        ObjCbteTrsldoDoc.iIdConexion = IdConexion;
        ObjCbteTrsldoDoc.iIdComprobante = Convert.ToInt64(dllCbtesPendientesXUsuario.SelectedValue);
        if (!ObjCbteTrsldoDoc.Modificacion())
        {
            //Error
            string DetalleError = ObjCbteTrsldoDoc.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
            return;
        }
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
}