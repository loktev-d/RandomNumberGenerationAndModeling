using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class NeumannSamplerDialogViewModel : GeneratorDialogViewModel<NeumannSampler>
    {
        public float FirstBound { get; set; }
        public float SecondBound { get; set; }

        public NeumannSamplerDialogViewModel(NeumannSampler neumannSampler, Window dialogView) : base(neumannSampler, dialogView)
        {
            FirstBound = Generator.FirstHorizontalBound;
            SecondBound = Generator.SecondHorizontalBound;
        }

        public override void Configure()
        {
            Generator.Length = Length;
            Generator.FirstHorizontalBound = FirstBound;
            Generator.SecondHorizontalBound = SecondBound;
        }
    }
}
