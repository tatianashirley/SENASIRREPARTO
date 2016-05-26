using System;
using System.Data;
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

using wcfGeo.Entidades;
using wcfGeo.Datos;

namespace wcfGeo.Logica
{
    public class clsLocalidad : clsLocalidadBE
    {
        //public clsLocalidad()
        //{
        //}

        public List<clsLocalidad> ListarPorLocalidades(string Localidad)
        {
            clsLocalidad p;
            clsLocalidadDA permiso = new clsLocalidadDA();
            List<clsLocalidad> listapermiso = new List<clsLocalidad>();

            using (IDataReader dr = permiso.ListarPorLocalidades(Localidad))
            {
                while (dr.Read())
                {
                    p = new clsLocalidad();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.IdLocalidad = (int)dr["IdLocalidad"];
                    p.NombreLocalidad = (string)dr["NombreLocalidad"];
                    p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    p.IdEstado = (int)dr["IdEstado"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsLocalidad> ListarPorLocalidadesCodigo(string Localidad)
        {
            clsLocalidad p;
            clsLocalidadDA permiso = new clsLocalidadDA();
            List<clsLocalidad> listapermiso = new List<clsLocalidad>();

            using (IDataReader dr = permiso.ListarPorLocalidades(Localidad))
            {
                while (dr.Read())
                {
                    p = new clsLocalidad();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.IdLocalidad = (int)dr["IdLocalidad"];
                    p.NombreLocalidad = (string)dr["NombreLocalidad"];
                    p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    p.IdEstado = (int)dr["IdEstado"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        //public void AdicionaDepartamento(string pNomDep)
        //{
        //    try
        //    {
        //        clsRolesDA cb = new clsRolesDA();
        //        cb.AdicionaDepartamento(pNomDep);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<clsLocalidad> ObtenerLocalidad(int pId, int Dep, int Prov, int Sec)
        {
            clsLocalidad p;
            clsLocalidadDA permiso = new clsLocalidadDA();
            List<clsLocalidad> ListaPermiso = new List<clsLocalidad>();
            using (IDataReader dr = permiso.ObtenerLocalidad(pId, Dep, Prov, Sec))
            {
                while (dr.Read())
                {
                    p = new clsLocalidad();

                    p.IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]);
                    p.IdProvincia = Convert.ToInt32(dr["IdProvincia"]);
                    p.IdSeccion = Convert.ToInt32(dr["IdSeccion"]);
                    p.IdLocalidad = Convert.ToInt32(dr["IdLocalidad"]);
                    p.NombreLocalidad = (string)dr["NombreLocalidad"];
                    p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    p.IdEstado = Convert.ToInt32(dr["IdEstado"]);

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        //public Boolean EliminarDepartamento(int pId)
        //{
        //    clsRolesDA eliR = new clsRolesDA();
        //    return eliR.EliminarDepartamento(pId);
        //}
        //public void ModificarDepartamento(int pId, string NomDep)
        //{
        //    try
        //    {
        //        clsRolesDA cb = new clsRolesDA();
        //        cb.ModificarDepartamento(pId, NomDep);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<clsLocalidad> ContarLocalidades()
        {
            clsLocalidad p;
            clsLocalidadDA permiso = new clsLocalidadDA();
            List<clsLocalidad> ListaPermiso = new List<clsLocalidad>();
            using (IDataReader dr = permiso.ContarLocalidades())
            {
                while (dr.Read())
                {
                    p = new clsLocalidad();

                    p.TotalR = (int)dr["TotalRegistros"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

    }
}

