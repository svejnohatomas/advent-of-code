// See https://aka.ms/new-console-template for more information

LinkedList<byte> linkedList;

using (var sr = new StreamReader("./input.txt"))
{
    var line = sr.ReadLine();
    if (line == null)
        return;

    linkedList = new LinkedList<byte>(line.Split(',').Select(x => byte.Parse(x)));
}

int days;
string input;

do
{
    Console.Write("Enter number of days: ");
    input = (Console.ReadLine() ?? "").Trim();
} while (!int.TryParse(input, out days));

for (int d = 0; d < days; d++)
{
    int numberOfNewLanternfish = 0;
    int queueCount = linkedList.Count;

    for (int i = 0; i < queueCount; i++)
    {
        var item = linkedList.First;
        linkedList.RemoveFirst();

        if (item.Value <= 0)
        {
            // Add new lanternfish
            numberOfNewLanternfish++;

            // Reset day count
            linkedList.AddLast(6);
        }
        else
        {
            linkedList.AddLast(--item.Value);
        }
    }

    for (int i = 0; i < numberOfNewLanternfish; i++)
    {
        linkedList.AddLast(8);
    }
}

Console.WriteLine($"\n" +
    $"Author: Tomas Svejnoha\n" +
    $"Date: 2021-12-06\n\n" +
    $"Number of lanternfish after {days} days: {linkedList.Count}\n\n");

Console.Write("Press enter to exit...");
Console.ReadLine();