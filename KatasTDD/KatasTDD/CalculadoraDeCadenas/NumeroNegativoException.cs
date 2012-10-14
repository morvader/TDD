using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.CalculadoraDeCadenas
{
    class NumeroNegativoException : Exception
    {
        public NumeroNegativoException(string message)
            : base(message)
        {
        }
    }
}
