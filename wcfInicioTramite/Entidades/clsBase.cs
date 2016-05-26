using System.Data;

namespace wcfInicioTramite.Entidades
{
    public class clsBase
    {
        public int iIdConexion { get; set; }
        public string cOperacion { get; set; }
        public string sParametro { get; set; }
        public string sMensajeError { get; set; }
        public bool sRespuesta { get; set; }
        public DataSet DSetTmp { get; set; }
    }
}