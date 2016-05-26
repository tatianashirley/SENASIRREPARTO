using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using Org.BouncyCastle.Utilities.Zlib;
using wcfInicioTramite.Tramite.Logica;
using wcfPagoUnico.Entidades;
using wcfPagoUnico.Logica;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using Panel = System.Web.UI.WebControls.Panel;
using TextBox = System.Web.UI.WebControls.TextBox;

public partial class PagoUnico_wfrmRegPagoUnico : System.Web.UI.Page
{
    private clsPUPersona objPersona = new clsPUPersona();
    private clsTramite objTramite = new clsTramite();
    private clsPUClasificador objClasif = new clsPUClasificador();
    private clsPUProcesos objProc = new clsPUProcesos();
    private int _idConexion;
    private string _mensajeError, _nivError;
    private static int _edadValidar;
    private static bool _titFallecido = false;
    const int EdadJubilacionActualVaron = 55;
    const int EdadJubilacionActualMujer = 50;
    private static bool _auto = false;
    private static string _nomFlujo;
    private static string _abrevFlujo;
    private static string _alertaFlujo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdConexion"] == null)
        {
            Response.Write("<script>window.open('LoginLDAP.aspx','_top');</script>");
            return;
        }
        else
        {
            _idConexion = (int) Session["IdConexion"];
        }

        

        if (!Page.IsPostBack)
        {
            Master.btnCerrarSesion.CausesValidation = false;
            txtFechaHojaRuta.Text = DateTime.Today.ToShortTimeString();

            CargarCboGenero();
            CargarCboEstadoCivil();
            CargarCboSector();
            CargarCboRegional();
            CargarCboTipoDoc();
            CargarCboExpedicionDoc();
            CargarListaDocTit();
            CargarListaDocDH();
            CargarCboParentesco();
        }
    }
   
    #region LIMPIAR

    private void LimpiarSolicitantes()
    {
        rbtnlstSolicitante.ClearSelection();
        for (int i = 0; i < rbtnlstSolicitante.Items.Count; i++)
        {
            rbtnlstSolicitante.Items[i].Enabled = true;
        }
    }

    private void LimpiarPaneles(Panel pPnl)
    {
        pPnl.Controls.OfType<TextBox>().ToList().ForEach(x => x.Text = string.Empty);
        txtCalcAniosInsal.Text = "0";
        txtMontoActual.Text = "0.00";
        txtTCActual.Text = "0.00";

        pPnl.Controls.OfType<CheckBox>().ToList().ForEach(x => x.Checked = false);
        pPnl.Controls.OfType<DropDownList>().ToList().ForEach(x => x.SelectedIndex = 0);
        pPnl.Controls.OfType<GridView>().ToList().ForEach(x => x.DataSource = null);
        pPnl.Controls.OfType<CheckBoxList>().ToList().ForEach(x => x.ClearSelection());
    }

    private void LimpiarMensajesMasterPage()
    {
        Master.lblMasterError.Visible = false;
        Master.imgMasterError.Visible = false;
        Master.lblMasterOk.Visible = false;
        Master.imgMasterOk.Visible = false;
    }

    private void LimpiarGrillarTitulares()
    {
        gvTitular.DataSource = null;
        gvTitular.DataBind();
    }

    #endregion

    #region CARGAR_DATOS_INICIALES

    private void CargarCboPorcentajes(DropDownList pDdl)
    {
        pDdl.Items.Insert(0, new ListItem("0.00", "0.00"));
        pDdl.Items.Insert(1, new ListItem("8.33", "8.33"));
        pDdl.Items.Insert(2, new ListItem("10.00", "10.00"));
        pDdl.Items.Insert(3, new ListItem("12.50", "12.50"));
        pDdl.Items.Insert(4, new ListItem("15.00", "15.00"));
        pDdl.Items.Insert(5, new ListItem("16.67", "16.67"));
        pDdl.Items.Insert(6, new ListItem("18.00", "18.00"));
        pDdl.Items.Insert(7, new ListItem("20.00", "20.00"));
        pDdl.Items.Insert(8, new ListItem("22.50", "22.50"));
        pDdl.Items.Insert(9, new ListItem("30.00", "30.00"));
        pDdl.Items.Insert(10, new ListItem("44.00", "44.00"));
        pDdl.Items.Insert(11, new ListItem("50.00", "50.00"));
        pDdl.Items.Insert(12, new ListItem("60.00", "60.00"));
        pDdl.Items.Insert(13, new ListItem("80.00", "80.00"));
        pDdl.Items.Insert(14, new ListItem("84.00", "84.00"));
        pDdl.Items.Insert(15, new ListItem("100.00", "100.00"));
    }

    private void CargarCboGrupoFamiliar(DropDownList pDdl)
    {
        pDdl.Items.Insert(0, new ListItem("1", "1"));
        pDdl.Items.Insert(1, new ListItem("2", "2"));
        pDdl.Items.Insert(2, new ListItem("3", "3"));
        pDdl.Items.Insert(3, new ListItem("4", "4"));
        pDdl.Items.Insert(4, new ListItem("5", "5"));
    }


    private void CargarCombosDetClasif(DropDownList pDdl, string pContenidoCombo, DataTable pDt, string pDataTextField, string pDataValueField)
    {
        try
        {
            if (pDt != null && pDt.Rows.Count > 0)
            {
                pDdl.DataSource = pDt;
                pDdl.DataTextField = pDataTextField;
                pDdl.DataValueField = pDataValueField;
                pDdl.DataBind();

                pDdl.Items.Insert(0, new ListItem("Seleccione valor ...", ""));
                pDdl.SelectedIndex = 0;
            }
            else
            {
                Master.MensajeError(_mensajeError, "Se produjo un error al cargar el combo de " + pContenidoCombo);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al recuperar los datos del combo!!!", ex.Message);
        }
    }

    private void CargarCboParentesco()
    {
        var dt = objClasif.ListarParentesco(_idConexion, "Q", null, null, ref _mensajeError, ref _nivError);
        CargarCombosDetClasif(ddlParentesco, "Parentesco", dt, "DescripcionDetalleClasificador", "IdDetalleClasificador");
    }

    private void CargarCboGenero()
    {
        var dt = objTramite.ObtenerClasificador(_idConexion, "Q", 1, ref _mensajeError);
        CargarCombosDetClasif(ddlGenero, "Género", dt, "Descripcion", "IdDetalleClasificador");
        CargarCombosDetClasif(ddlGeneroB, "Género", dt, "Descripcion", "IdDetalleClasificador");
    }

    private void CargarCboEstadoCivil()
    {
        var dt = objTramite.ObtenerClasificador(_idConexion, "Q", 3, ref _mensajeError);
        CargarCombosDetClasif(ddlEstadoCivil, "Estado Civil", dt, "Descripcion", "IdDetalleClasificador");
        CargarCombosDetClasif(ddlEstadoCivilB, "Estado Civil", dt, "Descripcion", "IdDetalleClasificador");
    }

    private void CargarCboTipoDoc()
    {
        var dt = objTramite.ObtenerClasificador(_idConexion, "Q", 4, ref _mensajeError);
        CargarCombosDetClasif(ddlTipoDoc, "Tipo Documento", dt, "Descripcion", "IdDetalleClasificador");
        CargarCombosDetClasif(ddlTipoDocB, "Tipo Documento", dt, "Descripcion", "IdDetalleClasificador");
    }

    private void CargarCboExpedicionDoc()
    {
        var dt = objTramite.ObtenerClasificador(_idConexion, "Q", 9, ref _mensajeError);
        CargarCombosDetClasif(ddlExpedido, "Expedición", dt, "Observacion", "IdDetalleClasificador");
        CargarCombosDetClasif(ddlExpedidoB, "Expedición", dt, "Observacion", "IdDetalleClasificador");
    }

    private void CargarCboSector()
    {
        var dt = objTramite.ObtenerParametros(_idConexion, "Q", "Sector", ref _mensajeError);
        CargarCombosDetClasif(ddlSector, "Sector", dt, "Descripcion", "IdSector");
    }

    private void CargarCboRegional()
    {
        var dt = objTramite.ObtenerParametros(_idConexion, "Q", "OficinaNotif", ref _mensajeError);
        CargarCombosDetClasif(ddlRegional, "Regional", dt, "DescripcionNotificacion", "IdOficina");
    }

    private void CargarListaDocumentos(DataTable pDtDoc, CheckBoxList pChkList, string pDetalle)
    {
        try
        {
            pChkList.DataSource = null;

            if (pDtDoc != null && pDtDoc.Rows.Count > 0)
            {
                pChkList.DataSource = pDtDoc;
                pChkList.DataTextField = "DescripcionDetalleClasificador";
                pChkList.DataValueField = "IdDetalleClasificador";
                pChkList.DataBind();
            }
            else
            {
                Master.MensajeError("Se produjo un error al cargar los Documentos de " + pDetalle, _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar los Documentos", ex.Message);
        }
    }

    private void CargarListaDocTit()
    {
        var dtDocTit = objClasif.ListarDocumentosTitular(_idConexion, "Q", null, null, ref _mensajeError, ref _nivError);
        CargarListaDocumentos(dtDocTit, chklstDocTitular, "Titular");
    }

    private void CargarListaDocDH()
    {
        var dtDocDH = objClasif.ListarDocumentosDH(_idConexion, "Q", null, null, ref _mensajeError, ref _nivError);
        CargarListaDocumentos(dtDocDH, chklstDocDH, "Beneficiarios");
    }

    private void CargarMontosActualizados()
    {
        var dt = new DataTable();
        if (Session["NUPTit"] != null)
        {
            dt = objProc.MontosCertificado(_idConexion, ref _mensajeError, Convert.ToInt64(Session["NUPTit"]));
            Session["dtMtoActual"] = dt;
        }

        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtMontoActual.Text = dr["MontoActual"].ToString();
            txtTCActual.Text = dr["TCActual"].ToString();
        }
        else
        {
            txtMontoActual.Text = "0.00";
            txtTCActual.Text = "0.00";
            Master.MensajeError("Se produjo un error al obtener los montos actualizados", _mensajeError);
        }
    }

    #endregion

    #region EVENTOS_DATOS_TRAMITE

    private void CargarDatosTramite(DataRow pDr)
    {
        try
        {
            txtMatricula.Text = pDr["Matricula"].ToString();
            txtTramite.Text = pDr["IdTramite"].ToString();
            txtTramiteCrenta.Text = pDr["Tramite"].ToString();
            txtCertificado.Text = pDr["NumeroCertificado"].ToString();
            txtNUA.Text = pDr["CUA"].ToString();
            txtCodAFP.Text = pDr["IdEntidadGestora"].ToString();
            ddlSector.SelectedValue = pDr["IdSector"].ToString();
            ddlRegional.SelectedValue = pDr["IdRegional"].ToString();
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar datos del trámite", ex.Message);
        }
    }

    private void CargarDatosAgrupados(DataRow pDr)
    {
        Session["NUPTit"] = pDr["NUP"].ToString(); //Para validación inicial

        if (!VerificarChequeCobrado(pDr["ESTADOCHEQUE"].ToString()))
        {
            if (!VerificarChequeRevertido(ref _mensajeError))
            {
                if (_mensajeError == null)
                {
                    habilitarFlujoAuto(false);
                }
                else
                {
                    Master.MensajeError("Se produjo un error al verificar reversión de cheque", _mensajeError);
                }
            }
            else
            {
                habilitarFlujoAuto(true);
            }

            CargarDatosTitular(pDr); //Habilitar Registrar
            CargarDatosTramite(pDr);
            CargarGrillaDH(Convert.ToInt64(pDr["NUP"]));
            CargarDatosCertificado(pDr);

            Master.MensajeOk("Se cargo correctamente el registro del titular como solicitante.");
        }
       
    }


    protected void btnBuscarMatric_Click(object sender, EventArgs e)
    {
        try
        {
            var dtTramite = objPersona.BusquedaAvanzada(_idConexion, "Q", null, null, null, null, null, txtMatricula.Text, 0, 0, null, null, 0, ref _mensajeError);

            if (_mensajeError == null)
            {
                if (dtTramite != null && dtTramite.Rows.Count > 0)
                {

                    DataRow dr = dtTramite.Rows[0];
                    
                    CargarDatosAgrupados(dr); 
                }

                else
                {
                    ibtnRegistrar.Enabled = false;
                    Master.MensajeWarning("¡No existen ningún registro con el criterio de búsqueda!");
                }
            }
            else
            {
                Master.MensajeError("Se produjo un error en el cargado de datos por búsqueda según Matrícula",
                       _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al momento de buscar por matrícula", ex.Message + " - " + ex.StackTrace);
        }      
    }

    #endregion

    #region EVENTOS_DATOS_PERSONALES_TITULAR

    public string CalcularEdadGenerico(DateTime pFecNac, DateTime pFecDesde)
    {   
        try
        {
            int anio = pFecDesde.Year - pFecNac.Year;
            if (pFecDesde < pFecNac.AddYears(anio))
                anio--;

            return anio.ToString();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }        
    }

    public string CalcularEdad(DateTime pFecNac)
    {
        return CalcularEdadGenerico(pFecNac, DateTime.Today);
    }

    private void CargarDatosTitular(DataRow pDr)
    {
        try
        {
            txtPaterno.Text = pDr["PrimerApellido"].ToString();
            txtMaterno.Text = pDr["SegundoApellido"].ToString();
            txtPrimNom.Text = pDr["PrimerNombre"].ToString();
            txtSegNom.Text = pDr["SegundoNombre"].ToString();
            txtNUP.Text = pDr["NUP"].ToString();
            txtCUA.Text = pDr["CUA"].ToString();
            if (!String.IsNullOrEmpty(pDr["CUA"].ToString()))
                Session["CUA"] = pDr["CUA"].ToString();
            else
                Session["CUA"] = 0;                           
            txtFechaNac.Text = Convert.ToDateTime(pDr["FechaNacimiento"]).ToShortDateString();
            txtEdad.Text = CalcularEdad(Convert.ToDateTime(txtFechaNac.Text));
           
            ddlGenero.SelectedValue = pDr["IdSexo"].ToString();
            ddlEstadoCivil.SelectedValue = pDr["IdEstadoCivil"].ToString();
            ddlTipoDoc.SelectedValue = pDr["IdTipoDocumento"].ToString();
            txtNumDoc.Text = pDr["NumeroDocumento"].ToString();
            ddlExpedido.SelectedValue = pDr["IdDocumentoExpedido"].ToString();
            txtCompleSEGIP.Text = pDr["ComplementoSEGIP"].ToString();

            DisponerBeneficiario(pDr["FechaFallecimiento"].ToString());           

        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo un error al cargar un dato del registro hallado", ex.Message);   
        }
    }

    private void DisponerBeneficiario(string pFecFallec)
    {
        
        if (String.IsNullOrEmpty(pFecFallec))
        {
            ibtnRegistrar.Enabled = true;
            DeshabilitarSolDH(false);
        }
        else
        {
            var vFecNac = Convert.ToDateTime(pFecFallec).ToShortDateString();
            if (vFecNac == "01/01/1900")
            {
                DeshabilitarSolDH(false);
            }
            else
            {
                txtFechaFallec.Text = vFecNac;
                DeshabilitarSolDH(true);
            }
        }
    }

    private void DeshabilitarSolDH(bool pValor)
    {
        _titFallecido = pValor;

        if (_titFallecido)
        {            
            rbtnlstSolicitante.ClearSelection();
            rbtnlstSolicitante.Items[0].Enabled = false;
            MostrarAlerta(_alertaFlujo + ".\\n\\nEl titular se encuentra fallecido.\\nSolo un derechohabiente podrá solicitar el beneficio!!!");
            
        }
        else
        {
            rbtnlstSolicitante.ClearSelection();
            rbtnlstSolicitante.Items[1].Enabled = false;
            MostrarAlerta(_alertaFlujo + ".\\n\\nEl beneficio solo puede ser solicitado por el titular!!!");
        }
    }

    protected void btnBuscarDatTit_Click(object sender, EventArgs e)
    {
        CargarGrillaTitulares();
    }

    private void CargarGrillaTitulares()
    {
        try
        {
            var dtTit = objPersona.BusquedaAvanzada(_idConexion, "Q", txtPaterno.Text, txtMaterno.Text, txtPrimNom.Text,
            txtSegNom.Text, "", "", 0, 0, txtNumDoc.Text, txtCompleSEGIP.Text, 0 , ref _mensajeError);

            if (_mensajeError == null)
            {
                if (dtTit != null && dtTit.Rows.Count > 0)
                {
                    gvTitular.DataSource = dtTit;
                    gvTitular.DataBind();
                    Master.MensajeOk("Se encontró(aron) el(los) registros según criterio de búsqueda. Debe seleccionar al titular para continuar el trámite");
                }
                else
                {
                    LimpiarGrillarTitulares();
                    Master.MensajeWarning("No se encontró ningún registro para el criterio de búsqueda.");
                }
            }
            else
            {
                Master.MensajeError(
                       "Se produjo un error en el cargado de datos por búsqueda según Datos Personales de Titular",
                       _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al momento de buscar datos del titular", ex.Message + " - " + ex.StackTrace);    
            
        }
    }
    

    protected void gvTitular_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var rowSelec = gvTitular.SelectedRow.RowIndex;
            var dataKey = gvTitular.DataKeys[rowSelec];
            if (dataKey != null)
            {
                var vNUPTit = Convert.ToInt64(dataKey.Values["NUP"]);
                var dtTit = objPersona.BusquedaNUP(_idConexion, "Q", vNUPTit, ref _mensajeError);

                if (_mensajeError == null)
                {
                    if (dtTit != null && dtTit.Rows.Count > 0)
                    {
                        DataRow dr = dtTit.Rows[0];
                        CargarDatosAgrupados(dr);
                    }
                    else
                    {
                        ibtnRegistrar.Enabled = false;
                        Master.MensajeWarning("No se recuperó ningún registro");
                    }
                }
                else
                {
                    Master.MensajeError("Se produjo un error en el cargado de la selección del titular", _mensajeError);
                }
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al momento de seleccionar el titular", ex.Message + " - " + ex.StackTrace);
        }        
    }

    protected void gvTitular_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTitular.PageIndex = e.NewPageIndex;
        CargarGrillaTitulares();
    }
   
    #endregion

    #region EVENTOS_DECLARACION_DERECHOHABIENTES

    private void CargarGrillaDH(long pNUP)
    {
        try
        {
            _mensajeError = null;
            var dtDH = objPersona.BuscaDH(_idConexion, "Q", pNUP, ref _mensajeError);
            Session["dtDH"] = dtDH;

            if (_mensajeError == null)
            {
                if (dtDH != null && dtDH.Rows.Count > 0)
                {
                    gvDH.DataSource = dtDH;
                    gvDH.DataBind();

                    HabilitaRegistrar();
                    SumarPorcentaje();
                }
                else
                {
                    gvDH.DataSource = null;
                    gvDH.DataBind();
                    Master.MensajeError("Se produjo un error en el cargado de la grilla Derechohabientes", "No se recuperó ningún registro");
                }
            }
            else
            {
                Master.MensajeError("Se produjo un error en el cargado de la grilla Derechohabientes", _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar la grilla de Derechohabientes", ex.Message + " - " + ex.StackTrace);
        }
    }

    protected void btnRegBenef_Click(object sender, EventArgs e)
    {
        try
        {
            var vIdParentesco = Convert.ToInt32(ddlParentesco.SelectedValue);
            var vNUP = Convert.ToInt64(Session["NUPTit"]);
            var vExisteConyugue = VerificarRegConyuguePrevio(vNUP, ref _mensajeError, vIdParentesco);

            switch (vExisteConyugue)
            {
                case 1:
                    var objPerBenef = new clsPUPersonaB();
                    objPerBenef.PrimerApellido = txtPaternoB.Text;
                    objPerBenef.SegundoApellido = txtMaternoB.Text;
                    objPerBenef.PrimerNombre = txtPrimNomB.Text;
                    objPerBenef.SegundoNombres = txtSegNomB.Text;
                    objPerBenef.FechaNacimiento = Convert.ToDateTime(txtFechaNacB.Text);
                    objPerBenef.FechaFallecimiento = Convert.ToDateTime("01/01/1900");
                    objPerBenef.Parentesco = vIdParentesco;
                    objPerBenef.IdSexo = ddlGeneroB.SelectedIndex;
                    objPerBenef.IdEstadoCivil = Convert.ToInt32(ddlEstadoCivil.SelectedValue);
                    objPerBenef.IdTipoDocumento = Convert.ToInt32(ddlTipoDocB.SelectedValue);
                    objPerBenef.NumeroDocumento = txtNumDocB.Text;
                    objPerBenef.DocumentoExpedido = Convert.ToInt64(ddlExpedidoB.SelectedValue);
                    objPerBenef.NUPTitular = vNUP;
                    objPerBenef.CUA = Convert.ToInt64(Session["CUA"]);
                    objPerBenef.IdEntidadGestora = 1;
                    objPerBenef.IdLocalidad = 1;
                    objPerBenef.IdPaisResidencia = 83;
                    objPerBenef.RegistroActivo = 1;
                    objPerBenef.ComplementoSEGIP = txtCompleSEGIPB.Text;

                    var vNUPresp = objPersona.RegistrarPersona(_idConexion, "I", ref objPerBenef, ref _mensajeError);

                    if (vNUPresp != 0 && _mensajeError == null)
                    {
                        txtNUP.Text = vNUPresp.ToString();
                        LimpiarPaneles(pnlDH);
                        CargarGrillaDH(Convert.ToInt64(Session["NUPTit"]));
                        Master.MensajeOk("Se registró correctamente el beneficiario");
                    }
                    else
                    {
                        Master.MensajeError("Se produjo un error al registrar el Derechohabiente", _mensajeError);
                    }

                    ScriptManager.RegisterStartupScript(Page, GetType(), "sol", "controlarSolicitante();", true);
                    break;
                case 0:
                    CargarGrillaDH(Convert.ToInt64(Session["NUPTit"]));
                    Master.MensajeError("Ya se ha registrado un CONYUGUE", "CONYUGUE registrado");
                    break;
                default:
                    CargarGrillaDH(Convert.ToInt64(Session["NUPTit"]));
                    Master.MensajeError("Se ha producido un error en la verificación de CONYUGUE", _mensajeError);
                    break;
            }
            
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al registrar un nuevo Derechohabientes", ex.Message + " - " + ex.StackTrace);
        }
    }

    private int VerificarRegConyuguePrevio(long pNUP, ref string pMsgError, int pIdParentescoNuevoDH)
    {
        try
        {
            var existe = 0;
            var respuesta = 0;
            var dtBenef = objPersona.BuscaDH(_idConexion, "Q", pNUP, ref _mensajeError);

            foreach (DataRow dr in dtBenef.Rows)
            {
                //Verificar registro de CONYUGUE previo (IdDetalleClasificador=3)
                if (Convert.ToInt32(dr["IdParentesco"]) == 3)
                {
                    existe = 1;
                    break;
                }
            }

            if (existe >= 1 && pIdParentescoNuevoDH == 3)
                respuesta = 0;
            else
                respuesta = 1;
            return respuesta;
        }
        catch (Exception ex)
        {
            pMsgError = ex.Message;
            return -1;
        }        
    }

    private DataTable ListarTablaDH()
    {
        try
        {
            var dt = new DataTable();
            dt.Columns.Add("NUPDH", typeof (long));
            dt.Columns.Add("Porcentaje", typeof(decimal));
            dt.Columns.Add("GrupoFlia", typeof (int));
            dt.Columns.Add("Receptor", typeof (bool));
            dt.Columns.Add("IdParentesco", typeof(int));
            dt.Columns.Add("RecepInt", typeof (int));
    
            for (int i = 0; i < gvDH.Rows.Count; i++)
            {
                GridViewRow row = gvDH.Rows[i];

                int vGrupFlia = Convert.ToInt32(((DropDownList)row.FindControl("ddlGrupFlia")).SelectedValue);
                decimal vPorcentaje = Convert.ToDecimal(((DropDownList) row.FindControl("ddlPorcentajes")).SelectedValue);
                bool vReceptor = ((CheckBox)row.FindControl("chkReceptorCheque")).Checked;
                int vRecepInt = Convert.ToInt32(vReceptor);
                long vNUPDH = 0;
                int vIdParentesco = 0;

                var dataKey = gvDH.DataKeys[i];
                if (dataKey != null)
                {
                    vNUPDH = (long) dataKey["NUP"];
                    vIdParentesco = (int) dataKey["IdParentesco"];
                }

                dt.Rows.Add(vNUPDH, vPorcentaje, vGrupFlia, vReceptor, vIdParentesco, vRecepInt);
            }         

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    protected void btnLimpiarBenef_Click(object sender, EventArgs e)
    {
        LimpiarPaneles(pnlDH);
        LimpiarMensajesMasterPage();
        ScriptManager.RegisterStartupScript(Page, GetType(), "sol", "controlarSolicitante();", true);     
    }

    protected void gvDH_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDH.PageIndex = e.NewPageIndex;
        CargarGrillaDH(Convert.ToInt64(Session["NUPTit"]));
    }

    #endregion

    #region EVENTOS_DATOS_CERTIFICADOS
    
    private void CargarDatosCertificado(DataRow pDr)
    {
        try
        {
            txtFecEmision.Text = Convert.ToDateTime(pDr["FechaEmision"]).ToShortDateString();
            txtCertificado.Text = pDr["NumeroCertificado"].ToString();
            txtMontoBase.Text = String.Format("{0:#.##}", pDr["MontoPU"]);
            txtTC.Text = pDr["TipoCambio"].ToString();
            txtNoCheque.Text = pDr["NumeroCheque"].ToString();
            if (!string.IsNullOrEmpty(pDr["FECHAEMISIONCHEQUE"].ToString()))
            {
                var vFecEmisionCheq = Convert.ToDateTime(pDr["FECHAEMISIONCHEQUE"]).ToShortDateString();
                if (vFecEmisionCheq == "01/01/1900")
                    txtFechaEmisionCheque.Text = "";
                else
                    txtFechaEmisionCheque.Text = vFecEmisionCheq;
            }
            else
            {
                txtFechaEmisionCheque.Text = "";    
            }
            txtHojaRuta.Text = pDr["HojaRuta"].ToString();
            if (!string.IsNullOrEmpty(pDr["FechaHojaRuta"].ToString()))
                txtFechaHojaRuta.Text = Convert.ToDateTime(pDr["FechaHojaRuta"]).ToShortDateString();
            txtEstadoCheque.Text = pDr["ESTADOCHEQUE"].ToString();
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar datos del certificado", ex.Message + " - " + ex.StackTrace);
        }
    }

    #endregion
    
    #region EVENTOS_DOCUMENTOS_PRESENTADOS

    private void RecorrerListaDocs(CheckBoxList pChkLst, DataRow pDr)
    {
        foreach (ListItem li in pChkLst.Items)
        {
            if (li.Value == pDr["IdDocumento"].ToString())
            {
                li.Selected = true;
                li.Enabled = false;
            }
        }
    }

    private void RegistrarDocumentos(CheckBoxList pChkLst, List<long> pListaNUP, ref long pNUP, ref string pMensajeError)
    {
        try
        {

            if (Request.QueryString["tpo"] == "1")
            {

                var listaChk = new List<int>();

                foreach (ListItem itemActual in pChkLst.Items)
                {
                    if (itemActual.Selected)
                    {
                        listaChk.Add(Convert.ToInt32(itemActual.Value));
                    }
                }

                foreach (long iNUP in pListaNUP)
                {
                    pNUP = objProc.RegistraDocumentos(_idConexion, "I", ref _mensajeError, listaChk,
                        Convert.ToInt64(Session["CUA"]), iNUP); //registrar solo los habilitados

                    if (_mensajeError != null)
                        pMensajeError += _mensajeError;
                    else
                        pMensajeError = null;
                }
            }
            else
            {
                pNUP = Convert.ToInt64(Session["NUPTit"]);
                pMensajeError = null;
            }

        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al cargar datos del certificado", ex.Message + " - " + ex.StackTrace);
        }        
    }


    #endregion

    #region VALIDACIONES

    /*********************************************************************
     * La Validación se retira e acuerdo a CITE: SENASIR-UCC-EM Nº 1620/15
     * para permitir que hijos mayores a 19 años puedan ser beneficiarios
     *********************************************************************/
    private bool ValidarEdadBenef()
    {
        //Validar que el derechohabiente sea mayor a 19 años a la fecha del inicio del trámite
        var continuar = false;

        if (ddlParentesco.SelectedIndex != 3) //CONYUGUE
        {
            if (_edadValidar <= 19)
                continuar = true;
        }
        else
        {
            continuar = true;
        }

        return continuar;
    }

    /*********************************************************************
    * Validar que el titular tenga minimante 55 años
    *********************************************************************/
    private bool ValidarEdadTitular()
    {
        try
        {
            var vEdadJubilacionActual = 0;
            switch (ddlGenero.SelectedValue)
            {
                case "1": //FEMENINO
                    vEdadJubilacionActual = EdadJubilacionActualMujer;
                    break;
                case "2": //MASCULINO
                    vEdadJubilacionActual = EdadJubilacionActualVaron;
                    break;
            }

            var edadActual = Convert.ToInt32(txtEdad.Text);
            var continuar = false;
            if (!chkAniosInsalubre.Checked)
            {
                if (edadActual >= vEdadJubilacionActual)
                    continuar = true;
            }
            else
            {
                var edadConAniosInsalubres = Convert.ToInt32(txtEdadJubilacion.Text);
                if (edadConAniosInsalubres >= vEdadJubilacionActual - 5)
                    continuar = true;
            }
            return continuar;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al validar la edad del titular", ex.Message + " - " + ex.StackTrace);
            return false;
        }
      
    }


    /*********************************************************************
     * Validar que el chuque este Cobrado para no permitir el tramite
    *********************************************************************/
    private bool VerificarChequeCobrado(string pEstadoCheque)
    {
        if (pEstadoCheque == "COBRADO")
        {
            MostrarAlerta("El cheque ya ha sido COBRADO, el trámite ya no es válido!!");
            return true;
        }
        else
        {
            return false;
        }
    }

   

    private void habilitarFlujoAuto(bool pAuto)
    {
        ibtnRegistrar.Enabled = true;
        //
        tcPU.Enabled = false;
        pnlBotones.Enabled = false;
        //
        if (!pAuto)
        {
            

            if (Request.QueryString["tpo"] == "1")
            {

                _nomFlujo = "Registro de la Pre-Solicitud de Pago Único";
                _abrevFlujo = "N";
                lblTitulo.Text = _nomFlujo;
                ibtnRegistrar.ImageUrl = "~/Imagenes/plomoRegistrar.png";
                ibtnRegistrar.ValidationGroup = "PreSol";
                tPnlDocus.Visible = true;
                pnlDatExtPreSol.Visible = true;

                rvPorcentaje.ValidationGroup = "PreSol";
                rvReceptor.ValidationGroup = "PreSol";
                ibtnRegistrar.ValidationGroup = "PreSol";


                tcPU.Enabled = true;
                pnlBotones.Enabled = true;
            }
        }
        else
        {
            

            if (Request.QueryString["tpo"] == "2")
            {

                _nomFlujo = "Vínculo del beneficiario-cheque para el 'Auto' de Pago Único";
                _abrevFlujo = "A";
                lblTitulo.Text = _nomFlujo;
                ibtnRegistrar.ImageUrl = "~/Imagenes/plomoRegistrarAuto.png";
                ibtnRegistrar.ValidationGroup = "Auto";
                tPnlDocus.Visible = false;
                pnlDatExtPreSol.Visible = false;

                rvPorcentaje.ValidationGroup = "Auto";
                rvReceptor.ValidationGroup = "Auto";
                ibtnRegistrar.ValidationGroup = "Auto";

                CargarMontosActualizados();

                tcPU.Enabled = true;
                pnlBotones.Enabled = true;
            }

        }

    

    }
    

    /*********************************************************************
     * Validar reversión de cheque para determinar si existe 
     * no genera Pre-Solicitud sino señalar elaboración de "Auto"
    *********************************************************************/
    private bool VerificarChequeRevertido(ref string pMensajeError)
    {
        var contiFlujoPreSol = false;
        
        if (objProc.ChequeRevertido(_idConexion, ref pMensajeError, Convert.ToInt64(Session["NUPTit"])))
        {
            if (pMensajeError == null)
            {
                contiFlujoPreSol = true;
                _alertaFlujo = "El cheque ya ha sido REVERTIDO, el trámite debe generar un Auto";   
             
            }
        }
        else
        {
            _alertaFlujo = "Trámite listo para Pre-Solicictud";
        }
        return contiFlujoPreSol;
    }

    private bool ValidarDatosFinal()
    {
        try
        {
            var continuarFlujo = false;

            if (ValidarEdadTitular())
            {
                continuarFlujo = true;
            }
            else
            {   
                Master.MensajeWarning("El titular no cumple aún la edad para obtener el beneficio.");
            }

            return continuarFlujo;
        }

        catch (Exception ex)
        {
            Master.MensajeError("Se pordujo una excepción al validar el beneficio!", ex.Message);
            return false;
        }
    }

    private int ContarReceptor(DataTable pDt)
    {
        var eRecep = pDt.AsEnumerable();

        var v2 = eRecep
            .GroupBy(x => x.Field<Int32>("GrupoFlia"))
            .Where(g => g.Sum(w => w.Field<Int32>("RecepInt")) != 1)
            .Select(z => new { GrupoFlia = z.Key, Suma = z.Sum(w => w.Field<Int32>("RecepInt")) }).ToArray();

        return v2.Count();
    }

    private int ContarPorcentajeConyugue(DataTable pDt)
    {
        var eRecep = pDt.AsEnumerable();
        var v1 = eRecep
            .Where(x => x.Field<Int32>("IdParentesco") == 3 && x.Field<decimal>("Porcentaje") < 50)
            .Select(x => x);

        return v1.Count();
    }

    protected void cvDocDH_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (rbtnlstSolicitante.SelectedIndex == 1)
            args.IsValid = ValidarListaDocs(chklstDocDH);

        ScriptManager.RegisterStartupScript(Page, GetType(), "sol", "controlarSolicitante();", true);
    }

    protected void cvDocTit_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (rbtnlstSolicitante.SelectedIndex == 0)
            args.IsValid = ValidarListaDocs(chklstDocTitular);

        ScriptManager.RegisterStartupScript(Page, GetType(), "sol", "controlarSolicitante();", true);
    }

    /***********************************************************************************
     * Segun manual de Procedimientos SENASIR/UCC/P/305 v.2, se validaron los documentos
     * *********************************************************************************/

    private bool ValidarListaDocs(CheckBoxList pChkLst)
    {
        try
        {
            var cont = 0;

            foreach (ListItem itemActual in pChkLst.Items)
            {
                var vValor = itemActual.Value;
                if (itemActual.Selected)
                {
                    if (vValor != "31406")
                        cont++;
                }
            }

            if (cont == pChkLst.Items.Count - 1)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción al validar la edad del titular", ex.Message + " - " + ex.StackTrace);
            return false;
        }
    }

    #endregion

    #region EVENTOS_LLAMADAS_JAVASCRIPTS

    private void MostrarAlerta(string pMensaje)
    {
        ScriptManager.RegisterStartupScript(Page, GetType(), "alert", "alert('" + pMensaje + "');", true); 
    }

    private void HabilitaRegistrar()
    {
        ScriptManager.RegisterStartupScript(Page, GetType(), "reg", "habilitaRegistrar();", true);
    }

    private void SumarPorcentaje()
    {
        ScriptManager.RegisterStartupScript(Page, GetType(), "sum", "sumarPorcentajes();", true);
    }

    #endregion

    #region EVENTOS_PRINCIPALES

    private void RegistrarPreSolictud(CheckBoxList pChkList)
    {
        try
        {
            var dt = ListarTablaDH();

            var listaNUPs = new List<long>();
            var solicitante = string.Empty;
            var continuarFlujo = false;

            if (rbtnlstSolicitante.SelectedIndex == 0)
            {
                solicitante = "TI";
                listaNUPs.Add(Convert.ToInt64(txtNUP.Text));
            }
            else
            {
                solicitante = "DH";
                foreach (DataRow dr in dt.Rows)
                {
                    listaNUPs.Add((long) dr["NUPDH"]);
                }
            }

            long vNUP = 0;

            RegistrarDocumentos(pChkList, listaNUPs, ref vNUP, ref _mensajeError);

            if (vNUP != 0 && _mensajeError == null)
            {
                if (solicitante == "DH")
                {
                    
                    if (ContarReceptor(dt) == 0)
                    {
                        if (ContarPorcentajeConyugue(dt) == 0)
                            continuarFlujo = true;
                        else
                            Master.MensajeError("El porcentaje del Conyugue debe ser igual o mayor al 50%",
                                "El porcentaje del Conyugue debe ser igual o mayor al 50%");
                    }
                    else
                    {
                        Master.MensajeError("Debe existir un Receptor de Cheque por Grupo Familiar",
                            "Existe mas de un Recpetor de Cheque por Grupo Familiar");
                    }
                    
                }
                else
                {
                    continuarFlujo = true;
                }

                if (continuarFlujo)
                {
                    dt.Columns.Remove("IdParentesco");
                    dt.Columns.Remove("RecepInt");

                    vNUP = objProc.ActualizaCertificado(_idConexion, "U", ref _mensajeError,
                        Convert.ToInt64(Session["NUPTit"]),
                        txtHojaRuta.Text, Convert.ToInt64(txtTramite.Text), Convert.ToInt32(txtCertificado.Text),
                        Convert.ToInt64(txtCalcAniosInsal.Text), solicitante, dt, _abrevFlujo);

                    if (vNUP != 0 && _mensajeError == null)
                    {
                        ibtnImprimir.Enabled = true;
                        Master.MensajeOk("Se ha registrado correctamente el " + _nomFlujo);
                        ibtnRegistrar.Enabled = false;
                    }
                    else
                    {
                        ibtnRegistrar.Enabled = true;
                        ibtnImprimir.Enabled = false;
                        Master.MensajeError("Se produjo un error en el " + _nomFlujo, _mensajeError);
                    }
                }
            }
            else
            {
                ibtnRegistrar.Enabled = true;
                ibtnImprimir.Enabled = false;
                Master.MensajeError("Se produjo en error al registrar los documentos seleccionados", _mensajeError);
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError("Se produjo una excepción en el " + _nomFlujo, ex.Message + " - " + ex.StackTrace);
        }
    }

    protected void ibtnLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarPaneles(pnlTram);
        LimpiarPaneles(pnlDatTit);
        LimpiarGrillarTitulares();
        LimpiarPaneles(pnlDH);
        CargarGrillaDH(-1);
        LimpiarPaneles(pnlDatCertificado);
        LimpiarPaneles(pnlDatExtPreSol);
        LimpiarPaneles(pnlDocus);
        LimpiarMensajesMasterPage();
        LimpiarSolicitantes();
        
        _titFallecido = false;
        ibtnRegistrar.Enabled = false;
        tcPU.Enabled = true;
        
        tPnlBenef.Visible = true;
        tPnlBenef.Enabled = true;
        
        Master.MensajeOk("Se limpió corectamente los registros.");

        
    }
  
    protected void ibtnRegistrar_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            if (ValidarDatosFinal())
            {   

                if (rbtnlstSolicitante.SelectedIndex == 0)
                {
                    RegistrarPreSolictud(chklstDocTitular);
                }
                else
                {
                    RegistrarPreSolictud(chklstDocDH);
                }
            }
        }
    }

    protected void ibtnImprimir_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["MatriculaTit"] = txtMatricula.Text;
            Session["NumDocPU"] = txtNumDoc.Text;
            if (_abrevFlujo != "A")
            {
                Response.Redirect("wfrmReportesPU.aspx?rpt=1");
            }
            else
            {
                Response.Redirect("wfrmReportesPU.aspx?rpt=5");
            }
        }
        catch (Exception ex)
        {
            Master.MensajeError(
                "Se produjo una excepción al enviar a la página de reportes de la(s) Pre-Solicitud(es)",
                ex.Message + " - " + ex.StackTrace);
        }
    }

    #endregion

    #region EVENTOS_SECUNDARIOS
    
    protected void gvDH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int fila = e.Row.RowIndex;

            DropDownList ddlPorcentajes = (e.Row.FindControl("ddlPorcentajes") as DropDownList);
            CargarCboPorcentajes(ddlPorcentajes);
            
            DropDownList ddlGrupFlia = (e.Row.FindControl("ddlGrupFlia") as DropDownList);
            CargarCboGrupoFamiliar(ddlGrupFlia);

            CheckBox chkReceptorCheque = (e.Row.FindControl("chkReceptorCheque") as CheckBox);
            
            if (Session["dtDH"] != null)
            {
                var dtDH = (DataTable)Session["dtDH"];
                ddlPorcentajes.SelectedValue = dtDH.Rows[fila]["Porcentaje"].ToString();
                ddlGrupFlia.SelectedValue = dtDH.Rows[fila]["GrupoFamiliar"].ToString();
                chkReceptorCheque.Checked = (bool) dtDH.Rows[fila]["ReceptorCheque"];
            }
        }
    }
   
    #endregion
    
}