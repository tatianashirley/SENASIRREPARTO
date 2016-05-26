using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using wcfEjemplo.Datos;
using wcfEjemplo.Entidades;

namespace wcfEjemplo.Logica
{
    public class clsSalarioReferencial : clsSalarioReferencialBE
    {
        public string[] ValidarSalarioCotizable(string Matricula, int IdTipoDocSalario, string PeriodoSalario, decimal SalarioCotizable, decimal IdMonedaSalario,
            int CantidadSalarios)
        {
            clsSalarioReferencialDA permiso = new clsSalarioReferencialDA();
            string[] resultado = new string[2];
            resultado = permiso.ValidaSalario(Matricula, IdTipoDocSalario, PeriodoSalario, SalarioCotizable, IdMonedaSalario, CantidadSalarios);
            return resultado;
        }

        public string SalarioFuerzasArmadas(string NumeroDocumento, string NUA)
        {
            string Salario = "";
            clsSalarioReferencialDA permiso = new clsSalarioReferencialDA();
            using (IDataReader dr = permiso.SalarioFuerzasArmadas(NumeroDocumento, NUA))
            {
                while (dr.Read())
                {
                    decimal dSalario = (decimal)dr["sal_oct96"];
                    Salario = dSalario.ToString();
                    Salario = Salario.Replace(",", ".");
                }
            }
            return Salario;
        }
    }
}