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
    public class clsPersonalDA
    {
        Database db = null;

        public clsPersonalDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnper");
        }

        //public IDataReader ListarPersonal(int Pagina, int Rango)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("paListarDatosUsuario", Pagina, Rango);
        //    IDataReader dataReader = db.ExecuteReader(cmd);
        //    return dataReader;
        //}

        public IDataReader ObtenerPorCI(string CI)
        {
            DbCommand cmd = db.GetStoredProcCommand("paObtenerPorCI", CI);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

    }

}