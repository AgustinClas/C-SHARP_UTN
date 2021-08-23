using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPrincipal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region Propiedades
        public bool EsCamiseta
        {
            get
            {
                if ((string)this.prenda.SelectedItem == "Camiseta")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Numero { get { return numero.Text; } }

        public Entidades.Prenda.ETalle Talle { get { return (Entidades.Prenda.ETalle)talle.SelectedItem; } }

        public Entidades.Prenda.EEquipacion Equipacion { get { return (Entidades.Prenda.EEquipacion)equipacion.SelectedItem; } }

        public string Bolsillo { get { return bolsillo.Text; } }

        public string Manga { get { return manga.Text; } }

        #endregion

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
}
