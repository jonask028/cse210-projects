class BreathingActivity(string name, string description, string endMessage) : Activity(name, description, endMessage)
{
  private bool _breatheIn = true;

  public void Breathe()
  {
    SetDuration();
    SetEndTime();
    DateTime endTime = GetEndTime();
    RunSpinnerMessage("Get ready . . . ", 4);
    Console.Write("\b" + " " + "\n\n");
    do
    {
      if (_breatheIn)
      {
        RunCountdownMessage("Breathe In . . . ", 4);
        Console.Write("\b" + " " + "\n");
      }
      else
      {
        RunCountdownMessage("Breathe Out . . . ", 6);
        Console.Write("\b" + " " + "\n\n");
      }
      _breatheIn = !_breatheIn;
    } while (DateTime.Now <= endTime);
    string endMessage = GetEndMessage();
    RunSpinnerMessage(endMessage, 4);
    DisplayCompletionMessage();
  }
}