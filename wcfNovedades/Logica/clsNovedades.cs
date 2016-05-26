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

using wcfNovedades.Entidades;
using wcfNovedades.Datos;

namespace wcfNovedades.Logica
{
    public class clsNovedades : clsNovedadesBE
    {
        clsNovedadesDA apli = new clsNovedadesDA();
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
        /* Prueba */
        public List<clsNovedades> ListarNovesPrueba(int IdActualizacion)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.ListarNovesPrueba(IdActualizacion))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();

                    p.DetalleActualizacion = (int)dr["DetalleActualizacion"];
                    p.IdTablaCampo = (int)dr["IdTablaCampo"];
                    p.IdActualizacion = (int)dr["IdActualizacion"];

                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public DataSet ListarNovesPruebaDataSet(int IdActualizacion)
        {
            clsNovedadesDA permiso = new clsNovedadesDA();
            DataSet dataTabla = permiso.ListarNovesPruebaDataSet(IdActualizacion);
            return dataTabla;
        }

        public DataTable ListarNovesPruebaTabla(int IdActualizacion)
        {
            clsNovedadesDA permiso = new clsNovedadesDA();
            DataTable dataTabla = permiso.ListarNovesPruebaTabla(IdActualizacion);
            return dataTabla;
        }

        public DataTable ReporteNovedadesId(int IdActualizacion)
        {
            clsNovedadesDA permiso = new clsNovedadesDA();
            DataTable dataTabla = permiso.ReporteNovedadesId(IdActualizacion);
            return dataTabla;
        }

        public DataSet ReporteNovedadesIdTabla(int IdActualizacion)
        {
            clsNovedadesDA permiso = new clsNovedadesDA();
            DataSet dataSet = permiso.ReporteNovedadesIdDataSet(IdActualizacion);
            return dataSet;
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
                    p.FuncionarioRegistro = (string)dr["UsuarioRegistro"];
                    p.FuncionarioAprobacion = (string)dr["UsuarioAprobacion"];
                    p.EstadoActualizacion = (int)dr["EstadoActualizacion"];
                    p.EstadoRegistro = (int)dr["EstadoRegistro"];
                    p.EstadoActualizacion = (int)dr["EstadoActualizacion"];
                    p.DescEstado = (string)dr["DescEstado"];
                    p.IdActualizacion = (int)dr["IdActualizacion"];
                    p.FechaEmision = (string)dr["Fecha_string"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public DataTable ListarNovedadesPorTipo1(int IdConexion,ref string sMensajeError, int CodTipo, DateTime fechainicio, DateTime fechafin, string estado)
        {
            DataSet DSetTmp = new DataSet();
            if (apli.ListarNovedadesPorTipo1("I",IdConexion,ref sMensajeError, CodTipo, fechainicio, fechafin, estado, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        /* Lista de Novedades por Tipo*/
        public List<clsNovedades> ListarNovedadesporCUA(string cua, string estado)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.ListarNovedadesporCUA(cua, estado))
            {
                while (dr.Read())
                {
                    p = new clsNovedades();
                    p.FechaRegistro = (DateTime)dr["FechaRegistro"];
                    p.IdTipoActualizacion = (int)dr["IdTipoActualizacion"];
                    p.DescripcionActualizacion = (string)dr["DescripcionDetalleClasificador"];
                    p.FuncionarioRegistro = (string)dr["UsuarioRegistro"];
                    p.FuncionarioAprobacion = (string)dr["UsuarioAprobacion"];
                    p.EstadoActualizacion = (int)dr["EstadoActualizacion"];
                    p.EstadoRegistro = (int)dr["EstadoRegistro"];
                    p.EstadoActualizacion = (int)dr["EstadoActualizacion"];
                    p.DescEstado = (string)dr["DescEstado"];
                    p.IdActualizacion = (int)dr["IdActualizacion"];
                    p.FechaEmision = (string)dr["Fecha_string"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public DataTable ListarNovedadesPorCUA1(int IdConexion, string cua, string estado)
        {
            DataSet DSetTmp = new DataSet();
            if (apli.ListarNovedadesporCUA1("I", IdConexion, cua, estado,  ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public bool ApruebaNovedad(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                     int IdActualizacion, int Estado, string DocumentoAprobacion, string IdUsuarioAprobacion, ref string mensaje)
        {
            bool bAsignacionOK = apli.ApruebaNovedad(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
                     IdActualizacion, Estado, DocumentoAprobacion, IdUsuarioAprobacion, ref mensaje);
            return (bAsignacionOK);
        }
        /*
        public void ApruebaNovedad(int IdActualizacion, int Estado, string DocumentoAprobacion, string IdUsuarioAprobacion, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA adi = new clsNovedadesDA();
                adi.ApruebaNovedad(IdActualizacion, Estado, DocumentoAprobacion, IdUsuarioAprobacion, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        public void EliminaNovedad(int IdActualizacion, string IdUsuarioAprobacion, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA adi = new clsNovedadesDA();
                adi.EliminaNovedad(IdActualizacion,IdUsuarioAprobacion, out mensaje, out retorno_proc);
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
		
        public bool Form02ValidaCerti1(int iIdConexion, string cOperacion, int no_certif, string claseCC, ref string mensaje)
        {
            bool bAsignacionOK = apli.Form02ValidaCerti1(iIdConexion, cOperacion, no_certif, claseCC, ref mensaje);
            return (bAsignacionOK);
        }		


        public void Form02ValidaInsercion(string NumeroDocumento, string ComplementoSEGIP, string NumRa, string FechaRa, ref string mensaje, ref int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form02ValidaInsercion1(NumeroDocumento, ComplementoSEGIP,NumRa, FechaRa, ref mensaje, ref retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Form02Ins(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
             string NUP, string CUA, string PrimerApellido, string SegundoApellido, string PrimerNombre, string SegundoNombre,
             string NumeroDocumento, string IdUsuarioRegistro, string IdInstitucionSolicitante, string DocumentoRespaldo, string IdTipoDocumento, string IdDocumentoExpedido,
             string ComplementoSEGIP, string NumRa, string FechaRa, string NroCertificado, string IdTipoCC,ref string mensajes)
        {
            bool bAsignacionOK = apli.Form02Ins(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
             NUP, CUA, PrimerApellido, SegundoApellido, PrimerNombre, SegundoNombre,
             NumeroDocumento, IdUsuarioRegistro, IdInstitucionSolicitante, DocumentoRespaldo, IdTipoDocumento, IdDocumentoExpedido,
             ComplementoSEGIP, NumRa, FechaRa, NroCertificado, IdTipoCC, ref mensajes  );
            return (bAsignacionOK);
        }

        //public void Form02Ins(string NUP, string CUA, string PrimerApellido, string SegundoApellido, string PrimerNombre, string SegundoNombre,
        //    string NumeroDocumento, string IdFuncionarioRegistro, string IdInstitucionSolicitante, string DocumentoRespaldo, string IdTipoDocumento, string IdDocumentoExpedido,
        //    string ComplementoSEGIP, string NumRa, string FechaRa, out string mensaje, out int retorno_proc)
        //{
        //    try
        //    {
        //        clsNovedadesDA apli = new clsNovedadesDA();
        //        apli.Form02Ins(NUP, CUA, PrimerApellido, SegundoApellido, PrimerNombre, SegundoNombre, NumeroDocumento,IdFuncionarioRegistro, IdInstitucionSolicitante, 
        //            DocumentoRespaldo, IdTipoDocumento,IdDocumentoExpedido, ComplementoSEGIP,NumRa, FechaRa, out mensaje, out retorno_proc);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<clsNovedades> ListarTitDH(int IdConexion,out string sMensajeError,string ci, string cua, string app, string apm, string nom1, string nom2, string tipo)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.ListarTitDH(IdConexion,"Q",0,"",out sMensajeError,ci, cua, app, apm, nom1, nom2, tipo))
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
                    p.NUP = (string)dr["NUP"];
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        public DataTable ListarTitDH1(int IdConexion, ref string sMensajeError, string ci, string cua, string app, string apm, string nom1, string nom2, string tipo)
        {
            DataSet DSetTmp = new DataSet();
            if (apli.ListarTitDH1(IdConexion, "Q",0,"" , ref sMensajeError,ci, cua, app, apm, nom1, nom2, tipo, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable Form04ListarDH1(int iIdConexion, string cOperacion, string IdTipoCertificado, string NumeroCertificado, string NUPDerechohabiente, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (apli.Form04ListarDH1(iIdConexion,cOperacion,IdTipoCertificado, NumeroCertificado, NUPDerechohabiente, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        public DataTable Form02BuscaCerti1(int iIdConexion,string cOperacion,int no_certif, string claseCC, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (apli.Form02BuscaCerti1(iIdConexion, cOperacion,no_certif, claseCC, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }		

        public DataTable Form03ListarTit1(int iIdConexion, string cOperacion, string IdTipoCertificado, string NumeroCertificado, string NUPTitular, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (apli.Form03ListarTit1(iIdConexion,cOperacion,IdTipoCertificado, NumeroCertificado, NUPTitular, ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }		

        public List<clsNovedades> Form04ListarDH(string IdTipoCertificado, string NumeroCertificado, string NUPDerechohabiente)
        {
            clsNovedades p;
            clsNovedadesDA permiso = new clsNovedadesDA();
            List<clsNovedades> ListaClas = new List<clsNovedades>();

            using (IDataReader dr = permiso.Form04ListarDH(IdTipoCertificado, NumeroCertificado, NUPDerechohabiente))
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

        public bool Form04Ins(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN, ref string sMensajeError,
                     string NUPAsegurado, string NUPDerechohabiente, string IdEntidadGestora, string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP, string PrimerApellido,
                    string SegundoApellido, string PrimerNombre, string SegundoNombre, string IdSexo, string FechaNacimiento, string FechaInicioVigencia, string RegistroActivo,
                    string EstadoVersion, string IdUsuarioRegistro, string IdInstitucionSolicitante, ref string mensaje)
        {
            bool bAsignacionOK = apli.Form04Ins(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
                    NUPAsegurado, NUPDerechohabiente, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP, PrimerApellido,
                    SegundoApellido, PrimerNombre, SegundoNombre, IdSexo, FechaNacimiento, FechaInicioVigencia, RegistroActivo,
                    EstadoVersion, IdUsuarioRegistro, IdInstitucionSolicitante, ref mensaje);
            return (bAsignacionOK);
        }
 

/*
        public void Form04Ins(string NUPAsegurado, string NUPDerechohabiente, string IdEntidadGestora, string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP, string PrimerApellido,
             string SegundoApellido, string PrimerNombre, string SegundoNombre, string IdSexo, string FechaNacimiento, string PeriodoInicio, string RegistroActivo,
             string EstadoVersion, string IdUsuarioRegistro, string IdInstitucionSolicitante, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form04Ins(NUPAsegurado, NUPDerechohabiente, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP, PrimerApellido, SegundoApellido, PrimerNombre, SegundoNombre, IdSexo, FechaNacimiento, PeriodoInicio, RegistroActivo, EstadoVersion, IdUsuarioRegistro, IdInstitucionSolicitante, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
*/
        public bool Form03Ins(int iIdConexion, string cOperacion, string sSessionTrabajo, string sSNN,ref string sMensajeError,
                     string NUPAsegurado, string NumeroCertificado, string IdTipoCertificado, string IdEntidadGestora, string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP,
                     string IdSexo, string RegistroActivo, string FechaSolicitud, string TipoCambio1, string TipoCambio2, string TipoAjuste, string PorcentajeAjuste, string SalarioBase,
                     string AniosInsalubres, string MontoAjustado, string NumeroSolicitud, string PeriodoSolicitud,
                     string IdUsuarioRegistro, string IdInstitucionSolicitante, ref string mensaje)
        {
            bool bAsignacionOK = apli.Form03Ins(iIdConexion, cOperacion, sSessionTrabajo, sSNN, ref sMensajeError,
                     NUPAsegurado, NumeroCertificado, IdTipoCertificado, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP,
                     IdSexo, RegistroActivo, FechaSolicitud, TipoCambio1, TipoCambio2, TipoAjuste, PorcentajeAjuste, SalarioBase,
                     AniosInsalubres, MontoAjustado, NumeroSolicitud, PeriodoSolicitud, IdUsuarioRegistro, IdInstitucionSolicitante, ref mensaje);
            return (bAsignacionOK);
        }
/*
        public void Form03Ins(string NUPAsegurado, string NumeroCertificado, string IdTipoCertificado, string IdEntidadGestora, string IdTipoDocumento, string IdDocumentoExpedido, string NumeroDocumento, string ComplementoSEGIP,
             string IdSexo, string RegistroActivo, string FechaSolicitud, string TipoCambio1, string TipoCambio2, string TipoAjuste, string PorcentajeAjuste, string SalarioBase,
             string AniosInsalubres, string MontoAjustado, string NumeroSolicitud, string PeriodoSolicitud,
             string IdUsuarioRegistro, string IdInstitucionSolicitante, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form03Ins(NUPAsegurado, NumeroCertificado, IdTipoCertificado, IdEntidadGestora, IdTipoDocumento, IdDocumentoExpedido, NumeroDocumento, ComplementoSEGIP, 
             IdSexo, RegistroActivo, FechaSolicitud, TipoCambio1,TipoCambio2, TipoAjuste, PorcentajeAjuste, SalarioBase,AniosInsalubres, MontoAjustado, NumeroSolicitud, PeriodoSolicitud,
             IdUsuarioRegistro, IdInstitucionSolicitante, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 */
        public void Form04ValidaInsercion(string NUPDerechohabiente, string NumeroDocumento, string ComplementoSEGIP, string Nacimiento, string IniPago, out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form04ValidaInsercion(NUPDerechohabiente, NumeroDocumento, ComplementoSEGIP, Nacimiento, IniPago, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Form03ValidaInsercion(string IdHabilitacionTitularCC, string NUPTitular, string NumeroDocumento, string ComplementoSEGIP,
             string FechaSolicitud, string RegistroActivo, string TipoAjuste, string PorcentajeAjuste, string MontoAjustado, string TipoCambio2,string TipoCambio1,out string mensaje, out int retorno_proc)
        {
            try
            {
                clsNovedadesDA apli = new clsNovedadesDA();
                apli.Form03ValidaInsercion(IdHabilitacionTitularCC,NUPTitular, NumeroDocumento, ComplementoSEGIP, FechaSolicitud, RegistroActivo, TipoAjuste,PorcentajeAjuste,MontoAjustado,TipoCambio2,TipoCambio1, out mensaje, out retorno_proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UsuarioConectado(int IdConexion)
        {
            clsNovedadesDA permiso = new clsNovedadesDA();
            string usuario = "";

            using (IDataReader dr = permiso.ListaDatosConexion(IdConexion))
            {
                while (dr.Read())
                {
                    usuario = (string)dr["CuentaUsuario"];
                }
            }
            return usuario;
        }
        public string IdUsuarioConectado(int IdConexion)
        {
            clsNovedadesDA permiso = new clsNovedadesDA();
            string idusuario = "";

            using (IDataReader dr = permiso.ListaDatosConexion(IdConexion))
            {
                while (dr.Read())
                {
                    idusuario = (string)dr["IdUsuario"];
                }
            }
            return idusuario;
        }
    }
}