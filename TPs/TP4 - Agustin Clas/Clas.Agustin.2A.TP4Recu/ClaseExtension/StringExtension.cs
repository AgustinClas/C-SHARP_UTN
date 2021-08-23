using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace MetodoDeExtension
{
    public static class StringExtension
    {
        /// <summary>
        /// Valida si la contraseña pasada por parametro es igual a la harcodeada
        /// Uso de metodo de extension
        /// </summary>
        /// <param name="contraseña"></param>
        /// <returns>true si la contraseña es valida, lanza una exception en caso de no serlo</returns>
        public static bool ValidarContraseña(this string contraseña)
        {
            if (contraseña == "sport2020")
                return true;
            else
                throw new ContraseñaIncorrectaException();
        }
    }
}
