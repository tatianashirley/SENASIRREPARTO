
namespace wcfInicioTramite.Entidades
{
    public class clsVerificacionDatosBE : clsBase
    {
        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int IdTipoInconsistencia { get; set; }
        public string Observacion { get; set; }
    }
}