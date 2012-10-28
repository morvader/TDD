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
    }
}
