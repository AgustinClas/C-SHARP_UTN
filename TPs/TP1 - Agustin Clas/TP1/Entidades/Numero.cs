using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad set que valida antes de asignar el numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        #region Constructores

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Suma dos Numeros pasados por parametros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;
            return resultado;
        }

        /// <summary>
        /// Resta dos Numeros pasados por parametros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;
            return resultado;
        }

        /// <summary>
        /// Multiplica dos Numeros pasados por parametros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;
            return resultado;
        }

        /// <summary>
        /// Divide dos Numeros pasados por parametros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Resultado</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }

            return resultado;
        }

        #endregion

        /// <summary>
        /// Comprueba que la cadena pasada sea un numero binario
        /// (Solo contenga ceros y unos)
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>true si lo es, false en caso de no serlo</returns>
        private bool EsBinario(string binario)
        {
            if (binario != "" && binario != null)
            {
                StringBuilder auxBinario = new StringBuilder(binario);
                bool esBinario = true;

                for (int i = (auxBinario.Length - 1); i >= 0; i--)
                {
                    if (auxBinario[i] != '1' && auxBinario[i] != '0')
                    {
                        esBinario = false;
                        break;
                    }
                    
                }

                return esBinario;
            }
            else
                return false;
        }

        /// <summary>
        /// Valida que la cadena pasada sea un numero
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Numero validado, 0 si la cadena no era un numero</returns>
        private double ValidarNumero(string strNumero)
        {
            double numValidado;

            if (!(double.TryParse(strNumero, out numValidado)))
            {
                numValidado = 0;
            }

            return numValidado;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Numero convertido a binario, o valor invalido si se ingreso una cadena erronea</returns>
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            double resto;
            double numeroEntero = Math.Floor(numero);

            if (numeroEntero >= 0)
            {
                while (numeroEntero > 1)
                {
                    resto = numeroEntero % 2;
                    numeroEntero = Math.Floor(numeroEntero / 2);

                    numeroBinario = resto.ToString() + numeroBinario;
                }

                numeroBinario = numeroEntero.ToString() + numeroBinario;
            }
            else
            {
                numeroBinario = "Valor invalido";
            }
            return numeroBinario;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Numero convertido a binario, o valor invalido si se ingreso una cadena erronea</returns>
        public string DecimalBinario(string numero)
        {
            double auxNum;

            if (double.TryParse(numero, out auxNum))
                return this.DecimalBinario(auxNum);
            else
                return "Valor invalido";
                    
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Numero convertido a decimal, o valor invalido si se ingreso una cadena erronea</returns>
        public string BinarioDecimal(string binario)
        {
            int numeroDecimal = 0;
            string numeroDecimalStr = "Valor invalido";
            char[] numeroBinario = binario.ToCharArray();


            if (this.EsBinario(binario))
            {
                 Array.Reverse(numeroBinario);

                 for(int i=0; i < numeroBinario.Length; i++)
                 {
                     if(numeroBinario[i] == '1')
                     {
                         numeroDecimal += (int)Math.Pow(2, i);
                     }
                 }

                 numeroDecimalStr = "" + numeroDecimal;
                
            }

            return numeroDecimalStr;
        }
    }
}
