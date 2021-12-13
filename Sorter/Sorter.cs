using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sorter
{
    public static class Sorter
    {
        public static void Run()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Текущая папка: {currentDirectory} \n");

            foreach (var targetFolder in Map.Directories)
            {
                Console.WriteLine($"Обрабатывается: {targetFolder.TargetDirectoryName}");
                var matchedDirectories = FindMatches(targetFolder, currentDirectory);

                foreach (var matchedDirectory in matchedDirectories)
                {
                    FileHelper.MoveEntireFolder(matchedDirectory, targetFolder.TargetDirectoryName);
                    Console.WriteLine($"Переместили: {matchedDirectory}");
                }

                Console.WriteLine($"Всего перемещено: {matchedDirectories.Count} \n \n");
            }

            Console.ReadKey();

        }

        private static List<string> FindMatches(DirectorySettings targetFolder, string currentDirectory)
        {
            var  matchedDirectories = new List<string>();
            foreach (var directoryTag in targetFolder.Tags)
            {
                matchedDirectories.AddRange(
                    Directory
                        .GetDirectories(currentDirectory)
                        .Where(c => c.ToLower()
                            .Contains(directoryTag.ToLower())));
            }

            return matchedDirectories.Distinct().ToList();
        }
    }
}
