using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;


        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }


        /// <summary>
        /// metodo estatico que muestra los datos de la universidad pasada por parametro
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Jornada j in uni.jornada)
            {
                sb.AppendLine(j.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Guarda en formato xml los datos de la universidad pasada por parametros
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlUni = new Xml<Universidad>();

            return xmlUni.Guardar("Universidad.xml", uni);
        }


        /// <summary>
        ///serializa los datos de una universidad desde un archivo xml y los devuelve
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad u = new Universidad();

            Xml<Universidad> xmlUni = new Xml<Universidad>();

            xmlUni.Leer("Universidad.xml", out u);

            return u;
        }

        #region Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno b in g.alumnos)
            {
                if (b == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor p)
        {
            bool retorno = false;

            foreach (Profesor b in g.profesores)
            {
                if (b == p)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }


        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor profesosAux = null;
            foreach (Profesor p in g.profesores)
            {
                if (p == clase)
                {
                    profesosAux = p;
                    break;
                }
            }

            if(profesosAux != null)
            {
                return profesosAux;
            }
            else
            {
                throw new SinProfesorException();
            }
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor profesosAux = null;
            foreach (Profesor p in g.profesores)
            {
                if (p != clase)
                {
                    profesosAux = p;
                    break;
                }
            }

            if (profesosAux != null)
            {
                return profesosAux;
            }
            else
            {
                throw new SinProfesorException();
            }
        }


        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
            {
                u.profesores.Add(p);
            }
            else
            {
                Console.WriteLine("Este profesor ya se encuentra dando clases en la universidad\n");
            }

            return u;
        }

        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            Profesor profesorAux = null;

            foreach(Profesor p in u.profesores)
            {
                if(p == clase)
                {
                    profesorAux = p;
                    break;
                }
            }

            if (profesorAux != null)
            {
                Jornada jornada = new Jornada(clase, profesorAux);

                foreach (Alumno a in u.alumnos)
                {
                    if (a == clase)
                    {
                        jornada = jornada + a;
                    }
                }

                u.jornada.Add(jornada);
            }

            return u;
        }

        #endregion
    }
}
