class GoalList()
{
  private List<BaseGoal> _goals = [];
  private double _numGoalsCompleted = 0;


  public void AddGoal(BaseGoal goal)
  {
    _goals.Add(goal);
  }

  public void CompleteGoal(int goalIndex)
  {
    BaseGoal goal = _goals[goalIndex];
    goal.CompleteGoal();
  }
  public void SaveGoals(string filename)
  {
    using StreamWriter _outputFile = new($"./goals/{filename}.txt");
    foreach (BaseGoal goal in _goals)
    {
      string saveString = goal.GetSaveString();
      _outputFile.WriteLine(saveString);
    }
  }

  public void LoadGoals(string filename)
  {
    _goals = [];
    string[] lines = File.ReadAllLines($"./goals/{filename}.txt");
    foreach (string line in lines)
    {
      string[] goalDetails = line.Split("###");
      string goalType = goalDetails[0];
      switch (goalType)
      {
        case "simple":
          if (goalDetails[1..^0] is [string simpleName, string simpleDescription, string simplePointString, string completedString])
          {
            double simplePoints = Program.ParseDouble(simplePointString);
            bool completed = completedString == "True";
            SimpleGoal newSimpleGoal = new(simpleName, simpleDescription, simplePoints, completed);
            if (completed)
            {
              newSimpleGoal.CompleteGoal();
            }
            _goals.Add(newSimpleGoal);
          }
          break;
        case "eternal":
          if (goalDetails[1..^0] is [string eternalName, string eternalDescription, string eternalPointString, string eternalNumCompletionString])
          {
            double eternalPoints = Program.ParseDouble(eternalPointString);
            int eternalNumCompletions = Program.ParseInt(eternalNumCompletionString);
            EternalGoal newEternalGoal = new(eternalName, eternalDescription, eternalPoints);
            for (int i = 0; i < eternalNumCompletions; i++)
            {
              newEternalGoal.CompleteGoal();
            }
            _goals.Add(newEternalGoal);
          }
          break;
        case "checklist":
          if (goalDetails[1..^0] is [string checklistName, string checklistDescription, string checklistPointString, string checklistRequiredCompletionString, string checklistCurrentCompletionString])
          {
            double checklistPoints = Program.ParseDouble(checklistPointString);
            int checklistRequiredCompletions = Program.ParseInt(checklistRequiredCompletionString);
            int checklistCurrentCompetions = Program.ParseInt(checklistCurrentCompletionString);
            ChecklistGoal newChecklistGoal = new(checklistName, checklistDescription, checklistPoints, checklistRequiredCompletions);
            for (int i = 0; i < checklistCurrentCompetions; i++)
            {
              newChecklistGoal.CompleteGoal();
            }
            _goals.Add(newChecklistGoal);
          }
          break;
      }
    }
  }

  public List<BaseGoal> GetGoals()
  {
    return _goals;
  }
  public void DisplayGoals(bool completed = false)
  {
    if (!completed)
    {

      foreach (BaseGoal goal in _goals)
      {
        int goalNumber = _goals.IndexOf(goal) + 1;
        Console.WriteLine($"{goalNumber}: {goal.GetDisplayString()}");
      }
    }
    else
    {
      List<BaseGoal> completedGoals = GetCompleted();
      foreach (BaseGoal goal in completedGoals)
      {
        int goalNumber = _goals.IndexOf(goal) + 1;
        Console.WriteLine($"{goalNumber}. {goal.GetDisplayString()}");
      }
    }
  }

  public double GetScore()
  {
    double score = 0.0;
    foreach (BaseGoal goal in _goals)
    {
      score += goal.GetScore();
    }
    return score;
  }

  public double GetNumCompleted()
  {
    return _numGoalsCompleted;
  }

  public List<BaseGoal> GetCompleted()
  {
    List<BaseGoal> completedGoals = [];
    foreach (BaseGoal goal in _goals)
    {
      double goalCompletion = goal.GetCompleted();
      if (goalCompletion > 0)
      {
        completedGoals.Add(goal);
      }
      _numGoalsCompleted += goalCompletion;
    }
    return completedGoals;
  }

}