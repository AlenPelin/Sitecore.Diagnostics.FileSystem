namespace Sitecore.Diagnostics.FileSystem.Extensions
{
    using System.IO;
    using Sitecore.Diagnostics.FileSystem;

    using JetBrains.Annotations;

    public static class FileExtensions
    {
        [NotNull]
        public static IFile CopyTo([NotNull] this IFile file, [NotNull] IDirectory parent)
        {
            return file.CopyTo(parent.GetChildFile(file.Name).FullName);
        }

        [NotNull]
        public static IFile MoveTo([NotNull] this IFile file, [NotNull] IDirectory parent)
        {
            var newFile = parent.GetChildFile(file.Name);
            file.MoveTo(newFile.FullName);

            return newFile;
        }

        public static void WriteAllText([NotNull] this IFile file, [NotNull] string text)
        {
            using (var writer = new StreamWriter(file.OpenWrite()))
            {
                writer.Write(text);
            }
        }

        public static string ReadAllText([NotNull] this IFile file)
        {
            using (var reader = new StreamReader(file.OpenRead()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}