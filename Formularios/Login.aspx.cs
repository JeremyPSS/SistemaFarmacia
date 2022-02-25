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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        AdministradorLN aln = new AdministradorLN();

        public bool LoginVerification(string user, string pass)
        {
            bool estado = false;
            foreach(AdministradorCE ob in aln.ViewAdministrador())
            {
                if (user.Equals(ob.Cedula) && (pass.Equals(ob.Contraseña)))
                { 
                    estado = true;
                }
            }
            if (estado == true)
            {
                Response.Write("<script>alert('USUARIO CORRECTO')</script>");
                Response.Redirect("PanelGeneral.aspx");
            }
            if (estado == false)
            {
                Response.Write("<script>alert('USUARIO INCORRECTO')</script>");
            }

            return estado;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            string pass = txtPassword.Text;
            /*
            string userName = "admin";
            string passName = "admin";

            if(user.Equals(userName) && pass.Equals(passName))
            {
                Response.Write("<script>alert('USUARIO CORRECTO')</script>");
            }
            else
            {
                Response.Write("<script>alert('USUARIO INCORRECTO')</script>");
            }
            */
            LoginVerification(user, pass);
        }
    }
}