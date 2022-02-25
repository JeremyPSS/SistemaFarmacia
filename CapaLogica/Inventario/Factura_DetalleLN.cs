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
    public class Factura_DetalleLN
    {
        public List<Factura_DetalleCE> ViewFacturaDetalle()
        {
            Factura_DetalleCE op;
            List<Factura_DetalleCE> Lista = new List<Factura_DetalleCE>();
            try
            {
                List<Factura_Detalle> aux = Factura_DetalleCD.ListarFacturaDetalle();
                foreach (Factura_Detalle prov in aux)
                {
                    op = new Factura_DetalleCE(prov.IdFactura, prov.IdMedicamento, prov.Cantidad, (double)prov.Subtotal);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos de factura_detalle", ex);
            }
            return Lista;
        }

        public List<Factura_DetalleCE> ViewFacturaDetalleFiltro(int val)
        {
            Factura_DetalleCE op;
            List<Factura_DetalleCE> Lista = new List<Factura_DetalleCE>();
            try
            {
                List<SP_ListarFactura_DetalleFiltroResult> aux = Factura_DetalleCD.ListarFacturaDetalleFiltro(val);

                foreach (SP_ListarFactura_DetalleFiltroResult prov in aux)
                {
                    op = new Factura_DetalleCE(prov.IdFactura, prov.IdMedicamento, prov.Cantidad, (double)prov.Subtotal);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos filtrados de facturadetalle", ex);
            }
            return Lista;
        }

        public bool CreateFacturaDetalle(Factura_DetalleCE op)
        {
            try
            {
                Factura_DetalleCD.InsertarFacturaDetalle(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert facturadetalle", ex);
            }
        }

        public bool UpdateFacturaDetalle(Factura_DetalleCE op)
        {
            try
            {
                Factura_DetalleCD.ModificarFacturaDetalle(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar facturadetalle", ex);
            }
        }

        public bool DelateFacturaDetalle(Factura_DetalleCE op)
        {
            try
            {
                Factura_DetalleCD.EliminarFacturaDetalle(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar facturadetalle", ex);
            }
        }





    }
}
