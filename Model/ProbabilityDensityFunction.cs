using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class ProbabilityDensityFunction : MathFunction
    {
        public abstract float UpperBound { get; }
    }
}
