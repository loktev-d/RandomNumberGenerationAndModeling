using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class LotterySampler : RandomSampler
    {
        public float[] Probabilities { get; set; }

        public override IEnumerable Generate(float[] randomNumbers)
        {
            for (var i = 0; i < randomNumbers.Length; i++)
            {
                float range = 0;
                for (var j = 0; j < Probabilities.Length; j++)
                {
                    range += Probabilities[j];
                    if (randomNumbers[i] <= range)
                    {
                        yield return j;
                        break;
                    }
                }
            }
        }
    }
}
