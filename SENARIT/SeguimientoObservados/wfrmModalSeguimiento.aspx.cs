
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using wcfObservados.Logica;
using WcfServicioClasificador.Logica;

public partial class SeguimientoObservados_wfrmModalSeguimiento : System.Web.UI.Page
{
    clsSeguimientoObservados Observado = new clsSeguimientoObservados();
    DataTable grilla;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListarRegistros();
        }
    }
    #region cargacombos_datos
        // cargar grilla con datos
        protected void ListarRegistros()
        {
            Int64 tra = Convert.ToInt32(Session["Tramite"]);
            int ben = Convert.ToInt32(Session["beneficio"]);
            clsSeguimientoObservados admi = new clsSeguimientoObservados();
            gvTipo.DataSource = admi.ListarSeguimientoObservados(Convert.ToInt32(Session["Tramite"]), Convert.ToInt32(Session["beneficio"]));
            gvTipo.DataBind();
        }
        // CARGAR TIPO REVISION
        protected void CargarTipoRevision()
        {
            clsServicioClasificador admi = new clsServicioClasificador();
            ddlTipoAccion.DataSource = admi.ListarServicioClasificadorTodo(70);
            ddlTipoAccion.DataValueField = "IdDetalleClasificador";
            ddlTipoAccion.DataTextField = "Descripcion";
            ddlTipoAccion.DataBind();
        }
        // CARGAR GESTIONES
        protected void CargarGestiones()
        {
            ddlGestion.Items.Insert(0,new ListItem("2010","1"));
            ddlGestion.Items.Insert(0,new ListItem("2011","2"));
            ddlGestion.Items.Insert(0,new ListItem("2012","3"));
            ddlGestion.Items.Insert(0,new ListItem("2013","4"));
            ddlGestion.Items.Insert(0,new ListItem("2014","5"));
            ddlGestion.Items.Insert(0,new ListItem("2015","6"));
        }
        //LLENAR DATOS DE LA VENTANA
        protected void VerDatos()
        {
          //  DateTime Cod = Convert.ToDateTime(cod);
            clsSeguimientoObservados tp1 = new clsSeguimientoObservados();
            foreach (clsSeguimientoObservados tp2 in tp1.ObtenerSeguimientoObservados(Convert.ToInt32(lblCodigo1.Text)))
            {
                ddlTipoAccion.SelectedValue = tp2.IdTipoAccion.ToString().Trim();
                txtHojaRuta.Text = tp2.HojaRuta.ToString();
                ddlGestion.DataValueField = tp2.Gestion.ToString();
                txtFojas.Text = tp2.NumeroFojas.ToString();
                txtNombreInteresado.Text = tp2.NombreInteresado.ToString();
                txtObservacion.Text = tp2.TextoObservacion.ToString();
                //if (tp2.RegistroActivo == 1) { chbEstado.Checked = true; }
                //else { chbEstado.Checked = false; }
            }
         }
    #endregion


    #region AccionBotonesCombos

        //BUSCAR DATOS DE CORRESPONDENCIA
        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            int correspondencia=0;
           // clsDatosCorrespondencia tp1 = new clsDatosCorrespondencia();
           // correspondencia = tp1.VerificarTipoCambio_Certificado(Convert.ToInt32(txtHojaRuta.Text),Convert.ToInt32(ddlGestion.SelectedValue));
            if(correspondencia>0)
                {
                lblObser.Text="Datos de Hoja de Ruta";
                }
            else{
                lblObser.Text = "No existe Datos de Hoja de Ruta";
            }

        }
        // ACCIONES DEL BOTON ACCIONAR ADICIONAR, ELIMINAR O MODIFICAR
        protected void btnAccionar_Click(object sender, EventArgs e)
        {
            Int64 tram = Convert.ToInt32(Session["Tramite"]);
            int ben = Convert.ToInt32(Session["beneficio"]);
            int etapa = Convert.ToInt32(Session["etapa"]);
    
            // CUANDO BOTON ES ADICIONAR
            if (btnAccionar.Text == "Adicionar")
            {
                if (txtNombreInteresado.Text == "" || txtObservacion.Text == "")
                {
                    lblObservaciones.Text = "El texto Introducido de algun dato... No es Valido!!!";
                }
                else
                {
                    clsSeguimientoObservados adicionar = new clsSeguimientoObservados();
                    int valor;
                    valor = Convert.ToInt32(ddlTipoAccion.SelectedValue);
                    switch (valor)
                    {
                        case 663:
                         //   adicionar.AdicionarSeguimientoObservados(tram, ben, etapa, txtNombreInteresado.Text, Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), 0, 0, txtObservacion.Text.ToUpper(), 1);
                            break;
                        case 664:
                      //      adicionar.AdicionarSeguimientoObservados(tram, ben, etapa, txtNombreInteresado.Text, Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), 0, Convert.ToInt32(txtFojas.Text), txtObservacion.Text.ToUpper(), 1);
                            break;
                        default:
                      //      adicionar.AdicionarSeguimientoObservados(tram, ben, etapa, txtNombreInteresado.Text, Convert.ToInt32(ddlTipoAccion.SelectedItem.Value), Convert.ToInt32(txtHojaRuta.Text), 0, txtObservacion.Text.ToUpper(), 1);
                            break;
                    }
                    lblObservaciones.Text = "Se adiciono la observacion revision  de forma Satisfactoria";
               }
                Limpiarventana();
                ListarRegistros();
                pnlGV.Visible = true;
                pnlGV.Enabled = true;
                Panelpopup.Visible = false;
            }
            // CUANDO BOTON ES MODIFICAR
            if (btnAccionar.Text == "Modificar")
            {
                if (txtNombreInteresado.Text == "" || txtObservacion.Text == "")
                {
                    lblObservaciones.Text = "El texto Introducido de algun dato... No es Valido!!!";
                }
                else
                {
                    clsSeguimientoObservados modificar = new clsSeguimientoObservados();
                    //modificar.ModificarSeguimientoObservados(Convert.ToInt32(lblCodigo1.Text),tram, ben, txtNombreInteresado.Text, Convert.ToInt32(txtFojas.Text), txtObservacion.Text.ToUpper(), 1);
                    lblObservaciones.Text = "Se modifico la observacion revision  de forma Satisfactoria";     
                }
                Limpiarventana();
                ListarRegistros();
                pnlGV.Visible = true;
                pnlGV.Enabled = true;
                Panelpopup.Visible = false;
            }
            // CUANDO ELIMINA
            if (btnAccionar.Text == "Eliminar")
            {
                clsSeguimientoObservados eliminar = new clsSeguimientoObservados();
                //eliminar.EliminarSeguimientoObservados(Convert.ToInt32(lblCodigo1.Text));
                lblObservaciones.Text = "Se elimino la observacion revision  de forma Satisfactoria";
                Limpiarventana();
                ListarRegistros();
                pnlGV.Visible = true;
                pnlGV.Enabled = true;
                Panelpopup.Visible = false;
            }
        }
        // ACCION PARA EL BOTON CANCELAR
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiarventana();
            pnlGV.Visible = true;
            pnlGV.Enabled = true;
            Panelpopup.Visible = false;
        }
        // ACCION PARA EL COMBO TIPO ACCION
        protected void ddlTipoAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor;
            valor = Convert.ToInt32(ddlTipoAccion.SelectedValue);

            switch (valor)
            {
                case 663:
                    txtHojaRuta.Enabled = false;
                    ddlGestion.Enabled = false;
                    imgBuscar.Enabled = false;
                    txtFojas.Enabled = false;
                    txtDescripcionDoc.Enabled = false;
                    txtNombreInteresado.Enabled = true;
                    break;
                case 664:
                    txtHojaRuta.Enabled = true;
                    ddlGestion.Enabled = true;
                    imgBuscar.Enabled = true;
                    txtFojas.Enabled = true;
                    txtDescripcionDoc.Enabled = true;
                    txtNombreInteresado.Enabled = true;
                    break;
                case 665:
                    txtHojaRuta.Enabled = true;
                    ddlGestion.Enabled = true;
                    imgBuscar.Enabled = true;
                    txtFojas.Enabled = false;
                    txtDescripcionDoc.Enabled = true;
                    txtNombreInteresado.Enabled = true;
                    break;
                case 666:
                    txtHojaRuta.Enabled = true;
                    ddlGestion.Enabled = true;
                    imgBuscar.Enabled = true;
                    txtFojas.Enabled = false;
                    txtDescripcionDoc.Enabled = true;
                    txtNombreInteresado.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        // ACCION DEL BOTON NUEVO REVISION 
        protected void imgNuevoRevision_Click(object sender, ImageClickEventArgs e)
            {
               // Habilita paneles
                Panelpopup.Visible = true;
                pnlGV.Enabled = false;
               // coloca textos
                lblTitulopopup.Text = "ADICION DE REVISIONES";
                btnAccionar.Text = "Adicionar";
               // carga datos
                CargarTipoRevision();
                CargarGestiones();
               //(des)habilita objetos
                txtHojaRuta.Enabled = false;
                ddlGestion.Enabled = false;
                imgBuscar.Enabled = false;
                txtFojas.Enabled = false;
                txtDescripcionDoc.Enabled = false;
            }
   #endregion

    # region EventosGrilla
    // ACCION PARA SELLECIONAR OPCION
    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }
    // 
    protected void gvTipo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int form;
        string accion = e.CommandName.ToUpper();
        int index = Convert.ToInt32(e.CommandArgument);
        this.gvTipo.Rows[index].Cells[0].Visible = true;
        form = Convert.ToInt32(gvTipo.Rows[index].Cells[1].Text); //IdFormulario
        Session["Cod"] = form;
        //this.gvTipo.Rows[index].Cells[3].Visible = false;
        if (accion == "VER")
        {
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("Tramite", Convert.ToString(Session["Tramite"])));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("Matricula", Convert.ToString(Session["Matricula"])));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("Paterno", Convert.ToString(Session["Paterno"])));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("Materno", Convert.ToString(Session["Materno"])));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("PNombre", Convert.ToString(Session["PNombre"])));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("SNombre", Convert.ToString(Session["SNombre"])));
            ReportViewer1.LocalReport.SetParameters(new ReportParameter("TipoTramite", Convert.ToString(Session["TipoTramite"])));

            //Response.Write("<script>");
            //Response.Write("window.open('../Reportes/wfrmReporteFormularioRevision.aspx','_blank')");
            //Response.Write("</script>");
        //    Panel1_ModalPopupExtender();
        }
    }

    protected void gvTipo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            gvTipo.Enabled = true;
            pnlGV.Enabled = true;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));

            if (DEstado == 1)
            {
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Activo.png";
                e.Row.Cells[8].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[8].Controls.Add(hlnk);
                if (rbTipoMuestra.SelectedIndex == 1)
                    e.Row.Visible = false;
            }
        }
    }
    protected void gvTipo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string estado;
        string valor;
        int val;
        // obtiene indice
        GridViewRow row = gvTipo.Rows[e.NewEditIndex];
        val = row.RowIndex;
        valor = gvTipo.Rows[val].Cells[1].Text;
        lblCodigo1.Text = valor;
        // limpia ventana de datos
        Limpiarventana();
        // coloca textos
        lblTitulopopup.Text = "MODIFICACION DE REVISIONES";
        btnAccionar.Text = "Modificar";
        // carga datos
        CargarTipoRevision();
        CargarGestiones();
        VerDatos();
        // (des)habilita objetos
        ddlTipoAccion.Enabled = false;
        txtHojaRuta.Enabled = false;
        ddlGestion.Enabled = false;
        txtNombreInteresado.Enabled = true;
        if (Convert.ToInt32(ddlTipoAccion.SelectedValue)==664)
                        txtFojas.Enabled = true;
        else txtFojas.Enabled = false;
        txtObservacion.Enabled = true;
        estado = Convert.ToString(gvTipo.Rows[val].BackColor);
        if (estado == "Color [Empty]")
        {  // Habilita paneles
            pnlGV.Enabled = false;
            Panelpopup.Visible = true;
        }
        else
            lblObservaciones.Text = "Este Registro no se puede Modificar";

       }
    protected void gvTipo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string estado;
        string valor;
        int val;

        GridViewRow row = gvTipo.Rows[e.RowIndex];
        val = row.RowIndex;
        valor = gvTipo.Rows[val].Cells[1].Text;
        lblCodigo1.Text = valor;

        Limpiarventana();
        lblTitulopopup.Text = "ELIMINACION DE REVISIONES";
        btnAccionar.Text = "Eliminar";
        CargarTipoRevision();
        CargarGestiones();
        VerDatos();
      
        ddlTipoAccion.Enabled = false;
        txtHojaRuta.Enabled = false;
        ddlGestion.Enabled = false;
        txtFojas.Enabled = false;
        txtNombreInteresado.Enabled = false;
        txtObservacion.Enabled = false;

        estado = Convert.ToString(gvTipo.Rows[val].BackColor);
        if (estado == "Color [Empty]")
        {    // Habilita paneles
            pnlGV.Enabled = false;
            Panelpopup.Visible = true;
        }
        else
            lblObservaciones.Text = "Este Registro no se puede Eliminar";
    }
    protected void gvTipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTipo.PageIndex = e.NewPageIndex;
        ListarRegistros();
    }
    // LIMPIA LOS REGISTROS 
    protected void Limpiarventana()
    {
        txtHojaRuta.Text = "";
        txtFojas.Text = "";
        txtNombreInteresado.Text = "";
        txtDescripcionDoc.Text = "";
        txtObservacion.Text = "";
    }
    #endregion


    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
}