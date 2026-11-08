class ListingActivity : Activity
{
  private readonly string[] _prompts = ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"];
  private List<string> _listedItems;

  public ListingActivity(string name, string description, string endMessage) : base(name, description, endMessage)
  {
    _listedItems = [];
  }

  public void List()
  {
    SetDuration();
    SetEndTime();

    DateTime endTime = GetEndTime();
    string endMessage = GetEndMessage();

    Random random = new();
    int randPromptIndex = random.Next(0, _prompts.Length);
    string prompt = _prompts[randPromptIndex];

    RunSpinnerMessage(prompt, 4);
    Console.Write("\b" + " " + "\n");
    RunSpinnerMessage("Get Ready . . .", 4);
    Console.Write("\b" + " " + "\n\n");

    do
    {
      Console.Write("> ");
      string listItem = Console.ReadLine();
      Console.Write("\n");

      _listedItems.Add(listItem);

    } while (DateTime.Now < endTime);

    Console.WriteLine($"You listed {_listedItems.Count} things!");
    RunSpinnerMessage(endMessage, 4);

    DisplayCompletionMessage();
  }
}