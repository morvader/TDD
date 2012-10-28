using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.ManosPoker
{


    public class CompruebaMano
    {
        public enum ValorFiguras { J = 11, Q = 12, K = 13, A = 14 };

        public enum PaloCarta { T, D, C, P };


        internal bool esEscaleraColor(string[] mano)
        {
            //Comprobar que todas las cartar son consecutivas y del mismo palo

            //REFACTORIZAR A ESCALERA + COLOR

            bool esEscalera = this.esEscalera(mano);
            if (!esEscalera) return false;
            bool esColor = this.esColor(mano);

            return esColor;

            #region antesRefactor
            ////Pamos a lista de tuplas para que sea más comodo
            //var manoTupla = manoStringToTupla(mano);
            ////Ordenar por valor
            //var manoOrdenada = manoTupla.OrderBy(c => c.Item1);

            ////Comprobamos mismo palo
            //char palo = manoOrdenada.First().Item2;
            //bool mismoPalo = manoOrdenada.All(c => c.Item2 == palo);
            //if (!mismoPalo) return false;

            ////Comprobamos orden
            //bool ordenada = true;
            //for (int i = 1; i < manoOrdenada.Count(); i++)
            //{
            //    if (manoOrdenada.ElementAt(i).Item1 != manoOrdenada.ElementAt(i - 1).Item1 +1)
            //        ordenada = false;
            //}

            //return ordenada;
            #endregion
            
            
        }

        internal string getCartaMasAlta(string[] mano)
        {
            string cartaMasAlta = mano[0];
            int valorNumericoCartaMasAlta = getValorNumericoCarta(cartaMasAlta);
            int valorNumericoCarta;
          
            foreach (string carta in mano)
            {    
                valorNumericoCarta = getValorNumericoCarta(carta);
                if (valorNumericoCarta > valorNumericoCartaMasAlta)
                {
                    cartaMasAlta = carta;
                    valorNumericoCartaMasAlta = valorNumericoCarta;
                }
            }
            return cartaMasAlta;
        }

        private int getValorNumericoCarta(string carta)
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

        private char getPaloCarta(string carta)
        {
            return carta.Substring(carta.Length - 1).First();
        }

        private Tuple<int, char>[] manoStringToTupla(string[] mano)
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

        internal bool esPoker(string[] mano)
        {
            //Comprobar 4 cartas con el mismo valor
            var manoTupla = manoStringToTupla(mano);

            bool poker = false;

            //Al tener que ser 4 cartas igual podemos comprobar si exiten 4 cartas igual a la primera o a la segunda

            //Primera carta
            int valorCarta = manoTupla.First().Item1;

            int cartasIguales= manoTupla.Count(c => c.Item1 == valorCarta);
            if (cartasIguales == 4) poker = true;

            //Segunda carta
            valorCarta = manoTupla.ElementAt(1).Item1;
            cartasIguales = manoTupla.Count(c => c.Item1 == valorCarta);
            if (cartasIguales == 4) poker = true;

            return poker;
            
        }

        internal bool esColor(string[] mano)
        {
            //Comprobar que todas las cartas son del mismo palo
            var manoTupla = manoStringToTupla(mano);

            char palo = manoTupla.First().Item2;

            bool color = manoTupla.All(c => c.Item2 == palo);

            return color;
        }

        internal bool esEscalera(string[] mano)
        {
            var manoTupla = manoStringToTupla(mano);
            //Ordenar por valor
            var manoOrdenada = manoTupla.OrderBy(c => c.Item1);

            //Comprobamos comsecutivos
            bool ordenada = true;
            for (int i = 1; i < manoOrdenada.Count(); i++)
            {
                if (manoOrdenada.ElementAt(i).Item1 != manoOrdenada.ElementAt(i - 1).Item1 + 1)
                    ordenada = false;
            }

            return ordenada;

        }
    }
}
