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
    public class clsRoles : clsRolesBE
    {
        public List<clsRoles> ListarRoles(int Pagina, int Rango)
        {
            clsRoles p;
            clsRolesDA permiso = new clsRolesDA();
            List<clsRoles> ListaPermiso = new List<clsRoles>();

            using (IDataReader dr = permiso.ListarRoles(Pagina, Rango))
            {
                while (dr.Read())
                {
                    p = new clsRoles();

                    p.IdRol = (int)dr["IdRol"];
                    p.Descripcion = (string)dr["Descripcion"];
                    p.IdEstado = (int)dr["IdEstado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public List<clsRoles> ListarRoles2(int Cod)
        {
            clsRoles p;
            clsRolesDA permiso = new clsRolesDA();
            List<clsRoles> ListaPermiso = new List<clsRoles>();

            using (IDataReader dr = permiso.ListarRoles2(Cod))
            {
                while (dr.Read())
                {
                    p = new clsRoles();

                    p.IdRol = (int)dr["IdRol"];
                    p.Descripcion = (string)dr["Descripcion"];
                    p.IdEstado = (int)dr["IdEstado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public void AdicionarRol(string Descripcion, int Estado)
        {
            try
            {
                clsRolesDA adi = new clsRolesDA();
                adi.AdicionarRol(Descripcion, Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsRoles> ObtenerRol(int Cod)
        {
            clsRoles p;
            clsRolesDA permiso = new clsRolesDA();
            List<clsRoles> ListaPermiso = new List<clsRoles>();
            using (IDataReader dr = permiso.ObtenerRol(Cod))
            {
                while (dr.Read())
                {
                    p = new clsRoles();

                    p.IdRol = (int)dr["IdRol"];
                    p.Descripcion = (string)dr["Descripcion"];
                    p.IdEstado = (int)dr["IdEstado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public List<clsRoles> ObtenerRolOblig(int Cod)
        {
            clsRoles p;
            clsRolesDA permiso = new clsRolesDA();
            List<clsRoles> ListaPermiso = new List<clsRoles>();
            using (IDataReader dr = permiso.ObtenerRolOblig(Cod))
            {
                while (dr.Read())
                {
                    p = new clsRoles();

                    p.IdRol = (int)dr["IdRol"];
                    p.Descripcion = (string)dr["Descripcion"];
                    p.IdEstado = (int)dr["IdEstado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public List<clsRoles> ContarRoles()
        {
            clsRoles p;
            clsRolesDA permiso = new clsRolesDA();
            List<clsRoles> ListaPermiso = new List<clsRoles>();
            using (IDataReader dr = permiso.ContarRoles())
            {
                while (dr.Read())
                {
                    p = new clsRoles();

                    p.TotalR = (int)dr["ContarRoles"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public List<clsRoles> VerificarRol(string Rol)
        {
            clsRoles p;
            clsRolesDA permiso = new clsRolesDA();
            List<clsRoles> ListaPermiso = new List<clsRoles>();
            using (IDataReader dr = permiso.VerificarRol(Rol))
            {
                while (dr.Read())
                {
                    p = new clsRoles();

                    p.Descripcion = (string)dr["Descripcion"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

        public Boolean EliminarRol(int Cod)
        {
            clsRolesDA eliR = new clsRolesDA();
            return eliR.EliminarRol(Cod);
        }

        public void ModificarRol(int IdRol, string Descripcion, int Estado)
        {
            try
            {
                clsRolesDA cb = new clsRolesDA();
                cb.ModificarRol(IdRol, Descripcion, Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}