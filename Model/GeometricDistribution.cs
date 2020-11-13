using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class GeometricDistribution : DiscreteDistribution
    {
        public double SuccessProbability { get; set; }
        public override double MathExpectation => 1 / SuccessProbability;
        public override double Variance => (1 - SuccessProbability) / (SuccessProbability * SuccessProbability);
        public override double StandardDeviation => Math.Sqrt(Variance);

        public GeometricDistribution(int length, double successProbability) : base(length)
        {
            SuccessProbability = successProbability;
        }

        public GeometricDistribution(double successProbability)
        {
            SuccessProbability = successProbability;
        }

        public override double GetValue(double x)
        {
            if (Length == x)
                return 1 - Math.Pow(1 - SuccessProbability, x - 1) * SuccessProbability;

            return Math.Pow(1 - SuccessProbability, x - 1) * SuccessProbability;
        }

        public override string ToString()
        {
            return "Geometrical distribution";
        }
    }
}
