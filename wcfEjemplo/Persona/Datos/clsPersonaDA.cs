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
    public class clsPersonaDA
    {
         Database db = null;

         public clsPersonaDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }

        public IDataReader ListarPersona()
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_PersonaListar");
            IDataReader dataReader = db.ExecuteReader(cmd);
            return dataReader;
        }

        public void AdicionarPersona(int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_PersonaIns", IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
            db.ExecuteNonQuery(cmd);
        }

        public Boolean EliminarPersona(int Cod)
        {
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_Persona.Eli", Cod);
                db.ExecuteNonQuery(dbCommand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ModificarPersona(int Cod, int IdSsistema, string Descripcion, int PadreId, int Posicion, string Formulario, string RutaFormulario, int IdRol, string Imagen, int IdEstado)
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_PersonaMod", IdSsistema, Descripcion, PadreId, Posicion, Formulario, RutaFormulario, IdRol, Imagen, IdEstado);
            db.ExecuteNonQuery(cmd);
        }

        public IDataReader ObtenerPersona(Int64 NUP, string Tipo, string Matricula)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_ObtenerPersona", NUP, Tipo, Matricula);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader VerificarPersona(string sPersona)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_PersonaVerificar", sPersona);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader EncontrarPersona(string[] datos)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_BusquedaPersonaInicio", datos);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader EncontrarPersonaCI(string CI)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_BusquedaPersonaCI", CI);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader ValidarReparto(string[] datos)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_Persona_ValidarReparto", datos);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader ValidarRepartoAprox(string[] datos)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_Persona_ValidarRepartoAprox", datos);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader ValidarCC(string[] datos)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PR_Persona_ValidarCC", datos);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader AutomaticoRepetido(string Matricula)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.AutomaticoRepetido", Matricula);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        public IDataReader PermisoManual(string Matricula)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.PermisoManual", Matricula);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }


        internal IDataReader EncontrarAutomaticoCI(string NumeroDocumento)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.EncontrarAutomaticoCI", NumeroDocumento);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        internal IDataReader EncontrarAutomatico(string[] datos)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.EncontrarAutomatico", datos);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
            return dataReader;
        }

        internal void RenunciaAutomatico(string NUP)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Persona.RenunciaAutomatico", NUP);
            IDataReader dataReader = db.ExecuteReader(dbCommand);
        }
    }
}