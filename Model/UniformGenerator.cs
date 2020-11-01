using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class UniformGenerator : RandomGenerator
    {
        public long Modulus { get; set; }
        public long Seed { get; set; }

        protected UniformGenerator(long modulus, long seed, int length) : base(length)
        {
            Modulus = modulus;
            Seed = seed;
            Length = length;
        }
    }
}
