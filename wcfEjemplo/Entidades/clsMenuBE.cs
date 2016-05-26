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
    public class clsMenuBE
    {
        public int IdMenu { get; set; }
        public int IdSistema { get; set; }
        public string Descripcion { get; set; }
        public int PadreId { get; set; }
        public int Posicion { get; set; }
        public string Formulario { get; set; }
        public string RutaFormulario { get; set; }
        public int IdRol { get; set; }
        public string Imagen { get; set; }
        public int IdEstado { get; set; }

        public int TotalMenu { get; set; }
    }
}