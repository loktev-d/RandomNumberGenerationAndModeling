using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumberGenerationAndModeling.Model
{
    public class RandomModel
    {
        public UniformGenerator Generator { get; set; }
        public DataEstimator Estimator { get; set; }

        public void Execute()
        {
            Generator.Generate();
            Estimator.Estimate();
        }
    }
}
