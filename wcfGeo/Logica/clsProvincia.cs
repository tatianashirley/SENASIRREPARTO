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
    public class clsProvincia : clsProvinciaBE
    {
        //public clsProvincia()
        //{
        //}

        public List<clsProvincia> ListarProvincias(int Dep)
        {
            clsProvincia p;
            clsProvinciaDA permiso = new clsProvinciaDA();
            List<clsProvincia> listapermiso = new List<clsProvincia>();

            using (IDataReader dr = permiso.ListarProvincias(Dep))
            {
                while (dr.Read())
                {
                    p = new clsProvincia();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.NombreProvincia = (string)dr["NombreProvincia"];
                    p.IdEstado = (int)dr["IdEstado"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsProvincia> ListarProvinciasPorDepartamento(int Dep)
        {
            clsProvincia p;
            clsProvinciaDA permiso = new clsProvinciaDA();
            List<clsProvincia> listapermiso = new List<clsProvincia>();

            using (IDataReader dr = permiso.ListarProvinciasPorDepartamento(Dep))
            {
                while (dr.Read())
                {
                    p = new clsProvincia();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.NombreProvincia = (string)dr["NombreProvincia"];
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

        public List<clsProvincia> ObtenerProvincia(int Cod, int Dep)
        {
            clsProvincia p;
            clsProvinciaDA permiso = new clsProvinciaDA();
            List<clsProvincia> ListaPermiso = new List<clsProvincia>();
            using (IDataReader dr = permiso.ObtenerProvincia(Cod, Dep))
            {
                while (dr.Read())
                {
                    p = new clsProvincia();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.NombreProvincia = (string)dr["NombreProvincia"];
                    p.IdEstado = (int)dr["IdEstado"];

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

        public List<clsProvincia> ContarProvincias()
        {
            clsProvincia p;
            clsProvinciaDA permiso = new clsProvinciaDA();
            List<clsProvincia> ListaPermiso = new List<clsProvincia>();
            using (IDataReader dr = permiso.ContarProvincias())
            {
                while (dr.Read())
                {
                    p = new clsProvincia();

                    p.TotalR = (int)dr["TotalRegistros"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

    }
}

