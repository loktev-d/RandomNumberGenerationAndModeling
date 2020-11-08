using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class CongruetialGeneratorDialogViewModel: GeneratorDialogViewModel<CongruentialGenerator>
    {
        public long Modulus { get; set; }
        public long Seed { get; set; }
        public long Multiplier { get; set; }
        public long Increment { get; set; }

        public CongruetialGeneratorDialogViewModel(CongruentialGenerator congruentialGenerator, Window dialogView) 
            : base(congruentialGenerator, dialogView)
        {
            Modulus = Generator.Modulus;
            Seed = Generator.Seed;
            Multiplier = Generator.Multiplier;
            Increment = Generator.Increment;
        }

        public override void Configure()
        {
            Generator.Length = Length;
            Generator.Modulus = Modulus; 
            Generator.Seed = Seed;
            Generator.Multiplier = Multiplier;
            Generator.Increment = Increment;
        }
    }
}
