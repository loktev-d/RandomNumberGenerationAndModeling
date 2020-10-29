using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomSampler
    {
        public abstract IEnumerable Generate(IEnumerable<float> randomNumbers);
    }
}
