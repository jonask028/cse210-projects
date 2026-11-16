using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");

        SimpleGoal newSimpleGoal = new("Go to Class", "Get to your CSE210 class on time!", 100);
        newSimpleGoal.DisplayGoal();
        newSimpleGoal.CompleteGoal();
        newSimpleGoal.DisplayGoal();
    }
}