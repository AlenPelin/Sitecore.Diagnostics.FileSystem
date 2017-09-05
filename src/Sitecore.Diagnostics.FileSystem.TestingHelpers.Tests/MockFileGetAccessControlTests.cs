namespace Sitecore.Diagnostics.FileSystem.TestingHelpers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;

    using NUnit.Framework;

    using XFS = MockUnixSupport;

    [TestFixture]
    public class MockFileGetAccessControlTests
    {
        [TestCase(" ")]
        [TestCase("   ")]
        public void MockFile_GetAccessControl_ShouldThrowArgumentExceptionIfPathContainsOnlyWhitespaces(string path)
        {
            // Arrange
            var fileSystem = new MockFileSystem();

            // Act
            TestDelegate action = () => fileSystem.Internals.File.GetAccessControl(path);

            // Assert
            var exception = Assert.Throws<ArgumentException>(action);
            Assert.That(exception.ParamName, Is.EqualTo("path"));
        }

        [Test]
        public void MockFile_GetAccessControl_ShouldThrowFileNotFoundExceptionIfFileDoesNotExistInMockData()
        {
            // Arrange
            var fileSystem = new MockFileSystem();
            var expectedFileName = XFS.Path(@"c:\a.txt");

            // Act
            TestDelegate action = () => fileSystem.Internals.File.GetAccessControl(expectedFileName);

            // Assert
            var exception = Assert.Throws<FileNotFoundException>(action);
            Assert.That(exception.FileName, Is.EqualTo(expectedFileName));
        }

        [Test]
        public void MockFile_GetAccessControl_ShouldReturnAccessControlOfFileData()
        {
            // Arrange
            var expectedFileSecurity = new FileSecurity();
            expectedFileSecurity.SetAccessRuleProtection(false, false);

            var filePath = XFS.Path(@"c:\a.txt");
            var fileData = new MockFileData("Test content")
            {
                AccessControl = expectedFileSecurity,
            };

            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
            {
                {filePath, fileData}
            });

            // Act
            var fileSecurity = fileSystem.Internals.File.GetAccessControl(filePath);

            // Assert
            Assert.That(fileSecurity, Is.EqualTo(expectedFileSecurity));
        }
    }
}