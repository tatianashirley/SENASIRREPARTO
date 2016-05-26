
namespace wcfInicioTramite.Entidades
{
    public class clsEmpresaPersonaBE : clsBase
    {
        public int IdEmpresaPersona { get; set; }
        public long IdTramite { get; set; }
        public int idGrupoBeneficio { get; set; }
        public string IdEmpresa { get; set; }
        public string NombreEmpresaDeclarada { get; set; }
        public string Observacion { get; set; }
        public string PeriodoInicio { get; set; }
        public string PeriodoFin { get; set; }
        public string Monto { get; set; }
        public int IdMoneda { get; set; }
        public int EstadoRegistro { get; set; }
        public string NroPatronalRucAlt { get; set; }
        public int IdSector { get; set; }
        public int IdTipoDocSalario { get; set; }

        public int IdTipoTramite { get; set; }
        public int Version { get; set; }
        public int Componente { get; set; }
        public string PeriodoSalario { get; set; }
        public int IdMonedaSalario { get; set; }
        public string Motivo { get; set; }

        public int IdSectorSSLP { get; set; }
        public string ValidaPFA { get; set; }
        public string MatriculaORG { get; set; }
    }
}