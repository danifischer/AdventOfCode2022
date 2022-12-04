internal class Task2
{
    internal static void Run()
    {
        var score = 0;
        var counter = 0;
        var lines = File.ReadAllLines("input.txt");
        var currentLines = lines.Skip(counter).Take(3);

        while (currentLines.Count() == 3)
        {
            var importantItem = FindImportantItem(currentLines.ToArray());
            score += GetScore(importantItem);

            counter += 3;
            currentLines = lines.Skip(counter).Take(3);
        }

        Console.WriteLine(score);
    }

    private static char FindImportantItem(string[] input)
    {
        foreach (var character in input[0])
        {
            if (input[1].Count(c => c == character) > 0 
            && input[2].Count(c => c == character) > 0)
            {
                return character;
            }
        }
        throw new Exception("should not happen");
    }

    private static int GetScore(char input)
    {
        if (input >= 97)
        {
            return input - 96;
        }
        return input - 38;
    }
}