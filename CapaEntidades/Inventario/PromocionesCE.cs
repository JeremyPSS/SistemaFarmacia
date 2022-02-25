using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class PromocionesCE
    {
        private int idPromocion;
        private string tipo;
        private double porcentaje;

        public PromocionesCE()
        {
        }

        public PromocionesCE(int idPromocion, string tipo, double porcentaje)
        {
            this.idPromocion = idPromocion;
            this.tipo = tipo;
            this.porcentaje = porcentaje;
        }

        public int IdPromocion { get => idPromocion; set => idPromocion = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public double Porcentaje { get => porcentaje; set => porcentaje = value; }
    }
}
