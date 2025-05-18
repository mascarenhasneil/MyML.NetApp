using Xunit;
using MyML_NetAppML.Model;

namespace MyML_NetAppML.Tests
{
    public class ConsumeModelTests
    {
        [Fact]
        public void ModelInput_CanBeCreated()
        {
            var input = new ModelInput { SentimentText = "This is a test." };
            Assert.Equal("This is a test.", input.SentimentText);
        }

        [Fact]
        public void ModelOutput_CanBeCreated()
        {
            var output = new ModelOutput { Prediction = "Positive", Score = new float[] { 0.9f, 0.1f } };
            Assert.Equal("Positive", output.Prediction);
            Assert.NotNull(output.Score);
            Assert.Equal(2, output.Score.Length);
            Assert.Equal(0.9f, output.Score[0]);
            Assert.Equal(0.1f, output.Score[1]);
        }

        [Fact]
        public void ConsumeModel_Predict_ReturnsOutput()
        {
            var input = new ModelInput { SentimentText = "good" };
            var result = ConsumeModel.Predict(input);
            Assert.NotNull(result);
            Assert.IsType<ModelOutput>(result);
            Assert.NotNull(result.Prediction);
            Assert.NotNull(result.Score);
        }
    }
}
