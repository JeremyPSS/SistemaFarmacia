using CapaEntidades.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Inventario
{
    public class ClienteCD
    {
        public static List<Cliente> ListarCliente()
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.Cliente.ToList();
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

        public static List<SP_ListarClienteFiltroResult> ListarClienteFiltro(string val)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.SP_ListarClienteFiltro(val).ToList();
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

        public static void InsertarCliente(ClienteCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_InsertarCliente(op.IdCliente, op.Nombre, op.Apellido, op.Correo, op.Cedula);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Insertar Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarCliente(ClienteCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_ActualizarCliente(op.IdCliente, op.Nombre, op.Apellido, op.Correo, op.Cedula);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Actualizar Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarCliente(ClienteCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_EliminarCliente(op.IdCliente);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Eliminar Cliente", ex);
            }
            finally
            {
                DB = null;
            }
        }



    }
}
