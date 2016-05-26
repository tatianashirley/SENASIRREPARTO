using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Resources;
using System.Collections.Generic;

using wcfEjemplo.Entidades;
using System.Configuration;

namespace wcfEjemplo.Datos
{
    public class clsNovedadesDA
    {
         Database db = null;

         public clsNovedadesDA()
        {
            db = DatabaseFactory.CreateDatabase("cnnstr");
        }

        /*
        public void AdicionarPersona(int IdFuncionarioRegistro, int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstado,  int CUA, string Matricula, int NUB, string NumeroDocumento, string  ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, DateTime  FechaNacimiento, DateTime FechaFallecimiento,  int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono, int RegistroActivo, out string mensaje, out int retorno_proc  )
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_PersonaIns", IdFuncionarioRegistro, IdTipoDocumento, IdEstadoCivil, IdEntidadGestora, IdSexo, IdEstado,  CUA, Matricula, NUB, NumeroDocumento, ComplementoSEGIP, IdDocumentoExpedido, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, ApellidoCasada, FechaNacimiento, FechaFallecimiento,  IdPaisResidencia, CorreoElectronico, Celular, Direccion, idLocalidad, Telefono,  RegistroActivo, mensaje, retorno_proc  );
            db.ExecuteNonQuery(cmd);
        }
		
        public void ModificarPersona(int IdFuncionarioRegistro, string NUP,int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstado,  int CUA, string Matricula, int NUB, string NumeroDocumento, string  ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, DateTime  FechaNacimiento, DateTime FechaFallecimiento,  int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono, int RegistroActivo, out string mensaje, out int retorno_proc  )
        {
            DbCommand cmd = db.GetStoredProcCommand("Persona.PR_PersonaMod", IdFuncionarioRegistro, NUP, IdTipoDocumento, IdEstadoCivil, IdEntidadGestora, IdSexo, IdEstado,  CUA, Matricula, NUB, NumeroDocumento, ComplementoSEGIP, IdDocumentoExpedido, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, ApellidoCasada, FechaNacimiento, FechaFallecimiento,  IdPaisResidencia, CorreoElectronico, Celular, Direccion, idLocalidad, Telefono,  RegistroActivo, mensaje, retorno_proc  );
            db.ExecuteNonQuery(cmd);
        }
        */

         /* Lista Clasificador por Tipos */
         public IDataReader ListarClasifporTipo(int tipoclasificador)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarClasifporTipo", tipoclasificador);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         /* Lista tipos de Tipos de Novedades*/
         public IDataReader ListarNovedadesPorTipo(int CodTipo, DateTime fechainicio, DateTime fechafin,string estado)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarNovedadesTipo", CodTipo, fechainicio, fechafin,estado);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }
        
         public void ApruebaNovedad(int IdActualizacion, int Estado	, string DocumentoAprobacion, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection("Database=SENARIT; Server=srvproceso; Integrated Security = True");
             SqlCommand cmd = new SqlCommand("Novedades.PR_NovedadesApRec", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@IdActualizacion", SqlDbType.Int);
             cmd.Parameters.Add("@Estado", SqlDbType.Int);
             cmd.Parameters.Add("@DocumentoAprobacion", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@IdFuncionarioAprobacion", SqlDbType.Int);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@IdActualizacion"].Value = IdActualizacion;
             cmd.Parameters["@Estado"].Value = Estado;
             cmd.Parameters["@DocumentoAprobacion"].Value = DocumentoAprobacion;
             cmd.Parameters["@IdFuncionarioAprobacion"].Value = 10000;
             //cmd.Parameters["@mensaje"].Value = "";
             //cmd.Parameters["@retorno_proc"].Value = 0;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
             

         }

         public void EliminaNovedad(int IdActualizacion, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection("Database=SENARIT; Server=srvproceso; Integrated Security = True");
             SqlCommand cmd = new SqlCommand("Novedades.PR_NovedadesElimina", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@IdActualizacion", SqlDbType.Int);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@IdActualizacion"].Value = IdActualizacion;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }

         public void AplicaNovedad(int IdActualizacion, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection("Database=SENARIT; Server=srvproceso; Integrated Security = True");
             SqlCommand cmd = new SqlCommand("Novedades.PR_NovedadesAplica", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@IdActualizacion", SqlDbType.Int);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@IdActualizacion"].Value = IdActualizacion;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }

         public void Form02ValidaCerti(int no_certif, string claseCC,out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection("Database=SENARIT; Server=srvproceso; Integrated Security = True");
             SqlCommand cmd = new SqlCommand("Novedades.PR_Form02ValidaCerti", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@no_certif", SqlDbType.Int);
             cmd.Parameters.Add("@claseCC", SqlDbType.VarChar, 2);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@no_certif"].Value = no_certif;
             cmd.Parameters["@claseCC"].Value = claseCC;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }

         public IDataReader Form02BuscaCerti(int no_certif, string claseCC)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form02BuscaCerti", no_certif,claseCC);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

 
         public void Form02ValidaInsercion(string NumeroDocumento, string ComplementoSEGIP, string NumRa, string FechaRa, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection("Database=SENARIT; Server=srvproceso; Integrated Security = True");
             SqlCommand cmd = new SqlCommand("Novedades.PR_Form02ValidaInsercion", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20);
             cmd.Parameters.Add("@ComplementoSEGIP", SqlDbType.VarChar, 2);
             cmd.Parameters.Add("@NumRa", SqlDbType.VarChar, 7);
             cmd.Parameters.Add("@FechaRa", SqlDbType.VarChar, 8);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters["@NumeroDocumento"].Value = NumeroDocumento;
             cmd.Parameters["@ComplementoSEGIP"].Value = ComplementoSEGIP;
             cmd.Parameters["@NumRa"].Value = NumRa;
             cmd.Parameters["@FechaRa"].Value = FechaRa;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }

         public void Form02Ins(string NUP, string CUA, string PrimerApellido,string SegundoApellido, string PrimerNombre, string SegundoNombre,
             string NumeroDocumento,string IdFuncionarioRegistro, string IdInstitucionSolicitante,string DocumentoRespaldo, string IdTipoDocumento, string IdDocumentoExpedido,
             string ComplementoSEGIP, string NumRa, string FechaRa, out string mensaje, out int retorno_proc)
         {
             SqlConnection conn = new SqlConnection("Database=SENARITD; Server=serv01\beta; Integrated Security = True");
             SqlCommand cmd = new SqlCommand("Novedades.PR_Form02Ins", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@NUP", SqlDbType.VarChar, 20);
             cmd.Parameters.Add("@CUA", SqlDbType.VarChar, 20);
             cmd.Parameters.Add("@PrimerApellido", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@SegundoApellido", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@PrimerNombre", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@SegundoNombre", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@IdFuncionarioRegistro", SqlDbType.VarChar, 10);
             cmd.Parameters.Add("@IdInstitucionSolicitante", SqlDbType.VarChar, 10);
             cmd.Parameters.Add("@DocumentoRespaldo", SqlDbType.VarChar, 50);
             cmd.Parameters.Add("@IdTipoDocumento", SqlDbType.VarChar, 20);
             cmd.Parameters.Add("@IdDocumentoExpedido", SqlDbType.VarChar, 20);
             cmd.Parameters.Add("@ComplementoSEGIP", SqlDbType.VarChar, 5);
             cmd.Parameters.Add("@NumRa", SqlDbType.VarChar, 7);
             cmd.Parameters.Add("@FechaRa", SqlDbType.VarChar, 8);
             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;

             cmd.Parameters["@NUP"].Value = NUP;
             cmd.Parameters["@CUA"].Value = CUA;
             cmd.Parameters["@PrimerApellido"].Value = PrimerApellido;
             cmd.Parameters["@SegundoApellido"].Value = SegundoApellido;
             cmd.Parameters["@PrimerNombre"].Value = PrimerNombre;
             cmd.Parameters["@SegundoNombre"].Value = SegundoNombre;
             cmd.Parameters["@NumeroDocumento"].Value = NumeroDocumento; 
             cmd.Parameters["@IdFuncionarioRegistro"].Value = IdFuncionarioRegistro;
             cmd.Parameters["@IdInstitucionSolicitante"].Value = IdInstitucionSolicitante;
             cmd.Parameters["@DocumentoRespaldo"].Value = DocumentoRespaldo;
             cmd.Parameters["@IdTipoDocumento"].Value = IdTipoDocumento;
             cmd.Parameters["@IdDocumentoExpedido"].Value = IdDocumentoExpedido;
             cmd.Parameters["@ComplementoSEGIP"].Value = ComplementoSEGIP;
             cmd.Parameters["@NumRa"].Value = NumRa;
             cmd.Parameters["@FechaRa"].Value = FechaRa;
             conn.Open();
             cmd.ExecuteNonQuery();
             mensaje = Convert.ToString(cmd.Parameters["@mensaje"].Value);
             retorno_proc = Convert.ToInt32(cmd.Parameters["@retorno_proc"].Value);
         }
         public IDataReader ListarTitDH(string ci, string cua, string app, string apm, string nom1, string nom2, string tipo)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_ListarTitDH", ci, cua, app, apm, nom1, nom2, tipo);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }
         public IDataReader Form04ListarDH(string IdTipoCertificado, string NumeroCertificado)
         {
             DbCommand cmd = db.GetStoredProcCommand("Novedades.PR_Form04ListarDH", IdTipoCertificado, NumeroCertificado);
             IDataReader dataReader = db.ExecuteReader(cmd);
             return dataReader;
         }

         public string[] PersonaIns(int IdFuncionarioRegistro, int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstadoint,
             Int64 CUA, string Matricula, string NUB, string NumeroDocumento, string ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre,
             string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, string FechaNacimiento,
             string FechaFallecimiento, int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono,
             string RegistroActivo)
         {
             string cadena = ConfigurationManager.ConnectionStrings["cnnstrD"].ConnectionString;
             SqlConnection conn = new SqlConnection(cadena);
             SqlCommand cmd = new SqlCommand("Novedades.PR_PersonaIns", conn);
             cmd.CommandType = CommandType.StoredProcedure;
             if (IdFuncionarioRegistro != 0)
                 cmd.Parameters.Add("@IdFuncionarioRegistro", SqlDbType.Int).Value = IdFuncionarioRegistro;
             else
                 cmd.Parameters.Add("@IdFuncionarioRegistro", SqlDbType.Int).Value = DBNull.Value;
             
             if (IdTipoDocumento != 0)
                 cmd.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = IdTipoDocumento;
             else
                 cmd.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = DBNull.Value;

             if (IdEstadoCivil != 0)
                 cmd.Parameters.Add("@IdEstadoCivil", SqlDbType.Int).Value = IdEstadoCivil;
             else
                 cmd.Parameters.Add("@IdEstadoCivil", SqlDbType.Int).Value = DBNull.Value;

             if(IdEntidadGestora != 0)
                 cmd.Parameters.Add("@IdEntidadGestora", SqlDbType.Int).Value = IdEntidadGestora;
             else
                 cmd.Parameters.Add("@IdEntidadGestora", SqlDbType.Int).Value = DBNull.Value;

             if(IdSexo != 0)
                 cmd.Parameters.Add("@IdSexo", SqlDbType.Int).Value = IdSexo;
             else
                 cmd.Parameters.Add("@IdSexo", SqlDbType.Int).Value = DBNull.Value;

             if(IdEstadoint != 0)
                 cmd.Parameters.Add("@IdEstado", SqlDbType.Int).Value = IdEstadoint;
             else
                 cmd.Parameters.Add("@IdEstado", SqlDbType.Int).Value = DBNull.Value;

             if(CUA != 0)
                 cmd.Parameters.Add("@CUA", SqlDbType.Int).Value = CUA;
             else
                 cmd.Parameters.Add("@CUA", SqlDbType.Int).Value = DBNull.Value;

             if(Matricula != "")
                 cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = Matricula;
             else
                 cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = DBNull.Value;

             if(NUB != "")
                 cmd.Parameters.Add("@NUB", SqlDbType.VarChar).Value = NUB;
             else
                 cmd.Parameters.Add("@NUB", SqlDbType.VarChar).Value = DBNull.Value;

             if(NumeroDocumento != "")
                 cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = NumeroDocumento;
             else
                 cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar).Value = DBNull.Value;

             if(ComplementoSEGIP != "")
                 cmd.Parameters.Add("@ComplementoSEGIP", SqlDbType.VarChar).Value = ComplementoSEGIP;
             else
                 cmd.Parameters.Add("@ComplementoSEGIP", SqlDbType.VarChar).Value = DBNull.Value;

             if(IdDocumentoExpedido != "")
                 cmd.Parameters.Add("@IdDocumentoExpedido", SqlDbType.VarChar).Value = IdDocumentoExpedido;
             else
                 cmd.Parameters.Add("@IdDocumentoExpedido", SqlDbType.VarChar).Value = DBNull.Value;

             if(PrimerNombre != "")
                 cmd.Parameters.Add("@PrimerNombre", SqlDbType.VarChar).Value = PrimerNombre;
             else
                 cmd.Parameters.Add("@PrimerNombre", SqlDbType.VarChar).Value = DBNull.Value;

             if(SegundoNombre != "")
                 cmd.Parameters.Add("@SegundoNombre", SqlDbType.VarChar).Value = SegundoNombre;
             else
                 cmd.Parameters.Add("@SegundoNombre", SqlDbType.VarChar).Value = DBNull.Value;

             if(PrimerApellido != "")
                 cmd.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = PrimerApellido;
             else
                 cmd.Parameters.Add("@PrimerApellido", SqlDbType.VarChar).Value = DBNull.Value;

             if(SegundoApellido != "")
                 cmd.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = SegundoApellido;
             else
                 cmd.Parameters.Add("@SegundoApellido", SqlDbType.VarChar).Value = DBNull.Value;

             if(ApellidoCasada != "")
                 cmd.Parameters.Add("@ApellidoCasada", SqlDbType.VarChar).Value = ApellidoCasada;
             else
                 cmd.Parameters.Add("@ApellidoCasada", SqlDbType.VarChar).Value = DBNull.Value;

             if (FechaNacimiento != "")
                 cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = FechaNacimiento;
             else
                 cmd.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = DBNull.Value;

             if (FechaFallecimiento != "")
                 cmd.Parameters.Add("@FechaFallecimiento", SqlDbType.VarChar).Value = FechaFallecimiento;
             else
                 cmd.Parameters.Add("@FechaFallecimiento", SqlDbType.VarChar).Value = DBNull.Value;

             if (IdPaisResidencia != 0)
                 cmd.Parameters.Add("@IdPaisResidencia", SqlDbType.Int).Value = IdPaisResidencia;
             else
                 cmd.Parameters.Add("@IdPaisResidencia", SqlDbType.Int).Value = DBNull.Value;

             if (CorreoElectronico != "")
                 cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = CorreoElectronico;
             else
                 cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = DBNull.Value;

             if (Celular != "")
                 cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = Celular;
             else
                 cmd.Parameters.Add("@Celular", SqlDbType.VarChar).Value = DBNull.Value;

             if (Direccion != "")
                 cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
             else
                 cmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = DBNull.Value;

             if (idLocalidad != 0)
                 cmd.Parameters.Add("@idLocalidad", SqlDbType.Int).Value = DBNull.Value;//REVISAR CON GEOGRÁFICO
             else
                 cmd.Parameters.Add("@idLocalidad", SqlDbType.Int).Value = DBNull.Value;

             if (Telefono != "")
                 cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
             else
                 cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = DBNull.Value;

             if (RegistroActivo != "")
                 cmd.Parameters.Add("@RegistroActivo", SqlDbType.VarChar).Value = RegistroActivo;
             else
                 cmd.Parameters.Add("@RegistroActivo", SqlDbType.VarChar).Value = DBNull.Value;

             cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@retorno_proc", SqlDbType.Int).Direction = ParameterDirection.Output;
             cmd.Parameters.Add("@nup_insertado", SqlDbType.Int).Direction = ParameterDirection.Output;

             conn.Open();
             cmd.ExecuteNonQuery();
             string[] result = new string[3];
             result[0]= Convert.ToString(cmd.Parameters["@mensaje"].Value);
             result[1] = Convert.ToString(cmd.Parameters["@retorno_proc"].Value);
             if(Convert.ToInt16(result[1]) > 0)
                result[2] = Convert.ToString(cmd.Parameters["@nup_insertado"].Value);

             return result;
         }

    }
}

