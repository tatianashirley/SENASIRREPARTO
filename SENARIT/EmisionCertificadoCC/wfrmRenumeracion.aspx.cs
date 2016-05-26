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


public partial class EmisionCertificadoCC_wfrmRenumeracion : System.Web.UI.Page
{
	int IdConexion;
	clsEmisionCertificado Conexion = new clsEmisionCertificado();
	clsEmisionCertificado certi = new clsEmisionCertificado();
	clsAsignarCorrelativo obt = new clsAsignarCorrelativo();
	DataTable DatosConexion;
	int Usuario, Oficina,contador;
	string mensaje;
	bool sw = false;
	string idOficina = "";
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
			contador = 0;
		}
		DatosConexion = new DataTable();
		DatosConexion = Conexion.DatosConexion((int)Session["IdConexion"]);
		Usuario = Convert.ToInt32(DatosConexion.Rows[0]["IdUsuario"].ToString());
		Oficina = Convert.ToInt32(DatosConexion.Rows[0]["IdOficina"].ToString());

		if (!Page.IsPostBack)
		{
			CargarComboOficinaPrincipal(); //Lista de Oficinas que tienen Certificados
			CargarUltimosNumero(); //Carga el ultimo numero de certificado usado en base a Oficina
			ListarRegistros(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
			//idOficina = ddlOficinacom.SelectedValue;
		}
	}

	# region Cargar_Combos_Grillas
	// LISTAR REGISTRO DE UN TIPO DE TRAMITE en la GRILLA (FUNCIONAL)
	protected void ListarRegistros(Int64 Trami, Int32 beneficio)
	{
		mensaje = null;
		gv1.DataSource = certi.DatosCertificadoCompleto((int)Session["IdConexion"], "A", Trami, beneficio, ref mensaje);
		gv1.DataBind();
		if (gv1.DataSource == null && gv1.Rows.Count <= 0)
			Master.MensajeError("Error al realizar la Operación", mensaje);
	}
	// CARGA GRILLA DE ULTIMOS NUMEROS GENERADOS
	protected void CargarUltimosNumero()
	{
		Master.MensajeCancel();
        int IdArea = Convert.ToInt32(ddlOficinacom.SelectedValue);
		clsAsignarCorrelativo admi = new clsAsignarCorrelativo();
        gvUltimo.DataSource = admi.UltimoNumeroAplicadoX((int)Session["IdConexion"], "M", IdArea, ref mensaje);
		gvUltimo.DataBind();
		if (gvUltimo.DataSource == null || gvUltimo.Rows.Count <= 0)
			Master.MensajeError("Error al realizar la Operación", mensaje);
	}
	//Actualiza el Lote de donde se sacará el nuevo certificado
	protected void ddlOficinacom_SelectedIndexChanged(object sender, EventArgs e)
	{
		idOficina = ddlOficinacom.SelectedValue;
		CargarUltimosNumero();
        ListarRegistros(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
	}

    private void CargarComboOficinaPrincipal() //CREACION 28/07/2015
	{
		ddlOficinacom.DataSource = obt.AreasImpresion((int)Session["IdConexion"], "B", ref mensaje);
		ddlOficinacom.DataValueField = "IdArea";
		ddlOficinacom.DataTextField = "Descripcion";
		ddlOficinacom.DataBind();
		if (ddlOficinacom.DataSource == null || ddlOficinacom.Items.Count <= 0)
			Master.MensajeError("Error al realizar la Operación", mensaje);
	}
	#endregion


	# region Eventos_AccionesGrilla
	// DATABOUND DE LA GRILLA PARA CONTROLAR UNO A UNO LA ACTIVACION DE BOTONES DE REIMPRIMIR Y REEMITIR
	protected void gvTipo_RowDataBound(object sender, GridViewRowEventArgs e)
	{   
		int fila=e.Row.RowIndex;
		int OfiNot, TipoTramite,FlagImprimeCC,IdEstado;
		OfiNot = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdOficinaNotificacion"));
		TipoTramite = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdTipoTramite"));
		FlagImprimeCC = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FlagImprimeCC"));
		int x = Convert.ToInt32(ddlOficinacom.SelectedValue);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			OfiNot = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdOficinaNotificacion"));
			TipoTramite = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdTipoTramite"));
			FlagImprimeCC = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FlagImprimeCC"));
			IdEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdEstado"));

            ImageButton imgReimprimir = (ImageButton)e.Row.FindControl("imgReimprimir");
            ImageButton imgRenumerar = (ImageButton)e.Row.FindControl("imgRenumerar");
            ImageButton imgVer = (ImageButton)e.Row.FindControl("imgVer");

            imgReimprimir.Enabled = false; //BOTON DE RENUMERA/IMPRIME - 19
            imgReimprimir.Visible = false; //BOTON DE RENUMERA/IMPRIME - 19
            imgRenumerar.Enabled = false; //BOTON DE RENUMERAR - 20
            imgRenumerar.Visible = false; //BOTON DE RENUMERAR - 20
            imgVer.Enabled = false; //BOTON DE VER - 21
            imgVer.Visible = false; //BOTON DE VER - 21

            if (IdEstado == 34 || IdEstado == 37 )
            {
	            if (OfiNot != 2)
	            {
                    //imgReimprimir.Enabled = false; //BOTON DE RENUMERA/IMPRIME - 19
                    //imgReimprimir.Visible = false; //BOTON DE RENUMERA/IMPRIME - 19
                    imgRenumerar.Enabled = true; //BOTON DE RENUMERAR - 20
                    imgRenumerar.Visible = true; //BOTON DE RENUMERAR - 20
                    imgVer.Enabled = true; //BOTON DE VER - 21
                    imgVer.Visible = true; //BOTON DE VER - 21
	            }
	            else
	            {
		            if (OfiNot == 2)
		            {
                        imgReimprimir.Enabled = false; //BOTON DE RENUMERA/IMPRIME - 19
                        imgReimprimir.Visible = false; //BOTON DE RENUMERA/IMPRIME - 19
                        imgRenumerar.Enabled = true; //BOTON DE RENUMERAR - 20
                        imgRenumerar.Visible = true; //BOTON DE RENUMERAR - 20
                        imgVer.Enabled = true; //BOTON DE VER - 21
                        imgVer.Visible = true; //BOTON DE VER - 21
                    }
	            }
            }

            if (ddlOficinacom.SelectedValue == "29121")
            {
                imgReimprimir.Enabled = true; //BOTON DE RENUMERA/IMPRIME - 19
                imgReimprimir.Visible = true; //BOTON DE RENUMERA/IMPRIME - 19
                imgRenumerar.Enabled = false; //BOTON DE RENUMERAR - 20
                imgRenumerar.Visible = false; //BOTON DE RENUMERAR - 20
                imgVer.Enabled = true; //BOTON DE VER - 21
                imgVer.Visible = true; //BOTON DE VER - 21
            }			
		}
	}

	protected void gvTipo_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int index = Convert.ToInt32(e.CommandArgument);
		string accion = e.CommandName.ToUpper();
		int TipoTramite = Convert.ToInt32(gv1.DataKeys[index]["IdTipoTramite"]);
		int CertActual = Convert.ToInt32(gv1.DataKeys[index]["NroCertificado"]);
		int NumeroCertificado,NroAsignacion,NroForm;
		if (accion == "CMDREIMPRIMIR")
		{   //Devuelve el numero de certificado que corresponde aplicar al tramite
			DataTable Certif = obt.ObtenerNumeroCertificadoX((int)Session["IdConexion"], "C", Convert.ToInt32(ddlOficinacom.SelectedValue), TipoTramite, ref mensaje);
			if (Certif.Rows.Count > 0)
			{
				NumeroCertificado = Convert.ToInt32(Certif.Rows[0]["existedatos"]);
				NroAsignacion = Convert.ToInt32(Certif.Rows[0]["NumeroAsignacion"]);
			}
			else 
			{ 
				NumeroCertificado = 0;
				NroAsignacion = 0;
			}
			if (NumeroCertificado == 0)
			{
				Master.MensajeError("Error al Realizar la operacion", "No existe Stock de Certificados para impresion");
			}
			else
			{
				//if (txtObs.Text != "")
				//{
				NroForm = Convert.ToInt32(gv1.DataKeys[index]["NoFormularioCalculo"]);
				ReimprimirCertificado(NumeroCertificado, txtObs.Text, 1, Convert.ToInt32(ddlOficinacom.SelectedValue), TipoTramite, NroAsignacion,NroForm,CertActual);
				CargarUltimosNumero();
				ListarRegistros(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
				Session["TipoFormulario"] = Convert.ToInt32(gv1.DataKeys[index]["IdTipoFormularioCalculo"]);
				Session["NroFormCalculo"] = Convert.ToInt32(gv1.DataKeys[index]["NoFormularioCalculo"]);
				
				Response.Redirect("../Reportes/wfrmReporteCertificadoCC.aspx?iIdTramite=" + iIdTramite.Value + "&iIdGrupoBeneficio=" + iIdGrupoB.Value + " ");
				//contador = 1;
				//}
				//else 
				//{
				//    Master.MensajeError("Error al realizar la operacion!!!", "Debe ingresar la glosa de la Baja del Certificado");
				//}
			}
		}
		if (accion == "CMDEMITIR")
		{
			DataTable Certif = obt.ObtenerNumeroCertificadoX((int)Session["IdConexion"], "C", Convert.ToInt32(ddlOficinacom.SelectedValue), TipoTramite, ref mensaje);
			if (Certif.Rows.Count > 0)
			{
				NumeroCertificado = Convert.ToInt32(Certif.Rows[0]["existedatos"]);
				NroAsignacion = Convert.ToInt32(Certif.Rows[0]["NumeroAsignacion"]);
			}
			else
			{
				NumeroCertificado = 0;
				NroAsignacion = 0;
			}

			if (NumeroCertificado == 0)
			{
				Master.MensajeError("Error al Realizar la operacion", "No existe Stock de Certificados para impresion");
			}
			else
			{
				//if (txtObs.Text != "")
				//{
					NroForm = Convert.ToInt32(gv1.DataKeys[index]["NoFormularioCalculo"]);
					ReimprimirCertificado(NumeroCertificado, txtObs.Text, 2, Convert.ToInt32(ddlOficinacom.SelectedValue), TipoTramite, NroAsignacion, NroForm, CertActual);
					CargarUltimosNumero();
					ListarRegistros(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
					contador = 1;
				//}
				//else 
				//{
				//    Master.MensajeError("Error al realizar la operacion!!!","Debe ingresar la glosa de la Baja del Certificado");
				//}
			}
		}
		if (accion == "CMDVER")
		{
			Session["TipoFormulario"] = Convert.ToInt32(gv1.DataKeys[index]["IdTipoFormularioCalculo"]);
			Session["NroFormCalculo"] = Convert.ToInt32(gv1.DataKeys[index]["NoFormularioCalculo"]);
			VerCertificadoEmitido(Convert.ToInt64(iIdTramite.Value), Convert.ToInt32(iIdGrupoB.Value));
		}
	}

	//Muestra el Certificado Nuevamente
	protected void VerCertificadoEmitido(Int64 Idtramite, Int32 IdGrupoB)
	{
		Response.Redirect("../Reportes/wfrmReporteCertificadoCC.aspx?iIdTramite=" + Idtramite + "&iIdGrupoBeneficio=" + IdGrupoB+ " ");
	}
	// MODULO PARA IMPRIMIR EL CERTIFICADO
	private void ReimprimirCertificado(Int32 NroCertificado,string Observacion, Int32 Decision,Int32 IdArea,Int32 TipoTramite,Int32 NroAsig,Int32 NroForm,Int32 CertActual )
	{
		clsEmisionCertificado act = new clsEmisionCertificado();
		string a = iIdTramite.Value;
		string b = iIdGrupoB.Value;
		if (certi.ReimpresionCertificadoCC((int)Session["IdConexion"],"B",Convert.ToInt64(a),Convert.ToInt32(b),NroCertificado,Observacion,IdArea,TipoTramite,NroAsig,Decision,NroForm,CertActual,ref mensaje))
		{
			//Response.Redirect("../Reportes/wfrmReporteCertificadoCC.aspx?iIdTramite=" + a + "&iIdGrupoBeneficio=" + b + " ");
			Master.MensajeOk("Se reimprimió con el Numero de Certificado: " + NroCertificado);

		}
		else
		{
			Master.MensajeError("Error al Realizar la Operación!!!", "No se puede realizar mas de una Reimpresion");
		}
	}
	#endregion

}
