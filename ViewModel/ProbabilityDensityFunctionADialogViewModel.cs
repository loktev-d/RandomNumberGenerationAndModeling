using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class ProbabilityDensityFunctionADialogViewModel : DistributionDialogViewModel<ProbabilityDensityFunctionA>
    {
        public double VariableA { get; set; }
        public double VariableC { get; set; }
        public double VariableM { get; set; }

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
