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
    public class clsLocalidad : clsLocalidadBE
    {
        public clsLocalidad()
        {
        }

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

                    p.ID_Departamento = (int)dr["ID_Departamento"];
                    p.ID_Provincia = (int)dr["ID_Provincia"];
                    p.ID_Seccion = (int)dr["ID_Seccion"];
                    p.ID_Localidad = (int)dr["ID_Localidad"];
                    p.Nombre_Localidad = (string)dr["Nombre_Localidad"];

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
                    p.Localidad = (int)dr["Localidad"];
                    p.ID_Departamento = (int)dr["ID_Departamento"];
                    p.ID_Provincia = (int)dr["ID_Provincia"];
                    p.ID_Seccion = (int)dr["ID_Seccion"];
                    p.ID_Localidad = (int)dr["ID_Localidad"];
                    p.Nombre_Localidad = (string)dr["Nombre_Localidad"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        //public void AdicionaDepartamento(string pNomDep)
        //{
        //    try
        //    {
        //        clsDepartamentoDA cb = new clsDepartamentoDA();
        //        cb.AdicionaDepartamento(pNomDep);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<clsLocalidad> ObtieneDepartamentoPorId(int pId)
        //{
        //    clsDepartamento p;
        //    clsDepartamentoDA permiso = new clsDepartamentoDA();
        //    List<clsDepartamento> ListaPermiso = new List<clsDepartamento>();
        //    using (IDataReader dr = permiso.ObtieneDepartamentoPorId(pId))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsDepartamento();

        //            p.ID_Departamento = Convert.ToInt32(dr["ID_Departamento"]);
        //            p.Nombre_Departamento = (string)dr["Nombre_Departamento"];

        //            ListaPermiso.Add(p);
        //        }
        //    }
        //    return ListaPermiso;
        //}
        //public Boolean EliminarDepartamento(int pId)
        //{
        //    clsDepartamentoDA eliR = new clsDepartamentoDA();
        //    return eliR.EliminarDepartamento(pId);
        //}
        //public void ModificarDepartamento(int pId, string NomDep)
        //{
        //    try
        //    {
        //        clsDepartamentoDA cb = new clsDepartamentoDA();
        //        cb.ModificarDepartamento(pId, NomDep);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



    }
}

