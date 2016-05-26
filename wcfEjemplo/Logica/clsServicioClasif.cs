
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

using wcfEjemplo.Entidades;
using wcfEjemplo.Datos;

namespace wcfEjemplo.Logica
{
    public class clsServicioClasif : clsServicioClasificadorBE
    {
      public List<clsServicioClasif> ContarServicioClasificador()
        {
            clsServicioClasif p;
            clsServicioClasifDA permiso = new clsServicioClasifDA();
            List<clsServicioClasif> ListaPermiso = new List<clsServicioClasif>();
            using (IDataReader dr = permiso.ContarServicioClasificador())
            {
                while (dr.Read())
                {
                    p = new clsServicioClasif();
                   ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

      public List<clsServicioClasif> ListarTipoClasificadormasalgo()
      {
          clsServicioClasif p;
          clsServicioClasifDA permiso = new clsServicioClasifDA();
          List<clsServicioClasif> ListaClas = new List<clsServicioClasif>();

          clsServicioClasif item = new clsServicioClasif();
          item.NombreClasificador = "Selecccione";
          ListaClas.Add(item);

          using (IDataReader dr = permiso.ListarTipoClasificador(0, 0))
          {
              while (dr.Read())
              {
                  p = new clsServicioClasif();
                  p.IdTipoClasificador = (int)dr["IdTipoClasificador"];
                  p.NombreClasificador = (string)dr["NombreClasificador"];
                  p.EstadoRegistro = Convert.ToInt16((bool)dr["EstadoRegistro"]);
                  ListaClas.Add(p);
              }
          }
          return ListaClas;
      }
        public List<clsServicioClasif> ListarTipoClasificador()
       {
           clsServicioClasif p;
           clsServicioClasifDA permiso = new clsServicioClasifDA();
           List<clsServicioClasif> ListaClas = new List<clsServicioClasif>();

           using (IDataReader dr = permiso.ListarTipoClasificador(0, 0))
           {
               while (dr.Read())
               {
                   p = new clsServicioClasif();
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
           clsServicioClasifDA tab = new clsServicioClasifDA();
           IDataReader dr = tab.ListarServicioClasificadorTodo(clas);
           
            dt.Load(dr);
            return dt;
        }
      public DataTable ListarServicioClasificadormasSeleccione(int clas)
      {
          DataTable dt = new DataTable();
         clsServicioClasifDA tab = new clsServicioClasifDA();
          IDataReader dr = tab.ListarServicioClasificadormasSeleccione(clas);
          dt.Load(dr);
         return dt;
      }
      public int EncontrarIdPorDescripcion(string nombre, int tipo)
      {
          clsServicioClasifDA permiso = new clsServicioClasifDA();
          int result = 0;

          using (IDataReader dr = permiso.EncontrarIdPorDescripcion(nombre, tipo))
          {
              while (dr.Read())
              {
                  if (dr["IdDetalleClasificador"] != DBNull.Value)
                      result = (int)dr["IdDetalleClasificador"];
                  else
                      result = 0;
              }
          }
          return result;
      }

      public DataTable ListarDocumentoTramite(int tramite)
      {
          DataTable dt = new DataTable();
          clsServicioClasifDA tab = new clsServicioClasifDA();
          IDataReader dr = tab.ListarDocumentoTramite(tramite);
          dt.Load(dr);
          return dt;
      }
   }
}
