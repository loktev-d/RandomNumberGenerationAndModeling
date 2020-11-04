using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class LotterySampler : CustomSampler<DiscreteDistribution>
    {
        public new int Length => Distribution.Length;

        public LotterySampler(int length) : base(length)
        {

        }

        public LotterySampler(int length, DiscreteDistribution distribution) : base(length, distribution)
        {

        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                float range = 0;
                for (var j = 1; j <= Length; j++)
                {
                    range += Distribution.GetValue(j);
                    if (GenerateRandomNumber() <= range)
                    {
                        yield return j;
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            return "Lottery";
        }
    }
}
