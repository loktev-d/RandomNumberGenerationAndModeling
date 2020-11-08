using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RandomNumberGenerationAndModeling.Model;
using RandomNumberGenerationAndModeling.ViewModel;

namespace RandomNumberGenerationAndModeling.View
{
    /// <summary>
    /// Логика взаимодействия для NeumannSamplerDialogView.xaml
    /// </summary>
    public partial class NeumannSamplerDialogView : Window
    {
        public NeumannSamplerDialogView(NeumannSampler neumannSampler)
        {
            InitializeComponent();

            DataContext = new NeumannSamplerDialogViewModel(neumannSampler, this);
        }
    }
}
