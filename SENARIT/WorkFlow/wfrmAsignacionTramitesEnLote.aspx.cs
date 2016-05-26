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

public partial class WorkFlow_wfrmAsignacionTramitesEnLote : System.Web.UI.Page
{
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    clsTransicionMasivaDet ObjTransicionMasivaDet = new clsTransicionMasivaDet();
    clsTransicionMasiva ObjTransicionMasiva = new clsTransicionMasiva();

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
            btnAsignarActividades.Enabled = false;
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
    protected void gvActividadesPorAsignar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gvActividadesPorAsignar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
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

            if (ObjTransicionMasivaDet.ObtieneUsuarios())
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
        CargaActividadesPorAsignar();
        CargaTransicionesDelUsuario();
    }
    protected void btnAsignarActividades_Click(object sender, EventArgs e)
    {
        //Procesa Asignaciones
        ObjTransicionMasiva.iIdConexion = IdConexion;
        ObjTransicionMasiva.iIdTransicionMsva = Convert.ToInt32(Session["iIdTransicionMsva"]);

        if (!ObjTransicionMasiva.ProcesaAsignacion())
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        Session["iIdTransicionMsva"] = null;

        ddlTransicionesDelUsuario.Enabled = true;
        //pnlAsignacionActividades.Visible = false;

        //CargaTransicionesDelUsuario();
        //CargaActividadesPorAsignar();
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
    protected void ddlUsuarioAsignado_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAsignarActividades.Enabled = false;

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

                    string sNemoNodoOrig; string sNemoNodoDest;
                    string ddlValue = ddlTransicionesDelUsuario.SelectedValue.ToString();
                    char[] delim = { '|' };
                    string[] strArr = ddlValue.Split(delim);
                    sNemoNodoOrig = strArr[0];
                    sNemoNodoDest = strArr[1];

                    //:..
                    //Registro temporal de asignación de actividad a usuario específico
                    ObjTransicionMasivaDet.iIdConexion = IdConexion;
                    ObjTransicionMasivaDet.iIdInstanciaEjecucion = Convert.ToInt32(IdInstancia);
                    ObjTransicionMasivaDet.iSecuenciaEjecucion = Convert.ToInt32(Secuencia);
                    ObjTransicionMasivaDet.iIdUsuario = IdUsuario;
                    ObjTransicionMasivaDet.sNemoNodoOrig = sNemoNodoOrig;
                    ObjTransicionMasivaDet.sNemoNodoDest = sNemoNodoDest;
                    if (Session["iIdTransicionMsva"] != null)
                    {
                        ObjTransicionMasivaDet.iIdTransicionMsva = Convert.ToInt32(Session["iIdTransicionMsva"]);
                    }

                    if (IdUsuario > 0)
                    {
                        if (ObjTransicionMasivaDet.Adicion())
                        {
                            if (ObjTransicionMasivaDet.iIdTransicionMsva != 0)
                            {
                                Session["iIdTransicionMsva"] = ObjTransicionMasivaDet.iIdTransicionMsva;
                            }
                            //pnlAsignacionActividades.Visible = true;
                            CargarGrillaActividadesUsuario(IdUsuario, Convert.ToInt32(Session["iIdTransicionMsva"]));
                        }
                        else
                        {
                            //Error
                            string DetalleError = ObjTransicionMasivaDet.sMensajeError;
                            string Error = "Error al realizar la operación";
                            Master.MensajeError(Error, DetalleError);
                            return;
                        }
                    }
                    else //IdUsuario==0
                    {
                        if (ObjTransicionMasivaDet.Eliminacion())
                        {
                            //pnlAsignacionActividades.Visible = false;
                        }
                        else
                        {
                            //Error
                            string DetalleError = ObjTransicionMasivaDet.sMensajeError;
                            string Error = "Error al realizar la operación";
                            Master.MensajeError(Error, DetalleError);
                        }
                    }

                    //TextBox txt = row.FindControl("txtTest") as TextBox;
                    lblddl1.Text = ddlUsuarioAsignado.SelectedValue;
                    lblIdTrans.Text = "-->" + Session["iIdTransicionMsva"].ToString();
                    lblIdTramite.Visible = false;

                    lblTitAsigActiv.Text = "Actividades del Usuario <span class=highlight>" + ddl1.SelectedItem.ToString() + "</span>";
                    gvActividadesPorAsignar.SelectedIndex = row.RowIndex;

                    ddlTransicionesDelUsuario.Enabled = false;
                    break;
                }
            }
        }
        btnAsignarActividades.Enabled = true;
    }

    // LLENA  DATOS DE LOS TRAMITES EN LA GRILA
    private void CargarGrillaActividadesUsuario(int iIdUsuario, int iIdTransicionMsva)
    {
        ObjTransicionMasivaDet.iIdConexion = IdConexion;
        ObjTransicionMasivaDet.iIdUsuario = iIdUsuario;
        ObjTransicionMasivaDet.iIdTransicionMsva = iIdTransicionMsva;
        if (ObjTransicionMasivaDet.ObtieneActividadesPendientesXUsuario())
        {
            gvActivUsuario.DataSource = ObjTransicionMasivaDet.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = ObjTransicionMasivaDet.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        gvActivUsuario.DataBind();
    }
    protected void gvActivUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void gvActivUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int IdInstancia = Convert.ToInt32
                (DataBinder.Eval(e.Row.DataItem, "IdInstancia"));
            if (IdInstancia == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#6495ED");
                e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }
    }
    protected void gvActivUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvActivUsuario.PageIndex = e.NewPageIndex;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
}