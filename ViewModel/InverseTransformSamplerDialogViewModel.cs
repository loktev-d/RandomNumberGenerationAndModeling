using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class InverseTransformSamplerDialogViewModel : GeneratorDialogViewModel<InverseTransformSampler>
    {
        public InverseTransformSamplerDialogViewModel(InverseTransformSampler inverseTransformSampler, Window dialogview)
            : base(inverseTransformSampler, dialogview)
        {
        }

        public override void Configure()
        {
        }
    }
}
