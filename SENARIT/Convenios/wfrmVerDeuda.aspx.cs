using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using wcfServicioIntercambioPago.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;
using wcfConvenios.Logica;
using wfcDoblePercepcion.Logica;


public partial class Convenios_wfrmVerDeuda : System.Web.UI.Page
{
	clsInformacionLO Convenio = new clsInformacionLO();
	string mensaje = null;
	clsInformacion DP = new clsInformacion();
	clsInformacion info = new clsInformacion();
	int []v  = new int [50];
    int BanderaHabilitacionRol = 0;
    int BanderaHabilitacionRol1 = 0;
    
    protected void Page_Load(object sender, EventArgs e)
	{
        DataTable Encontrados = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ROL", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        DataRow row2 = Encontrados.Rows[0];
        BanderaHabilitacionRol = Convert.ToInt32(row2[0].ToString());

        Encontrados = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ROL1", "", "", "", "", "", "", "", 0, 0, ref mensaje);
        row2 = Encontrados.Rows[0];
        BanderaHabilitacionRol1 = Convert.ToInt32(row2[0].ToString());


        if (!Page.IsPostBack)
		{
			HttpContext.Current.Server.ScriptTimeout = 2400;
           /* Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES", false);
            Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";*/
            CargarCombos();
            CargarInfo();
			CargaDeudas();
			CrearTablas();
            CambiarInterfaz();
            if (BanderaHabilitacionRol == 0)
            {
                imgNuevo.Enabled = false;
                btnNuevoDeposito.Enabled = false;
            }
            else
            {
                imgNuevo.Enabled = true;
                btnNuevoDeposito.Enabled = true;
            }
            //CargarEntidad();
            //CargaPeriodos();
            //txtPorcentaje.Attributes.Add("OnBlur", "Calcular()");
         }
            //        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "calculoMonto"))
            //        {
            //            ClientScript.RegisterClientScriptBlock(this.GetType(), "calculoMonto",
            //                String.Format(@"function porcentaje() {{
            //            var b, c, r;    // Se declara la variable
            //            b = document.getElementById('{1}').value;
            //            c = document.getElementById('{2}').innerText;
            //            r = (parseFloat(b) * parseFloat(c))/100;           // Convierte en Float y sumar
            //            document.getElementById('{0}').value = r; // El resultado en TextBox resultado
            //        }}", txtMontoDescuento.ClientID, txtPorcentaje.ClientID, lblMontoCC.ClientID)
            //                , true);
            //        }
            /*txtCuotas.Attributes.Add("OnBlur", "sumar()");
            txtPeriodoInicio.Attributes.Add("OnBlur", "sumar()");
            txtPeriodoFin.Attributes.Add("OnBlur", "sumar()");
            txtMontoDescuento.Attributes.Add("OnBlur", "sumar()");*/
        }
	#region Inicio

	private void CargarInfo()
	{
		mensaje = null;
        long NUPPrueba = Convert.ToInt64(Session["NUP"]);
        string CUAPRueba = Session["CUA"].ToString();
		if (Session["NUP"] != null)
		{
                        
			//DataTable Origen = Session["InfoDeudor"] as DataTable;

            DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Persona1", "", "", "", "", "", "", Session["CUA"].ToString()
													  , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
			//y cargamos todos los campos con estos datos
            txtNUP.Text = Origen.Rows[0][1].ToString();
			txtCUA.Text = Origen.Rows[0][2].ToString();
			txtMatricula.Text = Origen.Rows[0][3].ToString();
			txtCI.Text = Origen.Rows[0][4].ToString();
			txtPrimerApellido.Text = Origen.Rows[0][5].ToString();
			txtSegundoApellido.Text = Origen.Rows[0][6].ToString();
			txtPrimerNombre.Text = Origen.Rows[0][7].ToString();
			txtSegundoNombre.Text = Origen.Rows[0][8].ToString();
			txtEstadoCivil.Text = Origen.Rows[0][9].ToString();
			txtFechaNacimiento.Text = Origen.Rows[0][10].ToString().Replace(" 0:00:00","");
			txtFechaFallecimiento.Text = Origen.Rows[0][11].ToString();
			txtSexo.Text = Origen.Rows[0][12].ToString();
			hfMontoCC.Value = Origen.Rows[0][15].ToString();
			hfBeneficio.Value = Origen.Rows[0][14].ToString();
			lblSector.Text = Origen.Rows[0][16].ToString();
			hfIdBeneficio.Value = Origen.Rows[0][17].ToString();
            txtDireccion.Text = Origen.Rows[0][13].ToString();
            txtCel.Text = Origen.Rows[0][18].ToString();
            txtCelReferencial.Text = Origen.Rows[0][19].ToString();
            txtTelefono.Text = Origen.Rows[0][20].ToString();
           
            ddlExtension.SelectedValue = Origen.Rows[0][21].ToString();

            string y = Origen.Rows[0][23].ToString();
            
            ddlDepartamento.SelectedValue = Origen.Rows[0][23].ToString();
            
            if (Origen.Rows[0][23].ToString() != "0")
            {
             
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Add("SELECCIONE...");
                ddlLocalidad.AppendDataBoundItems = true;

                ddlLocalidad.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Localidad", "", "", "", "", "", "", ""
                                           , 0, Convert.ToInt32(ddlDepartamento.SelectedValue), ref mensaje);
                ddlLocalidad.DataValueField = "CodigoLocalidad";
                ddlLocalidad.DataTextField = "NombreLocalidad";
                ddlLocalidad.DataBind();
                ddlLocalidad.SelectedValue = Origen.Rows[0][22].ToString();
            }
            
         
           DataTable RentaCC = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "RentaCC", "", "", "", "", "", "", ""
                                                      , Convert.ToInt64(txtNUP.Text), 0, ref mensaje);

           if (RentaCC !=null && RentaCC.Rows.Count>0)
            txtRentaCC.Text = RentaCC.Rows[0][0].ToString().Replace(",",".");
           else
           {    
               if (RentaCC.Rows.Count == 0)
               {
                   txtRentaCC.Text = "0.00";
               }
               if (RentaCC != null)
               {
                   if (RentaCC.Rows.Count == 0)
                   {
                       txtRentaCC.Text = "0.00";
                   }
               }
               else 
               {
                   txtRentaCC.Text = "0.00";
              }
           }
            hfMontoCC.Value = txtRentaCC.Text;


            Session["Direccion"] = Origen.Rows[0][13].ToString();
            Session["Cel"] = Origen.Rows[0][18].ToString();
            Session["CelRef"] = Origen.Rows[0][19].ToString();
            Session["Tele"] = Origen.Rows[0][19].ToString();

            DataTable Conexion = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "DatosConexion", "", "", "", "", "", "", ""
                                                         , 0, 0, ref mensaje);

        }
		pnlDeuda.Visible = false;
		pnlControl.Visible = false;
		ddlInstitucion.Visible = false;
		lblInsitucion.Visible = false;
	}

	private void CargaDeudas()
	{
		mensaje = null;
		if (Session["NUP"] != null)
		{
			DataTable Deudas = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Deudas", "", "", "", "", "", "", ""
													  , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
			gvDeudas.DataSourceID = null;
			gvDeudas.DataSource = Deudas;
			gvDeudas.DataBind();
		}
	}

	private void CargarCombos()
	{
		mensaje = null;
		/*DataTable Parametricas = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaRegional", "", "", "", "", "", "", ""
													  , 0, ref mensaje);*/
       
        DataTable Regional = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaRegionalUsuario", "", "", "", "", "", "", ""
                                              , 0, 0, ref mensaje);
        
        
        /*ddlRegional.Items.Clear();
        ddlRegional.Items.Add(Regional.Rows[0][2].ToString());
        ddlRegional.DataValueField = Regional.Rows[0][0].ToString();
        ddlRegional.DataTextField = Regional.Rows[0][2].ToString(); 
        ddlRegional.DataBind();
        ddlRegional.AppendDataBoundItems = true;*/

        int u = 0;
        if (Regional.Rows[0][2].ToString()=="LA PAZ") 
        {
            u = 2;
        }
        if (Regional.Rows[0][2].ToString() == "COCHABAMBA")
        {
            u = 3;
        }
        if (Regional.Rows[0][2].ToString() == "SANTA CRUZ")
        {
            u =4;
        }
        if (Regional.Rows[0][2].ToString() == "ORURO")
        {
            u =5;
        }
        if (Regional.Rows[0][2].ToString() == "POTOSI")
        {
            u =6;
        }
        if (Regional.Rows[0][2].ToString() == "SUCRE")
        {
            u = 7;
        }
        if (Regional.Rows[0][2].ToString() == "TARIJA")
        {
            u = 8;
        }
        if (Regional.Rows[0][2].ToString() == "TRINIDAD")
        {
            u = 9;
       }
        if (Regional.Rows[0][2].ToString() == "COBIJA")
        {
            u = 10;
        }

        ddlRegional.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaRegional", "", "", "", "", "", "", ""
												  , 0, 0, ref mensaje);
		ddlRegional.DataValueField = "IdOficina";
		ddlRegional.DataTextField = "Nombre";
		ddlRegional.DataBind();

        ddlRegional.SelectedValue = u.ToString();

        /*DataTable DatosUsuario = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaRegionalUsuario", "", "", "", "", "", "", ""
                                     , 0, 0, ref mensaje);
        //Origen.Rows[i][3].ToString()
        ddlRegional.SelectedValue = DatosUsuario.Rows[0][2].ToString();*/

		ddlMoneda.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaMoneda", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlMoneda.DataValueField = "IdDetalleClasificador";
		ddlMoneda.DataTextField = "DescripcionDetalleClasificador";
		ddlMoneda.DataBind();


		ddlTipoDeuda.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaTipoDeuda", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlTipoDeuda.DataValueField = "IdDetalleClasificador";
		ddlTipoDeuda.DataTextField = "DescripcionDetalleClasificador";
		ddlTipoDeuda.DataBind();

		ddlEstadoDeuda.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaEstadoDeuda", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlEstadoDeuda.DataValueField = "IdDetalleClasificador";
		ddlEstadoDeuda.DataTextField = "DescripcionDetalleClasificador";
		ddlEstadoDeuda.DataBind();

		ddlTipoDocumento.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaTipoDocumento", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlTipoDocumento.DataValueField = "IdDetalleClasificador";
		ddlTipoDocumento.DataTextField = "DescripcionDetalleClasificador";
		ddlTipoDocumento.DataBind();
		//tambien para los modal
		ddlTipoMonedaTC.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaMoneda", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlTipoMonedaTC.DataValueField = "IdDetalleClasificador";
		ddlTipoMonedaTC.DataTextField = "DescripcionDetalleClasificador";
		ddlTipoMonedaTC.DataBind();

		ddlTipoMonedaND.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaMoneda", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlTipoMonedaND.DataValueField = "IdDetalleClasificador";
		ddlTipoMonedaND.DataTextField = "DescripcionDetalleClasificador";
		ddlTipoMonedaND.DataBind();

		ddlCuentasBancoND.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaCuentasBanco", "", "", "", "", "", "", ""
													  , 0, 0, ref mensaje);
		ddlCuentasBancoND.DataValueField = "IdCuenta";
		ddlCuentasBancoND.DataTextField = "Descripcion";
		ddlCuentasBancoND.DataBind();

		ddlInstitucion.Items.Clear();
        ddlInstitucion.Items.Insert(0, new System.Web.UI.WebControls.ListItem("SELECCIONE...", "0"));
		//ddlInstitucion.Items.Add("SELECCIONE...");
		ddlInstitucion.AppendDataBoundItems = true;

		ddlInstitucion.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Institucion", "", "", "", "", "", "", ""
										   , 0, 0, ref mensaje);
		ddlInstitucion.DataValueField = "IdInstitucion";
		ddlInstitucion.DataTextField = "NombreInstitucion";
		ddlInstitucion.DataBind();

        ddlTipoDeuda.SelectedIndex = 3;
        txtNumeroLiquidacion.Text = GeneraNumeroLiquidacion();
        txtNroDoc.Text = txtNumeroLiquidacion.Text;


        ddlExtension.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Extensiones", "", "", "", "", "", "", ""
                                   , 0, 0, ref mensaje);
        ddlExtension.DataValueField = "IdDetalleClasificador";
        ddlExtension.DataTextField = "ObservacionClasificador";
        ddlExtension.DataBind();


        ddlDepartamento.Items.Clear();
        ddlDepartamento.Items.Add("SELECCIONE...");
        ddlDepartamento.AppendDataBoundItems = true;

        ddlDepartamento.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Departamento", "", "", "", "", "", "", ""
                                   , 0, 0, ref mensaje);
        ddlDepartamento.DataValueField = "IdDepartamento";
        ddlDepartamento.DataTextField = "NombreDepartamento";
        ddlDepartamento.DataBind();

        ddlLocalidad.Items.Clear();
        ddlLocalidad.Items.Add("SELECCIONE...");
        ddlLocalidad.AppendDataBoundItems = true;
	}

	private void CrearTablas()
	{
		//crear tabla temp para tipo de Cambio
		DataTable TC = new DataTable();
		TC.Columns.Add(new DataColumn("FechaCambio", Type.GetType("System.DateTime")));
		TC.Columns.Add(new DataColumn("IdTipoMoneda", Type.GetType("System.Int32")));
		TC.Columns.Add(new DataColumn("TipoMoneda", Type.GetType("System.String")));
		TC.Columns.Add(new DataColumn("TasaCambio", Type.GetType("System.Decimal")));
		TC.Columns.Add(new DataColumn("MontoDeuda", Type.GetType("System.Decimal")));
		Session["TC"] = TC;
		//crear tabla temp para documentos
		DataTable Docs = new DataTable();
		Docs.Columns.Add(new DataColumn("Fila", Type.GetType("System.Int32")));
		Docs.Columns.Add(new DataColumn("IdDocumento", Type.GetType("System.Int32")));
		Docs.Columns.Add(new DataColumn("IdTipoDocumentoDeuda", Type.GetType("System.Int32")));
		Docs.Columns.Add(new DataColumn("TipoDocumento", Type.GetType("System.String")));
		Docs.Columns.Add(new DataColumn("NumeroDocumento", Type.GetType("System.String")));
		Docs.Columns.Add(new DataColumn("FechaDocumento", Type.GetType("System.DateTime")));
		Docs.Columns.Add(new DataColumn("ReferenciaDocumento", Type.GetType("System.String")));
		Docs.Columns.Add(new DataColumn("Observaciones", Type.GetType("System.String")));
		Docs.Columns.Add(new DataColumn("FechaRegistroDeuda", Type.GetType("System.DateTime")));
		Session["DOC"] = Docs;
		//crear tabla temp para Periodos
		DataTable Periodo = new DataTable();
		Periodo.Columns.Add(new DataColumn("Fila", Type.GetType("System.Int32")));
		Periodo.Columns.Add(new DataColumn("PeriodoInicioTGN", Type.GetType("System.String")));
		Periodo.Columns.Add(new DataColumn("PeriodoFinTGN", Type.GetType("System.String")));
		Periodo.Columns.Add(new DataColumn("CantidadDuodecimas", Type.GetType("System.String")));
/*        Periodo.Columns.Add(new DataColumn("Institucion", Type.GetType("System.String")));
		Periodo.Columns.Add(new DataColumn("IdInstitucion", Type.GetType("System.Int32")));*/
		Periodo.Columns.Add(new DataColumn("MontoDeuda", Type.GetType("System.Decimal")));
		Session["PERIODO"] = Periodo;
	}

	#endregion

	#region Acordeon

	protected void btnOpenCloseRegistro_Click(object sender, ImageClickEventArgs e)
	{
		if (pnlRegistro.Visible == false)
		{
			btnOpenCloseRegistro.ImageUrl = "~/Imagenes/16quitar.png";
			pnlRegistro.Visible = true;
		}
		else
		{
			btnOpenCloseRegistro.ImageUrl = "~/Imagenes/16adicionar.png";
			pnlRegistro.Visible = false;
		}
	}

	protected void btnOpenCloseLiquidacion_Click(object sender, ImageClickEventArgs e)
	{
		if (pnlLiquidacion.Visible == false)
		{
			btnOpenCloseLiquidacion.ImageUrl = "~/Imagenes/16quitar.png";
			pnlLiquidacion.Visible = true;
		}
		else
		{
			btnOpenCloseLiquidacion.ImageUrl = "~/Imagenes/16adicionar.png";
			pnlLiquidacion.Visible = false;
		}
	}

	protected void btnOpenClosePlan_Click(object sender, ImageClickEventArgs e)
	{
		if (pnlPlan.Visible == false)
		{
			btnOpenClosePlan.ImageUrl = "~/Imagenes/16quitar.png";
			pnlPlan.Visible = true;
		}
		else
		{
			btnOpenClosePlan.ImageUrl = "~/Imagenes/16adicionar.png";
			pnlPlan.Visible = false;
		}
	}

	protected void btnOpenCloseDocumentos_Click(object sender, ImageClickEventArgs e)
	{
		if (pnlDocumentos.Visible == false)
		{
			btnOpenCloseDocumentos.ImageUrl = "~/Imagenes/16quitar.png";
			pnlDocumentos.Visible = true;
		}
		else
		{
			btnOpenCloseDocumentos.ImageUrl = "~/Imagenes/16adicionar.png";
			pnlDocumentos.Visible = false;
		}
	}

	#endregion

	#region Deudas

	protected void gvDeudas_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int indice = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "cmdEliminar")
        {
            indice = indice - 1;
        }
		hfIdDeuda.Value = gvDeudas.DataKeys[indice].Values["IdDeuda"].ToString();
		lblSector.Text = gvDeudas.DataKeys[indice].Values["Sector"].ToString();
		hfBeneficio.Value = gvDeudas.DataKeys[indice].Values["Beneficio"].ToString();
		int IdDeuda = Convert.ToInt32(gvDeudas.DataKeys[indice].Values["IdDeuda"]);
        Session["IdDeuda"] = IdDeuda;
    	if (e.CommandName == "cmdDetalle")
		{
			try
			{
				pnlDeuda.Visible = true;
				pnlControl.Visible = false;
                txtDireccion.ReadOnly = true;
                txtCel.ReadOnly = true;
                txtCelReferencial.ReadOnly = true;
                txtTelefono.ReadOnly = true;

                CargarDetalle(indice, IdDeuda);
                MostrarPagos();
                //MostrarPagos1();
                this.gvListaPago.Columns[5].Visible = false;
                this.gvListaPago.Columns[6].Visible = true;
                txtDireccion.ReadOnly = true;
                txtCel.ReadOnly = true;
                txtCelReferencial.ReadOnly = true;
                txtTelefono.ReadOnly = true;		

				if (ddlTipoDeuda.SelectedValue == "746")
				{
					lblInsitucion.Visible = true;
					ddlInstitucion.Visible = true;
					pnMontoLiquidacion.Visible = true;
				 }
				else
                {
                    if (gvDeudas.Rows[indice].Cells[5].Text == "RECALCULO")
                    { GeneraPlanPagos(); }

                    DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Edad", "", "", "", "", "", "", txtPeriodoInicio.Text
                                                       , Convert.ToInt64(Session["NUP"]), Convert.ToInt32(txtCuotas.Text), ref mensaje);
                /*    EdadActual.Text = Origen.Rows[0][0].ToString() + " Años, con " + Origen.Rows[0][1].ToString() + " Meses.";
                    EdadFinal.Text = Origen.Rows[0][2].ToString() + " Años, con " + Origen.Rows[0][3].ToString() + " Meses.";*/



					txtPeriodoInicioDevTGN.Visible = false;
					txtPeriodoFinDevTGN.Visible = false;
					btnCalcularDeuda.Visible = false;
					lblPeriodoInicioTGN.Visible = false;
					lblPeriodoFinDevolucion.Visible = false;
				}

			}
			catch (Exception ex)
			{
				Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
			}
		}
		if (e.CommandName == "cmdModificar")
		{
            CargarDetalle(indice, IdDeuda);
            MostrarPagos();
            this.gvListaPago.Columns[5].Visible = true;
            this.gvListaPago.Columns[6].Visible = false;

            this.gvListaPago.Columns[5].Visible = true;
            this.gvListaPago.Columns[6].Visible = true;
            //MostrarPagos1();
			if (ddlTipoDeuda.SelectedValue == "746")
			{
				txtPeriodoInicioDevTGN.Visible = true;
				txtPeriodoFinDevTGN.Visible = true;
				btnCalcularDeuda.Visible = true;
				lblPeriodoInicioTGN.Visible = true;
				lblPeriodoFinDevolucion.Visible = true;
				pnMontoLiquidacion.Visible = true;
				ImageButton5.Visible = true;
				ImageButton6.Visible = true;
                lblInsitucion.Visible = true;
                ddlInstitucion.Visible = true;
			}
			else
			{
                if (gvDeudas.Rows[indice].Cells[5].Text == "RECALCULO")
                { GeneraPlanPagos(); }
                DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Edad", "", "", "", "", "", "", txtPeriodoInicio.Text
                                                       , Convert.ToInt64(Session["NUP"]), Convert.ToInt32(txtCuotas.Text), ref mensaje);
              /*  EdadActual.Text = Origen.Rows[0][0].ToString() + " Años, con " + Origen.Rows[0][1].ToString() + " Meses.";
                EdadFinal.Text = Origen.Rows[0][2].ToString() + " Años, con " + Origen.Rows[0][3].ToString() + " Meses.";*/

				txtPeriodoInicioDevTGN.Visible = false;
				txtPeriodoFinDevTGN.Visible = false;
				btnCalcularDeuda.Visible = false;
				lblPeriodoInicioTGN.Visible = false;
				lblPeriodoFinDevolucion.Visible = false;
			}

			pnlDeuda.Visible = true;
			pnlControl.Visible = false;
			//habilitamos todo para que se puda editar
            txtDireccion.ReadOnly = false;
            txtCel.ReadOnly = false;
            txtCelReferencial.ReadOnly = false;
            txtTelefono.ReadOnly = false;

			pnlRegistro.Enabled = true;
			pnlLiquidacion.Enabled = true;
			pnlPlan.Enabled = true;
			pnlDocumentos.Enabled = true;
			btnRegistrarDeuda.Text = "Actualizar Deuda";
			btnAgregarDoc.Text = "Actualizar Documento";
			btnAgregarDoc.Enabled = true;
			btnRegistraTC.Visible = false;
		}
		if (e.CommandName == "cmdControl")
		{
			//Session["NUP"] = txtNUP.Text.Trim();
			////habrir otro aspx y cargar la info pertienente
			//Response.Redirect("~/Convenios/wfrmVerDeuda.aspx");
			txtTotalDepositos.Text = "0";
			txtTotalDescuentos.Text = "0";
			pnlDeuda.Visible = false;
			pnlControl.Visible = true;
		   // btnNuevoDeposito.Enabled = true;
			CargarDepositos(Convert.ToInt32(hfIdDeuda.Value));
			CargarDescuentos(Convert.ToInt32(hfIdDeuda.Value));

        /*    decimal uu = Convert.ToDecimal(gvDeudas.Rows[indice].Cells[5].Text.Replace(",", "."));
            txtSaldoAux.Text = Convert.ToString(uu);
            decimal yy = Convert.ToDecimal(txtTotalDepositos.Text.Replace(",", "."));
			decimal xx = Convert.ToDecimal(txtTotalDescuentos.Text.Replace(",", "."));
			txtSaldoDeuda.Text = (uu - yy - xx).ToString().Replace(",",".");*/
            CalculoSaldos(Convert.ToInt32(hfIdDeuda.Value));


			if (gvDeudas.Rows[indice].Cells[7].Text == "CURSO DE PAGO SIN ENVIO APS" || gvDeudas.Rows[indice].Cells[7].Text == "DESCUENTO ACTIVO" ||
                gvDeudas.Rows[indice].Cells[7].Text == "ENVIADO AFP - APS" || gvDeudas.Rows[indice].Cells[7].Text == "PENDIENTE" || gvDeudas.Rows[indice].Cells[7].Text == "CC CURSO DE PAGO"
                || gvDeudas.Rows[indice].Cells[7].Text == "CONCLUIDO"
                )
			{
				btnNuevoDeposito.Enabled = true;
			}
			else
			{ 
				btnNuevoDeposito.Enabled = false;
			}
            
            if (BanderaHabilitacionRol == 0)
            {
                btnNuevoDeposito.Enabled = false;
            }
            else
            {
                btnNuevoDeposito.Enabled = true;
            }

		}
        if (e.CommandName == "cmdEliminar1")
        {
            
            /*EliminaConvenio(Convert.ToInt32(hfIdDeuda.Value));
             CargaDeudas();*/
            try
            {
                lblTituloND.Text = "Editar Datos Depósito";
                DataTable Conexion = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "DatosConexion", "", "", "", "", "", "", ""
                                                         , 0, 0, ref mensaje);
                txtAutorizadori.Text = Conexion.Rows[0][0].ToString();
                txtAutorizadori.Enabled = false;
                txtMotivoi.Text = "";
                txtObservacioni.Text = "";
                this.ModalPopupExtender3pnlJustificar.Show();

                //CargarDepositoEditar(indice, IdMoneda, IdBanco, IdDeposito);
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
    }

    protected void EliminaConvenio(int IdDeuda,string justificacion) 
    {
        mensaje = null;
        bool respuesta = Convenio.EliminaConvenio((int)Session["IdConexion"], "U", IdDeuda, justificacion, ref mensaje);
     
        if (mensaje == null && respuesta)
        {
            
            Master.MensajeOk("Se dio de Baja al convenio correctamente");
        } 
        else 
        {
            Master.MensajeError("No se elimino el convenio revise el error porfavor", mensaje);
        }
    }

	protected void gvDeudas_DataBound(object sender, EventArgs e)
	{
		foreach (GridViewRow row in gvDeudas.Rows)
		{
			if (row.Cells[7].Text == "CONCLUIDO")
			{
				//10-detalle;11-modificar;12-control
				row.Cells[11].Enabled = false;
				row.Cells[11].ForeColor = Color.Gray;
				btnNuevoDeposito.Enabled = false;
			}

			if (row.Cells[7].Text == "PENDIENTE")
			{
				//10-detalle;11-modificar;12-control
				row.Cells[11].Enabled = false;
				row.Cells[11].ForeColor = Color.Gray;
				//row.Cells[12].Enabled = false;
				//row.Cells[12].ForeColor = Color.Gray;
			}

			if (row.Cells[7].Text == "RECALCULO")
			{
				//10-detalle;11-modificar;12-control
				row.Cells[11].Enabled = false;
				row.Cells[11].ForeColor = Color.Gray;
				/*row.Cells[12].Enabled = false;
				row.Cells[12].ForeColor = Color.Gray;*/
			}

            if (row.Cells[7].Text == "BAJA")
            {
                //10-detalle;11-modificar;12-control
                row.Cells[10].Enabled = false;
                row.Cells[10].ForeColor = Color.Gray;
                row.Cells[11].Enabled = false;
                row.Cells[11].ForeColor = Color.Gray;
                row.Cells[12].Enabled = false;
                row.Cells[12].ForeColor = Color.Gray;
                row.Cells[13].Enabled = false;
                row.Cells[13].ForeColor = Color.Gray;
                row.Cells[14].Enabled = false;
                row.Cells[14].ForeColor = Color.Gray;
            }
            if (BanderaHabilitacionRol == 0)
            {	row.Cells[11].Enabled = false;
				row.Cells[11].ForeColor = Color.Gray;
                
            }
            if (BanderaHabilitacionRol1 == 0)
            {
                row.Cells[13].Enabled = false;
                row.Cells[13].ForeColor = Color.Gray;
            }
            if (BanderaHabilitacionRol1 == 1)
            {
                row.Cells[13].Enabled = true;
                //  row.Cells[13].ForeColor = Color.Gray;
            }
		}
	}

	private void CargarDetalle(int fila, int IdDeuda)
	{
		//cargamos los datos generales de la deuda
		mensaje = null;
		DataTable DetalleDeuda = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "DetalleDeuda", "", "", "", "", "", "", ""
													  , Convert.ToInt64(Session["NUP"]), IdDeuda, ref mensaje);
		if (mensaje == null && DetalleDeuda != null)
		{
			ddlRegional.SelectedValue = DetalleDeuda.Rows[0][2].ToString();
			ddlTipoDeuda.SelectedValue = DetalleDeuda.Rows[0][4].ToString();
			ddlMoneda.SelectedValue = DetalleDeuda.Rows[0][6].ToString();
			ddlEstadoDeuda.SelectedValue = DetalleDeuda.Rows[0][8].ToString();
			txtNumeroLiquidacion.Text = DetalleDeuda.Rows[0][10].ToString();
			txtMontoTotal.Text = DetalleDeuda.Rows[0][11].ToString().Replace(",",".");
            txtSaldo.Text = DetalleDeuda.Rows[0][23].ToString().Replace(",", ".");
			txtFechaActual.Text = DetalleDeuda.Rows[0][12].ToString().Replace(" 0:00:00", "");
			ddlAplica.SelectedValue = DetalleDeuda.Rows[0][13].ToString();
			txtPorcentaje.Text = DetalleDeuda.Rows[0][14].ToString().Replace(",", ".");
			txtMontoDeposito.Text = DetalleDeuda.Rows[0][15].ToString().Replace(",", ".");
			txtCuotas.Text = DetalleDeuda.Rows[0][16].ToString();
            if (DetalleDeuda.Rows[0][17].ToString() != "")
                txtMontoDescuento.Text = DetalleDeuda.Rows[0][17].ToString().Replace(",", ".");
            else
                txtMontoDescuento.Text = "0.00";

            if (ddlAplica.SelectedValue == "True" && Convert.ToDouble(txtPorcentaje.Text) > 0.00 && Convert.ToDouble(txtMontoDescuento.Text) == 0.00 && Convert.ToDouble(txtRentaCC.Text) > 0.00 && txtRentaCC.Text !="")
            {
                double var =  Math.Round((Convert.ToDouble(txtRentaCC.Text) * Convert.ToDouble(txtPorcentaje.Text) / 100.00),2);
                txtMontoDescuento.Text = Convert.ToString(var);
            }
			txtPeriodoInicio.Text = DetalleDeuda.Rows[0][18].ToString();
			txtPeriodoFin.Text = DetalleDeuda.Rows[0][19].ToString();

            int edad = 0; 
            if(txtCuotas.Text!=""&& txtCuotas.Text!="&nbsp;")
             edad= Convert.ToInt32(txtCuotas.Text);

            DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Edad", "", "", "", "", "", "", txtPeriodoInicio.Text
                                                         , Convert.ToInt64(Session["NUP"]), edad, ref mensaje);

            EdadActual.Text = Origen.Rows[0][0].ToString() + " Años, con " + Origen.Rows[0][1].ToString() + " Meses.";
            EdadFinal.Text = Origen.Rows[0][2].ToString() + " Años, con " + Origen.Rows[0][3].ToString() + " Meses.";

            txtObservaciones.Text = DetalleDeuda.Rows[0][20].ToString();
			//txtPeriodoInicioDevTGN.Text = DetalleDeuda.Rows[0][21].ToString();
			//txtPeriodoFinDevTGN.Text = DetalleDeuda.Rows[0][22].ToString();
		   
			txtNroDoc.Text = "";
			txtReferencia.Text = "";
			txtObservacionDoc.Text = "";
			txtFechaDocumento.Text = "";
           	
		}
		//cargamos plan de pagos
		mensaje = null;
		DataTable PlanPagos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "PlanRecuperacion", "", "", "", "", "", "", ""
													  , Convert.ToInt64(Session["NUP"]), IdDeuda, ref mensaje);
        if (mensaje == null && PlanPagos != null && PlanPagos.Rows.Count > 0)
        {
            decimal pp = Convert.ToDecimal(PlanPagos.Rows[0][7].ToString());
            decimal mm = 0;
            if (PlanPagos.Rows.Count > 1)
                mm = Convert.ToDecimal(PlanPagos.Rows[1][7].ToString());
            else
                mm = 1000000;

            if (pp > mm && DetalleDeuda.Rows[0][13].ToString()=="False")
            {
                txtMontoPrimerDeposito.Text = PlanPagos.Rows[0][7].ToString().Replace(",", ".");
                //txtSaldo.Text = Convert.ToString(Convert.ToDecimal(DetalleDeuda.Rows[0][23].ToString()) - pp).Replace(",", ".");
            }
            else
            {
                txtMontoPrimerDeposito.Text = "0.00";
                txtSaldo.Text = DetalleDeuda.Rows[0][23].ToString().Replace(",", ".");
            }
            gvPlanPagos.DataSource = PlanPagos;
            gvPlanPagos.DataBind();
        }
        else
        {
            txtMontoPrimerDeposito.Text = "0.00";
            txtSaldo.Text = DetalleDeuda.Rows[0][23].ToString().Replace(",", ".");
        }
 

		CargarDocumentacion(IdDeuda);
		CargaPeriodos(IdDeuda);
   
		//deshabilitamos todo par que no haya edición
		pnlRegistro.Enabled = false;
		pnlLiquidacion.Enabled = false;
		pnlPlan.Enabled = false;
		pnlDocumentos.Enabled = false;
		pnlLiquidacion.Enabled = false;
		btnImprimirPlan.Enabled = true;
		btnImprimirPlan.Visible = true;
		btnImprimirDeuda.Visible = true;
        CargaTipoCambio();
		
	}

    private void CargaTipoCambio() 
    {
        DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoCambio", txtFechaActual.Text, "", "", "", "", "", ""
                                                          , 0, 0, ref mensaje);
        if (Origen != null)
        {
            Origen.Columns.Add("MontoDeuda", typeof(decimal));
            int hh = Origen.Rows.Count;

            for (int i = 0; i < hh; i++)
            {
                decimal vv = Convert.ToDecimal(txtMontoTotal.Text, System.Globalization.CultureInfo.GetCultureInfo("si"));
                decimal mm = Convert.ToDecimal(Origen.Rows[i][3].ToString());
                Origen.Rows[i][4] = Math.Round(vv / mm, 2);
                gvLiquidacionDeuda.DataSourceID = null;
                gvLiquidacionDeuda.DataSource = Origen;
                gvLiquidacionDeuda.DataBind();
            }
        }
        else
        {
            gvLiquidacionDeuda.DataSource = null;
            gvLiquidacionDeuda.DataBind();
        }
    }

	private void CargarDocumentacion(int IdDeuda)
	{
		//cargamos documentos deuda
		mensaje = null;
		DataTable Documentos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "DocumentosDeuda", "", "", "", "", "", "", ""
													  , Convert.ToInt64(Session["NUP"]), IdDeuda, ref mensaje);
		if (mensaje == null)
		{
			gvDocumentos.DataSource = Documentos;
			gvDocumentos.DataBind();
		}
	}

	private void CargaPeriodos(int IdDeuda)
	{
		//cargamos documentos deuda
		mensaje = null;
		DataTable Periodos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Periodos", "", "", "", "", "", "", ""
													  , Convert.ToInt64(Session["NUP"]), IdDeuda, ref mensaje);

		if (Periodos != null && Periodos.Rows.Count>0)
		{ 
			ddlInstitucion.SelectedValue =  Periodos.Rows[0][4].ToString();
			lblIdInstitucion.Text = (Periodos.Rows[0][4].ToString());
			if (mensaje == null)
			{
                Session["PERIODO"] = Periodos;
                gvPeriodos.DataSource = Periodos;
                gvPeriodos.Visible = true;
				gvPeriodos.DataBind();
			}
		}
	}


	#endregion

	#region Registro

	protected void btnRegistrarDeuda_Click(object sender, EventArgs e)
	{
        btnRegistrarDeuda.Enabled = false;
		foreach (GridViewRow r in gvPlanPagos.Rows)
		{
			if (Convert.ToDecimal(r.Cells[3].Text,System.Globalization.CultureInfo.GetCultureInfo("si")) < 0)
			{
				Response.Write("<script>window.alert('No se puede registrar/actualizar una deuda con Saldos Negativos\nEn el Plan de Pagos');</script>");
				return;
			}
		}
		    mensaje = null;
		int idver = 0, idTM;
     

        if (btnRegistrarDeuda.Text.StartsWith("Registrar") && Valida_Celular() && Valida_Telefono() & Valida_CelularReferencia())
        {
            bool sw1 = false;
            int sw = 0;
            string estado = null;
            int sw2 = 1;
            if (ddlTipoDeuda.SelectedValue == "746")
            {
                string BanderaInstitucion = "False";
                string institucion = "0";
                if (ddlInstitucion.SelectedValue != "0") {
                    BanderaInstitucion = "True";
                    institucion = ddlInstitucion.SelectedValue;
                }
                DataTable bandera = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Registro", "", "", "", "", "", "",
                 "", Convert.ToInt64(txtNUP.Text), 0, ref mensaje);
                mensaje = null;
                if (bandera == null)
                {
                    if (gvPeriodos.Rows[0].Cells[1].Text != "" || gvPeriodos.Rows[0].Cells[2].Text != "" & gvPeriodos != null)
                    {
                        estado = "31550";
                        DP.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUP"]), "3", "16", Convert.ToInt32(estado),
                        Convert.ToInt32(372), Convert.ToInt32(ddlTipoDocumento.SelectedValue), gvDocumentos.Rows[0].Cells[4].Text, gvDocumentos.Rows[0].Cells[5].Text, institucion, "",
                        "", gvPeriodos.Rows[0].Cells[1].Text, gvPeriodos.Rows[0].Cells[2].Text, "5", BanderaInstitucion, txtReferencia.Text, txtObservacionDoc.Text, "Registro Insertado por registro de Convenio", 0, 0, ref mensaje);
                        sw = 1;
                    }
                    else
                    {

                        sw2 = 0;
                    }
                }
                else
                {
                    if (bandera.Rows.Count == 0)
                    {
                        if (gvPeriodos.Rows[0].Cells[1].Text != "" && gvPeriodos.Rows[0].Cells[2].Text != "" && gvPeriodos != null && gvDocumentos != null && gvDocumentos.Rows[0].Cells[4].Text != "" && gvDocumentos.Rows[0].Cells[5].Text != "")
                        {
                            estado = "31550";
                            DP.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUP"]), "3", "16", Convert.ToInt32(estado),
                            Convert.ToInt32(372), Convert.ToInt32(ddlTipoDocumento.SelectedValue), gvDocumentos.Rows[0].Cells[4].Text, gvDocumentos.Rows[0].Cells[5].Text, institucion, "",
                            "", gvPeriodos.Rows[0].Cells[1].Text, gvPeriodos.Rows[0].Cells[2].Text, "5", BanderaInstitucion, txtReferencia.Text, txtObservacionDoc.Text, "Periodo Devolucion TGN", 0, 0, ref mensaje);
                            sw = 1;
                        }
                        else
                        {

                            sw2 = 0;
                        }
                    }
                }
                if (sw1)
                {
                    if (ddlTipoDeuda.SelectedValue == "746")
                    {
                        estado = "31550";
                    }

                    DP.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUP"]), "3", "16", Convert.ToInt32(estado),
                    Convert.ToInt32(372), Convert.ToInt32(ddlTipoDocumento.SelectedValue), gvDocumentos.Rows[0].Cells[4].Text, gvDocumentos.Rows[0].Cells[5].Text, institucion, "",
                    "", gvPeriodos.Rows[0].Cells[1].Text, gvPeriodos.Rows[0].Cells[2].Text, "5", BanderaInstitucion, txtReferencia.Text, txtObservacionDoc.Text, "", 0, 0, ref mensaje);
                }
            }
            if (sw2 == 1)
            {
                int d = (int)Session["IdConexion"];
                string ff = txtFechaActual.Text.Substring(6, 4) + txtFechaActual.Text.Substring(3, 2) + txtFechaActual.Text.Substring(0, 2);

                string m = txtMontoTotal.Text/*.Replace(",", ".")*/;
                decimal MontoTotal = Convert.ToDecimal(m, System.Globalization.CultureInfo.GetCultureInfo("si"));
                bool Aplica = Convert.ToBoolean(ddlAplica.SelectedValue);

                decimal ww = Convert.ToDecimal(txtPorcentaje.Text);
                decimal ee = Convert.ToDecimal(txtPorcentaje.Text.Replace(",", "."));
                string beneficio = hfBeneficio.Value;
                if (hfBeneficio.Value == "")
                    beneficio = "COMPENSACION DE COTIZACIONES MENSUAL";

                string h = "";
                if (Session["id"] == null)
                {
                    h = GeneraNumeroLiquidacion();
                }
                else
                { 
                    h = txtNumeroLiquidacion.Text;
                }
                decimal t = Convert.ToDecimal(txtMontoTotal.Text.Replace(",", "."));
                Convenio.RegistraDeuda((int)Session["IdConexion"], "I", Convert.ToInt64(txtNUP.Text), "3", beneficio, lblSector.Text
                                       , h,
                                         ddlRegional.SelectedItem.ToString(), ddlMoneda.SelectedItem.ToString()
                                       , Convert.ToDecimal(txtMontoTotal.Text.Replace(",", ".")), Convert.ToDateTime(txtFechaActual.Text), ddlTipoDeuda.SelectedItem.ToString()
                                       , Convert.ToInt32(txtCuotas.Text), Convert.ToBoolean(ddlAplica.SelectedValue), ee
                                       , Convert.ToDecimal(txtMontoDescuento.Text.Replace(",", ".")), Convert.ToDecimal(txtMontoDeposito.Text.Replace(",", ".")), txtPeriodoInicio.Text
                                       , txtPeriodoFin.Text, txtObservaciones.Text, ddlEstadoDeuda.SelectedItem.ToString(), ref idver, ref mensaje);
                if (mensaje == null)
                {
                    if (sw == 1 || sw1)
                    {
                        estado = "364";
                        DP.InsertaRegistro((int)Session["IdConexion"], "I", Convert.ToInt64(Session["NUP"]), "3", "16", Convert.ToInt32(estado),
                          Convert.ToInt32(372), Convert.ToInt32(ddlTipoDocumento.SelectedValue), gvDocumentos.Rows[0].Cells[4].Text, gvDocumentos.Rows[0].Cells[5].Text, "0", "",
                          "", gvPeriodos.Rows[0].Cells[1].Text, gvPeriodos.Rows[0].Cells[2].Text, "5", "False", txtReferencia.Text, txtObservacionDoc.Text, "", 0, 0, ref mensaje);
                    }

                    hfIdDeuda.Value = idver.ToString();

                    if (btnRegistrarDeuda.Text.StartsWith("Registrar"))
                    {
                        foreach (GridViewRow r in gvPlanPagos.Rows)
                        {
                            Convenio.RegistraCuotaPlan((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
                                                        , Convert.ToInt32(r.Cells[0].Text), r.Cells[1].Text, r.Cells[2].Text, 0, Convert.ToDecimal(r.Cells[3].Text)
                                                        , Convert.ToDecimal(r.Cells[4].Text), false, ref mensaje);
                        }
                    }
                    if (hfParte.Value.IndexOf("|Plan") != -1)
                    {
                        //borramos el plan de cuotas anterior
                        Convenio.ModificaCuotaPlan((int)Session["IdConexion"], "U", "BorrarPlan", Convert.ToInt32(hfIdDeuda.Value), 0, "", "", 0, 0, 0, true, ref mensaje);
                        //ahora insertamos todas las cuotas de un nuevo plan
                        foreach (GridViewRow r in gvPlanPagos.Rows)
                        {
                            Convenio.RegistraCuotaPlan((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
                                                        , Convert.ToInt32(r.Cells[0].Text), r.Cells[1].Text, r.Cells[2].Text, 0, Convert.ToDecimal(r.Cells[3].Text)
                                                        , Convert.ToDecimal(r.Cells[4].Text), false, ref mensaje);
                        }
                    }
                    if (btnRegistrarDeuda.Text.StartsWith("Registrar"))//solo registramos en masivo cuando es REGISTRO no ACTUALIZACION
                    {
                        foreach (GridViewRow r in gvDocumentos.Rows)
                        {
                            string referencia = r.Cells[6].Text;
                            if (referencia == "&nbsp;")
                            {
                                referencia = "";
                            }
                            string observacion = r.Cells[7].Text;
                            if (observacion == "&nbsp;")
                            {
                                observacion = "";
                            }
                            Convenio.RegistraDocumento((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
                                            , r.Cells[3].Text, r.Cells[4].Text, Convert.ToDateTime(r.Cells[5].Text),referencia ,observacion , ref mensaje);
                        }
                        int institucion = 0;
                        if (ddlInstitucion.SelectedValue != "SELECCIONE...")
                        {
                            
                            institucion = Convert.ToInt32(ddlInstitucion.SelectedValue);
                        }

                        int x = gvPeriodos.Rows.Count;
                        int Aguinaldo = 0;

                        if (gvPeriodos != null && gvPeriodos.Rows.Count != 0 && ddlTipoDeuda.SelectedValue == "746" && gvListaPago != null && gvListaPago.Rows.Count != 0)
                        {
                            if (sw == 1 || sw1)
                            {

                                for (int i = 0; i < x; i++)
                                {
                                    Aguinaldo = 0;
                                    CheckBox chk_Publicar = (CheckBox)gvListaPago.Rows[i].Cells[5].FindControl("chkEnvio");
                                    if (chk_Publicar.Checked)
                                    {
                                        Aguinaldo = 1;
                                    }

                                    DP.RegistraPeriodo((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text), "Periodo Devolucion TGN",
                                                                   gvPeriodos.Rows[i].Cells[1].Text, gvPeriodos.Rows[i].Cells[2].Text, institucion, Aguinaldo, ref mensaje);
                                }
                            }
                            else
                            {

                                for (int i = 0; i < x; i++)
                                {
                                    Aguinaldo = 0;
                                    CheckBox chk_Publicar = (CheckBox)gvListaPago.Rows[i].Cells[5].FindControl("chkEnvio");
                                    if (chk_Publicar.Checked)
                                    {
                                        Aguinaldo = 1;
                                    }
                                    DP.RegistraPeriodo((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text), "Periodo Devolucion TGN",
                                                                   gvPeriodos.Rows[i].Cells[1].Text, gvPeriodos.Rows[i].Cells[2].Text, institucion, Aguinaldo, ref mensaje);
                                }
                            }
                        }
                        else
                        {
                            if (gvPeriodos != null && gvPeriodos.Rows.Count != 0 && ddlTipoDeuda.SelectedValue == "746" && gvListaPago != null)
                            {
                                for (int i = 0; i < x; i++)
                                {
                                    Aguinaldo = 0;
                                    DP.RegistraPeriodo((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text), "Periodo Devolucion TGN",
                                                                   gvPeriodos.Rows[i].Cells[1].Text, gvPeriodos.Rows[i].Cells[2].Text, institucion, Aguinaldo, ref mensaje);
                                }
                            }
                            
                        }
                        /*foreach (GridViewRow r in gvLiquidacionDeuda.Rows)
                        {
                            idTM = Convert.ToInt32(gvLiquidacionDeuda.DataKeys[r.RowIndex].Values["IdTipoMoneda"]);
                            Convenio.RegistraTipoCambio((int)Session["IdConexion"], "I", r.Cells[0].Text.Substring(0,10), idTM, Convert.ToDecimal(r.Cells[3].Text)
                                                        , ref mensaje);
                        }*/

                    }

                    if(txtDireccion.Text == Session["Direccion"].ToString())
                    {
                        txtDireccion.Text = "";
                    }
                    if (txtCel.Text == Session["Cel"].ToString())
                    {
                        txtCel.Text = "";
                    }
                    if (txtCelReferencial.Text == Session["CelRef"].ToString())
                    {
                        txtCelReferencial.Text = "";
                    }
                    if (txtTelefono.Text == Session["Tele"].ToString())
                    {
                        txtTelefono.Text = "";
                    }

                    string pp = ddlExtension.SelectedValue;
                    int ii = Convert.ToInt32(ddlLocalidad.SelectedValue);
                   Convenio.ModificaDatosPersona
                   ((int)Session["IdConexion"], "U", Convert.ToInt32(txtNUP.Text), txtDireccion.Text, txtCel.Text, txtCelReferencial.Text, txtTelefono.Text, ddlExtension.SelectedValue, Convert.ToInt32(ddlLocalidad.SelectedValue), ref mensaje); 

                }
                if (mensaje == null)
                {
                    Master.MensajeOk("Se registró/actualizó la deuda correctamente");
                    btnRegistrarDeuda.Text = "Registrar Deuda";
                    pnlRegistro.Enabled = false;
                    pnlLiquidacion.Enabled = false;
                    pnlPlan.Enabled = false;
                    pnlDocumentos.Enabled = false;
                    txtDireccion.ReadOnly=false;
                    txtCel.ReadOnly = false;
                    txtCelReferencial.ReadOnly = false;
                    txtTelefono.ReadOnly = false;
                    CargaDeudas();
                    lblMensaje.Text = "SE REGISTRÓ DE FORMA CORRECTA EL CONVENIO";
                    this.ModalPopupExtender3pnlMensaje.Show();
                    btnImprimirPlan.Enabled = true;
                    btnImprimirPlan.Visible = true;
                    btnImprimirDeuda.Enabled = true;
                    btnImprimirDeuda.Visible = true;

                    ddlExtension.Enabled = false;
                    ddlDepartamento.Enabled = false;
                    ddlLocalidad.Enabled = false;

                    lblMesRetiro.Visible = true;
                    txtMesRetiro.Visible = true;
                    ImageButton7.Visible = true;
                    lblFechaPago.Visible = true;
                    txtFechaPago.Visible = true;
                    ImageButton8.Visible = true;
                 }
                else
                {
                    Master.MensajeError("Error al intentar registrar la deuda", mensaje);
                    btnRegistrarDeuda.Enabled = true;
                }
            }
            else
            {
                string script = @"<script type='text/javascript'>alert('PORFAVOR INGRESE LOS 2 PERIDOS INICIO Y FIN TGN');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            if (Valida_Celular() && Valida_Telefono() & Valida_CelularReferencia())
            {
                if (/*hfParte.Value.IndexOf("|Deuda") != -1 &&*/ btnRegistrarDeuda.Text.StartsWith("Actualizar Deuda"))
                {

                    Convenio.ModificaDeuda((int)Session["IdConexion"], "U", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
                                           , txtNumeroLiquidacion.Text, Convert.ToInt32(ddlRegional.SelectedValue), Convert.ToInt32(ddlMoneda.SelectedValue)
                                           , Convert.ToDecimal(txtMontoTotal.Text.Replace(",", ".")), Convert.ToDateTime(txtFechaActual.Text), Convert.ToInt32(ddlTipoDeuda.SelectedValue)
                                           , Convert.ToInt32(txtCuotas.Text), Convert.ToBoolean(ddlAplica.SelectedValue), Convert.ToDecimal(txtPorcentaje.Text.Replace(",", "."))
                                           , Convert.ToDecimal(txtMontoDescuento.Text.Replace(",", ".")), Convert.ToDecimal(txtMontoDeposito.Text.Replace(",", ".")), txtPeriodoInicio.Text
                                           , txtPeriodoFin.Text, txtObservaciones.Text, Convert.ToInt32(ddlEstadoDeuda.SelectedValue), ref mensaje);
                    /*  DP.ModificaPeriodo((int)Session["IdConexion"], "U", hfIdDeuda.Value, lblIdInstitucion.Text, ddlInstitucion.SelectedIndex.ToString()
                       , "", "", "C1", ref mensaje);
                  */
                }
                if (mensaje == null)
                {
                    string Direccion = "";
                    string Celular = "";
                    string CelRefencia = "";
                    string Telefono = "";
                    if (txtDireccion.Text != Session["Direccion"].ToString())
                    {
                        Direccion = txtDireccion.Text;
                    }
                    if (txtCel.Text != Session["Cel"].ToString())
                    {
                        Celular = txtCel.Text;
                    }

                    if (txtCelReferencial.Text != Session["CelRef"].ToString())
                    {
                        CelRefencia = txtCelReferencial.Text;
                    }
                    if (txtTelefono.Text != Session["Tele"].ToString())
                    {
                        Telefono = txtTelefono.Text;
                    }

                    //Convenio.ModificaDatosPersona((int)Session["IdConexion"], "U", Convert.ToInt32(txtNUP.Text), Direccion, Celular, CelRefencia, Telefono, ref mensaje);
                    Convenio.ModificaDatosPersona
                    ((int)Session["IdConexion"], "U", Convert.ToInt32(txtNUP.Text), txtDireccion.Text, txtCel.Text, txtCelReferencial.Text, txtTelefono.Text, ddlExtension.SelectedIndex.ToString(), Convert.ToInt32(ddlLocalidad.SelectedValue), ref mensaje); 
                    //mensaje = null;
                    if (hfParte.Value.IndexOf("|Plan") != -1)
                    {
                        //borramos el plan de cuotas anterior
                        Convenio.ModificaCuotaPlan((int)Session["IdConexion"], "U", "BorrarPlan", Convert.ToInt32(hfIdDeuda.Value), 0, "", "", 0, 0, 0, true, ref mensaje);
                        //ahora insertamos todas las cuotas de un nuevo plan
                        foreach (GridViewRow r in gvPlanPagos.Rows)
                        {
                            Convenio.RegistraCuotaPlan((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
                                                        , Convert.ToInt32(r.Cells[0].Text), r.Cells[1].Text, r.Cells[2].Text, 0, Convert.ToDecimal(r.Cells[3].Text)
                                                        , Convert.ToDecimal(r.Cells[4].Text), false, ref mensaje);
                        }
                    }


                    DP.BorraPeriodo((int)Session["IdConexion"], "U", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text), ref mensaje);

                    int institucion = 0;
                    if (ddlInstitucion.SelectedValue != "SELECCIONE...")
                    {

                        institucion = Convert.ToInt32(ddlInstitucion.SelectedValue);
                    }
                    int x = gvPeriodos.Rows.Count;
                    if (gvPeriodos != null && gvPeriodos.Rows.Count != 0 && ddlTipoDeuda.SelectedValue == "746")
                    {
                        int Aguinaldo = 0;
                        for (int i = 0; i < x; i++)
                        {
                            Aguinaldo = 0;
                            CheckBox chk_Publicar = (CheckBox)gvListaPago.Rows[i].Cells[5].FindControl("chkEnvio");
                            if (chk_Publicar.Checked)
                            {
                                Aguinaldo = 1;
                            }
                            DP.RegistraPeriodo((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text), "Periodo Devolucion TGN",
                                                           gvPeriodos.Rows[i].Cells[1].Text, gvPeriodos.Rows[i].Cells[2].Text, institucion, Aguinaldo, ref mensaje);
                        }
                    }
                    if (mensaje == null)
                    {

                        Master.MensajeOk("Se registró/actualizó la deuda correctamente");
                        btnRegistrarDeuda.Text = "Registrar Deuda";
                        pnlRegistro.Enabled = false;
                        pnlLiquidacion.Enabled = false;
                        pnlPlan.Enabled = false;
                        pnlDocumentos.Enabled = false;
                        txtDireccion.ReadOnly = true;
                        txtCel.ReadOnly = true;
                        txtCelReferencial.ReadOnly = true;
                        txtTelefono.ReadOnly = true;
                        CargaDeudas();
                        lblMensaje.Text = "SE ACTUALIZÓ DE FORMA CORRECTA EL CONVENIO";
                        this.ModalPopupExtender3pnlMensaje.Show();
                    }
                    else
                    {
                        Master.MensajeError("Error al intentar registrar la deuda", mensaje);
                        btnRegistrarDeuda.Enabled = true;
                    }
                }
                else
                {
                    btnRegistrarDeuda.Enabled = true;
                }
            }
            else
            {
                btnRegistrarDeuda.Enabled = true;
            }
        }
	}

	protected void btnPlanPagos_Click(object sender, EventArgs e){
        if (hfParte.Value.IndexOf("|Plan") == -1)
        {
            hfParte.Value += "|Plan";//para cuando sea actualizacion tb actualice el plan de pagos
        }
        bool Desc;
        if (ddlAplica.SelectedValue == "True")
        {
            Desc = true;
        }
        else
        {
            Desc = false;
        }

        if (txtCuotas.Text == "0")
        {
            if (txtMontoDeposito.Text == "0.00")
            {
                if (txtMontoDescuento.Text != "0.00" && Desc)
                {
                    decimal v1 = Convert.ToDecimal(txtSaldo.Text);
                    decimal v2 = Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si"));
                    txtCuotas.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) / Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si")), 0));
                }
                else
                {
                    decimal uu = ((Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))) * 20 / 100);
                    txtCuotas.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) / uu, 0));
                    if (ddlTipoDeuda.SelectedValue == "746")
                    {
                        txtMontoDeposito.Text = Convert.ToString(Math.Round(uu, 0));
                        txtMontoDescuento.Text = "0.00";
                    }
                    else
                    {
                        txtMontoDescuento.Text = Convert.ToString(Math.Round(uu, 0));
                        txtMontoDeposito.Text = "0.00";
                    }

                }
            }
            else
            {
                if (txtMontoDescuento.Text != "0.00" && Desc)
                    txtCuotas.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) / (Convert.ToDecimal(txtMontoDeposito.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) + Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))), 0));
                else
                {
                    decimal ii = Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si"));
                    decimal hh = (Convert.ToDecimal(txtMontoDeposito.Text));
                    txtCuotas.Text = Convert.ToString(Math.Round(ii / hh, 0));
                    if (txtCuotas.Text == "0" || txtCuotas.Text == "")
                        txtCuotas.Text = "1";
                }

            }

        }

        else
        {
            string montodeudae = txtMontoTotal.Text;
            if (txtSaldo.Text != "" && txtSaldo.Text != "0.00")
            {
                montodeudae = txtSaldo.Text;
            }
            decimal uu
             = Math.Round(Convert.ToDecimal(montodeudae, System.Globalization.CultureInfo.GetCultureInfo("si")) / Convert.ToDecimal(txtCuotas.Text, System.Globalization.CultureInfo.GetCultureInfo("si")), 0);

            if (ddlTipoDeuda.SelectedValue == "746")
            {
                txtMontoDeposito.Text = Convert.ToString(Math.Round(uu, 0));
            }
            else
            {
                if (Desc)
                {
                    txtMontoDescuento.Text = Convert.ToString(Math.Round(uu, 0));
                    txtMontoDeposito.Text = "0.00";

                }
                else
                {
                    txtMontoDeposito.Text = Convert.ToString(Math.Round(uu, 0));
                    txtMontoDescuento.Text = "0.00";
                }
            }


        }
        string montodeuda = txtMontoTotal.Text;
        if (txtSaldo.Text != "" && txtSaldo.Text!="0.00")
        {
            montodeuda = txtSaldo.Text;
        }

        //txtPeriodoFin.Text = DateTime.Now.AddMonths(Convert.ToInt32(txtCuotas.Text)).Year.ToString() + DateTime.Now.AddMonths(Convert.ToInt32(txtCuotas.Text)).Month.ToString("00");

        string mesInicio = txtPeriodoInicio.Text;

        string numCuotas = txtCuotas.Text;
        // nº de meses = Nº de mes + nº de cuotas
        int rr = Convert.ToInt32(mesInicio.Substring(4, 2));
        int meses = Convert.ToInt32(mesInicio.Substring(4, 2)) + (Convert.ToInt32(numCuotas) - 1);
        //var meses = parseInt(mesInicio.slice(4)) + parseInt(numCuotas - 1);
        // Año = Año actual + (nº de meses / 12)
        int ee = Convert.ToInt32(mesInicio.Substring(0, 4));
        int tt = Convert.ToInt32(Math.Round(Convert.ToDouble(meses / 12), 0));

        double yy = 0.00;
        double ww = Convert.ToDouble(Convert.ToDouble(meses) / 12.00);

        if (Convert.ToDouble(Convert.ToDouble(meses) / 12.00) == 1)
            yy = 0;
        else
            yy = Convert.ToDouble(meses / 12);

        int anno = Convert.ToInt32(mesInicio.Substring(0, 4)) + Convert.ToInt32(Math.Round(yy, 0));
        //var anno = parseInt(mesInicio.slice(0, 4)) + Math.floor(meses / 12);
        // Mes = Resto de dividir el nº de meses entre 12

        var mes = (meses % 12);
        mes = (mes == 0 ? 1 : mes);
        if (meses == 12)
            mes = 12;
        // Formateamos la cadena
        var mesFin = Convert.ToString(anno) + (mes < 10 ? "0" : "") + Convert.ToString(mes);
        // Se asigna el valor al control txxtPeriodoFin
        txtPeriodoFin.Text = mesFin;



        decimal dd = 0;
        if (hfMontoCC.Value == "0,00")
        {
            dd = Convert.ToDecimal(txtMontoTotal.Text);
        }
        else
        {
            dd = Convert.ToDecimal(hfMontoCC.Value.Replace(",", "."));
        }

        GeneraPlanPagos(dd,
            Convert.ToDecimal(montodeuda, System.Globalization.CultureInfo.GetCultureInfo("si")), Convert.ToInt32(txtCuotas.Text)
            , Desc, Convert.ToDecimal(txtPorcentaje.Text, System.Globalization.CultureInfo.GetCultureInfo("si")),
            Convert.ToDecimal(txtMontoDeposito.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))
            , Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si")),
            txtPeriodoInicio.Text, txtPeriodoFin.Text,
            Convert.ToDecimal(txtMontoPrimerDeposito.Text, System.Globalization.CultureInfo.GetCultureInfo("si")));

        if (gvPlanPagos != null)
        {
            btnRegistrarDeuda.Enabled = true;
        }
        DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Edad", "", "", "", "", "", "",txtPeriodoInicio.Text
                                                          , Convert.ToInt64(Session["NUP"]), Convert.ToInt32(txtCuotas.Text), ref mensaje);
        EdadActual.Text = Origen.Rows[0][0].ToString() + " Años, con " + Origen.Rows[0][1].ToString() + " Meses.";
        EdadFinal.Text = Origen.Rows[0][2].ToString() + " Años, con " + Origen.Rows[0][3].ToString() + " Meses.";
    }

    
    protected void GeneraPlanPagos()
	{
		if (hfParte.Value.IndexOf("|Plan") == -1)
		{
			hfParte.Value += "|Plan";//para cuando sea actualizacion tb actualice el plan de pagos
		}
		bool Desc;
		if (ddlAplica.SelectedValue == "True")
		{
			Desc = true;
		}
		else
		{
			Desc = false;
		}

        txtCuotas.Text = "0";
		if (txtCuotas.Text == "0")
		{
			if (txtMontoDeposito.Text == "0.00")
			{
				if (txtMontoDescuento.Text != "0.00" && Desc)
				{
					decimal v1 = Convert.ToDecimal(txtSaldo.Text);
					decimal v2 = Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si"));
					txtCuotas.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) / Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si")), 0));
				}
				else
				{
					decimal uu = ((Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))) * 20 / 100);
					txtCuotas.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) / uu, 0));
				}
			}
			else
			{
				if (txtMontoDescuento.Text != "0.00" && Desc)
					txtCuotas.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) / (Convert.ToDecimal(txtMontoDeposito.Text, System.Globalization.CultureInfo.GetCultureInfo("si")) + Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))), 0));
				else
				{
					decimal ii = Convert.ToDecimal(txtSaldo.Text, System.Globalization.CultureInfo.GetCultureInfo("si"));
					decimal hh = (Convert.ToDecimal(txtMontoDeposito.Text));
					txtCuotas.Text = Convert.ToString(Math.Round(ii / hh, 0));
				}
			}

		}

		else
		{
			string montodeudae = txtMontoTotal.Text;
			if (txtSaldo.Text != "")
			{
				montodeudae = txtSaldo.Text;
			}
			decimal uu
			 = Math.Round(Convert.ToDecimal(montodeudae, System.Globalization.CultureInfo.GetCultureInfo("si")) / Convert.ToDecimal(txtCuotas.Text, System.Globalization.CultureInfo.GetCultureInfo("si")), 0);
			

		
		}
		string montodeuda = txtMontoTotal.Text;
		if (txtSaldo.Text != "")
		{
			montodeuda = txtSaldo.Text;
		}

		    //txtPeriodoFin.Text = DateTime.Now.AddMonths(Convert.ToInt32(txtCuotas.Text)).Year.ToString() + DateTime.Now.AddMonths(Convert.ToInt32(txtCuotas.Text)).Month.ToString("00");

            string mesInicio = txtPeriodoInicio.Text;
         
            string numCuotas = txtCuotas.Text;
            // nº de meses = Nº de mes + nº de cuotas
            int rr = Convert.ToInt32(mesInicio.Substring(4, 2));
            int meses = Convert.ToInt32(mesInicio.Substring(4,2))+(Convert.ToInt32(numCuotas)-1);
            //var meses = parseInt(mesInicio.slice(4)) + parseInt(numCuotas - 1);
            // Año = Año actual + (nº de meses / 12)
            int ee = Convert.ToInt32(mesInicio.Substring(0, 4));
            int tt = Convert.ToInt32(Math.Round(Convert.ToDouble(meses / 12), 0));
            
            double yy =0.00;
            double ww = Convert.ToDouble(Convert.ToDouble(meses) / 12.00);
            
            if (Convert.ToDouble(Convert.ToDouble(meses) / 12.00) == 1)
                yy = 0;
            else
                yy = Convert.ToDouble(meses / 12);
            
            int anno = Convert.ToInt32(mesInicio.Substring(0,4)) +Convert.ToInt32(Math.Round(yy,0));
            //var anno = parseInt(mesInicio.slice(0, 4)) + Math.floor(meses / 12);
            // Mes = Resto de dividir el nº de meses entre 12
            
            var mes = (meses % 12);
            mes = (mes == 0 ? 1 : mes);
            if (meses == 12)
                mes = 12;
            // Formateamos la cadena
            var mesFin = Convert.ToString(anno)+ (mes < 10 ? "0" : "") + Convert.ToString(mes);
            // Se asigna el valor al control txxtPeriodoFin
            txtPeriodoFin.Text = mesFin;



        decimal dd = 0;
        if (hfMontoCC.Value == "0,00")
        {
            dd = Convert.ToDecimal(txtMontoTotal.Text);
        }
        else
        {
            dd = Convert.ToDecimal(hfMontoCC.Value.Replace(",","."));
        }

        GeneraPlanPagos(dd, 
            Convert.ToDecimal(montodeuda, System.Globalization.CultureInfo.GetCultureInfo("si")), Convert.ToInt32(txtCuotas.Text)
			, Desc, Convert.ToDecimal(txtPorcentaje.Text, System.Globalization.CultureInfo.GetCultureInfo("si")),
            Convert.ToDecimal(txtMontoDeposito.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))
			, Convert.ToDecimal(txtMontoDescuento.Text, System.Globalization.CultureInfo.GetCultureInfo("si")),
            txtPeriodoInicio.Text, txtPeriodoFin.Text,
			Convert.ToDecimal(txtMontoPrimerDeposito.Text, System.Globalization.CultureInfo.GetCultureInfo("si")));

        if (gvPlanPagos != null)
        {
            btnRegistrarDeuda.Enabled = true;
        }
        DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Edad", "", "", "", "", "", "",txtPeriodoInicio.Text
                                                          , Convert.ToInt64(Session["NUP"]), Convert.ToInt32(txtCuotas.Text), ref mensaje);
        EdadActual.Text = Origen.Rows[0][0].ToString() + " Años, con " + Origen.Rows[0][1].ToString() + " Meses.";
        EdadFinal.Text = Origen.Rows[0][2].ToString() + " Años, con " + Origen.Rows[0][3].ToString() + " Meses.";

	}

	protected void btnImprimirPlan_Click(object sender, EventArgs e)
	{
		//Response.Write("<script>");
		//Response.Write("window.open('../Reportes/wfrmReporteCertificadoCC.aspx','_blank')");
		////Response.Write("window.open('wfrmReporteDeuda.aspx','_blank')");
		//Response.Write("</script>");
		Session["id"] = (hfIdDeuda.Value);
		Session["informe"] = "rptConvenioPlanPagos";
	   // Response.Redirect("wfrmReportePlanPagos.aspx");
		string script = "window.open('wfrmReportePlanPagos.aspx', '');";
		
		ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
	}

	protected void btnAgregarDoc_Click(object sender, EventArgs e)
	{
		//mensaje = null;
		//try
		//{
		//    Convenio.RegistraDocumento((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
		//                                , ddlTipoDocumento.SelectedItem.ToString(), txtNroDoc.Text, Convert.ToDateTime(txtFechaDocumento.Text)
		//                                , txtReferencia.Text, txtObservacionDoc.Text, ref mensaje);
		//}
		//catch
		//{
		//}
		//solo colocamos en un data table y al greedview
		DataTable Docs_temp = Session["DOC"] as DataTable;
		int NumDoc;
		if (gvDocumentos == null)
		{
			NumDoc = 1;
		}
		else
		{
			NumDoc = gvDocumentos.Rows.Count + 1;
		}
		try
		{
			if (btnAgregarDoc.Text.StartsWith("Agregar"))//agregamos
			{
                if (txtReferencia.Text == "&nbsp;")
                    txtReferencia.Text = "";

                if (txtObservacionDoc.Text == "&nbsp;")
                    txtObservacionDoc.Text = "";

				Docs_temp.Rows.Add(NumDoc, 0, Convert.ToInt32(ddlTipoDocumento.SelectedValue), ddlTipoDocumento.SelectedItem.ToString(), txtNroDoc.Text, Convert.ToDateTime(txtFechaDocumento.Text)
									, txtReferencia.Text, txtObservacionDoc.Text, DateTime.Now.Date);

              
                if (ddlTipoDocumento.SelectedValue == "749" || ddlTipoDocumento.SelectedValue == "31573" || ddlTipoDocumento.SelectedValue == "31574")
                {
                    if(Session["id"] == null)
                    {
                        Session["id"]  = ddlTipoDocumento.SelectedValue;
                    }
                }
        		//cargar la gv
				gvDocumentos.DataSourceID = null;
				gvDocumentos.DataSource = Docs_temp;
				gvDocumentos.DataBind();
				Session["DOC"] = Docs_temp;

                ddlTipoDocumento.SelectedIndex = 0;
                //txtNroDoc.Text = "";
                txtNroDoc.Text = txtNumeroLiquidacion.Text;
                txtFechaDocumento.Text = "";
                txtReferencia.Text = ""; 
                txtObservacionDoc.Text = "";
			}
			else //modificamos
			{
				//ver si esta antes de grabar o despues
				if (btnRegistrarDeuda.Text.StartsWith("Registrar"))
				{
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][2] = Convert.ToInt32(ddlTipoDocumento.SelectedValue);
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][3] = ddlTipoDocumento.SelectedItem.ToString();
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][4] = txtNroDoc.Text;
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][5] = Convert.ToDateTime(txtFechaDocumento.Text);
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][6] = txtReferencia.Text;
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][7] = txtObservacionDoc.Text;
					Docs_temp.Rows[Convert.ToInt32(lblFilaDocumento.Text)][8] = DateTime.Now.Date;
					gvDocumentos.DataSourceID = null;
					gvDocumentos.DataSource = Docs_temp;
					gvDocumentos.DataBind();
					Session["DOC"] = Docs_temp;
					btnAgregarDoc.Text = "Agregar Documento";
				}
				else//si ya esta en la DB
				{
					Convenio.ModificaDocDeuda((int)Session["IdConexion"], "U", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt32(lblIdDocumento.Text)
											, Convert.ToInt64(txtNUP.Text), Convert.ToInt32(ddlTipoDocumento.SelectedValue), txtNroDoc.Text
											, Convert.ToDateTime(txtFechaDocumento.Text), txtReferencia.Text, txtObservacionDoc.Text, "Modificar", ref mensaje);
					if (mensaje == null)
					{
             
                        CargarDocumentacion(Convert.ToInt32(hfIdDeuda.Value));
                        Master.MensajeOk("Se actualizó el documento correctamente");
                        ddlTipoDocumento.SelectedIndex = 0;
                        txtNroDoc.Text = "";
                        txtFechaDocumento.Text = "";
                        txtReferencia.Text = "";
                        txtObservacionDoc.Text = "";
					}
					else
					{
						Master.MensajeError("Error al modificar el documento", mensaje);
					}
				}

			}
		}
		catch (Exception ex)
		{
			Master.MensajeError("Error al agregar Docuemnto Deuda", ex.Message);
		}

	}

	protected void btnGuardarDoc_Click(object sender, EventArgs e)
	{
		mensaje = null;

		if (lblIdDocumento.Text == "0")
		{
			Convenio.RegistraDocumento((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
										, ddlTipoDocumento.SelectedItem.ToString(), txtNroDoc.Text, Convert.ToDateTime(txtFechaDocumento.Text)
										, txtReferencia.Text, txtObservacionDoc.Text, ref mensaje);
		}
		else
		{
			Convenio.ModificaDocDeuda((int)Session["IdConexion"], "U", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt32(lblIdDocumento.Text)
									   , Convert.ToInt64(txtNUP.Text), Convert.ToInt32(ddlTipoDocumento.SelectedValue), txtNroDoc.Text
									   , Convert.ToDateTime(txtFechaDocumento.Text), txtReferencia.Text, txtObservacionDoc.Text, "Modificar", ref mensaje);
		}
		if (mensaje == null)
		{
			Master.MensajeOk("Se registró la documentación correctamente");
			CargarDocumentacion(Convert.ToInt32(hfIdDeuda.Value));
		}
		else
		{
			Master.MensajeError("Error al intentar registrar la documentación", mensaje);
		}
	}

	private void LimpiarDocs()
	{
		lblIdDocumento.Text = "0";
		ddlTipoDocumento.SelectedIndex = 0;
		txtReferencia.Text = "";
		txtNroDoc.Text = "";
		txtObservacionDoc.Text = "";
		txtFechaDocumento.Text = DateTime.Now.Date.ToString();
	}

	protected void btnImprimirDeuda_Click(object sender, EventArgs e)
	{
		//Response.Write("<script>");
		//Response.Write("window.open('../Reportes/wfrmReporteCertificadoCC.aspx','_blank')");
		////Response.Write("window.open('wfrmReporteDeuda.aspx','_blank')");
		//Response.Write("</script>");
		Session["id"] = (hfIdDeuda.Value);
		if(ddlTipoDeuda.SelectedValue !="746")
        {Session["informe"] = "rptDetalleDeuda";}
		// Response.Redirect("wfrmReportePlanPagos.aspx");
        else
        {
           /* DataTable Deudas = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoDocConvenios", "", "", "", "", "", "", ""
                                                   ,0,Convert.ToInt32(hfIdDeuda.Value), ref mensaje);
            //Saldo.Rows[0][2].ToString()
            if (Deudas.Rows.Count > 0)
                Session["informe"] = "rptLiquidacion";
            else
            { Session["informe"] = "rptLiquidacion1"; 
            }
            */
            if (gvPlanPagos.Rows.Count <= 5)
            {
                if (gvPlanPagos.Rows.Count == 1)
                {
                    Session["TipoForm"] = "001";
                    Session["informe"] = "FORM01";
                    Session["MesRetiro"]= txtMesRetiro.Text;
                    Session["FechaPago"] = txtFechaPago.Text;
                }
                else
                { 
                    Session["TipoForm"] = "002";
                    Session["informe"] = "FORM02";
                }
                 
            }
            else
            {
                Session["informe"] = "rptLiquidacion";
            }

       }        
        
		string script = "window.open('wfrmReportePlanPagos.aspx', '');";
		ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);

		mensaje = null;

	}

	protected void btnCancelar_Click(object sender, EventArgs e)
	{
		Response.Redirect("~/Convenios/wfrmVerDeuda.aspx");
	}


	private void GeneraPlanPagos(decimal MontoCC, decimal MontoDeuda, int Cuotas, bool Descuento, decimal Porcentaje, decimal MontoDeposito
									, decimal MontoDescuento, string Inicio, string Fin, decimal MontoPrimerDeposito)
	{
		//creamos la tabla para almacenar el plan de pagos
		DataTable PlanCuotas = new DataTable();
		PlanCuotas.Columns.Add(new DataColumn("Numero", Type.GetType("System.Int32")));
		PlanCuotas.Columns.Add(new DataColumn("Tipo", Type.GetType("System.String")));
		PlanCuotas.Columns.Add(new DataColumn("Periodo", Type.GetType("System.String")));
		PlanCuotas.Columns.Add(new DataColumn("Monto", Type.GetType("System.Decimal")));
		PlanCuotas.Columns.Add(new DataColumn("Referencial", Type.GetType("System.Decimal")));
		decimal MontoCuota = 0;
		decimal TotalPagado = 0;
		string Mes;
		DateTime F1 = Convert.ToDateTime("01/" + Inicio.Substring(4, 2) + "/" + Inicio.Substring(0, 4));
		DateTime F2 = Convert.ToDateTime("01/" + Fin.Substring(4, 2) + "/" + Fin.Substring(0, 4));
		int c = 1,sw=0;

        int aa = 0;

        if (MontoPrimerDeposito != 0)//Ingresamos el primer deposito si existe
		{
           decimal PorcentajePrimerDescuento =0;
           if(MontoCC!=0)
		   PorcentajePrimerDescuento = Math.Round((MontoPrimerDeposito * 100) / MontoCC, 2);
           else
           PorcentajePrimerDescuento = Math.Round((MontoPrimerDeposito * 100) / MontoDeuda, 2);
			for (int i = 0; i < 1; i++)
			{
				MontoCuota = MontoPrimerDeposito;
				Mes = Convert.ToDateTime(F1).AddMonths(i).Year.ToString() + Convert.ToDateTime(F1).AddMonths(i).Month.ToString("00");
				PlanCuotas.Rows.Add(i+1, "DEPOSITO", Mes, MontoCuota, PorcentajePrimerDescuento);
			}
			sw = 1;
    	}
		if (sw == 1)
		{
			c++;
            aa = aa + 1;
    //        Fin = Convert.ToString(Convert.ToInt32(Fin) + 1);
            Fin = Convert.ToDateTime(F2).AddMonths(1).Year.ToString() + Convert.ToDateTime(F2).AddMonths(1).Month.ToString("00");
		}
		if (Descuento && MontoDeposito <= 0)//solo descuento
		{
            if (MontoCC > 0)
			    Porcentaje = Math.Round((MontoDescuento * 100) / MontoCC, 2);
            else
                Porcentaje = 0;

			for (int i = 0; i < Cuotas - 1; i++)
			{
				MontoCuota = MontoDescuento;
                Mes = Convert.ToDateTime(F1).AddMonths(i + aa).Year.ToString() + Convert.ToDateTime(F1).AddMonths(i + aa).Month.ToString("00");
				PlanCuotas.Rows.Add(i + c, "DESCUENTO AUTOMATICO", Mes, MontoCuota, Porcentaje);
			}
			//calculos para la ultima cuota
			Mes = Fin;
			MontoCuota = MontoDeuda - (MontoDescuento * (Cuotas - 1));
            if (MontoCuota != 0)
            {
                if (MontoCC > 0)
                    Porcentaje = Math.Round(((MontoCuota * 100) / MontoCC), 2);
                else
                    Porcentaje = 0;

                if (sw == 1)
                    Cuotas++;
                PlanCuotas.Rows.Add(Cuotas, "DESCUENTO AUTOMATICO", Mes, MontoCuota, Porcentaje);
            }
		}
		if (!Descuento && MontoDeposito >= 0)//solo depositos
		{
            if (MontoCC > 0)
                Porcentaje = Math.Round((MontoDeposito * 100) / MontoCC, 2);
            else
                Porcentaje = 0;
			for (int i = 0; i < Cuotas - 1; i++)
			{
				MontoCuota = MontoDeposito;
                Mes = Convert.ToDateTime(F1).AddMonths(i + aa).Year.ToString() + Convert.ToDateTime(F1).AddMonths(i + aa).Month.ToString("00");
				PlanCuotas.Rows.Add(i + c, "DEPOSITO", Mes, MontoCuota, Porcentaje);
			}
			//calculos para la ultima cuota
			Mes = Fin;
			MontoCuota = MontoDeuda - (MontoDeposito * (Cuotas - 1));
            if (MontoCuota!=0)
            {
                if (MontoCC > 0)
                     Porcentaje = Math.Round((MontoCuota * 100) / MontoCC, 2);
                else
                    Porcentaje = 0;
			    if (sw == 1)
				    Cuotas++;
			    PlanCuotas.Rows.Add(Cuotas, "DEPOSITO", Mes, MontoCuota, Porcentaje);
            }
		}
		if (Descuento && MontoDeposito > 0)//mixto
		{
            decimal MontoCuota2 = 0; decimal Porcentaje2 = 0;

            if (MontoCC > 0)
                Porcentaje2 = Math.Round((MontoDeposito * 100) / MontoCC, 2);
            else
                Porcentaje2 = 0;

			for (int i = 0; i < Cuotas - 1; i++)
			{
				MontoCuota = MontoDescuento;
				MontoCuota2 = MontoDeposito;
                Mes = Convert.ToDateTime(F1).AddMonths(i + aa).Year.ToString() + Convert.ToDateTime(F1).AddMonths(i + aa).Month.ToString("00");
				PlanCuotas.Rows.Add(i + c, "DESCUENTO AUTOMATICO", Mes, MontoCuota, Porcentaje);
				PlanCuotas.Rows.Add(i + c, "DEPOSITO", Mes, MontoCuota2, Porcentaje2);
				TotalPagado += MontoCuota + MontoCuota2;
			}
			//calculos para la ultima cuota
			if (sw == 1)
				Cuotas++;
			Mes = Fin;
			if (MontoDescuento <= (MontoDeuda - TotalPagado))//hacemos und escuento y el saldo para deposito
			{
				MontoCuota = MontoDescuento;
				PlanCuotas.Rows.Add(Cuotas, "DESCUENTO AUTOMATICO", Mes, MontoCuota, Porcentaje);
				TotalPagado += MontoCuota;
				//////////////////////////

				MontoCuota = MontoDeuda - TotalPagado;
                if (MontoCuota != 0)
                {
                    if (MontoCC > 0)
                        Porcentaje2 = Math.Round((MontoCuota * 100) / MontoCC, 2);
                    else
                        Porcentaje2 = 0;
                    PlanCuotas.Rows.Add(Cuotas, "DEPOSITO", Mes, MontoCuota, Porcentaje2);
                }
			}
			else//de los contrario solo hacemos un ultimo descuento con una cuota reducida
			{
				MontoCuota = MontoDeuda - TotalPagado;
                if (MontoCuota != 0)
                {
                    if (MontoCC > 0)
                        Porcentaje2 = Math.Round((MontoCuota * 100) / MontoCC, 2);
                    else
                        Porcentaje2 = 0;

                    PlanCuotas.Rows.Add(Cuotas, "DESCUENTO AUTOMATICO", Mes, MontoCuota, Porcentaje2);
                }
			}
		}
		gvPlanPagos.DataSourceID = null;
		gvPlanPagos.DataSource = PlanCuotas;
		gvPlanPagos.DataBind();
	}

	protected void lnkTipoCambio_Click(object sender, EventArgs e)
	{
		//txtFechaTC.Text = txtFechaActual.Text;
		//this.pnlTipoCambio_ModalPopupExtender.Show();
        Response.Redirect("~/EmisionCertificadoCC/wfrmTipoCambioConvenios.aspx");
    }

	protected void btnRegistraTC_Click(object sender, EventArgs e)
	{
		int idTM = 0;
		mensaje = null;
		foreach (GridViewRow r in gvLiquidacionDeuda.Rows)
		{
			//string fecha = Convert.ToDateTime(r.Cells[0].Text.Substring(0, 10) , "dd/mm/yy");
			//DateTime date = DateTime.ParseExact(r.Cells[0].Text/*.Substring(0,10)*/, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToShortDateString();
			idTM = Convert.ToInt32(gvLiquidacionDeuda.DataKeys[r.RowIndex].Values["IdTipoMoneda"]);
			//Convenio.RegistraTipoCambio((int)Session["IdConexion"], "I", Convert.ToDateTime(r.Cells[0].Text.Substring(0, 10)), idTM, Convert.ToDecimal(r.Cells[3].Text), ref mensaje);
			string ff = r.Cells[0].Text.Substring(6, 4) + r.Cells[0].Text.Substring(3, 2) + r.Cells[0].Text.Substring(0, 2);
			Convenio.RegistraTipoCambio((int)Session["IdConexion"], "I", ff, idTM, Convert.ToDecimal(r.Cells[3].Text), ref mensaje);
		}
		if (mensaje == null)
		{
			Master.MensajeOk("Se registro el Tipo de Cambio correctamente");
			btnRegistraTC.Enabled = false;
		}
		else
		{
			Master.MensajeError("Error al registrar el Tipo de Cambio.", mensaje);
		}
	}

	protected void btnCancelarTC_Click(object sender, EventArgs e)
	{

	}
   
	protected void btnAccionar_Click(object sender, EventArgs e)
	{
		DataTable TC_temp = Session["TC"] as DataTable;
		try
		{
			TC_temp.Rows.Add(Convert.ToDateTime(txtFechaTC.Text), ddlTipoMonedaTC.SelectedValue, ddlTipoMonedaTC.SelectedItem.ToString(), Convert.ToDecimal(txtTipoCambioTC.Text)
							 , Math.Round(Convert.ToDecimal(txtMontoTotal.Text) / Convert.ToDecimal(txtTipoCambioTC.Text), 2));
			//cargar la gv
			gvLiquidacionDeuda.DataSourceID = null;
			gvLiquidacionDeuda.DataSource = TC_temp;
			gvLiquidacionDeuda.DataBind();
			Session["TC"] = TC_temp;
		}
		catch (Exception ex)
		{
			Master.MensajeError("Error al introducir Tipo Cambio", ex.Message);
		}
	}

	protected void gvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int indice = Convert.ToInt32(e.CommandArgument);
		//int IdMoneda = Convert.ToInt32(gvDepositos.DataKeys[indice].Values["IdMoneda"].ToString());
		//int IdBanco = Convert.ToInt32(gvDepositos.DataKeys[indice].Values["IdBanco"].ToString());
		//hfBeneficio.Value = gvDeudas.DataKeys[indice].Values["Beneficio"].ToString();
		int IdDocumento = Convert.ToInt32(gvDocumentos.DataKeys[indice].Values["IdDocumento"]);
		if (e.CommandName == "cmdEditar")
		{
			try
			{
				CargaDocumentoEditar(indice);
			}
			catch (Exception ex)
			{
				Master.MensajeError("Error al intentar ver los datos del documento", ex.Message);
			}
		}
		if (e.CommandName == "cmdEliminar")
		{
			if (btnAgregarDoc.Text.StartsWith("Agregar Documento"))
			{
				DataTable DocsElimina = Session["DOC"] as DataTable;
				DocsElimina.Rows.Remove(DocsElimina.Rows[indice]);
				int n = 0;
				foreach (DataRow r in DocsElimina.Rows)
				{
					DocsElimina.Rows[n][0] = (n + 1);
					n += 1;
				}
				gvDocumentos.DataSourceID = null;
				gvDocumentos.DataSource = DocsElimina;
				gvDocumentos.DataBind();
				Session["DOC"] = DocsElimina;
				//gvDocumentos.DeleteRow(indice);
			}
			else
			{
				//OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
				//Response.Write("<script language=javascript>if(confirm('Movimiento guardado exitosamente. Desea ingresar un nuevo registro de \"" + lblNombreGraco.Text + "\"')==true){ location.href='wfGracosRegistroMovimiento.aspx';}else { location.href='wfGracosInicioMovimiento.aspx';}</script>");
				Convenio.ModificaDocDeuda((int)Session["IdConexion"], "U", Convert.ToInt32(hfIdDeuda.Value), IdDocumento, 0, 0, ""
											, DateTime.Now.Date, "", "", "Deshabilitar", ref mensaje);
				CargarDescuentos(Convert.ToInt32(hfIdDeuda.Value));
			}
		}
	}

	protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
	{
		Limpiar();
		pnlDeuda.Visible = true;
		pnlRegistro.Enabled = true;
		pnlLiquidacion.Enabled = true;
		pnlPlan.Enabled = true;
		pnlDocumentos.Enabled = true;
		pnlControl.Visible = false;
		//ddlRegional.SelectedIndex = 0;
		ddlMoneda.SelectedIndex = 1;
		ddlEstadoDeuda.Enabled = false;
        ddlTipoDeuda.SelectedIndex = 3;
		btnGuardarDoc.Enabled = false;
		btnAgregarDoc.Text="Agregar Documento";
		btnRegistrarDeuda.Text = "Registrar Deuda";
		gvPeriodos.Visible = false;
		gvListaPago.Visible = false;
		gvListaAguinaldo.Visible = false;
		btnImprimirPlan.Visible = false;
		btnImprimirDeuda.Visible = false;
        CargaTipoCambio();
        txtNumeroLiquidacion.Text = GeneraNumeroLiquidacion();
        txtNroDoc.Text = txtNumeroLiquidacion.Text;
        lblMesRetiro.Visible = false;
        txtMesRetiro.Visible = false;
        txtMesRetiro.Text = "";
        ImageButton7.Visible = false;
        lblFechaPago.Visible = false;
        txtFechaPago.Visible = false;
        txtFechaPago.Text = "";
        ImageButton8.Visible = false;

        ddlDepartamento.Enabled = true;
        ddlLocalidad.Enabled = true;
        if (ddlExtension.SelectedValue == "31512")
        {
            ddlExtension.Enabled = true;
        }
        else
        {
            ddlExtension.Enabled = false;
        }

	}

	private void Limpiar()
	{
		//ddlRegional.SelectedIndex = 1; //Session["IdOficina"].ToString();
		ddlTipoDeuda.SelectedIndex = 3;
		ddlMoneda.SelectedIndex = 0;
		//txtNumeroLiquidacion.Text = "";
		txtMontoTotal.Text = "";
		txtFechaActual.Text = DateTime.Now.Date.ToString().Replace(" 0:00:00", "");
		gvLiquidacionDeuda.DataSource = null;
		gvLiquidacionDeuda.DataBind();
		ddlAplica.SelectedIndex = 0;
		txtPorcentaje.Text = "0.00";
		txtPorcentaje.Enabled = true;
		txtMontoDeposito.Text = "0.00";
		txtMontoPrimerDeposito.Text = "0.00";
		txtCuotas.Text = "0";
		txtMontoDescuento.Text = "0.00";
		txtMontoDescuento.Enabled = true;
		txtMontoTotal.Text = "0.00";
		txtPeriodoInicio.Text = DateTime.Now.AddMonths(1).Year.ToString() + DateTime.Now.AddMonths(1).Month.ToString("00");
		txtPeriodoFin.Text = DateTime.Now.AddMonths(1).Year.ToString() + DateTime.Now.AddMonths(1).Month.ToString("00");
		txtObservaciones.Text = "";
		gvPlanPagos.DataSource = null;
		gvPlanPagos.DataBind();
		ddlTipoDocumento.SelectedIndex = 0;
		txtNroDoc.Text = txtNumeroLiquidacion.Text;
		txtReferencia.Text = "";
		txtObservacionDoc.Text = "";
		txtFechaDocumento.Text = "";
		gvDocumentos.DataSource = null;
		gvDocumentos.DataBind();
		//ddlTipoDeuda.Focus();
		txtPeriodoInicioDevTGN.Text = "";
		txtPeriodoFinDevTGN.Text = "";
        txtSaldo.Text = txtMontoTotal.Text;
        ddlEstadoDeuda.SelectedIndex = 3;
        txtDireccion.ReadOnly=false;
        txtCel.ReadOnly = false;
        txtCelReferencial.ReadOnly = false;
        txtTelefono.ReadOnly = false;
        if (ddlEstadoDeuda.SelectedIndex == 3)
        {
            muestraPanelDP();
        }
        else
        {
            ocultaPanelDP();
        }
        LimpiaPeriodos();
	}

	private void CargaDocumentoEditar(int Fila)
	{
		ddlTipoDocumento.SelectedValue = gvDocumentos.DataKeys[Fila].Values["IdTipoDocumentoDeuda"].ToString();
		txtNroDoc.Text = gvDocumentos.Rows[Fila].Cells[4].Text;
		


        if (gvDocumentos.Rows[Fila].Cells[6].Text != "&nbsp;")
            txtReferencia.Text = gvDocumentos.Rows[Fila].Cells[6].Text;
        else
            txtReferencia.Text = "";

        if (gvDocumentos.Rows[Fila].Cells[7].Text != "&nbsp;")
            txtObservacionDoc.Text = gvDocumentos.Rows[Fila].Cells[7].Text;
        else
            txtObservacionDoc.Text ="";

		txtFechaDocumento.Text = gvDocumentos.Rows[Fila].Cells[5].Text;
		lblIdDocumento.Text = gvDocumentos.DataKeys[Fila].Values["IdDocumento"].ToString();
		//btnGuardarDoc.Text = "Modificar Documento";
	}

	#endregion

	#region ControlDeuda

	protected void gvDepositos_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int indice = Convert.ToInt32(e.CommandArgument);
		int IdMoneda = Convert.ToInt32(gvDepositos.DataKeys[indice].Values["IdMonedaDeposito"].ToString());
		int IdBanco = Convert.ToInt32(gvDepositos.DataKeys[indice].Values["IdCuenta"].ToString());
		int IdDeposito = Convert.ToInt32(gvDepositos.DataKeys[indice].Values["IdDeposito"].ToString());
		//hfBeneficio.Value = gvDeudas.DataKeys[indice].Values["Beneficio"].ToString();
		//int IdDeuda = Convert.ToInt32(gvDeudas.DataKeys[indice].Values["IdDeuda"]);
		if (e.CommandName == "cmdEditar")
		{
			try
			{
				lblTituloND.Text = "Editar Datos Depósito";
				this.pnlDeposito_ModalPopupExtender.Show();
				CargarDepositoEditar(indice, IdMoneda, IdBanco, IdDeposito);
			}
			catch (Exception ex)
			{
				Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
			}
		}
	}

	private void CargarDepositoEditar(int fila, int IdMoneda, int IdBanco, int IdDeposito)
	{
		ddlTipoMonedaND.SelectedValue = IdMoneda.ToString();
		txtMontoDepositoND.Text = gvDepositos.Rows[fila].Cells[6].Text.Replace(",",".");
		txtFechaDepositoND.Text = gvDepositos.Rows[fila].Cells[1].Text;
		txtNumeroDepositoND.Text = gvDepositos.Rows[fila].Cells[4].Text;
		ddlCuentasBancoND.SelectedValue = IdBanco.ToString();
		lblIdDeposito.Text = IdDeposito.ToString();
	}

	protected void btnCancelarND_Click(object sender, EventArgs e)
	{

	}

	protected void btnAccionarND_Click(object sender, EventArgs e)
	{
		mensaje = null;

        if (ValidarDeposito(txtNumeroDepositoND.Text, Convert.ToDecimal(txtMontoDepositoND.Text, System.Globalization.CultureInfo.GetCultureInfo("si")),
            txtFechaDepositoND.Text))
        {
            if (lblTituloND.Text.StartsWith("Editar"))
            {

                Convenio.ModificaDeposito((int)Session["IdConexion"], "U", Convert.ToInt32(lblIdDeposito.Text), Convert.ToInt32(hfIdDeuda.Value)
                                            , txtNumeroDepositoND.Text, Convert.ToInt32(ddlTipoMonedaND.SelectedValue)
                                            , Convert.ToDecimal(txtMontoDepositoND.Text, System.Globalization.CultureInfo.GetCultureInfo("si")), Convert.ToDateTime(txtFechaDepositoND.Text)
                                            , Convert.ToInt32(ddlCuentasBancoND.SelectedValue), ref mensaje);
                lblMensaje.Text = "SE ACTUALIZÓ DE FORMA CORRECTA EL DEPOSITO";
            }

             else if (lblTituloND.Text.StartsWith("Agregar"))
                {

                    Convenio.RegistraDeposito((int)Session["IdConexion"], "I", Convert.ToInt32(hfIdDeuda.Value), Convert.ToInt64(txtNUP.Text)
                                     , txtNumeroDepositoND.Text, ddlTipoMonedaND.SelectedItem.ToString(), Convert.ToDecimal(txtMontoDepositoND.Text, System.Globalization.CultureInfo.GetCultureInfo("si"))
                                     , Convert.ToDateTime(txtFechaDepositoND.Text).Date, Convert.ToInt32(ddlCuentasBancoND.SelectedValue), ref mensaje);
                    lblMensaje.Text = "SE REGISTRÓ DE FORMA CORRECTA EL DEPOSITO";
                }
             
            if (mensaje == null)
            {
                Master.MensajeOk("El depósito fue registrado/modificado con éxito!!!");
                CargarDepositos(Convert.ToInt32(hfIdDeuda.Value));
                CalculoSaldos(Convert.ToInt32(hfIdDeuda.Value));                //CalculoSaldos();
                
                this.ModalPopupExtender3pnlMensaje.Show();
            }
            else
            {
                Master.MensajeError("Error al intentar registrar/modificar el depósito", mensaje);
            }
        }
        else
        {
            this.pnlDeposito_ModalPopupExtender.Show();
        }

	}

    protected bool ValidarDeposito(string txtNumeroDepositoND, decimal txtMontoDepositoND, string txtFechaDepositoND) 
    {
        string script;
        if (txtNumeroDepositoND == "")
        {
            script = @"<script type='text/javascript'>alert('INGRESO EL NUMERO DEL DEPOSITO PORFAVOR')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if( txtMontoDepositoND == 0 )
        {
            script = @"<script type='text/javascript'>alert('INGRESE UN MONTO DE DEPOSITO PORFAVOR')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        if (txtFechaDepositoND == "")
        {
            script = @"<script type='text/javascript'>alert('INGRESA LA FECHA DEL DEPOSITO PORFAVOR')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        DataTable Depositos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ValidaDeposito", "", "", "", "", "", "", txtNumeroDepositoND
													  , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
        if (Convert.ToInt32(Depositos.Rows[0][0].ToString())>0) 
        {
            script = @"<script type='text/javascript'>alert('EL NÚMERO DE DEPOSITO YA SE ENCUENTRA REGISTRADO')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;                    
        }
        return true;
    }
	private void CargarDepositos(int IdDeuda)
	{
		mensaje = null;
		DataTable Depositos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaDepositos", "", "", "", "", "", "", ""
													  , Convert.ToInt64(Session["NUP"]), IdDeuda, ref mensaje);
		if (mensaje == null)
		{
			Session["Depositos"] = Depositos;
			gvDepositos.DataSource = Depositos;
			gvDepositos.DataBind();
           // CalculoSaldos(IdDeuda);
		}
		else
		{
			gvDepositos.DataSource = null;
			gvDepositos.DataBind();
		}
	}

	private void CalculoSaldos(int IdDeuda)
	{
	/*	decimal TDepositos = 0, TDescuentos = 0;
		foreach (GridViewRow r in gvDepositos.Rows)
		{
			TDepositos += Convert.ToDecimal(r.Cells[6].Text);
		}
		foreach (GridViewRow r in gvRecuperaciones.Rows)
		{
			TDescuentos += Convert.ToDecimal(r.Cells[6].Text);
		}
        */
        DataTable Saldo = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "SaldoDeuda", "", "", "", "", "", "", ""
													, Convert.ToInt64(Session["NUP"]), IdDeuda, ref mensaje);


        txtTotalDepositos.Text = Saldo.Rows[0][2].ToString();
        txtTotalDescuentos.Text = Saldo.Rows[0][1].ToString();
        txtSaldoDeuda.Text = Saldo.Rows[0][3].ToString();
        /*txtTotalDepositos.Text = Math.Round(TDepositos, 2).ToString().Replace(",",".");
		txtTotalDescuentos.Text = Math.Round(TDescuentos, 2).ToString().Replace(",", ".");*/

        decimal yy = Convert.ToDecimal(txtTotalDepositos.Text.Replace(",", "."));
        decimal xx = Convert.ToDecimal(txtTotalDescuentos.Text.Replace(",", "."));

        if (txtSaldoAux.Text!="")
            txtSaldoDeuda.Text = (Math.Round(Convert.ToDecimal(txtSaldoAux.Text) - yy - xx,2)).ToString().Replace(",", ".");
      }

	private void CargarDescuentos(int IdDeuda)
	{
		mensaje = null;
		DataTable Descuentos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CargaDescuentos", "", "", "", "", "", "", ""
                                                     , Convert.ToInt64(Session["CUA"]), IdDeuda, ref mensaje);
		if (mensaje == null)
		{
			gvRecuperaciones.DataSource = Descuentos;
			gvRecuperaciones.DataBind();
			Session["Descuentos"] = Descuentos;
			//decimal TDescuentos = 0;
			//foreach (DataRow r in Descuentos.Rows)
			//{
			//    TDescuentos += Convert.ToDecimal(r.ItemArray[7]);
			//}
			//txtTotalDescuentos.Text = TDescuentos.ToString();
			//CalculoSaldos();
		}
		else
		{
			gvRecuperaciones.DataSource = null;
			gvRecuperaciones.DataBind();
		}
	}

	protected void btnNuevoDeposito_Click(object sender, ImageClickEventArgs e)
	{
		lblTituloND.Text = "Agregar Nuevo Depósito";
		limpiarND();
		this.pnlDeposito_ModalPopupExtender.Show();
	}

	private void limpiarND()
	{
		ddlTipoMonedaND.SelectedIndex = 1;
		txtMontoDepositoND.Text = "0.00";
		txtFechaDepositoND.Text = Convert.ToString( DateTime.Now.Date.ToString()).Substring(0,10);
		txtNumeroDepositoND.Text = "";
		ddlCuentasBancoND.SelectedIndex = 0;
	}

	protected void btnExportarDepositos_Click(object sender, EventArgs e)
	{
		gvDepositos.AllowPaging = false;
		gvDepositos.DataBind();
		ExportToExcel("Informe.xls", gvDepositos);
		//ExportarDTaExcel(Session["Depositos"] as DataTable);
		//ExporttoExcel2(Session["Depositos"] as DataTable);
	}

	private void ExportToExcel(string nameReport, GridView wControl)
	{
		HttpResponse response = Response;
		StringWriter sw = new StringWriter();
		HtmlTextWriter htw = new HtmlTextWriter(sw);

		Page pageToRender = new Page();
		HtmlForm form = new HtmlForm();
		form.Controls.Add(wControl);
		pageToRender.Controls.Add(form);
		response.Clear();
		response.Buffer = true;
		response.ContentType = "application/vnd.ms-excel";
		response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
		response.Charset = "UTF-8";
		Response.Cache.SetCacheability(HttpCacheability.NoCache);
		response.ContentEncoding = Encoding.Default;
		pageToRender.RenderControl(htw);
		response.Write(sw.ToString());
		response.End();
	} //feo

	private void ExportarDTaExcel(DataTable dt)
	{
		string attachment = "attachment; filename=mio.xls";
		Response.ClearContent();
		Response.AddHeader("content-disposition", attachment);
		Response.ContentType = "application/vnd.ms-excel";
		string tab = "";
		foreach (DataColumn dc in dt.Columns)
		{
			Response.Write(tab + dc.ColumnName);
			tab = "\t";
		}
		Response.Write("\n");
		int i;
		foreach (DataRow dr in dt.Rows)
		{
			tab = "";
			for (i = 0; i < dt.Columns.Count; i++)
			{
				Response.Write(tab + dr[i].ToString());
				tab = "\t";
			}
			Response.Write("\n");
		}
		Response.End();
	}   //maso

	private void ExporttoExcel2(DataTable table)
	{
		HttpContext.Current.Response.Write("<Td>");


		HttpContext.Current.Response.Clear();

		HttpContext.Current.Response.ClearContent();

		HttpContext.Current.Response.ClearHeaders();

		HttpContext.Current.Response.Buffer = true;

		HttpContext.Current.Response.ContentType = "application/ms-excel";

		HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");

		HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");



		HttpContext.Current.Response.Charset = "utf-8";

		HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

		//sets font

		HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");

		HttpContext.Current.Response.Write("<BR><BR><BR>");

		HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");

		int columnscount = gvDepositos.Columns.Count;



		for (int j = 0; j < columnscount; j++)
		{

			//Makes headers bold

			HttpContext.Current.Response.Write("<B>");
			HttpContext.Current.Response.Write(gvDepositos.Columns[j].HeaderText.ToString());
			HttpContext.Current.Response.Write("</B>");
			HttpContext.Current.Response.Write("</Td>");
		}
		HttpContext.Current.Response.Write("</TR>");
		foreach (DataRow row in table.Rows)
		{
			HttpContext.Current.Response.Write("<TR>");
			for (int i = 0; i < table.Columns.Count; i++)
			{
				HttpContext.Current.Response.Write("<Td>");
				HttpContext.Current.Response.Write(row[i].ToString());
				HttpContext.Current.Response.Write("</Td>");
			}

			HttpContext.Current.Response.Write("</TR>");
		}
		HttpContext.Current.Response.Write("</Table>");
		HttpContext.Current.Response.Write("</font>");
		HttpContext.Current.Response.Flush();
		HttpContext.Current.Response.End();
	}      //feo



	protected void btnImprimirDepositos_Click(object sender, EventArgs e)
	{

		Session["id"] = (hfIdDeuda.Value);
		// Response.Redirect("wfrmReportePlanPagos.aspx");
		Session["informe"] = "rptConvenioDeposito";
		string script = "window.open('wfrmReportePlanPagos.aspx', '');";

		ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);

	}
	protected void btnExportarRecuperacion_Click(object sender, EventArgs e)
	{

	}
	protected void btnImprimirRecuperacion_Click(object sender, EventArgs e)
	{

	}

	protected void gvDepositos_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvDepositos.PageIndex = e.NewPageIndex;
		gvDepositos.DataSource = Session["Depositos"] as DataTable;
		gvDepositos.DataBind();
	}
	protected void gvRecuperaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gvRecuperaciones.PageIndex = e.NewPageIndex;
		gvRecuperaciones.DataSource = Session["Descuentos"] as DataTable;
		gvRecuperaciones.DataBind();
	}

	#endregion

	protected void btnCalcularDeuda_Click(object sender, EventArgs e)
	{
		decimal monto = 0;

		foreach (GridViewRow row in gvListaPago.Rows)
		{

			//if (row.RowType == DataControlRowType.DataRow)
		   // {
				//CheckBox chkRol = (row.Cells[9].FindControl("chkRol") as CheckBox);
				//CheckBox check = (CheckBox)row.Cells["prueba"].FindControl("chkRol");
			//    CheckBox chk_Publicar = (CheckBox)row.Cells[5].FindControl("chkEnvio");
			//    if (chk_Publicar.Checked)
			 //   {
					monto = monto + Convert.ToDecimal(row.Cells[2].Text);
			 //    }
		 //   }
		}
		int m = 0;
		int t = 0;

		int CantidadAguinaldo = gvListaAguinaldo.Rows.Count;

		for (int i = 0; i < CantidadAguinaldo; i++)
		{
			int gestion = Convert.ToInt32(gvListaAguinaldo.Rows[i].Cells[0].Text);
			int c = 0;
			int CantidadPagos = gvListaPago.Rows.Count;
			for (int j = 0; j < CantidadPagos; j++)
			{
				int anyo = Convert.ToInt32(gvListaPago.Rows[j].Cells[0].Text.Substring(0, 4));
				if (anyo == gestion)
					c++;
			}
			//DropDownList ddl_nroduo = (DropDownList)gvListaAguinaldo.Rows[i].Cells[4].FindControl("ddlduo");
			v[i] = c;
			gvListaAguinaldo.Rows[i].Cells[4].Text = Convert.ToString(c);
			c = 0;

		}
        int n = 0;
		foreach (GridViewRow row in gvListaAguinaldo.Rows)
		{
			int c = 0;
			if (row.RowType == DataControlRowType.DataRow)
			{
                n = (n + m);
				m =v[t];
               
				decimal agui  = 0;

                int ee = (n + m);
				for(int i = n ; i<ee ;i++)
				{
					CheckBox chk_Publicar = (CheckBox)gvListaPago.Rows[i].Cells[5].FindControl("chkEnvio");
                    string ty = gvListaPago.Rows[i].Cells[0].Text;
					if (chk_Publicar.Checked)
					{
						agui = agui + Convert.ToDecimal(gvListaPago.Rows[i].Cells[2].Text);
						c++;

					}
				}
                agui = Math.Round(agui / 12,2);
				row.Cells[5].Text = agui.ToString();
    			monto = Math.Round(monto + agui,2);
				//ddl_nroduo.SelectedIndex = c - 1;
				row.Cells[4].Text = Convert.ToString(c);
				c = 0;
				t++;
			}
		}

		txtMontoTotal.Text = Convert.ToString( monto).Replace(",",".");
		txtSaldo.Text = Convert.ToString(monto).Replace(",", ".");
        ActualizaTipoCambio();
	}
	protected void txtFechaActual_TextChanged(object sender, EventArgs e)
	{
        ActualizaTipoCambio();
	}


    protected void ActualizaTipoCambio() 
    {
        DataTable Origen = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoCambio", txtFechaActual.Text, "", "", "", "", "", ""
                                                  , 0, 0, ref mensaje);
        if (Origen != null)
        {
            Origen.Columns.Add("MontoDeuda", typeof(decimal));
            int hh = Origen.Rows.Count;

            for (int i = 0; i < hh; i++)
            {
                decimal vv = Convert.ToDecimal(txtMontoTotal.Text, System.Globalization.CultureInfo.GetCultureInfo("si"));
                decimal mm = Convert.ToDecimal(Origen.Rows[i][3].ToString());
                Origen.Rows[i][4] = Math.Round(vv / mm, 2);
                gvLiquidacionDeuda.DataSourceID = null;
                gvLiquidacionDeuda.DataSource = Origen;
                gvLiquidacionDeuda.DataBind();
            }
        }
        else
        {
            gvLiquidacionDeuda.DataSource = null;
            gvLiquidacionDeuda.DataBind();
        }
    
    }

    protected void ocultaPanelDP()
    {
        txtPeriodoInicioDevTGN.Visible = false;
        txtPeriodoFinDevTGN.Visible = false;
        lblPeriodoInicioTGN.Visible = false;
        ImageButton5.Visible = false;
        lblPeriodoFinDevolucion.Visible = false;
        ImageButton6.Visible = false;
        btnAgregarPeriodo.Visible = false;
        btnListaPago.Visible = false;
        btnCalcularDeuda.Visible = false;
        gvPeriodos.Visible = false;
    }

    protected void muestraPanelDP()
    {
        txtPeriodoInicioDevTGN.Visible = true;
        txtPeriodoFinDevTGN.Visible = true;
        ImageButton5.Visible = true;
        ImageButton6.Visible = true;
        lblPeriodoFinDevolucion.Visible = true;
        lblPeriodoInicioTGN.Visible = true;
        btnCalcularDeuda.Visible = true;
        ddlAplica.SelectedValue = "False";
        pnMontoLiquidacion.Visible = true;
        btnAgregarPeriodo.Visible = true;
        btnListaPago.Visible = true;
        btnCalcularDeuda.Visible = true;
        gvPeriodos.Visible = true;
        ddlInstitucion.Visible = true;
        lblInsitucion.Visible = true;
    }

	protected void ddlEstadoDeuda_SelectedIndexChanged(object sender, EventArgs e)
	{

		if (ddlTipoDeuda.SelectedValue == "746")
		{
            muestraPanelDP();
            lnkTipoCambio.Visible = true;
			/*DataTable bandera = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Registro", "", "", "", "", "", "",
			"", Convert.ToInt64(Session["NUP"]), 0, ref mensaje);

			if (bandera != null) 
			{
				txtPeriodoInicioDevTGN.Text =bandera.Rows[0][2].ToString() ;
				txtPeriodoFinDevTGN.Text = bandera.Rows[0][3].ToString();
				txtPeriodoInicioDevTGN.Enabled = false;
				txtPeriodoFinDevTGN.Enabled = false;
				ImageButton5.Enabled = false;
				ImageButton6.Enabled = false;
			}
			ddlAplica.SelectedValue = "False";
			txtPorcentaje.Enabled = false;
			txtMontoDescuento.Text = "0.00";	
			txtMontoDescuento.Enabled = false;

		}
		else
		{

			txtPeriodoInicioDevTGN.Visible = false;
			txtPeriodoFinDevTGN.Visible = false;
			ImageButton5.Visible = false;
			ImageButton6.Visible = false;
			lblPeriodoFinDevolucion.Visible = false;
			lblPeriodoInicioTGN.Visible = false;
			btnCalcularDeuda.Visible = false;
			txtPorcentaje.Enabled = true;
			txtMontoDescuento.Enabled = true;
			ddlAplica.Enabled = true;
			ddlAplica.SelectedIndex = 0;
		}
			 */
		}
		else
		{
			ddlAplica.SelectedValue = "True";
			pnMontoLiquidacion.Visible = false;
			btnCalcularDeuda.Visible = false;
			ddlInstitucion.Visible = false;
			lblInsitucion.Visible = false;
            ddlRegional.SelectedIndex = 1 ;
            lnkTipoCambio.Visible = false;
		}
		txtNumeroLiquidacion.Text = GeneraNumeroLiquidacion();
        txtNroDoc.Text = txtNumeroLiquidacion.Text;
        txtNumeroLiquidacion.Enabled = false;
       
		
	}


	protected string GeneraNumeroLiquidacion() 
	{ 
        string NumeroLiquidacion = "HOLA";
		string region2 = ddlRegional.SelectedValue;
        string region = ddlRegional.SelectedItem.Text;
        string TipoSuspencion = ddlTipoDeuda.SelectedValue;
		string reg = "";
		int anyo = Convert.ToInt32(DateTime.Now.AddMonths(0).Year.ToString());

		if (region == "LA PAZ")
			reg = "LP";
		if (region == "COCHABAMBA")
			reg = "CB";
		if (region == "SANTA CRUZ")
			reg = "SC";
		if (region == "ORURO")
			reg = "OR";
		if (region == "POTOSI")
			reg = "PT";
		if (region == "CHUQUISACA")
			reg = "CH";
		if (region == "TARIJA")
			reg = "TJ";
		if (region == "TRINIDAD")
			reg = "TR";
        if (region == "COBIJA")
            reg = "CO";

        if (TipoSuspencion == "DOBLE PERCEPCION")
            TipoSuspencion = "746";

        DataTable Deudas = null;
        if (TipoSuspencion != "746")
        {
            Deudas = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Maximo", reg, "", "", "", "", "", ""
                                                         , anyo, Convert.ToInt32(TipoSuspencion), ref mensaje);
        }
        else
        {
           string TipoDocumento = ddlTipoDocumento.SelectedValue;
           Deudas = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Maximo1", reg, TipoDocumento, "", "", "", "", ""
           , anyo, Convert.ToInt32(TipoSuspencion), ref mensaje);
        }


        NumeroLiquidacion = Deudas.Rows[0][0].ToString() + "-" + reg + DateTime.Now.AddMonths(0).Year.ToString();
		
		return NumeroLiquidacion;
       
	}

	protected void ddlRegional_SelectedIndexChanged(object sender, EventArgs e)
	{
		txtNumeroLiquidacion.Text = GeneraNumeroLiquidacion();
        txtNroDoc.Text= txtNumeroLiquidacion.Text;
		txtNumeroLiquidacion.Enabled = false;
	}

	protected void btnAgregarPeriodo_Click(object sender, EventArgs e)
	{
		DataTable Periodos_temp = Session["PERIODO"] as DataTable;
		int NumPer;
		if (gvPeriodos == null)
		{
			NumPer = 1;
		}
		else
		{
			NumPer = gvPeriodos.Rows.Count + 1;
		}
		try
		{
			if (btnAgregarPeriodo.Text.StartsWith("AgregarPeriodo"))//agregamos
			{

				if (verficarPeriodo(txtPeriodoInicioDevTGN.Text,txtPeriodoFinDevTGN.Text)) {
                DataTable ListaPagos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "CantidadPagos", txtPeriodoInicioDevTGN.Text, txtPeriodoFinDevTGN.Text, "", "", "", "", ""
                                        , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
				Periodos_temp.Rows.Add(NumPer, txtPeriodoInicioDevTGN.Text, txtPeriodoFinDevTGN.Text, ListaPagos.Rows[0][0].ToString(), 0);
				//cargar la gv
				gvPeriodos.DataSourceID = null;
                gvPeriodos.Visible = true;
				gvPeriodos.DataSource = Periodos_temp;
				gvPeriodos.DataBind();
				Session["Periodos"] = Periodos_temp;
				txtPeriodoInicioDevTGN.Text = "";
				txtPeriodoFinDevTGN.Text = "";
				}
			}
		   
		}
		catch (Exception ex)
		{
			Master.MensajeError("Error al agregar Periodos TGN", ex.Message);
		}
	}

	public bool verficarPeriodo(string txtPeriodoInicioDevTGN, string txtPeriodoFinDevTGN)
	{
		string script = "";
		
        /*int tt = txtPeriodoInicioDevTGN.Length;
		string h = txtPeriodoInicioDevTGN.Substring(0, 4);
		string h1 = txtPeriodoInicioDevTGN.Substring(4, 2);
		string h2 = txtPeriodoFinDevTGN.Substring(0, 4);
		string h3 = txtPeriodoFinDevTGN.Substring(4, 2);*/

        if (txtPeriodoInicioDevTGN == "" || txtPeriodoFinDevTGN == "")
        {
            script = @"<script type='text/javascript'>alert('INGRESE LOS 2 PERIODOS (INICIO,FIN) TGN')</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

		if (Convert.ToInt32(txtPeriodoInicioDevTGN.Substring(0, 4)) < 2000 || Convert.ToInt32(txtPeriodoInicioDevTGN.Substring(4, 2)) < 1 || Convert.ToInt32(txtPeriodoInicioDevTGN.Substring(4, 2)) > 12)
		{
			script = @"<script type='text/javascript'>alert('FORMATO DE FECHA INCORRECTA EN PERIODO INICIO TGN')</script>";
			ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
			return false;
		}

		if (Convert.ToInt32(txtPeriodoFinDevTGN.Substring(0, 4)) < 2000 || Convert.ToInt32(txtPeriodoFinDevTGN.Substring(4, 2)) < 1 || Convert.ToInt32(txtPeriodoFinDevTGN.Substring(4, 2)) > 12)
		{
			script = @"<script type='text/javascript'>alert('FORMATO DE FECHA INCORRECTA EN PERIODO FIN TGN')</script>";
			ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
			return false;
		}

		if (Convert.ToInt32(txtPeriodoFinDevTGN) < Convert.ToInt32(txtPeriodoInicioDevTGN))
		{
			script = @"<script type='text/javascript'>alert('Periodo Fin TGN es menor a Periodo Inicio TGN')</script>";
			ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
			return false;
		}

		//caso 1 cuando el periodo ya existe
		foreach (GridViewRow r in gvPeriodos.Rows)
		{
			if (r.Cells[1].Text == txtPeriodoInicioDevTGN && r.Cells[2].Text == txtPeriodoFinDevTGN)
			{
				 script = @"<script type='text/javascript'>alert('YA EXISTE UN PERIODO IGUAL NO SE PUEDE INSERTAR 2 PERIODOS IGUALES');</script>";
				 ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
				return false;
			}
		}

		//caso 2 cuando hay interseccion de periodos
		foreach (GridViewRow r in gvPeriodos.Rows)
		{
			if (Convert.ToInt32(r.Cells[1].Text) >= Convert.ToInt32(txtPeriodoInicioDevTGN) && 
				Convert.ToInt32(txtPeriodoInicioDevTGN) >= Convert.ToInt32(r.Cells[2].Text) &&
				Convert.ToInt32(r.Cells[2].Text) >= Convert.ToInt32(txtPeriodoFinDevTGN))
			{
				 script = @"<script type='text/javascript'>alert('YA EXISTE UN PERIODO');</script>";
				 ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
				return false;
			}
			if (Convert.ToInt32(r.Cells[1].Text) <= Convert.ToInt32(txtPeriodoInicioDevTGN) &&
				Convert.ToInt32(txtPeriodoInicioDevTGN) <= Convert.ToInt32(r.Cells[2].Text) &&
				Convert.ToInt32(r.Cells[2].Text) <= Convert.ToInt32(txtPeriodoFinDevTGN))
			{
				 script = @"<script type='text/javascript'>alert('YA EXISTE UN PERIODO');</script>";
				 ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
				return false;
			}
		}

		//caso 3 cuando un periodo esta dentro de otro periodo
		foreach (GridViewRow r in gvPeriodos.Rows)
		{
			if (Convert.ToInt32(r.Cells[1].Text) <= Convert.ToInt32(txtPeriodoInicioDevTGN) && Convert.ToInt32(r.Cells[2].Text) >= Convert.ToInt32(txtPeriodoFinDevTGN))
			{
				 script = @"<script type='text/javascript'>alert('YA EXISTE UN PERIODO MAS GRANDE A ESTOS 2 PERIODOS');</script>"; 
				 ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
				 return false;
			}
		}
		return true;
	}
	protected void btnListaPago_Click(object sender, EventArgs e)
    {
        Session["IdDeuda"] = 0; 
        MostrarPagos();
        this.gvListaPago.Columns[5].Visible = true;
        this.gvListaPago.Columns[6].Visible = false;
        
    }

    protected void MostrarPagos()
    {
        int sw = 0;
        int sw1 = 0;
        DataTable Consolidado = null;
        DataTable ConsolidadoAguinaldo = null;

        if (Convert.ToInt32(Session["IdDeuda"]) == 0)
        {
            foreach (GridViewRow r in gvPeriodos.Rows)
            {
                DataTable ListaPagos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaPagos", r.Cells[1].Text, r.Cells[2].Text, "", "", "", "", ""
                                                      , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
                if (ListaPagos != null)
                {
                    if (ListaPagos.Rows.Count != 0)
                    {
                        if (sw == 0)
                        {
                            Consolidado = (ListaPagos); sw = 1;
                        }
                        else
                        {
                            Consolidado.Merge(ListaPagos);
                        }
                    }
                }

                DataTable ListaAguinaldo = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaAguinaldo", r.Cells[1].Text, r.Cells[2].Text, "", "", "", "", ""
                                                      , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
                int c;
                if (ConsolidadoAguinaldo == null)
                    c = 0;
                else
                {
                    c = ConsolidadoAguinaldo.Rows.Count;
                }


                int sww = 0;
                int swA = 0;
                if (ListaAguinaldo != null)
                {
                    int cc = ListaAguinaldo.Rows.Count;

                    for (int i = 0; i < cc; i++)
                    {
                        int ww = 0;
                        for (int h = 0; h < c; h++)
                        {
                            string tt = ConsolidadoAguinaldo.Rows[h][0].ToString();
                            string ttt = ListaAguinaldo.Rows[i][0].ToString();
                            if (ConsolidadoAguinaldo.Rows[h][0].ToString() == ListaAguinaldo.Rows[i][0].ToString())
                                sww = 1;
                            else
                                ww++;

                        }
                        if (ww == c && ww != 0)
                        {
                            DataRow ee = ListaAguinaldo.Rows[i];
                            //ListaAguinaldo.Rows[i].Delete();
                            ConsolidadoAguinaldo.ImportRow(ListaAguinaldo.Rows[i]);
                            //ConsolidadoAguinaldo.Rows.Add(ee);
                            swA = 1;
                        }
                    }

                }

                if (sww == 0)
                {
                    if (ListaAguinaldo != null)
                    {
                        if (sw1 == 0)
                        {
                            ConsolidadoAguinaldo = (ListaAguinaldo);
                            sw1 = 1;

                        }
                        else
                        {
                            if (sw1 == 0)
                            {
                                ConsolidadoAguinaldo.Merge(ListaAguinaldo);
                            }
                        }
                    }
                }
            }
            gvListaPago.Visible = true;
            gvListaPago.DataSourceID = null;
            gvListaPago.DataSource = Consolidado;
            gvListaPago.DataBind();


            if (ConsolidadoAguinaldo.Rows.Count != 0)
            {
                gvListaAguinaldo.Visible = true;
                gvListaAguinaldo.DataSourceID = null;
                gvListaAguinaldo.DataSource = ConsolidadoAguinaldo;
                gvListaAguinaldo.DataBind();
            }
            else
            {
                
                //ConsolidadoAguinaldo.Merge(ListaAguinaldo);
                DataTable ListaAguinaldo = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaAguinaldo2", "", "", "", "", "", "", ""
                                                      , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
                gvListaAguinaldo.Visible = true;
                gvListaAguinaldo.DataSourceID = null;
                gvListaAguinaldo.DataSource = ListaAguinaldo;
                gvListaAguinaldo.DataBind();
            }

            int CantidadAguinaldo = gvListaAguinaldo.Rows.Count;

            for (int i = 0; i < CantidadAguinaldo; i++)
            {
                int gestion = Convert.ToInt32(gvListaAguinaldo.Rows[i].Cells[0].Text);
                int c = 0;
                int CantidadPagos = gvListaPago.Rows.Count;
                for (int j = 0; j < CantidadPagos; j++)
                {
                    int anyo = Convert.ToInt32(gvListaPago.Rows[j].Cells[0].Text.Substring(0, 4));
                    if (anyo == gestion)
                        c++;
                }
                //DropDownList ddl_nroduo = (DropDownList)gvListaAguinaldo.Rows[i].Cells[4].FindControl("ddlduo");
                v[i] = c - 1;
                //ddl_nroduo.SelectedIndex = c-1;
                gvListaAguinaldo.Rows[i].Cells[4].Text = Convert.ToString(c);
                c = 0;
            }
        }
        else
        {
                DataTable ListaPagos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaPagos1", "", "", "", "", "", "", ""
                , Convert.ToInt64(Session["NUP"]), Convert.ToInt32(Session["IdDeuda"]), ref mensaje);
                gvListaPago.Visible = true;
                gvListaPago.DataSourceID = null;
                gvListaPago.DataSource = ListaPagos;
                gvListaPago.DataBind();
                DataTable ListaAguinaldo = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaAguinaldo1", "", "", "", "", "", "", ""
                 , Convert.ToInt64(Session["NUP"]), Convert.ToInt32(Session["IdDeuda"]), ref mensaje);
                gvListaAguinaldo.Visible = true;
                gvListaAguinaldo.DataSourceID = null;
                gvListaAguinaldo.DataSource = ListaAguinaldo;
                gvListaAguinaldo.DataBind();

                int t = 0;
                foreach (GridViewRow row in gvListaAguinaldo.Rows)
                {
                  row.Cells[4].Text = ListaAguinaldo.Rows[t][4].ToString();
                  t++;
                }
                
        
        }

    
    }
    /*protected void MostrarPagos1()
    {
        int sw = 0;
        int sw1 = 0;
        DataTable Consolidado = null;
        DataTable ConsolidadoAguinaldo = null;

        foreach (GridViewRow r in gvPeriodos.Rows)
        {
            DataTable ListaPagos = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaPagos1", r.Cells[1].Text, r.Cells[2].Text, "", "", "", "", ""
                                                  , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
            if (ListaPagos != null)
            {
                if (ListaPagos.Rows.Count != 0)
                {
                    if (sw == 0)
                    {
                        Consolidado = (ListaPagos); sw = 1;
                    }
                    else
                    {
                        Consolidado.Merge(ListaPagos);
                    }
                }
            }

            DataTable ListaAguinaldo = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "ListaAguinaldo1", r.Cells[1].Text, r.Cells[2].Text, "", "", "", "", ""
                                                  , Convert.ToInt64(Session["NUP"]), 0, ref mensaje);
            int c;
            if (ConsolidadoAguinaldo == null)
                c = 0;
            else
            {
                c = ConsolidadoAguinaldo.Rows.Count;
            }


            int sww = 0;
            int swA = 0;
            if (ListaAguinaldo != null)
            {
                int cc = ListaAguinaldo.Rows.Count;

                for (int i = 0; i < cc; i++)
                {
                    int ww = 0;
                    for (int h = 0; h < c; h++)
                    {
                        string tt = ConsolidadoAguinaldo.Rows[h][0].ToString();
                        string ttt = ListaAguinaldo.Rows[i][0].ToString();
                        if (ConsolidadoAguinaldo.Rows[h][0].ToString() == ListaAguinaldo.Rows[i][0].ToString())
                            sww = 1;
                        else
                            ww++;

                    }
                    if (ww == c && ww != 0)
                    {
                        DataRow ee = ListaAguinaldo.Rows[i];
                        //ListaAguinaldo.Rows[i].Delete();
                        ConsolidadoAguinaldo.ImportRow(ListaAguinaldo.Rows[i]);
                        //ConsolidadoAguinaldo.Rows.Add(ee);
                        swA = 1;
                    }
                }

            }

            if (sww == 0)
            {
                if (ListaAguinaldo != null)
                {
                    if (sw1 == 0)
                    {
                        ConsolidadoAguinaldo = (ListaAguinaldo);
                        sw1 = 1;

                    }
                    else
                    {
                        if (sw1 == 0)
                        {
                            ConsolidadoAguinaldo.Merge(ListaAguinaldo);
                        }
                    }
                }
            }
        }
        gvVerPagos.Visible = true;
        gvVerPagos.DataSourceID = null;
        gvVerPagos.DataSource = Consolidado;
        //gvVerPagos.Rows[0].Cells[6].Enabled = false;
        gvVerPagos.DataBind();

        gvListaAguinaldo.Visible = true;
        gvListaAguinaldo.DataSourceID = null;
        gvListaAguinaldo.DataSource = ConsolidadoAguinaldo;
        gvListaAguinaldo.DataBind();

        int CantidadAguinaldo = gvListaAguinaldo.Rows.Count;

        for (int i = 0; i < CantidadAguinaldo; i++)
        {
            int gestion = Convert.ToInt32(gvListaAguinaldo.Rows[i].Cells[0].Text);
            int c = 0;
            int CantidadPagos = gvVerPagos.Rows.Count;
            for (int j = 0; j < CantidadPagos; j++)
            {
                int anyo = Convert.ToInt32(gvVerPagos.Rows[j].Cells[0].Text.Substring(0, 4));
                if (anyo == gestion)
                    c++;
            }
            //DropDownList ddl_nroduo = (DropDownList)gvListaAguinaldo.Rows[i].Cells[4].FindControl("ddlduo");
            v[i] = c - 1;
            //ddl_nroduo.SelectedIndex = c-1;
            gvListaAguinaldo.Rows[i].Cells[4].Text = Convert.ToString(c);
            c = 0;

        }
    }*/
	protected void gvListaAguinaldo_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		DropDownList drp = e.Row.FindControl("ddlduo") as DropDownList;
		if (drp != null)
		{
		   string h =  e.Row.Cells[4].Text; // me devuelve el campo clave delg gridview para 
			// realizar mi consulta
		   drp.Items.Add("1");
		   drp.Items.Add("2");
		   drp.Items.Add("3");
		   drp.Items.Add("4");
		   drp.Items.Add("5");
		   drp.Items.Add("6");
		   drp.Items.Add("7");
		   drp.Items.Add("8");
		   drp.Items.Add("9");
		   drp.Items.Add("10");
		   drp.Items.Add("11");
		   drp.Items.Add("12");
		}

	}
	protected void gvPeriodos_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int indice = Convert.ToInt32(e.CommandArgument);
		if (e.CommandName == "cmdEliminar")
        {
          //  if (btnRegistrarDeuda.Text.StartsWith("Registrar Deuda"))
          //  {

				DataTable PeriodoElimina = Session["PERIODO"] as DataTable;
				PeriodoElimina.Rows.Remove(PeriodoElimina.Rows[indice]);
                int n = 0;
				foreach (DataRow r in PeriodoElimina.Rows)
				{
					PeriodoElimina.Rows[n][0] = (n + 1);
					n += 1;
				}
				gvPeriodos.DataSourceID = null;
				gvPeriodos.DataSource = PeriodoElimina;
				gvPeriodos.DataBind();
				Session["PERIODO"] = PeriodoElimina;
				//gvDocumentos.DeleteRow(indice);
		//	}
    /*        else
            {
                //OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                //Response.Write("<script language=javascript>if(confirm('Movimiento guardado exitosamente. Desea ingresar un nuevo registro de \"" + lblNombreGraco.Text + "\"')==true){ location.href='wfGracosRegistroMovimiento.aspx';}else { location.href='wfGracosInicioMovimiento.aspx';}</script>");
                Convenio.ModificaDocDeuda((int)Session["IdConexion"], "U", Convert.ToInt32(hfIdDeuda.Value), IdDocumento, 0, 0, ""
                                            , DateTime.Now.Date, "", "", "Deshabilitar", ref mensaje);
            }*/
        }
	}
    protected void LimpiaPeriodos()
    {
        DataTable PERIODO = Session["PERIODO"] as DataTable;
        PERIODO.Rows.Clear();
        Session["PERIODO"] = PERIODO;
        gvPeriodos.DataSource = null;
        gvPeriodos.DataBind();

    }
    protected void gvDeudas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (!IsPostBack)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")
                            //button.OnClientClick = "if (!confirm('Esta Seguro " +"de dar Baja el Convenio?')) return;";
                            button.OnClientClick = "javascript : return confirm('Esta seguro dar de Baja del Convenio?');";
                    }
                }
            }
        }
    }
    protected void lbtnEliminaConvenio_Click(object sender, EventArgs e)
    {
        LinkButton boton = (LinkButton)sender;
        EliminaConvenio(Convert.ToInt32(boton.CommandName)," ");
        CargaDeudas();
    }

    protected bool Valida_Celular()
    {   
        if (this.txtCel.Text.Trim() != null && this.txtCel.Text.Trim() != "")
        {
            if (this.txtCel.Text.Length < 8 || !(this.txtCel.Text.Substring(0).Contains("6")
                || this.txtCel.Text.Substring(0).Contains("7"))
                )
                {
                    mensaje = "El Teléfono Celular no es válido.";
                    Master.MensajeError("Error en el Celular que intenta registrar", mensaje);
                    return false;
                }
            else
                return true;
        }
        else
            return true;
    }
    
    protected bool Valida_CelularReferencia()
    {
        if (this.txtCelReferencial.Text.Trim() != null && this.txtCelReferencial.Text.Trim() != "")
        {
            if (this.txtCelReferencial.Text.Length < 8 || !(this.txtCelReferencial.Text.Substring(0).Contains("6")
                || this.txtCelReferencial.Text.Substring(0).Contains("7"))
                )
            {
                mensaje = "El Teléfono Celular de Referencia no es válido.";
                Master.MensajeError("Error en el Celular de Referencia que intenta registrar", mensaje);
                return false;
            }
            else
                return true;
        }
        else
            return true;
    }

    protected bool Valida_Telefono()
    {
        if (this.txtTelefono.Text.Trim() != null && this.txtTelefono.Text.Trim() != "")
        {
            if (this.txtTelefono.Text.Length < 7)
            {
                mensaje = "Error al tratar de registar el Numero de Telefono";
                Master.MensajeError("Error al tratar de registar el Numero de Telefono", "El Teléfono Fijo no es válido.");
                return false;
            }
            return true;
        }
        else
            return true;
    }
    protected void cmdLimpiar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Convenios/wfrmInformacion.aspx");
    }

    protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TipoSuspencion = ddlTipoDocumento.SelectedValue;
        if (ddlTipoDocumento.SelectedValue == "749" || ddlTipoDocumento.SelectedValue == "31573" || ddlTipoDocumento.SelectedValue == "31574")
        {
            txtNumeroLiquidacion.Text = "";
            txtNumeroLiquidacion.Text = GeneraNumeroLiquidacion();
            txtNroDoc.Text = txtNumeroLiquidacion.Text;
        }
    }
    protected void btnSiJustificar_Click(object sender, EventArgs e)
    {
        

        string JustificacionBaja = "Motivo: " + txtMotivoi.Text + " Autorizador: " + txtAutorizadori.Text + " Observacion:  " + txtObservacioni.Text;
        if(ValidarBaja())
        {
            EliminaConvenio(Convert.ToInt32(hfIdDeuda.Value), JustificacionBaja);
            if (mensaje == null)
            {
                this.ModalPopupExtender3pnlJustificar.Hide();
                CargaDeudas();
            }
            else
            {
                Master.MensajeError("Error a la hora de dar de Baja el convenio", mensaje);
                this.ModalPopupExtender3pnlJustificar.Hide();
                CargaDeudas();
            }
        }
        else
        {
            this.ModalPopupExtender3pnlJustificar.Show();
        }

        
    }
    protected bool ValidarBaja()
    {
        string script = "";
        if ((this.txtMotivoi.Text.Trim() == null || this.txtMotivoi.Text.Trim() == "") || (this.txtObservacioni.Text.Trim() == null || this.txtObservacioni.Text.Trim() == ""))
        {
            script = @"<script type='text/javascript'>alert('EL CAMPO MOTIVO Y EL CAMPO OBSERVACION SON OBLIGATORIOS PARA DAR DE BAJA UN CONVENIO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        else
            return true;
    }

    protected void gvDepositos_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvDepositos.Rows)
        {
            if (BanderaHabilitacionRol == 0)
            {
                row.Cells[10].Enabled = false;
            }       
        }
    }
    private void CambiarInterfaz()
    {

        AgregarJSAtributos(txtPeriodoFinDevTGN, btnAgregarPeriodo);
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
    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlLocalidad.Items.Clear();
        ddlLocalidad.Items.Add("SELECCIONE...");
        ddlLocalidad.AppendDataBoundItems = true;

        ddlLocalidad.DataSource = Convenio.ObtieneDatos((int)Session["IdConexion"], "Q", "Localidad", "", "", "", "", "", "", ""
                                   , 0, Convert.ToInt32(ddlDepartamento.SelectedValue), ref mensaje);
        ddlLocalidad.DataValueField = "CodigoLocalidad";
        ddlLocalidad.DataTextField = "NombreLocalidad";
        ddlLocalidad.DataBind();
    }
}