using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace wcfServicioIntercambioPago.Entidades
{
   public class clsServicioIntercambioBE
    {
       public int IdTipoClasificador { get; set; }
       public string NombreClasificador { get; set; }
       public int EstadoRegistro { get; set; }
       public string CodigoClasificador { get; set; }
       /******propios de Intercambio*****************/
       public int IdArchivo { get; set; }
       public string Descripcion { get; set; }
       public string Prefijo { get; set; }
       public string Extencion { get; set; }
       public string TablaDestino { get; set; }
       public string PeriodoAlta { get; set; }
       public string PeriodoBaja { get; set; }
       /******campos intercambio******************/
       public string NombreCampo { get; set; }
       public string TipoDato { get; set; }
       public string Tamanio { get; set; }
       public string Tabla { get; set; }
       public string Campo { get; set; }
       public int Precision { get; set; }
       public string CarateresNoValidados { get; set; }
      }
   
}