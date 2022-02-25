using CapaDatos;
using CapaDatos.Inventario;
using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Inventario
{
    public class FacturaLN
    {
        public List<FacturaCE> ViewFactura()
        {
            FacturaCE op;
            List<FacturaCE> Lista = new List<FacturaCE>();
            try
            {
                List<Factura> aux = FacturaCD.ListarFactura();
                foreach (Factura prov in aux)
                {
                    op = new FacturaCE(prov.IdFactura, (double)prov.Total, prov.FechaFactura, prov.IdCliente);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos de factura", ex);
            }
            return Lista;
        }

        public List<FacturaCE> ViewFacturaFiltro(int val)
        {
            FacturaCE op;
            List<FacturaCE> Lista = new List<FacturaCE>();
            try
            {
                List<SP_ListarFacturaFiltroResult> aux = FacturaCD.ListarFacturaFiltro(val);

                foreach (SP_ListarFacturaFiltroResult prov in aux)
                {
                    op = new FacturaCE(prov.IdFactura, (double)prov.Total, prov.FechaFactura, prov.IdCliente);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos filtrados de factura", ex);
            }
            return Lista;
        }

        public bool CreateFactura(FacturaCE op)
        {
            try
            {
                FacturaCD.InsertarFactura(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert factura", ex);
            }
        }

        public bool UpdateFactura(FacturaCE op)
        {
            try
            {
                FacturaCD.ModificarFactura(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar factura", ex);
            }
        }

        public bool DelateFactura(FacturaCE op)
        {
            try
            {
                FacturaCD.EliminarFactura(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar factura", ex);
            }
        }

        public FacturaCE GetFactura(int IdFactura)
        {
            FacturaCE resu = null;
            List<FacturaCE> aux = ViewFactura();
            foreach (FacturaCE ob in aux)
            {
                if (ob.IdFactura == IdFactura)
                {
                    return ob;
                }
            }
            return resu;
        }



    }
}
