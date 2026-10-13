class Journal
{
  public List<JournalEntry> _entries;

  public void Display()
  {
    foreach (JournalEntry entry in _entries)
    {
      Console.WriteLine($"\n{entry._date}: {entry._prompt}");
      Console.WriteLine($"{entry._content}\n");
    }
  }

  public void CreateJournal()
  {
    _entries = [];
  }

  public void AddEntry(JournalEntry entry)
  {
    entry.CreateEntry();
    _entries.Add(entry);
  }

  public void SaveJournal()
  {
    Console.WriteLine("Enter a filename for your journal");
    string filename = Console.ReadLine();
    using StreamWriter outputFile = new(filename);
    foreach (JournalEntry entry in _entries)
    {
      entry.SaveEntry(outputFile);
    }
  }
}