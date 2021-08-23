using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using SQL;
using Archivos;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Camiseta cam1 = new Camiseta(Prenda.ETalle.XL, Prenda.EEquipacion.suplente, 1, 10, true);
            Camiseta cam2 = new Camiseta(Prenda.ETalle.S, Prenda.EEquipacion.titular, 2, 5, true);

            Pantalon pant1 = new Pantalon(Prenda.ETalle.S, Prenda.EEquipacion.suplente, 3, 8, true);
            Pantalon pant2 = new Pantalon(Prenda.ETalle.M, Prenda.EEquipacion.titular, 4, 7, false);

            Stock<Camiseta> stockCa = new Stock<Camiseta>();
            stockCa.prendas.Add(cam1);
            stockCa.prendas.Add(cam2);

            Stock<Pantalon> stockPant = new Stock<Pantalon>();
            stockPant.prendas.Add(pant1);
            stockPant.prendas.Add(pant2);

            Console.WriteLine(stockCa.ToString());
            Console.WriteLine(stockPant.ToString());
            Console.ReadKey();

            Xml<Stock<Camiseta>> serializador = new Xml<Stock<Camiseta>>();
            string archivoCamisetas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Camisetas";

            serializador.Guardar(archivoCamisetas, stockCa);

            SQL.SQL.CargarDatos(out stockPant.prendas, out stockCa.prendas);

            Console.WriteLine(stockCa.ToString());
            Console.WriteLine(stockPant.ToString());
            Console.ReadKey();


        }


    }
}