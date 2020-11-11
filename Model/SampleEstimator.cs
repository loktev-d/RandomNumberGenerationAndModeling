using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomNumberGenerationAndModeling.Model
{
    public class SampleEstimator : INotifyPropertyChanged
    {
        private double _sampleMathExpectation;
        private double _sampleVariance;
        private double _sampleStandardDeviation;

        public double SampleMathExpectation
        {
            get => _sampleMathExpectation;
            protected set
            {
                _sampleMathExpectation = value;
                OnPropertyChanged("SampleMathExpectation");
            }
        }

        public double SampleVariance
        {
            get => _sampleVariance;
            protected set
            {
                _sampleVariance = value;
                OnPropertyChanged("SampleVariance");
            }
        }

        public double SampleStandardDeviation
        {
            get => _sampleStandardDeviation;
            protected set
            {
                _sampleStandardDeviation = value;
                OnPropertyChanged("SampleStandardDeviation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SampleEstimator()
        {
            SampleMathExpectation = 0;
            SampleVariance = 0;
            SampleStandardDeviation = 0;
        }

        public void EstimateSample(IEnumerable<double> generatedNumbers)
        {
            List<double> sampleNumbers = new List<double>(generatedNumbers);

            foreach (var sampleNumber in sampleNumbers)
            {
                SampleMathExpectation += sampleNumber / sampleNumbers.Count;
                SampleVariance += Math.Pow(SampleVariance, 2) / sampleNumbers.Count;
            }

            SampleVariance = (SampleVariance - Math.Pow(SampleMathExpectation, 2)) * sampleNumbers.Count /
                             (sampleNumbers.Count - 1);

            SampleStandardDeviation = Math.Sqrt(SampleVariance);
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
