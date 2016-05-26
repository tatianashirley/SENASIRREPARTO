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
    public class clsSeccionDA
    {
        Database db = null;

        public clsSeccionDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnGeo");
        }

        public IDataReader ListarSecciones(int Cod, int Dep, int Prov)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarSecciones", Cod, Dep, Prov);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        public IDataReader ListarSeccionesPorDepartamentoPorProvincia(int Dep, int Prov)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarSeccionesPorDepartamentoPorProvincia", Dep, Prov);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        //// Otros
        //public void AdicionaDepartamento(string pNomDep)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("paG_AdicionaDepartamento", pNomDep);
        //    db.ExecuteNonQuery(cmd);
        //}

        public IDataReader ObtenerSeccion(int pId, int Dep, int Prov)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Geografico.PR_ObtenerSeccion", pId, Dep, Prov);
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

        public IDataReader ContarSecciones()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Geografico.PR_ContarSecciones");
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
    }


}


