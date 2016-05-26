using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using AjaxControlToolkit;
using System.Configuration;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Drawing;


using wcfCalificacionRentas.Logica;


public partial class CalificacionRentas_wfrmCalificacionTitular : System.Web.UI.Page
{
    clsCalificacionTitular objCalif = new clsCalificacionTitular();
    protected void Page_Load(object sender, EventArgs e)
    {
    
        llenarClaseResolucion();
        llenarTipoRenta();
    }

    public void llenarClaseResolucion()
    {
        DataTable res = objCalif.ObtClasificadorTipoResolucion((int)Session["IdConexion"], "Q");
        ddlClaseResolucion.DataSource = res;
        ddlClaseResolucion.DataTextField = "NombreBeneficioOtorgado";
        ddlClaseResolucion.DataValueField = "IdBeneficioOtorgado";
        ddlClaseResolucion.DataBind();
    }
    public void llenarTipoRenta()
    {
        DataTable res = objCalif.ObtClasificadorTipoRenta((int)Session["IdConexion"], "R");
        ddlTipoResolucion.DataSource = res;
        ddlTipoResolucion.DataTextField = "DescripcionDetalleClasificador";
        ddlTipoResolucion.DataValueField = "IdDetalleClasificador";
        ddlTipoResolucion.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
     
    }

    protected void CargarComboTipoResolucion()
    {

    }
   
    protected void ddlTipoResolucion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
    {        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        /*TxtApPaterno.Text = TxtApPaterno.Text.Trim();
        TxtApMaterno.Text = TxtApMaterno.Text.Trim();
        TxtPrimerNombre.Text = TxtPrimerNombre.Text.Trim();
        TxtSegundoNombre.Text = TxtSegundoNombre.Text.Trim();
        TxtCi.Text = TxtCi.Text.Trim();
        TxtMatricula.Text = TxtMatricula.Text.Trim();*/

        String paterno = TxtApPaterno.Text.Trim();
        String materno = TxtApMaterno.Text.Trim();
        String pnonombre = TxtPrimerNombre.Text.Trim();
        String snombre = TxtSegundoNombre.Text.Trim();
        String ci = TxtCi.Text.Trim();
        String matriculas = TxtMatricula.Text.Trim();

        //TxtNup.Text = TxtNup.Text.Trim();

        /*if (String.IsNullOrEmpty(TxtMatricula.Text))
        {
            string Error = "Error: ";
            string DetalleError = "El numero de la matricula es un dato obligatorio para realizar la busqueda.";
            Master.MensajeError(Error, DetalleError);
            return;
        }

        if (TxtMatricula.Text.Length < 6)
        {
            string Error = "Error: ";
            string DetalleError = "El tamaño de la cadena de la matricula debe ser mayor a 6 caracteres.";
            Master.MensajeError(Error, DetalleError);
            return;
        }*/
        //llenado del grid
        
        /*LlenaListado(TxtApPaterno.Text, TxtApMaterno.Text,
            TxtPrimerNombre.Text, TxtSegundoNombre.Text,TxtCi.Text,TxtMatricula.Text);*/
        PanelListado.Visible = true;
        LlenaListado(paterno, materno, pnonombre, snombre, ci, matriculas);
  
    }
    private void LlenaListado(string appaterno, string apmaterno, string pnombre, string snombre, string ci, string matricula)
    {
        try
        {
            //clsCalificacionTitular objListadoAsegurados = new clsCalificacionTitular();
            //(string appaterno, string apmaterno, string nombres, string ci, string matricula, string nup, int                     IdConexion, string Operacion)

            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
            IDataReader readerFindUserInfo = objCalif.ListarDeAseguradoSegunFiltro(appaterno, apmaterno, pnombre, snombre, ci, matricula, (int)Session["IdConexion"], "Q");
            gdListadoCalificacion.DataSource = readerFindUserInfo;
            gdListadoCalificacion.DataBind();
            //PanelListado.Visible = true;
            string Msg = "Se realizó la Operación con éxito.";
            Master.MensajeOk(Msg);
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = "";
            Master.MensajeError(Error, DetalleError);
        }

    }
    /*private void LlenaListado(string appaterno, string apmaterno, string pnombre, string snombre, string ci, string matriculas)
    {
        try
        {
            clsCalificacionTitular objListadoAsegurados = new clsCalificacionTitular();
            //(string appaterno, string apmaterno, string nombres, string ci, string matricula, string nup, int                     IdConexion, string Operacion)

            string msg = "La operacion se realizo con exito";
            Master.MensajeOk(msg);
            IDataReader readerFindUserInfo = objListadoAsegurados.ListarDeAseguradoSegunFiltro(appaterno, apmaterno,                pnombre, snombre, ci, matricula, (int)Session["IdConexion"], "Q");
            gdListadoCalificacion.DataSource = readerFindUserInfo;
            gdListadoCalificacion.DataBind();
            gdListadoCalificacion.Visible = true;
            string Msg = "Se realizó la Operación con éxito.";
            Master.MensajeOk(Msg);
        }
        catch (Exception ex)
        {
            string Error = "Error al realizar la operación";
            string DetalleError = "";
            Master.MensajeError(Error, DetalleError);
        }

    }*/

    protected void Button6_Click(object sender, EventArgs e)
    {
        /*clsCalificacionTitular objCalifInser = new clsCalificacionTitular();
        string NUPAsegurado = Convert.ToString("220456");
        int IDGrupoBeneficio = Convert.ToInt16(1);
        int IDCampoAplicacion = Convert.ToInt32(29);
        DateTime FechaOtorgamiento = Convert.ToDateTime("24-05-2016");//Convert.ToDateTime(TextBox2.Text);
        int EstadoBeneficio = Convert.ToInt32(364);
        string BeneficioOtorgado = ddlClaseResolucion.DataValueField;
        string TipoResolucion = ddlTipoResolucion.DataValueField ;
        string res = objCalifInser.RegistrarNuevoBeneficio(NUPAsegurado, IDGrupoBeneficio, IDCampoAplicacion, FechaOtorgamiento, EstadoBeneficio, BeneficioOtorgado, TipoResolucion, (int)Session["IdConexion"], "I");

        if (res == null)
        {
            string Msg = "Se realizo la Operacion con exito";
            Master.MensajeOk(Msg);
        }
        else
        {
            string Error = "Error al realizar la operación";
            string DetalleError = res;
            Master.MensajeError(Error, DetalleError);
        }    */
    }
}