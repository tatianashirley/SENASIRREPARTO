using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfEnvioAPS.Entidades
{
    public class clsGeneraMediosBE : clsEnvioAPSbaseBE
    {
        #region "Declaración de variables/Propiedades de GeneraMedios Nivel lógico"
        public Int32 iNroCertificado { get; set; }
        public Int32 iIdTipoTramite { get; set; }
        public String sCodigoActualizacion { get; set; }
        public String sNumeroEnvio { get; set; }
        public Int32 iIdEntidadGestora { get; set; }

        public Int32 iNumeroCite { get; set; }
        public DateTime fFechaCite { get; set; }
        public DateTime fFechaRecepcion { get; set; }
        public String sArchivoEnvioNombre { get; set; }
        public String sArchivoEnvioContTipo { get; set; }
        public Int64 iArchivoEnvioLongitud { get; set; }
        public byte[] vArchivoEnvioDatos { get; set; }
        public String sArchivoEnvioCRCNombre { get; set; }
        public byte[] vArchivoEnvioCRCDatos { get; set; }
        public String sUsuario { get; set; }
        public Int32 iRegistroActivo { get; set; }
        #endregion
    }
}