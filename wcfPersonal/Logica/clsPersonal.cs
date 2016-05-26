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

using wcfPersonal.Entidades;
using wcfPersonal.Datos;

namespace wcfPersonal.Logica
{
    public class clsPersonal : clsPersonalBE
    {
        //public List<clsPersonal> ListarPersonal(int Pagina, int Rango)
        //    {
        //        clsPersonal p;
        //        clsPersonalDA permiso = new clsPersonalDA();
        //        List<clsPersonal> ListaPermiso = new List<clsPersonal>();
        //        using (IDataReader dr = permiso.ListarPersonal(Pagina, Rango))
        //        {
        //            while (dr.Read())
        //            {
        //                p = new clsPersonal();

        //                p.cedulaACT = (string)dr["cedulaACT"];
        //                p.APPAT = (string)dr["APPAT"];
        //                p.APMAT = (string)dr["APMAT"];
        //                p.NOMBRES = (string)dr["NOMBRES"];
        //                p.fechanac = (DateTime)dr["fechanac"];

        //                ListaPermiso.Add(p);
        //            }
        //        }
        //        return ListaPermiso;
        //    }

        public List<clsPersonal> ObtenerPorCI(string CI)
        {
            clsPersonal p;
            clsPersonalDA permiso = new clsPersonalDA();
            List<clsPersonal> ListaPermiso = new List<clsPersonal>();
            using (IDataReader dr = permiso.ObtenerPorCI(CI))
            {
                while (dr.Read())
                {
                    p = new clsPersonal();

                    p.Carnet = (int)dr["Carnet"];
                    p.Paterno = (string)dr["Paterno"];
                    p.Materno = (string)dr["Materno"];
                    p.Nombre1 = (string)dr["Nombre1"];
                    p.Nombre2 = (string)dr["Nombre2"];
                    p.EstadoFuncionario = (string)dr["EstadoFuncionario"];
                    p.Funcionario = (string)dr["Funcionario"];

                    ListaPermiso.Add(p);
                }
            }
            return ListaPermiso;
        }

    }


 }