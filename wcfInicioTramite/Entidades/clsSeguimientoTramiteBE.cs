using System;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Entidades
{
    public class clsSeguimientoTramiteBE : clsBase
    {
        public string IdTramite { get; set; }
        public string TipoConsulta { get; set; }
        public string Observaciones { get; set; }
    }
}