﻿using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public abstract class RandomSampler : RandomGenerator
    {
        protected List<float> randomGeneratedNumbers;
        protected Random Generator { get; set; }

        public IEnumerable<float> RandomGeneratedNumbers
        {
            get
            {
                foreach (float number in randomGeneratedNumbers)
                {
                    yield return number;
                }
            }
        }

        public RandomSampler(int length) : base(length)
        {
            Length = length;
            randomGeneratedNumbers = new List<float>();
        }

        protected float GenerateRandomNumber()
        {
            float number = (float) Generator.NextDouble();
            randomGeneratedNumbers.Add(number);
            return number;
        }
    }
}