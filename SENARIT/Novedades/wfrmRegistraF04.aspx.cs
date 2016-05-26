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

public partial class Novedades_wfrmRegistraF04 : System.Web.UI.Page
{

    string Tipo;
    string Certificado;
    string IdTipoCertificado;
    string NUPDerechohabiente;

    
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
        NUPDerechohabiente = (string)Session["NUP"];
        clsNovedades permiso = new clsNovedades();
        DataTable DH = permiso.Form04ListarDH1(iIdConexion,"Q", IdTipoCertificado, Certificado, NUPDerechohabiente, ref sMensajeError);
        if (sMensajeError.Length != 0)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
        }
        if (DH != null)
        {
            foreach (DataRow drDataRow in DH.Rows)
            {
                this.ddlEntidades.SelectedValue = Convert.ToString(drDataRow["IdFuente"]);
                this.ddlEntidades_muestra.SelectedValue = Convert.ToString(drDataRow["IdFuente"]);
                this.ddlTipoDoc.SelectedValue = Convert.ToString(drDataRow["IdTipoDocumento"]);
                this.ddlTipoDoc_muestra.SelectedValue = Convert.ToString(drDataRow["IdTipoDocumento"]);
                this.ddlOrigenDoc.SelectedValue = Convert.ToString(drDataRow["IdDocumentoExpedido"]);
                this.ddlOrigenDoc_muestra.SelectedValue = Convert.ToString(drDataRow["IdDocumentoExpedido"]);
                this.TextNumDoc.Text = Convert.ToString(drDataRow["NumeroDocumento"]);
                this.TextNumDoc_muestra.Text = Convert.ToString(drDataRow["NumeroDocumento"]);
                this.TextPaterno.Text = Convert.ToString(drDataRow["PrimerApellido"]);
                this.TextPaterno_muestra.Text = Convert.ToString(drDataRow["PrimerApellido"]);
                this.TextMaterno.Text = Convert.ToString(drDataRow["SegundoApellido"]);
                this.TextMaterno_muestra.Text = Convert.ToString(drDataRow["SegundoApellido"]);
                this.TextPrimer.Text = Convert.ToString(drDataRow["PrimerNombre"]);
                this.TextPrimer_muestra.Text = Convert.ToString(drDataRow["PrimerNombre"]);
                this.TextSegundo.Text = Convert.ToString(drDataRow["SegundoNombre"]);
                this.TextSegundo_muestra.Text = Convert.ToString(drDataRow["SegundoNombre"]);
                this.ddlSexo.SelectedValue = Convert.ToString(drDataRow["IdSexo"]);
                this.ddlSexo_muestra.SelectedValue = Convert.ToString(drDataRow["IdSexo"]);
                this.TextNacimiento.Text = Convert.ToString(drDataRow["Nacimiento"]);
                this.TextNacimiento_muestra.Text = Convert.ToString(drDataRow["Nacimiento"]);
                this.TextComplemento.Text = Convert.ToString(drDataRow["ComplementoSEGIP"]);
                this.TextComplemento_muestra.Text = Convert.ToString(drDataRow["ComplementoSEGIP"]);
                this.TextIniPago.Text = Convert.ToString(drDataRow["FechaInicio"]);
                this.TextIniPago_muestra.Text = Convert.ToString(drDataRow["FechaInicio"]);
                this.ddlEstadoDH.SelectedValue = Convert.ToString(drDataRow["ActivoDH"]);
                this.ddlEstadoDH_muestra.SelectedValue = Convert.ToString(drDataRow["ActivoDH"]);
                this.ddlTipoReg.SelectedValue = Convert.ToString(drDataRow["RegistroActivo"]);
                this.ddlTipoReg_muestra.SelectedValue = Convert.ToString(drDataRow["RegistroActivo"]);
                this.NUPAsegurado.Text = Convert.ToString(drDataRow["NUPAsegurado"]);
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
    }

   protected void InsertaF04(object sender, EventArgs e)
   {
       string separador = "|";
       string mensaje="" ;
       string DetalleError="";
       int retorno_proc;
       ValidaF04(out mensaje, out retorno_proc);
       if (retorno_proc == -1)
       {
           string Error = mensaje;
           DetalleError = mensaje;
           Master.MensajeError(Error, DetalleError);
           return;
        }

       NUPDerechohabiente = (string)Session["NUP"];
       clsNovedades valida = new clsNovedades();
       string NUPAsegurado = this.NUPAsegurado.Text;
       string IdTipoDocumento = this.ddlTipoDoc.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckTipoDoc.Checked));
       string IdEntidadGestora = this.ddlEntidades.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckEntidad.Checked));
       string IdDocumentoExpedido = this.ddlOrigenDoc.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckOrigen.Checked));
       string NumeroDocumento = this.TextNumDoc.Text + separador + Convert.ToString(Convert.ToInt32(CheckNumDoc.Checked));
       string ComplementoSEGIP = this.TextComplemento.Text + separador + Convert.ToString(Convert.ToInt32(CheckComplemento.Checked));
       string PrimerApellido = this.TextPaterno.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxPaterno.Checked));
       string SegundoApellido = this.TextMaterno.Text + separador + Convert.ToString(Convert.ToInt32(CheckMaterno.Checked));
       string PrimerNombre = this.TextPrimer.Text + separador + Convert.ToString(Convert.ToInt32(CheckPrimer.Checked));
       string SegundoNombre = this.TextSegundo.Text + separador + Convert.ToString(Convert.ToInt32(CheckSegundo.Checked));
       string IdSexo = this.ddlSexo.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckSexo.Checked));
       string FechaNacimiento = this.TextNacimiento.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxNacimiento.Checked));
       string FechaInicioVigencia = this.TextIniPago.Text + separador + Convert.ToString(Convert.ToInt32(CheckIniPago.Checked));
       string RegistroActivo = this.ddlEstadoDH.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckEstadoDH.Checked));
       string EstadoVersion = this.ddlTipoReg.SelectedValue + separador + Convert.ToString(Convert.ToInt32(CheckTipoReg.Checked));
       string IdInstitucionSolicitante = this.ddlEntidades.SelectedValue;
       string Usuario = valida.IdUsuarioConectado((int)Session["IdConexion"]);
       int iIdConexion = (int)Session["IdConexion"];
       string cOperacion = "I";
       string sSessionTrabajo = null;
       string sSNN = null;

       if (valida.Form04Ins(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref DetalleError,
              NUPAsegurado, NUPDerechohabiente, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP, PrimerApellido,
                    SegundoApellido, PrimerNombre, SegundoNombre, IdSexo, FechaNacimiento, FechaInicioVigencia, RegistroActivo,
                    EstadoVersion, Usuario, IdInstitucionSolicitante, ref mensaje))
       {
           Master.MensajeOk(mensaje);
       }
       else
       {
           Master.MensajeError("Error al realizar la operación", DetalleError);
       }
   }

   protected void ValidaF04(out string mensaje, out int retorno_proc)
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
       // se valida paterno
       valor1 = TextPaterno_muestra.Text;
       valor2 = TextPaterno.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxPaterno.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Paterno";
           return;
       }
       // se valida materno
       valor1 = TextMaterno_muestra.Text;
       valor2 = TextMaterno.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckMaterno.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Materno";
           return;
       }
       // se valida primer nombre
       valor1 = TextPrimer_muestra.Text;
       valor2 = TextPrimer.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckPrimer.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Primer Nombre";
           return;
       }
       // se valida segundo nombre
       valor1 = TextSegundo_muestra.Text;
       valor2 = TextSegundo.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckSegundo.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Segundo Nombre";
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
       // se valida Nacimiento
       valor1 = TextNacimiento_muestra.Text;
       valor2 = TextNacimiento.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckBoxNacimiento.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Nacimiento";
           return;
       }
       // se valida Inicio de Pago
       valor1 = TextIniPago_muestra.Text;
       valor2 = TextIniPago.Text;
       chequeado = Convert.ToString(Convert.ToInt32(CheckIniPago.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Inicio de Pago";
           return;
       }
       // se valida estadodh
       valor1 = this.ddlEstadoDH_muestra.SelectedValue;
       valor2 = this.ddlEstadoDH.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckEstadoDH.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de EstadoDH";
           return;
       }
       // se valida tiporegistro
       valor1 = this.ddlTipoReg_muestra.SelectedValue;
       valor2 = this.ddlTipoReg.SelectedValue;
       chequeado = Convert.ToString(Convert.ToInt32(CheckTipoReg.Checked));
       if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
       {
           retorno_proc = -1;
           mensaje = "Modificación Erronea de Tipo de Registro";
           return;
       }
       // se validan campos contra la base
       string separador = "|";
       NUPDerechohabiente = (string)Session["NUP"];
       string NumeroDocumento = this.TextNumDoc.Text + separador + Convert.ToString(Convert.ToInt32(CheckNumDoc.Checked));
       string ComplementoSEGIP = this.TextComplemento.Text + separador + Convert.ToString(Convert.ToInt32(CheckComplemento.Checked));
       string FechaNacimiento = this.TextNacimiento.Text + separador + Convert.ToString(Convert.ToInt32(CheckBoxNacimiento.Checked));
       string PeriodoInicio = this.TextIniPago.Text + separador + Convert.ToString(Convert.ToInt32(CheckIniPago.Checked));
       clsNovedades valida = new clsNovedades();
       valida.Form04ValidaInsercion(NUPDerechohabiente, NumeroDocumento, ComplementoSEGIP, FechaNacimiento, PeriodoInicio, out mensaje, out retorno_proc);
       if (retorno_proc == -1) return;
   }

   protected void VolverBuscaDH(object sender, EventArgs e)
   {
       Response.Redirect("wfrmBusquedaTitDH.aspx");
   }
}