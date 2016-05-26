using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades
{

    public class clsHisConceptoBE : clsWorkflowBaseBE
    {
        public Int32 iIdHisInstancia { get; set; }
        public string sIdConcepto { get; set; }
        public string sDescripcion { get; set; }
        public string sComentarios { get; set; }
        public string sTipoDato { get; set; }
        public Int16 iLongitud { get; set; }
        public Boolean bFlagMayusculas { get; set; }
        public string sMascara { get; set; }
        public Int32 iIdTipoClasificador { get; set; }
        public string sAlias { get; set; }
    }

}