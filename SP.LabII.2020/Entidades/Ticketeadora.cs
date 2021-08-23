using System;
using System.Collections.Generic;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class Ticketeadora<T> where T : Utiles
    {
        public static bool ImprimirTicket(Cartuchera<T> c1)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Tickets.log";

            try
            {
                if (File.Exists(ruta))
                {
                    using(StreamWriter sw = new StreamWriter(ruta, true))
                    {
                        sw.WriteLine("Fecha: {0}", DateTime.Now);
                        sw.WriteLine("Total cartuchera {0}\n", c1.PrecioTotal);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(ruta, false))
                    {
                        sw.WriteLine("Fecha: {0}", DateTime.Now);
                        sw.WriteLine("Total cartuchera {0}\n", c1.PrecioTotal);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }


        }
    }
}
