using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoLinkBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iSecuencia { get; set; }
        public String sDescripcion { get; set; }
        public String sLink { get; set; }
        public Boolean bFlagObligatorio { get; set; }
        public String sEstado { get; set; }
        public Int32 iIdGrupoRestriccion { get; set; }
    }

}