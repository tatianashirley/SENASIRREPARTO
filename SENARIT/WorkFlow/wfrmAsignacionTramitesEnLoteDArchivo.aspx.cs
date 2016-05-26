using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using System.Data.SqlClient;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;
using System.Data;

public partial class WorkFlow_wfrmAsignacionTramitesEnLoteDArchivo : System.Web.UI.Page
{
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    clsTransicionMasivaDet ObjTransicionMasivaDet = new clsTransicionMasivaDet();
    clsTransicionMasiva ObjTransicionMasiva = new clsTransicionMasiva();

    clsComprobanteTrasladoDocumentoDetTmp ObjCbteTrsldoDocDetTmp = new clsComprobanteTrasladoDocumentoDetTmp();
    clsComprobanteTrasladoDocumento ObjCbteTrsldoDoc = new clsComprobanteTrasladoDocumento();

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
            Session["iIdTransicionMsva"] = null;
            CargaTransicionesDelUsuario();
            CargaActividadesPorAsignar();
            btnGenerar.Enabled = false;
        }
    }

    private void CargaTransicionesDelUsuario()
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;

        if (ObjInstanciaNodo.ObtieneTransicionesParaAsignacion())
        {
            ddlTransicionesDelUsuario.DataTextField = "IdNodoOrigDesc_IdNodoDestDesc";
            ddlTransicionesDelUsuario.DataValueField = "IdNodoOrig_IdNodoDest";
            ddlTransicionesDelUsuario.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            ddlTransicionesDelUsuario.DataBind();
            ddlTransicionesDelUsuario.SelectedIndex = 0;
        }
        else
        {
            ddlTransicionesDelUsuario.Items.Add(new ListItem("El usuario NO tiene Actividades Asignadas", "0"));
            ddlTransicionesDelUsuario.SelectedValue = "0";
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    private void CargaActividadesPorAsignar()
    {
        string sNemoNodoOrig;
        string sNemoNodoDest;
        string ddlValue = ddlTransicionesDelUsuario.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = ddlValue.Split(delim);
        sNemoNodoOrig = strArr[0];
        sNemoNodoDest = strArr[1];

        ObjInstanciaNodo.iIdConexion = IdConexion;
        if (txtTramite.Text.ToString().Length > 0) ObjInstanciaNodo.iIdTramite = Convert.ToInt64(txtTramite.Text);
        else ObjInstanciaNodo.iIdTramite = 0;
        if (txtDateIni.Text.ToString().Length > 0) ObjInstanciaNodo.fFechaDesde = Convert.ToDateTime(txtDateIni.Text);
        else ObjInstanciaNodo.fFechaDesde = null;
        if (txtDateFin.Text.ToString().Length > 0) ObjInstanciaNodo.fFechaHasta = Convert.ToDateTime(txtDateFin.Text);
        else ObjInstanciaNodo.fFechaHasta = null;
        if (txtBeneficiario.Text.ToString().Length > 0) ObjInstanciaNodo.sNombreAsegurado = txtBeneficiario.Text;
        else ObjInstanciaNodo.sNombreAsegurado = null;
        ObjInstanciaNodo.sNemoNodoOrig = sNemoNodoOrig;
        ObjInstanciaNodo.sNemoNodoDest = sNemoNodoDest;
        if (sNemoNodoOrig != "0")
        {
            if (ObjInstanciaNodo.ObtieneActividadesParaAsignacion())
            {
                gvActividadesPorAsignar.DataSource = ObjInstanciaNodo.DSet.Tables[0];
                gvActividadesPorAsignar.DataBind();
            }
            else
            {
                //Error
                string DetalleError = ObjInstanciaNodo.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void gvActividadesPorAsignar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the DropDownList in the Row
            DropDownList ddlUsuarioAsignado = (e.Row.FindControl("ddlUsuarioAsignado") as DropDownList);

            //Select the Country of Customer in DropDownList
            string IdInstancia = (e.Row.FindControl("lblIdInstancia") as Label).Text;
            string Secuencia = (e.Row.FindControl("lblSecuencia") as Label).Text;
            //ddlUsuarioAsignado.Items.FindByValue(IdInstancia).Selected = true;

            ObjTransicionMasivaDet.iIdConexion = IdConexion;
            ObjTransicionMasivaDet.iSecuenciaEjecucion = Convert.ToInt32(Secuencia);
            ObjTransicionMasivaDet.iIdInstanciaEjecucion = Convert.ToInt32(IdInstancia);

            string aa = ddlTransicionesDelUsuario.SelectedValue.ToString();
            char[] delim = { '|' };
            string[] strArr = aa.Split(delim);
            ObjTransicionMasivaDet.sNemoNodoDest = strArr[1];

            if (ObjTransicionMasivaDet.ObtieneUsuariosConsulta())
            {
                //IdUsuario , CuentaUsuario , NombreCompleto
                ddlUsuarioAsignado.DataSource = ObjTransicionMasivaDet.DSet.Tables[0];
                ddlUsuarioAsignado.DataTextField = "CuentaUsuario";
                ddlUsuarioAsignado.DataValueField = "IdUsuario";
                ddlUsuarioAsignado.DataBind();
                ddlUsuarioAsignado.Items.Add(new ListItem("No Asignado", "0"));
                ddlUsuarioAsignado.SelectedValue = "0";
            }
            else
            {
                //Error
                string DetalleError = ObjTransicionMasivaDet.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void ddlTransicionesDelUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        CargaActividadesPorAsignar();
    }
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        string aa = ddlTransicionesDelUsuario.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = aa.Split(delim);
        string sNemoNodoDest = strArr[1];
        string sNemoNodoOrig = strArr[0];

        ObjCbteTrsldoDoc.iIdConexion = IdConexion;
        ObjCbteTrsldoDoc.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        ObjCbteTrsldoDoc.sNemoNodoOrig = sNemoNodoOrig;
        ObjCbteTrsldoDoc.sNemoNodoDest = sNemoNodoDest;
        ObjCbteTrsldoDoc.sComentarioGeneral = "";
        if (ObjCbteTrsldoDoc.Adicion2())
        {
            Session["iIdComprobante"] = ObjCbteTrsldoDoc.iIdComprobante;
            Session["iSesionTrabajo"] = null;
            //Response.Redirect("wfrmBandejaTramites.aspx");
            btnReporte430.Visible = true;
        }
        else
        {
            //Error
            string DetalleError = ObjCbteTrsldoDoc.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        btnGenerar.Visible = false;
    }
    protected void btnReporte430_Click(object sender, EventArgs e)
    {
        //Session["iIdComprobante"] = 4;
        Response.Redirect(@"~/Reportes/wfrmRptFormulario430.aspx");
    }
    protected void ddlUsuarioAsignado_SelectedIndexChanged(object sender, EventArgs e)
    {
        Master.MensajeCancel();

        btnGenerar.Enabled = false;

        DropDownList ddl = sender as DropDownList;
        foreach (GridViewRow row in gvActividadesPorAsignar.Rows)
        {
            Control ctrl = row.FindControl("ddlUsuarioAsignado") as DropDownList;
            if (ctrl != null)
            {
                DropDownList ddl1 = (DropDownList)ctrl;
                if (ddl.ClientID == ddl1.ClientID)
                {
                    //Get the button or DropDownList that raised the event
                    DropDownList ddlUsuarioAsignado = (DropDownList)sender;

                    //Get the row that contains this button
                    GridViewRow gvRow = (GridViewRow)ddlUsuarioAsignado.NamingContainer;

                    //Buscando Parametros
                    string IdInstancia = (gvRow.FindControl("lblIdInstancia") as Label).Text;
                    string Secuencia = (gvRow.FindControl("lblSecuencia") as Label).Text;
                    int IdUsuario = Convert.ToInt32(ddl1.SelectedValue);

                    ObjCbteTrsldoDocDetTmp.iIdConexion = IdConexion;
                    ObjCbteTrsldoDocDetTmp.iSesionTrabajo = Convert.ToInt32(Session["iSesionTrabajo"]);
                    ObjCbteTrsldoDocDetTmp.iIdInstancia = Convert.ToInt32(IdInstancia);
                    ObjCbteTrsldoDocDetTmp.iSecuencia = Convert.ToInt32(Secuencia);
                    ObjCbteTrsldoDocDetTmp.sComentario = "";
                    if (IdUsuario > 0)
                    {
                        ObjCbteTrsldoDocDetTmp.iIdUsuario = IdUsuario;
                        if (ObjCbteTrsldoDocDetTmp.Adicion())
                        {
                            Session["iSesionTrabajo"] = ObjCbteTrsldoDocDetTmp.iSesionTrabajo;
                        }
                        else
                        {
                            //Error
                            string DetalleError = ObjCbteTrsldoDocDetTmp.sMensajeError;
                            string Error = "Error al realizar la operación";
                            Master.MensajeError(Error, DetalleError);
                            break;
                        }
                        btnGenerar.Enabled = true;
                    }
                    else
                    {
                        if (!ObjCbteTrsldoDocDetTmp.Eliminacion())
                        {
                            //Error
                            string DetalleError = ObjCbteTrsldoDocDetTmp.sMensajeError;
                            string Error = "Error al realizar la operación";
                            Master.MensajeError(Error, DetalleError);
                            break;
                        }
                    }

                    //TextBox txt = row.FindControl("txtTest") as TextBox;
                    lblddl1.Text = ddlUsuarioAsignado.SelectedValue;
                    lblIdTramite.Visible = false;

                    lblTitAsigActiv.Text = "Actividades del Usuario <span class=highlight>" + ddl1.SelectedItem.ToString() + "</span>";
                    gvActividadesPorAsignar.SelectedIndex = row.RowIndex;

                    ddlTransicionesDelUsuario.Enabled = false;
                    break;
                }
            }
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        CargaActividadesPorAsignar();
    }
}