using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfDocumento.Entidades {

    public class clsTipoDocumentoBE : clsDocumentoBaseBE {

        public Int32 iIdTipoDocumento { get; set; }
        public string sDescripcion { get; set; }
        public Int32 iIdTipoArchivo { get; set; }
        public Int32 iIdEstado { get; set; }

    }

}