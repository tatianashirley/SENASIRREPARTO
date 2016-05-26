using System;
using System.Collections.Generic;
using System.Data;
using wcfPagoUnico.Datos;
using wcfPagoUnico.Entidades;

namespace wcfPagoUnico.Logica
{
    public class clsPUProcesos
    {
        clsPUProcesosDA ObjProcesoDA = new clsPUProcesosDA();
        clsPUUtilitarios objUtil = new clsPUUtilitarios();

        //Registra documentos con solicitante
        public long RegistraDocumentos(int iIdConexion, string cOperacion, ref string sMensajeError, 
            List<int> Documento, long vCUA, long vNUP)
        {
            long NUPResultado = 0;

            if (ObjProcesoDA.RegistraDocumentos(iIdConexion, cOperacion, ref sMensajeError,
            Documento, vCUA, vNUP, ref NUPResultado))
            {
                return NUPResultado;
            }
            else
            {
                return 0;
            }
        }

        //Obtiene los documentos que fueron presentados por el titular o DH
        public DataTable ObtieneDocumentos(int iIdConexion, string cOperacion, ref string sMensajeError, 
            long vCUA)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.ObtieneDocumentos(iIdConexion, cOperacion, ref sMensajeError, ref DSetTmp, vCUA))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Actualiza los datos del certificado
        /*public long ActualizaCertificados(int iIdConexion, string cOperacion, ref string sMensajeError, long NUP, string HojaRuta, int IdUsuarioHojaRuta, long Tramite, int NumeroCertificado, long AniosInsalubres, string PersonaSol, List<long> NUPSOlicitante, int Porcentaje)
        {
            DataTable NUPSol = objUtil.ToDataTable(NUPSOlicitante);

            if (ObjProcesoDA.ActualizaCertificado(iIdConexion, cOperacion, ref sMensajeError, ref NUP, HojaRuta, IdUsuarioHojaRuta, Tramite, NumeroCertificado, AniosInsalubres, PersonaSol, NUPSol, Porcentaje))
            {
                return NUP;
            }
            else
            {
                return 0;
            }
        }*/

        //Obtiene el clasificador de los porcentajes que se debe asignar a un DH
        public DataTable ObtieneClasiPorcentaje()
        {
            DataTable dt = new DataTable();
            clsPUProcesosDA val = new clsPUProcesosDA();
            IDataReader dr = val.ObtieneClasiPorcentaje();
            dt.Load(dr);
            return dt;
        }

        //Actualiza los datos del certificado
        public long ActualizaCertificado(int iIdConexion, string cOperacion, ref string sMensajeError, long NUP, string HojaRuta, long Tramite, int NumeroCertificado, long AniosInsalubres, string PersonaSol, DataTable tDH, string TipoSolicitud)
        {
            //DataTable NUPSol = objUtil.ToDataTable(NUPSOlicitante);

            //DataTable dt = new DataTable();
            clsPUProcesosDA val = new clsPUProcesosDA();
            long NUPResult = val.ActualizaCertificado(iIdConexion, cOperacion, ref sMensajeError, NUP, HojaRuta, Tramite, NumeroCertificado, AniosInsalubres, PersonaSol, tDH, TipoSolicitud);

            return NUPResult;
        }

        //Actualiza los estados del PU
        public long ActualizaEstadosPU(int IdConexion, string cOperacion, ref string sMensajeError, long NUPTitular, long NUPDH, int Estado, long Tramite, int NumeroCertificado)
        {
            long NUPResul = 0;

            if (ObjProcesoDA.ActualizaEstadosPU(IdConexion, cOperacion, ref sMensajeError, NUPTitular, NUPDH, Estado, Tramite, NumeroCertificado, ref NUPResul))
            {
                return NUPResul;
            }
            else
            {
                return 0;
            }
        }

        //Obtiene datos del Titular o DH solicitante.
        public DataTable ObtieneDatosSolicitantes(int IdConexion, string cOperacion, ref string sMensajeError, string vMatricula, string vNroDocumento)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.ObtieneDatosSolicitantes(IdConexion, cOperacion, ref sMensajeError, vMatricula,vNroDocumento, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Genera el numero de cheque.
        public long GeneraChequePU(int IdConexion, string cOperacion, ref string sMensajeError, int vIdBanco, int vC31, int vAnioProc, int vMesProc)
        {
            long NUPResultado = 0;

            if (ObjProcesoDA.GeneraChequePU(IdConexion, cOperacion, ref sMensajeError, vIdBanco, vC31, vAnioProc, vMesProc, ref NUPResultado))
            {
                return NUPResultado;
            }
            else
            {
                return 0;
            }
        }

        //Resgistra la resolucion que fue otorgada a la solicitud de pago del PU.
        public long RegistraResolucion(int IdConexion, string cOperacion, ref string sMensajeError, long vNUPTitular, long vNUPDH, long vResolucion, DateTime vFechaReso)
        {
            long NUPResultado = 0;

            if (ObjProcesoDA.RegistraResolucion(IdConexion, cOperacion, ref sMensajeError, vNUPTitular, vNUPDH, vResolucion, vFechaReso, ref NUPResultado))
            {
                return NUPResultado;
            }
            else
            {
                return 0;
            }
        }

        //Lista todos las personas Titulares o DH para pagar el PU por mes
        public DataTable ListarAprobadosMes(int IdConexion, string cOperacion, ref string sMensajeError, int vAnio, int vMes)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.ListarAprobadosMes(IdConexion, cOperacion, ref sMensajeError, vAnio, vMes, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Registra el documento C31.
        public long RegistraC31(int iIdConexion, ref string sMensajeError, clsPUC31 C31)
        {
            long Res = 0;
            if (ObjProcesoDA.RegistraC31(iIdConexion, "I", ref sMensajeError, C31, ref Res))
            {
                return Res;
            }
            else
            {
                return 0;
            }
        }

        //Obtiene el C31 de un anio y mes de procesos dados
        public DataTable ObtieneC31(int IdConexion, ref string sMensajeError, int vAnioProc, int vMesProc)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.ObtieneC31(IdConexion, "Q", ref sMensajeError, vAnioProc, vMesProc, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Obtiene el C31 en general.
        public DataTable ObtieneGeneralC31(int IdConexion, ref string sMensajeError)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.ObtieneGeneralC31(IdConexion, "Q", ref sMensajeError, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Modifica los datos del C31 de un anio y mes de procesos dados
        public long ModificaC31(int iIdConexion, ref string sMensajeError, int vC31, decimal vTotal, int vAnioProceso, int vMesProceso)
        {
            long Res = 0;
            if (ObjProcesoDA.ModificaC31(iIdConexion, "U", ref sMensajeError, vC31, vTotal, vAnioProceso, vMesProceso, ref Res))
            {
                return Res;
            }
            else
            {
                return 0;
            }
        }

        //Genera los datos necesarios para crear el medio para el C31
        public DataTable GeneraMediosC31(int IdConexion, ref string sMensajeError, int vC31, int vAnio, int vMes)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.GeneraMediosC31(IdConexion, "Q", ref sMensajeError, vC31, vAnio, vMes, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Genera los datos necesarios para crear el medio para el PU.
        public DataTable GeneraMediosPU(int IdConexion, ref string sMensajeError, int vC31, int vAnio, int vMes)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.GeneraMediosPU(IdConexion, "Q", ref sMensajeError, vC31, vAnio, vMes, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Devuelve si el NUP ingresado tiene un cheque en estado Revertido.
        public bool ChequeRevertido(int IdConexion, ref string sMensajeError, long vNUP)
        {
            DataSet DSetTmp = new DataSet();
            int Cantidad = 0;
            if (ObjProcesoDA.ChequeRevertido(IdConexion, "Q", ref sMensajeError, vNUP, ref Cantidad))
            {
                if (Cantidad > 0)
                    return (true);
                else
                    return (false);

            }
            else
            {
                return (false);
            }
        }

        //Devuelve si el NUP ingresado tiene un cheque en estado Revertido o los montos antriores y actualizados
        public DataTable MontosCertificado(int IdConexion, ref string sMensajeError, long vNUP)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.MontosCertificado(IdConexion, "Q", ref sMensajeError, vNUP, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

        //Dar de baja el documento C31 y las presolicitudes los certificados.
        public int AnulaC31(int iIdConexion, ref string sMensajeError, int vAnio, int vMes)
        {
            int Res = 0;
            if (ObjProcesoDA.AnulaC31(iIdConexion, ref sMensajeError, vAnio, vMes, ref Res))
            {
                return Res;
            }
            else
            {
                return 0;
            }
        }

        //Dar de baja el documento C31 y las presolicitudes los certificados.
        public int AnularCheque(int iIdConexion, ref string sMensajeError, DataTable Cheque)
        {
            int Res = 0,cantidad=0;
            int vNumeroCheque, vNumeroBanco;

            foreach(DataRow fila in Cheque.Rows){
                vNumeroCheque=Convert.ToInt32(fila[0]);
                vNumeroBanco=Convert.ToInt32(fila[1]);

                if (ObjProcesoDA.AnularCheque(iIdConexion, ref sMensajeError, vNumeroCheque, vNumeroBanco, ref Res))
                {
                    if (Res == 1) cantidad++;
                }
            }

            if(cantidad==Cheque.Rows.Count)
                return 1;
            else if (cantidad < Cheque.Rows.Count && cantidad > 0)
            {
                sMensajeError = "Se produjo algun error al anular los cheques, por favor verifique los mismos." + " " + sMensajeError;
                return 0;
            }
            else return -1;
        }

        //Lista los cheques generados en un determinado ao y mes ingresados.
        public DataTable ListadoChequesGenerados(int IdConexion, ref string sMensajeError, int vAnio, int vMes)
        {
            DataSet DSetTmp = new DataSet();
            if (ObjProcesoDA.ListadoChequesGenerados(IdConexion, "Q", ref sMensajeError, vAnio, vMes, ref DSetTmp))
            {
                return (DSetTmp.Tables[0]);
            }
            else
            {
                return (null);
            }
        }

    }
}