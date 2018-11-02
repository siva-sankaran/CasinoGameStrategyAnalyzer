using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouletteGame
{
    class NonRandomMock : Random
    {
        private int _value;
        
        public void SetSeed(int value) => _value = value;

        public override int Next(int minValue, int maxValue)
        {
            return _value;
        }
    }
}
