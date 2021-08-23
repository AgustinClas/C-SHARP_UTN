using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CartucheraLlenaException : Exception
    {
        public CartucheraLlenaException() { }

        public string InformarNovedad()
        {
            return "No se puede agregar este util ya que la cartuchera se encuentra llena";
        }
    }
}
