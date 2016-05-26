using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfNotificacion.Logica;

public partial class Notificaciones_wfrmDevoluciones : System.Web.UI.Page
{
    clsDevolucion Documento = new clsDevolucion();
    string mensaje = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        if (!Page.IsPostBack)
        {
            HttpContext.Current.Server.ScriptTimeout = 2400;
            grillaDevolucion();
        }
    }
    protected void grillaDevolucion() //Devolver J
    {
        try
        {
            gvDatos.Visible = true;
            gvDatos.DataSource = Documento.ObtieneDatos((int)Session["IdConexion"], "J", ref mensaje);
            gvDatos.DataBind();
            if (gvDatos.DataSource != null)
            imgbtnRecepcionar.Visible = true;
            else
                imgbtnRecepcionar.Visible = false;
        }
        catch 
        {
            Master.MensajeError("Error al realizar la Operación", mensaje);
        }
        
    }
    protected void imgbtnRecepcionar_Click(object sender, ImageClickEventArgs e)
    {
        pnlREcepcion_ModalPopupExtender.Show();
    }
    protected void btnAccionarRecepcion_Click(object sender, EventArgs e)
    {
        Int64 tram;
        Int32 idGBene;
        string fechDoc;
        Int32 nroDoc;
        Int32 idDoc;
        foreach (GridViewRow row in gvDatos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                //CheckBox chkRol = (row.Cells[9].FindControl("chkRol") as CheckBox);
                //CheckBox check = (CheckBox)row.Cells["prueba"].FindControl("chkRol");
                CheckBox chk_Publicar = (CheckBox)row.Cells[7].FindControl("chkRecepcion");
                if (chk_Publicar.Checked)
                {
                    // en lugar de val guardar registro
                    //int IdRol = Convert.ToInt32(row.Cells[1].Text);
                    tram = Convert.ToInt64(gvDatos.DataKeys[row.RowIndex].Values["IdTramite"].ToString());
                    idGBene = Convert.ToInt32(gvDatos.DataKeys[row.RowIndex].Values["IdGrupoBeneficio"].ToString());
                    fechDoc = gvDatos.DataKeys[row.RowIndex].Values["FechaDocumento"].ToString();
                    nroDoc = Convert.ToInt32(gvDatos.DataKeys[row.RowIndex].Values["NroDocumento"].ToString());
                    idDoc = Convert.ToInt32(gvDatos.DataKeys[row.RowIndex].Values["IdDocumento"].ToString());
                    //Devolucion O
                    if (Documento.RegistraDevolucion((int)Session["IdConexion"], "P", tram, idGBene, idDoc, fechDoc, nroDoc, txtCiteDev.Text, txtFEchaCiteDev.Text, txtFechaDevolucion.Text,txtObsEnv.Text, ref mensaje))
                    {
                        Master.MensajeOk("Se realizo con exito la operacion");
                    }
                    else 
                    {
                        Master.MensajeError("Error al realizar la Operación", mensaje);
                    }
                }
            }
        }
        grillaDevolucion();

    }
    protected void lnkmas_Click(object sender, System.EventArgs e)
    {
        if (lnkmas.Text == "ULTIMOS DOCUMENTOS DEVUELTOS")
        {
            try
            {
                gvDatos.Visible = false;
                lblDev.Visible = false;
                imgbtnRecepcionar.Visible = false;
                gvDevolucion.Visible = true;
                gvDevolucion.DataSource = Documento.DocsUltimosDevueltos((int)Session["IdConexion"], "K", ref mensaje);
                gvDevolucion.DataBind();
                lnkmas.Text = "VOLVER ATRAS";
            }
            catch
            {
                Master.MensajeError("Error al realizar la operacion", mensaje);
            }
        }
        else
        {
            gvDevolucion.Visible = false;
            lblDev.Visible = true;
            grillaDevolucion();
            lnkmas.Text = "ULTIMOS DOCUMENTOS DEVUELTOS";
        }
    }
}