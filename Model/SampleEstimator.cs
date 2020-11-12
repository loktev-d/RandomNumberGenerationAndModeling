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
            double sampleMathExpectation = 0;
            double sampleVariance = 0;
            double sampleStandardDeviation = 0;

            List<double> sampleNumbers = new List<double>(generatedNumbers);

            foreach (var sampleNumber in sampleNumbers)
            {
                sampleMathExpectation += sampleNumber / sampleNumbers.Count;
                sampleVariance += Math.Pow(sampleNumber, 2) / sampleNumbers.Count;
            }

            sampleVariance = (sampleVariance - Math.Pow(sampleMathExpectation, 2)) * sampleNumbers.Count /
                             (sampleNumbers.Count - 1);

            sampleStandardDeviation = Math.Sqrt(sampleVariance);

            SampleMathExpectation = sampleMathExpectation;
            SampleVariance = sampleVariance;
            SampleStandardDeviation = sampleStandardDeviation;
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
