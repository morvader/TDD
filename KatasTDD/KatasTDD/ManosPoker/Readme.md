﻿Introducción:

 Una baraja de poker se compone de 52 cartas.
	- Hay 4 palos: Corazones, diamantes, picas y tréboles (C,D,P,T)
	- Por cada palo, las cartas van del 2 hasta el As (2,3,4,5,6,7,8,9,10,J,Q,K,A)
 Una mano de poker consta de 5 cartas. A continuación, se enumera el valor de las mismas de menor a mayor:
 
 -CARTA MÁS ALTA: Cuando la mano no concuerda con ninguna de las categorías superiores
   se toma el valor de la carta más alta.
 - PAREJA: 2 de las 5 cartas de la mano tienen el mismo valor.
   Cuando ambas manos tiene pareja gana la que tenga el valos más alto.
   En caso de empate, la mano la decide el resto de cartas que no forman la pareja.
 - DOBLE PAREJA: La mano contiene dos parejas distintas.
   Cuando ambas manos tienen dobles parejas predonima el valos de la pareja más alta y si ambas coinciden, se pasa a la siguiente pareja.
   En caso de empate, gana el valor más alto de la carta restante.
 - TRIO: 3 cartas de la mano tienes el mismo valor.
   Cuando ambas manos tienen trio gana el valor más alto. 
   En caso de empare se mira el resto de cartas.
 - ESCALERA: Las 5 cartas de la mano tienen valores consecutivos.
   Gana la escalera con la carte de mayor valor más alta.
 - COLOR: Las 5 cartas de la mano son del mismo palo.
   Si ambas manos tienen color, gana la que tenga la carta más alta.
 - FULL: TRIO + PAREJA. Prodimona el valor del trio.
 - POKER: 4 cartas con el mismo valor.
 - ESCALERA DE COLOR: ESCALERA del mismo palo.

 - Instrucciones:
 Construir un programa que dadas las manos de dos jugadores indique el ganador y por qué razón:
 Ejemplos:

 Input: Black: 2T 3D 5P 9T KD White: 2T 3C 4P 8T AC
 Output: White wins - high card: Ace 
 
 Input: Black: 2C 4P 4T 2D 4C White: 2P 8P AP QP 3P
 Output: White wins - flush 

 Input: Black: 2C 3D 5P 9T KD White: 2T 3C 4P 8T KC
 Output: Black wins - high card: 9

 Input: Black: 2C 3D 5P 9T KD White: 2D 3C 5T 9P KC
 Output: Tie
