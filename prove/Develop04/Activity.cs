class Activity
{
  private readonly string _name;
  private readonly string _description;
  private DateTime _endTime;
  private readonly string _endMessage;
  private int _duration;

  public Activity(string name, string description, string endMessage)
  {
    _name = name;
    _description = description;
    _endMessage = endMessage;
  }

  public void DisplayInfo()
  {
    Console.Clear();
    Console.WriteLine($"Welcome to the {_name} activity!");
    Console.WriteLine($"{_description}\n");
  }

  public void RunSpinnerMessage(string message, int seconds)
  {
    Console.CursorVisible = false;
    // DateTime now = DateTime.Now;
    DateTime endTime = DateTime.Now.AddSeconds(seconds);
    Console.WriteLine($"\n{message}");

    // for(int i = 0; i < seconds; i++)
    while (DateTime.Now < endTime)
    {
      Console.Write("-");
      Thread.Sleep(400);
      Console.Write("\b");
      Console.Write("\\");
      Thread.Sleep(400);
      Console.Write("\b");
      Console.Write("|");
      Thread.Sleep(400);
      Console.Write("\b");
      Console.Write("/");
      Thread.Sleep(400);
      Console.Write("\b");
    }
    Console.Write(" ");
    Console.CursorVisible = true;
  }

  public void SetDuration()
  {
    Console.Write("Enter how long you want to do this activity for, in seconds: ");
    string durationStr = Console.ReadLine();
    if (!int.TryParse(durationStr, out int duration))
    {
      Console.WriteLine("Duration must be an integer");
      SetDuration();
    }
    else
    {
      _duration = duration;
    }
  }

  public string GetEndMessage()
  {
    return _endMessage;
  }

  public int GetDuration()
  {
    return _duration;
  }

  public void SetEndTime()
  {
    _endTime = DateTime.Now.AddSeconds(_duration + 4);
  }

  public DateTime GetEndTime()
  {
    return _endTime;
  }

  public void Pause(int seconds)
  {
    Thread.Sleep(seconds * 1000);
  }

  public void RunCountdownMessage(string message, int seconds)
  {
    Console.CursorVisible = false;
    for (int i = seconds; i > 0; i--)
    {
      if (i == seconds)
      {
        Console.Write($"{message} {i}");
        Pause(1);
      }
      else
      {
        Console.Write("\b");
        Console.Write(i);
        Pause(1);
      }
    }
    Console.CursorVisible = true;
  }

  public void DisplayCompletionMessage()
  {
    RunSpinnerMessage($"You have completed another {_duration} seconds of the {_name} Activity", 4);
  }
}