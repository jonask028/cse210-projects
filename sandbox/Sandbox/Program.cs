using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Bonjour tout le monde!");

        // bool done = false;

        // while (!done)
        // {
        //     Console.Write("Are we done? (y/N)");
        //     string input = Console.ReadLine();
        //     if (input.Equals("y"))
        //         done = true;
        //     else
        //         continue;

        // }

        // bool done;

        // do
        // {
        //     Console.Write("Are we done? (y/N)");
        //     string input = Console.ReadLine();
        //     if (input.ToLower().Equals("y"))
        //         done = true;
        //     else
        //         done = false;
        // } while (!done);

        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine(i);
        // }

        List<string> itemList = ["Betty", "And", "The", "Jets"];
        itemList.Prepend("Buh");

        foreach (string item in itemList)
            Console.WriteLine(item);

    }
}