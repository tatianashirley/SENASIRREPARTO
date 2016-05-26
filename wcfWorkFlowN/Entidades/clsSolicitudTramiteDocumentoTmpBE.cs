using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsSolicitudTramiteDocumentoTmpBE : clsWorkflowBaseBE {

        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite { get; set; }
        public Int32 iIdTipoDocumento { get; set; }
        public Int64 iIdDocumento { get; set; }

    }

}