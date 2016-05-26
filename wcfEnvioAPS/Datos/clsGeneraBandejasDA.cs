using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEnvioAPS.Entidades;
using SQLSPExecuter;

namespace wcfEnvioAPS.Datos
{
    public class clsGeneraBandejasDA : clsEnvioAPSBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public DateTime fFechaCorte { get; set; }
        public Int32 iPageIndex { get; set; }
        public Int32 iPageSize { get; set; }
        public Int32 iRecordCountA { get; set; }
        public Int32 iRecordCount { get; set; }
        public String cClaseEnvio { get; set; }
        public String sOrderBy { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        
        /// <summary>
        /// Genera Listado Preliminar de Altas (paginado)
        /// </summary>
        /// <returns></returns>
        public bool ListadoPreliminarAltasPagDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraBandejas", "Q");
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iPageIndex", iPageIndex);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iPageSize", iPageSize);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sOrderBy", sOrderBy);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int iRecordCountATmp = 0;
                        int iRecordCountTmp = 0;
                        DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@o_iRecordCountA", ref iRecordCountATmp);
                        iRecordCountA = iRecordCountATmp;
                        ObjSPExec.ObtenerValorParametro("@o_iRecordCount", ref iRecordCountTmp);
                        iRecordCount = iRecordCountTmp;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        
        /// <summary>
        /// Genera Listado Preliminar de Altas
        /// </summary>
        /// <returns></returns>
        public bool ListadoPreliminarAltasDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraBandejas", "E");
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

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCorte", fFechaCorte);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int iRecordCountATmp = 0;
                        int iRecordCountTmp = 0;
                        DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@o_iRecordCountA", ref iRecordCountATmp);
                        iRecordCountA = iRecordCountATmp;
                        ObjSPExec.ObtenerValorParametro("@o_iRecordCount", ref iRecordCountTmp);
                        iRecordCount = iRecordCountTmp;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        
        /// <summary>
        /// Genera Bandeja Preliminares de Altas, Modificaciones, Bajas (paginado)
        /// </summary>
        /// <returns></returns>
        public bool GeneraBandejaPreliminarPagDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "EnvioMedios.PR_EnvioAPS_GeneraBandejas", "B");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCorte", fFechaCorte);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iPageIndex", iPageIndex);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iPageSize", iPageSize);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_cClaseEnvio", cClaseEnvio);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int iRecordCountATmp = 0;
                        int iRecordCountTmp = 0;
                        DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@o_iRecordCountA", ref iRecordCountATmp);
                        iRecordCountA = iRecordCountATmp;
                        ObjSPExec.ObtenerValorParametro("@o_iRecordCount", ref iRecordCountTmp);
                        iRecordCount = iRecordCountTmp;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        #endregion
    }
}