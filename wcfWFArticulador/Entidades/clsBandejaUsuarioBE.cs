using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

namespace wcfWFArticulador.Entidades
{
    public class clsBandejaUsuarioBE : clsWFArticuladorBaseBE
    {
        #region "Declaración de variables/Propiedades"
        public Int32 iIdRuta { get; set; }
        public Int64 iIdTramite { get; set; }
        public String sIdTramite { get; set; }
        public Int32 iIdGrupoBeneficio { get; set; }
        public Int32 iIdUsuarioDestino { get; set; }
        public Int32 iIdAreaDestino { get; set; }
        public Int32 iIdUsuarioDestinoNew { get; set; }
        public Int32 iIdAreaDestinoNew { get; set; }
        public Int32 iIdRolNew { get; set; }
        public DateTime fFechaIngreso { get; set; }
        public Int32 iIdUsuarioOrigen { get; set; }
        public Int32 iIdAreaOrigen { get; set; }
        public DateTime fFechaSalida { get; set; }
        public String sObsSalidaArea { get; set; }
        public DateTime fFechaSalidaTentativa { get; set; }
        public Int32 iIdEstadoSeguimientoTramite { get; set; }
        public Int32 iIdUsuarioRegistro { get; set; }
        public DateTime fFechaRegistro { get; set; }
        public String Tipo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Int32 IdUsuarioOrigen { get; set; }
        public Int32 IdAreaOrigen { get; set; }
        public DateTime fFechaAsignacion { get; set; }
        public String sProvehido { get; set; }
        public Int32 iId430 { get; set; }
        public DateTime fFecha1 { get; set; }
        public DateTime fFecha2 { get; set; }
        #endregion
    }
}