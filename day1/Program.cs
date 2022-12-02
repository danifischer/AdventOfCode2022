var calories = new List<int>();
var buffer = 0;

foreach (var line in File.ReadAllLines("input.txt"))
{
    if (line == null) throw new ArgumentNullException();
    if (line.Length == 0)
    {
        calories.Add(buffer);
        buffer = 0;
        continue;
    }
    buffer += int.Parse(line);
}

// Task 1
Console.WriteLine(calories.OrderByDescending(item => item).First());

// Task 2
Console.WriteLine(calories.OrderByDescending(item => item).Take(3).Sum());

