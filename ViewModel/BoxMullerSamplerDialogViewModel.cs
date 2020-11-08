using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class BoxMullerSamplerDialogViewModel : GeneratorDialogViewModel<BoxMullerSampler>
    {
        public float Shift { get; set; }
        public float Scale { get; set; }

        public BoxMullerSamplerDialogViewModel(BoxMullerSampler boxMullerSampler, Window dialogView) : base(boxMullerSampler, dialogView)
        {
            Shift = Generator.Shift;
            Scale = Generator.Scale;
        }

        public override void Configure()
        {
            Generator.Length = Length;
            Generator.Shift = Shift;
            Generator.Scale = Scale;
        }
    }
}
