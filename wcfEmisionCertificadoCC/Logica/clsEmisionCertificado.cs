using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfEmisionCertificadoCC.Entidades;
using wcfEmisionCertificadoCC.Datos;
using wcfSeguridad.Datos;
using System.Data;
    
namespace wcfEmisionCertificadoCC.Logica
{
    public class clsEmisionCertificado : clsEmisionCertificadoBE
    {
        clsEmisionCertificadoDA certificado = new clsEmisionCertificadoDA();
        // Adiciona EmisionCertificado
                                                                                                         
        public void AdicionarEmisionCertificado(Int64 Tramite, int benefi, int tipoformc, int nroform, int tipocc, int tipocert, int NroCertificado, string FechaEmision, int IdOficina,int IdUsuarioEmi, string FechaImpresion,int IdUsuarioImp)
        {
            try
            {
                clsEmisionCertificadoDA adi = new clsEmisionCertificadoDA();
                adi.AdicionarEmisionCertificado(Tramite, benefi, tipoformc, nroform, tipocc,tipocert, NroCertificado,  FechaEmision,  IdOficina, IdUsuarioEmi,  FechaImpresion, IdUsuarioImp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //DatosConexion
       public DataTable DatosConexion(int IdConexion)
        {
            clsSeguridadDA Conexion = new clsSeguridadDA();
            try
            {
                return Conexion.ListaDatosConexion(IdConexion);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GENERA UN NUEVO CERTIFICADO
        //public void AdicionarActualizarEmisionCertificado(Int64 Tramite, int benefi, int tipoformc, int nroform, int tipocc, int tipocert, int NroCertificado, int NumeroAsig, string FechaEmision, int IdOficina, int IdUsuarioEmi, string montoaceptado,string TotalGanado,string DensidadTotal,string SalCotActTot,string SalCotAct)
        //{
        //    try
        //    {
        //        clsEmisionCertificadoDA adi = new clsEmisionCertificadoDA();
        //        adi.AdicionarActualizarEmisionCertificado(Tramite, benefi, tipoformc, nroform, tipocc, tipocert, NroCertificado, NumeroAsig, FechaEmision, IdOficina, IdUsuarioEmi,montoaceptado,TotalGanado,DensidadTotal,SalCotActTot,SalCotAct);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //CODIGO DE REEMPLAZO 20150526
        //public DataTable AdicionarActualizarEmisionCertificado(int IdConexion, string cOperacion,Int64 Tramite, int benefi, int tipoformc, int nroform, int tipocc, int tipocert, int NroCertificado, int NumeroAsig, string FechaEmision, int IdOficina, int IdUsuarioEmi, string montoaceptado,string TotalGanado,string DensidadTotal,string SalCotActTot,string SalCotAct, ref string sMensajeError)
        //{
        //    DataSet DSetTmp = new DataSet();
        //    if (certificado.AdicionarActualizarEmisionCertificado(IdConexion, cOperacion, Tramite, benefi, tipoformc,nroform,tipocc,tipocert,NroCertificado,NumeroAsig,FechaEmision,IdOficina,IdUsuarioEmi,montoaceptado,TotalGanado,DensidadTotal,SalCotActTot,SalCotAct, ref sMensajeError, ref DSetTmp))
        //    {
        //        return DSetTmp.Tables[0];
        //    }
        //    else
        //    {
        //        return (null);
        //    }
        //}

        public bool AdicionarActualizarEmisionCertificado(int IdConexion, string cOperacion, Int64 Tramite, int benefi, int tipoformc, int nroform, int tipocc, int tipocert, int NroCertificado, int NumeroAsig, string FechaEmision, int IdOficina, int IdUsuarioEmi, string montoaceptado, string TotalGanado, string DensidadTotal, string SalCotActTot, string SalCotAct, ref string sMensajeError)
        {
            bool bAsignacionOK = certificado.AdicionarActualizarEmisionCertificado(IdConexion, cOperacion, Tramite, benefi, tipoformc, nroform, tipocc, tipocert, NroCertificado, NumeroAsig, FechaEmision, IdOficina, IdUsuarioEmi, montoaceptado, TotalGanado, DensidadTotal, SalCotActTot, SalCotAct, ref sMensajeError);
            return (bAsignacionOK);

        }

        public void ActualizarCertificadoCC(Int64 Tramite, int benefi, int idtipoformc, int nroform, int tipocc)
           {
            try
            {
                clsEmisionCertificadoDA adi = new clsEmisionCertificadoDA();
                adi.ActualizarCertificadoCC(Tramite, benefi, idtipoformc, nroform, tipocc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CODIGO DE REEMPLAZO
        public bool ActualizarCertificadoCC(int IdConexion, string cOperacion, Int64 Tramite, Int32 benefi, Int32 tipoformc, Int32 nroform, Int32 tipocc, ref string sMensajeError)
        {
            bool bAsignacionOK = certificado.ActualizarCertificadoCC(IdConexion, cOperacion, Tramite, benefi, tipoformc, nroform, tipocc, ref sMensajeError);
            return (bAsignacionOK);

        }

        // Elimina EmisionCertificado
        public Boolean EliminarEmisionCertificado(int NumeroAsignacion)
        {
            clsEmisionCertificadoDA eli = new clsEmisionCertificadoDA();
            return eli.EliminarEmisionCertificado(NumeroAsignacion);
        }
        // Elimina EmisionCertificado
        public void ModificarEmisionCertificado(int numeroasig, int IdOficina, int IdTipoCertificado, DateTime FechaAsignacion, DateTime FechaEnvio, int NumeroInicial, int NumeroFinal, string Observacion, int RegistroActivo)
        {
            try
            {
                clsEmisionCertificadoDA mod = new clsEmisionCertificadoDA();
                mod.ModificarEmisionCertificado(numeroasig, IdOficina, IdTipoCertificado, FechaAsignacion, FechaEnvio, NumeroInicial, NumeroFinal, Observacion, RegistroActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Remprime el Certificado 
        public bool ReimpresionCertificadoCC(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, Int32 NroCertificado, string Observacion, Int32 IdArea, Int32 TipoTramite, Int32 NroAsig, Int32 Decision, Int32 NroFormulario,Int32 CertActual,ref string sMensajeError)
        {
            bool bAsignacionOK = certificado.ReimpresionCertificadoCC(iIdConexion, cOperacion, Tramite, GrupoB, NroCertificado, Observacion, IdArea, TipoTramite, NroAsig, Decision, NroFormulario, CertActual, ref sMensajeError);
            return (bAsignacionOK);

        }

        //Remprime el Certificado 
        public bool CertificadoReprocesado(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, Int32 NroCertificado, Int32 TipoTramite, Int32 TipoReproceso, Int32 NroFormularioRepro, Int32 iNoFormularioCalculo, ref string sMensajeError)
        {
            bool bAsignacionOK = certificado.CertificadoReprocesado(iIdConexion, cOperacion, Tramite, GrupoB, NroCertificado, TipoTramite, TipoReproceso, NroFormularioRepro, iNoFormularioCalculo, ref sMensajeError);
            iNroCertificadoReemplazo = certificado.iNroCertificadoReemplazo;
            return (bAsignacionOK);
        }
        public DataTable ObtieneParametros(int IdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, Int32 IdTipoTramite, Int32 NroCertificado, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.ObtieneParametros(IdConexion, cOperacion, Tramite, GrupoB, IdTipoTramite, NroCertificado, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }


        public bool RegistraImpresion(Int64 IdTramite, int idGrupoB, int idTipoFormulario) {
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            if (permiso.RegistraImpresion(IdTramite, idGrupoB, idTipoFormulario)) {
                return true;            
            }
            return false;
        }
       
        // Listar EmisionCertificado
        public List<clsEmisionCertificado> ListarEmisionCertificado(int cod)
        {
         //   clsEmisionCertificado p;
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            List<clsEmisionCertificado> ListaClas = new List<clsEmisionCertificado>();
            using (IDataReader dr = permiso.ListarEmisionCertificado(cod))
            {
                while (dr.Read())
                {
                    //p = new clsEmisionCertificado();
                    //p.NumeroAsignacion = (int)dr["NumeroAsignacion"];
                    //// p.IdOficina = (int)dr["IdOficina"];
                    ////p.IdTipoCertificado = (int)dr["IdTipoCertificado"];
                    //p.Oficina = (string)dr["Nombre"];
                    //p.TipoCertificado = (string)dr["DescripcionDetalleClasificador"];
                    //p.FechaAsignacion = (DateTime)dr["FechaAsignacion"];
                    //p.FechaEnvio = (DateTime)dr["FechaEnvio"];
                    //p.NumeroInicial = (int)dr["NumeroInicial"];
                    //p.NumeroFinal = (int)dr["NumeroFinal"];
                    //p.UltimoNumeroAplicado = (int)dr["UltimoNumeroAplicado"];
                    //p.Cantidad = 1 + p.NumeroFinal - p.NumeroInicial;
                    //p.Observacion = (string)dr["Observacion"];
                    //p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    //ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

      

        // Verificar EmisionCertificado
        public List<clsEmisionCertificado> VerificarEmisionCertificado(int IdOficina, int IdTipoCertificado, int NumeroInicial, int NumeroFinal)
        {
           // clsEmisionCertificado p;
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            List<clsEmisionCertificado> ListaClas = new List<clsEmisionCertificado>();
            using (IDataReader dr = permiso.VerificarEmisionCertificado(IdOficina, IdTipoCertificado, NumeroInicial, NumeroFinal))
            {
                while (dr.Read())
                {
                    //p = new clsEmisionCertificado();
                    //p.NumeroAsignacion = (int)dr["NumeroAsignacion"];
                    //p.IdOficina = (int)dr["IdOficina"];
                    //p.IdTipoCertificado = (int)dr["IdTipoCertificado"];

                    //p.FechaAsignacion = (DateTime)dr["FechaAsignacion"];
                    //p.FechaEnvio = (DateTime)dr["FechaEnvio"];
                    //p.NumeroInicial = (int)dr["NumeroInicial"];
                    //p.NumeroFinal = (int)dr["NumeroFinal"];
                    //p.UltimoNumeroAplicado = (int)dr["UltimoNumeroAplicado"];
                    //p.Observacion = (string)dr["Observacion"];
                    //p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    //ListaClas.Add(p);
                }
            }
            return ListaClas;
        }
        // verifica tipocambio
        public int ObtenerCertificadoCC(Int64 Tramite, int GrupoB, int TipoForm, int NoFormCalculo)
        {
            int valor = 0;

            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();

            using (IDataReader dr = permiso.ObtenerCertificadoCC(Tramite, GrupoB, TipoForm, NoFormCalculo))
            {
                while (dr.Read())
                {
                    valor = (int)dr[existedatos];
                }
            }
            return valor;
        }

        // // Calcular el monto aceptado a la fecha 
        public string CalcularMontosAlaFecha(int idtipoformc, int idtipocer, int idtipcc, string MontoCC, string fechagen)
        {
            string valor = "0";
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            using (IDataReader dr = permiso.CalcularMontosAlaFecha(idtipoformc, idtipocer, idtipcc, MontoCC, fechagen))
            {
                while (dr.Read())
                {
                    valor = (string)dr["nuevovalor"];
                }
            }
            return valor;
        }

        //27/04/2015
        public DataTable CalcularMontosAlaFecha(Int64 IdTramite,Int32 IdGrupoB,string Fecha) 
        {
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            return permiso.CalcularMontosAlaFecha(IdTramite, IdGrupoB, Fecha);
        }

        public DataTable BandejaEmisionCC(int IdConexion, string cOperacion,string NroCrenta,int iIdGrupoBeneficio, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.BandejaEmisionCC(IdConexion, cOperacion, NroCrenta,iIdGrupoBeneficio,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        public DataTable ValoresCC(int IdConexion, string cOperacion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.ValoresCC(IdConexion, cOperacion, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

        //CODIGO DE REEMPLAZO 2015-05-26
        public DataTable CalcularMontosaLaFecha(int IdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, string FechaAct,Int32 Tipoform,Int32 IdTipoCC, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.CalcularMontosaLaFecha(IdConexion, cOperacion, Tramite, GrupoB, FechaAct, Tipoform,IdTipoCC,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        //PARA LA IMPRESION
        public DataTable Impresion(Int64 IdTramite, Int32 IdGrupoB,Int32 IdTipoFormulario, Int32 NroFormulario)
        {
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            return permiso.Impresion(IdTramite, IdGrupoB, IdTipoFormulario,NroFormulario);
        }

        //CODIGO DE REEMPLAZO 
        public DataTable Impresion(int iIdConexion, string cOperacion, Int64 IdTramite, Int32 IdGupoBeneficio,Int32 IdTipoFormulario,Int32 NroFormulario, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.Impresion(iIdConexion, cOperacion, IdTramite, IdGupoBeneficio, IdTipoFormulario, NroFormulario, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }


        // Obtenr datos si certificado a sido impreso 
        public int ObtenerCertificadoImpreso(Int64 Tramite, int GrupoB, int TipoForm, int NoFormCalculo)
        {

            int valor = 0;
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            using (IDataReader dr = permiso.ObtenerCertificadoImpreso( Tramite,  GrupoB,  TipoForm,  NoFormCalculo))
            {
                while (dr.Read())
                {
                    valor = (int)dr["existedatos"];
                }
            }
            return valor;
        }

        //CODIGO DE REEMPLAZO
        public DataTable ObtenerCertificadoImpreso(int IdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, Int32 TipoForm, Int32 NoFormCalculo, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.ObtenerCertificadoImpreso(IdConexion, cOperacion, Tramite, GrupoB,TipoForm,NoFormCalculo, ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }
        //Obtener Datos completos del certificado a reimprimir
        public DataTable DatosCertificadoCompleto(int iIdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.DatosCertificadoCompleto(iIdConexion, cOperacion, Tramite, GrupoB,ref sMensajeError, ref DSetTmp))
            {
                return DSetTmp.Tables[0];
            }
            else
            {
                return (null);
            }
        }

      // obetenr 
        public List<clsEmisionCertificado> ObtenerEmisionCertificado(Int64 Tramite, int GrupoB, int TipoForm, int NoFormCalculo)
        {
            clsEmisionCertificado p;
            clsEmisionCertificadoDA permiso = new clsEmisionCertificadoDA();
            List<clsEmisionCertificado> ListaClas = new List<clsEmisionCertificado>();
            using (IDataReader dr = permiso.ObtenerEmisionCertificado(Tramite, GrupoB, TipoForm, NoFormCalculo))
            {
                while (dr.Read())
                {
                  
                    
                    p = new clsEmisionCertificado();
                    p.Idtramite = (Int64)dr["Idtramite"];
                    p.IdGrupoBeneficio = (int)dr["IdGrupoBeneficio"];
                    p.IdTipoFormularioCalculo = (int)dr["IdTipoFormularioCalculo"];
                    if (!DBNull.Value.Equals(dr["NoFormularioCalculo"]))
                        p.NoFormularioCalculo = (int)dr["NoFormularioCalculo"];
                    else
                        p.NoFormularioCalculo = 0;

                    p.IdTipoCC = (int)dr["IdTipoCC"];
                    if (!DBNull.Value.Equals(dr["NroCertificado"]))
                        p.NroCertificado = (int)dr["NroCertificado"];
                    else
                        p.NroCertificado = 0;

                    if (!DBNull.Value.Equals(dr["FechaEmision"]))
                        p.FechaEmision = (string)dr["FechaEmision"];
                    else
                        p.FechaEmision = "";

                    if (!DBNull.Value.Equals(dr["IdOficinaEmisionCC"]))
                        p.IdOficinaEmisionCC = (int)dr["IdOficinaEmisionCC"];
                    else
                        p.IdOficinaEmisionCC = 0;

                    if (!DBNull.Value.Equals(dr["IdUsuarioEmision"]))
                        p.IdUsuarioEmision = (int)dr["IdUsuarioEmision"];
                    else
                        p.IdUsuarioEmision = 0;
                 
                    if (!DBNull.Value.Equals(dr["FechaImpresionCC"]))
                        p.FechaImpresionCC =  (string)dr["FechaImpresionCC"];
                    else
                        p.FechaImpresionCC = "";

                    if (!DBNull.Value.Equals(dr["IdUsuarioImpresion"]))
                        p.IdUsuarioImpresion = (int)dr["IdUsuarioImpresion"];
                    else
                        p.IdUsuarioImpresion = 0;

                    if (!DBNull.Value.Equals(dr["CertificadoActivo"]))
                       p.CertificadoActivo = Convert.ToInt16((bool)dr["CertificadoActivo"]);
                    else
                        p.CertificadoActivo = 0;

                    if (!DBNull.Value.Equals(dr["RegistroAPS"]))
                        p.RegistroAPS = Convert.ToInt16((bool)dr["RegistroAPS"]);
                    else
                        p.RegistroAPS = 0;

                    if (!DBNull.Value.Equals(dr["IdEnvioAltaAPS"]))
                        p.IdEnvioAltaAPS = (int)dr["IdEnvioAltaAPS"];
                    else
                        p.IdEnvioAltaAPS = 0;

                    if (!DBNull.Value.Equals(dr["CursoPago"]))
                        p.CursoPago = Convert.ToInt16((bool)dr["CursoPago"]);
                    else
                        p.CursoPago = 0;

                    if (!DBNull.Value.Equals(dr["NroCertificadoReemplazo"]))
                        p.NroCertificadoReemplazo = (int)dr["NroCertificadoReemplazo"];
                    else
                        p.NroCertificadoReemplazo = 0;
                    
                    if (!DBNull.Value.Equals(dr["IdEstado"]))
                        p.IdEstado = (int)dr["IdEstado"];
                    else
                        p.IdEstado = 1;

                    if (!DBNull.Value.Equals(dr["RegistroActivo"]))
                        p.RegistroActivo = Convert.ToInt16((bool)dr["RegistroActivo"]);
                    else
                        p.RegistroActivo = 1;
               
                    ListaClas.Add(p);
                }
            }
            return ListaClas;
        }

        //OBTENER DATOS DEL FORMULARIO DE CALCULO PARA IMPRESION
        public DataTable ObtenerFormularioCalculoCC(int IdConexion, string cOperacion, Int64 Tramite, Int32 GrupoB, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (certificado.ObtenerFormularioCalculoCC(IdConexion, cOperacion,Tramite, GrupoB, ref sMensajeError, ref DSetTmp))
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

