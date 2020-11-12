using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class UniformGenerator : RandomGenerator
    {
        public double Modulus { get; set; }
        public double Seed { get; set; }
        public override double MathExpectation => (Modulus - 1) / 2;
        public override double Variance => Math.Pow(Modulus, 2) / 12;
        public override double StandardDeviation => Modulus / Math.Sqrt(12);

        public override double FirstHorizontalBound => 0;
        public override double SecondHorizontalBound => Modulus - 1;

        protected UniformGenerator(long modulus, long seed, int length) : base(length)
        {
            Modulus = modulus;
            Seed = seed;
            Length = length;
        }
    }
}
