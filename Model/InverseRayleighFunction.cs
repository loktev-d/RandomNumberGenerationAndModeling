using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseRayleighFunction : DistributionFunction
    {
        public double VariableS { get; set; }
        public override double MathExpectation => Math.Sqrt(Math.PI / 2) * StandardDeviation;
        public override double Variance => (2 - Math.PI / 2) * StandardDeviation * StandardDeviation;
        public override double StandardDeviation => VariableS;

        public InverseRayleighFunction(double variableS)
        {
            VariableS = variableS;
        }

        public override double GetValue(double x)
        {
            return VariableS * Math.Sqrt(-2 * Math.Log(1 - x, Math.E));
        }

        public override string ToString()
        {
            return "Rayleigh distribution";
        }
    }
}
