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
    public class clsSeccion : clsSeccionBE
    {
        //public clsSeccion()
        //{
        //}

        public List<clsSeccion> ListarSecciones(int Cod, int Dep, int Prov)
        {
            clsSeccion p;
            clsSeccionDA permiso = new clsSeccionDA();
            List<clsSeccion> listapermiso = new List<clsSeccion>();

            using (IDataReader dr = permiso.ListarSecciones(Cod, Dep, Prov))
            {
                while (dr.Read())
                {
                    p = new clsSeccion();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
                    p.IdEstado = (int)dr["IdEstado"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsSeccion> ListarSeccionesPorDepartamentoPorProvincia(int Dep, int Prov)
        {
            clsSeccion p;
            clsSeccionDA permiso = new clsSeccionDA();
            List<clsSeccion> listapermiso = new List<clsSeccion>();

            using (IDataReader dr = permiso.ListarSeccionesPorDepartamentoPorProvincia(Dep, Prov))
            {
                while (dr.Read())
                {
                    p = new clsSeccion();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
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

        public List<clsSeccion> ObtenerSeccion(int pId, int Dep, int Prov)
        {
            clsSeccion p;
            clsSeccionDA permiso = new clsSeccionDA();
            List<clsSeccion> ListaPermiso = new List<clsSeccion>();
            using (IDataReader dr = permiso.ObtenerSeccion(pId, Dep, Prov))
            {
                while (dr.Read())
                {
                    p = new clsSeccion();

                    p.IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]);
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
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

        public List<clsSeccion> ContarSecciones()
        {
            clsSeccion p;
            clsSeccionDA permiso = new clsSeccionDA();
            List<clsSeccion> ListaPermiso = new List<clsSeccion>();
            using (IDataReader dr = permiso.ContarSecciones())
            {
                while (dr.Read())
                {
                    p = new clsSeccion();

                    p.TotalR = (int)dr["TotalRegistros"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

    }
}

