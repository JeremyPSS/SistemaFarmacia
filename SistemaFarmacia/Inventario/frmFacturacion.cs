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
    public partial class frmFacturacion : Form
    {
        public frmFacturacion()
        {
            InitializeComponent();
        }

        ClienteLN oplnc = new ClienteLN();
        FacturaLN oplnf = new FacturaLN();
        Factura_DetalleLN oplnfd = new Factura_DetalleLN();
        MedicamentoLN oplnm = new MedicamentoLN();

        public void ListarFactura()
        {
            dataGridView2.DataSource = oplnf.ViewFactura();
        }

        public void ListarFacturaFiltro()
        {
            dataGridView2.DataSource = oplnf.ViewFacturaFiltro(int.Parse(textBox4.Text));
        }

        public void LLenarComboBox()
        {
            try
            {
                comboBox1.DataSource = oplnc.ViewClienteFiltro("");
                comboBox1.SelectedIndex = 0;
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "idCliente";

            }
            catch (Exception ex)
            {
                label16.Text = ex.Message;
            }
        }

        public Factura_DetalleCE CrearObjectoFactura_Detalle(int codM, int cant, double subtotal)
        {
            int idf = int.Parse(textBox1.Text);
            Factura_DetalleCE ob = new Factura_DetalleCE(idf, codM, cant, subtotal);
            return ob;
        }

        public FacturaCE CrearObjectoFactura()
        {
            int idf = int.Parse(textBox1.Text);
            int idc = int.Parse(comboBox1.SelectedValue.ToString());
            DateTime fchf = dateTimePicker1.Value;
            double tot = double.Parse(textBox3.Text);

            FacturaCE ob = new FacturaCE(idf, tot, fchf, idc);
            return ob;
        }

        public void CountItemsDG()
        {
            int num;
            num = dataGridView1.Rows.Count - 1;
            textBox2.Text = num.ToString();
        }

        public void CalculateTotal()
        {
            double total = 0;
            if (dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    total += double.Parse((string)dataGridView1.Rows[i].Cells[8].Value);
                }
            }
            textBox3.Text = total.ToString();
        }

        public void CalculateDescuento()
        {
            double descuento = 0;
            if (dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    descuento += double.Parse((string)dataGridView1.Rows[i].Cells[5].Value);
                }
            }
            textBox5.Text = descuento.ToString();
        }

        public bool ValidateData()
        {
            bool resu = true;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 ||
                (double.Parse(textBox1.Text.ToString())) == 0 || (double.Parse(textBox2.Text.ToString())) == 0)
            {
                resu = false;
            }
            return resu;
        }

        public void Save()
        {
            try
            {
                if (ValidateData() == true)
                {
                    oplnf.CreateFactura(CrearObjectoFactura());
                    if (dataGridView1.Rows.Count != 0)//validate if table not is empty
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            Factura_DetalleCE resu = CrearObjectoFactura_Detalle(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()),
                              int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()), double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString()));
                            oplnfd.CreateFacturaDetalle(resu);
                        }
                    }
                    label17.Text = "SE HA REGISTRADO LA FACTURA CORRECTAMENTE";
                    Limpiar();
                    ListarFactura();
                    //RestarMedicamento();
                }

            }
            catch (Exception ex)
            {
                label17.Text = ex.Message;
            }
        }

        public void Limpiar()
        {
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Today;
            dataGridView1.Rows.Clear();
            label10.Text = "....";
            label11.Text = "....";
            label12.Text = "....";
            label13.Text = "....";
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        //public void RestarMedicamento()
        //{
        //    foreach(MedicamentoCE ob in oplnm.ViewMedicamento())
        //    {
        //        bool resul = oplnm.ExisteMedicamento(ob.IdMedicamento);
        //        if(resul == true)
        //        {
        //            foreach(Factura_DetalleCE of in oplnfd.ViewFacturaDetalle())
        //            {
        //                int cod = of.IdMedicamento;
        //                oplnm.GetMedicamento(ob.IdMedicamento);
        //                if(cod == ob.IdMedicamento)
        //                {
        //                    int cantM = ob.Cantidad;
        //                    int cantF =  of.Cantidad;
        //                    int resta = cantM - cantF;
        //                    oplnm.UpdateMedicamento(ob);
        //                }
        //            }
        //        }
        //    }
        //}

        public void RestarMedicamento()
        {
            try
            {
                //foreach(FacturaCE of in oplnf.ViewFactura())
                //{
                //    foreach(MedicamentoCE om in oplnm.ViewMedicamento())
                //    {
                //        if(om.IdMedicamento == of.)
                //    }
                //}
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    int idm = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()); //idmedicamento
                    int cant = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());//celda cantidad
                    foreach (MedicamentoCE ob in oplnm.ViewMedicamento())
                    {
                        if (ob.IdMedicamento == idm)
                        {
                            int cantidad1 = ob.Cantidad - cant;
                            ob.Cantidad = cantidad1;
                            oplnm.UpdateMedicamento(ob);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Nuevo()
        {
            try
            {
                frmEditCliente frm = new frmEditCliente();
                frm.Text = "Ingreso CLiente";
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ClienteCE op = frm.CrearObjeto();
                    oplnc.CreateCliente(op);
                    frm.Close();
                    label16.Text = "Cliente Insertado";
                    LLenarComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    var res = MessageBox.Show("Deseas eliminar la factura", "Eliminar", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        FacturaCE op = dataGridView2.CurrentRow.DataBoundItem as FacturaCE;
                        oplnf.DelateFactura(op);
                        ListarFactura();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila");
                }
                ListarFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestarMedicamento();
            Save();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            LLenarComboBox();
            CountItemsDG();
            CalculateTotal();
            ListarFactura();
            CalculateDescuento();
            label19.Visible = false;
            textBox4.Visible = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(comboBox1.SelectedValue.ToString());
                ClienteCE ol = oplnc.GetCliente(index);
                if (ol != null)
                {
                    label10.Text = ol.Nombre;
                    label11.Text = ol.Apellido;
                    label12.Text = ol.Correo;
                    label13.Text = ol.Cedula;
                }

            }
            catch (Exception ex)
            {
                label16.Text = ex.Message;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "CodigoMedicamento")
                {
                    MedicamentoLN op = new MedicamentoLN();
                    int cod = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    foreach (var item in op.ViewMedicamento())
                    {
                        if (cod == item.IdMedicamento)
                        {
                            dataGridView1.CurrentRow.Cells[1].Value = item.Nombre;
                            dataGridView1.CurrentRow.Cells[2].Value = item.Precio;
                            dataGridView1.CurrentRow.Cells[3].Value = item.IdPromocion;
                        }
                    }
                    PromocionLN ol = new PromocionLN();
                    int codp = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    foreach (var item in ol.ViewPromociones())
                    {
                        if (codp == item.IdPromocion)
                        {
                            dataGridView1.CurrentRow.Cells[4].Value = item.Porcentaje;
                            double porce = double.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                            double precio = double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                            double desc = precio * (porce / 100);
                            double preciodes = precio - desc;
                            dataGridView1.CurrentRow.Cells[5].Value = desc.ToString();
                            dataGridView1.CurrentRow.Cells[6].Value = preciodes.ToString();
                        }
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Cantidad")
                {
                    double preciodesc = double.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                    int cant = int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
                    double total = cant * preciodesc;
                    dataGridView1.CurrentRow.Cells[8].Value = total.ToString();
                    CountItemsDG();
                    CalculateTotal();
                    CalculateDescuento();
                }
            }
            catch (Exception ex)
            {
                label17.Text = "Error desconocido" + ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmListaMedicamento frm = new frmListaMedicamento();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ListarFacturaFiltro();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    frmAdminFactura frm = new frmAdminFactura();
                    FacturaCE obc = dataGridView2.CurrentRow.DataBoundItem as FacturaCE;
                    FacturaCE op = oplnf.GetFactura(obc.IdFactura);
                    frm.SetDatos(op);
                    //frm.DisableComboBoxDateTimePicker(false);
                    frm.ShowDialog();
                    //frm.ListarGuiaDetalle(op.IdGuia);
                    if (frm.DialogResult == DialogResult.OK)
                    {

                        //Producto op = frm.CrearObjeto();
                        //opln1.CreateProducto(op);
                        //frm.Close();
                        //label2.Text = "Producto Insertado";

                    }
                }
                else
                    MessageBox.Show("Seleccione la fila a asignar");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
    }
}
