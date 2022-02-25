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
    public class MedicamentoLN
    {
        public List<MedicamentoCE> ViewMedicamento()
        {
            MedicamentoCE op;
            List<MedicamentoCE> Lista = new List<MedicamentoCE>();
            try
            {
                List<Medicamento> aux = MedicamentoCD.ListarMedicamento();
                foreach (Medicamento prov in aux)
                {
                    op = new MedicamentoCE(prov.IdMedicamento, prov.Nombre, prov.Enpaque, prov.Cantidad, prov.Presentacion, prov.FechaVencimiento, prov.viaAdministracion, prov.Almacenamiento,prov.Especificacion,(double)prov.Precio,prov.IdPromocion);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar datos del Medicamento", ex);
            }

            return Lista;
        }


        public List<MedicamentoCE> ViewMedicamentoFiltro(string valor)
        {
            MedicamentoCE op;
            List<MedicamentoCE> Lista = new List<MedicamentoCE>();
            try
            {
                List<SP_ListarMedicamentoFiltroResult> aux = MedicamentoCD.ListarMedicamentoFiltro(valor);
                foreach (SP_ListarMedicamentoFiltroResult prov in aux)
                {
                    op = new MedicamentoCE(prov.IdMedicamento,prov.Nombre,prov.Enpaque,prov.Cantidad,prov.Presentacion,prov.FechaVencimiento,prov.viaAdministracion,prov.Almacenamiento,prov.Especificacion,(double)prov.Precio,prov.IdPromocion);
                    Lista.Add(op);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al mostrar datos filtrados del Medicamento", ex);
            }

            return Lista;
        }

        public bool CreateMedicamento(MedicamentoCE op)
        {
            try
            {
                MedicamentoCD.InsertarMedicamento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert datos del Medicamento", ex);
            }
        }

        public bool UpdateMedicamento(MedicamentoCE op)
        {
            try
            {
                MedicamentoCD.ModificarMedicamento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error update Medicamento", ex);
            }
        }

        public bool DeleteMedicamento(MedicamentoCE op)
        {
            try
            {
                MedicamentoCD.EliminarMedicamento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error delete Medicamento", ex);
            }
        }

        public bool ExisteMedicamento(int idMedicamento)
        {
            bool estado = false;
            List<MedicamentoCE> aux = ViewMedicamento();
            foreach (MedicamentoCE ob in aux)
            {
                if (ob.IdMedicamento == idMedicamento)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }

        public MedicamentoCE GetMedicamento(int idMedicamento)
        {
            MedicamentoCE resu = null;
            List<MedicamentoCE> aux = ViewMedicamento();
            foreach (MedicamentoCE ob in aux)
            {
                if (ob.IdMedicamento == idMedicamento)
                {
                    return ob;
                }
            }
            return resu;
        }

        public List<MedicamentoCE> ExpiredMedications()
        {
            List<MedicamentoCE> lista = new List<MedicamentoCE>();
            foreach(MedicamentoCE ob in ViewMedicamento())
            {
                int resul = DateTime.Compare(ob.FechaVencimiento, DateTime.Now);
                if(resul < 0)
                {
                    lista.Add(ob);
                }
            }
            return lista;
        }

        public List<MedicamentoCE> FewMedications()
        {
            List<MedicamentoCE> lista = new List<MedicamentoCE>();
            foreach (MedicamentoCE ob in ViewMedicamento())
            {
                if (ob.Cantidad <20)
                {
                    lista.Add(ob);
                }
            }
            return lista;
        }

        public List<MedicamentoCE> MenorMedications()
        {
            List<MedicamentoCE> lista = new List<MedicamentoCE>();
            foreach (MedicamentoCE ob in ViewMedicamento())
            {
                if (ob.Cantidad < 20)
                {
                    lista.Add(ob);
                }
            }
            return lista;
        }


    }
}
