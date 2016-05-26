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
    public class clsOficinasBE
    {
        public int IdOficina { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdOficinaSuperior { get; set; }
        public int FlagMovimiento { get; set; } //Obs
        public int Nivel { get; set; } //Obs
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int IdLocalidad { get; set; } //Obs
        public int IdTipoOficina { get; set; }
        public int FlagImprimeCC { get; set; } //Obs
        public int IdEstado { get; set; }

        public int TotalR { get; set; }
    }

    //public class clsOficinasVBE
    //{
    //    public int IdRol { get; set; }
    //    public string NombreModulo { get; set; }
    //    public string AbreviacionRol { get; set; }
    //    public string DescripcionRol { get; set; }
    //    public int IdEstado { get; set; }

    //    public int TotalR { get; set; }
    //}
}