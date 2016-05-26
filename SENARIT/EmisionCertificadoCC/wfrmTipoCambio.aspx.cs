
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wcfEmisionCertificadoCC.Logica;
using WcfServicioClasificador.Logica;
public partial class EmisionCertificadoCC_wfrmTipoCambio : System.Web.UI.Page
{
    clsTipoCambio Resolucion = new clsTipoCambio();
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
            int a = Convert.ToInt32(rbTipoMuestra.SelectedValue);
            CargarComboMoneda();
            ListarRegistros(a);
        }
    }
    
    // LISTA LOS REGISTROS Y COLOCA EN GRILLA
    protected void ListarRegistros(int seleccion)
    {
         gvTipo.DataSource = Resolucion.ListarTiposdeCambios((int)Session["IdConexion"], "A",seleccion, ref mensaje);
         gvTipo.DataBind();
        if(gvTipo.Rows.Count>0 && gvTipo.DataSource != null)
        {
        }
        else
        {
            Master.MensajeError("Error al realizar la Operacion",mensaje);
        }
    }
    // LIMPIA LOS REGISTROS 
    protected void Limpiarventana()
    {
        txtResolucion.Text = "";
        txtTasaCambio.Text = "";
        txtDate.Text = "";
        chbEstado.Checked = true;
    }
    // CARGAR COMBO MONEDA
    protected void CargarComboMoneda()
    {
            ddlMoneda.DataSource = Resolucion.ListarTiposMoneda((int)Session["IdConexion"], "B", ref mensaje);
            ddlMoneda.DataValueField = "IdDetalleClasificador";
            ddlMoneda.DataTextField = "Descripcion";
            ddlMoneda.DataBind();
            if(ddlMoneda.DataSource != null && ddlMoneda.Items.Count>0)
            {
            }
            else
            {
               Master.MensajeError("Error al realizar la Operacion",mensaje);
            }
    }

    //RECUPERA LOS DATOS PARA VERLOS
    private void VerDatos(int Index)
    {
        //Nueva Estructura
        DataTable TipoResolucion = Resolucion.ObtieneDatosResolucion((int)Session["IdConexion"], "C", lblFechaR.Text, ref mensaje);
        if (TipoResolucion != null && TipoResolucion.Rows.Count > 0)
        {
            ddlMoneda.SelectedValue = TipoResolucion.Rows[Index]["IdMoneda"].ToString();
            txtResolucion.Text = TipoResolucion.Rows[Index]["Descripcion"].ToString();
            lblFechaRes.Text = TipoResolucion.Rows[Index]["Fecha"].ToString();
            txtFechaCom.Text = lblFechaRes.Text;
            txtPeriodo.Text = TipoResolucion.Rows[Index]["Periodo"].ToString();
            txtDate.Text = TipoResolucion.Rows[Index]["FechaResolucion"].ToString();
            txtTasaCambio.Text = TipoResolucion.Rows[Index]["TasaCambio"].ToString();
            if (Convert.ToInt32(TipoResolucion.Rows[Index]["RegistroActivo"]) == 1)
                chbEstado.Checked = true;
            else
                chbEstado.Checked = false;
        }

        else
        {
            Master.MensajeError("Error al realizar la Operacion", mensaje);
        }
    }

    # region botonespopup

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiarventana();
        ListarRegistros(2);
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        float dec;
        int valorverificar=0,f=0,t=0;
       
        DateTime fnac;

        if (DateTime.TryParse(txtDate.Text, out fnac)) { f = 1; }
        else { f = 0; }

        if (float.TryParse(txtTasaCambio.Text, out dec))
        {
            t = 1;
        }
        else { t = 0; }


        if (btnAccionar.Text == "Adicionar")
        {
            if (txtResolucion.Text != "" && f==1 && t==1)
            {
                 // VERIFICA EL TIPO DE CAMBIO DEL PERIODO QUE CORRESPONDE.
                string mes;
                mes=DateTime.Now.ToString("MMMM").ToUpper();
                clsTipoCambio tp1 = new clsTipoCambio();
                if(mes=="ENERO")
                {
                    valorverificar = Convert.ToInt32(Resolucion.VerificaResolucionTipoCambio((int)Session["IdConexion"], "H", txtFechaCom.Text, txtResolucion.Text, Convert.ToInt32(ddlMoneda.SelectedValue), ref mensaje).Rows[0]["existedatos"]);
                }
                else
                {
                    valorverificar = Convert.ToInt32(Resolucion.VerificaResolucionTipoCambio((int)Session["IdConexion"], "H", txtFechaCom.Text, txtResolucion.Text, Convert.ToInt32(ddlMoneda.SelectedValue), ref mensaje).Rows[0]["existedatos"]);
                }
                            
                if (valorverificar == 0) // si no existen datos para ese periodo
                {
                     if(Resolucion.AdcionaResolucionTipoCambio((int)Session["IdConexion"], "I", txtFechaCom.Text, Convert.ToInt32(ddlMoneda.SelectedValue), txtTasaCambio.Text, txtDate.Text, txtResolucion.Text, ref mensaje))
                     {
                        Master.MensajeOk("Se adiciono el Tipo de Cambio de forma Satisfactoria");
                        Limpiarventana();
                        ListarRegistros(2);
                     }
                     else 
                     {
                        Master.MensajeError("Error al realizar la Operacion",mensaje);
                        Limpiarventana();
                        ListarRegistros(2);
                     }
                }
                else
                {
                    Master.MensajeError("Error al realizar la operación", "Ya existen datos para ese Periodo de Cotización");
                    //lblObservaciones.Text = "El Tipo de Cambio para este mes... ya esta Registrado";
                }
            }
            else
            {
                Master.MensajeError("Error al realizar la Operación","La Descripcion de algun dato... No es Válido!!!");
                //lblObservaciones.Text = "La Descripcion de algun dato... No es Válido!!!";
            }
        }
        if (btnAccionar.Text == "Modificar") // CUANDO EL BOTON ES Modificar
        {
            // VERIFICA SI EL TIPO DE CAMBIO SE UTILIZADO EN ALGUN CERTIFICADO EMITIDO
           int nro_cert=0;
           int mes;
            mes = Convert.ToDateTime(lblFechaRes.Text).Month;
           clsTipoCambio tp1 = new clsTipoCambio();
           if (mes == 12)
           {
               nro_cert = Convert.ToInt32(Resolucion.VerificaCertificadosEmitidos((int)Session["IdConexion"], "E", Convert.ToDateTime(lblFechaRes.Text).AddMonths(-11).AddYears(1).ToShortDateString(), ref mensaje).Rows[0]["existedatos"]);
           }
           else
           {
               nro_cert = Convert.ToInt32(Resolucion.VerificaCertificadosEmitidos((int)Session["IdConexion"], "E", Convert.ToDateTime(lblFechaRes.Text).AddMonths(-11).AddYears(1).ToShortDateString(), ref mensaje).Rows[0]["existedatos"]);
           }

           if (nro_cert <= 0) // si no existen 
           {
               if(Resolucion.ActualizaCambioXresolucion((int)Session["IdConexion"], "F", lblFechaRes.Text, Convert.ToInt32(ddlMoneda.SelectedValue), txtResolucion.Text, txtDate.Text, txtTasaCambio.Text, ref mensaje))
               {
                   Master.MensajeOk("Modificacion  de Tipo de Cambio Satisfactoria");
                   Limpiarventana();
                   ListarRegistros(2);
               }
               else
               {
                   Master.MensajeError("Error al intentar realizar modificaciones",mensaje);
                   Limpiarventana();
                   ListarRegistros(2);
               }
               
           }
           else //si existen
           {
               string msg = "No se puede Modificar .. Existen Certificados emitidos con este tipo de Cambio!!!";
               Master.MensajeError("Error al realizar la Operación", msg);
               ListarRegistros(2);
           }
        }
 
 }
    #endregion
    
    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        DateTime aux2,aux3;
        Limpiarventana();
        btnAccionar.Text = "Adicionar";
        lblTitulo.Text = "Adicion de Tipo de cambio";
        lblRespuesta.Visible = false;
        txtResolucion.Text="";
        //lblFechaRes.Text=Convert.ToString( DateTime.Now.ToString("dd/MM/yyyy"));
        lblFechaRes.Text = Resolucion.FechaMesAnterior((int)Session["IdConexion"], "G", ref mensaje).Rows[0]["Fecha"].ToString();
        txtFechaCom.Text = lblFechaRes.Text;
        aux2 = Convert.ToDateTime(lblFechaRes.Text);
        aux3= aux2.AddMonths(-1);
        txtPeriodo.Text = Convert.ToString(aux3).Substring(3,7);
       // txtDate.Text = "";
        txtTasaCambio.Text = "";
    //    txtResolu.Text = Convert.ToString(DateTime.Now.ToString("yyyy"));
        CargarComboMoneda();
        ddlMoneda.SelectedValue = "327"; //Codigo de Detalle de solo dolares////
        ddlMoneda.Enabled = false;
        txtPeriodo.Enabled = false;
        txtResolucion.Enabled = true;
        txtDate.Enabled = true;
        txtTasaCambio.Enabled = true;
        //imgcalendario.Enabled = true;
        chbEstado.Enabled = false;
        this.pnlDatos_ModalPopupExtender.Show();
    }
    #endregion

    # region eventos

    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selected = Convert.ToInt32(rbTipoMuestra.SelectedValue);
        ListarRegistros(selected);
    }

   protected void gvTipo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));

            int Index = e.Row.RowIndex;
            if(Index != 0)
                e.Row.FindControl("imgEditar").Visible = false;
        }
    }
    #endregion

    protected void gvTipo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEditar") 
        { 
            int Index = Convert.ToInt32(e.CommandArgument);
            string valor;
            int val;
            GridViewRow row = gvTipo.Rows[Index];
            val = row.RowIndex;
            valor = gvTipo.Rows[val].Cells[4].Text;
            lblFechaR.Text = valor;

            Limpiarventana();

            btnAccionar.Text = "Modificar";
            lblTitulo.Text = "Modificacion de Tipo de Cambio ";

            ddlMoneda.Enabled = false;
            txtPeriodo.Enabled = false;

            txtResolucion.Enabled = true;
            //imgcalendario.Enabled = true;
            txtDate.Enabled = true;
            //txtResolu.Visible = false;
            txtTasaCambio.Enabled = true;
            chbEstado.Enabled = false;
            VerDatos(Index);
            this.pnlDatos_ModalPopupExtender.Show();
        }
    }
    //12-06-215 Verifica si existe la Resolucion a ser registrada
    protected void txtResolucion_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Resolucion.VerificaResolucion((int)Session["IdConexion"], "Z", txtResolucion.Text, ref mensaje).Rows[0]["existedatos"]) > 0)
        {
            lblRespuesta.Text = "Ya existe la Resolucion, cambie el número";
            lblRespuesta.Visible = true;
            lblRespuesta.ForeColor = Color.Red;
            this.pnlDatos_ModalPopupExtender.Show();
        }
        else 
        {
            lblRespuesta.Text = "Nueva Resolución";
            lblRespuesta.Visible = true;
            lblRespuesta.ForeColor = Color.Green;
            this.pnlDatos_ModalPopupExtender.Show();
        }

    }
    protected void gvTipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipo.PageIndex = e.NewPageIndex;
        ListarRegistros(2);
    }
}