using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entidades
{
    //Crear, en class library, la clase Cartuchera<T> -> restringir para que sólo lo pueda usar Utiles 
    //o clases que deriven de Utiles.
    //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
    //Propiedades:
    //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
    //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
    //Constructor
    //Cartuchera(), Cartuchera(int); 
    //El constructor por default es el único que se encargará de inicializar la lista.
    //Métodos:
    //ToString: Mostrará en formato de tipo string: 
    //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
    //de todos los elementos contenidos en la misma. Reutilizar código.
    //Sobrecarga de operadores:
    //(+) Será el encargado de agregar elementos a la cartuchera, 
    //siempre y cuando no supere la capacidad máxima de la misma.
    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;

        public delegate void delegadoEventoPrecio(object sender, EventArgs e);
        public event delegadoEventoPrecio EventoPrecio;
        


        public List<T> Elementos {
            get { return this.elementos; }
        }

        public double PrecioTotal
        {
            get { return this.CalcularPrecioTotal(); }
        }

        private double CalcularPrecioTotal()
        {
            double pTotal = 0;

            foreach (T item in this.elementos)
            {
                pTotal += item.precio;
            }

            return pTotal;
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(typeof(T).Name);
            sb.AppendLine($"\nCapacidad: {this.capacidad}");
            sb.AppendLine($"Cantidad actual: {this.elementos.Count}");
            sb.AppendLine($"Precio Total: {this.PrecioTotal.ToString()}\n");

            foreach (T item in this.elementos)
            {
                sb.AppendFormat(item.ToString());
                sb.AppendLine($"\n<--------------->\n");
            }

            return sb.ToString();

        }

        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera, T item)
        {
            if(cartuchera.capacidad > cartuchera.elementos.Count)
            {
                cartuchera.elementos.Add(item);
            }
            else
            {
                throw new CartucheraLlenaException();
            }

            if(cartuchera.PrecioTotal > 85 && cartuchera.EventoPrecio != null)
            {
                cartuchera.EventoPrecio.Invoke(cartuchera, EventArgs.Empty);
            }

            return cartuchera;
        }
    }
}
