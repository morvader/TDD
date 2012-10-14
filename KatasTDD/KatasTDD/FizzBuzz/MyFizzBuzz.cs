using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.FizzBuzz
{
    class MyFizzBuzz
    {
        internal static string[] getValues(int valorLimite)
        {
            List<string> resultado = new List<string>();

            string valorIntroducir;

            for (int i = 1; i <= valorLimite; i++)
            {
                valorIntroducir = i.ToString();

                if (i % 3 == 0 && i % 5 == 0)
                    valorIntroducir = "FizzBuzz";
                else if (i % 3 == 0)
                    valorIntroducir = "Fizz";
                else if (i % 5 == 0)
                    valorIntroducir = "Buzz";
                
                resultado.Add(valorIntroducir);
            }

            return resultado.ToArray();
        }
    }
}
