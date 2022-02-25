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
    public class PromocionLN
    {
        public List<PromocionesCE> ViewPromociones()
        {
            PromocionesCE op;
            List<PromocionesCE> Lista = new List<PromocionesCE>();
            try
            {
                List<Promociones> aux = PromocionesCD.ListarPromociones();
                foreach (Promociones prov in aux)
                {
                    op = new PromocionesCE(prov.IdPromocion, prov.Tipo,(double) prov.Porcentaje);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar datos del Promociones", ex);
            }

            return Lista;
        }

        public List<PromocionesCE> ViewPromocionesFiltro(string val)
        {
            PromocionesCE op;
            List<PromocionesCE> Lista = new List<PromocionesCE>();
            try
            {
                List<SP_ListarPromocionesFiltroResult> aux = PromocionesCD.ListarPromocionesFiltro(val);

                foreach (SP_ListarPromocionesFiltroResult prov in aux)
                {
                    op = new PromocionesCE(prov.IdPromocion, prov.Tipo, (double)prov.Porcentaje);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Mostrar datos filtrados de promociones", ex);
            }
            return Lista;
        }

        public bool CreatePromociones(PromocionesCE op)
        {
            try
            {
                PromocionesCD.InsertarPromocion(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert promociones", ex);
            }
        }

        public bool UpdatePromociones(PromocionesCE op)
        {
            try
            {
                PromocionesCD.ModificarProveedor(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar promociones", ex);
            }
        }

        public bool DelatePromociones(PromocionesCE op)
        {
            try
            {
                PromocionesCD.EliminarPromocion(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar promociones", ex);
            }
        }

        public bool ExistePromocion(int idPromocion)
        {
            bool estado = false;
            List<PromocionesCE> aux = ViewPromociones();
            foreach (PromocionesCE ob in aux)
            {
                if (ob.IdPromocion == idPromocion)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }

        public PromocionesCE GetPromocion(int idPromocion)
        {
            PromocionesCE resu = null;
            List<PromocionesCE> aux = ViewPromociones();
            foreach (PromocionesCE ob in aux)
            {
                if (ob.IdPromocion == idPromocion)
                {
                    return ob;
                }
            }
            return resu;
        }



    }
}
