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
            string primeroLista = lista.First();

            Assert.That(primeroEsperado, Is.EqualTo(primeroLista), string.Format("El primera de la lista [{0}] y el esperado [{1}] no coinciden",primeroLista, primeroEsperado));
        }
    }
}
