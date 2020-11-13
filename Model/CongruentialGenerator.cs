using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class CongruentialGenerator : UniformGenerator
    {
        public double Multiplier { get; set; }
        public double Increment { get; set; }

        public CongruentialGenerator(long modulus, long seed, long multiplier, long increment, int length)
            : base(modulus, seed, length)
        {
            Multiplier = multiplier;
            Increment = increment;
        }

        public override IEnumerable<double> Generate()
        {
            var value = Seed;
            for (var i = 0; i < Length; i++)
            {
                value = (Multiplier * value + Increment) % Modulus;
                yield return value;
            }
        }

        public override string ToString()
        {
            return "Linear congruential";
        }
    }
}
