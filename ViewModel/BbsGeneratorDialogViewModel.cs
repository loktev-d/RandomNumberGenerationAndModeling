using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class BbsGeneratorDialogViewModel: GeneratorDialogViewModel<BbsGenerator>
    {
        public double Modulus { get; set; }
        public double Seed { get; set; }

        public BbsGeneratorDialogViewModel(BbsGenerator bbsGenerator, Window dialogView) : base(bbsGenerator, dialogView)
        {
            Modulus = Generator.Modulus;
            Seed = Generator.Seed;
        }

        public override void Configure()
        {
            Generator.Length = Length;
            Generator.Modulus = Modulus;
            Generator.Seed = Seed;
        }
    }
}
