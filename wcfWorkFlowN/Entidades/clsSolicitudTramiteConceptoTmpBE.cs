using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsSolicitudTramiteConceptoTmpBE : clsWorkflowBaseBE {

        public Int16 iSecuencia  { get; set; }
        public Int32 iIdHisInstancia { get; set; }
        public string sIdTipoTramite { get; set; }
        public string sIdConcepto { get; set; }
        public string sTipoDato { get; set; }
        public Boolean bFlagInicio { get; set; }
        public Int32 iValorInt { get; set; }
        public Decimal mValorMoney { get; set; }
        public Double dValorFloat { get; set; }
        public string sValorChar { get; set; }
        public DateTime fValorDate { get; set; }
        public Int32 iValorCatalog { get; set; }
        public Boolean bValorBoolean { get; set; }

    }
}