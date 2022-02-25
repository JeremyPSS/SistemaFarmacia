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
using CapaEntidades.Inventario;

namespace SistemaFarmacia.Inventario
{
    public partial class frmAdminMedicamentos : Form
    {
        public frmAdminMedicamentos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        MedicamentoLN oplnm = new MedicamentoLN();
        PromocionLN oplnp = new PromocionLN();

        public void ListarMedicamentoFiltro()
        {
            dataGridView1.DataSource = oplnm.ViewMedicamentoFiltro(textBox11.Text); ;
        }

        public void ListarMedicamento()
        {
            dataGridView1.DataSource = oplnm.ViewMedicamento();
        }

        public void LLenarComboBox()
        {
            try
            {
                comboBox1.DataSource = oplnp.ViewPromociones();
                //comboBox1.SelectedIndex = 0;
                comboBox1.DisplayMember = "tipo";
                comboBox1.ValueMember = "idPromocion";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MedicamentoCE CrearObjeto()
        {
            MedicamentoCE op;
            int idm = int.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string emp = textBox3.Text;
            int cant = int.Parse(textBox4.Text);
            string pres = textBox5.Text;
            DateTime fchv = dateTimePicker1.Value;
            string viaA = textBox6.Text;
            string alm = textBox7.Text;
            string esp = textBox8.Text;
            double precio = double.Parse(textBox9.Text);
            int idp = int.Parse(comboBox1.SelectedValue.ToString());

            op = new MedicamentoCE(idm, nom, emp, cant, pres, fchv, viaA, alm, esp, precio, idp);
            return op;
        }

        public bool Validar()
        {
            bool valor = true;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 || textBox7.Text.Trim().Length == 0 || textBox8.Text.Trim().Length == 0 || textBox9.Text.Trim().Length == 0)
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
                    MedicamentoCE om = CrearObjeto();
                    oplnm.CreateMedicamento(om);
                    Limpiar();
                    ListarMedicamento();
                    label15.Text = "Medicamento ingresado";
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            dateTimePicker1.Value = DateTime.Today;
            label15.Text = "...";
        }

        public void cargar(int idm, string nom, string emp, int cant, string pres, DateTime fchv, string viaA, string alm, string esp, double pre, int idp)
        {
            textBox1.Text = idm.ToString();
            textBox2.Text = nom;
            textBox3.Text = emp;
            textBox4.Text = cant.ToString();
            textBox5.Text = pres;
            dateTimePicker1.Value = fchv;
            textBox6.Text = viaA;
            textBox7.Text = alm;
            textBox8.Text = esp;
            textBox9.Text = pre.ToString();
            comboBox1.SelectedValue = idp;
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
                        MedicamentoCE op = dataGridView1.CurrentRow.DataBoundItem as MedicamentoCE;
                        oplnm.DeleteMedicamento(op);
                        ListarMedicamento();
                        label15.Text = "Medicamento eliminado";
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila");
                }
                ListarMedicamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void frmAdminMedicamentos_Load(object sender, EventArgs e)
        {
            ListarMedicamentoFiltro();
            button6.Visible = false;
            LLenarComboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ListarMedicamentoFiltro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
            button6.Visible = false;
            button1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    MedicamentoCE om = dataGridView1.CurrentRow.DataBoundItem as MedicamentoCE;
                    cargar(om.IdMedicamento, om.Nombre, om.Enpaque, om.Cantidad, om.Presentacion, om.FechaVencimiento, om.ViaAdministracion, om.Almacenamiento, om.Especificacion, om.Precio, om.IdPromocion);
                    button6.Visible = true;
                    button1.Visible = false;
                }
                else
                    MessageBox.Show("Seleccione la fila a editar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.DialogResult = DialogResult.OK;
                MedicamentoCE ob = CrearObjeto();
                oplnm.UpdateMedicamento(ob);
                Limpiar();
                ListarMedicamento();
                label15.Text = "Medicamento actualizado";
            }
            else
            {
                
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            ListarMedicamentoFiltro();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmNotificaciones frm = new frmNotificaciones();
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validaciones.SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //ListarMedicamentoFiltro();
        }
    }
}
