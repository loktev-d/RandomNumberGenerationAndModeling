using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumberGenerationAndModeling.Model
{
    public class CltSampler : NormalSampler
    {
        protected override IEnumerable<float> Normalize(IEnumerable<float> randomNumbers)
        {
            foreach (var randomNumber in randomNumbers)
            {
                yield return (randomNumber - randomNumbers.Count() / 2) / (float) Math.Sqrt(randomNumbers.Count() / 12);
            }
        }
    }
}
