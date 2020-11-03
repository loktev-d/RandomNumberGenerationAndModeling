using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class GeometricDistribution : DiscreteDistribution
    {
        public float SuccessProbability { get; set; }
        public override float MathExpectation => 1 / SuccessProbability;
        public override float Variance => (1 - SuccessProbability) / SuccessProbability * SuccessProbability;
        public override float StandardDeviation => (float) Math.Sqrt(Variance);

        public GeometricDistribution(int length, float successProbability) : base(length)
        {
            SuccessProbability = successProbability;
        }

        public override float GetValue(float x)
        {
            if (Length == (int) x)
                return 1 - (float)Math.Pow(1 - SuccessProbability, (int)x - 1) * SuccessProbability;

            return (float) Math.Pow(1 - SuccessProbability, (int) x - 1) * SuccessProbability;
        }
    }
}
