using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class NeumannSampler : CustomSampler<ProbabilityDensityFunction>
    {
        public float FirstHorizontalBound { get; set; }
        public float SecondHorizontalBound { get; set; }
        public float UpperVerticalBound { get; set; }

        public NeumannSampler(float first, float second, float upper, int length, ProbabilityDensityFunction function)
            : base(length, function)
        {
            FirstHorizontalBound = first;
            SecondHorizontalBound = second;
            UpperVerticalBound = upper;
        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                var pointHorizontalCoordinate = FirstHorizontalBound +
                                                GenerateRandomNumber() * (SecondHorizontalBound - FirstHorizontalBound);

                var pointVerticalCoordinate = GenerateRandomNumber() * Distribution.UpperBound;

                if (pointVerticalCoordinate < Distribution.GetValue(pointVerticalCoordinate))
                {
                    yield return pointHorizontalCoordinate;
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
