using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SQLSPExecuter;

namespace wcfWorkFlowN.Datos {

    public class clsHisFlujoNodoDA : clsWorkflowBaseDA {

        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public string sDescripcion { get; set; }
        public string sComentarios { get; set; }
        public Int16 iDuracionMaxDias { get; set; }
        public Int16 iDuracionMaxHoras { get; set; }
        public Byte iNivelOficina { get; set; }
        public Int32 iIdOficina { get; set; }
        public Int32 iIdArea { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Boolean bFlagRechazo { get; set; }
        public Boolean bFlagFicticio { get; set; }
        public Boolean bFlagSincronizador { get; set; }
        public Boolean bFlagTerminal { get; set; }
        public Int32 iIdEstadoTramite { get; set; }
        public string sNemonico { get; set; }
        public string sEstado { get; set; }

       public bool ObtieneFila() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Workflow.PR_InstanciaNodo", "V");
            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "V");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdHisInstancia", iIdHisInstancia);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdFlujo", iIdFlujo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdNodo", iIdNodo);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_sNemonico", sNemonico);

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