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
    public partial class frmAdminClientes : Form
    {
        public frmAdminClientes()
        {
            InitializeComponent();
        }

        ClienteLN oplnc = new ClienteLN();

        public void ListarClienteFiltro()
        {
            dataGridView1.DataSource = oplnc.ViewClienteFiltro(textBox1.Text); ;
        }

        public void ListarCliente()
        {
            dataGridView1.DataSource = oplnc.ViewCliente();
        }

        public ClienteCE CrearObjeto()
        {
            ClienteCE op;
            int idc = int.Parse(textBox2.Text);
            string nom = textBox3.Text;
            string apel = textBox4.Text;
            string correo = textBox5.Text;
            string ced = textBox6.Text;
            
            op = new ClienteCE(idc, nom, apel, correo, ced);
            return op;
        }

        public bool Validar()
        {
            bool valor = true;
            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0)
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
                    ClienteCE om = CrearObjeto();
                    oplnc.CreateCliente(om);
                    Limpiar();
                    ListarCliente();
                    label8.Text = "Cliente ingresado";
                }
                else
                    MessageBox.Show("Ingrese correctamente los datos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        public void cargar(int idc, string nom, string apel, string correo, string ced)
        {
            textBox2.Text = idc.ToString();
            textBox3.Text = nom;
            textBox4.Text = apel;
            textBox5.Text = correo;
            textBox6.Text = ced;
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("Deseas eliminar el cliente", "Eliminar", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        ClienteCE op = dataGridView1.CurrentRow.DataBoundItem as ClienteCE;
                        oplnc.DelateCliente(op);
                        ListarCliente();
                        label8.Text = "Cliente eliminado";
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila");
                }
                ListarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAdminClientes_Load(object sender, EventArgs e)
        {
            ListarClienteFiltro();
            button6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarClienteFiltro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
                ClienteCE ob = CrearObjeto();
                oplnc.UpdateCliente(ob);
                Limpiar();
                ListarCliente();
                label8.Text = "Cliente actualizado";
            }
            else
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
            button5.Visible = true;
            button6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    ClienteCE om = dataGridView1.CurrentRow.DataBoundItem as ClienteCE;
                    cargar(om.IdCliente, om.Nombre, om.Apellido, om.Correo, om.Cedula);
                    button6.Visible = true;
                    button5.Visible = false;
                }
                else
                    MessageBox.Show("Seleccione la fila a editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarTamanioCedula(e, textBox6, 10);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListarClienteFiltro();
        }
    }
}
