using MySql.Data.MySqlClient;
using PracticaConocimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConocimientos.Dao
{
    internal class ClienteDao
    {
        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string database = "clientesdb";

            string cadenaConexion = "Database=" + database + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            MySqlConnection conexionDB = new MySqlConnection(cadenaConexion);
            conexionDB.Open();
            return conexionDB;
        }

        public List<Cliente> obtenerListadoCliente()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM cliente";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();

            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = lectura.GetString(0);
                cliente.Nombre = lectura.GetString(1);
                cliente.Apellido = lectura.GetString(2);
                cliente.Telefono = lectura.GetInt32(3);
                cliente.Tarjeta = lectura.GetString(4);
                lista.Add(cliente);

            }

            comando.Connection.Close();
            return lista;
        }

        public void guardar(Cliente cliente)
        {
            string consulta = "INSERT INTO `cliente` (`id`, `nombre`, `apellido`, `telefono`, `tarjeta_de_credito`) VALUES (NULL, '" + cliente.Nombre + "', '" + cliente.Apellido + "', '" + cliente.Telefono + "', '" + cliente.Tarjeta + "')";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
        }

        public void eliminar(Cliente cliente)
        {
            string consulta = "DELETE FROM `cliente` WHERE `cliente`.`id` = " + cliente.Id + "";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
        }

        public void actualizar(Cliente cliente)
        {
            string consulta = "UPDATE `cliente` SET `nombre` = '" + cliente.Nombre + "', `apellido` = '" + cliente.Apellido + "', `telefono` = '" + cliente.Telefono + "', `tarjeta_de_credito` = '" + cliente.Tarjeta + "' WHERE `cliente`.`id` = " + cliente.Id + "";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }
    }

}
