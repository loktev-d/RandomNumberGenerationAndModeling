using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class CltSampler : NormalSampler
    {
        public int PopulationSize { get; set; }

        public CltSampler(float shift, float scale, int length, int  populationSize) : base(shift, scale, length)
        {
            PopulationSize = populationSize;
        }

        protected override IEnumerable<float> Normalize()
        {
            for (var i = 0; i < Length; i++)
            {
                float randomNumber = 0;
                for (var j = 0; j < PopulationSize; j++) 
                {
                    randomNumber += GenerateRandomNumber();
                }
                yield return (randomNumber - PopulationSize / 2) / (float) Math.Sqrt(PopulationSize / 12);
            }
        }

        public override string ToString()
        {
            return "Central limit theorem";
        }
    }
}
