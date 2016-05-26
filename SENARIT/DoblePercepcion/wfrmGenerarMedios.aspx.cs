/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls
*/
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
using wcfServicioIntercambioPago.Logica;
using System.Data;
using System.Globalization;
using System.Drawing;
using wfcDoblePercepcion.Logica;


public partial class DoblePercepcion_wfrmGenerarMedios : System.Web.UI.Page
{
    clsManejoArchivo ManejoArchivo = new clsManejoArchivo();
    DataTable Encontrados, Consolidado = null, ConsolidadoFinal = null;
    string mensaje = null;
    clsInformacion info = new clsInformacion();

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            ddlTipoReporte.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Estado1", "", "", "", "", "", "", ""
                                                         , 0, 0, ref mensaje);

            ddlTipoReporte.DataValueField = "IdDetalleClasificador";
            ddlTipoReporte.DataTextField = "DescripcionDetalleClasificador";
            ddlTipoReporte.DataBind();

            cblAFP.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "AFP", "", "", "", "", "", "", ""
                                                         , 0, 0, ref mensaje);

            cblAFP.DataValueField = "IdDetalleClasificador";
            cblAFP.DataTextField = "DescripcionDetalleClasificador";
            cblAFP.DataBind();

            cblTipoSuspension.DataSource = info.ObtieneDatos((int)Session["IdConexion"], "Q", "TipoRehabilitacion", "", "", "", "", "", "", ""
                                             , 0, 0, ref mensaje);

            cblTipoSuspension.DataValueField = "IdDetalleClasificador";
            cblTipoSuspension.DataTextField = "DescripcionDetalleClasificador";
            cblTipoSuspension.DataBind();
        }
    }



    protected void btnGenerarReporte_Click(object sender, EventArgs e)
    {

        string id = ddlTipoReporte.SelectedValue;
        string FechaInicio = txtFechaInicio.Text.Replace("/", "-");
        string FechaFin = txtFechaFin.Text.Replace("/", "-");
        string nombre = Convert.ToString(ddlTipoReporte.SelectedItem);
        
        if (validar(FechaInicio, FechaFin))
        {
            string va = null;
            int sw = 0;
            if (ddlTipoReporte.SelectedValue != "364")
            {
                for (int i = 0; i < cblAFP.Items.Count; i++)
                {
                    if (cblAFP.Items[i].Selected)
                    {
                        // Valores += cblAFP.Items[i].Value + ";";


                        Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Medio", FechaInicio, FechaFin, id, "", "", "", "", 0, Convert.ToInt32(cblAFP.Items[i].Value), ref mensaje);
                        if (Encontrados.Rows.Count != 0)
                        {
                            if (sw == 0)
                            {
                                Consolidado = (Encontrados); sw = 1;
                            }
                            else
                            {
                                Consolidado.Merge(Encontrados);
                            }

                        }
                        va = va + "-" + Convert.ToInt32(cblAFP.Items[i].Value);
                    }
                }
            }
            else 
            {
                for (int i = 0; i < cblAFP.Items.Count; i++)
                {
                    if (cblAFP.Items[i].Selected)
                    {
                        // Valores += cblAFP.Items[i].Value + ";";

                        for (int j = 0; j < cblTipoSuspension.Items.Count; j++)
                        {
                            if (cblTipoSuspension.Items[j].Selected)
                            {
                                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Medio1", FechaInicio, FechaFin, id, "", "", "", "", Convert.ToInt32(cblTipoSuspension.Items[j].Value),
                                                                Convert.ToInt32(cblAFP.Items[i].Value), ref mensaje);
                                if (Encontrados.Rows.Count != 0)
                                {
                                    if (sw == 0)
                                    {
                                        Consolidado = (Encontrados); sw = 1;
                                    }
                                    else
                                    {
                                        Consolidado.Merge(Encontrados);
                                    }
                                }
                            }
                        }
                        va = va + "-" + Convert.ToInt32(cblAFP.Items[i].Value);
                    }
                }
            }
            if (sw == 0) {
                Consolidado = Encontrados;
            }
            if (Consolidado.Rows.Count != 0)
            {

                Encontrados = info.ObtieneDatos((int)Session["IdConexion"], "Q", "Cabecera", "", "", "", "", "", "", "", 0, 0, ref mensaje);
                if (Encontrados.Rows.Count != 0)
                {
                    ConsolidadoFinal = (Encontrados);
                    ConsolidadoFinal.Merge(Consolidado);
                }

                Session["ARCH_RESP"] = "MEDIO_DOBLE_PERCEPCION";
                DateTime fechaActual = DateTime.Now;
                int anyo = fechaActual.Year;
                int mes = fechaActual.Month;
                int day = fechaActual.Day;
                string mes1 = null;
                if (mes < 9)
                    mes1 = "0" + Convert.ToString(mes);
                else
                    mes1 = Convert.ToString(mes);
                string day1 = null;
                if (day < 9)
                    day1 = "0" + Convert.ToString(mes);
                else
                    day1 = Convert.ToString(day);

                Session["ARCH"] = "(" + nombre + ")" + va + "-" + Convert.ToString(anyo) + mes1 + day1;

                Session["ARCH_RESP"] = "DP_" + Session["ARCH"].ToString();
                string h = "DP_" + Session["ARCH"].ToString();
                if (CrearArchivo(ConsolidadoFinal, Session["ARCH_RESP"].ToString().Replace(" ", "") + ".TXT", true))
                {

                    lblDescarga.Visible = true;
                    lblDescargaCRC.Visible = true;
                    GenerarCRC(Session["CARPETA"] + Session["ARCH_RESP"].ToString().Replace(" ", "") + ".TXT");
                    Master.MensajeOk("Se creo el medio correctamente");
                }
                else
                {

                    lblDescarga.Visible = false;
                    lblDescargaCRC.Visible = false;
                }


            }
            else
            {
                lblDescarga.Visible = false;
                lblDescargaCRC.Visible = false;
                lblCRC.Text = "";
                Master.MensajeWarning("Archivo Vacio - No existe registros que generar");
            }
        }
    }

    protected bool validar(string FechaInicio, string FechaFin) 
    {
        if (FechaInicio == "" && FechaFin == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA INICIO Y FECHA FIN');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (FechaInicio == "" )
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA INICIO');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }
        if (FechaFin == "")
        {
            string script = @"<script type='text/javascript'>alert('INGRESE FECHA FIN');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
        }

        int sw = 0;
        for (int i = 0; i < cblAFP.Items.Count; i++)
        {
            if (cblAFP.Items[i].Selected)
            {
                sw = 1;

       
            }
        }
        if (sw == 0)
        { 
            string script = @"<script type='text/javascript'>alert('SELECCIONE AL MENOS 1 ENTIDAD');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            return false;
       }

        return true;
    }


    private bool CrearArchivo(DataTable TablaArchivo, string NomArchivo, bool Solapar)
    {
        try
        {

            //String CarpetaMedio = txtrutaID.Text+"/";
            String CarpetaMedio = Server.MapPath("~/Medios/CruceDoblePercepcion/");
            
            //String CarpetaMedio = Server.MapPath("~/Medios/CruceDoblePercepcion/");
            //string RutaCrear = CarpetaMedio.ToString();
            string RutaCrear = CarpetaMedio;
            
            Session["CARPETA"] = CarpetaMedio;
            ManejoArchivo.CrearArchivo(TablaArchivo, RutaCrear + NomArchivo);

           
            return true;
        
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al crear el Archivo.", ex.Message);
            return false;
        }

    }


    private void GenerarCRC(string RutaCompleta)
    {
        try
        {
            lblCRC.Text = ManejoArchivo.GenerarCRC(RutaCompleta);
        }
        catch (Exception ex)
        {
            Master.MensajeError("Error al generar el código de seguridad", ex.Message);
        }
    }

    protected void lblDescarga_Click(object sender, EventArgs e)
    {
        Response.Clear();
        string tipo = Session["ARCH_RESP"].ToString();
        string tipo1 = tipo.Replace(" ", "");
        Response.ContentType = "application/txt";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + tipo1 + ".TXT");
        Response.WriteFile(Session["CARPETA"].ToString() + tipo1 + ".TXT");
        Response.End();
    }

    protected void lblDescargaCRC_Click(object sender, EventArgs e)
    {  
        /*Response.Clear();
        Response.ContentType = "application/txt";
        string vv = Session["CARPETA"] + Session["ARCH_RESP"].ToString() + "_CRC.TXT";
        Response.AddHeader("Content-Disposition", "attachment; filename=" +  Session["CARPETA"] + Session["ARCH_RESP"].ToString() + "_CRC.TXT");
        Response.WriteFile( Session["CARPETA"] + Session["ARCH_RESP"].ToString()+ "_CRC.txt");
        Response.End();*/
        Response.Clear();
        string tipo = Session["ARCH_RESP"].ToString();
        string tipo1 = tipo.Replace(" ", "");
        Response.ContentType = "application/txt";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + tipo1 + "_CRC.TXT");
        Response.WriteFile(Session["CARPETA"].ToString() + tipo1 + "_CRC.TXT");
        Response.End();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DoblePercepcion/wfrmGenerarMedios.aspx");   
    }
    protected void ddlTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoReporte.SelectedValue == "364")
        {
            lblSuspension.Visible = true;
            cblTipoSuspension.Visible = true;
        }
        else
        {
            lblSuspension.Visible = false;
            cblTipoSuspension.Visible = false;
        }
    }
}