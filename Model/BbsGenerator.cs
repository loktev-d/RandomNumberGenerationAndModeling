using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class BbsGenerator : UniformGenerator
    {

        public BbsGenerator(long modulus, long seed, int length) : base(modulus, seed, length)
        {

        }

        public override IEnumerable<double> Generate()
        {
            double value = Seed;
            for (var i = 0; i < Length; i++)
            {
                value = (value * value) % Modulus;
                yield return value;
            }
        }

        public override string ToString()
        {
            return "Blum Blum Shub";
        }
    }
}
