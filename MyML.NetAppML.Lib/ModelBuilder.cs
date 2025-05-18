using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using MyML_NetAppML.Model;

namespace MyML_NetAppML.Lib
{
    public static class ModelBuilder
    {
        private static string _dataPath = Path.Combine(Environment.CurrentDirectory, "data", "data.csv");
        private static string _modelPath = Path.Combine(Environment.CurrentDirectory, "data", "model.zip");

        public static void CreateModel()
        {
            var mlContext = new MLContext();

            // Load data
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                path: _dataPath,
                hasHeader: true,
                separatorChar: ',');

            // Build training pipeline (match BuildTrainingPipeline)
            var trainingPipeline = BuildTrainingPipeline(mlContext);

            // Train model
            var model = trainingPipeline.Fit(dataView);

            // Save model
            mlContext.Model.Save(model, dataView.Schema, _modelPath);
        }

        public static ModelOutput Predict(ModelInput input)
        {
            var mlContext = new MLContext();

            if (!File.Exists(_modelPath))
                throw new FileNotFoundException("Trained model file not found.", _modelPath);

            // Load model
            DataViewSchema modelSchema;
            ITransformer trainedModel = mlContext.Model.Load(_modelPath, out modelSchema);

            // Create prediction engine
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);

            // Predict
            return predEngine.Predict(input);
        }

        // Builds a sample training pipeline for multiclass classification
        public static IEstimator<ITransformer> BuildTrainingPipeline(MLContext mlContext)
        {
            ArgumentNullException.ThrowIfNull(mlContext);
            return mlContext.Transforms.Text.FeaturizeText("Features", nameof(ModelInput.SentimentText))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(ModelInput.Sentiment)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
        }

        // Trains a model using the provided pipeline
        public static ITransformer TrainModel(MLContext mlContext, IDataView data, IEstimator<ITransformer> pipeline)
        {
            ArgumentNullException.ThrowIfNull(mlContext);
            ArgumentNullException.ThrowIfNull(data);
            ArgumentNullException.ThrowIfNull(pipeline);
            return pipeline.Fit(data);
        }

        // Returns the absolute path for a given relative path
        public static string GetAbsolutePath(string relativePath)
        {
            return Path.GetFullPath(relativePath);
        }

        // Calculates the standard deviation of a sequence
        public static double CalculateStandardDeviation(IEnumerable<double> values)
        {
            ArgumentNullException.ThrowIfNull(values);
            var arr = values.ToArray();
            if (arr.Length == 0) return 0;
            var avg = arr.Average();
            var sum = arr.Sum(d => Math.Pow(d - avg, 2));
            return Math.Sqrt(sum / arr.Length);
        }

        // Calculates the 95% confidence interval for a sequence
        public static double CalculateConfidenceInterval95(IEnumerable<double> values)
        {
            ArgumentNullException.ThrowIfNull(values);
            var arr = values.ToArray();
            if (arr.Length == 0) return 0;
            var std = CalculateStandardDeviation(arr);
            return 1.96 * std / Math.Sqrt(arr.Length);
        }

        // Prints multiclass classification metrics
        public static void PrintMulticlassClassificationMetrics(MulticlassClassificationMetrics metrics)
        {
            if (metrics == null) throw new ArgumentNullException(nameof(metrics));
            Console.WriteLine($"MacroAccuracy: {metrics.MacroAccuracy}");
            Console.WriteLine($"MicroAccuracy: {metrics.MicroAccuracy}");
            Console.WriteLine($"LogLoss: {metrics.LogLoss}");
            Console.WriteLine($"PerClassLogLoss: [{string.Join(", ", metrics.PerClassLogLoss)}]");
        }

        // Prints average metrics for cross-validation folds
        public static void PrintMulticlassClassificationFoldsAverageMetrics(IEnumerable<Microsoft.ML.TrainCatalogBase.CrossValidationResult<MulticlassClassificationMetrics>> crossValResults)
        {
            ArgumentNullException.ThrowIfNull(crossValResults);
            var metrics = crossValResults.Select(r => r.Metrics);
            Console.WriteLine($"Average MacroAccuracy: {metrics.Average(m => m.MacroAccuracy)}");
            Console.WriteLine($"Average MicroAccuracy: {metrics.Average(m => m.MicroAccuracy)}");
            Console.WriteLine($"Average LogLoss: {metrics.Average(m => m.LogLoss)}");
        }
    }
}