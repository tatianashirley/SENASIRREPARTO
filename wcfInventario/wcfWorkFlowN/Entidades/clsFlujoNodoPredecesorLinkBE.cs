using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoPredecesorLinkBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodoPred {get; set;}
        public Int16 iIdNodo {get; set;}
        public Int16 iSecuencia { get; set; }

    }

}