using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Inventario
{
    public class MedicamentoCE
    {
        private int idMedicamento;
        private string nombre;
        private string enpaque;
        private int cantidad;
        private string presentacion;
        private DateTime fechaVencimiento;
        private string viaAdministracion;
        private string almacenamiento;
        private string especificacion;
        private double precio;
        private int idPromocion;

        public MedicamentoCE()
        {
        }

        public MedicamentoCE(int idMedicamento, string nombre, string enpaque, int cantidad, string presentacion, DateTime fechaVencimiento, string viaAdministracion, string almacenamiento, string especificacion, double precio, int idPromocion)
        {
            this.idMedicamento = idMedicamento;
            this.nombre = nombre;
            this.enpaque = enpaque;
            this.cantidad = cantidad;
            this.presentacion = presentacion;
            this.fechaVencimiento = fechaVencimiento;
            this.viaAdministracion = viaAdministracion;
            this.almacenamiento = almacenamiento;
            this.especificacion = especificacion;
            this.precio = precio;
            this.idPromocion = idPromocion;
        }

        public int IdMedicamento { get => idMedicamento; set => idMedicamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Enpaque { get => enpaque; set => enpaque = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Presentacion { get => presentacion; set => presentacion = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string ViaAdministracion { get => viaAdministracion; set => viaAdministracion = value; }
        public string Almacenamiento { get => almacenamiento; set => almacenamiento = value; }
        public string Especificacion { get => especificacion; set => especificacion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int IdPromocion { get => idPromocion; set => idPromocion = value; }
    }
}
