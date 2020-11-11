using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class CustomSampler<T> : RandomSampler where T : DistributionFunction
    {
        public T Distribution { get; set; }
        public override double MathExpectation => Distribution.MathExpectation;
        public override double Variance => Distribution.Variance;
        public override double StandardDeviation => Distribution.StandardDeviation;

        public CustomSampler(int length) : base(length)
        {
            Distribution = null;
        }

        public CustomSampler(int length, T distribution) : base(length)
        {
            Distribution = distribution;
        }
    }
}
