class JournalEntry
{
  public DateTime _date;
  public string _prompt;
  public string _content;

  public void DisplayEntry()
  {
    Console.Write(_date);
    Console.WriteLine(_prompt);
    Console.WriteLine(_content);
  }

  public void CreateEntry()
  {
    string[] prompts = ["How was your day?", "Did you learn anything new today?", "How did God's hand touch your life today?", "Is there anything you would have done different today?", "What are some things you did well today?", "What was your favorite part of the day?"];
    Random rand = new();
    int randomIndex = rand.Next(0, prompts.Length);
    _prompt = prompts[randomIndex];
    Console.WriteLine($"{_prompt}");
    string content = Console.ReadLine();
    _date = DateTime.Now;
    _content = content;
  }

  public void SaveEntry(StreamWriter streamWriter)
  {
    // Console.WriteLine($"{_date}:#{_prompt}#{_content}");
    streamWriter.WriteLine($"{_date}:#{_prompt}#{_content}");
  }

}