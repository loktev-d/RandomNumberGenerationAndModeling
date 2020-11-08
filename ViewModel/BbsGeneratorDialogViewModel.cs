using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class BbsGeneratorDialogViewModel: GeneratorDialogViewModel<BbsGenerator>
    {
        public long Modulus { get; set; }
        public long Seed { get; set; }

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
