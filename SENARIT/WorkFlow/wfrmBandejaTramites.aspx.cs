using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;

using System.Text;
using System.Security.Cryptography;
using System.IO;  

public partial class WorkFlow_wfrmBandejaTramites : System.Web.UI.Page
{
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    clsSeguridad objSeguridad = new clsSeguridad();

    clsSolicitudTramite objSolTram = new clsSolicitudTramite();

    int IdConexion; int IdUsuario, IdOficina, IdArea; string CuentaUsuario; int IdRol;
    string instancia, secuencia;
    long IdTramite;

    private static long _idInstancia = 0;

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

            string s01 = Session["CuentaUsuario"].ToString();
            string s02 = Session["CodUsuario"].ToString();
            DataTable dtUsuarioDatos = objSeguridad.ListaDatosConexion(IdConexion);
            if (dtUsuarioDatos.Rows.Count > 0)
            {
                string s10 = dtUsuarioDatos.Rows[0]["IdUsuario"].ToString(); //2941
                string s11 = dtUsuarioDatos.Rows[0]["CuentaUsuario"].ToString();  //TECENVIOS2
                string s12 = dtUsuarioDatos.Rows[0]["IdRol"].ToString();    //107
                string s13 = dtUsuarioDatos.Rows[0]["Rol"].ToString();    //Técnico de Procesamiento CC y Envío APS
                string s14 = dtUsuarioDatos.Rows[0]["IdOficina"].ToString();    //2
                string s15 = dtUsuarioDatos.Rows[0]["Oficina"].ToString();  //LA PAZ
                string s16 = dtUsuarioDatos.Rows[0]["IdArea"].ToString();  //240
                string s17 = dtUsuarioDatos.Rows[0]["Area"].ToString(); //Envíos APS
                string s18 = dtUsuarioDatos.Rows[0]["FecHoraString"].ToString();    //29/05/2015  9:15AM
                string s19 = dtUsuarioDatos.Rows[0]["IdTipoUsuario"].ToString();    //677

                IdUsuario = Int32.Parse(s10);
                IdOficina = Int32.Parse(s14);
                IdArea = Int32.Parse(s16);
            }
            else
            {
                Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
                return;
            }
        }

        if (!Page.IsPostBack)
        {
            CargarGrillaTramites(-1);
            pnlHistorialTramites.Visible = false;
        }
    }

    private void CargarGrillaTramites(short IdNodo)
    {
        if (txtTramite.Text.ToString().Length > 0) ObjInstanciaNodo.iIdTramite = Convert.ToInt64(txtTramite.Text);
        else ObjInstanciaNodo.iIdTramite = 0;
        if (txtDateIni.Text.ToString().Length > 0) ObjInstanciaNodo.fFechaDesde = Convert.ToDateTime(txtDateIni.Text);
        else ObjInstanciaNodo.fFechaDesde = null;
        if (txtDateFin.Text.ToString().Length > 0) ObjInstanciaNodo.fFechaHasta = Convert.ToDateTime(txtDateFin.Text);
        else ObjInstanciaNodo.fFechaHasta = null;
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.sNombreAsegurado = txtBeneficiario.Text;
        ObjInstanciaNodo.iIdUsuario = IdUsuario;
        ObjInstanciaNodo.iIdOficina = IdOficina;
        ObjInstanciaNodo.iIdArea = IdArea;
        ObjInstanciaNodo.iIdNodo = IdNodo;
        if (ObjInstanciaNodo.ObtieneActividadesXUsuario())
        {
            gvTramite.DataSource = ObjInstanciaNodo.DSet.Tables[0];

            ddlFiltroActividades.DataTextField = "Descripcion";
            ddlFiltroActividades.DataValueField = "IdNodo";
            ddlFiltroActividades.DataSource = ObjInstanciaNodo.DSet.Tables[1];
            ddlFiltroActividades.DataBind();
            //Finding the last option value from a DropDownList
            if (ddlFiltroActividades.Items.Count > 0)
            {
                string myValue = ddlFiltroActividades.Items[ddlFiltroActividades.Items.Count - 1].Value;
                ddlFiltroActividades.SelectedValue = myValue;
                //ddlFiltroActividades.Items.Clear();
                ddlFiltroActividades.Items.Add(new ListItem("Todos (*)", "-1"));
                ddlFiltroActividades.SelectedValue = IdNodo.ToString();
            }
            else
            {
                //ddlFiltroActividades.Items.Clear();
                ddlFiltroActividades.Items.Add(new ListItem("No Existen Actividades", "-2"));
                ddlFiltroActividades.SelectedValue = IdNodo.ToString();
            }
        }
        else
        {
            //Error
            if (ObjInstanciaNodo.iNivelError != 2)
            {
                string DetalleError = ObjInstanciaNodo.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
                return;
            }
            else
            {
                if (ddlFiltroActividades.Items.Count == 0)
                {
                    //ddlFiltroActividades.Items.Clear();
                    ddlFiltroActividades.Items.Add(new ListItem("Bandeja VACIA, no existen Trámites asignados", "-2"));
                    ddlFiltroActividades.SelectedValue = IdNodo.ToString();
                }
            }
        }
        gvTramite.DataBind();
    }
    protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    {
        CargarGrillaTramites(Int16.Parse(ddlFiltroActividades.SelectedValue));
    }

    protected void gvTramite_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string currentCommand = e.CommandName;
        int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
        string instancia = gvTramite.DataKeys[currentRowIndex].Value.ToString();
        string secuencia = gvTramite.DataKeys[currentRowIndex]["Secuencia"].ToString();

        int index = Convert.ToInt32(e.CommandArgument.ToString());

        if (e.CommandName == "Historial") //Historial de Tramite
        {
            gvTramite.SelectedIndex = index;
            
            pnlHistorialTramites.Visible = true;
            lblHIdTramite.Text = gvTramite.DataKeys[currentRowIndex]["IdTramite"].ToString();
            lblHIdGrupoBeneficio.Text = gvTramite.DataKeys[currentRowIndex]["IdGrupoBeneficio"].ToString();
            _idInstancia = Int64.Parse(gvTramite.DataKeys[currentRowIndex]["IdInstancia"].ToString());
            CargarGrillaBusquedaMaestra(Int64.Parse(lblHIdTramite.Text), Int32.Parse(lblHIdGrupoBeneficio.Text));
        }
        if (e.CommandName == "cmdAsignar") //Genera Comprobante
        {
            Boolean bFlagArchivo = bool.Parse(gvTramite.DataKeys[currentRowIndex]["FlagArchivo"].ToString());

            if (bFlagArchivo)
            {
                Response.Redirect("~/WorkFlow/wfrmAsignacionTramitesEnLoteDArchivo.aspx");
            }
            else
            {
                Response.Redirect("~/WorkFlow/wfrmAsignacionTramitesEnLote.aspx");
                //Response.Redirect("~/WorkFlow/wfrmAsignacionTramitesPorUsuario.aspx");
            }
        }
        if (e.CommandName == "cmdGenera") //Genera Comprobante
        {
            string eIdInstancia = URLEncode(instancia);
            string eSecuencia = URLEncode(secuencia);
            Response.Redirect("~/WorkFlow/wfrmGeneracionComprobantes.aspx?IdInstancia=" + eIdInstancia + "&iSecuencia=" + eSecuencia);
        }
        if (e.CommandName == "cmdComprobante") //Aceptar Comprobante
        {
            Response.Redirect("~/WorkFlow/wfrmActividadesConCbte.aspx");
        }
        if (e.CommandName == "cmdActividades") //Ejecutar Actividad 
        {
            Response.Redirect("wfrmEjecucionActividades.aspx?inst=" + instancia + "&sec=" + secuencia);
        }
    }
    protected void gvTramite_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Check if the row that is being bound, is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string EstadoCod = DataBinder.Eval(e.Row.DataItem, "EstadoCod").ToString();
            ImageButton ImageButton4 = (ImageButton)e.Row.FindControl("ImageButton4"); //Asignar Actividades
            ImageButton ImageButton3 = (ImageButton)e.Row.FindControl("ImageButton3"); //Genera Comprobante
            ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("ImageButton1"); //Aceptar Comprobante
            ImageButton ImageButton2 = (ImageButton)e.Row.FindControl("ImageButton2"); //Ejecutar Actividad            
            ImageButton4.Visible = false;
            ImageButton3.Visible = false;
            ImageButton1.Visible = false;
            ImageButton2.Visible = false;

            if (EstadoCod == "A") //Asignar Actividades
            {
                ImageButton4.Visible = true;
            }
            if (EstadoCod == "G") //Genera Comprobante
            {
                ImageButton3.Visible = true;
            }
            if (EstadoCod == "W") //Aceptar Comprobante
            {
                ImageButton1.Visible = true;
            }
            if (EstadoCod == "I") //Ejecutar Actividad
            {
                ImageButton2.Visible = true;
            }
        }
    }

    protected void gvTramite_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTramite.PageIndex = e.NewPageIndex;
        CargarGrillaTramites(-1);
    }
    protected void ddlFiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarGrillaTramites(Int16.Parse(ddlFiltroActividades.SelectedValue));
    }
    private string URLEncode(string clearText)
    {
        string EncryptionKey = "53NA51R";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    #region HistorialTramite
    //---------------------------------------
    private void CargarGrillaBusquedaMaestra(long IdTramite,int IdGrupoBeneficio)
    {
        objSolTram.iIdConexion = IdConexion;
        objSolTram.sNombres = null;
        objSolTram.sApellidoPaterno = null;
        objSolTram.sApellidoMaterno = null;
        objSolTram.sNumeroDocumento = null;
        objSolTram.iIdTramite = IdTramite; 
        if (objSolTram.Busqueda())
        {
            var dt = objSolTram.DSet.Tables[0];
            gvBusqMaestro.DataSource = dt;
            gvBusqMaestro.DataBind();

            CargarGrillaDetalle(_idInstancia);
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla la busqueda", objSolTram.sMensajeError);
            gvBusqMaestro.DataSource = null;
            gvBusqMaestro.DataBind();
        }
    }
    private void CargarGrillaDetalle(long pInstancia)
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.iIdInstancia = pInstancia;

        if (ObjInstanciaNodo.ObtieneHistorialEjecucion())
        {
            gvDetalle.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            gvDetalle.DataBind();
        }
        else
        {
            Master.MensajeError("Se produjo un error al cargar la grilla de historial", objSolTram.sMensajeError);
            gvDetalle.DataSource = null;
            gvDetalle.DataBind();
        }
    }
    protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDetalle.PageIndex = e.NewPageIndex;
            CargarGrillaDetalle(_idInstancia);
        }
        catch (Exception Ex)
        {
            Master.MensajeError("Se produjo un error al recorrer la grilla de Historial", Ex.Message);
        }
    }
    #endregion
}