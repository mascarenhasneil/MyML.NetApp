using Xunit;
using System.IO;

namespace MyML_NetAppML.Tests
{
    public class ModelBuilderTests
    {
        [Fact]
        public void ModelFile_Exists()
        {
            var modelPath = Path.Combine("..", "MyML.NetAppML.Model", "MLModel.zip");
            Assert.True(File.Exists(modelPath));
        }
    }
}
