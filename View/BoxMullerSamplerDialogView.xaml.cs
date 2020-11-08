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
    /// Логика взаимодействия для BoxMullerSamplerDialogView.xaml
    /// </summary>
    public partial class BoxMullerSamplerDialogView : Window
    {
        public BoxMullerSamplerDialogView(BoxMullerSampler boxMullerSampler)
        {
            InitializeComponent();

            DataContext = new BoxMullerSamplerDialogViewModel(boxMullerSampler, this);
        }
    }
}
