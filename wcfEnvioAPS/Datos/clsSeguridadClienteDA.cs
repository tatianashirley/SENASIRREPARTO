using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using SQLSPExecuter;

using System.Data.SqlClient;

namespace wcfEnvioAPS.Datos
{
    public class clsSeguridadClienteDA
    {
        Database db = null;
        public clsSeguridadClienteDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnsenarit");
        }

        public DataTable ListaDatosConexionDA(int IdConexion)
        {
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DbCommand objCommand = db.GetSqlStringCommand("SELECT * FROM Seguridad.FN_ListaDatosConexion(@IdConexion)");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            db.AddInParameter(objCommand, "@IdConexion", DbType.Int32, IdConexion); //@IdConexion
            //db.AddInParameter(objCommand, "@Value2", DbType.String, Param2Value); //@Value2
            DataTable objDataTable = new DataTable();
            objDataTable.Load(db.ExecuteReader(objCommand));
            return objDataTable;            
        }

        public Int32 GetSeqNumbers(int Value1)
        {
            //Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DbCommand objCommand = db.GetSqlStringCommand("SELECT @result = dbo.fnSeqNumbers(@Value1);");
            objCommand.CommandTimeout = 0;  //Si no se pone da 40s, con 0 espera por siempre
            db.AddInParameter(objCommand, "@Value1", DbType.Int32, Value1); //@Value1
            //db.AddInParameter(objCommand, "@Value2", DbType.String, Param2Value); //@Value2
            db.AddOutParameter(objCommand, "@result", DbType.Int32, 0);
            db.ExecuteNonQuery(objCommand);
            return (int)(db.GetParameterValue(objCommand, "@result"));
        }
    }
}