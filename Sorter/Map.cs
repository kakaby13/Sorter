namespace Sorter
{
    public static class Map
    {
        public static List<DirectorySettings> Directories = new List<DirectorySettings>
        {
            new DirectorySettings
            {
                TargetDirectoryName = "Целевая папка 1",
                Tags = new List<string>{"tag1", "tag2", "tag3"}
            },
            new DirectorySettings
            {
                TargetDirectoryName = "Целевая папка 2",
                Tags = new List<string>{"tag4", "tag5"}
            }
        };
    }
}
