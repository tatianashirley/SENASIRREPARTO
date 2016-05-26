using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfEjemplo.Entidades
{
    public class clsProvinciaBE
    {
        public int ID_Departamento { get; set; }
        public string Nombre_Provincia { get; set; }
        public int ID_Provincia { get; set; }
    }

}
