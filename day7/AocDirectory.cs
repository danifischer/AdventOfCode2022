internal class AocDirectory
{
    public AocDirectory(string name, AocDirectory? parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public string Name { get; }

    public long Size { get; set; }

    public List<AocDirectory> Children {get; } = new();

    public List<AocFile> Files {get; } = new();

    public AocDirectory? Parent {get; }

    public string Print()
    {
        var parent = Parent != null ? Parent.Name : string.Empty;
        return $"{Name} (dir, parent={parent}, size={Size})";
    }
}