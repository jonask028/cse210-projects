class GoalList()
{
  private List<BaseGoal> _goals = [];
  private double _numGoalsCompleted = 0;


  public void AddGoal(BaseGoal goal)
  {
    _goals.Add(goal);
  }
  public void SaveGoals(string filename)
  {
    StreamWriter _outputFile = new($"../../../goals/{filename}.txt");
    foreach (BaseGoal goal in _goals)
    {
      _outputFile.WriteLine(goal.GetSaveString());
    }
  }

  public void LoadGoals(string filename)
  {
    string[] lines = File.ReadAllLines($"../../../{filename}.txt");
    foreach (string line in lines)
    {
      string[] goalDetails = line.Split("###");
      string goalType = goalDetails[0];
      if (goalDetails[1..^1] is [string name, string description, string pointString])
      {
        if (!double.TryParse(pointString, out double points))
        {
          throw new ArgumentException(message: "Points are not type double");
        }
        switch (goalType)
        {
          case "simple":
            SimpleGoal newSimpleGoal = new(name, description, points);
            break;
          case "eternal":
            SimpleGoal newEternalGoal = new(name, description, points);
            break;
          case "checklist":
            SimpleGoal newChecklistGoal = new(name, description, points);
            break;

        }
      }
    }
  }

  public List<BaseGoal> GetGoals()
  {
    return _goals;
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
      completedGoals.Add(goalCompletion > 0 ? goal : null);
      _numGoalsCompleted += goalCompletion;
    }
    return completedGoals;
  }

}