using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camiseta : Prenda
    {

        public bool mangaLarga;

        public bool MangaLarga
        {
            get { return this.mangaLarga; }
            set { this.mangaLarga = value; }
        }

        #region Constructores

        public Camiseta()
        {

        }

        public Camiseta(ETalle talle, EEquipacion equipacion, int idStock, int numero, bool mangaLarga) : base(idStock, talle, equipacion, numero)
        {
            this.mangaLarga = mangaLarga;
        }

        #endregion

        public override string ToString()
        {
            if (mangaLarga)
            {
                return $"{idStock}       {talle}        {equipacion}       {numero}       Manga larga";
            }
            else
            {
                return $"{idStock}       {talle}         {equipacion}       {numero}       Manga corta";
            }
        }
    }
}
