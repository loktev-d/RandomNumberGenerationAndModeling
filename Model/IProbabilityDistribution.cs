using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public interface IProbabilityDistribution
    {
        public double MathExpectation { get; }
        public double Variance { get; }
        public double StandardDeviation { get; }
    }
}
