﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class InverseTransformSampler : CustomSampler<DistributionFunction>
    {
        public InverseTransformSampler(int length) : base(length)
        {
        }

        public InverseTransformSampler(int length, DistributionFunction inverseFunction) : base(length, inverseFunction)
        {
        }

        public override IEnumerable<double> Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return Distribution.GetValue(GenerateRandomNumber());
            }
        }

        public override string ToString()
        {
            return "Inverse transform";
        }
    }
}