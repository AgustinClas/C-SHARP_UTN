using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador sea +, -, * o /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Operador validado, en caso de no haber ingresado uno correspondiente deuvelve '+'</returns>
        private static string ValidarOperador(char operador)
        {
            string operadorValidado;

            if (operador == '*')
            {
                operadorValidado = "*";

            }else if(operador == '/')
            {
                operadorValidado = "/";

            }
            else if (operador == '-')
            {
                operadorValidado = "-";

            }
            else
            {
                operadorValidado = "+";
            }

            return operadorValidado;
        }

        /// <summary>
        /// Valida y realiza la operacion pedida entre los numeros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double resultado = 0;
            string operadorAux;
      
            operadorAux = ValidarOperador(operador);

            switch (operadorAux)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            
            return resultado;
        }
    }
}
