using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace SQL
{
    public static class SQL
    {

        /// <summary>
        /// carga las listas de camisetas y pantalones desde
        /// una tabla de sql
        /// </summary>
        /// <param name="pantalones">lista de pantalones</param>
        /// <param name="camisetas">lista de camisetas</param>
        public static void CargarDatos(out List<Pantalon> pantalones, out List<Camiseta> camisetas)
        {
            camisetas = new List<Camiseta>();
            pantalones = new List<Pantalon>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT * FROM StockSport", conexion);
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        int talle = (int)reader["Talle"];
                        int equipacion = (int)reader["Equipacion"];
                        int numero = (int)reader["Numero"];
                        int mangaBolsillo = (int)(reader)["MangaOBolsillo"];
                        int esCamiseta = (int)(reader)["EsCamiseta"];

                        //el campo esCamiseta funciona como "bandera" para indicar en que lista tiene que ser añadida
                        if (esCamiseta == 1)
                        {
                            if (mangaBolsillo == 1)
                            {
                                Camiseta prenda = new Camiseta((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, true);
                                camisetas.Add(prenda);
                            }
                            else
                            {
                                Camiseta prenda = new Camiseta((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, false);
                                camisetas.Add(prenda);
                            }
                        }
                        else
                        {
                            if (mangaBolsillo == 1)
                            {
                                Pantalon prenda = new Pantalon((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, true);
                                pantalones.Add(prenda);
                            }
                            else
                            {
                                Pantalon prenda = new Pantalon((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, false);
                                pantalones.Add(prenda);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                camisetas = default;
                pantalones = default;
            }

        }

        /// <summary>
        /// Borra la prenda que contiene el id pasado por parametro
        /// </summary>
        /// <param name="id"></param>
        public static void BorrarPrenda(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    string comandoStr = "DELETE FROM StockSport WHERE Id = @id";

                    SqlCommand comando = new SqlCommand(comandoStr, conexion);
                    comando.Parameters.AddWithValue("id", id);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }


        /// <summary>
        /// Agrega la camiseta pasada por parametro a la base de datos
        /// </summary>
        /// <param name="camiseta"></param>
        /// <returns>True si pudo agregar el pantalon, false si no</returns>
        public static bool AgregarCamiseta(Camiseta camiseta)
        {
            bool retorno;
            //try
            //{
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    //No se le pasa el id porque se le asigna automaticamente
                    string comandoStr = "INSERT INTO StockSport(Talle, Equipacion, Numero, MangaOBolsillo, EsCamiseta) VALUES(@talle, @equipacion, @numero, @mangaOBolsillo, @esCamiseta)";

                    SqlCommand comando = new SqlCommand(comandoStr, conexion);
                    comando.Parameters.AddWithValue("talle", camiseta.Talle);
                    comando.Parameters.AddWithValue("equipacion", camiseta.Equipacion);
                    comando.Parameters.AddWithValue("numero", camiseta.Numero);

                    if (camiseta.mangaLarga)
                        comando.Parameters.AddWithValue("mangaOBolsillo", 1);
                    else
                        comando.Parameters.AddWithValue("mangaOBolsillo", 0);

                    comando.Parameters.AddWithValue("esCamiseta", 1);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                retorno = true;
            //}
            /*catch (Exception e)
            {
                retorno = false;
            }*/

            return retorno;
        }

        /// <summary>
        /// Agrega el pantalon pasado por parametro a la base de datos
        /// </summary>
        /// <param name="pantalon"></param>
        /// <returns>True si pudo agregar el pantalon, false si no</returns>
        public static bool AgregarPantalon(Pantalon pantalon)
        {
            bool retorno;
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    string comandoStr = "INSERT INTO StockSport(Talle, Equipacion, Numero, MangaOBolsillo, EsCamiseta) VALUES(@talle, @equipacion, @numero, @mangaOBolsillo, @esCamiseta)";

                    SqlCommand comando = new SqlCommand(comandoStr, conexion);
                    comando.Parameters.AddWithValue("talle", pantalon.Talle);
                    comando.Parameters.AddWithValue("equipacion", pantalon.Equipacion);
                    comando.Parameters.AddWithValue("numero", pantalon.Numero);

                    if (pantalon.conBolsillo == true)
                        comando.Parameters.AddWithValue("mangaOBolsillo", 1);
                    else
                        comando.Parameters.AddWithValue("mangaOBolsillo", 0);

                    comando.Parameters.AddWithValue("esCamiseta", 0);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
