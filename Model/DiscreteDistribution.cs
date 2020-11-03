using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class DiscreteDistribution : DistributionFunction
    {
        public int Length { get; set; }

        public DiscreteDistribution()
        {
            Length = 0;
        }
        public DiscreteDistribution(int length)
        {
            Length = length;
        }
    }
}
