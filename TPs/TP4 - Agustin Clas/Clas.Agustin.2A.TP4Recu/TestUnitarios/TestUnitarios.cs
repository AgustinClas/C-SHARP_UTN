using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using FormPrincipal;
using Entidades;
using MetodoDeExtension;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Testea si la excepcion ContraseñaIncorrectaException funciona adecuadamente
        /// </summary>
        [TestMethod]
        public void TestContraseñaIncorrecta()
        {
            string contraseñaIncorrecta = "abcd";
            
            try
            {
                Form1 form = new Form1();

                contraseñaIncorrecta.ValidarContraseña();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.ContraseñaIncorrectaException));
            }
        }

        /// <summary>
        /// Testea si la excepcion FueraDeStockException funciona adecuadamente
        /// </summary>
        [TestMethod]
        public void TestFueraDeStockException()
        {
            int id = 4;
            Stock<Camiseta> stock = new Entidades.Stock<Camiseta>();

            Camiseta cam1 = new Camiseta(Prenda.ETalle.XL, Prenda.EEquipacion.suplente, 1, 10, true);
            Camiseta cam2 = new Camiseta(Prenda.ETalle.S, Prenda.EEquipacion.titular, 2, 5, true);
            Camiseta cam3 = new Camiseta(Prenda.ETalle.M, Prenda.EEquipacion.suplente, 3, 12, false);

            stock.prendas.Add(cam1);
            stock.prendas.Add(cam2);
            stock.prendas.Add(cam3);

            try
            {
                stock.buscarPrenda(4, out cam1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(Excepciones.FueraDeStockException));
            }
        }
    }
}
