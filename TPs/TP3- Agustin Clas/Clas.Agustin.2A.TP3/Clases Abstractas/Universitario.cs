using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona 
    {
        private int legajo;

        #region Constructores
        public Universitario() : base()
        {
            this.legajo = default;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.ToString());

            sb.AppendLine($"\nLEGAJO NUMERO: {this.legajo}");

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                return this == (Universitario)obj;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (((object)pg1) != null && ((object)pg2) != null)
            {
                if (pg1.GetType() == pg2.GetType() && pg1.legajo == pg2.legajo)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {

            return !(pg1 == pg2);
        }
        #endregion

    }
}
