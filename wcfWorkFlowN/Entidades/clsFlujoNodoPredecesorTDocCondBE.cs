using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoPredecesorTDocCondBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodoPred {get; set;}
        public Int16 iIdNodo {get; set;}
        public String sIdTipoTramite {get; set;}
        public Int32 iIdTipoDocumento {get; set;}
        public String sEstado { get; set; }

    }

}