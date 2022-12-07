internal class AocFile
{
    public AocFile(string name, long size, AocDirectory parent)
    {
        Name = name;
        Size = size;
        Parent = parent;
    }

    public string Name { get; }

    public long Size { get; }

    public AocDirectory Parent { get; }

    public string Print()
    {
        return $"{Name} (file, size={Size}, parent={Parent.Name})";
    }
}