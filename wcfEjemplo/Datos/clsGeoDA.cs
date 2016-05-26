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

using wcfEjemplo.Entidades;

namespace wcfEjemplo.Datos
{
    public class clsGeoDA
    {
        Database db = null;

        public clsGeoDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }
        public IDataReader ListarPorLocalidades(string Localidad)
        {
            DbCommand comando = db.GetStoredProcCommand("paListarPorLocalidad", Localidad);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader  ListarPorNombreLocalidades(string Localidad)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_LocalidadListarPorNombre", Localidad);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarDepartamentos()
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_DepartamentosListar");
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarProvincias(int Dep)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_ProvinciasListar", Dep);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarSecciones(int Dep, int Prov)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_SeccionesListar", Dep, Prov);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarLocalidades(int Dep, int Prov, int Sec)
        {
            DbCommand comando = db.GetStoredProcCommand("Geografico.PR_LocalidadListar", Dep, Prov, Sec);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
        }
        public IDataReader ListarLocalidades_Codigos(int Dep, int Prov, int Sec)
        {
            DbCommand comando = db.GetStoredProcCommand("PR_LocalidadListarLocalidades", Dep, Prov, Sec);
            IDataReader dr = db.ExecuteReader(comando);
            return dr;
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

        
    }


}


