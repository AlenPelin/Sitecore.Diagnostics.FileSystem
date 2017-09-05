namespace Sitecore.Diagnostics.FileSystem.TestingHelpers
{
    using System;
    using System.IO;

    [Serializable]
    public class MockDirectoryData : MockFileData
    {
        public override bool IsDirectory
        {
            get { return true; }
        }

        public MockDirectoryData() : base(string.Empty)
        {
            Attributes = FileAttributes.Directory;
        }
    }
}