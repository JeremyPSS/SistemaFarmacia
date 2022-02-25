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
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        AdministradorLN aln = new AdministradorLN();

        public bool LoginVerification(string user, string pass)
        {
            bool estado = false;
            foreach (AdministradorCE ob in aln.ViewAdministrador())
            {
                if (user.Equals(ob.Cedula) && (pass.Equals(ob.Contraseña)))
                {
                    estado = true;
                }
            }
            if (estado == true)
            {
                frmMenu frm = new frmMenu();
                frm.Show();
                textBox1.Clear();
                textBox2.Clear();
            }
            if (estado == false)
            {
                MessageBox.Show("El usuario no existe, ingreso los datos correctamente");
            }
            return estado;
        }

        private void frmInicioSeccion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            LoginVerification(user, pass);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}
