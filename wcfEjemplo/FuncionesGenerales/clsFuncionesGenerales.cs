using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace wcfEjemplo.Logica
{
    public class clsFuncionesGenerales
    {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

            public string EncryptKey(string cadena)
            {
                //arreglo de bytes donde guardaremos la llave
                byte[] keyArray;
                //arreglo de bytes donde guardaremos el texto
                //que vamos a encriptar
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);

                //se utilizan las clases de encriptación
                //provistas por el Framework
                //Algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                //se guarda la llave para que se le realice
                //hashing
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo 3DAS
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                //se empieza con la transformación de la cadena
                ICryptoTransform cTransform = tdes.CreateEncryptor();

                //arreglo de bytes donde se guarda la
                //cadena cifrada
                byte[] ArrayResultado =
                cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }

            public string DecryptKey(string clave)
            {
                byte[] keyArray;
                //convierte el texto en una secuencia de bytes
                byte[] Array_a_Descifrar = Convert.FromBase64String(clave);

                //se llama a las clases que tienen los algoritmos
                //de encriptación se le aplica hashing
                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                //se regresa en forma de cadena
                return UTF8Encoding.UTF8.GetString(resultArray);
            }


            public int SOLO_NUMEROS(string cadena) 
            {
                string Temp_Str;
                string Letra;
                Temp_Str = "";
                // TODO: On Error Resume Next Warning!!!: The statement is not translatable 
                for (int c = 0; (c <= cadena.Length); c++) {
                    Letra = cadena.Substring((c - 1), 1);
                    if ((("0123456789".IndexOf(Letra) + 1) 
                                > 0)) {
                        Temp_Str = (Temp_Str + Letra);
                    }
                }
                return Convert.ToInt16(Temp_Str);
            }
        }
}