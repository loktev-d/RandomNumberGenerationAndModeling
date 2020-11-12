using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomGenerator : IProbabilityDistribution
    {
        public int Length { get; set; }
        public abstract double MathExpectation { get; }
        public abstract double Variance { get; }
        public abstract double StandardDeviation { get; }

        public virtual double FirstHorizontalBound => MathExpectation - StandardDeviation;
        public virtual double SecondHorizontalBound => MathExpectation + StandardDeviation;

        public RandomGenerator(int length)
        {
            Length = length;
        }

        public abstract IEnumerable<double> Generate();

        public abstract override string ToString();
    }
}
