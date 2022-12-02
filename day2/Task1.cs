internal static class Task1
{

    internal static void Run()
    {

        var totalScore = 0;

        foreach (var line in File.ReadAllLines("input.txt"))
        {
            if (line == null) throw new ArgumentNullException();
            totalScore += CalculateScore(line.Split(' '));
        }

        Console.WriteLine(totalScore);
    }

    private static int CalculateScore(string[] input)
    {
        var opponent = char.Parse(input[0]);
        var me = char.Parse(input[1]);

        var shapeScore = GetShapeScore(me);
        var playScore = GetPlayScore(opponent, me);

        return shapeScore + playScore;
    }

    private static int GetPlayScore(char opponent, char me)
    {
        switch ((me - opponent) % 3)
        {
            case 2:
                return 3;
            case 1:
                return 0;
            case 0:
            default:
                return 6;
        }
    }

    private static int GetShapeScore(char shape)
    {
        return shape - 87;
    }
}
