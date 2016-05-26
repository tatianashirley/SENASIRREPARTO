using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Org.BouncyCastle.Bcpg.OpenPgp;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;

public partial class WorkFlow_wfmConsultaAdmWF : System.Web.UI.Page
{
    private clsSeguridad objSeg = new clsSeguridad();
    private clsInstanciaNodo objInstNodo = new clsInstanciaNodo();
    private int _idConexion;
    private string _mensajeError;

    private static long _idInstancia = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            _idConexion = (int) Session["IdConexion"];
        }

        if (!Page.IsPostBack)
        {
            Master.btnCerrarSesion.CausesValidation = false;

            CargarCboOficina();
            CargarCboArea(0);
        }
    }

    #region CARGAR_DATOS

    private void LimpiarCampos()
    {
        cboOficina.SelectedIndex = 0;
        cboArea.SelectedIndex = 0;
        cboEstado.SelectedIndex = 0;

        txtFechaDesde.Text = "";
        txtFechaHasta.Text = "";
        txtUsuario.Text = "";
        txtUsuaReasignado.Text = "";

        ibtnImprimir.Enabled = false;   
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }   

    private void CargarCboOficina()
    {
        try
        {
            var objSeg = new clsSeguridad();
            cboOficina.Items.Clear();

            cboOficina.DataSource = objSeg.ListaOficinas();
            cboOficina.DataTextField = "Nombre";
            cboOficina.DataValueField = "IdOficina";
            cboOficina.DataBind();

            cboOficina.Items.Insert(0, new ListItem("Seleccionar todos ...", null));
            cboOficina.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al cargar el combo de las Oficinas", ex.Message);
        }
    }

    private void CargarCboArea(int pIdOficina)
    {
        try
        {
            cboArea.Items.Clear();

            var tb = objSeg.ListaArea(pIdOficina);

            if (tb != null && tb.Rows.Count > 0)
            {
                cboArea.DataSource = tb;
                cboArea.DataTextField = "Descripcion";
                cboArea.DataValueField = "IdArea";
                cboArea.DataBind();
            }

            cboArea.Items.Insert(0, new ListItem("Seleccionar todos ...", null));
            cboArea.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al cargar el combo de Área", ex.Message);
        }        
    }

    private void CargarGrillaConsulta()
    {
        try
        {
            var objUsua = new clsUsuario();
            var tbUsua = objUsua.ListaUsuarios(_idConexion, "Q", txtUsuario.Text, ref _mensajeError);
            if (tbUsua.Rows.Count > 0 && tbUsua != null)
            {
                var vIdUsuario = Convert.ToInt32(tbUsua.Rows[0]["IdUsuario"]);
                Session["UsuarioWF"] = tbUsua.Rows[0]["CuentaUsuario"].ToString();
                
                objInstNodo.iIdConexion = _idConexion;
                if (cboOficina.SelectedIndex > 0)
                {
                    objInstNodo.iIdOficina = Convert.ToInt32(cboOficina.SelectedValue);
                    Session["OficinaWF"] = cboOficina.SelectedItem;
                }
                else
                {
                    objInstNodo.iIdOficina = null;
                    Session["OficinaWF"] = null;
                }
                if (cboArea.SelectedIndex > 0)
                {
                    objInstNodo.iIdArea = Convert.ToInt32(cboArea.SelectedValue);
                    Session["AreaWF"] = cboArea.SelectedItem;
                }
                else
                {
                    objInstNodo.iIdArea = null;
                    Session["AreaWF"] = null;
                }
                objInstNodo.iIdUsuario = vIdUsuario;
                
                objInstNodo.sEstado = cboEstado.SelectedItem.Value;
                objInstNodo.fFechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
                objInstNodo.fFechaHasta = Convert.ToDateTime(txtFechaHasta.Text);

                Session["objNodoInsta"] = objInstNodo;

                if (objInstNodo.ObtieneTramitesXUsuario())
                {
                    var tb = objInstNodo.DSet.Tables[0];
                    if (tb.Rows.Count > 0 && tb != null)
                    {
                        gvConsultaAdm.DataSource = tb;
                        gvConsultaAdm.DataBind();
                    }
                    else
                    {
                        gvConsultaAdm.DataSource = null;
                        gvConsultaAdm.DataBind();

                        if (objInstNodo.iNivelError == 1)
                            Master.MensajeError("Se produjo un error en el cargado de la grilla",
                                objInstNodo.sMensajeError);
                    }
                }
            }
            else
            {
                Master.MensajeError("Se pordujo un error al recuperar el ID del Usuario ingresado", _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción!", ex.Message);
        }
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void cboOficina_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LimpiarMensajesMasterPage();
            if (cboOficina.SelectedIndex > 0)
            {
                CargarCboArea(Convert.ToInt32(cboOficina.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción en el cargado de la área según la oficina seleccionada", ex.Message + " - " + ex.StackTrace);
        }
    }

    protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        CargarGrillaConsulta();
        ibtnImprimir.Enabled = true;
    }

    protected void ibtnImprimir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/WorkFlow/wfrmRptConsultaAdmWF.aspx");
    }

    protected void ibtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {   
        LimpiarCampos();
    }

    protected void btnReasignacion_Click(object sender, EventArgs e)
    {

    }

    protected void gvConsultaAdm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvConsultaAdm.PageIndex = e.NewPageIndex;
        CargarGrillaConsulta();
    }
    
    #endregion
   
}

