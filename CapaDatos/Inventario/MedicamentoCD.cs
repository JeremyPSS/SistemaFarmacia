using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Inventario
{
    public class MedicamentoCD
    {
        public static List<Medicamento> ListarMedicamento()
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.Medicamento.ToList();
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


        public static List<SP_ListarMedicamentoFiltroResult> ListarMedicamentoFiltro(string val)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.SP_ListarMedicamentoFiltro(val).ToList();
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
        public static void InsertarMedicamento(MedicamentoCE oc)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_InsertarMedicamento(oc.IdMedicamento,oc.Nombre,oc.Enpaque,oc.Cantidad,oc.Presentacion,oc.FechaVencimiento,oc.ViaAdministracion,oc.Almacenamiento,oc.Especificacion,(decimal)oc.Precio,oc.IdPromocion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Insertar Medicamento", ex);
            }
            finally
            {
                DB = null;
            }

        }
        public static void ModificarMedicamento(MedicamentoCE oc)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_ActualizarMedicamento(oc.IdMedicamento, oc.Nombre, oc.Enpaque, oc.Cantidad, oc.Presentacion, oc.FechaVencimiento, oc.ViaAdministracion, oc.Almacenamiento, oc.Especificacion, (decimal)oc.Precio, oc.IdPromocion);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Actualizar Medicamento", ex);
            }
            finally
            {
                DB = null;
            }

        }
        public static void EliminarMedicamento(MedicamentoCE oc)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_EliminarMedicamento(oc.IdMedicamento);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Eliminar Medicamento", ex);
            }
            finally
            {
                DB = null;
            }

        }


    }
}
