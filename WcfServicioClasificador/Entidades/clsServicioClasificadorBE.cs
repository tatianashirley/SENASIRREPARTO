using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WcfServicioClasificador.Entidades
{
   public class clsServicioClasificadorBE
    {
       public int IdTipoClasificador { get; set; }
        public string NombreClasificador { get; set; }
       public int EstadoRegistro { get; set; }
     
      }
   
}