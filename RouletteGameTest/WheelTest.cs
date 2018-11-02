//using TypeMock.ArrangeActAssert.Suggest;
//using TypeMock.ArrangeActAssert;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteGame;

namespace RouletteGameTest
{
    [TestClass]
    public class WheelTest
    {
        #region Unit Tests for AddOutcome
        
        [TestMethod]
        public void AddOutcome_Test_Sets_binsLengthTo1()
        {
            // arrange
            var random = new Random();
            var wheel = new Wheel(random);
            var outcome = new Outcome("name", 0);
             
            // act
            wheel.AddOutcome(0, outcome);

            // assert
            // side affects on wheel
            //Isolate is a TypeMock class
            //Assert.AreEqual(1, ((Isolate.NonPublic.InstanceField(wheel,"_bins").Value) as Bin[]).Length);
            //Assert.AreEqual("[name (0:1)]", ((Isolate.NonPublic.InstanceField(wheel,"_bins").Value) as Bin[])[0].ToString());
        }

        #endregion
        private Wheel _wheel;
        [TestInitialize]
        public void Initialize()
        {
            Random random = new Random(3);
            _wheel = new Wheel(random);
        }

        [TestMethod]
        public void AddOutcomeTest()
        {
            _wheel.AddOutcome(0, new Outcome("0", 35));
            Bin output = _wheel.GetBin(0);

            Assert.AreEqual(expected:"[0 (35:1)]", actual: output.ToString());
        }

        [TestMethod]
        public void Next_Test_ReturnsNull()
        {
            // arrange
            var nonRandomMock = new NonRandomMock();
            var wheel = new Wheel(nonRandomMock);
            nonRandomMock.SetSeed(2);

            // act
            var result = wheel.Next();

            // assert
            Assert.IsNull(result);
        }

        public void Run_Wheel_test()
        {
            var nonRandomMock = new NonRandomMock();
            var wheel = new Wheel(nonRandomMock);
            Outcome fiveNumberOutcome = new Outcome("00-0-1-2-3", 6);
            Outcome zeroStraightOutcome = new Outcome("0", 35);
            wheel.AddOutcome(0, zeroStraightOutcome);
            wheel.AddOutcome(0, fiveNumberOutcome);

            Outcome zerozeroStraightOutcome = new Outcome("00", 35);
            wheel.AddOutcome(37, zerozeroStraightOutcome);
            wheel.AddOutcome(37, fiveNumberOutcome);

            Outcome oneStraightOutcome = new Outcome("1", 35);
            wheel.AddOutcome(1, oneStraightOutcome);
            wheel.AddOutcome(1, new Outcome("1-4", 17));
            wheel.AddOutcome(1, new Outcome("1-2", 17));
            wheel.AddOutcome(1, new Outcome("1-2-3", 11));
            wheel.AddOutcome(1, new Outcome("1-2-4-5", 8));
            wheel.AddOutcome(1, new Outcome("1-2-3-4-5-6", 5));
            wheel.AddOutcome(1, new Outcome("1-12", 2));
            wheel.AddOutcome(1, new Outcome("Col-1", 2));
            wheel.AddOutcome(1, new Outcome("1-18", 1));
            wheel.AddOutcome(1, new Outcome("Red", 1));

            nonRandomMock.SetSeed(37);
            var selectedBin = wheel.Next();
            Assert.AreEqual(actual: wheel.GetBin(37), expected: selectedBin);
        }

    }
}
