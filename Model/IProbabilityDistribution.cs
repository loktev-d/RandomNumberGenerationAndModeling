using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public interface IProbabilityDistribution
    {
        public float MathExpectation { get; }
        public float Variance { get; }
        public float StandardDeviation { get; }
    }
}
