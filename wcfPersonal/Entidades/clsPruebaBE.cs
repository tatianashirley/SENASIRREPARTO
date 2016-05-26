using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfPersonal.Entidades
{
    public class clsPruebaBE
    {
        //public int NUP { get; set; }
        //public string matricula { get; set; }
        public string carnet { get; set; }
        public string complementoSEGIP { get; set; }
        public string nua { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombres { get; set; }
        public string casada { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string habilitado { get; set; }

        public int TotalR { get; set; }
     }
}