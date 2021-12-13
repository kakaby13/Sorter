using System;
using System.IO;
using System.IO.Compression;

namespace Sorter
{
    public static class FileHelper
    {
        public static void MoveEntireFolder(string what, string to)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var tempArchiveName = $"temp-{Guid.NewGuid()}.zip";
            ZipFile.CreateFromDirectory(what, tempArchiveName, CompressionLevel.Fastest, true);

            var itemToMove = $"{currentDirectory}\\{tempArchiveName}";
            var newPath = $"{currentDirectory}\\{to}";

            ZipFile.ExtractToDirectory(itemToMove, newPath, true);
            File.Delete(itemToMove);
            Directory.Delete(what, true);
        }
    }
}
