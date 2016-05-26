using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using SQLSPExecuter;

namespace wcfReprocesos.Datos
{
    public class clsRenumeraDA : clsReprocesosBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public Int32 iNroFormularioRepro { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Int64 iIdTramite { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdOficinaArea { get; set; }
        public Int32 iNroAsignacion { get; set; }
        public Int32 iIdUsuarioImpresion { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iNuevoNumeroCertificado { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        /// <summary>
        /// Obtiene Certificados pertenecientes a un tramite
        /// </summary>
        /// <returns></returns>
        public bool ObtieneCertificadosTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_Renumera", "B");
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

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
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
        /// Obtiene Datos de Certificado
        /// </summary>
        /// <returns></returns>
        public bool ObtieneDatosCertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_Renumera", "C");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "C");
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
        /// Renumera Certificados
        /// </summary>
        /// <returns></returns>
        public bool RenumeraCertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_Renumera", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroFormularioRepro", iNroFormularioRepro);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroAPS", bRegistroAPS);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficina", iIdOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficinaArea", iIdOficinaArea);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroAsignacion", iNroAsignacion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuarioImpresion", iIdUsuarioImpresion);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int iNuevoNumeroCertificadoTmp = 0;
                        DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@o_iNuevoNumeroCertificado", ref iNuevoNumeroCertificadoTmp);
                        iNuevoNumeroCertificado = iNuevoNumeroCertificadoTmp;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }
        
        /// <summary>
        /// Obtiene Bandeja de Certificados Asignados por Oficina
        /// </summary>
        /// <returns></returns>
        public bool ObtieneBandejaCertificadosAsignadosOficinaDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_Renumera", "Q");
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

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficina", iIdOficina);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdOficinaArea", iIdOficinaArea);
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

        #endregion
    }
}