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
    public partial class frmNotificaciones : Form
    {
        public frmNotificaciones()
        {
            InitializeComponent();
        }

        MedicamentoLN opln = new MedicamentoLN();

        public void ListarVencimiento()
        {
            dataGridView1.DataSource = opln.ExpiredMedications();
        }

        public void ListarCantidad()
        {
            dataGridView2.DataSource = opln.MenorMedications();
        }

        private void frmNotificaciones_Load(object sender, EventArgs e)
        {
            ListarVencimiento();
            ListarCantidad();
        }
    }
}
