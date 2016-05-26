using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoPredecesorProcesoPrmBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public Int16 iIdNodoPred {get; set;}
        public Int16 iIdNodo {get; set;}
        public Int16 iSecuencia {get; set;}
        public Int32 iIdProcedimiento {get; set;}
        public String sIdParametro {get; set;}
        public String sIdConcepto { get; set; }
        public Boolean bFlagSolicitud { get; set; }
    }

}