internal static class Task
{
    record struct ElfPair(int ElfOneStart, int ElfOneEnd, int ElfTwoStart, int ElfTwoEnd);

    internal static void Run()
    {
        var fullOverlaps = 0;
        var partialOverlaps = 0;

        foreach (var line in File.ReadAllLines("input.txt"))
        {
            if (line == null) throw new ArgumentNullException();
            var result = ParseLine(line);
            fullOverlaps = DoesFullyOverlap(result) ? fullOverlaps + 1 : fullOverlaps;
            partialOverlaps = DoesPartiallyOverlap(result) ? partialOverlaps + 1 : partialOverlaps;
        }

        Console.WriteLine($"# of full overlaps:\t{fullOverlaps}");
        Console.WriteLine($"# of partial overlaps:\t{partialOverlaps}");
    }

    private static ElfPair ParseLine(string line)
    {
        var elves = line.Split(',');
        var elfOne = elves[0].Split('-').Select(i => int.Parse(i)).ToArray();
        var elfTwo = elves[1].Split('-').Select(i => int.Parse(i)).ToArray();

        return new ElfPair(elfOne[0], elfOne[1], elfTwo[0], elfTwo[1]);
    }

    private static bool DoesFullyOverlap(ElfPair elfPair)
    {
        return ((elfPair.ElfOneStart <= elfPair.ElfTwoStart && elfPair.ElfOneEnd >= elfPair.ElfTwoEnd) 
        || (elfPair.ElfOneStart >= elfPair.ElfTwoStart && elfPair.ElfOneEnd <= elfPair.ElfTwoEnd));
    }

    private static bool DoesPartiallyOverlap(ElfPair elfPair)
    {
        return ((elfPair.ElfOneStart <= elfPair.ElfTwoStart && elfPair.ElfTwoStart <= elfPair.ElfOneEnd) 
        || (elfPair.ElfTwoStart <= elfPair.ElfOneStart && elfPair.ElfOneStart <= elfPair.ElfTwoEnd));
    }
}