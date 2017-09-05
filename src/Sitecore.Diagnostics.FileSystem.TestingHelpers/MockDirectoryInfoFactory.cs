namespace Sitecore.Diagnostics.FileSystem.TestingHelpers
{
    using System;

    [Serializable]
    public class MockDirectoryInfoFactory : IDirectoryInfoFactory
    {
        readonly IMockFileDataAccessor mockFileSystem;

        public MockDirectoryInfoFactory(IMockFileDataAccessor mockFileSystem)
        {
            this.mockFileSystem = mockFileSystem;
        }

        public DirectoryInfoBase FromDirectoryName(string directoryName)
        {
            return new MockDirectoryInfo(mockFileSystem, directoryName);
        }
    }
}