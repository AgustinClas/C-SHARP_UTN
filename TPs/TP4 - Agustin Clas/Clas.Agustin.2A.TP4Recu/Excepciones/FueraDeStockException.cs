using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FueraDeStockException : Exception
    {
        /// <summary>
        /// Excepcion que sera lanzada cuando el usuario intente comprar un producto fuera de stock
        /// </summary>
        public FueraDeStockException() : base("Este item no se se encuentra en stock") { }
    }
}
