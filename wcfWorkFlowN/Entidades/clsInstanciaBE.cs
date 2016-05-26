using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsInstanciaBE : clsWorkflowBaseBE {

        public Int64 iIdInstancia {get; set;}
        public Int32 iIdHisInstancia {get; set;}
        public String sIdTipoTramite {get; set;}
        public Int32 iIdFlujo {get; set;}
        public DateTime fFechaHrInicio {get; set;}
        public DateTime fFechaHrFin {get; set;}
        public Int32 iIdOficina {get; set;}
        public Int32 iIdRol {get; set;}
        public Int32 iIdUsuario {get; set;}
        public Int64 iIdSolicitud {get; set;}
        public String sEstado {get; set;}
        public DateTime fCambioEstadoFechaHr {get; set;}
        public String sCancelaJustificacion {get; set;}
        public Int32 iCancelaIdOficina {get; set;}
        public Int32 iCancelaIdRol {get; set;}
        public Int32 iCancelaIdUsuario {get; set;}

        public Int64 iIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
    }

}