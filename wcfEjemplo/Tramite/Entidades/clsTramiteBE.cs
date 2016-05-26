using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEjemplo.Tramite.Entidades
{
    public class clsTramiteBE
    {
        public int NUP { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdBeneficio { get; set; }
        public int IdSubBeneficio { get; set; }
        public int IdTipoTramite { get; set; }
        public int IdFlujoTramite { get; set; }
        public int IdClaseExpediente { get; set; }
        public int IdSector { get; set; }
        public int IdOficinaRegistro { get; set; }
        public int NUPIniciaTramite { get; set; }
        public int IdTipoIniciaTramite { get; set; }
        public string Observaciones { get; set; }
        public int IdEstadoTramite { get; set; }
        public int IdTipoProcesoRegistroTramite { get; set; }
        public int EstadoHabilitacion { get; set; }
        public string DocumentoHabilitacion { get; set; }

        public int IdTramite { get; set; }
        public string mensaje { get; set; }
        public string retorno_proc { get; set; }
    }
}