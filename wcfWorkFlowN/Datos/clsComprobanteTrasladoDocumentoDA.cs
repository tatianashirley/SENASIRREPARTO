using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsComprobanteTrasladoDocumentoDA : clsWorkflowBaseDA {

        public Int64 iIdComprobante { get; set; }
        public DateTime fFechaRegistro { get; set; }
        public string sComentarioGeneral { get; set; }
        public Int32 iIdOficinaOrigen { get; set; }
        public Int32 iIdAreaOrigen { get; set; }
        public string sResponsableAreaOrig { get; set; }
        public Int32 iIdRolOrigen { get; set; }
        public Int32 iIdUsuarioOrigen { get; set; }
        public Int32 iIdOficinaDestino { get; set; }
        public Int32 iIdAreaDestino { get; set; }
        public Int32 sResponsableAreaDest { get; set; }
        public Int32 iIdRolDestino { get; set; }
        public Int32 iIdUsuarioDestino { get; set; }
        public string sEstado { get; set; }
        public DateTime fFechaCierre { get; set; }

        public String sNemoNodoOrig { get; set; }
        public String sNemoNodoDest { get; set; }

        public bool Adicion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumento", "I");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "I");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sComentarioGeneral", sComentarioGeneral);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        Int64 iIdComprobanteTmp = 0;
                        if (!ObjSPExec.ObtenerValorParametro("@o_iIdComprobante", ref iIdComprobanteTmp)) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         } else {
                             iIdComprobante = iIdComprobanteTmp;
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }    

        public bool Adicion2() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumento", "J");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "J");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", iSesionTrabajo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoOrig", sNemoNodoOrig);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemoNodoDest", sNemoNodoDest);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        Int64 iIdComprobanteTmp = 0;
                        if (!ObjSPExec.ObtenerValorParametro("@o_iIdComprobante", ref iIdComprobanteTmp)) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         } else {
                             iIdComprobante = iIdComprobanteTmp;
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }    

        public bool Modificacion() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumento", "U");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "U");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdComprobante", iIdComprobante);

                if (bAsignacionOK) {
                   if (!ObjSPExec.EjecutarProcedimientoNonQry()) {
                        sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                    } else {
                        Int64 iIdComprobanteTmp = 0; 
                        if (!ObjSPExec.ObtenerValorParametro("@o_iIdComprobante", ref iIdComprobanteTmp)) {
                            sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
                         } else {
                             iIdComprobante = iIdComprobanteTmp;
                        }
                    }
                }
            }
            return (ObjSPExec.p_bEstadoOK);
        }    
    
        public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumento", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdComprobante", iIdComprobante);
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

        public Boolean ObtieneCbtesPendientesXUsuario() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_ComprobanteTrasladoDocumento", "S");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "S");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
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