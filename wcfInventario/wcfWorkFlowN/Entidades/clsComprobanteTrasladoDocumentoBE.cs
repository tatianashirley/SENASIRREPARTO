using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsComprobanteTrasladoDocumentoBE : clsWorkflowBaseBE {

        public Int64 iIdComprobante  { get; set; }
        public DateTime fFechaRegistro { get; set; }
        public string sComentarioGeneral { get; set; }
        public Int32 iIdOficinaOrigen { get; set; }
        public Int32 iIdAreaOrigen  { get; set; }
        public string sResponsableAreaOrig  { get; set; }
        public Int32 iIdRolOrigen  { get; set; }
        public Int32 iIdUsuarioOrigen  { get; set; }
        public Int32 iIdOficinaDestino  { get; set; }
        public Int32 iIdAreaDestino  { get; set; }
        public Int32 sResponsableAreaDest  { get; set; }
        public Int32 iIdRolDestino  { get; set; }
        public Int32 iIdUsuarioDestino  { get; set; }
        public string sEstado { get; set; }
        public DateTime fFechaCierre { get; set; }
    }

}