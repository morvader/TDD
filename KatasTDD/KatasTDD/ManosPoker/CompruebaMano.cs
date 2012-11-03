using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.ManosPoker
{


    public class CompruebaMano
    {

        public enum ValorMano
        {
            CartaMasAlta = 0,
            Pareja,
            DoblePareja,
            Trio,
            Escalera,
            Color,
            Full,
            Poker,
            EscaleraColor
        };

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
            //Ordenar las cartas de la mano
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano).OrderBy(c=> c.Item1);

            //Al estar ordenado, comprobamos si hay 3 cartas con el mismo valor
            //Empezamos de la primera a la tercera
            //Luego segunda a la cuarta
            //Y terminamos con tercera a quinta
            if(manoTupla.ElementAt(0).Item1 == manoTupla.ElementAt(1).Item1 && manoTupla.ElementAt(0).Item1 == manoTupla.ElementAt(2).Item1)
                return ManosPokerUtils.manoTuplaToString(new Tuple<int,char>[] {manoTupla.ElementAt(0),manoTupla.ElementAt(1),manoTupla.ElementAt(2)});

            else if (manoTupla.ElementAt(1).Item1 == manoTupla.ElementAt(2).Item1 && manoTupla.ElementAt(1).Item1 == manoTupla.ElementAt(3).Item1)
                return ManosPokerUtils.manoTuplaToString(new Tuple<int, char>[] { manoTupla.ElementAt(1), manoTupla.ElementAt(2), manoTupla.ElementAt(3) });

            else if (manoTupla.ElementAt(2).Item1 == manoTupla.ElementAt(3).Item1 && manoTupla.ElementAt(2).Item1 == manoTupla.ElementAt(4).Item1)
                return ManosPokerUtils.manoTuplaToString(new Tuple<int, char>[] { manoTupla.ElementAt(2), manoTupla.ElementAt(3), manoTupla.ElementAt(4) });

            return null;

        }



        internal string[] getCartasPareja(string[] mano)
        {
            //Ordenar las cartas de la mano
            var manoTupla = ManosPokerUtils.manoStringToTupla(mano).OrderBy(c => c.Item1);

            //Comprobar dos cartas con valores iguales seguidas
            for (int i = 0; i < manoTupla.Count() -1; i++)
            {
                if (manoTupla.ElementAt(i).Item1 == manoTupla.ElementAt(i + 1).Item1)
                    return ManosPokerUtils.manoTuplaToString(new Tuple<int, char>[] { manoTupla.ElementAt(i), manoTupla.ElementAt(i + 1) });
            }

            return null;
        }

        internal bool esFull(string[] mano)
        {

            //Comprobamos si hay cartas para trío
            var cartasTrio = this.getCartasTrio(mano);
            
            //Si no hay, entonces no hay full
            if (cartasTrio == null)
                return false;

            //Con el resto de cartas, comprobamos si son pareja
            if (this.getCartasPareja(mano.Except(cartasTrio).ToArray()) == null)
                return false;

            return true;
        }

        internal string[] getCartasDoblePareja(string[] mano)
        {
           //Comprobamos si existen dos parejas

            var cartasPrimeraPareja = this.getCartasPareja(mano);

            //Comprobamos si existe al menos una pareja
            if (cartasPrimeraPareja == null)
                return null;

            //Comprobamos si existe otra pareja con el resto de cartas
            var cartasSegundaPareja = this.getCartasPareja(mano.Except(cartasPrimeraPareja).ToArray());

            if (cartasSegundaPareja == null)
                return null;

            //Devolemos las dos parejas
            return cartasPrimeraPareja.Concat(cartasSegundaPareja).ToArray();

        }

        internal string compruebaGanador(string[] manoJugador1, string[] manoJugador2)
        {
            ValorMano valorManoJugador1 = getValorManoJugador(manoJugador1);
            ValorMano valorManoJugador2 = getValorManoJugador(manoJugador2);

            //En caso de que una mano supere a la otra devolvemos directamente el ganador
            if (valorManoJugador1 > valorManoJugador2)
                return string.Format("Ganador jugador1 - {0}", Enum.GetName(typeof(ValorMano), valorManoJugador1));
            else if (valorManoJugador2 > valorManoJugador1)
                return string.Format("Ganador jugador2 - {0}", Enum.GetName(typeof(ValorMano), valorManoJugador2));
            //En caso de empates mirar el valor de la mano o el resto de cartas
            else
            {
                return this.resuelveEmpate(manoJugador1, manoJugador2, valorManoJugador1);
            }

        }

        private ValorMano getValorManoJugador(string[] mano)
        {
            //Comprobamos el valor de su mano en orden descendente
            if (this.esEscaleraColor(mano))
                return ValorMano.EscaleraColor;
            else if (this.getCartasPoker(mano) != null)
                return ValorMano.Poker;
            else if (this.esFull(mano))
                return ValorMano.Full;
            else if (this.esColor(mano))
                return ValorMano.Color;
            else if (this.esEscalera(mano))
                return ValorMano.Escalera;
            else if (getCartasTrio(mano) != null)
                return ValorMano.Trio;
            else if (getCartasDoblePareja(mano) != null)
                return ValorMano.DoblePareja;
            else if (getCartasPareja(mano) != null)
                return ValorMano.Pareja;
            return ValorMano.CartaMasAlta;
        }

        private string resuelveEmpate(string[] manoJugador1, string[] manoJugador2, ValorMano casoEmpate)
        {
            //Resolveremos los empates dependiendo del caso
            switch (casoEmpate)
            {
                case ValorMano.CartaMasAlta:
                    return this.resuelveEmpateCartaMasAlta(manoJugador1, manoJugador2);
                case ValorMano.Pareja:
                    return this.resuelveEmpatePareja(manoJugador1, manoJugador2);
                case ValorMano.DoblePareja:
                    return this.resuelveEmpateDoblePareja(manoJugador1, manoJugador2);
                case ValorMano.Trio:
                    return this.resuelveEmpateTrio(manoJugador1, manoJugador2);
                case ValorMano.Escalera:
                    return this.resuleveEmpateEscalera(manoJugador1, manoJugador2);
                case ValorMano.Color:
                    return this.resuelveEmpateColor(manoJugador1, manoJugador2);
                case ValorMano.Full:
                    return this.resuelveEmpateFull(manoJugador1, manoJugador2);                 
                case ValorMano.Poker:
                     return this.resuleveEmpatePoker(manoJugador1, manoJugador2);
                case ValorMano.EscaleraColor:
                     return this.resuleveEmpateEscalera(manoJugador1, manoJugador2);
                  
                default:
                    break;
            }

            return "Empate";
        }

        private string resuleveEmpateEscalera(string[] manoJugador1, string[] manoJugador2)
        {
            //Valor de la carta más alta de la escalera
            string cartaMasAltaJugador1 = getCartaMasAlta(manoJugador1);
            string cartaMasAltaJugador2 = getCartaMasAlta(manoJugador2);
            int valorCartaEscaleraJugador1 = ManosPokerUtils.getValorNumericoCarta(cartaMasAltaJugador1);
            int valorCartaEscaleraJugador2 = ManosPokerUtils.getValorNumericoCarta(cartaMasAltaJugador2);
            if (valorCartaEscaleraJugador1 > valorCartaEscaleraJugador2)
                return "Ganador jugador1 - CartaMasAlta :" + cartaMasAltaJugador1;
            else if (valorCartaEscaleraJugador2 > valorCartaEscaleraJugador1)
                return "Ganador jugador2 - CartaMasAlta :" + cartaMasAltaJugador2;
            else
                return "Empate";
        }

        private string resuleveEmpatePoker(string[] manoJugador1, string[] manoJugador2)
        {
            //Mirar el valor del poker
            var cartasPokerJugador1 = getCartasPoker(manoJugador1);
            var cartasPokerJugador2 = getCartasPoker(manoJugador2);

            int valorPokerJugador1 = ManosPokerUtils.getValorNumericoCarta(cartasPokerJugador1[0]);
            int valorPokerJugador2 = ManosPokerUtils.getValorNumericoCarta(cartasPokerJugador2[0]);

            if (valorPokerJugador1 > valorPokerJugador2)
                return "Ganador jugador1 - Poker";
            else  
                return "Ganador jugador2 - Poker";

            //No puede haber dos pokers con las mismas cartas
         
        }

        private string resuelveEmpateFull(string[] manoJugador1, string[] manoJugador2)
        {
            //Mirar el valor del trio
            var cartasTrioJugador1 = getCartasTrio(manoJugador1);
            var cartasTrioJugador2 = getCartasTrio(manoJugador2);

            int valorTrioJugador1 = ManosPokerUtils.getValorNumericoCarta(cartasTrioJugador1[0]);
            int valorTrioJugador2 = ManosPokerUtils.getValorNumericoCarta(cartasTrioJugador2[0]);

            if (valorTrioJugador1 > valorTrioJugador2)
                return "Ganador jugador1 - Full";
            else 
                return "Ganador jugador2 - Full";

            //No puede haber empate en los trios
        }

        private string resuelveEmpateColor(string[] manoJugador1, string[] manoJugador2)
        {
            //Mirar la carta mas alta del color
            int valorColorJugador1 = ManosPokerUtils.getValorNumericoCarta(getCartaMasAlta(manoJugador1));
            int valorColorJugador2 = ManosPokerUtils.getValorNumericoCarta(getCartaMasAlta(manoJugador2));

            if (valorColorJugador1 > valorColorJugador2)
                return "Ganador jugador1 - Color";
            else if (valorColorJugador2 > valorColorJugador1)
                return "Ganador jugador2 - Color";
            else
                return "Empate";
        }

        private string resuelveEmpateTrio(string[] manoJugador1, string[] manoJugador2)
        {

            //Mirar el valor del trio
            var cartasTrioJugador1 = getCartasTrio(manoJugador1);
            var cartasTrioJugador2 = getCartasTrio(manoJugador2);

            int valorTrioJugador1 = ManosPokerUtils.getValorNumericoCarta(cartasTrioJugador1[0]);
            int valorTrioJugador2 = ManosPokerUtils.getValorNumericoCarta(cartasTrioJugador2[0]);

            if (valorTrioJugador1 > valorTrioJugador2)
                return "Ganador jugador1 - Trio";
            else
                return "Ganador jugador2 - Trio";
            
            //No puede haber empate de trios
        }

        private string resuelveEmpateDoblePareja(string[] manoJugador1, string[] manoJugador2)
        {

            //Mirar el valor del trio
            var cartasDobleParejaJugador1 = getCartasDoblePareja(manoJugador1);
            var cartasDobleParejaJugador2 = getCartasDoblePareja(manoJugador2);

            int valorParejaAltaJugador1 = ManosPokerUtils.getValorNumericoCarta(cartasDobleParejaJugador1[2]);
            int valorParejaAltaJugador2 = ManosPokerUtils.getValorNumericoCarta(cartasDobleParejaJugador2[2]);

            if (valorParejaAltaJugador1 > valorParejaAltaJugador2)
                return "Ganador jugador1 - DoblePareja";
            else if (valorParejaAltaJugador2 > valorParejaAltaJugador1)
                return "Ganador jugador2 - DoblePareja";
            //En caso de que la pareja más alta sea igual, comprobar el valor de la segunda pareja
            else
            {
                int valorParejaBajaJugador1 = ManosPokerUtils.getValorNumericoCarta(cartasDobleParejaJugador1[0]);
                int valorParejaBajaJugador2 = ManosPokerUtils.getValorNumericoCarta(cartasDobleParejaJugador2[0]);

                if (valorParejaBajaJugador1 > valorParejaBajaJugador2)
                    return "Ganador jugador1 - DoblePareja";
                else if (valorParejaBajaJugador2 > valorParejaBajaJugador1)
                    return "Ganador jugador2 - DoblePareja";
                //En caso de empatar en la segunda pareja comprobamos el valor de la carta que sobra
                else
                {
                    int valorCartaSobranteJugador1 = ManosPokerUtils.getValorNumericoCarta(manoJugador1.Except(cartasDobleParejaJugador1).ToArray()[0]);
                    int valorCartaSobranteJugador2 = ManosPokerUtils.getValorNumericoCarta(manoJugador2.Except(cartasDobleParejaJugador2).ToArray()[0]);
                    if (valorCartaSobranteJugador1 > valorCartaSobranteJugador2)
                        return "Ganador jugador1 - CartaMasAlta : " + manoJugador1.Except(cartasDobleParejaJugador1).ToArray()[0];
                    else if (valorCartaSobranteJugador2 > valorCartaSobranteJugador1)
                        return "Ganador jugador2 - CartaMasAlta : " + manoJugador2.Except(cartasDobleParejaJugador2).ToArray()[0];
                    //En caso de empatar en la segunda pareja comprobamos el valor de la carta que sobra
                    else
                        return "Empate";
                }
            }
        }

        private string resuelveEmpatePareja(string[] manoJugador1, string[] manoJugador2)
        {
            //Mirar el valor de la pareja
            var cartasParejaJugador1 = getCartasPareja(manoJugador1);
            var cartasParejaJugador2 = getCartasPareja(manoJugador2);

            int valorParejaJugador1 = ManosPokerUtils.getValorNumericoCarta(cartasParejaJugador1[0]);
            int valorParejaJugador2 = ManosPokerUtils.getValorNumericoCarta(cartasParejaJugador2[0]);

            if (valorParejaJugador1 > valorParejaJugador2)
                return "Ganador jugador1 - Pareja";
            else if (valorParejaJugador2 > valorParejaJugador1)
                return "Ganador jugador2 - Pareja";
            //En caso de que la pareja sea igual, comprobar el valor del resto de cartas
            else
            {
                //Ordenamos el resto de cartas por su valor (De mayor a menor)
                var restoCartasJugador1 = ManosPokerUtils.manoStringToTupla(manoJugador1.Except(cartasParejaJugador1).ToArray()).OrderByDescending(c=> c.Item1);
                var restoCartasJugador2 = ManosPokerUtils.manoStringToTupla(manoJugador2.Except(cartasParejaJugador2).ToArray()).OrderByDescending(c => c.Item1);

                int valorCartaJugador1, valorCartaJugador2;
                for (int i = 0; i < restoCartasJugador1.Count(); i++)
                {
                    valorCartaJugador1 = restoCartasJugador1.ElementAt(i).Item1;
                    valorCartaJugador2 = restoCartasJugador2.ElementAt(i).Item1;
                    if(valorCartaJugador1 > valorCartaJugador2)
                        return "Ganador jugador1 - CartaMasAlta : " + ManosPokerUtils.getRepresentacionCarta(valorCartaJugador1) + restoCartasJugador1.ElementAt(i).Item2 ; 
                    if(valorCartaJugador2 > valorCartaJugador1)
                        return "Ganador jugador2 - CartaMasAlta : " + ManosPokerUtils.getRepresentacionCarta(valorCartaJugador2) + restoCartasJugador2.ElementAt(i).Item2 ; 
                }

                return "Empate";
            }
        }

        private string resuelveEmpateCartaMasAlta(string[] manoJugador1, string[] manoJugador2)
        {

            //Ordenamos cartas por su valor (de mayor a menor)
            var cartasJugador1 = ManosPokerUtils.manoStringToTupla(manoJugador1.ToArray()).OrderByDescending(c => c.Item1);
            var cartasJugador2 = ManosPokerUtils.manoStringToTupla(manoJugador2.ToArray()).OrderByDescending(c => c.Item1);

            int valorCartaJugador1, valorCartaJugador2;
            for (int i = 0; i < cartasJugador1.Count(); i++)
            {
                valorCartaJugador1 = cartasJugador1.ElementAt(i).Item1;
                valorCartaJugador2 = cartasJugador2.ElementAt(i).Item1;
                if (valorCartaJugador1 > valorCartaJugador2)
                    return "Ganador jugador1 - CartaMasAlta : " + ManosPokerUtils.getRepresentacionCarta(valorCartaJugador1) + cartasJugador1.ElementAt(i).Item2;
                if (valorCartaJugador2 > valorCartaJugador1)
                    return "Ganador jugador2 - CartaMasAlta : " + ManosPokerUtils.getRepresentacionCarta(valorCartaJugador2) + cartasJugador2.ElementAt(i).Item2;
            }

            return "Empate";
        }
    }
}
