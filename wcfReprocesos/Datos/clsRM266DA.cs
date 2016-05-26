using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using SQLSPExecuter;

namespace wcfReprocesos.Datos
{
    public class clsRM266DA : clsReprocesosBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public Int32 iNroFormularioRepro { get; set; }
        public String iNumeroResolucion { get; set; }
        public DateTime? fFechaResolucion { get; set; }
        public DateTime fFechaNacimientoNueva { get; set; }
        public String sMatriculaNueva { get; set; }
        public Int32 iRes { get; set; }
        public Int64 iNUP { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Int64 iIdTramite { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdOficinaArea { get; set; }
        public Int32 iNroAsignacion { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iNoFormularioCalculo { get; set; }
        public Int32 iIdTipoFormularioCalculo { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iNuevoNumeroCertificado { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        
        /// <summary>
        /// Obtiene Datos de una Persona
        /// </summary>
        /// <returns></returns>
        public bool ObtieneDatosPersonaDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_RM266", "A");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "A");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
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
        /// Obtiene Certificados pertenecientes a un tramite
        /// </summary>
        /// <returns></returns>
        public bool ObtieneCertificadosTramiteDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_RM266", "B");
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
        /// Anula Certificado Original
        /// </summary>
        /// <returns></returns>
        public bool AnulaCertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_RM266", "E");
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

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroFormularioRepro", iNroFormularioRepro);
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
        /// Modifica Fecha de Nacimiento a través de Novedades REPROCESO
        /// </summary>
        /// <returns></returns>
        public bool ModificaFechaNacimientoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_RM266", "F");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "F");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNoFormularioCalculo", iNoFormularioCalculo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoFormularioCalculo", iIdTipoFormularioCalculo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroResolucion", iNumeroResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaResolucion", fFechaResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaNacimientoNueva", fFechaNacimientoNueva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatriculaNueva", sMatriculaNueva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroFormularioRepro", iNroFormularioRepro);
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
        /// Modifica Fecha de Nacimiento a través de Novedades Tramite sin Certificado Impreso
        /// </summary>
        /// <returns></returns>
        public bool ModFechaNacimientoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_RM266", "G");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = false;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "G");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroResolucion", iNumeroResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaResolucion", fFechaResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaNacimientoNueva", fFechaNacimientoNueva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sMatriculaNueva", sMatriculaNueva);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
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
        /// RM266 Inserta Nuevo Certificado Recalculado
        /// </summary>
        /// <returns></returns>
        public bool ProcesaNuevoCertificadoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_RM266", "I");
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
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