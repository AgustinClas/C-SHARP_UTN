using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                File.WriteAllLines(archivo, new string[] { datos });
            }
            catch(Exception e)
            {
                return false;
                throw new ArchivosException(e);
            }

            return true;
        }

        public bool Leer(string archivo, out string datos)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                string[] arrayString = File.ReadAllLines(archivo);

                foreach(string s in arrayString)
                {
                    sb.AppendLine(s);
                }

                datos = sb.ToString();
            }
            catch (Exception e)
            {
                datos = "";
                return false;
                throw new ArchivosException(e);
            }

            return true;
        }
    }
}
