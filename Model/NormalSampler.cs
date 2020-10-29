using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class NormalSampler : RandomSampler
    {
        public float Shift { get; set; }
        public float Scale { get; set; }

        protected abstract IEnumerable<float> Normalize(IEnumerable<float> randomNumbers);

        public override IEnumerable Generate(IEnumerable<float> randomNumbers)
        {
            var normalizedNumbers = Normalize(randomNumbers);

            foreach (var number in normalizedNumbers)
            {
                yield return number * Scale + Shift;
            }
        }
    }
}
