internal static class Task
{
    internal static AocDirectory? CurrentDirectory = null;
    internal static List<AocDirectory> Directories = new List<AocDirectory>();

    internal static void Run()
    {
        foreach (var line in File.ReadAllLines("input.txt"))
        {
            var split = line.Split(' ');
            HandleInput(split[0], split[1], split.Length == 3 ? split[2] : "")();
        }

        Console.WriteLine($"Task 1: {Directories.Where(i => i.Size < 100000).Sum(j => j.Size)}");

        var spaceThreshold = Directories.Single(i => i.Name == "/").Size - (70000000 - 30000000);

        foreach (var dir in Directories.OrderBy(i => i.Size))
        {
            if (dir.Size >= spaceThreshold)
            {
                Console.WriteLine($"Task 2: {dir.Size}");
                return;
            }
        }
    }

    private static Action HandleInput(string first, string second, string third)
    => (first, second, third) switch
    {
        ("$", "cd", "..") => new Action(() => CurrentDirectory = CurrentDirectory?.Parent),
        ("$", "cd", _) => new Action(() => AddDir(third)),
        ("$", _, _) => new Action(() => { }),
        ("dir", _, _) => new Action(() => { }),
        (_, _, _) => new Action(() => AddSize(first)),
    };

    private static void AddDir(string name)
    {
        var dir = new AocDirectory(name, CurrentDirectory);
        CurrentDirectory = dir;
        Directories.Add(dir);
    }

    private static void AddSize(string size)
    {
        AddSizeToParent(long.Parse(size), CurrentDirectory!);
    }

    private static void AddSizeToParent(long size, AocDirectory directory)
    {
        directory.Size += size;
        if (directory.Parent != null)
        {
            AddSizeToParent(size, directory.Parent);
        }
    }
}