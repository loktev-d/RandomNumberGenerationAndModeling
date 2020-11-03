using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseTransformSampler : CustomSampler<DistributionFunction>
    {
        public InverseTransformSampler(int length, DistributionFunction inverseFunction) : base(length, inverseFunction)
        {
        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return Distribution.GetValue(GenerateRandomNumber());
            }
        }
    }
}