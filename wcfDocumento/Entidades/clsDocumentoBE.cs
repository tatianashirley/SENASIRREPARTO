using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfDocumento.Entidades {

    public class clsDocumentoBE : clsDocumentoBaseBE {

        public Int64 iIdDocumento { get; set; }
        public string sCodigo { get; set; }
        public string sDescripcion { get; set; }
        public string sResumen { get; set; }
        public Int32 iIdTipoDocumento { get; set; }
        public DateTime fFechaRegistro { get; set; }
        public Boolean bFlagDigital { get; set; }
        public Int32 iIdEstado { get; set; }

    }
}