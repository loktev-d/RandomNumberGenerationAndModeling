using System;
using System.Windows;
using Prism.Commands;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public abstract class GeneratorDialogViewModel<T> where T : RandomGenerator
    {
        public T Generator { get; set; }
        public int Length { get; set; }
        public DelegateCommand ConfigureCommand { get; }

        public GeneratorDialogViewModel(T generator, Window dialogView)
        {
            Generator = generator;
            Length = generator.Length;
            ConfigureCommand=new DelegateCommand(() =>
            {
                Configure();
                dialogView.DialogResult = true;
            });
        }

        public abstract void Configure();
    }
}
