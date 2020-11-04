using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class NeumannSampler : CustomSampler<ProbabilityDensityFunction>
    {
        public float FirstHorizontalBound { get; set; }
        public float SecondHorizontalBound { get; set; }

        public NeumannSampler(float firstBound, float secondBound, int length)
            : base(length)
        {
            FirstHorizontalBound = firstBound;
            SecondHorizontalBound = secondBound;
        }

        public NeumannSampler(float firstBound, float secondBound, int length, ProbabilityDensityFunction function)
            : base(length, function)
        {
            FirstHorizontalBound = firstBound;
            SecondHorizontalBound = secondBound;
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

        public override string ToString()
        {
            return "Neumann";
        }
    }
}
