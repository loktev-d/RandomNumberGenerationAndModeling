using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class NormalSampler : RandomSampler
    {
        public float Shift { get; set; }
        public float Scale { get; set; }
        public override float MathExpectation => Shift;
        public override float Variance => (float) Math.Pow(Scale, 2);
        public override float StandardDeviation => Scale;

        public NormalSampler(float shift, float scale, int length) : base(length)
        {
            Shift = shift;
            Scale = scale;
        }

        protected abstract IEnumerable<float> Normalize();

        public override IEnumerable Generate()
        {
            var normalizedNumbers = Normalize();

            foreach (var number in normalizedNumbers)
            {
                yield return number * Scale + Shift;
            }
        }
    }
}
