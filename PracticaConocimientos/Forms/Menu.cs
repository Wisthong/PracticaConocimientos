using PracticaConocimientos.Forms;

namespace PracticaConocimientos
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Promedio promedio = new Promedio();
            promedio.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumerosPrimos numerosPrimos = new NumerosPrimos();
            numerosPrimos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crud crud = new Crud();
            crud.ShowDialog();
        }
    }
}