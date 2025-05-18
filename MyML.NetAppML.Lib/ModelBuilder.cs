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

            // Build training pipeline
            var dataProcessPipeline = mlContext.Transforms.Categorical.OneHotEncoding("Category")
                .Append(mlContext.Transforms.Concatenate("Features", new[] { "Category", "NumericFeature" }))
                .Append(mlContext.Transforms.NormalizeMinMax("Features"));

            var trainer = mlContext.Regression.Trainers.Sdca(labelColumnName: "Label", featureColumnName: "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            // Train model
            var model = trainingPipeline.Fit(dataView);

            // Save model
            mlContext.Model.Save(model, dataView.Schema, _modelPath);
        }

        public static ModelOutput Predict(ModelInput input)
        {
            var mlContext = new MLContext();

            // Load model
            DataViewSchema modelSchema;
            ITransformer trainedModel = mlContext.Model.Load(_modelPath, out modelSchema);

            // Create prediction engine
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);

            // Predict
            return predEngine.Predict(input);
        }
    }
}