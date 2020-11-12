using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class LotterySampler : CustomSampler<DiscreteDistribution>
    {
        public LotterySampler(int length) : base(length)
        {
            Length = length;
        }

        public LotterySampler(DiscreteDistribution distribution, int length) : base(length)
        {
            Length = length;
            distribution.Length = length;
        }

        public override IEnumerable<double> Generate()
        {
            Distribution.Length = Length;

            for (var i = 0; i < Length; i++)
            {
                double range = 0;
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
