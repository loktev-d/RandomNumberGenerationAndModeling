using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class CltSampler : NormalSampler
    {
        public int PopulationSize { get; set; }

        public CltSampler(double shift, double scale, int populationSize, int length) : base(shift, scale, length)
        {
            PopulationSize = populationSize;
        }

        protected override IEnumerable<double> Normalize()
        {
            for (var i = 0; i < Length; i++)
            {
                double randomNumber = 0;
                for (var j = 0; j < PopulationSize; j++) 
                {
                    randomNumber += GenerateRandomNumber();
                }

                yield return (randomNumber - (double)PopulationSize / 2) / Math.Sqrt((double)PopulationSize / 12);
            }
        }

        public override string ToString()
        {
            return "Central limit theorem";
        }
    }
}
