using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Alumno : EntidadesAbstractas.Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        public Alumno() : base()
        {
            estadoCuenta = default;
            claseQueToma = default;
        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.estadoCuenta = default;
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.estadoCuenta = estadoCuenta;
            this.claseQueToma = claseQueToma;
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());

            sb.AppendLine($"\nESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine($"TOMA CLASES DE {this.claseQueToma}");

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
