using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using wcfEnvioAPS.Logica;

using wcfServicioIntercambioPago.Logica;
using System.IO;

using System.Globalization;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;

public partial class EnvioAPS_wfrmGeneracionDeMedios : System.Web.UI.Page
{
    clsManejoArchivo objManejoArchivo = new clsManejoArchivo();
    clsSeguridadCliente objSeguridadCliente = new clsSeguridadCliente();

    clsGeneraBandejas objGeneraBandejas = new clsGeneraBandejas();
    clsGeneraEnvios objGeneraEnvios = new clsGeneraEnvios();
    clsGeneraMedios objGeneraMedios = new clsGeneraMedios();
    clsContrlEnvios objContrlEnvios = new clsContrlEnvios();

    int IdConexion; int IdUsuario; string CuentaUsuario; int IdRol;

    string sMensajeError = null;
    string NumeroEnvioDetalleEnvioAPS;

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
            //IdConexion = 5679;
        }

        if (!Page.IsPostBack)
        {
            txtFechaCorte.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);    //formato español      
            //Llena_gvPreliminarEnvios(txtFechaCorte.Text, 1);
            btnGeneraEnvio.Enabled = false;
            ActualizaRAyFecha();
            //..::workflow::..
            Show_btnRemiteAltas();
        }

        //BEGIN gvPreliminarEnvios_CheckUpdate
        ArrayList CheckBoxArray;
        if (ViewState["CheckBoxArray"] != null)
        {
            CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
        }
        else
        {
            CheckBoxArray = new ArrayList();
        }

        if (IsPostBack && pnlGrid2.Visible && HFbandejaEnvios.Value == "1" && Convert.ToInt16(lblRecordCount.Text)>0)
        {
            int pageIndex = int.Parse(ViewState["pageIndex"].ToString());
            int CheckBoxIndex;
            bool CheckAllWasChecked = false;
            CheckBox chkAll = (CheckBox)gvPreliminarEnvios.HeaderRow.Cells[0].FindControl("chkAll");
            //string checkAllIndex = "chkAll-" + gvPreliminarEnvios.PageIndex;
            string checkAllIndex = "chkAll-" + pageIndex;
            if (chkAll.Checked)
            {
                if (CheckBoxArray.IndexOf(checkAllIndex) == -1)
                {
                    CheckBoxArray.Add(checkAllIndex);
                }
            }
            else
            {
                if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                {
                    CheckBoxArray.Remove(checkAllIndex);
                    CheckAllWasChecked = true;
                }
            }
            for (int i = 0; i < gvPreliminarEnvios.Rows.Count; i++)
            {
                if (gvPreliminarEnvios.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)gvPreliminarEnvios.Rows[i].Cells[0].FindControl("chkPE");
                    //CheckBoxIndex = gvPreliminarEnvios.PageSize * gvPreliminarEnvios.PageIndex + (i + 1);
                    CheckBoxIndex = gvPreliminarEnvios.PageSize * pageIndex + (i + 1);
                    if (chk.Checked)
                    {
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1 && !CheckAllWasChecked)
                        {
                            CheckBoxArray.Add(CheckBoxIndex);
                        }
                    }
                    else
                    {
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1 || CheckAllWasChecked)
                        {
                            CheckBoxArray.Remove(CheckBoxIndex);
                        }
                    }
                }
            }
        }
        ViewState["CheckBoxArray"] = CheckBoxArray;
        //END gvPreliminarEnvios_CheckUpdate
    }
    protected void Carga_gvEnvios()
    {
        if (String.IsNullOrEmpty(NumeroEnvioDetalleEnvioAPS) == true)
            NumeroEnvioDetalleEnvioAPS = "x";

        DataSet dsEnvios = new DataSet();
        objContrlEnvios.iIdConexion = IdConexion;
        objContrlEnvios.sNumeroEnvio = NumeroEnvioDetalleEnvioAPS;
        if (objContrlEnvios.SelectEnvioDetalleAPS())
        {
            dsEnvios = objContrlEnvios.DSet;
        }
        else
        {
            //Error
            string DetalleError = objContrlEnvios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        gvEnvios.DataSource = dsEnvios.Tables[0];
        gvEnvios.DataBind();
    }
    protected void Carga_gvDetalleEnvioAPS(string NumeroEnvioSelected)
    {
        if (String.IsNullOrEmpty(NumeroEnvioSelected) == true)
            NumeroEnvioSelected = "x";

        DataSet dsEnvios = new DataSet();
        objContrlEnvios.iIdConexion = IdConexion;
        objContrlEnvios.sNumeroEnvio = NumeroEnvioSelected;
        if (objContrlEnvios.SelectEnvioDetalleAPS())
        {
            dsEnvios = objContrlEnvios.DSet;
        }
        else
        {
            //Error
            string DetalleError = objContrlEnvios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        
        gvDetalleEnvioAPS.DataSource = dsEnvios.Tables[1];
        gvDetalleEnvioAPS.DataBind();
    }
    protected void btnBandejaEnvios_Click(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        pnlGrid1.Visible = true;
        pnlGrid2.Visible = false;
        Carga_gvEnvios();
        btnGeneraEnvio.Enabled = false;
    }
    protected void btnBandejaPreliminar_Click(object sender, EventArgs e)
    {
        Master.MensajeCancel();
        pnlGrid1.Visible = false;
        pnlGrid2.Visible = true;
        lblTitBandejaPreliminares.Text = "Bandeja Preliminares (" + ddnClaseEnvio.SelectedItem.Text + ")";
        Llena_gvPreliminarEnvios(ddnClaseEnvio.SelectedValue, txtFechaCorte.Text, 1);
    }
    protected void btnGeneraEnvio_Click(object sender, EventArgs e)
    {
        pnlGrid1.Visible = false;
        pnlGrid2.Visible = false;

        //Obteniendo los certificados seleccionados
        string LoteCertificados="";
        foreach (GridViewRow row in gvPreliminarEnvios.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkPE") as CheckBox);
                if (chkRow.Checked)
                {
                    string NroCertificado = row.Cells[7].Text;
                    //string IdTramite = row.Cells[3].Text;
                    string Clase_CC = row.Cells[9].Text; //Manual - Automatico
                    string IdTipoTramite = Clase_CC.Substring(0, 1); ; //M - A
                    string IdActualizacion = "";//IdActualizacion de Novedades
                    //if (IdTipoCC == "MENSUAL") IdTipoCC = "M";
                    //else IdTipoCC = "G";
                    //string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                    switch (ddnClaseEnvio.SelectedItem.Value)
                    {
                        case "A":
                            LoteCertificados = LoteCertificados + NroCertificado + "," + IdTipoTramite + "|";
                            break;
                        case "M":
                            IdActualizacion = row.Cells[26].Text;//IdActualizacion de Novedades
                            LoteCertificados = LoteCertificados + IdActualizacion + "|";
                            break;
                        case "B":
                            LoteCertificados = LoteCertificados + NroCertificado + "," + IdTipoTramite + "|";
                            //IdActualizacion = row.Cells[25].Text;//IdActualizacion de Novedades
                            //LoteCertificados = LoteCertificados + IdActualizacion + "|";
                            break;
                        default:
                            Master.MensajeWarning("Opcion no encontrada al Generar Envios!!");
                            break;
                    }
                }
            }
        }

        if (ddnClaseEnvio.SelectedValue == "A" & LoteCertificados.Length>0)
        {
            objGeneraEnvios.iIdConexion = IdConexion;
            objGeneraEnvios.fFechaCorte = txtFechaCorte.Text;
            objGeneraEnvios.sNumeroResolucionA = (String.IsNullOrEmpty(txtRA_A.Text) ? null : txtRA_A.Text);
            objGeneraEnvios.fFechaResolucionA = (String.IsNullOrEmpty(txtFechaRA_A.Text) ? null : txtFechaRA_A.Text);
            objGeneraEnvios.sNumeroResolucionM = (String.IsNullOrEmpty(txtRA_M.Text) ? null : txtRA_M.Text);
            objGeneraEnvios.fFechaResolucionM = (String.IsNullOrEmpty(txtFechaRA_M.Text) ? null : txtFechaRA_M.Text);
            objGeneraEnvios.sLoteCertificados = LoteCertificados;
            if (objGeneraEnvios.AltaGeneraEnvioXcertificado())
            {
                Master.MensajeOk("Exito!! Se generó el Envio de Altas correctamente.");
            }
            else
            {
                //Error
                string DetalleError = objGeneraEnvios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (ddnClaseEnvio.SelectedValue == "M" & LoteCertificados.Length > 0)
        {
            objGeneraEnvios.iIdConexion = IdConexion;
            objGeneraEnvios.fFechaCorte = txtFechaCorte.Text;
            objGeneraEnvios.sLoteCertificados = LoteCertificados;
            if (objGeneraEnvios.ModificacionGeneraEnvioXcertificado())
            {
                Master.MensajeOk("Exito!! Se generó el Envio de Modificaciones correctamente.");
            }
            else
            {
                //Error
                string DetalleError = objGeneraEnvios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (ddnClaseEnvio.SelectedValue == "B" & LoteCertificados.Length > 0)
        {
            objGeneraEnvios.iIdConexion = IdConexion;
            objGeneraEnvios.fFechaCorte = txtFechaCorte.Text;
            objGeneraEnvios.sLoteCertificados = LoteCertificados;
            if (objGeneraEnvios.BajasGeneraEnvioXcertificado())
            {
                Master.MensajeOk("Exito!! Se generó el Envio de Bajas correctamente.");
            }
            else
            {
                //Error
                string DetalleError = objGeneraEnvios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (LoteCertificados.Length == 0) Master.MensajeWarning("No se adicionó nada porque no hubo selección de Certificados!!");

        btnGeneraEnvio.Enabled = false;
    }
    protected void ddlPageSize_Changed(object sender, EventArgs e)
    {
        Llena_gvPreliminarEnvios(ddnClaseEnvio.SelectedValue, txtFechaCorte.Text, 1);
    }
    private void Llena_gvPreliminarEnvios(string ClaseEnvio, string FechaCorte, int pageIndex)
    {
        int RecordCount = 0, RecordCountA = 0, RecordCountM = 0;
        int pageSize = int.Parse(ddlPageSize.SelectedValue);

        DataTable listado1 = new DataTable();
        objGeneraBandejas.iIdConexion = IdConexion;
        objGeneraBandejas.fFechaCorte = Convert.ToDateTime(FechaCorte);
        objGeneraBandejas.iPageIndex = pageIndex;
        objGeneraBandejas.iPageSize = pageSize;
        objGeneraBandejas.cClaseEnvio = ClaseEnvio;
        if (objGeneraBandejas.GeneraBandejaPreliminarPag())
        {
            listado1 = objGeneraBandejas.DSet.Tables[0];
            RecordCountA = objGeneraBandejas.iRecordCountA;
            RecordCount = objGeneraBandejas.iRecordCount;
            if (listado1.Rows.Count == 0)
            {
                btnGeneraEnvio.Enabled = false;
            }
            else
            {
                btnGeneraEnvio.Enabled = true;
            }
        }
        else
        {
            //Error
            string DetalleError = objGeneraBandejas.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        
        gvPreliminarEnvios.DataSource = listado1;
        gvPreliminarEnvios.DataBind();
        RecordCountM = Math.Abs(RecordCount - RecordCountA);
        lblRecordCount.Text = RecordCount.ToString();
        lblRecordCountA.Text = RecordCountA.ToString();
        lblRecordCountM.Text = RecordCountM.ToString();

        PopulatePager(RecordCount, pageIndex);
    }
    protected void rptPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        ViewState["pageIndex"] = pageIndex.ToString();
        Llena_gvPreliminarEnvios(ddnClaseEnvio.SelectedValue, txtFechaCorte.Text, pageIndex);

        //BEGIN gvPreliminarEnvios_CheckUpdate
        if (ViewState["CheckBoxArray"] != null)
        {
            ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            //string checkAllIndex = "chkAll-" + gvPreliminarEnvios.PageIndex;
            string checkAllIndex = "chkAll-" + pageIndex;

            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
            {
                CheckBox chkAll = (CheckBox)gvPreliminarEnvios.HeaderRow.Cells[0].FindControl("chkAll");
                chkAll.Checked = true;
            }
            for (int i = 0; i < gvPreliminarEnvios.Rows.Count; i++)
            {

                if (gvPreliminarEnvios.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBox chk = (CheckBox)gvPreliminarEnvios.Rows[i].Cells[0].FindControl("chkPE");
                        chk.Checked = true;
                        //gvPreliminarEnvios.Rows[i].Attributes.Add("style", "background-color:aqua");
                    }
                    else
                    {
                        //int CheckBoxIndex = gvPreliminarEnvios.PageSize * (gvPreliminarEnvios.PageIndex) + (i + 1);
                        int CheckBoxIndex = gvPreliminarEnvios.PageSize * (pageIndex) + (i + 1);
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                        {
                            CheckBox chk = (CheckBox)gvPreliminarEnvios.Rows[i].Cells[0].FindControl("chkPE");
                            chk.Checked = true;
                            //gvPreliminarEnvios.Rows[i].Attributes.Add("style", "background-color:aqua");
                        }
                    }
                }
            }
        }
        //END gvPreliminarEnvios_CheckUpdate
    }
    protected void gvPreliminarEnvios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ddnClaseEnvio.SelectedValue == "A")
            {
                gvPreliminarEnvios.Columns[1].Visible = false;
                //string Clase_CC = e.Row.Cells[8].Text;
                //if (Clase_CC=="A")
                //    lblAutomatico.Text = Clase_CC;
                //else
                //    lblManual.Text = Clase_CC;
            }
            if (ddnClaseEnvio.SelectedValue == "M")
            {
                gvPreliminarEnvios.Columns[1].Visible = true;
                int IdActualizacion = Convert.ToInt32
                    (DataBinder.Eval(e.Row.DataItem, "IdActualizacion"));
                if (IdActualizacion > 0)
                {
                    HyperLink hlkMostrar = (HyperLink)e.Row.FindControl("hlkMostrar");
                    hlkMostrar.NavigateUrl = "wfrmRepNovedadesMod.aspx?idAct=" + Server.UrlEncode(IdActualizacion.ToString());
                }

                // int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                int Pago = Convert.ToInt32
                    (DataBinder.Eval(e.Row.DataItem, "Pago"));
                if (Pago == 1)
                {
                    e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
            }
            if (ddnClaseEnvio.SelectedValue == "B")
            {
                gvPreliminarEnvios.Columns[1].Visible = false;
                // int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                int Pago = Convert.ToInt32
                    (DataBinder.Eval(e.Row.DataItem, "Pago"));
                if (Pago == 1)
                {
                    e.Row.BackColor = System.Drawing.Color.LightSteelBlue;
                    e.Row.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }
    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)gvPreliminarEnvios.HeaderRow.FindControl("chkAll");
        foreach (GridViewRow row in gvPreliminarEnvios.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkPE");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
        if (ChkBoxHeader.Checked) btnGeneraEnvio.Enabled = true;
        else btnGeneraEnvio.Enabled = false;
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        ViewState["pageIndex"] = currentPage.ToString();
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("|<", "1", currentPage > 1));
            //for (int i = 1; i <= pageCount; i++)
            //{
            //    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            //}
            int startPage = currentPage - 5;
            int endPage = currentPage + 5;
            if (startPage < 5) startPage = 1;
            if (endPage > pageCount) endPage = pageCount;
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == startPage & i != 1) pages.Add(new ListItem("...", startPage.ToString(), startPage != currentPage));
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                if (i == endPage & i != pageCount) pages.Add(new ListItem("...", endPage.ToString(), currentPage < pageCount));
            }
            pages.Add(new ListItem(">|", pageCount.ToString(), currentPage < pageCount));
        }
        if (pageCount > 1)
        {
            rptPager.Visible = true;
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }
        else
        {
            rptPager.Visible = false;
        }
    }
    protected void gvEnvios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Loop thru each datarow in the gridview
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string colA = gvEnvios.DataKeys[e.Row.RowIndex].Values[0].ToString();
            //string colB = gvEnvios.DataKeys[e.Row.RowIndex].Values[1].ToString();
            //string colC = gvEnvios.DataKeys[e.Row.RowIndex].Values[2].ToString();
            if (objGeneraMedios.NumeroEnvioTieneMedio(colA))
            {
                Button btnGenerarMedios = (Button)e.Row.FindControl("btnGenerarMedios");
                //btnGenerarMedios.Text = colA;
                btnGenerarMedios.Enabled = false;
            }
        }
    }
    protected void gvEnvios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = gvEnvios.Rows[index];
            Label lblNumeroEnvio = selectedRow.FindControl("lblNumeroEnvio") as Label;
            NumeroEnvioDetalleEnvioAPS = lblNumeroEnvio.Text;

            Carga_gvDetalleEnvioAPS(NumeroEnvioDetalleEnvioAPS);
        }
        if (e.CommandName == "Generar")
        {
            //TemplateField
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            Label lblNumeroEnvio = row.FindControl("lblNumeroEnvio") as Label;
            string NumeroEnvio = lblNumeroEnvio.Text;

            AltaGeneraMediosMagEntidades(NumeroEnvio);
            Carga_gvEnvios();
        }
        if (e.CommandName == "Reporte01")
        {
            //ButtonField
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            string NumeroEnvio = gvEnvios.DataKeys[currentRowIndex].Value.ToString();

            pnlGrid1.Visible = false;
            pnlGrid2.Visible = false;

            Session["NumeroEnvioReporte"] = NumeroEnvio;
            Response.Redirect("wfrmRepRMCC01.aspx");

            //Response.Write("<script>");
            //Response.Write("window.open('wfrmControlDeEnvios.aspx','_blank')");
            //Response.Write("</script>");
        }
    }
    protected void gvDetalleEnvioAPS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hlkActualizacion = (HyperLink)e.Row.FindControl("hlkActualizacion");

            if (hlkActualizacion.Text == "Modificación")
            {
                int IdActualizacion = Int32.Parse(DataBinder.Eval(e.Row.DataItem, "IdActualizacion").ToString());
                hlkActualizacion.NavigateUrl = "wfrmRepNovedadesMod.aspx?idAct=" + Server.UrlEncode(IdActualizacion.ToString());
            }
        }
    }
    protected void gvDetalleEnvioAPS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string currentCommand = e.CommandName;
        int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
        //string Id = gvDetalleEnvioAPS.DataKeys[currentRowIndex].Value.ToString();

        //Label1.Text = "Command: " + currentCommand;
        //Label2.Text = "Row Index: " + currentRowIndex.ToString();
        //Label3.Text = "Id: " + Id;
        //Label ltrlName2 = (Label)gvDetalleEnvioAPS.Rows[currentRowIndex].FindControl("lblName");
        //Label4.Text = "Name: " + ltrlName2.Text;

        if (e.CommandName == "EXCLUIR")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblNumeroEnvio = (Label)gvDetalleEnvioAPS.Rows[index].FindControl("lblNumeroEnvio");
            Label lblFila = (Label)gvDetalleEnvioAPS.Rows[index].FindControl("lblFila");

            GridViewRow row = gvEnvios.SelectedRow;
            string MessageLabel = "You selected " + row.Cells[2].Text + ".";
            Button btnGenerarMedios = gvEnvios.SelectedRow.FindControl("btnGenerarMedios") as Button;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + lblNumeroEnvio.Text + "--" + lblFila.Text + "');", true);

            objGeneraEnvios.iIdConexion = IdConexion;
            objGeneraEnvios.sNumeroEnvio = lblNumeroEnvio.Text.ToString();
            objGeneraEnvios.iFila = Convert.ToInt32(lblFila.Text);
            if (!objGeneraEnvios.ExcluyeCertificadoMedioEnvioAPS())
            {
                //Error
                string DetalleError = objGeneraEnvios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }

            //if (!btnGenerarMedios.Enabled)
            //{
            //    AltaGeneraMediosMagEntidades(lblNumeroEnvio.Text);
            //}
            Carga_gvEnvios();
            gvDetalleEnvioAPS.DataBind();
        }
    }
    protected void AltaGeneraMediosMagEntidades(string NumeroEnvio)
    {
        //Borra directorio con datos obsoletos
        string pathToDelete = "~/Medios/EnviosAPS";
        if (Directory.Exists(Server.MapPath(pathToDelete)))
        {
            pathToDelete = pathToDelete + "/" + NumeroEnvio.ToString();
            var directoryInfo = new DirectoryInfo(Server.MapPath(pathToDelete));
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete(true);
            }
        }
        
        DataTable dtEntidadesGestoras = objGeneraMedios.ObtieneEntidadesGestoras();
        // 344 - '01' --AFP FUTURO
        // 345 - '02' --AFP PREVISIÓN
        // 346 - '203' --LA VITALICIA
        // 347 - '205' --PROVIDA
        // 701 - '11' --APS
        int IdDetalleClasificador;
        foreach (DataRow fila in dtEntidadesGestoras.Rows)
        {
            IdDetalleClasificador = Convert.ToInt32(fila["IdDetalleClasificador"]);
            AltaGeneraMediosMag(NumeroEnvio, IdDetalleClasificador);
        }   
    }
    protected void AltaGeneraMediosMag(string NumeroEnvio, int IdEntidadGestora)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-MX");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

        DataTable dtMediosMag = new DataTable();
        objGeneraMedios.iIdConexion = IdConexion;
        objGeneraMedios.sNumeroEnvio = NumeroEnvio;
        objGeneraMedios.iIdEntidadGestora = IdEntidadGestora;
        if (objGeneraMedios.AltaGeneraMediosMag())
        {
            dtMediosMag = objGeneraMedios.DSet.Tables[0];
        }
        else
        {
            //Error
            string DetalleError = objGeneraMedios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }

        if (dtMediosMag.Rows.Count>0)  //Si tiene registros para enviar a la entidad
        {
            string pathToCreate = "~/Medios/EnviosAPS/";
            if (Directory.Exists(Server.MapPath(pathToCreate)))
            {
                pathToCreate = pathToCreate + "/" + NumeroEnvio.ToString();
                Directory.CreateDirectory(Server.MapPath(pathToCreate));
            }
            // 344 - '01' --AFP FUTURO
            // 345 - '02' --AFP PREVISIÓN
            // 346 - '203' --LA VITALICIA
            // 347 - '205' --PROVIDA
            // 701 - '11' --APS
            string NomArchivo = NumeroEnvio + ".TXT";
            switch (IdEntidadGestora)
            {
                case 344: // 344 - '01' --AFP FUTURO
                    NomArchivo = "FUT" + NomArchivo;
                    break;
                case 345:   // 345 - '02' --AFP PREVISIÓN
                    NomArchivo = "PREV" + NomArchivo;
                    break;
                case 346:   // 346 - '203' --LA VITALICIA
                    NomArchivo = "VITA" + NomArchivo;
                    break;
                case 347:   // 347 - '205' --PROVIDA
                    NomArchivo = "VIDA" + NomArchivo;
                    break;
                default:
                    //Console.WriteLine("Default case");
                    break;
            }

            String RutaCrear = Server.MapPath("~/Medios/EnviosAPS/") + NumeroEnvio.ToString() + "/";
            try
            {
                objManejoArchivo.CrearArchivo(dtMediosMag, RutaCrear + NomArchivo);
                Master.MensajeOk("Exito!! El archivo de envio " + RutaCrear + NomArchivo + " se generó correctamente.");
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al crear el Archivo " + RutaCrear + NomArchivo + ".", ex.Message);
            }

            try
            {
                objManejoArchivo.GenerarCRC(RutaCrear + NomArchivo);
                Master.MensajeOk("Exito!! El archivo de envio " + RutaCrear + NomArchivo + " se generó correctamente.");
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error!! al crear el Archivo " + RutaCrear + NomArchivo + ".", ex.Message);
            }

            //344 AFP FUTURO
            //345 AFP PREVISIÓN
            //346 LA VITALICIA
            //347 PROVIDA
            //701 APS
            //int IdEntidad = 701;
            int NumeroCite = 0;
            string ArchivoEnvioNombre = RutaCrear + NomArchivo;
            string ArchivoEnvioContTipo = "text/plain";
            string ArchivoEnvioCRCNombre = RutaCrear + Path.GetFileNameWithoutExtension(NomArchivo) + "_CRC.TXT";

            string Usuario = objSeguridadCliente.CuentaUsuario((int)Session["IdConexion"]);
            int RegistroActivo = 1;

            //Subimos los archivos generados a la base de datos
            objGeneraMedios.iIdConexion = IdConexion;
            objGeneraMedios.sNumeroEnvio = NumeroEnvio;
            objGeneraMedios.iIdEntidadGestora = IdEntidadGestora;

            objGeneraMedios.iNumeroCite = NumeroCite;
            objGeneraMedios.fFechaCite = Convert.ToDateTime("01/01/2015");
            objGeneraMedios.fFechaRecepcion = Convert.ToDateTime("01/01/2015");
            objGeneraMedios.sArchivoEnvioNombre = ArchivoEnvioNombre;
            objGeneraMedios.sArchivoEnvioContTipo = ArchivoEnvioContTipo;
            //objGeneraMedios.iArchivoEnvioLongitud = iArchivoEnvioLongitud;
            //objGeneraMedios.vArchivoEnvioDatos = vArchivoEnvioDatos;
            objGeneraMedios.sArchivoEnvioCRCNombre = ArchivoEnvioCRCNombre;
            //objGeneraMedios.vArchivoEnvioCRCDatos = vArchivoEnvioCRCDatos;
            objGeneraMedios.sUsuario = Usuario;
            objGeneraMedios.iRegistroActivo = RegistroActivo;
            if (!objGeneraMedios.SaveEnvioToDB())
            {
                //Error
                string DetalleError = objGeneraMedios.sMensajeError;
                string Error = "Error al realizar la operación";
                Master.MensajeError(Error, DetalleError);
            }
        }
    }
    protected void ddnClaseEnvio_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlGrid1.Visible = false;
        pnlGrid2.Visible = false;
        btnGeneraEnvio.Enabled = false;
        ActualizaRAyFecha();
        btnBandejaPreliminar_Click(btnBandejaPreliminar, null);
    }
    protected void ActualizaRAyFecha()
    {
        if (ddnClaseEnvio.SelectedValue == "A")
        {
            txtRA_A.Visible = true;
            txtRA_M.Visible = true;
            txtFechaRA_A.Visible = true;
            txtFechaRA_M.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            imgPopup2.Visible = true;
            imgPopup3.Visible = true;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = true;

            DataTable dtDatosRAyFecha = new DataTable();
            objGeneraMedios.iIdConexion = IdConexion;
            objGeneraMedios.sCodigoActualizacion = ddnClaseEnvio.SelectedValue.ToString();
            if (objGeneraMedios.BuscaRAyFecha())
            {
                dtDatosRAyFecha = objGeneraMedios.DSet.Tables[0];

                //Actualiza datos de Numero de R.A. y Fecha asociados a la fecha de corte elegida
                txtRA_A.Text = dtDatosRAyFecha.Rows[0]["NumeroResolucion"].ToString();
                txtFechaRA_A.Text = String.Format("{0:dd/MM/yyyy}", dtDatosRAyFecha.Rows[0]["FechaResolucion"]);
                txtRA_M.Text = ""; txtFechaRA_M.Text = "";
                if (dtDatosRAyFecha.Rows.Count > 1)
                {
                    txtRA_M.Text = dtDatosRAyFecha.Rows[1]["NumeroResolucion"].ToString();
                    txtFechaRA_M.Text = String.Format("{0:dd/MM/yyyy}", dtDatosRAyFecha.Rows[1]["FechaResolucion"]);
                }
            }
            else
            {
                //Error
                string DetalleError = objGeneraMedios.sMensajeError;
                string Error = "Error al realizar la operación";
                //Master.MensajeError(Error, DetalleError);

                //Actualiza datos de Numero de R.A. y Fecha asociados a la fecha de corte elegida
                txtRA_A.Text = "";
                txtRA_M.Text = "";
                txtFechaRA_A.Text = "";
                txtFechaRA_M.Text = "";
            }
        }
        else 
        {
            //Actualiza datos de Numero de R.A. y Fecha asociados a la fecha de corte elegida
            txtRA_A.Visible = false;
            txtRA_M.Visible = false;
            txtFechaRA_A.Visible = false;
            txtFechaRA_M.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            imgPopup2.Visible = false;
            imgPopup3.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;

            txtRA_A.Text = "";
            txtRA_M.Text = "";
            txtFechaRA_A.Text = "";
            txtFechaRA_M.Text = "";
        }
    }
    protected void btnRemiteAltas_Click(object sender, EventArgs e)
    {
        DataTable dtDatosRAyFecha = new DataTable();
        objGeneraMedios.iIdConexion = IdConexion;
        if (!objGeneraMedios.RemiteAltas())
        {
            //Error
            string DetalleError = objGeneraMedios.sMensajeError;
            string Error = "Error al realizar la operación";
            Master.MensajeError(Error, DetalleError);
        }
        else
        {
            Response.Redirect(@"~/WorkFlow/wfrmBandejaTramites.aspx");
        }
    }
    protected void Show_btnRemiteAltas()
    {
        btnRemiteAltas.Visible = false;
        //..::articulador::..
        return;

        DataSet dsEnvios = new DataSet();
        objGeneraMedios.iIdConexion = IdConexion;
        objGeneraMedios.sCodigoActualizacion = "A";
        if (objGeneraMedios.ObtieneEnviosCerradosNoRemitidos())
        {
            dsEnvios = objGeneraMedios.DSet;
            if (dsEnvios.Tables[0].Rows.Count > 0)
            {
                btnRemiteAltas.Visible = true;
            }
        }
        else
        {
            //Error
            string DetalleError = objGeneraMedios.sMensajeError;
            string Error = "Error al realizar la operación";
            //Master.MensajeError(Error, DetalleError);
        }
        //btnRemiteAltas.Visible = false;
    }
}