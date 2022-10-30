using PracticaConocimientos.Dao;
using PracticaConocimientos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaConocimientos.Forms
{
    public partial class Crud : Form
    {
        public Crud()
        {
            InitializeComponent();
        }

        private void Crud_Load(object sender, EventArgs e)
        {
            cargarLista();
        }

        private void cargarLista()
        {
            ClienteDao db = new ClienteDao();
            List<Cliente> listaClientesDB = db.obtenerListadoCliente();
            listBox1.Items.Clear();
            for (int i = 0; i < listaClientesDB.Count; i++)
            {
                Cliente cliente = listaClientesDB[i];
                listBox1.Items.Add(cliente);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Cliente cliente = (Cliente)listBox1.SelectedItem;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtTarjeta.Text = cliente.Tarjeta;
                txtTelefono.Text = cliente.Telefono.ToString();
                lblId.Text = cliente.Id;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ClienteDao db = new ClienteDao();
                Cliente cliente = (Cliente)listBox1.SelectedItem;
                db.eliminar(cliente);
                MessageBox.Show("Has eliminado al cliente");
                cargarLista();
            }
            else
            {
                MessageBox.Show("No has seleccionado nada" );
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string tarjeta = txtTarjeta.Text;
            int telefono = Int32.Parse(txtTelefono.Text);

            ClienteDao db = new ClienteDao();
            Cliente cliente = new Cliente();
            cliente.Tarjeta = tarjeta;
            cliente.Apellido = apellido;
            cliente.Nombre = nombre;
            cliente.Telefono = telefono;
            if (lblId.Text != "")
            {
                if (nombre != "" && apellido != "" && tarjeta != "" && telefono > 0)
                {
                    cliente.Id = lblId.Text;
                    db.actualizar(cliente);
                    MessageBox.Show("Se modifico el cliente de manera correcta");
                    limpiarCampos();
                    cargarLista();
                }
                else
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
            }
            else
            {
                if (nombre != "" && apellido != "" && tarjeta != "" && telefono > 0)
                {
                    db.guardar(cliente);
                    MessageBox.Show("Se agrego el cliente de manera correcta");
                    limpiarCampos();
                    cargarLista();
                }
                else
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
            }



        }

        private void limpiarCampos()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtTarjeta.Text = "";
            txtTelefono.Text = "";
            lblId.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
