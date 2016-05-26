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
    public class clsModulosBE
    {
        public int IdModulo { get; set; }
        public string SiglaModulo { get; set; }
        public string DescripcionModulo { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }
}