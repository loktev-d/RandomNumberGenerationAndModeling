using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class ProbabilityDensityFunction : DistributionFunction
    {
        public abstract float UpperBound { get; }
    }
}
