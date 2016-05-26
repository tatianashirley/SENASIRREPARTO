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
    public class clsDepartamentoDA
    {
        Database db = null;

        public clsDepartamentoDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnGeo");
        }

        public IDataReader ListarDepartamentos()
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarDepartamentos");
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        //public IDataReader ListarDeptos(int Pagina, int Rango)
        //{
        //    DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarDeptos", Pagina, Rango);
        //    IDataReader dr = db.ExecuteReader(comando);
        //    return dr;
        //}

        //// Otros
        //public void AdicionaDepartamento(string pNomDep)
        //{
        //    DbCommand cmd = db.GetStoredProcCommand("paG_AdicionaDepartamento", pNomDep);
        //    db.ExecuteNonQuery(cmd);
        //}
        public IDataReader ObtenerDepartamento()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Geografico.PR_ObtenerDepartamento");
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

        public IDataReader ContarDepartamentos()
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Geografico.PR_ContarDepartamentos");
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
    }


}


