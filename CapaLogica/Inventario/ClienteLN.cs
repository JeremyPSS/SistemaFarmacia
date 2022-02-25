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
    public class ClienteLN
    {
        public List<ClienteCE> ViewCliente()
        {
            ClienteCE op;
            List<ClienteCE> Lista = new List<ClienteCE>();
            try
            {
                List<Cliente> aux = ClienteCD.ListarCliente();
                foreach (Cliente prov in aux)
                {
                    op = new ClienteCE(prov.IdCliente, prov.Nombre, prov.Apellido, prov.Correo, prov.Cedula);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos de cliente", ex);
            }
            return Lista;
        }


        public List<ClienteCE> ViewClienteFiltro(string val)
        {
            ClienteCE op;
            List<ClienteCE> Lista = new List<ClienteCE>();
            try
            {
                List<SP_ListarClienteFiltroResult> aux = ClienteCD.ListarClienteFiltro(val);

                foreach (SP_ListarClienteFiltroResult prov in aux)
                {
                    op = new ClienteCE(prov.IdCliente, prov.Nombre, prov.Apellido, prov.Correo, prov.Cedula);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos filtrados de cliente", ex);
            }
            return Lista;
        }

        public bool CreateCliente(ClienteCE op)
        {
            try
            {
                ClienteCD.InsertarCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert cliente", ex);
            }
        }

        public bool UpdateCliente(ClienteCE op)
        {
            try
            {
                ClienteCD.ModificarCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar cliente", ex);
            }
        }

        public bool DelateCliente(ClienteCE op)
        {
            try
            {
                ClienteCD.EliminarCliente(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar cliente", ex);
            }
        }


        public ClienteCE GetCliente(int idCliente)
        {
            ClienteCE resu = null;
            List<ClienteCE> aux = ViewCliente();
            foreach (ClienteCE ob in aux)
            {
                if (ob.IdCliente == idCliente)
                {
                    return ob;
                }
            }
            return resu;
        }

    }
}
