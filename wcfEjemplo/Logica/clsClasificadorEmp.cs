using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using wcfEjemplo.Datos;

namespace wcfEjemplo.Logica
{
    public class clsClasificadorEmp
    {
        public DataTable EmpresaEncontrar(string RUC, string Nombre)
        {
            DataTable dt = new DataTable();
            clsClasificadorEmpDA c = new clsClasificadorEmpDA();
            IDataReader dr = c.EmpresaEncontrar(RUC,Nombre);
            dt.Load(dr);
            return dt;
        }
    }
}