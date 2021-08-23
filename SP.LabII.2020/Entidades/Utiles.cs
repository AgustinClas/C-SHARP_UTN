using System;
using System.Text;

namespace Entidades
{
    //Utiles-> marca:string y precio:double (públicos); PreciosCuidados:bool (prop. s/l, abstracta);
    //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
    //ToString():string (polimorfismo; reutilizar código)
    public abstract class Utiles
    {
        public string marca;
        public double precio;

        protected abstract bool PreciosCuidados
        {
            get;
        }

        public string Marca { set { this.marca = value; } }
        public double Precio { set { this.precio = value; } }

        protected Utiles() { }

        protected Utiles(string marca, double precio) 
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Marca: {this.marca}");
            sb.AppendLine($"Precio: {this.precio}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
