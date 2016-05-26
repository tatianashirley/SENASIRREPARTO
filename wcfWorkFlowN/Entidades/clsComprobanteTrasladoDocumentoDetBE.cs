using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsComprobanteTrasladoDocumentoDetBE : clsWorkflowBaseBE {

        public Int64 iIdComprobante { get; set; }
        public Int64 iIdInstancia { get; set; }
        public Int32 iSecuencia { get; set; }
        public string sComentario { get; set; }
        public Boolean bFlagAceptacion { get; set; }

    }

}