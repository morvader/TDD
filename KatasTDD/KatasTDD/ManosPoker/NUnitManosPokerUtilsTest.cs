using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KatasTDD.ManosPoker
{
    [TestFixture]
    public class NUnitManosPokerUtilsTest
    {
        #region setUp
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
        [TestCase(2,"2")]
        [TestCase(10, "10")]
        [TestCase(11, "J")]
        [TestCase(12, "Q")]
        [TestCase(13, "K")]
        [TestCase(14, "A")]
        public void getRepresentacionCarta(int valor, string expected)
        {
            string actual = ManosPokerUtils.getRepresentacionCarta(valor);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
