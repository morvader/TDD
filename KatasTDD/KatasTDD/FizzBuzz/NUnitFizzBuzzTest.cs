using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KatasTDD.FizzBuzz
{
    [TestFixture]
    public class NUnitFizzBuzzTest
    {

        #region Setup
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
        [TestCase(0,Result = true)]
        [TestCase(-2, Result = false)]
        [TestCase(3, Result = true)]
        [TestCase(15, Result = true)]
        [TestCase(5, Result = false)]
        public bool TestNumeroFizz(int numero)
        {
            var fizzBuzz = new MyFizzBuzz();

            return  MyFizzBuzz.checkFizzNumber(numero);
           
        }

        [Test]
        [TestCase(0, Result = true)]
        [TestCase(-2, Result = false)]
        [TestCase(5, Result = true)]
        [TestCase(15, Result = true)]
        [TestCase(3, Result = false)]
        public bool TestNumeroBuzz(int numero)
        {
            var fizzBuzz = new MyFizzBuzz();

            return MyFizzBuzz.checkBuzzNumber(numero);

        }


        [Test]
        public void getFizzBuzzHasta10()
        {
            var fizzBuzz = new MyFizzBuzz();

            string[] resultado = MyFizzBuzz.getValues(10);
            string[] esperado = new string[] {"1","2","Fizz", "4", "Buzz","Fizz","7","8","Fizz","Buzz"};

            CollectionAssert.AreEqual(esperado, resultado);
        }

        [Test]
        public void getFizzBuzzHasta15()
        {
            var fizzBuzz = new MyFizzBuzz();

            string[] resultado = MyFizzBuzz.getValues(15);
            string[] esperado = new string[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz","11","Fizz","13","14","FizzBuzz" };

            CollectionAssert.AreEqual(esperado, resultado);
        }
    }
}
