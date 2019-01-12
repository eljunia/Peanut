using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Runtime.Data;

namespace Peanut.Services.MachineLearning
{
    internal class SayingModelPrediction
    {
        [ColumnName(DefaultColumnNames.PredictedLabel)]
        public string Category { get; set; }
    }
}