using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.Inventario;

namespace CapaDatos.Inventario
{
    public class AdministradorCD
    {
        public static List<Administrador> ListarAdministrador()
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.Administrador.ToList();
                }
            }catch(Exception ex)
            {
                throw new DatosExcepciones("Problemas al listar", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<SP_ListarAdministradorFiltroResult> ListarAdministradorFiltro(string val)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    return DB.SP_ListarAdministradorFiltro(val).ToList();
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

        public static void InsertarAdministrador(AdministradorCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_InsertarAdministrador(op.IdUsuario, op.Contraseña, op.Cedula, op.Nombres, op.Apellidos, op.Telefono, op.Email, op.Tipo, op.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Insertar Administrador", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void ModificarAdministrador(AdministradorCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_ActualizarAdministrador(op.IdUsuario, op.Contraseña, op.Cedula, op.Nombres, op.Apellidos, op.Telefono, op.Email, op.Tipo, op.Estado);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Actualizar Administrador", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarAdministrador(AdministradorCE op)
        {
            BDSistemaFarmaciaDataContext DB = null;
            try
            {
                using (DB = new BDSistemaFarmaciaDataContext())
                {
                    DB.SP_EliminarAdministrador(op.IdUsuario);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Eliminar Administrador", ex);
            }
            finally
            {
                DB = null;
            }
        }


    }
}
