Task1(InputParser.Parse());
Task2(InputParser.Parse());

void Task1(Input input)
{
    foreach (var move in input.Movement)
    {
        for (int i = 0; i < move.repetitions; i++)
        {
            var item = input.Stacks[move.source].Pop();
            input.Stacks[move.target].Push(item);
        }
    }

    foreach (var stack in input.Stacks)
    {
        Console.Write(stack.Value.Peek());
    }
    Console.WriteLine();
}

void Task2(Input input)
{
    var tempStack = new Stack<char>();

    foreach (var move in input.Movement)
    {
        for (int i = 0; i < move.repetitions; i++)
        {
            var item = input.Stacks[move.source].Pop();
            tempStack.Push(item);
        }

        foreach (var item in tempStack)
        {
            input.Stacks[move.target].Push(item);
        }

        tempStack.Clear();
    }

    foreach (var stack in input.Stacks)
    {
        Console.Write(stack.Value.Peek());
    }
    Console.WriteLine();
}
