class Menu
{
  public int ProcessMenu()
  {
    bool done = false;
    Scripture scripture = null;
    do
    {
      Console.WriteLine("Welcome to the Scripture Memorizer Program.");
      Console.WriteLine("Create, Display, Save, and Memorize Scriptures");
      Console.WriteLine(" 1. Create Scripture");
      Console.WriteLine(" 2. Memorize Scripture");
      Console.WriteLine(" 3. Save Scripture");
      Console.WriteLine(" 4. Read Scripture");
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
          Console.WriteLine("Enter Book");
          string bookName = Console.ReadLine();
          Console.WriteLine("Enter Chapter");
          int chapter = int.Parse(Console.ReadLine());
          Console.WriteLine("Enter Starting Verse");
          int startVerse = int.Parse(Console.ReadLine());
          Console.WriteLine("Enter Ending Verse (If same as start verse hit enter)");
          string endVerseString = Console.ReadLine();
          Console.WriteLine("Enter Text Including Verse Numbers");
          string text = Console.ReadLine();
          if (int.TryParse(endVerseString, out int endVerse))
          {
            Console.WriteLine($"Endverse found: {endVerse}");
            scripture = new(bookName, chapter, startVerse, endVerse, text);
            break;
          }
          scripture = new(bookName, chapter, startVerse, text);
          break;
        case 2:
          Console.WriteLine("Memorize");
          scripture.DisplayScripture();
          break;
        case 3:
          Console.WriteLine("Save");
          scripture.SaveScripture();
          break;
        case 4:
          Console.WriteLine("Load");
          scripture = LoadScripture();
          break;
      }

    } while (!done);

    return 1;
  }

  public Scripture LoadScripture()
  {
    Scripture loadScripture;
    Console.WriteLine("Enter the reference for your scripture");
    string referenceString = Console.ReadLine();
    string[] lines = File.ReadAllLines($"../../../scriptures/{referenceString}.txt");
    string text = lines[1];
    string[] referenceList = lines[0].Split("#");
    string bookName = referenceList[0];
    int chapter = int.Parse(referenceList[1]);
    int startVerse = int.Parse(referenceList[2]);
    if (referenceList.Length > 3)
    {
      int endVerse = int.Parse(referenceList[3]);
      loadScripture = new(bookName, chapter, startVerse, endVerse, text);
    }
    else
    {
      loadScripture = new(bookName, chapter, startVerse, text);
    }

    return loadScripture;
  }

}