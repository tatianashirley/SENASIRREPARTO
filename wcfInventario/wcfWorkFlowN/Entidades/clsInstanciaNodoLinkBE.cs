using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsInstanciaNodoLinkBE : clsWorkflowBaseBE {

        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iSecuenciaLink { get; set; }

    }

}