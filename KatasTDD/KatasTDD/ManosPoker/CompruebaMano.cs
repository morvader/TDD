using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.ManosPoker
{


    public class CompruebaMano
    {
        


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
            int valorNumericoCartaMasAlta = ManosPokerUtils.getValorNumericoCarta(cartaMasAlta);
            int valorNumericoCarta;
          

            foreach (string carta in mano)
            {
                valorNumericoCarta = ManosPokerUtils.getValorNumericoCarta(carta);
                if (valorNumericoCarta > valorNumericoCartaMasAlta)
                {
                    cartaMasAlta = carta;
                    valorNumericoCartaMasAlta = valorNumericoCarta;
                }
            }
            return cartaMasAlta;
        }

      

        internal bool esPoker(string[] mano)
        {
            //Comprobar 4 cartas con el mismo valor
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano);

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
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano);

            char palo = manoTupla.First().Item2;

            bool color = manoTupla.All(c => c.Item2 == palo);

            return color;
        }

        internal bool esEscalera(string[] mano)
        {
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano);
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

        internal string[] getCartasPoker(string[] mano)
        {
            var cartasPoker = new List<string>();
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano);

            //Primera carta
            int valorCarta = manoTupla.First().Item1;

            var cartasIguales = manoTupla.Where(c => c.Item1 == valorCarta);

            if (cartasIguales.Count() == 4)
               return ManosPokerUtils.manoTuplaToString(cartasIguales.ToArray());
            
            //Probamos con la segunda carta
            valorCarta = manoTupla.ElementAt(1).Item1;

            cartasIguales = manoTupla.Where(c => c.Item1 == valorCarta);

            if (cartasIguales.Count() == 4)
                return ManosPokerUtils.manoTuplaToString(cartasIguales.ToArray());


            return null;
        }

        internal string[] getCartasTrio(string[] mano)
        {
            var cartasTrio = new List<string>();

            //Ordenar las cartas de la mano
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano).OrderBy(c=> c.Item1);

            //Buscamos los trios empezando por la primera carta hasta la tercera

            //Primera carta
            int valorCarta = manoTupla.First().Item1;

            var cartasIguales = manoTupla.Where(c => c.Item1 == valorCarta);

            if (cartasIguales.Count() == 3)
                return ManosPokerUtils.manoTuplaToString(cartasIguales.ToArray());

            //Pasamos a la segunda carta
            valorCarta = manoTupla.ElementAt(1).Item1;

            cartasIguales = manoTupla.Where(c => c.Item1 == valorCarta);

            if (cartasIguales.Count() == 3)
                return ManosPokerUtils.manoTuplaToString(cartasIguales.ToArray());

            //TODO : Refactorizar a getCartasIguales(posicion, NumeroIguales)

            //Pasamos a la tercera carta
            valorCarta = manoTupla.ElementAt(2).Item1;

            cartasIguales = manoTupla.Where(c => c.Item1 == valorCarta);

            if (cartasIguales.Count() == 3)
                return ManosPokerUtils.manoTuplaToString(cartasIguales.ToArray());

            return null;
        }

      
    }
}
