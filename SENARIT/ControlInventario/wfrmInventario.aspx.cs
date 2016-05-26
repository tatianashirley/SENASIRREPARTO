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
using System.Web.UI.HtmlControls;
using wfcInventario.Logica;

public partial class ControlInventario_Inventario : System.Web.UI.Page
{
    DataTable Encontrados = null;
    string mensaje = null;
    clsLogicaI info = new clsLogicaI();
    protected void Page_Load(object sender, EventArgs e)
    {
        //carga_combo();
       if (!Page.IsPostBack)
        {
            gvUbicacion.Visible = true;
            gvUbicacion.DataSourceID = null;
            //carga el gridviuw de ubicacion
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Ubicacion", "", "", "", "", "", "", "", 0, 0, 0, 0, ref mensaje);
            gvUbicacion.DataSource = Encontrados;
            gvUbicacion.DataBind();
            carga_combo();
            CrearTablas();
            CambiarInterfaz();
            btnGrupoFamiliar.Enabled = false;
        }
    }

    protected void carga_combo() 
    {
        //droplist de las naves
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Nave", "", "", "", "", "", "", "", 0, 0, 0, 0,
        ref mensaje);

        ddlNave1.DataSource = Encontrados;
        ddlNave1.DataValueField = "Nave";
        ddlNave1.DataTextField = "Nave";
        ddlNave1.DataBind();

        ddlnave.DataSource = Encontrados;
        ddlnave.DataValueField = "Nave";
        ddlnave.DataTextField = "Nave";
        ddlnave.DataBind();

        ddlnave2.DataSource = Encontrados;
        ddlnave2.DataValueField = "Nave";
        ddlnave2.DataTextField = "Nave";
        ddlnave2.DataBind();

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "BusquedaUsuario", "", "", "", "", "", "", "", 0, 0, 0, 0,
                        ref mensaje);
        ddlUsuario.DataSource = Encontrados;
        ddlUsuario.DataValueField = "IdUsuario";
        ddlUsuario.DataTextField = "CuentaUsuario";
        ddlUsuario.DataBind();

        ddlUsuarioDevolucion.DataSource = Encontrados;
        ddlUsuarioDevolucion.DataValueField = "IdUsuario";
        ddlUsuarioDevolucion.DataTextField = "CuentaUsuario";
        ddlUsuarioDevolucion.DataBind();

        
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gvBusqueda.Visible = true;
        gvBusqueda.DataSourceID = null;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"],"Q","PersonaR", txtPrimerApellido.Text, txtSegundoApellido.Text,
        txtNombres1.Text, txtCI.Text, txtMatricula.Text, txtNroTramite.Text, "", 0, 0, 0, 0, ref mensaje);
       
        gvBusqueda.DataSource = Encontrados;
        gvBusqueda.DataBind();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SENARIT/DoblePercepcion/wfrmBuscarDatosAsegurado.aspx");
        Response.Redirect("wfrmBuscarDatosAsegurado.aspx");
    }
    protected void lnkHistorialArchivo_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.ActiveViewIndex = 0;
    }
    protected void lnkNave_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void lnkCaja_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void lnkListadoInventario_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
    }
    protected void lnkHistorialAsignacion_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
    }
    protected void gvBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        int fila2 = gvBusqueda.SelectedRow.RowIndex;
        string estado = gvBusqueda.DataKeys[fila2].Values["IdBeneficio"].ToString();
        Session["fila"] = fila2;
        Session["IdBeneficio"] = estado;
        CargarSeleccionado(fila2);
    }

    private void CargarSeleccionado(int fila)
     {
        int sw = 0;
        Session["ID"] = Convert.ToInt32(gvBusqueda.DataKeys[fila].Values["IdBeneficio"].ToString());
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "DatosPersona", "", "", "", "", gvBusqueda.SelectedRow.Cells[3].Text, gvBusqueda.SelectedRow.Cells[2].Text, "", 0, 0, 0,
        Convert.ToInt32(gvBusqueda.DataKeys[fila].Values["IdBeneficio"].ToString()), ref mensaje);
        //gvBeneficios.DataKeys[indice].Values["IdBeneficio"].ToString()

        if (Encontrados.Rows.Count != 0)
        {
            txtmatricula1.Text = Encontrados.Rows[0][0].ToString();
            txttramite.Text = Encontrados.Rows[0][1].ToString();
            txtCarnet.Text = Encontrados.Rows[0][2].ToString();
            txtFuncionario.Text = Encontrados.Rows[0][3].ToString();
            txtFechaIngreso.Text = Encontrados.Rows[0][4].ToString();
            txtExpediente.Text = Encontrados.Rows[0][5].ToString();
            txtPaterno.Text = Encontrados.Rows[0][6].ToString();
            txtMaterno.Text = Encontrados.Rows[0][7].ToString();
            txtNombres.Text = Encontrados.Rows[0][8].ToString();
            txtDpto.Text = Encontrados.Rows[0][9].ToString();
            txtRegional.Text = Encontrados.Rows[0][10].ToString();
            txtRegimen.Text = Encontrados.Rows[0][11].ToString();
            txtSector.Text = Encontrados.Rows[0][12].ToString();
            txtClaseRenta.Text = Encontrados.Rows[0][13].ToString();
            Session["Beneficio"] = Convert.ToInt32(gvBusqueda.DataKeys[fila].Values["IdBeneficio"].ToString());
            btnGrupoFamiliar.Enabled = true;

        }
        else
        {
            txtmatricula1.Text = "";
            txttramite.Text ="";
            txtCarnet.Text = "";
            txtFuncionario.Text = "";
            txtFechaIngreso.Text = "";
            txtExpediente.Text ="";
            txtPaterno.Text ="";
            txtMaterno.Text = "";
            txtNombres.Text = "";
            txtDpto.Text ="";
            txtRegional.Text = "";
            txtRegimen.Text = "";
            btnGrupoFamiliar.Enabled = false;
        }

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "UExpediente", "", "", "", "", gvBusqueda.SelectedRow.Cells[3].Text, gvBusqueda.SelectedRow.Cells[2].Text, "", 0, 0, 0, 0, ref mensaje);
         
        //  Encontrados = info.ObtieneDatos((int)Session["IdConexion"],"Q","UExpediente","","","","",txtmatricula1.Text,
        //  txttramite.Text, "", 0, 0, 0, 0, ref mensaje);

        if (Encontrados != null &&  Encontrados.Rows.Count != 0)
        {
            ddlNave1.SelectedValue = Encontrados.Rows[0][0].ToString();
            ddlNave1.Enabled = false;
            txtEstante1.Text = Encontrados.Rows[0][1].ToString();
            txtEstante1.Enabled = false;
            txtCodigoCaja1.Text = Encontrados.Rows[0][2].ToString();
            txtCodigoCaja1.Enabled = false;
            txtCodigoCajaAnterior.Text = Encontrados.Rows[0][3].ToString();
            txtCodigoCajaAnterior.Enabled = false;
            txtCodigoDigitalizacion.Text = Encontrados.Rows[0][4].ToString();
            txtCodigoDigitalizacion.Enabled = false;
            txtTipoObservacion.Text = Encontrados.Rows[0][5].ToString();
            txtTipoObservacion.Enabled = false;
            txtObservacion.Text = Encontrados.Rows[0][6].ToString();
            txtObservacion.Enabled = false;
            btnGuardarUbicacion.Enabled = false;
           
        }
        else
        {
            if (txtExpediente.Text == "CONFIRMADO")
            {
                sw = 1;
                ddlNave1.SelectedValue = "1";
                ddlNave1.Enabled = true;
                txtEstante1.Text = "";
                txtEstante1.Enabled = true;
                txtCodigoCaja1.Text = "";
                txtCodigoCaja1.Enabled = true;
                txtCodigoCajaAnterior.Text = "";
                txtCodigoCajaAnterior.Enabled = true;
                txtCodigoDigitalizacion.Text = "";
                txtCodigoDigitalizacion.Enabled = true;
                txtTipoObservacion.Text = "";
                txtTipoObservacion.Enabled = true;
                txtObservacion.Text = "";
                txtObservacion.Enabled = true;
                btnGuardarUbicacion.Enabled = true;
                btnModificaUbicacion.Enabled = false;
                btnReUbicacion.Enabled = false;
                txtCodigoCaja1.ForeColor = Color.Black;
                txtCodigoCaja1.BackColor = Color.White;
                txtEstante1.ForeColor = Color.Black;
                txtEstante1.BackColor = Color.White;
            }
            else
            {
                sw = 1;
                ddlNave1.SelectedValue = "1";
                ddlNave1.Enabled = false;
                txtEstante1.Text = "";
                txtEstante1.Enabled = false;
                txtCodigoCaja1.Text = "";
                txtCodigoCaja1.Enabled = false;
                txtCodigoCajaAnterior.Text = "";
                txtCodigoCajaAnterior.Enabled = false;
                txtCodigoDigitalizacion.Text = "";
                txtCodigoDigitalizacion.Enabled = false;
                txtTipoObservacion.Text = "";
                txtTipoObservacion.Enabled = false;
                txtObservacion.Text = "";
                txtObservacion.Enabled = false;
                btnGuardarUbicacion.Enabled = false;
                btnModificaUbicacion.Enabled = false;
                btnReUbicacion.Enabled = false;
                txtCodigoCaja1.ForeColor = Color.Black;
                txtCodigoCaja1.BackColor = Color.White;
                txtEstante1.ForeColor = Color.Black;
                txtEstante1.BackColor = Color.White;
            }
        }

        gvHistorial.Visible = true;
        gvHistorial.DataSourceID = null;

        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TramiteHistorial","", "", "", "",
        gvBusqueda.SelectedRow.Cells[3].Text, gvBusqueda.SelectedRow.Cells[2].Text, "", 0, 0, 0, 0,
          ref mensaje);

        gvHistorial.DataSource = Encontrados;
        gvHistorial.DataBind();

        gvGrupo.Visible = true;
        gvGrupo.DataSourceID = null;

        if (Encontrados!=null)
        {
            if (Encontrados.Rows.Count != 0 && sw == 0)
            {

                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Caja",
                    "", "", "", "", "", "", "", 0, Convert.ToInt32(ddlNave1.SelectedValue),
                    Convert.ToInt32(txtEstante1.Text)
                    , Convert.ToInt32(txtCodigoCaja1.Text),
                    ref mensaje);
                gvGrupo.DataSource = Encontrados;
                gvGrupo.DataBind();
            }
            else 
            {
                gvGrupo.DataSource = null;
                gvGrupo.DataBind();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        gvHistorialAsignacion.Visible = true;
        gvHistorialAsignacion.DataSourceID = null;

        if (Encontrados !=null)
        {
            if (Encontrados.Rows.Count != 0 && sw == 0)
            {

                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Asignacion",
                    "", "", "", "", txtmatricula1.Text, txttramite.Text, "", 0, 0,
                    0, 0, ref mensaje);
                gvHistorialAsignacion.DataSource = Encontrados;
                gvHistorialAsignacion.DataBind();
            }
            else 
            {
                gvHistorialAsignacion.DataSource = null;
                gvHistorialAsignacion.DataBind();
            }
         }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
    protected void btnGuardarUbicacion_Click(object sender, EventArgs e)
    {
        mensaje = null;
        if (txtCodigoDigitalizacion.Text =="")
        {
            txtCodigoDigitalizacion.Text = "0";
        }

        if (ValidarDatos(Convert.ToInt32(ddlNave1.SelectedValue), Convert.ToInt32(txtEstante1.Text), Convert.ToInt32(txtCodigoCaja1.Text)))
        {
            int jj = (int)Session["IdConexion"];
            string jjj = Convert.ToString((int)Session["Beneficio"]);
            info.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToString((int)Session["Beneficio"]), txttramite.Text, 0, txtmatricula1.Text,
                Convert.ToInt16(ddlNave1.SelectedValue), Convert.ToInt16(txtEstante1.Text), Convert.ToInt16(txtCodigoCaja1.Text),
                txtCodigoCajaAnterior.Text, Convert.ToInt32(txtCodigoDigitalizacion.Text),
                txtObservacion.Text, ref mensaje);

            if (mensaje == null)
            {
                ddlNave1.Enabled = false;
                txtEstante1.Enabled = false;
                txtCodigoCaja1.Enabled = false;
                txtCodigoCajaAnterior.Enabled = false;
                txtCodigoDigitalizacion.Enabled = false;
                txtTipoObservacion.Enabled = false;
                txtObservacion.Enabled = false;
                Master.MensajeOk("SE INSERTO CORRECTAMENTO LA UBICACION DEL EXPEDIENTE");
                CargarSeleccionado((int)Session["fila"]);
                btnGuardarUbicacion.Enabled = false;
            }
            else
            {
                Master.MensajeError("ERROR AL GUARDAR LA UBICACION DEL EXPEDIENTE PORFAVOR INTENTE DE NUEVO", mensaje);
            }
        }
        else
        {
            Master.MensajeError("ERROR AL GUARDAR LA UBICACION DEL EXPEDIENTE PORFAVOR INTENTE DE NUEVO", mensaje);
        }
    }
    protected void btnModificaUbicacion_Click(object sender, EventArgs e)
    {
        if (btnModificaUbicacion.Text.StartsWith("Modifica Ubicacion"))
        {
            ddlNave1.Enabled = false;
            txtEstante1.Enabled = true;
            txtCodigoCaja1.Enabled = true;
            txtCodigoCajaAnterior.Enabled = true;
            txtCodigoDigitalizacion.Enabled = true;
            txtTipoObservacion.Enabled = true;
            txtObservacion.Enabled = true;
            btnModificaUbicacion.Text = "Modificar Ubicacion";
            btnReUbicacion.Enabled = false;
        }
        else
        {
            if (txtCodigoDigitalizacion.Text == "")
            {
                txtCodigoDigitalizacion.Text = "0";
            }

            if (ValidarDatos(Convert.ToInt32(ddlNave1.SelectedValue), Convert.ToInt32(txtEstante1.Text), Convert.ToInt32(txtCodigoCaja1.Text)))
            {
                info.ModificaRegistro(
                (int)Session["IdConexion"], "U",
                Convert.ToInt16(ddlNave1.SelectedValue), Convert.ToInt16(txtEstante1.Text), Convert.ToInt16(txtCodigoCaja1.Text),
                (txttramite.Text), txtmatricula1.Text,txtCodigoCajaAnterior.Text, Convert.ToInt32(txtCodigoDigitalizacion.Text), 
                txtObservacion.Text, ref mensaje);
                
                btnModificaUbicacion.Text = "Modifica Ubicacion";
                txtEstante1.Enabled = false;
                txtCodigoCaja1.Enabled = false;
                txtCodigoCajaAnterior.Enabled = false;
                txtCodigoDigitalizacion.Enabled = false;
                txtTipoObservacion.Enabled = false;
                txtObservacion.Enabled = false;

                if (mensaje == null)
                {
                    txtEstante1.Enabled = false;
                    txtCodigoCaja1.Enabled = false;
                    txtCodigoCajaAnterior.Enabled = false;
                    txtCodigoDigitalizacion.Enabled = false;
                    txtTipoObservacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    Master.MensajeOk("SE REGISTRO DE FORMA CORRECTA LA MODIFICACION DE LA UBICACION DEL EXPEDIENTE");
                    btnReUbicacion.Enabled = true;
                    CargarSeleccionado((int)Session["fila"]);
                }

                else
                {
                    txtEstante1.Enabled = true;
                    txtCodigoCaja1.Enabled = true;
                    txtCodigoCajaAnterior.Enabled = true;
                    txtCodigoDigitalizacion.Enabled = true;
                    txtTipoObservacion.Enabled = true;
                    txtObservacion.Enabled = true;
                    btnModificaUbicacion.Text = "Modificar Ubicacion";
                    Master.MensajeError("ERROR AL REGISTRAR LA REHUBICACION DEL ARCHIVO", mensaje);
                }
            }
            else
            {
                txtEstante1.Enabled = true;
                txtCodigoCaja1.Enabled = true;
                txtCodigoCajaAnterior.Enabled = true;
                txtCodigoDigitalizacion.Enabled = true;
                txtTipoObservacion.Enabled = true;
                txtObservacion.Enabled = true;
                btnModificaUbicacion.Text = "Modificar Ubicacion";
                Master.MensajeError("ERROR AL REGISTRAR LA REHUBICACION DEL ARCHIVO", "Porfavor los parametros del Estante y Numero de Caja");
            }
        }
    }

    protected void btnLimpiar_Click1(object sender, EventArgs e)
    {
            Response.Redirect("wfrmInventario.aspx");
    }
    protected void btnReporte_Click(object sender, EventArgs e)
    {
        int h = Convert.ToInt32(ddlnave.SelectedValue);
        int minE = Convert.ToInt32(gvUbicacion.Rows[h -1].Cells[1].Text);
        int maxE = Convert.ToInt32(gvUbicacion.Rows[h -1].Cells[2].Text);
        int minC = Convert.ToInt32(gvUbicacion.Rows[h -1].Cells[3].Text);
        int maxC = Convert.ToInt32(gvUbicacion.Rows[h -1].Cells[4].Text);
        

        int sw = 0;
        if (Convert.ToInt32(txtEstante.Text) < minE || Convert.ToInt32(txtEstante.Text) >maxE)
        {
            sw = 1;
            Master.MensajeError("Error al generar el reporte", "El codigo de estante esta fuera de rango porfavor revise la tabla de parametros gracias.");
        }

        if (Convert.ToInt32(txtCodigoCaja.Text) <= minC || Convert.ToInt32(txtCodigoCaja.Text) >= maxC)
        {
            sw = 1;
            Master.MensajeError("Error al generar el reporte", "El codigo de caja esta fuera de rango porfavor revise la tabla de parametros gracias.");
        }

        if (sw == 0)
        {
            Session["id"] = txtCodigoCaja.Text;
            Session["estante"] = txtEstante.Text;
            Session["nave"] = (ddlnave.SelectedValue);

            // Response.Redirect("wfrmReportePlanPagos.aspx");
            Session["informe"] = "rptConvenioDeposito";
            string script = "window.open('wfrmreporte.aspx', '');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
            Master.MensajeOk("El reporte se genero de manera correcta");
        }
    }

    protected void btnOpenCloseResultado_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlResultado.Visible == false)
        {
            btnOpenCloseResultado.ImageUrl = "~/Imagenes/16quitar.png";
            pnlResultado.Visible = true;
        }
        else
        {
            btnOpenCloseResultado.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlResultado.Visible = false;
        }
    }

    protected void btnOpenCloseDatos_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlDatosUbicacion.Visible == false)
        {
            btnOpenCloseDatos.ImageUrl = "~/Imagenes/16quitar.png";
            pnlDatosUbicacion.Visible = true;
        }
        else
        {
            btnOpenCloseDatos.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlDatosUbicacion.Visible = false;
        }
    }

    protected void btnOpenCloseBusqueda_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlBusqueda.Visible == false)
        {
            btnOpenCloseBusqueda.ImageUrl = "~/Imagenes/16quitar.png";
            pnlBusqueda.Visible = true;
        }
        else
        {
            btnOpenCloseBusqueda.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlBusqueda.Visible = false;
        }
    }

    protected void btnOpenCloseDetalles_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlDetalle.Visible == false)
        {
            btnOpenCloseDetalles.ImageUrl = "~/Imagenes/16quitar.png";
            pnlDetalle.Visible = true;
        }
        else
        {
            btnOpenCloseDetalles.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlDetalle.Visible = false;
        }
    }
    protected void btnOpenCloseCoincidencias_Click(object sender, ImageClickEventArgs e)
    {
        if (pnlCoincidencias.Visible == false)
        {
            btnOpenCloseCoincidencias.ImageUrl = "~/Imagenes/16quitar.png";
            pnlCoincidencias.Visible = true;
        }
        else
        {
            btnOpenCloseCoincidencias.ImageUrl = "~/Imagenes/16adicionar.png";
            pnlCoincidencias.Visible = false;
        }
    }

    protected void btnAsignacionExpediente_Click(object sender, EventArgs e)
    {

        limpiaTablaAsignacion();
        gvAsignacion.Visible=false;
        pnlAsignaExpediente.Width = 600;
        pnlAsignaExpediente.Height = 350;
        this.pnlAsignaExpediente_ModalPopupExtender.Show();
    }

    protected void limpiaTablaAsignacion()
    {
        DataTable Tramite = Session["Tramite"] as DataTable;
        Tramite.Rows.Clear();
        Session["Tramite"] = Tramite;
        gvAsignacion.DataSource = null;
        gvAsignacion.DataBind();
             
    }
    protected void imgMostrarCaja_Click(object sender, ImageClickEventArgs e)
    {
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "BusquedaCaja",
        "", "", "", "", "", "", "", 0, Convert.ToInt32(ddlnave2.SelectedValue),
         Convert.ToInt32(txtEstante2.Text)
        , Convert.ToInt32(txtCaja3.Text),
        ref mensaje);

        gvAsignacion.DataSource = Encontrados;
        gvAsignacion.DataBind();
        gvAsignacion.Visible = true;
        pnlAsignaExpediente.Width = 650;
        pnlAsignaExpediente.Height = 450;
        this.pnlAsignaExpediente_ModalPopupExtender.Show();
        btnAccionarND.Enabled = true;
        
    }
    protected void imgBusquedaTramite_Click(object sender, ImageClickEventArgs e)
    {
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "VerificaAsignacion",
                    "", "", "", "", txtmatricula3.Text, txtNroTramite1.Text, "", 0, 0,
                    0, 0, ref mensaje);
        int sw = 0;
        if (Encontrados != null)
        {
            if (Encontrados.Rows.Count != 0)
            {
                string script = @"<script type='text/javascript'>alert('EL EXPEDIENTE YA SE ENCUENTRA ASIGNADO');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                this.pnlAsignaExpediente_ModalPopupExtender.Show();
                sw = 1;
            }
        }
        
        if(sw==0)
        {
            Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "BusquedaTramite",
              "", "", "", "", txtmatricula3.Text, txtNroTramite1.Text, "", 0, 0,
               0, 0, ref mensaje);
            /*
            gvBusqueda1.DataSource = Encontrados;
            gvBusqueda1.DataBind();
            gvBusqueda1.Visible = true;
            this.pnlAsignaExpediente_ModalPopupExtender.Show();
            */
            DataTable Tramite = Session["Tramite"] as DataTable;
            int NumPer;

            if (gvAsignacion == null)
            {
                NumPer = 1;
            }
            else
            {
                NumPer = gvAsignacion.Rows.Count + 1;
            }
            try
            {
                if (Encontrados.Rows.Count != -1)//agregamos
                {

                    int n = Encontrados.Rows.Count;
                   // string kk = Encontrados.Rows[i][7].ToString();
                    for(int i =0 ; i < Encontrados.Rows.Count ; i++)
                    {
                        Tramite.Rows.Add(NumPer, Encontrados.Rows[i][2].ToString(), Encontrados.Rows[i][12].ToString(), Encontrados.Rows[i][13].ToString(),
                        Encontrados.Rows[i][1].ToString(),Encontrados.Rows[i][3].ToString(),Encontrados.Rows[i][4].ToString(),Encontrados.Rows[i][5].ToString(),
                        Encontrados.Rows[i][7].ToString());
                        NumPer++;

                        /*   Tramite.Columns.Add(new DataColumn("Fila", Type.GetType("System.Int32")));
                            Tramite.Columns.Add(new DataColumn("Asegurado", Type.GetType("System.String")));
                            Tramite.Columns.Add(new DataColumn("Tramite", Type.GetType("System.String")));
                            Tramite.Columns.Add(new DataColumn("Matricula", Type.GetType("System.String")));
                            Tramite.Columns.Add(new DataColumn("Nave", Type.GetType("System.Int32")));
                            Tramite.Columns.Add(new DataColumn("Estante", Type.GetType("System.Int32")));
                            Tramite.Columns.Add(new DataColumn("CodCaja", Type.GetType("System.Int32")));
                            Tramite.Columns.Add(new DataColumn("CodCajaHist", Type.GetType("System.String")));
                            Tramite.Columns.Add(new DataColumn("Estado", Type.GetType("System.String")));
                            */ 
                    }
                    //cargar la gv
                    gvAsignacion.Visible = true;
                    gvAsignacion.DataSourceID = null;
                    gvAsignacion.DataSource = Tramite;
                    gvAsignacion.DataBind();
                    Session["Tramite"] = Tramite;
                    txtNroTramite1.Text = "";
                    txtmatricula3.Text = "";
                    pnlAsignaExpediente.Height = 450;
                    btnAccionarND.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error Buscar el Tramite", ex.Message);
            }
            this.pnlAsignaExpediente_ModalPopupExtender.Show();
        }
   }

    private void CrearTablas()
    {
        //crear tabla temp para tipo de Cambio
        DataTable Tramite = new DataTable();
        Tramite.Columns.Add(new DataColumn("Fila", Type.GetType("System.Int32")));
        Tramite.Columns.Add(new DataColumn("Asegurado", Type.GetType("System.String")));
        Tramite.Columns.Add(new DataColumn("Tramite", Type.GetType("System.String")));
        Tramite.Columns.Add(new DataColumn("Matricula", Type.GetType("System.String")));
        Tramite.Columns.Add(new DataColumn("Nave", Type.GetType("System.Int32")));
        Tramite.Columns.Add(new DataColumn("Estante", Type.GetType("System.Int32")));
        Tramite.Columns.Add(new DataColumn("CodCaja", Type.GetType("System.Int32")));
        Tramite.Columns.Add(new DataColumn("CodCajaHist", Type.GetType("System.String")));
        Tramite.Columns.Add(new DataColumn("Estado", Type.GetType("System.String")));
        
        Session["Tramite"] = Tramite;
    }

    protected void btnDevolucionExpediente_Click(object sender, EventArgs e)
    {
        txtInicioAsignacion.Text = "";
        txtFinAsignacion.Text = "";
        pnlDevolucionExpediente.Width = 700;
        pnlDevolucionExpediente.Height = 200;

        limpiaTablaDevolucion();
        mpeDevolucionExpediente.Show();
    }

    protected void btnAceptarDevolucionExpediente_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in gvDevolucionExpediente.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {

                CheckBox chk_Publicar = (CheckBox)row.Cells[7].FindControl("chkEnvio");
                if (chk_Publicar.Checked)
                {
                    if (mensaje == null)
                    {
                        // h = Convert.ToInt32(ddlUsuario.SelectedValue);
                        info.InsertaRegistroDevolucion((int)Session["IdConexion"], "U", Convert.ToInt32(row.Cells[1].Text), ref mensaje);
                    }
                    else
                    {
                        Master.MensajeError("Error al Asignar Documentos", mensaje);
                        break;
                    }
                }
                else {
                    Master.MensajeError("Error al Asignar Documentos", mensaje);
                    break;
                }
            }
        }
        if (mensaje == null)
            Master.MensajeOk("Se inserto de manera correcta los documentos Asignados");

        pnlDevolucionExpediente.Width = 700;
        pnlDevolucionExpediente.Height = 500;
        txtInicioAsignacion.Text = "";
        txtFinAsignacion.Text = "";
        //mpeDevolucionExpediente.Show();
    }

    protected void limpiaTablaDevolucion()
    {
        gvDevolucionExpediente.Visible = false;
        gvDevolucionExpediente.DataSource = null;
        gvDevolucionExpediente.DataBind();
    }

    protected void btnAccionarND_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvAsignacion.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {

                CheckBox chk_Publicar = (CheckBox)row.Cells[7].FindControl("chkEnvio");
                if (chk_Publicar.Checked )
                {
                    if(mensaje==null)
                    {
                        info.InsertaRegistroAsignacion((int)Session["IdConexion"], "I", row.Cells[2].Text, row.Cells[3].Text, Convert.ToInt32(ddlUsuario.SelectedValue), ref mensaje);
                    }
                    else
                    {
                        Master.MensajeError("Error al Asignar Documentos",mensaje);
                        break;
                    }
                 }
                if(mensaje!=null)
                {
                    Master.MensajeError("Error al Asignar Documentos", mensaje);
                    break;
                }
            }
        }
        if (mensaje == null)
            Master.MensajeOk("Se inserto de manera correcta los documentos Asignados");
    }

    protected void img_buscaDevolucion_Click(object sender, ImageClickEventArgs e)
    {
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "BusquedaAsig",
        "", "", "", "", "", "", "", 0, 0,
        0, Convert.ToInt16(ddlUsuarioDevolucion.SelectedValue), ref mensaje);

        gvDevolucionExpediente.Visible = true;
        gvDevolucionExpediente.DataSourceID = null;
        gvDevolucionExpediente.DataSource = Encontrados;
        gvDevolucionExpediente.DataBind();
        pnlDevolucionExpediente.Width = 700;
        pnlDevolucionExpediente.Height = 500;
        txtInicioAsignacion.Text = "";
        txtFinAsignacion.Text = "";
        btnAceptarDevolucionExpediente.Enabled = true;
        mpeDevolucionExpediente.Show();
    }
    protected void btnReUbicacion_Click(object sender, EventArgs e)
    {
        if (btnReUbicacion.Text.StartsWith("Re Ubicacion"))
        {
            ddlNave1.Enabled = true;
            txtEstante1.Enabled = true;
            txtCodigoCaja1.Enabled = true;
            txtCodigoCajaAnterior.Enabled = true;
            txtCodigoDigitalizacion.Enabled = true;
            txtTipoObservacion.Enabled = true;
            txtObservacion.Enabled = true;
            btnModificaUbicacion.Enabled = false;
            btnReUbicacion.Text = "Guardar Re Ubicacion";
        }
        else
        {

            if (ValidarDatos(Convert.ToInt32(ddlNave1.SelectedValue), Convert.ToInt32(txtEstante1.Text), Convert.ToInt32(txtCodigoCaja1.Text)))
            {
                if (txtCodigoDigitalizacion.Text == "")
                {
                    txtCodigoDigitalizacion.Text = "0";
                }
                info.RehubicacionRegistro((int)Session["IdConexion"], "U",
                Convert.ToInt16(ddlNave1.SelectedValue), Convert.ToInt16(txtEstante1.Text), Convert.ToInt16(txtCodigoCaja1.Text),
                (txttramite.Text), txtmatricula1.Text, txtCodigoCajaAnterior.Text, Convert.ToInt32(txtCodigoDigitalizacion.Text), txtObservacion.Text,
                (string)Session["IdBeneficio"], ref mensaje);

                if (mensaje == null)
                {
                    btnReUbicacion.Text = "Re Ubicacion";
                    ddlNave1.Enabled = false;
                    txtEstante1.Enabled = false;
                    txtCodigoCaja1.Enabled = false;
                    txtCodigoCajaAnterior.Enabled = false;
                    txtCodigoDigitalizacion.Enabled = false;
                    txtTipoObservacion.Enabled = false;
                    txtObservacion.Enabled = false;
                    btnModificaUbicacion.Enabled = true;
                    Master.MensajeOk("SE REGISTRO CORRECTAMENTE LA REHUBICACION DEL ARCHIVO");
                    CargarSeleccionado((int)Session["fila"]);
                }
                else
                {
                    ddlNave1.Enabled = true;
                    txtEstante1.Enabled = true;
                    txtCodigoCaja1.Enabled = true;
                    txtCodigoCajaAnterior.Enabled = true;
                    txtCodigoDigitalizacion.Enabled = true;
                    txtTipoObservacion.Enabled = true;
                    txtObservacion.Enabled = true;
                    btnReUbicacion.Text = "Guardar Re Ubicacion";
                    btnModificaUbicacion.Enabled = false;
                    Master.MensajeError("ERROR AL REGISTRAR LA REHUBICACION DEL ARCHIVO", mensaje);
                }
            }
            else
            {
                ddlNave1.Enabled = true;
                txtEstante1.Enabled = true;
                txtCodigoCaja1.Enabled = true;
                txtCodigoCajaAnterior.Enabled = true;
                txtCodigoDigitalizacion.Enabled = true;
                txtTipoObservacion.Enabled = true;
                txtObservacion.Enabled = true;
                btnReUbicacion.Text = "Guardar Re Ubicacion";
                Master.MensajeError("ERROR AL REGISTRAR LA REHUBICACION DEL ARCHIVO", "Porfavor los parametros del Estante y Numero de Caja");
            }
        }
    }

    protected bool ValidarDatos(int nave,int estante, int caja)
    {
        int nave1 = nave-1;
        int sw=0;
        int minE = Convert.ToInt32(gvUbicacion.Rows[nave1].Cells[1].Text);
        int maxE = Convert.ToInt32(gvUbicacion.Rows[nave1].Cells[2].Text);
        int minC = Convert.ToInt32(gvUbicacion.Rows[nave1].Cells[3].Text);
        int maxC = Convert.ToInt32(gvUbicacion.Rows[nave1].Cells[4].Text);
        /********************************************************************************************/
                                            //Valida la Estante

        if (estante <= minE || estante >= maxE)
        {
            Master.MensajeError("Error al generar el reporte", "El codigo de estante esta fuera de rango porfavor revise la tabla de parametros gracias.");
            txtEstante1.ForeColor = Color.White;
            txtEstante1.BackColor = Color.Red;
            sw = 1;
        }
        else 
        {
            txtEstante1.ForeColor = Color.Black;
            txtEstante1.BackColor = Color.White;
        }
       
        /********************************************************************************************/
        /********************************************************************************************/
                                            //Valida la Caja
        if (caja <= minC || caja >= maxC)
        {
            Master.MensajeError("Error al generar el reporte", "El codigo de caja esta fuera de rango porfavor revise la tabla de parametros gracias.");
            txtCodigoCaja1.ForeColor = Color.White;
            txtCodigoCaja1.BackColor = Color.Red;
            sw = 1;
        }
        else 
        {
            txtCodigoCaja1.ForeColor = Color.Black;
            txtCodigoCaja1.BackColor = Color.White;
        }
        /********************************************************************************************/

        if(sw==0)
            return true;
        else
            return false;
    }
    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtPrimerApellido, btnBuscar);
        AgregarJSAtributos(txtNombres1, btnBuscar);
        AgregarJSAtributos(txtCI, btnBuscar);
        AgregarJSAtributos(txtSegundoApellido, btnBuscar);
        AgregarJSAtributos(txtNroTramite, btnBuscar);
        AgregarJSAtributos(txtMatricula, btnBuscar);
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");
            //controlActual.Attributes.Add("onFocus", "  JavaScript:this.style.backgroundColor='#ffff00'; SelectAll(this)");
            //controlActual.Attributes.Add("onBlur", "  JavaScript:this.style.backgroundColor='#ffffff'; return focusNext('" + ctrlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "', null)  ");

        }
    }
    
    #region btnGrupoFamiliar_Click
    protected void btnGrupoFamiliar_Click(object sender, EventArgs e)
    {
        /*pnlAsignaExpediente.Width = 600;
        pnlAsignaExpediente.Height = 350;*/
        gvGrupoFamiliar.Visible = true;
        gvGrupoFamiliar.DataSourceID = null;
        //carga el gridviuw de ubicacion
        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "GrupoFamiliar", "", "", "", "", txtmatricula1.Text, txttramite.Text, "", 0, 0, 0, (int)Session["ID"], ref mensaje);
        gvGrupoFamiliar.DataSource = Encontrados;
        gvGrupoFamiliar.DataBind();
        this.mpeGrupoFamiliar.Show();

    }
    #endregion
}