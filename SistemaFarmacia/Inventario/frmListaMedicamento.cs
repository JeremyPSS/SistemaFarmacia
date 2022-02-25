using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.Inventario;

namespace SistemaFarmacia.Inventario
{
    public partial class frmListaMedicamento : Form
    {
        public frmListaMedicamento()
        {
            InitializeComponent();
        }

        MedicamentoLN opln = new MedicamentoLN();

        public void ListarMedicamento()
        {
            dataGridView1.DataSource = opln.ViewMedicamento();
        }

        private void AdminAdministrador_Load(object sender, EventArgs e)
        {
            ListarMedicamento();
        }
    }
}
