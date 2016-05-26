using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wcfWorkFlowN.Logica;

using System.Text;
using System.Security.Cryptography;
using System.IO;  

public partial class WorkFlow_wfrmGeneracionComprobantes : System.Web.UI.Page
{
    clsInstanciaNodo ObjInstanciaNodo = new clsInstanciaNodo();
    clsComprobanteTrasladoDocumentoDetTmp ObjCbteTrsldoDocDetTmp = new clsComprobanteTrasladoDocumentoDetTmp();
    clsComprobanteTrasladoDocumento ObjCbteTrsldoDoc = new clsComprobanteTrasladoDocumento();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;
    int iIdComprobante; long iIdInstancia; int iSecuencia;

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
            if (Request.QueryString["IdInstancia"] != null)
            {
                string ab1 = Request.QueryString["IdInstancia"];
                string ab2 = Request.QueryString["iSecuencia"];
                iIdInstancia = Convert.ToInt64(URLDecode(Request.QueryString["IdInstancia"]));
                iSecuencia = Convert.ToInt32(URLDecode(Request.QueryString["iSecuencia"]));
            }            
            CargarComboActividadesAceptarConCbte();
            CargaActividadesParaGeneracionCbte();
        }
    }
    private void CargarComboActividadesAceptarConCbte()
    {
        ObjInstanciaNodo.iIdConexion = IdConexion;
        if (iIdInstancia > 0)
        {
            ObjInstanciaNodo.iIdInstancia = iIdInstancia;
            ObjInstanciaNodo.iSecuencia = iSecuencia;
        }
        if (ObjInstanciaNodo.ObtieneTransicionesParaGeneracionDeCbte())
        {
            dllActividadesAceptarConCbte.DataTextField = "IdNodoOrigDesc_IdNodoDestDesc";
            dllActividadesAceptarConCbte.DataValueField = "IdNodoOrig_IdNodoDest";
            dllActividadesAceptarConCbte.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            dllActividadesAceptarConCbte.DataBind();

            //dllActividadesAceptarConCbte.SelectedIndex = 0;
            //dllActividadesAceptarConCbte.Items.Add(new ListItem("Todos (*)", "-1"));
            //dllActividadesAceptarConCbte.SelectedValue = "-1";
            
            //Finding the last option value from a DropDownList
            if (dllActividadesAceptarConCbte.Items.Count > 0)
            {
                string myValue = dllActividadesAceptarConCbte.Items[dllActividadesAceptarConCbte.Items.Count - 1].Value;
                dllActividadesAceptarConCbte.SelectedValue = myValue;
            }
        }
        else
        {
            dllActividadesAceptarConCbte.Items.Add(new ListItem("El usuario NO tiene Actividades Asignadas", "0"));
            dllActividadesAceptarConCbte.SelectedValue = "0";
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
            //btnAsignarActividades.Enabled = false;
        }
    }
    private void CargaActividadesParaGeneracionCbte()
    {
        string sNemoNodoOrig;
        string ddlValue = dllActividadesAceptarConCbte.SelectedValue.ToString();
        char[] delim = { '|' };
        string[] strArr = ddlValue.Split(delim);
        sNemoNodoOrig = strArr[0];

        if (sNemoNodoOrig == "-1") sNemoNodoOrig = null;

        ObjInstanciaNodo.iIdConexion = IdConexion;
        ObjInstanciaNodo.sNemoNodoOrig = sNemoNodoOrig;
        ObjInstanciaNodo.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        if (ObjInstanciaNodo.ObtieneActividadesParaGeneracionCbte())
        {
            gvActividadesParaGeneracionCbte.DataSource = ObjInstanciaNodo.DSet.Tables[0];
            gvActividadesParaGeneracionCbte.DataBind();
        }
        else
        {
            //Error
            string DetalleError = ObjInstanciaNodo.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
    }
    protected void dllActividadesAceptarConCbte_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaActividadesParaGeneracionCbte();
    }
    protected void gvActividadesParaGeneracionCbte_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "IMGProveido")
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            lblIdInstanciaPE.Text = gvActividadesParaGeneracionCbte.DataKeys[currentRowIndex].Value.ToString();
            lblSecuenciaPE.Text = gvActividadesParaGeneracionCbte.DataKeys[currentRowIndex]["Secuencia"].ToString();
            CheckBox chkActividadAux = (CheckBox)gvActividadesParaGeneracionCbte.Rows[currentRowIndex].FindControl("chkActividad");
            Label txtProveidoTransAux = (Label)gvActividadesParaGeneracionCbte.Rows[currentRowIndex].FindControl("lblProveidoE");
            txtProveidoTrans.Text = txtProveidoTransAux.Text;

            if (String.IsNullOrEmpty(txtProveidoTrans.Text) && chkActividadAux.Checked)
            {
                HFProveidoTrans.Value = "0";
            }
            else if (!String.IsNullOrEmpty(txtProveidoTrans.Text) && chkActividadAux.Checked)
            {
                HFProveidoTrans.Value = "1";
            }
            else
            {
                HFProveidoTrans.Value = "0";
            }

            HFchkActividadChecked.Value = "1";
            chkActividadAux.Checked = true;
            btnGenerar.Enabled = true;
            lblIndexPE.Text = currentRowIndex.ToString();
            
            string sNemoNodoOrig;
            string ddlValue = dllActividadesAceptarConCbte.SelectedValue.ToString();
            char[] delim = { '|' };
            string[] strArr = ddlValue.Split(delim);
            sNemoNodoOrig = strArr[0];

            lblNemoNodoOrigPE.Text = sNemoNodoOrig;

            lblIndexPE.Visible = false;
            lblIdInstanciaPE.Visible = false;
            lblSecuenciaPE.Visible = false;
            lblNemoNodoOrigPE.Visible = false;

            ModalPopupExtender1.Show();
        }
    }
    protected void gvActividadesParaGeneracionCbte_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string sIdInstancia = gvActividadesParaGeneracionCbte.DataKeys[e.Row.RowIndex].Value.ToString();
            string sSecuencia = gvActividadesParaGeneracionCbte.DataKeys[e.Row.RowIndex]["Secuencia"].ToString();
            string sIdTipoTramite = e.Row.Cells[4].Text; //IdTipoTramite
            string sIdTramite = e.Row.Cells[6].Text; //IdTramite
            if (iIdInstancia.ToString() == sIdInstancia & iSecuencia.ToString() == sSecuencia)
            {
                //e.Row.BackColor = System.Drawing.Color.RoyalBlue;
                //e.Row.ForeColor = System.Drawing.Color.White;
                //e.Row.BackColor = System.Drawing.Color.FromName("#6495ED");
                //e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
                //e.Row.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32("c6efce", 16));
                //e.Row.Cells[6].ForeColor = System.Drawing.Color.FromName("#6495ED");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[2].BackColor = System.Drawing.Color.RoyalBlue;
                e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[3].BackColor = System.Drawing.Color.RoyalBlue;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[6].BackColor = System.Drawing.Color.RoyalBlue;
            }
        }
    }
    protected void btnReporte430_Click(object sender, EventArgs e)
    {
        //Session["iIdComprobante"] = 4;
        Response.Redirect(@"~/Reportes/wfrmRptFormulario430.aspx");
    }
    protected void chkActividad_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cbx1 = (CheckBox)gvActividadesParaGeneracionCbte.Rows[index].FindControl("chkActividad");
        
        //here you can find your control and get value(Id).
        int currentRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chkActividadAux = (CheckBox)gvActividadesParaGeneracionCbte.Rows[currentRowIndex].FindControl("chkActividad");
        string IdInstancia = gvActividadesParaGeneracionCbte.DataKeys[currentRowIndex].Value.ToString();
        string Secuencia = gvActividadesParaGeneracionCbte.DataKeys[currentRowIndex]["Secuencia"].ToString();
        Label lblProveido = (Label)gvActividadesParaGeneracionCbte.Rows[currentRowIndex].FindControl("lblProveidoE");
        lblProveido.Text = "";

        ObjCbteTrsldoDocDetTmp.iIdConexion = IdConexion;
        ObjCbteTrsldoDocDetTmp.iSesionTrabajo = Convert.ToInt32(Session["iSesionTrabajo"]);
        ObjCbteTrsldoDocDetTmp.iIdInstancia = Convert.ToInt32(IdInstancia);
        ObjCbteTrsldoDocDetTmp.iSecuencia = Convert.ToInt32(Secuencia);
        ObjCbteTrsldoDocDetTmp.sComentario = "";
        if (chkActividadAux.Checked)
        {
            //Adicion
            if (ObjCbteTrsldoDocDetTmp.Adicion())
            {
                Session["iSesionTrabajo"] = ObjCbteTrsldoDocDetTmp.iSesionTrabajo;
                lblProveido.Text = "";
            }
            else
            {
                //Error
                string DetalleError = ObjCbteTrsldoDocDetTmp.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        else
        {
            //Eliminacion
            if (ObjCbteTrsldoDocDetTmp.Eliminacion())
            {
                lblProveido.Text = "";
            }
            else
            {
                //Error
                string DetalleError = ObjCbteTrsldoDocDetTmp.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);
            }
        }
        if (HFchkActividadChecked.Value == "1")
        {
            btnGenerar.Enabled = true;
        }
        else
        {
            btnGenerar.Enabled = false;
        }
    }
    protected void btnProveido_Click(object sender, EventArgs e)
    {
        ObjCbteTrsldoDocDetTmp.iIdConexion = IdConexion;
        ObjCbteTrsldoDocDetTmp.iSesionTrabajo = Convert.ToInt32(Session["iSesionTrabajo"]); 
        ObjCbteTrsldoDocDetTmp.iIdInstancia = Convert.ToInt32(lblIdInstanciaPE.Text);
        ObjCbteTrsldoDocDetTmp.iSecuencia = Convert.ToInt32(lblSecuenciaPE.Text);
        ObjCbteTrsldoDocDetTmp.sComentario = txtProveidoTrans.Text;
        if (HFProveidoTrans.Value == "1")
        {
            if (!ObjCbteTrsldoDocDetTmp.Modificacion())
            {
                //Error
                string DetalleError = ObjCbteTrsldoDocDetTmp.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        else //HFProveidoTrans.Value == "0"
        {
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
            }
        }

        int currentRowIndex = Int32.Parse(lblIndexPE.Text);
        Label txtProveidoTransGrid = (Label)gvActividadesParaGeneracionCbte.Rows[currentRowIndex].FindControl("lblProveidoE");
        txtProveidoTransGrid.Text = txtProveidoTrans.Text;
    }
    private string URLDecode(string cipherText)
    {
        string EncryptionKey = "53NA51R";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        ObjCbteTrsldoDoc.iIdConexion = IdConexion;
        ObjCbteTrsldoDoc.iSesionTrabajo = Convert.ToInt64(Session["iSesionTrabajo"]);
        ObjCbteTrsldoDoc.sComentarioGeneral = txtProveidoGeneral.Text;
        if (ObjCbteTrsldoDoc.Adicion())
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
    protected void btnCaqncelar_Click(object sender, EventArgs e)
    {
        Session["iSesionTrabajo"] = null;
        Response.Redirect("wfrmBandejaTramites.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        HFProveidoTrans.Value = "0";
    }
}