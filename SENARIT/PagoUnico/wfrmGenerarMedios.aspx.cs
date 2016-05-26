using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using wcfInicioTramite.Tramite.Logica;
using wcfPagoUnico.Logica;
using wcfServicioIntercambioPago.Logica;

public partial class PagoUnico_wfrmGenerarMedios : System.Web.UI.Page
{
    private clsManejoArchivo objManejArch = new clsManejoArchivo();
    private clsPUProcesos objProc = new clsPUProcesos();
    private int _idConexion;
    private string _mensajeError;
    private const string RUTA_MEDIO_PU = "~/Medios/PagoUnico/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            _idConexion = (int)Session["IdConexion"];
        }

        if (!Page.IsPostBack)
        {
            Master.btnCerrarSesion.CausesValidation = false;

            Limpiar();
            
        }
    }

    #region CARGAR_DATOS

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    private void Limpiar()
    {
        ddlTipoMedio.SelectedIndex = 0;
        txtC31.Text = "";
        ddlMesProc.SelectedValue = DateTime.Today.Month.ToString();
        txtAnioProc.Text = DateTime.Today.Year.ToString();
        
        LimpiarMensajesMasterPage();

    }

    #endregion

    #region EVENTOS_INTERMEDIOS

    private string ArmarNombreArchivoC31(int pAnio, int pMes)
    {
        var dtC31 = objProc.ObtieneC31(_idConexion, ref _mensajeError, pAnio, pMes);

        if (dtC31 != null && dtC31.Rows.Count == 1)
        {
            var dr = dtC31.Rows[0];

            var vEnt = dr["Ent"].ToString();
            var vDad = dr["Dad"].ToString();
            var vUes = dr["Ues"].ToString();
            var vC31 = dr["C31"].ToString();

            txtC31.Text = dr["C31"].ToString();

            return vEnt + vDad + vC31;
        }
        else
        {
            return null;
        }
    }

    private DataTable CargarTablaMedio(string pTipoMedio, int pC31, int pAnio, int pMes, ref string pMensajeError)
    {
        try
        {
            var dt = new DataTable();
            switch (pTipoMedio)
            {
                case "C31":
                    dt = objProc.GeneraMediosC31(_idConexion, ref pMensajeError, pC31, pAnio, pMes);
                    break;
                case "pgb":
                    dt = objProc.GeneraMediosPU(_idConexion, ref pMensajeError, pC31, pAnio, pMes);
                    break;
            }

            return dt;
        }
        catch (Exception ex)
        {
            pMensajeError = ex.Message;
            return null;
        }        
    }

    private bool CrearMedio(DataTable pDtDatos, string pRutaMedio,string pNomArchivo, string pTipoMedio, ref string pMensajeError)
    {
        try
        {
            var continuarFlujo = false;
            var vNomArchCRC = pNomArchivo + "_CRC";

           
            objManejArch.CrearArchivo(pDtDatos, pRutaMedio + pNomArchivo + ".TXT");
            objManejArch.GenerarCRC(pRutaMedio + pNomArchivo + ".TXT");

            if (MoverArchivo(pRutaMedio + pNomArchivo + ".TXT", pRutaMedio + pNomArchivo + "." + pTipoMedio,
                        ref pMensajeError))
                    {
                        if (MoverArchivo(pRutaMedio + pNomArchivo + "_CRC.TXT",
                            pRutaMedio + vNomArchCRC + "." + pTipoMedio, ref pMensajeError))
                        {
                            continuarFlujo = true;
                        }
                    }

            return continuarFlujo;
        }
        catch (Exception ex)
        {
            pMensajeError = ex.Message;
            return false;
        }
    }

    private bool MoverArchivo(string pNomArchivo, string pNuevoNomArchivo, ref string pMensajeError)
    {
        try
        {
            if (File.Exists(pNomArchivo))
            {
                File.Move(pNomArchivo, pNuevoNomArchivo);
            }

            return true;
        }
        catch (Exception ex)
        {
            pMensajeError = ex.Message;
            return false;
        }
    }

    private void DescargarArchivo(string pNomArch)
    {
        LimpiarMensajesMasterPage();
        try
        {
            var vRutaMedio = Server.MapPath(RUTA_MEDIO_PU);
            var vRutaCompleta = vRutaMedio + pNomArch;

            if (VerificarExisteArchivo(vRutaCompleta, ref _mensajeError))
            {
                Response.Clear();
                Response.ContentType = "application/txt";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pNomArch);
                Response.WriteFile(vRutaCompleta);
                Response.Flush();
                Response.End();

                Master.MensajeOk("Se ha logrado descargar exitosamente el archivo " + pNomArch + "!!!");
            }
            else
            {
                Master.MensajeError("El archivo " + pNomArch + " no existe", _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al descargar el archivo " + pNomArch + "!!!!", ex.Message);
        }
    }


    private bool VerificarExisteArchivo(string pRutaCompleta, ref string pMensajeError)
    {
        try
        {
            if (File.Exists(pRutaCompleta))
            {
                pMensajeError = "El archivo ya existe en el servidor";
                return true;
            }
            else
            {
                pMensajeError = "El archivo no existe!!!";
                return false;
            }
        }
        catch (Exception ex)
        {
            pMensajeError = ex.Message + " - " + ex.StackTrace;
            return false;
        }
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    protected void ibtnGenerarMedio_Click(object sender, ImageClickEventArgs e)
    {
        var vNomArchivo = ArmarNombreArchivoC31(Convert.ToInt32(txtAnioProc.Text), Convert.ToInt32(ddlMesProc.SelectedValue));

        if (vNomArchivo != null)
        {            
            var vRutaMedio = Server.MapPath(RUTA_MEDIO_PU);

            //if(!VerificarExisteArchivo(vRutaMedio + vNomArchivo + "." + ddlTipoMedio.SelectedValue, ref _mensajeError))
            //{
                var dtDatos = CargarTablaMedio(ddlTipoMedio.SelectedValue, Convert.ToInt32(txtC31.Text),
                    Convert.ToInt32(txtAnioProc.Text),
                    Convert.ToInt32(ddlMesProc.SelectedValue), ref _mensajeError);

                if (dtDatos != null)
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        BorrarArchivo(vRutaMedio + vNomArchivo + "." + ddlTipoMedio.SelectedValue);
                        BorrarArchivo(vRutaMedio + vNomArchivo + "_CRC." + ddlTipoMedio.SelectedValue);
                        
                        if (CrearMedio(dtDatos, vRutaMedio, vNomArchivo, ddlTipoMedio.SelectedValue,
                            ref _mensajeError))
                        {
                            ibtnDescargarMedio.Enabled = true;
                            ibtnDescargarCRC.Enabled = true;

                            Master.MensajeOk("Se ha almacenado correctamente el medio generado " + vNomArchivo + "." +
                                                ddlTipoMedio.SelectedValue + " y su respectivo CRC!!!!");
                        }
                        else
                        {
                            Master.MensajeError(
                                "Se produjo un error al crear el medio " + vNomArchivo + "." +
                                ddlTipoMedio.SelectedValue,
                                _mensajeError);
                        }
                       
                    }
                    else
                    {
                        Master.MensajeWarning("No se recupero ningún registro!!");
                    }
                }
                else
                {
                    Master.MensajeError("Se produjo un error al recuperar Datos para el medio " + vNomArchivo + "." + ddlTipoMedio.SelectedValue, _mensajeError);
                }
            //}
            //else
            //{
            //    Master.MensajeError("El medio " + vNomArchivo + "." + ddlTipoMedio.SelectedValue + " ya existe!!!", _mensajeError);
            //}
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('No se ha encontrado un registro del C31 dadas las características seleccionadas');", true);
        }
    }

    protected void ibtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();
    }

    protected void ibtnDescargarMedio_Click(object sender, ImageClickEventArgs e)
    {
        var vNomArchivo = ArmarNombreArchivoC31(Convert.ToInt32(txtAnioProc.Text), Convert.ToInt32(ddlMesProc.SelectedValue)) + "." + ddlTipoMedio.SelectedValue;
        DescargarArchivo(vNomArchivo);
    }

    protected void ibtnDescargarCRC_Click(object sender, ImageClickEventArgs e)
    {
        var vNomArchivo = ArmarNombreArchivoC31(Convert.ToInt32(txtAnioProc.Text), Convert.ToInt32(ddlMesProc.SelectedValue)) + "_CRC" + "." + ddlTipoMedio.SelectedValue;
        DescargarArchivo(vNomArchivo);
    }

    private void BorrarArchivo(string pArchivoPath)
    {
        if (VerificarExisteArchivo(pArchivoPath, ref _mensajeError))
        {
            File.Delete(pArchivoPath);
            //return true;
        }
        //else
        //{
        //    return false;
        //}
    }

    #endregion
    
}