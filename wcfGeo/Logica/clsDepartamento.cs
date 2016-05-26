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
    public class clsDepartamento : clsDepartamentoBE
    {
        //public clsDepartamento()
        //{
        //    this.IdDepartamento = 0;            
        //    this.NombreDepartamento = "";
        //}

        public List<clsDepartamento> ListarDepartamentos()
        {
            clsDepartamento p;
            clsDepartamentoDA permiso = new clsDepartamentoDA();
            List<clsDepartamento> listapermiso = new List<clsDepartamento>();

            using (IDataReader dr = permiso.ListarDepartamentos())
            {
                while (dr.Read())
                {
                    p = new clsDepartamento();

                    p.IdDepartamento = (int)dr["IdDepartamento"];
                    p.NombreDepartamento = (string)dr["NombreDepartamento"];
                    p.IdEstado = (int)dr["IdEstado"];

                    listapermiso.Add(p);
                }
            }
            return listapermiso;
        }

        //public List<clsDepartamento> ListarDeptos(int Pagina, int Rango)
        //{
        //    clsDepartamento p;
        //    clsDepartamentoDA permiso = new clsDepartamentoDA();
        //    List<clsDepartamento> listapermiso = new List<clsDepartamento>();

        //    using (IDataReader dr = permiso.ListarDeptos(Pagina, Rango))
        //    {
        //        while (dr.Read())
        //        {
        //            p = new clsDepartamento();

        //            p.IdDepartamento = (int)dr["IdDepartamento"];
        //            p.NombreDepartamento = (string)dr["NombreDepartamento"];
        //            p.IdEstado = (int)dr["IdEstado"];

        //            listapermiso.Add(p);
        //        }
        //    }
        //    return listapermiso;
        //}

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

        public List<clsDepartamento> ObtenerDepartamento()
        {
            clsDepartamento p;
            clsDepartamentoDA permiso = new clsDepartamentoDA();
            List<clsDepartamento> ListaPermiso = new List<clsDepartamento>();
            using (IDataReader dr = permiso.ObtenerDepartamento())
            {
                while (dr.Read())
                {
                    p = new clsDepartamento();

                    p.IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]);
                    p.NombreDepartamento = (string)dr["NombreDepartamento"];
                    p.IdEstado = (int)dr["IdEstado"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

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

        public List<clsDepartamento> ContarDepartamentos()
        {
            clsDepartamento p;
            clsDepartamentoDA permiso = new clsDepartamentoDA();
            List<clsDepartamento> ListaPermiso = new List<clsDepartamento>();
            using (IDataReader dr = permiso.ContarDepartamentos())
            {
                while (dr.Read())
                {
                    p = new clsDepartamento();

                    p.TotalR = (int)dr["TotalRegistros"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

    }
}

