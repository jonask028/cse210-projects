abstract class BaseGoal(string name, string description, double points, string goalType)
{
  protected readonly string _name = name;
  protected readonly string _description = description;
  protected readonly double _points = points;
  protected readonly string _goalType = goalType;

  public abstract double CompleteGoal();
  public abstract double GetScore();

  public abstract double GetCompleted();

  public virtual string GetDisplayString()
  {
    return $"{_name}: {_description} | Point Value: {_points}";
  }

  public virtual string GetSaveString()
  {
    return $"{_goalType}###{_name}###{_description}###{_points}";
  }

}