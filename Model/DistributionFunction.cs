using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class DistributionFunction : IProbabilityDistribution
    {
        public abstract float MathExpectation { get; }
        public abstract float Variance { get; }
        public abstract float StandardDeviation { get; }
        public abstract float GetValue(float x);
        public abstract override string ToString();
    }
}
