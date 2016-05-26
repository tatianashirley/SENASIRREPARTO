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
    public class clsEstacionesBE
    {
        public int IdEstacion { get; set; }
        public string Nombre { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public int IdOficina { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }

    //public class clsEstacionesVBE
    //{
    //    public int IdRol { get; set; }
    //    public string NombreModulo { get; set; }
    //    public string AbreviacionRol { get; set; }
    //    public string DescripcionRol { get; set; }
    //    public int IdEstado { get; set; }

    //    public int TotalR { get; set; }
    //}
}