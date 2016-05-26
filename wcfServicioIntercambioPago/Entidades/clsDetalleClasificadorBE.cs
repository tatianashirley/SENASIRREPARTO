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
    public class clsDetalleClasificadorBE
    {
        public int IdDetalleClasificador { get; set; }
        public int IdTipoClasificador { get; set; }
        public string CodigoDetalleClasificador { get; set; }
        public string DescripcionDetalleClasificador { get; set; }
        public string ObservacionClasificador { get; set; }

        public int IdPadre { get; set; }
        public int EstadoDetalleClasificador { get; set; }
        public int EstadoRegistro { get; set; }

        public int TotalR { get; set; }
    }
}