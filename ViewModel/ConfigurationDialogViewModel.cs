using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Prism.Commands;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public abstract class ConfigurationDialogViewModel
    {
        public DelegateCommand ConfigureCommand { get; }

        public ConfigurationDialogViewModel(Window dialogView)
        {
            ConfigureCommand = new DelegateCommand(() =>
            {
                Configure();
                dialogView.DialogResult = true;
            });
        }

        public abstract void Configure();
    }
}
