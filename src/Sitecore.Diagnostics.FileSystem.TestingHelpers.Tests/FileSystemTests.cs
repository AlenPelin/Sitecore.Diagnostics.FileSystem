using NUnit.Framework;

namespace Sitecore.Diagnostics.FileSystem.TestingHelpers.Tests
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [TestFixture]
    public class FileSystemTests
    {
        [Test]
        public void Is_Serializable()
        {
            var fileSystem = new FileSystem();
            var memoryStream = new MemoryStream();

            var serializer = new BinaryFormatter();
            serializer.Serialize(memoryStream, fileSystem);

            Assert.That(memoryStream.Length > 0, "Length didn't increase after serialization task.");
        }
    }
}
