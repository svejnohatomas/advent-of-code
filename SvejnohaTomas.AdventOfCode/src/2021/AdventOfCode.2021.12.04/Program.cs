// See https://aka.ms/new-console-template for more information

using AdventOfCode._2021._12._04;

int[] drawNumbers = null!;
LinkedList<BingoBoard> boards = new LinkedList<BingoBoard>();

using (var sr = new StreamReader("./input.txt"))
{
    if (!sr.EndOfStream)
    {
        var line = sr.ReadLine();
        if (line is null)
            return;

        drawNumbers = line.Split(',').Select(x => int.Parse(x)).ToArray();
    }

    while(!sr.EndOfStream)
    {
        // Discard separating line
        sr.ReadLine();

        var bingoBoard = new BingoBoard();

        for (int i = 0; i < 5; i++)
        {
            var line = sr.ReadLine()?.Trim().Replace("  ", " ");
            if (line is null)
                throw new Exception("Input parse error");

            var lineNumbers = line.Split(' ').Select(sr => int.Parse(sr)).ToArray();
            for (int j = 0; j < lineNumbers.Length; j++)
            {
                bingoBoard.Cells[i,j].Value = lineNumbers[j];
            }
        }

        boards.AddLast(bingoBoard);
    }
}

var scores = new List<int>(boards.Count);

for (int i = 0; i < drawNumbers.Length && boards.Any(x => !x.Bingo); i++)
{
    var number = drawNumbers[i];

    foreach (var item in boards)
    {
        if (item.Bingo)
            continue;

        item.Mark(number);

        if (item.IsBingo())
        {
            scores.Add(item.Score(number));
        }
    }
}

Console.WriteLine($"" +
    $"Author: Tomas Svejnoha\n" +
    $"Date: 2021-12-04\n\n" +
    $"Part 1:\n" +
    $"The score of the winning board is: {scores[0]}\n\n" +
    $"Part 2:\n" +
    $"The score of the loosing board is: {scores[scores.Count - 1]}\n");

Console.Write("Press enter to exit...");
Console.ReadLine();
