public record Movement(int repetitions, char source, char target);

public class Input {

    public readonly Dictionary<char, Stack<char>> Stacks;
    public readonly IEnumerable<Movement> Movement;

    public Input(Dictionary<char, Stack<char>> stacks, IEnumerable<Movement> movement)
    {
        Stacks = stacks;
        Movement = movement;
    }

}

public static class InputParser
{

    public static Input Parse()
    {
        var lines = File.ReadAllLines("input.txt");
        var divider = Array.IndexOf(lines, String.Empty);

        var stacks = lines.Take(divider).ParseStacks();
        var movement = lines.Skip(divider + 1).ParseMovement();

        return new Input(stacks, movement);
    }

    private static Dictionary<char, Stack<char>> ParseStacks(this IEnumerable<string> stackInput)
    {
        var stacks = new Dictionary<char, Stack<char>>();
        var stackInputArray = stackInput.ToArray();

        var numberLine = stackInputArray[stackInputArray.Length - 1];
        var numbers = numberLine
        .Split(" ")
        .Where(item => item != "")
        .Select(item => Convert.ToChar(item));

        foreach (var number in numbers)
        {
            var queue = new Stack<char>();

            for (int i = stackInputArray.Length - 2; i >= 0; i--)
            {
                var line = stackInputArray[i].ToCharArray();
                var numberIndex = Array.IndexOf(numberLine.ToCharArray(), number);
                if (numberIndex <= line.Length && line[numberIndex] != ' ')
                {
                    queue.Push(line[numberIndex]);
                }
            }

            stacks.Add(number, queue);
        }

        return stacks;
    }

    private static IEnumerable<Movement> ParseMovement(this IEnumerable<string> movementInput)
    {
        var movements = new List<Movement>();

        foreach (var move in movementInput)
        {
            var moveArray = move.Replace("move ", "").Replace("from ", "").Replace("to ", "")
            .Split(' ')
            .ToArray();

            movements.Add(new Movement(
                int.Parse(moveArray[0]),
            Convert.ToChar(moveArray[1]),
            Convert.ToChar(moveArray[2])));
        }

        return movements;
    }

}