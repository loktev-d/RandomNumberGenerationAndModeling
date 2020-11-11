using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomSampler : RandomGenerator
    {
        protected Random Generator { get; set; }

        public RandomSampler(int length) : base(length)
        {
            Generator = new Random();
            Length = length;
        }

        protected double GenerateRandomNumber()
        {
            return Generator.NextDouble();
        }
    }
}
