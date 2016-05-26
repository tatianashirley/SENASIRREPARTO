
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using wcfEmisionCertificadoCC.Logica;
using WcfServicioClasificador.Logica;

public partial class EmisionCertificadoCC_wfrmControlAsignarCorrelativos : System.Web.UI.Page
{
    clsAsignarCorrelativo Correlativo = new clsAsignarCorrelativo();
    string mensaje;
    string Error = "Error al realizar la Operación";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }

        if (!Page.IsPostBack)
        {
            CargarGrillaStock(); //Carga la cantidad de Tipos de Certificado
            CargarComboOficinaPrincipal(); //Carga combo de Oficinas que imprimen certificados
            CargarComboTipoCertificado();   //Lista los tipos de certificado Autmatico o Manual
            CargarComboOficina();   //Lista oficinas a cuales se les envía stock de certificados
            ListarRegistros(); //Lista la grilla de datos completos
        }
    }

    private void CargarComboOficinaPrincipal() //MODIFICACION 05-06-2015
    {

        ddlOficinacom.DataSource = Correlativo.AreasImpresion((int)Session["IdConexion"], "B", ref mensaje);
        ddlOficinacom.DataValueField = "IdArea";
        ddlOficinacom.DataTextField = "Descripcion";
        ddlOficinacom.DataBind();
        if (ddlOficinacom.Items.Count > 0 && ddlOficinacom.DataSource != null)
        {
            ddlOficinacom.Items.Insert(0, new ListItem("TODOS", "0"));
            ddlOficinacom.SelectedValue = "0";
        }
        else
            Master.MensajeError(Error, mensaje);
    }
    // LISTA LOS REGISTROS Y COLOCA EN GRILLA
    protected void ListarRegistros() //MODIFICACION 05-06-2015
    {
        int ckSeleccion = Convert.ToInt32(ckAgotado.Checked);

        gvCorrelativo.DataSource = Correlativo.ListaAsignacionStockCorrelativos((int)Session["IdConexion"], "C", Convert.ToInt32(ddlOficinacom.SelectedValue), ckSeleccion, ref mensaje);
        gvCorrelativo.DataBind();

        if (gvCorrelativo.DataSource == null || gvCorrelativo.Rows.Count <= 0)
            Master.MensajeError(Error, mensaje);
    }
    //LIMPIA DATOS DE MODAL POPUP
    protected void Limpiar()
    {
        txtFechaReg.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
        txtDate.Text = "";
        txtCantidad.Text="";
        txtNumInicial.Text = "";
        txtNumFinal.Text = "";
        txtObservacion.Text = "";
        lblObservaciones.Text = "";
    }
    // CARGA COMBOS DE TIPO CERTIFICADO PARA EL POP UP
    protected void CargarComboTipoCertificado()
    {
        clsStockCorrelativo cor = new clsStockCorrelativo();

        ddlTipoCertificado.DataSource = cor.ListaCertificados((int)Session["IdConexion"], "A", ref mensaje);
        ddlTipoCertificado.DataValueField = "IdDetalleClasificador";
        ddlTipoCertificado.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoCertificado.DataBind();
        if (ddlTipoCertificado.Items.Count <= 0 || ddlTipoCertificado.DataSource == null)
            Master.MensajeError(Error, mensaje);
    }
    // CARGA COMBOS DE OFICINA MODIFICADO 05-06-2015
    protected void CargarComboOficina() //CARGA LISTA DE OFICINAS Q PUEDEN IMPRIMIR CERTIFICADOS Y A LAS CUALES SE LES DERIVA LOS FISICOS
    {

        ddlOficina.DataSource = Correlativo.AreasImpresion((int)Session["IdConexion"], "B", ref mensaje);
        ddlOficina.DataValueField = "IdArea";
        ddlOficina.DataTextField = "Descripcion";
        ddlOficina.DataBind();
        if (ddlOficina.Items.Count <= 0 && ddlOficina.DataSource == null)
            Master.MensajeError(Error, mensaje);
    }
    // CARGA GRILLA de STOCK MODIFICADO 03-06-2015
    protected void CargarGrillaStock()
    {
        mensaje = null;
        gvSaldos.DataSource = Correlativo.ListaSaldoCertificados((int)Session["IdConexion"], "A", ref mensaje);
        gvSaldos.DataBind();
        if (gvSaldos.DataSource == null && gvSaldos.Rows.Count <= 0) 
            Master.MensajeError(Error, mensaje);
    }
    //RECUPERA LOS DATOS PARA VERLOS PARA EFECTUAR ELIMINACIONES
    private void VerDatos() //MODIFICADO 05-06-2015
    {
        int Cod = Convert.ToInt32(lblCodigo.Text);
        DataTable Asignacion = Correlativo.ObtieneDatosAsignacion((int)Session["IdConexion"], "E", Cod, ref mensaje);
        if (Asignacion != null && Asignacion.Rows.Count > 0)
        {
            foreach (DataRow tp2 in Asignacion.Rows)
            {
                txtFechaReg.Text = tp2["FechaAsignacion"].ToString();
                txtDate.Text = tp2["FechaAsignacion"].ToString();
                ddlTipoCertificado.SelectedValue = tp2["IdTipoTramite"].ToString();
                ddlOficina.SelectedValue = tp2["IdOficinaArea"].ToString();
                txtNumInicial.Text = tp2["NumeroInicial"].ToString();
                txtNumFinal.Text = tp2["NumeroFinal"].ToString();
                txtObservacion.Text = tp2["Observacion"].ToString();
                txtCantidad.Text = tp2["Cantidad"].ToString();
            }
        }
        else
            Master.MensajeError(Error, mensaje);
    }
    

    protected void ddlOficinacom_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }

# region botones
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
        ListarRegistros();
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        int Estado,cant=0;
        int verificar=0;
        DateTime fnac;
      
        if (chbEstado.Checked)
        {
            Estado = 1;      
        }
        else
        {
            Estado = 0;
        }    
            if (btnAccionar.Text == "Adicionar") // CUANDO EL BOTON ES ADICIONAR
            {
                if (DateTime.TryParse(txtDate.Text, out fnac))
                {
                    DateTime fasignacion = Convert.ToDateTime(txtFechaReg.Text);
                    DateTime fenvio = Convert.ToDateTime(txtDate.Text);
                    if (fasignacion <= fenvio)
                    {
                        if (String.IsNullOrEmpty(txtCantidad.Text))
                        {
                            Master.MensajeError(Error, "Debe ingresar la cantidad a ser solicitada");
                        }
                        else
                        {   
                            DataTable Cor = Correlativo.ObtenerCantidadStockCorrelativos((int)Session["IdConexion"], "F", Convert.ToInt32(ddlTipoCertificado.SelectedValue), ref mensaje);
                            if (Cor != null && Cor.Rows.Count > 0)
                                cant = Convert.ToInt32(Cor.Rows[0]["existedatos"]);
                            else
                                cant = -99; 

                            if (cant >=Convert.ToInt32(txtCantidad.Text))
                            {
                                if(Correlativo.AdicionarNuevaAsignacion((int)Session["IdConexion"], "I", Convert.ToInt32(ddlOficina.SelectedItem.Value), Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), fasignacion, fenvio, Convert.ToInt32(txtCantidad.Text), txtObservacion.Text, ref mensaje))
                                {  
                                    Master.MensajeOk("Asignacion de Certificados Satisfactoria!!!");
                                    Limpiar();
                                    ListarRegistros();
                                    CargarGrillaStock();
                                }
                                else
                                {
                                    Master.MensajeError(Error, mensaje);
                                }
                            }
                            else
                            {
                                Master.MensajeError(Error, "No existe cantidad disponible para realizar la Asignación");
                            }
                        }
                    }
                    else
                    {
                        string msg = "La Fecha de envío tiene que ser mayor o igual a la fecha de asignación";
                        Master.MensajeError(Error, msg);
                    }
                }
                else
                {
                    Master.MensajeError(Error, "Introduzca la fecha correctamente");
                }

            }

            if (btnAccionar.Text == "Eliminar") // CUANDO EL BOTON ES ELIMINAR
            {
                int Cod, Ver = 0, cont1 = 0;
                Cod = Convert.ToInt32(lblCodigo.Text);
                DataTable Control = Correlativo.VerificarUltimaAsignacion((int)Session["IdConexion"], "G", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedValue), ref mensaje);
                if (Control != null && Control.Rows.Count > 0)
                {
                    cont1 = Convert.ToInt32(Control.Rows[0]["existedatos"]);
                }
                else 
                {
                    cont1 = -99;
                }
                if(cont1==0)
                {
                    Ver = Convert.ToInt32(Correlativo.VerificarCertificadosEmitidos((int)Session["IdConexion"], "H", Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), Convert.ToInt32(txtNumInicial.Text), Convert.ToInt32(txtNumFinal.Text), ref mensaje).Rows[0]["existedatos"]);
                    if (Ver <= 0)
                    {
                        if(Correlativo.EliminarAsignacionCorrelativos((int)Session["IdConexion"], "D", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), (Convert.ToInt32(txtNumFinal.Text) - Convert.ToInt32(txtNumInicial.Text) + 1), ref mensaje))
                        {
                            
                            Master.MensajeOk("Eliminacion de Asignacion Satisfactoria");
                            Limpiar();
                            ListarRegistros();
                            CargarComboTipoCertificado();
                        }
                        else 
                        {
                            Master.MensajeError("Error al realizar la Operacion", mensaje); 
                            Limpiar();
                            ListarRegistros();
                            CargarComboTipoCertificado();
                        }
                        
                    }
                    else //si existen
                    {
                        string msg = "No se puede Eliminar .. Existen Certificados emitidos de este stock!!!";
                        Master.MensajeError(Error, msg);
                        ListarRegistros();
                        CargarComboTipoCertificado();
                    }
                }
                else //si existen mas asignaciones
                {
                    string msg = "No se puede Eliminar .. Existen asignaciones mas adelante y no se puede modificar los iniciales y finales !!!";
                    Master.MensajeError(Error, msg);
                    ListarRegistros();
                    CargarComboTipoCertificado();
                }
            }

            if (btnAccionar.Text == "Modificar") // CUANDO EL BOTON ES MODIFICAR
            {
                int Cod;
                Cod = Convert.ToInt32(lblCodigo.Text);
                if (DateTime.TryParse(txtDate.Text, out fnac))
                   {
                        DateTime fasignacion = Convert.ToDateTime(txtFechaReg.Text);
                        DateTime fenvio = Convert.ToDateTime(txtDate.Text);
                        if (fasignacion <= fenvio)
                        {
                            if (string.IsNullOrEmpty(txtCantidad.Text))
                            {
                                Master.MensajeError(Error, "Debe ingresar la cantidad a ser solicitada");
                            }
                            else
                            {
                            //verificar = Convert.ToInt32(Correlativo.VerificaUltimoNumeroAsignacion((int)Session["IdConexion"], "G", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), ref mensaje).Rows[0]["existedatos"]);
                            DataTable Ver = Correlativo.VerificaUltimoNumeroAsignacion((int)Session["IdConexion"], "G", Cod, Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), ref mensaje);
                            if (Ver != null && Ver.Rows.Count > 0)
                                verificar = Convert.ToInt32(Ver.Rows[0]["existedatos"]);
                            else
                                verificar = -99; 
                            if(verificar==0)
                              {
                                if (Convert.ToInt32(txtCantidad.Text) == Convert.ToInt32(Session["Can"]))
                                {
                                    if(Correlativo.ModificarAsignacionArea((int)Session["IdConexion"], "U", Cod, Convert.ToInt32(ddlOficina.SelectedValue), Convert.ToInt32(ddlTipoCertificado.SelectedValue), fasignacion.ToShortDateString(),fenvio.ToShortDateString(), Convert.ToInt32(txtCantidad.Text), txtObservacion.Text, ref mensaje))
                                    {
                                        Master.MensajeOk ( "Modificacion de la Asignacion Satisfactoria!!!");
                                        Limpiar();
                                        ListarRegistros();
                                        CargarComboTipoCertificado();
                                    }
                                    else 
                                    {
                                        Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
                                        Limpiar();
                                        ListarRegistros();
                                        CargarComboTipoCertificado();
                                    }

                                }
                                else
                                {
                                    if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(Session["Can"]))
                                    {
                                        int num,npedido;
                                        num = Convert.ToInt32(Correlativo.ObtenerSaldoUltimaAsignacion((int)Session["IdConexion"], "J", Convert.ToInt32(txtNumInicial.Text), Convert.ToInt32(ddlTipoCertificado.SelectedValue), ref mensaje).Rows[0]["Saldo"]);
                                        npedido = Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(Session["Can"]);
                                        if (num >= npedido)  // existe stock
                                        {
                                            if(Correlativo.ModificarAsignacionCantMayor((int)Session["IdConexion"], "K", Cod, Convert.ToInt32(ddlOficina.SelectedValue), Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), Convert.ToInt32(txtCantidad.Text), txtObservacion.Text, ref mensaje))
                                            {
                                                Master.MensajeOk("Modificacion de la Asignacion Satisfactoria!!!");
                                                Limpiar();
                                                ListarRegistros();
                                                CargarComboTipoCertificado();
                                            }
                                            else 
                                            {
                                                Master.MensajeError("Ocurrió un problema al querer efectuar la Modificación!!!",mensaje);
                                                Limpiar();
                                                ListarRegistros();
                                                CargarComboTipoCertificado();
                                            }
                                        }
                                        else
                                        {
                                            Master.MensajeError("Ocurrió un problema al querer efectuar la Modificación!!!","La Cantidad no se puede modificar no existe stock suficiente!!!");
                                        }

                                    }
                                    else
                                    {
                                        int num, npedido;
                                        npedido = Convert.ToInt32(Session["Can"]) - Convert.ToInt32(txtCantidad.Text);
                                        num = Convert.ToInt32(txtNumFinal.Text) - Convert.ToInt32(txtNumInicial.Text) + 1;

                                        if (num >= npedido)  // existe stock
                                        {
                                            if(Correlativo.ModificarAsignacionCantMenor((int)Session["IdConexion"], "L", Cod, Convert.ToInt32(ddlOficina.SelectedValue), Convert.ToInt32(ddlTipoCertificado.SelectedItem.Value), Convert.ToInt32(txtCantidad.Text), txtObservacion.Text, ref mensaje))
                                            {
                                                
                                                Master.MensajeOk("Modificacion de la Asignacion Satisfactoria!!!");
                                                Limpiar();
                                                ListarRegistros();
                                                CargarComboTipoCertificado();
                                            }
                                            else
                                            {
                                                Master.MensajeError("Ocurrió un problema al querer efectuar la Modificación!!!",mensaje);
                                                Limpiar();
                                                ListarRegistros();
                                                CargarComboTipoCertificado();
                                            }
                                        }
                                        else
                                        {
                                            string msg = "La Cantidad no se puede modificar no existe stock suficiente!!!";
                                            Master.MensajeError(Error, msg);
                                        }
                                        Master.MensajeOk("Modificacion de la Asignacion Satisfactoria!!!");
                                        Limpiar();
                                        ListarRegistros();
                                        CargarComboTipoCertificado();
                                    }

                                }
                              }
                            else
                            {
                                string msg = "Esta Asignacion no puede ser modificada por que hay registro mas adelante Registrados";
                                Master.MensajeError(Error,msg);
                            }
                            }
                        }

                        else
                        {
                            string msg = "La Fecha de envio tiene que ser mayor o igual a la fecha de asignacion";
                            Master.MensajeError(Error,msg);
                        }
                    }
                   else
                    {
                        string msg = "Introduzca la fecha correctamente";
                        Master.MensajeError(Error, msg);
                    }
               
            }
    }
    #endregion

    #region habilitacionpopup

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
        Master.MensajeCancel();
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de una nueva asignacion de Certificado";
        txtFechaReg.Text = DateTime.Now.ToString("dd/MM/yyyy");

        //imgcalendario.Enabled = true;
        txtDate.Enabled = true;
        ddlTipoCertificado.Enabled = true;
        ddlOficina.Enabled = true;
        txtCantidad.Enabled = true;
        txtCantidad.Visible = true;
        txtNumInicial.Visible = false;
        txtNumFinal.Visible = false;
        lblNumFinal.Visible = false;
        lblNumInicial.Visible = false;
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
    protected void ckAgotado_CheckedChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }
   
    protected void gvCorrelativo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int Estado, UltAplicado,NumFinal,Cantidad,ChkSeleccionado;
            Estado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));
            UltAplicado=Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UltimoNumeroAplicado"));
            NumFinal=Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NumeroFinal"));
            Cantidad=Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
            ChkSeleccionado = Convert.ToInt32(ckAgotado.Checked);
            if (Estado == 1  )
            {
                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgEstado");
                imagen.ImageUrl = "~/Imagenes/16Activo.png";
                if (UltAplicado == NumFinal)
                {
                    e.Row.Cells[0].Text = "STOCK AGOTADO";
                    e.Row.Cells[0].BackColor = Color.Magenta;
                    if (ChkSeleccionado == 0)
                        e.Row.Visible = true;

                }
                else
                {
                    if (UltAplicado > (NumFinal - (Cantidad * 0.10))) 
                    {
                        e.Row.Cells[0].Text = "POCO STOCK";
                        e.Row.Cells[0].BackColor = Color.LightCoral;
                    }
                    else
                    {
                        e.Row.Cells[0].Text = "CON STOCK";
                        e.Row.Cells[0].BackColor = Color.SeaGreen;
                    }
                }
               
            }
            if (Estado == 0)
            {
                e.Row.BackColor = Color.BlueViolet;
                e.Row.ForeColor = Color.Lavender;
                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgEstado");
                imagen.ImageUrl = "~/Imagenes/16Inactivo.png";
                if (UltAplicado == NumFinal)
                {
                    e.Row.Cells[0].Text = "STOCK AGOTADO";
                    e.Row.Cells[0].BackColor = Color.Magenta;
                    if (ChkSeleccionado == 0)
                        e.Row.Visible = true;

                }
                else
                {
                    if (UltAplicado > (NumFinal - (Cantidad * 0.10)))
                    {
                        e.Row.Cells[0].Text = "POCO STOCK";
                        e.Row.Cells[0].BackColor = Color.LightCoral;
                    }
                    else
                    {
                        e.Row.Cells[0].Text = "CON STOCK";
                        e.Row.Cells[0].BackColor = Color.SeaGreen;
                    }
                }    
            }
        }
    }

    #endregion

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCorrelativo.PageIndex = e.NewPageIndex;

        ListarRegistros();
        
    }

    protected void gvCorrelativo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index = Convert.ToInt32(e.CommandArgument);
        string estado;
        string valor;
        int val;
        if (e.CommandName == "cmdEditar")
        {
            GridViewRow row = gvCorrelativo.Rows[Index];
            val = row.RowIndex;
            //valor = gvCorrelativo.Rows[val].Cells[12].Text;
            valor = gvCorrelativo.DataKeys[val].Values["NumeroAsignacion"].ToString();
            lblCodigo.Text = valor;
            Session["can"] = Convert.ToInt32(gvCorrelativo.Rows[val].Cells[5].Text); //Obtiene la cantidad de 
            //Limpiar();
            btnAccionar.Text = "Modificar";
            lblTitulo.Text = "Modificacion de Asignacion de Correlativos";

            //imgcalendario.Enabled = true;
            txtDate.Enabled = true;
            ddlTipoCertificado.Enabled = false;
            ddlOficina.Enabled = true;
            txtCantidad.Visible = true;
            txtNumInicial.Visible = true;
            txtNumFinal.Visible = true;
            txtNumInicial.Enabled = false;
            txtNumFinal.Enabled = false;
            lblNumFinal.Visible = true;
            lblNumInicial.Visible = true;
            txtObservacion.Enabled = true;

            chbEstado.Enabled = false;
            VerDatos();

            estado = Convert.ToString(gvCorrelativo.Rows[val].BackColor);
            if (estado == "Color [Empty]")
                this.pnlDatos_ModalPopupExtender.Show();
            else
                Master.MensajeError(Error, "Este Registro no se puede Modificar");
        }
        else 
        {
            if (e.CommandName == "cmdEliminar") 
            {
                GridViewRow row = gvCorrelativo.Rows[Index];
                val = row.RowIndex;
                //valor = gvCorrelativo.Rows[val].Cells[12].Text;
                valor = gvCorrelativo.DataKeys[val].Values["NumeroAsignacion"].ToString();
                lblCodigo.Text = valor;

                Limpiar();

                btnAccionar.Text = "Eliminar";
                lblTitulo.Text = "Eliminacion de Correlativos Asignados";

                //imgcalendario.Enabled = false;
                txtDate.Enabled = false;
                ddlTipoCertificado.Enabled = false;
                ddlOficina.Enabled = false;
                txtCantidad.Visible = false;
                txtNumInicial.Enabled = false;
                txtNumFinal.Enabled = false;
                lblNumFinal.Visible = true;
                lblNumInicial.Visible = true;
                txtObservacion.Enabled = false;

                chbEstado.Enabled = false;

                VerDatos();
                estado = Convert.ToString(gvCorrelativo.Rows[val].BackColor);
                if (estado == "Color [Empty]")
                    this.pnlDatos_ModalPopupExtender.Show();
                else
                    Master.MensajeError(Error, "Este Registro no se puede Eliminar");
            }
        }
       
    }
}
