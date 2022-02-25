using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class AdministradorCE
    {
        private int idUsuario;
        private string contraseña;
        private string cedula;
        private string nombres;
        private string apellidos;
        private string telefono;
        private string email;
        private string tipo;
        private string estado;

        public AdministradorCE()
        {
        }

        public AdministradorCE(int idUsuario, string contraseña, string cedula, string nombres, string apellidos, string telefono, string email, string tipo, string estado)
        {
            this.idUsuario = idUsuario;
            this.contraseña = contraseña;
            this.cedula = cedula;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.email = email;
            this.tipo = tipo;
            this.estado = estado;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
