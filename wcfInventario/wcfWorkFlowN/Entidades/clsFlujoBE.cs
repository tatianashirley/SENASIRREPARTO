using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class clsFlujoBE : clsWorkflowBaseBE {

        public Int32 iIdFlujo {get; set;}
        public String sDescripcion {get; set;}
        public String sIdTipoTramite {get; set;}
        public String sComentarios {get; set;}
        public Int16 iDuracionMaxDias {get; set;}
        public Int16 iDuracionMaxHoras {get; set;}
        public Int32 iIdGrupoRestriccion {get; set;}
        public Boolean bFlagUnRechazo {get; set;}
        public Byte iNivelOficina {get; set;}
        public Int32 iIdOficina {get; set;}
        public Int32 iIdArea {get; set;}
        public Int32 iIdRol {get; set;}
        public Int32 iIdUsuario {get; set;}
        public Byte iPrioridad { get; set; }

    }

}