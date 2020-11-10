using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class ProbabilityDensityFunctionA : ProbabilityDensityFunction
    {
        public float VariableA { get; set; }
        public float VariableC { get; set; }
        public float VariableM { get; set; }
        public override float UpperBound => 3 * (float)Math.Sqrt(VariableA) / (4 * (float)Math.Sqrt(VariableC));
        public override float MathExpectation => VariableM;
        public override float Variance => StandardDeviation * StandardDeviation - MathExpectation * MathExpectation;
        public override float StandardDeviation => (20 * VariableC * VariableM * VariableM + 4 * VariableC * VariableC / VariableA) / (20 * VariableC);

        public ProbabilityDensityFunctionA(float variableA, float variableC, float variableM)
        {
            VariableA = variableA;
            VariableC = variableC;
            VariableM = variableM;
        }

        public override float GetValue(float x)
        {
            return 3 * (float)Math.Sqrt(VariableA) *
                   (VariableC - VariableA * (float)Math.Pow(x - VariableM, 2)) /
                   (4 * VariableC * (float)Math.Sqrt(VariableC));
        }

        public override string ToString()
        {
            return "Density function A";
        }
    }
}
