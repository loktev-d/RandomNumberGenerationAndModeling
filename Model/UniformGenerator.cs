using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class UniformGenerator : RandomGenerator
    {
        public long Modulus { get; set; }
        public long Seed { get; set; }
        public override float MathExpectation => (Modulus - 1) / 2;
        public override float Variance => (float) Math.Pow(Modulus, 2) / 12;
        public override float StandardDeviation => Modulus / (float) Math.Sqrt(12);

        protected UniformGenerator(long modulus, long seed, int length) : base(length)
        {
            Modulus = modulus;
            Seed = seed;
            Length = length;
        }
    }
}
