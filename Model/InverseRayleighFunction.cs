using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseRayleighFunction : DistributionFunction
    {
        public float VariableS { get; set; }
        public override float MathExpectation => (float) Math.Sqrt(Math.PI / 2) * StandardDeviation;
        public override float Variance => (2 - (float) Math.PI / 2) * StandardDeviation * StandardDeviation;
        public override float StandardDeviation => VariableS;

        public InverseRayleighFunction(float variableS)
        {
            VariableS = variableS;
        }

        public override float GetValue(float x)
        {
            return VariableS * (float) Math.Sqrt(-2 * (float) Math.Log(1 - x, Math.E));
        }
    }
}
