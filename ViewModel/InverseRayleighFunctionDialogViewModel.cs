using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class InverseRayleighFunctionDialogViewModel : DistributionDialogViewModel<InverseRayleighFunction>
    {
        public float VariableS { get; set; }

        public InverseRayleighFunctionDialogViewModel(InverseRayleighFunction inverseRayleighFunction, Window dialogView)
            : base(inverseRayleighFunction, dialogView)
        {
            VariableS = Distribution.VariableS;
        }

        public override void Configure()
        {
            Distribution.VariableS = VariableS;
        }
    }
}
