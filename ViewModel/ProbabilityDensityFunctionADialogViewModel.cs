using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class ProbabilityDensityFunctionADialogViewModel : DistributionDialogViewModel<ProbabilityDensityFunctionA>
    {
        public float VariableA { get; set; }
        public float VariableC { get; set; }
        public float VariableM { get; set; }

        public ProbabilityDensityFunctionADialogViewModel(ProbabilityDensityFunctionA densityFunctionA, Window dialogView)
            : base(densityFunctionA, dialogView)
        {
            VariableA = Distribution.VariableA;
            VariableC = Distribution.VariableC;
            VariableM = Distribution.VariableM;
        }

        public override void Configure()
        {
            Distribution.VariableA = VariableA;
            Distribution.VariableC = VariableC;
            Distribution.VariableM = VariableM;
        }
    }
}
