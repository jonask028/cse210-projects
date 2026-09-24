using System;

class Program
{

    static void SayHello()
    {
        Console.WriteLine("Hello! I have some questions for you!");
    }

    static string GetName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    static int GetFavNum()
    {
        Console.Write("What is your favorite number? ");
        string faveNumString = Console.ReadLine();
        try
        {
            int faveNum = int.Parse(faveNumString);
            return faveNum;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {faveNumString} is not a number!");
            throw new FormatException($"Error Message: {ex.Message}");
        }
    }

    static int GetBirthYear(out int birthYear)
    {
        Console.Write("What is your birth year? ");
        string birthYearString = Console.ReadLine();
        try
        {
            birthYear = int.Parse(birthYearString);
            return birthYear;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {birthYearString} is not a number!");
            throw new FormatException($"Error Message: {ex.Message}");
        }
    }

    static int SquareNum(int num)
    {
        return num * num;
    }

    static void DisplayResult(string name, int squaredNum, int birthYear)
    {
        int age = DateTime.Now.Year - birthYear;
        Console.WriteLine($"{name} the square of your favorite number is {squaredNum}");
        Console.WriteLine($"{name}, you will turn {age} this year!");
    }

    static void Main(string[] args)
    {
        int birthYear;
        SayHello();
        string name = GetName();
        int faveNum = GetFavNum();
        birthYear = GetBirthYear(out birthYear);
        int squaredNum = SquareNum(faveNum);
        DisplayResult(name, squaredNum, birthYear);
    }
}