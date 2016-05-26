using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsSolicitudTramiteDocumentoTmpDA : clsWorkflowBaseDA {

        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite { get; set; }
        public Int32 iIdTipoDocumento { get; set; }
        public Int64 iIdDocumento { get; set; }

        /// <summary>
        /// Registra un documento
        /// </summary>
        /// <returns></returns>
        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteDocumentoTmp", "I");
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
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", iIdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", iIdDocumento);
                               
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
                   }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Quita un documento
        /// </summary>
        /// <returns></returns>
        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteDocumentoTmp", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", iIdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", iIdDocumento);
                               
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
                   }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }

        /// <summary>
        /// Quita todos los documentos
        /// </summary>
        /// <returns></returns>
        public bool EliminacionTodos() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteDocumentoTmp", "B");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "B");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                               
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
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteDocumentoTmp", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sIdTipoTramite", sIdTipoTramite);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdTipoDocumento", iIdTipoDocumento);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdDocumento", iIdDocumento);

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
        public bool ObtieneDocumentosRegistrados() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_SolicitudTramiteDocumentoTmp", "Q");
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