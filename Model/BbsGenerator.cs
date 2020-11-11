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
            for (var i = 0; i < Length; i++)
            {
                Seed = Seed * Seed % Modulus;
                yield return Seed;
            }
        }

        public override string ToString()
        {
            return "Blum Blum Shub";
        }
    }
}
