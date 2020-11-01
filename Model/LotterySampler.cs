using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class LotterySampler : RandomSampler
    {
        public float[] Probabilities { get; }

        public LotterySampler(float[] probabilities) : base(probabilities.Length)
        {
            Probabilities = Probabilities;
        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                float range = 0;
                for (var j = 0; j < Length; j++)
                {
                    range += Probabilities[j];
                    if (GenerateRandomNumber() <= range)
                    {
                        yield return j+1;
                        break;
                    }
                }
            }
        }
    }
}
