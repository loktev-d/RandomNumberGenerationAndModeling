using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class BoxMullerSamplerDialogViewModel : GeneratorDialogViewModel<BoxMullerSampler>
    {
        public double Shift { get; set; }
        public double Scale { get; set; }

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
