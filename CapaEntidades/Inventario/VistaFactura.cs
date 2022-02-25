using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class VistaFactura
    {
        private int idMedicamento;
        private string nombre;
        private string tipo;
        private int cantidad;
        private double subtotal;

        public VistaFactura()
        {
        }

        public VistaFactura(int idMedicamento, string nombre, string tipo, int cantidad, double subtotal)
        {
            this.IdMedicamento = idMedicamento;
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Cantidad = cantidad;
            this.Subtotal = subtotal;
        }

        public int IdMedicamento { get => idMedicamento; set => idMedicamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
