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
                //Inicializar a cadena vacia
                valorIntroducir = string.Empty;
                
                
                if (checkFizzNumber(i)) 
                    //Concatenar Fizz
                    valorIntroducir = "Fizz";
                if (checkBuzzNumber(i))
                    //Concatenar Buzz
                    valorIntroducir += "Buzz";
                //Si sigue siendo la cadena vacía es que el numero no es Fizz ni Buzz
                //Por lo que se introduce el número en sí
                if(string.IsNullOrEmpty(valorIntroducir))
                    valorIntroducir = i.ToString();

                resultado.Add(valorIntroducir);
            }

            return resultado.ToArray();
        }

        internal static bool checkFizzNumber(int numero)
        {
            return numero % 3 == 0;
        }

        internal static bool checkBuzzNumber(int numero)
        {
            return numero % 5 == 0;
        }
    }
}
