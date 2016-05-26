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
    public class clsCaducidadBE
    {
        public int IdCaducidad { get; set; }
        public int IdRol { get; set; }
        public int Dias { get; set; }
        public int IdEstado { get; set; }

        public int TotalCad { get; set; }
    }

    public class clsCaducidadesVBE
    {
        public int IdCaducidad { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public int IdEstado { get; set; }
    }
}