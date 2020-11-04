using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using Prism.Commands;
using RandomNumberGenerationAndModeling.Model;
using System.Linq;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class ApplicationViewModel: INotifyPropertyChanged
    {
        private RandomGenerator selectedGenerator;
        private bool isCustomSampler;
        private IEnumerable GeneratedNumbers { get; set; }

        public RandomGenerator SelectedGenerator
        {
            get => selectedGenerator;
            set
            {
                selectedGenerator = value;
                if (selectedGenerator is CustomSampler<DistributionFunction> ||
                    selectedGenerator is CustomSampler<ProbabilityDensityFunction> ||
                    selectedGenerator is CustomSampler<DiscreteDistribution>)
                {
                    IsCustomSampler = true;
                }
                else
                {
                    IsCustomSampler = false;
                }
                OnPropertyChanged("SelectedGenerator");
            }
        }
        public ObservableCollection<RandomGenerator> Generators { get; }
        public DiscreteDistribution SelectedDistribution { get; set; }
        public ObservableCollection<DistributionFunction> Distributions { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCustomSampler
        {
            get => isCustomSampler;
            set
            {
                isCustomSampler = value;
                OnPropertyChanged("IsCustomSampler");
            }
        }

        public DelegateCommand GenerateCommand { get; }
        public DelegateCommand ConfigureCommand { get; }

        public ApplicationViewModel()
        {
            Generators = new ObservableCollection<RandomGenerator>()
            {
                new CongruentialGenerator(34568932, 28934, 30,456,10345),
                new BbsGenerator(1020945, 3247,30),
                new CltSampler(75,54,30,12),
                new BoxMullerSampler(865, 43, 30),
                new NeumannSampler(20, 100,30),
                new InverseTransformSampler(30),
                new LotterySampler(30)
            };

            SelectedGenerator = Generators[0];

            Distributions = new ObservableCollection<DistributionFunction>();


            GenerateCommand = new DelegateCommand(() => GeneratedNumbers = SelectedGenerator.Generate().Cast<float>().ToList());
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
