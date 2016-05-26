using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using wcfEmisionCertificadoCC.Entidades;
using wcfEmisionCertificadoCC.Datos;

namespace wcfEmisionCertificadoCC.Logica
{
    public class clsTipoCambio : clsTipoCambioBE
    {
        clsTipoCambioDA Res = new clsTipoCambioDA();
        // Adiciona TipoCambio
        public void AdicionarTipoCambio( int IdMoneda, int Resolucion, DateTime FechaResolucion,string TasaCambio,int RegistroActivo) //PARA BORRAR
        {
            try
            {
                clsTipoCambioDA adi = new clsTipoCambioDA();
                adi.AdicionarTipoCambio( IdMoneda,  Resolucion,  FechaResolucion, TasaCambio, RegistroActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AdcionaResolucionTipoCambio(int iIdConexion, string cOperacion,string FechaCambio,Int32 Moneda,string TipoCambio,string FechaResolucion,string Resolucion, ref string sMensajeError)
        {
            bool Respuesta = Res.AdcionaResolucionTipoCambio(iIdConexion, cOperacion,FechaCambio,Moneda,TipoCambio,FechaResolucion,Resolucion, ref sMensajeError);
            return (Respuesta);
        }

        // Elimina TipoCambio
        //public Boolean EliminarTipoCambio(DateTime Fecha)
        //{
        //    clsTipoCambioDA eli = new clsTipoCambioDA();
        //    return eli.EliminarTipoCambio(Fecha);
        //}

        // Modificar TipoCambio
     
        public void ModificarTipoCambio(DateTime Fecha, int IdMoneda, int Resolucion, DateTime FechaResolucion, string TasaCambio, int RegistroActivo)
        {
            try
            {
                clsTipoCambioDA mod = new clsTipoCambioDA();
                mod.ModificarTipoCambio(Fecha, IdMoneda, Resolucion, FechaResolucion, TasaCambio, RegistroActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Listar TipoCambio
        public List<clsTipoCambio> ListarTipoCambio()
        {
            string vari;
            clsTipoCambio p;
            clsTipoCambioDA permiso = new clsTipoCambioDA();
            List<clsTipoCambio> ListaClas = new List<clsTipoCambio>();
            using (IDataReader dr = permiso.ListarTipoCambio())
            {
                while (dr.Read())
                {
                   

                    p = new clsTipoCambio();
                    p.Fecha = (DateTime)dr["Fecha"];
                    p.Periodo = Convert.ToString((DateTime)dr["Fecha"]).Substring(3, 7);
                    // p.IdMoneda = (int)dr["IdMoneda"];
                    p.Moneda = (string)dr["DescripcionDetalleClasificador"];
                    p.Resolucion = String.Concat(String.Concat(Convert.ToString((int)dr["Resolucion"]), '.'), p.Fecha.Year);
                    p.FechaResolucion = Convert.ToString((DateTime)dr["FechaResolucion"]).Substring(0, 10);
                    p.TasaCambio = Convert.ToString((decimal)dr["TasaCambio"]);
                    p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);


                }
          }
            return ListaClas;
        }
       // verifica tipocambio
        public int VerificarTipoCambio(DateTime Fecha, int Resolucion)
        {
            int valor=0;
           
            clsTipoCambioDA permiso = new clsTipoCambioDA();
         
            using (IDataReader dr = permiso.VerificarTipoCambio(Fecha, Resolucion))
            {
                while (dr.Read())
                {
                   valor = (int)dr[existedatos];
                }
            }
            return valor;
          }
        // obteber tipo cambio
        public List<clsTipoCambio> ObtenerTipoCambio(DateTime Cod) //PARA BORRAR
        {
            clsTipoCambio p;
            clsTipoCambioDA permiso = new clsTipoCambioDA();
            List<clsTipoCambio> ListaClas = new List<clsTipoCambio>();
            using (IDataReader dr = permiso.ObtenerTipoCambio(Cod))
            {
                while (dr.Read())
                {
                    p = new clsTipoCambio();
                    p.Fecha=(DateTime)dr["Fecha"];
                    p.Periodo = Convert.ToString((DateTime)dr["Fecha"]).Substring(3, 7);
                    p.IdMoneda = (int)dr["IdMoneda"];
                    p.Resolucion = Convert.ToString((int)dr["Resolucion"]);
                    //+'.' + p.Fecha.Year;
                    p.FechaResolucion = Convert.ToString((DateTime)dr["FechaResolucion"]).Substring(0,10);
                    p.TasaCambio =Convert.ToString( (decimal)dr["TasaCambio"]);
                    p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }
        // Verificar TipoCambio en los Certificado 
        public int VerificarTipoCambio_Certificado(DateTime dat) //PARA BORRAR
        {
            int valor = 0;
           clsTipoCambioDA permiso = new clsTipoCambioDA();
          using (IDataReader dr = permiso.VerificarTipoCambio_Certificado(dat))
            {
                while (dr.Read())
                {
                    valor = (int)dr[existedatos];
                }
            }
            return valor;
        }

        //Actualiza la tabla TipoCambio y Resolucion Sello
        public bool ActualizaCambioXresolucion(int iIdConexion, string cOperacion, string Fecha, int IdMoneda, string Resolucion, string FechaResolucion, string TasaCambio, ref string sMensajeError)
        {
            bool bAsignacionOK = Res.ActualizaCambioXresolucion(iIdConexion, cOperacion,Fecha,IdMoneda,Resolucion,FechaResolucion,TasaCambio, ref sMensajeError);
            return (bAsignacionOK);

        }

        //Inserta el nuevo tipo de cambio vigente
        public bool InsertaTipoCambio(int iIdConexion, string cOperacion, int IdMoneda, string Fecha, string TasaCambio, string Observacion, ref string sMensajeError)
        {
            bool bAsignacionOK = Res.InsertaTipoCambio(iIdConexion, cOperacion, IdMoneda, Fecha, TasaCambio, Observacion, ref sMensajeError);
            return (bAsignacionOK);

        }

        //Actualiza Tipo Cambio de Convenios    
        public bool ActualizaTipoCambio(int iIdConexion, string cOperacion, string Fecha, int IdMoneda, string TasaCambio, string Observacion, ref string sMensajeError)
        {
            bool bAsignacionOK = Res.ActualizaTipoCambio(iIdConexion, cOperacion, Fecha, IdMoneda, TasaCambio, Observacion, ref sMensajeError);
            return (bAsignacionOK);

        }

        //Verifica si existen certificados emitidos en el mes de la resolucion 10-06-2015
        public DataTable VerificaCertificadosEmitidos(int iIdConexion, string cOperacion,string Fecha, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.VerificaCertificadosEmitidos(iIdConexion, cOperacion, Fecha,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Verificar si existe la resolucion para no dejar pasar los datos 12-06-2015
        public DataTable VerificaResolucion(int iIdConexion, string cOperacion, string Resolucion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.VerificaResolucion(iIdConexion, cOperacion, Resolucion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene el Listado de los tipos de Cambio 07-06-2015
        public DataTable ListarTiposdeCambios(int iIdConexion, string cOperacion,Int32 seleccion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.ListarTiposdeCambios(iIdConexion, cOperacion,seleccion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene registro si existe Tipo de cambio o Resolucion para Adicionar nueva 12-06-2015
        public DataTable VerificaResolucionTipoCambio(int iIdConexion, string cOperacion,string FechaCambio,string Resolucion,Int32 IdMoneda, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.VerificaResolucionTipoCambio(iIdConexion, cOperacion,FechaCambio,Resolucion,IdMoneda,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene datos del registro a ser modificado 08-06-2015
        public DataTable DatosTipoCambio(int iIdConexion, string cOperacion, Int32 IdMoneda, string Fecha, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.DatosTipoCambio(iIdConexion, cOperacion, IdMoneda,Fecha,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene el Tipo de Cambio para su Modificacion
        public DataTable ObtieneDatosResolucion(int iIdConexion, string cOperacion, string FechaResolucion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.ObtieneDatosResolucion(iIdConexion, cOperacion, FechaResolucion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Obtiene la fecha del mes anterior para registrar nueva resolucion 12-06-2015
        public DataTable FechaMesAnterior(int iIdConexion, string cOperacion,ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.FechaMesAnterior(iIdConexion, cOperacion,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //Lista los tipos de Moneda
        public DataTable ListarTiposMoneda(int iIdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (Res.ListaTiposMoneda(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
    }
}