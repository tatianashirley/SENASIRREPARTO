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


public partial class CertificacionCC_reprogramacion : System.Web.UI.Page
{
    clsProgramacion ObjProgramacion = new clsProgramacion();
    clsReprogramacion ObjReprogramacion = new clsReprogramacion();
    clsEstructuraProgramacion ObjEstructuraProgramacion = new clsEstructuraProgramacion();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            String TituloSistema = "Certificacion CC";
            Master.TituloSistema(TituloSistema);
            lblTituloSistema.Text = TituloSistema;
            lblSubTitulo.Text = "Re-Programacion";
            ListaUsuariosBloqueados();
            pnlListaUsuarios.Visible = false;
            CambiarInterfaz();
        }
        

    }
    private void CambiarInterfaz()
    {
        AgregarJSAtributos(txtIdProgramacion, btnBuscar);
        
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");

        }
    }
    protected void ListaUsuariosBloqueados()
    {
        try
        {
            string sMensajeError = "";
            int iIdConexion = (int)Session["IdConexion"];
            string cOperacion = "F";
            int iIdProgramacion = 0;
            int iIdEstadoProgramacion = 719;
            DataTable EquipoTrabajo;
            EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigente(iIdConexion, cOperacion, iIdProgramacion, iIdEstadoProgramacion, ref sMensajeError));
            gvListaUsuariosBloqueados.DataSource = EquipoTrabajo;
            gvListaUsuariosBloqueados.DataBind();            

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
        
        
        
    }
    protected void gvListaUsuariosBloqueados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdAsignarVerificador")
        {
            try
            {

                int Index = Convert.ToInt32(e.CommandArgument);                
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdUsuario"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdUsuario"]);
                ViewState["iNroTramites"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["NroTramites"]);
                ViewState["iIdEstadoProgramacion"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdEstadoProgramacion"]);
                ViewState["iIdRol"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdRol"]);
                int iIdRolAntiguo=(int)ViewState["iIdRol"];
                int iIdProgramacionAntigua = (int)ViewState["iIdProgramacion"];                
                if (iIdRolAntiguo == 7) //Control de Calidad
                {
                    pnlListaUsuarios.Visible = true;
                    lblIngreseProgramacion.Visible = false;
                    txtIdProgramacion.Visible = false;
                    btnBuscar.Visible = false;
                    ListaUsuariosAsignar(iIdProgramacionAntigua, iIdRolAntiguo);
                }
                if (iIdRolAntiguo == 8) //Revisor
                {
                    pnlListaUsuarios.Visible = true;
                    lblIngreseProgramacion.Visible = false;
                    txtIdProgramacion.Visible = false;
                    btnBuscar.Visible = false;
                    ListaUsuariosAsignar(iIdProgramacionAntigua, iIdRolAntiguo);
                }
                if (iIdRolAntiguo == 9) //Verificador
                {

                    pnlListaUsuarios.Visible = true;
                }

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        if (e.CommandName == "cmdArchivoTransitorio")
        {
            try
            {
                /*int Index = Convert.ToInt32(e.CommandArgument);
                ViewState["iIdProgramacion"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdProgramacion"]);
                ViewState["iIdUsuario"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdUsuario"]);
                ViewState["iNroTramites"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["NroTramites"]);
                ViewState["iIdEstadoProgramacion"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdEstadoProgramacion"]);
                ViewState["iIdRol"] = Convert.ToInt32(gvListaUsuariosBloqueados.DataKeys[Index].Values["IdRol"]);
                int iIdRolAntiguo = (int)ViewState["iIdRol"];
                int iIdProgramacionAntigua = (int)ViewState["iIdProgramacion"]; */
                //Response.Write("<script>");
                //Response.Write("window.open('../Reportes/wfrmReporteCertificadoCC.aspx','_blank')");
                //Response.Write("</script>");

                //Response.Redirect("../Reportes/wfrmReporteCertificadoCC.aspx" + Security.encryptQueryString("1") + "");
                //ScriptManager.RegisterStartupScript(this, GetType(), "openF07", " window.open('../Reportes/wfrmReporteCertificadoCC.aspx', 'newWindow', 'height=600, width=800, top=50, left=50, resizable=yes, scrollbars=yes, toolbar=0, menubar=0, status=0, location=0');", true);

            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }
        
        
    }
    protected void ListaUsuariosAsignar(int iIdProgramacion,int iIdRol)
    {
        try
        {
              int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "B";
                string sMensajeError = "";
                DataTable EquipoTrabajo = new DataTable();
                gvListaProgramacionMalla.Columns[8].Visible = true;
                EquipoTrabajo = (ObjProgramacion.ConsultaProgramacionMallaVigentexRol(iIdConexion, cOperacion, iIdProgramacion, iIdRol, ref sMensajeError));               

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

    protected void gvListaProgramacionMalla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdSelecciona")
        {
            try
            {
                
                int Index = Convert.ToInt32(e.CommandArgument);
                int iIdRol = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdRol"]);

                
                    int iIdConexion = (int)Session["IdConexion"];
                    string cOperacion = "I";
                    string sMensajeError = "";
                    DataTable EquipoTrabajo = new DataTable();
                    int iIdProgramacionNueva = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdProgramacion"]);
                    int iIdUsuarioNuevo = Convert.ToInt32(gvListaProgramacionMalla.DataKeys[Index].Values["IdUsuario"]);
                    int iIdProgramacionAntigua = (int)ViewState["iIdProgramacion"];
                    int iIdUsuarioAntiguo = (int)ViewState["iIdUsuario"];
                    if (ObjReprogramacion.ProgramacionReasigna(iIdConexion, cOperacion, iIdUsuarioAntiguo, iIdProgramacionAntigua, iIdUsuarioNuevo, iIdProgramacionNueva, ref sMensajeError))
                    {
                        string msg = "La operacion se realizo con exito";
                        Master.MensajeOk(msg);
                    }
                    else
                    {
                        string Error = "Error al realizar la operación";
                        string DetalleError = sMensajeError;
                        Master.MensajeError(Error, DetalleError);
                    }
                    //string msg = "Programacion antigua:" + iIdProgramacionAntigua + "IdUsuarioAntiguo:" + iIdUsuarioAntiguo + "Programacion nueva:" + iIdProgramacionNueva + "IdUsuarioAntiguo:" + iIdUsuarioNuevo;
                    //Master.MensajeOk(msg); 
            }
            catch (Exception ex)
            {
                string Error = "Error al realizar la operación";
                string DetalleError = Convert.ToString(ex);
                Master.MensajeError(Error, DetalleError);
            }
        }

        
        
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int iIdProgramacionNueva =Convert.ToInt32(txtIdProgramacion.Text);        
        int iIdRol = (int)ViewState["iIdRol"];
        ListaUsuariosAsignar(iIdProgramacionNueva, iIdRol);


    }

    
}