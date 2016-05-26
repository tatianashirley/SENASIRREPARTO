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
    public class clsAccesoUsuarioBE
    {
        public int IdAcceso { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdResultadoAcceso { get; set; }

        public int TotalAU { get; set; }
    }

    public class clsAccesoUsuarioVBE
    {
        public int IdAcceso { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdResultadoAcceso { get; set; }
    }
}