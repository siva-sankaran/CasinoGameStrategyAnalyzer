using System;
using System.Collections.Generic;
using System.Linq;

namespace RouletteGame
{
    class Bin
    {
        private readonly ISet<Outcome> _outcomes;
        
        public Bin()
        {
            _outcomes = new SortedSet<Outcome>();
        }

        public Bin(IEnumerable<Outcome> outcomes)
        {
            _outcomes = new SortedSet<Outcome>(outcomes);
        }

        public void Add(Outcome outcome) => _outcomes.Add(outcome);

        public override string ToString() => String.Format("[{0}]", string.Join(", ", _outcomes.Select(o => o.ToString()).ToArray()));
    }
}
