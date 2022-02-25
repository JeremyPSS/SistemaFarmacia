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
    public partial class frmAdminPromociones : Form
    {
        public frmAdminPromociones()
        {
            InitializeComponent();
        }

        PromocionLN oplnp = new PromocionLN();

        public void ListarPromociones()
        {
            dataGridView1.DataSource = oplnp.ViewPromociones();
        }

        public void ListarPromocionesFiltrar()
        {
            dataGridView1.DataSource = oplnp.ViewPromocionesFiltro(textBox1.Text);
        }

        public PromocionesCE CrearObjeto()
        {
            PromocionesCE op;
            int idp = int.Parse(textBox2.Text);
            string tipo = textBox3.Text;
            double por = double.Parse(textBox4.Text);

            op = new PromocionesCE(idp, tipo, por);
            return op;
        }

        public bool Validar()
        {
            bool valor = true;
            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0)
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
                    PromocionesCE om = CrearObjeto();
                    oplnp.CreatePromociones(om);
                    Limpiar();
                    ListarPromociones();
                    label6.Text = "Promocion ingresada";
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
        }

        public void cargar(int idp, string tipo, double por)
        {
            textBox2.Text = idp.ToString();
            textBox3.Text = tipo;
            textBox4.Text = por.ToString();
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("Deseas eliminar la promocion", "Eliminar", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        PromocionesCE op = dataGridView1.CurrentRow.DataBoundItem as PromocionesCE;
                        oplnp.DelatePromociones(op);
                        ListarPromociones();
                        label6.Text = "Promocion eliminada";
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila");
                }
                ListarPromociones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    PromocionesCE om = dataGridView1.CurrentRow.DataBoundItem as PromocionesCE;
                    cargar(om.IdPromocion, om.Tipo, om.Porcentaje);
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

        private void frmAdminPromociones_Load(object sender, EventArgs e)
        {
            ListarPromocionesFiltrar();
            button6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListarPromocionesFiltrar();
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
                PromocionesCE ob = CrearObjeto();
                oplnp.UpdatePromociones(ob);
                Limpiar();
                ListarPromociones();
                label6.Text = "Promocion actualizado";
            }
            else
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Limpiar();
            button6.Visible = false;
            button5.Visible = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListarPromocionesFiltrar();
        }
    }
}
