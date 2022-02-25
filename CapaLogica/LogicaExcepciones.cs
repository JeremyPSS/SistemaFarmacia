using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaExcepciones:ApplicationException
    {
        public LogicaExcepciones(string men, Exception original)
            :base(men, original)
        {

        }

        public LogicaExcepciones(string men)
            :base(men)
        {

        }
    }
}
