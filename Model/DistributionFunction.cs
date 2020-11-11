using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class DistributionFunction : IProbabilityDistribution
    {
        public abstract double MathExpectation { get; }
        public abstract double Variance { get; }
        public abstract double StandardDeviation { get; }
        public abstract double GetValue(double x);
        public abstract override string ToString();
    }
}
