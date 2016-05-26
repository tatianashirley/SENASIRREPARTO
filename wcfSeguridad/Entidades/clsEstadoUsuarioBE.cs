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
    public class clsEstadoUsuarioBE
    {
        public int IdEstadoUsuario { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }

        public int TotalE { get; set; }
    }
}