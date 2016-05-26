
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

using wcfServicioIntercambioPago.Entidades;
using wcfServicioIntercambioPago.Datos;

namespace wcfServicioIntercambioPago.Logica
{
    public class clsDetalleClasificador : clsDetalleClasificadorBE
    {
        // Adiciona DEtalle Clasificador
        public void AdicionarDetalleClasificador(int IdTipoClasificador, string CodigoDetalleClasificador, string DescripcionDetalleClasificador, string ObservacionClasificador, int IdPadre, int EstadoDetalleClasificador, int EstadoRegistro)
        {
            try
            {
                clsDetalleClasificadorDA adi = new clsDetalleClasificadorDA();
                adi.AdicionarDetalleClasificador(IdTipoClasificador, CodigoDetalleClasificador, DescripcionDetalleClasificador, ObservacionClasificador, IdPadre, EstadoDetalleClasificador, EstadoRegistro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Elimina Clasficador
        public Boolean EliminarDetalleClasificador(int IdDetalleClasificador)
        {
            clsDetalleClasificadorDA eli = new clsDetalleClasificadorDA();
            return eli.EliminarDetalleClasificador(IdDetalleClasificador);
        }
        // Elimina Clasficador
        public void ModificarDetalleClasificador(int IdDetalleClasificador, string CodigoDetalleClasificador, string DescripcionDetalleClasificador, string ObservacionClasificador, int IdPadre, int EstadoDetalleClasificador, int EstadoRegistro)
        {
            try
            {
                clsDetalleClasificadorDA mod = new clsDetalleClasificadorDA();
                mod.ModificarDetalleClasificador(IdDetalleClasificador, CodigoDetalleClasificador, DescripcionDetalleClasificador, ObservacionClasificador, IdPadre, EstadoDetalleClasificador, EstadoRegistro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Contar Clasificadores
        public List<clsDetalleClasificador> ContarDetalleClasificador(int clas)
        {
            clsDetalleClasificador p;
            clsDetalleClasificadorDA permiso = new clsDetalleClasificadorDA();
            List<clsDetalleClasificador> ListaPermiso = new List<clsDetalleClasificador>();
            using (IDataReader dr = permiso.ContarDetalleClasificador(clas))
            {
                while (dr.Read())
                {
                    p = new clsDetalleClasificador();
                    p.TotalR = (int)dr["ContarDetalleClasificadores"];
                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }
     // LISTAR DETALLES 
        public List<clsDetalleClasificador> ListarDetalleClasificador(int IdTipoClasificador)
        {
           clsDetalleClasificador p;
            clsDetalleClasificadorDA permiso = new clsDetalleClasificadorDA();
            List<clsDetalleClasificador> ListaClas = new List<clsDetalleClasificador>();

            //clsDetalleClasificador item = new clsDetalleClasificador();
            //    item.IdDetalleClasificador = 0;
            //    item.CodigoDetalleClasificador = "Seleccione";
            //    ListaClas.Add(item);
           
            using (IDataReader dr = permiso.ListarDetalleClasificador(IdTipoClasificador))
            {
                while (dr.Read())
                {
                    p = new clsDetalleClasificador();
                    p.IdDetalleClasificador = (int)dr["IdDetalleClasificador"];
                    p.CodigoDetalleClasificador = (string)dr["CodigoDetalleClasificador"];
                    p.DescripcionDetalleClasificador = (string)dr["DescripcionDetalleClasificador"];
                    p.ObservacionClasificador = (string)dr["ObservacionClasificador"];
                    if ((int)dr["IdPadre"] > 0)
                       p.IdPadre = (int)dr["IdPadre"];
                    else
                       p.IdPadre = 0;
                    p.EstadoDetalleClasificador = (int)dr["IdEstadoDetalleClasificador"];    
                    p.EstadoRegistro = Convert.ToInt16((bool)dr["RegistroActivo"]);      
                    ListaClas.Add(p);
                  }
            }
            return ListaClas;
        }

        public List<clsDetalleClasificador> ListarDetalleClasificadorCombo(int IdTipoClasificador)
        {
            clsDetalleClasificador p;
            clsDetalleClasificadorDA permiso = new clsDetalleClasificadorDA();
            List<clsDetalleClasificador> ListaClas = new List<clsDetalleClasificador>();

            clsDetalleClasificador item = new clsDetalleClasificador();
            item.IdDetalleClasificador = 0;
            item.CodigoDetalleClasificador = "Seleccione";
            ListaClas.Add(item);

            using (IDataReader dr = permiso.ListarDetalleClasificador(IdTipoClasificador))
            {
                while (dr.Read())
                {
                    p = new clsDetalleClasificador();
                    p.IdDetalleClasificador = (int)dr["IdDetalleClasificador"];
                    p.CodigoDetalleClasificador = (String)dr["CodigoDetalleClasificador"];
                    p.DescripcionDetalleClasificador = (String)dr["DescripcionDetalleClasificador"];
                    p.ObservacionClasificador = (String)dr["ObservacionClasificador"];
                    p.IdTipoClasificador = (int)dr["IdTipoClasificador"];
                    if ((int)dr["IdPadre"] > 0)
                        p.IdPadre = (int)dr["IdPadre"];
                    else
                        p.IdPadre = 0;
                    p.EstadoDetalleClasificador = (int)dr["EstadoDetalleClasificador"];
                    p.EstadoRegistro = Convert.ToInt16((bool)dr["EstadoRegistro"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public List<clsDetalleClasificador> VerificarDetalleClasificador(int IdTipoClasificador, string descrip)
        {
            clsDetalleClasificador p;
            clsDetalleClasificadorDA permiso = new clsDetalleClasificadorDA();
            List<clsDetalleClasificador> ListaClas = new List<clsDetalleClasificador>();
            using (IDataReader dr = permiso.VerificarDetalleClasificador(IdTipoClasificador, descrip))
            {
                while (dr.Read())
                {
                    p = new clsDetalleClasificador();
                    p.IdDetalleClasificador = (int)dr["IdDetalleClasificador"];
                    p.CodigoDetalleClasificador = (String)dr["CodigoDetalleClasificador"];
                    p.DescripcionDetalleClasificador = (String)dr["DescripcionDetalleClasificador"];
                    p.ObservacionClasificador = (String)dr["ObservacionClasificador"];
                    if ((int)dr["IdPadre"] > 0)
                        p.IdPadre = (int)dr["IdPadre"];
                    else
                        p.IdPadre = 0;
                    p.EstadoDetalleClasificador = (int)dr["IdEstadoDetalleClasificador"];
                    p.EstadoRegistro = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }
        //obtiene directamente el IdDetalleClasificador
        public int ObtieneId(int IdTipoClasificador,string Descripcion)
        {
            DataTable dt = new DataTable();
            clsDetalleClasificadorDA val = new clsDetalleClasificadorDA();
            IDataReader dr = val.VerificarDetalleClasificador(IdTipoClasificador,Descripcion);
            dt.Load(dr);
            int idr = Convert.ToInt16(dt.Rows[0][0]);
            return idr;
        }

    }
}