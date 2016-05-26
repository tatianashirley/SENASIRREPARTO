using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsHisFlujoNodoLinkBE : clsWorkflowBaseBE {

        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iSecuencia { get; set; }
        public string sDescripcion { get; set; }
        public string sLink { get; set; }
        public Boolean bFlagObligatorio { get; set; }
        public string sEstado { get; set; }

    }
}