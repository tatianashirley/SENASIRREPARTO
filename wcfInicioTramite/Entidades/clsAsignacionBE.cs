
namespace wcfInicioTramite.Entidades
{
    public class clsAsignacionBE : clsBase
    {
        public string TipoConsulta { get; set; }
        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdUsuarioDestino { get; set; }
        public int IdAreaDestino { get; set; }
        public int IdUsuarioOrigen { get; set; }
        public int IdAreaOrigen { get; set; }
        public string Observacion { get; set; }
        public long IdGrupoTramite { get; set; }
    }
}