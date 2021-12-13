using Sorter;
using Directory = System.IO.Directory;

var currentDirectory = Directory.GetCurrentDirectory();
//var currentDirectory = "D:\\playground";
Console.WriteLine($"Текущая папка: {currentDirectory}");
Console.WriteLine("");

foreach (var directory in Map.Directories)
{
    Console.WriteLine($"Обрабатывается: {directory.TargetDirectoryName}");
    var filesInDirectory = new List<string>();

    var files = Directory.GetFiles(currentDirectory);
    foreach (var directoryTag in directory.Tags)
    {
        filesInDirectory.AddRange(files.Where(c=>c.Contains(directoryTag)));
    }

    foreach (var file in filesInDirectory.Distinct())
    {
        var fileName = Path.GetFileName(file);
        var newPath = $"{currentDirectory}\\{directory.TargetDirectoryName}\\{fileName}";
        File.Move(file, newPath);
        Console.WriteLine($"Переместили: {fileName}");
    }

    Console.WriteLine($"Всего перемещено: {filesInDirectory.Distinct().Count()}");
    Console.WriteLine("");
    Console.WriteLine("");
}

Console.ReadKey();