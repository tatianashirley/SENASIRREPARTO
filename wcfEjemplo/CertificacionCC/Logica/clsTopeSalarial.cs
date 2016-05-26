using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using wcfEjemplo.Datos;
using wcfEjemplo.Entidades;

namespace wcfEjemplo.Logica
{
    public class clsTopeSalarial : clsTopeSalarialBE
    {
        //Verifica si el salario cotizable es menor al tope permitido + 10% de acuerdo al periodo, devolviendo el id de la moneda correpondiente al periodo, ó 0 si no lo es.
        public int VerificarCargar(string Periodo, decimal Monto)
        {
            clsTopeSalarialDA permiso = new clsTopeSalarialDA();
            DateTime Fecha;
            int Cotizable;
            string DescripcionDetalleClasificador;
            int TipoMoneda;

            using (IDataReader dr = permiso.EncuentraTopePeriodo(Periodo))
            {
                while (dr.Read())
                {
                    if (!DBNull.Value.Equals(dr["Fecha"]))
                        Fecha = (DateTime)dr["Fecha"];
                    else
                        Fecha = DateTime.MinValue;

                    if (!DBNull.Value.Equals(dr["SalarioCotizable"]))
                        SalarioCotizable = (decimal)dr["SalarioCotizable"];
                    else
                        SalarioCotizable = 0;

                    if (!DBNull.Value.Equals(dr["DescripcionDetalleClasificador"]))
                        DescripcionDetalleClasificador = (string)dr["DescripcionDetalleClasificador"];
                    else
                        DescripcionDetalleClasificador = "";

                    if (!DBNull.Value.Equals(dr["IdMoneda"]))
                        TipoMoneda = (int)dr["IdMoneda"];
                    else
                        TipoMoneda = 0;

                    if (Monto < SalarioCotizable)
                        return TipoMoneda;
                    else 
                        return 0;
                }
            }
            return 0;
        }
    }
}