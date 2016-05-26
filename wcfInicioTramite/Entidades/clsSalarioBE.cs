
namespace wcfInicioTramite.Entidades
{
    public class clsSalarioBE : clsBase
    {
        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public int Version { get; set; }
        public int Componente { get; set; }
        public string Ruc { get; set; }
        public int IdTipoDocSalario { get; set; }
        public string PeriodoSalario { get; set; }
        public string SalarioCotizable { get; set; }
        public int IdMonedaSalario { get; set; }
        public int IdEstadoSalario { get; set; }
        public int RegistroActivo { get; set; }
        public int IdSector { get; set; }
    }
}