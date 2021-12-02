// See https://aka.ms/new-console-template for more information

int horizontalPositionPart1 = 0,
    depthPart1 = 0;
int horizontalPositionPart2 = 0,
    depthPart2 = 0,
    aim = 0;

using (var sr = new StreamReader("./input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine();
        if (line == null)
            continue;

        var lineArr = line.Split(' ');

        switch (lineArr[0])
        {
            case "forward":
                // Part 1
                horizontalPositionPart1 += int.Parse(lineArr[1]);

                // Part 2
                horizontalPositionPart2 += int.Parse(lineArr[1]);
                depthPart2 += aim * int.Parse(lineArr[1]);

                break;
            case "down":
                // Part 1
                depthPart1 += int.Parse(lineArr[1]);

                // Part 2
                aim += int.Parse(lineArr[1]);

                break;
            case "up":
                // Part 1
                depthPart1 -= int.Parse(lineArr[1]);

                // Part 2
                aim -= int.Parse(lineArr[1]);

                break;
            default:
                break;
        }
    }
}

Console.WriteLine($"" +
    $"Author: Tomas Svejnoha\n" +
    $"Date: 2021-12-02\n\n" +
    $"Part 1:\n" +
    $"Result of multiplying final horizontal position and final depth: {horizontalPositionPart1 * depthPart1}\n\n" +
    $"Part 2:\n" +
    $"Result of multiplying final horizontal position and final depth: {horizontalPositionPart2 * depthPart2}\n");

Console.Write("Press enter to exit...");
Console.ReadLine();