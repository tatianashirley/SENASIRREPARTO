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
using wcfSeguridad.Logica;
using wcfNotificacion.Logica;
using wcfWorkFlowN.Logica;

public partial class Notificaciones_wfrmNotificaciones : System.Web.UI.Page
{
    clsNotificaciones documento = new clsNotificaciones();
    clsRegistroDocumento registro = new clsRegistroDocumento();
    clsSeguridad ObjSeguridad = new clsSeguridad();
    DataTable gvNot;
    string mensaje = null,msg = null;
    Int64 iIdTramite = 0;
    int iIdGrupoBeneficio = 0;
    int IdArea;
    int Verifica;
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

            if (Request.QueryString["iIdTramite"] != null)
            {
                iIdTramite = Convert.ToInt32(Request.QueryString["iIdTramite"]);
                iIdGrupoBeneficio = Convert.ToInt32(Request.QueryString["iIdGrupoBeneficio"]);
                Tram.Value = Convert.ToString(iIdTramite);
                gruBen.Value = Convert.ToString(iIdGrupoBeneficio);

            }

            HttpContext.Current.Server.ScriptTimeout = 2400;
            if (iIdTramite != 0) {
                Verifica = Convert.ToInt32(documento.ExisteDocumento((int)Session["IdConexion"],"V",Convert.ToInt32(Tram.Value), Convert.ToInt32(gruBen.Value),ref mensaje).Rows[0]["existedato"]);
                if (Verifica == 0)
                {
                    InsertarNotificacion(Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), null);
                }
                else 
                {
                    gvNotificar();
                }
            }
            gvNotificar();
        }
    }
    protected void gvNotificar() //Sin_Notificar F
    {

        gvDatos.Visible = true;
        lblCoincidencias.Visible = true;
        //gvNot = documento.ObtieneDatos((int)Session["IdConexion"], "Q", "Sin_Notificar",IdArea, ref mensaje);
        //gvDatos.DataSource = gvNot;
        //gvDatos.DataBind();
        if(Tram.Value!= "" && gruBen.Value!="")
            Verifica = Convert.ToInt32(documento.ExisteDocumento((int)Session["IdConexion"], "V", Convert.ToInt32(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje).Rows[0]["existedato"]);
        else
            Verifica = 0;
        //OBTIENE AREA
        if (Tram.Value != null && gruBen.Value != "" && Verifica == 0)
        {
            gvNot = documento.ObtieneDatos((int)Session["IdConexion"], "F", Tram.Value,gruBen.Value, ref mensaje);
            gvDatos.DataSource = gvNot;
            gvDatos.DataBind();
            if (gvNot.DataSet != null && gvNot.Rows.Count > 0) 
            {
                CargarDatosPersona();
            }
            else
                Master.MensajeError("Error al realizar la Operación", "No existen Documentos para realizar la Notificación");
        }
        else
        {
            gvNot = documento.ObtieneDatos((int)Session["IdConexion"], "F", Tram.Value,gruBen.Value, ref mensaje);
            gvDatos.DataSource = gvNot;
            gvDatos.DataBind();
            if (gvNot.DataSet != null && gvNot.Rows.Count > 0) {
                if (iIdTramite != null && iIdTramite != 0 && iIdGrupoBeneficio != null && iIdGrupoBeneficio != 0)
                    CargarDatosPersona();
            }
            else
                Master.MensajeError("Error al realizar la Operación", "No existen Documentos para realizar la Notificación");
        }
        
    }

    protected void InsertarNotificacion(Int64 IdTramite, Int32 IdGrBeneficio,string Obs) //Automatico L  
    {
        mensaje = null;
        if (registro.RegistraDocumento((int)Session["IdConexion"], "L", IdTramite, IdGrBeneficio,Obs, ref mensaje))
        {
            string msg = "La operación se realizó con éxito";
            Master.MensajeOk(msg);
            gvNotificar();
            

        }
        else
        {
            if (mensaje != null)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = mensaje;
                Master.MensajeError(Error, DetalleError);
            }
        }
    }

    protected void gvCabecera_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex);
            int iIdTipoTramite = Convert.ToInt32(gvDatos.DataKeys[rowIndex].Values["IdTipoTramite"]);
            int iIdEstadoTramite = Convert.ToInt32(gvDatos.DataKeys[rowIndex].Values["IdEstadoTramite"]);

            if(gvDatos.DataKeys[rowIndex].Values["FechaNotificacion"].ToString() == "")
            {
                e.Row.FindControl("imgNotificacion").Visible = true;
                e.Row.FindControl("imgRecurso").Visible = false;
                e.Row.FindControl("btnImprimir").Visible = false;
                gvDatos.Columns[10].HeaderText = "Notificar";
            }
            else
            {
                if(gvDatos.DataKeys[rowIndex].Values["FechaRecurso"].ToString() == "")
                {
                    e.Row.FindControl("imgNotificacion").Visible = false;
                    e.Row.FindControl("imgRecurso").Visible = true;
                    e.Row.FindControl("btnImprimir").Visible = false;
                    if(iIdTipoTramite == 357)
                        gvDatos.Columns[21].HeaderText = "Rev/Renuncia";
                    else
                        gvDatos.Columns[21].HeaderText = "Rec. Reclamación";
                }
                else
                {
                    e.Row.FindControl("imgNotificacion").Visible = false;
                    e.Row.FindControl("imgRecurso").Visible = false;
                    e.Row.FindControl("imgEditar").Visible = false;
                    e.Row.FindControl("btnImprimir").Visible = true;
                    if (iIdEstadoTramite == 31)
                        e.Row.FindControl("btnImprimir").Visible = false;
                }
            }
            if (iIdTipoTramite == 357)
                gvDatos.Columns[8].HeaderText = "Fec. Solicitud Revision/Renuncia";
            else 
                gvDatos.Columns[8].HeaderText = "Fec. Solicitud Rec. Reclamación";
        }
    }

    protected void gvDetalle_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "cmdNotificar")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            Tram.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
            gruBen.Value = gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
            FechaDoc.Value = gvDatos.DataKeys[Index].Values["FechaDocumento"].ToString();
            NroDoc.Value = gvDatos.DataKeys[Index].Values["NroDocumento"].ToString();
            IdDoc.Value = gvDatos.DataKeys[Index].Values["IdDocumento"].ToString();
            Direccion.Value = gvDatos.DataKeys[Index].Values["Direccion"].ToString();
            TipoTram.Value = gvDatos.DataKeys[Index].Values["IdTipoTramite"].ToString();
            try
            {
                lblNotificacion.Text = "Registrar Notificación";
                txtFechaRecurso.Text = "";
                txtFechaNotificacion.Text = "";
                txtONotificar.Text = "";
                txtORecurso.Text = "";
                lblNotificacion.Text = "Registrar Notificación";
                btnAccionarNotificar.Text = "Aceptar";
                txtFecCalculo.Text = documento.ObtieneFechaCalculo((int)Session["IdConexion"], "H", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), Convert.ToInt32(NroDoc.Value), FechaDoc.Value, ref mensaje).Rows[0]["FechaCalculo"].ToString();
                this.pnlNotificar.Show();
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
        if (e.CommandName == "cmdRecurso")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            Tram.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
            gruBen.Value = gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
            FechaDoc.Value = gvDatos.DataKeys[Index].Values["FechaDocumento"].ToString();
            NroDoc.Value = gvDatos.DataKeys[Index].Values["NroDocumento"].ToString();
            IdDoc.Value = gvDatos.DataKeys[Index].Values["IdDocumento"].ToString();
            Direccion.Value = gvDatos.DataKeys[Index].Values["Direccion"].ToString();
            TipoTram.Value = gvDatos.DataKeys[Index].Values["IdTipoTramite"].ToString();
            FecPlazo.Value = gvDatos.DataKeys[Index].Values["FechaVencePlazo"].ToString();
            if (Convert.ToInt32(TipoTram.Value) == 357) 
            {
                rbAutmatico.Visible = true;
                lblRecurso.Text = "Revisión/Renuncia";
            }
            else
            {
                rbAutmatico.Visible = false;
                lblRecurso.Text = "Recurso de Reclamación";
            }
            try
            {   
                txtFechaRecurso.Text = "";
                txtFechaNotificacion.Text = "";
                txtONotificar.Text = "";
                txtORecurso.Text = "";
                this.pnlRecurso_Pop.Show();
            }
            catch (Exception ex)
            {
                Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
            }
        }
        if (e.CommandName == "cmdEditar")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            Tram.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
            gruBen.Value = gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
            FechaDoc.Value = gvDatos.DataKeys[Index].Values["FechaDocumento"].ToString();
            NroDoc.Value = gvDatos.DataKeys[Index].Values["NroDocumento"].ToString();
            IdDoc.Value = gvDatos.DataKeys[Index].Values["IdDocumento"].ToString();
            Direccion.Value = gvDatos.DataKeys[Index].Values["Direccion"].ToString();
            TipoTram.Value = gvDatos.DataKeys[Index].Values["IdTipoTramite"].ToString();
            DataTable datos = documento.CargaDatosNotificacion((int)Session["IdConexion"], "T", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), ref mensaje);
            if(datos.Rows.Count>0){
                txtFechaNotificacion.Text = datos.Rows[0]["FecNot"].ToString();
                txtONotificar.Text = datos.Rows[0]["Obs"].ToString();
                txtORecurso.Text = "";
                lblNotificacion.Text = "Modificar  ";
                btnAccionarNotificar.Text = "Modificar";
                txtFecCalculo.Text = documento.ObtieneFechaCalculo((int)Session["IdConexion"], "H", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), Convert.ToInt32(NroDoc.Value), FechaDoc.Value, ref mensaje).Rows[0]["FechaCalculo"].ToString();
                this.pnlNotificar.Show();
            }
            else
            {
                Master.MensajeError("Error al intentar ver la información de la Notificación",mensaje);
            }
        }
        if (e.CommandName == "cmdImprimir")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            Tram.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
            gruBen.Value = gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
            FechaDoc.Value = gvDatos.DataKeys[Index].Values["FechaDocumento"].ToString();
            NroDoc.Value = gvDatos.DataKeys[Index].Values["NroDocumento"].ToString();
            IdDoc.Value = gvDatos.DataKeys[Index].Values["IdDocumento"].ToString();
            Direccion.Value = gvDatos.DataKeys[Index].Values["Direccion"].ToString();
            TipoTram.Value = gvDatos.DataKeys[Index].Values["IdTipoTramite"].ToString();
            string contentUrl = "wfrmCodigos.aspx";
            Master.MensajeOk(msg);
            //Response.Redirect(contentUrl + "?IdTramite=" + Tram.Value + "&IdGrupo=" + gruBen.Value + "&Fecha=" + FechaDoc.Value + "&NoDoc=" + NroDoc.Value + "&IdDoc=" + IdDoc.Value);

            ScriptManager.RegisterStartupScript(this, GetType(), "openReporteListado", " window.open('../Notificaciones/wfrmCodigos.aspx" + "?IdTramite=" + Tram.Value + "&IdGrupo=" + gruBen.Value + "&Fecha=" + FechaDoc.Value + "&NoDoc=" + NroDoc.Value + "&IdDoc=" + IdDoc.Value + "','newWindow', 'height=0, width=0, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);
        }
    }

     private void CargarDatosPersona() 
     {
         txtCIC.Text = gvDatos.DataKeys[0].Values["NumeroDocumento"].ToString();
         txtFechaNacC.Text = gvDatos.DataKeys[0].Values["FechaNacimiento"].ToString();
         txtPaternoC.Text = gvDatos.DataKeys[0].Values["PrimerApellido"].ToString();
         txtMaternoC.Text = gvDatos.DataKeys[0].Values["SegundoApellido"].ToString();
         txtNombreC.Text = gvDatos.DataKeys[0].Values["PrimerNombre"].ToString();
         txtTramiteC.Text = gvDatos.DataKeys[0].Values["IdTramite"].ToString();
         txtMatriculaC.Text = gvDatos.DataKeys[0].Values["Matricula"].ToString();
         txtDptoActual.Text = gvDatos.DataKeys[0].Values["Departamento"].ToString();
         txtRegional.Text = gvDatos.DataKeys[0].Values["Regional"].ToString();
     }

   
     protected void btnAccionarRecurso_Click(object sender, EventArgs e) //Recurso M
     {
         string impresion, codigo,sFechaRecurso,sFechaPlazo,sTipo;
         DateTime dtFechaPlazo = Convert.ToDateTime(FecPlazo.Value); //Fecha de Plazo
         DateTime dtFechaRecurso = Convert.ToDateTime(txtFechaRecurso.Text); //Fecha de Recurso
         sFechaPlazo = dtFechaPlazo.ToShortDateString();
         sFechaRecurso = dtFechaRecurso.ToShortDateString();
         if (dtFechaRecurso <= dtFechaPlazo)
         {
             if (Convert.ToInt32(TipoTram.Value) == 357)
             {
                 if (Convert.ToInt32(rbAutmatico.SelectedValue) == 1) //Revision del Formulario Automatico
                 {
                     if (documento.ActualizaDocumento((int)Session["IdConexion"], "N", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaRecurso.Text, txtORecurso.Text, Convert.ToInt32(TipoTram.Value), 3, ref mensaje))
                         Master.MensajeOk("Se realizó con éxito la Operación");
                     else
                         Master.MensajeError("Error al realizar la operación", mensaje);
                 }
                 else
                 {
                     if (documento.ActualizaDocumento((int)Session["IdConexion"], "N", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaRecurso.Text, txtORecurso.Text, Convert.ToInt32(TipoTram.Value), 1, ref mensaje))
                     {
                         DataTable codigos = documento.DatosImpresion((int)Session["IdConexion"], "Z", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(TipoTram.Value), ref mensaje);
                         codigo = codigos.Rows[0]["Codigo"].ToString();
                         impresion = codigos.Rows[0]["CodigoImpresion"].ToString();
                         if (documento.RegistraRecursoRenuncia((int)Session["IdConexion"], "Y", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), ObjSeguridad.Encriptar(codigo), impresion, Convert.ToInt32(TipoTram.Value), ref mensaje))
                             Master.MensajeOk("Operación realizada con éxito");
                         else
                             Master.MensajeError("Error al realizar la Operación", mensaje);
                     }
                     else
                     {
                         Master.MensajeError("Error al realizar la Operación", mensaje);
                     }
                 }
             }
             else
             {
                 if (documento.ActualizaDocumento((int)Session["IdConexion"], "N", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaRecurso.Text, txtORecurso.Text, Convert.ToInt32(TipoTram.Value), 2, ref mensaje))
                 {
                     DataTable codigos = documento.DatosImpresion((int)Session["IdConexion"], "Z", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(TipoTram.Value), ref mensaje);
                     codigo = codigos.Rows[0]["Codigo"].ToString();
                     impresion = codigos.Rows[0]["CodigoImpresion"].ToString();
                     if (documento.RegistraRecursoRenuncia((int)Session["IdConexion"], "Y", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), ObjSeguridad.Encriptar(codigo), impresion, Convert.ToInt32(TipoTram.Value), ref mensaje))
                         Master.MensajeOk("Operación realizada con éxito");
                     else
                         Master.MensajeError("Error al realizar la Operación", mensaje);
                 }
                 else
                 {
                     Master.MensajeError("Error al realizar la Operación", mensaje);
                 }
             }
         }
         else 
         {
             if (Convert.ToInt32(TipoTram.Value) == 357)
                 sTipo = "Rev/Ren";
             else
                 sTipo = "Rec. Reclamación";
             this.pnlRecurso_Pop.Show();
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fecha de Presentación de " + sTipo + " fuera del plazo: " + sFechaPlazo + "')", true);
             
         }
         txtFechaRecurso.Text = "";
         txtORecurso.Text = "";
         gvNotificar();
     }

     protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gvDatos.PageIndex = e.NewPageIndex;
         gvNotificar();
     }

     protected void btnAccionarNotificar_Click(object sender, EventArgs e)
     {
         if (btnAccionarNotificar.Text == "Aceptar")
         {
             if (documento.ActualizaDocumento((int)Session["IdConexion"], "M", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaNotificacion.Text, txtONotificar.Text, 31372, 0,ref mensaje))
             {
                 Master.MensajeOk("Se realizo satisfactoriamente la operación");
             }
             else
             {
                 Master.MensajeError("Error al realizar la Operación", mensaje);
             }
             txtFechaNotificacion.Text = "";
             txtONotificar.Text = "";
             gvNotificar();
         }
         if (btnAccionarNotificar.Text == "Modificar")
         {
             if (documento.ActualizaDocumento((int)Session["IdConexion"], "U", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaNotificacion.Text, txtONotificar.Text, 31372,0, ref mensaje))
             {
                 Master.MensajeOk("Se realizó satisfactoriamente la operación");
             }
             else
             {
                 Master.MensajeError("Error al realizar la Operación", mensaje);
             }
             txtFechaNotificacion.Text = "";
             txtONotificar.Text = "";
             txtFecCalculo.Text = documento.ObtieneFechaCalculo((int)Session["IdConexion"], "H", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), Convert.ToInt32(NroDoc.Value), FechaDoc.Value, ref mensaje).ToString();
             gvNotificar();
         }
         DataTable Verifica = documento.ExisteDocumentoSinsNotificar((int)Session["IdConexion"], "G", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value),ref mensaje);
         if (Convert.ToInt32(Verifica.Rows[0]["Existe"]) != 0)
         {
             Master.MensajeOk("Se guardó la Notificación, debe notificar el otro formulario");
         }   
     }
}