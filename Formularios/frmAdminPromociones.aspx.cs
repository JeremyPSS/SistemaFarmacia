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
    public partial class frmAdminPromociones : System.Web.UI.Page
    {
        //GLOBAL VARIABLES
        PromocionLN opln = new PromocionLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListPromociones();
                ListInDropDownList();
                txtSaveEdit.Visible = false;
            }
        }
        /*
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        */

        protected void txtSaveEdit_Click(object sender, EventArgs e)
        {
            ConfirmarEdit();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearInformation();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void ListPromociones()
        {
            GridView1.DataSource = opln.ViewPromociones();
            GridView1.DataBind();
        }

        public void ListInDropDownList()
        {
            try
            {
                ddlEditar.DataSource = opln.ViewPromociones();
                ddlEditar.DataValueField = "idPromocion";
                ddlEditar.DataTextField = "tipo";
                ddlEditar.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al listar en el DropDownList')</script>");
            }


        }



        public void Save()
        {
            try
            {
                if (Validar() == true)
                {
                    PromocionesCE obj = CreateObject();
                    opln.CreatePromociones(obj);
                    ListPromociones();
                    ListInDropDownList();
                    ClearInformation();
                    Response.Write("<script>alert('SE HA INGRESADO CORRECTAMENTE')</script>");
                }
                else
                {
                    Response.Write("<script>alert('INGRESE CORRECTAMENTE LOS DATOS')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al registrar')</script>");
            }
        }

        public void ClearInformation()
        {
            txtIdPromocion.Text = "";
            txtTipo.Text = "";
            txtPorcentaje.Text = "";
            
        }
        public PromocionesCE CreateObject()
        {
            int id = int.Parse(txtIdPromocion.Text);
            string tip = txtTipo.Text;
            double por = double.Parse(txtPorcentaje.Text);

            PromocionesCE obj = new PromocionesCE(id, tip,por);
            return obj;
        }
        public void SetData(PromocionesCE ob)
        {
            txtIdPromocion.Text = ob.IdPromocion.ToString();
            txtTipo.Text = ob.Tipo;
            txtPorcentaje.Text = ob.Porcentaje.ToString();
            
        }
        public void Edit()
        {
            int id;
            try
            {
                id = int.Parse(ddlEditar.SelectedValue.ToString());
                PromocionesCE ob = opln.GetPromocion(id);
                ClearInformation();
                SetData(ob);
                txtSaveEdit.Visible = true;
                btnRegister.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al editar')</script>");
            }
        }


        public void Delete()
        {
            int id;
            try
            {
                id = int.Parse(ddlEditar.SelectedValue.ToString());
                PromocionesCE ob = opln.GetPromocion(id);
                opln.DelatePromociones(ob);
                ListPromociones();
                ListInDropDownList();
                Response.Write("<script>alert('SE HA ELIMINADO EXITOSAMENTE')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al eliminar')</script>");
            }
        }
        public bool Validar()
        {
            bool valor = true;
            if (txtIdPromocion.Text.Trim().Length == 0 || txtPorcentaje.Text.Trim().Length == 0 || txtTipo.Text.Trim().Length == 0 )
            {
                valor = false;
            }
            return valor;
        }


        public void ConfirmarEdit()
        {
            try
            {
                if (Validar() == true)
                {
                    PromocionesCE ob = CreateObject();
                    opln.UpdatePromociones(ob);
                    btnRegister.Visible = true;
                    txtSaveEdit.Visible = false;
                    ClearInformation();
                    ListPromociones();
                    ListInDropDownList();
                    Response.Write("<script>alert('SE HA EDITADO CORRECTAMENTE')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Ingrese correctamente los datos')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un errores')</script>");
            }
        }


    }
}