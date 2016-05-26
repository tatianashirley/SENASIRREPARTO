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

using wcfServicioIntercambioPago.Entidades;

namespace wcfServicioIntercambioPago.Datos
{
    
    public class clsDetalleClasificadorDA
    {
        Database db = null;

        public clsDetalleClasificadorDA()
        {
            db = DatabaseFactory.CreateDatabase("cadena");
        }

        /* Adiciona un Tipo de Clasificador */
        public void AdicionarDetalleClasificador(int IdTipoClasificador, string CodigoDetalleClasificador, string DescripcionDetalleClasificador, string ObservacionClasificador, int IdPadre, int EstadoDetalleClasificador, int EstadoRegistro)
        
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_AdicionarDetalleClasificador", IdTipoClasificador, CodigoDetalleClasificador, DescripcionDetalleClasificador, ObservacionClasificador, IdPadre, EstadoDetalleClasificador, EstadoRegistro);
            db.ExecuteNonQuery(cmd);
        }
        /* Elimina logicamente un Tipo de Clasificador */
        public Boolean EliminarDetalleClasificador(int Cod)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("Clasifiador.PR_EliminarDetalleClasificador", Cod);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* Modificar un Tipo de Clasificador */
        public void ModificarDetalleClasificador(int IdDetalleClasificador, string CodigoDetalleClasificador, string DescripcionDetalleClasificador, string ObservacionClasificador, int IdPadre, int EstadoDetalleClasificador, int EstadoRegistro)
        {
            DbCommand cmd = db.GetStoredProcCommand("CLasificador.PR_ModificarDetalleClasificador", IdDetalleClasificador, CodigoDetalleClasificador, DescripcionDetalleClasificador, ObservacionClasificador, IdPadre, EstadoDetalleClasificador, EstadoRegistro);
            db.ExecuteNonQuery(cmd);
        }

        /* Contar tipo Clasificador   */
        public IDataReader ContarDetalleClasificador(int clas)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Clasificador.PR_ContarDetalleClasificador",clas);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        ///* Lista tipos de clasificadores */
        public IDataReader ListarDetalleClasificador(int IdTipoClasificador)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarDetalleClasificador", IdTipoClasificador);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        public IDataReader ListarDetalleClasificadorCombo(int IdTipoClasificador)
        {
            DbCommand cmd = db.GetStoredProcCommand("Clasificador.PR_ListarDetalleClasificador", IdTipoClasificador);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        /* Verificar Tipos de Clasificadores*/
        public IDataReader VerificarDetalleClasificador(int IdTipoClasificador, string descrip)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Clasificador.PR_VerificarDetalleClasificador", IdTipoClasificador, descrip);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        /*     public IDataReader ListarTipoClasificador2(int Cod)
        {
            DbCommand cmd = db.GetStoredProcCommand("paListarTipoClasificador2", Cod);
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }
        public IDataReader ObtenerTipoClasificadorOblig(int Cod)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("paObtenerTipoClasificadorOblig", Cod);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
        public IDataReader VerificarTipoClasificador(string TipoClasificador)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("paVerificarTipoClasificador", TipoClasificador);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }
        */

    }
}