using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaConocimientos
{
    public partial class NumerosPrimos : Form
    {
        public NumerosPrimos()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int parametro = Int32.Parse(txtCantidad.Text);
            int numero = 2;
            int contador = 0;
            string resultado = "";
            
            while(contador < parametro)
            {
                if (esPrimo(numero))
                {
                    resultado += numero + ", ";
                    contador++;
                }
                numero++;
            }

            lblResultado.Text = "Los primeros "+parametro+ " números primos son: "+resultado;
            MessageBox.Show("Los primeros " + parametro + " números primos son: " + resultado);
        }

        private bool esPrimo(int numero)
        {
            bool flags = true;

            for(int i=2; i < numero; i++)
            {
                if(numero % i == 0)
                {
                    flags = false;
                }
            }
            return flags;
        }

    }
}
