using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class ProbabilityDensityFunctionA : ProbabilityDensityFunction
    {
        public float A { get; set; }
        public float C { get; set; }
        public float MathExpectation { get; set; }
        public override float UpperBound => 3 * (float)Math.Sqrt(A) / (4 * (float)Math.Sqrt(C));

        public ProbabilityDensityFunctionA(float a, float c, float m)
        {
            A = a;
            C = c;
            MathExpectation = m;
        }

        public override float GetVerticalCoordinate(float x)
        {
            return 3 * (float)Math.Sqrt(A) *
                   (C - A * (float)Math.Pow(x - MathExpectation, 2)) /
                   (4 * C * (float)Math.Sqrt(C));
        }
    }
}
