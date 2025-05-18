using Xunit;
using MyML_NetAppML.Model;

namespace MyML_NetAppML.Tests
{
    public class ModelInputOutputTests
    {
        [Fact]
        public void ModelInput_DefaultValues()
        {
            var input = new ModelInput();
            Assert.Null(input.SentimentText);
        }

        [Fact]
        public void ModelOutput_DefaultValues()
        {
            var output = new ModelOutput();
            Assert.Null(output.Prediction);
            Assert.Null(output.Score);
        }
    }
}
