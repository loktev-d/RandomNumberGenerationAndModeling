using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class ProbabilityDensityFunction : DistributionFunction
    {
        public abstract double UpperBound { get; }
    }
}
