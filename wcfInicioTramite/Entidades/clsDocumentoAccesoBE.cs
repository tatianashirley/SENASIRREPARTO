
namespace wcfInicioTramite.Entidades
{
    public class clsDocumentoAccesoBE : clsBase
    {
        public string IdTramite { get; set; }
        public string Matricula { get; set; }
        public int IdRequisito { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdCausa { get; set; }
    }
}