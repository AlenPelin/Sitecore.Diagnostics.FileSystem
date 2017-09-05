using System.Collections.Generic;
using System.Security.AccessControl;
using NUnit.Framework;

namespace Sitecore.Diagnostics.FileSystem.TestingHelpers.Tests
{
    using System;
    using System.IO;

    public class MockDirectoryArgumentPathTests
    {
        private static IEnumerable<Action<DirectoryBase>> GetFileSystemActionsForArgumentNullException()
        {
            yield return ds => ds.Delete(null);
            yield return ds => ds.Delete(null, true);
            yield return ds => ds.CreateDirectory(null);
            yield return ds => ds.CreateDirectory(null, new DirectorySecurity());
            yield return ds => ds.SetCreationTime(null, DateTime.Now);
            yield return ds => ds.SetCreationTimeUtc(null, DateTime.Now);
            yield return ds => ds.SetLastAccessTime(null, DateTime.Now);
            yield return ds => ds.SetLastAccessTimeUtc(null, DateTime.Now);
            yield return ds => ds.SetLastWriteTime(null, DateTime.Now);
            yield return ds => ds.SetLastWriteTimeUtc(null, DateTime.Now);
            yield return ds => ds.EnumerateDirectories(null);
            yield return ds => ds.EnumerateDirectories(null, "foo");
            yield return ds => ds.EnumerateDirectories(null, "foo", SearchOption.AllDirectories);
        }

        [TestCaseSource("GetFileSystemActionsForArgumentNullException")]
        public void Operations_ShouldThrowArgumentNullExceptionIfPathIsNull(Action<DirectoryBase> action)
        {
            // Arrange
            var fileSystem = new MockFileSystem();

            // Act
            TestDelegate wrapped = () => action(fileSystem.Directory);

            // Assert
            var exception = Assert.Throws<ArgumentNullException>(wrapped);
            Assert.AreEqual("path", exception.ParamName);
        }
    }
}
