using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsComprobanteTrasladoDocumentoDetTmpDA : clsWorkflowBaseDA {

        public Int64 iSesion { get; set; }
        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public string sComentario { get; set; }
        public Boolean bFlagAceptacion { get; set; }

        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumentoDetTmp", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentario", sComentario);

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
  
        public bool Modificacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumentoDetTmp", "U");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentario", sComentario);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }  

        public bool Eliminacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumentoDetTmp", "D");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "D");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iSecuencia", iSecuencia);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } 
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        } 

        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumentoDetTmp", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdInstancia", iIdInstancia);
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

    }
}