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
    public class clsUsuariosModulosRolesBE
    {
        public int IdUsuarioModuloRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public int IdRol { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }

    public class clsUsuariosModulosRolesVBE
    {
        public int IdUsuarioModuloRol { get; set; }
        public int IdUsuario { get; set; }
        public string CuentaUsuario { get; set; }
        public int IdModulo { get; set; }
        public string NombreModulo { get; set; }
        public int IdRol { get; set; }
        public string AbreviacionRol { get; set; }
        public string DescripcionRol { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }
}