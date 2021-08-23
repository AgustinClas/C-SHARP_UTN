using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalon : Prenda
    {
        public bool conBolsillo;

        public bool ConBolsillo
        {
            get { return this.conBolsillo; }
            set { this.conBolsillo = value; }
        }

        #region Constructores

        public Pantalon()
        {

        }

        public Pantalon(ETalle talle, EEquipacion equipacion, int idStock, int numero, bool conBolsillo) : base(idStock, talle, equipacion, numero)
        {
            this.conBolsillo = conBolsillo;
        }

        #endregion

        
        public override string ToString()
        {
            if (conBolsillo)
            {
                return $"{idStock}       {talle}        {equipacion}         {numero}       Con bolsillo";
            }
            else
            {
                return $"{idStock}       {talle}          {equipacion}        {numero}       Sin bolsillo";
            }
        }


    }
}
