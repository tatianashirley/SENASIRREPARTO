using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using wcfWFArticulador.Entidades;
using wcfWFArticulador.Datos;
using System.Data;

namespace wcfWFArticulador.Logica
{
    public class clsBandejaUsuario : clsBandejaUsuarioBE
    {
        #region "Declaración de funciones/Procedimientos Capa Logica"
        clsBandejaUsuarioDA objBandejaUsuarioDA = new clsBandejaUsuarioDA();

        /// <summary>
        /// Lista Bandeja Entrada
        /// </summary>
        /// <returns></returns>
        public Boolean ListaBandejaEntrada()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "Pendientes430";
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Bandeja Entrada Detalle
        /// </summary>
        /// <returns></returns>
        public Boolean ListaBandejaEntradaDetalle()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "Listado430";
            objBandejaUsuarioDA.iId430 = iId430;
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaDetalleDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Busca Tramite en Bandeja Entrada
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaTramiteBandejaEntrada()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "TramitePendiente";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.BuscaTramiteBandejaDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Historial de movimientos de un Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean HistorialTramite()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "SeguimientoTramite";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.HistorialTramiteDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Seguimiento Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean SeguimientoTramites()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "ControlUnidad";
            objBandejaUsuarioDA.fFecha1 = fFecha1;
            objBandejaUsuarioDA.fFecha2 = fFecha2;
            Boolean AnsOK = objBandejaUsuarioDA.SeguimientoTramitesDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Busca Tramite en Bandeja de Trabajo
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaTramiteBandejaTrabajo()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "TramiteAceptado";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.BuscaTramiteBandejaDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Bandeja Trabajo
        /// </summary>
        /// <returns></returns>
        public Boolean ListaBandejaTrabajo()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "TramitesAceptados";
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaTrabajoDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Bandeja Trabajo
        /// </summary>
        /// <returns></returns>
        public Boolean CantidadTramitesBandejaTrabajo()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "CantidadTrabajo";
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaTrabajoDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Busca Tramite PreAsigna en Bandeja de Trabajo
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaTramitePreAsignaBandejaTrabajo()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "TramitePreAsignar";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            objBandejaUsuarioDA.iIdAreaDestino = iIdAreaDestino;
            objBandejaUsuarioDA.iIdAreaDestinoNew = iIdAreaDestinoNew;
            objBandejaUsuarioDA.iIdRolNew = iIdRolNew;
            Boolean AnsOK = objBandejaUsuarioDA.BuscaTramiteBandejaTrabajoDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Posibles Destinos a derivarse un tramite para un usuario (iIdConexion)
        /// </summary>
        /// <returns></returns>
        public Boolean ListaPosiblesDestinos()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "AreaDestinoPosible";
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Usuario Destino Posible
        /// </summary>
        /// <returns></returns>
        public Boolean ListaUsuarioDestinoPosible()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "RolDestinoPosible";
            objBandejaUsuarioDA.iIdAreaDestino = iIdAreaDestino;
            objBandejaUsuarioDA.iIdAreaDestinoNew = iIdAreaDestinoNew;
            Boolean AnsOK = objBandejaUsuarioDA.ListaUsuarioDestinoPosibleDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Acepta Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean AceptaTramite()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "Acepta";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.FlujoTramiteDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Acepta Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean RechazaTramite()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "Rechaza";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.FlujoTramiteDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Asigna Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean AsignaTramite()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "Asigna";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            objBandejaUsuarioDA.iIdRuta = iIdRuta;
            objBandejaUsuarioDA.iIdAreaDestinoNew = iIdAreaDestinoNew;
            objBandejaUsuarioDA.fFechaAsignacion = fFechaAsignacion;
            objBandejaUsuarioDA.sObsSalidaArea = sObsSalidaArea;
            objBandejaUsuarioDA.sProvehido = sProvehido;
            Boolean AnsOK = objBandejaUsuarioDA.AsignaTramiteDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Busca Tramite en Bandeja Salida
        /// </summary>
        /// <returns></returns>
        public Boolean BuscaTramiteBandejaSalida()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "TramiteAsignado";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.BuscaTramiteBandejaDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Bandeja Salida
        /// </summary>
        /// <returns></returns>
        public Boolean ListaBandejaSalida()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "TramitesAsignados430";
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Lista Bandeja Salida Detalle
        /// </summary>
        /// <returns></returns>
        public Boolean ListaBandejaSalidaDetalle()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "AsignadoListado430";
            objBandejaUsuarioDA.iId430 = iId430;
            Boolean AnsOK = objBandejaUsuarioDA.ListaBandejaDetalleDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }

        /// <summary>
        /// Cancela Tramite
        /// </summary>
        /// <returns></returns>
        public Boolean CancelaTramite()
        {
            objBandejaUsuarioDA.iIdConexion = iIdConexion;
            objBandejaUsuarioDA.Tipo = "Cancela";
            objBandejaUsuarioDA.sIdTramite = sIdTramite;
            Boolean AnsOK = objBandejaUsuarioDA.FlujoTramiteDA();
            DSet = objBandejaUsuarioDA.DSet;
            sMensajeError = objBandejaUsuarioDA.sMensajeError;
            return (AnsOK);
        }
        #endregion
    }
}