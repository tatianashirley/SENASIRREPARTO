using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using SQLSPExecuter;

using System.Threading;
using System.Globalization;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace wcfEnvioAPS.Datos
{
    public class clsGeneraMediosDA : clsEnvioAPSBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public String sCodigoActualizacion { get; set; }
        public String sNumeroEnvio { get; set; }
        public Int32 iIdEntidadGestora { get; set; }

        public Int32 iNumeroCite { get; set; }
        public DateTime fFechaCite { get; set; }			  
        public DateTime fFechaRecepcion { get; set; }
		public String sArchivoEnvioNombre { get; set; }	  
        public String sArchivoEnvioContTipo { get; set; }	  
        public Int64 iArchivoEnvioLongitud { get; set; }
        public byte[] vArchivoEnvioDatos { get; set; }
        public String sArchivoEnvioCRCNombre { get; set; }	  
        public byte[] vArchivoEnvioCRCDatos { get; set; }
        public String sUsuario { get; set; }
        public Int32 iRegistroActivo { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        Database db = null;
        public clsGeneraMediosDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        /// <summary>
        /// Busca datos de un Certificado
        /// </summary>
        /// <returns></returns>
        public bool BuscaDatosCertificado()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraMedios", "B");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }                
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Busca R.A. y Fecha R.A.
        /// </summary>
        /// <returns></returns>
        public bool BuscaRAyFecha()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraMedios", "V");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodigoActualizacion", sCodigoActualizacion);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Obtiene la Bandeja de EnviosAPS
        /// </summary>
        /// <returns></returns>
        public bool ObtieneBandejaEnviosAPS()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraMedios", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Genera Datos para Archivo en Medios Magneticos de EnvioAPS
        /// </summary>
        /// <returns></returns>
        public bool AltaGeneraMediosMagDA()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraMedios", "G");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "G");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidadGestora", iIdEntidadGestora);

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Adicionar Archivo de Envios y CRC para un Envio determinado
        /// </summary>
        /// <returns></returns>
        public bool AdicionaMedioEnvioAPS2DA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraMedios", "H");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "H");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodigoActualizacion", sCodigoActualizacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidadGestora", iIdEntidadGestora);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroCite", iNumeroCite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCite", fFechaCite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaRecepcion", fFechaRecepcion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sArchivoEnvioNombre", sArchivoEnvioNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sArchivoEnvioContTipo", sArchivoEnvioContTipo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iArchivoEnvioLongitud", iArchivoEnvioLongitud);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_vArchivoEnvioDatos", vArchivoEnvioDatos);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sArchivoEnvioCRCNombre", sArchivoEnvioCRCNombre);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_vArchivoEnvioCRCDatos", vArchivoEnvioCRCDatos);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sUsuario", sUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroActivo", iRegistroActivo);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Establece si el Numero de Envio tiene generado el Medio
        /// </summary>
        /// <returns></returns>
        public Boolean NumeroEnvioTieneMedioDA(string Value1)
        {
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DbCommand objCommand = db.GetSqlStringCommand("SELECT @result = EnvioMedios.FN_NumeroEnvioTieneMedio(@Value1);");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            db.AddInParameter(objCommand, "@Value1", DbType.String, Value1); //@Value1
            //db.AddInParameter(objCommand, "@Value2", DbType.String, Param2Value); //@Value2
            db.AddOutParameter(objCommand, "@result", DbType.Boolean, 0);
            db.ExecuteNonQuery(objCommand);
            return (Boolean)(db.GetParameterValue(objCommand, "@result"));
        }

        /// <summary>
        /// Lista las Entidades Gestoras
        /// </summary>
        /// <returns></returns>
        public DataTable ObtieneEntidadesGestorasDA()
        {
            DbCommand objCommand = db.GetSqlStringCommand("SELECT * FROM EnvioMedios.FN_ObtieneEntidadesGestoras()");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            DataTable objDataTable = new DataTable();
            objDataTable.Load(db.ExecuteReader(objCommand));

            return objDataTable;
        }

        /// <summary>
        /// Adicionar Archivo de Envios y CRC para un Envio determinado
        /// </summary>
        /// <returns></returns>
        public void AdicionaMedioEnvioAPSDA()
        {
            string o_sMensajeError="";
            DbCommand objCommand = db.GetStoredProcCommand("EnvioMedios.PR_AdicionaMedioEnvioAPS", sNumeroEnvio, iIdEntidadGestora, iNumeroCite, fFechaCite, fFechaRecepcion, sArchivoEnvioNombre, sArchivoEnvioContTipo, iArchivoEnvioLongitud, vArchivoEnvioDatos, sArchivoEnvioCRCNombre, vArchivoEnvioCRCDatos, sUsuario, iRegistroActivo, o_sMensajeError);
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            DataTable objDataTable = new DataTable();
            objDataTable.Load(db.ExecuteReader(objCommand));
            o_sMensajeError = Convert.ToString(db.GetParameterValue(objCommand, "o_sMensajeError"));
        }

        /// <summary>
        /// Remite Altas
        /// </summary>
        /// <returns></returns>
        public bool RemiteAltasDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_RemiteAltas", "P");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "P");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Obtiene Envios Cerrados pero no Remitidos
        /// </summary>
        /// <returns></returns>
        public bool ObtieneEnviosCerradosNoRemitidosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraMedios", "J");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "J");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sCodigoActualizacion", sCodigoActualizacion);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        #endregion
    }
}