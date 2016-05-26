using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {

    public class clsTransicionMasivaDet : clsTransicionMasivaDetBE {

        clsTransicionMasivaDetDA ObjTranMsvaDetDA = new clsTransicionMasivaDetDA();

        public Boolean Adicion() {
            ObjTranMsvaDetDA.iIdConexion = iIdConexion;
            ObjTranMsvaDetDA.iIdTransicionMsva = iIdTransicionMsva;
            ObjTranMsvaDetDA.iIdInstanciaEjecucion = iIdInstanciaEjecucion;
            ObjTranMsvaDetDA.iSecuenciaEjecucion = iSecuenciaEjecucion;
            ObjTranMsvaDetDA.iIdUsuario = iIdUsuario;
            ObjTranMsvaDetDA.sNemoNodoOrig = sNemoNodoOrig; 
            ObjTranMsvaDetDA.sNemoNodoDest = sNemoNodoDest;
            Boolean AnsOK = ObjTranMsvaDetDA.Adicion();
            iIdTransicionMsva = ObjTranMsvaDetDA.iIdTransicionMsva;
            sMensajeError = ObjTranMsvaDetDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean AdicionItemLista(Int32 iIdTransicionMsva, Int64 iIdInstanciaEjecucion, Int32 iSecuenciaEjecucion, Int32 iIdUsuario, string sNemoNodoOrig, string sNemoNodoDest) {
            Boolean AnsOk = true;
            string Cadena = ""; 
            try {
                Cadena = iIdTransicionMsva.ToString() + "|" + iIdInstanciaEjecucion.ToString() + "|" + iSecuenciaEjecucion.ToString() + "|" + iIdUsuario.ToString() + "|" + sNemoNodoOrig.Trim() + "|" + sNemoNodoDest.Trim();
                Lista.Add(Cadena);
            } catch { 
                AnsOk = false;
            }
            return (AnsOk);
        }

        public Boolean AdicionLote() {
            List <string> ListaTmp = new List<string>();
            string CadenaTmp = "";

            foreach (string Cadena in Lista) {
                string[] Arreglo = Cadena.Split('|');
                ObjTranMsvaDetDA.iIdConexion = iIdConexion;
                if (iIdTransicionMsva != 0) {
                    ObjTranMsvaDetDA.iIdTransicionMsva = iIdTransicionMsva;
                }
                ObjTranMsvaDetDA.iIdInstanciaEjecucion = Int32.Parse(Arreglo[1]);
                ObjTranMsvaDetDA.iSecuenciaEjecucion = Int32.Parse(Arreglo[2]);
                ObjTranMsvaDetDA.iIdUsuario = Int32.Parse(Arreglo[3]);
                ObjTranMsvaDetDA.sNemoNodoOrig = Arreglo[4];
                ObjTranMsvaDetDA.sNemoNodoDest = Arreglo[5];
                Boolean AnsOK = ObjTranMsvaDetDA.Adicion();
                if (AnsOK) {
                    iIdTransicionMsva = ObjTranMsvaDetDA.iIdTransicionMsva;
                    sMensajeError = "OK";
                } else {
                    sMensajeError = ObjTranMsvaDetDA.sMensajeError;
                }
                CadenaTmp = Cadena + "|" + sMensajeError;
                ListaTmp.Add(CadenaTmp);
            }

            if (ObtieneActividadesDisponilesParaAsignacion()) {
                foreach (string Cadena in ListaTmp) {
                    string[] Arreglo = Cadena.Split('|');
                    DataRow[] ArrDRow = DSet.Tables[0].Select("IdInstancia=" + Arreglo[1] + " and " + "Secuencia=" + Arreglo[2]);
                    if (ArrDRow.Length > 0) {
                        if (Arreglo[6] != "OK") {
                            ArrDRow[0]["EstadoAsignacion"] = Arreglo[6];
                            DSet.Tables[0].AcceptChanges();
                        }
                    }
                }
            }

            return(true);
        }

        public Boolean Eliminacion() {
            ObjTranMsvaDetDA.iIdConexion = iIdConexion;
            ObjTranMsvaDetDA.iIdTransicionMsva = iIdTransicionMsva;
            ObjTranMsvaDetDA.iIdInstanciaEjecucion = iIdInstanciaEjecucion;
            ObjTranMsvaDetDA.iSecuenciaEjecucion = iSecuenciaEjecucion;
            Boolean AnsOK = ObjTranMsvaDetDA.Eliminacion();
            sMensajeError = ObjTranMsvaDetDA.sMensajeError;
            return (AnsOK);
        }

                                                                                                                                                                                                                   
        public Boolean ObtieneUsuarios() {
            ObjTranMsvaDetDA.iIdConexion = iIdConexion;
            ObjTranMsvaDetDA.iIdInstanciaEjecucion = iIdInstanciaEjecucion;
            ObjTranMsvaDetDA.iSecuenciaEjecucion = iSecuenciaEjecucion;
            ObjTranMsvaDetDA.sNemoNodoDest = sNemoNodoDest;
            Boolean AnsOK = ObjTranMsvaDetDA.ObtieneUsuarios();
            DSet = ObjTranMsvaDetDA.DSet;
            sMensajeError = ObjTranMsvaDetDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneActividadesPendientesXUsuario() {
            ObjTranMsvaDetDA.iIdConexion = iIdConexion;
            ObjTranMsvaDetDA.iIdTransicionMsva = iIdTransicionMsva;
            ObjTranMsvaDetDA.iIdUsuario = iIdUsuario;
            Boolean AnsOK = ObjTranMsvaDetDA.ObtieneActividadesPendientesXUsuario();
            DSet = ObjTranMsvaDetDA.DSet;
            sMensajeError = ObjTranMsvaDetDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneActividadesDisponilesParaAsignacion() {
            ObjTranMsvaDetDA.iIdConexion = iIdConexion;
            ObjTranMsvaDetDA.iIdTransicionMsva = iIdTransicionMsva;
            ObjTranMsvaDetDA.sNemoNodoOrig = sNemoNodoOrig;
            Boolean AnsOK = ObjTranMsvaDetDA.ObtieneActividadesDisponilesParaAsignacion();
            DSet = ObjTranMsvaDetDA.DSet;
            sMensajeError = ObjTranMsvaDetDA.sMensajeError;
            return (AnsOK);
        }

    }

}