namespace Bits_Parity
{
    public class Helper
    {
        public static string GetBinaryInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (!IsBinary(input))
                {
                    Console.WriteLine("Invalid input! Please enter binary data (0s and 1s) only.");
                }
            } while (!IsBinary(input));
            return input;
        }

        public static bool IsBinary(string input)
        {
            return input.All(c => c == '0' || c == '1');
        }

        public static string GetParityOption()
        {
            string option;
            do
            {
                Console.WriteLine("Choose Parity:");
                Console.WriteLine("1. EVEN");
                Console.WriteLine("2. ODD");
                option = Console.ReadLine();
            } while (option != "1" && option != "2");

            return option;
        }

        public static string GetSpecificParity(string bitSet, string parityOption)
        {
            int count = bitSet.Count(bit => bit == '1');

            if ((count % 2 == 0 && parityOption == "1") || (count % 2 != 0 && parityOption == "2"))
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        public static string[] GetBlockOfBits()
        {
            Console.WriteLine("Enter the number of lines in the block:");
            if (!int.TryParse(Console.ReadLine(), out int lines))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return GetBlockOfBits();
            }

            Console.WriteLine("Enter the number of bits per line:");
            if (!int.TryParse(Console.ReadLine(), out int bits))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return GetBlockOfBits();
            }

            string[] block = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                block[i] = GetBinaryInput($"Enter line {i + 1} of {lines} (length: {bits}):");
                if (block[i].Length != bits)
                {
                    Console.WriteLine($"Invalid input! The line must have {bits} bits.");
                    i--;
                }
            }

            return block;
        }

        public static string GetBCC(string[] blockOfBits)
        {
            if (blockOfBits.Length == 0)
            {
                Console.WriteLine("Block of bits is empty!");
                return string.Empty;
            }

            string bcc = blockOfBits[0];

            for (int i = 1; i < blockOfBits.Length; i++)
            {
                bcc = CalculateXOR(bcc, blockOfBits[i]);
            }

            return bcc;
        }

        public static bool CheckError(string[] blockOfBits, string bcc)
        {
            string calculatedBCC = GetBCC(blockOfBits);
            return calculatedBCC != bcc;
        }

        public static string GetBCCWithParity(string blockOfBits)
        {
            List<int> bits = blockOfBits.Select(bit => int.Parse(bit.ToString())).ToList();
            int bcc = bits.Aggregate((x, y) => x ^ y);

            string lrc = Convert.ToString(bcc, 2).PadLeft(blockOfBits.Length, '0');
            string evenParity = bcc % 2 == 0 ? "0" : "1";
            string oddParity = bcc % 2 == 0 ? "1" : "0";

            return $"{blockOfBits}{evenParity}{oddParity}{lrc}";
        }

        public static string CalculateXOR(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                throw new InvalidOperationException("Strings must have equal lengths.");
            }

            char[] result = new char[str1.Length];
            for (int i = 0; i < str1.Length; i++)
            {
                result[i] = str1[i] == str2[i] ? '0' : '1';
            }

            return new string(result);
        }
    }
}
