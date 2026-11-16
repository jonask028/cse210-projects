class EternalGoal(string name, string description, double points) : BaseGoal(name, description, points, "eternal")
{
  private int _numCompletions = 0;

  public override double CompleteGoal()
  {
    _numCompletions += 1;
    return _points;
  }

  public override string GetDisplayString()
  {
    return $"Completed {_numCompletions} times - {base.GetDisplayString()}";
  }

  public override string GetSaveString()
  {
    return $"{base.GetSaveString()}###{_numCompletions}";
  }

  public override double GetScore()
  {
    return _numCompletions * _points;
  }

  public override int GetCompleted()
  {
    return _numCompletions;
  }
}