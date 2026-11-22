using System;

class Program
{
    static void Main(string[] args)
    {
        Menu newMenu = new();
        newMenu.ProcessMainMenu();
    }

    public static int ParseInt(string intString)
    {
        if (!int.TryParse(intString, out int num))
        {
            throw new ArgumentException(message: "Required completions is not type int");
        }
        return num;
    }

    public static double ParseDouble(string doubleString)
    {
        if (!double.TryParse(doubleString, out double num))
        {
            throw new ArgumentException(message: "Required completions is not type double");
        }
        return num;
    }
}