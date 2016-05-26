using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfGeo.Entidades
{
    public class clsDepartamentoBE
    {
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int IdPais { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }

}
