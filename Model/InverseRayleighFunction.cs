using System;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseRayleighFunction : MathFunction
    {
        public float StandardDeviation { get; set; }

        public InverseRayleighFunction(float standardDeviation)
        {
            StandardDeviation = standardDeviation;
        }

        public override float GetVerticalCoordinate(float x)
        {
            return StandardDeviation * (float) Math.Sqrt(-2 * (float) Math.Log(1 - x, Math.E));
        }
    }
}
