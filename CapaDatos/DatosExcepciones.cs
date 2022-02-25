using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosExcepciones : ApplicationException
    {
        public DatosExcepciones(string men, Exception original)
            : base(men, original)
        {

        }

        public DatosExcepciones(string men)
            :base(men)
        {

        }
    }
}
