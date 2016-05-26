using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SQLSPExecuter;

namespace wcfSeguridad.Datos {

    public class clsRolUsuarioDA {

        public Int64 iIdConexion { get; set; }
        public string sOperacion { get; set; }
        public Int64 iSesionTrabajo { get; set; }
        public string sSSN { get; set; }
        public string sMensajeError { get; set; }

        public DataSet DSet { get; set; }

        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public Int32 iIdOficina	{ get; set; }
        public DateTime fFechaVigencia { get; set; }
        public DateTime fFechaExpiracion { get; set; }
        public Int32 iIdEstado { get; set; }
        public Int32 iIdRolUsuario { get; set; }

        public bool ObtieneUsuariosXRol() {
            ClassSPExec ObjSPExec = new ClassSPExec(iIdConexion, "Seguridad.PR_RolUsuario", "Q");

            if (!ObjSPExec.p_bEstadoOK) {
                sMensajeError = ObjSPExec.ObtenerPilaMensajesError();
            } else {
                bool bAsignacionOK = true;
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iIdConexion", iIdConexion);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_cOperacion", "Q");
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_iSesionTrabajo", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@s_sSSN", null);
                bAsignacionOK = bAsignacionOK && ObjSPExec.AsignarValorParametro("@i_iIdRol", iIdRol);

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