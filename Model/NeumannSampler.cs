using System;
using System.Collections;

namespace RandomNumberGenerationAndModeling.Model
{
    public class NeumannSampler : RandomSampler
    {
        public float FirstHorizontalBound { get; set; }
        public float SecondHorizontalBound { get; set; }
        public float UpperVerticalBound { get; set; }
        public ProbabilityDensityFunction ProbabilityDensityFunction { get; set; }

        public NeumannSampler(float first, float second, float upper, int length, ProbabilityDensityFunction function)
            : base(length)
        {
            FirstHorizontalBound = first;
            SecondHorizontalBound = second;
            UpperVerticalBound = upper;
            ProbabilityDensityFunction = function;
        }

        public override IEnumerable Generate()
        {
            for (var i = 0; i < Length; i++)
            {
                var pointHorizontalCoordinate = FirstHorizontalBound +
                                                GenerateRandomNumber() * (SecondHorizontalBound - FirstHorizontalBound);

                var pointVerticalCoordinate = GenerateRandomNumber() * ProbabilityDensityFunction.UpperBound;

                if (pointVerticalCoordinate < ProbabilityDensityFunction.GetVerticalCoordinate(pointVerticalCoordinate))
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
