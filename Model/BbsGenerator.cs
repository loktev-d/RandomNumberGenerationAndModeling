using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class BbsGenerator : RandomGenerator
    {
        public BbsGenerator(long modulus, long seed)
            : base(modulus, seed)
        {
            
        }

        public override IEnumerable<long> Generate(int size)
        {
            for (var i = 0; i < size; i++)
            {
                Seed = Seed * Seed % Modulus;
                yield return Seed;
            }
        }
    }
}
