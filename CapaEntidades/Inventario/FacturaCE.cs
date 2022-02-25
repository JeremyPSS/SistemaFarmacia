using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class FacturaCE
    {
        private int idFactura;
        private double total;
        private DateTime fechaFactura;
        private int idCliente;

        public FacturaCE()
        {
        }

        public FacturaCE(int idFactura, double total, DateTime fechaFactura, int idCliente)
        {
            this.idFactura = idFactura;
            this.total = total;
            this.fechaFactura = fechaFactura;
            this.idCliente = idCliente;
        }

        public int IdFactura { get => idFactura; set => idFactura = value; }
        public double Total { get => total; set => total = value; }
        public DateTime FechaFactura { get => fechaFactura; set => fechaFactura = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
    }
}
