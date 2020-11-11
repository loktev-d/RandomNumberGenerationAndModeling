using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class BoxMullerSampler : NormalSampler
    {
        public BoxMullerSampler(double shift, double scale, int length) : base(shift, scale, length)
        {

        }

        protected override IEnumerable<double> Normalize()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return Math.Sqrt(-2 * Math.Log(GenerateRandomNumber(), Math.E)) *
                             Math.Cos(2 * Math.PI * GenerateRandomNumber());
            }
        }

        public override string ToString()
        {
            return "Box-Muller transform";
        }
    }
}
