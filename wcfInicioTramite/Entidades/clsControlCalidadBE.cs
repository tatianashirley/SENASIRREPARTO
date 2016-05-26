
namespace wcfInicioTramite.Entidades
{
    public class clsControlCalidadBE : clsBase
    {
        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public int IdUsuario { get; set; }
    }
}