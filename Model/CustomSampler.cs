using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class CustomSampler<T> : RandomSampler where T : DistributionFunction
    {
        public T Distribution { get; protected set; }
        public override float MathExpectation => Distribution.MathExpectation;
        public override float Variance => Distribution.Variance;
        public override float StandardDeviation => Distribution.StandardDeviation;

        public CustomSampler(int length, T distribution) : base(length)
        {
            Distribution = distribution;
        }
    }
}
