using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace Entidades
{
    //Lapiz-> color:ConsoleColor(público); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; público); PreciosCuidados->true; 
    //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {

        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz() { }

        public ConsoleColor Color { set { this.color = value; } }

        public ETipoTrazo Trazo { set { this.trazo = value; } }



        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio) : base(marca, precio) 
        {
            this.color = color;
            this.trazo = trazo;
        }

        protected override bool PreciosCuidados
        {
            get { return true; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Lapiz");
            sb.AppendFormat(base.UtilesToString());
            sb.AppendLine($"\nColor: {this.color}");
            sb.AppendLine($"\nTrazo: {this.trazo}");
            sb.AppendLine("Precios cuidados: si\n");

            return sb.ToString();
        }

        public bool Xml()
        {
            string archivo = this.Path;

            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));

                serializer.Serialize(writer, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string Path { get { return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString() + "\\Clas.Agustin.Lapiz.Xml"; } }

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool retorno = true;
            string archivo = this.Path;

            //try
            //{
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Lapiz));

                    lapiz = (Lapiz)serializer.Deserialize(reader);
                }
            //}
            /*catch (Exception e)
            {
                lapiz = null;
                retorno = false;
            }*/

            return retorno;
        }
    }
}
