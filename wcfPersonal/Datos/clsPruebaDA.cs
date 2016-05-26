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

using wcfPersonal.Entidades;

namespace wcfPersonal.Datos
{
    public class clsPruebaDA
    {
        Database db = null;

        public clsPruebaDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnEjemplo");
        }

        public IDataReader _ListarTodos()
        {
            DbCommand cmd = db.GetStoredProcCommand("pa_ListarTodos");
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;

        }
        public IDataReader _ListarPorDatos(string paterno, string materno, string nombre1, string nombre2, string carnet, string fechanac, string presicion)
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_BusquedaPersona", paterno, materno, nombre1, nombre2, carnet, fechanac, presicion);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        public IDataReader _ListarPorCI(string CI)
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_BusquedaPersonaCI", CI);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

    }

}