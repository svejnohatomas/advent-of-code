namespace AdventOfCode._2021._12._03
{
    internal class BinaryConverter
    {
        public static uint ConvertToUInt(string binaryValues)
        {
            int[] arr = binaryValues.ToCharArray().Select(x => x == '0' ? 0 : 1).ToArray();
            return ConvertToUInt(arr);
        }

        public static uint ConvertToUInt(int[] binaryValues)
        {
            double output = 0;

            for (int i = binaryValues.Length - 1; i >= 0; i--)
            {
                output += Math.Pow(2, binaryValues.Length - i - 1) * binaryValues[i];
            }

            return Convert.ToUInt32(output);
        }
    }
}
