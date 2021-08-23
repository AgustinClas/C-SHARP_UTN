using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ContraseñaIncorrectaException : Exception
    {
        /// <summary>
        /// Excepcion que sera lanzada cuando el usuario ingrese una contraseña erronea
        /// </summary>
        public ContraseñaIncorrectaException() : base("Contraseña incorrecta") { }
    }
}
