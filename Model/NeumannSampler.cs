using System;
using System.Collections.Generic;

namespace RandomNumberGenerationAndModeling.Model
{
    public class NeumannSampler : CustomSampler<ProbabilityDensityFunction>
    {
        public double FirstHorizontalBound { get; set; }
        public double SecondHorizontalBound { get; set; }

        public NeumannSampler(double firstBound, double secondBound, int length)
            : base(length)
        {
            FirstHorizontalBound = firstBound;
            SecondHorizontalBound = secondBound;
        }

        public NeumannSampler(double firstBound, double secondBound, int length, ProbabilityDensityFunction function)
            : base(length, function)
        {
            FirstHorizontalBound = firstBound;
            SecondHorizontalBound = secondBound;
        }

        public override IEnumerable<double> Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                var pointHorizontalCoordinate = FirstHorizontalBound +
                                                GenerateRandomNumber() * (SecondHorizontalBound - FirstHorizontalBound);

                var pointVerticalCoordinate = GenerateRandomNumber() * Distribution.UpperBound;

                if (pointVerticalCoordinate < Distribution.GetValue(pointHorizontalCoordinate))
                {
                    yield return pointHorizontalCoordinate;
                }
                else
                {
                    i--;
                }
            }
        }

        public override string ToString()
        {
            return "Neumann";
        }
    }
}
