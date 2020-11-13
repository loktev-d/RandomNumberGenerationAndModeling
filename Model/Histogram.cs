using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumberGenerationAndModeling.Model
{
    public static class Histogram
    {
        public static IEnumerable<double> CountFrequencies(IEnumerable<double> values, int binsCount)
        {
            var frequencies = new double[binsCount];

            var minValue = values.Min();
            var maxValue = values.Max();

            var bin = (maxValue - minValue) / binsCount;

            foreach (var value in values)
            {
                double range = minValue;
                for (var i = 0; i < binsCount; i++)
                {
                    range += bin;
                    if (value <= range)
                    {
                        frequencies[i]++;
                        break;
                    }
                }
            }

            return frequencies;
        }
    }
}
