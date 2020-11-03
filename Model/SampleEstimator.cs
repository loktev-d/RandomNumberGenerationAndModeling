using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class SampleEstimator
    {
        public float SampleMathExpectation { get; protected set; }
        public float SampleVariance { get; protected set; }
        public float SampleStandardDeviation { get; protected set; }

        public SampleEstimator()
        {
            SampleMathExpectation = 0;
            SampleVariance = 0;
            SampleStandardDeviation = 0;
        }

        public void EstimateSample(IEnumerable generatedNumbers)
        {
            List<float> sampleNumbers = (List<float>) generatedNumbers;

            foreach (var sampleNumber in sampleNumbers)
            {
                SampleMathExpectation += sampleNumber / sampleNumbers.Count;
                SampleVariance += (float) Math.Pow(SampleVariance, 2) / sampleNumbers.Count;
            }

            SampleVariance = (SampleVariance - (float) Math.Pow(SampleMathExpectation, 2)) * sampleNumbers.Count /
                             (sampleNumbers.Count - 1);

            SampleStandardDeviation = (float) Math.Sqrt(SampleVariance);
        }
    }
}
