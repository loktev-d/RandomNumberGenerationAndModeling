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
    /// Логика взаимодействия для CltSamplerDialogView.xaml
    /// </summary>
    public partial class CltSamplerDialogView : Window
    {
        public CltSamplerDialogView(CltSampler cltSampler)
        {
            InitializeComponent();

            DataContext = new CltSamplerDialogViewModel(cltSampler, this);
        }
    }
}
