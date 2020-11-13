using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseRayleighFunction : DistributionFunction
    {
        public double Scale { get; set; }
        public override double MathExpectation => Math.Sqrt(Math.PI / 2) * Scale;
        public override double Variance => (2 - Math.PI / 2) * Scale * Scale;
        public override double StandardDeviation => Math.Sqrt(Variance);

        public InverseRayleighFunction(double scale)
        {
            Scale = scale;
        }

        public override double GetValue(double x)
        {
            return Scale * Math.Sqrt(-2 * Math.Log(1 - x, Math.E));
        }

        public override string ToString()
        {
            return "Rayleigh distribution";
        }
    }
}
