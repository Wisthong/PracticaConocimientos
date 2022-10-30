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
    public partial class Promedio : Form
    {
        public Promedio()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double nota1 = Double.Parse(txtNota1.Text);
            double nota2 = Double.Parse(txtNota2.Text);
            double nota3 = Double.Parse(txtNota3.Text);

            double resultado = 0;

            if(nota1 > 0 && nota2 > 0 && nota3 > 0 )
            {
                resultado += (nota1 * 0.30) + (nota2 * 0.30) + (nota3 * 0.40);
                lblResultado.Text = resultado.ToString();
                MessageBox.Show("La nota del usuario promediada es: " + resultado);
            }
            else
            {
                    
            }
                
        }
    }
}
