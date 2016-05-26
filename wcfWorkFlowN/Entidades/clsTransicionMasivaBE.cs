using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsTransicionMasivaBE : clsWorkflowBaseBE {
        public Int32 iIdTransicionMsva {get; set;}
        public string sNemoNodoOrig {get; set;}
        public string sNemoNodoDest {get; set;}
        public DateTime fFechaRegistro {get; set;}
        public Int32 iRealizadoPor {get; set;}
        public Boolean bFlagConfirmado { get; set;}
    }

}