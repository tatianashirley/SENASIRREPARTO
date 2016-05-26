using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using System.Text;
using System.Data.Common;

using wcfEjemplo.Entidades;
using wcfEjemplo.Datos;

namespace wcfEjemplo.Logica
{
    public class clsNovedades : clsNovedadesBE
    {
        /*
        public void AdicionarPersona(int IdFuncionarioRegistro, int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstado,  int CUA, string Matricula, int NUB, string NumeroDocumento, string  ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, DateTime  FechaNacimiento, DateTime FechaFallecimiento,  int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono, int RegistroActivo, out string mensaje, out int retorno_proc )
        {
            try
            {
                clsNovedadesDA adi = new clsNovedadesDA();
                adi.AdicionarPersona(IdFuncionarioRegistro, IdTipoDocumento, IdEstadoCivil, IdEntidadGestora, IdSexo, IdEstado,  CUA, Matricula, NUB, NumeroDocumento, ComplementoSEGIP, IdDocumentoExpedido, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, ApellidoCasada, FechaNacimiento, FechaFallecimiento,  IdPaisResidencia, CorreoElectronico, Celular, Direccion, idLocalidad, Telefono,  RegistroActivo, mensaje, retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarPersona(int IdFuncionarioRegistro, string NUP, int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstado,  int CUA, string Matricula, int NUB, string NumeroDocumento, string  ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, DateTime  FechaNacimiento, DateTime FechaFallecimiento,  int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono, int RegistroActivo, out string mensaje, out int retorno_proc )
        {
            try
            {
                clsNovedadesDA adi = new clsNovedadesDA();
                adi.ModificarPersona(IdFuncionarioRegistro, NUP,IdTipoDocumento, IdEstadoCivil, IdEntidadGestora, IdSexo, IdEstado,  CUA, Matricula, NUB, NumeroDocumento, ComplementoSEGIP, IdDocumentoExpedido, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, ApellidoCasada, FechaNacimiento, FechaFallecimiento,  IdPaisResidencia, CorreoElectronico, Celular, Direccion, idLocalidad, Telefono,  RegistroActivo, mensaje, retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }		
		*/

        /* Lista Clasificador por Tipos */
        public List<clsNovedades> ListarClasifporTipo(int tipoclasificador)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.ListarClasifporTipo(tipoclasificador))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();

                    p.IdTipoActualizacion = (int)dr["IdTipoActualizacion"];
                    p.CodigoActualizacion = (string)dr["Codigo"];
                    p.DescripcionActualizacion = (string)dr["Descripcion"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        /* Lista de Novedades por Tipo*/
        public List<clsNovedades> ListarNovedadesPorTipo(int CodTipo, DateTime fechainicio, DateTime fechafin,string estado)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.ListarNovedadesPorTipo(CodTipo, fechainicio, fechafin,estado))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();
                    p.FechaRegistro = (DateTime)dr["FechaRegistro"];
                    p.IdTipoActualizacion = (int)dr["IdTipoActualizacion"];
                    p.DescripcionActualizacion = (string)dr["DescripcionDetalleClasificador"];
                    p.FuncionarioRegistro = (string)dr["FuncionarioRegistro"];
                    p.FuncionarioAprobacion = (string)dr["FuncionarioAprobacion"];
                    p.EstadoActualizacion = (int)dr["EstadoActualizacion"];
                    p.EstadoRegistro = (int)dr["EstadoRegistro"];
                    p.EstadoActualizacion = (int)dr["EstadoActualizacion"];
                    p.DescEstado = (string)dr["DescEstado"];
                    p.IdActualizacion = (int)dr["IdActualizacion"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public void ApruebaNovedad(int IdActualizacion, int Estado, string DocumentoAprobacion, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA adi = new clsNovedadesDA();
                adi.ApruebaNovedad(IdActualizacion, Estado, DocumentoAprobacion, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminaNovedad(int IdActualizacion,  out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA adi = new clsNovedadesDA();
                adi.EliminaNovedad(IdActualizacion, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AplicaNovedad(int IdActualizacion, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.AplicaNovedad(IdActualizacion, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsNovedades> Form02BuscaCerti(int no_certif, string claseCC)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.Form02BuscaCerti(no_certif, claseCC))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();
                    p.Matricula = (string)dr["Matricula"];
                    p.Matricula_cys = (string)dr["Matricula_cys"];
                    p.Tramite = (string)dr["Tramite"];
                    p.DescEstado = (string)dr["Estado"];
                    p.Certificado = (string)dr["Certificado"];
                    p.ClaseCC = (string)dr["ClaseCC"];
                    p.FechaEmision = (string)dr["FechaEmision"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public List<clsNovedades> Form02BuscaPersona(int no_certif, string claseCC)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.Form02BuscaCerti(no_certif, claseCC))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();
                    p.Paterno = (string)dr["Paterno"];
                    p.Materno = (string)dr["Materno"];
                    p.PrimerNombre = (string)dr["PrimerNombre"];
                    p.SegundoNombre = (string)dr["SegundoNombre"];
                    p.CI = (string)dr["CI"];
                    p.NUA = (string)dr["NUA"];
                    p.ComplementoSEGIP = (string)dr["ComplementoSEGIP"];
                    p.IdTipoDocumento = (string)dr["IdTipoDocumento"];
                    p.IdDocumentoExpedido = (string)dr["IdDocumentoExpedido"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public void Form02ValidaCerti(int no_certif, string claseCC, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form02ValidaCerti(no_certif, claseCC, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Form02ValidaInsercion(string NumeroDocumento, string ComplementoSEGIP, string NumRa, string FechaRa, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form02ValidaInsercion(NumeroDocumento, ComplementoSEGIP,NumRa, FechaRa, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Form02Ins(string NUP, string CUA, string PrimerApellido, string SegundoApellido, string PrimerNombre, string SegundoNombre,
            string NumeroDocumento, string IdFuncionarioRegistro, string IdInstitucionSolicitante, string DocumentoRespaldo, string IdTipoDocumento, string IdDocumentoExpedido,
            string ComplementoSEGIP, string NumRa, string FechaRa, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form02Ins(NUP, CUA, PrimerApellido, SegundoApellido, PrimerNombre, SegundoNombre, NumeroDocumento,IdFuncionarioRegistro, IdInstitucionSolicitante, 
                    DocumentoRespaldo, IdTipoDocumento,IdDocumentoExpedido, ComplementoSEGIP,NumRa, FechaRa, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsNovedades> ListarTitDH(string ci, string cua, string app, string apm, string nom1, string nom2, string tipo)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.ListarTitDH(ci, cua, app, apm, nom1, nom2, tipo))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();
                    p.fila = (string)dr["fila"];
                    p.NUA = (string)dr["CUA"];
                    p.CI = (string)dr["NumeroDocumento"];
                    p.IdTipoDocumento = (string)dr["TipoDoc"];
                    p.Paterno = (string)dr["PrimerApellido"];
                    p.Materno = (string)dr["SegundoApellido"];
                    p.PrimerNombre = (string)dr["PrimerNombre"];
                    p.SegundoNombre = (string)dr["SegundoNombre"];
                    p.FechaNac = (string)dr["Nacimiento"];
                    p.Certificado = (string)dr["NumeroCertificado"];
                    p.TipoCertificado = (string)dr["TipoCC"];
                    p.TipoBeneficio = (string)dr["TipoCC"];
                    p.Descripcion = (string)dr["Tipo"];
                    p.IdTipoCertificado = (string)dr["IdTipoCertificado"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }
        public List<clsNovedades> Form04ListarDH(string IdTipoCertificado, string NumeroCertificado)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.Form04ListarDH(IdTipoCertificado, NumeroCertificado))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();
                    p.IdFuente = (string)dr["IdFuente"];
                    p.IdTipoDocumento = (string)dr["IdTipoDocumento"];
                    p.CI = (string)dr["NumeroDocumento"];
                    p.Paterno = (string)dr["PrimerApellido"];
                    p.Materno = (string)dr["SegundoApellido"];
                    p.PrimerNombre = (string)dr["PrimerNombre"];
                    p.SegundoNombre = (string)dr["SegundoNombre"];
                    p.IdSexo = (string)dr["IdSexo"];
                    p.FechaNac = (string)dr["Nacimiento"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public string[] PersonaIns(int IdFuncionarioRegistro, int IdTipoDocumento, int IdEstadoCivil, int IdEntidadGestora, int IdSexo, int IdEstadoint,
             Int64 CUA, string Matricula, string NUB, string NumeroDocumento, string ComplementoSEGIP, string IdDocumentoExpedido, string PrimerNombre,
             string SegundoNombre, string PrimerApellido, string SegundoApellido, string ApellidoCasada, string FechaNacimiento,
             string FechaFallecimiento, int IdPaisResidencia, string CorreoElectronico, string Celular, string Direccion, int idLocalidad, string Telefono,
             string RegistroActivo)
        {
            clsNovedadesDA novedades = new clsNovedadesDA();
            string[] result = new string[3];
            result = novedades.PersonaIns(IdFuncionarioRegistro, IdTipoDocumento, IdEstadoCivil, IdEntidadGestora, IdSexo, IdEstadoint,
             CUA, Matricula, NUB, NumeroDocumento, ComplementoSEGIP, IdDocumentoExpedido, PrimerNombre,
             SegundoNombre, PrimerApellido, SegundoApellido, ApellidoCasada, FechaNacimiento,
             FechaFallecimiento, IdPaisResidencia, CorreoElectronico, Celular, Direccion, idLocalidad, Telefono,
             RegistroActivo);
            return result;

        }

    }
}