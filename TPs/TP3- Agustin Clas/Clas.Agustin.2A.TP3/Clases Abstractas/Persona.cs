using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value);}
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set {this.nombre = this.ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this.dni = this.ValidarDni(this.nacionalidad, value); }
            
        }
        #endregion

        #region Constructores

        public Persona()
        {
            this.apellido = default;
            this.dni = default;
            this.nacionalidad = default;
            this.nombre = default;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.dni = default;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el dni corresponda con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></nacionalidad de la persona
        /// <param name="dato"></ numero de dni
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if((nacionalidad == ENacionalidad.Argentino && dato > 0 && dato < 90000000) || 
                (nacionalidad == ENacionalidad.Extranjero && dato > 89999999 & dato < 100000000)){

                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;

            if (int.TryParse(dato, out aux))
            {
                return this.ValidarDni(nacionalidad, aux);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            bool esValido = Regex.IsMatch(dato, @"^[a-zA-Z]+$");

            if (esValido)
            {
                return dato;
            }
            else
            {
                return "";
            }
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}\n");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }
        #endregion


    }
}
