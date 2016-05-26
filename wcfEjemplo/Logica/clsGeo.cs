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

using wcfEjemplo.Entidades;
using wcfEjemplo.Datos;

namespace wcfEjemplo.Logica
{
    public class clsGeo : clsGeoBE
    {
        public clsGeo()
        {
            this.IdDepartamento = 0;            
            this.NombreDepartamento = "";
        }

        public List<clsGeo> ListarPorLocalidades(string Localidad)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            using (IDataReader dr = permiso.ListarPorLocalidades(Localidad))
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

        public List<clsGeo> ListarPorNombreLocalidades(string Localidad)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            using (IDataReader dr = permiso.ListarPorNombreLocalidades(Localidad))
            {
                while (dr.Read())
                {
                    p = new clsGeo();
                    if(!DBNull.Value.Equals(dr["CodigoLocalidad"]))
                        p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    else
                        p.CodigoLocalidad = 0;

                    if (!DBNull.Value.Equals(dr["IdDepartamento"]))
                        p.IdDepartamento = (int)dr["IdDepartamento"];
                    else
                        p.IdDepartamento = 0;

                    if (!DBNull.Value.Equals(dr["NombreDepartamento"]))
                        p.NombreDepartamento = (string)dr["NombreDepartamento"];
                    else
                        p.NombreDepartamento = string.Empty;

                    if (!DBNull.Value.Equals(dr["IdProvincia"]))
                        p.IdProvincia = (int)dr["IdProvincia"];
                    else
                        p.IdProvincia = 0;

                    if (!DBNull.Value.Equals(dr["NombreProvincia"]))
                        p.NombreProvincia = (string)dr["NombreProvincia"];
                    else
                        p.NombreProvincia = string.Empty;

                    if (!DBNull.Value.Equals(dr["IdSeccion"]))
                        p.IdSeccion = (int)dr["IdSeccion"];
                    else
                        p.IdSeccion = 0;

                    if (!DBNull.Value.Equals(dr["NombreSeccionMunicipal"]))
                        p.NombreSeccionMunicipal = (string)dr["NombreSeccionMunicipal"];
                    else
                        p.NombreSeccionMunicipal = string.Empty;

                    if (!DBNull.Value.Equals(dr["DetalleSeccion"]))
                        p.DetalleSeccion = (string)dr["DetalleSeccion"];
                    else
                        p.DetalleSeccion = string.Empty;

                    if (!DBNull.Value.Equals(dr["IdLocalidad"]))
                        p.IdLocalidad = (int)dr["IdLocalidad"];
                    else
                        p.IdLocalidad = 0;

                    if (!DBNull.Value.Equals(dr["NombreLocalidad"]))
                        p.NombreLocalidad = (string)dr["NombreLocalidad"];
                    else
                        p.NombreLocalidad = string.Empty;

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        public List<clsGeo> ListarDepartamentos()
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreDepartamento = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarDepartamentos())
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

        public List<clsGeo> ListarProvincias(int Dep)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreProvincia = "Selecccione";
            listapermiso.Add(item);
        
            using (IDataReader dr = permiso.ListarProvincias(Dep))
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

        public List<clsGeo> ListarSecciones(int Dep, int Sec)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreSeccionMunicipal = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarSecciones(Dep, Sec))
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

        public List<clsGeo> ListarLocalidades(int Dep, int Prov, int Sec)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreLocalidad = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarLocalidades(Dep, Prov, Sec))
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
        public List<clsGeo> ListarLocalidades_Codigos(int Dep, int Prov, int Sec)
        {
            clsGeo p;
            clsGeoDA permiso = new clsGeoDA();
            List<clsGeo> listapermiso = new List<clsGeo>();

            clsGeo item = new clsGeo();
            item.NombreLocalidad = "Selecccione";
            listapermiso.Add(item);

            using (IDataReader dr = permiso.ListarLocalidades_Codigos(Dep, Prov, Sec))
            {
                while (dr.Read())
                {
                    p = new clsGeo();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.IdProvincia = (int)dr["IdProvincia"];
                    p.IdSeccion = (int)dr["IdSeccion"];
                    p.CodigoLocalidad = (int)dr["CodigoLocalidad"];
                    p.IdLocalidad = (int)dr["IdLocalidad"];
                    p.NombreLocalidad = (string)dr["NombreLocalidad"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

    }
}

