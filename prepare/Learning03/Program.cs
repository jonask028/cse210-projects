using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating Fractions");
        Fraction fraction1 = new();
        Fraction fraction2 = new(6);
        Fraction fraction3 = new(6, 7);
        Console.WriteLine($"{fraction1.GetFractionString()}, {fraction2.GetFractionString()}, {fraction3.GetFractionString()}");


        for (int i = 0; i < 20; i++)
        {
            Random rand = new();
            int top = rand.Next(1, 100);
            int bottom = rand.Next(1, 100);
            Fraction randFraction = new();
            randFraction.SetTop(top);
            randFraction.SetBottom(bottom);
            Console.WriteLine($"Fraction {i}: {randFraction.GetFractionString()} Number: {randFraction.GetDecimalValue()}");
        }
    }
}