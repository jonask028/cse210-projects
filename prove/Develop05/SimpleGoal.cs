class SimpleGoal(string name, string description, double points) : BaseGoal(name, description, points, "simple")
{
  private bool _completed = false;

  public override double CompleteGoal()
  {
    _completed = true;
    return _points;
  }

  public override string GetDisplayString()
  {
    return $"[{(_completed ? "X" : " ")}] - {base.GetDisplayString()}";
  }

  public override string GetSaveString()
  {
    return $"{base.GetSaveString()}###{_completed}";
  }

  public override double GetScore()
  {
    return _completed ? _points : 0.0;
  }

  public override int GetCompleted()
  {
    return _completed ? 1 : 0;
  }
}