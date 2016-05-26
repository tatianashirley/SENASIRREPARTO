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
    public class clsRolesDA
    {
        Database db = null;

        public clsRolesDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }

        public IDataReader ListarRoles(int Pagina, int Rango)
        {
            DbCommand cmd = db.GetStoredProcCommand("paListarRoles", Pagina, Rango);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        public IDataReader ListarRoles2(int Cod)
        {
            DbCommand cmd = db.GetStoredProcCommand("paListarRoles2", Cod);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        public void AdicionarRol(string Descripcion, int Estado)
        {
            DbCommand cmd = db.GetStoredProcCommand("paAdicionarRol", Descripcion, Estado);
            db.ExecuteNonQuery(cmd);
        }

        public IDataReader ObtenerRol(int Cod)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("paObtenerRol", Cod);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader ObtenerRolOblig(int Cod)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("paObtenerRolOblig", Cod);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader ContarRoles()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("paContarRoles");
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader VerificarRol(string Rol)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("paVerificarRol", Rol);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public Boolean EliminarRol(int Cod)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("paEliminarRol", Cod);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ModificarRol(int IdRol, string Descripcion, int Estado)
        {
            DbCommand cmd = db.GetStoredProcCommand("paModificarRol", IdRol, Descripcion, Estado);
            db.ExecuteNonQuery(cmd);
        }

    }
}