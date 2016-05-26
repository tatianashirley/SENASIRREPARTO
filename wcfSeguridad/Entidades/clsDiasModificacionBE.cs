using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfSeguridad.Entidades
{
    public class clsDiasModificacionBE
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int Dias { get; set; }

        public int TotalR { get; set; }
    }
}