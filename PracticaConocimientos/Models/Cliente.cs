using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConocimientos.Models
{
    internal class Cliente
    {
        private string id;
        private string nombre;
        private string apellido;
        private int telefono;
        private string tarjeta;

        public string Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public int Telefono { get { return telefono; } set { telefono = value; } }
        public string Tarjeta { get { return tarjeta; } set { tarjeta = value; } }
        public string NombreCompleto { get { return nombre + " " + apellido; } }

        public override string ToString() { return NombreCompleto; }
    }
}
