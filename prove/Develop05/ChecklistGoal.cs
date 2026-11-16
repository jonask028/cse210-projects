class ChecklistGoal(string name, string description, double points, int requiredCompletions) : BaseGoal(name, description, points, "checklist")
{
  private readonly int _requiredCompletions = requiredCompletions;
  private int _numCompletions;

  public override double CompleteGoal()
  {
    _numCompletions += 1;
    if (_numCompletions < _requiredCompletions)
    {
      return _points * 1.0 / (_requiredCompletions * 2.0);
    }
    else if (_numCompletions > _requiredCompletions)
    {
      return 0.0;
    }
    else
    {
      return _points / 2.0;
    }
  }

  public override string GetDisplayString()
  {
    return $"Completed {_numCompletions} of {_requiredCompletions} times - {base.GetDisplayString()}";
  }

  public override string GetSaveString()
  {
    return $"{base.GetSaveString()}###{_requiredCompletions}###{_numCompletions}";
  }

  public override double GetScore()
  {
    if (_numCompletions == 0)
    {
      return 0.0;
    }
    else if (_numCompletions < _requiredCompletions)
    {
      return _numCompletions * (_points / (_requiredCompletions * 2.0));
    }
    else
    {
      return _points;
    }
  }

  public override int GetCompleted()
  {
    return _numCompletions > 0 ? _numCompletions / _requiredCompletions : 0;
  }
}