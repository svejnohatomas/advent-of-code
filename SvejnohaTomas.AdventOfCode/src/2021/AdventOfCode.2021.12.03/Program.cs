// See https://aka.ms/new-console-template for more information

// Common
using AdventOfCode._2021._12._03;

int lineLength = 0;

// Part 1
int[] countZeros;
int[] countOnes;

int[] gammaFinalBinaryNumber;
int[] epsilonFinalBinaryNumber;

double gammaRate = 0;
double epsilonRate = 0;

// Part 2
LinkedList<string> oxygenGeneratorNumbers = new LinkedList<string>();
LinkedList<string> co2ScrubberNumbers = new LinkedList<string>();

uint oxygenGeneratorRating = 0;
uint co2ScrubberRating = 0;

using (var sr = new StreamReader("./input.txt"))
{
    if (!sr.EndOfStream)
    {
        var tline = sr.ReadLine();
        lineLength = (tline ?? "").Length;

        countZeros = new int[lineLength];
        countOnes = new int[lineLength];

        gammaFinalBinaryNumber = new int[lineLength];
        epsilonFinalBinaryNumber = new int[lineLength];

        sr.DiscardBufferedData();
        sr.BaseStream.Seek(0, SeekOrigin.Begin);

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            if (line == null)
                continue;

            for (int i = 0; i < lineLength; i++)
            {
                if (line[i] == '0')
                {
                    countZeros[i] += 1;
                }
                else
                {
                    countOnes[i] += 1;
                }
            }
        }

        for (int i = 0; i < gammaFinalBinaryNumber.Length; i++)
        {
            gammaFinalBinaryNumber[i] = countZeros[i] < countOnes[i] ? 1 : 0;
            epsilonFinalBinaryNumber[i] = countZeros[i] > countOnes[i] ? 1 : 0;
        }

        gammaRate = BinaryConverter.ConvertToUInt(gammaFinalBinaryNumber);
        epsilonRate = BinaryConverter.ConvertToUInt(epsilonFinalBinaryNumber);

        sr.DiscardBufferedData();
        sr.BaseStream.Seek(0, SeekOrigin.Begin);

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            if (line == null)
                continue;

            if (line[0] == (countZeros[0] < countOnes[0] ? '0' : '1'))
            {
                co2ScrubberNumbers.AddLast(line);
            }
            else
            {
                oxygenGeneratorNumbers.AddLast(line);
            }
        }

        // Oxygen - greater count
        for (int i = 1; i < lineLength && oxygenGeneratorNumbers.Count > 1; i++)
        {
            int countListZeroes = oxygenGeneratorNumbers.Count(x => x[i] == '0');

            oxygenGeneratorNumbers = countListZeroes > oxygenGeneratorNumbers.Count - countListZeroes
                    ? (new(oxygenGeneratorNumbers.Where(x => x[i] == '0')))
                    : (new(oxygenGeneratorNumbers.Where(x => x[i] == '1')));
        }

        // CO2 - lower count
        for (int i = 1; i < lineLength && co2ScrubberNumbers.Count > 1; i++)
        {
            int countListZeroes = co2ScrubberNumbers.Count(x => x[i] == '0');

            co2ScrubberNumbers = countListZeroes <= co2ScrubberNumbers.Count - countListZeroes
                ? (new(co2ScrubberNumbers.Where(x => x[i] == '0')))
                : (new(co2ScrubberNumbers.Where(x => x[i] == '1')));
        }

        oxygenGeneratorRating = BinaryConverter.ConvertToUInt(oxygenGeneratorNumbers.FirstOrDefault() ?? "");
        co2ScrubberRating = BinaryConverter.ConvertToUInt(co2ScrubberNumbers.LastOrDefault() ?? "");
    }
}

Console.WriteLine($"" +
    $"Author: Tomas Svejnoha\n" +
    $"Date: 2021-12-02\n\n" +
    $"Part 1:\n" +
    $"Power consumption of the submarine: {gammaRate * epsilonRate}\n\n" +
    $"Part 2:\n" +
    $"Life support rating of the submarine: {oxygenGeneratorRating * co2ScrubberRating}\n");

Console.Write("Press enter to exit...");
Console.ReadLine();