using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class СongruentialGenerator : RandomGenerator
    {
        public long Multiplier { get; set; }
        public long Increment { get; set; }

        public СongruentialGenerator(int modulus, int seed, int multiplier, int increment)
            : base(modulus, seed)
        {
            Multiplier = multiplier;
            Increment = increment;
        }

        public override IEnumerable<long> Generate(int size)
        {
            for (var i = 0; i < size; i++)
            {
                Seed = (Multiplier * Seed + Increment) % Modulus;
                yield return Seed;
            }
        }
    }
}
