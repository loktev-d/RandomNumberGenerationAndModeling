using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class NeumannSamplerDialogViewModel : GeneratorDialogViewModel<NeumannSampler>
    {
        public double FirstBound { get; set; }
        public double SecondBound { get; set; }

        public NeumannSamplerDialogViewModel(NeumannSampler neumannSampler, Window dialogView) : base(neumannSampler, dialogView)
        {
            FirstBound = Generator.FirstHorizontalBound;
            SecondBound = Generator.SecondHorizontalBound;
        }

        public override void Configure()
        {
            Generator.FirstHorizontalBound = FirstBound;
            Generator.SecondHorizontalBound = SecondBound;
        }
    }
}
