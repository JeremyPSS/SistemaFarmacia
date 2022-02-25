using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Inventario
{
    public class Factura_DetalleCD
    {
        public static List<Factura_Detalle> ListarFacturaDetalle()
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.Factura_Detalle.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al listar", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<SP_ListarFactura_DetalleFiltroResult> ListarFacturaDetalleFiltro(int val)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.SP_ListarFactura_DetalleFiltro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void InsertarFacturaDetalle(Factura_DetalleCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_InsertarFactura_Detalle(op.IdFactura, op.IdMedicamento, op.Cantidad,(decimal) op.Subtotal);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Insertar FacturaDetalle", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarFacturaDetalle(Factura_DetalleCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_ActualizarFactura_Detalle(op.IdFactura, op.IdMedicamento, op.Cantidad, (decimal)op.Subtotal);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Actualizar FacturaDetalle", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarFacturaDetalle(Factura_DetalleCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_EliminarFactura_Detalle(op.IdFactura);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Eliminar FacturaDetalle", ex);
            }
            finally
            {
                DB = null;
            }
        }


    }
}
