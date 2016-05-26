using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wcfEjemplo.Datos
{
    public class clsClasificadorEmpDA
    {
        Database db = null;

        public clsClasificadorEmpDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }

        //* BuscarEmpresa   */
        public IDataReader EmpresaEncontrar(string RUC, string Nombre)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Clasificador.PR_EmpresaEncontrar",RUC,Nombre);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
    }
}