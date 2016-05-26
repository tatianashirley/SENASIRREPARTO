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
using wcfNovedades.Datos;

using System.Drawing;

//using WcfServicioClasificador.Logica;
//using wcfNovedades.Datos;

public partial class Novedades_wfrmRegistraF02 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {     
        if (!Page.IsPostBack)
        {
            CargarCombos();           
        }
    }
    //-------------------------------------------------------------------------------------------------
    protected void CargarCombos()
    {
        gvCertificado.DataSource = null;
        gvCertificado.DataBind();
        this.TablaPersona.Visible = false;
        clsNovedades clas = new clsNovedades();
        ddlTipoDocumento.DataSource = clas.ListarClasifporTipo(4);
        ddlTipoDocumento.DataValueField = "IdTipoActualizacion";
        ddlTipoDocumento.DataTextField = "DescripcionActualizacion";
        ddlTipoDocumento.DataBind();
        ddlTipoDocumento_muestra.DataSource = clas.ListarClasifporTipo(4);
        ddlTipoDocumento_muestra.DataValueField = "IdTipoActualizacion";
        ddlTipoDocumento_muestra.DataTextField = "DescripcionActualizacion";
        ddlTipoDocumento_muestra.DataBind();
        ddlExtDocumento.DataSource = clas.ListarClasifporTipo(9);
        ddlExtDocumento.DataValueField = "IdTipoActualizacion";
        ddlExtDocumento.DataTextField = "CodigoActualizacion";
        ddlExtDocumento.DataBind();
        ddlExtDocumento_muestra.DataSource = clas.ListarClasifporTipo(9);
        ddlExtDocumento_muestra.DataValueField = "IdTipoActualizacion";
        ddlExtDocumento_muestra.DataTextField = "CodigoActualizacion";
        ddlExtDocumento_muestra.DataBind();
        ddlEntidades.DataSource = clas.ListarClasifporTipo(16);
        ddlEntidades.DataValueField = "IdTipoActualizacion";
        ddlEntidades.DataTextField = "DescripcionActualizacion";
        ddlEntidades.DataBind();
    }



    protected void InsertaF02(object sender, EventArgs e)
    {
        string separador = "|";
        string mensaje = "";
        string DetalleError = "";
        int retorno_proc;
        string NumeroDocumento = this.TextCI.Text;
        string ComplementoSEGIP = this.TextAlfa.Text;
        string NumRa = this.TextNumRa.Text;
        string FechaRa = this.TextFechaRa.Text;
        ValidaF02(out mensaje, out retorno_proc);
        if (retorno_proc == -1)
        {
            string Error = "Error No 13558";
            DetalleError = mensaje;
            Master.MensajeError(Error, DetalleError);
            return;
        }
        clsNovedades valida = new clsNovedades();
        valida.Form02ValidaInsercion(NumeroDocumento, ComplementoSEGIP, NumRa, FechaRa,ref mensaje, ref retorno_proc);
        if (retorno_proc == -1)
        {
            string Error = "Error No 13558";
            DetalleError = mensaje;
            Master.MensajeError(Error, DetalleError);
            return;
        };
        // se pasaron las validaciones, se inserta la novedad F02, verificando si ha sido elegido, o no
        string NUP = this.NUP.Text;
        string CUA = TextCUA.Text + "|"+ Convert.ToString(Convert.ToInt32(CheckCUA.Checked));
        string PrimerApellido = TextPaterno.Text + "|" + Convert.ToString(Convert.ToInt32(CheckBoxPaterno.Checked));
        string SegundoApellido = TextMaterno.Text + "|" + Convert.ToString(Convert.ToInt32(CheckMaterno.Checked));
        string PrimerNombre = TextPrimerNombre.Text + "|" + Convert.ToString(Convert.ToInt32(CheckPrimer.Checked));
        string SegundoNombre = TextSegundoNombre.Text + "|" + Convert.ToString(Convert.ToInt32(CheckSegundo.Checked));
        string IdTipoDocumento = this.ddlTipoDocumento.SelectedValue + "|" + Convert.ToString(Convert.ToInt32(CheckTipo.Checked));
        string IdDocumentoExpedido = this.ddlExtDocumento.SelectedValue + "|" + Convert.ToString(Convert.ToInt32(CheckExt.Checked));
        ComplementoSEGIP = this.TextAlfa.Text + "|" + Convert.ToString(Convert.ToInt32(CheckAlfa.Checked));
        NumeroDocumento = TextCI.Text + "|" + Convert.ToString(Convert.ToInt32(CheckCI.Checked));
        string claseCC = TextTipoCC.Text;
        string no_certif = this.txtNroCerti.Text;
        string IdEntidadGestora = this.ddlEntidades.SelectedValue;
        string Usuario = valida.IdUsuarioConectado((int)Session["IdConexion"]);
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        string sSessionTrabajo = null;
        string sSNN = null;

        if (valida.Form02Ins(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref DetalleError,
                 NUP, CUA, PrimerApellido, SegundoApellido, PrimerNombre, SegundoNombre, NumeroDocumento,Usuario, IdEntidadGestora,"Documento 1",
              IdTipoDocumento, IdDocumentoExpedido, ComplementoSEGIP, NumRa, FechaRa,no_certif,claseCC, ref mensaje))
        {
            Master.MensajeOk(mensaje);
        }
        else
        {
            Master.MensajeError("Error al realizar la operación", DetalleError);
        }

        //valida.Form02Ins(NUP, CUA, PrimerApellido, SegundoApellido, PrimerNombre, SegundoNombre, NumeroDocumento, Usuario, IdEntidadGestora, "Documento1", IdTipoDocumento, IdDocumentoExpedido, ComplementoSEGIP, NumRa, FechaRa, out mensaje, out retorno_proc);
        //if (retorno_proc == 1) MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        //else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        
        gvCertificado.DataSource = null;
        gvCertificado.DataBind();
        this.TablaPersona.Visible = false;
        
    }

    protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
		int iIdConexion = (int)Session["IdConexion"];
		String sMensajeError="";
        string claseCC = this.ddlTipoCC.SelectedValue;
        int no_certif = Convert.ToInt32(this.txtNroCerti.Text);
        int retorno_proc = 0;
        clsNovedades busca = new clsNovedades();
        busca.Form02ValidaCerti1(iIdConexion, "Q", no_certif, claseCC, ref sMensajeError);
        if (sMensajeError.Length != 0)
        {
            gvCertificado.DataSource = null;
            gvCertificado.DataBind();
            this.TablaPersona.Visible = false;
            string Error = "Error al realizar la operación";
            string DetalleError = sMensajeError;
            Master.MensajeError(Error, DetalleError);
			return;
        }		
		
		/*
        busca.Form02ValidaCerti(no_certif, claseCC, out mensaje, out retorno_proc);
        if (retorno_proc == -1)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            gvCertificado.DataSource = null;
            gvCertificado.DataBind();
            this.TablaPersona.Visible = false;
            return;

        };
		*/
        Master.MensajeCancel();
        clsNovedades permiso = new clsNovedades();
		DataTable Cert = busca.Form02BuscaCerti1(iIdConexion,"Q",no_certif, claseCC,ref sMensajeError);

		if (Cert != null)
        {
			this.TablaPersona.Visible = true;
			gvCertificado.DataSource = Cert;
			gvCertificado.DataBind();			
            foreach (DataRow drDataRow in Cert.Rows)
            {
                this.TextPaterno_muestra.Text = Convert.ToString(drDataRow["Paterno"]);
				this.TextPaterno.Text = Convert.ToString(drDataRow["Paterno"]);
				this.TextMaterno.Text = Convert.ToString(drDataRow["Materno"]);
				this.TextMaterno_muestra.Text = Convert.ToString(drDataRow["Materno"]);
				this.TextCUA.Text = Convert.ToString(drDataRow["NUA"]);
				this.TextCUA_muestra.Text = Convert.ToString(drDataRow["NUA"]);
				this.TextCI.Text = Convert.ToString(drDataRow["CI"]); 
				this.TextCI_muestra.Text = Convert.ToString(drDataRow["CI"]); 
				this.LabelTitular.Text = "Datos Titular " + Convert.ToString(drDataRow["TipoPago"]);
				this.NUP.Text = Convert.ToString(drDataRow["NUP"]);
				this.TextTipoCC.Text = claseCC;
				this.TextPrimerNombre.Text = Convert.ToString(drDataRow["PrimerNombre"]);
				this.TextPrimerNombre_muestra.Text = Convert.ToString(drDataRow["PrimerNombre"]);
				this.TextSegundoNombre.Text = Convert.ToString(drDataRow["SegundoNombre"]);
				this.TextSegundoNombre_muestra.Text = Convert.ToString(drDataRow["SegundoNombre"]);
                this.Text_AFP.Text = Convert.ToString(drDataRow["AFP"]);
				
				this.ddlTipoDocumento.SelectedValue = Convert.ToString(drDataRow["IdTipoDocumento"]);
				this.ddlTipoDocumento_muestra.SelectedValue = Convert.ToString(drDataRow["IdTipoDocumento"]);
				this.ddlExtDocumento.SelectedValue = Convert.ToString(drDataRow["IdDocumentoExpedido"]);
				this.ddlExtDocumento_muestra.SelectedValue = Convert.ToString(drDataRow["IdDocumentoExpedido"]);

				this.TextAlfa.Text = Convert.ToString(drDataRow["ComplementoSEGIP"]);
				this.TextAlfa_muestra.Text = Convert.ToString(drDataRow["ComplementoSEGIP"]);
				this.CheckBoxPaterno.Checked = false;
				this.CheckMaterno.Checked = false;
				this.CheckPrimer.Checked = false;
				this.CheckSegundo.Checked = false;
				this.CheckCUA.Checked = false;
				this.CheckCI.Checked = false;
				this.CheckTipo.Checked = false;
				this.CheckExt.Checked = false;
				this.CheckAlfa.Checked = false;
				this.TextNumRa.Text = "";
				this.TextFechaRa.Text = "";
           
       
            }
        }				

        else
        {

            gvCertificado.DataSource = null;
            gvCertificado.DataBind();
            this.TablaPersona.Visible = false;
        }

    }

    protected void ValidaF02(out string mensaje, out int retorno_proc)
    {
        string valor1;
        string valor2;
        string chequeado;
        retorno_proc = 1;
        mensaje = "";
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
        valor1 = TextPrimerNombre_muestra.Text;
        valor2 = TextPrimerNombre.Text;
        chequeado = Convert.ToString(Convert.ToInt32(CheckPrimer.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de Primer Nombre";
            return;
        }
        // se valida segundo nombre
        valor1 = TextSegundoNombre_muestra.Text;
        valor2 = TextSegundoNombre.Text;
        chequeado = Convert.ToString(Convert.ToInt32(CheckSegundo.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de Segundo Nombre";
            return;
        }
        // se valida cua
        valor1 = TextCUA_muestra.Text;
        valor2 = TextCUA.Text;
        chequeado = Convert.ToString(Convert.ToInt32(CheckCUA.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de CUA";
            return;
        }
        // se valida ci
        valor1 = TextCI_muestra.Text;
        valor2 = TextCI.Text;
        chequeado = Convert.ToString(Convert.ToInt32(CheckCI.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de CI";
            return;
        }
        // se valida tipo de documento
        valor1 = this.ddlTipoDocumento_muestra.SelectedValue;
        valor2 = this.ddlTipoDocumento.SelectedValue;
        chequeado = Convert.ToString(Convert.ToInt32(CheckTipo.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de Tipo Documento";
            return;
        }
        // se valida origen de documento
        valor1 = this.ddlExtDocumento_muestra.SelectedValue;
        valor2 = this.ddlExtDocumento.SelectedValue;
        chequeado = Convert.ToString(Convert.ToInt32(CheckExt.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de Origen Documento";
            return;
        }
        // se valida ci
        valor1 = TextAlfa_muestra.Text;
        valor2 = TextAlfa.Text;
        chequeado = Convert.ToString(Convert.ToInt32(CheckAlfa.Checked));
        if (((valor1 != valor2) & chequeado != "1") ^ ((valor1 == valor2) & chequeado == "1"))
        {
            retorno_proc = -1;
            mensaje = "Modificación Erronea de Complemento";
            return;
        }
    }

}