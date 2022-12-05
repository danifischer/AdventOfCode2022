internal static class Task
{
    record struct ElfPair(int ElfOneStart, int ElfOneEnd, int ElfTwoStart, int ElfTwoEnd);

    internal static void Run()
    {
        var lines = File.ReadAllLines("input.txt")
            .Select(line => line.Parse())
            .ToArray();

        Console.WriteLine($"# of full overlaps:\t{lines.Count(line => line.DoesFullyOverlap())}");
        Console.WriteLine($"# of partial overlaps:\t{lines.Count(line => line.DoesPartiallyOverlap())}");
    }

    private static ElfPair Parse(this string line)
    {
        var elves = line.Split(',');
        var elfOne = elves[0].Split('-').Select(i => int.Parse(i)).ToArray();
        var elfTwo = elves[1].Split('-').Select(i => int.Parse(i)).ToArray();

        return new ElfPair(elfOne[0], elfOne[1], elfTwo[0], elfTwo[1]);
    }

    private static bool DoesFullyOverlap(this ElfPair elfPair)
    {
        return ((elfPair.ElfOneStart <= elfPair.ElfTwoStart && elfPair.ElfOneEnd >= elfPair.ElfTwoEnd)
                || (elfPair.ElfOneStart >= elfPair.ElfTwoStart && elfPair.ElfOneEnd <= elfPair.ElfTwoEnd));
    }

    private static bool DoesPartiallyOverlap(this ElfPair elfPair)
    {
        return ((elfPair.ElfOneStart <= elfPair.ElfTwoStart && elfPair.ElfTwoStart <= elfPair.ElfOneEnd)
                || (elfPair.ElfTwoStart <= elfPair.ElfOneStart && elfPair.ElfOneStart <= elfPair.ElfTwoEnd));
    }
}