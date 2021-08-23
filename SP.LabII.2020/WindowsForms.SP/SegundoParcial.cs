﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;
using System.IO;

//Agregar usings necesarios

namespace WindowsForms.SP
{
    //Agregar manejo de excepciones en TODOS los lugares críticos!!!
    public partial class SegundoParcial : Form
    {
        private Lapiz lapiz;
        private Goma goma;
        private Sacapunta sacapunta;

        private Cartuchera<Utiles> c_utiles;
        private Cartuchera<Lapiz> c_lapices;
        private Cartuchera<Goma> c_gomas;

        private SqlConnection cn = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database=sp_lab_II_utiles;Trusted_Connection=True;");
        private SqlDataAdapter da;
        private DataTable dt;

        public SegundoParcial()
        {
            InitializeComponent();

            this.dt = new DataTable("utiles");


            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Cambiar por su apellido y nombre
        private void SegundoParcial_Load(object sender, EventArgs e)
        {
            MessageBox.Show("CLAS AGUSTIN");
            this.Text = "Clas Agustin";
        }

        //Crear, en un class library, la siguiente jerarquía de clases:
        //Utiles-> marca:string y precio:double (públicos); PreciosCuidados:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
        //ToString():string (polimorfismo; reutilizar código)
        //Lapiz-> color:ConsoleColor(público); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; público); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        //Goma-> soloLapiz:bool(público); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        //Sacapunta-> deMetal:bool(público); 
        //Reutilizar UtilesToString en ToString() (mostrar TODOS los valores).
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            //Crear una instancia de cada clase e inicializar los atributos del form lapiz, goma y sacapunta. 
            this.lapiz = new Lapiz(ConsoleColor.Green, ETipoTrazo.Grueso, "Sylvapen", 25.50);
            this.goma = new Goma(true, "Pelican", 30);
            this.sacapunta = new Sacapunta(true, 55.90, "Afiladitos");

            MessageBox.Show(this.lapiz.ToString());
            MessageBox.Show(this.goma.ToString());
            MessageBox.Show(this.sacapunta.ToString());
        }

        //Crear, en class library, la clase Cartuchera<T> -> restringir para que sólo lo pueda usar Utiles 
        //o clases que deriven de Utiles.
        //atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
        //Propiedades:
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
        //Constructor
        //Cartuchera(), Cartuchera(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        //Métodos:
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        //Sobrecarga de operadores:
        //(+) Será el encargado de agregar elementos a la cartuchera, 
        //siempre y cuando no supere la capacidad máxima de la misma.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_lapices = new Cartuchera<Lapiz>(3);
            this.c_gomas = new Cartuchera<Goma>(3);
            this.c_utiles = new Cartuchera<Utiles>(2);

            this.c_lapices += new Lapiz(ConsoleColor.Red, ETipoTrazo.Medio, "Faber-Castell", 32.25);
            this.c_lapices += new Lapiz(ConsoleColor.Blue, ETipoTrazo.Fino, "Paper Mate", 30);
            this.c_lapices += this.lapiz;

            this.c_gomas += this.goma;
            this.c_gomas += new Goma(false, "Dos banderas", 25);

            this.c_utiles += this.lapiz;
            this.c_utiles += this.goma;

            MessageBox.Show(this.c_lapices.ToString());
            MessageBox.Show(this.c_gomas.ToString());
            MessageBox.Show(this.c_utiles.ToString());
        }

        //Agregar un elemento a la cartuchera de útiles, al superar la cantidad máxima, 
        //lanzará un CartucheraLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            try
            {
                this.c_utiles += this.lapiz;
            }
            catch (CartucheraLlenaException ex)
            {
                //Agregar, para la clase CartucheraLlenaException, un método de extensión (InformarNovedad():string)
                //que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }
        }

        //Si el precio total de la cartuchera supera los 85 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cartuchera. 
        //Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        //Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total de la cartuchera (en un nuevo renglón). 
        //Se deben acumular los mensajes. 
        //El archivo se guardará con el nombre 'tickets.log' en la carpeta 'Mis documentos' del cliente.
        //El manejador de eventos (c_gomas_EventoPrecio) invocará al método (de clase) 
        //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano 
        //indicando si se pudo escribir o no.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos (c_gomas_EventoPrecio) aquí  
            this.c_gomas.EventoPrecio += c_gomas_EventoPrecio;
            this.c_gomas += new Goma(false, "Faber-Castell", 31);
        }

        private void c_gomas_EventoPrecio(object sender, EventArgs e)
        {
            bool todoOK = Ticketeadora<Goma>.ImprimirTicket(c_gomas);//Reemplazar por la llamada al método de clase ImprimirTicket

            if (todoOK)
            {
                MessageBox.Show("Ticket impreso correctamente!!!");
            }
            else
            {
                MessageBox.Show("No se pudo imprimir el ticket!!!");
            }
        }


        //Configurar el OpenFileDialog, para poder seleccionar el log de tickets
        private void btnVerLog_Click(object sender, EventArgs e)
        {
            //titulo -> 'Abrir archivo de tickets'
            //directorio por defecto -> Mis documentos
            //tipo de archivo (filtro) -> .log
            //extensión por defecto -> .log
            //nombre de archivo (defecto) -> tickets

            DialogResult rta = openFileDialog1.ShowDialog();//Reemplazar por la llamada al método correspondiente del OpenFileDialog

            if (rta == DialogResult.OK)
            {
                string ruta = openFileDialog1.FileName;

                StreamReader sr = new StreamReader(ruta);
                string Lector = sr.ReadToEnd();

                sr.Close();

                this.txtVisorTickets.Text = Lector;

            }
        }

        //Crear las interfaces (en class library): 
        //#.-ISerializa -> Xml() : bool
        //              -> Path{ get; } : string
        //#.-IDeserializa -> Xml(out Lapiz) : bool
        //Implementar (implícitamente) ISerializa lápiz
        //Implementar (explícitamente) IDeserializa en lápiz
        //El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con su apellido.nombre.lapiz.xml
        //Ejemplo: Alumno Juan Pérez -> perez.juan.lapiz.xml
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Lapiz aux = null;

            if (this.lapiz.Xml())
            {
                MessageBox.Show("Lápiz serializado OK");
            }
            else
            {
                MessageBox.Show("Lápiz NO serializado");
            }

            if (((IDeserializa)this.lapiz).Xml(out aux))
            {
                MessageBox.Show("Lápiz deserializado OK");
                MessageBox.Show(aux.ToString());
            }
            else
            {
                MessageBox.Show("Lápiz NO deserializado");
            }
        }

        //Obtener de la base de datos (sp_lab_II_utiles) el listado de útiles:
        //Tabla - utiles { id(autoincremental - numérico) - marca(cadena) - precio(numérico) - tipo(cadena) }.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            this.ConfiguarDataTable();
            this.ConfigurarDataAdapter();

            //Configurar el SqlDataAdapter (y su selectCommand)                        

            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
        }

        //Agregar en el dataTable los útiles del formulario (lapiz, goma y sacapunta).
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            //Configurar el insertCommand del SqlDataAdapter y sus parámetros
            foreach(Lapiz l in this.c_lapices.Elementos)
            {
                DataRow file = this.dt.NewRow();

                file["marca"] = l.marca;
                file["precio"] = l.precio;
                file["tipo"] = l.GetType().Name;

                dt.Rows.Add(file);
            }

            foreach (Goma g in this.c_gomas.Elementos)
            {
                DataRow file = this.dt.NewRow();

                file["marca"] = g.marca;
                file["precio"] = g.precio;
                file["tipo"] = g.GetType().Name;

                dt.Rows.Add(file);
            }

            foreach (Utiles u in this.c_utiles.Elementos)
            {
                DataRow file = this.dt.NewRow();

                file["marca"] = u.marca;
                file["precio"] = u.precio;
                file["tipo"] = u.GetType().Name;

                dt.Rows.Add(file);
            }

            //Agregar los utiles del formulario al dataTable (crear filas)
        }

        //Eliminar del dataTable el primer registro
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            DataRow fila = this.dt.Rows[0];
            fila.Delete();

        }

        //Modificar del dataTable el último registro, cambiarlo por: marca:barrilito; precio:72
        private void btnPunto9_Click(object sender, EventArgs e)
        {
            DataRow fila = this.dt.Rows[this.dt.Rows.Count - 1];
            fila["marca"] = "barrilito";
            fila["precio"] = 72;
        }

        //Sincronizar los cambios (sufridos en el dataTable) con la base de datos
        private void btnPunto10_Click(object sender, EventArgs e)
        {
            try
            {
                this.da.Update(this.dt);

                MessageBox.Show("Datos sincronizados!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha sincronizado!!!\n" + ex.Message);
            }
        }

        private void ConfiguarDataTable()
        {
            this.dt = new DataTable("Utiles");

            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("marca", typeof(string));
            this.dt.Columns.Add("precio", typeof(double));
            this.dt.Columns.Add("tipo", typeof(string));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;//obtener el último id insertado en la tabla
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        private bool ConfigurarDataAdapter()
        {

            bool rta = true;
            try
            {
                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id,marca,precio,tipo FROM utiles", this.cn);
                this.da.InsertCommand = new SqlCommand("INSERT utiles (marca,precio,tipo) VALUES (@marca,@precio,@tipo)", this.cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE utiles SET marca=@marca,precio=@precio,tipo=@tipo", this.cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM utiles WHERE id=@id", this.cn);

                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");

                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

    
    }
    
}
