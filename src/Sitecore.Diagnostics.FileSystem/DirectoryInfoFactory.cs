namespace Sitecore.Diagnostics.FileSystem
{
    using System;
    using System.IO;

    [Serializable]
    internal class DirectoryInfoFactory : IDirectoryInfoFactory
    {
        public DirectoryInfoBase FromDirectoryName(string directoryName)
        {
            var realDirectoryInfo = new DirectoryInfo(directoryName);
            return new DirectoryInfoWrapper(realDirectoryInfo);
        }
    }
}