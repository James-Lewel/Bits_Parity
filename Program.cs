using Bits_Parity;

while (true)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("a. Determine Parity of a bit set");
    Console.WriteLine("b. Find BCC of a block of character bits");
    Console.WriteLine("c. Check for errors in Block Character Bits and its BCC");
    Console.WriteLine("d. Find BCC with Parity");
    Console.WriteLine("e. Quit");

    char choice = Console.ReadKey().KeyChar;
    Console.WriteLine();

    if (char.ToLower(choice) == 'e')
    {
        Console.WriteLine("Exiting the program...");
        break;
    }

    switch (char.ToLower(choice))
    {
        case 'a':
            string bitSet = Helper.GetBinaryInput("Enter a set of bits:");
            string parityOption = Helper.GetParityOption();
            Console.WriteLine("\nChecking if the bit set has the selected parity:");
            Console.WriteLine($"Input bit set: {bitSet}");
            string parityResult = Helper.GetSpecificParity(bitSet, parityOption);
            Console.WriteLine($"Parity: {parityResult}");
            break;

        case 'b':
            string[] blockOfBits = Helper.GetBlockOfBits();
            Console.WriteLine("\nFinding Block Character Check (BCC):");
            string bcc = Helper.GetBCC(blockOfBits);
            Console.WriteLine($"Block of Character Bits:");
            foreach (var line in blockOfBits)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"BCC: {bcc}");
            break;

        case 'c':
            string[] blockToCheck = Helper.GetBlockOfBits();
            string bccToCheck = Helper.GetBinaryInput("Enter the BCC to check:");
            bool hasError = Helper.CheckError(blockToCheck, bccToCheck);
            Console.WriteLine($"Does the block of character bits have an error? {hasError}");
            break;

        case 'd':
            string blockForBCCWithParity = Helper.GetBinaryInput("\nEnter a block of character bits to find its BCC with parity:");
            Console.WriteLine("\nFinding BCC through LRC, EVEN-set, ODD-set parity bits, and BCC parity:");
            string bccWithParity = Helper.GetBCCWithParity(blockForBCCWithParity);
            Console.WriteLine($"BCC with Parity: {bccWithParity}");
            break;

        default:
            Console.WriteLine("Invalid option! Please choose a valid option or type 'e' to exit.");
            break;
    }

    Console.WriteLine("Press \"Enter\" to clear screen");
    Console.ReadLine();
    Console.Clear();
}
