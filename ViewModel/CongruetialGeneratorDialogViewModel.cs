using System;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class CongruetialGeneratorDialogViewModel: GeneratorDialogViewModel<CongruentialGenerator>
    {
        public double Modulus { get; set; }
        public double Seed { get; set; }
        public double Multiplier { get; set; }
        public double Increment { get; set; }

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
