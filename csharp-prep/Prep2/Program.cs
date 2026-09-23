using System;

class Program
{
    static void Main(string[] args)
    {
        string letterGrade;
        string aOrAn = "a";
        string passingMessage;
        string[] passingGrades = ["A", "B", "C"];
        string gradeQuality;

        Console.Write("Enter a whole number from 0-100: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int grade))
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), $"{grade} not an integer between 0 and 100");
            throw new Exception($"{input} is not a whole number");
        }

        if (90 <= grade && grade <= 100)
        {
            letterGrade = "A";
            aOrAn = "an";
        }
        else if (80 <= grade && grade < 90)
            letterGrade = "B";
        else if (70 <= grade && grade < 80)
            letterGrade = "C";
        else if (60 <= grade && grade < 70)
            letterGrade = "D";
        else
            letterGrade = "F";

        if (grade % 10 < 3 && grade != 100 || grade < 67)
            gradeQuality = "-";
        else if (grade % 10 > 3 && grade % 10 < 7)
            gradeQuality = "";
        else
            gradeQuality = "+";

        if (passingGrades.Contains(letterGrade))
            passingMessage = "Congratulations!";
        else
            passingMessage = "Try harder next time!";

        Console.WriteLine($"You got {aOrAn} {letterGrade}{gradeQuality}, {passingMessage}");

    }
}