using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class СongruentialGenerator : UniformGenerator
    {
        public long Multiplier { get; set; }
        public long Increment { get; set; }

        public СongruentialGenerator(long modulus, long seed, int length, long multiplier, long increment)
            : base(modulus, seed, length)
        {
            Multiplier = multiplier;
            Increment = increment;
        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                Seed = (Multiplier * Seed + Increment) % Modulus;
                yield return Seed;
            }
        }
    }
}
