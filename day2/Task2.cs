internal static class Task2
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
        var outcome = char.Parse(input[1]);

        var shape = GetShape(opponent, outcome);
        var shapeScore = GetShapeScore(shape);
        var playScore = GetPlayScore(opponent, shape);

        return shapeScore + playScore;
    }

    private static char GetShape(char opponent, char outcome)
    {
        var deltaOutcome = 0;

        switch (outcome)
        {
            case 'X':
                deltaOutcome = -1;
                break;
            case 'Z':
                deltaOutcome = 1;
                break;
            default:
                break;
        }

        int shape = opponent + 23 + deltaOutcome;

        if (shape == 91) shape = 88;
        if (shape == 87) shape = 90;

        return (char)shape;
    }

    private static int GetPlayScore(char opponent, char me)
    {
        return (((me - opponent - 1) % 3) * 3);
    }

    private static int GetShapeScore(char shape)
    {
        return shape - 87;
    }
}
