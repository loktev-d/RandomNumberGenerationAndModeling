using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public abstract class DistributionDialogViewModel<T> : ConfigurationDialogViewModel where T: DistributionFunction
    {
        public T Distribution { get; set; }

        public DistributionDialogViewModel(T distribution, Window dialogView) : base(dialogView)
        {
            Distribution = distribution;
        }
    }
}
