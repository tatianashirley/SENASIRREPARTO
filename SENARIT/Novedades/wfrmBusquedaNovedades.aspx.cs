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

public partial class Novedades_wfrmBusquedaNovedades : System.Web.UI.Page
{



    
    protected void Page_Load(object sender, EventArgs e)
    {
              
        if (!Page.IsPostBack)
        {
            string usuariored = User.Identity.Name;
            CargarComboDeClasificadores();
            Cargar_Grid();
             
        }
    }
    //-------------------------------------------------------------------------------------------------
    protected void CargarComboDeClasificadores()
    {
        clsNovedades clas = new clsNovedades();
        ddlTipoNovedad.DataSource = clas.ListarClasifporTipo(7);
        ddlTipoNovedad.DataValueField = "IdTipoActualizacion";
        ddlTipoNovedad.DataTextField = "CodigoActualizacion";
        ddlTipoNovedad.DataBind();
    }

    protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        Cargar_Grid();
    }

    protected void BuscarNUA(object sender, ImageClickEventArgs e)
    {
        string cua = this.TextCUA.Text;
        string estado = this.ddlEstadoNovedad.SelectedValue;
        int iIdConexion = (int)Session["IdConexion"];
        clsNovedades busca = new clsNovedades();
        gvNovedades.DataSource = busca.ListarNovedadesPorCUA1(iIdConexion,cua, estado);
        //gvNovedades.KeyFieldName = "IdActualizacion";
        gvNovedades.DataBind();
       
    }

    private void Cargar_Grid()
    {

        string CodTipo = this.ddlTipoNovedad.SelectedValue;
        string estado = this.ddlEstadoNovedad.SelectedValue;
        if (CodTipo == "") CodTipo = "0";
        if (estado == "") estado = "0";
        int iIdConexion = (int)Session["IdConexion"];
        DateTime fechainicio = DateTime.Today;
        DateTime fechafin;
        string mensaje = "";
        if (DateTime.TryParse(txtFechaInicio.Text, out fechainicio)) fechainicio = Convert.ToDateTime(txtFechaInicio.Text);
        else fechainicio = DateTime.MinValue;
        if (DateTime.TryParse(txtFechaFin.Text, out fechafin)) fechafin = Convert.ToDateTime(txtFechaFin.Text);
        else fechafin = DateTime.MaxValue;
        clsNovedades busca = new clsNovedades();
        gvNovedades.DataSource = busca.ListarNovedadesPorTipo1(iIdConexion,ref mensaje,Convert.ToInt32(CodTipo), fechainicio, fechafin, estado);
        //gvNovedades.KeyFieldName = "IdActualizacion";
        gvNovedades.DataBind();
       
    }



    protected void gvNovedades_RowCommand(object sender,  GridViewCommandEventArgs e)
    {
        string accion = e.CommandName.ToUpper();
        GridViewRow row1 = gvNovedades.SelectedRow;
        int IdActualizacion;
        int Estado;
        string DocumentoAprobacion = "Nada";
        string mensaje = "";
        string mensaje_error = "";
        int retorno_proc = 0;
        if (accion == "PAGE") return;
        clsNovedades adi = new clsNovedades();
        int iIdConexion = (int)Session["IdConexion"];
        string cOperacion = "I";
        string sSessionTrabajo = null;
        string sSNN = null;
        string Usuario = adi.IdUsuarioConectado((int)Session["IdConexion"]);
        foreach (GridViewRow row in this.gvNovedades.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
               //CheckBox chkRow = (row.Cells[0].FindControl("chkNovedad") as CheckBox);
                System.Web.UI.WebControls.CheckBox chkRow = (row.FindControl("chkNovedad") as System.Web.UI.WebControls.CheckBox);
                if (chkRow.Checked)
                {
                    IdActualizacion = Convert.ToInt32(row.Cells[2].Text);
                    switch (accion)
                    {
                        case "APROBAR":
                            Estado = 1;
                            if (adi.ApruebaNovedad(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref mensaje_error,
                                    IdActualizacion, Estado, DocumentoAprobacion, Usuario, ref mensaje
                                     ))
                            {
                                Master.MensajeOk(mensaje);
                            }
                            else
                            {
                                string DetalleError = mensaje;
                                Master.MensajeError("Error al realizar la operación", mensaje_error);
                            }
                            break;
                        case "RECHAZAR":
                            Estado = 2;
                            if (adi.ApruebaNovedad(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref mensaje_error,
                                    IdActualizacion, Estado, DocumentoAprobacion, Usuario, ref mensaje
                                     ))
                            {
                                Master.MensajeOk(mensaje);
                            }
                            else
                            {
                                string DetalleError = mensaje;
                                Master.MensajeError("Error al realizar la operación", mensaje_error);
                            }
                            break;
                        case "APLICAR":
                            Estado = 3;
                            adi.AplicaNovedad(IdActualizacion, out mensaje, out retorno_proc);
                            //Muestra_Mensaje(mensaje);
                            if (retorno_proc == 1) MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            break;
                        case "ELIMINAR":
                            Estado = 4;
                            adi.EliminaNovedad(IdActualizacion,Usuario, out mensaje, out retorno_proc);
                            //Muestra_Mensaje(mensaje);
                            if (retorno_proc == 1) MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            else MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            break;
                        case "IMPRIMIR":
                            Session["IdActualizacion"] = IdActualizacion;
                            Response.Redirect("wfrmRepNovedadesId.aspx");
                            Estado = 0;
                            return;
                    }
                }
            }
        }
        Cargar_Grid();
    }
    protected void gvNovedades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvNovedades.PageIndex = e.NewPageIndex;
        Cargar_Grid();
    }

}
