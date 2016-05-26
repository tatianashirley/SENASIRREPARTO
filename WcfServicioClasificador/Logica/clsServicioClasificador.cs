
using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using WcfServicioClasificador.Entidades;
using WcfServicioClasificador.Datos;

namespace WcfServicioClasificador.Logica
{
    public class clsServicioClasificador : clsServicioClasificadorBE
    {
      public List<clsServicioClasificador> ContarServicioClasificador()
        {
            clsServicioClasificador p;
            clsServicioClasificadorDA permiso = new clsServicioClasificadorDA();
            List<clsServicioClasificador> ListaPermiso = new List<clsServicioClasificador>();
            using (IDataReader dr = permiso.ContarServicioClasificador())
            {
                while (dr.Read())
                {
                    p = new clsServicioClasificador();
                   ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

      public List<clsServicioClasificador> ListarTipoClasificadormasalgo()
      {
          clsServicioClasificador p;
          clsServicioClasificadorDA permiso = new clsServicioClasificadorDA();
          List<clsServicioClasificador> ListaClas = new List<clsServicioClasificador>();

          clsServicioClasificador item = new clsServicioClasificador();
          item.NombreClasificador = "Selecccione";
          ListaClas.Add(item);

          using (IDataReader dr = permiso.ListarTipoClasificador(0, 0))
          {
              while (dr.Read())
              {
                  p = new clsServicioClasificador();
                  p.IdTipoClasificador = (int)dr["IdTipoClasificador"];
                  p.NombreClasificador = (string)dr["NombreClasificador"];
                  p.EstadoRegistro = Convert.ToInt16((bool)dr["EstadoRegistro"]);
                  ListaClas.Add(p);
              }
          }
          return ListaClas;
      }
        public List<clsServicioClasificador> ListarTipoClasificador()
       {
           clsServicioClasificador p;
           clsServicioClasificadorDA permiso = new clsServicioClasificadorDA();
           List<clsServicioClasificador> ListaClas = new List<clsServicioClasificador>();

           using (IDataReader dr = permiso.ListarTipoClasificador(0, 0))
           {
               while (dr.Read())
               {
                   p = new clsServicioClasificador();
                   p.IdTipoClasificador = (int)dr["IdTipoClasificador"];
                   p.NombreClasificador = (string)dr["NombreClasificador"];
                   p.EstadoRegistro = Convert.ToInt16((bool)dr["EstadoRegistro"]);
                   ListaClas.Add(p);
               }
           }
           return ListaClas;
       }
      public DataTable ListarServicioClasificadorTodo(int clas)
        {
          DataTable dt = new DataTable();
           clsServicioClasificadorDA tab = new clsServicioClasificadorDA();
           IDataReader dr = tab.ListarServicioClasificadorTodo(clas);
           
            dt.Load(dr);
            return dt;
        }
      public DataTable ListarServicioClasificadormasSeleccione(int clas)
      {
          DataTable dt = new DataTable();
         clsServicioClasificadorDA tab = new clsServicioClasificadorDA();
          IDataReader dr = tab.ListarServicioClasificadormasSeleccione(clas);
          dt.Load(dr);
         return dt;
      }
   }
}
