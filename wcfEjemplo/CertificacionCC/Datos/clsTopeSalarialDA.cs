using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace wcfEjemplo.Datos
{
    public class clsTopeSalarialDA
    {
         Database db = null;

         public clsTopeSalarialDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstrD");
        }

         public IDataReader EncuentraTopePeriodo(string periodo)
         {
             DbCommand cmd = db.GetStoredProcCommand("CertificacionCC.PR_EncuentraTopePorPeriodo", periodo);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }
    }
}