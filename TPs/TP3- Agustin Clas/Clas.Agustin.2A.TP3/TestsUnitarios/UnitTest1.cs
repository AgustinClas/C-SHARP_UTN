using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNull()
        {
            Alumno alumno = new Alumno(10, "Carlos", "Rodriguez", "43000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Profesor profesor = new Profesor(10, "Carlos", "Rodriguez", "45000000", Persona.ENacionalidad.Argentino);

            Jornada jornada = new Jornada(Universidad.EClases.Programacion, profesor);

            jornada = jornada + alumno;

            Assert.IsNotNull(jornada.Alumnos);

        }

        [TestMethod]
        public void TestNacionalidadInvalidadException()
        {
            string dni = "99000000";

            try
            {
                Alumno alumno = new Alumno(10, "Carlos", "Rodriguez", dni, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestDniInvalidoException()
        {
            string dni = "abc";

            try
            {
                Profesor profesor = new Profesor(10, "Carlos", "Rodriguez", dni, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.DniInvalidoException));
            }
        }

    }
}
