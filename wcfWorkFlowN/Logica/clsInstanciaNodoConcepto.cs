using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWorkFlowN.Entidades;
using wcfWorkFlowN.Datos;

namespace wcfWorkFlowN.Logica {
    public class clsInstanciaNodoConcepto : clsInstanciaNodoConceptoBE {

        clsInstanciaNodoConceptoDA ObjINodoCptoDA = new clsInstanciaNodoConceptoDA();

        Int32 iValorIntTmp = 0;
        Decimal mValorMoneyTmp = 0;
        Double dValorFloatTmp = 0;
        String sValorStringTmp = "";
        DateTime fValorDateTimeTmp = DateTime.Parse("01/01/1900");
        Int32 iValorCatalogTmp = 0;
        Boolean bValorBooleanTmp = false;
        
        private Boolean ValidacionValor() {
            if (sTipoDato == "I") {
                return (Int32.TryParse(sValorGenerico0, out iValorIntTmp)); 
            } else if (sTipoDato == "M") {
                return (Decimal.TryParse(sValorGenerico0, out mValorMoneyTmp)); 
            } else if (sTipoDato == "F") {
                return (Double.TryParse(sValorGenerico0, out dValorFloatTmp)); 
            } else if (sTipoDato == "C") {
                if (sValorGenerico0.Contains("'")) {
                    return (false);
                } else {
                    sValorStringTmp = sValorGenerico0;
                    return (true);
                }
            } else if (sTipoDato == "D") {
                return (DateTime.TryParse(sValorGenerico0, out fValorDateTimeTmp));
            } else if (sTipoDato == "T") {
                return (Int32.TryParse(sValorGenerico0, out iValorCatalogTmp));
            } else if (sTipoDato == "B") {
                if (sValorGenerico0 == "S" || sValorGenerico0 == "N") {
                    bValorBooleanTmp = (sValorGenerico0 == "S");
                    return (true);
                } else {
                    return (false);
                }
            }
            return (false); 
        }

        public Boolean Grabar() {
            if (sValorGenerico0 == "SINASIGNAR") {
                ObjINodoCptoDA.iIdConexion = iIdConexion;
                ObjINodoCptoDA.iIdInstancia = iIdInstancia;
                ObjINodoCptoDA.iSecuencia = iSecuencia; 
                ObjINodoCptoDA.sIdConcepto = sIdConcepto;
                if (ObjINodoCptoDA.ObtieneDefinicionConcepto()) {
                    sTipoDato = ObjINodoCptoDA.DSet.Tables[0].Rows[0]["TipoDato"].ToString();
                    if (sTipoDato == "B") {
                        ObjINodoCptoDA.bValorBoolean = bValorBoolean;
                    } else if (sTipoDato == "I")  {
                        ObjINodoCptoDA.iValorInt = iValorInt;
                    } else if (sTipoDato == "M")  {
                        ObjINodoCptoDA.mValorMoney = mValorMoney;
                    } else if (sTipoDato == "F")  {
                        ObjINodoCptoDA.dValorFloat = dValorFloat;
                    } else if (sTipoDato == "C")  {
                        ObjINodoCptoDA.sValorChar = sValorChar;
                    } else if (sTipoDato == "D")  {
                        ObjINodoCptoDA.fValorDate = fValorDate;
                    } else if (sTipoDato == "T")  {
                        ObjINodoCptoDA.iValorCatalog = iValorCatalog;
                    }
                    ObjINodoCptoDA.iIdConexion = iIdConexion;
                    ObjINodoCptoDA.iIdInstancia = iIdInstancia;
                    ObjINodoCptoDA.iSecuencia = iSecuencia;
                    ObjINodoCptoDA.sIdConcepto = sIdConcepto;
                    ObjINodoCptoDA.sComentarios = sComentarios;

                    Boolean AnsOK = ObjINodoCptoDA.Grabar();
                    sMensajeError = ObjINodoCptoDA.sMensajeError;
                    return (AnsOK);
                } else {
                    sMensajeError = "El concepto especificado no está registrado para la actividad especificada";
                    return (false);
                }
            }

            if (ValidacionValor() ) {
                ObjINodoCptoDA.iIdConexion = iIdConexion;
                ObjINodoCptoDA.iIdInstancia = iIdInstancia;
                ObjINodoCptoDA.iSecuencia = iSecuencia;
                ObjINodoCptoDA.sIdConcepto = sIdConcepto;
                ObjINodoCptoDA.sComentarios = sComentarios;
                ObjINodoCptoDA.iValorInt = iValorIntTmp;
                ObjINodoCptoDA.mValorMoney = mValorMoneyTmp;
                ObjINodoCptoDA.dValorFloat = dValorFloatTmp;
                ObjINodoCptoDA.sValorChar = sValorStringTmp;
                ObjINodoCptoDA.fValorDate = fValorDateTimeTmp;
                ObjINodoCptoDA.iValorCatalog = iValorCatalogTmp;
                ObjINodoCptoDA.bValorBoolean = bValorBooleanTmp;

                Boolean AnsOK = ObjINodoCptoDA.Grabar();
                sMensajeError = ObjINodoCptoDA.sMensajeError;
                return (AnsOK);
            } else {
                sMensajeError = "El valor especificado no es válido";
                return (false);
            }
        }

        public Boolean Eliminacion() {
            ObjINodoCptoDA.iIdConexion = iIdConexion;
            ObjINodoCptoDA.iIdInstancia = iIdInstancia;
            ObjINodoCptoDA.iSecuencia = iSecuencia;
            ObjINodoCptoDA.sIdConcepto = sIdConcepto;

            Boolean AnsOK = ObjINodoCptoDA.Eliminacion();
            sMensajeError = ObjINodoCptoDA.sMensajeError;
            return (AnsOK);
        }

        public Boolean ObtieneConceptosXActividad() {
            ObjINodoCptoDA.iIdConexion = iIdConexion;
            ObjINodoCptoDA.iIdInstancia = iIdInstancia;
            ObjINodoCptoDA.iSecuencia = iSecuencia;
            Boolean AnsOK = ObjINodoCptoDA.ObtieneConceptosXActividad();
            DSet = ObjINodoCptoDA.DSet;
            sMensajeError = ObjINodoCptoDA.sMensajeError;
            return (AnsOK);
        }

    }
}