using System;

class StringReplaceProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string containing consecutive zeroes followed by non-zero numbers:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());

        int zeroIndex = -1;
        int nonZeroIndex = -1;

        // Finding the index of the start of consecutive zeroes
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '0')
            {
                zeroIndex = i;
                break;
            }
        }

        // Finding the index of the start of the non-zero number
        for (int i = zeroIndex + 1; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]) && input[i] != '0')
            {
                nonZeroIndex = i;
                break;
            }
        }

        if (zeroIndex != -1 && nonZeroIndex != -1)
        {
            string part1 = input.Substring(0, zeroIndex);
            string part2 = input.Substring(zeroIndex, nonZeroIndex - zeroIndex);
            string part3 = input.Substring(nonZeroIndex);

            //Console.WriteLine($"Part 1: {part1}");
            //Console.WriteLine($"Part 2: {part2}");
            //Console.WriteLine($"Part 3: {part3}");

            for (int i = 0; i <= number-1; i++)
            {
                string result = $"{part1}{new string('0', i)}{part3}";
                Console.WriteLine(result);
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please make sure the input string contains consecutive zeroes followed by non-zero numbers.");
        }
    }
}
