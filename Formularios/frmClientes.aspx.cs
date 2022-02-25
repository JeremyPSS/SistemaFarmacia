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
    public partial class frmClientes : System.Web.UI.Page
    {
        ClienteLN ocln = new ClienteLN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListCliente();
                //ListClienteinDropDownList();
            }
        }

        public void ListCliente()
        {
            GridView1.DataSource = ocln.ViewCliente();
            GridView1.DataBind();
        }

        //public void ListClienteinDropDownList()
        //{
        //    try
        //    {
        //        ddlEditar.DataSource = ocln.ViewCliente();
        //        ddlEditar.DataValueField = "idCliente";
        //        ddlEditar.DataTextField = "apellido";
        //        ddlEditar.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('Ha ocurrido un error al listar en Comobo')</script>");
        //    }
        //}

        //public void Delete()
        //{

        //    try
        //    {
        //        int id = int.Parse(ddlEditar.SelectedValue.ToString());
        //        ClienteCE ob = ocln.GetCliente(id);
        //        ocln.DelateCliente(ob);
        //        ListCliente();
        //        ListClienteinDropDownList();
        //        Response.Write("<script>alert('SE HA ELIMINADO EXITOSAMENTE')</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('Ha ocurrido un error al eliminar')</script>");
        //    }
        //}

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //Delete();
        }
    }
}