using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Entidades;
using SQL;
using System.Collections.Generic;
using Excepciones;
using System.Threading;
using Archivos;
using MetodoDeExtension;

namespace FormPrincipal
{
    public partial class Form1 : Form
    {
        public Stock<Camiseta> stockCa;
        public Stock<Pantalon> stockPant;

        Thread hilo2;

        public delegate void DelegadoVenta();

        public event DelegadoVenta Venta;

        public Form1()
        {
            InitializeComponent();

            stockCa = new Stock<Camiseta>();
            stockPant = new Stock<Pantalon>();

            SQL.SQL.CargarDatos(out stockPant.prendas, out stockCa.prendas);
            this.dataGridPantalones.DataSource = stockPant.prendas;
            this.dataGridCamisetas.DataSource = stockCa.prendas;

            //Instanciamos e inicializamos el hilo secundario
            hilo2 = new Thread(PasarImagenes);
            hilo2.Start();

            //añadimos los metodos al evento Venta
            Venta += this.GenerarVenta;
            Venta += this.ActualizarGrillas;

        }

        
        private void PasarImagenes()
        {
            try
            {
                string str = Directory.GetCurrentDirectory() + @"\Imagenes\CamisetaTitular_.jpg";
                Bitmap imagen1 = new Bitmap(str);

                str = Directory.GetCurrentDirectory() + @"\Imagenes\PantalonTitular_.jpg";
                Bitmap imagen2 = new Bitmap(str);

                str = Directory.GetCurrentDirectory() + @"\Imagenes\CamisetaSuplente_.jpg";
                Bitmap imagen3 = new Bitmap(str);

                str = Directory.GetCurrentDirectory() + @"\Imagenes\PantalonSuplente_.jpg";
                Bitmap imagen4 = new Bitmap(str);

                //La condicion es true porque debe funcionar siempre que el hilo este en ejecucion
                while (true)
                {
                    this.pictureBox1.Image = imagen1;
                    Thread.Sleep(7000);
                    this.pictureBox1.Image = imagen2;
                    Thread.Sleep(7000);
                    this.pictureBox1.Image = imagen3;
                    Thread.Sleep(7000);
                    this.pictureBox1.Image = imagen4;
                    Thread.Sleep(7000);
                }
            }
            catch(ThreadAbortException e)
            {

            }
            catch(Exception e)
            {
                MessageBox.Show("Error al cargar las imagenes");
            }
        }

        #region Metodos Botones

        private void buttonComprar_Click(object sender, EventArgs e)
        {

            try
            {
                this.Venta.Invoke();
            }
            catch (FueraDeStockException f)
            {
                MessageBox.Show(f.Message);
            }

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarProducto();
            }
            catch (ContraseñaIncorrectaException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Xml<Stock<Camiseta>> serializadorCamisetas = new Xml<Stock<Camiseta>>();
            Xml<Stock<Pantalon>> serializadorPantalones = new Xml<Stock<Pantalon>>();

            string archivoCamisetas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Camisetas";
            string archivoPantalones = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pantalones";

            if (serializadorPantalones.Guardar(archivoPantalones, stockPant) && serializadorCamisetas.Guardar(archivoCamisetas, stockCa))
                MessageBox.Show("Back up realizado con exito");
            else
                MessageBox.Show("No se pudo realizar el Back up");

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Busca la prenda a traves del id pasado por parametro y la quita del stock en caso de existir
        /// </summary>
        /// <param name="id"></param>
        public void GenerarVenta()
        {

            Camiseta camiseta = new Camiseta();
            Pantalon pantalon = new Pantalon();
            int id;

            if (int.TryParse(this.textBox2.Text, out id))
            {
                if (stockCa.buscarPrenda(id, out camiseta))
                {
                    if (camiseta.mangaLarga)
                        MessageBox.Show("Usted compro una camiseta manga larga!");
                    else
                        MessageBox.Show("Usted compro una camiseta manga corta!");


                    stockCa.prendas.Remove(camiseta);
                    SQL.SQL.BorrarPrenda(id);
                    this.ActualizarGrillas();

                }
                else if (stockPant.buscarPrenda(id, out pantalon))
                {
                    if (pantalon.conBolsillo)
                        MessageBox.Show("Usted compro un pantalon con bolsillo!");
                    else
                        MessageBox.Show("Usted compro un pantalon sin bolsillo!");


                    SQL.SQL.BorrarPrenda(id);
                    stockPant.prendas.Remove(pantalon);
                    this.ActualizarGrillas();

                }
                else
                {
                    throw new FueraDeStockException();
                }
            }
        }

        /// <summary>
        /// Agrega un producto a la lista correspondiente y a la base de datos
        /// Tomando los datos del form2
        /// Requiere validacion de una contraseña
        /// </summary>
        private void AgregarProducto()
        {
            string contraseñaUsuario = this.textBox1.Text;
            if (contraseñaUsuario.ValidarContraseña())
            {
                Form2 form2 = new Form2();
                bool flag = false;
                Pantalon pantalon;
                Camiseta camiseta;


                if (form2.ShowDialog() == DialogResult.OK)
                {
                    if (form2.EsCamiseta)
                    {
                        camiseta = stockCa.AgregarCamiseta(form2.Numero, form2.Talle, form2.Equipacion, form2.Manga);
                        if (SQL.SQL.AgregarCamiseta(camiseta))
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        pantalon = stockPant.AgregarPantalon(form2.Numero, form2.Talle, form2.Equipacion, form2.Bolsillo);
                        if (SQL.SQL.AgregarPantalon(pantalon))
                        {
                            flag = true;
                        }

                    }

                    //si se agrego el producto a la base de datos:
                    if (flag)
                    {
                        //cargamos nuevamente las listas con el objeto añadido con su id correspondiente
                        SQL.SQL.CargarDatos(out stockPant.prendas, out stockCa.prendas);
                        this.ActualizarGrillas();
                        MessageBox.Show("Producto agregado con exito!");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el producto");
                    }
                }
            }
        }
        /// <summary>
        /// Actualiza las grillas con las listas actualizadas
        /// </summary>
        private void ActualizarGrillas()
        {
            this.dataGridCamisetas.DataSource = null;
            this.dataGridPantalones.DataSource = null;

            this.dataGridCamisetas.Rows.Clear();
            this.dataGridPantalones.Rows.Clear();

            this.dataGridPantalones.DataSource = stockPant.prendas;
            this.dataGridCamisetas.DataSource = stockCa.prendas;
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hilo2.Abort();
        }
    }
}
