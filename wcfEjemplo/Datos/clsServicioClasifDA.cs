using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Resources;
using System.Collections.Generic;

using wcfEjemplo.Entidades;


namespace wcfEjemplo.Datos
{
    
    public class clsServicioClasifDA
    {
        Database db = null;

        public clsServicioClasifDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
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
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarServicioClasificador", Pagina, Rango,clas);
            
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
        public IDataReader EncontrarIdPorDescripcion(string nombre, int tipo)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_EncontrarIdPorDescripcion", nombre, tipo);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        internal IDataReader ListarDocumentoTramite(int tramite)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarDocumentoTramite", tramite);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
    }
}