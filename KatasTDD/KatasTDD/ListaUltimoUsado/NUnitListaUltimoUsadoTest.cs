using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KatasTDD.ListaUltimoUsado
{
    [TestFixture]
    public class NUnitListaUltimoUsadoTest
    {
        [TestFixtureSetUp]
        public void SetupMethods()
        {
        }
        [TestFixtureTearDown]
        public void TearDownMethods()
        {
        }
        [SetUp]
        public void SetupTest()
        {
        }
        [TearDown]
        public void TearDownTest()
        {
        }
        [Test]
        public void inicialmenteVacia()
        {
            TListaUltimoUsado lista = new TListaUltimoUsado();

            //Utilizamos Count puesto que asumimos que no tiene errores
            //No sería correcto utilizar métodos desarrollados por nosotros

            Assert.That(lista.Count(), Is.EqualTo(0), string.Format("El tamño inicial debe ser 0 cuando en realidad es: [{0}]", lista.Count()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage="No se permiten inserciones vacias")]
        [TestCase("")]
        [TestCase(null)]
        public void NoInsercionesVacias(string elemento)
        {
            TListaUltimoUsado lista = new TListaUltimoUsado();
            lista.Add(elemento);
        }

        [Test]
        public void comprobarPrimerElementoEsUltimoInsertado()
        {
            var lista = new TListaUltimoUsado();
            lista.Add("Primero");
            lista.Add("Segundo");
            lista.Add("Tercero");

            string primeroEsperado = "Tercero";

            //Utilizamos First puesto que no sería correcto utilziar un método desarrollado por nosotros
            string primeroLista = lista.First();

            Assert.That(primeroEsperado, Is.EqualTo(primeroLista), string.Format("El primera de la lista [{0}] y el esperado [{1}] no coinciden",primeroLista, primeroEsperado));
        }

        [Test]
        [TestCase(0, Result = "Tercero")]
        [TestCase(1, Result = "Segundo")]
        [TestCase(2, Result = "Primero")]
        public string comprobarAccesoPorIndice(int indice)
        {
            var lista = new TListaUltimoUsado();
            lista.Add("Primero");
            lista.Add("Segundo");
            lista.Add("Tercero");

            return lista.elemento(indice);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException), ExpectedMessage = "Fuera de rango")]
        [TestCase(-1)]
        [TestCase(5)]
        [TestCase(12)]
        public string comprobarExcepcionFueraDeRango(int indice)
        {
            var lista = new TListaUltimoUsado();
            lista.Add("Primero");
            lista.Add("Segundo");
            lista.Add("Tercero");

            return lista.elemento(indice);
        }

        [Test]
        //Los elementos sólo pueden existir una vez
        [TestCase("Primero", Result= 1)]
        [TestCase("Segundo", Result = 1)]
        [TestCase("Tercero", Result = 1)]
        [TestCase("Cuarto", Result = 1)]
        [TestCase("Quinto", Result = 1)]
        public int soloUnaAparicionAlInsetarDuplicado(string nuevoElemento)
        {
            var lista = new TListaUltimoUsado();
            lista.Add("Primero");
            lista.Add("Segundo");
            lista.Add("Tercero");
            lista.Add("Cuarto");

            lista.Add(nuevoElemento);

            //Contamos el número de veces que está el nuevo elemento en la lista
            return lista.Count(e => e.Equals(nuevoElemento));
        }

        [Test]
        [TestCase("Primero", Result = "Primero")]
        [TestCase("Segundo", Result = "Segundo")]
        [TestCase("Tercero", Result = "Tercero")]
        [TestCase("Cuarto", Result = "Cuarto")]
        [TestCase("Quinto", Result = "Quinto")]
        public string comprobarInsercionesDuplicadasAlPrincipio(string nuevoElemento)
        {
            var lista = new TListaUltimoUsado();
            lista.Add("Primero");
            lista.Add("Segundo");
            lista.Add("Tercero");
            lista.Add("Cuarto");

            lista.Add(nuevoElemento);

            //Devolvemos el primero de la lista
            return lista.First();
        }

        [Test]
        public void comprobarElementosConTamañoMaximoLista()
        {
            var lista = new TListaUltimoUsado(3);

            lista.Add("Primero");
            lista.Add("Segundo");
            lista.Add("Tercero");

            //Al introducir el cuarto, se elimina el primero
            lista.Add("Cuarto");

            CollectionAssert.AreEqual(lista, new List<string>() { "Cuarto","Tercero", "Segundo"});
                
        }
    }
}
