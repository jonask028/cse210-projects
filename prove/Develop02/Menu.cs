class Menu
{
  public int ProcessMenu()
  {
    bool done = false;

    do
    {
      Console.WriteLine("Welcome to the Journal Program.");
      Console.WriteLine("Create, Display, Save, and Read Journal Entries");
      Console.WriteLine(" 1. Create Entry");
      Console.WriteLine(" 2. Display Entry");
      Console.WriteLine(" 3. Save Entry");
      Console.WriteLine(" 4. Read Entry");
      Console.WriteLine("Q to quit");
      Console.Write("> ");

      string input = Console.ReadLine();
      if (!int.TryParse(input, out int option))
      {
        if (input.ToUpper().Equals("Q"))
        {
          done = true;
        }
        else
        {
          Console.WriteLine($"{input} is not a valid response");
        }
      }
      switch (option)
      {
        case 1:
          Console.WriteLine("Create");
          break;
        case 2:
          Console.WriteLine("Display");
          break;
        case 3:
          Console.WriteLine("Save");
          break;
        case 4:
          Console.WriteLine("Read");
          break;
      }

    } while (!done);

    return 1;
  }
}