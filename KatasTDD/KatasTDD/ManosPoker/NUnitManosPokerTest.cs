using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KatasTDD.ManosPoker
{
    [TestFixture]
    public class NUnitManosPokerTest
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
        [TestCase(false, new string[] { "2T", "4C", "9P", "5D", "10T" })]
        [TestCase(false, new string[] { "2T", "3C", "4P", "5D", "6T" })]
        [TestCase(true, new string[] { "3T", "4T", "5T", "6T", "7T" })]
        [TestCase(true, new string[] { "10T", "JT", "QT", "KT", "AT" })]
        public void esEscaleraColor(bool expected, string[] mano)
        {
            CompruebaMano check = new CompruebaMano();
            bool esEscaleraColor = check.esEscaleraColor(mano);
            Assert.That(esEscaleraColor, Is.EqualTo(expected));

        }

        [Test]
        [TestCase(false, new string[] { "2T", "4C", "9P", "5D", "10T" })]
        [TestCase(false, new string[] { "2T", "3C", "4P", "5D", "JT" })]
        [TestCase(true, new string[] { "6T", "3T", "5C", "4T", "7T" })]
        [TestCase(true, new string[] { "AT", "JT", "QD", "KT", "10T" })]
        public void esEscaleraNormal(bool expected, string[] mano)
        {
            CompruebaMano check = new CompruebaMano();
            bool esEscaleraNormal = check.esEscalera(mano);
            Assert.That(esEscaleraNormal, Is.EqualTo(expected));

        }

        [Test]
        [TestCase(false, new string[] { "2T", "4C", "9P", "5D", "10T" })]
        [TestCase(false, new string[] { "2T", "3C", "4P", "5D", "6T" })]
        [TestCase(false, new string[] { "2T", "4T", "5T", "6T", "7T" })]
        [TestCase(true, new string[] { "JC", "JT", "JD", "JP", "AT" })]
        [TestCase(true, new string[] { "2P", "3T", "3D", "3C", "3P" })]
        public void esPoker(bool expected, string[] mano)
        {
            CompruebaMano check = new CompruebaMano();
            bool esPoker = check.esPoker(mano);
            Assert.That(esPoker, Is.EqualTo(expected));

        }
        [Test]
        [TestCase(new string[] { "2T", "4C", "9P", "5D", "10T" }, null)]
        [TestCase(new string[] { "2T", "3C", "4P", "5D", "6T" }, null)]
        [TestCase(new string[] { "2T", "4T", "5T", "6T", "7T" }, null)]
        [TestCase(new string[] { "JC", "JT", "JD", "JP", "AT" }, new string[] {"JC", "JT", "JD", "JP"})]
        [TestCase(new string[] { "2P", "3T", "3D", "3C", "3P" }, new string[] { "3T", "3D", "3C", "3P" })]
        public void getCartasPoker(string[] mano, string[] expected)
        {
            CompruebaMano check = new CompruebaMano();
            string[] actual = check.getCartasPoker( mano);
            CollectionAssert.AreEqual(actual, expected);
        }


        [Test]
        [TestCase(false, new string[] { "2T", "4C", "9P", "5D", "10T" })]
        [TestCase(false, new string[] { "2T", "3C", "4P", "5D", "6T" })]
        [TestCase(true, new string[] { "2T", "4T", "5T", "6T", "7T" })]
        [TestCase(false, new string[] { "JC", "JT", "JD", "JP", "AT" })]
        [TestCase(true, new string[] { "AP", "2P", "JP", "10P", "3P" })]
        [TestCase(true, new string[] { "5C", "10C", "QC", "9C", "6C" })]
        public void esColor(bool expected, string[] mano)
        {
            CompruebaMano check = new CompruebaMano();
            bool esColor = check.esColor(mano);
            Assert.That(esColor, Is.EqualTo(expected));

        }

        [Test]
        [TestCase(false, new string[] { "2T", "4C", "9P", "5D", "10T" })]
        [TestCase(false, new string[] { "2T", "3C", "4P", "5D", "6T" })]
        [TestCase(true, new string[] { "2T", "4T", "5T", "6T", "7T" })]
        [TestCase(false, new string[] { "JC", "JT", "JD", "JP", "AT" })]
        [TestCase(true, new string[] { "2P", "2D", "2C", "10P", "10T" })]
        [TestCase(true, new string[] { "5C", "5T", "QC", "QT", "QP" })]
        public void esFull(bool expected, string[] mano)
        {
            CompruebaMano check = new CompruebaMano();
            bool esColor = check.esFull(mano);
            Assert.That(esColor, Is.EqualTo(expected));

        }

        [Test]
        [TestCase("10T", new string[] { "2T", "4C", "9P", "5D", "10T" })]
        [TestCase("AP", new string[] { "2T", "4C", "AP", "5D", "10T" })]
        [TestCase("KD", new string[] { "KD", "4C", "9P", "5D", "10T" })]
        [TestCase("5C", new string[] { "2T", "4C", "2P", "5C", "3T" })]
        public void getCartaMasAltaMano(string expected, string[] mano)
        {
            CompruebaMano check = new CompruebaMano();
            string manoMasAlta=  check.getCartaMasAlta(mano);

            Assert.That(manoMasAlta, Is.EqualTo(expected));

        }

        [Test]
        [TestCase(new string[] { "2T", "4C", "9P", "5D", "10T" }, null)]
        [TestCase(new string[] { "2T", "3C", "4P", "5D", "6T" }, null)]
        [TestCase(new string[] { "2T", "4T", "5T", "6T", "7T" }, null)]
        [TestCase(new string[] { "JC", "JT", "JD", "10P", "AT" }, new string[] { "JC", "JT", "JD"})]
        [TestCase(new string[] { "2P", "3T", "7D", "3C", "3P" }, new string[] { "3T","3C", "3P" })]
        [TestCase(new string[] { "2P", "AT", "AD", "3C", "AP" }, new string[] { "AT", "AD", "AP" })]
        public void getCartasTrio( string[] mano,string[] expected)
        {
            CompruebaMano check = new CompruebaMano();
            string[] actual = check.getCartasTrio(mano);
            CollectionAssert.AreEqual(actual, expected);
            
        }

        [Test]
        [TestCase(new string[] { "2T", "4C", "9P", "5D", "10T" }, null)]
        [TestCase(new string[] { "2T", "3C", "4P", "5D", "6T" }, null)]
        [TestCase(new string[] { "2T", "4T", "5T", "6T", "7T" }, null)]
        [TestCase(new string[] { "3C", "JT", "JD", "10P", "AT" }, new string[] { "JT", "JD" })]
        [TestCase(new string[] { "2P", "3T", "7D", "3C", "6P" }, new string[] { "3T", "3C"})]
        [TestCase(new string[] { "2P", "QT", "AD", "3C", "AP" }, new string[] { "AD", "AP" })]
        public void getCartasPareja(string[] mano, string[] expected)
        {
            CompruebaMano check = new CompruebaMano();
            string[] actual = check.getCartasPareja(mano);
            CollectionAssert.AreEqual(actual, expected);

        }

        [Test]
        [TestCase(new string[] { "2T", "4C", "9P", "5D", "10T" }, null)]
        [TestCase(new string[] { "2T", "3C", "4P", "5D", "6T" }, null)]
        [TestCase(new string[] { "2T", "4T", "5T", "6T", "7T" }, null)]
        [TestCase(new string[] { "AC", "JT", "JD", "10P", "AT" }, new string[] { "JT", "JD","AC","AT" })]
        [TestCase(new string[] { "7P", "3T", "7D", "3C", "6P" }, new string[] { "3T", "3C","7P", "7D" })]
        [TestCase(new string[] { "2P", "QT", "AD", "QC", "AP" }, new string[] { "QT", "QC", "AD", "AP" })]
        public void getCartasDoblePareja(string[] mano, string[] expected)
        {
            CompruebaMano check = new CompruebaMano();
            string[] actual = check.getCartasDoblePareja(mano);
            CollectionAssert.AreEqual(actual, expected);

        }

        [Test]
        [TestCase(new string[] { "2T", "4C", "9P", "5D", "10T" }, new string[] { "2C", "4T", "9D", "5P", "10C" },"Empate")]
        [TestCase(new string[] { "2T", "4C", "9P", "5D", "10T" }, new string[] { "2C", "4T", "QD", "5P", "10C" }, "Ganador jugador2 - CartaMasAlta : QD")]
        [TestCase(new string[] { "2T", "3C", "4P", "5D", "6T" }, new string[] { "2T", "3C", "10P", "5D", "10T" }, "Ganador jugador1 - Escalera")]
        [TestCase(new string[] { "2T", "2C", "5T", "6T", "7T" }, new string[] { "2T", "3C", "5P", "5D", "5T" }, "Ganador jugador2 - Trio")]
        [TestCase(new string[] { "AC", "JT", "JD", "10P", "AT" }, new string[] { "QT", "QD", "QC", "KT", "KD" }, "Ganador jugador2 - Full")]
        [TestCase(new string[] { "7P", "3T", "7D", "3C", "6P" }, new string[] { "2T", "2C", "8P", "9D", "AC" }, "Ganador jugador1 - DoblePareja")]
        [TestCase(new string[] { "2P", "QT", "AD", "QC", "AP" }, new string[] { "QP", "QD", "AT", "AC", "5P" }, "Ganador jugador2 - CartaMasAlta : 5P")]
        [TestCase(new string[] { "2P", "QT", "AD", "JC", "AP" }, new string[] { "KP", "QD", "AT", "AC", "5P" }, "Ganador jugador2 - CartaMasAlta : KP")]
        public void compruebaGanador(string[] manoJugador1, string[] manoJugador2, string resultado)
        {
            CompruebaMano check = new CompruebaMano();
            string actual = check.compruebaGanador(manoJugador1, manoJugador2);
            Assert.That(actual, Is.EqualTo(resultado));

        }
    }
}
