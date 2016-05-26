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

public partial class WorkFlow_wfrmAsignacionTramitesPorUsuario : System.Web.UI.Page
{
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    clsTransicionMasivaDet ObjTransicionMasivaDet = new clsTransicionMasivaDet();
    clsTransicionMasiva ObjTransicionMasiva = new clsTransicionMasiva();
    clsHisTipoTramiteRolUsuario ObjHTipoTramRosUsr = new clsHisTipoTramiteRolUsuario();

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
            btnAsignarActividades.Enabled = true;
            Session["iIdTransicionMsva"] = null;
            CargaTransicionesDelUsuario();
            CargaActividadesPorAsignar();
            CargaUsuariosDisponibles();
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
            //btnAsignarActividades.Enabled = false;
        }
    }
    private void CargaActividadesPorAsignar()
    {
        string sNemoNodoOrig;
        string ddlValue = ddlTransicionesDelUsuario.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = ddlValue.Split(delim);
        sNemoNodoOrig = strArr[0];

        ObjTransicionMasivaDet.iIdConexion = IdConexion;
        ObjTransicionMasivaDet.sNemoNodoOrig = sNemoNodoOrig;
        if (Session["iIdTransicionMsva"] != null)
        {
            ObjTransicionMasivaDet.iIdTransicionMsva = Convert.ToInt32(Session["iIdTransicionMsva"]);
        }
        else
        {
            ObjTransicionMasivaDet.iIdTransicionMsva = 0;
        }

        if (sNemoNodoOrig != "0")
        {
            if (ObjTransicionMasivaDet.ObtieneActividadesDisponilesParaAsignacion())
            {
                gvActividadesPorAsignar.DataSource = ObjTransicionMasivaDet.DSet.Tables[0];
                gvActividadesPorAsignar.DataBind();
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
            string EstadoAsignacion = DataBinder.Eval(e.Row.DataItem, "EstadoAsignacion").ToString();
            if (EstadoAsignacion.Length > 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#BC8F8F");
                e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            }
        }
    }
    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)gvActividadesPorAsignar.HeaderRow.FindControl("chkboxSelectAll");
        foreach (GridViewRow row in gvActividadesPorAsignar.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkActividad");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }
    private void CargaUsuariosDisponibles()
    {
        ObjHTipoTramRosUsr.iIdConexion = IdConexion;            
        if (ObjHTipoTramRosUsr.ObtieneUsuariosSubordinados())
        {
            //IdUsuario , CuentaUsuario , NombreCompleto
            ddlUsuariosDisponibles.DataSource = ObjHTipoTramRosUsr.DSet.Tables[0];
            ddlUsuariosDisponibles.DataTextField = "CuentaUsuario";
            ddlUsuariosDisponibles.DataValueField = "IdUsuario";
            ddlUsuariosDisponibles.DataBind();
            ddlUsuariosDisponibles.Items.Add(new ListItem("No Asignado", "0"));
            ddlUsuariosDisponibles.SelectedValue = "0";
            btnAsignacionTemporal.Enabled = false;
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void CargaUsuariosDisponibles2()
    {
        ObjTransicionMasivaDet.iIdConexion = IdConexion;
        ObjTransicionMasivaDet.iSecuenciaEjecucion = 2;
        ObjTransicionMasivaDet.iIdInstanciaEjecucion = 8;

        string aa = ddlTransicionesDelUsuario.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = aa.Split(delim);
        ObjTransicionMasivaDet.sNemoNodoDest = strArr[1];

        if (ObjTransicionMasivaDet.ObtieneUsuarios())
        {
            //IdUsuario , CuentaUsuario , NombreCompleto
            ddlUsuariosDisponibles.DataSource = ObjTransicionMasivaDet.DSet.Tables[0];
            ddlUsuariosDisponibles.DataTextField = "CuentaUsuario";
            ddlUsuariosDisponibles.DataValueField = "IdUsuario";
            ddlUsuariosDisponibles.DataBind();
            ddlUsuariosDisponibles.Items.Add(new ListItem("No Asignado", "0"));
            ddlUsuariosDisponibles.SelectedValue = "0";
            btnAsignacionTemporal.Enabled = false;
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void CargarGrillaActividadesUsuario(int iIdUsuario, int iIdTransicionMsva)
    {
        ObjTransicionMasivaDet.iIdConexion = IdConexion;
        ObjTransicionMasivaDet.iIdUsuario = iIdUsuario;
        ObjTransicionMasivaDet.iIdTransicionMsva = iIdTransicionMsva;
        if (ObjTransicionMasivaDet.ObtieneActividadesPendientesXUsuario())
        {
            gvActivUsuario.DataSource = ObjTransicionMasivaDet.DSet.Tables[0].Copy();
        }
        else
        {
            //Error
            string DetalleError = ObjTransicionMasivaDet.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
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
            if (IdInstancia==0)
            {
                e.Row.BackColor = System.Drawing.Color.RoyalBlue;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
        }
    }
    protected void gvActivUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvActivUsuario.PageIndex = e.NewPageIndex;
    }
    protected void ddlUsuariosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUsuariosDisponibles.SelectedValue != "0")
        {
            if (Session["iIdTransicionMsva"] != null)
            {
                CargarGrillaActividadesUsuario(Convert.ToInt32(ddlUsuariosDisponibles.SelectedValue), Convert.ToInt32(Session["iIdTransicionMsva"]));
            }
            else
            {
                CargarGrillaActividadesUsuario(Convert.ToInt32(ddlUsuariosDisponibles.SelectedValue), 0);
            }
            lblTitAsigActiv.Text = "Actividades del Usuario <span class=highlight>" + ddlUsuariosDisponibles.SelectedItem.ToString() + "</span>";
            lblTitAsigActiv.Visible = true;
            btnAsignacionTemporal.Enabled = true;
        }
        else
        {
            gvActivUsuario.DataBind();
            lblTitAsigActiv.Visible = false;
            btnAsignacionTemporal.Enabled = false;
        }
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
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
    protected void btnAsignacionTemporal_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("IdInstancia"), new DataColumn("Secuencia") });
        foreach (GridViewRow row in gvActividadesPorAsignar.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkActividad") as CheckBox);
                if (chkRow.Checked)
                {
                    string IdInstancia = (row.Cells[2].FindControl("lblIdInstancia") as Label).Text;
                    string Secuencia = (row.Cells[3].FindControl("lblSecuencia") as Label).Text;
                    dt.Rows.Add(IdInstancia, Secuencia);
                }
            }
        }
        //gvSelected.DataSource = dt;
        //gvSelected.DataBind();

        string aa = ddlTransicionesDelUsuario.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = aa.Split(delim);
        //strArr[1];

        string vIdInstancia, vSecuencia;
        int IdUsuario = Convert.ToInt32(ddlUsuariosDisponibles.SelectedValue);
        foreach (DataRow fila in dt.Rows)
        {
            vIdInstancia = fila["IdInstancia"].ToString();
            vSecuencia = fila["Secuencia"].ToString();
            //CargaTemporalDeActividadUsuario(Convert.ToInt32(vIdInstancia), Convert.ToInt32(vSecuencia), IdUsuario);
            ObjTransicionMasivaDet.AdicionItemLista(0, Convert.ToInt32(vIdInstancia), Convert.ToInt32(vSecuencia), Convert.ToInt32(ddlUsuariosDisponibles.SelectedValue), strArr[0], strArr[1]);
        }
        DataTable dtActividadesPorAsignar = new DataTable();

        ObjTransicionMasivaDet.iIdConexion = IdConexion;
        ObjTransicionMasivaDet.sNemoNodoOrig = strArr[0];
        ObjTransicionMasivaDet.iIdTransicionMsva = Convert.ToInt32(Session["iIdTransicionMsva"]);
        if (ObjTransicionMasivaDet.AdicionLote())
        {
            if (ObjTransicionMasivaDet.DSet != null)
            {
                dtActividadesPorAsignar = ObjTransicionMasivaDet.DSet.Tables[0].Copy();
                gvActividadesPorAsignar.DataSource = dtActividadesPorAsignar;                
            }
            if (ObjTransicionMasivaDet.iIdTransicionMsva != 0)
            {
                Session["iIdTransicionMsva"] = ObjTransicionMasivaDet.iIdTransicionMsva;
            }
        }
        else
        {
            //Error
            string DetalleError = ObjTransicionMasivaDet.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        gvActividadesPorAsignar.DataBind();
        CargarGrillaActividadesUsuario(Convert.ToInt32(ddlUsuariosDisponibles.SelectedValue), Convert.ToInt32(Session["iIdTransicionMsva"]));
        //CargaActividadesPorAsignar();
        ddlTransicionesDelUsuario.Enabled = false;
        btnAsignarActividades.Enabled = true;
    }

    private void CargaTemporalDeActividadUsuario(int IdInstancia, int Secuencia, int IdUsuario)
    {
        //Buscando Parametros
        string sNemoNodoOrig; string sNemoNodoDest;
        string ddlValue = ddlTransicionesDelUsuario.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = ddlValue.Split(delim);
        sNemoNodoOrig = strArr[0];
        sNemoNodoDest = strArr[1];

        //:..
        //Registro temporal de asignación de actividad a usuario específico
        ObjTransicionMasivaDet.iIdConexion = IdConexion;
        ObjTransicionMasivaDet.iIdInstanciaEjecucion = IdInstancia;
        ObjTransicionMasivaDet.iSecuenciaEjecucion = Secuencia;
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
                //CargarGrillaActividadesUsuario(IdUsuario, Convert.ToInt32(Session["iIdTransicionMsva"]));
            }
            else
            {
                //Error
                string DetalleError = ObjTransicionMasivaDet.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
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
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
}