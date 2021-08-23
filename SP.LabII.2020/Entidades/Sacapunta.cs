using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    //Sacapunta-> deMetal:bool(público); 
    //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public Sacapunta(bool deMetal, double precio, string marca) : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        protected override bool PreciosCuidados
        {
            get { return false; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Sacapuntas");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendLine($"\nDe metal: {this.deMetal}");
            sb.AppendLine("Precios cuidados: no\n");

            return sb.ToString();
        }
    }
}
