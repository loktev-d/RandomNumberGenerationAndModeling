using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class ProbabilityDensityFunctionA : ProbabilityDensityFunction
    {
        public double VariableA { get; set; }
        public double VariableC { get; set; }
        public double VariableM { get; set; }
        public override double UpperBound => 3 * Math.Sqrt(VariableA) / (4 * Math.Sqrt(VariableC));
        public override double MathExpectation => VariableM;
        public override double Variance => StandardDeviation * StandardDeviation - MathExpectation * MathExpectation;

        public override double StandardDeviation =>
            (20 * VariableC * VariableM * VariableM + 4 * VariableC * VariableC / VariableA) / (20 * VariableC);

        public ProbabilityDensityFunctionA(double variableA, double variableC, double variableM)
        {
            VariableA = variableA;
            VariableC = variableC;
            VariableM = variableM;
        }

        public override double GetValue(double x)
        {
            return 3 * Math.Sqrt(VariableA) *
                   (VariableC - VariableA * Math.Pow(x - VariableM, 2)) /
                   (4 * VariableC * Math.Sqrt(VariableC));
        }

        public override string ToString()
        {
            return "Density function A";
        }
    }
}
