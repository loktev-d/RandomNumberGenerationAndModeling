using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomGenerator
    {
        public int Length { get; set; }

        public RandomGenerator(int length)
        {
            Length = length;
        }

        public abstract IEnumerable Generate();
    }
}
