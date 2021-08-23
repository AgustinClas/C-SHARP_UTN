using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Clases_Instanciables
{
    public class Profesor : EntidadesAbstractas.Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        static Profesor()
        {
            Profesor.random = new Random();
        }

        private Profesor() : base()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());

            sb.AppendLine($"{this.ParticiparEnClase()}");

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            if (this.clasesDelDia.Count < 0)
            {
                sb.AppendLine("CLASES DEL DIA:");
                foreach (Universidad.EClases clase in this.clasesDelDia)
                {
                    sb.AppendLine($"{clase}");
                }
            }

            return sb.ToString();
        }

        private void _randomClases()
        {
            int largoEnum = Enum.GetNames(typeof(Universidad.EClases)).Length - 1;
            int random = Profesor.random.Next(0, (largoEnum));

            this.clasesDelDia.Enqueue((Universidad.EClases)random);

            random = Profesor.random.Next(0, largoEnum);

            this.clasesDelDia.Enqueue((Universidad.EClases)random);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases claseAux in i.clasesDelDia)
            {
                if (claseAux == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
