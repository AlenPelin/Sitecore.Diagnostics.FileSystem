namespace Sitecore.Diagnostics.FileSystem
{
    public interface IFileSystemInternals
    {
        FileBase File { get; }
        DirectoryBase Directory { get; }
        IFileInfoFactory FileInfo { get; }
        PathBase Path { get; }
        IDirectoryInfoFactory DirectoryInfo { get; }
        IDriveInfoFactory DriveInfo { get; }
    }
}