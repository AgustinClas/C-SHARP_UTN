using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;


        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Constructores
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("JORNADA:\n");

            if(((object)this.Instructor) != null)
                sb.AppendFormat("Clase de {0} por {1}", this.clase, this.Instructor.ToString());

            sb.AppendLine("ALUMNOS: ");

            if (this.alumnos.Count > 0)
            {
                foreach (Alumno a in this.alumnos)
                {
                    sb.AppendLine(a.ToString());
                }
            }
            else
            {
                sb.AppendLine("No hay alumnos en esta clase\n");
            }

            sb.AppendLine("<------------------------------------------------>"); 

            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();

            return t.Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto t = new Texto();
            string retorno;

            t.Leer("Jornada.txt", out retorno);

            return retorno;
        }

        #endregion

        #region Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno b in j.alumnos)
            {
                if (b == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                Console.WriteLine("Este alumno ya se encuentra en la clase\n");
            }

            return j;
        }

        #endregion
    }
}
