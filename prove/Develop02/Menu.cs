class Menu
{
  public int ProcessMenu()
  {
    bool done = false;
    Journal journal = null;

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
      if (journal == null)
      {
        journal = new();
        journal.CreateJournal();
      }
      switch (option)
      {
        case 1:
          Console.WriteLine("Write");
          JournalEntry newEntry = new();
          journal.AddEntry(newEntry);
          break;
        case 2:
          Console.WriteLine("Display");
          journal.Display();
          break;
        case 3:
          Console.WriteLine("Save");
          journal.SaveJournal();
          break;
        case 4:
          Console.WriteLine("Load");
          journal = LoadJournal();
          break;
      }

    } while (!done);

    return 1;
  }

  public Journal LoadJournal()
  {
    Console.WriteLine("Enter the filename for your journal");
    string filename = Console.ReadLine();
    string[] lines = File.ReadAllLines($"journals/{filename}");
    Journal loadJournal = new();
    loadJournal.CreateJournal();
    foreach (string line in lines)
    {
      Console.WriteLine(line);
      JournalEntry newEntry = new();
      string[] parts = line.Split("#");
      if (parts.Length == 3)
      {
        newEntry._date = DateTime.Parse(parts[0][0..^1]);
        newEntry._prompt = parts[1];
        newEntry._content = parts[2];
      }
      loadJournal._entries.Add(newEntry);
    }
    return loadJournal;
  }

}