// See https://aka.ms/new-console-template for more information

int lineId = 0;
int counterPart1 = 0;
int counterPart2 = 0;

int previousDepth = 0;

int previousWindowSum = 0;
int[] window = new int[3];

using (StreamReader sr = new StreamReader("./input.txt"))
{
    if (!sr.EndOfStream)
    {
        var line = sr.ReadLine();
        if (line != null)
        {
            if (int.TryParse(line, out int first))
            {
                previousDepth = first;
                window[2] = first;
            }
        }
    }

    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine();
        if (line != null)
        {
            lineId++;

            if (int.TryParse(line, out int currentDepth))
            {
                // Part 1
                if (currentDepth > previousDepth)
                {
                    counterPart1++;
                }

                previousDepth = currentDepth;

                // Part 2

                for (int i = 0; i < window.Length - 1; i++)
                {
                    window[i] = window[i + 1];
                }
                window[window.Length - 1] = currentDepth;

                if (lineId >= 2)
                {
                    var currentWindowSum = window.Sum(x => x);
                    if (lineId > 2 && currentWindowSum > previousWindowSum)
                    {
                        counterPart2++;
                    }
                    previousWindowSum = currentWindowSum;
                }
            }
        }
    }
}

Console.WriteLine($"" +
    $"Author: Tomas Svejnoha\n" +
    $"Date: 2021-12-01\n\n" +
    $"Part 1:\n" +
    $"The number of measurements that are larger than the previous one: {counterPart1}\n\n" +
    $"Part 2:\n" +
    $"The number of sums of three-measurement sliding window that are larger than the previous one: {counterPart2}\n");

Console.Write("Press enter to exit...");
Console.ReadLine();