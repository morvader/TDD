using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.CalculadoraDeCadenas
{
    class CalculadoraCadenas
    {
        //Delimitador por defecto
        char delimitador = ',';

        internal int Sumar(string numeros)
        {
            int resultado = 0;

            if (String.IsNullOrEmpty(numeros))
                resultado = 0;
            else
            {
                //Comprobar si hay nuevo delimitador
                if (checkNuevoDelimitador(numeros))
                {
                    //Actualizar delimitador
                    delimitador = getDelimitador(numeros);

                    //Eliminar parte de la cadena con información del delimitador ya puede dar problemas al procesar
                    numeros = numeros.Substring(numeros.IndexOf("\n"));
                }

                resultado = this.sumaValores(numeros);
            }


            return resultado;
        }

        private char getDelimitador(string numeros)
        {
            //Caracter justo después de //
            return numeros.Substring(2, 1).ToCharArray()[0];
        }

        private bool checkNuevoDelimitador(string numeros)
        {
            return numeros.StartsWith("//");
        }

        private int sumaValores(string numeros)
        {
            int resultado = 0;

            var valores = numeros.Split(this.delimitador);

            int numero;

            foreach (var valor in valores)
            {
                //Si existe algun numero negativo lanzar excepcion
                numero = int.Parse(valor);
                if (numero < 0) throw new NumeroNegativoException("No se admiten números negativos");
                //Si el numero es mayor que 1000 no lo sumamos
                if (numero > 1000) numero = 0;

                resultado += numero;
            }

            return resultado;
        }

    }
}
