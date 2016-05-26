using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.Common;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfGeo.Entidades;

namespace wcfGeo.Datos
{
    public class clsProvinciaDA
    {
        Database db = null;

        public clsProvinciaDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnGeo");
        }

        public IDataReader ListarProvincias(int Dep)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarProvincias", Dep);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        public IDataReader ListarProvinciasPorDepartamento(int Dep)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarProvinciasPorDepartamento", Dep);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        //// Otros
        //public void AdicionaDepartamento(string pNomDep)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("paG_AdicionaDepartamento", pNomDep);
        //    db.ExecuteNonQuery(cmd);
        //}

        public IDataReader ObtenerProvincia(int Cod, int Dep)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Geografico.PR_ObtenerProvincia", Cod, Dep);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        //public Boolean EliminarDepartamento(int pId)
        //{
        //    try
        //    {
        //        DbCommand dbCommand = db.GetStoredProcCommand("paG_EliminarDepartamento", pId);
        //        db.ExecuteNonQuery(dbCommand);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public void ModificarDepartamento(int Id, string NomDep)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("paG_ModificarDepartamento", Id, NomDep);
        //    db.ExecuteNonQuery(cmd);
        //}

        public IDataReader ContarProvincias()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Geografico.PR_ContarProvincias");
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
    }


}


