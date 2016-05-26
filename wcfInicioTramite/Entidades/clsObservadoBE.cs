
namespace wcfInicioTramite.Entidades
{
    public class clsObservadoBE : clsBase
    {
        public int IdObservado { get; set; }
        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public long NUP { get; set; }
        public string NumeroDocumento { get; set; }
        public string CUA { get; set; }
        public string Matricula { get; set; }
        public string Tabla { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string PrimerNombre { get; set; }
        public string Motivo { get; set; }
        public string Autorizador { get; set; }
        public string Observaciones { get; set; }
    }
}