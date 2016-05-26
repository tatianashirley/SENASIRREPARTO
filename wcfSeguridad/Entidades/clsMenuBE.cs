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
    public class clsMenuBE
    {
        public int IdMenu { get; set; }
        public int IdModulo { get; set; }
        public string DescripcionMenu { get; set; }
        public int IdMenuSuperior { get; set; }
        public int Posicion { get; set; }
        public string URL { get; set; }
        public string Roles_pm { get; set; }
        public string Imagen { get; set; }
        public int IdEstado { get; set; }

        public int TotalMenu { get; set; }
    }
}