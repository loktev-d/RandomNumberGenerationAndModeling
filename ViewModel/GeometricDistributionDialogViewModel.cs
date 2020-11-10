﻿using System;
using System.Collections.Generic;
using System.Windows;
using RandomNumberGenerationAndModeling.Model;

namespace RandomNumberGenerationAndModeling.ViewModel
{
    public class GeometricDistributionDialogViewModel : DistributionDialogViewModel<GeometricDistribution>
    {
        public int Length { get; set; }
        public float SuccessProbability { get; set; }

        public GeometricDistributionDialogViewModel(GeometricDistribution geometricDistribution, Window dialogView) 
            : base(geometricDistribution, dialogView)
        {
            Length = Distribution.Length;
            SuccessProbability = Distribution.SuccessProbability;
        }

        public override void Configure()
        {
            Distribution.Length = Length;
            Distribution.SuccessProbability = SuccessProbability;
        }
    }
}