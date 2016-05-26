using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades
{

    public class clsHisGrupoRestriccionBE : clsWorkflowBaseBE
    {
        public Int32 iIdHisInstancia { get; set; }
        public Int32 iIdGrupoRestriccion { get; set; }
        public string sDescripcion { get; set; }
        public string sComentarios { get; set; }
        public string sReglaEvaluacion { get; set; }

        public Int32 iIdGrupoRestriccionDesde { get; set; }
        public Int32 iIdGrupoRestriccionHasta { get; set; }

    }

}