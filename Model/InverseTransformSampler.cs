using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseTransformSampler : RandomSampler
    {
        public MathFunction InverseFunction { get; set; }

        public InverseTransformSampler(int length) : base(length)
        {
        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return InverseFunction.GetVerticalCoordinate(GenerateRandomNumber());
            }
        }
    }
}