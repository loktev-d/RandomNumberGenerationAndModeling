using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomSampler : RandomGenerator
    {
        protected Random Generator { get; set; }

        public RandomSampler(int length) : base(length)
        {
            Length = length;
        }

        protected float GenerateRandomNumber()
        {
            return (float) Generator.NextDouble();
        }
    }
}
