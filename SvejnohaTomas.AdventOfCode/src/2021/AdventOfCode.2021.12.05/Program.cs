// See https://aka.ms/new-console-template for more information

var list = new LinkedList<(ushort, ushort, ushort, ushort)>();

ushort minX = ushort.MaxValue;
ushort maxX = ushort.MinValue;

ushort minY = ushort.MaxValue;
ushort maxY = ushort.MinValue;

using (var sr = new StreamReader("./input.txt"))
{
    while (!sr.EndOfStream)
    {
        var line = sr.ReadLine();
        if (line == null)
            continue;

        var numbers = line.Replace(" -> ", ",").Split(',').Select(x => ushort.Parse(x)).ToArray();
        list.AddLast((numbers[0], numbers[1], numbers[2], numbers[3]));

        minX = Math.Min(minX, Math.Min(numbers[0], numbers[2]));
        maxX = Math.Max(maxX, Math.Max(numbers[0], numbers[2]));

        minY = Math.Min(minY, Math.Min(numbers[1], numbers[3]));
        maxY = Math.Max(maxY, Math.Max(numbers[1], numbers[3]));
    }
}

int sizeX = Convert.ToInt32(maxX) - Convert.ToInt32(minX) + 1;
int sizeY = Convert.ToInt32(maxY) - Convert.ToInt32(minY) + 1;

short[,] ventsArrPart1 = new short[sizeX, sizeY];
short[,] ventsArrPart2 = new short[sizeX, sizeY];

foreach ((ushort x1, ushort y1, ushort x2, ushort y2) item in list)
{
    // Part 1
    if (item.x1 == item.x2)
    {
        var minItemY = Math.Min(item.y1, item.y2);
        var maxItemY = Math.Max(item.y1, item.y2);

        for (int y = minItemY; y <= maxItemY; y++)
        {
            ventsArrPart1[item.x1 - minX, y - minY] += 1;
            ventsArrPart2[item.x1 - minX, y - minY] += 1;
        }
    }
    else if (item.y1 == item.y2)
    {
        var minItemX = Math.Min(item.x1, item.x2);
        var maxItemX = Math.Max(item.x1, item.x2);

        for (int x = minItemX; x <= maxItemX; x++)
        {
            ventsArrPart1[x - minX, item.y1 - minY] += 1;
            ventsArrPart2[x - minX, item.y1 - minY] += 1;
        }
    }
    // Part 2
    else
    {
        var incrementX = item.x1 < item.x2 ? 1 : -1;
        var incrementY = item.y1 < item.y2 ? 1 : -1;

        int x = item.x1;
        int y = item.y1;

        do
        {
            if (x == item.x2)
                incrementX = 0;
            if (y == item.y2)
                incrementY = 0;

            ventsArrPart2[x - minX, y - minY] += 1;

            x += incrementX;
            y += incrementY;

        } while (incrementX != 0 && incrementY != 0);
    }
}

int countPart1 = 0;
int countPart2 = 0;
for (int x = 0; x < sizeX; x++)
{
    for (int y = 0; y < sizeY; y++)
    {
        if (ventsArrPart1[x, y] >= 2)
        {
            countPart1++;
        }
        if (ventsArrPart2[x, y] >= 2)
        {
            countPart2++;
        }
    }
}

Console.WriteLine($"" +
    $"Author: Tomas Svejnoha\n" +
    $"Date: 2021-12-05\n\n" +
    $"Part 1:\n" +
    $"Number of overlapping points: {countPart1}\n\n" +
    $"Part 2:\n" +
    $"Number of overlapping points: {countPart2}\n");

Console.Write("Press enter to exit...");
Console.ReadLine();