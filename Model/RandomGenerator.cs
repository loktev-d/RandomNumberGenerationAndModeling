using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomGenerator
    {
        public long Modulus { get; set; }
        public long Seed { get; set; }

        protected RandomGenerator(long modulus, long seed)
        {
            Modulus = modulus;
            Seed = seed;
        }

        public abstract IEnumerable<long> Generate(int size);
    }
}
