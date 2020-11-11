using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class CltSamplerDialogViewModel: GeneratorDialogViewModel<CltSampler>
    {
        public double Shift { get; set; }
        public double Scale { get; set; }
        public int PopulationSize { get; set; }

        public CltSamplerDialogViewModel(CltSampler cltSampler, Window dialogView) : base(cltSampler, dialogView)
        {
            Shift = Generator.Shift;
            Scale = Generator.Scale;
            PopulationSize = Generator.PopulationSize;
        }

        public override void Configure()
        {
            Generator.Length = Length;
            Generator.Shift = Shift;
            Generator.Scale = Scale;
            Generator.PopulationSize = PopulationSize;
        }
    }
}
