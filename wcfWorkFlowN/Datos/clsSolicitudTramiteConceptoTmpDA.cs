using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsSolicitudTramiteConceptoTmpDA : clsWorkflowBaseDA {

        public Int16 iSecuencia { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite { get; set; }
        public string sIdConcepto { get; set; }
        public string sTipoDato { get; set; }
        public Boolean bFlagInicio { get; set; }
        public Int32 iValorInt { get; set; }
        public Decimal mValorMoney { get; set; }
        public Double dValorFloat { get; set; }
        public string sValorChar { get; set; }
        public DateTime fValorDate { get; set; }
        public Int32 iValorCatalog { get; set; }
        public Boolean bValorBoolean { get; set; }

        /// <summary>
        /// Registra el valor de un concepto
        /// </summary>
        /// <returns></returns>
        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteConceptoTmp", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdConcepto", sIdConcepto);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorInt", iValorInt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValorMoney", mValorMoney);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValorFloat", dValorFloat);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValorChar", sValorChar);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValorDate", fValorDate);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorCatalog", iValorCatalog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValorBoolean", bValorBoolean);
                               
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                   } else {
                       Int64 iSesionTrabajoTmp = 0;
                       if (!ObjSPExec.ObtenerValorParametro("@s_iSesionTrabajo", ref iSesionTrabajoTmp)) {
                           sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                       } else {
                            iSesionTrabajo = iSesionTrabajoTmp;
                       }

                       Int16 iSecuenciaTmp = 0;
                       if (!ObjSPExec.ObtenerValorParametro("@s_iSesionTrabajo", ref iSecuenciaTmp)) {
                           sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                       } else {
                           iSecuencia = iSecuenciaTmp;
                       }
                   }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Modificación el valor de un concepto
        /// </summary>
        /// <returns></returns>
        public bool Modificacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteConceptoTmp", "U");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorInt", iValorInt);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_mValorMoney", mValorMoney);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_dValorFloat", dValorFloat);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sValorChar", sValorChar);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_fValorDate", fValorDate);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iValorCatalog", iValorCatalog);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_bValorBoolean", bValorBoolean);
                               
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Eliminación el valor de un concepto
        /// </summary>
        /// <returns></returns>
        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteConceptoTmp", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                               
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Devuelve la definición de un concepto específico 
        /// </summary>
        /// <returns></returns>
        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteConceptoTmp", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Devuelve los conceptos registrados
        /// </summary>
        /// <returns></returns>
        public bool ObtieneConceptosRegistrados() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteConceptoTmp", "Q");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        DSet = ObjSPExec.p_DataSetResultado;
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }


    }

}