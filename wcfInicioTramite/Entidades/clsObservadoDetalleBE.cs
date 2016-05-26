
namespace wcfInicioTramite.Entidades
{
    public class clsObservadoDetalleBE : clsBase
    {
        public long IdObservado { get; set; }
        public string Tramite { get; set; }
        public string Tipo { get; set; }
        public string NumeroDocumento { get; set; }
        public string CUA { get; set; }
        public string Matricula { get; set; }
        public string PrimeroApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombres { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sector { get; set; }
        public string DHMatricula { get; set; }
        public string EstadoObservado { get; set; }
    }
}