using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase generica
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stock<T> where T : Prenda
    {
        public List<T> prendas;

        #region Constructor

        public Stock()
        {
            prendas = new List<T>();
        }

        #endregion

        #region Propiedades

        public List<T> Prendas
        {
            get { return this.prendas; }
            set { this.prendas = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Busca una prenda a traves del id pasado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prenda"></param>
        /// <returns> Devuelve true si encuentra la prenda y false si no </returns>
        public bool buscarPrenda(int id, out T prenda)
        {
            bool retorno = false;
            prenda = default;

            foreach (T p in this.prendas)
            {
                if (p.IdStock == id)
                {
                    prenda = p;
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Agrega una camiseta a la lista con los datos pasados por parametros
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="talle"></param>
        /// <param name="equipacion"></param>
        /// <param name="manga"></param>
        /// <returns> Camiseta con los datos cargados</returns>
        public Camiseta AgregarCamiseta(string numero, Prenda.ETalle talle, Prenda.EEquipacion equipacion, string manga)
        {
            int auxNum;
            int auxManga = 0;
            Camiseta camiseta;

            if (!int.TryParse(numero, out auxNum) || auxNum > 99)
                auxNum = 10;

            if (manga == "Manga larga")
            {
                auxManga = 1;
            }

            //Se le pone un id auxiliar a la lista, que luego sera remplazado por el que asigne la base de datos
            if (auxManga == 1)
                camiseta = new Camiseta(talle, equipacion, 10000, auxNum, true);
            else
                camiseta = new Camiseta(talle, equipacion, 10000, auxNum, false);

            return camiseta;
        }

        /// <summary>
        /// Agrega un pantalon a la lista con los datos pasados por parametros
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="talle"></param>
        /// <param name="equipacion"></param>
        /// <param name="bolsillo"></param>
        /// <returns></returns>
        public Pantalon AgregarPantalon(string numero, Prenda.ETalle talle, Prenda.EEquipacion equipacion, string bolsillo)
        {
            int auxNum;
            int auxBolsillo = 0;
            Pantalon pantalon;

            if (!int.TryParse(numero, out auxNum) || auxNum > 99)
                auxNum = 10;

            if (bolsillo == "Con bolsillo")
            {
                auxBolsillo = 1;
            }

            if (auxBolsillo == 1)
                pantalon = new Pantalon(talle, equipacion, 10000, auxNum, true);
            else
                pantalon = new Pantalon(talle, equipacion, 10000, auxNum, false);

            return pantalon;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id    Talle    Equipacion   Numero    Manga/Bolsillo");

            foreach (T item in this.prendas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }


        #endregion
    }
}
