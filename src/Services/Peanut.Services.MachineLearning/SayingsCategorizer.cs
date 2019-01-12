using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using Microsoft.ML.Runtime.Data;

namespace Peanut.Services.MachineLearning
{
    public class SayingsCategorizer : ISayingsCategorizer
    {
        public string Categorize(string modelFile, string sayingContent)
        {
            var mlContext = new MLContext(seed: 0);
            ITransformer trainedModel;
            using (var stream = new FileStream(modelFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                trainedModel = mlContext.Model.Load(stream);
            }

            var predFunction = trainedModel.MakePredictionFunction<SayingModel, SayingModelPrediction>(mlContext);
            var prediction = predFunction.Predict(new SayingModel { Content = sayingContent });
            return prediction.Category;
        }
    }
}