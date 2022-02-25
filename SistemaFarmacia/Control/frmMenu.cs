using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia.Inventario
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdminUsuarios"] == null)
            {
                frmAdminUsuarios frm1 = new frmAdminUsuarios
                {
                    MdiParent = this
                };
                frm1.Show();
                label1.Visible = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdminMedicamentos"] == null)
            {
                frmAdminMedicamentos frm2 = new frmAdminMedicamentos
                {
                    MdiParent = this
                };
                frm2.Show();
                label1.Visible = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdminPromociones"] == null)
            {
                frmAdminPromociones frm3 = new frmAdminPromociones
                {
                    MdiParent = this
                };
                frm3.Show();
                label1.Visible = false;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmAdminClientes"] == null)
            {
                frmAdminClientes frm4 = new frmAdminClientes
                {
                    MdiParent = this
                };
                frm4.Show();
                label1.Visible = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmFacturacion"] == null)
            {
                frmFacturacion frm4 = new frmFacturacion
                {
                    MdiParent = this
                };
                frm4.Show();
                label1.Visible = false;
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            label1.Visible = true;
        }
    }
}
