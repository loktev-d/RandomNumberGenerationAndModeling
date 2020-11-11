using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class CongruentialGenerator : UniformGenerator
    {
        public double Multiplier { get; set; }
        public double Increment { get; set; }

        public CongruentialGenerator(long modulus, long seed, int length, long multiplier, long increment)
            : base(modulus, seed, length)
        {
            Multiplier = multiplier;
            Increment = increment;
        }

        public override IEnumerable<double> Generate()
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
