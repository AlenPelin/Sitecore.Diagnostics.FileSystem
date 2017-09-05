namespace Sitecore.Diagnostics.FileSystem
{
    public interface IFileSystem
    {
        IFileSystemInternals Internals { get; }
        IFile ParseFile(string fullName);
        IDirectory ParseDirectory(string fullName);
    }
}