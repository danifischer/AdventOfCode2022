internal static class Task
{
    internal static AocDirectory? CurrentDirectory = null;
    internal static List<AocDirectory> Directories = new List<AocDirectory>();

    internal static void Run()
    {
        foreach (var line in File.ReadAllLines("input.txt"))
        {
            if (line[0] == '$')
            {
                ParseCommand(line);
            }
            else
            {
                ParseFile(line);
            }
        }

        foreach (var dir in Directories)
        {
            if(dir.Parent != null)
            {
                dir.Parent.Children.Add(dir);
            }
        }

        GetFiles(new List<AocFile>(), Directories.Single(i => i.Name == "/"));      
        Console.WriteLine($"Task 1: {Directories.Where(i => i.Size < 100000).Sum(j => j.Size)}"); 

        var diskSpaceNeeded = 70000000 - 30000000;
        var diff = Directories.Single(i => i.Name == "/").Size - diskSpaceNeeded;

        foreach (var dir in Directories.OrderBy(i => i.Size))
        {
            if(dir.Size >= diff)
            {
                Console.WriteLine($"Task 2: {dir.Size}"); 
                return;
            } 
        }

    }

    private static List<AocFile> GetFiles(List<AocFile> files, AocDirectory directory)
    {
        var treeFiles = new List<AocFile>();

        foreach (var children in directory.Children)
        {
            treeFiles = GetFiles(treeFiles, children);
        }

        treeFiles.AddRange(directory.Files.AsEnumerable());
        directory.Size = treeFiles.Sum(i => i.Size);
        files.AddRange(treeFiles.AsEnumerable());

        return files;
    }

    private static void ParseCommand(string line)
    {
        var split = line.Split(' ');
        if (split[1] == "cd")
        {
            if (split[2] == "..")
            {
                if (CurrentDirectory != null)
                {
                    CurrentDirectory = CurrentDirectory.Parent;
                }
            }
            else
            {
                var dir = new AocDirectory(split[2], CurrentDirectory);
                CurrentDirectory = dir;
                Directories.Add(dir);
            }
        }
    }

    private static void ParseFile(string line)
    {
        if(CurrentDirectory == null) return;

        var split = line.Split(' ');        
        if(split[0] == "dir") return;
        var file = new AocFile(split[1], long.Parse(split[0]), CurrentDirectory);
        CurrentDirectory.Files.Add(file);
    }
}