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
    public class clsGeoDA
    {
        Database db = null;

        public clsGeoDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnGeo");
        }
        //public IDataReader ListarPorLocalidades(string Localidad)
        //{
        //    DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarPorLocalidadV", Localidad);
        //    IDataReader dr = db.ExecuteReader(comando);
        //    return dr;
        //}
        public IDataReader  ListarPorNombreLocalidadV(string Localidad)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarPorLocalidadV", Localidad);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarDepartamentosV()
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarDepartamentosV");
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarProvinciasV(int Dep)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarProvinciasV", Dep);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarSeccionesV(int Dep, int Prov)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarSeccionesV", Dep, Prov);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarLocalidadesV(int Dep, int Prov, int Sec)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ListarLocalidadesV", Dep, Prov, Sec);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        public IDataReader ObtenerCodigoPorNombreLocalidadV(string Localidad)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ObtenerCodigoPorNombreLocalidadV", Localidad);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }

        //public IDataReader ListarLocalidades_Codigos(int Dep, int Prov, int Sec)
        //{
        //    DbCommand comando = db.GetStoredProcCommand("Geografico.PR_LocalidadListarLocalidades", Dep, Prov, Sec);
        //    IDataReader dr = db.ExecuteReader(comando);
        //    return dr;
        //}
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

        
    }


}


