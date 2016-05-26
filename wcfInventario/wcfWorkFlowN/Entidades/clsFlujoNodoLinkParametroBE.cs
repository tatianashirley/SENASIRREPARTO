using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoNodoLinkParametroBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo { get; set; }
        public Int16 iIdNodo { get; set; }
        public Int16 iSecuencia { get; set; }
        public String sIdConcepto { get; set; }
        public Boolean bFlagSolicitud { get; set; }
        public String sComentarios { get; set; }

    }
}