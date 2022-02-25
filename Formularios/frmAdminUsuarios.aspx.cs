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
    public partial class frmAdminUsuarios : System.Web.UI.Page
    {
        AdministradorLN oaln = new AdministradorLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarAdministradores();
                ListUsuariosCombo();
                btnAceptarEdit.Visible = false;
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           
        }

        protected void btnAceptarEdit_Click(object sender, EventArgs e)
        {
            ConfirmarEdit();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearInformation();
            if (btnAceptarEdit.Visible == true) btnAceptarEdit.Visible = false;
            if (Button1.Visible == false) Button1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Edit();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void ListarAdministradores()
        {
            GridView1.DataSource = oaln.ViewAdministrador();
            GridView1.DataBind();
        }

        public void ListUsuariosCombo()
        {
            try
            {
                ddlEditar.DataSource = oaln.ViewAdministrador();
                ddlEditar.DataValueField = "idUsuario";
                ddlEditar.DataTextField = "apellidos";
                ddlEditar.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Ha ocurrido un error al listar Usuarios')</script>");
            }


        }

       

        public void Save()
        {
            try
            {
                if (Validar() == true)
                {
                    AdministradorCE obj = CreateObject();
                    oaln.CreateAdministrador(obj);
                    ListarAdministradores();
                    ListUsuariosCombo();
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
                Response.Write("<script>alert('Ha ocurrido un error al registrar el medicamento')</script>");
            }
        }

        public void ClearInformation()
        {
            txtIdAdministrador.Text = "";
            txtCedula.Text = "";
            txtContrasena.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
        public AdministradorCE CreateObject()
        {
            int id = int.Parse(txtIdAdministrador.Text);
            string ced = txtCedula.Text;
            string pass = txtContrasena.Text;
            string nom = txtNombres.Text;
            string ape = txtApellidos.Text;
            string tel = txtTelefono.Text;
            string est = ddlEstado.SelectedValue.ToString();
            string email = txtEmail.Text;
            string tipo = ddlTipo.SelectedValue.ToString();
            AdministradorCE obj = new AdministradorCE(id,pass,ced,nom,ape,tel,email,tipo,est);
            return obj;
        }
        public void SetData(AdministradorCE ob)
        {
            txtIdAdministrador.Text = ob.IdUsuario.ToString();
            txtCedula.Text = ob.Cedula;
            txtContrasena.Text = ob.Contraseña;
            txtNombres.Text = ob.Nombres;
            txtApellidos.Text = ob.Apellidos.ToString();
            txtTelefono.Text = ob.Telefono;
            ddlEstado.Text = ob.Estado.ToString();
            txtEmail.Text = ob.Email;
            ddlTipo.Text = ob.Tipo;
        }
        public void Edit()
        {
            int id;
            try
            {
                id = int.Parse(ddlEditar.SelectedValue.ToString());
                AdministradorCE ob = oaln.GetAdministrador(id);
                ClearInformation();
                SetData(ob);
                btnAceptarEdit.Visible = true;
                Button1.Visible = false;
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
                AdministradorCE ob = oaln.GetAdministrador(id);
                oaln.DelateAdministrador(ob);
                ListarAdministradores();
                ListUsuariosCombo();
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
            if (txtIdAdministrador.Text.Trim().Length == 0 || txtCedula.Text.Trim().Length == 0 || txtContrasena.Text.Trim().Length == 0 || txtNombres.Text.Trim().Length == 0
                || txtApellidos.Text.Trim().Length == 0 || txtTelefono.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0 )
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
                    AdministradorCE ob = CreateObject();
                    oaln.UpdateAdministrador(ob);
                    Button1.Visible = true;
                    btnAceptarEdit.Visible = false;
                    ClearInformation();
                    ListarAdministradores();
                    ListUsuariosCombo();
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