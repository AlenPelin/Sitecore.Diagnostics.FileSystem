namespace Sitecore.Diagnostics.FileSystem
{
    using System;
    using System.IO;

    [Serializable]
    internal class FileInfoFactory : IFileInfoFactory
    {
        public FileInfoBase FromFileName(string fileName)
        {
            var realFileInfo = new FileInfo(fileName);
            return new FileInfoWrapper(realFileInfo);
        }
    }
}