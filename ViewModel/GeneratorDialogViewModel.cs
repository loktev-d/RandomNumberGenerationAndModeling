using System;
using System.Windows;
using Prism.Commands;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public abstract class GeneratorDialogViewModel<T> : ConfigurationDialogViewModel where T : RandomGenerator
    {
        public T Generator { get; set; }

        public GeneratorDialogViewModel(T generator, Window dialogView) : base(dialogView)
        {
            Generator = generator;
        }
    }
}
