using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumberGenerationAndModeling.Model
{
    public static class Histogram
    {
        public static IEnumerable<int> CountFrequencies(IEnumerable<double> values, double minValue, double maxValue, int binsCount)
        {
            var frequencies = new int[binsCount];

            var bin = (maxValue - minValue) / binsCount;
            foreach (var value in values)
            {
                double range = 0;
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
