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
    public class clsUsuariosBE
    {
        public int IdUsuario { get; set; }
        public int Carnet { get; set; }
        public string CuentaUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdEstacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdEstado { get; set; }
        
        public int TotalR { get; set; }
    }

    public class clsUsuariosVBE
    {
        public int IdUsuario { get; set; }
        public int Carnet { get; set; }
        public string NombrePersona { get; set; }
        public string CuentaUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }
}