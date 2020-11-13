using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class NormalSampler : RandomSampler
    {
        public double Shift { get; set; }
        public double Scale { get; set; }
        public override double MathExpectation => Shift;
        public override double Variance => Math.Pow(Scale, 2);
        public override double StandardDeviation => Scale;

        public NormalSampler(double shift, double scale, int length) : base(length)
        {
            Shift = shift;
            Scale = scale;
        }

        protected abstract IEnumerable<double> Normalize();

        public override IEnumerable<double> Generate()
        {
            var normalizedNumbers = Normalize();

            foreach (var number in normalizedNumbers)
            {
                yield return number * Scale + Shift;
            }
        }
    }
}
