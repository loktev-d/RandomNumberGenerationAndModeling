using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class LotterySampler : CustomSampler<DiscreteDistribution>
    {
        public new int Length
        {
            get
            {
                if (Distribution != null)
                    return Distribution.Length;
                return 0;
            }
        }

        public LotterySampler() : base(0)
        {

        }

        public LotterySampler(DiscreteDistribution distribution) : base(distribution.Length)
        {

        }

        public override IEnumerable<double> Generate()
        {
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
