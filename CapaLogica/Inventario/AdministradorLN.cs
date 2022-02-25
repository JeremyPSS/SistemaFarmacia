using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.Inventario;
using CapaDatos.Inventario;
using CapaDatos;

namespace CapaLogica.Inventario
{
    public class AdministradorLN
    {
        public List<AdministradorCE> ViewAdministrador()
        {
            AdministradorCE op;
            List<AdministradorCE> Lista = new List<AdministradorCE>();
            try
            {
                List<Administrador> aux = AdministradorCD.ListarAdministrador();
                foreach (Administrador prov in aux)
                {
                    op = new AdministradorCE(prov.IdUsuario, prov.Contrasena, prov.Cedula, prov.Nombres, prov.Apellidos, prov.Telefono, prov.Email, prov.Tipo, prov.Estado);
                    Lista.Add(op);
                }
            }catch(Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos de administrador", ex);
            }
            return Lista;
        }

        public List<AdministradorCE> ViewAdministradorFiltro(string val)
        {
            AdministradorCE op;
            List<AdministradorCE> Lista = new List<AdministradorCE>();
            try
            {
                List<SP_ListarAdministradorFiltroResult> aux = AdministradorCD.ListarAdministradorFiltro(val);

                foreach (SP_ListarAdministradorFiltroResult prov in aux)
                {
                    op = new AdministradorCE(prov.IdUsuario, prov.Contrasena, prov.Cedula, prov.Nombres, prov.Apellidos, prov.Telefono, prov.Email, prov.Tipo, prov.Estado);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos filtrados de administrador", ex);
            }
            return Lista;
        }

        public bool CreateAdministrador(AdministradorCE op)
        {
            try
            {
                AdministradorCD.InsertarAdministrador(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert administrador", ex);
            }
        }

        public bool UpdateAdministrador(AdministradorCE op)
        {
            try
            {
                AdministradorCD.ModificarAdministrador(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar administrador", ex);
            }
        }

        public bool DelateAdministrador(AdministradorCE op)
        {
            try
            {
                AdministradorCD.EliminarAdministrador(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar administrador", ex);
            }
        }

        public bool ExisteAdministrador(int idAdministrador)
        {
            bool estado = false;
            List<AdministradorCE> aux = ViewAdministrador();
            foreach (AdministradorCE ob in aux)
            {
                if (ob.IdUsuario == idAdministrador)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }

        public AdministradorCE GetAdministrador(int idAdministrador)
        {
            AdministradorCE resu = null;
            List<AdministradorCE> aux = ViewAdministrador();
            foreach (AdministradorCE ob in aux)
            {
                if (ob.IdUsuario == idAdministrador)
                {
                    return ob;
                }
            }
            return resu;
        }


    }
}
