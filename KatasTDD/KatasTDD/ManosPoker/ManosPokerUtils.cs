using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.ManosPoker
{
    public class ManosPokerUtils
    {
        public enum ValorFiguras { J = 11, Q = 12, K = 13, A = 14 };

        public enum PaloCarta { T, D, C, P };

        public static string getRepresentacionCarta(int valor)
        {
            if (valor <= 10)
                return valor.ToString();
            else
                return Enum.GetName(typeof(ValorFiguras), valor);
        }

        public static int getValorNumericoCarta(string carta)
        {
            int valorNumerico;
            char cadenaValor;
            //Si la carta tiene caracter es un 10X
            //En caso contrario el valor es el primere caracter
            if (carta.Length == 3)
                valorNumerico = 10;
            else
            {
                //Puede ser un numero o una figura
                cadenaValor = carta[0];
                //Si es una figura convertimos
                if (char.IsLetter(cadenaValor))
                    valorNumerico = (int)Enum.Parse(typeof(ValorFiguras), cadenaValor.ToString());
                else
                    valorNumerico = int.Parse(cadenaValor.ToString());
            }

            return valorNumerico;
        }

        public static char getPaloCarta(string carta)
        {
            return carta.Substring(carta.Length - 1).First();
        }

        public static Tuple<int, char>[] manoStringToTupla(string[] mano)
        {
            List<Tuple<int, char>> tuplaMano = new List<Tuple<int, char>>();
            char palo;
            int valorNumerico;
            foreach (string carta in mano)
            {
                palo = getPaloCarta(carta);
                valorNumerico = getValorNumericoCarta(carta);
                tuplaMano.Add(new Tuple<int, char>(valorNumerico, palo));
            }

            return tuplaMano.ToArray();
        }

        public static string[] manoTuplaToString(Tuple<int, char>[] mano)
        {
            var manoString = new List<string>();
            string representacionCarta; 

            foreach (var carta in mano)
            {
                representacionCarta = getRepresentacionCarta(carta.Item1);
                manoString.Add(representacionCarta + carta.Item2);
            }

            return manoString.ToArray();
        }
    }
}
