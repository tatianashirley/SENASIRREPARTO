using System;
using System.Data;
using wcfInicioTramite.Tramite.Datos;
using wcfInicioTramite.Tramite.Entidades;

namespace wcfInicioTramite.Tramite.Logica
{
    public class clsTramite : clsTramiteBE
    {
        clsTramiteDA ObjTramiteDA = new clsTramiteDA();
        //Obtener parametros para el tramite
        public DataTable ObtenerParametros(int iIdConexion, string cOperacion, string sParametro, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.ObtenerParametros(iIdConexion, cOperacion, sParametro, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //Obtener clasificadores para el tramite
        public DataTable ObtenerClasificador(int iIdConexion, string cOperacion, int iTabla, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.ObtenerClasificador(iIdConexion, cOperacion, iTabla, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //Obtener clasificadores por descripcion para el tramite
        public DataTable ObtenerClasificadorPorDescripcion(int iIdConexion, string cOperacion, int iTipo, string sDescripcion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.ObtenerClasificadorPorDescripcion(iIdConexion, cOperacion, iTipo, sDescripcion, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //buscar pais para el tramite
        public DataTable BuscarPaises()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.Pais = this.Pais;
            if (ObjTramiteDA.BuscarPais())
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                return (null);
            }
        }

        //buscar localidades para el tramite
        public DataTable BuscarLocalidades()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.Localidad = this.Localidad;
            if (ObjTramiteDA.BuscarLocalidad())
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                return (null);
            }
        }

        //buscar empresas para el tramite
        public DataTable BuscarEmpresas(int iIdConexion, string cOperacion, string sNombreEmpresa, string sRucEmpresa, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.BuscarEmpresa(iIdConexion, cOperacion, sNombreEmpresa, sRucEmpresa, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //Validar CUA
        public DataTable ValidarCUA()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.PrimerApellido = this.PrimerApellido;
            ObjTramiteDA.SegundoApellido = this.SegundoApellido;
            ObjTramiteDA.Nombre = this.Nombre;
            ObjTramiteDA.SegundoNombre = this.SegundoNombre;
            ObjTramiteDA.NumeroDocumento = this.NumeroDocumento;
            ObjTramiteDA.Nua = this.Nua;
            ObjTramiteDA.Sexo = this.Sexo;
            ObjTramiteDA.Matricula = this.Matricula;
            if (ObjTramiteDA.ValidarCUA())
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                return (null);
            }
        }

        //Validar Inicio
        public DataTable ValidarInicio()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.PrimerApellido = this.PrimerApellido;
            ObjTramiteDA.SegundoApellido = this.SegundoApellido;
            ObjTramiteDA.Nombre = this.Nombre;
            ObjTramiteDA.NumeroDocumento = this.NumeroDocumento;
            ObjTramiteDA.Nua = this.Nua;
            ObjTramiteDA.Matricula = this.Matricula;
            if (ObjTramiteDA.ValidarInicio())
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                return (null);
            }
        }

        //Validar Inicio
        public DataTable ObtenerInicioTramite()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            ObjTramiteDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            if (ObjTramiteDA.ObtenerInicioTramite())
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                return (null);
            }
        }

        //Registrar Tramite 
        public long RegistrarTramite(int iIdConexion, string cOperacion, ref clsTramite objTramite, ref string sMensajeError)
        {
            if (ObjTramiteDA.RegistrarTramite(iIdConexion, cOperacion, ref objTramite, ref sMensajeError))
            {
                return objTramite.IdTramite;
            }
            else
            {
                return 0;
            }
        }

        //Validar proceso automatico
        public bool ValidarProcesoAutomatico(int iIdConexion, string cOperacion, long iIdTramite, ref int bValidoManual, ref string sMensajeValidacion, ref string sMensajeError)
        {
            if (ObjTramiteDA.ValidarProcesoAutomatico(iIdConexion, cOperacion, iIdTramite, ref bValidoManual, ref sMensajeValidacion, ref sMensajeError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Registrar Tramite FFAA
        public string RegistrarTramiteFFAA(int iIdConexion, string cOperacion, string sNUA, int iIdContinuo, long iIdTramite, string sObservaciones, ref string sMensajeError)
        {
            string sDetalleTramite = "";
            if (ObjTramiteDA.RegistrarTramiteFFAA(iIdConexion, cOperacion, sNUA, iIdContinuo, iIdTramite, sObservaciones, ref sDetalleTramite, ref sMensajeError))
            {
                return sDetalleTramite;
            }
            else
            {
                return "";
            }
        }

        //Obtener datos reporte para el tramite
        public DataTable ObtenerDatosReporte(int iIdConexion, string cOperacion, long IdTramite, string sTipoInf, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.ObtenerDatosReporte(iIdConexion, cOperacion, IdTramite, sTipoInf, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //Obtener datos reporte para el tramite
        public DataTable BuscarTramite(int iIdConexion, string cOperacion, string iIdTramite, int iIdGrupoBeneficio, string sPrimerNombre, string sSegundoNombre, string sPrimerApellido, string sSegundoApellido, string sNumeroDocumento, string sCUA, string sMatricula, string sEstadoTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.BuscarTramite(iIdConexion, cOperacion, iIdTramite, iIdGrupoBeneficio, sPrimerNombre, sSegundoNombre, sPrimerApellido, sSegundoApellido, sNumeroDocumento, sCUA, sMatricula, sEstadoTramite, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //Obtener datos reporte para el tramite
        public DataTable BuscarTramiteReparto(int iIdConexion, string cOperacion, String iIdTramite, string sPrimerNombre, string sSegundoNombre, string sPrimerApellido, string sSegundoApellido, string sNumeroDocumento, string sCUA, string sMatricula, string sEstadoTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.BuscarTramiteReparto(iIdConexion, cOperacion, iIdTramite, sPrimerNombre, sSegundoNombre, sPrimerApellido, sSegundoApellido, sNumeroDocumento, sCUA, sMatricula, sEstadoTramite, ref sMensajeError, ref DSetTmp))
            {
                return ((DSetTmp != null && DSetTmp.Tables != null && DSetTmp.Tables.Count > 0) ? DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }

        //Obtener datos reporte para el tramite
        public bool RenunciaAutomatica(int iIdConexion, string cOperacion, long IdTramite, int IdGrupoBeneficio, string sObservaciones, ref long lIdTramite, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjTramiteDA.RenunciaTramite(iIdConexion, cOperacion, IdTramite, IdGrupoBeneficio, sObservaciones, ref lIdTramite, ref sMensajeError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Iniciar Tramite en el workflow
        public bool IniciarTramite(int iIdConexion, string cOperacion, ref clsTramite objTramite, ref string sMensajeError)
        {
            if (ObjTramiteDA.IniciarTramite(iIdConexion, cOperacion, ref objTramite, ref sMensajeError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Modificar oficina notificacion
        public bool ModificarOficinaNotificacion()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            ObjTramiteDA.IdGrupoBeneficio = this.IdGrupoBeneficio;
            ObjTramiteDA.IdOficinaNotificacion = this.IdOficinaNotificacion;
            ObjTramiteDA.Observaciones = this.Observaciones;
            if (ObjTramiteDA.ModificarOficina())
            {
                this.sRespuesta = true;
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                this.sRespuesta = false;
            }
            return sRespuesta;
        }

        //Obtener Clasificadores SSLP
        public DataTable ObtenerClasificadorSSLP()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdSector = this.IdSector;
            if (ObjTramiteDA.ObtenerClasificadorSSLP())
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                this.sMensajeError = ObjTramiteDA.sMensajeError;
                return (null);
            }
        }

        //Validar control estados
        public bool ValidarControlEstados(ref string sURL)
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            if (ObjTramiteDA.ControlEstados(ref sURL))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Validar flujo tramite
        public bool FlujoTramite()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            ObjTramiteDA.Tipo = this.Tipo;
            this.sRespuesta = ObjTramiteDA.FlujoTramiteDA();
            this.sMensajeError = ObjTramiteDA.sMensajeError;
            return this.sRespuesta;
        }

        //Validar Consulta tramite
        public DataTable ConsultaTramite()
        {
            ObjTramiteDA.iIdConexion = this.iIdConexion;
            ObjTramiteDA.cOperacion = this.cOperacion;
            ObjTramiteDA.IdTramite = this.IdTramite;
            ObjTramiteDA.Tipo = this.Tipo;
            this.sRespuesta = ObjTramiteDA.ConsultaTramiteDA();
            this.sMensajeError = ObjTramiteDA.sMensajeError;
            if (this.sRespuesta)
            {
                return (ObjTramiteDA.DSetTmp != null && ObjTramiteDA.DSetTmp.Tables != null && ObjTramiteDA.DSetTmp.Tables.Count > 0 ? ObjTramiteDA.DSetTmp.Tables[0] : null);
            }
            else
            {
                return (null);
            }
        }
    }
}