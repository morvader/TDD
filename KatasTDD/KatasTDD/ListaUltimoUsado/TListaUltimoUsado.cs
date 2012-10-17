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
        #endregion

        #region publicMembers

        public TListaUltimoUsado()
        {
            _lista = new List<string>();
        }

        public void Add(string p)
        {
            //Comprobar que los elementos a introducir son validos
            comprobarElemento(p);

            //Añadir elementos al principio
            _lista.Insert(0, p);
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

       
    }
}
