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
using wcfSeguridad.Logica;
using wcfCertificacionCC.Logica;
using wcfGeo.Logica;
using wcfWorkFlowN.Logica;
using wcfWFArticulador.Logica;



using System.Drawing;


public partial class WFArticulador_wfrmAdministradorRutas : System.Web.UI.Page
{
    
    clsSeguridad ObjSeguridad = new clsSeguridad();
    clsRutas ObjRutas = new clsRutas();
    
    
    protected void Page_Load(object sender, EventArgs e)
    
    {
        
        if (!Page.IsPostBack)
        {
            
            
            lblTituloSistema.Text = "ADMINISTRADOR DE RUTAS";
            lblTitulo.Text = "Lista de Areas a Derivar";
            pnlListaRutas.Visible = true;
            pnlNuevaRuta.Visible = false;
            ListarFlujoBusqueda();
            
            
        }
    }   

    #region INTERFAZ
    
    private void CambiarInterfaz()
    {

        //AgregarJSAtributos(txtDescripcionRUC, ddlTipoDocumento);
        //AgregarJSAtributos(txtRUC, txtDetRUC);
        //AgregarJSAtributos(txtDetRUC, ddlTipoDocumento);
        //AgregarJSAtributos(txtPeriodoSalario, txtSalarioCotizable);
        //AgregarJSAtributos(txtSalarioCotizable, ddlMonedaSalario);        
        //AgregarJSAtributos(txtGlosaSalario, btnInsertar);
    }
    private void AgregarJSAtributos(Control ctrlActual, Control ctrlSiguiente)
    {
        if (ctrlActual is TextBox)
        {
            TextBox controlActual = (TextBox)ctrlActual;

            controlActual.Attributes.Add("onkeypress", " return focusNext('" + controlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "',  event) ");
            //controlActual.Attributes.Add("onFocus", "  JavaScript:this.style.backgroundColor='#ffff00'; SelectAll(this)");
            //controlActual.Attributes.Add("onBlur", "  JavaScript:this.style.backgroundColor='#ffffff'; return focusNext('" + ctrlActual.ClientID + "', '" + ctrlSiguiente.ClientID + "', null)  ");

        }
    }
    #endregion
    public void CleanControl(ControlCollection controles)
    {
        foreach (Control control in controles)
        {
            if (control is TextBox)
                ((TextBox)control).Text = string.Empty;
            else if (control is DropDownList)
                ((DropDownList)control).ClearSelection();
            else if (control is RadioButtonList)
                ((RadioButtonList)control).ClearSelection();
            else if (control is CheckBoxList)
                ((CheckBoxList)control).ClearSelection();
            else if (control is RadioButton)
                ((RadioButton)control).Checked = false;
            else if (control is CheckBox)
                ((CheckBox)control).Checked = false;
            else if (control.HasControls())
                //Esta linea detécta un Control que contenga otros Controles
                //Así ningún control se quedará sin ser limpiado.
                CleanControl(control.Controls);
        }
    }
    private void ListarFlujo()
    {
        try
        {
        int iIdConexion = (int)Session["IdConexion"];
        string sMensajeError = null;
        int iIdArea = (int)Session["IdArea"];
        string cOperacion = "A";
        ddlTipoFlujo.Items.Clear();

        ddlTipoFlujo.DataSource = ObjRutas.ListaFlujo(iIdConexion, cOperacion,ref sMensajeError);
        ddlTipoFlujo.DataValueField = "IdDetalleClasificador";
        ddlTipoFlujo.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoFlujo.DataBind();
        ddlTipoFlujo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlTipoFlujo.SelectedValue = "0";
        }

        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void ListarFlujoBusqueda()
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            int iIdArea = (int)Session["IdArea"];
            string cOperacion = "A";
            ddlTipoFlujoBusqueda.Items.Clear();

            ddlTipoFlujoBusqueda.DataSource = ObjRutas.ListaFlujo(iIdConexion, cOperacion, ref sMensajeError);
            ddlTipoFlujoBusqueda.DataValueField = "IdDetalleClasificador";
            ddlTipoFlujoBusqueda.DataTextField = "DescripcionDetalleClasificador";
            ddlTipoFlujoBusqueda.DataBind();
            ddlTipoFlujoBusqueda.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlTipoFlujoBusqueda.SelectedValue = "0";
        }

        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void ListaAreaDestino(int iIdTipoFlujo)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "Q";
            int? iIdArea = null;
            if ((int)Session["RolUsuario"] != 253)
            {
                iIdArea = (int)Session["IdArea"];
            }

            ddlAreaDestino.Items.Clear();
            ddlAreaDestino.DataSource = ObjRutas.ListaAreaDestino(iIdConexion, cOperacion, iIdArea,iIdTipoFlujo, ref sMensajeError);
            ddlAreaDestino.DataValueField = "IdAreaDestino";
            ddlAreaDestino.DataTextField = "AreaDestino";
            ddlAreaDestino.DataBind();
            ddlAreaDestino.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlAreaDestino.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void ListaAreaOrigen()
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "B";
            int ?iIdArea = null;
            if ((int)Session["RolUsuario"] != 253)            
            {
               iIdArea = (int)Session["IdArea"];
               ddlAreaOrigen.Enabled = false;
            }

            ddlAreaOrigen.Items.Clear();            
            ddlAreaOrigen.DataSource = ObjRutas.ListaAreaOrigen(iIdConexion, cOperacion, iIdArea , ref sMensajeError);
            ddlAreaOrigen.DataValueField = "IdAreaOrigen";
            ddlAreaOrigen.DataTextField = "AreaOrigen";
            ddlAreaOrigen.DataBind();
            ddlAreaOrigen.Items.Insert(0, new ListItem("Seleccione...", "0"));
            if ((int)Session["RolUsuario"] != 253)
            {
                ddlAreaOrigen.SelectedIndex = 1;
                ListaRolesOrigen(Convert.ToInt32(ddlAreaOrigen.SelectedValue));
            }
            else
            {
                ddlAreaOrigen.SelectedValue = "0";
            }
            
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    private void ListaAreaOrigenBusqueda()
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "B";
            int? iIdArea = null;
            if ((int)Session["RolUsuario"] != 253)
            {
                iIdArea = (int)Session["IdArea"];
                ddlAreaOrigenBusqueda.Enabled = false;
            }

            ddlAreaOrigenBusqueda.Items.Clear();
            ddlAreaOrigenBusqueda.DataSource = ObjRutas.ListaAreaOrigen(iIdConexion, cOperacion, iIdArea, ref sMensajeError);
            ddlAreaOrigenBusqueda.DataValueField = "IdAreaOrigen";
            ddlAreaOrigenBusqueda.DataTextField = "AreaOrigen";
            ddlAreaOrigenBusqueda.DataBind();
            ddlAreaOrigenBusqueda.Items.Insert(0, new ListItem("Seleccione...", "0"));
            if ((int)Session["RolUsuario"] != 253)
            {
                ddlAreaOrigenBusqueda.SelectedIndex = 1;
                ListaRutas(Convert.ToInt32(ddlTipoFlujoBusqueda.SelectedValue), Convert.ToInt32(ddlAreaOrigenBusqueda.SelectedValue));
            }
            else
            {
                ddlAreaOrigenBusqueda.SelectedValue = "0";
            }

        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void ddlTipoFlujo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdTipoFlujo =Convert.ToInt32(ddlTipoFlujo.SelectedValue);
        ListaAreaDestino(iIdTipoFlujo);
        ListaAreaOrigen();
        
    }
    protected void ddlAreaDestino_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdArea=Convert.ToInt32(ddlAreaDestino.SelectedValue);
        ListaRolesDestino(iIdArea);
    }
    private void ListaRolesDestino(int iIdArea)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "C";


            ddlRolDestino.Items.Clear();
            ddlRolDestino.DataSource = ObjRutas.ListaRolDestino(iIdConexion, cOperacion, iIdArea, ref sMensajeError);
            ddlRolDestino.DataValueField = "IdRol";
            ddlRolDestino.DataTextField = "DescripcionRol";
            ddlRolDestino.DataBind();
            ddlRolDestino.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlRolDestino.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        CleanControl(this.Controls);
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {

            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "I";
            int iIdTipoFlujo = Convert.ToInt32(ddlTipoFlujo.SelectedValue);
            int iIdAreaOrigen = Convert.ToInt32(ddlAreaOrigen.SelectedValue);
            int iIdRolOrigen = Convert.ToInt32(ddlRolOrigen.SelectedValue);
            int iIdAreaDestino = Convert.ToInt32(ddlAreaDestino.SelectedValue);
            int iIdRolDestino = Convert.ToInt32(ddlRolDestino.SelectedValue);
            string sJustificacion = ckeJustificacion.Text;
            if (ObjRutas.InsertarRuta(iIdConexion, cOperacion, iIdTipoFlujo, iIdAreaOrigen, iIdAreaDestino, iIdRolOrigen,iIdRolDestino, sJustificacion, ref sMensajeError))
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
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }

    }
    protected void ddlAreaOrigen_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIdArea = Convert.ToInt32(ddlAreaOrigen.SelectedValue);
        ListaRolesOrigen(iIdArea);
    }
    private void ListaRolesOrigen(int iIdArea)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "C";
            ddlRolOrigen.Items.Clear();
            ddlRolOrigen.DataSource = ObjRutas.ListaRolDestino(iIdConexion, cOperacion, iIdArea, ref sMensajeError);
            ddlRolOrigen.DataValueField = "IdRol";
            ddlRolOrigen.DataTextField = "DescripcionRol";
            ddlRolOrigen.DataBind();
            ddlRolOrigen.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddlRolOrigen.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }

    protected void btnNuevaRuta_Click(object sender, ImageClickEventArgs e)
    {
        pnlListaRutas.Visible = false;
        pnlNuevaRuta.Visible = true;
        ListarFlujo();
    }
    private void ListaRutas(int iIdTipoFlujo,int iIdArea)
    {
        try
        {
            int iIdConexion = (int)Session["IdConexion"];
            string sMensajeError = null;
            string cOperacion = "E";

            gvDatosRutas.DataSource = ObjRutas.ListaRutas(iIdConexion, cOperacion, iIdTipoFlujo, iIdArea,  ref sMensajeError);
            gvDatosRutas.DataBind();   
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = Convert.ToString(ex);
            Master.MensajeError(Error, DetalleError);
        }
    }


    protected void ddlTipoFlujoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaAreaOrigenBusqueda();
    }
    protected void ddlAreaOrigenBusqueda_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListaRutas(Convert.ToInt32(ddlTipoFlujoBusqueda.SelectedValue), Convert.ToInt32(ddlAreaOrigenBusqueda.SelectedValue));
    }
    protected void gvDatosRutas_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowIndex = Convert.ToInt32(e.Row.RowIndex) + 1;
            int iIdEstadoRuta = Convert.ToInt32(gvDatosRutas.DataKeys[e.Row.RowIndex].Values["IdEstadoRuta"]);
            int iRegistroActivo = Convert.ToInt32(gvDatosRutas.DataKeys[e.Row.RowIndex].Values["RegistroActivo"]);
            if (iIdEstadoRuta == 31530)
            {
                e.Row.FindControl("imgEliminar").Visible = false;
                e.Row.FindControl("imgDeshabilitar").Visible = false;
            }
            if (iRegistroActivo == 0)
            {
                e.Row.BackColor = Color.FromName("#FFCC00");
                e.Row.FindControl("imgDeshabilitar").Visible = false;
            }
        }
    }
    protected void btnListaRutas_Click(object sender, ImageClickEventArgs e)
    {
        pnlListaRutas.Visible = true;
        pnlNuevaRuta.Visible = false;
    }
    protected void gvDatosRutas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        if (e.CommandName == "cmdEliminar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);
                

                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "D";
                string sMensajeError = null;

                int iIdRuta = Convert.ToInt32(gvDatosRutas.DataKeys[Index].Values["IdRuta"]);


                if (ObjRutas.EliminaRuta(iIdConexion, cOperacion, iIdRuta, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListaRutas(Convert.ToInt32(ddlTipoFlujoBusqueda.SelectedValue), Convert.ToInt32(ddlAreaOrigenBusqueda.SelectedValue));
                    

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
        if (e.CommandName == "cmdDeshabilitar")
        {
            try
            {
                int Index = Convert.ToInt32(e.CommandArgument);


                int iIdConexion = (int)Session["IdConexion"];
                string cOperacion = "F";
                string sMensajeError = null;

                int iIdRuta = Convert.ToInt32(gvDatosRutas.DataKeys[Index].Values["IdRuta"]);


                if (ObjRutas.DeshabilitaRuta(iIdConexion, cOperacion, iIdRuta, ref sMensajeError))
                {
                    string msg = "La operacion se realizo con exito";
                    Master.MensajeOk(msg);
                    ListaRutas(Convert.ToInt32(ddlTipoFlujoBusqueda.SelectedValue), Convert.ToInt32(ddlAreaOrigenBusqueda.SelectedValue));


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
        
    }
}