using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using wcfEmisionCertificadoCC.Logica;

public partial class EmisionCertificadoCC_wfrmRegistroStock : System.Web.UI.Page
{
    clsStockCorrelativo correlativo = new clsStockCorrelativo();
    string mensaje;
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
            CargarComboTipoCertificado();
            ListarRegistros();
        }
    }

    #region Cargar_datos
    // LISTA LOS REGISTROS Y COLOCA EN GRILLA
    protected void ListarRegistros()
    {
        mensaje = null;
        gvStock.DataSource = correlativo.ListaStockCorrelativos((int)Session["IdConexion"], "B", ref mensaje);
        gvStock.DataBind();
        if (gvStock.DataSource == null || gvStock.Rows.Count <= 0)
            Master.MensajeError("Error al realizar la Operacion", mensaje);
    }
    //LIMPIA DATOS DE MODAL POPUP
    protected void Limpiar()
    {
        lblFechaReg.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
        txtCantidad.Text = "";
        txtObservacion.Text = "";
        chbEstado.Checked = true;
        lblObservaciones.Text = "";
    }

    //Carga Combos deTipo Certificado 20/06/2015
    protected void CargarComboTipoCertificado() 
    {   
        mensaje = null;
        ddlTipoCertificado.DataSource = correlativo.ListaCertificados((int)Session["IdConexion"], "A", ref mensaje);
        ddlTipoCertificado.DataValueField = "IdDetalleClasificador";
        ddlTipoCertificado.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoCertificado.DataBind();
        if (ddlTipoCertificado.DataSource == null || ddlTipoCertificado.Items.Count <= 0) 
            Master.MensajeError("Error al realizar la Operacion", mensaje);
    }

    //RECUPERA LOS DATOS PARA VERLOS
    private void VerDatos()
    {
        Int32 Cod = Convert.ToInt32(lblCodigo.Text);
        DataTable cor = new DataTable();
        cor = correlativo.ObtenerStockCorrelativos((int)Session["IdConexion"], "C", Cod, ref mensaje);
        if (cor.Rows.Count > 0 && cor != null)
        {
            ddlTipoCertificado.SelectedValue = cor.Rows[0]["IdTipoCertificado"].ToString();
            txtNumInicial.Text = cor.Rows[0]["NumeroInicial"].ToString();
            txtNumFinal.Text = cor.Rows[0]["NumeroFinal"].ToString();
            txtCantidad.Text = cor.Rows[0]["Saldo"].ToString();
            txtObservacion.Text = cor.Rows[0]["Observacion"].ToString();
        }
        else 
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }
    #endregion

    # region botones
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        mensaje = null;
        int Estado,Control=0 , cont1=0;
        DateTime fnac = Convert.ToDateTime(lblFechaReg.Text);
       
        if (chbEstado.Checked) 
        { Estado = 1; }
        else 
        { Estado = 0;   }

        if (btnAccionar.Text == "Adicionar") // Accion del Boton Adicionar
        {
            if (!String.IsNullOrEmpty(txtCantidad.Text))
            {
                if(correlativo.AdicionaStockCorrelativos((int)Session["IdConexion"], "I", Convert.ToInt32(ddlTipoCertificado.SelectedValue), Convert.ToInt32(txtCantidad.Text), txtObservacion.Text, ref mensaje))
                {
                    Master.MensajeOk("Se adicionó Correctamente el Stock");
                    ListarRegistros();
                }
                else
                {
                    Master.MensajeError("Error al realizar la Operación",mensaje);
                    ListarRegistros();
                }
            }
            else
            {   
                string msg = "Ingrese la Cantidad de Solicitud";
                Master.MensajeError("Error al realizar la Operación", msg);
                ListarRegistros();
                }
        }
       if (btnAccionar.Text == "Eliminar") // Accion del Boton Eliminar
            {
                DataTable VerStock, VerUltAplicado;
                int Cod = Convert.ToInt32(lblCodigo.Text);
                VerStock = correlativo.VerificarStockAsignaciones((int)Session["IdConexion"], "E", Convert.ToInt32(ddlTipoCertificado.SelectedValue), Convert.ToInt32(txtNumInicial.Text), Convert.ToInt32(txtNumFinal.Text), ref mensaje);
                VerUltAplicado = correlativo.VerificarUltimoStockCorrelativos((int)Session["IdConexion"], "F", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedValue), Convert.ToInt32(txtCantidad.Text), ref mensaje);
                if (VerStock.Rows.Count > 0 && VerStock != null)
                    Control = Convert.ToInt32(VerStock.Rows[0]["existedatos"]);
                else
                    Control = 0;
                if (VerUltAplicado.Rows.Count > 0 && VerUltAplicado != null)
                    cont1 = Convert.ToInt32(VerUltAplicado.Rows[0]["PartidaLote"]);
                else
                    cont1 = 0;

                if (Control == 0 && cont1==0)
                    {
                        if (correlativo.EliminarStockCorrelativos((int)Session["IdConexion"], "G", Cod, ref mensaje))
                        {
                            Master.MensajeOk("Eliminacion de Stock Satisfactoria");
                            Limpiar();
                            ListarRegistros();
                        }
                        else 
                        {
                            Master.MensajeError("Error al realizar la Operación", mensaje);
                            Limpiar();
                            ListarRegistros();
                        }
                }
                else
                {
                    string msg = "No se puede eliminar el Stock,existen Asignaciones realizadas";
                    Master.MensajeError("Error al realizar la Operación", msg);
                    ListarRegistros();
                }

            }
            if (btnAccionar.Text == "Modificar") // CUANDO EL BOTON ES MODIFICAR
            {
                int cont = 0;
                cont1=0;
                int Cod = Convert.ToInt32(lblCodigo.Text);
                DataTable VerStock = new DataTable(); 
                DataTable VerUltAplicado = new DataTable();
                clsStockCorrelativo modi = new clsStockCorrelativo();
                if (!String.IsNullOrEmpty(txtCantidad.Text))
                {
                    VerStock = correlativo.VerificarStockAsignaciones((int)Session["IdConexion"], "E", Convert.ToInt32(ddlTipoCertificado.SelectedValue), Convert.ToInt32(txtNumInicial.Text), Convert.ToInt32(txtNumFinal.Text), ref mensaje);
                    VerUltAplicado = correlativo.VerificarUltimoStockCorrelativos((int)Session["IdConexion"], "F", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedValue), Convert.ToInt32(txtCantidad.Text), ref mensaje);
                    if (VerStock.Rows.Count > 0 && VerStock != null)
                        cont = Convert.ToInt32(VerStock.Rows[0]["existedatos"]);
                    else
                        cont = -99;
                    if (VerUltAplicado.Rows.Count > 0 && VerUltAplicado != null)
                        cont1 = Convert.ToInt32(VerUltAplicado.Rows[0]["PartidaLote"]);
                    else
                        cont1 = -99;
                    if (cont == 0 && cont1==0)
                    {
                        if (correlativo.ModificaStockCorrelativos((int)Session["IdConexion"], "H", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedValue), Convert.ToInt32(txtNumInicial.Text), Convert.ToInt32(txtCantidad.Text), txtObservacion.Text, ref mensaje))
                        {
                            Master.MensajeOk("La Modificacion de Stock fue Satisfactoria!!!");
                            Limpiar();
                            ListarRegistros();
                        }
                        else 
                        {
                            Master.MensajeError("Error al realizar la Operación!!!", mensaje);
                            Limpiar();
                            ListarRegistros();
                        }
                    }
                    else
                    {
                        Master.MensajeError("Error al realizar la Operación", "No se puede modificar el registro por asginaciones ya realizadas");
                    }
                }
                else
                {
                    string msg = "Ingrese el valor de la Cantidad solicitada";
                    Master.MensajeError("Error al realizar la Operación", msg);
                }

            }
       
    }
#endregion 

    #region habilitacionpopup

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de Stock certificados";
        lblFechaReg.Text = DateTime.Now.ToString("dd/MM/yyyy");

        ddlTipoCertificado.Enabled = true;
        txtNumInicial.Visible= false;
        txtNumFinal.Visible = false;
        txtNumInicial.Enabled = false;
        txtNumFinal.Enabled = false;
        lblInicial.Visible = false;
        lblFinal.Visible = false;
        txtCantidad.Enabled = true;
        txtObservacion.Enabled = true;
        chbEstado.Enabled = false;
        CargarComboTipoCertificado();
        this.pnlDatos_ModalPopupExtender.Show();
    }
    #endregion

    # region eventos

    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }

    protected void gvStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));


            if (DEstado == 1)
            {
                //HyperLink hlnk = new HyperLink();
                //hlnk.NavigateUrl = "";
                //hlnk.ImageUrl = "~/Imagenes/16Activo.png";
                //e.Row.Cells[8].Controls.Add(hlnk);
                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgEstado");
                imagen.ImageUrl = "~/Imagenes/16Activo.png";
                if(Convert.ToInt32(e.Row.Cells[5].Text)==0)
                {
                    e.Row.Cells[5].BackColor = Color.DodgerBlue;
                }
                 
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.SlateGray;
                e.Row.ForeColor = Color.GhostWhite;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                //HyperLink hlnk = new HyperLink();
                //hlnk.NavigateUrl = "";
                //hlnk.ImageUrl = "~/Imagenes/16Peligro.png";
                //e.Row.Cells[8].Controls.Add(hlnk);
                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgEstado");
                imagen.ImageUrl = "~/Imagenes/16Inactivo.png";
                e.Row.FindControl("imgEditar").Visible = false;
                e.Row.FindControl("imgEliminar").Visible = false;
                if (rbTipoMuestra.SelectedIndex == 1)
                    e.Row.Visible = false;
            }
        }
    }
    protected void gvStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string estado;
        string valor;
        int val;

        GridViewRow row = gvStock.Rows[e.RowIndex];
        val = row.RowIndex;
        valor = gvStock.Rows[val].Cells[8].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Eliminar";
        lblTitulo.Text = "Eliminacion de Stock";

        ddlTipoCertificado.Enabled = false;
        txtNumInicial.Visible = true;
        txtNumFinal.Visible = true;
        txtNumInicial.Enabled = false;
        txtNumFinal.Enabled = false;

        txtCantidad.Enabled = false;
        txtObservacion.Enabled = false;
        chbEstado.Enabled = false;
        chbEstado.Checked = false;

        VerDatos();
        estado = Convert.ToString(gvStock.Rows[val].BackColor);
        if (estado == "Color [Empty]")
            this.pnlDatos_ModalPopupExtender.Show();
        else
            lblObservaciones.Text = "Este Registro no se puede Eliminar"; 
      //  this.pnlDatos_ModalPopupExtender.Show();
    }
    protected void gvStock_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string estado;
        string valor;
        int val;
        GridViewRow row = gvStock.Rows[e.NewEditIndex];
        val = row.RowIndex;
        valor = gvStock.Rows[val].Cells[8].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion  de Stock";
        ddlTipoCertificado.Enabled = true;

        txtNumInicial.Visible = true;
        txtNumFinal.Visible = true;
        txtNumInicial.Enabled = false;
        txtNumFinal.Enabled = false;

        txtCantidad.Enabled = true;
        txtObservacion.Enabled = true;
       
        chbEstado.Enabled = false;
  
        VerDatos();
        estado = Convert.ToString(gvStock.Rows[val].BackColor);
        if (estado == "Color [Empty]")
            this.pnlDatos_ModalPopupExtender.Show();
        else
            lblObservaciones.Text = "Este Registro no se puede Modificar"; 
     //   this.pnlDatos_ModalPopupExtender.Show();
    }
    #endregion


    protected void gvStock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index = Convert.ToInt32(e.CommandArgument);
        string estado;
        string valor;
        int val;
        if (e.CommandName == "cmdEditar")
        { 
            GridViewRow row = gvStock.Rows[Index];
            val = row.RowIndex;
            //valor = gvStock.Rows[val].Cells[8].Text;
            valor = Convert.ToString(gvStock.DataKeys[val].Values["PartidaLote"]);
            lblCodigo.Text = valor;

            Limpiar();

            btnAccionar.Text = "Modificar";
            lblTitulo.Text = "Modificacion  de Stock";

            txtNumInicial.Visible = true;
            txtNumFinal.Visible = true;
            txtNumInicial.Enabled = false;
            txtNumFinal.Enabled = false;
            ddlTipoCertificado.Enabled = false;
            txtCantidad.Enabled = true;
            txtObservacion.Enabled = true;

            chbEstado.Enabled = false;

            VerDatos();
            estado = Convert.ToString(gvStock.Rows[val].BackColor);
            if (estado == "Color [Empty]")
                this.pnlDatos_ModalPopupExtender.Show();
            else
                lblObservaciones.Text = "Este Registro no se puede Modificar";
        }
        if (e.CommandName == "cmdEliminar") 
        { 
            GridViewRow row = gvStock.Rows[Index];
            val = row.RowIndex;
            //valor = gvStock.Rows[val].Cells[8].Text;
            valor = Convert.ToString(gvStock.DataKeys[val].Values["PartidaLote"]);
            lblCodigo.Text = valor;

            Limpiar();

            btnAccionar.Text = "Eliminar";
            lblTitulo.Text = "Eliminacion de Stock";

            ddlTipoCertificado.Enabled = false;
            txtNumInicial.Visible = true;
            txtNumFinal.Visible = true;
            txtNumInicial.Enabled = false;
            txtNumFinal.Enabled = false;

            txtCantidad.Enabled = false;
            txtObservacion.Enabled = false;
            chbEstado.Enabled = false;
            chbEstado.Checked = false;

            VerDatos();
            estado = Convert.ToString(gvStock.Rows[val].BackColor);
            if (estado == "Color [Empty]")
                this.pnlDatos_ModalPopupExtender.Show();
            else
                lblObservaciones.Text = "Este Registro no se puede Eliminar";
        }
    }
    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvStock.PageIndex = e.NewPageIndex;
        ListarRegistros();
    }

}