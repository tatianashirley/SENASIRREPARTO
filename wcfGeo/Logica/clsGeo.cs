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
    public class clsGeo : clsGeoBE
    {
        //public clsGeo()
        //{
        //    this.IdDepartamento = 0;            
        //    this.NombreDepartamento = "";
        //}

        //public List<clsGeo> ListarPorLocalidades(string Localidad)
        //{
        //    clsGeo p;
        //    clsGeoDA permiso = new clsGeoDA();
        //    List<clsGeo> listapermiso = new List<clsGeo>();

        //    using (IDataReader dr = permiso.ListarPorLocalidades(Localidad))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsGeo();
        //            p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
        //            p.IdDepartamento = (int)dr["IdDepartamento"];
        //            p.NombreDepartamento = (string)dr["NombreDepartamento"];
        //            p.IdProvincia = (int)dr["IdProvincia"];
        //            p.NombreProvincia = (string)dr["NombreProvincia"];
        //            p.IdSeccion = (int)dr["IdSeccion"];
        //            p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
        //            p.DetalleSeccion = (string)dr["DetalleSeccion"];
        //            p.IdLocalidad = (int)dr["IdLocalidad"];
        //            p.NombreLocalidad = (string)dr["NombreLocalidad"];
        //            listapermiso.Add(p);
        //        }
        //    }
        //    return listapermiso;
        //}

        public List<clsGeo> ListarPorNombreLocalidadV(string Localidad)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            using (IDataReader dr = permiso.ListarPorNombreLocalidadV(Localidad))
            {
                while (dr.Read())
                {
                    p = new clsGeo();
                    p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.NombreDepartamento = (string)dr["NombreDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.NombreProvincia = (string)dr["NombreProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
                    p.DetalleSeccion = (string)dr["DetalleSeccion"];
                    p.IdLocalidad = (int)dr["IdLocalidad"];
                    p.NombreLocalidad = (string)dr["NombreLocalidad"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsGeo> ListarDepartamentosV()
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreDepartamento = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarDepartamentosV())
            {
                while (dr.Read())
                {
                    p = new clsGeo();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.NombreDepartamento = (string)dr["NombreDepartamento"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsGeo> ListarProvinciasV(int Dep)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreProvincia = "Selecccione";
            listapermiso.Add(item);
        
            using (IDataReader dr = permiso.ListarProvinciasV(Dep))
            {
                while (dr.Read())
                {
                    p = new clsGeo();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.NombreProvincia = (string)dr["NombreProvincia"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsGeo> ListarSeccionesV(int Dep, int Sec)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreSeccionMunicipal = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarSeccionesV(Dep, Sec))
            {
                while (dr.Read())
                {
                    p = new clsGeo();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsGeo> ListarLocalidadesV(int Dep, int Prov, int Sec)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreLocalidad = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarLocalidadesV(Dep, Prov, Sec))
            {
                while (dr.Read())
                {
                    p = new clsGeo();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                  //  p.Localidad = (int)dr["Localidad"];
                    p.IdLocalidad = (int)dr["IdLocalidad"];
                    p.NombreLocalidad = (string)dr["NombreLocalidad"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsGeo> ObtenerCodigoPorNombreLocalidadV(string Localidad)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            using (IDataReader dr = permiso.ObtenerCodigoPorNombreLocalidadV(Localidad))
            {
                while (dr.Read())
                {
                    p = new clsGeo();
                    p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    //p.IdDepartamento = (int)dr["IdDepartamento"];
                    //p.NombreDepartamento = (string)dr["NombreDepartamento"];
                    //p.IdProvincia = (int)dr["IdProvincia"];
                    //p.NombreProvincia = (string)dr["NombreProvincia"];
                    //p.IdSeccion = (int)dr["IdSeccion"];
                    //p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
                    //p.DetalleSeccion = (string)dr["DetalleSeccion"];
                    //p.IdLocalidad = (int)dr["IdLocalidad"];
                    //p.NombreLocalidad = (string)dr["NombreLocalidad"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        //public List<clsGeo> ListarLocalidades_Codigos(int Dep, int Prov, int Sec)
        //{
        //    clsGeo p;
        //    clsGeoDA permiso = new clsGeoDA();
        //    List<clsGeo> listapermiso = new List<clsGeo>();

        //    clsGeo item = new clsGeo();
        //    item.NombreLocalidad = "Selecccione";
        //    listapermiso.Add(item);

        //    using (IDataReader dr = permiso.ListarLocalidades_Codigos(Dep, Prov, Sec))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsGeo();

        //            p.IdDepartamento = (int)dr["IdDepartamento"];
        //            p.IdProvincia = (int)dr["IdProvincia"];
        //            p.IdSeccion = (int)dr["IdSeccion"];
        //            p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
        //            p.IdLocalidad = (int)dr["IdLocalidad"];
        //            p.NombreLocalidad = (string)dr["NombreLocalidad"];

        //            listapermiso.Add(p);
        //        }
        //    }
        //    return listapermiso;
        //}

    }
}

