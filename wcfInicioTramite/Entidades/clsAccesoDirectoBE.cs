using System;
using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Tramite.Entidades
{
    public class clsAccesoDirectoBE : clsBase
    {
        public string IdTramite { get; set; }
        public string Matricula { get; set; }
        public string TipoInformacion { get; set; }
    }
}