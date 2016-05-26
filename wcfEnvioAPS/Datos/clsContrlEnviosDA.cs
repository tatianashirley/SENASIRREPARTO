using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using SQLSPExecuter;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace wcfEnvioAPS.Datos
{
    public class clsContrlEnviosDA : clsEnvioAPSBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public String sNumeroEnvio { get; set; }
        public DateTime fFechaCorte { get; set; }
        public Int32 iIdEntidad { get; set; }
        public Int32 iNumeroCite { get; set; }
        public DateTime fFechaCite { get; set; }
        public DateTime fFechaRecepcion { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        Database db = null;
        public clsContrlEnviosDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        /// <summary>
        /// Lista Numeros de Envios Registrados APS
        /// </summary>
        /// <returns></returns>
        public bool ListaNumeroEnviosRegistradosAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "L");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "L");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
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
        /// Lista Envios y Detalles
        /// </summary>
        /// <returns></returns>
        public bool SelectEnvioDetalleAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "E");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "E");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
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
        /// Lista Archivos Medios Enviados
        /// </summary>
        /// <returns></returns>
        public bool ListaMediosEnviadosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCorte", fFechaCorte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidad", iIdEntidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
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
        /// Tramites Envio de Medios Detalle
        /// </summary>
        /// <returns></returns>
        public bool TramitesEnvioDeMediosDetalleDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "T");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "T");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidad", iIdEntidad);
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
        /// Obtiene una tupla específica de MedioEnvioAPS
        /// </summary>
        /// <returns></returns>
        public bool GetRowMedioEnvioAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "R");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "R");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidad", iIdEntidad);
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
        /// Actualiza Envios Medios Cites
        /// </summary>
        /// <returns></returns>
        public bool ActualizaCitesEnvioAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "S");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidad", iIdEntidad);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroCite", iNumeroCite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCite", fFechaCite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaRecepcion", fFechaRecepcion);
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
        /// CIERRE de Envio
        /// </summary>
        /// <returns></returns>
        public bool CierreEnvioAPSDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "U");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
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
        /// rptCtrlCites_Detalle01
        /// </summary>
        /// <returns></returns>
        public bool CtrlCites_Detalle01DA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "W");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "W");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                //bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
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
        /// Remisión de Tramites a Archivo Central
        /// </summary>
        /// <returns></returns>
        public bool RemisionDeTramitesDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_ControlEnvios", "Z");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Z");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNumeroEnvio", sNumeroEnvio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdEntidad", iIdEntidad);
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

        public DataTable ListaEntidadesDA(int IdTipoClasificador)
        {
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DbCommand objCommand = db.GetSqlStringCommand("SELECT IdDetalleClasificador,CodigoDetalleClasificador,DescripcionDetalleClasificador FROM Clasificador.DetalleClasificador WHERE IdTipoClasificador = @IdTipoClasificador");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            db.AddInParameter(objCommand, "@IdTipoClasificador", DbType.Int32, IdTipoClasificador); //@IdConexion
            //db.AddInParameter(objCommand, "@Value2", DbType.String, Param2Value); //@Value2
            DataTable objDataTable = new DataTable();
            objDataTable.Load(db.ExecuteReader(objCommand));
            return objDataTable;
        }
        public DataTable RemisionEnviosAPS_ArchivoCentralDA(Int64 iIdConexion,string sNumeroEnvio,int iIdEntidad)
        {
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DbCommand objCommand = db.GetSqlStringCommand("SELECT * FROM EnvioMedios.FN_RemisionEnviosAPS_ArchivoCentral(@iIdConexion,@sNumeroEnvio,@iIdEntidad)");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            db.AddInParameter(objCommand, "@iIdConexion", DbType.Int64, iIdConexion); 
            db.AddInParameter(objCommand, "@sNumeroEnvio", DbType.String, sNumeroEnvio);
            db.AddInParameter(objCommand, "@iIdEntidad", DbType.Int32, iIdEntidad); //@iIdEntidad

            //db.AddInParameter(objCommand, "@Value2", DbType.String, Param2Value); //@Value2
            DataTable objDataTable = new DataTable();
            objDataTable.Load(db.ExecuteReader(objCommand));
            return objDataTable;
        }
        #endregion
    }
}