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
    public class clsGeoBE
    {
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int CodigoLocalidad { get; set; }
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public int IdSeccion { get; set; }
        public string NombreSeccionMunicipal { get; set; }
        public string DetalleSeccion { get; set; }
        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }

        public int TotalR { get; set; }
    }
}
