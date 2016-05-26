using System.Data;
using System.Dynamic;


namespace wcfPagoUnico.Entidades
{
    public class clsPUBase
    {
        public int iIdConexion { get; set; }
        public string cOperacion { get; set; }
        public string sParametro { get; set; }
        public string sMensajeError { get; set; }
        public bool sRespuesta { get; set; }
        public DataSet DSetTmp { get; set; }
    }
}