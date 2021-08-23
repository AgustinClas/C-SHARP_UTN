using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    //Goma-> soloLapiz:bool(público); PreciosCuidados->true; 
    //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
    public class Goma : Utiles
    {
        public bool soloLapiz;

        public Goma(bool soloLapiz, string marca, double precio) : base(marca, precio)
        {
            this.soloLapiz = soloLapiz;
        }

        protected override bool PreciosCuidados
        {
            get { return true; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Goma");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendLine($"\nSolo lapiz: {this.soloLapiz}");
            sb.AppendLine("Precios cuidados: si\n");

            return sb.ToString();
        }
    }
}

