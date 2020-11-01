using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class BoxMullerSampler : NormalSampler
    {

        public BoxMullerSampler(float shift, float scale, int length) : base(shift, scale, length)
        {

        }

        protected override IEnumerable<float> Normalize()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return (float) Math.Sqrt(-2 * (float) Math.Log(GenerateRandomNumber(), Math.E)) *
                             (float) Math.Cos(2 * Math.PI * GenerateRandomNumber());
            }
        }
    }
}
