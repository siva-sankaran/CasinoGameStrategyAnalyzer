using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteGame;

namespace RouletteGameTest
{
    [TestClass]
    public class OutComeTest
    {
        [TestMethod]
        public void EqualityTest()
        {
            Outcome oc1 = new Outcome("Red", 5);
            Outcome oc2 = new Outcome("Red", 5);

            Assert.AreEqual<bool>(true, oc1.Equals(oc2));
        }

        [TestMethod]
        public void HashEqualityTest()
        {
            Outcome oc1 = new Outcome("Red", 5);
            Outcome oc2 = new Outcome("Red", 5);
            Assert.AreEqual(oc1.GetHashCode(), oc2.GetHashCode());
        }

        [TestMethod]
        public void WinAmountTest()
        {
            Outcome oc1 = new Outcome("Red", 5);
            Assert.AreEqual<int>(50, oc1.WinAmount(10));
        }

        [TestMethod]
        public void CompareTo_Test_Returns0()
        {
            // arrange
            var outcome1 = new Outcome("name", (-1));
            var outcome = new Outcome("name", (-1));

            // act
            var result = outcome1.CompareTo(outcome);

            // assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Outcome oc1 = new Outcome("Red", 5);
            Assert.AreEqual("Red (5:1)", actual: oc1.ToString());
        }
    }
}
