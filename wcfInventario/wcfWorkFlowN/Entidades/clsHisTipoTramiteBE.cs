using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades
{

    public class clsHisTipoTramiteBE : clsWorkflowBaseBE
    {
        public Int32 iIdHisInstancia { get; set; }
        public String sIdTipoTramite { get; set; }
        public String sDescripcion { get; set; }
        public String sIdTipoTramiteSup { get; set; }
        public Boolean bFlagAgrupador { get; set; }
        public Int32 iIdModulo { get; set; }
        public Boolean bFlagExcepcion { get; set; }
        public String sFlagReinicio { get; set; }
        public Int16 iMaxDiasIniTramite { get; set; }
        public Int16 iMaxDiasTramiteInactivo { get; set; }
        public Int32 iIdGrupoRestriccion { get; set; }

    }
}