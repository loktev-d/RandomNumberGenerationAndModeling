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
using LiveCharts;
using LiveCharts.Wpf;
using RandomNumberGenerationAndModeling.View;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class ApplicationViewModel: INotifyPropertyChanged
    {
        private RandomGenerator _selectedGenerator;
        private DistributionFunction _selectedDistribution;
        private bool _isCustomSampler;
        private bool _isConfigurable;
        private ObservableCollection<DistributionFunction> _currentDistributions;
        private double _mathExpectation;
        private double _variance;
        private double _standardDeviation;

        public SeriesCollection GeneratedNumbers { get; set; }

        public RandomGenerator SelectedGenerator
        {
            get => _selectedGenerator;
            set
            {
                _selectedGenerator = value;
                if (_selectedGenerator is CustomSampler<DistributionFunction> ||
                    _selectedGenerator is CustomSampler<ProbabilityDensityFunction> ||
                    _selectedGenerator is CustomSampler<DiscreteDistribution>)
                {
                    IsCustomSampler = true;
                }
                else
                {
                    IsCustomSampler = false;
                }

                IsConfigurable = DialogViewModels.ContainsKey(_selectedGenerator.GetType());

                CurrentDistributions = new ObservableCollection<DistributionFunction>(Distributions
                    .Where(pair => SelectedGenerator.GetType().Equals(pair.Key)).Select(pair => pair.Value));

                if (CurrentDistributions != null && CurrentDistributions.Count != 0)
                    SelectedDistribution = CurrentDistributions[0];

                OnPropertyChanged("SelectedGenerator");
            }
        }
        public ObservableCollection<RandomGenerator> Generators { get; }
        public Dictionary<Type, Action> DialogViewModels { get; }

        public DistributionFunction SelectedDistribution
        {
            get => _selectedDistribution;
            set
            {
                _selectedDistribution = value;
                OnPropertyChanged("SelectedDistribution");
            }
        }

        public Dictionary<Type, DistributionFunction> Distributions { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCustomSampler
        {
            get => _isCustomSampler;
            set
            {
                _isCustomSampler = value;
                OnPropertyChanged("IsCustomSampler");
            }
        }

        public bool IsConfigurable
        {
            get => _isConfigurable;
            set
            {
                _isConfigurable = value;
                OnPropertyChanged("IsConfigurable");
            }
        }

        public DelegateCommand GenerateCommand { get; }
        public DelegateCommand ConfigureMethodCommand { get; }
        public DelegateCommand ConfigureDistributionCommand { get; }

        public ObservableCollection<DistributionFunction> CurrentDistributions
        {
            get => _currentDistributions;
            set
            {
                _currentDistributions = value; 
                OnPropertyChanged("CurrentDistributions");
            }
        }

        public SampleEstimator Estimator { get; }

        public double MathExpectation
        {
            get => _mathExpectation;
            set
            {
                _mathExpectation = value;
                OnPropertyChanged("MathExpectation");
            }
        }

        public double Variance
        {
            get => _variance;
            set
            {
                _variance = value;
                OnPropertyChanged("Variance");
            }
        }

        public double StandardDeviation
        {
            get => _standardDeviation;
            set
            {
                _standardDeviation = value;
                OnPropertyChanged("StandardDeviation");
            }
        }

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

            DialogViewModels = new Dictionary<Type, Action>()
            {
                {
                    typeof(CongruentialGenerator),
                    () => new CongruentialGeneratorDialogView((CongruentialGenerator) SelectedGenerator).ShowDialog()
                },
                {typeof(BbsGenerator), () => new BbsGeneratorDialogView((BbsGenerator) SelectedGenerator).ShowDialog()},
                {typeof(CltSampler), () => new CltSamplerDialogView((CltSampler) SelectedGenerator).ShowDialog()},
                {typeof(BoxMullerSampler), () => new  BoxMullerSamplerDialogView((BoxMullerSampler) SelectedGenerator).ShowDialog()},
                {typeof(NeumannSampler), () => new NeumannSamplerDialogView((NeumannSampler) SelectedGenerator).ShowDialog()},
                {typeof(InverseTransformSampler), () => new InverseTransformSamplerDialogView((InverseTransformSampler) SelectedGenerator).ShowDialog()},
                {typeof(GeometricDistribution), () => new GeometricDistributionDialogView((GeometricDistribution) SelectedDistribution).ShowDialog()},
                {typeof(InverseRayleighFunction), () => new InverseRayleighFunctionDialogView((InverseRayleighFunction) SelectedDistribution).ShowDialog()},
                {typeof(ProbabilityDensityFunctionA), () => new ProbabilityDensityFunctionAView((ProbabilityDensityFunctionA) SelectedDistribution).ShowDialog()}
            };

            Distributions = new Dictionary<Type, DistributionFunction>()
            {
                {typeof(LotterySampler), new GeometricDistribution(30, 0.4)},
                {typeof(InverseTransformSampler), new InverseRayleighFunction(934)},
                {typeof(NeumannSampler), new ProbabilityDensityFunctionA(234, 6453, 23)}
            };

            SelectedGenerator = Generators[0];

            GenerateCommand = new DelegateCommand(Generate);
            ConfigureMethodCommand = new DelegateCommand(ConfigureMethod);
            ConfigureDistributionCommand = new DelegateCommand(ConfigureDistribution);

            GeneratedNumbers = new SeriesCollection()
            {
                new ColumnSeries()
            };

            Estimator = new SampleEstimator();
        }

        public void ConfigureMethod()
        {
            DialogViewModels[SelectedGenerator.GetType()].Invoke();
        }

        public void ConfigureDistribution()
        {
            DialogViewModels[SelectedDistribution.GetType()].Invoke();
        }

        public void Generate()
        {
            if (SelectedGenerator is CustomSampler<DistributionFunction>)
            {
                ((CustomSampler<DistributionFunction>) SelectedGenerator).Distribution = SelectedDistribution;
            }
            if (SelectedGenerator is CustomSampler<DiscreteDistribution>)
            {
                ((CustomSampler<DiscreteDistribution>)SelectedGenerator).Distribution = (DiscreteDistribution) SelectedDistribution;
            }
            if (SelectedGenerator is CustomSampler<ProbabilityDensityFunction>)
            {
                ((CustomSampler<ProbabilityDensityFunction>)SelectedGenerator).Distribution = (ProbabilityDensityFunction) SelectedDistribution;
            }

            MathExpectation = SelectedGenerator.MathExpectation;
            Variance = SelectedGenerator.Variance;
            StandardDeviation = SelectedGenerator.StandardDeviation;

            IEnumerable<double> numbers = SelectedGenerator.Generate();
            GeneratedNumbers[0].Values = new ChartValues<double>(numbers);
            Estimator.EstimateSample(numbers);
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
