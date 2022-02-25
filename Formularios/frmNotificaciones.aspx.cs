using CapaLogica.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFarmaciaWeb.Formularios
{
    public partial class frmNotificaciones : System.Web.UI.Page
    {

        MedicamentoLN omln = new MedicamentoLN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListExpiredMedicine();
                ListAFewMedicine();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ListExpiredMedicine();
            ListAFewMedicine();
        }

        public void ListExpiredMedicine()
        {
            try
            {
                if (omln.ExpiredMedications().Count>=0)
                {
                    GridView1.DataSource = omln.ExpiredMedications();
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public void ListAFewMedicine()
        {
            try
            {
                if (omln.FewMedications().Count >= 0)
                {
                    GridView2.DataSource = omln.FewMedications();
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}