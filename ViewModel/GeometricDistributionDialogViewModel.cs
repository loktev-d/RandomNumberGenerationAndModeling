using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class GeometricDistributionDialogViewModel : DistributionDialogViewModel<GeometricDistribution>
    {
        public double SuccessProbability { get; set; }

        public GeometricDistributionDialogViewModel(GeometricDistribution geometricDistribution, Window dialogView) 
            : base(geometricDistribution, dialogView)
        {
            SuccessProbability = Distribution.SuccessProbability;
        }

        public override void Configure()
        {
            Distribution.SuccessProbability = SuccessProbability;
        }
    }
}
