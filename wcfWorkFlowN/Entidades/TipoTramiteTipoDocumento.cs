﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfWorkFlowN.Entidades {

    public class TipoTramiteTipoDocumento : clsWorkflowBaseBE {

        public string sIdTipoTramite { get; set; }
        public Int32 iIdTipoDocumento { get; set; }
        public String sComentarios { get; set; }
        public Boolean bFlagSolicitud { get; set; }
        public Boolean bFlagModificable { get; set; }
        public Boolean bFlagObligatorio { get; set; }
        public Boolean bFlagRepeticion { get; set; }

    }

}