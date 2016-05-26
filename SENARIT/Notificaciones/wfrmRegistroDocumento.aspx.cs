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
using wcfNotificacion.Logica;
using wcfSeguridad.Logica;
public partial class Notificaciones_wfrmRegistroDocumento : System.Web.UI.Page
{
    clsRegistroDocumento Info = new clsRegistroDocumento();
    clsEnvio Envio = new clsEnvio();
    clsRecepcion Documento = new clsRecepcion();
    clsDevolucion Devolucion = new clsDevolucion();
    DataTable Encontrados;
    string mensaje = null;
    int pp;
    string iIdTramite;
    clsSeguridad ObjSeguridad = new clsSeguridad();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            //string LoginPage = System.Configuration.ConfigurationManager.AppSettings("LoginPageURL");
            Response.Write("<script>window.open('../LoginLDAP.aspx','_top');</script>");
            return;
        }
        ObjSeguridad.ListaDatosConexion((int)Session["IdConexion"]);
        if (!Page.IsPostBack)
        {
            HttpContext.Current.Server.ScriptTimeout = 2400;
            if (Request.QueryString["iIdTramite"] != null)
            {
                iIdTramite = Request.QueryString["iIdTramite"];
                Tram.Value = Convert.ToString(iIdTramite);

            }
            if (!String.IsNullOrEmpty(iIdTramite))
            {
                DatosParametro(iIdTramite);
                lnkbtnMas.Visible = false;
                txtCIC.Text = txtFechaNacC.Text = txtPaternoC.Text = txtMaternoC.Text = txtNombreC.Text = txtTramiteC.Text = txtMatriculaC.Text = txtRegional.Text = "";
                HabilitarPaneles(0);
            }
            else 
            { 
                pp = 0;
                ListaOficinas();
                ComboFuncionario();
                HabilitarPaneles(pp);
            }
        }
    }  
    //PARTE INICIO DE ENVIOS NOTIFICACION
    protected void UltimoEnvio(object sender, EventArgs e)
    {
        if (lnkMas.Text == "VER ULTIMO ENVIO")
        {
            try
            {
                gvEnvio.Visible = false;
                lblRegional.Visible = false;
                btnEnviar.Visible = false;
                gvUltEnvio.Visible = true;
                gvUltEnvio.DataSource = Envio.DocsUltimoEnvio((int)Session["IdConexion"], "M", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
                gvUltEnvio.DataBind();
                lnkMas.Text = "VOLVER ATRAS";
            }
            catch
            {
                Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
            }
        }
        else
        {
            gvUltEnvio.Visible = false;
            lblRegional.Visible = true;
            grillaEnvio();
            lnkMas.Text = "VER ULTIMO ENVIO";
        }
    }

     protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Int64 tram;
        Int32 idGBene;
        string fechDoc;
        Int32 nroDoc;
        Int32 idDoc;
        foreach (GridViewRow row in gvEnvio.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk_Publicar = (CheckBox)row.Cells[5].FindControl("chkEnvio");
                if (chk_Publicar.Checked)
                {
                    tram = Convert.ToInt64(Tram.Value);
                    idGBene = Convert.ToInt32(gruBen.Value);
                    fechDoc = gvEnvio.DataKeys[row.RowIndex].Values["FechaDocumento"].ToString();
                    nroDoc = Convert.ToInt32(gvEnvio.DataKeys[row.RowIndex].Values["NroDocumento"].ToString());
                    idDoc = Convert.ToInt32(gvEnvio.DataKeys[row.RowIndex].Values["IdDocumento"].ToString());

                    //Envio K
                    if (Envio.RegistroEnvio((int)Session["IdConexion"], "K", tram, idGBene, fechDoc, nroDoc, idDoc, txtCite.Text, txtFechaCITE.Text, txtFechaEnvio.Text, Convert.ToInt32(ddlFuncionario.SelectedValue), Convert.ToInt32(ddlOficina.SelectedValue.ToString()), txtObsEnv.Text, ref mensaje))
                    {
                        Master.MensajeOk("Se realizo con exito la Operacion");
                    }
                    else
                    {
                        Master.MensajeError("Error al realizar la Operacion", mensaje);
                        break;
                    }
                }   
            }
        }
        txtCite.Text = "";
        txtFechaCITE.Text = "";
        txtFechaEnvio.Text = "";
        ComboFuncionario();
        txtObsEnvio.Text = "";
        ListaOficinas();
        grillaEnvio();
        grillaRecepcion();
    }

     public void grillaEnvio() //Envio E
     {
         try
         {
             gvEnvio.Visible = true;
             gvEnvio.DataSource = Envio.DatosNotificacionEnvio((int)Session["IdConexion"], "E", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
             gvEnvio.DataBind();
             int filas = gvEnvio.Rows.Count;
             if (filas > 0)
             {

                 btnEnviar.Visible = true;
             }
             else
             {
                 btnEnviar.Visible = false;
             }
         }
         catch
         {
             Master.MensajeError("Error al realizar la Operacion!!!",mensaje);
         }
     }

     protected void btnEnviar_Click1(object sender, EventArgs e)
     {
         ListaOficinas();
         pnlTipoCambio_ModalPopupExtender.Show();
         PreDocumento();
     }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        DatosBeneficiario(); //Beneficiario Q
    }
    protected void gvDatos_PageIndexChanging2(object sender, GridViewPageEventArgs e)
    {
        gvNotificaciones.PageIndex = e.NewPageIndex;
        PreDocumento(); //Beneficiario Q
    }
    public void ListaOficinas() //Oficina B
    {
        try
        {
            ddlOficina.DataSource = null;
            ddlOficina.DataSource = Envio.ListaOficinas((int)Session["IdConexion"], "B", 1,ref mensaje);
            ddlOficina.DataValueField = "IdOficina";
            ddlOficina.DataTextField = "Nombre";
            ddlOficina.DataBind();
            ddlOficina.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlOficina.SelectedValue = "0";

            ddlOficina.SelectedValue = IdOfNot.Value;
        }
        catch
        {
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
        }
    }
    protected void gvEnvio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEnvio.PageIndex = e.NewPageIndex;
        grillaEnvio();
    }
    protected void ComboFuncionario()
    {
        ddlFuncionario.Items.Insert(0, new ListItem("Funcionario...", "0"));
        ddlFuncionario.SelectedValue = "0";
    }
    protected void btnCancelarEnvio_Click(object sender, EventArgs e)
    {
        txtCite.Text = "";
        txtFechaCITE.Text = "";
        txtFechaEnvio.Text = "";
        ddlFuncionario.SelectedValue = Convert.ToString(0);
    }
    //FINAL DE LA PARTE DE ENVIOS

    protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Master.MensajeCancel();
        DatosBeneficiario();//Beneficiario Q
        lnkbtnMas.Visible = false;
        txtCIC.Text = txtFechaNacC.Text = txtPaternoC.Text = txtMaternoC.Text = txtNombreC.Text = txtTramiteC.Text = txtMatriculaC.Text =  txtRegional.Text = "";
        HabilitarPaneles(0);
    }

    public void DatosBeneficiario() //Beneficiario Q
    {
            gvDatos.Visible = true;
            //gvDatos.DataSource = null;
            int iIdConexion = (int)Session["IdConexion"];
            //Encontrados = Info.ObtieneDatos(iIdConexion, "Q", "Beneficiario", txtMatricula.Text, txtTramite.Text, txtNroDocumento.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, ref mensaje);
            gvDatos.DataSource = Info.ObtieneDatos(iIdConexion, "Q", txtMatricula.Text, txtTramite.Text, txtNroDocumento.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, ref mensaje);
            gvDatos.DataBind();
            if(gvDatos.Rows.Count > 0)
            {
                lblHistorico.Visible = false;
                gvNotificaciones.Visible = false;
            }
            else
                Master.MensajeError("Error al realizar la Operacion!!!", "El trámite no se encuentra en el área");
    }
    public void DatosParametro(string iIdTramite) //Beneficiario Q
    {
        gvDatos.Visible = true;
        //gvDatos.DataSource = null;
        int iIdConexion = (int)Session["IdConexion"];
        //Encontrados = Info.ObtieneDatos(iIdConexion, "Q", "Beneficiario", txtMatricula.Text, txtTramite.Text, txtNroDocumento.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, ref mensaje);
        gvDatos.DataSource = Info.ObtieneDatos(iIdConexion, "Q", txtMatricula.Text, iIdTramite, txtNroDocumento.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, ref mensaje);
        gvDatos.DataBind();
        if (gvDatos.Rows.Count > 0)
        {
            lblHistorico.Visible = false;
            gvNotificaciones.Visible = false;
        }
        else
            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
    }


     public void PreDocumento() //Historico C
     {
         try
         {
             lblHistorico.Visible = true;
             gvNotificaciones.Visible = true;
             gvNotificaciones.DataSource = Info.ObtieneDatos((int)Session["IdConexion"], "C", Convert.ToInt64(gvDatos.SelectedDataKey["IdTramite"]), Convert.ToInt32(gvDatos.SelectedDataKey["IdGrupoBeneficio"]), ref mensaje);
             gvNotificaciones.DataBind();
         }
         catch 
         { 
             Master.MensajeError("Error al realizar la Operacion!!!", mensaje); 
         }
     }
     protected void lnkbtnMas_Click(object sender, EventArgs e)//Beneficiario Q
     {
         try
         {
             pp = 0;
             gvDatos.Visible = true;
             gvDatos.DataSource = null;
             int iIdConexion = (int)Session["IdConexion"];
             Encontrados = Info.ObtieneDatos(iIdConexion, "Q", txtMatricula.Text, txtTramite.Text, txtNroDocumento.Text, txtPaterno.Text, txtMaterno.Text, txtNombres.Text, ref mensaje);
             gvDatos.DataSource = Encontrados;
             gvDatos.DataBind();
             lnkbtnMas.Visible = false;
             imgbtnAdd.Enabled = false;
             gvNotificaciones.Visible = false;
             lblHistorico.Visible = false;
             imgbtnAdd.Visible = false;
             txtCIC.Text = txtFechaNacC.Text = txtPaternoC.Text = txtMaternoC.Text = txtNombreC.Text = txtTramiteC.Text = txtMatriculaC.Text  = txtRegional.Text = "";
             HabilitarPaneles(pp);
         }
         catch
         {
             Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
         }
     }

     protected void btnAccionarRegistro_Click(object sender, EventArgs e) //Registro I Introduce un nuevo registro en la tabla Notificacion.Notificacion
     {
         mensaje = null;
         pp = 1;

             if (ddlOrigen.SelectedValue != "0" && ddlTipoDocumento.SelectedValue != "0") 
             {
                 if (txtFechaDocumento.Text != "" && txtNroDocumento.Text != "")
                 {
                    if (Info.RegistraDocumento((int)Session["IdConexion"], "I", Convert.ToInt64(gvDatos.SelectedDataKey["IdTramite"].ToString()), Convert.ToInt32(gvDatos.SelectedDataKey["IdGrupoBeneficio"].ToString()),
                    txtFechaDocumento.Text, Convert.ToInt32(txtNroDocumento.Text), Convert.ToInt32(ddlTipoDocumento.SelectedValue), ref mensaje))
                    {
                        txtFechaDocumento.Text = "";
                        txtNroDocumento.Text = "";
                        CargarCombos();
                        PreDocumento();
                        grillaEnvio();
                        grillaRecepcion();
                        grillaDevolucion();
                        HabilitarPaneles(pp);
                        Master.MensajeOk("Se hizo el registro satisfactoriamente!!!");
                    }
                    else
                    {
                        Master.MensajeError("Error al realizar la Operacion", mensaje);
                        txtFechaDocumento.Text = "";
                        txtNroDocumento.Text = "";
                        CargarCombos();
                        grillaEnvio();
                        PreDocumento();
                    }
                 }
                 else 
                 {
                     Master.MensajeError("Error al Realizar la Operacion", "Ingrese la Fecha y/o el Nro del Documento");   
                 }
             }
             else
             {
                 Master.MensajeError("Error al Realizar la Operacion","Seleccione Origen y Documento");
             }
             
     }
     private void CargarCombos() //Documentos A
     {
         //mensaje = null;
             ddlTipoDocumento.DataSource = Info.ObtieneDatos((int)Session["IdConexion"], "A", "", "", "", "", "", "", ref mensaje);
             ddlTipoDocumento.DataValueField = "IdDocumento";
             ddlTipoDocumento.DataTextField = "DescripcionDocumento";
             ddlTipoDocumento.DataBind();
             if (ddlTipoDocumento != null && ddlTipoDocumento.Items.Count > 0)
             {
                 ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione...", "0"));
                 ddlTipoDocumento.SelectedValue = "0";
             }
             else
                 Master.MensajeError("Error al realizar la Operacion", mensaje);
     }
     protected void gvNotificar_OnRowcommand(object sender, GridViewCommandEventArgs e)
     {
         int Index = Convert.ToInt32(e.CommandArgument);
         if (e.CommandName == "cmdNotificar")
         {
             Tram.Value = gvNotificaciones.DataKeys[Index].Values["IdTramite"].ToString();
             gruBen.Value = gvNotificaciones.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
             FechaDoc.Value = gvNotificaciones.DataKeys[Index].Values["FechaDocumento"].ToString();
             NroDoc.Value = gvNotificaciones.DataKeys[Index].Values["NroDocumento"].ToString();
             IdDoc.Value = gvNotificaciones.DataKeys[Index].Values["IdDocumento"].ToString();
             try
             {
                 txtFechaRecurso.Text = "";
                 txtFechaNotificacion.Text = "";
                 txtObservacion.Text = "";
                 txtORecurso.Text = "";
                 btnAccionarNotificar.Text = "Aceptar";
                 this.pnlNotificar.Show();
             }
             catch (Exception ex)
             {
                 Master.MensajeError("Error al intentar ver la información del beneficio", ex.Message);
             }
         }
         if (e.CommandName == "cmdRecurso")
         {
             Tram.Value = gvNotificaciones.DataKeys[Index].Values["IdTramite"].ToString();
             gruBen.Value = gvNotificaciones.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
             FechaDoc.Value = gvNotificaciones.DataKeys[Index].Values["FechaDocumento"].ToString();
             NroDoc.Value = gvNotificaciones.DataKeys[Index].Values["NroDocumento"].ToString();
             IdDoc.Value = gvNotificaciones.DataKeys[Index].Values["IdDocumento"].ToString();
             try
             {
                 txtFechaRecurso.Text = "";
                 txtFechaNotificacion.Text = "";
                 txtObservacion.Text = "";
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
                Tram.Value = gvNotificaciones.DataKeys[Index].Values["IdTramite"].ToString();
                gruBen.Value = gvNotificaciones.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
                FechaDoc.Value = gvNotificaciones.DataKeys[Index].Values["FechaDocumento"].ToString();
                NroDoc.Value = gvNotificaciones.DataKeys[Index].Values["NroDocumento"].ToString();
                IdDoc.Value = gvNotificaciones.DataKeys[Index].Values["IdDocumento"].ToString();
                clsNotificaciones documento = new clsNotificaciones();
                DataTable datos = documento.CargaDatosNotificacion((int)Session["IdConexion"], "T", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), ref mensaje);
                try
                {
                    txtFechaNotificacion.Text = datos.Rows[0]["FecNot"].ToString();
                    txtObservacion.Text = datos.Rows[0]["Obs"].ToString();
                    txtORecurso.Text = "";
                    lblNotificacion.Text = "Modificar Notificacion";
                    btnAccionarNotificar.Text = "Modificar";
                    this.pnlNotificar.Show();
                }
                catch (Exception ex)
                {
                    Master.MensajeError("Error al intentar ver la información de la Notificación", ex.Message);
                }
            }
     }

     protected void btnAccionarNotificar_Click(object sender, EventArgs e) //Notificacion U
     {   int tipoNotificacion;
         if (chkhabilita.Checked == true)
         {
             tipoNotificacion = Convert.ToInt32(ddlDomicilio.SelectedValue);
         }
         else 
         {
             tipoNotificacion = 31372;  
         }
         if (Info.ActualizaDocumento((int)Session["IdConexion"], "U", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaNotificacion.Text, txtObservacion.Text, tipoNotificacion, ref mensaje))
         {
             txtFechaNotificacion.Text = "";
             txtObservacion.Text = "";
             PreDocumento();
             Master.MensajeOk("Se realizo con exito la Operacion");
         }
         else
         {
             Master.MensajeError("Error al realizar la operación!!!", mensaje);
             txtFechaNotificacion.Text = "";
             txtObservacion.Text = "";
             PreDocumento();
         }
     }

     protected void btnAccionarRecurso_Click(object sender, EventArgs e) //Recurso M
     {
         if (Info.ActualizaDocumento((int)Session["IdConexion"], "N", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), Convert.ToInt32(IdDoc.Value), txtFechaRecurso.Text, txtORecurso.Text, 0, ref mensaje))
         {
             txtFechaRecurso.Text = "";
             txtORecurso.Text = "";
             PreDocumento();
             Master.MensajeOk("Se realizo con exito la Operacion");
         }
         else {
             txtFechaRecurso.Text = "";
             txtORecurso.Text = "";
             PreDocumento();
             Master.MensajeError("Error al realizar la operación!!!", mensaje);
         }
     }

     protected void btnCancelarRegistro_Click(object sender, EventArgs e)
     {
         CargarCombos();
         txtFechaDocumento.Text = "";
         txtNroDocumento.Text = "";
         
     }

     protected void gvCabecera_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             if (e.Row.Cells[4].Text.ToString() == "&nbsp;")
             {
                     e.Row.FindControl("imgElaborada").Visible = true;
                     e.Row.FindControl("imgPendiente").Visible = false;
                     e.Row.FindControl("imgEliminar").Visible = false;
                     e.Row.FindControl("imgEditar").Visible = false;
             }
             else
             {
                 if (e.Row.Cells[5].Text.ToString() == "&nbsp;")
                 {
                     if (Convert.ToInt32(gvNotificaciones.DataKeys[e.Row.RowIndex]["IdDocumento"]) >= 17 && Convert.ToInt32(gvNotificaciones.DataKeys[e.Row.RowIndex]["IdDocumento"]) <= 29)
                     {
                         e.Row.FindControl("imgElaborada").Visible = false;
                         e.Row.FindControl("imgPendiente").Visible = false;
                         e.Row.FindControl("imgEliminar").Visible = false;
                         e.Row.FindControl("imgEditar").Visible = true  ;
                     }
                     else
                     {
                         e.Row.FindControl("imgElaborada").Visible = false;
                         e.Row.FindControl("imgPendiente").Visible = true;
                         e.Row.FindControl("imgEliminar").Visible = false;
                         e.Row.FindControl("imgEditar").Visible = true;
                     }
                }
                 else
                 {
                     e.Row.FindControl("imgElaborada").Visible = false;
                     e.Row.FindControl("imgPendiente").Visible = false;
                     e.Row.FindControl("imgEliminar").Visible = false;
                     e.Row.FindControl("imgEditar").Visible = true;
                 }
                 
             }
         }


     }

     protected void chkhabilita_CheckedChanged(object sender, EventArgs e)
     {
         this.pnlNotificar.Show();
         if (chkhabilita.Checked == true)
         {
             ddlDomicilio.Visible = true;
             lblDomicilio.Visible = true;
             txtDireccion.Text = Direccion.Value;
             txtDireccion.Visible = true;
             txtDireccion.Enabled = false;
         }
         else
         { 
             ddlDomicilio.Visible = false;
             lblDomicilio.Visible = false;
             txtDireccion.Text = "";
             txtDireccion.Visible = false;
         }
     }

     protected void imgbtnBorrar_Click(object sender, ImageClickEventArgs e)
     {
         Response.Redirect("~/Notificaciones/wfrmRegistroDocumento.aspx");
     }

     protected void btnAccionarCambios_Click(object sender, EventArgs e) // Cambia_Datos P
     {
         if (Info.ModificaDocumento((int)Session["IdConexion"], "P", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), Convert.ToInt32(IdDoc.Value), FechaDoc.Value, Convert.ToInt32(NroDoc.Value), txtFnot.Text, txtFrec.Text, ref mensaje))
         {
             txtFnot.Text = "";
             txtFrec.Text = "";
             PreDocumento();
             Master.MensajeOk("Se realizo con exito la Operacion");
         }
         else
         {
             txtFnot.Text = "";
             txtFrec.Text = "";
             PreDocumento();
             Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
         }
     }

    private void HabilitarPaneles(int iTipo)
    {
        switch (iTipo)
        {
            case 0:                
                this.pnlDocumentos.Visible = true;
                this.TabPanel1.Visible = false;
                this.TabPanel2.Visible = false;
                this.TabPanel3.Visible = false;
                this.TabPanel4.Visible = false;
                this.TabPanel5.Visible = false;
                this.TabContainer1.ActiveTabIndex = 0;
                break;
            case 1:
                this.pnlDocumentos.Visible = true;                              
                this.TabPanel1.Visible = false;
                this.TabPanel2.Visible = true; 
                this.TabPanel3.Visible = true;
                this.TabPanel4.Visible = true;
                this.TabPanel5.Visible = false;
                this.TabContainer1.ActiveTabIndex = 0;
                break;
            case 2:

                this.pnlDocumentos.Visible = true;
                this.TabPanel1.Visible = true;
                this.TabPanel2.Visible = false;
                this.TabPanel3.Visible = false;
                this.TabPanel4.Visible = false;
                this.TabPanel5.Visible = true;
                this.TabContainer1.ActiveTabIndex = 1;
                break;

         }

     }
     protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
     {
         //Tram.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
         //gruBen.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
         pp = 2;
         HabilitarPaneles(pp); 
         grillaEnvio();
         grillaRecepcion();
     }
     protected void btnCancelar_Click(object sender, EventArgs e)
     {
         txtDocNro.Text = txtNotaResp.Text = txtNotResp.Text = txtObsNota.Text = "";
         ddlOrigen.SelectedValue = ddlTipoDocumento.SelectedValue = "0";
         txtDias.Text = txtPlazo.Text = lblDocumentoRecurso.Text = txtFechaDocumento.Text = txtNroDocumento.Text = "";
         pp = 1;
         HabilitarPaneles(pp);
     }
     protected void ddlOrigen_TextChanged(object sender, EventArgs e)
     {   
         ddlTipoDocumento.Items.Clear();
         if (ddlOrigen.SelectedValue != "0")
         {
             try
             {
                 ddlTipoDocumento.DataSource = Info.ddlDocumentos((int)Session["IdConexion"], "C", Convert.ToInt32(ddlOrigen.SelectedValue), ref mensaje);
                 ddlTipoDocumento.DataValueField = "IdDocumento";
                 ddlTipoDocumento.DataTextField = "DescripcionDocumento";
                 ddlTipoDocumento.DataBind();
                 ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione...", "0"));
                 ddlTipoDocumento.SelectedValue = "0";
                 txtDias.Text = txtPlazo.Text = lblDocumentoRecurso.Text = "";
             }
             catch
             {
                 Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
             }
         }
     }

     protected void ddlTipoDocumento_TextChanged(object sender, EventArgs e)
     {
         if (ddlTipoDocumento.SelectedValue != "0")
         {
             try
             {
                 Encontrados = Info.DatosDocumento((int)Session["IdConexion"], "D", Convert.ToInt32(ddlTipoDocumento.SelectedValue), ref mensaje);
                 txtDias.Text = Encontrados.Rows[0]["Plazo"].ToString();
                 txtPlazo.Text = Encontrados.Rows[0]["TipoPlazo"].ToString();
                 lblDocumentoRecurso.Text = Encontrados.Rows[0]["DescDoc"].ToString();
             }
             catch
             {
                 Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
             }
         }
         else 
         {
             txtDias.Text = txtPlazo.Text = "";
         }
     }
     protected void btnRegNota_Click(object sender, EventArgs e)
     {
         mensaje = null;
         pp = 0;
        if(Info.RegistraNotas((int)Session["IdConexion"], "I", long.Parse(gvDatos.SelectedDataKey["IdTramite"].ToString()), int.Parse(gvDatos.SelectedDataKey["IdGrupoBeneficio"].ToString()),
             txtNotaResp.Text, Convert.ToInt32(txtDocNro.Text), 30,txtNotResp.Text,txtObsNota.Text, ref mensaje))
        {
             txtDocNro.Text = txtNotaResp.Text = txtNotResp.Text = txtObsNota.Text = "";
             CargarCombos();
             PreDocumento();
             HabilitarPaneles(pp);
             Master.MensajeOk("Se ralizó correctamente el Registro");
        }
        else
        {
             Master.MensajeError("Error al realizar la Operación", "Ocurrión un problema al realizar el registro");
             txtDocNro.Text = txtNotaResp.Text = txtNotResp.Text = txtObsNota.Text = "";
             CargarCombos();
             PreDocumento();
        }
     }
    //INICIO PARTE DE RECEPCCION
     protected void grillaRecepcion() //Recepcionar E
     {
         try
         {
             GridView1.Visible = true;
             GridView1.DataSource = Documento.DocumentosRecepcionNotificacion((int)Session["IdConexion"], "F", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
             GridView1.DataBind();
             int fila = GridView1.Rows.Count;
             if (fila > 0)
             {
                 imgbtnRecepcionar.Visible = true;
             }
             else
             {
                 imgbtnRecepcionar.Visible = false;
             }
         }
         catch
         {
             Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
         }
     }
     protected void btnAccionarRecepcion_Click(object sender, EventArgs e)
     {
         Int64 tram;
         Int32 idGBene;
         string fechDoc;
         Int32 nroDoc;
         Int32 idDoc;
         foreach (GridViewRow row in GridView1.Rows)
         {
             if (row.RowType == DataControlRowType.DataRow)
             {
                 
                 //CheckBox chkRol = (row.Cells[9].FindControl("chkRol") as CheckBox);
                 //CheckBox check = (CheckBox)row.Cells["prueba"].FindControl("chkRol");
                 CheckBox chk_Publicar = (CheckBox)row.Cells[7].FindControl("chkRecepcion");
                 if (chk_Publicar.Checked)
                 {
                     // en lugar de val guardar registro
                     //int IdRol = Convert.ToInt32(row.Cells[1].Text);
                     tram = Convert.ToInt64(Tram.Value);
                     idGBene = Convert.ToInt32(gruBen.Value);
                     fechDoc = GridView1.DataKeys[row.RowIndex].Values["FechaDocumento"].ToString();
                     nroDoc = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["NroDocumento"].ToString());
                     idDoc = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["IdDocumento"].ToString());
                     //Recepcion N
                     if(Documento.RegistraRecepcion((int)Session["IdConexion"], "O", tram, idGBene, fechDoc, nroDoc, idDoc, txtFechaRecepcion.Text, ref mensaje))
                     {
                         Master.MensajeOk("Se realizo con exito la Operacion");
                     }
                     else
                     {
                         Master.MensajeError("Error al realizar la Operacion!!!",mensaje);
                     }
                 }
             }
         }
         txtFechaRecepcion.Text = "";
         grillaRecepcion();
         grillaDevolucion();
     }
     protected void imgbtnRecepcionar_Click(object sender, ImageClickEventArgs e)
     {
         pnlREcepcion_ModalPopupExtender.Show();
     }
    //FIN DE RECEPCION

    //INICIO DE DEVOLUCION DE DOCUMENTOS NOTIFICACION

     protected void grillaDevolucion() 
     {  
         try
         {
             gvDevoluciones.Visible = true;
             gvDevoluciones.DataSource = Devolucion.DocumentosDevolucion((int)Session["IdConexion"], "G", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
             gvDevoluciones.DataBind();
             int filas = gvDevoluciones.Rows.Count;
             if (filas > 0)
             {
                 imgbtnDevolver.Visible = true;
             }
             else
             {
                 imgbtnDevolver.Visible = false;
             }
         }
         catch
         {
             Master.MensajeError("Error al realizar la Operacion!!!",mensaje);
         }
     }
     protected void imgbtnDevolver_Click(object sender, ImageClickEventArgs e)
     {
         pnlDevolver_ModalPopupExtender.Show();
     }
     protected void btnAccionarDevolucion_Click(object sender, EventArgs e)
     {
         Int64 tram;
         Int32 idGBene;
         string fechDoc;
         Int32 nroDoc;
         Int32 idDoc;
         foreach (GridViewRow row in gvDevoluciones.Rows)
         {
             if (row.RowType == DataControlRowType.DataRow)
             {
                 //CheckBox chkRol = (row.Cells[9].FindControl("chkRol") as CheckBox);
                 //CheckBox check = (CheckBox)row.Cells["prueba"].FindControl("chkRol");
                 CheckBox chk_Publicar = (CheckBox)row.Cells[7].FindControl("chkDevolucion");
                 if (chk_Publicar.Checked)
                 {
                     // en lugar de val guardar registro
                     //int IdRol = Convert.ToInt32(row.Cells[1].Text);
                     tram = Convert.ToInt64(Tram.Value);
                     idGBene = Convert.ToInt32(gruBen.Value);
                     fechDoc = gvDevoluciones.DataKeys[row.RowIndex].Values["FechaDocumento"].ToString();
                     nroDoc = Convert.ToInt32(gvDevoluciones.DataKeys[row.RowIndex].Values["NroDocumento"].ToString());
                     idDoc = Convert.ToInt32(gvDevoluciones.DataKeys[row.RowIndex].Values["IdDocumento"].ToString());
                     //Devolucion O
                     if(Devolucion.RegistraDevolucion((int)Session["IdConexion"], "P", tram, idGBene, idDoc, fechDoc, nroDoc, txtCiteDev.Text, txtFEchaCiteDev.Text, txtFechaDevolucion.Text,txtObsEnvio.Text, ref mensaje))
                     {
                         Master.MensajeOk("Se realizo la Operacion con exito");
                     }
                     else
                     {
                         Master.MensajeError("Error al realizar la Operacion!!!",mensaje);
                     }
                 }
             }
         }
         HabilitarPaneles(1);
         txtFEchaCiteDev.Text = "";
         txtFechaDevolucion.Text = "";
         txtFEchaCiteDev.Text = "";
         txtCiteDev.Text = "";
         txtObsEnvio.Text = "";

         grillaDevolucion();

     }


    //FIN DE DEVOLUCION DE DOCUMENTOS NOTIFICACION
     //protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
     //{
     //    int Index = Convert.ToInt32(e.CommandArgument);
     //    Tram.Value = gvDatos.DataKeys[Index].Values["IdTramite"].ToString();
     //    gruBen.Value = gvDatos.DataKeys[Index].Values["IdGrupoBeneficio"].ToString();
     //    imgbtnAdd.Visible = true;
     //    CargarSeleccionado(Index);
     //    pp = 1;
     //    HabilitarPaneles(pp);
     //    grillaEnvio();
     //    grillaRecepcion();
     //    grillaDevolucion();
     //}

     protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
     {
         int fila2 = gvDatos.SelectedRow.RowIndex;
         Tram.Value = gvDatos.DataKeys[fila2].Values["IdTramite"].ToString();
         gruBen.Value = gvDatos.DataKeys[fila2].Values["IdGrupoBeneficio"].ToString();
         IdOfNot.Value = gvDatos.DataKeys[fila2].Values["IdOficinaNotificacion"].ToString();

         imgbtnAdd.Visible = true;
         imgbtnAdd.Enabled = true;
         CargarSeleccionado();
         pp = 1;
         HabilitarPaneles(pp);
         grillaEnvio();
         grillaRecepcion();
         grillaDevolucion();
     }
     private void CargarSeleccionado()
     {
         //Cargado de Datos en los TextBox
         txtCIC.Text = gvDatos.SelectedRow.Cells[3].Text;
         //txtCIC.Text = gvDatos.SelectedRow.RowIndex.ToString(); //agarra el numero de fila en la q se hace click
         txtFechaNacC.Text = gvDatos.SelectedDataKey["FechaNacimiento"].ToString();
         //txtPaternoC.Text=gvDatos.SelectedRow.Cells[4].Text;
         txtPaternoC.Text = gvDatos.SelectedDataKey["PrimerApellido"].ToString();
         //txtMaternoC.Text=gvDatos.SelectedRow.Cells[5].Text;
         txtMaternoC.Text = gvDatos.SelectedDataKey["SegundoApellido"].ToString();
         txtNombreC.Text = gvDatos.SelectedRow.Cells[6].Text;
         //txtTramiteC.Text = gvDatos.SelectedDataKey["IdTramite"].ToString();
         txtTramiteC.Text = gvDatos.SelectedRow.Cells[1].Text;
         txtMatriculaC.Text = gvDatos.SelectedRow.Cells[2].Text;
         //txtDptoActual.Text = gvDatos.SelectedRow.Cells[8].Text;
         //txtDptoActual.Text = gvDatos.SelectedDataKey["Departamento"].ToString();
         //txtFuncionarioC.Text = gvDatos.SelectedDataKey["Funcionario"].ToString();
         txtRegional.Text = gvDatos.SelectedRow.Cells[7].Text;
         Direccion.Value = gvDatos.SelectedDataKey["Direccion"].ToString();
         lblCoincidencias.Visible = false;
         gvDatos.Visible = false;
         lnkbtnMas.Visible = true;
         imgbtnAdd.Visible = true;
         PreDocumento();
     }
     protected void ddlFuncionario_TextChanged(object sender, EventArgs e)
     {         
         ddlFuncionario.DataSource = Envio.ListaFuncionarios((int)Session["IdConexion"], "A",Convert.ToInt32(ddlOficina.SelectedValue), ref mensaje);
         ddlFuncionario.DataValueField = "IdUsuario";
         ddlFuncionario.DataTextField = "Nombre";
         ddlFuncionario.DataBind();
         if (ddlFuncionario.DataSource == null)
         {
             ddlFuncionario.Enabled = false;
             ComboFuncionario();
         }
         else 
         {
             ddlFuncionario.Enabled = true;
         }
         pnlTipoCambio_ModalPopupExtender.Show();
     }
     protected void lnkmas_Click(object sender, System.EventArgs e)
     {
         if (lnkUltDev.Text == "ULTIMOS DOCUMENTOS DEVUELTOS")
         {
             try
             {
                 gvDevoluciones.Visible = false;
                 lnkUltDev.Visible = false;
                 imgbtnRecepcionar.Visible = false;
                 gvDevolucion.Visible = true;
                 gvDevolucion.DataSource = Devolucion.DocsUltimosDevueltos((int)Session["IdConexion"], "N", Convert.ToInt64(Tram.Value), Convert.ToInt32(gruBen.Value), ref mensaje);
                 gvDevolucion.DataBind();
                 lnkUltDev.Text = "VOLVER ATRAS";
             }
             catch
             {
                 Master.MensajeError("Error al realizar la operacion", mensaje);
             }
         }
         else
         {
             gvDevolucion.Visible = false;
             lnkUltDev.Visible = true;
             grillaDevolucion();
             lnkUltDev.Text = "ULTIMOS DOCUMENTOS DEVUELTOS";
         }
     }

     //PARTE INICIO DE ENVIOS NOTIFICACION
     //protected void UltimoEnvio(object sender, EventArgs e)
     //{
     //    if (lnkMas.Text == "VER ULTIMO ENVIO")
     //    {
     //        try
     //        {
     //            gvEnvio.Visible = false;
     //            lblRegional.Visible = false;
     //            btnEnviar.Visible = false;
     //            gvUltEnvio.Visible = true;
     //            gvUltEnvio.DataSource = Envio.DocsUltimoEnvio((int)Session["IdConexion"], "J", ref mensaje);
     //            gvUltEnvio.DataBind();
     //            lnkMas.Text = "VOLVER ATRAS";
     //        }
     //        catch
     //        {
     //            Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
     //        }
     //    }
     //    else
     //    {
     //        gvUltEnvio.Visible = false;
     //        lblRegional.Visible = true;
     //        grillaEnvio();
     //        lnkMas.Text = "VER ULTIMO ENVIO";
     //    }
     //}
     protected void UltimaRecepcion(object sender, EventArgs e)
     {
         if (lnkMas.Text == "VER ULTIMA RECEPCION")
         {
             try
             {
                 gvEnvio.Visible = false;
                 lblRegional.Visible = false;
                 btnEnviar.Visible = false;
                 gvUltEnvio.Visible = true;
                 gvUltEnvio.DataSource = Documento.DocsRecepcion((int)Session["IdConexion"], "O",Convert.ToInt64(Tram.Value),Convert.ToInt32(gruBen.Value), ref mensaje);
                 gvUltEnvio.DataBind();
                 lnkMas.Text = "VOLVER ATRAS";
             }
             catch
             {
                 Master.MensajeError("Error al realizar la Operacion!!!", mensaje);
             }
         }
         else
         {
             gvUltEnvio.Visible = false;
             lblRegional.Visible = true;
             grillaEnvio();
             lnkMas.Text = "VER ULTIMA RECEPCION";
         }
     }
}