using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteGame;

namespace RouletteGameTest
{
    [TestClass]
    class BinTest
    {
        private Bin _zeroBin;
        [TestInitialize]
        public void Initialize()
        {
            Outcome fiveNumberOutcome = new Outcome("00-0-1-2-3", 6);
            Outcome[] zeroOutcomes = new Outcome[] { new Outcome("0", 35), fiveNumberOutcome };
            Outcome[] zerozeroOutcomes = new[] { new Outcome("0", 35), fiveNumberOutcome };

            _zeroBin = new Bin(zeroOutcomes);
        }

        [TestMethod]
        public void ToStringTest()
        {
            

            Assert.AreEqual(expected: "[0 (35:1), 00-0-1-2-3 (6:1)]", actual: _zeroBin.ToString());
        }

    }
}
