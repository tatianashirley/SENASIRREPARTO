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
    public class clsSeccion : clsSeccionBE
    {
        public clsSeccion()
        {
        }

        public List<clsSeccion> ListarPorLocalidades(string Localidad)
        {
            clsSeccion p;
            clsSeccionDA permiso = new clsSeccionDA();
            List<clsSeccion> listapermiso = new List<clsSeccion>();

            using (IDataReader dr = permiso.ListarPorLocalidades(Localidad))
            {
                while (dr.Read())
                {
                    p = new clsSeccion();

                    p.ID_Departamento = (int)dr["ID_Departamento"];
                    p.ID_Provincia = (int)dr["ID_Provincia"];
                    p.ID_Seccion = (int)dr["ID_Seccion"];
                    p.Nombre_Seccion = (string)dr["Nombre_Seccion"];

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
        //public List<clsSeccion> ObtieneDepartamentoPorId(int pId)
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

