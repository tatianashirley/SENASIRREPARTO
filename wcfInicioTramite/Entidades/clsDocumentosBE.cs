using wcfInicioTramite.Entidades;

namespace wcfInicioTramite.Documentos.Entidades
{
    public class clsDocumentosBE : clsBase
    {
        public int IdRestriccion { get; set; }
        public int CptoTDOc { get; set; }
        public string Descripcion { get; set; }
        public string Comentarios { get; set; }

        public long IdTramite { get; set; }
        public int IdGrupoBeneficio { get; set; }
        public long IdDocumento { get; set; }
        public int IdTipoDocumento { get; set; }

        public string TipoTramite { get; set; }
        public long IdTipoPersona { get; set; }
        public long IdSector { get; set; }
    }
}