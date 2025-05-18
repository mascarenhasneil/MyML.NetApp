using Xunit;
using System.IO;

namespace MyML_NetAppML.Tests
{
    public class ModelBuilderTests
    {
        [Fact]
        public void ModelFile_Exists()
        {
            var modelPath = Path.Combine(Directory.GetCurrentDirectory(), "MLModel.zip");
            Assert.True(File.Exists(modelPath), $"Model file not found at: {modelPath}");
        }
    }
}
