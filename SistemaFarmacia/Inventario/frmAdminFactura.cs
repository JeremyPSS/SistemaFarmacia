using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.Inventario;
using CapaLogica.Inventario;

namespace SistemaFarmacia.Inventario
{
    public partial class frmAdminFactura : Form
    {
        public frmAdminFactura()
        {
            InitializeComponent();
        }

        FacturaLN oplnf = new FacturaLN();
        Factura_DetalleLN oplnfd = new Factura_DetalleLN();
        ClienteLN oplnc = new ClienteLN();

        public void ListarFacturaDetalleFiltro(int IdFactura)
        {
            dataGridView1.DataSource = oplnfd.ViewFacturaDetalleFiltro(IdFactura);
        }

        public void SetDatos(FacturaCE og)
        {
            textBox1.Text = og.IdFactura.ToString();
            label8.Text = og.IdCliente.ToString();
            dateTimePicker1.Value = og.FechaFactura;
            label9.Text = og.Total.ToString();

            SetC(og);
        }

        public void SetC(FacturaCE og)
        {
            ClienteCE ot = oplnc.GetCliente(og.IdCliente);
            label2.Text = ot.Nombre;
            label11.Text = ot.Apellido;
            label13.Text = ot.Cedula;
        }

        private void frmAdminFactura_Load(object sender, EventArgs e)
        {
            ListarFacturaDetalleFiltro(int.Parse(textBox1.Text));
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
