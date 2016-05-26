using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsSolicitudTramiteBE : clsWorkflowBaseBE {

        public Int64 iIdSolicitud  { get; set; }
        public string sCodigoTramite { get; set; }
        public string sDescripcion { get; set; }
        public string sComentarios { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite  { get; set; }
        public Int32 iIdRol { get; set; }
        public Int32 iIdUsuario { get; set; }
        public DateTime fFechaHoraRegistro { get; set; }
        public DateTime fFechaHoraInicio { get; set; }
        public Int32 iIdRolInicio { get; set; }
        public Int32 iIdUsuarioInicio { get; set; }
        public DateTime fFechaHoraTermino { get; set; }
        public string sEstado { get; set; }

        public DateTime fFechaDesde { get; set; }
        public DateTime fFechaHasta { get; set; }

        public string sNombres { get; set; }
        public string sApellidoPaterno { get; set; }
        public string sApellidoMaterno { get; set; }
        public string sNumeroDocumento { get; set; }
        public Int64  iIdTramite { get; set; }

    }

}