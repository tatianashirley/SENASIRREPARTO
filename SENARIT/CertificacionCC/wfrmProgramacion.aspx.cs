using System;
using System.Collections.Generic;
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
using wcfCertificacionCC.Logica;
using wcfGeo.Logica;
using wcfSeguridad.Logica;



using System.Drawing;
using System.Globalization;
public partial class CertificacionCC_wfrmProgramacion : System.Web.UI.Page
{
  
  clsProgramacion ObjProgramacion = new clsProgramacion();
  clsEstructuraProgramacion ObjEstructuraProgramacion = new clsEstructuraProgramacion();
  clsSeguridad ObjSeguridad = new clsSeguridad();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String TituloSistema="Certificacion CC";
            Master.TituloSistema(TituloSistema);
            lblTituloSistema.Text = TituloSistema;
            lblSubTitulo.Text = "Programacion";
            pnlRegistrarMalla.Visible = false;
            pnlRegistrarMallaRechazada.Visible = false;
            
            CabeceraMalla();
            EstructuraProgramacion();
            ListaProgramacion(0);
            gvCabecera.Columns[14].Visible = false;
            CambiarInterfaz();
            imgcalendariofinal.Enabled = false;
            txtFechaFinal.Enabled = false;
            txtFechaInicio.Enabled = false;
            lblValidacionFechaMayo.Visible = false;
        }
    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtFechaInicio, txtFechaFinal);
        AgregarJSAtributos(txtFechaFinal, btnIngresarCabecera);
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void CabeceraMalla()
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "Q";

            DataTable PlazoProgramacion;
            PlazoProgramacion = ObjProgramacion.PlazoProgramacion(iIdConexion, cOperacion, ref sMensajeError);

            if (PlazoProgramacion.Rows.Count > 0)
            {
                ddlPlazoProgramacion.DataSource = PlazoProgramacion;
                ddlPlazoProgramacion.DataValueField = "IdDetalleClasificador";
                ddlPlazoProgramacion.DataTextField = "DescripcionDetalleClasificador";
                ddlPlazoProgramacion.DataBind();
                ddlPlazoProgramacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlPlazoProgramacion.SelectedValue = "0";
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
        
    }
    protected void EstructuraProgramacion()
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "Q";

            DataTable PlazoProgramacion;
            PlazoProgramacion = ObjProgramacion.EstructuraProgramacion(iIdConexion, cOperacion, ref sMensajeError);

            if (PlazoProgramacion.Rows.Count > 0)
            {
                ddlEstructura.DataSource = PlazoProgramacion;
                ddlEstructura.DataValueField = "IdEstructura";
                ddlEstructura.DataTextField = "Descripcion";
                ddlEstructura.DataBind();
                ddlEstructura.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlEstructura.SelectedValue = "0";
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void ListaResponsable(int iIdEstructura)
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "C";
            DataTable ProgramacionResponsable;
            ProgramacionResponsable = ObjProgramacion.ProgramacionResponsable(iIdConexion, cOperacion, iIdEstructura, ref sMensajeError);
            txtIdRol.Text = Convert.ToString(ProgramacionResponsable.Rows[0]["IdRol"]);

            if (ProgramacionResponsable.Rows.Count > 0)
            {
                ddlIdUsuarioResponsable.DataSource = ProgramacionResponsable;
                ddlIdUsuarioResponsable.DataValueField = "IdUsuario";
                ddlIdUsuarioResponsable.DataTextField = "DatosCompletosUsuario";
                ddlIdUsuarioResponsable.DataBind();
                ddlIdUsuarioResponsable.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddlIdUsuarioResponsable.SelectedValue = "0";
                string msg = "La operacion se realizo con exito";
                Master.MensajeOk(msg);
            }
            else
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(sMensajeError);
                Master.MensajeError(Error, DetalleError);
            }
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void ddlEstructura_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            int iIdEstructura=Convert.ToInt32(ddlEstructura.SelectedValue);

            ListaResponsable(iIdEstructura);
            
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnCancelar_Click1(object sender, EventArgs e)
    {
        
        ddlIdUsuarioResponsable.Items.Clear();
        txtFechaFinal.Text = "";
        txtFechaInicio.Text = "";
        CabeceraMalla();
        EstructuraProgramacion();
        btnActualizarCabecera.Visible = false;
        btnIngresarCabecera.Visible = true;
        pnlModificaProgramacion.Visible = false;
        pnlRegistrarMalla.Visible = false;
        pnlRegistrarMallaRechazada.Visible = false;
        ListaProgramacion(0);
        gvCabecera.Columns[14].Visible = false;
        ddlEstructura.Enabled = true;
        ddlIdUsuarioResponsable.Enabled = true;
        txtFechaInicio.Enabled = false;
        ddlPlazoProgramacion.Enabled = true;
        imgcalendariofinal.Enabled = false;
        txtFechaFinal.Enabled = false;
        lblValidacionFechaMayo.Visible = false;

    }
    protected void btnIngresarCabecera_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fFechaFinal = Convert.ToDateTime(txtFechaFinal.Text);

            if (fFechaInicio <= fFechaFinal)
                            {
                                lblValidacionFechaMayo.Visible = false;
                                pnlModificaProgramacion.Visible = false;
                                pnlRegistrarMalla.Visible = false;
                                pnlRegistrarMallaRechazada.Visible = false;

                                int iIdConexion = (int)Session["IdConexion"];
                                string cOperacion = "I";


                                int iIdPlazoProgramacion = Convert.ToInt32(ddlPlazoProgramacion.SelectedValue);
                                int iIdEstructuraProgramacion = Convert.ToInt32(ddlEstructura.SelectedValue);
                                int iIdResponsable = Convert.ToInt32(ddlIdUsuarioResponsable.SelectedValue);
                                string sFechaInicio = txtFechaInicio.Text;
                                string sFechaFinal = txtFechaFinal.Text;
                                int iIdRol = Convert.ToInt32(txtIdRol.Text);
                                string sMensajeError = null;
                                int iIdProgramacion = 0;
                                if (ObjProgramacion.ProgramacionAdiciona(iIdConexion, cOperacion, iIdEstructuraProgramacion, iIdPlazoProgramacion, iIdResponsable, sFechaInicio, sFechaFinal, ref sMensajeError, ref iIdProgramacion))
                                {
                                    string msg = "Se registro la programación con exito";
                                    Master.MensajeOk(msg);
                                    ListaProgramacion(iIdProgramacion);
                                    if (ObjProgramacion.ProgramacionMallaAdiciona(iIdConexion, cOperacion, iIdProgramacion, sFechaInicio, sFechaFinal, 685, iIdResponsable, 0, iIdRol, 716, ref sMensajeError))
                                    {
                                        msg = "Se registro la programación con exito";
                                        Master.MensajeOk(msg);
                                        ListaProgramacion(iIdProgramacion);
                                        gvCabecera.Columns[14].Visible = false;
                                    }
                                    else
                                    {
                                        string Error = "Error al realizar la operación";
                                        string DetalleError = sMensajeError;
                                        Master.MensajeError(Error, DetalleError);
                                    }
                                }
                                else
                                {
                                    string Error = "Error al realizar la operación";
                                    string DetalleError = sMensajeError;
                                    Master.MensajeError(Error, DetalleError);
                                }
                                
                                
                            }
                            else
                            {
                                lblValidacionFechaMayo.Visible = true;
                                lblValidacionFechaMayo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Final de la programacion";
                                

                            }
            
            
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
        
    }

    protected void ListaProgramacion(int iIdProgramacion)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "V";            
            string sMensajeError = null;
            gvCabecera.Columns[14].Visible = true;
            gvCabecera.DataSource = ObjProgramacion.ListaProgramacionPorId(iIdConexion, cOperacion, iIdProgramacion, ref sMensajeError);
            gvCabecera.DataBind();
            
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }   
    protected void ddlPlazoProgramacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdPlazoProgramacion = Convert.ToInt32(ddlPlazoProgramacion.SelectedValue);
        //DateTime fFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
        //DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture)
        DateTime fFechaInicio = DateTime.ParseExact(txtFechaInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None);
        //DateTime fFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
       
        if (iIdPlazoProgramacion == 678)
        {
            txtFechaFinal.Text = Convert.ToString(txtFechaInicio.Text);
           
        }
        if (iIdPlazoProgramacion == 679)
        {

            DateTime fFechaFin=fFechaInicio.AddDays(7);
            txtFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", fFechaFin);
        }
        if (iIdPlazoProgramacion == 680)
        {
            
            DateTime fFechaFin = fFechaInicio.AddDays(15);
            txtFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", fFechaFin);
           
        }
        if (iIdPlazoProgramacion == 681)
        {
            
            DateTime fFechaFin = fFechaInicio.AddMonths(1);
            txtFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", fFechaFin);
           
        }
        if (iIdPlazoProgramacion == 682)
        {
            
            DateTime fFechaFin = fFechaInicio.AddMonths(3);
            txtFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", fFechaFin);
           
        }
        if (iIdPlazoProgramacion == 683)
        {
            
            DateTime fFechaFin = fFechaInicio.AddMonths(6);
            txtFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", fFechaFin);
            
        }
        if (iIdPlazoProgramacion == 684)
        {
            
            DateTime fFechaFin = fFechaInicio.AddMonths(12);
            txtFechaFinal.Text = String.Format("{0:dd/MM/yyyy}", fFechaFin);
            
        }
        
        txtFechaFinal.Focus();
        imgcalendariofinal.Enabled = true;
        txtFechaFinal.Enabled = false;

            
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            string sFechaInicioParte = (string)ViewState["sFechaInicioParte"];
            string sFechaConclusionParte = (string)ViewState["sFechaConclusionParte"];            
            int iIdProgramacion = (int)ViewState["iIdProgramacion"];
            int iIdTipoProgramacion = 685;
            int iIdEstadoProgramacion = 716;            
            string sMensajeError = null;
            foreach (GridViewRow row in gvMallaAutomatica.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRol = (row.Cells[0].FindControl("chkRol") as CheckBox);

                    if (chkRol.Checked)
                    {                        
                        int iIdUsuario = Convert.ToInt32(row.Cells[1].Text);
                        int iIdRol = Convert.ToInt32(row.Cells[3].Text);
                        int iIdUsuarioSuperior = Convert.ToInt32(row.Cells[5].Text);

                        if (ObjProgramacion.ProgramacionMallaAdiciona(iIdConexion, cOperacion, iIdProgramacion, sFechaInicioParte, sFechaConclusionParte, iIdTipoProgramacion, iIdUsuario, iIdUsuarioSuperior, iIdRol, iIdEstadoProgramacion, ref sMensajeError))
                        {
                            string msg = "La operacion se realizo con exito";
                            Master.MensajeOk(msg);
                            pnlRegistrarMalla.Visible = false;
                        }
                        else
                        {
                            string Error = "Error al realizar la operación";
                            string DetalleError = sMensajeError;
                            Master.MensajeError(Error, DetalleError);
                        }

                    }
                }
            }
            ListaProgramacion(0);
            gvCabecera.Columns[14].Visible = false;
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnRechazar_Click(object sender, EventArgs e)
    {
        pnlRegistrarMalla.Visible = false;
        pnlRegistrarMallaRechazada.Visible = true;   
        int iIdProgramacion = (int)ViewState["iIdProgramacion"];
        lblNroProgramacion2.Text = Convert.ToString(iIdProgramacion);
        int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
        int iIdEstructura = (int)ViewState["iIdEstructura"];
        string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
        //string sFechaConclusionPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
        string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = "";
        int iCantidad = 0;
        int iIdRol = 0;
        int iIdUsuarioSuperior = 0;
        DataTable EquipoTrabajo = new DataTable();
        EquipoTrabajo = ObjProgramacion.ProgramacionMallaAutomatico(iIdConexion, cOperacion, iIdRol, sFechaInicioPrg,sFechaFinalPrg, iCantidad, iIdUsuarioSuperior,iIdEstructura, ref sMensajeError);
        gvEstructuraMallaAsistida.DataSource = EquipoTrabajo;
        gvEstructuraMallaAsistida.DataBind();
    }
    protected void btnAceptarAsistida_Click(object sender, EventArgs e)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            string sFechaInicioParte = (string)ViewState["sFechaInicioParte"];
            string sFechaConclusionParte = (string)ViewState["sFechaConclusionParte"];
            int iIdProgramacion = (int)ViewState["iIdProgramacion"];
            int iIdTipoProgramacion = 685;
            int iIdEstadoProgramacion = 716;
            string sMensajeError = null;
            string DetalleError = null;
            foreach (GridViewRow row in gvEstructuraMallaAsistida.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRolAsistida = (row.Cells[0].FindControl("chkRolAsistida") as CheckBox);

                    if (chkRolAsistida.Checked)
                    {
                        // en lugar de val guardar registro
                        int iIdUsuario = Convert.ToInt32(row.Cells[1].Text);
                        int iIdRol = Convert.ToInt32(row.Cells[3].Text);
                        int iIdUsuarioSuperior = 0;

                        if (ObjProgramacion.ProgramacionMallaAdiciona(iIdConexion, cOperacion, iIdProgramacion, sFechaInicioParte, sFechaConclusionParte, iIdTipoProgramacion, iIdUsuario, iIdUsuarioSuperior, iIdRol, iIdEstadoProgramacion, ref sMensajeError))
                        {
                            string msg = "La operacion se realizo con exito";
                            Master.MensajeOk(msg);
                            pnlRegistrarMallaRechazada.Visible = false;
                            
                        }
                        else
                        {
                            string Error = "Error al realizar la operación";
                            
                            DetalleError=DetalleError+sMensajeError;
                            Master.MensajeError(Error, DetalleError);
                        }

                    }
                }
            }
            ListaProgramacion(0);
            gvCabecera.Columns[14].Visible = false;


        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void gvCabecera_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iIdPersonas = Convert.ToInt32(e.Row.Cells[13].Text.ToString());
            int iIdEstadoProgramacion = Convert.ToInt32(e.Row.Cells[14].Text.ToString());

            if (iIdEstadoProgramacion == 717)
            {
                
                e.Row.FindControl("imgAprobada").Visible = true;
                e.Row.FindControl("imgElaborada").Visible = false;
                e.Row.FindControl("imgPendiente").Visible = false;
                e.Row.FindControl("imgModificar").Visible = true;                
                e.Row.FindControl("imgEliminar").Visible = false;                
            }
            else
            {
                if (iIdPersonas > 1)
                {   
                    e.Row.FindControl("imgAprobada").Visible = false;
                    e.Row.FindControl("imgElaborada").Visible = true;
                    e.Row.FindControl("imgPendiente").Visible = false;
                    e.Row.FindControl("imgModificar").Visible = true;                    
                    e.Row.FindControl("imgEliminar").Visible = true;

                }
                else
                {
                    e.Row.FindControl("imgAprobada").Visible = false;
                    e.Row.FindControl("imgElaborada").Visible = false;
                    e.Row.FindControl("imgPendiente").Visible = true;
                    e.Row.FindControl("imgModificar").Visible = false;                    
                    e.Row.FindControl("imgEliminar").Visible = true;

                }
            }
            
        }
        
        
    }
    protected void gvCabecera_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdElaborarEquipo")
        {
            try
            {
                
                int Index = Convert.ToInt32(e.CommandArgument);
                gvCabecera.Rows[Index].BackColor = Color.FromName("#FFCC00");
                pnlRegistrarMalla.Visible = true;
                pnlRegistrarMallaRechazada.Visible = false;
                pnlModificaProgramacion.Visible = false;
                ViewState["sFechaInicioParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaInicioPrg"]);
                ViewState["sFechaConclusionParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaFinalPrg"]);
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdEstructura"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdEstructura"]);
                ViewState["iIdUsuarioResponsable"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdUsuarioResponsable"]);
                int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                lblNroProgramacion1.Text = Convert.ToString(iIdProgramacion);
                int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                int iIdEstructura = (int)ViewState["iIdEstructura"];
                string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "Q";
                string sMensajeError = "";
                int iCantidad = 0;
                int iIdRol = 0;

                DataTable Estructura;
                DataTable EquipoTrabajo = new DataTable();
                DataTable EquipoTrabajo1 = new DataTable();
                Estructura = (ObjEstructuraProgramacion.ConsultaEstructuraDetalle(iIdConexion, cOperacion, iIdEstructura, ref sMensajeError));
                if (Estructura != null && Estructura.Rows.Count > 0)
                {
                    foreach (DataRow drDataRow in Estructura.Rows)
                    {
                        int iIdUsuarioSuperior;
                        if (drDataRow["IdRolSuperior"] is DBNull)
                        {

                        }
                        else
                        {  
                            iIdRol = Convert.ToInt32(drDataRow["IdRol"]);
                            iCantidad = Convert.ToInt32(drDataRow["Cantidad"]);
                            if (EquipoTrabajo.Rows.Count < 1)
                            {
                                iIdUsuarioSuperior = iIdUsuarioResponsable;
                                EquipoTrabajo = ObjProgramacion.ProgramacionMallaAutomatico(iIdConexion, cOperacion, iIdRol, sFechaInicioPrg,sFechaFinalPrg, iCantidad, iIdUsuarioSuperior, iIdEstructura, ref sMensajeError);
                            }
                            else if (EquipoTrabajo.Rows.Count >= 1)
                            {
                                int ultimo = EquipoTrabajo.Rows.Count;
                                iIdUsuarioSuperior = Convert.ToInt32(EquipoTrabajo.Rows[ultimo - 1][1]);
                                EquipoTrabajo1 = ObjProgramacion.ProgramacionMallaAutomatico(iIdConexion, cOperacion, iIdRol, sFechaInicioPrg,sFechaFinalPrg, iCantidad, iIdUsuarioSuperior, iIdEstructura, ref sMensajeError);

                                foreach (DataRow drRow in EquipoTrabajo1.Rows)
                                {
                                    DataRow dr = EquipoTrabajo.NewRow();
                                    dr[0] = Convert.ToString(drRow["CuentaUsuario"]);
                                    dr[1] = Convert.ToString(drRow["IdUsuario"]);
                                    dr[2] = Convert.ToString(drRow["IdRol"]);
                                    dr[3] = Convert.ToString(drRow["Rol"]);
                                    dr[4] = Convert.ToString(drRow["IdUsuarioSuperior"]);
                                    dr[5] = Convert.ToString(drRow["NombreCompletoUsuario"]);
                                    dr[6] = Convert.ToString(drRow["DatosCompletosUsuario"]);
                                    EquipoTrabajo.Rows.Add(dr);

                                }
                            }

                        }

                    }
                    gvMallaAutomatica.DataSource = EquipoTrabajo;
                    gvMallaAutomatica.DataBind();

                }

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdAprobar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                gvCabecera.Rows[Index].BackColor = Color.FromName("#FFCC00");
                ViewState["sFechaInicioParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaInicioPrg"]);
                ViewState["sFechaConclusionParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaFinalPrg"]);
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdEstructura"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdEstructura"]);
                ViewState["iIdUsuarioResponsable"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdUsuarioResponsable"]);
                int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                int iIdEstructura = (int)ViewState["iIdEstructura"];
                string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "U";
                string sMensajeError = "";
                int iIdEstadoProgramacion = 717;
                if (ObjProgramacion.ProgramacionMallaModificaEstado(iIdConexion, cOperacion, iIdProgramacion,iIdEstructura, iIdEstadoProgramacion, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListaProgramacion(0);
                    gvCabecera.Columns[14].Visible = false;
                    Response.Redirect("~/CertificacionCC/wfrmProgramacion.aspx");
                    
                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operaciónn";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdModificar")
        {
            try
            {
                
                lblModificaVisualiza.Text = "Modificacion de la Programacion: Nro ";                
                int Index = Convert.ToInt32(e.CommandArgument);                
                gvCabecera.Rows[Index].BackColor = Color.FromName("#FFCC00");
                //gvCabecera.Rows[Index].BackColor = Color.Gray;
                pnlRegistrarMalla.Visible = false;
                pnlRegistrarMallaRechazada.Visible = false;                
                pnlModificaProgramacion.Visible = true;
                btnAdicionar.Visible = true;
                ViewState["sFechaInicioParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaInicioPrg"]);
                ViewState["sFechaConclusionParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaFinalPrg"]);
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdEstructura"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdEstructura"]);
                ViewState["iIdUsuarioResponsable"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdUsuarioResponsable"]);
                int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                lblNroProgramacion.Text = Convert.ToString(iIdProgramacion);
                int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                int iIdEstructura = (int)ViewState["iIdEstructura"];
                string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
                int iIdConexion = (int)Session["IdConexion"];               
                string sMensajeError = "";
                DataTable EquipoTrabajoSN = new DataTable();
                DataTable EquipoTrabajo = new DataTable();
                string cOperacion = "F";
                gvListaProgramacionMalla.Columns[8].Visible = true;
                int iIdEstadoProgramacion =0;
                EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion,   iIdProgramacion,iIdEstadoProgramacion,ref sMensajeError));
                gvListaProgramacionMalla.DataSource = EquipoTrabajo;
                gvListaProgramacionMalla.DataBind();
                gvListaProgramacionMalla.Columns[8].Visible = false;
                cOperacion = "V";
                EquipoTrabajoSN = (ObjProgramacion.ConsultaProgramacionMalla(iIdConexion, cOperacion, iIdEstructura, sFechaInicioPrg, sFechaFinalPrg,iIdProgramacion, ref sMensajeError));                
                gvModificaProgramacion.DataSource = EquipoTrabajoSN;
                gvModificaProgramacion.DataBind();
                gvModificaProgramacion.Visible = true;
                

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        
        if (e.CommandName == "cmdEliminar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);                
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdProgramacion"]);
                int iIdProgramacion = (int)ViewState["iIdProgramacion"];                
                int iIdConexion = (int)Session["IdConexion"];
                string sMensajeError = "";                
                string cOperacion = "D";
                if (ObjProgramacion.EliminaProgramacion(iIdConexion, cOperacion, iIdProgramacion, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);                    
                    ListaProgramacion(0);
                    gvCabecera.Columns[14].Visible = false;

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
                
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdModificarCabecera")
        {
            try
            {
                btnIngresarCabecera.Visible = false;
                btnActualizarCabecera.Visible = true;
                
                int Index = Convert.ToInt32(e.CommandArgument);
                gvCabecera.Rows[Index].BackColor = Color.FromName("#FFCC00");
                ViewState["sFechaInicioParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaInicioPrg"]);
                ViewState["sFechaConclusionParte"] = Convert.ToString(gvCabecera.DataKeys[Index].Values["FechaFinalPrg"]);
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdEstructura"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdEstructura"]);
                ViewState["iIdUsuarioResponsable"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdUsuarioResponsable"]);
                ViewState["iIdEstadoProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdEstadoProgramacion"]);
                ViewState["iIdTipoPlazoProgramacion"] = Convert.ToInt32(gvCabecera.DataKeys[Index].Values["IdTipoPlazoProgramacion"]);
                int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                int iIdEstructura = (int)ViewState["iIdEstructura"];
                string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                string sFechaConclusionPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
                int iIdEstadoProgramacion = (int)ViewState["iIdEstadoProgramacion"];
                int iIdTipoPlazoProgramacion = (int)ViewState["iIdTipoPlazoProgramacion"];
                if (iIdEstadoProgramacion == 717)
                {
                    ddlEstructura.Enabled = false;
                    ddlIdUsuarioResponsable.Enabled = false;
                    txtFechaInicio.Enabled = false;
                    ddlPlazoProgramacion.Enabled = true;

                }
                else
                {
                    ddlEstructura.Enabled = true;
                    ddlIdUsuarioResponsable.Enabled = true;
                    txtFechaInicio.Enabled = false;
                    ddlPlazoProgramacion.Enabled = true;
                }
                ddlEstructura.SelectedValue = Convert.ToString(iIdEstructura);
                ListaResponsable(iIdEstructura);
                ddlIdUsuarioResponsable.SelectedValue = Convert.ToString(iIdUsuarioResponsable);
                ddlPlazoProgramacion.SelectedValue = Convert.ToString(iIdTipoPlazoProgramacion);
                txtFechaInicio.Text = sFechaInicioPrg;
                txtFechaFinal.Text = sFechaConclusionPrg;
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
    }

    protected void gvListaProgramacionMalla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdEliminar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                
                pnlRegistrarMalla.Visible = false;
                pnlRegistrarMallaRechazada.Visible = false;
                ViewState["iIdProgramacionM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdUsuarioM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdUsuario"]);
                ViewState["iIdRolM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdRol"]);


                int iIdProgramacionM = (int)ViewState["iIdProgramacionM"];
                int iIdUsuarioM = (int)ViewState["iIdUsuarioM"];
                int iIdRolM = (int)ViewState["iIdRolM"];                
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "D";
                string sMensajeError = "";     
                
                if (ObjProgramacion.EliminaProgramacionMalla(iIdConexion, cOperacion, iIdProgramacionM,iIdUsuarioM,iIdRolM, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                    int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                    int iIdEstructura = (int)ViewState["iIdEstructura"];
                    string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                    string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
                    sMensajeError = "";
                    DataTable EquipoTrabajoSN = new DataTable();
                    DataTable EquipoTrabajo = new DataTable();
                    cOperacion = "F";
                    int iIdEstadoProgramacion = 0;
                    gvListaProgramacionMalla.Columns[8].Visible = true;
                    EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion, iIdProgramacion,iIdEstadoProgramacion,ref sMensajeError));
                    gvListaProgramacionMalla.DataSource = EquipoTrabajo;
                    gvListaProgramacionMalla.DataBind();
                    gvListaProgramacionMalla.Columns[8].Visible = false;
                    cOperacion = "V";
                    EquipoTrabajoSN = (ObjProgramacion.ConsultaProgramacionMalla(iIdConexion, cOperacion, iIdEstructura, sFechaInicioPrg,sFechaFinalPrg, iIdProgramacion, ref sMensajeError));
                    gvModificaProgramacion.DataSource = EquipoTrabajoSN;
                    gvModificaProgramacion.DataBind();
                    ListaProgramacion(0);
                    gvCabecera.Columns[14].Visible = false;

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdBloqueado")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                gvListaProgramacionMalla.Rows[Index].BackColor = Color.FromName("#FFCC00");
                pnlRegistrarMalla.Visible = false;
                pnlRegistrarMallaRechazada.Visible = false;
                ViewState["iIdProgramacionM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdUsuarioM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdUsuario"]);
                ViewState["iIdRolM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdRol"]);
                ViewState["IdEstadoProgramacionM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdEstadoProgramacion"]);
                ViewState["FechaInicioParteM"] = Convert.ToString(gvListaProgramacionMalla.DataKeys[Index].Values["FechaInicioParte"]);
                ViewState["FechaConclusionParteM"] = Convert.ToString(gvListaProgramacionMalla.DataKeys[Index].Values["FechaConclusionParte"]);


                int iIdProgramacionM = (int)ViewState["iIdProgramacionM"];
                int iIdUsuarioM = (int)ViewState["iIdUsuarioM"];
                int iIdRolM = (int)ViewState["iIdRolM"];
                string sFechaInicioParteM = (string)ViewState["FechaInicioParteM"];
                string sFechaConclusionParteM = (string)ViewState["FechaConclusionParteM"];
                int iIdConexion = (int)Session["IdConexion"];
                int iIdEstadoProgramacionM = (int)ViewState["IdEstadoProgramacionM"];  
                string cOperacion = "U";
                string sMensajeError = "";

                if (ObjProgramacion.ModificaProgramacionMallaEstado(iIdConexion, cOperacion, iIdProgramacionM, iIdUsuarioM, iIdRolM,iIdEstadoProgramacionM,sFechaInicioParteM,sFechaConclusionParteM, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                    int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                    int iIdEstructura = (int)ViewState["iIdEstructura"];
                    string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                    string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);
                    sMensajeError = "";
                    DataTable EquipoTrabajoSN = new DataTable();
                    DataTable EquipoTrabajo = new DataTable();
                    cOperacion = "F";
                    int iIdEstadoProgramacion = 0;
                    gvListaProgramacionMalla.Columns[8].Visible = true;
                    EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion, iIdProgramacion,iIdEstadoProgramacion, ref sMensajeError));
                    gvListaProgramacionMalla.DataSource = EquipoTrabajo;
                    gvListaProgramacionMalla.DataBind();
                    gvListaProgramacionMalla.Columns[8].Visible = false;
                    cOperacion = "V";
                    EquipoTrabajoSN = (ObjProgramacion.ConsultaProgramacionMalla(iIdConexion, cOperacion, iIdEstructura, sFechaInicioPrg,sFechaFinalPrg, iIdProgramacion, ref sMensajeError));
                    gvModificaProgramacion.DataSource = EquipoTrabajoSN;
                    gvModificaProgramacion.DataBind();
                    ListaProgramacion(0);
                    gvCabecera.Columns[14].Visible = false;

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdAprobar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                gvListaProgramacionMalla.Rows[Index].BackColor = Color.FromName("#FFCC00");
                pnlRegistrarMalla.Visible = false;
                pnlRegistrarMallaRechazada.Visible = false;
                ViewState["iIdProgramacionM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdUsuarioM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdUsuario"]);
                ViewState["iIdRolM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdRol"]);
                ViewState["IdEstadoProgramacionM"] = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdEstadoProgramacion"]);
                ViewState["FechaInicioParteM"] = Convert.ToString(gvListaProgramacionMalla.DataKeys[Index].Values["FechaInicioParte"]);
                ViewState["FechaConclusionParteM"] = Convert.ToString(gvListaProgramacionMalla.DataKeys[Index].Values["FechaConclusionParte"]);
                int iIdProgramacionM = (int)ViewState["iIdProgramacionM"];
                int iIdUsuarioM = (int)ViewState["iIdUsuarioM"];
                int iIdRolM = (int)ViewState["iIdRolM"];
                string sFechaInicioParteM =(string)ViewState["FechaInicioParteM"];
                string sFechaConclusionParteM = (string)ViewState["FechaConclusionParteM"];
                sFechaInicioParteM=sFechaInicioParteM.Substring(0,10);
                int iIdConexion = (int)Session["IdConexion"];
                int iIdEstadoProgramacionM = (int)ViewState["IdEstadoProgramacionM"]; //Estado Aprobado
                string cOperacion = "U";
                string sMensajeError = "";

                if (ObjProgramacion.ModificaProgramacionMallaEstado(iIdConexion, cOperacion, iIdProgramacionM, iIdUsuarioM, iIdRolM,iIdEstadoProgramacionM, sFechaInicioParteM,sFechaConclusionParteM,ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                    int iIdUsuarioResponsable = (int)ViewState["iIdUsuarioResponsable"];
                    int iIdEstructura = (int)ViewState["iIdEstructura"];
                    string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
                    string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);

                    sMensajeError = "";
                    DataTable EquipoTrabajoSN = new DataTable();
                    DataTable EquipoTrabajo = new DataTable();
                    cOperacion = "F";
                    int iIdEstadoProgramacion = 0;
                    gvListaProgramacionMalla.Columns[8].Visible = true;
                    EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion, iIdProgramacion,iIdEstadoProgramacion, ref sMensajeError));
                    gvListaProgramacionMalla.DataSource = EquipoTrabajo;
                    gvListaProgramacionMalla.DataBind();
                    gvListaProgramacionMalla.Columns[8].Visible = false;
                    cOperacion = "V";
                    EquipoTrabajoSN = (ObjProgramacion.ConsultaProgramacionMalla(iIdConexion, cOperacion, iIdEstructura, sFechaInicioPrg,sFechaFinalPrg, iIdProgramacion, ref sMensajeError));
                    gvModificaProgramacion.DataSource = EquipoTrabajoSN;
                    gvModificaProgramacion.DataBind();
                    ListaProgramacion(0);
                    gvCabecera.Columns[14].Visible = false;

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdReprogramacion")
        {
            Response.Redirect("~/CertificacionCC/wfrmReprogramacion.aspx");
        }
    }
    protected void gvListaProgramacionMalla_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int iIdEstadoProgramacion = Convert.ToInt32(e.Row.Cells[8].Text.ToString());
            

            if (iIdEstadoProgramacion == 717)
            {
                e.Row.FindControl("imgBloqueadoMalla").Visible = true;
                e.Row.FindControl("imgEliminarMalla").Visible = false;
                e.Row.FindControl("imgAprobarMalla").Visible = false;
            }
            else
            {
                if (iIdEstadoProgramacion == 716)
                {
                    e.Row.FindControl("imgBloqueadoMalla").Visible = false;
                    e.Row.FindControl("imgEliminarMalla").Visible = true;
                    e.Row.FindControl("imgAprobarMalla").Visible = true;
                }
                else
                {
                    if (iIdEstadoProgramacion == 719 || iIdEstadoProgramacion == 720)
                    {
                        e.Row.FindControl("imgBloqueadoMalla").Visible = false;
                        e.Row.FindControl("imgEliminarMalla").Visible = false;
                        e.Row.FindControl("imgAprobarMalla").Visible = true;
                    }
                    else
                    {
                        
                        e.Row.FindControl("imgBloqueadoMalla").Visible = false;
                        e.Row.FindControl("imgEliminarMalla").Visible = false;
                        e.Row.FindControl("imgAprobarMalla").Visible = false;
                    }
                }
                
            }

        }


    }
    protected void btnLimpiarPnl_Click(object sender, EventArgs e)
    {
        pnlModificaProgramacion.Visible = false;
        pnlRegistrarMalla.Visible = false;
        pnlRegistrarMallaRechazada.Visible = false;
        pnlNuevoUsuarioProgramacion.Visible = false;
        gvModificaProgramacion.Visible = false;
        ddlIdUsuarioResponsable.Items.Clear();
        txtFechaFinal.Text = "";
        txtFechaInicio.Text = "";

    }
    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        try
        {
            pnlNuevoUsuarioProgramacion.Visible = false;
            gvModificaProgramacion.Visible = false;

            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            string sFechaInicioParte = (string)ViewState["sFechaInicioParte"];            
            string sFechaConclusionParte = (string)ViewState["sFechaConclusionParte"];
            int iIdProgramacion = (int)ViewState["iIdProgramacion"];
            int iIdTipoProgramacion = 685; //Programacion Oficial
            int iIdEstadoProgramacion = 716;
            string sMensajeError = null;
            string DetalleError = null;
            foreach (GridViewRow row in gvModificaProgramacion.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRolAsistida = (row.Cells[0].FindControl("chkRolAsistida") as CheckBox);

                    if (chkRolAsistida.Checked)
                    {
                        // en lugar de val guardar registro
                        int iIdUsuario = Convert.ToInt32(row.Cells[1].Text);
                        int iIdRol = Convert.ToInt32(row.Cells[3].Text);
                        int iIdUsuarioSuperior = 0;

                        if (ObjProgramacion.ProgramacionMallaAdiciona(iIdConexion, cOperacion, iIdProgramacion, sFechaInicioParte, sFechaConclusionParte, iIdTipoProgramacion, iIdUsuario, iIdUsuarioSuperior, iIdRol, iIdEstadoProgramacion, ref sMensajeError))
                        {
                            string msg = "La operacion se realizo con exito";
                            Master.MensajeOk(msg);
                            pnlRegistrarMallaRechazada.Visible = false;

                        }
                        else
                        {
                            string Error = "Error al realizar la operación";                            
                            DetalleError=DetalleError + sMensajeError;
                            Master.MensajeError(Error, DetalleError);
                        }

                    }
                }
            }

            //ListaProgramacion(0);
            //gvCabecera.Columns[14].Visible = false;
            //pnlModificaProgramacion.Visible = false;                                    
            DataTable EquipoTrabajo = new DataTable();
            cOperacion = "F";
            gvListaProgramacionMalla.Columns[8].Visible = true;
            iIdEstadoProgramacion = 0;
            EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion, iIdProgramacion, iIdEstadoProgramacion, ref sMensajeError));
            gvListaProgramacionMalla.DataSource = EquipoTrabajo;
            gvListaProgramacionMalla.DataBind();
            gvListaProgramacionMalla.Columns[8].Visible = false;
            cOperacion = "V";
         
          
            int iIdEstructura = (int)ViewState["iIdEstructura"];
            string sFechaInicioPrg = ((string)ViewState["sFechaInicioParte"]).Substring(0, 10);
            string sFechaFinalPrg = ((string)ViewState["sFechaConclusionParte"]).Substring(0, 10);

            DataTable EquipoTrabajoSN = new DataTable();
            EquipoTrabajoSN = (ObjProgramacion.ConsultaProgramacionMalla(iIdConexion, cOperacion, iIdEstructura, sFechaInicioPrg, sFechaFinalPrg, iIdProgramacion, ref sMensajeError));
            gvModificaProgramacion.DataSource = EquipoTrabajoSN;
            gvModificaProgramacion.DataBind();
            gvModificaProgramacion.Visible = true;

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnActualizarCabecera_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fFechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fFechaFinal = Convert.ToDateTime(txtFechaFinal.Text);

            if (fFechaInicio <= fFechaFinal)
            {
                lblValidacionFechaMayo.Visible = false;
                pnlModificaProgramacion.Visible = false;
                pnlRegistrarMalla.Visible = false;
                pnlRegistrarMallaRechazada.Visible = false;
                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "M";

                int iIdEstadoProgramacion = (int)ViewState["iIdEstadoProgramacion"];
                int iIdProgramacion = (int)ViewState["iIdProgramacion"];
                int iIdPlazoProgramacion = Convert.ToInt32(ddlPlazoProgramacion.SelectedValue);
                int iIdEstructuraProgramacion = Convert.ToInt32(ddlEstructura.SelectedValue);
                int iIdResponsable = Convert.ToInt32(ddlIdUsuarioResponsable.SelectedValue);
                string sFechaInicio = txtFechaInicio.Text;
                string sFechaFinal = txtFechaFinal.Text;
                int iIdRol = Convert.ToInt32(txtIdRol.Text);
                string sMensajeError = null;
                if (ObjProgramacion.ProgramacionCabeceraModifica(iIdConexion, cOperacion, iIdProgramacion, iIdEstructuraProgramacion, iIdPlazoProgramacion, iIdResponsable, sFechaInicio, sFechaFinal, iIdRol, iIdEstadoProgramacion, ref sMensajeError))
                {
                    string msg = "Se modifico la programación con exito";
                    Master.MensajeOk(msg);
                    ListaProgramacion(iIdProgramacion);

                }
                else
                {
                    string Error = "Error al realizar la operación";
                    string DetalleError = sMensajeError;
                    Master.MensajeError(Error, DetalleError);
                }
                


            }
            else
            {
                lblValidacionFechaMayo.Visible = true;
                lblValidacionFechaMayo.Text = "La Fecha Inicio no puede ser mayor a la Fecha Final de la programacion";


            }
            
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }   
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        pnlNuevoUsuarioProgramacion.Visible = true;
        btnAdicionar.Visible = false;
        btnLimpiarPnl.Visible = false;
        gvListaxRol.DataSource = null;
        gvListaxRol.DataBind();
        int iIdEstructura = (int)ViewState["iIdEstructura"];
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "Q";
        string sMensajeError = null;
        ddlListaEstructura.Items.Clear();
        ddlListaEstructura.DataSource = ObjEstructuraProgramacion.ConsultaEstructuraDetalle(iIdConexion, cOperacion, iIdEstructura, ref sMensajeError);
        ddlListaEstructura.DataValueField = "IdRol";
        ddlListaEstructura.DataTextField = "Rol";
        ddlListaEstructura.DataBind();
        ddlListaEstructura.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlListaEstructura.SelectedValue = "0";

    }
    protected void ddlListaEstructura_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "W";
        string sMensajeError = null;
        int iIdRol=Convert.ToInt32(ddlListaEstructura.SelectedValue);
        gvListaxRol.DataSource=ObjProgramacion.ConsultaUsuarioxRol(iIdConexion, cOperacion, iIdRol, ref sMensajeError);
        gvListaxRol.DataBind();
    }
    protected void btnAdicionarNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            pnlNuevoUsuarioProgramacion.Visible = false;
            gvModificaProgramacion.Visible = false;

            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "I";
            string sFechaInicioParte = ObjSeguridad.ObtenerFecha();
            string sFechaConclusionParte = (string)ViewState["sFechaConclusionParte"];
            int iIdProgramacion = (int)ViewState["iIdProgramacion"];
            int iIdTipoProgramacion = 685; //Programacion Oficial
            int iIdEstadoProgramacion = 716;
            string sMensajeError = null;
            string DetalleError = null;
            foreach (GridViewRow row in gvListaxRol.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkNuevo = (row.Cells[0].FindControl("chkNuevo") as CheckBox);

                    if (chkNuevo.Checked)
                    {
                        // en lugar de val guardar registro
                        int iIdUsuario = Convert.ToInt32(row.Cells[1].Text);
                        int iIdRol = Convert.ToInt32(row.Cells[3].Text);
                        int iIdUsuarioSuperior = 0;

                        if (ObjProgramacion.ProgramacionMallaAdiciona(iIdConexion, cOperacion, iIdProgramacion, sFechaInicioParte, sFechaConclusionParte, iIdTipoProgramacion, iIdUsuario, iIdUsuarioSuperior, iIdRol, iIdEstadoProgramacion, ref sMensajeError))
                        {
                            string msg = "La operacion se realizo con exito";
                            Master.MensajeOk(msg);
                            pnlRegistrarMallaRechazada.Visible = false;

                        }
                        else
                        {
                            string Error = "Error al realizar la operación";
                            DetalleError = DetalleError + sMensajeError;
                            Master.MensajeError(Error, DetalleError);
                        }

                    }
                }
            }

            //ListaProgramacion(0);
            //gvCabecera.Columns[14].Visible = false;
            //pnlModificaProgramacion.Visible = false;                                    
            DataTable EquipoTrabajo = new DataTable();
            cOperacion = "F";
            gvListaProgramacionMalla.Columns[8].Visible = true;
            iIdEstadoProgramacion = 0;
            EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion, iIdProgramacion, iIdEstadoProgramacion, ref sMensajeError));
            gvListaProgramacionMalla.DataSource = EquipoTrabajo;
            gvListaProgramacionMalla.DataBind();
            gvListaProgramacionMalla.Columns[8].Visible = false;

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
}