using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new("Jonas Kennedy", "Computer Science");
        Console.WriteLine(myAssignment.GetSummary());
        WritingAssignment myWritingAssignment = new("Chuck Hanks", "Persuasive Writing", "On the Ethics of the Oompa Loompas");
        Console.WriteLine(myWritingAssignment.GetWritingInfo());
        MathAssignment myMathAssignment = new("Carl Sagan", "Theoretical Physics", "12.7", "1-20");
        Console.WriteLine(myMathAssignment.GetHomeworkList());

    }
}