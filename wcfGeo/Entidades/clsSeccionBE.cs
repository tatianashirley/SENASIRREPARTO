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
    public class clsSeccionBE
    {
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdSeccion { get; set; }
        public string NombreSeccionMunicipal { get; set; }
        public string DetalleSeccion { get; set; }
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }

}
