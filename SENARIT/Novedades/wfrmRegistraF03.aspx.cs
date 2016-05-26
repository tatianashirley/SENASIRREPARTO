using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfNovedades.Logica;

using System.Drawing;

//using WcfServicioClasificador.Logica;
using wcfNovedades.Datos;

public partial class Novedades_wfrmRegistraF02 : System.Web.UI.Page
{

    string Tipo;
    string Certificado;
    string IdTipoCertificado;
    string NUPTitular;

    
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!Page.IsPostBack)
        {
            CargarCombos();
            Cargar_Campos();
             
        }
    }
    //-------------------------------------------------------------------------------------------------

    private void Cargar_Campos()
    {
		int iIdConexion = (int)Session["IdConexion"];
		 String sMensajeError="";
        Tipo = (string)Session["Tipo"];
        Certificado = (string)Session["Certificado"];
        IdTipoCertificado = (string)Session["TipoCertificado"];
        NUPTitular = (string)Session["NUP"];
        clsNovedades permiso = new clsNovedades();
        DataTable Tit = permiso.Form03ListarTit1(iIdConexion,"Q", IdTipoCertificado, Certificado, NUPTitular, ref sMensajeError);
        if (sMensajeError.Length != 0)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
		
        if (Tit != null)
        {
            foreach (DataRow drDataRow in Tit.Rows)
            {
                this.ddlEntidades.SelectedValue = Convert.ToString(drDataRow["IdFuente"]);
                this.ddlEntidades_muestra.SelectedValue = Convert.ToString(drDataRow["IdFuente"]);
                this.ddlTipoDoc.SelectedValue = Convert.ToString(drDataRow["IdTipoDocumento"]);
                this.ddlTipoDoc_muestra.SelectedValue = Convert.ToString(drDataRow["IdTipoDocumento"]);
                this.ddlOrigenDoc.SelectedValue = Convert.ToString(drDataRow["IdDocumentoExpedido"]);
                this.ddlOrigenDoc_muestra.SelectedValue = Convert.ToString(drDataRow["IdDocumentoExpedido"]);
                this.ddlSexo.SelectedValue = Convert.ToString(drDataRow["IdSexo"]);
                this.ddlSexo_muestra.SelectedValue = Convert.ToString(drDataRow["IdSexo"]);

                this.TextNumDoc.Text = Convert.ToString(drDataRow["NumeroDocumento"]);
                this.TextNumDoc_muestra.Text = Convert.ToString(drDataRow["NumeroDocumento"]);
                this.TextSolicitud.Text = Convert.ToString(drDataRow["FechaSolicitud"]);
                this.TextSolicitud_muestra.Text= Convert.ToString(drDataRow["FechaSolicitud"]);
                this.TipoCambio1.Text = Convert.ToString(drDataRow["TipoCambio1"]);
                this.TipoCambio1_muestra.Text= Convert.ToString(drDataRow["TipoCambio1"]);
                this.TipoCambio2.Text = Convert.ToString(drDataRow["TipoCambio2"]);
                this.TipoCambio2_muestra.Text= Convert.ToString(drDataRow["TipoCambio2"]);
                this.ddlTipoAjuste_muestra.SelectedValue = Convert.ToString(drDataRow["TipoAjuste"]);
                this.ddlTipoAjuste.SelectedValue = Convert.ToString(drDataRow["TipoAjuste"]);
                this.PorcentajeAjuste.Text = Convert.ToString(drDataRow["PorcentajeAjuste"]);
                this.PorcentajeAjuste_muestra.Text = Convert.ToString(drDataRow["PorcentajeAjuste"]);
                this.SalarioBase.Text = Convert.ToString(drDataRow["SalarioBase"]);
                this.SalarioBase_muestra.Text = Convert.ToString(drDataRow["SalarioBase"]);
                this.AniosInsalubres.Text = Convert.ToString(drDataRow["AniosInsalubres"]);
                this.AniosInsalubres_muestra.Text = Convert.ToString(drDataRow["AniosInsalubres"]);
                this.MontoAjustado.Text = Convert.ToString(drDataRow["MontoAjustado"]);
                this.MontoAjustado_muestra.Text = Convert.ToString(drDataRow["MontoAjustado"]);
                this.NumeroSolicitud.Text = Convert.ToString(drDataRow["NumeroSolicitud"]);
                this.NumeroSolicitud_muestra.Text = Convert.ToString(drDataRow["NumeroSolicitud"]);
                this.PeriodoSolicitud.Text = Convert.ToString(drDataRow["PeriodoSolicitud"]);
                this.PeriodoSolicitud_muestra.Text = Convert.ToString(drDataRow["PeriodoSolicitud"]);
                this.ddlRegistroActivo.SelectedValue = Convert.ToString(drDataRow["RegistroActivo"]);
                this.ddlRegistroActivo_muestra.SelectedValue = Convert.ToString(drDataRow["RegistroActivo"]);
                this.IdTitular.Text = Convert.ToString(drDataRow["IdHabilitacionTitularCC"]);
                this.lblNombre.Text = Convert.ToString(drDataRow["Nombres"]);
        
            }
        }		
        
    }

   protected void CargarCombos()
    {
        clsNovedades clas = new clsNovedades();
         ddlEntidades.DataSource = clas.ListarClasifporTipo(16);
         ddlEntidades.DataValueField = "IdTipoActualizacion";
         ddlEntidades.DataTextField = "DescripcionActualizacion";
         ddlEntidades.DataBind();
         ddlEntidades_muestra.DataSource = clas.ListarClasifporTipo(16);
         ddlEntidades_muestra.DataValueField = "IdTipoActualizacion";
         ddlEntidades_muestra.DataTextField = "DescripcionActualizacion";
         ddlEntidades_muestra.DataBind();
        ddlTipoDoc.DataSource = clas.ListarClasifporTipo(4);
        ddlTipoDoc.DataValueField = "IdTipoActualizacion";
        ddlTipoDoc.DataTextField = "DescripcionActualizacion";
        ddlTipoDoc.DataBind();
        ddlTipoDoc_muestra.DataSource = clas.ListarClasifporTipo(4);
        ddlTipoDoc_muestra.DataValueField = "IdTipoActualizacion";
        ddlTipoDoc_muestra.DataTextField = "DescripcionActualizacion";
        ddlTipoDoc_muestra.DataBind();
        ddlSexo.DataSource = clas.ListarClasifporTipo(1);
        ddlSexo.DataValueField = "IdTipoActualizacion";
        ddlSexo.DataTextField = "DescripcionActualizacion";
        ddlSexo.DataBind();
        ddlSexo_muestra.DataSource = clas.ListarClasifporTipo(1);
        ddlSexo_muestra.DataValueField = "IdTipoActualizacion";
        ddlSexo_muestra.DataTextField = "DescripcionActualizacion";
        ddlSexo_muestra.DataBind();
        ddlOrigenDoc.DataSource = clas.ListarClasifporTipo(9);
        ddlOrigenDoc.DataValueField = "IdTipoActualizacion";
        ddlOrigenDoc.DataTextField = "DescripcionActualizacion";
        ddlOrigenDoc.DataBind();
        ddlOrigenDoc_muestra.DataSource = clas.ListarClasifporTipo(9);
        ddlOrigenDoc_muestra.DataValueField = "IdTipoActualizacion";
        ddlOrigenDoc_muestra.DataTextField = "DescripcionActualizacion";
        ddlOrigenDoc_muestra.DataBind();
        ddlTipoAjuste.DataSource = clas.ListarClasifporTipo(56);
        ddlTipoAjuste.DataValueField = "IdTipoActualizacion";
        ddlTipoAjuste.DataTextField = "DescripcionActualizacion";
        ddlTipoAjuste.DataBind();
        ddlTipoAjuste_muestra.DataSource = clas.ListarClasifporTipo(56);
        ddlTipoAjuste_muestra.DataValueField = "IdTipoActualizacion";
        ddlTipoAjuste_muestra.DataTextField = "DescripcionActualizacion";
        ddlTipoAjuste_muestra.DataBind();

    }

   protected void InsertaF03(object sender, EventArgs e)
   {
       string separador = "|";
       string mensaje="" ;
       string DetalleError="" ;
       int retorno_proc;
       ValidaF03(out mensaje, out retorno_proc);
       if (retorno_proc == -1)
       {
           string Error = mensaje;
           DetalleError = mensaje;
           Master.MensajeError(Error, DetalleError);
           return;
       }
       NUPTitular = (string)Session["NUP"];
       Certificado = (string)Session["Certificado"];
       IdTipoCertificado = (string)Session["TipoCertificado"];
       clsNovedades valida = new clsNovedades();
       string IdTipoDocumento = this.ddlTipoDoc.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckTipoDoc.Checked));
       string IdEntidadGestora = this.ddlEntidades.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckEntidad.Checked));
       string IdDocumentoExpedido = this.ddlOrigenDoc.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckOrigen.Checked));
       string NumeroDocumento = this.TextNumDoc.Text + separador + Convert.ToString(Convert.ToInt32(CheckNumDoc.Checked));
       string ComplementoSEGIP = this.TextComplemento.Text + separador + Convert.ToString(Convert.ToInt32(CheckComplemento.Checked));
       string IdSexo = this.ddlSexo.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckSexo.Checked));
       string RegistroActivo = this.ddlRegistroActivo.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckBoxRegistroActivo.Checked));
       string FechaSolicitud = this.TextSolicitud.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxSolicitud.Checked));
       string TipoCambio1 = this.TipoCambio1.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxTipo1.Checked));
       string TipoCambio2 = this.TipoCambio2.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxTipo2.Checked));
       string TipoAjuste = this.ddlTipoAjuste.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckBoxTipoAjuste.Checked));
       string PorcentajeAjuste = this.PorcentajeAjuste.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxPorcentajeAjuste.Checked));
       string SalarioBase = this.SalarioBase.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxSalarioBase.Checked));
       string AniosInsalubres = this.AniosInsalubres.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxAniosInsalubres.Checked));
       string MontoAjustado = this.MontoAjustado.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxMontoAjustado.Checked));
       string NumeroSolicitud = this.NumeroSolicitud.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxNumeroSolicitud.Checked));
       string PeriodoSolicitud = this.PeriodoSolicitud.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxPeriodoSolicitud.Checked));
       string IdInstitucionSolicitante = this.ddlEntidades.SelectedValue;
       string Usuario = valida.IdUsuarioConectado((int)Session["IdConexion"]);
       int iIdConexion = (int)Session["IdConexion"];
       string cOperacion = "I";
       string sSessionTrabajo = null;
       string sSNN = null;

       if (valida.Form03Ins(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref DetalleError,
                NUPTitular, Certificado, IdTipoCertificado, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP,
             IdSexo, RegistroActivo, FechaSolicitud, TipoCambio1, TipoCambio2, TipoAjuste, PorcentajeAjuste, SalarioBase, AniosInsalubres, MontoAjustado, NumeroSolicitud, PeriodoSolicitud,
             Usuario, IdInstitucionSolicitante, ref mensaje))
       {
           Master.MensajeOk(mensaje);
       }
       else
       {
          Master.MensajeError("Error al realizar la operación", DetalleError);
       }
   }

   protected void ValidaF03(out string mensaje, out int retorno_proc)
   {
       string valor1;
       string valor2;
       string chequeado;
       retorno_proc = 1;
       mensaje = "";
       // se valida código de entidad
       valor1 = this.ddlEntidades_muestra.SelectedValue;
       valor2 = this.ddlEntidades.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckEntidad.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Entidad";
           return;
       }
       // se valida tipo de documento
       valor1 = this.ddlTipoDoc_muestra.SelectedValue;
       valor2 = this.ddlTipoDoc.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckTipoDoc.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Tipo Documento";
           return;
       }
       // se valida origen de documento
       valor1 = this.ddlOrigenDoc_muestra.SelectedValue;
       valor2 = this.ddlOrigenDoc.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckOrigen.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Origen Documento";
           return;
       }
       // se valida número de documento
       valor1 = TextNumDoc_muestra.Text;
       valor2 = TextNumDoc.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckNumDoc.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Número Documento";
           return;
       }
       // se valida número de documento
       valor1 = TextComplemento_muestra.Text;
       valor2 = TextComplemento.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckComplemento.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Complemento Documento";
           return;
       }
       // se valida sexo
       valor1 = this.ddlSexo_muestra.SelectedValue;
       valor2 = this.ddlSexo.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckSexo.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Género";
           return;
       }
       // se valida fecha de solicitud
       valor1 = TextSolicitud_muestra.Text;
       valor2 = TextSolicitud.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxSolicitud.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Fecha Solicitud";
           return;
       }
       // se valida TipoCambio1
       valor1 = TipoCambio1_muestra.Text;
       valor2 = TipoCambio1.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxTipo1.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Tipo Cambio 1";
           return;
       }
       // se valida TipoCambio2
       valor1 = TipoCambio2_muestra.Text;
       valor2 = TipoCambio2.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxTipo2.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Tipo Cambio 2";
           return;
       }
       // se valida Tipo Ajuste
       valor1 = this.ddlTipoAjuste_muestra.SelectedValue;
       valor2 = this.ddlTipoAjuste.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxTipoAjuste.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Tipo Ajuste";
           return;
       }
       // se valida % Ajuste
       valor1 = SalarioBase_muestra.Text;
       valor2 = SalarioBase.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxSalarioBase.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Salario Base";
           return;
       }
       // se valida Salario Base
       valor1 = PorcentajeAjuste_muestra.Text;
       valor2 = PorcentajeAjuste.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxPorcentajeAjuste.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea % Ajuste";
           return;
       }
       // se valida Años Insalubres
       valor1 = AniosInsalubres_muestra.Text;
       valor2 = AniosInsalubres.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxAniosInsalubres.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Años Insalubres";
           return;
       }
       // se valida Monto Ajustado
       valor1 = MontoAjustado_muestra.Text;
       valor2 = MontoAjustado.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxMontoAjustado.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Monto Ajustado";
           return;
       }
       // se valida estado titular
       valor1 = this.ddlRegistroActivo_muestra.SelectedValue;
       valor2 = this.ddlRegistroActivo.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxRegistroActivo.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Estado Titular";
           return;
       }
       // se valida Numero Solicitud
       valor1 = NumeroSolicitud_muestra.Text;
       valor2 = NumeroSolicitud.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxNumeroSolicitud.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Numero Solicitud";
           return;
       }
       // se valida Numero Solicitud
       valor1 = NumeroSolicitud_muestra.Text;
       valor2 = NumeroSolicitud.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxNumeroSolicitud.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Numero Solicitud";
           return;
       }
       // se valida Periodo Solicitud
       valor1 = PeriodoSolicitud_muestra.Text;
       valor2 = PeriodoSolicitud.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxPeriodoSolicitud.Checked));
       if (((valor1 != valor2) && chequeado != "1") ^ ((valor1 == valor2) && chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea Periodo Solicitud";
           return;
       }
       // se validan campos contra la base
       string separador = "|";
       NUPTitular = (string)Session["NUP"];
       string NumeroDocumento = this.TextNumDoc.Text + separador + Convert.ToString(Convert.ToInt32(CheckNumDoc.Checked));
       string ComplementoSEGIP = this.TextComplemento.Text + separador + Convert.ToString(Convert.ToInt32(CheckComplemento.Checked));
       string FechaSolicitud = this.TextSolicitud.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxSolicitud.Checked));
       string TipoAjuste = this.ddlTipoAjuste.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckBoxTipoAjuste.Checked));
       string RegistroActivo = this.ddlRegistroActivo.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckBoxRegistroActivo.Checked));
       string IdHabilitacionTitularCC = this.IdTitular.Text;
       string PorcentajeAjuste1 = this.PorcentajeAjuste.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxPorcentajeAjuste.Checked));
       string MontoAjustado1 = this.MontoAjustado.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxMontoAjustado.Checked));
       string TipoCambio_1 = this.TipoCambio1.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxTipo1.Checked));
       string TipoCambio_2 = this.TipoCambio2.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxTipo2.Checked));
       clsNovedades valida = new clsNovedades();
       valida.Form03ValidaInsercion(IdHabilitacionTitularCC,NUPTitular, NumeroDocumento, ComplementoSEGIP, FechaSolicitud, RegistroActivo, TipoAjuste,PorcentajeAjuste1, MontoAjustado1,TipoCambio_2,TipoCambio_1,out mensaje, out retorno_proc);
       if (retorno_proc == -1) return;
       
   }

   protected void VolverBuscaDH(object sender, EventArgs e)
   {
       Response.Redirect("wfrmBusquedaTitDH.aspx");
   }
}