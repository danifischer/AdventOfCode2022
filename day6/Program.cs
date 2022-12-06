var input = File.ReadAllText("input.txt").ToCharArray();

Task1(input);
Task2(input);

void Task1(char[] input)
{
    var buffer = new HashSet<char>();

    for (int i = 0; i < input.Length - 4; i++)
    {
        buffer.Clear();
        for (int j = i; j < i + 4; j++)
        {
            if (buffer.Contains(input[j]))
            {
                buffer.Clear();
                break;
            }
            buffer.Add(input[j]);

            if (buffer.Count() == 4)
            {
                Console.Write("Task 1: start-of-packet '" + string.Concat(buffer) + "' @ ");
                Console.WriteLine(j + 1);
                return;
            }
        }
    }
}

void Task2(char[] input)
{
    var buffer = new HashSet<char>();

    for (int i = 0; i < input.Length - 14; i++)
    {
        buffer.Clear();
        for (int j = i; j < i + 14; j++)
        {
            if (buffer.Contains(input[j]))
            {
                buffer.Clear();
                break;
            }
            buffer.Add(input[j]);

            if (buffer.Count() == 14)
            {
                Console.Write("Task 2: start-of-message '" + string.Concat(buffer) + "' @ ");
                Console.WriteLine(j + 1);
                return;
            }
        }
    }
}