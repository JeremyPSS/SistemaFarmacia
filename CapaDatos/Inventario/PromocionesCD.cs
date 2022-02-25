using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Inventario
{
    public class PromocionesCD
    {
        public static List<Promociones> ListarPromociones()
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.Promociones.ToList();
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

        public static List<SP_ListarPromocionesFiltroResult> ListarPromocionesFiltro(string val)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.SP_ListarPromocionesFiltro(val).ToList();
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

        public static void InsertarPromocion(PromocionesCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_InsertarPromociones(op.IdPromocion, op.Tipo, (decimal)op.Porcentaje);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Insertar Promocion", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarProveedor(PromocionesCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_ActualizarPromociones(op.IdPromocion, op.Tipo, (decimal)op.Porcentaje);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Actualizar Promocion", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarPromocion(PromocionesCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_EliminarPromociones(op.IdPromocion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Eliminar Promocion", ex);
            }
            finally
            {
                DB = null;
            }
        }


    }
}
