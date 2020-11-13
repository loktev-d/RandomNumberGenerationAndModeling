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
        private ChartValues<double> _generatedNumbers;
        private ChartValues<double> _frequencies;

        public ChartValues<double> GeneratedNumbers
        {
            get => _generatedNumbers;
            set
            {
                _generatedNumbers = value;
                OnPropertyChanged("GeneratedNumbers");
            }
        }

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

        public int SampleSize { get; set; }
        public int BinsCount { get; set; }

        public ChartValues<double> Frequencies
        {
            get => _frequencies;
            set
            {
                _frequencies = value;
                OnPropertyChanged("Frequencies");
            }
        }

        public ApplicationViewModel()
        {
            SampleSize = 70;
            BinsCount = 10;

            Generators = new ObservableCollection<RandomGenerator>()
            {
                new CongruentialGenerator(1000, 893, 24, 7, SampleSize),
                new BbsGenerator(26649, 863, SampleSize),
                new CltSampler(75, 54, 15, SampleSize),
                new BoxMullerSampler(865, 43, SampleSize),
                new NeumannSampler(-10000, 10000, SampleSize),
                new InverseTransformSampler(SampleSize),
                new LotterySampler(SampleSize)
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
                {typeof(GeometricDistribution), () => new GeometricDistributionDialogView((GeometricDistribution) SelectedDistribution).ShowDialog()},
                {typeof(InverseRayleighFunction), () => new InverseRayleighFunctionDialogView((InverseRayleighFunction) SelectedDistribution).ShowDialog()},
                {typeof(ProbabilityDensityFunctionA), () => new ProbabilityDensityFunctionAView((ProbabilityDensityFunctionA) SelectedDistribution).ShowDialog()}
            };

            Distributions = new Dictionary<Type, DistributionFunction>()
            {
                {typeof(LotterySampler), new GeometricDistribution(0.4)},
                {typeof(InverseTransformSampler), new InverseRayleighFunction(934)},
                {typeof(NeumannSampler), new ProbabilityDensityFunctionA(234, 6453, 23)}
            };

            SelectedGenerator = Generators[0];

            GenerateCommand = new DelegateCommand(Execute);
            ConfigureMethodCommand = new DelegateCommand(ConfigureMethod);
            ConfigureDistributionCommand = new DelegateCommand(ConfigureDistribution);

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

        public void Execute()
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

            SelectedGenerator.Length = SampleSize;

            double[] numbers = SelectedGenerator.Generate().ToArray();
            if (numbers.Length < 1000)
            {
                GeneratedNumbers = new ChartValues<double>(numbers);
            }
            else
            {
                GeneratedNumbers = new ChartValues<double>();
            }
            Estimator.EstimateSample(numbers);

            double[] frequencies = Histogram.CountFrequencies(numbers, BinsCount).ToArray();
            Frequencies = new ChartValues<double>(frequencies);
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
