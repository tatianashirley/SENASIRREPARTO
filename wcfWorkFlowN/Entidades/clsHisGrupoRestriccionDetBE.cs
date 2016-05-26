using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades
{

    public class clsHisGrupoRestriccionDetBE : clsWorkflowBaseBE
    {
        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdGrupoRestriccion { get; set; }
        public Int32 iIdRestriccion { get; set; }
        public Int16 iOrden { get; set; }
        public Int16 iSubGrupo { get; set; }
        public Boolean bFlagInclusivo { get; set; }
        public string sReglaEvaluacion { get; set; }
        public Int32 iIdProcedimiento { get; set; }
        public string sIdParametro { get; set; }

    }
}