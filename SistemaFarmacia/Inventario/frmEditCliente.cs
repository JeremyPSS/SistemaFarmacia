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
    public partial class frmEditCliente : Form
    {
        public frmEditCliente()
        {
            InitializeComponent();
        }

        ClienteLN oplnc = new ClienteLN();

        public ClienteCE CrearObjeto()
        {
            ClienteCE op;
            int idc = int.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string apel = textBox3.Text;
            string correo = textBox4.Text;
            string ced = textBox5.Text;

            op = new ClienteCE(idc, nom, apel, correo, ced);
            return op;
        }

        public bool Validar()
        {
            bool valor = true;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0)
            {
                valor = false;
            }
            return valor;
        }

        public void Guardar()
        {
            try
            {
                if (Validar())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ingrese correctamente los datos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarTamanioCedula(e, textBox5, 10);
        }
    }
}
