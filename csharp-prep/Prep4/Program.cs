using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> nums = [];
        int userNum;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out userNum))
            {
                Console.WriteLine($"{input} is not a number!");
            }
            nums.Add(userNum);
        } while (userNum != 0);
        nums.Remove(0);
        int sumOfNums = 0;
        foreach (int num in nums)
        {
            sumOfNums += num;
        }
        float averageNum = sumOfNums / (float)nums.Count;
        int largestNum = nums.Max();
        int smallestPosNum = largestNum;
        foreach (int num in nums)
        {
            if (num < largestNum)
            {
                smallestPosNum = num;
            }
        }
        Console.WriteLine($"Sum: {sumOfNums}");
        Console.WriteLine($"Average: {averageNum}");
        Console.WriteLine($"Largest Number: {largestNum}");
        Console.WriteLine($"Smallest Positive Number: {smallestPosNum}");
        nums.Sort();
        Console.WriteLine("The Sorted List is:");
        foreach (int item in nums)
        {
            Console.WriteLine(item);
        }
    }
}