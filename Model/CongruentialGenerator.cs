using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class CongruentialGenerator : UniformGenerator
    {
        public long Multiplier { get; set; }
        public long Increment { get; set; }

        public CongruentialGenerator(long modulus, long seed, int length, long multiplier, long increment)
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

        public override string ToString()
        {
            return "Linear congruential";
        }
    }
}
