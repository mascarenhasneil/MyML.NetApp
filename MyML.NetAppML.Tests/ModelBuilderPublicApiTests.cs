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
            var data = mlContext.Data.LoadFromEnumerable(new List<MyML_NetAppML.Model.ModelInput>());
            var pipeline = ModelBuilder.BuildTrainingPipeline(mlContext);
            var model = ModelBuilder.TrainModel(mlContext, data, pipeline);
            Assert.NotNull(model);
        }

        [Fact]
        public void GetAbsolutePath_ReturnsFullPath()
        {
            var relative = "testfile.txt";
            var full = ModelBuilder.GetAbsolutePath(relative);
            Assert.EndsWith(relative, full);
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
            var metrics = new MulticlassClassificationMetrics(0.9, 0.8, 0.1, new double[] { 0.1, 0.2 });
            ModelBuilder.PrintMulticlassClassificationMetrics(metrics);
            Assert.True(true); // Dummy assertion
        }

        [Fact]
        public void PrintMulticlassClassificationFoldsAverageMetrics_DoesNotThrow()
        {
            var metrics = new MulticlassClassificationMetrics(0.9, 0.8, 0.1, new double[] { 0.1, 0.2 });
            var fold = new Microsoft.ML.TrainCatalogBase.CrossValidationResult<MulticlassClassificationMetrics>
            {
                Metrics = metrics
            };
            var folds = new[] { fold, fold, fold };
            ModelBuilder.PrintMulticlassClassificationFoldsAverageMetrics(folds);
            Assert.True(true); // Dummy assertion
        }
    }
}
