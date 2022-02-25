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
    public partial class frmAdminUsuarios : Form
    {
        public frmAdminUsuarios()
        {
            InitializeComponent();
        }

        AdministradorLN oplna = new AdministradorLN();

        public void ListarAdministrador()
        {
            dataGridView1.DataSource = oplna.ViewAdministrador();
        }

        public void ListarAdministradorFiltro()
        {
            dataGridView1.DataSource = oplna.ViewAdministradorFiltro(textBox1.Text);
        }

        private void frmAdminUsuarios_Load(object sender, EventArgs e)
        {
            ListarAdministradorFiltro();
            button6.Visible = false;
        }

        public AdministradorCE CrearObjeto()
        {
            AdministradorCE op;
            int idu = int.Parse(textBox2.Text);
            string contr = textBox3.Text;
            string ced = textBox4.Text;
            string nom = textBox5.Text;
            string apel = textBox6.Text;
            string tel = textBox7.Text;
            string email = textBox8.Text;
            string tipo = comboBox1.Text;
            string est = comboBox2.Text;

            op = new AdministradorCE(idu, contr, ced, nom, apel, tel, email, tipo, est);
            return op;
        }

        public bool Validar()
        {
            bool valor = true;
            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 || textBox7.Text.Trim().Length == 0 || textBox8.Text.Trim().Length == 0)
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
                    AdministradorCE om = CrearObjeto();
                    oplna.CreateAdministrador(om);
                    Limpiar();
                    ListarAdministrador();
                    label3.Text = "Usuario ingresado";
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
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.SelectedIndex = 0;
            label3.Text = "...";
        }

        public void cargar(int idu, string cont, string ced, string nom, string apel, string tel, string email, string tipo, string est)
        {
            textBox2.Text = idu.ToString();
            textBox3.Text = cont;
            textBox4.Text = ced;
            textBox5.Text = nom;
            textBox6.Text = apel;
            textBox7.Text = tel;
            textBox8.Text = email;
            comboBox1.Text = tipo;
            comboBox2.Text = est;
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("Deseas eliminar el usuario", "Eliminar", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        AdministradorCE op = dataGridView1.CurrentRow.DataBoundItem as AdministradorCE;
                        oplna.DelateAdministrador(op);
                        ListarAdministrador();
                        label3.Text = "Usuario eliminado";
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila");
                }
                ListarAdministrador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    AdministradorCE om = dataGridView1.CurrentRow.DataBoundItem as AdministradorCE;
                    cargar(om.IdUsuario, om.Contraseña, om.Cedula, om.Nombres, om.Apellidos, om.Telefono, om.Email, om.Tipo, om.Estado);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
            button5.Visible = true;
            button6.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListarAdministradorFiltro();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
                AdministradorCE ob = CrearObjeto();
                oplna.UpdateAdministrador(ob);
                Limpiar();
                ListarAdministrador();
                label3.Text = "Usuario actualizado";
            }
            else
            {
                //frm.Close();
                //label3.Text = "Accion cancelada";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarTamanioCedula(e, textBox4, 10);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListarAdministradorFiltro();
        }
    }
}
