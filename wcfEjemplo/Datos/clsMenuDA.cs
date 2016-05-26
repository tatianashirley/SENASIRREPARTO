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
    public class clsMenuDA
    {
        Database db = null;

    //    public clsMenuDA()
    //    {
    //        db = DatabaseFactory.CreateDatabase("cnnSS");
    //    }

    //    public IDataReader ListarMenu(int Pagina, int Rango)
    //    {
    //        DbCommand cmd = db.GetStoredProcCommand("paListarMenu", Pagina, Rango);
    //        IDataReader dataReader = db.ExecuteReader(cmd);
    //        return dataReader;
    //    }

    //    public void AdicionarMenu(int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
    //    {
    //        DbCommand cmd = db.GetStoredProcCommand("paAdicionarMenu", IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
    //        db.ExecuteNonQuery(cmd);
    //    }

    //    public Boolean EliminarMenu(int Cod)
    //    {
    //        try
    //        {
    //            DbCommand dbCommand = db.GetStoredProcCommand("paEliminarMenu", Cod);
    //            db.ExecuteNonQuery(dbCommand);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    public void ModificarMenu(int Cod, int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
    //    {
    //        DbCommand cmd = db.GetStoredProcCommand("paModificarMenu", IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
    //        db.ExecuteNonQuery(cmd);
    //    }

    //    public IDataReader ObtenerMenu(int Cod)
    //    {
    //        DbCommand dbCommand = db.GetStoredProcCommand("paObtenerMenu", Cod);
    //        IDataReader dataReader = db.ExecuteReader(dbCommand);
    //        return dataReader;
    //    }

    //    public IDataReader ContarMenu()
    //    {
    //        DbCommand dbCommand = db.GetStoredProcCommand("paContarMenu");
    //        IDataReader dataReader = db.ExecuteReader(dbCommand);
    //        return dataReader;
    //    }

    //    public IDataReader VerificarMenu(string sMenu)
    //    {
    //        DbCommand dbCommand = db.GetStoredProcCommand("paVerificarMenu", sMenu);
    //        IDataReader dataReader = db.ExecuteReader(dbCommand);
    //        return dataReader;
    //    }

    }

}