using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoPredecesorProcesoBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodoPred {get; set;}
        public Int16 iIdNodo {get; set;}
        public Int16 iSecuencia {get; set;}
        public Int32 iIdProcedimiento {get; set;}
        public Boolean bFLagExitoProc { get; set; }
        public string sPrmOperacion	{ get; set; }
        public Boolean bFlagCbteAcepDoc { get; set; }
        public Boolean bFlagAceptacion { get; set; }

    }

}