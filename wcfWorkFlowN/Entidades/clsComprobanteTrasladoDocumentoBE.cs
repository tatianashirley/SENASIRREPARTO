using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsComprobanteTrasladoDocumentoBE : clsWorkflowBaseBE {

        public Int64 iIdComprobante  { get; set; }
        public DateTime fFechaRegistro { get; set; }
        public String sComentarioGeneral { get; set; }
        public Int32 iIdOficinaOrigen { get; set; }
        public Int32 iIdAreaOrigen  { get; set; }
        public String sResponsableAreaOrig  { get; set; }
        public Int32 iIdRolOrigen  { get; set; }
        public Int32 iIdUsuarioOrigen  { get; set; }
        public Int32 iIdOficinaDestino  { get; set; }
        public Int32 iIdAreaDestino  { get; set; }
        public Int32 sResponsableAreaDest  { get; set; }
        public Int32 iIdRolDestino  { get; set; }
        public Int32 iIdUsuarioDestino  { get; set; }
        public String sEstado { get; set; }
        public DateTime fFechaCierre { get; set; }

        public String sNemoNodoOrig { get; set; }
        public String sNemoNodoDest { get; set; }
    }

}