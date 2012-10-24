using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasTDD.ListaUltimoUsado
{
    class TListaUltimoUsado: IEnumerable<string>
    {
        #region privateMembers
        //Internamente implementamos una lista
        List<string> _lista;

        //En principio sin limite 
        private int tamañoMaximo = int.MaxValue;

        #endregion

        #region publicMembers

        public TListaUltimoUsado()
        {
            _lista = new List<string>();
        }

        public TListaUltimoUsado(int t)
        {
            tamañoMaximo = t;
            _lista = new List<string>(t);
        }

        public void Add(string p)
        {
            //Comprobar que los elementos a introducir son validos
            comprobarElemento(p);

            //Elimina duplicados
            eliminaDuplicados(p);

            //Si superamos el tamaño maximo entonces eliminar el último de la lista
            if (_lista.Count == tamañoMaximo)
                _lista.RemoveAt(_lista.Count - 1);

            //Añadir elementos al principio
            _lista.Insert(0, p);
        }

        private void eliminaDuplicados(string p)
        {
            _lista.RemoveAll(e => e.Equals(p));
        }

        private void comprobarElemento(string p)
        {
            if (string.IsNullOrEmpty(p)) throw new ArgumentException("No se permiten inserciones vacias");
        }

        #endregion

        #region privateMembers

        #endregion


        #region IEnumerable<string> Members

        public IEnumerator<string> GetEnumerator()
        {
            return _lista.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion



        internal string elemento(int indice)
        {
            try
            {
                return this._lista.ElementAt(indice);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("Fuera de rango", ex) ;
            }
           
        }
    }
}
