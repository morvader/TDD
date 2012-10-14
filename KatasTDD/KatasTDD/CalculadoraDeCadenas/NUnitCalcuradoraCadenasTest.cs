using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KatasTDD.CalculadoraDeCadenas
{
    [TestFixture]
    public class NUnitCalcuradoraCadenasTest
    {
        #region SetUp
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
        #endregion
        
        [Test]
        [TestCase ("", Result= 0)]
        [TestCase(null, Result = 0)]
        public int SumarCadenaVacia(string numeros)
        {
            var calculadora = new CalculadoraCadenas();
            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("0",Result = 0)]
        [TestCase("5", Result = 5)]
        [TestCase ("12", Result = 12)]
        public int SumarUnValor(string numeros)
        {
            var calculadora = new CalculadoraCadenas();

            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("0,0", Result = 0)]
        [TestCase("5,4", Result = 9)]
        [TestCase("12,25", Result = 37)]
        public int SumarDosValores(string numeros)
        {
            var calculadora = new CalculadoraCadenas();

            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("0,0", Result = 0)]
        [TestCase("5", Result = 5)]
        [TestCase("12,25,0", Result = 37)]
        [TestCase("12,25,11", Result = 48)]
        [TestCase("0,3", Result = 3)]
        public int SumarVariosValores(string numeros)
        {
            var calculadora = new CalculadoraCadenas();

            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("0\n,0", Result = 0)]
        [TestCase("5\n", Result = 5)]
        [TestCase("12\n,25,0", Result = 37)]
        [TestCase("12,25\n,11", Result = 48)]
        [TestCase("0,3\n", Result = 3)]
        public int SumarVariosValoresConSaltosLinea(string numeros)
        {
            var calculadora = new CalculadoraCadenas();
            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("//;\n1;2", Result = 3)]
        [TestCase("//;\n0", Result = 0)]
        [TestCase("//;\n11;22", Result = 33)]
        [TestCase("//;\n1;2;5", Result = 8)]
        [TestCase("//;\n11;22;33", Result = 66)]
        [TestCase("//;\n11\n;22;33", Result = 66)]
        [TestCase("//;\n1\n;4", Result = 5)]
        [TestCase("//$\n11$22$33", Result = 66)]
        public int SumarVariosValoresConSaltosLineaYNuevoDelimitador(string numeros)
        {
            var calculadora = new CalculadoraCadenas();
            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("-1", Result = -1)]
        [TestCase("0,-13", Result = 0)]
        [TestCase("4\n,-45", Result = 0)]
        [TestCase("2,4,-45", Result = 0)]
        [TestCase("//;\n1\n;-4", Result = 5)]
        [TestCase("//$\n-11\n$4", Result = 5)]
        [ExpectedException(typeof(NumeroNegativoException), ExpectedMessage = "No se admiten números negativos")]
        public int ExcepcionParaValoresNegativos(string numeros)
        {
            var calculadora = new CalculadoraCadenas();
            return calculadora.Sumar(numeros);
        }

        [Test]
        [TestCase("0\n,0", Result = 0)]
        [TestCase("1001\n", Result = 0)]
        [TestCase("12\n,1225,0", Result = 12)]
        [TestCase("12,1225\n,11", Result = 23)]
        [TestCase("1110,3\n", Result = 3)]
        public int IgnorarNumerosMayoresAMil(string numeros)
        {
            var calculadora = new CalculadoraCadenas();
            return calculadora.Sumar(numeros);
        }
    }
}
