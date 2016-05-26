using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace wcfPagoUnico.Logica
{
    public class clsPUUtilitarios
    {
        //Generar Matricula
        public string GenerarMatricula(string pat, string mat, string nombre, DateTime fnac, string sex)
        {
            string result = "";
            string mat_new;
            try
            {
                string ip = "";
                string im = "";
                string ino = "";
                int tsexo;
                int a, d, m;
                string a1, d1, m1;

                if (pat == "NULL" || pat.Trim() == "")
                {
                    pat = "";
                }
                else
                {
                    pat = pat.Trim();
                    ip = pat.Substring(0, 1);
                }

                if (mat == "NULL" || mat.Trim() == "")
                {
                    mat = "";
                }
                else
                {
                    mat = mat.Trim();
                    im = mat.Substring(0, 1);
                }

                if (nombre == "NULL" || nombre.Trim() == "")
                {
                    nombre = "";
                }
                else
                {
                    nombre = nombre.Trim();
                    ino = nombre.Substring(0, 1);
                }

                if (ip == "" && im != "")
                {
                    if (mat.Length > 1)
                    {
                        im = mat.Substring(0, 2);
                    }
                }
                if (im == "" && ip != "")
                {
                    if (pat.Length > 1)
                    {
                        ip = pat.Substring(0, 2);
                    }
                }

                tsexo = 0;

                if (sex == "1" || sex == "F")
                {
                    tsexo = 50;
                }

                a = fnac.Year;
                m = fnac.Month;
                d = fnac.Day;
                m = m + tsexo;

                a1 = a.ToString().Substring(2, 2);
                if (m < 10)
                {
                    m1 = "0" + m;
                }
                else
                {
                    m1 = m.ToString();
                }

                if (d < 10)
                {
                    d1 = "0" + d;
                }
                else
                {
                    d1 = d.ToString();
                }

                mat_new = a1 + m1 + d1 + ip + im + ino;
                result = mat_new.ToUpper();
            }
            catch (Exception ex)
            {
                result = "";
                System.Console.Write(ex.Message);
            }
            return result;
        }

        //Pasa datos de un List a un DataTable
        public DataTable ToDataTable(List<long> lista)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("NUP",typeof(long));
            foreach (var item in lista)
            {
                dt.Rows.Add(item);
            }

            return dt;
        }
    }
}