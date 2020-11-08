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
using System.Windows;
using RandomNumberGenerationAndModeling.View;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class ApplicationViewModel: INotifyPropertyChanged
    {
        private RandomGenerator selectedGenerator;
        private bool isCustomSampler;
        private bool isConfigurable;
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

                IsConfigurable = GeneratorViewModels.ContainsKey(selectedGenerator.GetType());

                OnPropertyChanged("SelectedGenerator");
            }
        }
        public ObservableCollection<RandomGenerator> Generators { get; }
        public Dictionary<Type, Action> GeneratorViewModels { get; set; }
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

        public bool IsConfigurable
        {
            get => isConfigurable;
            set
            {
                isConfigurable = value;
                OnPropertyChanged("IsConfigurable");
            }
        }

        public DelegateCommand GenerateCommand { get; }
        public DelegateCommand ConfigureMethodCommand { get; }
        public DelegateCommand ConfigureDistributionCommand { get; }

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
                new LotterySampler()
            };

            GeneratorViewModels = new Dictionary<Type, Action>()
            {
                {
                    typeof(CongruentialGenerator),
                    () => new CongruentialGeneratorDialogView((CongruentialGenerator) SelectedGenerator).ShowDialog()
                },
                {typeof(BbsGenerator), () => new BbsGeneratorDialogView((BbsGenerator) SelectedGenerator).ShowDialog()},
                {typeof(CltSampler), () => new CltSamplerDialogView((CltSampler) SelectedGenerator).ShowDialog()},
                {typeof(BoxMullerSampler), () => new  BoxMullerSamplerDialogView((BoxMullerSampler) SelectedGenerator).ShowDialog()},
                {typeof(NeumannSampler), () => new NeumannSamplerDialogView((NeumannSampler) SelectedGenerator).ShowDialog()},
                {typeof(InverseTransformSampler), () => new InverseTransformSamplerDialogView((InverseTransformSampler) SelectedGenerator).ShowDialog()}
            };
            
            SelectedGenerator = Generators[0];

            Distributions = new ObservableCollection<DistributionFunction>();

            GenerateCommand = new DelegateCommand(() => GeneratedNumbers = SelectedGenerator.Generate().Cast<float>().ToList());
            ConfigureMethodCommand = new DelegateCommand(ConfigureMethod);
            ConfigureDistributionCommand = new DelegateCommand(ConfigureDistribution);
        }

        public void ConfigureMethod()
        {
            GeneratorViewModels[SelectedGenerator.GetType()].Invoke();
        }

        public void ConfigureDistribution()
        {

        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
