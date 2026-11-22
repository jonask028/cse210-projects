class Menu
{
  private GoalList _goalList = new();
  private List<BaseGoal> goals;
  private string _filename = null;
  public int ProcessMainMenu()
  {
    bool done = false;
    do
    {
      goals = _goalList.GetGoals();
      Console.Clear();
      Console.WriteLine("Welcome to the Eternal Quest Program");
      Console.WriteLine("Select an Option: ");
      Console.WriteLine(" 1. Create New Goal");
      Console.WriteLine(" 2. Save Goals");
      Console.WriteLine(" 3. Load Goals");
      Console.WriteLine(" 4. Display Goals Menu");
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
          ProcessGoalCreationMenu();
          break;
        case 2:
          _goalList.SaveGoals(GetFilename());
          RunSpinnerMessage($"Saving goals to {_filename}", 2);
          RunSpinnerMessage("Goals saved! Returning to main menu", 2);
          break;
        case 3:
          _goalList.LoadGoals(GetFilename());
          RunSpinnerMessage($"Loading goals from {_filename}", 2);
          RunSpinnerMessage("Goals loaded! Returning to main menu", 2);
          break;
        case 4:
          if (goals.Count < 1)
          {
            RunSpinnerMessage("No goals currently loaded, please create or load goals", 3);
            break;
          }
          ProcessGoalsMenu();
          break;
      }

    } while (!done);

    return 1;
  }

  private string GetFilename()
  {
    Console.Clear();
    Console.Write("Enter Filename: ");
    _filename = Console.ReadLine();
    return _filename;
  }

  public void ProcessGoalCreationMenu()
  {
    bool done = false;
    do
    {
      Console.WriteLine("Select Goal Type to Create: ");
      Console.WriteLine(" 1. Simple Goal");
      Console.WriteLine(" 2. Eternal Goal");
      Console.WriteLine(" 3. Checklist Goal");
      Console.WriteLine("Enter to return to main menu");
      Console.Write("> ");

      string input = Console.ReadLine();
      if (!int.TryParse(input, out int option))
      {
        if (input.ToUpper().Equals(""))
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
          Console.Clear();
          Console.Write("Enter goal name: ");
          string simpleName = Console.ReadLine();
          Console.Write("Enter goal description: ");
          string simpleDescription = Console.ReadLine();
          double simplePoints = GetGoalCreationPoints();
          SimpleGoal newSimpleGoal = new(simpleName, simpleDescription, simplePoints);
          _goalList.AddGoal(newSimpleGoal);
          break;
        case 2:
          Console.Clear();
          Console.Write("Enter goal name: ");
          string eternalName = Console.ReadLine();
          Console.Write("Enter goal description: ");
          string eternalDescription = Console.ReadLine();
          double eternalPoints = GetGoalCreationPoints();
          EternalGoal newEternalGoal = new(eternalName, eternalDescription, eternalPoints);
          _goalList.AddGoal(newEternalGoal);
          break;
        case 3:
          Console.Clear();
          Console.Write("Enter goal name: ");
          string checklistName = Console.ReadLine();
          Console.Write("Enter goal description: ");
          string checklistDescription = Console.ReadLine();
          double checklistPoints = GetGoalCreationPoints();
          int requiredCompletions = GetRequiredGoalNumber();
          ChecklistGoal newChecklistGoal = new(checklistName, checklistDescription, checklistPoints, requiredCompletions);
          _goalList.AddGoal(newChecklistGoal);
          break;
      }
    } while (!done);
  }

  public void ProcessGoalsMenu()
  {
    bool done = false;
    do
    {
      Console.Clear();
      _goalList.DisplayGoals();
      Console.WriteLine("Select Goal Action: ");
      Console.WriteLine(" 1. Complete Goal");
      Console.WriteLine(" 2. Show Completed Goals");
      Console.WriteLine(" 3. Show Score");
      Console.WriteLine("Enter to return to main menu");
      Console.Write("> ");

      string input = Console.ReadLine();
      if (!int.TryParse(input, out int option))
      {
        if (input.ToUpper().Equals(""))
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
          Console.Write("Enter number of goal to complete: ");
          string goalIdString = Console.ReadLine();
          int goalIndex = Program.ParseInt(goalIdString) - 1;
          _goalList.CompleteGoal(goalIndex);
          _goalList.SaveGoals(_filename);
          break;
        case 2:
          Console.Clear();
          _goalList.DisplayGoals(completed: true);
          Console.WriteLine($"You have completed {_goalList.GetNumCompleted():N2} goals");
          Console.WriteLine("Enter to continue");
          Console.ReadLine();
          break;
        case 3:
          Console.WriteLine($"Current Score: {_goalList.GetScore():N2}");
          Console.WriteLine("Enter to continue");
          Console.ReadLine();
          break;
      }
    } while (!done);
  }

  private static double GetGoalCreationPoints()
  {
    Console.Write("Enter goal points: ");
    string pointString = Console.ReadLine();
    if (!double.TryParse(pointString, out double points))
    {
      Console.WriteLine("Goal points must be a number");
      GetGoalCreationPoints();
    }
    return points;
  }

  private static int GetRequiredGoalNumber()
  {
    Console.Write("Enter desired number of completions: ");
    string requiredCompletionsString = Console.ReadLine();
    if (!int.TryParse(requiredCompletionsString, out int requiredGoalNumber))
    {
      Console.WriteLine("Desired goal completions must be a number");
      GetRequiredGoalNumber();
    }
    return requiredGoalNumber;
  }

  private static void RunSpinnerMessage(string message, int seconds)
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
}