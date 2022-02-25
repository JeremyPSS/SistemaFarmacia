using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class Factura_DetalleCE
    {
        private int idFactura;
        private int idMedicamento;
        private int cantidad;
        private double subtotal;

        public Factura_DetalleCE()
        {
        }

        public Factura_DetalleCE(int idFactura, int idMedicamento, int cantidad, double subtotal)
        {
            this.idFactura = idFactura;
            this.idMedicamento = idMedicamento;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
        }

        public int IdFactura { get => idFactura; set => idFactura = value; }
        public int IdMedicamento { get => idMedicamento; set => idMedicamento = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
    }
}
