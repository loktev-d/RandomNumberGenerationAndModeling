using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class InverseRayleighFunctionDialogViewModel : DistributionDialogViewModel<InverseRayleighFunction>
    {
        public double Scale { get; set; }

        public InverseRayleighFunctionDialogViewModel(InverseRayleighFunction inverseRayleighFunction, Window dialogView)
            : base(inverseRayleighFunction, dialogView)
        {
            Scale = Distribution.Scale;
        }

        public override void Configure()
        {
            Distribution.Scale = Scale;
        }
    }
}
