using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using wcfInicioTramite.Tramite.Logica;
using wcfPagoUnico.Logica;

public partial class PagoUnico_wfrmGenerarChequesPU : System.Web.UI.Page
{
    private clsPUProcesos objProcesos = new clsPUProcesos();
    private clsTramite objTramite = new clsTramite();

    private int _idConexion;
    private string _mensajeError;
    private DateTime _hoy = DateTime.Today;

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
            CargarCboEntidadFinan();
            txtAnio.Text = _hoy.Year.ToString();
            ddlMes.SelectedValue = _hoy.Month.ToString();
        }
    }

    #region CARGAR_DATOS

    private void LimpiarGrillaCheqPen()
    {
        gvPendientes.DataSource = null;
        gvPendientes.DataBind();
    }

    private void LimpiarGrillaChequesGenerados()
    {
        gvAnularCheque .DataSource = null;
        gvAnularCheque.DataBind();
    }

    private void CargarCboEntidadFinan()
    {
        try
        {
            var dt = objTramite.ObtenerClasificador(_idConexion, "Q", 93, ref _mensajeError);

            if (dt != null && dt.Rows.Count > 0)
            {
                ddlEntFinan.DataSource = dt;
                ddlEntFinan.DataTextField = "Descripcion";
                ddlEntFinan.DataValueField = "IdDetalleClasificador";
                ddlEntFinan.DataBind();

                ddlEntFinan.Items.Insert(0, new ListItem("Seleccione valor ...", String.Empty));
                ddlEntFinan.SelectedValue = 811.ToString();//por defecto
            }
            else
            {
                Master.MensajeError("Se produjo un error al cargar el combo de Entidades Financieras", _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar las Entidades Financieras", ex.Message);
        }
    }

    private void CargarGrillaChequesAGenerar()
    {
        try
        {
            var dt = objProcesos.ListarAprobadosMes(_idConexion, "Q", ref _mensajeError, Convert.ToInt32(txtAnio.Text), Convert.ToInt32(ddlMes.SelectedValue));

            if (_mensajeError == null)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    gvPendientes.DataSource = dt;
                    gvPendientes.DataBind();

                    ibtnGenCheque.Enabled = true;
                }
                else
                {
                    gvPendientes.DataSource = null;
                    gvPendientes.DataBind();
                    ibtnGenCheque.Enabled = false;

                    Master.MensajeWarning("No se encontró ningún registro para el criterio de búsqueda.");
                }
            }
            else
            {
                Master.MensajeError(
                       "Se produjo un error en el cargado de datos para la búsqueda con la matrícula requerida.",
                       _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar la grilla de Cheques pendientes de generar", ex.Message);   
        }
    }

    private void CargarGrillaChequesGenerados()
    {
        try
        {
            var dt = objProcesos.ListadoChequesGenerados(_idConexion, ref _mensajeError, Convert.ToInt32(txtAnio.Text), Convert.ToInt32(ddlMes.SelectedValue));

            if (_mensajeError == null)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    gvAnularCheque.DataSource = dt;
                    gvAnularCheque.DataBind();
                }
                else
                {
                    gvAnularCheque.DataSource = null;
                    gvAnularCheque.DataBind();
                    Master.MensajeWarning("No se encontró ningún registro para el criterio de búsqueda.");
                }
            }
            else
            {
                Master.MensajeError(
                       "Se produjo un error en el cargado de datos para la búsqueda con la matrícula requerida.",
                       _mensajeError);
            }
        }
        catch (Exception ex )
        { 
            Master.MensajeError("Se pordujo una excepción al cargar la grilla de cheques generados", ex.Message);   
        }
    }

    #endregion

    #region EVENTOS_INTERMEDIOS

    private bool VerificarRegistroC31(int pAnio, int pMes)
    {
        try
        {
            bool continuaFlujo = false;
            var dtC31 = objProcesos.ObtieneC31(_idConexion, ref _mensajeError, pAnio, pMes);
            if (dtC31 != null && dtC31.Rows.Count == 1)
            {
                var dr = dtC31.Rows[0];
                txtC31.Text = dr["C31"].ToString();
                ibtnGenCheque.Enabled = true;

                continuaFlujo = true;
            }
            else
            {
                txtC31.Text = "";
                ibtnGenCheque.Enabled = false;
                ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('No se ha encontrado un registro de C31 para el mes " + pMes + " del año " + pAnio + "');", true);
            }
            return continuaFlujo;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al verificar el registro del C31", ex.Message);
            return false;
        }
    }

    private DataTable ListarChequesAnulados()
    {
        try
        {
            var dt = new DataTable();
            dt.Columns.Add("NumeroCheque", typeof (int));
            dt.Columns.Add("NumeroBanco", typeof(int));

            for (int i = 0; i < gvAnularCheque.Rows.Count; i++)
            {
                GridViewRow row = gvAnularCheque.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chkCheque")).Checked;

                if (isChecked)
                {
                    var dataKey = gvAnularCheque.DataKeys[i];
                    if (dataKey != null)
                    {
                        dt.Rows.Add(Convert.ToInt32(dataKey["NumeroCheque"]), Convert.ToInt32(dataKey["NumeroBanco"]));
                    }
                        
                }
            }
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterWarning .Visible = false;
        Master.imgMasterWarning.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    #endregion

  

    #region EVENTOS_PRINCIPALES

    protected void ibtnBuscarPeGenCheque_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarGrillaCheqPen();
        LimpiarMensajesMasterPage();
        try
        {
            if (VerificarRegistroC31(Convert.ToInt32(txtAnio.Text), Convert.ToInt32(ddlMes.SelectedValue)))
            {
                CargarGrillaChequesAGenerar();
                LimpiarGrillaChequesGenerados();
                ibtnAnularCheques.Enabled = false;

            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al buscar los cheques pendientes de generación", ex.Message);
        }
    }

    protected void ibtnGenCheque_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            var vNUP = objProcesos.GeneraChequePU(_idConexion, "I", ref _mensajeError,
            Convert.ToInt32(ddlEntFinan.SelectedValue), Convert.ToInt32(txtC31.Text), _hoy.Year, _hoy.Month);

            if (vNUP != 0 && _mensajeError == null)
            {
                ibtnGenCheque.Enabled = false;
                CargarGrillaChequesAGenerar();
                Master.MensajeOk("Se generó corretamente el Cheque");
            }
            else
            {
                ibtnGenCheque.Enabled = true;
                Master.MensajeError("Se produjo un error en la Generación de Cheque", _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al Generar el(los) cheque(s)", ex.Message);   
        }
          
    }

    protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarMensajesMasterPage();
        try
        {
            if (VerificarRegistroC31(Convert.ToInt32(txtAnio.Text), Convert.ToInt32(ddlMes.SelectedValue)))
            {
                CargarGrillaChequesGenerados();
                ibtnAnularCheques.Enabled = true;
                LimpiarGrillaCheqPen();
                ibtnGenCheque.Enabled = false;
            }
            else
            {
                gvAnularCheque.DataSource = null;
                gvAnularCheque.DataBind();
                ibtnAnularCheques.Enabled = false;
                Master.MensajeWarning("No se encontró ningún registro para el criterio de búsqueda.");
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al buscar los cheques generados", ex.Message);
        }
    }

    protected void ibtnAnularCheques_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            var dt = ListarChequesAnulados();

            if (dt != null && dt.Rows.Count > 0)
            {
                int anulado = objProcesos.AnularCheque(_idConexion, ref _mensajeError, dt);

                switch (anulado)
                {
                    case 1:
                        if (_mensajeError == null)
                        {
                            CargarGrillaChequesGenerados();
                            Master.MensajeOk("Se anuló correctamente los cheques seleccionados");
                        }
                        break;
                    case 0:
                        if (_mensajeError != null)
                        {
                            Master.MensajeError(
                                "No todos los cheques lograron anularse, por favor verificar desplegando nuevamente los cheques!!!",
                                _mensajeError);
                        }
                        break;
                    case -1:
                        if (_mensajeError != null)
                        {
                            Master.MensajeError(
                                "Ningun cheque se logró anular, por favor verificar desplegando nuevamente los cheques!!!",
                                _mensajeError);
                        }
                        break;
                    default:
                        Master.MensajeOk("Se produjo un inconveniente, no existe un proceso para el caso!!!");
                        break;
                }
            }
            else
            {
                Master.MensajeWarning("Debe seleccionar por lo menos un cheque para anular");
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al Anular lor cheques", ex.Message);
        }
    }

    #endregion

    
}