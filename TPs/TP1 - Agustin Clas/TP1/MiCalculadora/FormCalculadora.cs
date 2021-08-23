using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.AddRange(new string[] { "+", "-", "*", "/" });
            
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = "" + resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Borra los textos cargados en la calculadora para poder hacer una operacion nueva
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();  
            lblResultado.Text = num.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            lblResultado.Text = num.BinarioDecimal(lblResultado.Text);

        }

        /// <summary>
        /// Instancia dos Numeros con los strings pasados por parametro y
        /// llama a Calculadora.Operar para realizar la operacion
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            StringBuilder sb = new StringBuilder();

            if (operador != "" && operador != null)
                sb.AppendFormat(operador);
            else
                sb.Append("+");

            double resultado = Calculadora.Operar(num1, num2, sb[0]);

            return resultado;
        }

        /// <summary>
        /// Pide al usuario confirmacion para cerrar la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closing = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (closing == DialogResult.Yes)
            {
                e.Cancel = false;
                MessageBox.Show("Hasta la proxima!");
            }
            else
                e.Cancel = true;
        }
    }
}
