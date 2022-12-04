internal class Task1
{

    internal static void Run()
    {
        var score = 0;

        foreach (var line in File.ReadAllLines("input.txt"))
        {
            if (line == null) throw new ArgumentNullException();
            var left = line.Substring(0, line.Length / 2);
            var right = line.Substring(line.Length / 2);

            var duplicate = FindDuplicate(left, right);
            score += GetScore(duplicate);
        }

        Console.WriteLine(score);
    }

    private static char FindDuplicate(string left, string right)
    {
        foreach (var character in left)
        {
            if (right.Contains(character))
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