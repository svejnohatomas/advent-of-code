namespace AdventOfCode._2021._12._04
{
    internal class BingoBoard
    {
        public BingoBoardCell[,] Cells { get; }
        public bool Bingo { get; private set; }

        public BingoBoard()
        {
            Cells = new BingoBoardCell[5, 5];

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Cells[x, y] = new BingoBoardCell();
                }
            }
        }

        public void Mark(int number)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (Cells[x, y].Value == number)
                    {
                        Cells[x, y].Marked = true;
                    }
                }
            }
        }

        public bool IsBingo()
        {
            for (int row = 0; row < 5; row++)
            {
                bool[] rowMarks = new bool[5];
                bool[] colMarks = new bool[5];

                for (int col = 0; col < 5; col++)
                {
                    rowMarks[col] = Cells[row, col].Marked;
                    colMarks[col] = Cells[col, row].Marked;
                }

                if (rowMarks.All(x => x) || colMarks.All(x => x))
                {
                    Bingo = true;
                    return true;
                }
            }

            return false;
        }

        public int Score(int lastDrawnNumber)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!Cells[i, j].Marked)
                    {
                        sum += Cells[i, j].Value;
                    }
                }
            }

            return sum * lastDrawnNumber;
        }

        internal class BingoBoardCell
        {
            public int Value { get; set; }
            public bool Marked { get; set; }
        }
    }
}
