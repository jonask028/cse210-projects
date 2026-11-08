class ReflectionActivity : Activity
{
  private string[] _prompts;
  private List<string> _questions;

  public ReflectionActivity(string name, string description, string endMessage) : base(name, description, endMessage)
  {
    _prompts = ["Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."];
    _questions = ["Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"];
  }

  public void Reflect()
  {
    SetDuration();
    SetEndTime();

    DateTime endTime = GetEndTime();
    string endMessage = GetEndMessage();
    List<string> questionsCopy = _questions;
    Random random = new();
    int randPromptIndex = random.Next(0, _prompts.Length);
    string prompt = _prompts[randPromptIndex];

    RunSpinnerMessage(prompt, 10);
    Console.Write("\b" + " " + "\n\n");
    RunSpinnerMessage("Get Ready . . .", 4);
    Console.Write("\b" + " " + "\n");

    do
    {

      int randQIndex = random.Next(0, questionsCopy.Count);
      string question = questionsCopy[randQIndex];
      questionsCopy.RemoveAt(randQIndex);

      RunSpinnerMessage(question, 10);
      Console.Write("\b" + " " + "\n\n");

      if (questionsCopy.Count == 0)
      {
        break;
      }

    } while (DateTime.Now < endTime.AddSeconds(10));

    RunSpinnerMessage(endMessage, 4);
    DisplayCompletionMessage();
  }
}