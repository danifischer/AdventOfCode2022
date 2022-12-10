var input = File.ReadAllLines("input.txt");

var inputArray = TransformInput(i => int.Parse(i.ToString()), input);
var inputMask = TransformInput(i => 1, input);

Task1(inputArray, inputMask);
Task2(inputArray, inputMask);

void Task1(int[][] inputArray, int[][] inputMask)
{

    var lastLeft = -1;
    var lastRight = -1;

    for (int y = 0; y < inputArray.Length; y++)
    {
        var lastTop = -1;
        var lastBottom = -1;

        for (int x = 0; x < inputArray[y].Length; x++)
        {
            if (lastLeft < inputArray[x][y])
            {
                lastLeft = inputArray[x][y];
                inputMask[x][y] += 1;
            }
            if (lastRight < inputArray[inputArray[y].Length - 1 - x][y])
            {
                lastRight = inputArray[inputArray[y].Length - 1 - x][y];
                inputMask[inputArray[y].Length - 1 - x][y] += 1;
            }
            if (lastTop < inputArray[y][x])
            {
                lastTop = inputArray[y][x];
                inputMask[y][x] += 1;
            }
            if (lastBottom < inputArray[y][inputArray[y].Length - 1 - x])
            {
                lastBottom = inputArray[y][inputArray[y].Length - 1 - x];
                inputMask[y][inputArray[y].Length - 1 - x] += 1;
            }
        }

        lastLeft = -1;
        lastRight = -1;
    }

    PrintArray(inputMask);
    Console.WriteLine();
    Console.WriteLine(inputMask.SelectMany(i => i).Count(j => j > 0));
}

void Task2(int[][] inputArray, int[][] inputMask)
{
    var inputMaskL = TransformInput(i => 1, input);
    var inputMaskR = TransformInput(i => 1, input);
    var inputMaskT = TransformInput(i => 1, input);
    var inputMaskB = TransformInput(i => 1, input);

    for (int y = 0; y < inputArray.Length; y++)
    {
        for (int x = 0; x < inputArray[y].Length; x++)
        {
            var right = ExtractFront(inputArray[y], x);
            var left = ExtractBack(inputArray[y], x);

            SetViewDistance(inputArray, inputMask, x, y, right);
            SetViewDistance(inputArray, inputMask, x, y, left);
        }
    }

    for (int x = 0; x < inputArray[0].Length; x++)
    {
        var column = ExtractColumn(inputArray, x);
        for (int y = 0; y < column.Length; y++)
        {
            var bottom = ExtractFront(column, y);
            var top = ExtractBack(column, y);

            SetViewDistance(inputArray, inputMask, x, y, bottom);
            SetViewDistance(inputArray, inputMask, x, y, top);
        }
    }

    Console.WriteLine(inputMask.SelectMany(i => i).Max());
}

void SetViewDistance(int[][] inputArray, int[][] inputMask, int x, int y, int[] directionArray)
{
    var counter = 0;

    for (int i = 0; i < directionArray.Length; i++)
    {
        counter++;
        if (directionArray[i] >= inputArray[y][x])
        {
            break;
        }
    }

    if (counter > 0) inputMask[y][x] *= counter;
}

int[] ExtractColumn(int[][] input, int columnNumber)
{
    return input.Select(row => row[columnNumber]).ToArray();
}

int[][] TransformInput(Func<char, int> transformation, string[] input)
{
    var transformed = input
    .Select(i => i.ToCharArray())
        .Select(j => j.Select(k => transformation(k))
        .ToArray())
    .ToArray();

    return transformed;
}

void PrintArray(int[][] array)
{
    foreach (var subArray in array)
    {
        foreach (var value in subArray)
        {
            Console.Write("." + value);
        }
        Console.WriteLine();
    }
}

int[] ExtractFront(int[] input, int position)
{
    return input.Skip(position + 1).ToArray();
}

int[] ExtractBack(int[] input, int position)
{
    return input.Take(position).Reverse().ToArray();
}
