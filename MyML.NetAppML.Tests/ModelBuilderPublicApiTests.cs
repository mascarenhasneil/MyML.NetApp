using Xunit;
using MyML_NetAppML.Lib;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyML_NetAppML.Tests
{
    public class ModelBuilderPublicApiTests
    {
        [Fact]
        public void BuildTrainingPipeline_ReturnsPipeline()
        {
            var mlContext = new MLContext();
            var pipeline = ModelBuilder.BuildTrainingPipeline(mlContext);
            Assert.NotNull(pipeline);
        }

        [Fact]
        public void TrainModel_ThrowsOnNulls()
        {
            var mlContext = new MLContext();
            var data = mlContext.Data.LoadFromEnumerable(new List<MyML_NetAppML.Model.ModelInput>());
            var pipeline = ModelBuilder.BuildTrainingPipeline(mlContext);
            Assert.Throws<ArgumentNullException>(() => ModelBuilder.TrainModel(null, data, pipeline));
            Assert.Throws<ArgumentNullException>(() => ModelBuilder.TrainModel(mlContext, null, pipeline));
            Assert.Throws<ArgumentNullException>(() => ModelBuilder.TrainModel(mlContext, data, null));
        }

        [Fact]
        public void TrainModel_ReturnsModel()
        {
            var mlContext = new MLContext();
            var data = mlContext.Data.LoadFromEnumerable(new List<MyML_NetAppML.Model.ModelInput>
            {
                new MyML_NetAppML.Model.ModelInput { SentimentText = "This is great!", Sentiment = "Positive", LoggedIn = true },
                new MyML_NetAppML.Model.ModelInput { SentimentText = "This is bad!", Sentiment = "Negative", LoggedIn = false }
            });
            var pipeline = ModelBuilder.BuildTrainingPipeline(mlContext);
            var model = ModelBuilder.TrainModel(mlContext, data, pipeline);
            Assert.NotNull(model);
        }

        [Fact]
        public void GetAbsolutePath_ReturnsFullPath()
        {
            var relative = "testfile.txt";
            var full = ModelBuilder.GetAbsolutePath(relative);
            Assert.EndsWith(relative, full, StringComparison.Ordinal);
            Assert.True(Path.IsPathRooted(full));
        }

        [Fact]
        public void CalculateStandardDeviation_Works()
        {
            var values = new double[] { 1, 2, 3, 4, 5 };
            var std = ModelBuilder.CalculateStandardDeviation(values);
            Assert.True(std > 0);
        }

        [Fact]
        public void CalculateConfidenceInterval95_Works()
        {
            var values = new double[] { 1, 2, 3, 4, 5 };
            var ci = ModelBuilder.CalculateConfidenceInterval95(values);
            Assert.True(ci > 0);
        }

        [Fact]
        public void PrintMulticlassClassificationMetrics_DoesNotThrow()
        {
            var mlContext = new MLContext();
            var data = mlContext.Data.LoadFromEnumerable(new List<MyML_NetAppML.Model.ModelInput>
            {
                new MyML_NetAppML.Model.ModelInput { SentimentText = "This is great!", Sentiment = "Positive", LoggedIn = true },
                new MyML_NetAppML.Model.ModelInput { SentimentText = "This is bad!", Sentiment = "Negative", LoggedIn = false }
            });
            var pipeline = ModelBuilder.BuildTrainingPipeline(mlContext);
            var model = pipeline.Fit(data);
            var predictions = model.Transform(data);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions);
            ModelBuilder.PrintMulticlassClassificationMetrics(metrics);
            Assert.True(true); // Dummy assertion
        }

        [Fact(Skip = "Cannot construct CrossValidationResult<MulticlassClassificationMetrics> directly; tested via integration.")]
        public void PrintMulticlassClassificationFoldsAverageMetrics_DoesNotThrow()
        {
            // Skipped: No public constructor for CrossValidationResult<T>.
            Assert.True(true);
        }

        [Fact]
        public void Predict_ThrowsFileNotFoundException_WhenModelFileMissing()
        {
            // Arrange: Temporarily rename the model file if it exists
            var modelPath = Path.Combine(Environment.CurrentDirectory, "..", "MyML.NetAppML.Model", "MLModel.zip");
            var backupPath = modelPath + ".bak";
            bool modelExisted = false;
            if (File.Exists(modelPath))
            {
                File.Move(modelPath, backupPath);
                modelExisted = true;
            }

            try
            {
                var input = new MyML_NetAppML.Model.ModelInput { SentimentText = "test", Sentiment = "Positive", LoggedIn = true };
                Assert.Throws<FileNotFoundException>(() => ModelBuilder.Predict(input));
            }
            finally
            {
                // Restore the model file if it was renamed
                if (modelExisted && File.Exists(backupPath))
                    File.Move(backupPath, modelPath);
            }
        }
    }
}
