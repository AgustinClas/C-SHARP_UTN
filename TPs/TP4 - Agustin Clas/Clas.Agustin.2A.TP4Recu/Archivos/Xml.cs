using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Clase generica
    /// Uso de archivos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los archivos pasados por parametros en formato xml
        /// </summary>
        /// <param name="archivo">Path del arhivo donde se guaradara</param>
        /// <param name="datos"></param>
        /// <returns>True si pudo serializar, false si no</returns>
        public bool Guardar(string archivo, T datos)
        {

            bool retorno = true;
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, datos);
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }

    }
}
