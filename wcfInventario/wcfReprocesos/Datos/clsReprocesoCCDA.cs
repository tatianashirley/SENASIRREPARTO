using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfReprocesos.Entidades;
using SQLSPExecuter;

namespace wcfReprocesos.Datos
{
    public class clsReprocesoCCDA : clsReprocesosBaseDA
    {
        #region "Declaración de variables o parametros para las funciones/Procedimientos Capa Datos"
        public String iNumeroResolucion { get; set; }
        public DateTime? iFechaResolucion { get; set; }
        public Int64 iIdTramite { get; set; }
        public Int64 iNUP { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iNoFormularioCalculo { get; set; }
        public DateTime? fFechaCalculo { get; set; }
        public Decimal dMontoCC { get; set; }
        public Int32 iSIP_impresion { get; set; }
        public Boolean bRegistroAPS { get; set; }
        public Boolean bCursoPago { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoCC { get; set; }
        public Int32 iIdTipoReproceso { get; set; }
        public String cCodigoReproceso { get; set; }
        public Int32 iNroFormularioRepro { get; set; }
        #endregion

        #region "Declaración de funciones/Procedimientos Capa Datos"
        /// <summary>
        /// Inserta Formulario Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool InsertaFormularioReprocesoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "I");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNumeroResolucion", iNumeroResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iFechaResolucion", iFechaResolucion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTramite", iIdTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNUP", iNUP);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoTramite", iIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdGrupoBeneficio", iIdGrupoBeneficio);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNoFormularioCalculo", iNoFormularioCalculo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fFechaCalculo", fFechaCalculo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dMontoCC", dMontoCC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSIP_impresion", iSIP_impresion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bRegistroAPS", bRegistroAPS);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bCursoPago", bCursoPago);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdUsuario", iIdUsuario);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iNroCertificado", iNroCertificado);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoCC", iIdTipoCC);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_cCodigoReproceso", cCodigoReproceso);
                //sMensajeError = ObjSPExec.ObtenerPilaMensajesError();

                if (bAsignacionOK)
                {
                    if (!ObjSPExec.EjecutarProcedimientoQry())
                    {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    }
                    else
                    {
                        int iNroFormularioReproTmp = 0;
                        DSet = ObjSPExec.p_DataSetResultado;
                        ObjSPExec.ObtenerValorParametro("@o_iNroFormularioRepro", ref iNroFormularioReproTmp);
                        iNroFormularioRepro = iNroFormularioReproTmp;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Obtiene Detalle de un Formulario de Reproceso
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFormReproDetalleDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "O");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "O");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroFormularioRepro", iNroFormularioRepro);
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
        /// Obtiene Formularios de Reprocesos
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFormulariosReprocesosDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "Q");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
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
        /// Obtiene un Formulario de Reproceso Específico
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFormularioReprocesoEspecificoDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "R");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "R");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroFormularioRepro", iNroFormularioRepro);
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
        /// Obtiene Salario Cotizable Trámite de un Formulario de Reproceso Específico
        /// </summary>
        /// <returns></returns>
        public bool ObtieneSalarioCotizableDA()
        {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Reprocesos.PR_Reprocesos_FormularioRepro", "S");
            if (!ObjSPExec.p_bEstadoOK)
            {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            }
            else
            {
                bool bAsignacionOK = true;
                ObjSPExec.p_RemplazarCeroPorDBNull = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);

                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@o_iNroFormularioRepro", iNroFormularioRepro);
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