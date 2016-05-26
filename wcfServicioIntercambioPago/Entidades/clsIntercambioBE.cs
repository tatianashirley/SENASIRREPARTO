using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfServicioIntercambioPago.Entidades
{
    public class clsIntercambioBE
    {
        public int IdArchivo { get; set; }
        public int IdTransaccion { get; set; }
        public string Descripcion { get; set; }
        public string Prefijo { get; set; }
        public string Formato { get; set; }
        public string CodigoMedio { get; set; }
        public string Extension { get; set; }
        public string ExpReg { get; set; }
        public string TablaTemporal { get; set; }
        public string TablaFinal { get; set; }
        public string Procedimiento { get; set; }
        public string Alta { get; set; }
        public string Baja { get; set; }
        public int RegistroActivo { get; set; }
        /*los que faltan para campos registro*/
        public string CampoMedio { get; set; }
        public string Tipo { get; set; }
        public int Tamaño { get; set; }
        public string CampoTabla { get; set; }
        public string Observacion { get; set; }  
    }
}