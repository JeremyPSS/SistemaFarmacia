using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class ClienteCE
    {
        private int idCliente;
        private string nombre;
        private string apellido;
        private string correo;
        private string cedula;

        public ClienteCE()
        {
        }

        public ClienteCE(int idCliente, string nombre, string apellido, string correo, string cedula)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.cedula = cedula;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }
}
