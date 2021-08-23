using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;
using System.Net.Mime;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
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
                throw new ArchivosException(e);
            }

            return retorno;
        }
    

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = true;
            try
            {
                using(XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));

                    datos = (T)serializer.Deserialize(reader);
                }
            }
            catch(Exception e)
            {
                datos = default;
                retorno = false;
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
