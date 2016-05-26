using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Data.Common;
using System.Collections.Generic;



namespace WcfServicioClasificador.Datos
{
    
    public class clsServicioClasificadorDA
    {
        Database db = null;

        public clsServicioClasificadorDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }
        //* Contar servicio Clasificador   */
        public IDataReader ContarServicioClasificador()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Clasificador.PR_ContarServicioClasificador");
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
        /* Lista tipos de clasificadores */
        public IDataReader ListarTipoClasificador(int Pagina, int Rango)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarTipoClasificador", Pagina, Rango);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        /* Lista tipos de clasificadores */
        public IDataReader ListarServicioClasificador(int Pagina, int Rango,int clas)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarServicioClasificador", Pagina, Rango, clas);
            
            IDataReader dataReader = db.ExecuteReader(cmd);
            
            return dataReader;
        }
        public IDataReader ListarServicioClasificadorTodo(int clas)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ServicioClasificador", clas);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        public IDataReader ListarServicioClasificadormasSeleccione(int clas)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ServicioClasificador", clas);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
   
    }
}