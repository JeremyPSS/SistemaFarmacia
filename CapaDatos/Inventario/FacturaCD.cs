using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Inventario
{
    public class FacturaCD
    {
        public static List<Factura> ListarFactura()
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.Factura.ToList();
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

        public static List<SP_ListarFacturaFiltroResult> ListarFacturaFiltro(int val)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.SP_ListarFacturaFiltro(val).ToList();
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

        public static void InsertarFactura(FacturaCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_InsertarFactura(op.IdFactura, (decimal)op.Total, op.FechaFactura, op.IdCliente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Insertar Factura", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarFactura(FacturaCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_ActualizarFactura(op.IdFactura, (decimal)op.Total, op.FechaFactura, op.IdCliente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Actualizar Factura", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarFactura(FacturaCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_EliminarFactura(op.IdFactura);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Eliminar Factura", ex);
            }
            finally
            {
                DB = null;
            }
        }



    }
}
