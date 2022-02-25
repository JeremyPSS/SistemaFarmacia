using CapaEntidades.Inventario;
using CapaLogica.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFarmaciaWeb.Formularios
{
    public partial class frmFactura : System.Web.UI.Page
    {
        //GLOBAL VAIRABLES
        ClienteLN ocln = new ClienteLN();
        FacturaLN ofln = new FacturaLN();
        Factura_DetalleLN ofdln = new Factura_DetalleLN();
        MedicamentoLN omln = new MedicamentoLN();
        PromocionLN opln = new PromocionLN();
        static List<VistaFactura> listafd = new List<VistaFactura>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlIdFactura.Visible = false;
                txtCantidad.Enabled = false;
                txtDescuento.Enabled = false;
                txtTotal.Enabled = false;
                txtTotalFinal.Enabled = false;
                btnCargar.Visible = false;

                ListMedicationInDropDownList();

            }
        }

        public ClienteCE CreateOCliente()
        {
            int id = int.Parse(txtIdCliente.Text);
            string nom = txtNomCliente.Text;
            string ape = txtApeCliente.Text;
            string email = txtCorCliente.Text;
            string ced = txtCedCliente.Text;
            ClienteCE obj = new ClienteCE(id, nom, ape, email, ced);
            return obj;
        }

        public FacturaCE CreateOFactura()
        {
            int id = int.Parse(txtIdFactura.Text);
            double total = double.Parse(txtTotalFinal.Text);
            DateTime fec = Calendar1.SelectedDate;
            int idc = int.Parse(txtIdCliente.Text);
            FacturaCE obj = new FacturaCE(id, total, fec, idc);
            return obj;
        }

        public Factura_DetalleCE CreateOFactura_Detalle(int idMedicamento, int cant, double subtotal)
        {
            int idf = int.Parse(txtIdFactura.Text);
            Factura_DetalleCE ob = new Factura_DetalleCE(idf,idMedicamento,cant,subtotal);
            return ob;
        }
        
        public void Save()
        {
            //try
            //{
                if (ValidateData() == true)
                {
                    ofln.CreateFactura(CreateOFactura());
                    
                    if (listafd.Count > 0)
                    {
                        foreach(VistaFactura ob in listafd)
                        {
                            Factura_DetalleCE o1 = CreateOFactura_Detalle(ob.IdMedicamento, ob.Cantidad, ob.Subtotal);
                            ofdln.CreateFacturaDetalle(o1);
                        }
                        Response.Write("<script>alert('REGISTRO EXITOSO')</script>");
                    }

                    
                }

            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('Error en guardar')</script>");
            //}
        }


        public bool ValidateData()
        {
            bool resu = true;
            if (txtIdCliente.Text.Trim().Length == 0 || txtNomCliente.Text.Trim().Length == 0 || txtApeCliente.Text.Trim().Length == 0
                || txtCorCliente.Text.Trim().Length == 0 || txtCedCliente.Text.Trim().Length == 0 || txtIdFactura.Text.Trim().Length == 0 )
            {
                resu = false;
            }
            return resu;
        }

        public void CalculateTotal()
        {
            double res = 0;
            foreach (VistaFactura ob in listafd)
            {
                res += ob.Subtotal;
            }
            txtTotal.Text = res.ToString();
        }

        public void CalculateCantidad()
        {
            txtCantidad.Text = listafd.Count.ToString();
        }

        public void CalculateDescuento()
        {
            double res = 0;
            foreach(VistaFactura ob in listafd)
            {
                MedicamentoCE o1 = omln.GetMedicamento(ob.IdMedicamento);
                PromocionesCE o2 = opln.GetPromocion(o1.IdPromocion);
   
                res += o2.Porcentaje;
            }
            txtDescuento.Text = res.ToString();
        }

        public void CalculateTotalFinal()
        {
            double res = 0;
            foreach (VistaFactura ob in listafd)
            {
                res += ob.Subtotal;
            }

            double descuento = double.Parse(txtDescuento.Text);

            res = res - (res * (descuento / (double)100));
            txtTotalFinal.Text = res.ToString();
        }

        public void ListarFacturaDetalle()
        {
            GridView1.DataSource = listafd;
            GridView1.DataBind();
        }

        public void ListMedicationInDropDownList()
        {
            try
            {
                ddlElejirMedicamento.DataSource = omln.ViewMedicamento();
                ddlElejirMedicamento.DataValueField = "idMedicamento";
                ddlElejirMedicamento.DataTextField = "nombre";
                ddlElejirMedicamento.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al listar medicamentos')</script>");
            }
        }

        public void AddMedicamentos()
        {
            try
            {
                if (!txtCant.Text.Equals(""))
                {
                    int id = int.Parse(ddlElejirMedicamento.SelectedValue.ToString());
                    int cant = int.Parse(txtCant.Text);
                    MedicamentoCE obm = omln.GetMedicamento(id);
                    PromocionesCE op = opln.GetPromocion(obm.IdPromocion);
                    VistaFactura o1 = new VistaFactura(id, obm.Nombre, op.Tipo, cant, (cant * obm.Precio));
                    listafd.Add(o1);
                    ListarFacturaDetalle();
                }
                

            }catch(Exception ex)
            {

            }
        }

        protected void btnAnadirMedicamento_Click(object sender, EventArgs e)
        {
            AddMedicamentos();
            CalculateCantidad();
            CalculateDescuento();
            CalculateTotal();
            CalculateTotalFinal();
        }

        public void SaveCliente()
        {
            ClienteCE ob = CreateOCliente();
            ocln.CreateCliente(ob);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveCliente();
            Save();
            RestarMedicamentos();
            ClearInformation();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearInformation();

        }

        public void ClearInformation()
        {
            listafd.Clear();
            txtIdCliente.Text = "";
            txtIdFactura.Text = "";
            txtNomCliente.Text = "";
            txtApeCliente.Text = "";
            txtCant.Text = "";
            txtCantidad.Text = "";
            txtDescuento.Text = "";
            txtTotal.Text = "";
            txtTotalFinal.Text = "";
            txtCedCliente.Text = "";
            txtCorCliente.Text = "";
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            ddlIdFactura.Visible = true;
            ListFacturainDropDownList();

        }

        public void ListFacturainDropDownList()
        {
            try
            {
                ddlIdFactura.DataSource = omln.ViewMedicamento();
                ddlIdFactura.DataValueField = "idFactura";
                ddlIdFactura.DataTextField = "idFactura";
                ddlIdFactura.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al listar medicamentos')</script>");
            }
        }

        public void RestarMedicamentos()
        {
            try
            {
                foreach(VistaFactura ov in listafd)
                {
                    foreach(MedicamentoCE om in omln.ViewMedicamento())
                    {
                        if(om.IdMedicamento == ov.IdMedicamento)
                        {
                            int cantfinal = om.Cantidad - ov.Cantidad;
                            om.Cantidad = cantfinal;
                            omln.UpdateMedicamento(om);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error en Restar Medicamentos')</script>");
            }
        }




        /*

        public void RestarMedicamento()
        {
            
            for(int = 0, int < datagriedaview.count; i++)
            {
                int idm = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) //idmedicamento
                double cant = double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString())//celda cantidad
                foreach (MedicamentoCE ob in oplnm.ViewMedicamento())
                {
                    if (ob.IdMedicamento == idm)
                    {
                        ob.Cantidad = (ob.Cantidad - (cant));
                        oplnm.UpdateMedicamento(ob);
                    }


                }
            }
            
        }
        */

    }
}