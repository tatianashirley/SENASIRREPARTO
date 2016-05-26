using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using AjaxControlToolkit;
using wcfEmisionCertificadoCC.Logica;
using wcfSeguridad.Logica;
using wcfWorkFlowN.Logica;


public partial class EmisionCertificadoCC_wfrmEmisionCertificado : System.Web.UI.Page
{
	int IdConexion;
	clsEmisionCertificado Conexion = new clsEmisionCertificado();
	clsEmisionCertificado ObjCertificado = new clsEmisionCertificado();
	clsAsignarCorrelativo ObjAsignacion = new clsAsignarCorrelativo();
	DataTable DatosConexion;
	int Usuario, Oficina;
	string mensaje;
	bool sw = false;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["IdConexion"] == null)
		{
			Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
			return;
		}
		else
		{
			IdConexion = (int)Session["IdConexion"];
		}
		if (Request.QueryString["iIdTramite"] != null)
		{
			iIdTramite.Value = Request.QueryString["iIdTramite"];
			iIdGrupoB.Value = Request.QueryString["iIdGrupoBeneficio"];
		}
		DatosConexion = new DataTable();
		DatosConexion = Conexion.DatosConexion((int)Session["IdConexion"]);
		Usuario = Convert.ToInt32(DatosConexion.Rows[0]["IdUsuario"].ToString());
		Oficina = Convert.ToInt32(DatosConexion.Rows[0]["IdOficina"].ToString());
  
		if (!Page.IsPostBack)
		{
			if (iIdTramite.Value != "") {
			CargarUltimosNumero();
			ListarRegistros(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
			}
		 }
	}
	
	# region Cargar_Combos_Grillas
	// LISTAR REGISTRO DE UN TIPO DE TRAMITE en la GRILLA (FUNCIONAL)
	protected void ListarRegistros(Int64 Trami, Int32 beneficio)
	{   
		mensaje = null;

		gvTipo.DataSource = ObjCertificado.ObtenerFormularioCalculoCC((int)Session["IdConexion"], "Q", Trami, beneficio, ref mensaje);
		gvTipo.DataBind();
		if (gvTipo.DataSource != null && gvTipo.Rows.Count > 0)
		{
			gvTipo.Columns[0].Visible = false; //IdTipoFormularioCalculo
			gvTipo.Columns[1].Visible = false; //DescripcionTipoFormulario
			gvTipo.Columns[2].Visible = false; //IdTipoCertificado
			gvTipo.Columns[3].Visible = false; //IdTipoCC
		}
		else 
		{
			Master.MensajeError("Error al realizar la Operacion", mensaje);
		}
	}
	// CARGA GRILLA DE ULTIMOS NUMEROS GENERADOS
	protected void CargarUltimosNumero()
	{
		gvUltimo.DataSource = ObjAsignacion.UltimosNumerosCertificados((int)Session["IdConexion"],"Q",Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value),ref mensaje);
		gvUltimo.DataBind();
		if (gvUltimo.DataSource == null || gvUltimo.Rows.Count <= 0) 
			Master.MensajeError("Error al realizar la Operación", mensaje);
	}


	#endregion

	# region Eventos_AccionesGrilla
	// DATABOUND DE LA GRILLA PARA CONTROLAR UNO A UNO LA ACTIVACION DE BOTONES DE REIMPRIMIR, EMITIR
	protected void gvTipo_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			int DEstado,EstadoCalc;
			string FechaAcep;
			DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "RegistroActivo"));
			FechaAcep = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FechaAceptacion"));
			EstadoCalc = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdEstado"));
			if (DEstado == 1)
			  {
				  if (EstadoCalc == 0)
				  {
					  e.Row.Cells[16].Enabled = true; // BOTON DE EMITIR
					  e.Row.Cells[17].Enabled = false;  // BOTON DE IMPRIMIR
					  e.Row.Cells[18].Enabled = false;  // BOTON DE VER
				  }
				  else
				  {
					  if (EstadoCalc == 33)
					  {
						  e.Row.Cells[16].Enabled = false; // BOTON DE EMITIR
						  e.Row.Cells[17].Enabled = true;  // BOTON DE IMPRIMIR
						  e.Row.Cells[18].Enabled = false;  // BOTON DE VER
					  }
					  else 
					  {
						  if (EstadoCalc == 34 || EstadoCalc == 12 || EstadoCalc == 13) 
						  {
							  e.Row.Cells[16].Enabled = false; // BOTON DE EMITIR
							  e.Row.Cells[17].Enabled = false;  // BOTON DE IMPRIMIR
							  e.Row.Cells[18].Enabled = true;  // BOTON DE VER
							  //impresion.Visible = true;
						  }
						  
					  }
				  }
			  }
		}
	}
  
	protected void gvTipo_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int idtipoformc, idtipocer, idtipcc;
		string descrtipo;
		string fecemision;
		DateTime fNot;
		string accion = e.CommandName.ToUpper();
		int index = Convert.ToInt32(e.CommandArgument);

		this.gvTipo.Rows[index].Cells[0].Visible = true;
		this.gvTipo.Rows[index].Cells[1].Visible = true;
		this.gvTipo.Rows[index].Cells[2].Visible = true;
		this.gvTipo.Rows[index].Cells[3].Visible = true;
		/*
		idtipoformc = Convert.ToInt32(gvTipo.Rows[index].Cells[0].Text); //IdTipoFormularioCalculo
		descrtipo = Convert.ToString(gvTipo.Rows[index].Cells[1].Text); //DescripcionTipoFormulario
		idtipocer = Convert.ToInt32(gvTipo.Rows[index].Cells[2].Text); //IdTipoCertificado
		idtipcc = Convert.ToInt32(gvTipo.Rows[index].Cells[3].Text); //IdTipoCC
		*/
		idtipoformc = Convert.ToInt32(gvTipo.DataKeys[index].Values["IdTipoFormularioCalculo"]);
		descrtipo = gvTipo.DataKeys[index].Values["DescripcionTipoFormulario"].ToString();
		idtipocer = Convert.ToInt32(gvTipo.DataKeys[index].Values["IdTipoTramite"]);
		idtipcc = Convert.ToInt32(gvTipo.DataKeys[index].Values["IdTipoCC"]);
		fNot = Convert.ToDateTime(gvTipo.DataKeys[index].Values["FechaNotificacion"]);
		
		this.gvTipo.Rows[index].Cells[0].Visible = false;
		this.gvTipo.Rows[index].Cells[1].Visible = false;
		this.gvTipo.Rows[index].Cells[2].Visible = false;
		this.gvTipo.Rows[index].Cells[3].Visible = false;
		
		Session["TipoFormulario"]=idtipoformc;
		Session["NroFormCalculo"] = Convert.ToInt32(gvTipo.Rows[index].Cells[6].Text); //NoFormularioCalculo
		Session["Accion"] = accion;

		if (accion == "EMITIR")
		{
			TimeSpan Diferencia = DateTime.Now - fNot;
			int dias = Diferencia.Days;
			string FecCom = fNot.ToShortDateString();
            if (fNot <= DateTime.Now && dias >= 2 && FecCom != "01/01/0001")
            {
                EmitirCertificado(idtipoformc, idtipocer, idtipcc, Convert.ToInt32(gvTipo.Rows[index].Cells[6].Text), Convert.ToDecimal(gvTipo.Rows[index].Cells[8].Text.Replace(',', '.')), Convert.ToString(gvTipo.Rows[index].Cells[9].Text));
                if (Convert.ToInt32(Session["NumeroCert"]) == 0)
                {
                    string msg = "No se emtió el certificado, no exite Stock disponible";
                    Master.MensajeError("Error al realizar la Operación", msg);
                }
                else
                {
                    if (mensaje == null)
                    {
                        string cadena = "Se emitió satisfactoriamente el certificado n° " + Convert.ToString(Session["NumeroCert"]);
                        Master.MensajeOk(cadena);
                    }
                    else
                        Master.MensajeError("Error al realizar la operación", "No se pudo generar el correlativo para el nuevo certificado... " + mensaje);

                    CargarUltimosNumero();
                    ListarRegistros(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
                }
            }
            else
                Master.MensajeError("Error al realizar la operación", "No puede emitir el Certificado antes de las 48 horas");
		}
		if (accion == "IMPRIMIR")
		{
			// VERIFICA SI YA TIENE UN CERTIFICADO EMITIDO O IMPRESO
			int nume;
		   
			//nume = obt.ObtenerCertificadoImpreso(Convert.ToInt64(iIdTramite.Value),Convert.ToInt32(iIdGrupoB.Value), idtipoformc, Convert.ToInt32(Session["NroFormCalculo"]));
			DataTable Cert = ObjCertificado.ObtenerCertificadoImpreso((int)Session["IdConexion"], "Q", Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value), idtipoformc, Convert.ToInt32(Session["NroFormCalculo"]), ref mensaje);
			if (Cert.Rows.Count > 0)
				nume = Convert.ToInt32(Cert.Rows[0]["existedatos"]);
			else
				nume = -99;

			if (nume == 0)
			{   
				ImprimirCertificado(idtipoformc, Convert.ToInt32(gvTipo.Rows[index].Cells[6].Text), idtipcc, idtipocer);

				// certificado.ImprimeCertificado(IdActualizacion, Estado, DocumentoAprobacion, out mensaje, out retorno_proc);
				string msg = "El certificado fue impreso correctamente";
				Master.MensajeOk(msg);
			}
			else 
			{
				Master.MensajeError("Error al Realizar la Operación","Ya se imprimió el Certificado, Usted solo puede Ver");
				//MessageBox.Show("No puede Imprimi nuevamente el Certificado.....ya tiene asignado el numero , usted puede ver!!", "Mensaje", MessageBoxButtons.OK);
			}
		}
		if (accion == "VER")
		{
			int nume;
			nume = Convert.ToInt32(ObjCertificado.ObtenerCertificadoImpreso((int)Session["IdConexion"], "Q", Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value), idtipoformc, Convert.ToInt32(Session["NroFormCalculo"]), ref mensaje).Rows[0]["existedatos"].ToString());
			GridViewRow gvRow = gvTipo.Rows[index];
			fecemision = gvRow.Cells[10].Text;
			VerCertificadoEmitido(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value), fecemision);
			string msg = "El certificado se visualizó en la pantalla previa";
			Master.MensajeOk(msg);
		 }
	}
   
	// MODULO PARA EMITIR EL CERTIFICADO
	protected void EmitirCertificado(int idtipoformc, int idtipocer, int idtipcc, int NroForm, decimal MontoCC , string fechagen)
	{
		string fechaemi = Convert.ToString(DateTime.Now.ToString()); // 18
	   
		int NumeroCertificado=0;
		int NumeroAsig=0;
			  
		// OBTIENE CORRELATIVO PARA EL CERTIFICADO  SI EXISTE O NO UN CERTIFICADO EMITIDO
		DataTable dt = ObjAsignacion.ObtenerNumeroCertificado((int)Session["IdConexion"], "Q", Oficina, idtipocer,Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value), ref mensaje);
		if (dt != null && dt.Rows.Count > 0)
		{
			foreach (DataRow tp2 in dt.Rows)
			{
				NumeroCertificado = Convert.ToInt32(tp2["existedatos"]);
				NumeroAsig = Convert.ToInt32(tp2["NumeroAsignacion"]);
			}
			Session["NumeroCert"] = NumeroCertificado;
		}
		else 
		{
			NumeroAsig = 0;
			NumeroCertificado = 0;
			Master.MensajeError("Error al realizar la Operación", mensaje);
		}
			//   NumeroCertificado = 0;
		if (NumeroCertificado == 0)  // si no existe stock
		{
			Master.MensajeError("Error al Realizar la operación", "No puede Emitir el Certificado,no existe stock de certificados en Almacén");
		}
		else // si existe
		{
			DateTime fec = DateTime.Now;
			DataTable Certificado = new DataTable();
			// VOLVER CALCULAR EL MONTO
			string newvalue,TotalGanado="",DensidadTotal,SalCotActTot,SalCotAct="";

			//DESCOMENTAR EN CASO DE NO FUNCIONAR
			Certificado = ObjCertificado.CalcularMontosaLaFecha((int)Session["IdConexion"], "Q", Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value),/* "01/06/2014"*/fec.ToShortDateString(), idtipoformc, idtipcc, ref mensaje);
			if (Certificado != null && Certificado.Rows.Count > 0)
			{
				newvalue = Certificado.Rows[0]["MontoCCAceptado"].ToString().Replace(',', '.'); // MontoCCAceptado
				TotalGanado = ""; //TotalGanado
				DensidadTotal = Certificado.Rows[0]["Densidad_Total"].ToString().Replace(',', '.');//DensidadTotal
				SalCotActTot = Certificado.Rows[0]["SalarioCotizableAct_Total"].ToString().Replace(',', '.');//SalarioCotizableActualizadoTotal
				SalCotAct = ""; //SalarioActualizadoTotal
				if (ObjCertificado.AdicionarActualizarEmisionCertificado((int)Session["IdConexion"], "I", Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value), idtipoformc, NroForm, idtipcc, idtipocer, NumeroCertificado, NumeroAsig, fechaemi, Oficina, Usuario, newvalue, TotalGanado, DensidadTotal, SalCotActTot, SalCotAct, ref mensaje))
					Master.MensajeOk("Se realizó la operación con éxito");
				else
					Master.MensajeError("Error al realizar la Operación", mensaje);
			}
			else 
			{
				Master.MensajeError("Error al realizar la operación", mensaje);
			}            
		// ADICIONA EL CERTIFICADO EN LA TABLA CERTIFICADO CC 

		}
	}

	// MODULO PARA IMPRIMIR EL CERTIFICADO
	private void ImprimirCertificado(int idtipoformc,int NoFormCalculo,int idtipcc,int idtipocer)
	{
		clsEmisionCertificado act = new clsEmisionCertificado();
		string a = iIdTramite.Value;
		string b = iIdGrupoB.Value;
		if (ObjCertificado.ActualizarCertificadoCC((int)Session["IdConexion"], "U", Convert.ToInt64(a), Convert.ToInt32(b), idtipoformc, NoFormCalculo, idtipcc, ref mensaje))
		{
            //Response.Redirect("../Reportes/wfrmReporteCertificadoCC.aspx?iIdTramite=" + a + "&iIdGrupoBeneficio=" + b + " ");
            ScriptManager.RegisterStartupScript(this, GetType(), "openCertificado", " window.open('../Reportes/wfrmReporteCertificadoCC.aspx?iIdTramite=" + a + "&iIdGrupoBeneficio=" + b + "', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
		}
		else 
		{
			Master.MensajeError("Error al Realizar la Operación", mensaje);
		}  	
	}

	// LISTA REGISTROS ya emitidos EN MODALPOPUP
	protected void VerCertificadoEmitido(Int64 Idtramite,Int32 IdGrupoB, string fecemision)
	{   
		if (fecemision == " ")
			Session["ImprCertificado"] = 0;  // no existe certificado generado
		else 
			Session["ImprCertificado"] = 1; // existe un certificado generado

		ScriptManager.RegisterStartupScript(this, GetType(), "openReporteSeguimiento", " window.open('../Reportes/wfrmReporteCertificadoCC.aspx?iIdTramite=" + iIdTramite.Value + "&iIdGrupoBeneficio=" + iIdGrupoB.Value + "', 'newWindow', 'height=1250px, width=100%,  resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
	}
	#endregion
}
