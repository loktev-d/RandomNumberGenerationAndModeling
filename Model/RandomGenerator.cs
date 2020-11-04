using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomGenerator : IProbabilityDistribution
    {
        public int Length { get; set; }
        public abstract float MathExpectation { get; }
        public abstract float Variance { get; }
        public abstract float StandardDeviation { get; }

        public RandomGenerator(int length)
        {
            Length = length;
        }

        public abstract IEnumerable Generate();

        public abstract override string ToString();
    }
}
